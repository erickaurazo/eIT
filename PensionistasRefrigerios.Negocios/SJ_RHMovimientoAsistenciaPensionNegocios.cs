using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using TransportistaMto.Datos;

namespace Transportista.Negocios
{
    public class SJ_RHMovimientoAsistenciaPensionNegocios
    {
        private SJ_RHMovimientoAsistenciaPensionNegocios modelo;

        public List<SJ_RHMovimientoAsistenciaPension> ObtenerListaMovimientosAsistenciaByPeriodo(string desde, string hasta, string idProveedor)
        {
            List<SJ_RHMovimientoAsistenciaPension> listado = new List<SJ_RHMovimientoAsistenciaPension>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2015"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                listado = Modelo.SJ_RHMovimientoAsistenciaPensions.ToList();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return listado;
        }

        public SJ_RHMovimientoAsistenciaPension ObtenerMovimientosAsistenciaByCodigo(SJ_RHMovimientoAsistenciaPension movimientoAsistencia)
        {
            SJ_RHMovimientoAsistenciaPension oMovimientoAsistencia = new SJ_RHMovimientoAsistenciaPension();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2015"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                oMovimientoAsistencia = Modelo.SJ_RHMovimientoAsistenciaPensions.Where(x => x.idMovimiento == oMovimientoAsistencia.idMovimiento).Single();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return oMovimientoAsistencia;
        }

