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
    public class HorasTrabajadasByPersonalCampoNegocio
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

        public List<SJ_RHListarAsistenciaPersonalByPeriodoResult> ObtenerListadoHorasAcumuladasByPersonalByDia(List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistencia)
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

                            if (listadoAsistenciaPersonalByDiaByPersona != null && listadoAsistenciaPersonalByDiaByPersona.ToList().Count > 0)
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
                                personal.nombreDiaFechaRegistro = listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombreDiaFechaRegistro != null ? listadoAsistenciaPersonalByDiaByPersona.FirstOrDefault().nombreDiaFechaRegistro.ToString().Trim() : "";
                                HorasTrabajadasByPersonalCampoNegocio negocio = new HorasTrabajadasByPersonalCampoNegocio();
                                personal.TOTAL_HORAS = negocio.SumarHoras(listadoAsistenciaPersonalByDiaByPersona.Select(x => x.TOTAL_HORAS != null ? Convert.ToDecimal(x.TOTAL_HORAS.Value) : 0).ToList());
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

        public List<HoraTrabajadaByPersonalCampo> ObtenerListadoResumenHorasAcumuladasByPersonalByDia(List<SJ_RHListarAsistenciaPersonalByPeriodoResult> ListadoHorasAcumuladasByPersonalByDiaDetallado)
        {
            List<HoraTrabajadaByPersonalCampo> listado = new List<HoraTrabajadaByPersonalCampo>();

            List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoPersonalEnMasdeUnaLaborYActividad = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();


            var ListaDias = (from diaItem in ListadoHorasAcumuladasByPersonalByDiaDetallado
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
                    var listaLaboresByDia = ListadoHorasAcumuladasByPersonalByDiaDetallado.Where(x => x.FECHA == itemDia.diaTrabajado).ToList();

                    if (listaLaboresByDia != null && listaLaboresByDia.ToList().Count > 0)
                    {
                        HoraTrabajadaByPersonalCampo oDesarrolloLaboresByPersonalCampo = new HoraTrabajadaByPersonalCampo();
                        oDesarrolloLaboresByPersonalCampo.fecha = itemDia.diaTrabajado;
                        oDesarrolloLaboresByPersonalCampo.semana = listaLaboresByDia.FirstOrDefault().numeroSemanaRegistro != null ? listaLaboresByDia.FirstOrDefault().numeroSemanaRegistro : 0;
                        oDesarrolloLaboresByPersonalCampo.numeroMes = listaLaboresByDia.FirstOrDefault().mesFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().mesFechaRegistro : 0;
                        oDesarrolloLaboresByPersonalCampo.numeroAño = listaLaboresByDia.FirstOrDefault().añoFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().añoFechaRegistro : 0;
                        oDesarrolloLaboresByPersonalCampo.nombreMes = listaLaboresByDia.FirstOrDefault().nombreMesFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().nombreMesFechaRegistro : "";
                        oDesarrolloLaboresByPersonalCampo.nombreDia = listaLaboresByDia.FirstOrDefault().nombreDiaFechaRegistro != null ? listaLaboresByDia.FirstOrDefault().nombreDiaFechaRegistro : "";
                        oDesarrolloLaboresByPersonalCampo.criterio1 = listaLaboresByDia.Where(x => x.TOTAL_HORAS > 0 && x.TOTAL_HORAS <=6).ToList().Count;
                        oDesarrolloLaboresByPersonalCampo.criterio2 = listaLaboresByDia.Where(x => x.TOTAL_HORAS > 6 && x.TOTAL_HORAS <= 8).ToList().Count;
                        oDesarrolloLaboresByPersonalCampo.criterio3 = listaLaboresByDia.Where(x => x.TOTAL_HORAS > 8 && x.TOTAL_HORAS <= Convert.ToDecimal(9.6)).ToList().Count;
                        oDesarrolloLaboresByPersonalCampo.criterio4 = listaLaboresByDia.Where(x => x.TOTAL_HORAS > Convert.ToDecimal(9.6) ).ToList().Count;
                        oDesarrolloLaboresByPersonalCampo.total = listaLaboresByDia.Where(x => (x.TOTAL_HORAS != null ? x.TOTAL_HORAS : 0) > 0).Count();
                        listado.Add(oDesarrolloLaboresByPersonalCampo);
                    }
                }
            }

            return listado;
        }

        public decimal? SumarHoras(List<decimal> lista)
        {
            decimal? diferencialDecimales = 0;
            decimal? diferencialEnteros = 0;

            decimal resultado = 0;
            if (lista != null)
            {
                foreach (var item in lista)
                {
                    if (item > 0)
                    {
                        decimal numeralHoraTermino = Math.Floor(item);
                        decimal decimalHoraTermino = item - numeralHoraTermino;

                        decimal numeralHoraInicio = Math.Floor(resultado);
                        decimal decimalHoraInicio = resultado - numeralHoraInicio;

                        if (decimalHoraTermino > decimalHoraInicio)
                        {
                            diferencialDecimales = decimalHoraTermino + decimalHoraInicio;
                        }
                        else
                        {
                            diferencialDecimales = decimalHoraInicio + decimalHoraTermino;
                        }

                        diferencialEnteros = numeralHoraTermino + numeralHoraInicio;



                        if (diferencialDecimales >= Convert.ToDecimal(0.6))
                        {
                            diferencialDecimales = diferencialDecimales - Convert.ToDecimal(0.60);
                            diferencialEnteros = diferencialEnteros + 1;
                        }

                        resultado = diferencialEnteros.Value + diferencialDecimales.Value;
                    }
                }
            }
            else
            {
                resultado = 0;
            }
            return resultado;
        }

    }
}
