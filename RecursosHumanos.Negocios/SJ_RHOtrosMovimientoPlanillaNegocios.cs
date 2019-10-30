using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;

namespace RecursosHumanos.Negocios
{
    public class SJ_RHOtrosMovimientoPlanillaNegocios
    {

        public List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult> ObtenerListadoPivot(string periodo, string idPlanilla)
        {
            List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult> listado = new List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9800000;
                var resultadoconsulta = Modelo.SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivot(idPlanilla).ToList();


                if (resultadoconsulta != null && resultadoconsulta.ToList().Count > 0)
                {
                    listado = (from item in resultadoconsulta
                               select new SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult
                               {
                                   tipo = item.tipo != null ? item.tipo : string.Empty,
                                   iddocumento = item.iddocumento != null ? item.iddocumento : string.Empty,
                                   tipoDocumentoMovimiento = item.tipoDocumentoMovimiento != null ? item.tipoDocumentoMovimiento : string.Empty,
                                   motivoMovimiento = item.motivoMovimiento != null ? item.motivoMovimiento : string.Empty,
                                   memorandum = item.memorandum != null ? item.memorandum : string.Empty,
                                   idMotivoMemo = item.idMotivoMemo != null ? item.idMotivoMemo : string.Empty,
                                   idMotivoMovimiento = item.idMotivoMovimiento != null ? item.idMotivoMovimiento : string.Empty,
                                   PAM = item.PAM != null ? "[X]" : string.Empty,
                                   PAS = item.PAS != null ? "[X]" : string.Empty,
                                   EMA = item.EMA != null ? "[X]" : string.Empty,
                                   PRA = item.PRA != null ? "[X]" : string.Empty,
                                   OBM = item.OBM != null ? "[X]" : string.Empty,
                                   EMP = item.EMP != null ? "[X]" : string.Empty,
                               }
                                   ).ToList();
                }

                Modelo.Connection.Close();
            }
            return listado;
        }

        public List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralResult> ObtenerListadoPorConceptoByPlanilla(string periodo, string idPlanilla)
        {
            List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralResult> listado = new List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9800000;
                listado = Modelo.SJ_RHMovimientoOtrosDocumentosPersonalGeneral(idPlanilla).ToList();

                Modelo.Connection.Close();
            }
            return listado;
        }


        public List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult> ObtenerListadoPorConceptoByPlanilla(string periodo, string idtipo, string iddocumento, string idplanilla, string idMotivoMemo, string idMotivoMovimiento)
        {
            List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult> listado = new List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9800000;
                listado = Modelo.SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumento(idtipo, iddocumento, idplanilla, idMotivoMemo, idMotivoMovimiento).ToList();
                Modelo.Connection.Close();
            }
            return listado;
        }

        public List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult> ObtenerListadoPorConceptoByPlanilla(string periodo, SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult otrosMovimientoPlanilla, string idplanilla)
        {
            List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult> listado = new List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (RecursosHumanosDataContext Modelo = new RecursosHumanosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9800000;
                listado = Modelo.SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumento(otrosMovimientoPlanilla.tipo, otrosMovimientoPlanilla.iddocumento, idplanilla, otrosMovimientoPlanilla.idMotivoMemo, otrosMovimientoPlanilla.idMotivoMovimiento).ToList();
                Modelo.Connection.Close();
            }
            return listado;
        }



    }
}
