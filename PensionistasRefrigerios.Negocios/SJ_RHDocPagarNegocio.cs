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
    public class SJ_RHDocPagarNegocio
    {
        private Grupo Doc;
        private SJ_RHDocPagarAsociadoNegocios modeloDocumentoPagarAsociados;

        public List<SJ_RHDocPagarListarxPeriodoResult> ListarDocumentosAPagar(string periodo, string desde, string hasta)
        {
            string cnx = string.Empty;
            List<SJ_RHDocPagarListarxPeriodoResult> Listado = new List<SJ_RHDocPagarListarxPeriodoResult>();
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Listado = Modelo.SJ_RHDocPagarListarxPeriodo(desde, hasta).ToList();
            }

            return Listado;
        }

        public List<SJ_RHDocPagarxCodigoResult> ObtenerObjetoDocPagar(string periodo, string codigo)
        {
            string cnx = string.Empty;
            List<SJ_RHDocPagarxCodigoResult> Listado = new List<SJ_RHDocPagarxCodigoResult>();
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Listado = Modelo.SJ_RHDocPagarxCodigo(codigo).ToList();
            }

            return Listado;
        }

        public List<SJ_RHDocPagarDetallexCodigoResult> ObtenerDetalleDocPagar(string periodo, string codigo)
        {
            string cnx = string.Empty;
            List<SJ_RHDocPagarDetallexCodigoResult> Listado = new List<SJ_RHDocPagarDetallexCodigoResult>();
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Listado = Modelo.SJ_RHDocPagarDetallexCodigo(codigo).ToList();
            }

            return Listado;
        }

        public void ActualizarEstadoMovimientoTransportista(List<SJ_RHDocPagarDetalle> detalleDocPagar, string periodo)
        {
            try
            {
                #region Actualizar()
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

                using (TransactionScope Scope = new TransactionScope())
                {

                    using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                    {
                        #region

                        Modelo.CommandTimeout = 9000;

                        var MovimientoMovilidades = (from item in detalleDocPagar
                                                     group item by new { item.codigoMovimiento } into j
                                                     select new SJ_RHMovimientoMovilidad
                                                     {
                                                         Codigo = j.Key.codigoMovimiento.ToString().Trim(),
                                                     }
                                                         ).ToList();

                        foreach (SJ_RHMovimientoMovilidad item in MovimientoMovilidades)
                        {
                            #region Actualizar Estado del movimiento de parte de transportista()
                            try
                            {
                                //SJ_RHMovimientoMovilidad objeto = new SJ_RHMovimientoMovilidad();
                                //if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.Codigo.ToString().Trim() == item.Codigo.ToString() && x.IdEstado == "PE").ToList().Count == 1)
                                //{

                                //    objeto = Modelo.SJ_RHMovimientoMovilidad.Where(x => x.Codigo.ToString().Trim() == item.Codigo.ToString() && x.IdEstado == "PE").Single();
                                //    objeto.IdEstado = "PR";
                                //    Modelo.SubmitChanges();
                                //}

                                SJ_RHMovimientoMovilidad objeto = new SJ_RHMovimientoMovilidad();
                                if (Modelo.SJ_RHMovimientoMovilidadBuscarxCodigo(item.Codigo.ToString()).ToList().Count == 1)
                                {

                                    objeto = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo.ToString().Trim() == item.Codigo.ToString() && x.IdEstado == "PE").Single();
                                    objeto.IdEstado = "PR";
                                    Modelo.SubmitChanges();
                                }

                            }
                            catch (Exception Ex)
                            {

                                Ex.Message.ToString();
                            }
                            #endregion
                        }


                        #endregion
                        Modelo.Connection.Close();
                    }
                    Scope.Complete();
                }
                #endregion
            }

            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }

        }

        public string RegistrarFacturacionTransportista(SJ_RHDocPagar cabecera, List<SJ_RHDocPagarDetalle> detalle, string periodo, SJ_LogTablas SJLogTablas, SJ_RHDocPagarAsociado documentoPagarAsociado)
        {
            string codigo = string.Empty;
            try
            {
                #region Registrar Facturación()

                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

                //using (TransactionScope Scope = new TransactionScope())
                //{
                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    Modelo.CommandTimeout = 999998;
                    codigo = Modelo.ObtenerId().FirstOrDefault().Codigo.ToString().Trim();


                    #region Actualizar Estado del movimiento de parte de transportista()
                    var MovimientoMovilidades = (from item in detalle
                                                 group item by new { item.codigoMovimiento } into j
                                                 select new SJ_RHMovimientoMovilidad
                                                 {
                                                     Codigo = j.Key.codigoMovimiento.ToString().Trim(),
                                                 }
                                                     ).ToList();

                    foreach (SJ_RHMovimientoMovilidad item in MovimientoMovilidades)
                    {
                        #region Actualizar Estado del movimiento de parte de transportista()
                        try
                        {
                            //SJ_RHMovimientoMovilidad objeto = new SJ_RHMovimientoMovilidad();
                            //if (Modelo.SJ_RHMovimientoMovilidad.Where(x => x.Codigo.ToString().Trim() == item.Codigo.ToString() && x.IdEstado == "PE").ToList().Count == 1)
                            //{

                            //    objeto = Modelo.SJ_RHMovimientoMovilidad.Where(x => x.Codigo.ToString().Trim() == item.Codigo.ToString() && x.IdEstado == "PE").Single();
                            //    objeto.IdEstado = "PR";
                            //    Modelo.SubmitChanges();
                            //}

                            SJ_RHMovimientoMovilidad objeto = new SJ_RHMovimientoMovilidad();
                            if (Modelo.SJ_RHMovimientoMovilidadBuscarxCodigo(item.Codigo.ToString()).ToList().Count == 1)
                            {

                                objeto = Modelo.SJ_RHMovimientoMovilidads.Where(x => x.Codigo.ToString().Trim() == item.Codigo.ToString() && x.IdEstado == "PE").Single();
                                objeto.IdEstado = "PR";
                                Modelo.SubmitChanges();
                            }

                        }
                        catch (Exception Ex)
                        {

                            Ex.Message.ToString();
                        }
                        #endregion
                    }
                    #endregion


                    //ActualizarEstadoMovimientoTransportista(detalle, "2014");

                    if (cabecera.codigo.ToString().Trim() != "")
                    {
                        #region Actualizar()

                        if (Modelo.SJ_RHDocPagar.Where(x => x.codigo.ToString().Trim() == cabecera.codigo.ToString().Trim()).ToList().Count == 1)
                        {
                            #region Actualizar Objeto DocPagar()
                            SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                            docPagar = Modelo.SJ_RHDocPagar.Where(x => x.codigo.ToString().Trim() == cabecera.codigo.ToString().Trim()).Single();
                            docPagar.idEmpresa = cabecera.idEmpresa;
                            docPagar.idEmisor = cabecera.idEmisor;
                            docPagar.idSucursal = cabecera.idSucursal;
                            docPagar.periodo = cabecera.periodo;
                            docPagar.fechaRegistro = cabecera.fechaRegistro;
                            docPagar.idDocumento = cabecera.idDocumento;
                            docPagar.serie = cabecera.serie;
                            docPagar.numero = cabecera.numero;
                            docPagar.fecha = cabecera.fecha;
                            docPagar.idClieProv = cabecera.idClieProv;
                            docPagar.direccion = cabecera.direccion;
                            docPagar.ruc = cabecera.ruc;
                            docPagar.razonSocial = cabecera.razonSocial;
                            docPagar.vVenta = cabecera.vVenta;
                            docPagar.impuesto = cabecera.impuesto;
                            docPagar.importe = cabecera.importe;
                            docPagar.importeMof = cabecera.importeMof;
                            docPagar.importeMex = cabecera.importeMex;
                            docPagar.idEstado = cabecera.idEstado;
                            #endregion
                            Modelo.SubmitChanges();
                            codigo = docPagar.codigo;

                            documentoPagarAsociado.codigo = codigo;
                            modeloDocumentoPagarAsociados = new SJ_RHDocPagarAsociadoNegocios();
                            modeloDocumentoPagarAsociados.Registrar(documentoPagarAsociado);

                        }

                        #region Registrar SJ_LogTablas()
                        SJ_LogTablas oSJLogTablas = new SJ_LogTablas();
                        oSJLogTablas.IDEMPRESA = SJLogTablas.IDEMPRESA;
                        oSJLogTablas.IDLOG = codigo.ToString();
                        oSJLogTablas.ITEM = Modelo.SJ_LogTableObtenerNumeroItemxTablaxCodigo(codigo.ToString(), "SJ_RHDocPagar").FirstOrDefault().serie != null ? Modelo.SJ_LogTableObtenerNumeroItemxTablaxCodigo(codigo.ToString(), "SJ_RHDocPagar").FirstOrDefault().serie : "001";
                        oSJLogTablas.TABLA = SJLogTablas.TABLA;
                        oSJLogTablas.IDCAMPO = SJLogTablas.IDCAMPO;
                        oSJLogTablas.CAMPOCLAVE = SJLogTablas.CAMPOCLAVE;
                        oSJLogTablas.IDTABLA = SJLogTablas.IDTABLA;
                        oSJLogTablas.EVENTO = "MODIFICAR";
                        oSJLogTablas.VALORANTERIOR = SJLogTablas.VALORANTERIOR;
                        oSJLogTablas.VALORACTUAL = SJLogTablas.VALORACTUAL;
                        oSJLogTablas.IDUSUARIO = SJLogTablas.IDUSUARIO;
                        oSJLogTablas.MAQUINA = SJLogTablas.MAQUINA;
                        oSJLogTablas.FECHACREACION = SJLogTablas.FECHACREACION;
                        oSJLogTablas.VENTANA = SJLogTablas.VENTANA;
                        Modelo.SJ_LogTablas.InsertOnSubmit(oSJLogTablas);
                        Modelo.SubmitChanges();
                        #endregion

                        #endregion
                    }
                    else
                    {
                        #region Nuevo()
                        #region Nuevo()
                        #region Grabar Objeto DocPagar()
                        SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                        docPagar.codigo = codigo;
                        docPagar.idEmpresa = cabecera.idEmpresa;
                        docPagar.idEmisor = cabecera.idEmisor;
                        docPagar.idSucursal = cabecera.idSucursal;
                        docPagar.periodo = cabecera.periodo;
                        docPagar.fechaRegistro = cabecera.fechaRegistro;
                        docPagar.idDocumento = cabecera.idDocumento;
                        docPagar.serie = cabecera.serie;
                        docPagar.numero = ObtenerNumeroDocumentoFacturacionTransportista();
                        docPagar.fecha = cabecera.fecha;
                        docPagar.idClieProv = cabecera.idClieProv;
                        docPagar.direccion = cabecera.direccion;
                        docPagar.ruc = cabecera.ruc;
                        docPagar.razonSocial = cabecera.razonSocial;
                        docPagar.vVenta = cabecera.vVenta;
                        docPagar.impuesto = cabecera.impuesto;
                        docPagar.importe = cabecera.importe;
                        docPagar.importeMof = cabecera.importeMof;
                        docPagar.importeMex = cabecera.importeMex;
                        docPagar.idEstado = cabecera.idEstado;
                        Modelo.SJ_RHDocPagar.InsertOnSubmit(docPagar);
                        #endregion
                        Modelo.SubmitChanges();
                        codigo = docPagar.codigo;
                        #endregion

                        foreach (SJ_RHDocPagarDetalle item in detalle)
                        {
                            #region Grabar Detalle()
                            SJ_RHDocPagarDetalle oDetalle = new SJ_RHDocPagarDetalle();
                            oDetalle.Codigo = codigo;
                            oDetalle.item = item.item;
                            oDetalle.codigoMovimiento = item.codigoMovimiento;
                            oDetalle.codServicio = item.codServicio;
                            oDetalle.descripcionServicio = item.descripcionServicio;
                            oDetalle.cantidad = item.cantidad;
                            oDetalle.unidadMedida = item.unidadMedida;
                            oDetalle.documento = item.documento;
                            oDetalle.fecha = item.fecha;
                            oDetalle.placa = item.placa;
                            oDetalle.tipoTransporte = item.tipoTransporte;

                            oDetalle.idTipoTransporte = "";
                            if (item.tipoTransporte.ToString().Trim().ToUpper() == "Por flete".ToUpper().Trim())
                            {
                                oDetalle.idTipoTransporte = "01";
                            }

                            if (item.tipoTransporte.ToString().Trim().ToUpper() == "Número Personas".ToUpper().Trim())
                            {
                                oDetalle.idTipoTransporte = "02";
                            }

                            if (item.tipoTransporte.ToString().Trim().ToUpper() == "Recorrido Interno".ToUpper().Trim())
                            {
                                oDetalle.idTipoTransporte = "03";
                            }


                            oDetalle.recorridoIda = item.recorridoIda;
                            oDetalle.recorridoRegreso = item.recorridoRegreso;
                            oDetalle.nroPersonas = item.nroPersonas;
                            oDetalle.precio = item.precio;
                            oDetalle.vventa = item.vventa;
                            oDetalle.igv = item.igv;
                            oDetalle.promedioPersona = item.promedioPersona;
                            oDetalle.importe = item.importe;
                            oDetalle.importeMof = item.importeMof;
                            oDetalle.importeMex = item.importeMex;
                            oDetalle.idDocumentoProveedor = item.idDocumentoProveedor;
                            oDetalle.serieProveedor = item.serieProveedor;
                            oDetalle.numeroProveedor = item.numeroProveedor;
                            oDetalle.fechaProveedor = item.fechaProveedor;
                            oDetalle.chofer = item.chofer;
                            oDetalle.categoriaMovilidad = item.categoriaMovilidad;
                            Modelo.SJ_RHDocPagarDetalles.InsertOnSubmit(oDetalle);
                            Modelo.SubmitChanges();
                            #endregion
                        }

                        #region Registrar Log de Movimiento de Tablas
                        SJ_LogTablas oSJLogTablas = new SJ_LogTablas();
                        oSJLogTablas.IDEMPRESA = SJLogTablas.IDEMPRESA.ToString().Trim();
                        oSJLogTablas.IDLOG = codigo.ToString().ToString().Trim();
                        oSJLogTablas.ITEM = SJLogTablas.ITEM.ToString().Trim();
                        oSJLogTablas.TABLA = SJLogTablas.TABLA.ToString().Trim();
                        oSJLogTablas.IDCAMPO = SJLogTablas.IDCAMPO.ToString().Trim();
                        oSJLogTablas.CAMPOCLAVE = SJLogTablas.CAMPOCLAVE.Trim();
                        oSJLogTablas.IDTABLA = SJLogTablas.IDTABLA.Trim();
                        oSJLogTablas.EVENTO = SJLogTablas.EVENTO.Trim();
                        oSJLogTablas.VALORANTERIOR = SJLogTablas.VALORANTERIOR;
                        oSJLogTablas.VALORACTUAL = SJLogTablas.VALORACTUAL;
                        oSJLogTablas.IDUSUARIO = SJLogTablas.IDUSUARIO.Trim();
                        oSJLogTablas.MAQUINA = SJLogTablas.MAQUINA.Trim();
                        oSJLogTablas.FECHACREACION = SJLogTablas.FECHACREACION;
                        oSJLogTablas.VENTANA = SJLogTablas.VENTANA.Trim();
                        Modelo.SJ_LogTablas.InsertOnSubmit(oSJLogTablas);
                        Modelo.SubmitChanges();
                        #endregion

                        #endregion
                    }

                    Modelo.Connection.Close();
                    Modelo.Dispose();
                }
                #endregion
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }

            return codigo;
        }

        public List<Grupo> ObtenerIdDocumentoFacturacionTransportista()
        {
            List<Grupo> Lista = new List<Grupo>();

            Doc = new Grupo();
            Doc.Codigo = "FCP";
            Doc.Descripcion = "FCP";
            Doc.Valor = "FCP";
            Lista.Add(Doc);

            return Lista;
        }

        public List<Grupo> ObtenerSerieFacturacionTransportista()
        {
            List<Grupo> Lista = new List<Grupo>();
            Doc = new Grupo();
            Doc.Codigo = "0001";
            Doc.Descripcion = "0001";
            Doc.Valor = "0001";
            Lista.Add(Doc);

            return Lista;
        }

        public string ObtenerNumeroDocumentoFacturacionTransportista()
        {
            string Numero = string.Empty;
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 89000;
                Numero = Modelo.SJ_RHPagarDocObtenerNumeroDocumento().FirstOrDefault().Numero != null ? Modelo.SJ_RHPagarDocObtenerNumeroDocumento().FirstOrDefault().Numero.ToString().Trim() : "0000001";
                Modelo.Connection.Close();
            }

            return Numero;
        }

        public List<SJ_RHDocPagarDetalleReporteResumenResult> ObtenerObjetoReporteResumenDocPagar(string periodo, string codigo)
        {
            string cnx = string.Empty;
            List<SJ_RHDocPagarDetalleReporteResumenResult> Listado = new List<SJ_RHDocPagarDetalleReporteResumenResult>();
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();

            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Listado = Modelo.SJ_RHDocPagarDetalleReporteResumen(codigo).ToList();
            }

            return Listado;
        }

        public List<SJ_RHDocPagarDetalleReporteDetalleResult> ObtenerReporteDetalleDocPagar(string periodo, string codigo)
        {
            string cnx = string.Empty;
            List<SJ_RHDocPagarDetalleReporteDetalleResult> Listado = new List<SJ_RHDocPagarDetalleReporteDetalleResult>();
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Modelo.CommandTimeout = 9880000;
                Listado = Modelo.SJ_RHDocPagarDetalleReporteDetalle(codigo).ToList();
                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return Listado;
        }


        public void AnularDocumentoDeFacturacion(SJ_RHDocPagar oDocPagar)
        {
            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    #region
                    Modelo.CommandTimeout = 9880000;
                    if (Modelo.SJ_RHDocPagar.Where(x => x.codigo.ToString().Trim() == oDocPagar.codigo.ToString().Trim()).ToList().Count == 1)
                    {
                        SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                        docPagar = Modelo.SJ_RHDocPagar.Where(x => x.codigo.ToString().Trim() == oDocPagar.codigo.ToString().Trim()).Single();
                        docPagar.idEstado = "AN";
                        Modelo.SubmitChanges();


                        var ObtenerDetallesDocumentoFacturacion = Modelo.SJ_RHDocPagarDetalles.Where(x => x.Codigo.ToString().Trim() == oDocPagar.codigo.ToString().Trim()).ToList();

                        if (ObtenerDetallesDocumentoFacturacion != null && ObtenerDetallesDocumentoFacturacion.ToList().Count() > 1)
                        {
                            foreach (var itemDetalle in ObtenerDetallesDocumentoFacturacion)
                            {
                                Modelo.SJ_RHLiberarDetalleDocumentoFacturacionTransportistas(itemDetalle.Codigo, itemDetalle.item, itemDetalle.codigoMovimiento);
                            }
                        }

                    }




                    /*limpirCodigo del movimiento en el documento detalle de la factura*/

                    /*Actualizar el estado del movimiento de reccorido de los documento */

                    Modelo.Connection.Close();
                    Modelo.Dispose();
                    #endregion
                }
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
                return;
            }
        }

        public void EliminarDocumentoDeFacturacion(SJ_RHDocPagar oDocPagar)
        {
            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

                using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
                {
                    #region
                    Modelo.CommandTimeout = 9880000;
                    if (Modelo.SJ_RHDocPagar.Where(x => x.codigo.ToString().Trim() == oDocPagar.codigo.ToString().Trim()).ToList().Count == 1)
                    {
                        var ObtenerDetallesDocumentoFacturacion = Modelo.SJ_RHDocPagarDetalles.Where(x => x.Codigo.ToString().Trim() == oDocPagar.codigo.ToString().Trim()).ToList();
                        if (ObtenerDetallesDocumentoFacturacion != null && ObtenerDetallesDocumentoFacturacion.ToList().Count() > 0)
                        {
                            foreach (var itemDetalle in ObtenerDetallesDocumentoFacturacion)
                            {
                                var resultadoByDetalle = Modelo.SJ_RHDocPagarDetalles.Where(x => x.Codigo.ToString().Trim() == itemDetalle.Codigo.ToString().Trim() && x.item.ToString().Trim() == itemDetalle.item.ToString().Trim()).ToList();
                                if (resultadoByDetalle.Count == 1)
                                {
                                    Modelo.SJ_RHLiberarDetalleDocumentoFacturacionTransportistas(itemDetalle.Codigo, itemDetalle.item, itemDetalle.codigoMovimiento.ToString().Trim());
                                }
                            }

                            foreach (var itemDetalle in ObtenerDetallesDocumentoFacturacion)
                            {
                                if (Modelo.SJ_RHDocPagarDetalles.Where(x => x.Codigo.ToString().Trim() == itemDetalle.Codigo.ToString().Trim() && x.item.ToString().Trim() == itemDetalle.item.ToString().Trim()).ToList().Count == 1)
                                {
                                    SJ_RHDocPagarDetalle docPagarDetalle = new SJ_RHDocPagarDetalle();
                                    docPagarDetalle = Modelo.SJ_RHDocPagarDetalles.Where(x => x.Codigo.ToString().Trim() == itemDetalle.Codigo.ToString().Trim() && x.item.ToString().Trim() == itemDetalle.item.ToString().Trim()).Single();
                                    Modelo.SJ_RHDocPagarDetalles.DeleteOnSubmit(docPagarDetalle);
                                    Modelo.SubmitChanges();
                                }
                            }
                        }

                        SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                        docPagar = Modelo.SJ_RHDocPagar.Where(x => x.codigo.ToString().Trim() == oDocPagar.codigo.ToString().Trim()).Single();
                        Modelo.SJ_RHDocPagar.DeleteOnSubmit(docPagar);
                        Modelo.SubmitChanges();
                    }


                    /*limpirCodigo del movimiento en el documento detalle de la factura*/

                    /*Actualizar el estado del movimiento de reccorido de los documento */

                    Modelo.Connection.Close();
                    Modelo.Dispose();
                    #endregion
                }
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        }
    }
}
