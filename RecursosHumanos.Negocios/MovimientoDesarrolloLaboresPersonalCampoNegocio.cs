using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;

namespace RecursosHumanos.Negocios
{
    public class MovimientoDesarrolloLaboresPersonalCampoNegocio
    {

        public List<SJ_RHListarAsistenciaPersonalByPeriodoResult> ObtenerListadoListadoAsistenaPersonalCampo(string periodo, string desde, string hasta)
        {

            List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listado = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9800000;
                listado = Modelo.SJ_RHListarAsistenciaPersonalByPeriodo(desde, hasta).ToList();

                Modelo.Connection.Close();
            }

            return listado;

        }

        public List<SJ_RHListarAsistenciaPersonalByPeriodoResult> ObtenerListadoListadoAsistenaPersonalCampo(string periodo, string desde, string hasta, List<string> listaPlanillasInvolucradas)
        {
            List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listado = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9800000;
                var resultadoConsulta = Modelo.SJ_RHListarAsistenciaPersonalByPeriodo(desde, hasta).ToList();

                listado = (from items in resultadoConsulta.ToList()
                           where (listaPlanillasInvolucradas.Contains(items.idPlanilla.ToString().Trim()))
                           select items
                           ).ToList();

                Modelo.Connection.Close();
            }

            return listado;
        }

        public List<SJ_RHListarAsistenciaPersonalByPeriodoResult> ObtenerListadoPersonalEnMasdeUnaLabor(List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistencia)
        {

            List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listado = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();

            #region Logica descrita
            /*
             Agrupar por:
             * 1.- DIA
             * 2.- ACTIVIDAD
             * 3.- LABOR
             * 4.- CODIGO DE TRABAJADOR             
             */
            #endregion

            var ListaDias = (from diaItem in listadoAsistencia
                             where diaItem.FECHA != null
                             group diaItem by new { diaItem.FECHA } into j
                             select new
                             {
                                 diaTrabajado = j.Key.FECHA,
                             }).ToList();


            if (ListaDias != null && ListaDias.ToList().Count > 0)
            {
                #region Agrupar por actividades()
                foreach (var itemDiaTrabajado in ListaDias)
                {


                    var listadoPersonasByDia = listadoAsistencia.Where(x => x.FECHA == itemDiaTrabajado.diaTrabajado).ToList();
                    /* Agrupar por personal by labores by actividades por día trabajado */
                    var ListadoPersonal = (from diaItem in listadoPersonasByDia
                                           where diaItem.IDCODIGOGENERAL != null
                                           group diaItem by new { diaItem.IDCODIGOGENERAL } into j
                                           select new
                                           {
                                               codigoPersonal = j.Key.IDCODIGOGENERAL.ToString().Trim(),
                                           }).ToList();

                    if (ListadoPersonal != null && ListadoPersonal.ToList().Count > 0)
                    {

                        foreach (var itemPersonal in ListadoPersonal)
                        {

                            #region
                            var listadoAsistenciaPersonalByDiaByPersona = listadoPersonasByDia.Where(x => x.IDCODIGOGENERAL.ToString().Trim() == itemPersonal.codigoPersonal.ToString().Trim() && x.FECHA == itemDiaTrabajado.diaTrabajado).ToList();
                            /*Agrupar actividades por día trabajado*/
                            var ListaActividades = (from diaItem in listadoAsistenciaPersonalByDiaByPersona
                                                    where diaItem.IDACTIVIDAD != null
                                                    group diaItem by new { diaItem.IDACTIVIDAD } into j
                                                    select new
                                                    {
                                                        codigoActividad = j.Key.IDACTIVIDAD.ToString().Trim(),
                                                    }).ToList();

                            if (ListaActividades != null && ListaActividades.ToList().Count > 0)
                            {
                                #region Agrupar por Actividad()
                                foreach (var itemActividad in ListaActividades)
                                {
                                    #region
                                    var listadoByActividadByAsistenciaByDia = listadoAsistenciaPersonalByDiaByPersona.
                                        Where(x => x.IDACTIVIDAD.ToString().Trim() == itemActividad.codigoActividad.ToString().Trim() &&
                                            x.IDCODIGOGENERAL.ToString().Trim() == itemPersonal.codigoPersonal.ToString().Trim() &&
                                             x.FECHA == itemDiaTrabajado.diaTrabajado
                                            ).ToList();
                                    /*Agrupar labores by actividades por día trabajado*/
                                    var ListaLabor = (from diaItem in listadoByActividadByAsistenciaByDia
                                                      where diaItem.IDLABOR != null && diaItem.IDLABOR.ToString().Trim() != ""
                                                      group diaItem by new { diaItem.IDLABOR } into j
                                                      select new
                                                      {
                                                          codigoLabor = j.Key.IDLABOR.ToString().Trim(),
                                                      }).ToList();


                                    if (ListaLabor != null && ListaLabor.ToList().Count > 0)
                                    {
                                        #region Agrupar por Labor()
                                        //foreach (var itemLabor in ListaLabor)
                                        //{
                                        #region Agregar a la lista()
                                        SJ_RHListarAsistenciaPersonalByPeriodoResult personal = new SJ_RHListarAsistenciaPersonalByPeriodoResult();
                                        personal.FECHA = itemDiaTrabajado.diaTrabajado;
                                        personal.NROASISTENCIA = "";
                                        personal.IDCODIGOGENERAL = itemPersonal.codigoPersonal;
                                        personal.IDCONSUMIDOR = "";
                                        personal.nombresTrabajador = listadoByActividadByAsistenciaByDia.FirstOrDefault().nombresTrabajador != null ? listadoByActividadByAsistenciaByDia.FirstOrDefault().nombresTrabajador.ToString().Trim() : "";
                                        personal.nroDocumento = listadoByActividadByAsistenciaByDia.FirstOrDefault().nroDocumento != null ? listadoByActividadByAsistenciaByDia.FirstOrDefault().nroDocumento.ToString().Trim() : "";
                                        personal.consumidor = listadoByActividadByAsistenciaByDia.FirstOrDefault().consumidor != null ? listadoByActividadByAsistenciaByDia.FirstOrDefault().consumidor.ToString().Trim() : "";
                                        personal.IDACTIVIDAD = itemActividad.codigoActividad;
                                        personal.IDLABOR = ListaLabor.FirstOrDefault().codigoLabor != null ? ListaLabor.FirstOrDefault().codigoLabor.ToString().Trim() : "";
                                        //personal.TOTAL_HORAS = listadoPersonaByLaborByActividadByAsistenciaByDia.Sum(x => x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0);
                                        personal.TOTAL_HORAS = ListaLabor.ToList().Count;

                                        personal.numeroSemanaRegistro = listadoByActividadByAsistenciaByDia.FirstOrDefault().numeroSemanaRegistro != null ? listadoByActividadByAsistenciaByDia.FirstOrDefault().numeroSemanaRegistro : 0;
                                        personal.añoFechaRegistro = listadoByActividadByAsistenciaByDia.FirstOrDefault().añoFechaRegistro != null ? listadoByActividadByAsistenciaByDia.FirstOrDefault().añoFechaRegistro : (int?)null;
                                        personal.mesFechaRegistro = listadoByActividadByAsistenciaByDia.FirstOrDefault().mesFechaRegistro != null ? listadoByActividadByAsistenciaByDia.FirstOrDefault().mesFechaRegistro : (int?)null;
                                        personal.nombreMesFechaRegistro = listadoByActividadByAsistenciaByDia.FirstOrDefault().nombreMesFechaRegistro != null ? listadoByActividadByAsistenciaByDia.FirstOrDefault().nombreMesFechaRegistro.ToString().Trim() : "";

                                        personal.actividad = listadoByActividadByAsistenciaByDia.FirstOrDefault().actividad != null ? listadoByActividadByAsistenciaByDia.FirstOrDefault().actividad.ToString().Trim() : "";
                                        personal.labor = listadoByActividadByAsistenciaByDia.FirstOrDefault().labor != null ? listadoByActividadByAsistenciaByDia.FirstOrDefault().labor.ToString().Trim() : "";
                                        personal.idPlanilla = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().idPlanilla != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().idPlanilla.ToString().Trim() : "";
                                        personal.grupoRepetido = "L"; /*A.- Actividad / L.- Labor */

                                        listado.Add(personal);
                                        #endregion
                                        //}

                                        #endregion
                                    }
                                    #endregion
                                }
                                #endregion
                            }
                            #endregion

                        }
                    }
                }
                #endregion
            }

            return listado;

        }

        /* Creada el 09.03.16 solo deseo agrupar por labores diferentes en este caso no me importa las actividades*/
        public List<SJ_RHListarAsistenciaPersonalByPeriodoResult> ObtenerListadoPersonalEnMasdeUnaLabor(List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistencia, int incluirLabor)
        {
            List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listado = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();

            #region Logica descrita
            /*
             Agrupar por:
             * 1.- DIA
             * 2.- CODIGO DE TRABAJADOR             
             * 3.- codigo unico actividad-labor
             */
            #endregion

            var ListaDias = (from diaItem in listadoAsistencia
                             where diaItem.FECHA != null
                             group diaItem by new { diaItem.FECHA } into j
                             select new
                             {
                                 diaTrabajado = j.Key.FECHA,
                             }).ToList();


            if (ListaDias != null && ListaDias.ToList().Count > 0)
            {
                #region Agrupar por actividades()
                foreach (var itemDiaTrabajado in ListaDias)
                {
                    #region

                    var listadoPersonasByDia = listadoAsistencia.Where(x => x.FECHA == itemDiaTrabajado.diaTrabajado).ToList();
                    /* Agrupar por personal by labores by actividades por día trabajado */
                    var ListadoPersonal = (from diaItem in listadoPersonasByDia
                                           where diaItem.IDCODIGOGENERAL != null
                                           group diaItem by new { diaItem.IDCODIGOGENERAL } into j
                                           select new
                                           {
                                               codigoPersonal = j.Key.IDCODIGOGENERAL.ToString().Trim(),
                                           }).ToList();

                    if (ListadoPersonal != null && ListadoPersonal.ToList().Count > 0)
                    {
                        #region
                        foreach (var itemPersonal in ListadoPersonal)
                        {
                            #region
                            var listadoAsistenciaPersonalByDiaByPersona = listadoPersonasByDia.Where(x => x.IDCODIGOGENERAL.ToString().Trim() == itemPersonal.codigoPersonal.ToString().Trim() && x.FECHA == itemDiaTrabajado.diaTrabajado).ToList();
                            /*Agrupar actividades por día trabajado*/
                            var ListaLabores = (from diaItem in listadoAsistenciaPersonalByDiaByPersona
                                                where diaItem.idUnicoByLabor != null
                                                group diaItem by new { diaItem.idUnicoByLabor } into j
                                                select new
                                                {
                                                    codigoActividadLabor = j.Key.idUnicoByLabor.ToString().Trim(),
                                                }).ToList();

                            if (ListaLabores != null && ListaLabores.ToList().Count > 0)
                            {
                                #region Agrupar por Labor()
                                //foreach (var itemLabor in ListaLabor)
                                //{
                                #region Agregar a la lista()
                                SJ_RHListarAsistenciaPersonalByPeriodoResult personal = new SJ_RHListarAsistenciaPersonalByPeriodoResult();
                                personal.FECHA = itemDiaTrabajado.diaTrabajado;
                                personal.NROASISTENCIA = "";
                                personal.IDCODIGOGENERAL = itemPersonal.codigoPersonal;
                                personal.IDCONSUMIDOR = "";
                                personal.nombresTrabajador = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombresTrabajador != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombresTrabajador.ToString().Trim() : "";
                                personal.nroDocumento = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nroDocumento != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nroDocumento.ToString().Trim() : "";
                                personal.consumidor = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().consumidor != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().consumidor.ToString().Trim() : "";
                                personal.IDACTIVIDAD = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().IDACTIVIDAD != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().IDACTIVIDAD.ToString().Trim() : "";
                                personal.IDLABOR = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().IDLABOR != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().IDLABOR.ToString().Trim() : "";
                                //personal.TOTAL_HORAS = listadoPersonaByLaborByActividadByAsistenciaByDia.Sum(x => x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0);
                                personal.TOTAL_HORAS = ListaLabores.ToList().Count;

                                personal.numeroSemanaRegistro = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().numeroSemanaRegistro != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().numeroSemanaRegistro : 0;
                                personal.añoFechaRegistro = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().añoFechaRegistro != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().añoFechaRegistro : (int?)null;
                                personal.mesFechaRegistro = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().mesFechaRegistro != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().mesFechaRegistro : (int?)null;
                                personal.nombreMesFechaRegistro = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombreMesFechaRegistro != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombreMesFechaRegistro.ToString().Trim() : "";

                                personal.actividad = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().actividad != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().actividad.ToString().Trim() : "";
                                personal.labor = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().labor != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().labor.ToString().Trim() : "";
                                personal.idPlanilla = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().idPlanilla != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().idPlanilla.ToString().Trim() : "";
                                personal.grupoRepetido = "L"; /*A.- Actividad / L.- Labor */
                                personal.idUnicoByLabor = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().idUnicoByLabor != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().idUnicoByLabor.ToString().Trim() : "";
                                listado.Add(personal);
                                #endregion
                                //}

                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }

            return listado;

        }

        public List<SJ_RHListarAsistenciaPersonalByPeriodoResult> ObtenerListadoPersonalEnMasdeUnaActividad(List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistencia)
        {
            List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listado = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();

            #region Logica descrita
            /*
             Agrupar por:
             * 1.- DIA
             * 2.- ACTIVIDAD          
             */
            #endregion

            var ListaDias = (from diaItem in listadoAsistencia
                             where diaItem.FECHA != null
                             group diaItem by new { diaItem.FECHA } into j
                             select new
                             {
                                 diaTrabajado = j.Key.FECHA,
                             }).ToList();
            if (ListaDias != null && ListaDias.ToList().Count > 0)
            {
                #region Agrupar por actividades()
                foreach (var itemDiaTrabajado in ListaDias)
                {
                    #region
                    var listadoPersonasByDia = listadoAsistencia.Where(x => x.FECHA == itemDiaTrabajado.diaTrabajado).ToList();
                    /* Agrupar por personal by labores by actividades por día trabajado */
                    var ListadoPersonal = (from diaItem in listadoPersonasByDia
                                           where diaItem.IDCODIGOGENERAL != null
                                           group diaItem by new { diaItem.IDCODIGOGENERAL } into j
                                           select new
                                           {
                                               codigoPersonal = j.Key.IDCODIGOGENERAL.ToString().Trim(),
                                           }).ToList();

                    if (ListadoPersonal != null && ListadoPersonal.ToList().Count > 0)
                    {
                        #region
                        foreach (var itemPersonal in ListadoPersonal)
                        {
                            #region
                            var listadoAsistenciaPersonalByDiaByPersona = listadoPersonasByDia.Where(x => x.IDCODIGOGENERAL.ToString().Trim() == itemPersonal.codigoPersonal.ToString().Trim() && x.FECHA == itemDiaTrabajado.diaTrabajado).ToList();
                            /*Agrupar actividades por día trabajado*/
                            var ListaActividades = (from diaItem in listadoAsistenciaPersonalByDiaByPersona
                                                    where diaItem.IDACTIVIDAD != null
                                                    group diaItem by new { diaItem.IDACTIVIDAD } into j
                                                    select new
                                                    {
                                                        codigoActividad = j.Key.IDACTIVIDAD.ToString().Trim(),
                                                    }).ToList();

                            if (ListaActividades != null && ListaActividades.ToList().Count > 1)
                            {
                                #region Agregar a la lista()
                                SJ_RHListarAsistenciaPersonalByPeriodoResult personal = new SJ_RHListarAsistenciaPersonalByPeriodoResult();
                                personal.FECHA = itemDiaTrabajado.diaTrabajado;
                                personal.NROASISTENCIA = "";
                                personal.IDCODIGOGENERAL = itemPersonal.codigoPersonal;
                                personal.IDCONSUMIDOR = "";
                                personal.nombresTrabajador = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombresTrabajador != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombresTrabajador.ToString().Trim() : "";
                                personal.nroDocumento = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nroDocumento != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nroDocumento.ToString().Trim() : "";
                                personal.consumidor = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().consumidor != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().consumidor.ToString().Trim() : "";
                                personal.IDACTIVIDAD = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().IDLABOR != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().IDLABOR.ToString().Trim() : "";
                                personal.IDLABOR = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().IDLABOR != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().IDLABOR.ToString().Trim() : "";
                                personal.TOTAL_HORAS = ListaActividades.ToList().Count;
                                personal.numeroSemanaRegistro = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().numeroSemanaRegistro != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().numeroSemanaRegistro : 0;
                                personal.añoFechaRegistro = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().añoFechaRegistro != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().añoFechaRegistro : (int?)null;
                                personal.mesFechaRegistro = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().mesFechaRegistro != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().mesFechaRegistro : (int?)null;
                                personal.nombreMesFechaRegistro = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombreMesFechaRegistro != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombreMesFechaRegistro.ToString().Trim() : "";
                                personal.actividad = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().actividad != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().actividad.ToString().Trim() : "";
                                personal.labor = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().labor != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().labor.ToString().Trim() : "";
                                personal.idPlanilla = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().idPlanilla != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().idPlanilla.ToString().Trim() : "";
                                personal.grupoRepetido = "A"; /*A.- Actividad / L.- Labor */
                                listado.Add(personal);
                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                    #endregion

                }
                #endregion
            }

            return listado;
        }

        public List<DesarrolloLaboresPersonalCampo> ObtenerListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores(List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoPersonalEnMasdeUnaLabor)
        {

            List<DesarrolloLaboresPersonalCampo> listado = new List<DesarrolloLaboresPersonalCampo>();


            var ListaDias = (from diaItem in listadoPersonalEnMasdeUnaLabor
                             where diaItem.FECHA != null
                             group diaItem by new { diaItem.FECHA } into j
                             select new
                             {
                                 diaTrabajado = j.Key.FECHA,
                             }).ToList();


            if (ListaDias != null && ListaDias.ToList().Count > 0)
            {
                #region

                foreach (var itemDia in ListaDias)
                {
                    var listaLaboresByDia = listadoPersonalEnMasdeUnaLabor.Where(x => x.FECHA == itemDia.diaTrabajado).ToList();

                    if (listaLaboresByDia != null && listaLaboresByDia.ToList().Count > 0)
                    {
                        DesarrolloLaboresPersonalCampo oDesarrolloLaboresByPersonalCampo = new DesarrolloLaboresPersonalCampo();
                        oDesarrolloLaboresByPersonalCampo.fecha = itemDia.diaTrabajado;
                        oDesarrolloLaboresByPersonalCampo.semana = listaLaboresByDia.FirstOrDefault().numeroSemanaRegistro != null ? listaLaboresByDia.FirstOrDefault().numeroSemanaRegistro : 0;
                        oDesarrolloLaboresByPersonalCampo.numeroMes = listaLaboresByDia.FirstOrDefault().mesFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().mesFechaRegistro : 0;
                        oDesarrolloLaboresByPersonalCampo.numeroAño = listaLaboresByDia.FirstOrDefault().añoFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().añoFechaRegistro : 0;
                        oDesarrolloLaboresByPersonalCampo.nombreMes = listaLaboresByDia.FirstOrDefault().nombreMesFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().nombreMesFechaRegistro : "";
                        oDesarrolloLaboresByPersonalCampo.unaLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 1).Count();
                        oDesarrolloLaboresByPersonalCampo.dosLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 2).Count();
                        oDesarrolloLaboresByPersonalCampo.tresLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 3).Count();
                        oDesarrolloLaboresByPersonalCampo.cuatroLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 4).Count();
                        oDesarrolloLaboresByPersonalCampo.cincoLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 5).Count();
                        oDesarrolloLaboresByPersonalCampo.seisLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 6).Count();
                        oDesarrolloLaboresByPersonalCampo.sieteLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 7).Count();
                        oDesarrolloLaboresByPersonalCampo.ochoLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 8).Count();
                        oDesarrolloLaboresByPersonalCampo.nueveLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 9).Count();
                        oDesarrolloLaboresByPersonalCampo.diezLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 10).Count();
                        oDesarrolloLaboresByPersonalCampo.masdiez = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) > 10).Count();
                        oDesarrolloLaboresByPersonalCampo.total = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) > 0).Count();
                        listado.Add(oDesarrolloLaboresByPersonalCampo);
                    }
                }
                #endregion
            }

            return listado;

        }

        public List<DesarrolloLaboresPersonalCampo> ObtenerListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores(List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoLabores, List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoActividades)
        {
            List<DesarrolloLaboresPersonalCampo> listado = new List<DesarrolloLaboresPersonalCampo>();

            List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoPersonalEnMasdeUnaLaborYActividad = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();


            if (listadoActividades != null && listadoActividades.ToList().Count > 0)
            {
                listadoPersonalEnMasdeUnaLaborYActividad.AddRange(listadoActividades);
            }


            if (listadoLabores != null && listadoLabores.ToList().Count > 0)
            {
                if (listadoActividades != null && listadoActividades.ToList().Count > 0)
                {
                    foreach (var item in listadoLabores)
                    {
                        var resultadoFiltro = listadoActividades.Where(x => x.IDCODIGOGENERAL.ToString().Trim() == item.IDCODIGOGENERAL.ToString().Trim() && x.FECHA == item.FECHA).ToList();

                        if (resultadoFiltro != null && resultadoFiltro.Count > 0)
                        {

                        }
                        else
                        {
                            listadoPersonalEnMasdeUnaLaborYActividad.Add(item);
                        }
                    }
                }
                else
                {
                    listadoPersonalEnMasdeUnaLaborYActividad.AddRange(listadoLabores);
                }
            }






            var ListaDias = (from diaItem in listadoPersonalEnMasdeUnaLaborYActividad
                             where diaItem.FECHA != null
                             group diaItem by new { diaItem.FECHA } into j
                             select new
                             {
                                 diaTrabajado = j.Key.FECHA,
                             }).ToList();


            if (ListaDias != null && ListaDias.ToList().Count > 0)
            {

                foreach (var itemDia in ListaDias)
                {
                    var listaLaboresByDia = listadoPersonalEnMasdeUnaLaborYActividad.Where(x => x.FECHA == itemDia.diaTrabajado).ToList();

                    if (listaLaboresByDia != null && listaLaboresByDia.ToList().Count > 0)
                    {
                        DesarrolloLaboresPersonalCampo oDesarrolloLaboresByPersonalCampo = new DesarrolloLaboresPersonalCampo();
                        oDesarrolloLaboresByPersonalCampo.fecha = itemDia.diaTrabajado;
                        oDesarrolloLaboresByPersonalCampo.semana = listaLaboresByDia.FirstOrDefault().numeroSemanaRegistro != null ? listaLaboresByDia.FirstOrDefault().numeroSemanaRegistro : 0;
                        oDesarrolloLaboresByPersonalCampo.numeroMes = listaLaboresByDia.FirstOrDefault().mesFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().mesFechaRegistro : 0;
                        oDesarrolloLaboresByPersonalCampo.numeroAño = listaLaboresByDia.FirstOrDefault().añoFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().añoFechaRegistro : 0;
                        oDesarrolloLaboresByPersonalCampo.nombreMes = listaLaboresByDia.FirstOrDefault().nombreMesFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().nombreMesFechaRegistro : "";
                        oDesarrolloLaboresByPersonalCampo.unaLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 1).Count();
                        oDesarrolloLaboresByPersonalCampo.dosLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 2).Count();
                        oDesarrolloLaboresByPersonalCampo.tresLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 3).Count();
                        oDesarrolloLaboresByPersonalCampo.cuatroLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 4).Count();
                        oDesarrolloLaboresByPersonalCampo.cincoLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 5).Count();
                        oDesarrolloLaboresByPersonalCampo.seisLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 6).Count();
                        oDesarrolloLaboresByPersonalCampo.sieteLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 7).Count();
                        oDesarrolloLaboresByPersonalCampo.ochoLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 8).Count();
                        oDesarrolloLaboresByPersonalCampo.nueveLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 9).Count();
                        oDesarrolloLaboresByPersonalCampo.diezLabor = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) == 10).Count();
                        oDesarrolloLaboresByPersonalCampo.masdiez = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) > 10).Count();
                        oDesarrolloLaboresByPersonalCampo.total = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) > 0).Count();
                        listado.Add(oDesarrolloLaboresByPersonalCampo);
                    }
                }
            }

            return listado;
        }


    }
}
