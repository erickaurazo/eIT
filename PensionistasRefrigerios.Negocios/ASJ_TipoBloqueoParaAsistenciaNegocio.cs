using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using TransportistaMto.Datos;
using System.Configuration;

namespace Asistencia.Negocios
{
    public class ASJ_TipoBloqueoParaAsistenciaNegocio
    {

        string cnx = string.Empty;

        public string Grabar(string periodo, ASJ_PersonalTipoBloqueo personalBloqueo)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<ASJ_PersonalTipoBloqueo> resultadoConsulta = new List<ASJ_PersonalTipoBloqueo>();
            ASJ_PersonalTipoBloqueo oTipoBloqueo = new ASJ_PersonalTipoBloqueo();

            using (SJ_RHFacturacionTransportistaDataContext modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                modelo.CommandTimeout = 9999900;
                resultadoConsulta = modelo.ASJ_PersonalTipoBloqueo.Where(x => x.codigoPersonalTipoBloqueo == personalBloqueo.codigoPersonalTipoBloqueo).ToList();
                int nuevoCodigo = Convert.ToInt32(modelo.ASJ_PersonalTipoBloqueo.Max(x => x.codigoPersonalTipoBloqueo)) + 1;

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Editar()
                    oTipoBloqueo = resultadoConsulta.Single();
                    oTipoBloqueo.descripcion = personalBloqueo.descripcion != null ? personalBloqueo.descripcion.Trim() : string.Empty;
                    oTipoBloqueo.color = personalBloqueo.color != null ? personalBloqueo.color.Trim() : string.Empty;
                    modelo.SubmitChanges();
                    resultado = "Transacción satisfactorio";
                    #endregion
                }
                else if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 0)
                {
                    #region Registrar()
                    oTipoBloqueo.codigoPersonalTipoBloqueo = nuevoCodigo.ToString().PadLeft(3, '0');
                    oTipoBloqueo.descripcion = personalBloqueo.descripcion != null ? personalBloqueo.descripcion.Trim() : string.Empty;
                    oTipoBloqueo.color = personalBloqueo.color != null ? personalBloqueo.color.Trim() : string.Empty;
                    oTipoBloqueo.estado = 1;
                    modelo.ASJ_PersonalTipoBloqueo.InsertOnSubmit(oTipoBloqueo);
                    modelo.SubmitChanges();
                    resultado = "Transacción satisfactorio";
                    #endregion
                }
            }

            return resultado;
        }

        public string GrabarListado(string periodo, List<ASJ_PersonalTipoBloqueo> listadoTipoBloqueo)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<ASJ_PersonalTipoBloqueo> resultadoConsulta = new List<ASJ_PersonalTipoBloqueo>();
            ASJ_PersonalTipoBloqueo oTipoBloqueo = new ASJ_PersonalTipoBloqueo();






            return resultado;
        }

        public string Anular(string periodo, ASJ_PersonalTipoBloqueo personalBloqueo)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<ASJ_PersonalTipoBloqueo> resultadoConsulta = new List<ASJ_PersonalTipoBloqueo>();
            ASJ_PersonalTipoBloqueo oTipoBloqueo = new ASJ_PersonalTipoBloqueo();

            using (SJ_RHFacturacionTransportistaDataContext modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                modelo.CommandTimeout = 9999900;
                resultadoConsulta = modelo.ASJ_PersonalTipoBloqueo.Where(x => x.codigoPersonalTipoBloqueo == personalBloqueo.codigoPersonalTipoBloqueo).ToList();
                int nuevoCodigo = Convert.ToInt32(modelo.ASJ_PersonalTipoBloqueo.Max(x => x.codigoPersonalTipoBloqueo)) + 1;

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Activar o Anular()
                    oTipoBloqueo = resultadoConsulta.Single();


                    if (oTipoBloqueo.estado == 1)
                    {
                        oTipoBloqueo.estado = 0;
                        resultado = "Registro Anulado";
                    }
                    else if (oTipoBloqueo.estado == 0)
                    {
                        oTipoBloqueo.estado = 1;
                        resultado = "Registro Activado";
                    }

                    modelo.SubmitChanges();

                    #endregion
                }

            }

            return resultado;
        }

        public string Eliminar(string periodo, ASJ_PersonalTipoBloqueo personalBloqueo)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<ASJ_PersonalTipoBloqueo> resultadoConsulta = new List<ASJ_PersonalTipoBloqueo>();
            ASJ_PersonalTipoBloqueo oTipoBloqueo = new ASJ_PersonalTipoBloqueo();

            using (SJ_RHFacturacionTransportistaDataContext modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                modelo.CommandTimeout = 9999900;
                resultadoConsulta = modelo.ASJ_PersonalTipoBloqueo.Where(x => x.codigoPersonalTipoBloqueo == personalBloqueo.codigoPersonalTipoBloqueo).ToList();
                int nuevoCodigo = Convert.ToInt32(modelo.ASJ_PersonalTipoBloqueo.Max(x => x.codigoPersonalTipoBloqueo)) + 1;

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Activar o Anular()
                    oTipoBloqueo = resultadoConsulta.Single();


                    if (oTipoBloqueo.estado == 1)
                    {
                        modelo.ASJ_PersonalTipoBloqueo.DeleteOnSubmit(oTipoBloqueo);
                        resultado = "Registro Eliminado";
                    }
                    else if (oTipoBloqueo.estado == 0)
                    {
                        resultado = "No se puede eliminar registro anulado";
                    }

                    modelo.SubmitChanges();

                    #endregion
                }

            }

            return resultado;
        }

        public List<ASJ_ObtenerListadoDeTipoPersonalbloqueadoResult> ObtenerListadoTipoBloqueo(string periodo)
        {
            List<ASJ_ObtenerListadoDeTipoPersonalbloqueadoResult> listado = new List<ASJ_ObtenerListadoDeTipoPersonalbloqueadoResult>();

            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                listado = Modelo.ASJ_ObtenerListadoDeTipoPersonalbloqueado().ToList();
            }

            return listado;
        }


    }
}
