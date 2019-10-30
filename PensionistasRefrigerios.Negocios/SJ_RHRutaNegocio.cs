using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using TransportistaMto.Datos;

namespace Transportista.Negocios
{
    public class SJ_RHRutaNegocios
    {        
        public List<SJ_RHListaRutasResult> ListarRutasDeRecorridos()
        {
            List<SJ_RHListaRutasResult> ListadoRutas = new List<SJ_RHListaRutasResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                ListadoRutas = Modelo.SJ_RHListaRutas().ToList();
                Modelo.Connection.Close();
            }
            return ListadoRutas.OrderByDescending(x => x.Id).ToList();
        }

        public int Registrar(SJ_RHRuta oRuta)
        {
            int CodigoRegistro = 0;
            using (TransactionScope Scope = new TransactionScope())
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    #region Transaccion()

                    if (oRuta.Id == 0)
                    {
                        #region Nuevo()
                        try
                        {
                            SJ_RHRuta objeto = new SJ_RHRuta();
                            objeto.Id = 0;
                            objeto.RutaOrigen = oRuta.RutaOrigen;
                            objeto.RutaDestino = oRuta.RutaDestino;
                            objeto.Distancia = oRuta.Distancia;
                            objeto.TiempoViaje = oRuta.TiempoViaje;
                            objeto.Observacion = oRuta.Observacion;
                            objeto.IdEstado = oRuta.IdEstado;
                            objeto.FechaRegistro = DateTime.Now;
                            objeto.abreviaturaRutaOrigen = oRuta.abreviaturaRutaOrigen.ToString().Trim();
                            objeto.abreviaturaRuraDestino = oRuta.abreviaturaRuraDestino.ToString().Trim();
                            objeto.descripcionCortaDestino = oRuta.descripcionCortaDestino.ToString().Trim();
                            objeto.descripcionCortaOrigen = oRuta.descripcionCortaOrigen.ToString().Trim();
                            objeto.esIngreso = oRuta.esIngreso.ToString().Trim();
                            Modelo.SJ_RHRuta.InsertOnSubmit(objeto);
                            Modelo.SubmitChanges();

                            CodigoRegistro = objeto.Id;

                        }
                        catch (Exception Ex)
                        {
                            throw Ex;
                        }

                        #endregion
                    }
                    else
                    {
                        #region Modificar()
                        if (Modelo.SJ_RHRuta.Where(x => x.Id == oRuta.Id).ToList().Count == 1)
                        {
                            SJ_RHRuta objeto = new SJ_RHRuta();
                            objeto = Modelo.SJ_RHRuta.Where(x => x.Id == oRuta.Id).Single();
                            objeto.RutaOrigen = oRuta.RutaOrigen;
                            objeto.RutaDestino = oRuta.RutaDestino;
                            objeto.Distancia = oRuta.Distancia;
                            objeto.TiempoViaje = oRuta.TiempoViaje;
                            objeto.Observacion = oRuta.Observacion;
                            objeto.abreviaturaRutaOrigen = oRuta.abreviaturaRutaOrigen.ToString().Trim();
                            objeto.abreviaturaRuraDestino = oRuta.abreviaturaRuraDestino.ToString().Trim();
                            objeto.descripcionCortaDestino = oRuta.descripcionCortaDestino.ToString().Trim();
                            objeto.descripcionCortaOrigen = oRuta.descripcionCortaOrigen.ToString().Trim();
                            objeto.esIngreso = oRuta.esIngreso.ToString().Trim();
                            Modelo.SubmitChanges();
                            CodigoRegistro = oRuta.Id;
                        }
                        #endregion
                    }
                    #endregion
                    Modelo.Connection.Close();
                }
                Scope.Complete();
            }

            return CodigoRegistro;
        }

        public void Anular(int CodigoRegistro)
        {
            using (TransactionScope Scope = new TransactionScope())
            {
                #region Transacción()

                string cnx = string.Empty;

                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    if (Modelo.SJ_RHRuta.Where(x => x.Id == CodigoRegistro).ToList().Count == 1)
                    {
                        //Anular
                        try
                        {
                            SJ_RHRuta oRuta = new SJ_RHRuta();
                            oRuta = Modelo.SJ_RHRuta.Where(x => x.Id == CodigoRegistro).Single();
                            oRuta.IdEstado = "AN";
                            Modelo.SubmitChanges();
                        }
                        catch (Exception Ex)
                        {

                            throw Ex;
                        }

                    }

                }
                #endregion

                Scope.Complete();
            }
        }

        public void Eliminar(int CodigoRegistro)
        {
            using (TransactionScope Scope = new TransactionScope())
            {
                #region Transacción()

                string cnx = string.Empty;

                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    if (Modelo.SJ_RHRuta.Where(x => x.Id == CodigoRegistro).ToList().Count == 1)
                    {
                        //Anular
                        try
                        {
                            SJ_RHRuta oRuta = new SJ_RHRuta();
                            oRuta = Modelo.SJ_RHRuta.Where(x => x.Id == CodigoRegistro).Single();
                            Modelo.SJ_RHRuta.DeleteOnSubmit(oRuta);
                            Modelo.SubmitChanges();
                        }
                        catch (Exception Ex)
                        {

                            throw Ex;
                        }

                    }

                }
                #endregion

                Scope.Complete();
            }
        }

    }
}