        public string Registrar(SJ_RHMovimientoAsistenciaPension movimientoAsistencia, List<SJ_RHMovimientoAsistenciaPensionDetalle> detalleMovimiento, List<SJ_RHMovimientoAsistenciaPensionDetalle> detalleMovimientoEliminado, List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult> detalleAsistenciaDesdeProgramacion)
        {
            List<SJ_RHMovimientoAsistenciaPension> listado = new List<SJ_RHMovimientoAsistenciaPension>();
            string cnx, codigo = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2015"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                codigo = modelo.ObtenerNuevoCodigo("2014");
                /* Generar asistencia en la tabla sjm_pension */
                if (detalleAsistenciaDesdeProgramacion != null && detalleAsistenciaDesdeProgramacion.ToList().Count > 0)
                {
                    foreach (var item in detalleAsistenciaDesdeProgramacion)
                    {
                        if (item.codigoTransferencia == 0)
                        {
                            #region
                            SJM_Pensione registroAsistencia = new SJM_Pensione();
                            registroAsistencia.DniPension = item.DniPension;
                            registroAsistencia.NombresPension = item.NombresPension;
                            registroAsistencia.DniTrabajador = item.DniTrabajador;
                            registroAsistencia.NombresTrabajador = item.NombresTrabajador;
                            registroAsistencia.TipoComida = item.TipoComida;
                            registroAsistencia.FechaPension = item.FechaPension;
                            registroAsistencia.FechaRegistro = item.FechaRegistro;
                            registroAsistencia.EsProcesado = 0;
                            registroAsistencia.estado = 1;
                            registroAsistencia.excluirDescuento = 0;
                            registroAsistencia.CodigoRegistroAsistencia = codigo;


                            contexto.SJM_Pensiones.InsertOnSubmit(registroAsistencia);
                            contexto.SubmitChanges();
                            SJM_Pensione registroAsistencia2 = new SJM_Pensione();
                            registroAsistencia2 = registroAsistencia;

                            SJ_RHMovimientoAsistenciaPensionDetalle detalle = new SJ_RHMovimientoAsistenciaPensionDetalle();
                            detalle.idMovimiento = string.Empty;
                            //detalle.item = 0;
                            detalle.codigoTransferenciaAsistenciaMovil = registroAsistencia2.IdPension;
                            detalle.estado = 1;
                            detalle.glosa = string.Empty;
                            detalleMovimiento.Add(detalle);
                            #endregion
                        }
                    }
                }

                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();

                if ((movimientoAsistencia.idMovimiento != null ? movimientoAsistencia.idMovimiento.ToString().Trim() : string.Empty) == string.Empty)
                {

                    #region Registrar()
                    SJ_RHMovimientoAsistenciaPension oMovimiento = new SJ_RHMovimientoAsistenciaPension();
                    oMovimiento.idSucursal = movimientoAsistencia.idSucursal != null ? movimientoAsistencia.idSucursal.ToString().Trim() : string.Empty;
                    oMovimiento.idEmpresa = movimientoAsistencia.idEmpresa != null ? movimientoAsistencia.idEmpresa.ToString().Trim() : string.Empty;
                    oMovimiento.idMovimiento = codigo;
                    oMovimiento.idclieprov = movimientoAsistencia.idclieprov != null ? movimientoAsistencia.idclieprov.ToString().Trim() : string.Empty;
                    oMovimiento.dniPension = movimientoAsistencia.dniPension != null ? movimientoAsistencia.dniPension.ToString().Trim() : string.Empty;
                    oMovimiento.fecha = movimientoAsistencia.fecha != null ? movimientoAsistencia.fecha : DateTime.Now;
                    oMovimiento.idDocumento = movimientoAsistencia.idDocumento != null ? movimientoAsistencia.idDocumento.ToString().Trim() : string.Empty;
                    oMovimiento.serie = movimientoAsistencia.serie != null ? movimientoAsistencia.serie.ToString().Trim() : string.Empty;
                    oMovimiento.numero = movimientoAsistencia.numero != null ? movimientoAsistencia.numero.ToString().Trim() : string.Empty;
                    oMovimiento.numeroOperacion = movimientoAsistencia.numeroOperacion != null ? movimientoAsistencia.numeroOperacion.ToString().Trim() : string.Empty;
                    oMovimiento.periodo = movimientoAsistencia.periodo != null ? movimientoAsistencia.periodo.ToString().Trim() : string.Empty;
                    oMovimiento.estado = movimientoAsistencia.estado != null ? movimientoAsistencia.estado : 0;
                    oMovimiento.idEstado = movimientoAsistencia.idEstado != null ? movimientoAsistencia.idEstado.ToString().Trim() : string.Empty;
                    oMovimiento.registradoPor = movimientoAsistencia.registradoPor != null ? movimientoAsistencia.registradoPor.ToString().Trim() : string.Empty;
                    oMovimiento.maquinanaRegistrada = movimientoAsistencia.maquinanaRegistrada != null ? movimientoAsistencia.maquinanaRegistrada.ToString().Trim() : string.Empty;
                    oMovimiento.fechaRegistro = movimientoAsistencia.fechaRegistro != null ? movimientoAsistencia.fechaRegistro.Value : (DateTime?)null;
                    oMovimiento.NombreMes = movimientoAsistencia.NombreMes != null ? movimientoAsistencia.NombreMes.ToString().Trim() : string.Empty;
                    //oMovimiento.SJ_RHMovimientoAsistenciaPensionDetalles.AddRange(detalleMovimiento);
                    contexto.SJ_RHMovimientoAsistenciaPensions.InsertOnSubmit(oMovimiento);
                    //1.- contexto.SubmitChanges();



                    #endregion

                    #region Registrar detalle y Asociar movimiento de asistencia a transferencia de moviles(estado a 1)
                    if (detalleMovimiento != null && detalleMovimiento.Where(x => x.codigoTransferenciaAsistenciaMovil > 0).ToList().Count > 0)
                    {
                        foreach (var itemMovimiento in detalleMovimiento)
                        {
                            /*  Registrar detalle del movimiento de asistencia */
                            SJ_RHMovimientoAsistenciaPensionDetalle detalle = new SJ_RHMovimientoAsistenciaPensionDetalle();
                            var resultadoConsultaDetalle = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.idMovimiento == itemMovimiento.idMovimiento && x.codigoTransferenciaAsistenciaMovil == detalle.codigoTransferenciaAsistenciaMovil).ToList();

                            if (resultadoConsultaDetalle != null && resultadoConsultaDetalle.ToList().Count == 0)
                            {
                                #region Registrar ()
                                //detalle.item = itemMovimiento.item;
                                detalle.idMovimiento = codigo;
                                detalle.codigoTransferenciaAsistenciaMovil = itemMovimiento.codigoTransferenciaAsistenciaMovil;
                                detalle.estado = itemMovimiento.estado != null ? Convert.ToByte(itemMovimiento.estado) : Convert.ToByte(0);
                                detalle.glosa = itemMovimiento.glosa != null ? itemMovimiento.glosa.ToString().Trim() : "";
                                contexto.SJ_RHMovimientoAsistenciaPensionDetalles.InsertOnSubmit(detalle);
                                //1.-contexto.SubmitChanges();
                                #endregion
                            }
                            if (resultadoConsultaDetalle.ToList().Count == 1)
                            {
                                #region Actualizar()
                                detalle = resultadoConsultaDetalle.Single();
                                detalle.glosa = itemMovimiento.glosa != null ? itemMovimiento.glosa.ToString().Trim() : "";
                                //1.-contexto.SubmitChanges();
                                #endregion
                            }

                            if (oMovimiento.idDocumento.Trim() == "RAR")
                            {
                                SJM_Pensione transferenciaMovil = new SJM_Pensione();
                                var resultadoConsulta = contexto.SJM_Pensiones.Where(x => x.IdPension == itemMovimiento.codigoTransferenciaAsistenciaMovil).ToList();
                                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                                {
                                    transferenciaMovil = resultadoConsulta.Single();
                                    transferenciaMovil.CodigoMovimientoAsistencia = null;
                                    transferenciaMovil.EsProcesado = 0;
                                }

                            }
                            else if (oMovimiento.idDocumento.Trim() == "MAR")
                            {
                                /*  Asociar movimiento de asistencia a transferencia de moviles(estado a 1) si se trata de un movimiento es decir para un estado procesado, para el caso de registro de asitencia dejarlo en null*/
                                SJM_Pensione transferenciaMovil = new SJM_Pensione();
                                var resultadoConsulta = contexto.SJM_Pensiones.Where(x => x.IdPension == itemMovimiento.codigoTransferenciaAsistenciaMovil).ToList();
                                if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                                {
                                    transferenciaMovil = contexto.SJM_Pensiones.Where(x => x.IdPension == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                                    transferenciaMovil.CodigoMovimientoAsistencia = oMovimiento.idMovimiento.ToString().Trim();
                                    transferenciaMovil.EsProcesado = 1;
                                }
                                //1.-contexto.SubmitChanges();
                            }


                        }
                    }

                    #endregion

                    #region Actualizar documento()

                    //List<SJ_DocumentoNotificacion> consultarDocumentoActualizar = new List<SJ_DocumentoNotificacion>();
                    var consultarDocumentoActualizar = contexto.SJ_DocumentoNotificacions.Where(x => x.idDocumento == oMovimiento.idDocumento.Trim()).ToList();
                    if (consultarDocumentoActualizar != null && consultarDocumentoActualizar.ToList().Count == 1)
                    {
                        SJ_DocumentoNotificacion documento = new SJ_DocumentoNotificacion();
                        documento = consultarDocumentoActualizar.Single();
                        documento.numero = (Convert.ToInt32(documento.numero) + 1).ToString().PadLeft(7, '0');
                        documento.correlativo = (Convert.ToInt32(documento.correlativo) + 1).ToString().PadLeft(7, '0');
                        //contexto.SubmitChanges();
                    }
                    #endregion

                    #region Registrar Log de Movimiento de Tablas
                    SJ_LogTablasPension oSJLogTablas = new SJ_LogTablasPension();
                    oSJLogTablas.IDEMPRESA = oMovimiento.idEmpresa;
                    oSJLogTablas.IDLOG = oMovimiento.idMovimiento;
                    oSJLogTablas.ITEM = "001";
                    oSJLogTablas.TABLA = "SJ_RHMovimientoAsistenciaPension";
                    oSJLogTablas.IDCAMPO = "idMovimiento";
                    oSJLogTablas.CAMPOCLAVE = "idMovimiento";
                    oSJLogTablas.IDTABLA = "idMovimiento";
                    oSJLogTablas.EVENTO = "NUEVO";
                    oSJLogTablas.VALORANTERIOR = oMovimiento.fecha.ToPresentationDate();
                    oSJLogTablas.VALORACTUAL = oMovimiento.numero;
                    oSJLogTablas.IDUSUARIO = Environment.UserName;
                    oSJLogTablas.MAQUINA = Environment.MachineName;
                    oSJLogTablas.FECHACREACION = DateTime.Now;
                    oSJLogTablas.VENTANA = "MovimientoAsistenciaRefrigerioMatenimiento";
                    contexto.SJ_LogTablasPension.InsertOnSubmit(oSJLogTablas);
                    //contexto.SubmitChanges();
                    #endregion

                    contexto.SubmitChanges();
                }
                else
                {
                    codigo = movimientoAsistencia.idMovimiento.ToString().Trim();
                    #region Actualizar();
                    SJ_RHMovimientoAsistenciaPension oMovimiento = new SJ_RHMovimientoAsistenciaPension();
                    oMovimiento = contexto.SJ_RHMovimientoAsistenciaPensions.Where(x => x.idMovimiento == movimientoAsistencia.idMovimiento).Single();
                    //oMovimiento.idSucursal = movimientoAsistencia.idSucursal != null ? movimientoAsistencia.idSucursal.ToString().Trim() : "";
                    //oMovimiento.idEmpresa = movimientoAsistencia.idEmpresa != null ? movimientoAsistencia.idEmpresa.ToString().Trim() : "";
                    //oMovimiento.idMovimiento = movimientoAsistencia.idMovimiento != null ? movimientoAsistencia.idMovimiento.ToString().Trim() : "";
                    //oMovimiento.idclieprov = movimientoAsistencia.idclieprov != null ? movimientoAsistencia.idclieprov.ToString().Trim() : "";
                    //oMovimiento.dniPension = movimientoAsistencia.dniPension != null ? movimientoAsistencia.dniPension.ToString().Trim() : "";
                    oMovimiento.fecha = movimientoAsistencia.fecha != null ? movimientoAsistencia.fecha : DateTime.Now;
                    //oMovimiento.idDocumento = movimientoAsistencia.idDocumento != null ? movimientoAsistencia.idDocumento.ToString().Trim() : "";
                    //oMovimiento.serie = movimientoAsistencia.serie != null ? movimientoAsistencia.serie.ToString().Trim() : "";
                    //oMovimiento.numero = movimientoAsistencia.numero != null ? movimientoAsistencia.numero.ToString().Trim() : "";
                    //oMovimiento.numeroOperacion = movimientoAsistencia.numeroOperacion != null ? movimientoAsistencia.numeroOperacion.ToString().Trim() : "";
                    oMovimiento.periodo = movimientoAsistencia.periodo != null ? movimientoAsistencia.periodo.ToString().Trim() : "";
                    //oMovimiento.estado = movimientoAsistencia.estado != null ? movimientoAsistencia.estado : 0;
                    //oMovimiento.idEstado = movimientoAsistencia.idEstado != null ? movimientoAsistencia.idEstado.ToString().Trim() : "";
                    //oMovimiento.registradoPor = movimientoAsistencia.registradoPor != null ? movimientoAsistencia.registradoPor.ToString().Trim() : "";
                    //oMovimiento.maquinanaRegistrada = movimientoAsistencia.maquinanaRegistrada != null ? movimientoAsistencia.maquinanaRegistrada.ToString().Trim() : "";
                    //oMovimiento.fechaRegistro = movimientoAsistencia.fechaRegistro != null ? movimientoAsistencia.fechaRegistro.Value : (DateTime?)null;
                    oMovimiento.NombreMes = movimientoAsistencia.NombreMes != null ? movimientoAsistencia.NombreMes.ToString().Trim() : "";
                    //contexto.SubmitChanges();
                    #endregion

                    #region Desasociar movimiento de asistencia a transferencia de moviles(estado a 1)
                    if (detalleMovimientoEliminado != null && detalleMovimientoEliminado.ToList().Count > 0)
                    {
                        foreach (var itemMovimiento in detalleMovimientoEliminado)
                        {
                            SJ_RHMovimientoAsistenciaPensionDetalle oDetalle = new SJ_RHMovimientoAsistenciaPensionDetalle();
                            oDetalle = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.item == itemMovimiento.item && x.idMovimiento == codigo).Single();
                            contexto.SJ_RHMovimientoAsistenciaPensionDetalles.DeleteOnSubmit(oDetalle);
                            contexto.SubmitChanges();

                            SJM_Pensione transferenciaMovil = new SJM_Pensione();
                            transferenciaMovil = contexto.SJM_Pensiones.Where(x => x.IdPension == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                            transferenciaMovil.CodigoMovimientoAsistencia = "";
                            transferenciaMovil.EsProcesado = 0;
                            contexto.SubmitChanges();
                        }
                    }
                    #endregion

                    #region Registrar listado detalle()
                    if (detalleMovimiento != null && detalleMovimiento.ToList().Count > 0)
                    {
                        foreach (var itemMovimiento in detalleMovimiento)
                        {
                            SJ_RHMovimientoAsistenciaPensionDetalle oDetalle = new SJ_RHMovimientoAsistenciaPensionDetalle();
                            var resultadoByDetalle = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.codigoTransferenciaAsistenciaMovil == itemMovimiento.codigoTransferenciaAsistenciaMovil && x.idMovimiento == itemMovimiento.idMovimiento).ToList();
                            if (resultadoByDetalle.ToList().Count == 0)
                            {
                                #region REGISTRAR DETALLE() y ASOCIAR TRANSFERENCIA CON MOVIMIENTO()
                                oDetalle = resultadoByDetalle.Single();
                                //oDetalle.item = itemMovimiento.item != null ? itemMovimiento.item : 0;
                                oDetalle.idMovimiento = codigo;
                                oDetalle.codigoTransferenciaAsistenciaMovil = itemMovimiento.codigoTransferenciaAsistenciaMovil != null ? itemMovimiento.codigoTransferenciaAsistenciaMovil : 0;
                                oDetalle.estado = itemMovimiento.estado != null ? Convert.ToByte(itemMovimiento.estado) : Convert.ToByte(0);
                                oDetalle.glosa = itemMovimiento.glosa != null ? itemMovimiento.glosa : "";
                                contexto.SJ_RHMovimientoAsistenciaPensionDetalles.InsertOnSubmit(oDetalle);
                                contexto.SubmitChanges();

                                SJM_Pensione transferenciaMovil = new SJM_Pensione();
                                transferenciaMovil = contexto.SJM_Pensiones.Where(x => x.IdPension == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();

                                if (oMovimiento.idDocumento == "MAR")
                                {
                                    transferenciaMovil.CodigoMovimientoAsistencia = oMovimiento.idMovimiento.ToString().Trim();

                                }
                                else if (oMovimiento.idDocumento == "RAR")
                                {
                                    transferenciaMovil.CodigoRegistroAsistencia = oMovimiento.idMovimiento.ToString().Trim();
                                    transferenciaMovil.CodigoMovimientoAsistencia = null;
                                }

                                transferenciaMovil.EsProcesado = 1;
                                contexto.SubmitChanges();
                                #endregion
                            }
                            else if (resultadoByDetalle.ToList().Count == 1)
                            {
                                #region ACTUALIZAR DETALLE()
                                oDetalle = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.codigoTransferenciaAsistenciaMovil == itemMovimiento.codigoTransferenciaAsistenciaMovil && x.idMovimiento == itemMovimiento.idMovimiento).Single();
                                oDetalle.glosa = itemMovimiento.glosa != null ? itemMovimiento.glosa : "";
                                contexto.SubmitChanges();
                                #endregion
                            }

                        }
                    }
                    #endregion

                    #region Registrar Log de Movimiento de Tablas
                    SJ_LogTablasPension oSJLogTablas = new SJ_LogTablasPension();
                    oSJLogTablas.IDEMPRESA = oMovimiento.idEmpresa;
                    oSJLogTablas.IDLOG = oMovimiento.idMovimiento;
                    //oSJLogTablas.ITEM = "001";
                    oSJLogTablas.ITEM = ObtenerNumeroItemLogTablas(oMovimiento.idMovimiento, "SJ_RHMovimientoAsistenciaPension").ToString();
                    oSJLogTablas.TABLA = "SJ_RHMovimientoAsistenciaPension";
                    oSJLogTablas.IDCAMPO = "idMovimiento";
                    oSJLogTablas.CAMPOCLAVE = "idMovimiento";
                    oSJLogTablas.IDTABLA = "idMovimiento";
                    oSJLogTablas.EVENTO = "MODIFICADO";
                    oSJLogTablas.VALORANTERIOR = oMovimiento.fecha.ToPresentationDate();
                    oSJLogTablas.VALORACTUAL = oMovimiento.numero;
                    oSJLogTablas.IDUSUARIO = Environment.UserName;
                    oSJLogTablas.MAQUINA = Environment.MachineName;
                    oSJLogTablas.FECHACREACION = DateTime.Now;
                    oSJLogTablas.VENTANA = "MovimientoAsistenciaRefrigerioMatenimiento";
                    contexto.SJ_LogTablasPension.InsertOnSubmit(oSJLogTablas);
                    contexto.SubmitChanges();
                    #endregion
                    contexto.SubmitChanges();
                }
            }

