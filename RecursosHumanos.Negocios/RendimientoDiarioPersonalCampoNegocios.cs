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
    public class RendimientoDiarioPersonalCampoNegocios
    {


        public List<SJ_RRHHRendimientoDiarioPersonalCampoResult> ObtenerListadoRendimientoDiarioPersonalCampo(string periodo, string desde, string hasta, string idActividad, string idLabor)
        {

            List<SJ_RRHHRendimientoDiarioPersonalCampoResult> listado = new List<SJ_RRHHRendimientoDiarioPersonalCampoResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {

                if (contexto.SJ_RRHHRendimientoDiarioPersonalCampo(desde, hasta, idActividad, idLabor).ToList().Count > 0)
                {
                    listado = contexto.SJ_RRHHRendimientoDiarioPersonalCampo(desde, hasta, idActividad, idLabor).ToList();
                }
            }

            return listado;
        }

        public List<SJ_RRHHRendimientoDiarioPersonalCampoResult> ObtenerListadoRendimientoDiarioPersonalCampoAgrupadoByPersonaByDia(List<SJ_RRHHRendimientoDiarioPersonalCampoResult> listadoDetalle, decimal basicoBruto, decimal basicoNeto, decimal valorPlantaRacimo, decimal valorPlantaRacimoAdicional, decimal estandarByLabor)
        {
            List<SJ_RRHHRendimientoDiarioPersonalCampoResult> listadoResultado = new List<SJ_RRHHRendimientoDiarioPersonalCampoResult>();

            if (listadoDetalle != null && listadoDetalle.ToList().Count > 0)
            {
                /*Obtengo los dias de mi consulta*/
                var dias = (from item in listadoDetalle
                            where item.fecha != null
                            group item by new { item.fecha } into j
                            select new
                            {
                                dia = j.Key.fecha,
                            }
                                ).ToList();


                if (dias != null && dias.ToList().Count() > 0)
                {
                    /* Recorro dia por dia para obtner listado de trabajos por dia */
                    foreach (var oDia in dias)
                    {
                        var PersonalByDia = listadoDetalle.Where(x => x.fecha == oDia.dia).ToList();

                        if (PersonalByDia != null && PersonalByDia.ToList().Count > 0)
                        {
                            /*Obtengo los dias de mi consulta*/
                            var listaPersonal = (from item in PersonalByDia
                                                 where item.dnirTrabajador != null
                                                 group item by new { item.dnirTrabajador } into j
                                                 select new
                                                 {
                                                     dni = j.Key.dnirTrabajador,
                                                     nombresCompletosResponsable = j.FirstOrDefault().nombresCompletosResponsable != null ? j.FirstOrDefault().nombresCompletosResponsable.ToString().Trim() : "",
                                                     //dniTrabajador = j.FirstOrDefault().dnirTrabajador != null ? j.FirstOrDefault().dnirTrabajador.ToString().Trim() : "",
                                                     idCodigoGeneral = j.FirstOrDefault().idCodigoGeneral != null ? j.FirstOrDefault().idCodigoGeneral.ToString().Trim() : "",
                                                     trabajador = j.FirstOrDefault().trabajador != null ? j.FirstOrDefault().trabajador.ToString().Trim() : "",
                                                 }).ToList();


                            if (listaPersonal != null && listaPersonal.ToList().Count > 0)
                            {

                                foreach (var oPersonal in listaPersonal)
                                {

                                    var listadoPersonal = PersonalByDia.Where(x => x.dnirTrabajador.ToString().Trim() == oPersonal.dni.ToString().Trim()).ToList();

                                    var actividades = (from item in listadoPersonal
                                                       where item.idactividad != null
                                                       group item by new { item.idactividad } into j
                                                       select new
                                                       {
                                                           idActividad = j.Key.idactividad.ToString().Trim(),
                                                           actividad = j.FirstOrDefault().descripcionActividad != null ? j.FirstOrDefault().descripcionActividad.ToString().Trim() : "",
                                                       }).ToList();

                                    foreach (var oActividad in actividades)
                                    {

                                        var listadoActividadLabores = listadoPersonal.Where(x => x.idactividad.ToString().Trim() == oActividad.idActividad.ToString().Trim()).ToList();


                                        var labores = (from item in listadoActividadLabores
                                                       where item.idLabor != null
                                                       group item by new { item.idLabor } into j
                                                       select new
                                                       {
                                                           idLabor = j.Key.idLabor.ToString().Trim(),
                                                           labor = j.FirstOrDefault().descripcionLabor != null ? j.FirstOrDefault().descripcionLabor.ToString().Trim() : "",
                                                       }).ToList();

                                        foreach (var oLabores in labores)
                                        {

                                            var listadLabores = listadoActividadLabores.Where(x => x.idLabor.ToString().Trim() == oLabores.idLabor.ToString().Trim()).ToList();

                                            SJ_RRHHRendimientoDiarioPersonalCampoResult oResultado = new SJ_RRHHRendimientoDiarioPersonalCampoResult();
                                            oResultado.fecha = oDia.dia;
                                            oResultado.fechaHoraRegistro = listadLabores.FirstOrDefault().fechaHoraRegistro != null ? listadLabores.FirstOrDefault().fechaHoraRegistro.Value : (DateTime?)null;
                                            oResultado.dniResponsable = listadLabores.FirstOrDefault().dniResponsable != null ? listadLabores.FirstOrDefault().dniResponsable : "";
                                            oResultado.nombresCompletosResponsable = listadLabores.FirstOrDefault().nombresCompletosResponsable != null ? listadLabores.FirstOrDefault().nombresCompletosResponsable : "";
                                            oResultado.idCodigoGeneral = oPersonal.idCodigoGeneral;
                                            oResultado.dnirTrabajador = oPersonal.dni;
                                            oResultado.trabajador = oPersonal.trabajador;
                                            oResultado.idConsumidor = listadLabores.FirstOrDefault().idConsumidor != null ? listadLabores.FirstOrDefault().idConsumidor : "";
                                            oResultado.descripcionLote = listadLabores.FirstOrDefault().descripcionLote != null ? listadLabores.FirstOrDefault().descripcionLote : "";
                                            oResultado.idactividad = oActividad.idActividad;
                                            oResultado.descripcionActividad = oActividad.actividad;
                                            oResultado.idLabor = oLabores.idLabor;
                                            oResultado.descripcionLabor = oLabores.labor;
                                            oResultado.idUnidadMedida = listadLabores.FirstOrDefault().idUnidadMedida != null ? listadLabores.FirstOrDefault().idUnidadMedida : "";
                                            oResultado.descripcion = listadLabores.FirstOrDefault().descripcion != null ? listadLabores.FirstOrDefault().descripcion : "";

                                            double? avance = 0;
                                            avance = listadLabores.Sum(x => x.Avance != null ? x.Avance.Value : 0);
                                            oResultado.Avance = avance;
                                            oResultado.standar = Convert.ToInt32(estandarByLabor);

                                            double? horasTrabajadas = 0;
                                            horasTrabajadas = listadLabores.Sum(x => x.horasTrabajadas != null ? x.horasTrabajadas.Value : 0);
                                            oResultado.horasTrabajadas = horasTrabajadas;
                                            oResultado.observacion = listadLabores.FirstOrDefault().observacion != null ? listadLabores.FirstOrDefault().observacion : "";
                                            oResultado.esAvance = listadLabores.Max(x => x.esAvance != (Int32?)null ? x.esAvance : 0);                                           
                                            decimal? jornalDiario = (Convert.ToDecimal(basicoNeto) * valorPlantaRacimo);
                                            oResultado.jornalDiario = jornalDiario;
                                            oResultado.dominical = 0;
                                            decimal? jornalDiarioExtra = ((Convert.ToDecimal(avance) - Convert.ToInt32(estandarByLabor)) * valorPlantaRacimoAdicional);
                                            oResultado.jornalDiarioExtra = Convert.ToDecimal(jornalDiarioExtra > 0 ? jornalDiarioExtra : 0);
                                            oResultado.totalPago = jornalDiario + (jornalDiarioExtra > 0 ? jornalDiarioExtra : 0);
                                            listadoResultado.Add(oResultado);

                                        }


                                    }

                                }

                            }

                        }

                    }

                }

            }

            return listadoResultado;
        }
    }
}
