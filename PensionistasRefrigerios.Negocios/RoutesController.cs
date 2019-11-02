using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding.Busquedas;
using Asistencia.Datos;

namespace Asistencia.Negocios
{
    public class SJ_RHRutaNegocios
    {
        public List<SJ_RHListaRutasResult> ListarRutasDeRecorridos()
        {
            List<SJ_RHListaRutasResult> ListadoRutas = new List<SJ_RHListaRutasResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (BDAsistenciaDataContext Modelo = new BDAsistenciaDataContext(cnx))
            {
                ListadoRutas = Modelo.SJ_RHListaRutas().ToList();
                Modelo.Connection.Close();
            }
            return ListadoRutas.OrderByDescending(x => x.Id).ToList();
        }

        public bool AddRuta(SJ_RHRuta oRuta)
        {
            bool estate = false;
            using (TransactionScope Scope = new TransactionScope())
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (BDAsistenciaDataContext Modelo = new BDAsistenciaDataContext(cnx))
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

                            estate = true;

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
                            estate = true;
                        }
                        #endregion
                    }
                    #endregion
                    Modelo.Connection.Close();
                }
                Scope.Complete();
            }

            return estate;
        }


        public bool AddRutaIdaVuelta(SJ_RHRuta oRuta)
        {
            bool estate = false;
            using (TransactionScope Scope = new TransactionScope())
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
                {
                    #region Transaccion()

                    var resultIda = context.SJ_RHRuta.Where(x =>
                 x.RutaOrigen == oRuta.RutaOrigen &&
                 x.RutaDestino == oRuta.RutaDestino &&
                 x.abreviaturaRutaOrigen == oRuta.abreviaturaRutaOrigen &&
                 x.abreviaturaRuraDestino == oRuta.abreviaturaRuraDestino
                    ).ToList();

                    var resultVuelta = context.SJ_RHRuta.Where(x =>
                    x.RutaOrigen == oRuta.RutaDestino &&
                    x.RutaDestino == oRuta.RutaOrigen &&
                    x.abreviaturaRutaOrigen == oRuta.abreviaturaRuraDestino &&
                    x.abreviaturaRuraDestino == oRuta.abreviaturaRutaOrigen).ToList();

                    #region Ida()
                    if (resultIda != null && resultIda.ToList().Count == 0)
                    {
                        #region Agregar ida
                        SJ_RHRuta objeto = new SJ_RHRuta();
                        //objeto.Id = 0;
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
                        objeto.esIngreso = "1";
                        context.SJ_RHRuta.InsertOnSubmit(objeto);
                        context.SubmitChanges();
                        estate = true;
                        #endregion
                    }
                    //else if (resultIda != null && resultIda.ToList().Count == 1)
                    //{
                    //    #region Editar ida();
                    //    SJ_RHRuta objeto = new SJ_RHRuta();
                    //    objeto = resultIda.Single();
                    //    objeto.RutaOrigen = oRuta.RutaOrigen;
                    //    objeto.RutaDestino = oRuta.RutaDestino;
                    //    objeto.Distancia = oRuta.Distancia;
                    //    objeto.TiempoViaje = oRuta.TiempoViaje;
                    //    objeto.Observacion = oRuta.Observacion;
                    //    objeto.abreviaturaRutaOrigen = oRuta.abreviaturaRutaOrigen.ToString().Trim();
                    //    objeto.abreviaturaRuraDestino = oRuta.abreviaturaRuraDestino.ToString().Trim();
                    //    objeto.descripcionCortaDestino = oRuta.descripcionCortaDestino.ToString().Trim();
                    //    objeto.descripcionCortaOrigen = oRuta.descripcionCortaOrigen.ToString().Trim();
                    //    objeto.esIngreso = "1";
                    //    context.SubmitChanges();
                    //    estate = true;
                    //    #endregion
                    //}
                    #endregion


                    #region Vuelta()
                    if (resultVuelta != null && resultVuelta.ToList().Count == 0)
                    {
                        #region Agregar Vuelta
                        SJ_RHRuta objeto = new SJ_RHRuta();
                        //objeto.Id = 0;
                        objeto.RutaOrigen = oRuta.RutaDestino;
                        objeto.RutaDestino = oRuta.RutaOrigen;
                        objeto.Distancia = oRuta.Distancia;
                        objeto.TiempoViaje = oRuta.TiempoViaje;
                        objeto.Observacion = oRuta.Observacion;
                        objeto.IdEstado = oRuta.IdEstado;
                        objeto.FechaRegistro = DateTime.Now;
                        objeto.abreviaturaRutaOrigen = oRuta.abreviaturaRuraDestino.ToString().Trim();
                        objeto.abreviaturaRuraDestino = oRuta.abreviaturaRutaOrigen.ToString().Trim();
                        objeto.descripcionCortaDestino = oRuta.descripcionCortaOrigen.ToString().Trim();
                        objeto.descripcionCortaOrigen = oRuta.descripcionCortaDestino.ToString().Trim();
                        objeto.esIngreso = "0";
                        context.SJ_RHRuta.InsertOnSubmit(objeto);
                        context.SubmitChanges();
                        estate = true;
                        #endregion
                    }
                    //else if (resultVuelta != null && resultVuelta.ToList().Count == 1)
                    //{
                    //    #region Editar Vuelta();
                    //    SJ_RHRuta objeto = new SJ_RHRuta();
                    //    objeto = resultVuelta.Single();
                    //    objeto.RutaOrigen = oRuta.RutaDestino;
                    //    objeto.RutaDestino = oRuta.RutaOrigen;
                    //    objeto.Distancia = oRuta.Distancia;
                    //    objeto.TiempoViaje = oRuta.TiempoViaje;
                    //    objeto.Observacion = oRuta.Observacion;
                    //    objeto.abreviaturaRutaOrigen = oRuta.abreviaturaRuraDestino.ToString().Trim();
                    //    objeto.abreviaturaRuraDestino = oRuta.abreviaturaRutaOrigen.ToString().Trim();
                    //    objeto.descripcionCortaDestino = oRuta.descripcionCortaOrigen.ToString().Trim();
                    //    objeto.descripcionCortaOrigen = oRuta.descripcionCortaDestino.ToString().Trim();
                    //    objeto.esIngreso = "0";
                    //    context.SubmitChanges();
                    //    estate = true;
                    //    #endregion
                    //}
                    #endregion                 
                    #endregion
                    context.Connection.Close();
                }
                Scope.Complete();
            }

            return estate;
        }


        public void Anular(int CodigoRegistro)
        {
            using (TransactionScope Scope = new TransactionScope())
            {
                #region Transacción()

                string cnx = string.Empty;

                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

                using (BDAsistenciaDataContext Modelo = new BDAsistenciaDataContext(cnx))
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

                using (BDAsistenciaDataContext Modelo = new BDAsistenciaDataContext(cnx))
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

        public string GetSourceAbbreviatedPathName(string period, string abbreviateCode, string rutaOrigen)
        {
            string cnx, abbreviatePathName = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + period].ToString();
            using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
            {
                var resulta = context.SJ_RHRuta.Where(x => x.RutaOrigen == rutaOrigen && x.abreviaturaRutaOrigen.Trim() == abbreviateCode);
                if (resulta != null && resulta.ToList().Count > 0)
                {
                    abbreviatePathName = resulta.FirstOrDefault().descripcionCortaOrigen.Trim();
                }
            }
            return abbreviatePathName;
        }

        public string GetDestinationAbbreviatedPathName(string period, string abbreviateCode, string rutaDestino)
        {
            string cnx, abbreviatePathName = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + period].ToString();
            using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
            {
                var resulta = context.SJ_RHRuta.Where(x => x.RutaDestino.Trim() == rutaDestino.Trim() && x.abreviaturaRuraDestino.Trim() == abbreviateCode.Trim());
                if (resulta != null && resulta.ToList().Count > 0)
                {
                    abbreviatePathName = resulta.FirstOrDefault().descripcionCortaDestino.Trim();
                }
            }
            return abbreviatePathName;
        }

    }
}
