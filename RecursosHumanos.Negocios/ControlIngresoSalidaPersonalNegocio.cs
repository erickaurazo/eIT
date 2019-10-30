using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;



namespace RecursosHumanos.Negocios
{
    public class ControlIngresoSalidaPersonalNegocio
    {


        //public List<EST_ObtenerListadoMarcacionesPuertaDetalleByCodigoResult> EST_ObtenerListadoMarcacionesPuertaDetalleByCodigo(string codigoMarcacion, string EmpresaCodigo, string periodo)
        //{
        //    List<EST_ObtenerListadoMarcacionesPuertaDetalleByCodigoResult> listado = new List<EST_ObtenerListadoMarcacionesPuertaDetalleByCodigoResult>();

        //    string cnx = string.Empty;
        //    cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();
        //    using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
        //    {
        //        Modelo.CommandTimeout = 1800;

        //        listado = Modelo.EST_ObtenerListadoMarcacionesPuertaDetalleByCodigo(codigoMarcacion, EmpresaCodigo).OrderBy(x => x.item).ToList(); ;
        //    }

        //    return listado;
        //}


        //public List<EST_ObtenerListadoMarcacionesPuertaResult> EST_ObtenerListadoMarcacionesPuertaByPeriodo(string desde, string hasta, string sucursalCodigo, string periodo)
        //{
        //    List<EST_ObtenerListadoMarcacionesPuertaResult> listado = new List<EST_ObtenerListadoMarcacionesPuertaResult>();
        //    string cnx = string.Empty;
        //    cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();
        //    using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
        //    {
        //        Modelo.CommandTimeout = 1800;

        //        var listadoAsistenciasByConsulta = Modelo.EST_ObtenerListadoMarcacionesPuerta(desde, hasta, sucursalCodigo).ToList();

        //        var asistenciaByCodigo = (from item in listadoAsistenciasByConsulta
        //                                  where item.MarcacionCodigo != null
        //                                  group item by new { item.MarcacionCodigo } into j
        //                                  select new
        //                                  {
        //                                      codigoRegistro = j.Key.MarcacionCodigo.Trim(),
        //                                  }
        //                                      ).ToList();

                



        //        foreach (var registroAsistencia in asistenciaByCodigo)
        //        {
        //            EST_ObtenerListadoMarcacionesPuertaResult oMarcacion = new EST_ObtenerListadoMarcacionesPuertaResult();

        //            var resultadoPorCodigo = listadoAsistenciasByConsulta.Where(x => x.MarcacionCodigo == registroAsistencia.codigoRegistro).ToList();

        //            var asistenciaByCodigoPersonaByDia = (from item in resultadoPorCodigo
        //                                      where item.codigoPersonal != null
        //                                      group item by new { item.codigoPersonal } into j
        //                                      select new
        //                                      {
        //                                          codigoPersona = j.Key.codigoPersonal.Trim(),
        //                                      }
        //                                     ).ToList();


        //            var asistenciaByCodigoPersonaByDiaIngresoLabores = (from item in resultadoPorCodigo
        //                                                                where item.codigoPersonal != null && item.IngresoALabores == 1
        //                                                                group item by new { item.codigoPersonal } into j
        //                                                                select new
        //                                                                {
        //                                                                    codigoPersona = j.Key.codigoPersonal.Trim(),
        //                                                                }
        //                 ).ToList();


        //            var asistenciaByCodigoPersonaByDiaSalidaLabores = (from item in resultadoPorCodigo
        //                                                                where item.codigoPersonal != null && item.SalidaDeLabores == 1
        //                                                                group item by new { item.codigoPersonal } into j
        //                                                                select new
        //                                                                {
        //                                                                    codigoPersona = j.Key.codigoPersonal.Trim(),
        //                                                                }
        //                 ).ToList();

        //            int totalPersonalMarcacion, totalPersonalMarcacionIngresoLabores, totalPersonalMarcacionSalidaLabores = 0;
        //            totalPersonalMarcacion = asistenciaByCodigoPersonaByDia.ToList().Count;
        //            totalPersonalMarcacionIngresoLabores = asistenciaByCodigoPersonaByDiaIngresoLabores.ToList().Count;
        //            totalPersonalMarcacionSalidaLabores = asistenciaByCodigoPersonaByDiaSalidaLabores.ToList().Count;


        //            oMarcacion.Fecha = resultadoPorCodigo.FirstOrDefault().Fecha != null ? resultadoPorCodigo.FirstOrDefault().Fecha : DateTime.Now;
        //            oMarcacion.DiaSemana = resultadoPorCodigo.FirstOrDefault().DiaSemana != null ? resultadoPorCodigo.FirstOrDefault().DiaSemana : string.Empty;
        //            oMarcacion.MarcacionCodigo = registroAsistencia.codigoRegistro.Trim();
        //            oMarcacion.SucursalCodigo = resultadoPorCodigo.FirstOrDefault().SucursalCodigo != null ? resultadoPorCodigo.FirstOrDefault().SucursalCodigo : string.Empty;
        //            oMarcacion.Sucursal = resultadoPorCodigo.FirstOrDefault().Sucursal != null ? resultadoPorCodigo.FirstOrDefault().Sucursal : string.Empty;
        //            oMarcacion.Documento = resultadoPorCodigo.FirstOrDefault().Documento != null ? resultadoPorCodigo.FirstOrDefault().Documento : string.Empty;
        //            oMarcacion.ResponsableCodigo = resultadoPorCodigo.FirstOrDefault().ResponsableCodigo != null ? resultadoPorCodigo.FirstOrDefault().ResponsableCodigo : string.Empty;
        //            oMarcacion.Responsable = resultadoPorCodigo.FirstOrDefault().Responsable != null ? resultadoPorCodigo.FirstOrDefault().Responsable : string.Empty;
        //            oMarcacion.EstadoCodigo = resultadoPorCodigo.FirstOrDefault().EstadoCodigo != null ? resultadoPorCodigo.FirstOrDefault().EstadoCodigo : string.Empty;
        //            oMarcacion.Estado = resultadoPorCodigo.FirstOrDefault().Estado != null ? resultadoPorCodigo.FirstOrDefault().Estado : string.Empty;
        //            oMarcacion.nropersonas = totalPersonalMarcacion;
        //            oMarcacion.codigoPersonal = "";
        //            oMarcacion.IngresoALabores = totalPersonalMarcacionIngresoLabores;
        //            oMarcacion.SalidaDeLabores = 0;
        //            oMarcacion.SalidaARefrigerio = 0;
        //            oMarcacion.RetornoDeRefrigerio = 0;
        //            oMarcacion.SalidaAComision = 0;
        //            oMarcacion.RetornoDeComision = 0;
        //            listado.Add(oMarcacion);
        //        }





        //    }
        //    return listado;
        //}

    }
}
