using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using System.Data.OleDb;
using System.Data;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using System.Globalization;
using System.Data.Odbc;


namespace RecursosHumanos.Negocios
{
    public class ConsumidorNegocio
    {

        private string oConexion = string.Empty;
        public List<Consumidor> ObtenerConsumidorByListadoDetalleAsistencia(List<ObtenerListadoAsistenciaByCodigoResult> listadoMovimientoAsistencia)
        {
            try
            {
                List<Consumidor> listado = new List<Consumidor>();

                listado = (from items in listadoMovimientoAsistencia
                           group items by new
                           {
                               items.codigoConsumidor
                           } into j
                           select new Consumidor
                           {
                               codigoConsumidor = j.Key.codigoConsumidor,
                           }).ToList();
                return listado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Consumidor> ObtenerListadoConsumidorForListadoDetalleAsistencia(string periodoConsulta)
        {
            try
            {
                List<Consumidor> listado = new List<Consumidor>();

                oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
                using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
                {
                    var listadoConsumidores = Modelo.Consumidor.ToList();
                    listado = (from items in listadoConsumidores
                               group items by new
                               {
                                   items.codigoConsumidor
                               } into j
                               select new Consumidor
                               {
                                   codigoConsumidor = j.Key.codigoConsumidor.Trim(),
                                   descripcion = j.FirstOrDefault().descripcion != null ? j.FirstOrDefault().descripcion.Trim() : string.Empty,
                               }).ToList();
                    return listado;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ext_ListarConsumidorResult> ObtenerTodosConsumidores(string periodoConsulta)
        {
            List<ext_ListarConsumidorResult> listado = new List<ext_ListarConsumidorResult>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                //Modelo.Connection.ConnectionTimeout = 100;
                listado = Modelo.ext_ListarConsumidor().ToList();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return listado;
        }


        public void ActualizarEtiquetaConsumidor(CONSUMIDOR oConsumidor)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (AgricolaSanJoseDataContext contexto = new AgricolaSanJoseDataContext(cnx))
            {
                var resultado = contexto.CONSUMIDOR.Where(x => x.IDCONSUMIDOR == oConsumidor.IDCONSUMIDOR && x.IDEMPRESA == oConsumidor.IDEMPRESA).ToList();
                if (resultado.Count() == 1)
                {
                    #region Modificar()
                    CONSUMIDOR oConsumidorModificado = new CONSUMIDOR();
                    oConsumidorModificado = resultado.Single();
                    oConsumidorModificado.TIPO = oConsumidor.TIPO;
                    contexto.SubmitChanges();
                    #endregion
                }

            }

        }


    }
}
