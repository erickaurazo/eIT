using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using TransportistaMto.Datos;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class FacturacionMovilidadesEdicion : Telerik.WinControls.UI.RadForm
    {
        private DocumentoNegocio documentoNeg;
        private List<Grupo> documentoPagDoc;
        private List<Grupo> documentoProveedor;
        private List<Grupo> seriesPagDoc;
        private List<SJ_RHDocPagarDetalle> ListadetalleFacturacion;
        private SJ_RHDocPagar oDocPagar;
        private string mes;
        private string nombreMes;
        private string codigoProveedor;
        private string proveedor;
        public string esGrabado = "Cancel";
        private SJ_RHDocPagarNegocio modelo;
        private List<SJ_RHDocPagarDetalle> ListadetalleFacturacionGrabar;
        private string msg;
        private string codigo;
        private string periodo;
        private List<SJ_RHDocPagarxCodigoResult> ObjetoDocPag;
        private List<SJ_RHDocPagarDetallexCodigoResult> ListaDetalleDocPag;
        private SJ_RHDocPagarNegocio negocioDocPag;
        private string documentoFac;
        private string fechaDoc;
        private string rucProveedor;
        private string proveedorDescripcion;
        private string proveedorDocumento;
        private string proveedorFechaDoc;
        private string nombreUsuario;
        private string documentoAsociado = string.Empty;
        private SJ_RHDocPagarAsociado oDocPagarAsociado;
        private SJ_RHDocPagarAsociado objetoDocumentoPagarAsociado;
        private SJ_RHDocPagarAsociadoNegocios negocioDocPagAsociados;



        public FacturacionMovilidadesEdicion()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            CargarDocumentosInicialesProveedor();
            CargarDocumentoMovimientoPagarDocumento();
        }

        public FacturacionMovilidadesEdicion(string mes, string nombreMes, string codigoProveedor, string proveedor, List<SJ_RHDocPagarDetalle> ListadetalleFacturacion)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            CargarDocumentosInicialesProveedor();
            CargarDocumentoMovimientoPagarDocumento();

            this.mes = mes;
            this.nombreMes = nombreMes;
            this.codigoProveedor = codigoProveedor;
            this.proveedor = proveedor;
            this.ListadetalleFacturacion = ListadetalleFacturacion;

            this.btnEditar.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.btnExportar.Enabled = false;
            this.btnImprimir.Enabled = false;
            this.btnVistaPrevia.Enabled = false;
            this.btnSalir.Enabled = true;

            gbProveedorReemplazo.Enabled = false;

            cboMes.Text = this.nombreMes;
            txtRUCNumero.Text = this.codigoProveedor;
            txtRucRazonSocial.Text = this.proveedor;

            if (ListadetalleFacturacion != null)
            {
                if (ListadetalleFacturacion.ToList().Count > 0)
                {
                    dgvDetalle.DataSource = this.ListadetalleFacturacion.OrderBy(x => x.item).ToList().ToDataTable<SJ_RHDocPagarDetalle>();
                    dgvDetalle.Refresh();
                    decimal? subTot = 0;
                    subTot = ListadetalleFacturacion.Sum(x => x.vventa.Value);
                    this.txtSubTotal.Text = subTot.Value.ToDecimalPresentation();
                    //this.txtIgv.Text = ListadetalleFacturacion.Sum(x => x.igv.Value).ToDecimalPresentation();
                    //this.txtTotal.Text = ListadetalleFacturacion.Sum(x => x.importe.Value).ToDecimalPresentation();
                    decimal? igvTotal = 0;
                    igvTotal = (subTot * Convert.ToDecimal(0.18));
                    this.txtIgv.Text = (igvTotal.Value.ToDecimalPresentation());
                    this.txtTotal.Text = (subTot + igvTotal).Value.ToDecimalPresentation();
                }
            }

        }

        public FacturacionMovilidadesEdicion(string codigo, string periodo)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            this.codigo = codigo;
            this.periodo = periodo;

            CargarDocumentosInicialesProveedor();
            CargarDocumentoMovimientoPagarDocumento();

            this.btnEditar.Enabled = true;
            this.btnGuardar.Enabled = false;
            this.gbCabecera.Enabled = false;
            this.gbDetalle.Enabled = false;
            this.gbTotales.Enabled = false;
            this.btnImprimir.Enabled = false;

            CargarCabecerayDetalle();
            PresentarDatos();

        }

        private void PresentarDatos()
        {
            try
            {
                #region Presentar al Objeto y Lista Detalle en el Formulario()

                #region Cabecera()
                this.txtMovimientoCodigo.Text = ObjetoDocPag.FirstOrDefault().codigo != null ? ObjetoDocPag.FirstOrDefault().codigo.ToString().Trim() : "";
                txtEmpresaCodigo.Text = ObjetoDocPag.FirstOrDefault().idEmpresa != null ? ObjetoDocPag.FirstOrDefault().idEmpresa.ToString().Trim() : "";
                txtEmpresaDescripcion.Text = ObjetoDocPag.FirstOrDefault().empresa != null ? ObjetoDocPag.FirstOrDefault().empresa.ToString().Trim() : "";
                txtSucursalCodigo.Text = ObjetoDocPag.FirstOrDefault().idSucursal != null ? ObjetoDocPag.FirstOrDefault().idSucursal.ToString().Trim() : "";
                txtSucursalDescripcion.Text = ObjetoDocPag.FirstOrDefault().sucursal != null ? ObjetoDocPag.FirstOrDefault().sucursal.ToString().Trim() : "";
                txtPeriodo.Text = ObjetoDocPag.FirstOrDefault().periodo != null ? ObjetoDocPag.FirstOrDefault().sucursal.ToString().Trim() : "";
                cboMes.Text = ObjetoDocPag.FirstOrDefault().mes != null ? ObjetoDocPag.FirstOrDefault().mes.ToString().Trim() : "";
                txtEstadoCodigo.Text = ObjetoDocPag.FirstOrDefault().idEstado != null ? ObjetoDocPag.FirstOrDefault().idEstado.ToString().Trim() : "";
                txtEstadoDescripcion.Text = ObjetoDocPag.FirstOrDefault().estado != null ? ObjetoDocPag.FirstOrDefault().estado.ToString().Trim() : "";

                cboIdDocumentoMovimiento.SelectedValue = ObjetoDocPag.FirstOrDefault().documento != null ? ObjetoDocPag.FirstOrDefault().documento.ToString().Trim().Substring(0, 3) : "";
                cboSerieMovimiento.SelectedValue = ObjetoDocPag.FirstOrDefault().documento != null ? ObjetoDocPag.FirstOrDefault().documento.ToString().Trim().Substring(6, 4) : "";
                txtNumeroDocumentoMovimiento.Text = ObjetoDocPag.FirstOrDefault().documento != null ? ObjetoDocPag.FirstOrDefault().documento.ToString().Trim().Substring(13, 7) : "";
                txtFechaMovimiento.Text = ObjetoDocPag.FirstOrDefault().fecha != null ? ObjetoDocPag.FirstOrDefault().fecha.ToString() : "";
                txtRUCNumero.Text = ObjetoDocPag.FirstOrDefault().ruc != null ? ObjetoDocPag.FirstOrDefault().ruc.ToString().Trim() : "";
                txtRucRazonSocial.Text = ObjetoDocPag.FirstOrDefault().razonSocial != null ? ObjetoDocPag.FirstOrDefault().razonSocial.ToString().Trim() : "";

                txtSubTotal.Text = ObjetoDocPag.FirstOrDefault().vVenta != null ? ObjetoDocPag.FirstOrDefault().vVenta.Value.ToDecimalPresentation().Trim() : "";
                txtIgv.Text = ObjetoDocPag.FirstOrDefault().impuesto != null ? ObjetoDocPag.FirstOrDefault().impuesto.ToString().Trim() : "";
                txtTotal.Text = ObjetoDocPag.FirstOrDefault().importe != null ? ObjetoDocPag.FirstOrDefault().importe.ToString().Trim() : "";

                #region Documentos asociados()
                cboIdDocumentoProveedorReemplazo.SelectedValue = objetoDocumentoPagarAsociado.idDocumento != null ? objetoDocumentoPagarAsociado.idDocumento.ToString().Trim() : "";
                txtNumeroSerieProveedorReemplazo.Text = objetoDocumentoPagarAsociado.serie != null ? objetoDocumentoPagarAsociado.serie.ToString().Trim() : "";
                txtNumeroDocumentoProveedorReemplazo.Text = objetoDocumentoPagarAsociado.numero != null ? objetoDocumentoPagarAsociado.numero.ToString().Trim() : "";
                txtFechaDocumentoProveedorReemplazo.Text = objetoDocumentoPagarAsociado.fecha != null ? objetoDocumentoPagarAsociado.fecha.ToPresentationDate() : "";

                #endregion

                #endregion


                #endregion

                #region Detalle()
                dgvDetalle.DataSource = ListaDetalleDocPag.ToDataTable<SJ_RHDocPagarDetallexCodigoResult>();
                dgvDetalle.Refresh();

                cboIdDocumentoProveedor.SelectedValue = ListaDetalleDocPag.FirstOrDefault().idDocumentoProveedor != null ? ListaDetalleDocPag.FirstOrDefault().idDocumentoProveedor.ToString().Trim() : "";
                txtNumeroSerieProveedor.Text = ListaDetalleDocPag.FirstOrDefault().serieProveedor != null ? ListaDetalleDocPag.FirstOrDefault().serieProveedor.ToString().Trim() : "";
                txtNumeroDocumentoProveedor.Text = ListaDetalleDocPag.FirstOrDefault().numeroProveedor != null ? ListaDetalleDocPag.FirstOrDefault().numeroProveedor.ToString().Trim() : "";
                txtFechaDocumentoProveedor.Text = ListaDetalleDocPag.FirstOrDefault().fechaProveedor != null ? ListaDetalleDocPag.FirstOrDefault().fechaProveedor.ToString().Trim() : "";


                #endregion
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
                return;
            }
        }

        private void CargarCabecerayDetalle()
        {
            try
            {
                #region Cargar Objeto y Lista Detalle()
                negocioDocPag = new SJ_RHDocPagarNegocio();
                ObjetoDocPag = new List<SJ_RHDocPagarxCodigoResult>();
                ObjetoDocPag = negocioDocPag.ObtenerObjetoDocPagar(this.periodo, this.codigo);

                negocioDocPag = new SJ_RHDocPagarNegocio();
                ListaDetalleDocPag = new List<SJ_RHDocPagarDetallexCodigoResult>();
                ListaDetalleDocPag = negocioDocPag.ObtenerDetalleDocPagar(this.periodo, this.codigo);

                if (ObjetoDocPag != null && ObjetoDocPag.ToList().Count == 1)
                {
                    /*Instancio un nuevo objeto de tipo SJ_RHDocPagar y le asigno el codigo generado en el documentoPagar y luego procedo a obtener documento Asociado */
                    SJ_RHDocPagar objetoDocumentoPagar = new SJ_RHDocPagar();
                    objetoDocumentoPagar.codigo = ObjetoDocPag.FirstOrDefault().codigo != null ? ObjetoDocPag.FirstOrDefault().codigo.ToString().Trim() : "";
                    negocioDocPagAsociados = new SJ_RHDocPagarAsociadoNegocios();
                    objetoDocumentoPagarAsociado = new SJ_RHDocPagarAsociado();
                    objetoDocumentoPagarAsociado = negocioDocPagAsociados.ObtenerObjeto(objetoDocumentoPagar);
                }





                #endregion
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        }

        private void FacturacionMovilidades_Load(object sender, EventArgs e)
        {

        }

        private void CargarDocumentoMovimientoPagarDocumento()
        {
            try
            {
                // lista de documento
                documentoNeg = new DocumentoNegocio();
                documentoPagDoc = new List<Grupo>();
                documentoPagDoc = documentoNeg.ObtenerIdDocumentoFacturacionTransportista().ToList();

                // lista de serie
                documentoNeg = new DocumentoNegocio();
                seriesPagDoc = new List<Grupo>();
                seriesPagDoc = documentoNeg.ObtenerSerieFacturacionTransportista().ToList();


                if (documentoPagDoc != null)
                {
                    if (documentoPagDoc.ToList().Count > 0)
                    {
                        cboIdDocumentoMovimiento.DisplayMember = "Descripcion";
                        cboIdDocumentoMovimiento.ValueMember = "Codigo";
                        cboIdDocumentoMovimiento.DataSource = documentoPagDoc.ToList();
                    }
                }

                if (seriesPagDoc != null)
                {
                    if (seriesPagDoc.ToList().Count > 0)
                    {
                        cboSerieMovimiento.DisplayMember = "Descripcion";
                        cboSerieMovimiento.ValueMember = "Codigo";
                        cboSerieMovimiento.DataSource = seriesPagDoc.ToList();
                    }
                }

                string numeroDocumento = string.Empty;
                documentoNeg = new DocumentoNegocio();
                numeroDocumento = documentoNeg.ObtenerNumeroDocumentoFacturacionTransportista();
                this.txtNumeroDocumentoMovimiento.Text = numeroDocumento;

                this.txtFechaMovimiento.Text = DateTime.Now.ToPresentationDate();
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }

        }

        private void CargarDocumentosInicialesProveedor()
        {
            try
            {

                documentoNeg = new DocumentoNegocio();
                documentoProveedor = new List<Grupo>();
                documentoProveedor = documentoNeg.ObtenerIdDocumentoProveedor().ToList();

                if (documentoProveedor != null)
                {
                    if (documentoProveedor.ToList().Count > 0)
                    {
                        cboIdDocumentoProveedor.DisplayMember = "Descripcion";
                        cboIdDocumentoProveedor.ValueMember = "Codigo";
                        cboIdDocumentoProveedor.DataSource = documentoProveedor.ToList();

                        cboIdDocumentoProveedorReemplazo.DisplayMember = "Descripcion";
                        cboIdDocumentoProveedorReemplazo.ValueMember = "Codigo";
                        cboIdDocumentoProveedorReemplazo.DataSource = documentoProveedor.ToList();

                    }
                }

                this.txtFechaDocumentoProveedor.Text = DateTime.Now.ToPresentationDate();

            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }

        }

        private void txtNumeroSerieProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean nonNumberEntered;



            nonNumberEntered = true;



            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {

                nonNumberEntered = false;

            }



            if (nonNumberEntered == true)
            {

                // Stop the character from being entered into the control since it is non-numerical.

                e.Handled = true;

            }

            else
            {

                e.Handled = false;

            }
        }

        private void txtNumeroDocumentoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean nonNumberEntered;



            nonNumberEntered = true;



            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {

                nonNumberEntered = false;

            }



            if (nonNumberEntered == true)
            {

                // Stop the character from being entered into the control since it is non-numerical.

                e.Handled = true;

            }

            else
            {

                e.Handled = false;

            }
        }

        private void txtNumeroSerieProveedor_Leave(object sender, EventArgs e)
        {
            this.txtNumeroSerieProveedor.Text = this.txtNumeroSerieProveedor.Text.Trim();

            if (this.txtNumeroSerieProveedor.Text.Trim().Length < 4)
            {
                this.txtNumeroSerieProveedor.Text = this.txtNumeroSerieProveedor.Text.PadLeft(4, '0');
            }
        }

        private void txtNumeroDocumentoProveedor_Leave(object sender, EventArgs e)
        {
            this.txtNumeroDocumentoProveedor.Text = this.txtNumeroDocumentoProveedor.Text.Trim();

            if (this.txtNumeroDocumentoProveedor.Text.Trim().Length < 7)
            {
                this.txtNumeroDocumentoProveedor.Text = this.txtNumeroDocumentoProveedor.Text.PadLeft(7, '0');
            }
        }

        private void gbProveedor_Click(object sender, EventArgs e)
        {

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (ValidarGrabado() == true)
            {
                RegistrarFacturaDelDocumento();

                this.btnEditar.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnExportar.Enabled = true;
                this.btnVistaPrevia.Enabled = true;
                this.btnSalir.Enabled = true;
                this.btnImprimir.Enabled = true;

                gbCabecera.Enabled = true;
                gbDetalle.Enabled = false;
                gbMovimientoFacturacion.Enabled = false;
            }
            else
            {
                MessageBox.Show(msg,"MENSAJE DEL SISTEMA");
            }


        }

        private bool ValidarGrabado()
        {
            bool estado = true;

            if (this.txtNumeroSerieProveedor.Text.ToString().Trim() == "")
            {
                estado = false;
                msg += "Ingrese la serie del documento del proveedor \n";
            }

            if (this.txtNumeroDocumentoProveedor.Text.ToString().Trim() == "")
            {
                estado = false;
                msg += "Ingrese numero documento del proveedor \n";
            }

            return estado;
        }

        private void RegistrarFacturaDelDocumento()
        {
            #region Pasos() que se siguen para el registro del documento de facturación()
            /*
             1.- Actualizar el estado de los movimientos de registro de movimiento
             2.- Registrar la cabecera y el detalle del movimiento
             2.1.- Registrar tb en caso lo requiera los documento asociados. 18/12/2015 Erick Aurazo
             3.- Generar Resumen y Detalle por Documento de Facturación
             */
            #endregion
            try
            {
                ObtenerObjetoDocPagar();
                ObtenerObjetoDocPagarDetalle();
                ObtenerObjetoDocPagarAsociado();

                #region Log de tablas()
                SJ_LogTablas log = new SJ_LogTablas();
                log.IDEMPRESA = this.txtEmpresaCodigo.Text.ToString().Trim();
                log.IDLOG = this.txtMovimientoCodigo.Text.ToString();
                log.ITEM = "001";
                log.TABLA = "SJ_RHDocPagar";
                log.IDCAMPO = "codigo";
                log.CAMPOCLAVE = "codigo";
                log.IDTABLA = "SJ_RHDocPagar";
                log.EVENTO = "NUEVO";
                log.VALORANTERIOR = oDocPagar.idDocumento + " - " + oDocPagar.serie + " - " + oDocPagar.numero;
                log.VALORACTUAL = "Fec. Doc : " + oDocPagar.fecha.ToPresentationDate();
                log.IDUSUARIO = Environment.UserName;
                log.MAQUINA = Environment.MachineName;
                log.FECHACREACION = DateTime.Now;
                log.VENTANA = "Mantenimiento de Facturación por Servicio de Movilidad al personal";
                #endregion

                modelo = new SJ_RHDocPagarNegocio();
                //pagardocNeg.ActualizarEstadoMovimientoTransportista(this.ListadetalleFacturacion, "2014");
                this.txtMovimientoCodigo.Text = modelo.RegistrarFacturacionTransportista(oDocPagar, ListadetalleFacturacionGrabar, this.txtPeriodo.Value.ToString(), log, oDocPagarAsociado);
                btnBuscarPension.DialogResult = DialogResult.OK;
                esGrabado = "OK";

                MessageBox.Show("Generado correctamente", "Mensaje de Sistema");

                // limpiar listas y objeto docpagar()
                ListadetalleFacturacionGrabar = new List<SJ_RHDocPagarDetalle>();
                oDocPagar = new SJ_RHDocPagar();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "Registrar facturacion", "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void ObtenerObjetoDocPagarAsociado()
        {
            try
            {
                if (txtNumeroSerieProveedorReemplazo.Text.ToString().Trim() != "" && txtNumeroDocumentoProveedorReemplazo.Text.ToString().Trim() != "")
                {
                    #region Obtener Objeto DocPagar()
                    oDocPagarAsociado = new SJ_RHDocPagarAsociado();
                    oDocPagarAsociado.codigo = this.txtMovimientoCodigo.Text.ToString().Trim();
                    oDocPagarAsociado.idDocumento = this.cboIdDocumentoProveedorReemplazo.SelectedValue.ToString().Trim();
                    oDocPagarAsociado.serie = txtNumeroSerieProveedorReemplazo.Text.ToString().Trim();
                    oDocPagarAsociado.numero = txtNumeroDocumentoProveedorReemplazo.Text.ToString().Trim();
                    oDocPagarAsociado.fecha = Convert.ToDateTime(txtFechaDocumentoProveedorReemplazo.Text);

                    #endregion
                }

            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }

        private void ObtenerObjetoDocPagarDetalle()
        {
            ListadetalleFacturacionGrabar = new List<SJ_RHDocPagarDetalle>();
            if (this.ListadetalleFacturacion != null)
            {
                if (this.ListadetalleFacturacion.ToList().Count > 0)
                {
                    foreach (var item in this.ListadetalleFacturacion)
                    {
                        try
                        {
                            #region Obtener Objeto Detalle Grabar()
                            SJ_RHDocPagarDetalle oDetalle = new SJ_RHDocPagarDetalle();
                            oDetalle.Codigo = this.txtMovimientoCodigo.Text.ToString().Trim();
                            oDetalle.item = item.item;
                            oDetalle.codigoMovimiento = item.codigoMovimiento;
                            oDetalle.codServicio = item.codServicio;
                            oDetalle.descripcionServicio = item.descripcionServicio;
                            oDetalle.cantidad = item.cantidad;
                            oDetalle.unidadMedida = item.unidadMedida;
                            oDetalle.documento = item.documento;
                            oDetalle.fecha = item.fecha;
                            oDetalle.placa = item.placa;
                            oDetalle.categoriaMovilidad = item.categoriaMovilidad;
                            oDetalle.idTipoTransporte = item.idTipoTransporte;
                            oDetalle.tipoTransporte = item.tipoTransporte;
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
                            oDetalle.idDocumentoProveedor = cboIdDocumentoProveedor.SelectedValue.ToString().Trim();
                            oDetalle.serieProveedor = txtNumeroSerieProveedor.Text.ToString().Trim();
                            oDetalle.numeroProveedor = txtNumeroDocumentoProveedor.Text.ToString().Trim();
                            oDetalle.fechaProveedor = Convert.ToDateTime(txtFechaDocumentoProveedor.Text.ToString().Trim());
                            oDetalle.chofer = item.chofer;
                            ListadetalleFacturacionGrabar.Add(oDetalle);
                            #endregion
                        }
                        catch (Exception Ex)
                        {

                            Ex.Message.ToString();
                        }

                    }
                }
            }
        }

        private void ObtenerObjetoDocPagar()
        {
            try
            {
                #region Obtener Objeto DocPagar()
                oDocPagar = new SJ_RHDocPagar();
                oDocPagar.codigo = this.txtMovimientoCodigo.Text.ToString().Trim();
                oDocPagar.idEmpresa = "001";
                oDocPagar.idEmisor = "001";
                oDocPagar.idSucursal = "002";
                oDocPagar.periodo = this.txtPeriodo.Value.ToString() + this.mes;
                oDocPagar.fechaRegistro = DateTime.Now;
                oDocPagar.idDocumento = this.cboIdDocumentoMovimiento.SelectedValue.ToString().Trim();
                oDocPagar.serie = cboSerieMovimiento.SelectedValue.ToString().Trim();
                oDocPagar.numero = txtNumeroDocumentoMovimiento.Text.ToString().Trim();
                oDocPagar.fecha = Convert.ToDateTime(txtFechaMovimiento.Text);
                oDocPagar.idClieProv = txtRUCNumero.Text.ToString().Trim();
                oDocPagar.direccion = "";
                oDocPagar.ruc = txtRUCNumero.Text.ToString().Trim();
                oDocPagar.razonSocial = txtRucRazonSocial.Text.ToString().Trim();
                oDocPagar.vVenta = Convert.ToDecimal(txtSubTotal.Text);
                oDocPagar.impuesto = Convert.ToDecimal(txtIgv.Text);
                oDocPagar.importe = Convert.ToDecimal(txtTotal.Text);
                oDocPagar.importeMof = Convert.ToDecimal(txtTotal.Text);
                oDocPagar.importeMex = Convert.ToDecimal(0);
                oDocPagar.idEstado = "PE";
                #endregion
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }

        private void btnBuscarPension_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            if (esGrabado == "OK")
            {
                btnBuscarPension.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                esGrabado = "Cancel";
                btnBuscarPension.DialogResult = DialogResult.Cancel;
                this.Close();
            }




            //this.Dispose();
        }

        private void FacturacionMovilidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnBuscarPension.DialogResult == DialogResult.OK)
            {
                this.Dispose();
                this.Close();
            }
            else
            {
                btnBuscarPension.DialogResult = DialogResult.Cancel;
                this.Dispose();
                this.Close();
            }
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            SumarElementosSeleccionadosGrilla(sender);
        }

        public void SumarElementosSeleccionadosGrilla(object senderGrilla)
        {
            try
            {
                if (((RadGridView)senderGrilla).CurrentRow != null && ((RadGridView)senderGrilla).CurrentCell != null)
                {
                    int fila = ((RadGridView)senderGrilla).CurrentRow.Index;
                    int columna = ((RadGridView)senderGrilla).CurrentCell.ColumnIndex;

                    decimal SumaSeleccionada = 0;
                    decimal promedioSeleccionado = 0;
                    int recuento = 0;

                    //foreach (DataGridViewCell celda in ((DataGridView)senderGrilla).SelectedCells)
                    foreach (GridViewCellInfo celda in ((RadGridView)senderGrilla).SelectedCells)
                    {
                        if (celda.Value != null)
                        {
                            string tipoDato = celda.Value.GetType().Name.ToString();
                            if (tipoDato != null && tipoDato != string.Empty)
                            {
                                #region
                                if (tipoDato == "Double" || tipoDato == "Decimal")
                                {
                                    SumaSeleccionada += Convert.ToDecimal(celda.Value != null ? celda.Value : 0);
                                    recuento++;
                                    promedioSeleccionado = (SumaSeleccionada / recuento);
                                }
                                else
                                {
                                    SumaSeleccionada = 0;
                                    recuento = 0;
                                    promedioSeleccionado = 0;
                                    break;
                                }
                                #endregion
                            }
                            else
                            {
                                #region
                                SumaSeleccionada = 0;
                                recuento = 0;
                                promedioSeleccionado = 0;
                                break;
                                #endregion
                            }
                            this.lblSumaSeleccionada.Text = SumaSeleccionada.ToDecimalPresentation();
                            this.lblRecuento.Text = recuento.ToString();
                            this.lblPromedio.Text = promedioSeleccionado.ToDecimalPresentation();
                        }


                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
            this.btnEditar.Enabled = false;
            gbCabecera.Enabled = true;
            gbDetalle.Enabled = true;
            this.gbTotales.Enabled = true;
            gbProveedorReemplazo.Enabled = true;
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            if (this.dgvDetalle != null)
            {
                if (dgvDetalle.Rows.Count > 0)
                {
                    #region
                    menuPrincipal.Enabled = false;
                    bgwHilo.RunWorkerAsync();
                    #endregion
                }
            }
        }

        private void gbMovimientoFacturacion_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            ObtenerDatosParaReporte();
        }

        private void ObtenerDatosParaReporte()
        {
            try
            {
                //string rucProveedor, proveedorDescripcion, proveedorDocumento, proveedorFechaDoc, documentoFac, fechaDoc, codigo = string.Empty;

                documentoFac = this.cboIdDocumentoMovimiento.SelectedValue.ToString().Trim() + " - " + this.cboSerieMovimiento.SelectedValue.ToString().Trim() + " - " + txtNumeroDocumentoMovimiento.Text.ToString().Trim();
                fechaDoc = txtFechaMovimiento.Text.ToString().Trim();
                rucProveedor = this.txtRUCNumero.Text.ToString().Trim();
                proveedorDescripcion = txtRucRazonSocial.Text.ToString().Trim();
                proveedorDocumento = this.cboIdDocumentoProveedor.SelectedValue.ToString().Trim() + " - " + this.txtNumeroSerieProveedor.Text.ToString().Trim() + " - " + txtNumeroDocumentoProveedor.Text.ToString().Trim();
                proveedorFechaDoc = this.txtFechaDocumentoProveedor.Text.ToString().Trim();
                codigo = txtMovimientoCodigo.Text.ToString().Trim();
                nombreUsuario = Environment.UserName.ToString().Trim();
                documentoAsociado = (this.txtNumeroSerieProveedorReemplazo.Text.ToString().Trim() != "" || this.txtNumeroDocumentoProveedorReemplazo.Text.ToString().Trim() != "" )? (cboIdDocumentoProveedorReemplazo.SelectedValue.ToString() + " - " + this.txtNumeroSerieProveedorReemplazo.Text.ToString().Trim() + " - " + this.txtNumeroDocumentoProveedorReemplazo.Text.ToString().Trim()) : "";
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarReportes();
        }

        private void PresentarReportes()
        {
            try
            {
                if (codigo != null && codigo != "")
                {

                    //FacturacionMovilidadesImprimirResumen ofrm = new FacturacionMovilidadesImprimirResumen(codigo);
                    //ofrm.AgregarParametroCadena("@Documento", documentoFac.ToString().Trim());
                    //ofrm.AgregarParametroCadena("@FechaDoc", fechaDoc.ToString().Trim());
                    //ofrm.AgregarParametroCadena("@RucProveedor", rucProveedor.ToString().Trim());
                    //ofrm.AgregarParametroCadena("@ProveedorDescripcion", proveedorDescripcion.ToString().Trim());
                    //ofrm.AgregarParametroCadena("@ProveedorDocumento", proveedorDocumento.ToString().Trim());
                    //ofrm.AgregarParametroCadena("@ProveedorFechaDoc", proveedorFechaDoc.ToString().Trim());
                    //ofrm.AgregarParametroCadena("@codigo", codigo.ToString().Trim());
                    //ofrm.AgregarParametroCadena("@nombreUsuario", nombreUsuario.ToString().Trim());

                    //ofrm.ShowDialog();

                    FacturacionMovilidadesImprimirDetalle oFrmDetalle = new FacturacionMovilidadesImprimirDetalle(codigo);
                    oFrmDetalle.MdiParent = FacturacionMovilidadesEdicion.ActiveForm;
                    oFrmDetalle.AgregarParametroCadena("@Documento", documentoFac.ToString().Trim());
                    oFrmDetalle.AgregarParametroCadena("@FechaDoc", fechaDoc.ToString().Trim());
                    oFrmDetalle.AgregarParametroCadena("@RucProveedor", rucProveedor.ToString().Trim());
                    oFrmDetalle.AgregarParametroCadena("@ProveedorDescripcion", proveedorDescripcion.ToString().Trim());
                    oFrmDetalle.AgregarParametroCadena("@ProveedorDocumento", proveedorDocumento.ToString().Trim());
                    oFrmDetalle.AgregarParametroCadena("@ProveedorFechaDoc", proveedorFechaDoc.ToString().Trim());
                    oFrmDetalle.AgregarParametroCadena("@codigo", codigo.ToString().Trim());
                    oFrmDetalle.AgregarParametroCadena("@nombreUsuario", nombreUsuario.ToString().Trim());
                    oFrmDetalle.AgregarParametroCadena("@DocumentoAsociado", documentoAsociado.ToString().Trim());
                    //oFrmDetalle.ShowDialog();
                    oFrmDetalle.Show();

                    menuPrincipal.Enabled = true;

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString() + "\n.Presentar Reportes", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtMovimientoCodigo.Text.ToString().Trim() != "")
                {
                    Historial ofrm = new Historial(this.txtMovimientoCodigo.Text.ToString().Trim(), "0", "SJ_RHDocPagar");
                    ofrm.Text = "Historial del documento de Facturación";
                    ofrm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El documento actual no contiene historial", "MENSAJE DEL SISTEMA");
                }

            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            /* En el anular se libera los movimientos asociados a la facturacion, solo se anulará el documento de facturacion */
            if (this.txtMovimientoCodigo.Text.ToString().Trim() != "")
            {
                /*Obtengo el Documento*/
                ObtenerObjetoDocPagar();
                modelo.AnularDocumentoDeFacturacion(oDocPagar);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            /* En el Eliminar se libera los movimientos asociados a la facturacion y también el documento de facturacion y tambien el log de tablas en caso tenga movimiento */
            if (this.txtMovimientoCodigo.Text.ToString().Trim() != "")
            {
                ObtenerObjetoDocPagar();
                modelo.EliminarDocumentoDeFacturacion(oDocPagar);
            }
        }

        private void txtNumeroSerieProveedorReemplazo_Leave(object sender, EventArgs e)
        {
            this.txtNumeroSerieProveedorReemplazo.Text = this.txtNumeroSerieProveedorReemplazo.Text.Trim();

            if (this.txtNumeroSerieProveedorReemplazo.Text.Trim().Length < 4)
            {
                this.txtNumeroSerieProveedorReemplazo.Text = this.txtNumeroSerieProveedorReemplazo.Text.PadLeft(4, '0');
            }
        }

        private void txtNumeroDocumentoProveedorReemplazo_Leave(object sender, EventArgs e)
        {
            this.txtNumeroDocumentoProveedorReemplazo.Text = this.txtNumeroDocumentoProveedorReemplazo.Text.Trim();

            if (this.txtNumeroDocumentoProveedorReemplazo.Text.Trim().Length < 7)
            {
                this.txtNumeroDocumentoProveedorReemplazo.Text = this.txtNumeroDocumentoProveedorReemplazo.Text.PadLeft(7, '0');
            }
        }

        private void btnEliminarDocumentoAsociado_Click(object sender, EventArgs e)
        {
            if (this.txtMovimientoCodigo.Text.ToString().Trim() != "" && this.txtNumeroSerieProveedorReemplazo.Text.ToString().Trim() != "" && this.txtNumeroDocumentoProveedorReemplazo.Text.ToString().Trim() != "")
            {
                negocioDocPagAsociados = new SJ_RHDocPagarAsociadoNegocios();
                SJ_RHDocPagarAsociado objeto = new SJ_RHDocPagarAsociado();
                objeto.codigo = this.txtMovimientoCodigo.Text.ToString().Trim();
                negocioDocPagAsociados.Eliminar(objeto);

                this.txtNumeroSerieProveedorReemplazo.Clear();
                this.txtNumeroDocumentoProveedorReemplazo.Clear();
                this.txtFechaDocumentoProveedorReemplazo.Clear();

                MessageBox.Show("El documento se ha desasociado al documento actual", "MENSAJE DEL SISTEMA");
            }
            else
            {
                MessageBox.Show("El documento no tiene un documento asociado", "MENSAJE DEL SISTEMA");
                return;
            }
        }


    }
}
