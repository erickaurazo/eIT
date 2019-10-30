using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using TransportistaMto.Datos;
using System.Configuration;

namespace TransportistaMto.Negocios
{
    public class SJ_RHMovimientoMovilidadAsistenciaTrabajadorNegocio
    {
        string cnx = string.Empty;
        public List<SJ_RHMovimientoMovilidadAsistenciaTrabajadorListadoByCodigoResult> RHMovimientoMovilidadAsistenciaTrabajadorListadoByCodigo(string periodo, string codigoFormulario)
        {
            List<SJ_RHMovimientoMovilidadAsistenciaTrabajadorListadoByCodigoResult> listado = new List<SJ_RHMovimientoMovilidadAsistenciaTrabajadorListadoByCodigoResult>();

            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(1, 4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                listado = Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajadorListadoByCodigo(codigoFormulario).ToList();

                return listado;
            }

        }

        public void RegistrarListado(string periodo, SJ_RHMovimientoMovilidad movimiento, List<SJ_RHMovimientoMovilidadAsistenciaTrabajador> ListadoDetalleAsistencia)
        {
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(1, 4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                var resultadoMovimiento = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo == movimiento.Codigo).ToList();
                if (resultadoMovimiento.ToList().Count == 1)
                {
                    if (ListadoDetalleAsistencia != null && ListadoDetalleAsistencia.ToList().Count > 0)
                    {
                        foreach (var item in ListadoDetalleAsistencia)
                        {
                            var resultadoDetalle = Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.Where(x => x.codigoMovimientoMovilidad == item.codigoMovimientoMovilidad && x.item == item.item).ToList();

                            if (resultadoDetalle != null && resultadoDetalle.ToList().Count == 0)
                            {
                                #region Registro Nuevo()
                                SJ_RHMovimientoMovilidadAsistenciaTrabajador detalle = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                                detalle.codigoMovimientoMovilidad = movimiento.Codigo;
                                detalle.item = item.item != null ? item.item : string.Empty;
                                detalle.idCodigoGeneral = item.idCodigoGeneral != null ? item.idCodigoGeneral : string.Empty;
                                detalle.nroDocumento = item.nroDocumento != null ? item.nroDocumento : string.Empty;
                                detalle.nombresCompletos = item.nombresCompletos != null ? item.nombresCompletos : string.Empty;
                                detalle.subPlanilla = item.subPlanilla != null ? item.subPlanilla : string.Empty;
                                detalle.fechaRegistro = item.fechaRegistro;
                                detalle.idconsumidor = item.idconsumidor != null ? item.idconsumidor : string.Empty;
                                detalle.idParadero = item.idParadero != null ? item.idParadero : string.Empty;
                                detalle.paradero = item.paradero != null ? item.paradero : string.Empty;
                                detalle.tipoAsistencia = item.tipoAsistencia != null ? item.tipoAsistencia : 'S';
                                detalle.hora = item.hora != null ? item.hora : string.Empty;
                                detalle.idRegistroMovil = item.idRegistroMovil != (int?)null ? item.idRegistroMovil : 0;
                                detalle.estado = item.estado != null ? item.estado : 0;
                                Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.InsertOnSubmit(detalle);
                                Modelo.SubmitChanges();

                                /* Actualizar la transferencia con el codigo de transferencia */
                                var modeloTransferenciaMovil = Modelo.ASJ_RegistroTransferenciaTransportes.Where(x => x.idRegistroMovil == item.idRegistroMovil).ToList();

                                if (modeloTransferenciaMovil != null && modeloTransferenciaMovil.ToList().Count == 1)
                                {
                                    /* Actualizar registro con el codigo del movimiento */
                                    ASJ_RegistroTransferenciaTransportes registroTransferenciaMovil = new ASJ_RegistroTransferenciaTransportes();
                                    registroTransferenciaMovil = modeloTransferenciaMovil.Single();
                                    registroTransferenciaMovil.codigoTransferencia = movimiento.Codigo;
                                    Modelo.SubmitChanges();
                                }


                                #endregion
                            }
                            else if (resultadoDetalle != null && resultadoDetalle.ToList().Count == 1)
                            {
                                #region Editar Registro()
                                SJ_RHMovimientoMovilidadAsistenciaTrabajador detalle = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                                detalle = resultadoDetalle.Single();
                                //detalle.codigoMovimientoMovilidad = movimiento.Codigo;
                                //detalle.item = item.item != null ? item.item : string.Empty;
                                detalle.idCodigoGeneral = item.idCodigoGeneral != null ? item.idCodigoGeneral : string.Empty;
                                detalle.nroDocumento = item.nroDocumento != null ? item.nroDocumento : string.Empty;
                                detalle.nombresCompletos = item.nombresCompletos != null ? item.nombresCompletos : string.Empty;
                                detalle.subPlanilla = item.subPlanilla != null ? item.subPlanilla : string.Empty;
                                detalle.fechaRegistro = item.fechaRegistro;
                                detalle.idconsumidor = item.idconsumidor != null ? item.idconsumidor : string.Empty;
                                detalle.idParadero = item.idParadero != null ? item.idParadero : string.Empty;
                                detalle.paradero = item.paradero != null ? item.paradero : string.Empty;
                                detalle.tipoAsistencia = item.tipoAsistencia != (char?)null ? item.tipoAsistencia : 'S';
                                detalle.hora = item.hora != null ? item.hora : string.Empty;
                                detalle.idRegistroMovil = item.idRegistroMovil != (int?)null ? item.idRegistroMovil : 0;
                                detalle.estado = item.estado != null ? item.estado : 0;
                                Modelo.SubmitChanges();

                                /* Actualizar la transferencia con el codigo de transferencia */
                                var modeloTransferenciaMovil = Modelo.ASJ_RegistroTransferenciaTransportes.Where(x => x.idRegistroMovil == item.idRegistroMovil).ToList();

                                if (modeloTransferenciaMovil != null && modeloTransferenciaMovil.ToList().Count == 1)
                                {
                                    /* Actualizar registro con el codigo del movimiento */
                                    ASJ_RegistroTransferenciaTransportes registroTransferenciaMovil = new ASJ_RegistroTransferenciaTransportes();
                                    registroTransferenciaMovil = modeloTransferenciaMovil.Single();
                                    registroTransferenciaMovil.codigoTransferencia = movimiento.Codigo;
                                    Modelo.SubmitChanges();
                                }

                                #endregion
                            }


                        }
                    }
                }
            }
        }

