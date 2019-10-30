using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Configuration;
using Transportista.Negocios;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;

using Telerik.WinControls.UI;
//using System.Collections;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Data.OleDb;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class MovimientoRecorridosMantenimiento : Telerik.WinControls.UI.RadForm
    {
        #region Variables()
        private string Periodo;
        private DocumentoNegocio documentoNeg;
        private List<Grupo> ListaSerie;
        private List<Grupo> ListaIdDocumento;
        private SJ_RHMovimientoMovilidad MovimientoMovilidad;
        private MovimientoMovilidadNegocio movimientoRecorridosNegocio;
        private SJ_RHObtenerDocumentoRecorridoMovilidadResult Documento;
        private List<SJ_RHObtenerDocumentoRecorridoMovilidadDetalleResult> DocumentoDetalle;
        private List<SJ_RHMovimientoMovilidadDetalle> ListaDetalleEliminados = new List<SJ_RHMovimientoMovilidadDetalle>();
        private List<SJ_RHMovimientoMovilidadDetalle> ListaDetalleRecorridoInterno = new List<SJ_RHMovimientoMovilidadDetalle>();
        private List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult> oLitadoMarcacionesSelecionadasIngreso;
        private List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult> oLitadoMarcacionesSelecionadasSalida;
        private List<FormatoImportacionMovimientoRecorridoInterLocalidades> listaFormartoImportacionIngreso;
        private List<FormatoImportacionMovimientoRecorridoInterLocalidades> listaFormartoImportacionSalida;
        private List<SJ_RHMovimientoMovilidadAsistenciaTrabajador> listadoPersonalIngresoByBus;
        private List<SJ_RHMovimientoMovilidadAsistenciaTrabajador> listadoPersonalSaludaByBus;
        private List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ListaPasajerosByParadero;
        private List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ListaDetalleAsistencia, ListaDetalleMovimientoAsistencia;
        private DestinoMovilidad destinoMovilidadNegocios;
        private List<SJ_RHDestinoMovilidad> ListaDestinos;
        private List<SJ_RHDestinoMovilidad> ListaDestinoMovilidad;
        private RadTextBox control;
        private List<DFormatoSimple> ListaCampos;
        private string CodigoDocumento;
        private string TabSelecionado;
        private string msg;
        private string criterio;
        private string NumeroDocumento;
        private string movimiento;
        private string periodo;
        private string campoDestino;
        private decimal precioVueltaAcumulado = 0;
        private decimal? PromedioPersonal;
        private string mensajeControlProcedencia;
        private string rutaArchivoListaTrabajadores;
        private string hoja;
        private int numeroClickDistribuir = 0;
        private string CodDocumento;
        private string fecha;
        private string IdDocumento;




        #endregion

        public MovimientoRecorridosMantenimiento()
        {
            MovimientoMovilidad = new SJ_RHMovimientoMovilidad();
            MovimientoMovilidad.Codigo = string.Empty;
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            Inicio();
            CargarDatosIniciales();
            PresentarCboDestino();

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnAnular.Enabled = false;
            btnAtras.Enabled = false;
            btnExportar.Enabled = false;
            btnHistorial.Enabled = false;
            btnImportar.Enabled = true;
            btnSalir.Enabled = true;
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        private void CargarDatosIniciales()
        {
            try
            {
                this.txtFechaMovimientoRecorridoInterLocalidad.Text = DateTime.Now.ToShortDateString();
                this.txtFechaMovimientoInterno.Text = DateTime.Now.ToShortDateString();
                txtPeriodo.Text = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0');
                txtPeriodoNombre.Text = MonthName(DateTime.Now.Month);
                if (criterio != null)
                {

                    /* PARA RECORRIDOS DENTROS DEL FUNDO OSEA RECORRIDOS INTERNOS */
                    if (criterio.ToString().Trim() == "MTL")
                    {
                        movimientoRecorridosNegocio = new MovimientoMovilidadNegocio();
                        NumeroDocumento = movimientoRecorridosNegocio.ObtenerNumeroDocumento(criterio, this.txtFechaMovimientoInterno.Text);
                        //this.txtCodigoInterno.Text = NumeroDocumento;
                    }

                    /* PARA RECORRIDOS ENTRE LOCALIDADES EJM TUMAN - CHONGOYAPE Y VICIVERSA */
                    if (criterio.ToString().Trim() == "MTI")
                    {
                        movimientoRecorridosNegocio = new MovimientoMovilidadNegocio();
                        NumeroDocumento = movimientoRecorridosNegocio.ObtenerNumeroDocumento(criterio, this.txtFechaMovimientoRecorridoInterLocalidad.Text);
                        //txtNumeroDocumentoExterno.Text = NumeroDocumento;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString().Trim() + "\nCargas datos para la configuración inicial del documento", "ADVERTENCIA DEL SISTEMA");
                return;
            }


        }

        public MovimientoRecorridosMantenimiento(string TabSelecionado)
        {
            InitializeComponent();


            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            this.TabSelecionado = TabSelecionado;
            //ProgressBar.Visible = true;
            switch (TabSelecionado)
            {
                case "InterLocalidad":
                    tabRegistros.SelectedPage = tabRecorridoInterLocalidad;
                    this.tabRegistros.Pages.Remove(tabRecorridoInterno);
                    criterio = "MTI";
                    Inicio();
                    CargarDatosIniciales();
                    PresentarCboIdDocumento("INTERLOCALIDAD");
                    PresentarCboSerie("INTERLOCALIDAD");
                    PresentarCboDestino();

                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnAtras.Enabled = true;
                    btnExportar.Enabled = false;
                    btnHistorial.Enabled = true;
                    btnImportar.Enabled = true;
                    btnSalir.Enabled = true;
                    //gbDestinoMovimiento.Enabled = true;
                    gbDocumentoRegistro.Enabled = true;
                    gbMovimientoInterlocalidad.Enabled = true;
                    gbMovimientoInterno.Enabled = true;
                    gbProcedenciaMovimientoInterno.Enabled = true;
                    gbProcedenciaExterno.Enabled = true;
                    gbRegistroMovimientoExterno.Enabled = false;
                    gbRegistroRecorridoInterno.Enabled = false;
                    gbTransportistaInformacion.Enabled = true;
                    ProgressBar.Visible = false;
                    tabRegistros.Enabled = true;
                    gbRegistroDocumento.Enabled = true;
                    gbRegistroPersonasExterno.Enabled = true;


                    break;

                case "Interno":

                    tabRegistros.SelectedPage = tabRecorridoInterno;
                    this.tabRegistros.Pages.Remove(tabRecorridoInterLocalidad);
                    criterio = "MTL";
                    Inicio();
                    CargarDatosIniciales();
                    PresentarCboIdDocumento("INTERNO");
                    PresentarCboSerie("INTERNO");
                    PresentarCboDestino();
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnAtras.Enabled = true;
                    btnExportar.Enabled = false;
                    btnHistorial.Enabled = true;
                    btnImportar.Enabled = true;
                    btnSalir.Enabled = true;
                    //gbDestinoMovimiento.Enabled = true;
                    gbMovimientoInterlocalidad.Enabled = true;
                    gbDocumentoRegistro.Enabled = true;
                    gbMovimientoInterno.Enabled = true;
                    gbProcedenciaMovimientoInterno.Enabled = true;
                    gbProcedenciaExterno.Enabled = true;
                    gbRegistroMovimientoExterno.Enabled = false;
                    gbRegistroRecorridoInterno.Enabled = false;
                    gbTransportistaInformacion.Enabled = true;
                    ProgressBar.Visible = false;
                    tabRegistros.Enabled = true;
                    gbRegistroDocumento.Enabled = true;
                    gbRegistroPersonasExterno.Enabled = true;
                    break;

                case "":
                    Inicio();
                    criterio = "";
                    CargarDatosIniciales();
                    PresentarCboDestino();
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnAnular.Enabled = false;
                    btnAtras.Enabled = false;
                    btnExportar.Enabled = false;
                    btnHistorial.Enabled = true;
                    btnImportar.Enabled = false;
                    btnSalir.Enabled = true;

                    //gbDestinoMovimiento.Enabled = false;
                    gbMovimientoInterlocalidad.Enabled = false;
                    gbMovimientoInterno.Enabled = false;
                    gbProcedenciaMovimientoInterno.Enabled = false;
                    gbProcedenciaExterno.Enabled = false;
                    gbRegistroMovimientoExterno.Enabled = false;
                    gbRegistroRecorridoInterno.Enabled = false;
                    gbTransportistaInformacion.Enabled = false;
                    ProgressBar.Visible = false;
                    gbRegistroPersonasExterno.Enabled = false;
                    tabRegistros.Enabled = false;
                    gbDocumentoRegistro.Enabled = false;
                    break;


                default:
                    Inicio();
                    CargarDatosIniciales();
                    EjecutarConsultar();
                    PresentarCboDestino();
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnAnular.Enabled = false;
                    btnAtras.Enabled = false;
                    btnExportar.Enabled = false;
                    btnHistorial.Enabled = true;
                    btnImportar.Enabled = false;
                    btnSalir.Enabled = true;

                    //gbDestinoMovimiento.Enabled = false;
                    gbMovimientoInterlocalidad.Enabled = false;
                    gbMovimientoInterno.Enabled = false;
                    gbProcedenciaMovimientoInterno.Enabled = false;
                    gbProcedenciaExterno.Enabled = false;
                    gbRegistroMovimientoExterno.Enabled = false;
                    gbRegistroRecorridoInterno.Enabled = false;
                    gbTransportistaInformacion.Enabled = false;
                    ProgressBar.Visible = false;
                    gbDocumentoRegistro.Enabled = false;
                    gbRegistroPersonasExterno.Enabled = false;
                    tabRegistros.Enabled = false;
                    break;
            }
        }

        /* Constructor para la edición */
        public MovimientoRecorridosMantenimiento(string CodDocumento, string fecha, string IdDocumento)
        {
            try
            {
                InitializeComponent();
                this.CodDocumento = CodDocumento;
                this.fecha = fecha;
                this.IdDocumento = IdDocumento;
                Actualizar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                return;
            }
        }

        private void Actualizar()
        {
            try
            {
                #region Actualizar()

                RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
                RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
                RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
                RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
                PresentarCboDestino();
                /* PARA RECORRIDOS ENTRE LOCALIDADES EJM TUMAN - CHONGOYAPE Y VICIVERSA */
                if (IdDocumento.ToString().Trim() == "MTI")
                {
                    tabRegistros.SelectedPage = tabRecorridoInterLocalidad;
                    this.tabRegistros.Pages.Remove(tabRecorridoInterno);
                    criterio = "MTI";
                    TabSelecionado = "INTERLOCALIDAD";
                }
                /* PARA RECORRIDOS DENTROS DEL FUNDO OSEA RECORRIDOS INTERNOS */
                if (IdDocumento.ToString().Trim() == "MTL")
                {
                    tabRegistros.SelectedPage = tabRecorridoInterno;
                    this.tabRegistros.Pages.Remove(tabRecorridoInterLocalidad);
                    criterio = "MTL";
                    TabSelecionado = "INTERNO";
                }

                this.CodigoDocumento = CodDocumento;
                this.periodo = fecha;
                Inicio();
                ProgressBar.Visible = false;
                CargarDatosIniciales();
                bgwHilo.RunWorkerAsync();
                //CargarDatosIniciales();
                //EjecutarConsultar();

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }


        private void Refrescar()
        {
            try
            {
                #region Refrescar()

                this.CodigoDocumento = CodDocumento;
                this.periodo = fecha;
                Inicio();
                ProgressBar.Visible = false;
                CargarDatosIniciales();
                bgwHilo.RunWorkerAsync();
                //CargarDatosIniciales();
                //EjecutarConsultar();

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void EjecutarConsultar()
        {
            try
            {
                #region Obtener documento de movimiento (Cabecera del movimiento)
                Documento = new SJ_RHObtenerDocumentoRecorridoMovilidadResult();
                movimientoRecorridosNegocio = new MovimientoMovilidadNegocio();
                Documento = movimientoRecorridosNegocio.ObtenerDocumentoParteRecorrido(this.CodigoDocumento, periodo);
                //this.CodigoDocumento = Documento.Codigo != null ? Documento.Codigo : "";
                //ObtenerListaDetalleMovimiento();
                #endregion
                #region Obtener Detalle del movimiento Interno();
                DocumentoDetalle = new List<SJ_RHObtenerDocumentoRecorridoMovilidadDetalleResult>();
                movimientoRecorridosNegocio = new MovimientoMovilidadNegocio();
                DocumentoDetalle = movimientoRecorridosNegocio.ObtenerDocumentoDetalleMovimientosInternos(this.CodigoDocumento, periodo).ToList();
                #endregion
                #region Obtener Detalle del movimiento InterLocalidad();
                ListaDetalleMovimientoAsistencia = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                movimientoRecorridosNegocio = new MovimientoMovilidadNegocio();
                ListaDetalleMovimientoAsistencia = movimientoRecorridosNegocio.ObtenerDocumentoDetalleMovimientosInterLocalidades(this.CodigoDocumento, periodo).ToList();


                ListaPasajerosByParadero = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                ListaPasajerosByParadero = movimientoRecorridosNegocio.ObtenerListaPasajerosByParadero(ListaDetalleMovimientoAsistencia).ToList();


                #endregion
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                return;
            }
        }

        private void PresentarControlesTransporteInterno()
        {
            try
            {
                #region Presentar Datos Recorrido Interno()

                #region Presentar Cabecera del movimiento()
                PresentarCboIdDocumento("INTERNO");
                PresentarCboSerie("INTERNO");
                this.txtPrecioVuelta.Text = Documento.PrecioVuelta.ToDecimalPresentation();
                this.cboIdDocumentoInterno.SelectedValue = Documento.idDocumento.ToString().Trim();
                this.cboIdSerieInterno.SelectedValue = Documento.Serie.ToString().Trim();
                this.txtNumeroDocumentoInterno.Text = Documento.Numero.ToString().Trim();
                this.txtNumeroManualInterno.Text = Documento.NumeroManual.ToString().Trim();
                this.txtFechaMovimientoInterno.Text = Documento.Fecha.ToPresentationDate();
                txtCodigoInterno.Text = Documento.Codigo.ToString().Trim();
                txtIdMovilInterno.Text = Documento.IdTransportista != null ? Documento.IdTransportista.ToString().Trim() : "";
                txtIdEstadoInterno.Text = Documento.IdEstado != null ? Documento.IdEstado.ToString().Trim() : "";
                this.txtEstadoInterno.Text = Documento.Estado != null ? Documento.Estado.ToString().Trim() : "";


                if (Documento.IdEstado == "AN")
                {
                    this.txtIdEstadoInterno.TextBoxElement.TextBoxItem.BackColor = Color.Red;
                    this.txtIdEstadoInterno.TextBoxElement.TextBoxItem.ForeColor = Color.Black;
                }
                if (Documento.IdEstado == "PE")
                {
                    this.txtIdEstadoInterno.TextBoxElement.TextBoxItem.BackColor = Color.White;
                    this.txtIdEstadoInterno.TextBoxElement.TextBoxItem.ForeColor = Color.Black;
                }

                if (Documento.IdEstado == "PR")
                {
                    this.txtIdEstadoInterno.TextBoxElement.TextBoxItem.BackColor = Utiles.colorAmarilloClaro;
                    this.txtIdEstadoInterno.TextBoxElement.TextBoxItem.ForeColor = Color.Black;
                }


                txtIdEstadoInterlocalidad.Text = Documento.IdEstado.ToString().Trim();

                txtPseudonombreInterno.Text = Documento.Transportista != null ? Documento.Transportista.ToString().Trim() : "";
                txtRUCInterno.Text = Documento.RUC != null ? Documento.RUC.ToString().Trim() : "";
                txtRazonSocialInterno.Text = Documento.RazonSocial != null ? Documento.RazonSocial.ToString().Trim() : "";
                txtTipoMovilidadInterno.Text = Documento.TipoMovilidad != null ? Documento.TipoMovilidad.ToString().Trim() : "";
                txtNroAsientosInterno.Text = Documento.NumeroAsientos != null ? Documento.NumeroAsientos.Value.ToString("N0").Trim() : "";
                txtChofeDNIRecorridoInterno.Text = Documento.DNI != null ? Documento.DNI.ToString().Trim() : "";
                txtChoferNombresRecorridoInterno.Text = Documento.Chofer != null ? Documento.Chofer.ToString().Trim() : "";
                txtPlacaInterno.Text = Documento.Placa != null ? Documento.Placa.ToString().Trim() : "";
                txtChoferCodigoRecorridoInterno.Text = Documento.IdChofer != null ? Documento.IdChofer.ToString().Trim() : "";



                if (Documento.RegistroRecorrido.ToString().Trim() == "01")
                {
                    //rbtIdaVueltaInterno.IsChecked = true;
                }
                else
                {
                    //rbtIdaVueltaInterno.IsChecked = true;
                }

                if (Documento.RegistroRecorrido.ToString().Trim() == "02")
                {
                    //rbtIdaInterno.IsChecked = true;
                }

                if (Documento.RegistroRecorrido.ToString().Trim() == "03")
                {
                    rbtVueltaInterno.IsChecked = true;
                }
                else
                {
                    rbtVueltaInterno.IsChecked = true;
                }
                #endregion

                #region Presentar detalle del movimiento()
                this.dgvRecorridosInternos.CargarDatos(DocumentoDetalle.ToDataTable<SJ_RHObtenerDocumentoRecorridoMovilidadDetalleResult>());
                this.dgvRecorridosInternos.Refresh();

                if (dgvRecorridosInternos != null)
                {
                    #region
                    if (dgvRecorridosInternos.Rows.Count > 0)
                    {
                        #region
                        precioVueltaAcumulado = Convert.ToDecimal(dgvRecorridosInternos.Sumar("chPrecio"));
                        this.txtNumeroViajesRecorridoInterno.Text = dgvRecorridosInternos.Rows.Count.ToString();
                        this.txtNroPersonasRecorridoInterno.Text = Documento.NumeroPersonas != null ? Documento.NumeroPersonas.Value.ToString("N0") : Convert.ToDecimal(0.0).ToDecimalPresentation();
                        this.txtTotalRecorridoInterno.Text = Documento.Total != null ? Documento.Total.Value.ToDecimalPresentation() : Convert.ToDecimal(0.0).ToDecimalPresentation();
                        this.txtSubTotalRecorridoInterno.Text = Documento.SubTotal != null ? Documento.SubTotal.Value.ToDecimalPresentation() : Convert.ToDecimal(0.0).ToDecimalPresentation();
                        this.txtIGVRecorridoInterno.Text = Documento.IGV != null ? Documento.IGV.Value.ToDecimalPresentation() : Convert.ToDecimal(0.0).ToDecimalPresentation();
                        this.txtPrecioPersonaPromedioRecorridoInterno.Text = Documento.PromedioxPersona != null ? Documento.PromedioxPersona.Value.ToDecimalPresentation() : Convert.ToInt32(0).ToString();
                        #endregion
                    }
                    else
                    {
                        precioVueltaAcumulado = 0;
                    }
                    #endregion
                }
                else
                {
                    precioVueltaAcumulado = 0;
                }

                #endregion

                #endregion
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        } /* PARA RECORRIDOS DENTROS DEL FUNDO OSEA RECORRIDOS INTERNOS */

        private void PresentarControlesTransporteExterno() //* PARA RECORRIDOS ENTRE LOCALIDADES EJM TUMAN - CHONGOYAPE Y VICIVERSA */
        {
            try
            {
                #region Presentar Movimiento()

                #region Presentar Cabecera del Documento()
                PresentarCboIdDocumento("INTERLOCALIDAD");
                PresentarCboSerie("INTERLOCALIDAD");
                this.cboIdDocumentoExterno.SelectedValue = Documento.idDocumento != null ? Documento.idDocumento.ToString().Trim() : "";
                this.cboIdSerieExterno.SelectedValue = Documento.Serie != null ? Documento.Serie.ToString().Trim() : "";
                this.txtNumeroDocumentoExterno.Text = Documento.Numero != null ? Documento.Numero.ToString().Trim() : "";
                this.txtNumeroManualExterno.Text = Documento.NumeroManual != null ? Documento.NumeroManual.ToString().Trim() : "";
                this.txtFechaMovimientoRecorridoInterLocalidad.Text = Documento.Fecha != null ? Documento.Fecha.ToPresentationDate() : DateTime.Now.ToPresentationDate();
                this.txtChoferCodigoRecorridoInterLocalidad.Text = Documento.IdChofer != null ? Documento.IdChofer.Value.ToString().Trim() : "";
                this.txtChofeDNIRecorridoInterlocalidad.Text = Documento.DNI != null ? Documento.DNI.ToString().Trim() : "";
                txtChoferNombresRecorridoInterLocalidad.Text = Documento.Chofer != null ? Documento.Chofer.ToString().Trim() : "";

                if (Documento.Movimiento == "01")
                {
                    rbtFlete.IsChecked = true;
                }

                if (Documento.Movimiento == "02")
                {
                    this.rbtNumeroPersonas.IsChecked = true;
                }
                txtCodigoExterno.Text = Documento.Codigo != null ? Documento.Codigo.ToString().Trim() : "";
                txtIdMovilRecorridoInterlocalidad.Text = Documento.IdTransportista != null ? Documento.IdTransportista.ToString().Trim() : "";
                txtPlacaInterLocalidad.Text = Documento.Placa != null ? Documento.Placa.ToString().Trim() : "";
                txtIdEstadoInterlocalidad.Text = Documento.IdEstado != null ? Documento.IdEstado.ToString().Trim() : "";
                txtIdEstadoInterno.Text = Documento.IdEstado != null ? Documento.IdEstado.ToString().Trim() : "";
                txtEstadoInterLocalidad.Text = Documento.Estado != null ? Documento.Estado.ToString().Trim() : "";

                if (Documento.IdEstado == "AN")
                {
                    this.txtEstadoInterLocalidad.TextBoxElement.TextBoxItem.BackColor = Color.Red;
                    this.txtEstadoInterLocalidad.TextBoxElement.TextBoxItem.ForeColor = Color.Black;
                }
                if (Documento.IdEstado == "PE")
                {
                    this.txtEstadoInterLocalidad.TextBoxElement.TextBoxItem.BackColor = Color.White;
                    this.txtEstadoInterLocalidad.TextBoxElement.TextBoxItem.ForeColor = Color.Black;
                }

                if (Documento.IdEstado == "PR")
                {
                    this.txtEstadoInterLocalidad.TextBoxElement.TextBoxItem.BackColor = Utiles.colorAmarilloClaro;
                    this.txtEstadoInterLocalidad.TextBoxElement.TextBoxItem.ForeColor = Color.Black;
                }



                txtPseudonombreInterlocalidad.Text = Documento.Transportista != null ? Documento.Transportista.ToString().Trim() : "";
                txtRUCInterlocalidad.Text = Documento.RUC != null ? Documento.RUC.ToString().Trim() : "";
                txtRazonSocialInterlocalidad.Text = Documento.RazonSocial != null ? Documento.RazonSocial.ToString().Trim() : "";
                txtTipoMovilidadInterLocalidad.Text = Documento.TipoMovilidad != null ? Documento.TipoMovilidad.ToString().Trim() : "";
                txtNroAsientosInterlocalidad.Text = Documento.NumeroAsientos != null ? Documento.NumeroAsientos.ToString().Trim() : "";
                txtCodigoRutaOrigen.Text = Documento.IdRutaOrigen != null ? Documento.IdRutaOrigen.ToString().Trim() : "";
                txtRutaOrigen.Text = Documento.Origen != null ? Documento.Origen.ToString().Trim() : "";
                txtPrecioProcedenciaInterlocalidad.Text = Documento.precioOrigen != null ? Convert.ToDecimal(Documento.precioOrigen).ToDecimalPresentation() : "";
                txtCodigoRutaDestino.Text = Documento.IdRutaDestino != null ? Documento.IdRutaDestino.ToString().Trim() : "";
                txtRutaDestino.Text = Documento.Destino != null ? Documento.Destino.ToString().Trim() : "";
                txtPrecioDestinoInterprocedencia.Text = Documento.precioDestino != null ? Convert.ToDecimal(Documento.precioDestino).ToDecimalPresentation() : "";
                txtNumeroPersonasInterlocalidad.Text = Documento.NumeroPersonas != null ? Documento.NumeroPersonas.Value.ToString("N0").Trim() : "";
                txtPrecioExterno.Text = Documento.Precio != null ? Documento.Precio.Value.ToDecimalPresentation().ToString().Trim() : "";
                txtSubTotalInterlocalidad.Text = Documento.SubTotal != null ? Documento.SubTotal.Value.ToDecimalPresentation().ToString().Trim() : "";
                txtIGVInterlocalidad.Text = Documento.IGV != null ? Documento.IGV.Value.ToDecimalPresentation().ToString().Trim() : "";
                txtTotalInterlocalidad.Text = Documento.Total != null ? Documento.Total.Value.ToDecimalPresentation().ToString().Trim() : "";
                txtPromedioPersona.Text = Documento.PromedioxPersona != null ? Documento.PromedioxPersona.Value.ToDecimalPresentation().ToString().Trim() : "";
                txtObservacionInterlocalidad.Text = Documento.Observacion != null ? Documento.Observacion.ToString().Trim() : "";

                cboDestinoMovimientos.SelectedValue = Documento.campoDestino != null ? Documento.campoDestino.ToString().Trim() : "001";


                if (Documento.RegistroRecorrido == "01")
                {
                    rbtIdaVuelta.IsChecked = true;
                }
                if (Documento.RegistroRecorrido == "02")
                {
                    this.rbtRecorridoOrigen.IsChecked = true;
                }

                if (Documento.RegistroRecorrido == "03")
                {
                    this.rbtRecorridoDestino.IsChecked = true;
                }


                this.txtItemIda.Text = Documento.itemRecorridoIda;
                this.txtItemRegreso.Text = Documento.itemRecorridoRegreso;

                //MovimientoMovilidad.precioIda = Documento.precioOrigen;
                //MovimientoMovilidad.precioRegreso = Documento.precioDestino;




                //if (Documento.campoDestino == "001")
                //{
                //    rbtUvaSJ.IsChecked = true;
                //    rbtUcupe.IsChecked = false;
                //    this.rbtOtrosCampos.IsChecked = false;
                //}
                //if (Documento.campoDestino == "002")
                //{
                //    rbtUvaSJ.IsChecked = false;
                //    this.rbtUcupe.IsChecked = true;
                //    this.rbtOtrosCampos.IsChecked = false;
                //}

                //if (Documento.campoDestino == "003")
                //{
                //    this.rbtOtrosCampos.IsChecked = true;
                //    this.rbtUvaSJ.IsChecked = false;
                //    this.rbtUcupe.IsChecked = false;
                //}
                #endregion

                #region Presentar Detalle del Documento (Lista de asistencia del personal que tubo el beneficio del transporte entre localidad)

                dgvListadoTrabajadoresIngreso.DataSource = (ListaDetalleMovimientoAsistencia.OrderBy(x => Convert.ToInt32(x.item)).ToList().ToDataTable<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>());
                dgvListadoTrabajadoresIngreso.Refresh();


                #endregion

                #region Presentar agrupacion del Documento (Lista de asistencia del personal que tubo el beneficio del transporte entre localidad)

                dgvResumenPorParadero.DataSource = (ListaPasajerosByParadero.OrderBy(x => Convert.ToInt32(x.cantidad)).ToList().ToDataTable<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>());
                dgvResumenPorParadero.Refresh();


                #endregion
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }


        }

        private void PresentarCboSerie(string tipoMovimiento)
        {
            documentoNeg = new DocumentoNegocio();
            ListaSerie = new List<Grupo>();
            ListaSerie = documentoNeg.ObtenerNumeroSerieMovimientoTransportista(tipoMovimiento);

            if (ListaSerie != null)
            {
                cboIdSerieExterno.DataSource = ListaSerie;
                cboIdSerieExterno.DisplayMember = "Codigo";
                cboIdSerieExterno.ValueMember = "Descripcion";
                cboIdSerieExterno.SelectedIndex = 0;
                //cboIdSerieInterLocalidad.Enabled = false;

                cboIdSerieInterno.DataSource = ListaSerie;
                cboIdSerieInterno.DisplayMember = "Codigo";
                cboIdSerieInterno.ValueMember = "Descripcion";
                cboIdSerieInterno.SelectedIndex = 0;
                //cboSerieInterno.Enabled = false;

                //string NumeroDocumentoInterLocal, NumeroDocumentoIntero = string.Empty;
                //NumeroDocumentoInterLocal = documentoNeg.ObtenerNumeroDocumento(tipoMovimiento, cboIdSerieInterLocalidad.SelectedValue.ToString().Trim());
                //NumeroDocumentoIntero = documentoNeg.ObtenerNumeroDocumento(tipoMovimiento, cboIdSerieInterno.SelectedValue.ToString().Trim());

                txtNumeroDocumentoExterno.Text = NumeroDocumento;
                txtNumeroDocumentoInterno.Text = NumeroDocumento;

                this.txtIdEstadoInterlocalidad.Text = "PE";
                this.txtIdEstadoInterno.Text = "PE";

                this.txtEstadoInterLocalidad.Text = "PENDIENTE";
                this.txtEstadoInterno.Text = "PENDIENTE";

            }

        }

        private void PresentarCboDestino()
        {
            try
            {
                destinoMovilidadNegocios = new DestinoMovilidad();
                ListaDestinoMovilidad = new List<SJ_RHDestinoMovilidad>();

                ListaDestinoMovilidad = destinoMovilidadNegocios.ListadoDestinos();

                var listadoDestino = ListaDestinoMovilidad;

                cboDestinoMovimientos.DataSource = listadoDestino;
                cboDestinoMovimientos.DisplayMember = "descripcion";
                cboDestinoMovimientos.ValueMember = "codigo";

                if (cboDestinoMovimientos.SelectedIndex > -1)
                {
                    cboDestinoMovimientos.SelectedIndex = 0;
                }
                //this.cboDestinoMovimiento.DisplayMember = "Descripcion";
                //cboDestinoMovimiento.ValueMember = "Codigo";
                //cboDestinoMovimiento.DataSource = ListaDestinos.ToDataTable<SJ_RHDestinoMovilidad>();
                //cboDestinoMovimiento.SelectedValue = DateTime.Now.ToString("00");


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString());
                return;
            }


        }

        private void PresentarCboIdDocumento(string tipoMovimiento)
        {
            documentoNeg = new DocumentoNegocio();
            ListaIdDocumento = new List<Grupo>();
            ListaIdDocumento = documentoNeg.ObtenerIdDocumentoMovimientoTransportista(tipoMovimiento);

            if (ListaIdDocumento != null)
            {
                cboIdDocumentoExterno.DataSource = ListaIdDocumento;
                cboIdDocumentoExterno.DisplayMember = "Codigo";
                cboIdDocumentoExterno.ValueMember = "Descripcion";

                if (cboIdDocumentoExterno.SelectedIndex > -1)
                {
                    cboIdDocumentoExterno.SelectedIndex = 0;
                }


                //cboIdDocumentoInterLocalidad.Enabled = false;

                cboIdDocumentoInterno.DataSource = ListaIdDocumento;
                cboIdDocumentoInterno.DisplayMember = "Codigo";
                cboIdDocumentoInterno.ValueMember = "Descripcion";

                if (cboIdDocumentoInterno.SelectedIndex > -1)
                {
                    cboIdDocumentoInterno.SelectedIndex = 0;
                }
                //cboIdDocumentoInterno.Enabled = false;
            }
        }

        public void Inicio()
        {
            try
            {
                Periodo = DateTime.Now.Year.ToString();
                Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + Periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "EAURAZO";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "EAURAZOC";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void RegistroMovimientoMovilidad_Load(object sender, EventArgs e)
        {
            try
            {
                dgvRecorridosInternos.Columns["chModulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvRecorridosInternos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void btnBuscarMovilidad_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarMovilidadTransportePersonalCampo ofrm = new BuscarMovilidadTransportePersonalCampo("INTERLOCALIDAD");
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    #region
                    if (ofrm.oMovilidad != null)
                    {
                        #region
                        this.txtPlacaInterLocalidad.Text = ofrm.oMovilidad.Placa;
                        this.txtRUCInterlocalidad.Text = ofrm.oMovilidad.RUC;
                        this.txtRazonSocialInterlocalidad.Text = ofrm.oMovilidad.RazonSocial;
                        this.txtPseudonombreInterlocalidad.Text = ofrm.oMovilidad.PseudoNombre;
                        this.txtNroAsientosInterlocalidad.Text = ofrm.oMovilidad.NumeroAsientos.ToString();
                        this.txtTipoMovilidadInterLocalidad.Text = ofrm.oMovilidad.TipoMovilidad.ToString();
                        this.txtIdMovilRecorridoInterlocalidad.Text = ofrm.oMovilidad.Id.ToString();

                        if (ofrm.oMovilidad.Placa.ToString().Trim() != string.Empty)
                        {
                            gbRegistroPersonasExterno.Enabled = true;
                            gbProcedenciaExterno.Enabled = true;
                            gbRegistroMovimientoExterno.Enabled = true;

                        }
                        else
                        {
                            gbRegistroPersonasExterno.Enabled = false;
                            gbProcedenciaExterno.Enabled = false;
                            gbRegistroMovimientoExterno.Enabled = false;


                            this.txtRutaDestino.Clear();
                            this.txtCodigoRutaDestino.Clear();
                            this.txtPrecioDestinoInterprocedencia.Clear();
                            this.txtCodigoRutaOrigen.Clear();
                            this.txtRutaOrigen.Clear();
                            this.txtPrecioProcedenciaInterlocalidad.Clear();
                        }

                        #endregion
                    }
                    else
                    {
                        #region
                        gbRegistroPersonasExterno.Enabled = false;
                        gbProcedenciaExterno.Enabled = false;
                        gbRegistroMovimientoExterno.Enabled = false;
                        #endregion
                    }
                    #endregion
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void rbtIdaVuelta_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.btnBuscarRutaDestino.Enabled = true;
            this.btnBuscarRutaOrigen.Enabled = true;
            this.txtCodigoRutaDestino.Enabled = true;
            this.txtCodigoRutaOrigen.Enabled = true;
            this.txtRutaDestino.Enabled = true;
            this.txtRutaOrigen.Enabled = true;

        }

        private void rbtIda_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.btnBuscarRutaDestino.Enabled = false;
            this.btnBuscarRutaOrigen.Enabled = true;

            this.txtCodigoRutaDestino.Enabled = false;
            this.txtCodigoRutaOrigen.Enabled = true;

            this.txtRutaDestino.Enabled = false;
            this.txtRutaOrigen.Enabled = true;

            this.txtRutaDestino.Clear();
            this.txtCodigoRutaDestino.Clear();

            this.txtPrecioDestinoInterprocedencia.Clear();

        }

        private void rbtVuelta_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.btnBuscarRutaDestino.Enabled = true;
            this.btnBuscarRutaOrigen.Enabled = false;

            this.txtCodigoRutaDestino.Enabled = true;
            this.txtCodigoRutaOrigen.Enabled = false;

            this.txtRutaDestino.Enabled = true;
            this.txtRutaOrigen.Enabled = false;

            this.txtRutaOrigen.Clear();
            this.txtCodigoRutaOrigen.Clear();
            this.txtPrecioProcedenciaInterlocalidad.Clear();
        }

        private void rbtNumeroPersonas_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            if (rbtNumeroPersonas.IsChecked == true)
            {
                movimiento = "02";
                if (this.txtPlacaInterLocalidad.Text.ToString().Trim() != string.Empty)
                {
                    gbRegistroPersonasExterno.Enabled = true;
                    //this.gbDestinoMovimiento.Enabled = false;
                    //rbtUvaSJ.IsChecked = false;
                    this.gbTransportistaInformacion.Enabled = false;
                }
                else if (txtCodigoExterno.Text.ToString().Trim() == "")
                {
                    gbRegistroPersonasExterno.Enabled = true;
                    //this.gbDestinoMovimiento.Enabled = true;
                    //rbtUvaSJ.IsChecked = true;
                    this.gbTransportistaInformacion.Enabled = true;

                }
                else
                {
                    gbRegistroPersonasExterno.Enabled = false;
                    //this.gbDestinoMovimiento.Enabled = false;
                    //rbtUvaSJ.IsChecked = false;
                    this.gbTransportistaInformacion.Enabled = false;

                }
            }

        }

        private void rbtFlete_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rbtFlete.IsChecked == true)
            {
                movimiento = "01";
                if (this.txtPlacaInterLocalidad.Text.ToString().Trim() != string.Empty)
                {
                    gbRegistroPersonasExterno.Enabled = true;
                    //this.gbDestinoMovimiento.Enabled = true;
                    //rbtUvaSJ.IsChecked = true;
                    this.gbTransportistaInformacion.Enabled = true;
                }

                else if (txtCodigoExterno.Text.ToString().Trim() == "")
                {
                    gbRegistroPersonasExterno.Enabled = true;
                    //this.gbDestinoMovimiento.Enabled = true;
                    //rbtUvaSJ.IsChecked = true;
                    this.gbTransportistaInformacion.Enabled = true;
                }


                else
                {
                    gbRegistroPersonasExterno.Enabled = false;
                    //this.gbDestinoMovimiento.Enabled = true;
                    //rbtUvaSJ.IsChecked = true;
                    this.gbTransportistaInformacion.Enabled = false;
                }
            }


        }

        private void btnBuscarRutaOrigen_Click(object sender, EventArgs e)
        {

            try
            {
                BuscarRuta ofrm = new BuscarRuta(this.txtIdMovilRecorridoInterlocalidad.Text.ToString().Trim(), this.txtCodigoRutaDestino.Text);
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    if (ofrm.oRuta != null)
                    {
                        if (ofrm.oRuta.IdRuta.ToString().Trim() != string.Empty)
                        {
                            this.txtCodigoRutaOrigen.Text = ofrm.oRuta.IdRuta.ToString();
                            this.txtRutaOrigen.Text = ofrm.oRuta.Ruta.ToString().Trim();
                            this.txtItemIda.Text = ofrm.oRuta.Item != null ? ofrm.oRuta.Item.ToString().Trim() : "";



                            if (this.rbtFlete.IsChecked == true)
                            {
                                this.txtPrecioProcedenciaInterlocalidad.Text = ofrm.oRuta.PrecioFlete.ToString().Trim();
                                RealizarCalculo();
                            }
                            else
                            {
                                this.txtPrecioProcedenciaInterlocalidad.Text = ofrm.oRuta.PrecioPersona.ToString().Trim();
                                RealizarCalculo();
                            }
                        }
                        else
                        {
                            this.txtCodigoRutaOrigen.Clear();
                            this.txtRutaOrigen.Clear();
                            this.txtPrecioProcedenciaInterlocalidad.Clear();
                            RealizarCalculo();
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }


        }

        private void RealizarCalculo()
        {

            try
            {
                #region MyRegion

                decimal? MontoxRutaOrigen, MontoxRutaDestino, CantidadPersona, Precio, SubTotal, IGV, Total = 0;
                MontoxRutaOrigen = (this.txtPrecioProcedenciaInterlocalidad.Text.ToString().Trim() != "" && this.txtPrecioProcedenciaInterlocalidad.Text != null) ? Convert.ToDecimal(this.txtPrecioProcedenciaInterlocalidad.Text.ToString().Trim()) : 0;
                MontoxRutaDestino = (this.txtPrecioDestinoInterprocedencia.Text.ToString().Trim() != "") ? Convert.ToDecimal(this.txtPrecioDestinoInterprocedencia.Text.ToString().Trim()) : 0;
                CantidadPersona = (this.txtNumeroPersonasInterlocalidad.Text.ToString().Trim() != "") ? Convert.ToDecimal(this.txtNumeroPersonasInterlocalidad.Text.ToString().Trim()) : 0;


                // el check de pago x personas esta activado sacamos el precio de la siguiente manera
                if (rbtNumeroPersonas.IsChecked == true)
                {
                    if (MontoxRutaOrigen != (decimal?)null || MontoxRutaDestino != (decimal?)null || CantidadPersona != (decimal?)null)
                    {
                        Precio = (MontoxRutaOrigen + MontoxRutaDestino);
                        SubTotal = (Precio * CantidadPersona);
                        IGV = (SubTotal * Convert.ToDecimal(0.18));
                        Total = SubTotal + IGV;
                        PromedioPersonal = (CantidadPersona != null && CantidadPersona.Value > 0) ? SubTotal / CantidadPersona : 0;

                        txtPrecioExterno.Text = Precio.Value.ToDecimalPresentation();
                        txtSubTotalInterlocalidad.Text = SubTotal.Value.ToDecimalPresentation();
                        txtIGVInterlocalidad.Text = IGV.Value.ToDecimalPresentation();
                        txtTotalInterlocalidad.Text = Total.Value.ToDecimalPresentation();
                        txtPromedioPersona.Text = PromedioPersonal.Value.ToDecimalPresentation();

                    }
                    else
                    {
                        txtPromedioPersona.Clear();
                        txtPrecioExterno.Clear();
                        txtSubTotalInterlocalidad.Clear();
                        txtIGVInterlocalidad.Clear();
                        txtTotalInterlocalidad.Clear();
                    }
                }
                else
                {
                    Precio = (MontoxRutaOrigen + MontoxRutaDestino);
                    SubTotal = Precio;
                    IGV = (Precio * Convert.ToDecimal(0.18));
                    Total = SubTotal + IGV;
                    PromedioPersonal = (CantidadPersona != null && CantidadPersona.Value > 0) ? (SubTotal / CantidadPersona) : 0;

                    txtPrecioExterno.Text = Precio.Value.ToDecimalPresentation();
                    txtSubTotalInterlocalidad.Text = SubTotal.Value.ToDecimalPresentation();
                    txtIGVInterlocalidad.Text = IGV.Value.ToDecimalPresentation();
                    txtTotalInterlocalidad.Text = Total.Value.ToDecimalPresentation();
                    txtPromedioPersona.Text = PromedioPersonal.Value.ToDecimalPresentation();
                }

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }




        }

        private void btnBuscarRutaDestino_Click(object sender, EventArgs e)
        {

            try
            {
                BuscarRuta ofrm = new BuscarRuta(this.txtIdMovilRecorridoInterlocalidad.Text.ToString().Trim(), txtCodigoRutaOrigen.Text.ToString().Trim());
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    if (ofrm.oRuta != null)
                    {
                        if (ofrm.oRuta.IdRuta.ToString().Trim() != string.Empty)
                        {
                            this.txtCodigoRutaDestino.Text = ofrm.oRuta.IdRuta.ToString();
                            this.txtRutaDestino.Text = ofrm.oRuta.Ruta.ToString().Trim();
                            this.txtItemRegreso.Text = ofrm.oRuta.Item != null ? ofrm.oRuta.Item.ToString().Trim() : "";

                            if (this.rbtFlete.IsChecked == true)
                            {
                                this.txtPrecioDestinoInterprocedencia.Text = ofrm.oRuta.PrecioFlete.ToString().Trim();
                                RealizarCalculo();
                            }
                            else
                            {
                                this.txtPrecioDestinoInterprocedencia.Text = ofrm.oRuta.PrecioPersona.ToString().Trim();
                                RealizarCalculo();
                            }
                        }
                        else
                        {
                            this.txtCodigoRutaDestino.Clear();
                            this.txtRutaDestino.Clear();
                            this.txtPrecioDestinoInterprocedencia.Clear();
                            RealizarCalculo();
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }


        }

        private void txtNumeroPersonasInterlocalidad_Leave(object sender, EventArgs e)
        {
            RealizarCalculo();
        }

        private void btnBuscarMovilInterno_Click(object sender, EventArgs e)
        {
            BuscarMovilidadTransportePersonalCampo ofrm = new BuscarMovilidadTransportePersonalCampo("INTERNO");
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                #region
                if (ofrm.oMovilidad != null)
                {
                    if (ofrm.oMovilidad.Id > 0)
                    {
                        #region
                        this.txtPlacaInterno.Text = ofrm.oMovilidad.Placa;
                        this.txtRUCInterno.Text = ofrm.oMovilidad.RUC;
                        this.txtRazonSocialInterno.Text = ofrm.oMovilidad.RazonSocial;
                        this.txtPseudonombreInterno.Text = ofrm.oMovilidad.PseudoNombre;
                        this.txtNroAsientosInterno.Text = ofrm.oMovilidad.NumeroAsientos.ToString();
                        this.txtTipoMovilidadInterno.Text = ofrm.oMovilidad.TipoMovilidad.ToString();
                        this.txtIdMovilInterno.Text = ofrm.oMovilidad.Id.ToString();
                        this.txtPrecioVuelta.Text = ofrm.oMovilidad.PrecioVuelta.ToDecimalPresentation();
                        this.txtItemRecorridoInterno.Text = ofrm.oMovilidad.item != null ? ofrm.oMovilidad.item.ToString().Trim() : "";
                        btnChoferBuscar.Enabled = true;

                        this.txtChofeDNIRecorridoInterno.Text = "";
                        this.txtChoferNombresRecorridoInterno.Text = "";

                        if (ofrm.oMovilidad.Placa.ToString().Trim() != string.Empty)
                        {
                            gbRegistroRecorridoInterno.Enabled = true;
                        }
                        else
                        {
                            gbRegistroRecorridoInterno.Enabled = false;
                        }



                        #endregion
                    }
                }
                else
                {
                    #region
                    gbRegistroRecorridoInterno.Enabled = false;
                    this.txtPlacaInterno.Clear();
                    this.txtRUCInterno.Clear();
                    this.txtRazonSocialInterno.Clear();
                    this.txtPseudonombreInterno.Clear();
                    this.txtNroAsientosInterno.Clear();
                    this.txtTipoMovilidadInterno.Clear();
                    this.txtIdMovilInterno.Clear();
                    btnChoferBuscar.Enabled = false;
                    #endregion
                }
                #endregion
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            try
            {
                #region Nuevo()
                try
                {
                    #region Generar un nuevo formato para el registro del movimiento de recorrido()
                    switch (CodigoDocumento)
                    {
                        case "InterLocalidad":
                            #region
                            LimpiaMovimientoInterlocal();
                            CargarDatosIniciales();
                            PresentarCboIdDocumento("INTERLOCALIDAD");
                            PresentarCboSerie("INTERLOCALIDAD");
                            precioVueltaAcumulado = 0;


                            btnNuevo.Enabled = false;
                            btnEditar.Enabled = false;
                            btnGrabar.Enabled = true;
                            btnAnular.Enabled = false;
                            btnAtras.Enabled = true;
                            btnExportar.Enabled = false;
                            btnHistorial.Enabled = true;
                            btnImportar.Enabled = true;
                            btnSalir.Enabled = true;


                            gbMovimientoInterlocalidad.Enabled = false;
                            gbMovimientoInterno.Enabled = true;
                            gbProcedenciaMovimientoInterno.Enabled = true;
                            gbProcedenciaExterno.Enabled = true;
                            gbRegistroMovimientoExterno.Enabled = false;
                            gbRegistroRecorridoInterno.Enabled = false;
                            gbTransportistaInformacion.Enabled = false;
                            ProgressBar.Visible = false;
                            tabRegistros.Enabled = true;
                            gbRegistroDocumento.Enabled = true;

                            #endregion

                            break;
                        case "Interno":
                            #region
                            LimpiarMovimientoInterno();
                            CargarDatosIniciales();
                            PresentarCboIdDocumento("INTERNO");
                            PresentarCboSerie("INTERNO");

                            precioVueltaAcumulado = 0;
                            ListaDetalleRecorridoInterno = new List<SJ_RHMovimientoMovilidadDetalle>();
                            ListaDetalleEliminados = new List<SJ_RHMovimientoMovilidadDetalle>();


                            gbMovimientoInterno.Enabled = true;
                            gbProcedenciaMovimientoInterno.Enabled = true;
                            btnAgregarRecorrido.Enabled = true;
                            btnQuitarRecorrido.Enabled = true;

                            btnNuevo.Enabled = false;
                            btnEditar.Enabled = false;
                            btnGrabar.Enabled = true;
                            btnAnular.Enabled = false;
                            btnAtras.Enabled = true;
                            btnExportar.Enabled = false;
                            btnHistorial.Enabled = true;
                            btnImportar.Enabled = true;
                            btnSalir.Enabled = true;
                            //gbDestinoMovimiento.Enabled = false;
                            gbMovimientoInterlocalidad.Enabled = false;
                            gbMovimientoInterno.Enabled = true;
                            gbProcedenciaMovimientoInterno.Enabled = true;
                            gbProcedenciaExterno.Enabled = true;
                            gbRegistroMovimientoExterno.Enabled = false;
                            gbRegistroRecorridoInterno.Enabled = false;
                            gbTransportistaInformacion.Enabled = false;
                            ProgressBar.Visible = false;
                            tabRegistros.Enabled = true;
                            gbRegistroDocumento.Enabled = true;
                            gbRegistroPersonasExterno.Enabled = true;
                            #endregion
                            break;
                        default:
                            #region

                            if (this.TabSelecionado.ToString().Trim().ToUpper() == "InterLocalidad".ToUpper())
                            {
                                criterio = "MTI";
                            }
                            else if (this.TabSelecionado.ToString().Trim().ToUpper() == "Interno".ToUpper())
                            {
                                criterio = "MTL";
                            }


                            LimpiaMovimientoInterlocal();
                            LimpiarMovimientoInterno();
                            CargarDatosIniciales();

                            if (this.TabSelecionado.ToString().Trim().ToUpper() == "InterLocalidad".ToUpper())
                            {
                                PresentarCboIdDocumento("INTERLOCALIDAD");
                                PresentarCboSerie("INTERLOCALIDAD");
                                precioVueltaAcumulado = 0;
                            }
                            else if (this.TabSelecionado.ToString().Trim().ToUpper() == "Interno".ToUpper())
                            {
                                PresentarCboIdDocumento("INTERNO");
                                PresentarCboSerie("INTERNO");

                                precioVueltaAcumulado = 0;
                                ListaDetalleRecorridoInterno = new List<SJ_RHMovimientoMovilidadDetalle>();
                                ListaDetalleEliminados = new List<SJ_RHMovimientoMovilidadDetalle>();
                            }

                            btnNuevo.Enabled = true;
                            btnEditar.Enabled = true;
                            btnGrabar.Enabled = false;
                            btnAnular.Enabled = false;
                            btnAtras.Enabled = false;
                            btnExportar.Enabled = false;
                            btnHistorial.Enabled = true;
                            btnImportar.Enabled = false;
                            btnSalir.Enabled = true;

                            gbRegistroDocumento.Enabled = true;
                            gbMovimientoInterno.Enabled = true;
                            gbProcedenciaMovimientoInterno.Enabled = true;

                            gbMovimientoInterlocalidad.Enabled = true;
                            //gbDestinoMovimiento.Enabled = true;
                            gbTransportistaInformacion.Enabled = true;
                            gbRegistroMovimientoExterno.Enabled = false;
                            gbProcedenciaExterno.Enabled = false;
                            gbRegistroPersonasExterno.Enabled = true;
                            tabRegistros.Enabled = true;
                            btnGrabar.Enabled = true;
                            btnEditar.Enabled = false;
                            btnAnular.Enabled = false;
                            #endregion
                            break;
                    }

                    #endregion
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.ToString().Trim() + "\n Generar nuevo Documento", "ADVERTENCIA DEL SISTEA");
                    return;
                }
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void LimpiarMovimientoInterno()
        {
            try
            {
                #region Limpiar recorrrido de movimiento Interno ()
                CodigoDocumento = string.Empty;
                txtCodigoInterno.Clear();
                txtIdMovilInterno.Clear();
                //cboIdDocumentoInterno.SelectedValue.ToString().Trim();
                //cboIdSerieInterno.SelectedValue.ToString().Trim();
                txtItemRecorridoInterno.Clear();
                txtNumeroDocumentoInterno.Clear();
                txtFechaMovimientoInterno.Clear();
                txtNumeroManualInterno.Clear();
                txtIdEstadoInterno.Clear();
                rbtIdaVueltaInterno.IsChecked = true;
                txtPseudonombreInterno.Clear();
                txtRUCInterno.Clear();
                txtRazonSocialInterno.Clear();
                txtTipoMovilidadInterno.Clear();
                txtNroAsientosInterno.Clear();
                txtChofeDNIRecorridoInterno.Clear();
                txtChoferNombresRecorridoInterno.Clear();

                txtNroPersonasRecorridoInterno.Text = "0.00";
                txtPrecioPersonaPromedioRecorridoInterno.Text = "0.00";
                txtNumeroViajesRecorridoInterno.Text = "0.00";
                txtSubTotalRecorridoInterno.Text = "0.00";
                txtIGVRecorridoInterno.Text = "0.00";
                txtTotalRecorridoInterno.Text = "0.00";

                this.txtEstadoInterno.TextBoxElement.TextBoxItem.BackColor = Color.White;
                this.txtEstadoInterno.TextBoxElement.TextBoxItem.ForeColor = Color.Black;


                //txtPlacaInterLocalidad.Clear();
                txtPlacaInterno.Clear();
                DocumentoDetalle = new List<SJ_RHObtenerDocumentoRecorridoMovilidadDetalleResult>();
                this.dgvRecorridosInternos.CargarDatos(DocumentoDetalle.ToDataTable<SJ_RHObtenerDocumentoRecorridoMovilidadDetalleResult>());
                this.dgvRecorridosInternos.Refresh();
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString().Trim() + "\n Limpiar recorrido de movimiento interno", "ADVERTENCIA DEL SISTEA");
                return;
            }
        }

        private void LimpiaMovimientoInterlocal()
        {
            try
            {
                #region Limpiar movimiento de recorrido
                CodigoDocumento = string.Empty;
                rbtFlete.IsChecked = true;
                txtCodigoExterno.Clear();
                txtIdMovilRecorridoInterlocalidad.Clear();
                txtPlacaInterLocalidad.Clear();
                txtIdEstadoInterlocalidad.Text = "PE";
                txtEstadoInterLocalidad.Text = "PENDIENTE";

                this.txtEstadoInterLocalidad.TextBoxElement.TextBoxItem.BackColor = Color.White;
                this.txtEstadoInterLocalidad.TextBoxElement.TextBoxItem.ForeColor = Color.Black;


                txtPseudonombreInterlocalidad.Clear();
                txtRUCInterlocalidad.Clear();
                txtRazonSocialInterlocalidad.Clear();
                txtTipoMovilidadInterLocalidad.Clear();
                txtNroAsientosInterlocalidad.Clear();
                rbtIdaVuelta.IsChecked = true;
                txtCodigoRutaOrigen.Clear();
                txtRutaOrigen.Clear();
                txtPrecioProcedenciaInterlocalidad.Clear();
                txtCodigoRutaDestino.Clear();
                txtRutaDestino.Clear();
                txtPrecioDestinoInterprocedencia.Clear();
                txtNumeroPersonasInterlocalidad.Clear();
                txtPrecioExterno.Clear();
                txtSubTotalInterlocalidad.Clear();
                txtIGVInterlocalidad.Clear();
                txtTotalInterlocalidad.Clear();
                txtPromedioPersona.Clear();
                txtObservacionInterlocalidad.Clear();
                gbMovimientoInterlocalidad.Enabled = true;
                gbRegistroDocumento.Enabled = true;


                this.txtItemIda.Clear();
                this.txtItemRegreso.Clear();

                this.txtPrecioProcedenciaInterlocalidad.Clear();
                this.txtPrecioDestinoInterprocedencia.Clear();




                List<FormatoImportacionMovimientoRecorridoInterLocalidades> listaFormartoImportacion = new List<FormatoImportacionMovimientoRecorridoInterLocalidades>();
                //dgvListadoTrabajadores.CargarDatos(listaFormartoImportacion.ToDataTable<FormatoImportacionMovimientoRecorridoInterLocalidades>());
                dgvListadoTrabajadoresIngreso.DataSource = listaFormartoImportacion.ToDataTable<FormatoImportacionMovimientoRecorridoInterLocalidades>();
                dgvListadoTrabajadoresIngreso.Refresh();
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "\nLimpiar Movimiento de recorrido interlocalidad", "ADVERTENCIA DEL SISTEMA");
                return;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();



        }

        private void Editar()
        {
            /* PARA RECORRIDOS ENTRE LOCALIDADES EJM TUMAN - CHONGOYAPE Y VICIVERSA */
            if (criterio == "MTI")
            {
                #region
                if (this.txtIdEstadoInterlocalidad.Text.ToString().Trim() != "AN")
                {
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnAtras.Enabled = true;
                    btnExportar.Enabled = false;
                    btnHistorial.Enabled = true;
                    if (this.txtIdEstadoInterlocalidad.Text.ToString().Trim() == "PE")
                    {
                        btnImportar.Enabled = true;
                    }
                    else
                    {
                        btnImportar.Enabled = false;
                    }
                    btnSalir.Enabled = true;
                    //gbDestinoMovimiento.Enabled = true;
                    //gbMovimientoInterlocalidad.Enabled = false;
                    gbMovimientoInterno.Enabled = true;
                    gbProcedenciaMovimientoInterno.Enabled = true;
                    gbProcedenciaExterno.Enabled = true;
                    gbRegistroMovimientoExterno.Enabled = true;
                    gbRegistroRecorridoInterno.Enabled = false;
                    gbMovimientoInterlocalidad.Enabled = true;
                    gbTransportistaInformacion.Enabled = true;
                    ProgressBar.Visible = false;
                    tabRegistros.Enabled = true;
                    gbRegistroDocumento.Enabled = true;
                    gbRegistroPersonasExterno.Enabled = true;
                    btnBuscarMovilidad.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El documento no tiene el estado para la edición", "Mensaje del Sistema");
                }
                #endregion
            }


            /* PARA RECORRIDOS DENTROS DEL FUNDO OSEA RECORRIDOS INTERNOS O LOCALES */
            if (criterio == "MTL")
            {
                #region
                if (this.txtIdEstadoInterno.Text.ToString().Trim() != "AN")
                {
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnAnular.Enabled = false;
                    btnAtras.Enabled = true;
                    btnExportar.Enabled = false;
                    btnHistorial.Enabled = true;
                    if (this.txtIdEstadoInterno.Text.ToString().Trim() == "PE")
                    {
                        btnImportar.Enabled = true;
                    }
                    else
                    {
                        btnImportar.Enabled = false;
                    }

                    btnSalir.Enabled = true;
                    //gbDestinoMovimiento.Enabled = false;
                    gbMovimientoInterlocalidad.Enabled = false;
                    gbMovimientoInterno.Enabled = true;
                    gbProcedenciaMovimientoInterno.Enabled = true;
                    gbProcedenciaExterno.Enabled = true;
                    gbRegistroMovimientoExterno.Enabled = false;
                    gbRegistroRecorridoInterno.Enabled = false;
                    gbTransportistaInformacion.Enabled = false;
                    ProgressBar.Visible = false;
                    tabRegistros.Enabled = true;
                    gbRegistroDocumento.Enabled = true;
                    gbRegistroPersonasExterno.Enabled = true;


                }
                else
                {
                    MessageBox.Show("El documento no tiene el estado para la edición", "Mensaje del Sistema");
                }
                #endregion
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            /* PARA RECORRIDOS ENTRE LOCALIDADES EJM TUMAN - CHONGOYAPE Y VICIVERSA */
            if (criterio == "MTI")
            {
                if (this.txtIdEstadoInterlocalidad.Text.ToString().Trim() == "PE")
                {
                    this.txtIdEstadoInterlocalidad.Text = "AN";
                    this.txtEstadoInterLocalidad.Text = "ANULADO";

                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnAnular.Enabled = false;
                    btnAtras.Enabled = false;
                    btnExportar.Enabled = false;
                    btnHistorial.Enabled = false;
                    btnImportar.Enabled = false;
                    btnSalir.Enabled = true;

                    //gbDestinoMovimiento.Enabled = false;
                    gbMovimientoInterlocalidad.Enabled = false;
                    gbMovimientoInterno.Enabled = false;
                    gbProcedenciaMovimientoInterno.Enabled = false;
                    gbProcedenciaExterno.Enabled = false;
                    gbRegistroMovimientoExterno.Enabled = false;
                    gbRegistroRecorridoInterno.Enabled = false;
                    gbTransportistaInformacion.Enabled = false;
                    ProgressBar.Visible = false;
                    gbRegistroDocumento.Enabled = false;
                    tabRegistros.Enabled = false;
                    bgwHilo.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("El documento no tiene el estado para anular", "Mensaje del Sistema");
                }
            }


            /* PARA RECORRIDOS DENTROS DEL FUNDO OSEA RECORRIDOS INTERNOS O LOCALES */
            if (criterio == "MTL")
            {
                if (this.txtIdEstadoInterno.Text.ToString().Trim() == "PE")
                {
                    this.txtIdEstadoInterno.Text = "AN";
                    this.txtEstadoInterno.Text = "ANULADO";

                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnAnular.Enabled = false;
                    btnAtras.Enabled = false;
                    btnExportar.Enabled = false;
                    btnHistorial.Enabled = false;
                    btnImportar.Enabled = false;
                    btnSalir.Enabled = true;

                    //gbDestinoMovimiento.Enabled = false;
                    gbMovimientoInterlocalidad.Enabled = false;
                    gbMovimientoInterno.Enabled = false;
                    gbProcedenciaMovimientoInterno.Enabled = false;
                    gbProcedenciaExterno.Enabled = false;
                    gbRegistroMovimientoExterno.Enabled = false;
                    gbRegistroRecorridoInterno.Enabled = false;
                    gbTransportistaInformacion.Enabled = false;
                    ProgressBar.Visible = false;
                    gbRegistroDocumento.Enabled = false;
                    tabRegistros.Enabled = false;
                    bgwHilo.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("El documento no tiene el estado para anular", "Mensaje del Sistema");
                }
            }

            //this.btnNuevo.Enabled = true;
            //this.btnGrabar.Enabled = false;
            //this.btnEditar.Enabled = true;
            //this.btnExportar.Enabled = true;
            //this.btnHistorial.Enabled = true;
            //this.btnAnular.Enabled = false;
            //this.btnAtras.Enabled = false;
            //gbMovimientoInterlocalidad.Enabled = false;
            //gbRegistroDocumento.Enabled = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            switch (CodigoDocumento)
            {
                case "InterLocalidad":

                    break;
                case "Interno":

                    break;
                default:
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            if (this.txtIdEstadoInterlocalidad.Text.ToString().Trim() == "PE" | this.txtIdEstadoInterno.Text.ToString().Trim() == "PE")
            {
                #region
                switch (this.TabSelecionado.ToString().Trim().ToUpper())
                {
                    #region
                    case "INTERLOCALIDAD": /* Entre localidades */
                        if (ValidarFormularioExterno() == true)
                        {
                            #region habilitarDesabilitar controles para recorrido externo()
                            RegistrarMovimientoExterno();
                            ListaDetalleRecorridoInterno = new List<SJ_RHMovimientoMovilidadDetalle>();
                            ListaDetalleEliminados = new List<SJ_RHMovimientoMovilidadDetalle>();
                            ListaDetalleMovimientoAsistencia = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                            #endregion
                        }
                        else
                        {
                            RadMessageBox.Show(msg, "Atención");
                            return;
                        }

                        break;
                    case "INTERNO": /* dentro del fundo san juan */

                        if (ValidarFormularioInterno() == true)
                        {
                            #region habilitarDesabilitar controles para recorrido interno()
                            RegistrarMovimientoInterno();
                            ListaDetalleRecorridoInterno = new List<SJ_RHMovimientoMovilidadDetalle>();
                            ListaDetalleEliminados = new List<SJ_RHMovimientoMovilidadDetalle>();
                            ListaDetalleMovimientoAsistencia = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                            #endregion
                        }
                        else
                        {
                            RadMessageBox.Show(msg, "Atención");
                            return;
                        }

                        break;
                    default:
                        if (Documento != null && Documento.idDocumento == "MTI")
                        {
                            if (ValidarFormularioExterno() == true)
                            {
                                #region habilitarDesabilitar controles para recorrido externo()
                                RegistrarMovimientoExterno();
                                ListaDetalleRecorridoInterno = new List<SJ_RHMovimientoMovilidadDetalle>();
                                ListaDetalleEliminados = new List<SJ_RHMovimientoMovilidadDetalle>();
                                ListaDetalleMovimientoAsistencia = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                                #endregion
                            }
                            else
                            {
                                RadMessageBox.Show(msg, "Atención");
                                return;
                            }
                        }

                        if (Documento != null && Documento.idDocumento == "MTL")
                        {
                            if (ValidarFormularioInterno() == true)
                            {
                                #region habilitarDesabilitar controles para recorrido Interno()
                                RegistrarMovimientoInterno();
                                ListaDetalleRecorridoInterno = new List<SJ_RHMovimientoMovilidadDetalle>();
                                ListaDetalleEliminados = new List<SJ_RHMovimientoMovilidadDetalle>();
                                ListaDetalleMovimientoAsistencia = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                                #endregion
                            }
                            else
                            {
                                RadMessageBox.Show(msg, "Atención");
                                return;
                            }
                        }
                        break;
                        #endregion
                }

                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                btnAnular.Enabled = false;
                btnAtras.Enabled = false;
                btnExportar.Enabled = false;
                btnHistorial.Enabled = false;
                btnImportar.Enabled = false;
                btnSalir.Enabled = true;

                //gbDestinoMovimiento.Enabled = false;
                gbMovimientoInterlocalidad.Enabled = false;
                gbMovimientoInterno.Enabled = false;
                gbProcedenciaMovimientoInterno.Enabled = false;
                gbProcedenciaExterno.Enabled = false;
                gbRegistroMovimientoExterno.Enabled = false;
                gbRegistroRecorridoInterno.Enabled = false;
                gbTransportistaInformacion.Enabled = false;
                ProgressBar.Visible = false;
                gbRegistroDocumento.Enabled = false;
                tabRegistros.Enabled = false;
                bgwHilo.RunWorkerAsync();
                #endregion
            }
            else
            {
                RadMessageBox.Show("El documento no tiene el estado para grabar", "Atención");
                return;
            }
        }

        private bool ValidarFormularioInterno()
        {
            bool Estado = true;
            msg = string.Empty;
            control = new RadTextBox();

            if (txtNumeroDocumentoInterno.Text.ToString().Trim() == "")
            {
                Estado = false;
                msg += "El documento no tiene generado un numero de documento.\n";
                control = txtNumeroDocumentoInterno;
            }

            if (txtPlacaInterno.Text.ToString().Trim() == "")
            {
                Estado = false;
                msg += "Los datos de la Unidad móvil no son correctos. \n";
                control = txtPlacaInterno;
            }


            if (txtChofeDNIRecorridoInterno.Text.ToString().Trim() == "")
            {
                Estado = false;
                msg += "Los datos del conductor no son correctos. \n";
                control = txtChofeDNIRecorridoInterno;
            }

            if (this.txtNroPersonasRecorridoInterno.Text.ToString().Trim() == "" || this.txtNroPersonasRecorridoInterno.Text.ToString().Trim() == "0" || this.txtNroPersonasRecorridoInterno.Text.ToString().Trim() == "0.00")
            {
                Estado = false;
                msg += "Los datos del número de personas no son correctos. \n";
                control = txtNroPersonasRecorridoInterno;
            }


            return Estado;
        }

        private bool ValidarFormularioExterno()
        {
            bool Estado = true;
            msg = string.Empty;

            if (txtNumeroDocumentoExterno.Text.ToString().Trim() == "")
            {
                Estado = false;
                msg += "El documento no tiene generado un numero de documento.\n";
            }

            if (txtIdEstadoInterlocalidad.Text.ToString().Trim() == "")
            {
                Estado = false;
                msg += "El documento no tiene un estado valido.\n";
            }

            if (txtIdMovilRecorridoInterlocalidad.Text.ToString().Trim() == "")
            {
                Estado = false;
                msg += "Debe ingresar una móvilidad valida.\n";
            }

            if (rbtIdaVuelta.IsChecked)
            {
                if (txtCodigoRutaOrigen.Text.ToString().Trim() == "")
                {
                    Estado = false;
                    msg += "Debe ingresar una ruta origen valida.\n";
                }

                if (txtCodigoRutaDestino.Text.ToString().Trim() == "")
                {
                    Estado = false;
                    msg += "Debe ingresar una ruta destino.\n";
                }

                if (txtPrecioProcedenciaInterlocalidad.Text.ToString().Trim() == "")
                {
                    Estado = false;
                    msg += "La ruta de origen no tiene configurada un precio de ida valido.\n";
                }

                if (txtPrecioDestinoInterprocedencia.Text.ToString().Trim() == "")
                {
                    Estado = false;
                    msg += "La ruta de destino no tiene configurada un precio de ida valido.\n";
                }
            }

            if (rbtRecorridoOrigen.IsChecked)
            {
                if (txtCodigoRutaOrigen.Text.ToString().Trim() == "")
                {
                    Estado = false;
                    msg += "Debe ingresar una ruta origen valida.\n";
                }

                if (txtPrecioProcedenciaInterlocalidad.Text.ToString().Trim() == "")
                {
                    Estado = false;
                    msg += "La ruta de origen no tiene configurada un precio de ida valido.\n";
                }
            }

            if (rbtRecorridoDestino.IsChecked)
            {
                if (txtCodigoRutaDestino.Text.ToString().Trim() == "")
                {
                    Estado = false;
                    msg += "Debe ingresar una ruta destino.\n";
                }

                if (txtPrecioDestinoInterprocedencia.Text.ToString().Trim() == "")
                {
                    Estado = false;
                    msg += "La ruta de destino no tiene configurada un precio de ida valido.\n";
                }
            }

            if (txtNumeroPersonasInterlocalidad.Text.ToString().Trim() == "")
            {
                Estado = false;
                msg += "Debe ingresar un número de personas valido.\n";
            }

            if (txtPromedioPersona.Text.ToString().Trim() == "")
            {
                Estado = false;
                msg += "Debe ingresar un valor promedio de personas valido.\n";
            }

            return Estado;
        }

        private void RegistrarMovimientoExterno() /* Movimiento Recorrido Interlocalidad (Entre distritos) */
        {
            try
            {
                #region Obtener Objeto Local()
                MovimientoMovilidad = new SJ_RHMovimientoMovilidad();
                MovimientoMovilidad.Codigo = txtCodigoExterno.Text.ToString().Trim();

                if (rbtFlete.IsChecked == true)
                {
                    movimiento = "01";
                    MovimientoMovilidad.Movimiento = movimiento;
                    //MovimientoMovilidad.RegistroRecorrido = "01";
                }
                if (rbtNumeroPersonas.IsChecked == true)
                {
                    movimiento = "02";
                    // MovimientoMovilidad.RegistroRecorrido = "02";
                    MovimientoMovilidad.Movimiento = movimiento;
                }

                MovimientoMovilidad.IdTransportista = txtIdMovilRecorridoInterlocalidad.Text.ToString().Trim() != "" ? Convert.ToInt32(txtIdMovilRecorridoInterlocalidad.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.IdDocumento = cboIdDocumentoExterno.SelectedValue != null ? cboIdDocumentoExterno.SelectedValue.ToString().Trim() : "MTI";
                MovimientoMovilidad.Serie = cboIdSerieExterno.SelectedValue.ToString().Trim();
                MovimientoMovilidad.Numero = txtNumeroDocumentoExterno.Text.ToString().Trim();
                MovimientoMovilidad.Fecha = txtFechaMovimientoRecorridoInterLocalidad.Text.ToString().Trim() != "" ? Convert.ToDateTime(txtFechaMovimientoRecorridoInterLocalidad.Text.ToString().Trim()) : (DateTime?)null;
                MovimientoMovilidad.NumeroManual = txtNumeroManualExterno.Text.ToString().Trim();
                MovimientoMovilidad.IdEstado = txtIdEstadoInterlocalidad.Text.ToString().Trim();

                /*el registro del movimiento quiere decir si es de ida si es vuelta o ida y vuelta*/
                if (rbtIdaVuelta.IsChecked == true)
                {
                    MovimientoMovilidad.RegistroRecorrido = "01";
                }
                if (rbtRecorridoOrigen.IsChecked == true)
                {
                    MovimientoMovilidad.RegistroRecorrido = "02";
                }
                if (rbtRecorridoDestino.IsChecked == true)
                {
                    MovimientoMovilidad.RegistroRecorrido = "03";
                }

                MovimientoMovilidad.IdRutaOrigen = txtCodigoRutaOrigen.Text.ToString().Trim() != "" ? Convert.ToInt32(txtCodigoRutaOrigen.Text.ToString().Trim()) : (int?)null;
                MovimientoMovilidad.IdRutaDestino = txtCodigoRutaDestino.Text.ToString().Trim() != "" ? Convert.ToInt32(txtCodigoRutaDestino.Text.ToString().Trim()) : (int?)null;
                MovimientoMovilidad.NumeroPersonas = txtNumeroPersonasInterlocalidad.Text.ToString().Trim() != "" ? Convert.ToInt32(txtNumeroPersonasInterlocalidad.Text.ToString().Trim()) : (int?)null;
                MovimientoMovilidad.PromedioxPersona = txtPromedioPersona.Text.ToString().Trim() != "" ? Convert.ToDecimal(txtPromedioPersona.Text.ToString().Trim()) : (decimal?)null;
                MovimientoMovilidad.Precio = txtPrecioExterno.Text.ToString().Trim() != "" ? Convert.ToDecimal(txtPrecioExterno.Text.ToString().Trim()) : (decimal?)null;
                MovimientoMovilidad.SubTotal = txtSubTotalInterlocalidad.Text.ToString().Trim() != "" ? Convert.ToDecimal(txtSubTotalInterlocalidad.Text.ToString().Trim()) : (decimal?)null;
                MovimientoMovilidad.IGV = txtIGVInterlocalidad.Text.ToString().Trim() != "" ? Convert.ToDecimal(txtIGVInterlocalidad.Text.ToString().Trim()) : (decimal?)null;
                MovimientoMovilidad.Total = txtTotalInterlocalidad.Text.ToString().Trim() != "" ? Convert.ToDecimal(txtTotalInterlocalidad.Text.ToString().Trim()) : (decimal?)null;
                MovimientoMovilidad.Observacion = txtObservacionInterlocalidad.Text.ToString().Trim();
                MovimientoMovilidad.IdChofer = txtChoferCodigoRecorridoInterLocalidad.Text.ToString().Trim() != "" ? Convert.ToInt32(txtChoferCodigoRecorridoInterLocalidad.Text) : (int?)null;

                MovimientoMovilidad.itemRecorridoIda = this.txtItemIda.Text.ToString().Trim();
                MovimientoMovilidad.itemRecorridoRegreso = this.txtItemRegreso.Text.ToString().Trim();

                MovimientoMovilidad.precioIda = this.txtPrecioProcedenciaInterlocalidad.Text != "" ? Convert.ToDecimal(this.txtPrecioProcedenciaInterlocalidad.Text) : 0;
                MovimientoMovilidad.precioRegreso = this.txtPrecioDestinoInterprocedencia.Text != "" ? Convert.ToDecimal(this.txtPrecioDestinoInterprocedencia.Text) : 0;


                campoDestino = cboDestinoMovimientos.SelectedValue.ToString().Trim();
                MovimientoMovilidad.CampoDestino = campoDestino;


                ListaDetalleRecorridoInterno = new List<SJ_RHMovimientoMovilidadDetalle>();
                // registro detalle de ingreso de personal - IDA

                listadoPersonalIngresoByBus = new List<SJ_RHMovimientoMovilidadAsistenciaTrabajador>();

                if (dgvListadoTrabajadoresIngreso != null)
                {
                    if (dgvListadoTrabajadoresIngreso.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow fila in dgvListadoTrabajadoresIngreso.Rows)
                        {
                            SJ_RHMovimientoMovilidadAsistenciaTrabajador oIngreso = new SJ_RHMovimientoMovilidadAsistenciaTrabajador();
                            oIngreso.codigoMovimientoMovilidad = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            oIngreso.item = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            oIngreso.idCodigoGeneral = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            oIngreso.nroDocumento = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            oIngreso.nombresCompletos = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            oIngreso.subPlanilla = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            //oIngreso.fechaRegistro = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            //oIngreso.idconsumidor = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            //oIngreso.idParadero = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            //oIngreso.paradero = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            //oIngreso.tipoAsistencia = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            //oIngreso.hora = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            //oIngreso.idRegistroMovil = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            //oIngreso.estado = fila.Cells[""].Value != null ? fila.Cells[""].Value.ToString().Trim() : string.Empty;
                            listadoPersonalIngresoByBus.Add(oIngreso);
                        }
                    }
                }
                // registro detalle de salida de personal -- SALIDA


                movimientoRecorridosNegocio = new MovimientoMovilidadNegocio();
                this.CodigoDocumento = movimientoRecorridosNegocio.RegistrarMovimiento(MovimientoMovilidad, ListaDetalleRecorridoInterno, ListaDetalleEliminados, ListaDetalleAsistencia);
                periodo = txtFechaMovimientoRecorridoInterLocalidad.Text.ToString().Trim();
                TabSelecionado = "INTERLOCALIDAD";
                this.txtCodigoExterno.Text = this.CodigoDocumento;
                RadMessageBox.Show("Registrado Correctamente", "Mensaje Sistema");


                //CargarDocumento();
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void RegistrarMovimientoInterno()
        {
            try
            {
                #region Obtener Objeto Interno()
                MovimientoMovilidad = new SJ_RHMovimientoMovilidad();
                MovimientoMovilidad.Codigo = txtCodigoInterno.Text.ToString().Trim();
                //MovimientoMovilidad.Movimiento = "";
                MovimientoMovilidad.IdTransportista = txtIdMovilInterno.Text.ToString().Trim() != "" ? Convert.ToInt32(txtIdMovilInterno.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.IdDocumento = cboIdDocumentoInterno.SelectedValue.ToString().Trim();
                MovimientoMovilidad.Serie = cboIdSerieInterno.SelectedValue.ToString().Trim();
                MovimientoMovilidad.Numero = txtNumeroDocumentoInterno.Text.ToString().Trim();
                MovimientoMovilidad.Fecha = txtFechaMovimientoInterno.Text.ToString().Trim() != "" ? Convert.ToDateTime(txtFechaMovimientoInterno.Text.ToString().Trim()) : (DateTime?)null;
                MovimientoMovilidad.NumeroManual = txtNumeroManualInterno.Text.ToString().Trim();
                MovimientoMovilidad.IdEstado = txtIdEstadoInterno.Text.ToString().Trim();
                MovimientoMovilidad.Movimiento = "03";
                if (rbtIdaVueltaInterno.IsChecked == true)
                {
                    //MovimientoMovilidad.RegistroRecorrido = "01";
                }
                else
                {
                    // MovimientoMovilidad.RegistroRecorrido = "01";
                }
                if (rbtIdaInterno.IsChecked == true)
                {
                    //MovimientoMovilidad.RegistroRecorrido = "02";
                }
                if (rbtVueltaInterno.IsChecked == true)
                {
                    MovimientoMovilidad.RegistroRecorrido = "03";
                }
                else
                {
                    MovimientoMovilidad.RegistroRecorrido = "03";
                }

                MovimientoMovilidad.IdRutaOrigen = 15;
                MovimientoMovilidad.IdRutaDestino = 15;
                MovimientoMovilidad.NumeroPersonas = (this.txtNroPersonasRecorridoInterno.Text.ToString().Trim() != "" || this.txtNroPersonasRecorridoInterno.Text.ToString().Trim() != "0.00") ? Convert.ToInt32(this.txtNroPersonasRecorridoInterno.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.PromedioxPersona = this.txtPrecioPersonaPromedioRecorridoInterno.Text.ToString().Trim() != "" ? Convert.ToDecimal(this.txtPrecioPersonaPromedioRecorridoInterno.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.Precio = this.txtPrecioVuelta.Text != "" ? Convert.ToDecimal(this.txtPrecioVuelta.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.SubTotal = this.txtSubTotalRecorridoInterno.Text.ToString().Trim() != "" ? Convert.ToDecimal(this.txtSubTotalRecorridoInterno.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.IGV = this.txtIGVRecorridoInterno.Text.ToString().Trim() != "" ? Convert.ToDecimal(this.txtIGVRecorridoInterno.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.Total = this.txtTotalRecorridoInterno.Text != "" ? Convert.ToDecimal(this.txtTotalRecorridoInterno.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.Observacion = "";
                MovimientoMovilidad.IdChofer = this.txtChoferCodigoRecorridoInterno.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtChoferCodigoRecorridoInterno.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.CampoDestino = "001";

                MovimientoMovilidad.itemRecorridoIda = txtItemRecorridoInterno.Text.ToString().Trim();
                MovimientoMovilidad.itemRecorridoRegreso = "";
                MovimientoMovilidad.precioIda = txtPrecioVuelta.Text.ToString().Trim() != "" ? Convert.ToDecimal(txtPrecioVuelta.Text.ToString().Trim()) : 0;
                MovimientoMovilidad.precioRegreso = 0;


                movimientoRecorridosNegocio = new MovimientoMovilidadNegocio();

                ObtenerListaObjetoInternoDetalle();

                this.CodigoDocumento = movimientoRecorridosNegocio.RegistrarMovimiento(MovimientoMovilidad, ListaDetalleRecorridoInterno, ListaDetalleEliminados, ListaDetalleMovimientoAsistencia);
                periodo = txtFechaMovimientoRecorridoInterLocalidad.Text.ToString().Trim();
                this.txtCodigoInterno.Text = this.CodigoDocumento;
                TabSelecionado = "INTERNO";

                RadMessageBox.Show("Registrado Correctamente", "Mensaje Sistema");
                // CargarDocumento();
                #endregion
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }

        private void ObtenerListaObjetoInternoDetalle()
        {
            ListaDetalleRecorridoInterno = new List<SJ_RHMovimientoMovilidadDetalle>();

            if (dgvRecorridosInternos != null)
            {
                if (dgvRecorridosInternos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow fila in dgvRecorridosInternos.Rows)
                    {
                        SJ_RHMovimientoMovilidadDetalle detalle = new SJ_RHMovimientoMovilidadDetalle();
                        detalle.Codigo = this.txtCodigoInterno.Text.ToString().Trim();
                        detalle.item = fila.Cells["chItem"].Value != null ? fila.Cells["chItem"].Value.ToString().Trim() : "";
                        detalle.IdConsumidor = fila.Cells["chIdModulo"].Value != null ? fila.Cells["chIdModulo"].Value.ToString().Trim() : "";
                        detalle.consumidor = fila.Cells["chModulo"].Value != null ? fila.Cells["chModulo"].Value.ToString().Trim() : "";
                        detalle.horaSalida = fila.Cells["chHoraSalida"].Value != null ? fila.Cells["chHoraSalida"].Value.ToString().Trim() : "";
                        detalle.horaRegreso = fila.Cells["chHoraRetorno"].Value != null ? fila.Cells["chHoraRetorno"].Value.ToString().Trim() : "";
                        detalle.Precio = fila.Cells["chPrecio"].Value != null ? Convert.ToDecimal(fila.Cells["chPrecio"].Value.ToString().Trim()) : 0;
                        ListaDetalleRecorridoInterno.Add(detalle);
                    }
                }
            }


        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                Historial ofrm = new Historial(this.CodigoDocumento.ToString().Trim(), "0", "SJ_RHMovimientoMovilidad");
                ofrm.Text = "Historial del Registros";
                ofrm.ShowDialog();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Cancelar();

        }

        private void Cancelar()
        {
            try
            {
                #region Cancelar()

                btnNuevo.Enabled = false;
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnAnular.Enabled = false;
                btnAtras.Enabled = false;
                btnExportar.Enabled = false;
                btnHistorial.Enabled = false;
                btnImportar.Enabled = false;
                btnSalir.Enabled = true;

                //gbDestinoMovimiento.Enabled = false;
                gbMovimientoInterlocalidad.Enabled = false;
                gbMovimientoInterno.Enabled = false;
                gbProcedenciaMovimientoInterno.Enabled = false;
                gbProcedenciaExterno.Enabled = false;
                gbRegistroMovimientoExterno.Enabled = false;
                gbRegistroRecorridoInterno.Enabled = false;
                gbTransportistaInformacion.Enabled = false;
                ProgressBar.Visible = false;
                tabRegistros.Enabled = false;
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void gbMovimientoInterno_Click(object sender, EventArgs e)
        {

        }

        private void btnChoferBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaBusquedadChofer = this.txtFechaMovimientoInterno.Text.ToString().Trim() != "" ? Convert.ToDateTime(this.txtFechaMovimientoInterno.Text.ToString().Trim()) : DateTime.Now;
                //ChoferBuscar ofrm = new ChoferBuscar(txtIdMovilInterno.Text.ToString().Trim(), fechaBusquedadChofer.Year.ToString());
                ChoferBuscar ofrm = new ChoferBuscar(txtRUCInterno.Text.ToString().Trim(), fechaBusquedadChofer.Year.ToString());
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    #region
                    if (ofrm.Chofer != null)
                    {
                        if (ofrm.Chofer.Id > 0)
                        {
                            this.txtChofeDNIRecorridoInterno.Text = ofrm.Chofer.DNI.ToString().Trim();
                            this.txtChoferNombresRecorridoInterno.Text = ofrm.Chofer.Nombres.ToString().Trim();
                            this.txtChoferCodigoRecorridoInterno.Text = ofrm.Chofer.Id.ToString().Trim();
                        }
                        else
                        {
                            this.txtChofeDNIRecorridoInterno.Text = "";
                            this.txtChoferNombresRecorridoInterno.Text = "";
                        }
                    }
                    else
                    {
                        this.txtChofeDNIRecorridoInterno.Text = "";
                        this.txtChoferNombresRecorridoInterno.Text = "";
                    }
                    #endregion
                }
                else
                {
                    #region
                    this.txtChofeDNIRecorridoInterno.Text = "";
                    this.txtChoferNombresRecorridoInterno.Text = "";
                    #endregion
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "\n.Buscar al Chofer - Recorrido Interno", "ADVERTENCIA DEL SISTEMA");
                return;
            }



        }

        private void txtPlacaInterno_Leave(object sender, EventArgs e)
        {
            if (txtPlacaInterno.Text.ToString().Trim() != "")
            {
                btnChoferBuscar.Enabled = true;
            }
            else
            {
                btnChoferBuscar.Enabled = false;
            }
        }

        private void btnAgregarRecorrido_Click(object sender, EventArgs e)
        {
            switch (this.TabSelecionado.ToUpper())
            {
                #region
                case "INTERLOCALIDAD":
                    if (ValidarFormularioExterno() == true)
                    {

                    }
                    else
                    {
                        RadMessageBox.Show(msg, "Atención");

                    }

                    break;
                case "INTERNO":

                    if (ValidarFormularioInterno() == true)
                    {
                        AgregarLinea();
                    }
                    else
                    {
                        RadMessageBox.Show(msg.ToString(), "Atención");
                        control.Focus();
                    }

                    break;
                default:
                    if (Documento != null && Documento.idDocumento == "MTI")
                    {
                        // externo
                        if (ValidarFormularioExterno() == true)
                        {

                        }
                        else
                        {
                            RadMessageBox.Show(msg, "Atención");
                        }
                    }
                    if (Documento != null && Documento.idDocumento == "MTL")
                    {
                        // Interno
                        if (ValidarFormularioInterno() == true)
                        {
                            AgregarLinea();
                        }
                        else
                        {
                            RadMessageBox.Show(msg, "Atención");
                            control.Focus();
                        }
                    }
                    break;
                    #endregion
            }
        }

        private void AgregarLinea()
        {
            try
            {
                if (this.dgvRecorridosInternos != null)
                {
                    System.Collections.ArrayList array = new System.Collections.ArrayList();
                    array.Add(this.txtCodigoInterno.Text.ToString().Trim()); // Codigo Cabecera                  
                    array.Add((AsignarNumeroItemsGrilla(ObtenerUltimoNumeroItem(dgvRecorridosInternos)))); // item
                    array.Add(string.Empty); // idModulo       
                    array.Add(string.Empty); // Modulo
                    array.Add("00:00"); // horaSalida
                    array.Add("00:00"); // horaRegreso                                                          
                    array.Add(this.txtPrecioVuelta.Text); // precio vuelta
                    this.dgvRecorridosInternos.AgregarFila(array);
                    precioVueltaAcumulado = precioVueltaAcumulado + Convert.ToDecimal(this.txtPrecioVuelta.Text);
                    decimal? IGV, Total, SubTotal = 0;
                    int CantidadPersona = 0;
                    CantidadPersona = this.txtNroPersonasRecorridoInterno.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtNroPersonasRecorridoInterno.Text.ToString().Trim()) : 0;
                    SubTotal = precioVueltaAcumulado;
                    IGV = (precioVueltaAcumulado * Convert.ToDecimal(0.18));
                    Total = SubTotal + IGV;
                    PromedioPersonal = (CantidadPersona != null || CantidadPersona != 0) ? SubTotal / CantidadPersona : 0;
                    this.txtNumeroViajesRecorridoInterno.Text = dgvRecorridosInternos.Rows.Count.ToString();
                    this.txtSubTotalRecorridoInterno.Text = precioVueltaAcumulado.ToDecimalPresentation();
                    this.txtTotalRecorridoInterno.Text = Total.Value.ToDecimalPresentation();
                    this.txtIGVRecorridoInterno.Text = IGV.Value.ToDecimalPresentation();
                    this.txtPrecioPersonaPromedioRecorridoInterno.Text = PromedioPersonal.Value.ToDecimalPresentation();
                }
                else
                {
                    Formateador.MostrarMensajeAdvertencia(this, "Haga click en la Grilla a Modificar", "Validacion Ingreso de Datos");
                }
            }
            catch (Exception ex)
            {
                Formateador.ControlExcepcion(this, this.Name, ex);
            }

        }

        private void QuitarLinea()
        {
            if (dgvRecorridosInternos != null)
            {
                if (dgvRecorridosInternos.Rows.Count > 0)
                {
                    if (this.dgvRecorridosInternos.CurrentRow != null)
                    {
                        try
                        {
                            string codigoParte, nroItemDetalle = "";
                            codigoParte = (this.dgvRecorridosInternos.CurrentRow.Cells["chCodDocumento"].Value != null ? Convert.ToString(this.dgvRecorridosInternos.CurrentRow.Cells["chCodDocumento"].Value) : "");
                            nroItemDetalle = (this.dgvRecorridosInternos.CurrentRow.Cells["chItem"].Value != null ? Convert.ToString(this.dgvRecorridosInternos.CurrentRow.Cells["chItem"].Value) : "");

                            if (codigoParte != "")
                            {
                                if (nroItemDetalle != "")
                                {

                                    ListaDetalleEliminados.Add(new SJ_RHMovimientoMovilidadDetalle
                                    {
                                        Codigo = codigoParte,
                                        item = nroItemDetalle,
                                    });
                                    precioVueltaAcumulado = precioVueltaAcumulado - Convert.ToDecimal(this.txtPrecioVuelta.Text);
                                    decimal? IGV, Total, SubTotal = 0;
                                    int CantidadPersona = 0;
                                    CantidadPersona = this.txtNroPersonasRecorridoInterno.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtNroPersonasRecorridoInterno.Text.ToString().Trim()) : 0;

                                    SubTotal = precioVueltaAcumulado;
                                    IGV = (precioVueltaAcumulado * Convert.ToDecimal(0.18));
                                    Total = SubTotal + IGV;
                                    PromedioPersonal = (CantidadPersona != null || CantidadPersona != 0) ? SubTotal / CantidadPersona : 0;


                                    this.txtSubTotalRecorridoInterno.Text = precioVueltaAcumulado.ToDecimalPresentation();
                                    this.txtTotalRecorridoInterno.Text = Total.Value.ToDecimalPresentation();
                                    this.txtIGVRecorridoInterno.Text = IGV.Value.ToDecimalPresentation();
                                    this.txtPrecioPersonaPromedioRecorridoInterno.Text = PromedioPersonal.Value.ToDecimalPresentation();


                                }
                            }

                            dgvRecorridosInternos.Rows.Remove(dgvRecorridosInternos.CurrentRow);
                            this.txtTotalRecorridoInterno.Text = precioVueltaAcumulado.ToDecimalPresentation();
                            this.txtNumeroViajesRecorridoInterno.Text = dgvRecorridosInternos.Rows.Count.ToString(); /*RESTAR EL NUMERO DE VIAJES*/


                        }
                        catch (Exception Ex)
                        {

                            Ex.Message.ToString();
                        }
                    }

                }
            }

        }

        private int ObtenerUltimoNumeroItem(MyDataGridViewDetails grilla)
        {
            List<int> Items = new List<int>();
            if (grilla.Rows.Count > 0)
            {

                foreach (DataGridViewRow filas in grilla.Rows)
                {
                    /* agrego la columna 1, por que en ambos caso la filla items esta situada en la colunmna 1*/
                    Items.Add((filas.Cells[1].Value) != null ? Convert.ToInt32(filas.Cells[1].Value) : 0);
                }
            }
            else
            {
                Items.Add(0);
            }

            return Items.Max();

        }

        private string AsignarNumeroItemsGrilla(int numeroRegistros)
        {
            #region
            string item = "";
            numeroRegistros += 1;

            switch (numeroRegistros.ToString().Length)
            {
                case 1:
                    item = "00" + numeroRegistros.ToString();
                    break;

                case 2:
                    item = "0" + numeroRegistros.ToString();
                    break;

                case 3:
                    item = numeroRegistros.ToString();
                    break;

                default:
                    item = "";
                    break;
            }


            return item;
            #endregion
        }

        private void btnQuitarRecorrido_Click(object sender, EventArgs e)
        {
            QuitarLinea();
        }

        private void dgvRecorrido_KeyUp(object sender, KeyEventArgs e)
        {
            if (((DataGridView)sender).RowCount > 0)
            {
                #region
                if (((DataGridView)sender).CurrentCell.OwningColumn.Name == "chIdModulo")
                {
                    if (e.KeyCode == Keys.F3)
                    {
                        frmBusquedaFormatoSimple busquedas = new frmBusquedaFormatoSimple();

                        documentoNeg = new DocumentoNegocio();
                        ListaCampos = new List<DFormatoSimple>();
                        ListaCampos = documentoNeg.ListaCamposAgricolas().ToList();
                        busquedas.ListaGeneralResultado = ListaCampos;
                        busquedas.Text = "Buscar consumidor";
                        busquedas.txtTextoFiltro.Text = "";
                        if (busquedas.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            //idRetorno = busquedas.ObjetoRetorno.Codigo;
                            this.dgvRecorridosInternos.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chIdModulo"].Value = busquedas.ObjetoRetorno.Codigo;
                            this.dgvRecorridosInternos.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chModulo"].Value = busquedas.ObjetoRetorno.Descripcion;
                        }
                    }
                }
                #endregion
            }
        }

        private void dgvRecorrido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            documentoNeg = new DocumentoNegocio();
            if (((DataGridView)sender).RowCount > 0)
            {
                if (((DataGridView)sender).CurrentCell.OwningColumn.Name == "chIdModulo")
                {
                    //frmBusquedaFormatoSimple busquedas = new frmBusquedaFormatoSimple();
                    //busquedas.ListaGeneralResultado = negocio.;
                    //busquedas.Text = "Buscar Rutas";
                    //busquedas.txtTextoFiltro.Text = "";
                    //if (busquedas.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    //{
                    //idRetorno = busquedas.ObjetoRetorno.Codigo;
                    //this.dgvRegistros.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chDniTrabajador"].Value = busquedas.ObjetoRetorno.Codigo;
                    string descripcion = documentoNeg.ObtenerNombreCamposAgricola(this.dgvRecorridosInternos.CurrentRow.Cells["chIdModulo"].Value.ToString()).ToString();
                    this.dgvRecorridosInternos.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chModulo"].Value = descripcion;
                    //}                    
                }
            }
        }

        private void rbtUvaSJ_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void rbtUcupe_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void rbtOtrosCampos_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void btnChoferBuscarRecorridoInterlocadlidad_Click(object sender, EventArgs e)
        {
            try
            {
                #region Buscar chofer()
                ChoferBuscar ofrm = new ChoferBuscar(this.txtRUCInterlocalidad.Text.ToString().Trim(), Convert.ToDateTime(this.txtFechaMovimientoRecorridoInterLocalidad.Text.ToString().Trim()).Year.ToString());
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    if (ofrm.Chofer != null)
                    {
                        if (ofrm.Chofer.Id > 0)
                        {
                            this.txtChofeDNIRecorridoInterlocalidad.Text = ofrm.Chofer.DNI.ToString().Trim();
                            this.txtChoferNombresRecorridoInterLocalidad.Text = ofrm.Chofer.Nombres.ToString().Trim();
                            this.txtChoferCodigoRecorridoInterLocalidad.Text = ofrm.Chofer.Id.ToString().Trim();
                        }
                        else
                        {
                            this.txtChofeDNIRecorridoInterlocalidad.Text = "";
                            this.txtChoferNombresRecorridoInterLocalidad.Text = "";
                        }
                    }
                    else
                    {
                        this.txtChofeDNIRecorridoInterlocalidad.Text = "";
                        this.txtChoferNombresRecorridoInterLocalidad.Text = "";
                    }
                }
                else
                {
                    this.txtChofeDNIRecorridoInterlocalidad.Text = "";
                    this.txtChoferNombresRecorridoInterLocalidad.Text = "";
                }
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void txtNumeroManualExterno_Leave(object sender, EventArgs e)
        {
            this.txtNumeroManualExterno.Text = this.txtNumeroManualExterno.Text.Trim();

            if (this.txtNumeroManualExterno.Text.Trim().Length < 7)
            {
                this.txtNumeroManualExterno.Text = this.txtNumeroManualExterno.Text.PadLeft(7, '0');
            }
        }

        private void txtNumeroManualInterno_Leave(object sender, EventArgs e)
        {
            this.txtNumeroManualInterno.Text = this.txtNumeroManualInterno.Text.Trim();

            if (this.txtNumeroManualInterno.Text.Trim().Length < 7)
            {
                this.txtNumeroManualInterno.Text = this.txtNumeroManualExterno.Text.PadLeft(7, '0');
            }
        }

        private void gbRegistroMovimientoExterno_Click(object sender, EventArgs e)
        {


        }

        private void gbDestinoMovimiento_Click(object sender, EventArgs e)
        {

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (VerificarControlesProcedencia() == true)
            {
                CargarDocumentoExcel();
            }
            else
            {
                MessageBox.Show(mensajeControlProcedencia, "Advertencia del Sistema");
            }

        }

        private void CargarDocumentoExcel()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
                //solo los archivos excel
                dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana
                dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo
                //si al seleccionar el archivo damos Ok
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //el nombre del archivo sera asignado al textbox
                    rutaArchivoListaTrabajadores = dialog.FileName;
                    hoja = "Hoja1"; //la variable hoja tendra el valor del textbox donde colocamos el nombre de la hoja
                    LLenarGrid(rutaArchivoListaTrabajadores, hoja); //se manda a llamar al metodo

                    //dgvListadoTrabajadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //se ajustan las
                    txtNumeroPersonasInterlocalidad.Text = dgvListadoTrabajadoresIngreso != null && dgvListadoTrabajadoresIngreso.Rows.Count > 0 ? dgvListadoTrabajadoresIngreso.Rows.Count.ToString() : "";
                    //columnas al ancho del DataGridview para que no quede espacio en blanco (opcional)
                    RealizarCalculo();
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void LLenarGrid(string rutaArchivo, string hoja)
        {
            //declaramos las variables         
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [" + hoja + "$]";

            //esta cadena es para archivos excel 2007 y 2010
            //string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + rutaArchivoListaTrabajadores + "';Extended Properties=Excel 12.0; Xml;HDR=YES";


            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0; Data Source ='" + rutaArchivoListaTrabajadores + "'; Extended Properties =\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";

            // string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.16.0;Data Source='" + @rutaArchivoListaTrabajadores + "';Extended Properties=Excel 16.0; Xml;HDR=YES";

            //string cadenaConexionArchivoExcel =    @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            //@"Data Source=" + rutaArchivoListaTrabajadores + ";" +
            //@"Extended Properties=" + Convert.ToChar(34).ToString() +
            //@"Excel 8.0" + Convert.ToChar(34).ToString() + ";";

            //para archivos de 97-2003 usar la siguiente cadena
            //string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + rutaArchivoListaTrabajadores + "';Extended Properties=Excel 8.0;";

            //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("No hay una hoja para leer");
            }
            else
            {
                try
                {
                    //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    conexion.Open(); //abrimos la conexion
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                    dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                    dataAdapter.Fill(dataSet, hoja);//llenamos el dataset

                    ListaDetalleAsistencia = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();

                    DataTable tablaResultado = new DataTable();
                    tablaResultado = dataSet.Tables[0];

                    foreach (DataRow item in tablaResultado.Rows)
                    {
                        SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult asistenciaPersonal = new SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult();
                        asistenciaPersonal.codigoMovimientoMovilidad = this.CodigoDocumento;
                        foreach (DataColumn dc in tablaResultado.Columns)
                        {
                            if (dc.ColumnName == "item")
                            {
                                asistenciaPersonal.item = item[dc].ToString();
                            }

                            if (dc.ColumnName == "idcodigoGeneral")
                            {
                                asistenciaPersonal.idCodigoGeneral = item[dc].ToString();
                            }

                            if (dc.ColumnName == "nroDocumento")
                            {
                                asistenciaPersonal.nroDocumento = item[dc].ToString();
                            }

                            if (dc.ColumnName == "nombresCompletos")
                            {
                                asistenciaPersonal.nombresCompletos = item[dc].ToString();
                            }


                            if (dc.ColumnName == "subplanilla")
                            {
                                asistenciaPersonal.subPlanilla = item[dc].ToString();
                            }

                            if (dc.ColumnName == "idConsumidor")
                            {
                                asistenciaPersonal.subPlanilla = item[dc].ToString();
                            }

                            if (dc.ColumnName == "hora")
                            {
                                asistenciaPersonal.hora = item[dc].ToString();
                            }

                        }
                        ListaDetalleAsistencia.Add(asistenciaPersonal);
                        //asistenciaPersonal.item = item.Table.Rows[item.]
                    }



                    ActualizarListaAsistencia();

                    //dgvListadoTrabajadores.DataSource = dataSet.Tables[0]; //le asignamos al DataGridView el contenido del dataSet
                    conexion.Close();//cerramos la conexion
                    dgvListadoTrabajadoresIngreso.AllowUserToAddRows = false;       //eliminamos la ultima fila del datagridview que se autoagrega
                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    //MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
                    MessageBox.Show(ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                    return;
                }
            }
        }

        private bool VerificarControlesProcedencia()
        {
            mensajeControlProcedencia = string.Empty;
            bool estadoControl = false;

            /* PARA EL CASO DE SELECIONAR LA OPCION OSEA EL RADIO BUTON RECORRIDO IDA Y VUELTA VERIFICO QUE TENGA INGRESADO UNA RUTA DE ORIGEN Y DESTINO */
            if (rbtIdaVuelta.IsChecked == true)
            {
                if (txtCodigoRutaOrigen.Text.ToString().Trim() != "" && txtCodigoRutaDestino.Text.ToString().Trim() != "")
                {
                    estadoControl = true;
                }
                else
                {
                    mensajeControlProcedencia += "Se debe ingresar una ruta origen y destino correctamente";
                }

            }

            if (rbtRecorridoOrigen.IsChecked == true)
            {
                if (txtCodigoRutaOrigen.Text.ToString().Trim() != "")
                {
                    estadoControl = true;
                }
                else
                {
                    mensajeControlProcedencia += "Se debe ingresar una ruta origen correctamente";
                }
            }

            if (rbtRecorridoDestino.IsChecked == true)
            {
                if (txtCodigoRutaDestino.Text.ToString().Trim() != "")
                {
                    estadoControl = true;
                }
                else
                {
                    mensajeControlProcedencia += "Se debe ingresar una ruta destino correctamente";
                }
            }

            return estadoControl;
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarDatos();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            //CargarDatosIniciales();
            EjecutarConsultar();

        }

        private void PresentarDatos()
        {

            try
            {
                if (this.CodigoDocumento != "")
                {
                    #region Obtener Documento

                    CodigoDocumento = Documento.Codigo != null ? Documento.Codigo.ToString().Trim() : "";
                    /* PARA RECORRIDOS ENTRE LOCALIDADES EJM TUMAN - CHONGOYAPE Y VICIVERSA */
                    if (Documento.idDocumento == "MTI")
                    {
                        PresentarControlesTransporteExterno();
                        //gbProcedenciaExterno.Enabled = true;
                        //gbRegistroMovimientoExterno.Enabled = true;
                        //gbRegistroPersonasExterno.Enabled = true;
                        //gbTransportistaInformacion.Enabled = false;

                    }
                    /* PARA RECORRIDOS DENTROS DEL FUNDO OSEA RECORRIDOS INTERNOS */
                    if (Documento.idDocumento == "MTL")
                    {
                        PresentarControlesTransporteInterno();
                        //gbProcedenciaExterno.Enabled = true;
                        //gbRegistroMovimientoExterno.Enabled = true;
                        //gbRegistroPersonasExterno.Enabled = true;
                        //gbTransportistaInformacion.Enabled = true;
                    }
                    #endregion
                }
                else
                {
                    LimpiaMovimientoInterlocal();
                    LimpiarMovimientoInterno();
                }

                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnAnular.Enabled = false;
                btnAtras.Enabled = false;
                btnExportar.Enabled = false;
                btnHistorial.Enabled = true;
                btnImportar.Enabled = false;
                btnSalir.Enabled = true;

                //gbDestinoMovimiento.Enabled = false;
                gbMovimientoInterlocalidad.Enabled = false;
                gbMovimientoInterno.Enabled = false;
                gbProcedenciaMovimientoInterno.Enabled = false;
                gbProcedenciaExterno.Enabled = false;
                gbRegistroMovimientoExterno.Enabled = false;
                gbRegistroRecorridoInterno.Enabled = false;
                gbTransportistaInformacion.Enabled = false;
                ProgressBar.Visible = false;
                gbRegistroPersonasExterno.Enabled = false;
                tabRegistros.Enabled = false;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Mensaje del sistema");
                return;
            }






        }

        private void btnActualizarListaAsistencia_Click(object sender, EventArgs e)
        {
            ActualizarListaAsistencia();

        }

        private void ActualizarListaAsistencia()
        {
            try
            {
                //if (dgvListadoTrabajadores != null && dgvListadoTrabajadores.Rows.Count > 0)
                //{
                if (ListaDetalleAsistencia != null && ListaDetalleAsistencia.ToList().Count > 0)
                {
                    gbRegistroDocumento.Enabled = false;
                    ProgressBar.Visible = true;
                    menuPrincipal.Enabled = false;

                    string fechaAsistencia = this.txtFechaMovimientoRecorridoInterLocalidad.Text.ToString().Trim();
                    movimientoRecorridosNegocio = new MovimientoMovilidadNegocio();
                    List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ListaDetalleAsistenciaActualizada = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                    ListaDetalleAsistenciaActualizada = movimientoRecorridosNegocio.ValidarListaTrabajadores(ListaDetalleAsistencia, fechaAsistencia).ToList();

                    if (ListaDetalleAsistenciaActualizada != null && ListaDetalleAsistenciaActualizada.ToList().Count > 0)
                    {
                        ListaDetalleAsistencia = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                        ListaDetalleAsistencia = ListaDetalleAsistenciaActualizada.ToList();

                        MessageBox.Show("Se actualización correctamente la información de lista de los trabajadores", "MENSAJE DEL SISTEMA");
                        dgvListadoTrabajadoresIngreso.DataSource = (ListaDetalleAsistencia.OrderBy(x => Convert.ToInt32(x.item)).ToList().ToDataTable<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>());
                        Refresh();
                    }
                    else
                    {
                        MessageBox.Show("No se realizo actualización por que no se registran asistencias de los trabajadores", "MENSAJE DEL SISTEMA");
                    }

                    gbRegistroDocumento.Enabled = true;
                    ProgressBar.Visible = false;
                    menuPrincipal.Enabled = true;
                }

                else
                {
                    MessageBox.Show("No hay elementros en la lista para realizar actualización de los trabajadores", "MENSAJE DEL SISTEMA");
                    return;
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString().Trim() + "\n.Error al Obtener información trabajadores en su asistencias y datos generales", "MENSAJE DEL SISTEMA");
                return;

            }

        }

        private void txtNroPersonasRecorridoInterno_Leave(object sender, EventArgs e)
        {
            int? CantidadPersona = 0;
            decimal? subTotal = 0;
            decimal? Total = 0;
            decimal? IGV = 0;
            decimal? PromedioPersonal = 0;
            decimal? nroViajes = 0;
            decimal? precioVuelta = 0;

            this.txtSubTotalRecorridoInterno.Text = subTotal.Value.ToDecimalPresentation();
            this.txtTotalRecorridoInterno.Text = Total.Value.ToDecimalPresentation();
            this.txtIGVRecorridoInterno.Text = IGV.Value.ToDecimalPresentation();
            this.txtPrecioPersonaPromedioRecorridoInterno.Text = PromedioPersonal.Value.ToDecimalPresentation();

            if (dgvRecorridosInternos != null && dgvRecorridosInternos.Rows.Count > 0)
            {
                nroViajes = txtNumeroViajesRecorridoInterno.Text.ToString().Trim() != null ? Convert.ToInt32(txtNumeroViajesRecorridoInterno.Text.ToString().Trim()) : 0;
                precioVuelta = txtPrecioVuelta.Text.ToString().Trim() != null ? Convert.ToDecimal(txtPrecioVuelta.Text.ToString().Trim()) : 0;
                subTotal = nroViajes * precioVuelta;

                IGV = 0;
                if (subTotal > 0)
                {
                    Total = (subTotal * Convert.ToDecimal("1.18"));
                }

                if (this.dgvRecorridosInternos != null && this.dgvRecorridosInternos.Rows.Count > 0)
                {
                    CantidadPersona = this.dgvRecorridosInternos.Rows.Count * (txtNroPersonasRecorridoInterno.Text.ToString().Trim() != "" ? Convert.ToInt32(txtNroPersonasRecorridoInterno.Text.ToString().Trim()) : 0);
                }

                IGV = Total - subTotal;
                PromedioPersonal = (CantidadPersona != null || CantidadPersona != 0) ? Total / CantidadPersona : 0;


                this.txtSubTotalRecorridoInterno.Text = subTotal.Value.ToDecimalPresentation();
                this.txtTotalRecorridoInterno.Text = Total.Value.ToDecimalPresentation();
                this.txtIGVRecorridoInterno.Text = IGV.Value.ToDecimalPresentation();
                this.txtPrecioPersonaPromedioRecorridoInterno.Text = PromedioPersonal.Value.ToDecimalPresentation();

            }
        }

        private void dgvRecorridosInternos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRecorridosInternos_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgvRecorridosInternos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void txtPrecioProcedenciaInterlocalidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroPersonasInterlocalidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDistribucionPasajerosByParadero_Click(object sender, EventArgs e)
        {
            Distribuir();


        }

        private void Distribuir()
        {
            numeroClickDistribuir += 1;
            if (this.txtCodigoExterno.Text.Trim() != string.Empty)
            {
                numeroClickDistribuir = 0;

                oMovilidad movilidad = new oMovilidad();
                movilidad.codigoMovimiento = txtCodigoExterno.Text.Trim();
                movilidad.placa = txtPlacaInterLocalidad.Text.Trim();
                movilidad.pseudonombre = txtPseudonombreInterlocalidad.Text.Trim();
                movilidad.nroRUC = txtRUCInterlocalidad.Text.Trim();
                movilidad.razonSocial = txtRazonSocialInterlocalidad.Text.Trim();
                movilidad.tipoMovilidad = txtTipoMovilidadInterLocalidad.Text.Trim();
                movilidad.choferDNI = txtChofeDNIRecorridoInterlocalidad.Text.Trim();
                movilidad.chofer = txtChoferNombresRecorridoInterLocalidad.Text.Trim();
                movilidad.numeroAsientos = txtNroAsientosInterlocalidad.Text.Trim() != string.Empty ? Convert.ToInt32(txtNroAsientosInterlocalidad.Text.Trim()) : 0;
                movilidad.esIdaVuelta = rbtIdaVuelta.IsChecked == true ? 1 : 0;
                movilidad.esIda = rbtRecorridoOrigen.IsChecked == true ? 1 : 0;
                movilidad.esVuelta = rbtRecorridoDestino.IsChecked == true ? 1 : 0;
                movilidad.numeroPasajeros = txtNumeroPersonasInterlocalidad.Text.Trim() != string.Empty ? Convert.ToInt32(txtNumeroPersonasInterlocalidad.Text.Trim()) : 0;
                movilidad.rutaOrigen = txtRutaOrigen.Text.Trim();
                movilidad.rutaDestino = txtRutaDestino.Text.Trim();

                MovimientoRecorridosDistribucionPasajerosByParaderos ofrm = new MovimientoRecorridosDistribucionPasajerosByParaderos(movilidad);
                //ofrm.MdiParent = MovimientoRecorridosMantenimiento.ActiveForm;
                ofrm.Show();



            }
            else
            {
                if (numeroClickDistribuir == 1)
                {
                    MessageBox.Show("Sólo se puede distribuir a un registro guardardo", "MENSAJE DEL SISTEMA");
                }
                else if (numeroClickDistribuir == 2)
                {
                    MessageBox.Show("Ya pues...  Sólo se puede distribuir a un registro guardardo", "MENSAJE DEL SISTEMA");
                }
                else if (numeroClickDistribuir > 2)
                {
                    MessageBox.Show("Esta es la " + numeroClickDistribuir.ToString() + " intento. \n Sólose puede distribuir a un registro guardardo", "MENSAJE DEL SISTEMA");
                }

            }
        }

        private void btnGuardarSeguirEditando_Click(object sender, EventArgs e)
        {
            GrabarYEditar();

        }

        private void GrabarYEditar()
        {
            try
            {
                Grabar();
                Editar();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
            }
        }

        private void EdicionDesdeTeclado(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }


            if (Control.ModifierKeys == Keys.F5)
            {
                Actualizar();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G && e.KeyCode == Keys.E)
            {
                GrabarYEditar();
            }


            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D)
            {
                Distribuir();
            }

            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Editar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {

            }
            if (e.KeyData == (Keys.Escape))
            {
            }
        }

        private void menuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbRegistroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbMovimientoInterlocalidad_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbDestinoMovimiento_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbTransportistaInformacion_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbRegistroMovimientoExterno_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbProcedenciaExterno_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbRegistroPersonasExterno_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void btnDistribucionPasajerosByParadero_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void dgvResumenPorParadero_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void dgvListadoTrabajadores_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void btnActualizarListaAsistencia_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void btnGrabar_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtNumeroPersonasInterlocalidad_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void MovimientoRecorridosMantenimiento_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtPromedioPersona_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtPrecioExterno_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtSubTotalInterlocalidad_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtIGVInterlocalidad_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtTotalInterlocalidad_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {

        }

        private void gbTransportistaInformacion_Click(object sender, EventArgs e)
        {

        }

        private void btnImportarAsistenciaIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                oCabeceraImportacionParteTransporteTercerosByMovil odatosCabeceraFormulario = new oCabeceraImportacionParteTransporteTercerosByMovil();

                odatosCabeceraFormulario.empresaCodigo = txtEmpresaCodigo.Text.Trim();
                odatosCabeceraFormulario.empresaDescripcion = txtEmpresaDescripcion.Text.Trim();
                odatosCabeceraFormulario.codigoFormulario = txtCodigoExterno.Text.Trim();
                odatosCabeceraFormulario.periodo = txtPeriodoNombre.Text.Trim();
                odatosCabeceraFormulario.periodoFormato = txtPeriodo.Text.Trim();
                odatosCabeceraFormulario.numeroManual = txtNumeroManualExterno.Text.Trim();
                odatosCabeceraFormulario.codigoDocumento = cboIdDocumentoExterno.Text.Trim();
                odatosCabeceraFormulario.serieDocumento = cboIdSerieExterno.Text.Trim();
                odatosCabeceraFormulario.numeroDocumento = txtNumeroDocumentoExterno.Text.Trim();
                odatosCabeceraFormulario.fechaDocumento = txtFechaMovimientoRecorridoInterLocalidad.Text.Trim();
                odatosCabeceraFormulario.estadoCodigo = txtIdEstadoInterlocalidad.Text.Trim();
                odatosCabeceraFormulario.estadoDescripcion = txtEstadoInterLocalidad.Text.Trim();
                odatosCabeceraFormulario.unidadMovilCodigo = txtIdMovilRecorridoInterlocalidad.Text.Trim();
                odatosCabeceraFormulario.unidadMovilPlaca = txtPlacaInterLocalidad.Text.Trim();
                odatosCabeceraFormulario.unidadMovilRUC = txtRUCInterlocalidad.Text.Trim();
                odatosCabeceraFormulario.unidadMovilTipoMovilidad = txtTipoMovilidadInterLocalidad.Text.Trim();
                odatosCabeceraFormulario.unidadMovilNombreComercial = txtPseudonombreInterlocalidad.Text.Trim();
                odatosCabeceraFormulario.unidadMovilRazonSocial = txtRazonSocialInterlocalidad.Text.Trim();
                odatosCabeceraFormulario.unidadMovilNumeroAsientos = txtNroAsientosInterlocalidad.Text.Trim();
                odatosCabeceraFormulario.conductorCodigo = txtChoferCodigoRecorridoInterLocalidad.Text.Trim();
                odatosCabeceraFormulario.conductorDNI = txtChofeDNIRecorridoInterlocalidad.Text.Trim();
                odatosCabeceraFormulario.conductorNombres = txtChoferNombresRecorridoInterLocalidad.Text.Trim();
                odatosCabeceraFormulario.rutaOrigenCodigo = txtCodigoRutaOrigen.Text.Trim();
                odatosCabeceraFormulario.rutaOrigenItem = txtItemIda.Text.Trim();
                odatosCabeceraFormulario.rutaOrigenDescripcion = txtRutaOrigen.Text.Trim();
                odatosCabeceraFormulario.rutaOrigenPrecio = txtPrecioProcedenciaInterlocalidad.Text.Trim();
                odatosCabeceraFormulario.rutaDestinoCodigo = txtCodigoRutaDestino.Text.Trim();
                odatosCabeceraFormulario.rutaDestinoItem = txtItemRegreso.Text.Trim();
                odatosCabeceraFormulario.rutaDestinoDescripcion = txtRutaDestino.Text.Trim();
                odatosCabeceraFormulario.rutDestinoPrecio = txtPrecioDestinoInterprocedencia.Text.Trim();



                MovimientoRecorridosImportarAsistenciaDesdeMoviles ofrm = new MovimientoRecorridosImportarAsistenciaDesdeMoviles(odatosCabeceraFormulario);
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    // si traigo info, actualizo la lista
                    oLitadoMarcacionesSelecionadasIngreso = new List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult>();
                    listaFormartoImportacionIngreso = new List<FormatoImportacionMovimientoRecorridoInterLocalidades>();
                    listaFormartoImportacionSalida = new List<FormatoImportacionMovimientoRecorridoInterLocalidades>();
                    if (ofrm.oLitadoSelecionadoByIngreso.ToList().Count > 0)
                    {

                        oLitadoMarcacionesSelecionadasIngreso = ofrm.oLitadoSelecionadoByIngreso.ToList();
                        if (ofrm.oLitadoSelecionadoByIngreso.ToList().Count > 0)
                        {
                            listaFormartoImportacionIngreso = (from item in ofrm.oLitadoSelecionadoByIngreso.ToList()
                                                               group item by item.idRegistroMovil
                                                               into j
                                                               select new FormatoImportacionMovimientoRecorridoInterLocalidades
                                                               {
                                                                   item = "001",
                                                                   idcodigoGeneral = j.FirstOrDefault().idCodigoGeneral != null ? j.FirstOrDefault().idCodigoGeneral : string.Empty,
                                                                   nroDocumento = j.FirstOrDefault().idCodigoGeneral != null ? j.FirstOrDefault().idCodigoGeneral : string.Empty,
                                                                   nombresCompletos = j.FirstOrDefault().nombres != null ? j.FirstOrDefault().nombres : string.Empty,
                                                                   subplanilla = string.Empty,
                                                                   hora = j.FirstOrDefault().hora != null ? j.FirstOrDefault().hora : string.Empty,
                                                               }
                                                               ).ToList();
                        }


                        txtNumeroPersonasInterlocalidad.Text = listaFormartoImportacionIngreso.ToList().Count().ToString();
                        RealizarCalculo();
                        dgvListadoTrabajadoresIngreso.DataSource = listaFormartoImportacionIngreso;




                        //Actualizar lista Actual
                    }
                    if (ofrm.oLitadoSelecionadoBySalida.ToList().Count > 0)
                    {
                        oLitadoMarcacionesSelecionadasSalida = ofrm.oLitadoSelecionadoBySalida.ToList();

                        if (ofrm.oLitadoSelecionadoBySalida.ToList().Count > 0)
                        {
                            listaFormartoImportacionSalida = (from item in ofrm.oLitadoSelecionadoBySalida.ToList()
                                                              group item by item.idRegistroMovil
                                                               into j
                                                              select new FormatoImportacionMovimientoRecorridoInterLocalidades
                                                              {
                                                                  item = "001",
                                                                  idcodigoGeneral = j.FirstOrDefault().idCodigoGeneral != null ? j.FirstOrDefault().idCodigoGeneral : string.Empty,
                                                                  nroDocumento = j.FirstOrDefault().idCodigoGeneral != null ? j.FirstOrDefault().idCodigoGeneral : string.Empty,
                                                                  nombresCompletos = j.FirstOrDefault().nombres != null ? j.FirstOrDefault().nombres : string.Empty,
                                                                  subplanilla = string.Empty,
                                                                  hora = j.FirstOrDefault().hora != null ? j.FirstOrDefault().hora : string.Empty,
                                                              }
                                                               ).ToList();
                        }

                        dgvListadoTrabajadoresSalida.DataSource = listaFormartoImportacionSalida;
                        //Actualizar lista Actual
                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }


        }

        private void menuPrincipal_KeyDown_1(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }





    }
}

