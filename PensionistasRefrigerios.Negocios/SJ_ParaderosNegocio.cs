using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding.Busquedas;
using Asistencia.Datos;

namespace Asistencia.Negocios
{
    public class SJ_ParaderosNegocio
    {
        string cnx = string.Empty;

        public string Grabar(string periodo, SJ_Paraderos paradero)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<SJ_Paraderos> resultadoConsulta = new List<SJ_Paraderos>();
            SJ_Paraderos oSJ_Paraderos = new SJ_Paraderos();

            using (SJ_RHFacturacionTransportistaDataContext modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                modelo.CommandTimeout = 9999900;
                resultadoConsulta = modelo.SJ_Paraderos1.Where(x => x.IdParadero == paradero.IdParadero).ToList();
                int nuevoCodigo = Convert.ToInt32(modelo.SJ_Paraderos1.Max(x => x.IdParadero)) + 1;
                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Editar()
                    oSJ_Paraderos = resultadoConsulta.Single();
                    // oSJ_Paraderos.IdEmpresa = paradero.IdEmpresa;
                    //oSJ_Paraderos.IdParadero = paradero.IdParadero;
                    oSJ_Paraderos.DescripcionParadero = paradero.DescripcionParadero;
                    oSJ_Paraderos.Observacion = paradero.Observacion;
                    //oSJ_Paraderos.ESTADO = paradero.ESTADO;
                    oSJ_Paraderos.tipo = paradero.tipo;


                    modelo.SubmitChanges();
                    resultado = "Transacción satisfactorio";
                    #endregion
                }
                else if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 0)
                {
                    #region Registrar()
                    oSJ_Paraderos = new SJ_Paraderos();
                    oSJ_Paraderos.IdEmpresa = paradero.IdEmpresa;
                    oSJ_Paraderos.IdParadero = nuevoCodigo.ToString().PadLeft(3, '0');
                    oSJ_Paraderos.DescripcionParadero = paradero.DescripcionParadero;
                    oSJ_Paraderos.Observacion = paradero.Observacion;
                    oSJ_Paraderos.ESTADO = paradero.ESTADO;
                    modelo.SJ_Paraderos1.InsertOnSubmit(oSJ_Paraderos);
                    modelo.SubmitChanges();
                    resultado = "Transacción satisfactorio";
                    #endregion
                }
            }
            return resultado;
        }

        public string Anular(string periodo, SJ_Paraderos paradero)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<SJ_Paraderos> resultadoConsulta = new List<SJ_Paraderos>();
            SJ_Paraderos oSJ_Paraderos = new SJ_Paraderos();

            using (SJ_RHFacturacionTransportistaDataContext modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                modelo.CommandTimeout = 9999900;
                resultadoConsulta = modelo.SJ_Paraderos1.Where(x => x.IdParadero == paradero.IdParadero && x.IdEmpresa == paradero.IdEmpresa).ToList();
                int nuevoCodigo = Convert.ToInt32(modelo.SJ_Paraderos1.Max(x => x.IdParadero)) + 1;

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Activar o Anular()
                    oSJ_Paraderos = resultadoConsulta.Single();


                    if (oSJ_Paraderos.ESTADO == 1)
                    {
                        oSJ_Paraderos.ESTADO = 0;
                        resultado = "Registro Anulado";
                    }
                    else if (oSJ_Paraderos.ESTADO == 0)
                    {
                        oSJ_Paraderos.ESTADO = 1;
                        resultado = "Registro Activado";
                    }

                    modelo.SubmitChanges();

                    #endregion
                }

            }

            return resultado;
        }

        public string Eliminar(string periodo, SJ_Paraderos paradero)
        {
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            List<SJ_Paraderos> resultadoConsulta = new List<SJ_Paraderos>();
            SJ_Paraderos oSJ_Paraderos = new SJ_Paraderos();

            using (SJ_RHFacturacionTransportistaDataContext modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                modelo.CommandTimeout = 9999900;
                resultadoConsulta = modelo.SJ_Paraderos1.Where(x => x.IdParadero == paradero.IdParadero && x.IdEmpresa == paradero.IdEmpresa).ToList();
                int nuevoCodigo = Convert.ToInt32(modelo.SJ_Paraderos1.Max(x => x.IdParadero)) + 1;

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                {
                    #region Activar o Anular()
                    oSJ_Paraderos = resultadoConsulta.Single();


                    if (oSJ_Paraderos.ESTADO == 1)
                    {
                        modelo.SJ_Paraderos1.DeleteOnSubmit(oSJ_Paraderos);
                        resultado = "Registro eliminado";
                    }
                    else if (oSJ_Paraderos.ESTADO == 0)
                    {
                        oSJ_Paraderos.ESTADO = 1;
                        resultado = "Registro Activado";
                    }

                    modelo.SubmitChanges();

                    #endregion
                }

            }

            return resultado;
        }

        public List<SJ_Paraderos> ListarTodos(string periodo)
        {
            List<SJ_Paraderos> listado = new List<SJ_Paraderos>();

            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(0, 4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                listado = Modelo.SJ_Paraderos1.ToList();
            }

            return listado;
        }


    }
}