        public void Registar(string periodo, SJ_RHMovimientoMovilidad movimiento, SJ_RHMovimientoMovilidadAsistenciaTrabajador detalleAsistencia)
        {
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(1, 4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                var resultadoMovimiento = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo == movimiento.Codigo).ToList();
                if (resultadoMovimiento.ToList().Count == 1)
                {

                    var resultadoDetalle = Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.Where(x => x.codigoMovimientoMovilidad == detalleAsistencia.codigoMovimientoMovilidad && x.item == detalleAsistencia.item).ToList();

                    if (resultadoDetalle != null && resultadoDetalle.ToList().Count == 0)
                    {
                        #region Registro Nuevo()
                        SJ_RHMovimientoMovilidadAsistenciaTrabajador detalle = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                        detalle.codigoMovimientoMovilidad = movimiento.Codigo;
                        detalle.item = detalleAsistencia.item != null ? detalleAsistencia.item : string.Empty;
                        detalle.idCodigoGeneral = detalleAsistencia.idCodigoGeneral != null ? detalleAsistencia.idCodigoGeneral : string.Empty;
                        detalle.nroDocumento = detalleAsistencia.nroDocumento != null ? detalleAsistencia.nroDocumento : string.Empty;
                        detalle.nombresCompletos = detalleAsistencia.nombresCompletos != null ? detalleAsistencia.nombresCompletos : string.Empty;
                        detalle.subPlanilla = detalleAsistencia.subPlanilla != null ? detalleAsistencia.subPlanilla : string.Empty;
                        detalle.fechaRegistro = detalleAsistencia.fechaRegistro;
                        detalle.idconsumidor = detalleAsistencia.idconsumidor != null ? detalleAsistencia.idconsumidor : string.Empty;
                        detalle.idParadero = detalleAsistencia.idParadero != null ? detalleAsistencia.idParadero : string.Empty;
                        detalle.paradero = detalleAsistencia.paradero != null ? detalleAsistencia.paradero : string.Empty;
                        detalle.tipoAsistencia = detalleAsistencia.tipoAsistencia != null ? detalleAsistencia.tipoAsistencia : 'S';
                        detalle.hora = detalleAsistencia.hora != null ? detalleAsistencia.hora : string.Empty;
                        detalle.idRegistroMovil = detalleAsistencia.idRegistroMovil != (int?)null ? detalleAsistencia.idRegistroMovil : 0;
                        detalle.estado = detalleAsistencia.estado != null ? detalleAsistencia.estado : 0;
                        Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.InsertOnSubmit(detalle);
                        Modelo.SubmitChanges();

                        /* Actualizar la transferencia con el codigo de transferencia */
                        var modeloTransferenciaMovil = Modelo.ASJ_RegistroTransferenciaTransportes.Where(x => x.idRegistroMovil == detalleAsistencia.idRegistroMovil).ToList();

                        if (modeloTransferenciaMovil != null && modeloTransferenciaMovil.ToList().Count == 1)
                        {
                            /* Actualizar registro con el codigo del movimiento */
                            ASJ_RegistroTransferenciaTransportes registroTransferenciaMovil = new ASJ_RegistroTransferenciaTransportes();
                            registroTransferenciaMovil = modeloTransferenciaMovil.Single();
                            registroTransferenciaMovil.codigoTransferencia = movimiento.Codigo;
                            Modelo.SubmitChanges();
                        }


                        #endregion
                    }
                    else if (resultadoDetalle != null && resultadoDetalle.ToList().Count == 1)
                    {
                        #region Editar Registro()
                        SJ_RHMovimientoMovilidadAsistenciaTrabajador detalle = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                        detalle = resultadoDetalle.Single();
                        //detalle.codigoMovimientoMovilidad = movimiento.Codigo;
                        //detalle.item = item.item != null ? item.item : string.Empty;
                        detalle.idCodigoGeneral = detalleAsistencia.idCodigoGeneral != null ? detalleAsistencia.idCodigoGeneral : string.Empty;
                        detalle.nroDocumento = detalleAsistencia.nroDocumento != null ? detalleAsistencia.nroDocumento : string.Empty;
                        detalle.nombresCompletos = detalleAsistencia.nombresCompletos != null ? detalleAsistencia.nombresCompletos : string.Empty;
                        detalle.subPlanilla = detalleAsistencia.subPlanilla != null ? detalleAsistencia.subPlanilla : string.Empty;
                        detalle.fechaRegistro = detalleAsistencia.fechaRegistro;
                        detalle.idconsumidor = detalleAsistencia.idconsumidor != null ? detalleAsistencia.idconsumidor : string.Empty;
                        detalle.idParadero = detalleAsistencia.idParadero != null ? detalleAsistencia.idParadero : string.Empty;
                        detalle.paradero = detalleAsistencia.paradero != null ? detalleAsistencia.paradero : string.Empty;
                        detalle.tipoAsistencia = detalleAsistencia.tipoAsistencia != (char?)null ? detalleAsistencia.tipoAsistencia : 'S';
                        detalle.hora = detalleAsistencia.hora != null ? detalleAsistencia.hora : string.Empty;
                        detalle.idRegistroMovil = detalleAsistencia.idRegistroMovil != (int?)null ? detalleAsistencia.idRegistroMovil : 0;
                        detalle.estado = detalleAsistencia.estado != null ? detalleAsistencia.estado : 0;
                        Modelo.SubmitChanges();

                        /* Actualizar la transferencia con el codigo de transferencia */
                        var modeloTransferenciaMovil = Modelo.ASJ_RegistroTransferenciaTransportes.Where(x => x.idRegistroMovil == detalleAsistencia.idRegistroMovil).ToList();

                        if (modeloTransferenciaMovil != null && modeloTransferenciaMovil.ToList().Count == 1)
                        {
                            /* Actualizar registro con el codigo del movimiento */
                            ASJ_RegistroTransferenciaTransportes registroTransferenciaMovil = new ASJ_RegistroTransferenciaTransportes();
                            registroTransferenciaMovil = modeloTransferenciaMovil.Single();
                            registroTransferenciaMovil.codigoTransferencia = movimiento.Codigo;
                            Modelo.SubmitChanges();
                        }

                        #endregion
                    }

                }
            }
        }

        public void Anular(string periodo, SJ_RHMovimientoMovilidad movimiento, SJ_RHMovimientoMovilidadAsistenciaTrabajador detalleAsistencia)
        {
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(1, 4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                var resultadoMovimiento = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo == movimiento.Codigo).ToList();
                if (resultadoMovimiento.ToList().Count == 1)
                {

                    var resultadoDetalle = Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.Where(x => x.codigoMovimientoMovilidad == detalleAsistencia.codigoMovimientoMovilidad && x.item == detalleAsistencia.item).ToList();

                    if (resultadoDetalle != null && resultadoDetalle.ToList().Count == 1)
                    {
                        #region Editar Registro()
                        SJ_RHMovimientoMovilidadAsistenciaTrabajador detalle = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                        detalle = resultadoDetalle.Single();

                        if (detalle.estado == 1)
                        {
                            detalle.estado =  0;
                        }
                        else if (detalle.estado == 0)
                        {
                            detalle.estado = 1;
                        }
                       
                        Modelo.SubmitChanges();

                        /* Actualizar la transferencia con el codigo de transferencia */
                        var modeloTransferenciaMovil = Modelo.ASJ_RegistroTransferenciaTransportes.Where(x => x.idRegistroMovil == detalleAsistencia.idRegistroMovil).ToList();

                        if (modeloTransferenciaMovil != null && modeloTransferenciaMovil.ToList().Count == 1)
                        {
                            /* Actualizar registro con el codigo del movimiento */
                            ASJ_RegistroTransferenciaTransportes registroTransferenciaMovil = new ASJ_RegistroTransferenciaTransportes();
                            registroTransferenciaMovil = modeloTransferenciaMovil.Single();
                            registroTransferenciaMovil.codigoTransferencia = string.Empty;
                            Modelo.SubmitChanges();
                        }

                        #endregion
                    }


                }
            }
        }

        public void Eliminar(string periodo, SJ_RHMovimientoMovilidad movimiento, SJ_RHMovimientoMovilidadAsistenciaTrabajador detalleAsistencia)
        {
            cnx = ConfigurationManager.AppSettings["bd" + periodo.Substring(1, 4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                var resultadoMovimiento = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo == movimiento.Codigo).ToList();
                if (resultadoMovimiento.ToList().Count == 1)
                {

                    var resultadoDetalle = Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.Where(x => x.codigoMovimientoMovilidad == detalleAsistencia.codigoMovimientoMovilidad && x.item == detalleAsistencia.item).ToList();

                    if (resultadoDetalle != null && resultadoDetalle.ToList().Count == 1)
                    {
                        #region Editar Registro()
                        SJ_RHMovimientoMovilidadAsistenciaTrabajador detalle = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                        detalle = resultadoDetalle.Single();
                        Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.DeleteOnSubmit(detalle);
                        Modelo.SubmitChanges();

                        /* Actualizar la transferencia con el codigo de transferencia */
                        var modeloTransferenciaMovil = Modelo.ASJ_RegistroTransferenciaTransportes.Where(x => x.idRegistroMovil == detalleAsistencia.idRegistroMovil).ToList();

                        if (modeloTransferenciaMovil != null && modeloTransferenciaMovil.ToList().Count == 1)
                        {
                            /* Actualizar registro con el codigo del movimiento */
                            ASJ_RegistroTransferenciaTransportes registroTransferenciaMovil = new ASJ_RegistroTransferenciaTransportes();
                            registroTransferenciaMovil = modeloTransferenciaMovil.Single();
                            registroTransferenciaMovil.codigoTransferencia = string.Empty;
                            Modelo.SubmitChanges();
                        }

                        #endregion
                    }


                }
            }
        }


    }
}