            return codigo;
        }

        public void Eliminar(SJ_RHMovimientoAsistenciaPension movimientoAsistencia)
        {
            SJ_RHMovimientoAsistenciaPension oMovimiento = new SJ_RHMovimientoAsistenciaPension();
            string cnx, codigo = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2015"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 988989;
                if (movimientoAsistencia.idMovimiento != null && movimientoAsistencia.idMovimiento.ToString().Trim() != "")
                {
                    var resultadoConsultaDetalle = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.idMovimiento.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();

                    if (resultadoConsultaDetalle != null && resultadoConsultaDetalle.ToList().Count > 0)
                    {
                        foreach (var itemMovimiento in resultadoConsultaDetalle)
                        {
                            SJM_Pensione transferenciaMovil = new SJM_Pensione();
                            transferenciaMovil = contexto.SJM_Pensiones.Where(x => x.IdPension == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                            transferenciaMovil.CodigoMovimientoAsistencia = "";
                            transferenciaMovil.EsProcesado = 0;

                            SJ_RHMovimientoAsistenciaPensionDetalle detalleAsistenciaProcesada = new SJ_RHMovimientoAsistenciaPensionDetalle();
                            detalleAsistenciaProcesada = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.codigoTransferenciaAsistenciaMovil == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                            contexto.SJ_RHMovimientoAsistenciaPensionDetalles.DeleteOnSubmit(detalleAsistenciaProcesada);
                        }
                    }


                    var resultadoConsulta = contexto.SJ_RHMovimientoAsistenciaPensions.Where(x => x.idMovimiento.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();

                    if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                    {
                        oMovimiento = resultadoConsulta.Single();
                        contexto.SJ_RHMovimientoAsistenciaPensions.DeleteOnSubmit(oMovimiento);
                    }


                    List<SJ_LogTablasPension> logTabla = new List<SJ_LogTablasPension>();
                    var resultadoConsultaLogTablas = contexto.SJ_LogTablasPension.Where(x => x.IDLOG.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();
                    contexto.SJ_LogTablasPension.DeleteAllOnSubmit(resultadoConsultaLogTablas);


                }

                contexto.SubmitChanges();
                contexto.Connection.Close();
                contexto.Dispose();
            }


        }

        public void Eliminar(SJ_RHMovimientoAsistenciaPension movimientoAsistencia, string idDocumento)
        {
            SJ_RHMovimientoAsistenciaPension oMovimiento = new SJ_RHMovimientoAsistenciaPension();
            string cnx, codigo = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2015"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 988989;
                if (movimientoAsistencia.idMovimiento != null && movimientoAsistencia.idMovimiento.ToString().Trim() != "")
                {
                    var resultadoConsultaDetalle = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.idMovimiento.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();

                    if (resultadoConsultaDetalle != null && resultadoConsultaDetalle.ToList().Count > 0)
                    {
                        foreach (var itemMovimiento in resultadoConsultaDetalle)
                        {
                            SJM_Pensione transferenciaMovil = new SJM_Pensione();
                            transferenciaMovil = contexto.SJM_Pensiones.Where(x => x.IdPension == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                            transferenciaMovil.CodigoMovimientoAsistencia = "";
                            transferenciaMovil.EsProcesado = 0;

                            SJ_RHMovimientoAsistenciaPensionDetalle detalleAsistenciaProcesada = new SJ_RHMovimientoAsistenciaPensionDetalle();
                            detalleAsistenciaProcesada = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.codigoTransferenciaAsistenciaMovil == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                            contexto.SJ_RHMovimientoAsistenciaPensionDetalles.DeleteOnSubmit(detalleAsistenciaProcesada);
                        }
                    }


                    var resultadoConsulta = contexto.SJ_RHMovimientoAsistenciaPensions.Where(x => x.idMovimiento.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();

                    if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                    {
                        oMovimiento = resultadoConsulta.Single();
                        contexto.SJ_RHMovimientoAsistenciaPensions.DeleteOnSubmit(oMovimiento);
                    }


                    List<SJ_LogTablasPension> logTabla = new List<SJ_LogTablasPension>();
                    var resultadoConsultaLogTablas = contexto.SJ_LogTablasPension.Where(x => x.IDLOG.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();
                    contexto.SJ_LogTablasPension.DeleteAllOnSubmit(resultadoConsultaLogTablas);


                }

                contexto.SubmitChanges();
                contexto.Connection.Close();
                contexto.Dispose();
            }


        }


        public void Anular(SJ_RHMovimientoAsistenciaPension movimientoAsistencia)
        {
            SJ_RHMovimientoAsistenciaPension oMovimiento = new SJ_RHMovimientoAsistenciaPension();
            string cnx, codigo = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2015"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 988989;
                if (movimientoAsistencia.idMovimiento != null && movimientoAsistencia.idMovimiento.ToString().Trim() != "")
                {
                    var resultadoConsulta = contexto.SJ_RHMovimientoAsistenciaPensions.Where(x => x.idMovimiento.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();
                    if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                    {
                        oMovimiento = resultadoConsulta.Single();
                        if (oMovimiento.idEstado.ToString().Trim() == "PE")
                        {
                            #region Anular()
                            oMovimiento.idEstado = "AN";
                            oMovimiento.estado = 0;
                            var resultadoConsultaDetalle = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.idMovimiento.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();
                            if (resultadoConsultaDetalle != null && resultadoConsultaDetalle.ToList().Count > 0)
                            {
                                foreach (var itemMovimiento in resultadoConsultaDetalle)
                                {
                                    SJM_Pensione transferenciaMovil = new SJM_Pensione();
                                    transferenciaMovil = contexto.SJM_Pensiones.Where(x => x.IdPension == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                                    //transferenciaMovil.CodigoMovimirntoAsistencia = "";
                                    transferenciaMovil.EsProcesado = 0;

                                    SJ_RHMovimientoAsistenciaPensionDetalle detalleAsistenciaProcesada = new SJ_RHMovimientoAsistenciaPensionDetalle();
                                    detalleAsistenciaProcesada = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.codigoTransferenciaAsistenciaMovil == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                                    detalleAsistenciaProcesada.glosa = "Dado de baja el :" + DateTime.Today.ToShortDateString();
                                }
                            }
                            #endregion
                        }
                        else if (oMovimiento.idEstado.ToString().Trim() == "AN")
                        {
                            #region Activar()
                            oMovimiento.idEstado = "PE";
                            oMovimiento.estado = 1;
                            var resultadoConsultaDetalle = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.idMovimiento.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();

                            if (resultadoConsultaDetalle != null && resultadoConsultaDetalle.ToList().Count > 0)
                            {
                                foreach (var itemMovimiento in resultadoConsultaDetalle)
                                {
                                    SJM_Pensione transferenciaMovil = new SJM_Pensione();
                                    transferenciaMovil = contexto.SJM_Pensiones.Where(x => x.IdPension == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                                    //transferenciaMovil.CodigoMovimirntoAsistencia = "";
                                    transferenciaMovil.EsProcesado = 1;

                                    SJ_RHMovimientoAsistenciaPensionDetalle detalleAsistenciaProcesada = new SJ_RHMovimientoAsistenciaPensionDetalle();
                                    detalleAsistenciaProcesada = contexto.SJ_RHMovimientoAsistenciaPensionDetalles.Where(x => x.codigoTransferenciaAsistenciaMovil == itemMovimiento.codigoTransferenciaAsistenciaMovil).Single();
                                    detalleAsistenciaProcesada.glosa = "";
                                }
                            }
                            #endregion
                        }
                    }
                }
                contexto.SubmitChanges();
                contexto.Connection.Close();
                contexto.Dispose();
            }
        }

        public void Anular(SJ_RHMovimientoAsistenciaPension movimientoAsistencia, string periodo)
        {
            SJ_RHMovimientoAsistenciaPension oMovimiento = new SJ_RHMovimientoAsistenciaPension();
            string cnx, codigo = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2015"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 988989;
                if (movimientoAsistencia.idMovimiento != null && movimientoAsistencia.idMovimiento.ToString().Trim() != "")
                {
                    var resultadoConsulta = contexto.SJ_RHMovimientoAsistenciaPensions.Where(x => x.idMovimiento.ToString().Trim() == movimientoAsistencia.idMovimiento.ToString().Trim()).ToList();
                    if (resultadoConsulta != null && resultadoConsulta.ToList().Count == 1)
                    {
                        oMovimiento = resultadoConsulta.Single();
                        if (oMovimiento.idEstado.ToString().Trim() == "PE")
                        {
                            if (oMovimiento.idDocumento.Trim() == "RAR")
                            {
                                contexto.SJ_RHAnularRegistroAsistenciaRefrigerioCampos(oMovimiento.idMovimiento);
                            }
                            else if (oMovimiento.idDocumento.Trim() == "MAR")
                            {
                                contexto.SJ_RHAnularMovimientoAsistenciaRefrigerioCampos(oMovimiento.idMovimiento);
                            }                            
                        }
                    }
                }
                contexto.SubmitChanges();
                contexto.Connection.Close();
                contexto.Dispose();
            }
        }

        private string ObtenerNuevoCodigo(string periodoRegistro)
        {
            string cnx = string.Empty;
            string codigo = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoRegistro.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Contexto.CommandTimeout = 99999;
                //string resultado = Contexto.SJ_Paraderos.ToList().OrderByDescending(x => x.IdParadero).ElementAt(0).IdParadero.Substring(1, 3);
                //int nuevoCodigo = Convert.ToInt32(resultado) + 1;
                //codigo = "P" + nuevoCodigo.ToString().PadLeft(3, '0');
                codigo = Contexto.ObtenerId().FirstOrDefault().Codigo.Trim();
                Contexto.Connection.Close();
                Contexto.Dispose();
            }

            return codigo;
        }

        private string ObtenerNumeroItemLogTablas(string idCodigo, string tabla)
        {
            string cnx = string.Empty;
            string item = "001";
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                #region Registro / Edicion()
                Modelo.CommandTimeout = 9998000;

                var resultadoConsulta = Modelo.SJ_LogTablasPension.Where(x => x.IDLOG.ToString().Trim() == idCodigo && x.TABLA.ToString().Trim().Trim() == tabla).ToList();

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                {
                    int numero = Convert.ToInt32(resultadoConsulta.OrderByDescending(x => x.ITEM).FirstOrDefault().ITEM) + 1;
                    item = numero.ToString().Trim().PadLeft(3, '0');
                }

                Modelo.Connection.Close();
                Modelo.Dispose();
                #endregion
            }

            return item;
        }

        public List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult> ObtenerMovimientoAsistenciaRefrigerioByPeriodo(string codigoMovimiento, string dniPension, string desde, string hasta)
        {
            List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult> listado = new List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2015"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                listado = Modelo.SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalle(codigoMovimiento, dniPension, desde, hasta).ToList();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return listado;
        }

        public List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> ObtenerListadoMovimientoAsistenciasProcesadasByPeriodo(string desde, string hasta, string idProveedor)
        {
            List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> listado = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                listado = Modelo.SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodo(desde, hasta, idProveedor).ToList();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return listado;
        }

        public List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> ObtenerListadoMovimientoAsistenciasSinProcesarByPeriodo(string desde, string hasta, string idProveedor)
        {
            List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> listado = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                listado = Modelo.SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodo(desde, hasta, idProveedor).Where(x => x.CodigoRegistroAsistencia != null).ToList();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return listado;
        }

        public List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> AgruparListadoMovimientoAsistenciasProcesadasByCodigoMovimiento(List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> listaAsistenciasProcesadas)
        {
            List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> listado = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult>();

            if (listaAsistenciasProcesadas != null && listaAsistenciasProcesadas.ToList().Count > 0)
            {

                var codigosByMovimientoAsistenciaProcesada = (from iten in listaAsistenciasProcesadas
                                                              where iten.idMovimiento != null
                                                              group iten by new { iten.idMovimiento } into j
                                                              select new
                                                              {
                                                                  codigoRegistro = j.Key.idMovimiento.ToString().Trim(),
                                                              }).ToList();


                if (codigosByMovimientoAsistenciaProcesada != null && codigosByMovimientoAsistenciaProcesada.ToList().Count > 0)
                {
                    foreach (var movimiento in codigosByMovimientoAsistenciaProcesada)
                    {

                        var resultadoByCodigo = listaAsistenciasProcesadas.Where(x => x.idMovimiento.ToString().Trim() == movimiento.codigoRegistro).ToList();
                        SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult oRegistroProcesado = new SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult();
                        oRegistroProcesado.idMovimiento = movimiento.codigoRegistro;
                        oRegistroProcesado.idclieprov = resultadoByCodigo.FirstOrDefault().idclieprov != null ? resultadoByCodigo.FirstOrDefault().idclieprov.ToString().Trim() : string.Empty;
                        oRegistroProcesado.RAZON_SOCIAL = resultadoByCodigo.FirstOrDefault().RAZON_SOCIAL != null ? resultadoByCodigo.FirstOrDefault().RAZON_SOCIAL.ToString().Trim() : string.Empty;
                        oRegistroProcesado.fecha = resultadoByCodigo.FirstOrDefault().fecha != null ? resultadoByCodigo.FirstOrDefault().fecha : DateTime.Today;
                        oRegistroProcesado.semana = resultadoByCodigo.FirstOrDefault().semana != null ? resultadoByCodigo.FirstOrDefault().semana : 0;
                        oRegistroProcesado.idDocumento = resultadoByCodigo.FirstOrDefault().idDocumento != null ? resultadoByCodigo.FirstOrDefault().idDocumento.ToString().Trim() : string.Empty;
                        oRegistroProcesado.documento = resultadoByCodigo.FirstOrDefault().documento != null ? resultadoByCodigo.FirstOrDefault().documento.ToString().Trim() : string.Empty;
                        oRegistroProcesado.periodo = resultadoByCodigo.FirstOrDefault().periodo != null ? resultadoByCodigo.FirstOrDefault().periodo.ToString().Trim() : string.Empty;
                        oRegistroProcesado.idEstado = resultadoByCodigo.FirstOrDefault().idEstado != null ? resultadoByCodigo.FirstOrDefault().idEstado.ToString().Trim() : string.Empty;
                        oRegistroProcesado.tipoRefrigerio = resultadoByCodigo.FirstOrDefault().tipoRefrigerio != null ? resultadoByCodigo.FirstOrDefault().tipoRefrigerio.ToString().Trim() : string.Empty;
                        oRegistroProcesado.desayuno = resultadoByCodigo.Sum(x => x.desayuno != null ? x.desayuno : 0);
                        oRegistroProcesado.almuerzo = resultadoByCodigo.Sum(x => x.almuerzo != null ? x.almuerzo : 0);
                        oRegistroProcesado.cena = resultadoByCodigo.Sum(x => x.cena != null ? x.cena : 0);
                        oRegistroProcesado.CodigotipoRefrigerio = resultadoByCodigo.FirstOrDefault().CodigotipoRefrigerio != null ? resultadoByCodigo.FirstOrDefault().CodigotipoRefrigerio : 0;
                        oRegistroProcesado.estado = resultadoByCodigo.FirstOrDefault().estado != null ? resultadoByCodigo.FirstOrDefault().estado.ToString().Trim() : string.Empty;
                        oRegistroProcesado.estadoRegistro = resultadoByCodigo.FirstOrDefault().estadoRegistro != null ? resultadoByCodigo.FirstOrDefault().estadoRegistro : 0;
                        oRegistroProcesado.CodigoMovimientoAsistencia = resultadoByCodigo.FirstOrDefault().CodigoMovimientoAsistencia != null ? resultadoByCodigo.FirstOrDefault().CodigoMovimientoAsistencia.ToString().Trim() : string.Empty;
                        oRegistroProcesado.CodigoRegistroAsistencia = resultadoByCodigo.FirstOrDefault().CodigoRegistroAsistencia != null ? resultadoByCodigo.FirstOrDefault().CodigoRegistroAsistencia.ToString().Trim() : string.Empty;
                        oRegistroProcesado.DniPension = resultadoByCodigo.FirstOrDefault().DniPension != null ? resultadoByCodigo.FirstOrDefault().DniPension.ToString().Trim() : string.Empty;

                        listado.Add(oRegistroProcesado);
                    }
                }
            }
            return listado;
        }

        /* Método que me trae el detalle del movimiento de asistencia procesado por codigo de movimiento */
        public List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult> ObtenerListadoDetalleMovimientoAsistenciasProcesadasByCodigo(string idMovimiento)
        {
            List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult> listado = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                listado = Modelo.SJ_RHListadoMovimientoAsistenciasProcesadasByCodigo(idMovimiento).ToList();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return listado;
        }

        /* Método que me trae la info de la cabecera del movimiento de asistencia procesado por codigo de movimiento */
        public SJ_RHMovimientoAsistenciasProcesadasByCodigoResult ObteneMovimientoAsistenciaProcesadaRefrigerioByCodigo(string idMovimiento)
        {
            SJ_RHMovimientoAsistenciasProcesadasByCodigoResult movimientoAsistenciaProcesadaRefrigerio = new SJ_RHMovimientoAsistenciasProcesadasByCodigoResult();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                movimientoAsistenciaProcesadaRefrigerio = Modelo.SJ_RHMovimientoAsistenciasProcesadasByCodigo(idMovimiento).Single();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return movimientoAsistenciaProcesadaRefrigerio;
        }

        public List<SJ_RHListadoPersonalByProgramacionByPensionResult> ObtenerListadoPersonalPorProgramacionRefrigerio(string NroDNIPension, string fecha)
        {
            string cnx = string.Empty;
            List<SJ_RHListadoPersonalByProgramacionByPensionResult> listadoPersonal = new List<SJ_RHListadoPersonalByProgramacionByPensionResult>();
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                listadoPersonal = Modelo.SJ_RHListadoPersonalByProgramacionByPension(NroDNIPension, fecha).ToList();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return listadoPersonal;
        }

        public string ObtenerCodigoProveedor(string dniPension)
        {
            string cnx = string.Empty;
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                var resultadoConsulta = Modelo.SJ_RHPensions.Where(x => x.NroDNI.Trim() == dniPension).ToList();

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                {
                    resultado = resultadoConsulta.FirstOrDefault().IdPension != null ? resultadoConsulta.FirstOrDefault().IdPension.ToString() : string.Empty;
                }

                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return resultado;
        }

        public string ObtenerNroRucProveedor(string dniPension)
        {
            string cnx = string.Empty;
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                var resultadoConsulta = Modelo.SJ_RHPensions.Where(x => x.NroDNI.Trim() == dniPension).ToList();

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                {
                    resultado = resultadoConsulta.FirstOrDefault().NroRuc != null ? resultadoConsulta.FirstOrDefault().NroRuc.Trim() : string.Empty;
                }

                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return resultado;
        }

        public string ObtenerPseudoNomnbreProveedor(string dniPension)
        {
            string cnx = string.Empty;
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                var resultadoConsulta = Modelo.SJ_RHPensions.Where(x => x.NroDNI.Trim() == dniPension).ToList();

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                {
                    resultado = resultadoConsulta.FirstOrDefault().PseudoNombre != null ? resultadoConsulta.FirstOrDefault().PseudoNombre.Trim() : string.Empty;
                }

                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return resultado;
        }

        public string ObtnerCodigoPersonal(string nroDniPersonal)
        {

            string cnx = string.Empty;
            string resultado = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999999;
                var resultadoConsulta = Modelo.SJ_ListadoPersonalGenerals.Where(x => x.numeroDocumento.Trim() == nroDniPersonal).ToList();

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                {
                    resultado = resultadoConsulta.FirstOrDefault().codigoGeneral != null ? resultadoConsulta.FirstOrDefault().codigoGeneral.Trim() : string.Empty;
                }

                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return resultado;

        }
    }
}
