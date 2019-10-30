using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using TransportistaMto.Datos;
using System.Configuration;


namespace Transportista.Negocios
{
    public class MovimientoMovilidadNegocio
    {
        private SJ_RHMovimientoMovilidad Movimiento;
        private string cnx;

        /* LISTAO DE MOVIMIENTOS PENDIENTES A FACTURACION, ES DECIR CON EL ESTADO PENDIENTE */
        public List<SJ_RHMovimientMovilidadPendientesFacturacionResult> ListarMovimientoPendientesFacturacionxProveedor(string codigoProveedor, string desde, string hasta, string periodo)
        {
            string cnx = string.Empty;

            List<SJ_RHMovimientMovilidadPendientesFacturacionResult> Listado = new List<SJ_RHMovimientMovilidadPendientesFacturacionResult>();
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 998900;

                #region Consulta()
                // codigoProveedor es el idclieprov, mejor dicho el ruc de la empresa.
                Listado = Modelo.SJ_RHMovimientMovilidadPendientesFacturacion(codigoProveedor, desde, hasta).ToList();

                #endregion

                Modelo.Connection.Close();
            }
            return Listado;
        }

        /* REGISTRAR EL MOVIMIENTO DE ASISTENCIAS DEL PERSONAL QUE HACE USO DEL SERVICIO DE MOVILIDAD ENTRE LOCALIDADES  */
        public string RegistrarMovimiento(SJ_RHMovimientoMovilidad movimientoTransportista, List<SJ_RHMovimientoMovilidadDetalle> listaDetalleMovimientoInterno, List<SJ_RHMovimientoMovilidadDetalle> listaDetalleMovimientoInternoEliminados, List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ListaDetalleMovimientoInterLocalidadAsistenciaTrabajadores)
        {
            string Codigo = string.Empty;
            string cnx = string.Empty;

            if (movimientoTransportista != null)
            {
                if (movimientoTransportista.Fecha != null)
                {
                    #region Registrar Movimiento()
                    string Periodo = movimientoTransportista.Fecha.Value.Year.ToString().Trim();
                    /* aqui asociio mi cadena de conexion a la base que yo deseo conectarme */
                    cnx = ConfigurationManager.AppSettings["bd" + Periodo].ToString();

                    //using (TransactionScope Scope = new TransactionScope())
                    //{
                    #region Empezar la Transacción()

                    using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                    {
                        Modelo.CommandTimeout = 9999900;
                        #region Registro / Actualizacion

                        if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo.ToString().Trim() == movimientoTransportista.Codigo.ToString().Trim()).ToList().Count == 1)
                        {
                            #region Actualizar()
                            try
                            {
                                #region Actualizar Cabecera()
                                Movimiento = new SJ_RHMovimientoMovilidad();
                                Movimiento = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo.ToString().Trim() == movimientoTransportista.Codigo.ToString().Trim()).Single();
                                //Movimiento.Codigo = Modelo.ObtenerId().FirstOrDefault().Codigo.ToString().Trim();
                                Movimiento.Movimiento = movimientoTransportista.Movimiento;
                                Movimiento.IdTransportista = movimientoTransportista.IdTransportista;
                                //Movimiento.IdDocumento = movimiento.IdDocumento;
                                //Movimiento.Serie = movimiento.Serie;
                                //Movimiento.Numero = movimiento.Numero;
                                Movimiento.Fecha = movimientoTransportista.Fecha;
                                Movimiento.NumeroManual = movimientoTransportista.NumeroManual;
                                Movimiento.IdEstado = movimientoTransportista.IdEstado;
                                Movimiento.RegistroRecorrido = movimientoTransportista.RegistroRecorrido;
                                Movimiento.IdRutaOrigen = movimientoTransportista.IdRutaOrigen;
                                Movimiento.IdRutaDestino = movimientoTransportista.IdRutaDestino;
                                Movimiento.NumeroPersonas = movimientoTransportista.NumeroPersonas;
                                Movimiento.PromedioxPersona = movimientoTransportista.PromedioxPersona;
                                Movimiento.Precio = movimientoTransportista.Precio;
                                Movimiento.SubTotal = movimientoTransportista.SubTotal;
                                Movimiento.IGV = movimientoTransportista.IGV;
                                Movimiento.Total = movimientoTransportista.Total;
                                Movimiento.Observacion = movimientoTransportista.Observacion;
                                Movimiento.IdChofer = movimientoTransportista.IdChofer;
                                Movimiento.CampoDestino = movimientoTransportista.CampoDestino;
                                Movimiento.IdChofer = movimientoTransportista.IdChofer != null ? movimientoTransportista.IdChofer : (int?)null;

                                Movimiento.itemRecorridoIda = movimientoTransportista.itemRecorridoIda != null ? movimientoTransportista.itemRecorridoIda : "";
                                Movimiento.itemRecorridoRegreso = movimientoTransportista.itemRecorridoRegreso != null ? movimientoTransportista.itemRecorridoRegreso : "";

                                Movimiento.precioIda = movimientoTransportista.precioIda != null ? movimientoTransportista.precioIda : 0;
                                Movimiento.precioRegreso = movimientoTransportista.precioRegreso != null ? movimientoTransportista.precioRegreso : 0;

                                Modelo.SubmitChanges();
                                #endregion
                                Codigo = Movimiento.Codigo.ToString().Trim();

                                if (listaDetalleMovimientoInternoEliminados != null)
                                {
                                    #region Lista Detalle()
                                    if (listaDetalleMovimientoInternoEliminados.ToList().Count > 0)
                                    {
                                        foreach (SJ_RHMovimientoMovilidadDetalle item in listaDetalleMovimientoInternoEliminados)
                                        {
                                            if (Modelo.SJ_RHMovimientoMovilidadDetalle.Where(x =>
                                                x.Codigo.ToString().Trim() == item.Codigo.ToString().Trim() &&
                                                x.item.ToString().Trim() == item.item.ToString().Trim()
                                                ).ToList().Count == 1)
                                            {
                                                #region Eliminar detalle()
                                                try
                                                {
                                                    SJ_RHMovimientoMovilidadDetalle det = new SJ_RHMovimientoMovilidadDetalle();
                                                    det = Modelo.SJ_RHMovimientoMovilidadDetalle.Where(x =>
                                                    x.Codigo.ToString().Trim() == item.Codigo.ToString().Trim() &&
                                                    x.item.ToString().Trim() == item.item.ToString().Trim()
                                                    ).Single();

                                                    Modelo.SJ_RHMovimientoMovilidadDetalle.DeleteOnSubmit(det);
                                                    Modelo.SubmitChanges();
                                                }
                                                catch (Exception Ex)
                                                {

                                                    throw Ex;
                                                }

                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion
                                }

                                if (listaDetalleMovimientoInterno != null)
                                {
                                    #region Lista Detalle()
                                    if (listaDetalleMovimientoInterno.ToList().Count > 0)
                                    {
                                        foreach (SJ_RHMovimientoMovilidadDetalle item in listaDetalleMovimientoInterno)
                                        {

                                            if (Modelo.SJ_RHMovimientoMovilidadDetalle.Where(x => x.Codigo.ToString().Trim() == item.Codigo.ToString().Trim() && x.item.ToString().Trim() == item.item.ToString().Trim()).ToList().Count == 1)
                                            {
                                                #region Editar
                                                SJ_RHMovimientoMovilidadDetalle detalle = new SJ_RHMovimientoMovilidadDetalle();
                                                detalle = Modelo.SJ_RHMovimientoMovilidadDetalle.Where(x => x.Codigo.ToString().Trim() == item.Codigo.ToString().Trim() && x.item.ToString().Trim() == item.item.ToString().Trim()).Single();
                                                //detalle.Codigo = Codigo;
                                                //detalle.item = item.item;
                                                detalle.IdConsumidor = item.IdConsumidor;
                                                detalle.consumidor = item.consumidor;
                                                detalle.horaSalida = item.horaSalida;
                                                detalle.horaRegreso = item.horaRegreso;
                                                detalle.Precio = item.Precio;
                                                Modelo.SubmitChanges();
                                                #endregion
                                            }
                                            else
                                            {
                                                #region Nuevo
                                                if (item.consumidor.ToString().Trim() != "")
                                                {
                                                    SJ_RHMovimientoMovilidadDetalle detalle = new SJ_RHMovimientoMovilidadDetalle();
                                                    detalle.Codigo = Codigo;
                                                    detalle.item = item.item;
                                                    detalle.IdConsumidor = item.IdConsumidor;
                                                    detalle.consumidor = item.consumidor;
                                                    detalle.horaSalida = item.horaSalida;
                                                    detalle.horaRegreso = item.horaRegreso;
                                                    detalle.Precio = item.Precio;
                                                    Modelo.SJ_RHMovimientoMovilidadDetalle.InsertOnSubmit(detalle);
                                                    Modelo.SubmitChanges();
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    #endregion
                                }


                                if (ListaDetalleMovimientoInterLocalidadAsistenciaTrabajadores != null)
                                {
                                    #region Lista Detalle()
                                    if (ListaDetalleMovimientoInterLocalidadAsistenciaTrabajadores.ToList().Count > 0)
                                    {

                                        #region Eliminar lista registrada anteriormente()
                                        Modelo.SJ_RHEliminarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigo(Codigo);
                                        #endregion

                                        #region Detalle Movimiento InterLocalidad - Asistencia Trabajadores()
                                        if (ListaDetalleMovimientoInterLocalidadAsistenciaTrabajadores != null)
                                        {
                                            if (ListaDetalleMovimientoInterLocalidadAsistenciaTrabajadores.ToList().Count > 0)
                                            {
                                                foreach (var item in ListaDetalleMovimientoInterLocalidadAsistenciaTrabajadores)
                                                {
                                                    #region Registrar Movimiento de Movilidad por Asistencias de Trabajadores
                                                    SJ_RHMovimientoMovilidadAsistenciaTrabajador detalle = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                                                    detalle.codigoMovimientoMovilidad = Codigo;
                                                    detalle.item = item.item;
                                                    detalle.idCodigoGeneral = item.idCodigoGeneral != null ? item.idCodigoGeneral.ToString().Trim() : "";
                                                    detalle.nroDocumento = item.nroDocumento != null ? item.nroDocumento.ToString().Trim() : "";
                                                    detalle.nombresCompletos = item.nombresCompletos != null ? item.nombresCompletos.ToString().Trim() : "";
                                                    detalle.subPlanilla = item.subPlanilla != null ? item.subPlanilla.ToString().Trim() : "";
                                                    detalle.fechaRegistro = DateTime.Now;
                                                    detalle.idconsumidor = item.idConsumidor != null ? item.idConsumidor.ToString().Trim() : "";
                                                    detalle.estado = 1;
                                                    Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.InsertOnSubmit(detalle);
                                                    Modelo.SubmitChanges();
                                                    #endregion
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }

                                #region Registrar Log Historial
                                SJ_LogTablas logTabla = new SJ_LogTablas();
                                logTabla.IDEMPRESA = "001";
                                logTabla.IDLOG = Codigo;
                                logTabla.ITEM = Modelo.SJ_LogTableObtenerNumeroItemxTablaxCodigo(Codigo, "SJ_RHMovimientoMovilidad").FirstOrDefault().serie != null ? Modelo.SJ_LogTableObtenerNumeroItemxTablaxCodigo(Codigo, "SJ_RHMovimientoMovilidad").FirstOrDefault().serie : "000";
                                logTabla.TABLA = "SJ_RHMovimientoMovilidad";
                                logTabla.IDCAMPO = "";
                                logTabla.CAMPOCLAVE = "";
                                logTabla.IDTABLA = "Codigo";
                                logTabla.EVENTO = "MODIFICADO";
                                logTabla.VALORANTERIOR = Movimiento.NumeroPersonas.ToString();
                                logTabla.VALORACTUAL = Movimiento.Total.ToString();
                                logTabla.IDUSUARIO = Environment.UserName;
                                logTabla.MAQUINA = Environment.MachineName;
                                logTabla.FECHACREACION = DateTime.Now;
                                logTabla.VENTANA = "MovimientoRecorridosMantenimiento";
                                Modelo.SJ_LogTablas.InsertOnSubmit(logTabla);
                                Modelo.SubmitChanges();
                                #endregion



                            }
                            catch (Exception Ex)
                            {

                                Ex.Message.ToString(); ;
                            }
                            #endregion
                        }
                        else
                        {
                            #region Nuevo()

                            try
                            {
                                #region ObjetoMovimiento()

                                #region Movimiento Movilidad()
                                Movimiento = new SJ_RHMovimientoMovilidad();
                                Movimiento.Codigo = Modelo.ObtenerId().FirstOrDefault().Codigo.ToString().Trim();
                                Movimiento.Movimiento = movimientoTransportista.Movimiento;
                                Movimiento.IdTransportista = movimientoTransportista.IdTransportista;
                                Movimiento.IdDocumento = movimientoTransportista.IdDocumento;
                                Movimiento.Serie = movimientoTransportista.Serie;
                                Movimiento.Numero = movimientoTransportista.Numero;
                                Movimiento.Fecha = movimientoTransportista.Fecha;
                                Movimiento.NumeroManual = movimientoTransportista.NumeroManual;
                                Movimiento.IdEstado = movimientoTransportista.IdEstado;
                                Movimiento.RegistroRecorrido = movimientoTransportista.RegistroRecorrido;
                                Movimiento.IdRutaOrigen = movimientoTransportista.IdRutaOrigen;
                                Movimiento.IdRutaDestino = movimientoTransportista.IdRutaDestino;
                                Movimiento.NumeroPersonas = movimientoTransportista.NumeroPersonas;
                                Movimiento.PromedioxPersona = movimientoTransportista.PromedioxPersona;
                                Movimiento.Precio = movimientoTransportista.Precio;
                                Movimiento.SubTotal = movimientoTransportista.SubTotal;
                                Movimiento.IGV = movimientoTransportista.IGV;
                                Movimiento.Total = movimientoTransportista.Total;
                                Movimiento.Observacion = movimientoTransportista.Observacion;
                                //Movimiento.IdChofer = movimiento.IdChofer;
                                Movimiento.CampoDestino = movimientoTransportista.CampoDestino != null ? movimientoTransportista.CampoDestino : "001";
                                Movimiento.IdChofer = movimientoTransportista.IdChofer != null ? movimientoTransportista.IdChofer : (int?)null;


                                Movimiento.itemRecorridoIda = movimientoTransportista.itemRecorridoIda != null ? movimientoTransportista.itemRecorridoIda : "";
                                Movimiento.itemRecorridoRegreso = movimientoTransportista.itemRecorridoIda != null ? movimientoTransportista.itemRecorridoIda : "";

                                Movimiento.precioIda = movimientoTransportista.precioIda != null ? movimientoTransportista.precioIda : 0;
                                Movimiento.precioRegreso = movimientoTransportista.precioRegreso != null ? movimientoTransportista.precioRegreso : 0;


                                Modelo.SJ_RHMovimientoMovilidads.InsertOnSubmit(Movimiento);
                                Modelo.SubmitChanges();
                                Codigo = Movimiento.Codigo.ToString().Trim();
                                #endregion

                                #region Detalle Movimiento Interno()
                                if (listaDetalleMovimientoInterno != null)
                                {
                                    if (listaDetalleMovimientoInterno.ToList().Count > 0)
                                    {
                                        foreach (var item in listaDetalleMovimientoInterno)
                                        {
                                            SJ_RHMovimientoMovilidadDetalle detalle = new SJ_RHMovimientoMovilidadDetalle();
                                            detalle.Codigo = Codigo;
                                            detalle.item = item.item;
                                            detalle.IdConsumidor = item.IdConsumidor;
                                            detalle.consumidor = item.consumidor;
                                            detalle.horaSalida = item.horaSalida;
                                            detalle.horaRegreso = item.horaRegreso;
                                            detalle.Precio = item.Precio;
                                            Modelo.SJ_RHMovimientoMovilidadDetalle.InsertOnSubmit(detalle);
                                            Modelo.SubmitChanges();
                                        }
                                    }
                                }
                                #endregion

                                #region Detalle Movimiento InterLocalidad - Asistencia Trabajadores()
                                if (ListaDetalleMovimientoInterLocalidadAsistenciaTrabajadores != null)
                                {
                                    if (ListaDetalleMovimientoInterLocalidadAsistenciaTrabajadores.ToList().Count > 0)
                                    {
                                        foreach (var item in ListaDetalleMovimientoInterLocalidadAsistenciaTrabajadores)
                                        {
                                            #region Registrar Movimiento de Movilidad por Asistencias de Trabajadores
                                            SJ_RHMovimientoMovilidadAsistenciaTrabajador detalle = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                                            detalle.codigoMovimientoMovilidad = Codigo;
                                            detalle.item = item.item;
                                            detalle.idCodigoGeneral = item.idCodigoGeneral != null ? item.idCodigoGeneral.ToString().Trim() : "";
                                            detalle.nroDocumento = item.nroDocumento != null ? item.nroDocumento.ToString().Trim() : "";
                                            detalle.nombresCompletos = item.nombresCompletos != null ? item.nombresCompletos.ToString().Trim() : "";
                                            detalle.subPlanilla = item.subPlanilla != null ? item.subPlanilla.ToString().Trim() : "";
                                            detalle.fechaRegistro = DateTime.Now;
                                            detalle.estado = 1;
                                            Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.InsertOnSubmit(detalle);
                                            Modelo.SubmitChanges();
                                            #endregion
                                        }
                                    }
                                }
                                #endregion

                                #region Registrar Log Historial
                                SJ_LogTablas logTabla = new SJ_LogTablas();
                                logTabla.IDEMPRESA = "001";
                                logTabla.IDLOG = Codigo;
                                logTabla.ITEM = "001";
                                logTabla.TABLA = "SJ_RHMovimientoMovilidad";
                                logTabla.IDCAMPO = "";
                                logTabla.CAMPOCLAVE = "";
                                logTabla.IDTABLA = "Codigo";
                                logTabla.EVENTO = "NUEVO";
                                logTabla.VALORANTERIOR = Movimiento.NumeroPersonas.ToString();
                                logTabla.VALORACTUAL = Movimiento.Total.ToString();
                                logTabla.IDUSUARIO = Environment.UserName;
                                logTabla.MAQUINA = Environment.MachineName;
                                logTabla.FECHACREACION = DateTime.Now;
                                logTabla.VENTANA = "ProgramacionRefrigerioxPersonalMantenimiento";
                                Modelo.SJ_LogTablas.InsertOnSubmit(logTabla);
                                Modelo.SubmitChanges();
                                #endregion

                                #endregion
                            }
                            catch (Exception Ex)
                            {

                                Ex.Message.ToString();
                            }

                            #endregion
                        }

                        Modelo.Connection.Close();
                    }
                    #endregion
                    #endregion
                    //    Scope.Complete();
                    //}

                    #endregion
                }
                else
                {
                    Codigo = "";
                }
            }
            return Codigo;
        }

        /* LISTADO DE MOVIMIENTOS REGISTRADOS DURANTE UN PERIODO DEFINIDO POR EL USUARIO */
        public List<SJ_RHMovimientoMovilidadListadoResult> ListarMovimientosDeRecorridosPorPeriodos(string desde, string hasta)
        {
            List<SJ_RHMovimientoMovilidadListadoResult> Movimientos = new List<SJ_RHMovimientoMovilidadListadoResult>();
            string Periodo = Convert.ToDateTime(hasta).Year.ToString().Trim();
            cnx = ConfigurationManager.AppSettings["bd" + Periodo].ToString();

            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 900;
                #region Conexion y Consulta()

                if (desde != null && hasta != null)
                {
                    if (desde.ToString().Trim() != "" && hasta.ToString().Trim() != "")
                    {
                        Movimientos = new List<SJ_RHMovimientoMovilidadListadoResult>();
                        Movimientos = Modelo.SJ_RHMovimientoMovilidadListado(desde, hasta).ToList();
                    }
                }

                #endregion
                Modelo.Connection.Close();
            }
            return Movimientos;
        }

        /* ANULAR EL MOVIMIENTO */
        public void AnularMovimiento(string periodo, string CodigoMov)
        {
            using (TransactionScope Scope = new TransactionScope())
            {
                #region Transacción()
                string cnx;
                cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();
                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    Modelo.CommandTimeout = 1900;
                    SJ_RHMovimientoMovilidad Objeto = new SJ_RHMovimientoMovilidad();

                    if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo.ToString().Trim() == CodigoMov).ToList().Count == 1)
                    {
                        Objeto = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo.ToString().Trim() == CodigoMov).Single();
                        if (Objeto.IdEstado == "PE")
                        {
                            Objeto.IdEstado = "AN";
                        }
                        else
                        {
                            if (Objeto.IdEstado == "AN")
                            {
                                Objeto.IdEstado = "PE";
                            }
                        }


                        Modelo.SubmitChanges();
                    }
                }
                #endregion
                Scope.Complete();
            }
        }

        /* OBTEN EL ULTIMO NUMERO DE MOVIMIENTO YA SEA INTERNO O INTERLOCALIDAD, AL METODO LE ESPECIFICO EL TIPO DE DOCUMENTO SI ES INTERNO O INTERLOCAL */
        public string ObtenerNumeroDocumento(string criterio, string periodo)
        {
            string Numero = string.Empty;

            List<SJ_RHMovimientoMovilidadListadoResult> Movimientos = new List<SJ_RHMovimientoMovilidadListadoResult>();
            string Periodo = Convert.ToDateTime(periodo).Year.ToString().Trim();
            cnx = ConfigurationManager.AppSettings["bd" + Periodo].ToString();

            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 900;
                #region Conexion y Consulta()

                if (criterio != null)
                {
                    if (criterio.ToString().Trim() != "")
                    {
                        int NumObtenido = Convert.ToInt32(Modelo.SJ_RHObtenerUltimoNumeroDocumentoParteRecorrido(criterio).FirstOrDefault().Column1.Value);

                        switch (NumObtenido.ToString().Length)
                        {
                            case 1:
                                Numero = "000000" + NumObtenido.ToString();
                                break;

                            case 2:
                                Numero = "00000" + NumObtenido.ToString();
                                break;

                            case 3:
                                Numero = "0000" + NumObtenido.ToString();
                                break;

                            case 4:
                                Numero = "000" + NumObtenido.ToString();
                                break;

                            case 5:
                                Numero = "00" + NumObtenido.ToString();
                                break;

                            case 6:
                                Numero = "0" + NumObtenido.ToString();
                                break;

                            default:
                                Numero = NumObtenido.ToString();
                                break;
                        }

                    }
                }

                #endregion
                Modelo.Connection.Close();
            }
            return Numero;
        }

        /* METODO PARA OBTENER LOS DATOS DE UN DOCUMENTO DE MOVIMIENTO FILTRADO POR SU CODIGO */
        public SJ_RHObtenerDocumentoRecorridoMovilidadResult ObtenerDocumentoParteRecorrido(string Codigo, string periodo)
        {
            SJ_RHObtenerDocumentoRecorridoMovilidadResult Documento = new SJ_RHObtenerDocumentoRecorridoMovilidadResult();
            string Periodo = Convert.ToDateTime(periodo).Year.ToString().Trim();
            cnx = ConfigurationManager.AppSettings["bd" + Periodo].ToString();

            if (Codigo != null & Codigo.ToString().Trim() != "")
            {
                if (periodo != null && periodo.ToString().Trim() != "")
                {
                    using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                    {
                        Modelo.CommandTimeout = 987900;

                        #region Consulta()

                        var resultadosConsulta = Modelo.SJ_RHObtenerDocumentoRecorridoMovilidad(Codigo).ToList();

                        if (Modelo.SJ_RHObtenerDocumentoRecorridoMovilidad(Codigo).ToList().Count == 1)
                        {
                            Documento = Modelo.SJ_RHObtenerDocumentoRecorridoMovilidad(Codigo).Single();
                        }
                        else
                        {
                            Documento = new SJ_RHObtenerDocumentoRecorridoMovilidadResult();
                            Documento.Codigo = "";
                        }

                        #endregion

                        Modelo.Connection.Close();
                    }
                }
            }



            return Documento;
        }

        /* METODO PARA OBTENER EL DETALLE DE UN DOCUMENTO DE MOVIMIENTO FILTRADO POR SU CODIGO, ESTE DETALLE ES PARA LOS DOCUMENTOS DE MOVIMIENTO INTERNOS */
        public List<SJ_RHObtenerDocumentoRecorridoMovilidadDetalleResult> ObtenerDocumentoDetalleMovimientosInternos(string Codigo, string periodo)
        {
            List<SJ_RHObtenerDocumentoRecorridoMovilidadDetalleResult> DocDetalle = new List<SJ_RHObtenerDocumentoRecorridoMovilidadDetalleResult>();
            string Periodo = Convert.ToDateTime(periodo).Year.ToString().Trim();
            cnx = ConfigurationManager.AppSettings["bd" + Periodo].ToString();

            if (Codigo != null & Codigo.ToString().Trim() != "")
            {
                if (periodo != null && periodo.ToString().Trim() != "")
                {
                    using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                    {
                        Modelo.CommandTimeout = 900;
                        #region Consulta()

                        if (Modelo.SJ_RHObtenerDocumentoRecorridoMovilidad(Codigo).ToList().Count > 0)
                        {
                            DocDetalle = Modelo.SJ_RHObtenerDocumentoRecorridoMovilidadDetalle(Codigo).ToList();
                        }
                        else
                        {
                            DocDetalle = new List<SJ_RHObtenerDocumentoRecorridoMovilidadDetalleResult>();
                        }
                        #endregion

                        Modelo.Connection.Close();
                    }
                }
            }

            return DocDetalle;
        }

        /* METODO PARA OBTENER EL DETALLE DE UN DOCUMENTO DE MOVIMIENTO FILTRADO POR SU CODIGO, ESTE DETALLE ES PARA LOS DOCUMENTOS DE MOVIMIENTO INTERLOCALIDAD, ES DECIR CARGA LA LISTA DE TRABAJADORES BENEFICIADOS EN ESTE MOVIMIENTO DE TRANPORTISTAS */
        public List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ObtenerDocumentoDetalleMovimientosInterLocalidades(string Codigo, string periodo)
        {
            List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> DocDetalle = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
            string Periodo = Convert.ToDateTime(periodo).Year.ToString().Trim();
            cnx = ConfigurationManager.AppSettings["bd" + Periodo].ToString();

            if (Codigo != null & Codigo.ToString().Trim() != "")
            {
                if (periodo != null && periodo.ToString().Trim() != "")
                {
                    using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                    {
                        Modelo.CommandTimeout = 900;
                        #region Consulta()

                        if (Modelo.SJ_RHObtenerDocumentoRecorridoMovilidad(Codigo).ToList().Count == 1)
                        {
                            DocDetalle = Modelo.SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigo(Codigo).ToList();
                        }
                        #endregion

                        Modelo.Connection.Close();
                    }
                }
            }

            return DocDetalle;
        }

        public List<SJ_RHMovimientMovilidadPendientesFacturacionResult> ActivarListaVista(int Activar, List<string> codigoSelecionados, List<SJ_RHMovimientMovilidadPendientesFacturacionResult> ListadoPendientesFacturacion)
        {
            List<SJ_RHMovimientMovilidadPendientesFacturacionResult> Listado = new List<SJ_RHMovimientMovilidadPendientesFacturacionResult>();

            Listado = (from item in ListadoPendientesFacturacion.Where(x => x.IdEstado.ToString().Trim() == "PE").ToList()
                       where !(codigoSelecionados.Contains(item.Codigo.ToString()))
                       select item
                           ).ToList();


            foreach (var codigo in codigoSelecionados)
            {
                foreach (SJ_RHMovimientMovilidadPendientesFacturacionResult item in ListadoPendientesFacturacion)
                {
                    if (item.Codigo.ToString() == codigo.ToString().Trim())
                    {
                        #region
                        SJ_RHMovimientMovilidadPendientesFacturacionResult movimiento = new SJ_RHMovimientMovilidadPendientesFacturacionResult();
                        movimiento.Codigo = item.Codigo;

                        if (Activar == 0)
                        {
                            movimiento.Selecionado = 0;
                        }
                        else
                        {
                            movimiento.Selecionado = 1;
                        }

                        movimiento.Movimiento = item.Movimiento;
                        movimiento.IdTransportista = item.IdTransportista;
                        movimiento.RUC = item.RUC;
                        movimiento.placa = item.placa;
                        movimiento.categoriaMovilidad = item.categoriaMovilidad;
                        movimiento.nombreCorto = item.nombreCorto;
                        movimiento.TipoMovilidad = item.TipoMovilidad;
                        movimiento.EsMovilidadlocal = item.EsMovilidadlocal;
                        movimiento.EsInterlocal = item.EsInterlocal;
                        movimiento.DOCUMENTO = item.DOCUMENTO;
                        movimiento.Fecha = item.Fecha;
                        movimiento.idRegistroRecorrido = item.idRegistroRecorrido;
                        movimiento.RegistroMovimiento = item.RegistroMovimiento;
                        movimiento.idRutaOrigen = item.idRutaOrigen;
                        movimiento.recorridoIda = item.recorridoIda;
                        movimiento.idRutaDestino = item.idRutaDestino;
                        movimiento.recorridoVuelta = item.recorridoVuelta;
                        movimiento.numeroPersonas = item.numeroPersonas;
                        movimiento.promedioPersona = item.promedioPersona;
                        movimiento.precio = item.precio;
                        movimiento.subTotal = item.subTotal;
                        movimiento.igv = item.igv;
                        movimiento.total = item.total;
                        movimiento.idChofer = item.idChofer;
                        movimiento.Chofer = item.Chofer;
                        movimiento.idCampoDestino = item.idCampoDestino;
                        movimiento.CampoDestino = item.CampoDestino;
                        movimiento.IdEstado = item.IdEstado;
                        Listado.Add(movimiento);
                        #endregion
                    }
                }
            }



            return Listado.OrderBy(x => x.Fecha).OrderBy(x => x.RegistroMovimiento).ToList();
        }

        public List<SJ_RHMovimientMovilidadPendientesFacturacionResult> VisualizarLista(int Activar, List<string> codigoSelecionados, List<SJ_RHMovimientMovilidadPendientesFacturacionResult> ListadoPendientesFacturacion)
        {
            List<SJ_RHMovimientMovilidadPendientesFacturacionResult> Listado = new List<SJ_RHMovimientMovilidadPendientesFacturacionResult>();

            var Listadobajas = (from item in ListadoPendientesFacturacion.ToList()
                                where !(codigoSelecionados.Contains(item.Codigo.ToString()))
                                select item
                            ).ToList();

            foreach (SJ_RHMovimientMovilidadPendientesFacturacionResult item in Listadobajas)
            {

                #region
                SJ_RHMovimientMovilidadPendientesFacturacionResult movimiento = new SJ_RHMovimientMovilidadPendientesFacturacionResult();
                movimiento.Codigo = item.Codigo;
                movimiento.Selecionado = 0;
                movimiento.Movimiento = item.Movimiento;
                movimiento.IdTransportista = item.IdTransportista;
                movimiento.RUC = item.RUC;
                movimiento.placa = item.placa;
                movimiento.categoriaMovilidad = item.categoriaMovilidad;
                movimiento.nombreCorto = item.nombreCorto;
                movimiento.TipoMovilidad = item.TipoMovilidad;
                movimiento.EsMovilidadlocal = item.EsMovilidadlocal;
                movimiento.EsInterlocal = item.EsInterlocal;
                movimiento.DOCUMENTO = item.DOCUMENTO;
                movimiento.Fecha = item.Fecha;
                movimiento.idRegistroRecorrido = item.idRegistroRecorrido;
                movimiento.RegistroMovimiento = item.RegistroMovimiento;
                movimiento.idRutaOrigen = item.idRutaOrigen;
                movimiento.recorridoIda = item.recorridoIda;
                movimiento.idRutaDestino = item.idRutaDestino;
                movimiento.recorridoVuelta = item.recorridoVuelta;
                movimiento.numeroPersonas = item.numeroPersonas;
                movimiento.promedioPersona = item.promedioPersona;
                movimiento.precio = item.precio;
                movimiento.subTotal = item.subTotal;
                movimiento.igv = item.igv;
                movimiento.total = item.total;
                movimiento.idChofer = item.idChofer;
                movimiento.Chofer = item.Chofer;
                movimiento.idCampoDestino = item.idCampoDestino;
                movimiento.CampoDestino = item.CampoDestino;

                if (Activar == 0)
                {
                    movimiento.IdEstado = "PE";
                }
                else
                {
                    movimiento.IdEstado = "BA";
                }

                Listado.Add(movimiento);
                #endregion
            }


            foreach (var codigo in codigoSelecionados)
            {
                foreach (SJ_RHMovimientMovilidadPendientesFacturacionResult item in ListadoPendientesFacturacion)
                {
                    if (item.Codigo.ToString() == codigo.ToString().Trim())
                    {
                        #region
                        SJ_RHMovimientMovilidadPendientesFacturacionResult movimiento = new SJ_RHMovimientMovilidadPendientesFacturacionResult();
                        movimiento.Codigo = item.Codigo;
                        movimiento.Selecionado = 0;
                        movimiento.Movimiento = item.Movimiento;
                        movimiento.IdTransportista = item.IdTransportista;
                        movimiento.RUC = item.RUC;
                        movimiento.placa = item.placa;
                        movimiento.categoriaMovilidad = item.categoriaMovilidad;
                        movimiento.nombreCorto = item.nombreCorto;
                        movimiento.TipoMovilidad = item.TipoMovilidad;
                        movimiento.EsMovilidadlocal = item.EsMovilidadlocal;
                        movimiento.EsInterlocal = item.EsInterlocal;
                        movimiento.DOCUMENTO = item.DOCUMENTO;
                        movimiento.Fecha = item.Fecha;
                        movimiento.idRegistroRecorrido = item.idRegistroRecorrido;
                        movimiento.RegistroMovimiento = item.RegistroMovimiento;
                        movimiento.idRutaOrigen = item.idRutaOrigen;
                        movimiento.recorridoIda = item.recorridoIda;
                        movimiento.idRutaDestino = item.idRutaDestino;
                        movimiento.recorridoVuelta = item.recorridoVuelta;
                        movimiento.numeroPersonas = item.numeroPersonas;
                        movimiento.promedioPersona = item.promedioPersona;
                        movimiento.precio = item.precio;
                        movimiento.subTotal = item.subTotal;
                        movimiento.igv = item.igv;
                        movimiento.total = item.total;
                        movimiento.idChofer = item.idChofer;
                        movimiento.Chofer = item.Chofer;
                        movimiento.idCampoDestino = item.idCampoDestino;
                        movimiento.CampoDestino = item.CampoDestino;

                        if (Activar == 0)
                        {
                            movimiento.IdEstado = "PE";
                        }
                        else
                        {
                            movimiento.IdEstado = "PE";
                        }

                        Listado.Add(movimiento);
                        #endregion
                    }

                }
            }

            return Listado.OrderBy(x => x.Fecha).OrderBy(x => x.RegistroMovimiento).ToList();
        }

        public void EliminarMovimiento(SJ_RHMovimientoMovilidad movimiento)
        {
            string Codigo = string.Empty;
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                if (Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo.ToString().Trim() == movimiento.Codigo.ToString().Trim()).ToList().Count == 1)
                {
                    SJ_RHMovimientoMovilidad oMovimiento = new SJ_RHMovimientoMovilidad();
                    oMovimiento = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo.ToString().Trim() == movimiento.Codigo.ToString().Trim()).Single();
                    if (oMovimiento.IdEstado.ToString().Trim() == "PE")
                    {
                        var detallesDelMovimiento = Modelo.SJ_RHMovimientoMovilidadDetalle.Where(x => x.Codigo.ToString().Trim() == oMovimiento.Codigo.ToString().Trim()).ToList();

                        if (detallesDelMovimiento != null && detallesDelMovimiento.ToList().Count > 0)
                        {
                            foreach (var itemDetalle in detallesDelMovimiento)
                            {

                                var listadoDetallexCodigo = Modelo.SJ_RHMovimientoMovilidadDetalle.Where(x => x.Codigo.ToString().Trim() == itemDetalle.Codigo.ToString().Trim() && x.item.ToString().Trim() == itemDetalle.item.ToString().Trim()).ToList();

                                if (listadoDetallexCodigo != null && listadoDetallexCodigo.ToList().Count == 1)
                                {
                                    SJ_RHMovimientoMovilidadDetalle oMovimientoDetalle = new SJ_RHMovimientoMovilidadDetalle();
                                    oMovimientoDetalle = Modelo.SJ_RHMovimientoMovilidadDetalle.Where(x => x.Codigo.ToString().Trim() == itemDetalle.Codigo.ToString().Trim() && x.item.ToString().Trim() == itemDetalle.item.ToString().Trim()).Single();
                                    Modelo.SJ_RHMovimientoMovilidadDetalle.DeleteOnSubmit(oMovimientoDetalle);
                                    Modelo.SubmitChanges();
                                }



                            }
                        }



                        var listadoMovimientoMovilidadAsistenciaTrabajador = Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.Where(x => x.codigoMovimientoMovilidad.ToString().Trim() == movimiento.Codigo.ToString().Trim()).ToList();
                        if (listadoMovimientoMovilidadAsistenciaTrabajador != null && listadoMovimientoMovilidadAsistenciaTrabajador.ToList().Count > 0)
                        {
                            foreach (var itemDetalleTrabajador in listadoMovimientoMovilidadAsistenciaTrabajador)
                            {
                                SJ_RHMovimientoMovilidadAsistenciaTrabajador oMovimientoDetalleTrabajador = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                                oMovimientoDetalleTrabajador = Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.Where(x => x.codigoMovimientoMovilidad == itemDetalleTrabajador.codigoMovimientoMovilidad.ToString().Trim() && x.item.ToString().Trim() == itemDetalleTrabajador.item.ToString().Trim()).Single();
                                Modelo.SJ_RHMovimientoMovilidadAsistenciaTrabajador.DeleteOnSubmit(oMovimientoDetalleTrabajador);
                                Modelo.SubmitChanges();
                            }
                        }

                    }
                    Modelo.SJ_RHMovimientoMovilidads.DeleteOnSubmit(oMovimiento);
                    Modelo.SubmitChanges();

                    Modelo.Connection.Close();
                    Modelo.Dispose();
                }
            }
        }

        public List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ValidarListaTrabajadores(List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ListaDetalleAsistencia, string fechaAsistencia)
        {
            List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> listado = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    Modelo.CommandTimeout = 9999900;
                    #region Actualizar()
                    if (ListaDetalleAsistencia != null && ListaDetalleAsistencia.ToList().Count > 0)
                    {
                        foreach (var item in ListaDetalleAsistencia)
                        {

                            List<SJ_RRHHObtenerDatosTrabajadorByAsistenciaResult> resultadoConsulta = new List<SJ_RRHHObtenerDatosTrabajadorByAsistenciaResult>();

                            resultadoConsulta = Modelo.SJ_RRHHObtenerDatosTrabajadorByAsistencia(item.idCodigoGeneral, item.nroDocumento, fechaAsistencia, fechaAsistencia).ToList();

                            if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                            {
                                if (resultadoConsulta.ToList().Count == 1)
                                {
                                    SJ_RRHHObtenerDatosTrabajadorByAsistenciaResult resultadoConsultaUnificado = resultadoConsulta.OrderByDescending(x => x.total_horas).Single();
                                    listado.Add(new SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult
                                    {
                                        codigoMovimientoMovilidad = item.codigoMovimientoMovilidad != null ? item.codigoMovimientoMovilidad.ToString().Trim() : "",
                                        item = item.item != null ? item.item.ToString().Trim().PadLeft(3, '0') : "000",
                                        idCodigoGeneral = resultadoConsultaUnificado.CodigoPersonal != null ? resultadoConsultaUnificado.CodigoPersonal.ToString().Trim() : "",
                                        nroDocumento = resultadoConsultaUnificado.DniTrabajador != null ? resultadoConsultaUnificado.DniTrabajador.ToString().Trim() : "",
                                        nombresCompletos = resultadoConsultaUnificado.NombresTrabajador != null ? resultadoConsultaUnificado.NombresTrabajador.ToString().Trim() : "",
                                        subPlanilla = resultadoConsultaUnificado.SubPlanilla != null ? resultadoConsultaUnificado.SubPlanilla.ToString().Trim() : "",
                                        fechaRegistro = DateTime.Now != null ? DateTime.Now : (DateTime?)null,
                                        estado = Convert.ToByte(1),
                                        idConsumidor = resultadoConsultaUnificado.idconsumidor != null ? resultadoConsultaUnificado.idconsumidor.ToString().Trim() : "",
                                        consumidor = resultadoConsultaUnificado.area != null ? resultadoConsultaUnificado.area.ToString().Trim() : "",
                                        //hora = resultadoConsultaUnificado.hora != null ? resultadoConsultaUnificado.hora.ToString().Trim() : "",
                                    }
                                  );
                                }
                                else
                                {
                                    decimal? horas = resultadoConsulta.Max(x => x.total_horas);
                                    var resultadoConsultaUnificado = resultadoConsulta.Where(x => x.total_horas == horas).ElementAt(0);


                                    listado.Add(new SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult
                                    {
                                        codigoMovimientoMovilidad = item.codigoMovimientoMovilidad != null ? item.codigoMovimientoMovilidad.ToString().Trim() : "",
                                        item = item.item != null ? item.item.ToString().Trim().PadLeft(3, '0') : "000",
                                        idCodigoGeneral = resultadoConsultaUnificado.CodigoPersonal != null ? resultadoConsultaUnificado.CodigoPersonal.ToString().Trim() : "",
                                        nroDocumento = resultadoConsultaUnificado.DniTrabajador != null ? resultadoConsultaUnificado.DniTrabajador.ToString().Trim() : "",
                                        nombresCompletos = resultadoConsultaUnificado.NombresTrabajador != null ? resultadoConsultaUnificado.NombresTrabajador.ToString().Trim() : "",
                                        subPlanilla = resultadoConsultaUnificado.SubPlanilla != null ? resultadoConsultaUnificado.SubPlanilla.ToString().Trim() : "",
                                        fechaRegistro = DateTime.Now != null ? DateTime.Now : (DateTime?)null,
                                        estado = Convert.ToByte(1),
                                        idConsumidor = resultadoConsultaUnificado.idconsumidor != null ? resultadoConsultaUnificado.idconsumidor.ToString().Trim() : "",
                                        consumidor = resultadoConsultaUnificado.area != null ? resultadoConsultaUnificado.area.ToString().Trim() : "",
                                    }
                                    );
                                }
                            }
                        }
                        #endregion
                        Modelo.Connection.Close();
                        Modelo.Dispose();
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            return listado;
        }


        /* obtener lista de pasajeros agrupados por paradero de un movimiento de recorrido */
        public List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ObtenerListaPasajerosByParadero(List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ListaPasajerosByMovimientoRecorrido)
        {

            List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> listado = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
            if (ListaPasajerosByMovimientoRecorrido != null && ListaPasajerosByMovimientoRecorrido.ToList().Count > 0)
            {
                var paraderos = (from item in ListaPasajerosByMovimientoRecorrido
                                 where item.idParadero != null
                                 group item by new { item.idParadero } into j
                                 select new
                                 {
                                     idParadero = j.Key.idParadero.Trim()
                                 }).ToList();

                if (paraderos != null && paraderos.ToList().Count > 0)
                {
                    foreach (var itemParadero in paraderos)
                    {
                        var resultadoConsulta = ListaPasajerosByMovimientoRecorrido.Where(x => x.idParadero.Trim() == itemParadero.idParadero.Trim()).ToList();
                        SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult registro = new SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult();
                        registro.idParadero = itemParadero.idParadero.Trim();
                        registro.paradero = resultadoConsulta.FirstOrDefault().paradero != null ? resultadoConsulta.FirstOrDefault().paradero.Trim() : string.Empty;
                        registro.cantidad = resultadoConsulta.Count();
                        listado.Add(registro);
                    }
                }

            }


            return listado;

        }

        public List<Paradero> ObtenerListadoParaderosActivos(string periodoConsulta)
        {
            List<Paradero> listado = new List<Paradero>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoConsulta.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                Contexto.CommandTimeout = 99999;

                var resultadoConsulta = Contexto.SJ_Paraderos.Where(x => x.tipo == Convert.ToChar("T")).ToList().OrderBy(x => x.IdParadero).ToList();

                listado = (from item in resultadoConsulta
                           where item.IdParadero != null
                           group item by new { item.IdParadero } into j
                           select new Paradero
                           {
                               idParadero = j.Key.IdParadero,
                               descripcionParadero = j.FirstOrDefault().DescripcionParadero != null ? j.FirstOrDefault().DescripcionParadero.Trim() : string.Empty,
                               observacion = j.FirstOrDefault().Observacion != null ? j.FirstOrDefault().Observacion.Trim() : string.Empty,
                               estado = j.FirstOrDefault().ESTADO != null ? Convert.ToInt32(j.FirstOrDefault().ESTADO.Value) : 0,
                               tipo = j.FirstOrDefault().tipo != null ? j.FirstOrDefault().tipo.ToString().Trim() : string.Empty,
                               estadoDescripcion = ((j.FirstOrDefault().ESTADO != null ? Convert.ToInt32(j.FirstOrDefault().ESTADO.Value) : 0) == 1) ? "ACTIVO" : "ANULADO",
                               tipoDescripcion = (j.FirstOrDefault().tipo != null ? j.FirstOrDefault().tipo.ToString().Trim() : string.Empty) == "T" ? "TRANSPORTE" : "PENSION",
                               numeroPasajeros = 0,
                               EsSelecionado = 0,
                           }).ToList();


                Contexto.Connection.Close();
            }

            return listado;
        }


        public List<Paradero> ObtenerListadoAgrupadoDistribucionPasajerosPorParadero(string periodo, string codigoMovimientoRecorrido)
        {
            List<Paradero> listado = new List<Paradero>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Contexto.CommandTimeout = 99999;

                //var resultadoConsulta = Contexto.SJ_Paraderos.Where(x => x.tipo == Convert.ToChar("T")).ToList().OrderBy(x => x.IdParadero).ToList();
                var resultadoConsulta = Contexto.SJ_ListadoPasajerosByMovimientoRecorrido(codigoMovimientoRecorrido).ToList();


                listado = (from item in resultadoConsulta
                           where item.idParadero != null
                           group item by new { item.idParadero } into j
                           select new Paradero
                           {
                               idParadero = j.Key.idParadero,
                               descripcionParadero = j.FirstOrDefault().paradero != null ? j.FirstOrDefault().paradero.Trim() : string.Empty,
                               observacion = string.Empty,
                               estado = 1,
                               tipo = "T",
                               estadoDescripcion = "ACTIVO",
                               tipoDescripcion = "TRANSPORTE",
                               numeroPasajeros = j.Sum(x => x.numeroPasajero != null ? x.numeroPasajero : 0),
                               EsSelecionado = 1
                           }).ToList();


                Contexto.Connection.Close();
            }

            return listado;
        }

        /* Vista de la parte inferior izquierda */
        public List<Paradero> ObtenerListadoDistribucionPasajerosPorParadero(string periodo, List<Paradero> listadoParaderoActivos, List<Paradero> listadoDistribucionPasajerosPorParadero)
        {
            List<Paradero> listadoUnion = new List<Paradero>();
            List<Paradero> listado = new List<Paradero>();

            listadoUnion.AddRange(listadoParaderoActivos);
            listadoUnion.AddRange(listadoDistribucionPasajerosPorParadero);



            listado = (from item in listadoUnion
                       where item.idParadero != null
                       group item by new { item.idParadero } into j
                       select new Paradero
                       {
                           idParadero = j.Key.idParadero,
                           descripcionParadero = j.FirstOrDefault().descripcionParadero != null ? j.FirstOrDefault().descripcionParadero.Trim() : string.Empty,
                           observacion = (j.FirstOrDefault().observacion != null && j.FirstOrDefault().observacion.Trim() != string.Empty) ? j.FirstOrDefault().observacion.Trim() : string.Empty,
                           estado = j.FirstOrDefault().estado != null ? Convert.ToInt32(j.FirstOrDefault().estado) : 0,
                           tipo = j.FirstOrDefault().tipo != null ? j.FirstOrDefault().tipo.ToString().Trim() : string.Empty,
                           estadoDescripcion = j.FirstOrDefault().estadoDescripcion != null ? j.FirstOrDefault().estadoDescripcion.ToString().Trim() : string.Empty,
                           tipoDescripcion = j.FirstOrDefault().tipoDescripcion != null ? j.FirstOrDefault().tipoDescripcion.ToString().Trim() : string.Empty,
                           numeroPasajeros = j.Sum(x => x.numeroPasajeros),
                           EsSelecionado = j.Max(x => x.EsSelecionado),
                       }).ToList();



            return listado;
        }


        public void GenerarDistribucionPasajerosByParadero(List<Paradero> listaParaderosGenerar, string codigoMovimiento, string periodo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Contexto.CommandTimeout = 99999;

                List<SJ_ListadoPasajerosByMovimientoRecorridoResult> resultadoConsulta = new List<SJ_ListadoPasajerosByMovimientoRecorridoResult>();
                resultadoConsulta = Contexto.SJ_ListadoPasajerosByMovimientoRecorrido(codigoMovimiento).ToList();

                /* Eliminar registros */
                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                {
                    foreach (var item in resultadoConsulta)
                    {
                        SJ_RHMovimientoMovilidadAsistenciaTrabajador oPasajero = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                        oPasajero = Contexto.SJ_RHMovimientoMovilidadAsistenciaTrabajador.Where(x => x.codigoMovimientoMovilidad.Trim() == item.codigoMovimientoMovilidad.Trim() && x.item == item.item).Single();
                        Contexto.SJ_RHMovimientoMovilidadAsistenciaTrabajador.DeleteOnSubmit(oPasajero);
                    }
                }

                Contexto.SubmitChanges();


                /* Agregar registros */
                if (listaParaderosGenerar != null && listaParaderosGenerar.ToList().Count > 0)
                {
                    int numeroColaborador = 1;
                    foreach (var item in listaParaderosGenerar)
                    {
                        for (int i = 0; i < item.numeroPasajeros; i++)
                        {
                            SJ_RHMovimientoMovilidadAsistenciaTrabajador oPasajero = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                            oPasajero.codigoMovimientoMovilidad = codigoMovimiento;
                            oPasajero.item = numeroColaborador.ToString().PadLeft(3, '0');
                            oPasajero.idCodigoGeneral = numeroColaborador.ToString().PadLeft(7, '0');
                            oPasajero.nroDocumento = numeroColaborador.ToString().PadLeft(7, '0');
                            oPasajero.nombresCompletos = "COLABORADOR " + numeroColaborador.ToString();
                            oPasajero.subPlanilla = "SEMANAL";
                            oPasajero.fechaRegistro = DateTime.Now;
                            oPasajero.estado = 1;
                            oPasajero.idconsumidor = "CVSJ";
                            oPasajero.idParadero = item.idParadero != null ? item.idParadero.Trim() : string.Empty;
                            oPasajero.paradero = item.descripcionParadero != null ? item.descripcionParadero.Trim() : string.Empty;
                            Contexto.SJ_RHMovimientoMovilidadAsistenciaTrabajador.InsertOnSubmit(oPasajero);
                            numeroColaborador += 1;
                        }
                    }
                }

                Contexto.SubmitChanges();
                Contexto.Connection.Close();

            }
        }


        /* 23.08.16 */

        public List<SJ_RHDistribucionPersonalPorParaderoResult> ObtenerListadoDistribucionPasajerosPorParadero(string periodo, string desde, string hasta, string rucTransportista)
        {
            List<SJ_RHDistribucionPersonalPorParaderoResult> listado = new List<SJ_RHDistribucionPersonalPorParaderoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Contexto.CommandTimeout = 9999999;
                //var resultadoConsulta = Contexto.SJ_Paraderos.Where(x => x.tipo == Convert.ToChar("T")).ToList().OrderBy(x => x.IdParadero).ToList();
                listado = Contexto.SJ_RHDistribucionPersonalPorParadero(desde, hasta).ToList();
                Contexto.Connection.Close();
                Contexto.Dispose();
            }
            return listado;

        }



        /* 12.05.19 Liberar en las marcaciones moviles el codigo de transferencia o el movimiento donde se estaba referenciando esas marcaciones */
        public string LiberarCodigoTransferenciaMovilFromTransferenciaMovilTrasnporte(string periodo, string codigoRegistro, string placa, int idRuta, string idConductor, string fecha, char tipoAsistencia)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Contexto.SJ_RHLiberarCodigoTransferenciaMovilFromTransferenciaMovilTrasnporte(codigoRegistro, placa, idRuta, idConductor, fecha, tipoAsistencia);
            }
            return string.Empty;
        }

        /* 12.05.19 Actualizar en las marcaciones moviles con un codigo de transferencia en el movimiento o parte diario de unidades de traslado de personal */
        public string ActualizarCodigoTransferenciaMovilFromTransferenciaMovilTrasnporte(string periodo, string codigoRegistro, string placa, int idRuta, string idConductor, string fecha, char tipoAsistencia)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Contexto.SJ_RHActualizarCodigoTransferenciaMovilFromTransferenciaMovilTrasnporte(codigoRegistro, placa, idRuta, idConductor, fecha, tipoAsistencia);
            }
            return string.Empty;
        }

        /* 12.05.19 obtener las marcaciones moviles que no estan asociadas a un movimiento de traslado de personal o parte diario de unidades que ofrecen el servicio de traslado del personal */
        public List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult> ObtenerListadoMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRuta(string periodo, string codigoRegistro, string placa, int idRuta, string idConductor, string fecha, char tipoAsistencia)
        {
            List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult> listado = new List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Substring(0,4)].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                listado = Contexto.SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRuta(placa, idRuta, idConductor, fecha, tipoAsistencia).ToList(); ;
            }
            return listado;
        }


    }
}