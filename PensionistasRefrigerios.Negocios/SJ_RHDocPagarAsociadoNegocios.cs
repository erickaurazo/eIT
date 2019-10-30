using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using TransportistaMto.Datos;

namespace Transportista.Negocios
{
    public class SJ_RHDocPagarAsociadoNegocios
    {

        public SJ_RHDocPagarAsociado ObtenerObjeto(SJ_RHDocPagar documentoPagar)
        {
            SJ_RHDocPagarAsociado documento = new SJ_RHDocPagarAsociado();
            documento.codigo = "";
            documento.idDocumento = "";
            documento.serie = "";
            documento.numero = "";
            documento.fecha = (DateTime?)null;

            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    Modelo.CommandTimeout = 999998;

                    var resultadoConsulta = Modelo.SJ_RHDocPagarAsociados.Where(x => x.codigo == documentoPagar.codigo).ToList();


                    if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                    {
                        documento = resultadoConsulta.Single();
                    }

                    Modelo.Connection.Close();
                    Modelo.Dispose();
                }
            }

            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }

            return documento;
        }

        public void Registrar(SJ_RHDocPagarAsociado documentoPagarAsociado)
        {
            SJ_RHDocPagarAsociado documento = new SJ_RHDocPagarAsociado();

            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    Modelo.CommandTimeout = 999998;

                    var resultadoConsulta = Modelo.SJ_RHDocPagarAsociados.Where(x => x.codigo == documentoPagarAsociado.codigo).ToList();

                    if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                    {
                        #region Actualizar()
                        documento = resultadoConsulta.Single();
                        documento.idDocumento = documentoPagarAsociado.idDocumento != null ? documentoPagarAsociado.idDocumento.ToString().Trim() : "";
                        documento.serie = documentoPagarAsociado.serie != null ? documentoPagarAsociado.serie.ToString().Trim() : "";
                        documento.numero = documentoPagarAsociado.numero != null ? documentoPagarAsociado.numero.ToString().Trim() : "";
                        documento.fecha = documentoPagarAsociado.fecha != null ? documentoPagarAsociado.fecha : (DateTime?)null;
                        Modelo.SubmitChanges();
                        #endregion
                    }
                    else if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 0)
                    {
                        #region Registrar()
                        documento.codigo = documentoPagarAsociado.codigo != null ? documentoPagarAsociado.codigo.ToString().Trim() : "";
                        documento.idDocumento = documentoPagarAsociado.idDocumento != null ? documentoPagarAsociado.idDocumento.ToString().Trim() : "";
                        documento.serie = documentoPagarAsociado.serie != null ? documentoPagarAsociado.serie.ToString().Trim() : "";
                        documento.numero = documentoPagarAsociado.numero != null ? documentoPagarAsociado.numero.ToString().Trim() : "";
                        documento.fecha = documentoPagarAsociado.fecha != null ? documentoPagarAsociado.fecha : (DateTime?)null;
                        documento.item = "001";
                        Modelo.SJ_RHDocPagarAsociados.InsertOnSubmit(documento);
                        Modelo.SubmitChanges();
                        #endregion
                    }

                    Modelo.Connection.Close();
                    Modelo.Dispose();
                }
            }

            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }

        public void Eliminar(SJ_RHDocPagarAsociado documentoPagarAsociado)
        {
            SJ_RHDocPagarAsociado documento = new SJ_RHDocPagarAsociado();

            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    Modelo.CommandTimeout = 999998;

                    var resultadoConsulta = Modelo.SJ_RHDocPagarAsociados.Where(x => x.codigo == documentoPagarAsociado.codigo).ToList();

                    if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                    {
                        #region Actualizar()
                        documento = resultadoConsulta.Single();
                        Modelo.SJ_RHDocPagarAsociados.DeleteOnSubmit(documento);
                        Modelo.SubmitChanges();
                        #endregion
                    }

                    Modelo.Connection.Close();
                    Modelo.Dispose();
                }
            }

            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }
    }

}
