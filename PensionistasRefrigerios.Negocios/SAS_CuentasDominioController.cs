using Asistencia.Datos;
using MyControlsDataBinding.Busquedas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Asistencia.Negocios
{
    public class SAS_CuentasDominioController
    {


        public List<SAS_CuentasDominio> GetDomainAccounts(string conection)
        {
            List<SAS_CuentasDominio> listado = new List<SAS_CuentasDominio>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                listado = model.SAS_CuentasDominio.ToList();
            }
            return listado.OrderBy(x => x.cuenta).ToList();
        }


        public List<SAS_CuentasDominioListado> GetListOfDomainAccounts(string conection)
        {
            List<SAS_CuentasDominioListado> listado = new List<SAS_CuentasDominioListado>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                listado = model.SAS_CuentasDominioListado.ToList();
            }
            return listado.OrderBy(x => x.cuenta).ToList();
        }

        public int Register(string conection, SAS_CuentasDominio item)
        {
            //SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();

            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    var resultado = model.SAS_CuentasDominio.Where(x => x.id == item.id).ToList();
                    if (resultado != null)
                    {
                        #region Registro | Actualizacion() 
                        if (resultado.ToList().Count == 0)
                        {
                            #region Nuevo();
                            SAS_CuentasDominio oregistro = new SAS_CuentasDominio();
                            oregistro.id = item.id;
                            oregistro.cuenta = item.cuenta;
                            oregistro.estado = item.estado;
                            oregistro.idcodigoGeneral = item.idcodigoGeneral;
                            oregistro.vienesDesdeSolicitud = item.vienesDesdeSolicitud;
                            oregistro.codigoSolicitud = item.codigoSolicitud;
                            oregistro.observaciones = item.observaciones;
                            oregistro.fechaActivacion = item.fechaActivacion;
                            oregistro.fechaBaja = item.fechaBaja;
                            oregistro.esCorportativo = item.esCorportativo;
                            oregistro.clave = item.clave;


                            model.SAS_CuentasDominio.InsertOnSubmit(oregistro);
                            model.SubmitChanges();
                            tipoResultadoOperacion = 0; // registrar
                            #endregion
                        }
                        else if (resultado.ToList().Count == 1)
                        {
                            #region Actualizar()
                            SAS_CuentasDominio oregistro = new SAS_CuentasDominio();
                            oregistro = resultado.Single();
                            oregistro.cuenta = item.cuenta;
                            oregistro.estado = item.estado;
                            oregistro.idcodigoGeneral = item.idcodigoGeneral;
                            oregistro.vienesDesdeSolicitud = item.vienesDesdeSolicitud;
                            oregistro.codigoSolicitud = item.codigoSolicitud;
                            oregistro.observaciones = item.observaciones;
                            oregistro.fechaActivacion = item.fechaActivacion;
                            oregistro.fechaBaja = item.fechaBaja;
                            oregistro.esCorportativo = item.esCorportativo;
                            oregistro.clave = item.clave;

                            model.SubmitChanges();
                            #endregion
                            tipoResultadoOperacion = 1; // modificar
                        }
                        #endregion
                    }
                    Scope.Complete();
                }
            }

            return tipoResultadoOperacion;

        }


        public int Register(string conection, SAS_CuentasDominio item, List<SAS_CuentasDominioDetalle> detalleEliminados, List<SAS_CuentasDominioDetalle> detalles)
        {
            //SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();

            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    var resultado = model.SAS_CuentasDominio.Where(x => x.id == item.id).ToList();
                    if (resultado != null)
                    {
                        #region Registro | Actualizacion() 
                        if (resultado.ToList().Count == 0)
                        {
                            #region Nuevo();
                            SAS_CuentasDominio oregistro = new SAS_CuentasDominio();
                            oregistro.id = item.id;
                            oregistro.cuenta = item.cuenta;
                            oregistro.estado = item.estado;
                            oregistro.idcodigoGeneral = item.idcodigoGeneral;
                            oregistro.vienesDesdeSolicitud = item.vienesDesdeSolicitud;
                            oregistro.codigoSolicitud = item.codigoSolicitud;
                            oregistro.observaciones = item.observaciones;
                            oregistro.fechaActivacion = item.fechaActivacion;
                            oregistro.fechaBaja = item.fechaBaja;
                            oregistro.esCorportativo = item.esCorportativo;
                            oregistro.clave = item.clave;
                            oregistro.idPerfilCuenta = item.idPerfilCuenta;
                            oregistro.nombres = item.nombres;
                            model.SAS_CuentasDominio.InsertOnSubmit(oregistro);
                            model.SubmitChanges();
                            tipoResultadoOperacion = 0; // registrar
                            #endregion

                            if (detalles != null)
                            {
                                #region Registrar detalle() 
                                if (detalles.ToList().Count > 0)
                                {
                                    foreach (var itemDetalle in detalles)
                                    {
                                        var resultadoDetalle = model.SAS_CuentasDominioDetalle.Where(x => x.id == oregistro.id && x.item == itemDetalle.item).ToList();
                                        if (resultadoDetalle.Count == 0)
                                        {
                                            #region Registrar() 
                                            SAS_CuentasDominioDetalle oDetalle = new SAS_CuentasDominioDetalle();
                                            oDetalle.id = oregistro.id;
                                            oDetalle.item = itemDetalle.item;
                                            oDetalle.idTipo = itemDetalle.idTipo;
                                            oDetalle.link = itemDetalle.link;
                                            oDetalle.descripcion = itemDetalle.descripcion;
                                            oDetalle.estado = itemDetalle.estado;
                                            oDetalle.creadoPor = Environment.UserName;
                                            model.SAS_CuentasDominioDetalle.InsertOnSubmit(oDetalle);
                                            model.SubmitChanges();
                                            #endregion
                                        }
                                        else if (resultadoDetalle.Count == 1)
                                        {
                                            #region Modificar() 
                                            SAS_CuentasDominioDetalle oDetalle = new SAS_CuentasDominioDetalle();
                                            oDetalle = resultadoDetalle.Single();
                                            oDetalle.idTipo = itemDetalle.idTipo;
                                            oDetalle.link = itemDetalle.link;
                                            oDetalle.descripcion = itemDetalle.descripcion;
                                            oDetalle.estado = itemDetalle.estado;
                                            oDetalle.creadoPor = Environment.UserName;
                                            model.SubmitChanges();
                                            #endregion  
                                        }
                                    }
                                }
                                #endregion
                            }

                        }
                        else if (resultado.ToList().Count == 1)
                        {
                            #region Actualizar()
                            SAS_CuentasDominio oregistro = new SAS_CuentasDominio();
                            oregistro = resultado.Single();
                            oregistro.cuenta = item.cuenta;
                            oregistro.estado = item.estado;
                            oregistro.idcodigoGeneral = item.idcodigoGeneral;
                            oregistro.vienesDesdeSolicitud = item.vienesDesdeSolicitud;
                            oregistro.codigoSolicitud = item.codigoSolicitud;
                            oregistro.observaciones = item.observaciones;
                            oregistro.fechaActivacion = item.fechaActivacion;
                            oregistro.fechaBaja = item.fechaBaja;
                            oregistro.esCorportativo = item.esCorportativo;
                            oregistro.clave = item.clave;
                            oregistro.idPerfilCuenta = item.idPerfilCuenta;
                            oregistro.nombres = item.nombres;
                            model.SubmitChanges();
                            #endregion
                            tipoResultadoOperacion = 1; // modificar


                            #region eliminar listado detalle() 
                            if (detalleEliminados != null)
                            {
                                #region Eliminar detalle() 
                                if (detalleEliminados.ToList().Count > 0)
                                {
                                    foreach (var itemDetalle in detalleEliminados)
                                    {
                                        var resultadoDetalle = model.SAS_CuentasDominioDetalle.Where(x => x.id == itemDetalle.id && x.item == itemDetalle.item).ToList();
                                        if (resultadoDetalle.Count == 1)
                                        {
                                            #region Modificar() 
                                            SAS_CuentasDominioDetalle oDetalle = new SAS_CuentasDominioDetalle();
                                            oDetalle = resultadoDetalle.Single();
                                            model.SAS_CuentasDominioDetalle.DeleteOnSubmit(oDetalle);
                                            model.SubmitChanges();
                                            #endregion  
                                        }
                                    }
                                }
                                #endregion
                            }
                            #endregion

                            #region Registrar detalle() 
                            if (detalles != null)
                            {
                                #region Registrar detalle() 
                                if (detalles.ToList().Count > 0)
                                {
                                    foreach (var itemDetalle in detalles)
                                    {
                                        var resultadoDetalle = model.SAS_CuentasDominioDetalle.Where(x => x.id == itemDetalle.id && x.item == itemDetalle.item).ToList();
                                        if (resultadoDetalle.Count == 0)
                                        {
                                            #region Registrar() 
                                            SAS_CuentasDominioDetalle oDetalle = new SAS_CuentasDominioDetalle();
                                            oDetalle.id = item.id;
                                            oDetalle.item = itemDetalle.item;
                                            oDetalle.idTipo = itemDetalle.idTipo;
                                            oDetalle.link = itemDetalle.link;
                                            oDetalle.descripcion = itemDetalle.descripcion;
                                            oDetalle.estado = itemDetalle.estado;
                                            oDetalle.creadoPor = Environment.UserName;
                                            model.SAS_CuentasDominioDetalle.InsertOnSubmit(oDetalle);
                                            model.SubmitChanges();
                                            #endregion
                                        }
                                        else if (resultadoDetalle.Count == 1)
                                        {
                                            #region Modificar() 
                                            SAS_CuentasDominioDetalle oDetalle = new SAS_CuentasDominioDetalle();
                                            oDetalle = resultadoDetalle.Single();
                                            oDetalle.idTipo = itemDetalle.idTipo;
                                            oDetalle.link = itemDetalle.link;
                                            oDetalle.descripcion = itemDetalle.descripcion;
                                            oDetalle.estado = itemDetalle.estado;
                                            oDetalle.creadoPor = Environment.UserName;
                                            //model.SAS_CuentasCorreoDetalle.InsertOnSubmit(oDetalle);
                                            model.SubmitChanges();
                                            #endregion  
                                        }
                                    }
                                }
                                #endregion
                            }
                            #endregion


                        }
                        #endregion
                    }
                    Scope.Complete();
                }
            }

            return tipoResultadoOperacion;

        }


        public int ChangeState(string conection, SAS_CuentasDominio item)
        {

            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                var resultado = model.SAS_CuentasDominio.Where(x => x.id == item.id).ToList();
                if (resultado != null)
                {
                    if (resultado.ToList().Count == 1)
                    {
                        #region Cambiar de estado()
                        SAS_CuentasDominio oregistro = new SAS_CuentasDominio();
                        oregistro = resultado.Single();

                        if (oregistro.estado == 1)
                        {
                            oregistro.estado = 0;
                            tipoResultadoOperacion = 2; // desactivar
                        }
                        else
                        {
                            oregistro.estado = 1;
                            tipoResultadoOperacion = 3; // Activar
                        }
                        model.SubmitChanges();
                        #endregion                       
                    }
                }
            }
            return tipoResultadoOperacion;
        }

        public int registerUnsubscribe(string conection, SAS_CuentasDominio item)
        {
            //SAS_DispositivoTipoSoftware oregistro = new SAS_DispositivoTipoSoftware();
            int tipoResultadoOperacion = 1; // 1 es registro , 0 es nuevo
            string cnx = ConfigurationManager.AppSettings[conection].ToString();

            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    var resultado = model.SAS_CuentasDominio.Where(x => x.id == item.id).ToList();
                    if (resultado != null)
                    {
                        #region REGISTRAR BAJA  
                        if (resultado.ToList().Count == 1)
                        {
                            #region Actualizar()
                            SAS_CuentasDominio oregistro = new SAS_CuentasDominio();
                            oregistro = resultado.Single();
                            oregistro.fechaBaja = item.fechaBaja;
                            model.SubmitChanges();
                            #endregion
                            tipoResultadoOperacion = 5; // baja
                        }
                        #endregion
                    }
                    Scope.Complete();
                }
            }

            return tipoResultadoOperacion;

        }

        public List<SAS_CuentasDominioDetalleByIdResult> GetDomainAccountsDetailById(string conection, SAS_CuentasDominio item)
        {

            List<SAS_CuentasDominioDetalleByIdResult> listado = new List<SAS_CuentasDominioDetalleByIdResult>();
            string cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext model = new SATURNODataContext(cnx))
            {
                listado = model.SAS_CuentasDominioDetalleById(item.id).ToList();
            }
            return listado.OrderBy(x => x.item).ToList();
        }

        public List<DFormatoSimple> FeatureType(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                listado.Add(new DFormatoSimple { Codigo = "1", Descripcion = "BackUp" });
                listado.Add(new DFormatoSimple { Codigo = "2", Descripcion = "Imagen" });
                listado.Add(new DFormatoSimple { Codigo = "3", Descripcion = "Pertenencia en grupo" });
                listado.Add(new DFormatoSimple { Codigo = "4", Descripcion = "Unidad compartida" });
            }
            return listado;
        }


        public List<DFormatoSimple> GetType(string conection)
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            string cnx;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (SATURNODataContext Contexto = new SATURNODataContext(cnx))
            {
                listado.Add(new DFormatoSimple { Codigo = "1", Descripcion = "BackUp" });
                listado.Add(new DFormatoSimple { Codigo = "2", Descripcion = "Imagen" });
            }
            return listado;
        }

    }
}
