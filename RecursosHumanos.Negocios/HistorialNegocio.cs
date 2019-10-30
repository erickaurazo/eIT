using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using RecursosHumanos.Datos;

namespace RecursosHumanos.Negocios
{
    public class HistorialNegocio
    {

        List<HistorialObj> historiales;

        public List<HistorialObj> ListarHistorialSJ(string idHistorial)
        {
            historiales = new List<HistorialObj>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                contexto.CommandTimeout = 98000;
                if (contexto.LogTablas.Where(x => x.IDLOG.ToString().Trim() == idHistorial.ToString().Trim()).ToList().Count > 0)
                {
                    historiales = (from items in contexto.LogTablas.Where(x => x.IDLOG.ToString().Trim() == idHistorial.ToString().Trim()).OrderBy(x => x.ITEM).ToList()
                                   group items by new { items.ITEM } into j
                                   select new HistorialObj
                                   {
                                       evento = j.FirstOrDefault().EVENTO.ToString().Trim(),
                                       usuario = j.FirstOrDefault().IDUSUARIO.ToString().Trim(),
                                       fecha = j.FirstOrDefault().FECHACREACION.Value,
                                       maquina = j.FirstOrDefault().MAQUINA.ToString().Trim(),
                                   }
                                       ).ToList();
                }
                else
                {
                    historiales = new List<HistorialObj>();
                }
            }

            return historiales;
        }

        public List<HistorialObj> ListarHistorial(string idLog, string tabla)
        {
            historiales = new List<HistorialObj>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                contexto.CommandTimeout = 98000;


                var resultadoConsultaHistorial = contexto.ListarLogDeTablasByCodigoLogByNombreTabla(idLog, tabla).ToList();


                if (resultadoConsultaHistorial != null && resultadoConsultaHistorial.ToList().Count > 0)
                {
                    historiales = (from items in resultadoConsultaHistorial
                                   group items by new { items.ITEM } into j
                                   select new HistorialObj
                                   {
                                       evento = j.FirstOrDefault().EVENTO.ToString().Trim(),
                                       usuario = j.FirstOrDefault().IDUSUARIO.ToString().Trim(),
                                       fecha = j.FirstOrDefault().FECHACREACION.Value,
                                       maquina = j.FirstOrDefault().MAQUINA.ToString().Trim(),
                                   }
                                       ).ToList();
                }
                else
                {
                    historiales = new List<HistorialObj>();
                }
            }

            return historiales;
        }

        public string AsignarNumeroItemHistorial(string periodo, string idLog)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            string correlativo = "001";
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(cnx))
            {
                Modelo.CommandTimeout = 980000;

                int? numeroItem = Modelo.LogTableObtenerNumeroItem(idLog).FirstOrDefault().item;
                Modelo.Connection.Close();
                correlativo = numeroItem.Value.ToString().PadLeft(3, '0');

            }

            return correlativo;
        }

        public void RegistrarHistorial(LogTablas historial, string periodo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(cnx))
            {
                Modelo.CommandTimeout = 98000;
                if (historial.TABLA != null && historial.IDUSUARIO != null && historial.IDLOG != null)
                {
                    #region MyRegion
                    LogTablas oHistorial = new LogTablas();
                    oHistorial.IDEMPRESA = "001";
                    oHistorial.IDLOG = historial.IDLOG.ToString().Trim();
                    oHistorial.ITEM = AsignarNumeroItemHistorial(periodo, historial.IDLOG);
                    oHistorial.TABLA = historial.TABLA.ToString().Trim();
                    oHistorial.IDCAMPO = historial.IDCAMPO.ToString().Trim();
                    oHistorial.CAMPOCLAVE = historial.CAMPOCLAVE.ToString().Trim();
                    oHistorial.IDTABLA = historial.IDTABLA.ToString().Trim();
                    oHistorial.EVENTO = historial.EVENTO.ToString().Trim();
                    oHistorial.VALORANTERIOR = historial.VALORANTERIOR;
                    oHistorial.VALORACTUAL = historial.VALORACTUAL;
                    oHistorial.IDUSUARIO = historial.IDUSUARIO;
                    oHistorial.MAQUINA = historial.MAQUINA.ToString().Trim();
                    oHistorial.FECHACREACION = DateTime.Now;
                    oHistorial.VENTANA = historial.VENTANA.ToString().Trim();
                    Modelo.LogTablas.InsertOnSubmit(oHistorial);
                    Modelo.SubmitChanges();
                    #endregion
                }
                Modelo.Connection.Close();
            }
        }


    }
}