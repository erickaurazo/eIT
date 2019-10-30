using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Configuration;
using System.Collections;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class MovimientoAsistenciaRefrigerioMatenimiento : Telerik.WinControls.UI.RadForm
    {
        private string Periodo;
        private SJM_PensionesNegocios negocio;
        private List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult> Listado;
        private string dniPension;
        private string desde;
        private string hasta;
        private string Msg;
        private RadTextBox ControlValidar;
        private SJM_Pensione Obj;
        private List<SJM_Pensione> ListaObjeto;
        private List<SJM_Pensione> ListaObjetoEliminados = new List<SJM_Pensione>();
        private string codigo;
        private List<SJ_RHMovimientoAsistenciaRefrigerioObjetoResult> Objeto;
        private string periodo;
        private string fecha;
        private List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult> Detalle;
        private SJ_RHMovimientoAsistenciaPension movimientoAsistenciaRefrigerio;
        private List<SJ_RHMovimientoAsistenciaPensionDetalle> detallemovimientoAsistenciaRefrigerio;
        private List<SJ_RHMovimientoAsistenciaPensionDetalle> detallemovimientoAsistenciaRefrigerioEliminados;
        private oConsultaConsolidadAsistenciaRefrigerio oConsulta;
        private List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> listadoAsistenciaSinDesconocidos;
        private SJ_RHMovimientoAsistenciaPensionNegocios modelo;
        //private SJ_RHMovimientoAsistenciaPension movimientoAsistencia;
        private List<SJ_RHMovimientoAsistenciaPensionDetalle> detalleMovimiento;
        private List<SJ_RHMovimientoAsistenciaPensionDetalle> detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
        private SJ_RHMovimientoAsistenciaPension oMovimiento;
        private SJ_RHMovimientoAsistenciasProcesadasByCodigoResult movimientoAsistenciaProcesadaRefrigerioByCodigo;
        private List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult> detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
        private SJ_ObtenerDocumentoMovimientoResult oDocumentoMovimientoxCodDocumento;
        private List<SJ_ObtenerDocumentoMovimientoResult> oDocumentoMovimientoxCodDocumentos;
        private DocumentoNegocio documentoNegocio;

        private List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult> listaImportadaByProgramacion;

        private string sinProceso;
        private List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult> detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
        private string proveedorNroRUC;
        private string proveedorNombre;
        private string proveedorNombreComercial;
        private string proveedordni;
        private string codigoPension;

        public MovimientoAsistenciaRefrigerioMatenimiento()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.txtDocumentoFecha.Text = DateTime.Now.ToShortDateString();
            codigo = string.Empty;
            this.txtCodigoRegistro.Text = codigo;
        }

        public MovimientoAsistenciaRefrigerioMatenimiento(oConsultaConsolidadAsistenciaRefrigerio oConsulta)
        {
            try
            {
                #region Inicio
                InitializeComponent();
                this.codigoDocumento = "MAR";
                RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
                RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
                RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
                RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
                this.oConsulta = oConsulta;
                AsignarInformacionFormularioOrigen();
                PresentarDatosDocumento(this.codigoDocumento);
                //btnActualizarLista.Enabled = false;
                btnAgregar.Enabled = false;
                btnAnular.Enabled = false;
                //btnBuscarPension.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnExportar.Enabled = false;
                btnGuardar.Enabled = true;
                btnNuevo.Enabled = true;
                btnQuitar.Enabled = false;
                btnSalir.Enabled = true;
                txtDocumentoFecha.ReadOnly = true;
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        public MovimientoAsistenciaRefrigerioMatenimiento(SJ_RHMovimientoAsistenciaPension oMovimiento, string codigoDocumento)
        {
            try
            {
                #region Inicio()
                InitializeComponent();
                RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
                RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
                RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
                RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
                this.oMovimiento = oMovimiento;
                this.codigoDocumento = codigoDocumento;
                codigo = oMovimiento.idMovimiento != null ? oMovimiento.idMovimiento.ToString().Trim() : string.Empty;
                this.txtCodigoRegistro.Text = codigo;
                this.sinProceso = oMovimiento.idDocumento != null ? oMovimiento.idDocumento.Trim() : string.Empty;
                //btnActualizarLista.Enabled = false;
                btnAgregar.Enabled = false;
                btnAnular.Enabled = false;
                //btnBuscarPension.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnExportar.Enabled = false;
                btnGuardar.Enabled = true;
                btnNuevo.Enabled = true;
                btnQuitar.Enabled = false;
                btnSalir.Enabled = true;
                txtDocumentoFecha.ReadOnly = true;
                this.btnQuitar.Enabled = true;
                PresentarDocumentSerieNumeroDocumento();

                if (oMovimiento.idEstado.Trim() == "PE")
                {
                    if (this.codigoDocumento.Trim() == "RAR")
                    {
                        this.txtDocumentoFecha.ReadOnly = false;
                        this.txtDocumentoFecha.Enabled = true;
                    }
                }

                gbCabecera.Enabled = true;
                gbDetalle.Enabled = true;
                barraPrincipal.Enabled = true;
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        public MovimientoAsistenciaRefrigerioMatenimiento(string sinProceso)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.sinProceso = "RAR";
            this.codigoDocumento = "RAR";
            Inicio();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.txtDocumentoFecha.Text = DateTime.Now.ToShortDateString();
            codigo = string.Empty;
            this.txtCodigoRegistro.Text = codigo;
            //AsignarInformacionFormularioOrigen();
            PresentarDatosDocumento(this.codigoDocumento);
            //btnActualizarLista.Enabled = false;
            btnAgregar.Enabled = !false;
            btnAnular.Enabled = false;
            //btnBuscarPension.Enabled = !false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = false;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = true;
            btnQuitar.Enabled = !false;
            btnSalir.Enabled = true;
            txtDocumentoFecha.ReadOnly = true;
            txtProveedorNroRUC.ReadOnly = false;
            btnAgregarAsistenciaDesdeProgramacion.Enabled = !false;
            txtDocumentoFecha.Enabled = true;


        }

        public MovimientoAsistenciaRefrigerioMatenimiento(string sinProceso, string proveedorNroRUC, string proveedorNombre, string proveedorNombreComercial, string proveedordni, string codigoPension)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.sinProceso = "RAR";
            this.codigoDocumento = "RAR";
            this.proveedorNroRUC = proveedorNroRUC;
            this.proveedorNombre = proveedorNombre;
            this.proveedorNombreComercial = proveedorNombreComercial;
            this.proveedordni = proveedordni;
            this.codigoPension = codigoPension;

            this.txtnroDniPension.Text = this.proveedordni;
            this.txtProveedorRazonSocial.Text = this.proveedorNombre;
            this.txtProveedorCodigo.Text = codigoPension;
            this.txtProveedorNroRUC.Text = this.proveedorNroRUC;
            this.txtProveedorPseudoNombre.Text = proveedorNombreComercial;

            Inicio();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.txtDocumentoFecha.Text = DateTime.Now.ToShortDateString();
            codigo = string.Empty;
            this.txtCodigoRegistro.Text = codigo;
            //AsignarInformacionFormularioOrigen();
            PresentarDatosDocumento(this.codigoDocumento);
            //btnActualizarLista.Enabled = false;
            btnAgregar.Enabled = !false;
            btnAnular.Enabled = false;
            //btnBuscarPension.Enabled = !false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = false;
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = true;
            btnQuitar.Enabled = !false;
            btnSalir.Enabled = true;
            txtDocumentoFecha.ReadOnly = true;
            txtProveedorNroRUC.ReadOnly = false;
            btnAgregarAsistenciaDesdeProgramacion.Enabled = !false;
            txtDocumentoFecha.Enabled = true;
            txtDocumentoFecha.ReadOnly = false;
        }

        private void PresentarDatosDocumento(string idDocumento)
        {
            try
            {
                #region Obtener Datos Del Documento Movimiento: Cod. Doc, Serie, Numero()
                DocumentoNegocio documentoNegocio = new DocumentoNegocio();
                SJ_ObtenerDocumentoMovimientoResult oDocumentoMovimientoxCodDocumento = new SJ_ObtenerDocumentoMovimientoResult();
                List<SJ_ObtenerDocumentoMovimientoResult> oDocumentoMovimientoxCodDocumentos = new List<SJ_ObtenerDocumentoMovimientoResult>();
                oDocumentoMovimientoxCodDocumento = documentoNegocio.ObtenerDocumentoMovimientoxCodDocumento(idDocumento);
                oDocumentoMovimientoxCodDocumentos.Add(oDocumentoMovimientoxCodDocumento);
                this.cboDocumentoCodigo.DisplayMember = "idDocumento";
                this.cboDocumentoCodigo.ValueMember = "idDocumento";
                this.cboDocumentoCodigo.DataSource = oDocumentoMovimientoxCodDocumentos;
                this.cboDocumentoSerie.DisplayMember = "serie";
                this.cboDocumentoSerie.ValueMember = "serie";
                this.cboDocumentoSerie.DataSource = oDocumentoMovimientoxCodDocumentos;
                this.txtDocumentoNumero.Text = oDocumentoMovimientoxCodDocumento.NUMERO;
                this.txtOperacionNumero.Text = oDocumentoMovimientoxCodDocumento.correlativo.ToString().Trim();

                if (oDocumentoMovimientoxCodDocumento.IDDOCUMENTO == "RAR")
                {
                    btnAgregarAsistenciaDesdeProgramacion.Enabled = true;
                }

                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void AsignarInformacionFormularioOrigen()
        {
            try
            {
                #region Enlazar Controles Del Formulario Anterior Al Actual()
                this.txtPeriodo.Text = this.oConsulta.periodo != null ? this.oConsulta.periodo : string.Empty;
                this.txtPeriodoNombre.Text = this.oConsulta.nombresMes != null ? this.oConsulta.nombresMes : string.Empty;
                this.txtProveedorNroRUC.Text = this.oConsulta.nroRuc != null ? this.oConsulta.nroRuc : string.Empty;
                this.txtProveedorRazonSocial.Text = this.oConsulta.nombrePension != null ? this.oConsulta.nombrePension : string.Empty;
                this.txtProveedorCodigo.Text = this.oConsulta.IdPension != null ? this.oConsulta.IdPension : string.Empty;
                this.txtnroDniPension.Text = this.oConsulta.nroDniPension != null ? this.oConsulta.nroDniPension : string.Empty;
                this.txtProveedorPseudoNombre.Text = this.oConsulta.nombreComercial != null ? this.oConsulta.nombreComercial : string.Empty;
                this.txtDocumentoFecha.Text = this.oConsulta.fechaDesde != null ? this.oConsulta.fechaDesde : string.Empty;

                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                listadoMovimientoAsistenciaRefrigerios = new List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult>();
                listadoMovimientoAsistenciaRefrigerios = modelo.ObtenerMovimientoAsistenciaRefrigerioByPeriodo(this.txtCodigoRegistro.Text.ToString().Trim(), oConsulta.nroDniPension, oConsulta.fechaDesde, oConsulta.fechaHasta).ToList();

                detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
                detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo = (from item in listadoMovimientoAsistenciaRefrigerios
                                                                          group item by new { item.codigoTransferencia } into j
                                                                          select new SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult
                                                                          {
                                                                              codigoMovimiento = j.FirstOrDefault().codigoMovimiento != null ? j.FirstOrDefault().codigoMovimiento.ToString().Trim() : "",
                                                                              item = j.FirstOrDefault().item != null ? j.FirstOrDefault().item : 0,
                                                                              codigo = j.FirstOrDefault().codigo != null ? j.FirstOrDefault().codigo.ToString().Trim() : "",
                                                                              codigoTransferencia = j.FirstOrDefault().codigoTransferencia != null ? j.FirstOrDefault().codigoTransferencia : 0,
                                                                              DniPension = j.FirstOrDefault().DniPension != null ? j.FirstOrDefault().DniPension.ToString().Trim() : "",
                                                                              NombresPension = j.FirstOrDefault().NombresPension != null ? j.FirstOrDefault().NombresPension.ToString().Trim() : "",
                                                                              DniTrabajador = j.FirstOrDefault().DniTrabajador != null ? j.FirstOrDefault().DniTrabajador.ToString().Trim() : "",
                                                                              NombresTrabajador = j.FirstOrDefault().NombresTrabajador != null ? j.FirstOrDefault().NombresTrabajador.ToString().Trim() : "",
                                                                              TipoComida = j.FirstOrDefault().TipoComida != null ? j.FirstOrDefault().TipoComida : 0,
                                                                              Refrigerio = j.FirstOrDefault().Refrigerio != null ? j.FirstOrDefault().Refrigerio.ToString().Trim() : "",
                                                                              FechaPension = j.FirstOrDefault().FechaPension != null ? j.FirstOrDefault().FechaPension.Value : (DateTime?)null,
                                                                              FechaRegistro = j.FirstOrDefault().FechaRegistro != null ? j.FirstOrDefault().FechaRegistro.Value : (DateTime?)null,
                                                                              EsProcesado = j.FirstOrDefault().EsProcesado != null ? j.FirstOrDefault().EsProcesado : 0,
                                                                              idParadero = j.FirstOrDefault().idParadero != null ? j.FirstOrDefault().idParadero.ToString().Trim() : "",
                                                                              glosa = j.FirstOrDefault().glosa != null ? j.FirstOrDefault().glosa.ToString().Trim() : "",
                                                                          }).ToList();


                int totalDesayunos, totalAlmuerzos, totalCenas = 0;
                totalDesayunos = detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo != null ? detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.Where(x => x.Refrigerio == "DESAYUNO").ToList().Count : 0;
                totalAlmuerzos = detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo != null ? detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.Where(x => x.Refrigerio == "ALMUERZO").ToList().Count : 0;
                totalCenas = detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo != null ? detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.Where(x => x.Refrigerio == "CENA").ToList().Count : 0;

                dgvRegistrosAsistencias.CargarDatos(detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.ToDataTable<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>());
                dgvRegistrosAsistencias.Refresh();

                this.txtRefrigerioTotalDesayunos.Text = totalDesayunos.ToString();
                this.txtRefrigerioTotalAlmuerzos.Text = totalAlmuerzos.ToString();
                this.txtRefrigerioTotalCenas.Text = totalCenas.ToString();

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void RegistroAsistenciaRefrigerio_Load(object sender, EventArgs e)
        {
            //dgvRegistrosAsistencias.Columns["chNombresTrabajador"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void Inicio()
        {
            /*
            try
            {
                Periodo = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + Periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }*/
        }

        private void btnBuscarPension_Click(object sender, EventArgs e)
        {
            BuscarPension oFrm = new BuscarPension();
            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                if (oFrm.ObjetoBusquedaPension != null)
                {
                    try
                    {
                        // llenar los controles
                        this.txtProveedorCodigo.Text = oFrm.ObjetoBusquedaPension.IdPension.ToString();
                        this.txtProveedorNroRUC.Text = oFrm.ObjetoBusquedaPension.NroRuc;
                        this.txtProveedorRazonSocial.Text = oFrm.ObjetoBusquedaPension.RazonSocial;
                        //this.txtRucDNIResponsable.Text = oFrm.ObjetoBusquedaPension.NroDNI;
                        this.txtProveedorPseudoNombre.Text = oFrm.ObjetoBusquedaPension.PseudoNombre.ToString().Trim();
                        this.txtProveedorNroRUC.Text = oFrm.ObjetoBusquedaPension.NroDNI.ToString().Trim();
                        //this.txtRucNombreComercial.Text = oFrm.ObjetoBusquedaPension.PseudoNombre;

                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                }
            }
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            //PresentarDocumentSerieNumeroDocumento();
            /*
            Consultar();
            progressBar.Visible = true;
             * */
        }

        private void PresentarDocumentSerieNumeroDocumento()
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {
                progressBar.Visible = true;
                gbCabecera.Enabled = false;
                gbDetalle.Enabled = false;
                barraPrincipal.Enabled = false;
                bgwSubProceso1.RunWorkerAsync();
            }
            else
            {
                //RadMessageBox.Show(Msg, "Atención");
                if (Msg.ToString().Trim() != "")
                {
                    MessageBox.Show(Msg, "ATENCIÓN");
                    ControlValidar.Focus();
                }

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void Agregar()
        {

        }

        private bool ValidarGrabado()
        {
            bool Estado = true;
            Msg = string.Empty;
            ControlValidar = new RadTextBox();

            try
            {
                if (this.txtProveedorCodigo.Text.ToString().Trim() == "")
                {
                    Msg += "Debe ingresar un código de pensión válido \n";
                    ControlValidar = this.txtProveedorNroRUC;
                    //Estado = false;
                }
                if (this.txtDocumentoFecha.Text.ToString().Trim() == "")
                {

                }
                else
                {
                    if (this.txtDocumentoFecha.Text.ToString().Trim() == "__/__/____")
                    {
                        Estado = false;
                        Msg += "Debe ingresar una fecha de registro válido \n";
                        ControlValidar = this.txtProveedorNroRUC;
                    }
                }

                if (this.txtEstadoCodigo.Text.ToString().Trim() != "PE")
                {
                    Msg += "El documento no contiene el estado para la edición \n";
                    ControlValidar = this.txtProveedorNroRUC;
                    Estado = false;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return false;
            }



            return Estado;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            Quitar();
        }

        private void Quitar()
        {
            try
            {
                #region Quitar elemento de la lista
                if (this.dgvRegistrosAsistencias != null)
                {
                    if (this.dgvRegistrosAsistencias.CurrentRow != null)
                    {
                        try
                        {
                            Int32 codigoTransferenciaAsistenciaMovil = (this.dgvRegistrosAsistencias.CurrentRow.Cells["chcodigoTransferencia"].Value != null ? Convert.ToInt32(this.dgvRegistrosAsistencias.CurrentRow.Cells["chcodigoTransferencia"].Value) : 0);
                            string idMovimiento = (this.dgvRegistrosAsistencias.CurrentRow.Cells["chIdMovimiento"].Value != null ? (this.dgvRegistrosAsistencias.CurrentRow.Cells["chIdMovimiento"].Value).ToString().Trim() : "");
                            if (codigoTransferenciaAsistenciaMovil != 0)
                            {
                                detalleMovimientoEliminado.Add(new SJ_RHMovimientoAsistenciaPensionDetalle
                                {
                                    idMovimiento = idMovimiento,
                                    codigoTransferenciaAsistenciaMovil = codigoTransferenciaAsistenciaMovil
                                });
                            }

                            dgvRegistrosAsistencias.Rows.Remove(dgvRegistrosAsistencias.CurrentRow);

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                            return;
                        }
                    }
                }

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void Editar()
        {

            if (this.sinProceso == "RAR")
            {
                oMovimiento = new SJ_RHMovimientoAsistenciaPension();
                detalleMovimiento = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                movimientoAsistenciaRefrigerio = new SJ_RHMovimientoAsistenciaPension();
                detallemovimientoAsistenciaRefrigerio = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                detallemovimientoAsistenciaRefrigerioEliminados = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                movimientoAsistenciaProcesadaRefrigerioByCodigo = new SJ_RHMovimientoAsistenciasProcesadasByCodigoResult();
                detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
                gbCabecera.Enabled = true;
                gbDetalle.Enabled = true;
                this.btnAgregar.Enabled = true;
                this.btnQuitar.Enabled = true;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnAnular.Enabled = false;
                btnExportar.Enabled = false;
                btnHistorial.Enabled = true;
                btnAtras.Enabled = true;
                btnSalir.Enabled = true;
                btnGuardar.Enabled = !true;
                txtDocumentoFecha.Enabled = !true;
                btnAgregarAsistenciaDesdeProgramacion.Enabled = !true;


                if (this.txtEstadoCodigo.Text.Trim() == "PE")
                {
                    btnAgregarAsistenciaDesdeProgramacion.Enabled = true;
                    txtDocumentoFecha.Enabled = true;
                    btnGuardar.Enabled = true;
                }


            }
            else
            {
                oMovimiento = new SJ_RHMovimientoAsistenciaPension();
                detalleMovimiento = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                movimientoAsistenciaRefrigerio = new SJ_RHMovimientoAsistenciaPension();
                detallemovimientoAsistenciaRefrigerio = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                detallemovimientoAsistenciaRefrigerioEliminados = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                movimientoAsistenciaProcesadaRefrigerioByCodigo = new SJ_RHMovimientoAsistenciasProcesadasByCodigoResult();
                detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
                gbCabecera.Enabled = true;
                gbDetalle.Enabled = true;
                //this.btnAgregar.Enabled = true;
                this.btnQuitar.Enabled = true;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = false;
                btnAnular.Enabled = false;
                btnExportar.Enabled = false;
                btnHistorial.Enabled = true;
                btnAtras.Enabled = true;
                //btnActualizarLista.Enabled = true;
                btnSalir.Enabled = true;

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Registrar();
            PresentarDocumentSerieNumeroDocumento();

        }

        private void Registrar()
        {
            #region Registrar()
            try
            {
                if (ValidarGrabado() == true)
                {
                    progressBar.Visible = true;
                    gbCabecera.Enabled = false;
                    gbDetalle.Enabled = false;
                    barraPrincipal.Enabled = false;
                    bgwSubProceso3.RunWorkerAsync();

                }
                else
                {
                    //RadMessageBox.Show(Msg, "Atención");
                    MessageBox.Show(Msg, "MENSAJE DE SISTEMA");
                    ControlValidar.Focus();
                }

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
            }
            #endregion
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }


        public string MonthName(int numeroMes)
        {
            string nombre = string.Empty;

            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            nombre = dtinfo.GetMonthName(numeroMes);
            return nombre;
        }

        private void Nuevo()
        {
            gbCabecera.Enabled = true;
            gbDetalle.Enabled = true;
            LimpiarFormulario();
            oMovimiento = new SJ_RHMovimientoAsistenciaPension();
            detalleMovimiento = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
            detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();

            modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
            movimientoAsistenciaRefrigerio = new SJ_RHMovimientoAsistenciaPension();
            detallemovimientoAsistenciaRefrigerio = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
            detallemovimientoAsistenciaRefrigerioEliminados = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
            movimientoAsistenciaProcesadaRefrigerioByCodigo = new SJ_RHMovimientoAsistenciasProcesadasByCodigoResult();
            detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
            //dgvRegistrosAsistencias.CargarDatos()
            dgvRegistrosAsistencias.CargarDatos(detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.ToDataTable<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>());
            dgvRegistrosAsistencias.Refresh();
            PresentarDatosDocumento(this.codigoDocumento);

            txtPeriodoNombre.Text = MonthName(Convert.ToDateTime(this.txtDocumentoFecha.Text).Month);
            txtPeriodo.Text = Convert.ToDateTime(this.txtDocumentoFecha.Text).Year + Convert.ToDateTime(this.txtDocumentoFecha.Text).Month.ToString().PadLeft(2, '0');

            progressBar.Visible = false;
            barraPrincipal.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = false;
            btnAnular.Enabled = false;
            btnExportar.Enabled = true;
            btnHistorial.Enabled = true;
            //btnActualizarLista.Enabled = true;
            btnSalir.Enabled = false;

        }

        private void LimpiarFormulario()
        {
            this.txtProveedorCodigo.Clear();
            this.txtProveedorPseudoNombre.Clear();
            this.txtProveedorRazonSocial.Clear();
            this.txtDocumentoNumero.Clear();
            this.txtDocumentoFecha.Text = DateTime.Today.ToShortDateString();
            this.txtPeriodo.Clear();
            this.txtPeriodoNombre.Clear();
            this.txtEstado.Text = "PENDIENTE";
            this.txtEstadoCodigo.Text = "PE";
            this.txtCodigoRegistro.Clear();
            this.txtRefrigerioTotalAlmuerzos.Clear();
            this.txtRefrigerioTotalCenas.Clear();
            this.txtRefrigerioTotalDesayunos.Clear();
            this.txtnroDniPension.Clear();
            this.txtProveedorNroRUC.Clear();

        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            Historial ofrm = new Historial(this.txtCodigoRegistro.Text.ToString().Trim(), "0", "SJ_RHMovimientoAsistenciaPension");
            ofrm.Text = "Historial del Registros";
            ofrm.ShowDialog();
        }

        private void bgwSubProcesoGrabar_DoWork(object sender, DoWorkEventArgs e)
        {
            RealizarProcesoGrabado();
        }

        private void RealizarProcesoGrabado()
        {
            try
            {
                oMovimiento = new SJ_RHMovimientoAsistenciaPension();
                oMovimiento.idSucursal = this.txtSucursalCodigo.Text != null ? this.txtSucursalCodigo.Text.ToString().Trim() : string.Empty;
                oMovimiento.idEmpresa = this.txtEmpresaCodigo.Text != null ? this.txtEmpresaCodigo.Text.ToString().Trim() : string.Empty;
                oMovimiento.idMovimiento = this.txtCodigoRegistro.Text != null ? this.txtCodigoRegistro.Text.ToString().Trim() : string.Empty;
                oMovimiento.idclieprov = this.txtProveedorNroRUC.Text != null ? this.txtProveedorNroRUC.Text.ToString().Trim() : string.Empty;
                oMovimiento.dniPension = this.txtnroDniPension.Text != null ? this.txtnroDniPension.Text.ToString().Trim() : string.Empty;
                oMovimiento.fecha = this.txtDocumentoFecha.Text != null ? Convert.ToDateTime(this.txtDocumentoFecha.Text) : DateTime.Now;
                oMovimiento.idDocumento = this.cboDocumentoCodigo.SelectedValue != null ? this.cboDocumentoCodigo.SelectedValue.ToString().Trim() : string.Empty;
                oMovimiento.serie = this.cboDocumentoSerie.SelectedValue != null ? this.cboDocumentoSerie.SelectedValue.ToString().Trim() : string.Empty;
                oMovimiento.numero = this.txtDocumentoNumero.Text != null ? this.txtDocumentoNumero.Text.ToString().Trim() : string.Empty;
                oMovimiento.numeroOperacion = this.txtOperacionNumero.Text != null ? this.txtOperacionNumero.Text.ToString().Trim() : string.Empty;
                oMovimiento.periodo = this.txtPeriodo.Text != null ? this.txtPeriodo.Text.ToString().Trim() : string.Empty;
                oMovimiento.estado = 1;
                oMovimiento.idEstado = this.txtEstadoCodigo.Text != null ? this.txtEstadoCodigo.Text.ToString().Trim() : "AN";
                oMovimiento.registradoPor = Environment.UserName.ToString();
                oMovimiento.maquinanaRegistrada = Environment.MachineName.ToString();
                oMovimiento.fechaRegistro = DateTime.Now;
                oMovimiento.NombreMes = this.txtPeriodoNombre.Text != null ? this.txtPeriodoNombre.Text.ToString().Trim() : string.Empty;

                detalleMovimiento = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                if (dgvRegistrosAsistencias != null && dgvRegistrosAsistencias.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in dgvRegistrosAsistencias.Rows)
                    {
                        if ((item.Cells["chcodigoTransferencia"].Value != null ? Convert.ToInt32(item.Cells["chcodigoTransferencia"].Value.ToString().Trim()) : 0) > 0)
                        {
                            SJ_RHMovimientoAsistenciaPensionDetalle detalle = new SJ_RHMovimientoAsistenciaPensionDetalle();
                            //detalle.idMovimiento = item.Cells["chcodigoMovimiento"].Value != null ? item.Cells["chcodigoMovimiento"].Value.ToString().Trim() : string.Empty;
                            detalle.idMovimiento = oMovimiento.idMovimiento != null ? oMovimiento.idMovimiento : string.Empty;
                            detalle.item = item.Cells["chItem"].Value != null ? Convert.ToInt32(item.Cells["chItem"].Value.ToString().Trim()) : 0;
                            detalle.codigoTransferenciaAsistenciaMovil = item.Cells["chcodigoTransferencia"].Value != null ? Convert.ToInt32(item.Cells["chcodigoTransferencia"].Value.ToString().Trim()) : 0;
                            detalle.estado = item.Cells["chEsProcesado"].Value != null ? Convert.ToByte(item.Cells["chEsProcesado"].Value.ToString().Trim()) : Convert.ToByte(0);
                            detalle.glosa = item.Cells["chGlosa"].Value != null ? item.Cells["chGlosa"].Value.ToString().Trim() : string.Empty;
                            detalleMovimiento.Add(detalle);
                        }
                    }
                }

                //detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                codigo = modelo.Registrar(oMovimiento, detalleMovimiento, detalleMovimientoEliminado, detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva);
                this.txtCodigoRegistro.Text = codigo;
                oMovimiento = new SJ_RHMovimientoAsistenciaPension();
                detalleMovimiento = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwSubProcesoGrabar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarResultadosProcesoGrabado();
        }

        private void PresentarResultadosProcesoGrabado()
        {
            try
            {
                this.txtCodigoRegistro.Text = codigo;
                this.btnQuitar.Enabled = false;
                progressBar.Visible = false;
                gbCabecera.Enabled = true;
                gbDetalle.Enabled = true;
                barraPrincipal.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = true;
                btnAnular.Enabled = true;
                btnExportar.Enabled = true;
                btnHistorial.Enabled = false;
                //btnActualizarLista.Enabled = false;
                btnSalir.Enabled = true;
                //RadMessageBox.Show("La operación se ha registrado correctamente", "Mensaje de Sistema");
                oMovimiento = new SJ_RHMovimientoAsistenciaPension();
                detalleMovimiento = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                movimientoAsistenciaRefrigerio = new SJ_RHMovimientoAsistenciaPension();
                detallemovimientoAsistenciaRefrigerio = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                detallemovimientoAsistenciaRefrigerioEliminados = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                movimientoAsistenciaProcesadaRefrigerioByCodigo = new SJ_RHMovimientoAsistenciasProcesadasByCodigoResult();
                detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();

                MessageBox.Show("Proceso realizado con éxito", "MENSAJE DEL SISTEMA");
            }
            catch (Exception Ex)
            {
                progressBar.Visible = false;
                gbCabecera.Enabled = true;
                gbDetalle.Enabled = true;
                barraPrincipal.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = true;
                btnAnular.Enabled = true;
                btnExportar.Enabled = true;
                btnHistorial.Enabled = false;
                //btnActualizarLista.Enabled = false;
                btnSalir.Enabled = true;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void Anular()
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {
                if (Environment.UserName.ToString().Trim().Contains("EAURAZOC") || Environment.UserName.ToString().Trim().Contains("ZSAAVEDRA") || Environment.UserName.ToString().Trim().Contains("BONILLA") || Environment.UserName.ToString().Trim().Contains("LLONTOP") || Environment.UserName.ToString().Trim().Contains("JGUERRERO") || Environment.UserName.ToString().Trim().Contains("FPENAU"))
                {
                    #region Como administrador()
                    modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                    SJ_RHMovimientoAsistenciaPension movimientoAnudo = new SJ_RHMovimientoAsistenciaPension();
                    movimientoAnudo.idMovimiento = codigo.ToString().Trim();
                    //modelo.Anular(movimientoAnudo);
                    modelo.Anular(movimientoAnudo, DateTime.Now.Year.ToString());
                    PresentarDocumentSerieNumeroDocumento();
                    progressBar.Visible = false;
                    barraPrincipal.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnAnular.Enabled = true;
                    btnExportar.Enabled = true;
                    btnHistorial.Enabled = false;
                    //btnActualizarLista.Enabled = false;
                    btnSalir.Enabled = true;
                    this.btnQuitar.Enabled = false;
                    detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                    #endregion
                }
                else
                {
                    if (this.txtEstadoCodigo.Text == "PE")
                    {
                        #region Usuario normal()
                        modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                        SJ_RHMovimientoAsistenciaPension movimientoAnudo = new SJ_RHMovimientoAsistenciaPension();
                        movimientoAnudo.idMovimiento = codigo.ToString().Trim();
                        //modelo.Anular(movimientoAnudo);
                        modelo.Anular(movimientoAnudo, DateTime.Now.Year.ToString());
                        PresentarDocumentSerieNumeroDocumento();
                        progressBar.Visible = false;
                        barraPrincipal.Enabled = true;
                        btnNuevo.Enabled = true;
                        btnEditar.Enabled = true;
                        btnGuardar.Enabled = false;
                        btnEliminar.Enabled = true;
                        btnAnular.Enabled = true;
                        btnExportar.Enabled = true;
                        btnHistorial.Enabled = false;
                        //btnActualizarLista.Enabled = false;
                        btnSalir.Enabled = true;
                        this.btnQuitar.Enabled = false;
                        detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                        #endregion
                    }
                }

            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {
                if (Environment.UserName.ToString().Trim().Contains("EAURAZOC") || Environment.UserName.ToString().Trim().Contains("ZSAAVEDRA") || Environment.UserName.ToString().Trim().Contains("BONILLA") || Environment.UserName.ToString().Trim().Contains("LLONTOP") || Environment.UserName.ToString().Trim().Contains("JGUERRERO") || Environment.UserName.ToString().Trim().Contains("FPENAU"))
                {
                    if (this.txtEstadoCodigo.Text.Trim() == "PE")
                    {
                        #region Como administrador()
                        modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                        SJ_RHMovimientoAsistenciaPension movimientoAnudo = new SJ_RHMovimientoAsistenciaPension();
                        movimientoAnudo.idMovimiento = codigo.ToString().Trim();
                        //modelo.Anular(movimientoAnudo);
                        modelo.Eliminar(movimientoAnudo, DateTime.Now.Year.ToString());

                        progressBar.Visible = false;
                        barraPrincipal.Enabled = true;
                        btnNuevo.Enabled = true;
                        btnEditar.Enabled = true;
                        btnGuardar.Enabled = false;
                        btnEliminar.Enabled = true;
                        btnAnular.Enabled = true;
                        btnExportar.Enabled = true;
                        btnHistorial.Enabled = false;
                        //btnActualizarLista.Enabled = false;
                        btnSalir.Enabled = true;
                        this.btnQuitar.Enabled = false;
                        detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                        #endregion
                    }
                }

            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void Exportar()
        {
            throw new NotImplementedException();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MovimientoAsistenciaRefrigerioMatenimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwSubProceso3.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (this.bgwSubProceso2.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (this.bgwSubProceso4.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Atras();
        }

        private void Atras()
        {
            if (this.txtCodigoRegistro.Text.ToString().Trim() != "")
            {
                this.btnQuitar.Enabled = false;
                progressBar.Visible = false;
                gbCabecera.Enabled = true;
                gbDetalle.Enabled = true;
                barraPrincipal.Enabled = true;
                btnNuevo.Enabled = true;
                btnAtras.Enabled = false;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = true;
                btnAnular.Enabled = true;
                btnExportar.Enabled = true;
                btnHistorial.Enabled = false;
                //btnActualizarLista.Enabled = false;
                btnSalir.Enabled = true;
            }
        }

        public List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult> listadoMovimientoAsistenciaRefrigerios { get; set; }

        private void bgwSubProcesoObtenerDocumentoAsistenciaProcesada_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                movimientoAsistenciaProcesadaRefrigerioByCodigo = new SJ_RHMovimientoAsistenciasProcesadasByCodigoResult();
                detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
                movimientoAsistenciaProcesadaRefrigerioByCodigo = modelo.ObteneMovimientoAsistenciaProcesadaRefrigerioByCodigo(codigo);
                detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo = modelo.ObtenerListadoDetalleMovimientoAsistenciasProcesadasByCodigo(codigo);

                documentoNegocio = new DocumentoNegocio();
                oDocumentoMovimientoxCodDocumento = new SJ_ObtenerDocumentoMovimientoResult();
                oDocumentoMovimientoxCodDocumentos = new List<SJ_ObtenerDocumentoMovimientoResult>();
                oDocumentoMovimientoxCodDocumento = documentoNegocio.ObtenerDocumentoMovimientoxCodDocumento(this.codigoDocumento);
                oDocumentoMovimientoxCodDocumentos.Add(oDocumentoMovimientoxCodDocumento);

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwSubProcesoObtenerDocumentoAsistenciaProcesada_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                #region Cargar datos a contol de cabecera()
                this.txtEstado.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.estado != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.estado.ToString().Trim() : string.Empty;

                string idestado = movimientoAsistenciaProcesadaRefrigerioByCodigo.idEstado != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.idEstado.ToString().Trim() : "AN";
                if (idestado == "AN")
                {
                    this.txtEstado.TextBoxElement.TextBoxItem.BackColor = Utiles.colorRojoClaro;
                    this.txtEstado.TextBoxElement.TextBoxItem.ForeColor = Color.Black;
                }
                if (idestado == "PE")
                {
                    this.txtEstado.TextBoxElement.TextBoxItem.BackColor = Color.White;
                    this.txtEstado.TextBoxElement.TextBoxItem.ForeColor = Color.Black;
                }

                if (idestado == "PR")
                {
                    this.txtEstado.TextBoxElement.TextBoxItem.BackColor = Utiles.colorVerdeClaro;
                    this.txtEstado.TextBoxElement.TextBoxItem.ForeColor = Color.Black;
                }

                this.txtEstadoCodigo.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.idEstado != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.idEstado.ToString().Trim() : string.Empty;
                this.txtProveedorCodigo.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.IdPension != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.IdPension.ToString().Trim() : string.Empty;
                this.txtProveedorNroRUC.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.IdPension != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.IdPension.ToString().Trim() : string.Empty;
                this.txtDocumentoNumero.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.documento != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.documento.ToString().Trim() : string.Empty;
                this.txtDocumentoFecha.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.fecha != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.fecha.ToPresentationDate() : string.Empty;
                this.txtProveedorRazonSocial.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.RAZON_SOCIAL != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.RAZON_SOCIAL.ToString().Trim() : string.Empty;
                this.txtProveedorNroRUC.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.idclieprov != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.idclieprov.ToString().Trim() : string.Empty;
                this.txtProveedorPseudoNombre.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.nombreComercial != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.nombreComercial.ToString().Trim() : string.Empty;
                this.txtOperacionNumero.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.numeroOperacion != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.numeroOperacion.ToString().Trim() : string.Empty;


                this.txtnroDniPension.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.dniPension != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.dniPension.ToString().Trim() : string.Empty;
                //this.txtProveedorRazonSocial.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.RAZON_SOCIAL != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.RAZON_SOCIAL.ToString().Trim() : string.Empty;
                this.txtProveedorCodigo.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.dniPension != null ? modelo.ObtenerCodigoProveedor(movimientoAsistenciaProcesadaRefrigerioByCodigo.dniPension.ToString().Trim()) : string.Empty;
                this.txtProveedorNroRUC.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.dniPension != null ? modelo.ObtenerNroRucProveedor(movimientoAsistenciaProcesadaRefrigerioByCodigo.dniPension.ToString().Trim()) : string.Empty;
                this.txtProveedorPseudoNombre.Text = movimientoAsistenciaProcesadaRefrigerioByCodigo.dniPension != null ? modelo.ObtenerPseudoNomnbreProveedor(movimientoAsistenciaProcesadaRefrigerioByCodigo.dniPension.ToString().Trim()) : string.Empty;


                this.cboDocumentoCodigo.DisplayMember = "idDocumento";
                this.cboDocumentoCodigo.ValueMember = "idDocumento";
                this.cboDocumentoCodigo.DataSource = oDocumentoMovimientoxCodDocumentos;
                this.cboDocumentoCodigo.SelectedValue = movimientoAsistenciaProcesadaRefrigerioByCodigo.idDocumento != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.idDocumento.ToString().Trim() : string.Empty;

                this.cboDocumentoSerie.DisplayMember = "serie";
                this.cboDocumentoSerie.ValueMember = "serie";
                this.cboDocumentoSerie.DataSource = oDocumentoMovimientoxCodDocumentos;
                this.cboDocumentoSerie.SelectedValue = movimientoAsistenciaProcesadaRefrigerioByCodigo.serie != null ? movimientoAsistenciaProcesadaRefrigerioByCodigo.serie.ToString().Trim() : string.Empty;

                #endregion

                #region Cargar datos a contol de detalle()

                this.txtRefrigerioTotalDesayunos.Text = "0";
                this.txtRefrigerioTotalAlmuerzos.Text = "0";
                this.txtRefrigerioTotalCenas.Text = "0";

                if (detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo != null && detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.ToList().Count > 0)
                {

                    int totalDesayunos, totalAlmuerzos, totalCenas = 0;
                    totalDesayunos = detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo != null ? detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.Where(x => x.Refrigerio == "DESAYUNO").ToList().Count : 0;
                    totalAlmuerzos = detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo != null ? detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.Where(x => x.Refrigerio == "ALMUERZO").ToList().Count : 0;
                    totalCenas = detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo != null ? detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.Where(x => x.Refrigerio == "CENA").ToList().Count : 0;

                    this.txtRefrigerioTotalDesayunos.Text = totalDesayunos.ToString();
                    this.txtRefrigerioTotalAlmuerzos.Text = totalAlmuerzos.ToString();
                    this.txtRefrigerioTotalCenas.Text = totalCenas.ToString();

                    dgvRegistrosAsistencias.CargarDatos(detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.ToList().ToDataTable<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>());
                    dgvRegistrosAsistencias.Refresh();
                }
                else
                {
                    dgvRegistrosAsistencias.CargarDatos(detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.ToList().ToDataTable<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>());
                    dgvRegistrosAsistencias.Refresh();
                }


                progressBar.Visible = false;
                detalleMovimientoEliminado = new List<SJ_RHMovimientoAsistenciaPensionDetalle>();
                #endregion

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void MovimientoAsistenciaRefrigerioMatenimiento_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtEmpresaCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtEmpresaDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtSucursalCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtSucursalDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtPeriodoNombre_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtOperacionNumero_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void btnBuscarPension_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtProveedorNroRUC_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtProveedorRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtProveedorPseudoNombre_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtEstado_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void cboDocumentoCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void cboDocumentoSerie_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtDocumentoNumero_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtDocumentoFecha_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void dgvRegistrosAsistencias_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void EdicionDesdeTeclado(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Registrar();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Editar();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Atras();
            }
        }

        private void gbCabecera_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void txtnroDniPension_Leave(object sender, EventArgs e)
        {
            string[] cadena = this.txtProveedorRazonSocial.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPension(cadena);
            }

            if (this.txtProveedorPseudoNombre.Text != "" && this.txtProveedorRazonSocial.Text.ToString().Trim() == "")
            {
                this.txtProveedorPseudoNombre.Clear();
                this.txtnroDniPension.Clear();
                this.txtProveedorNroRUC.Clear();
            }
        }

        private void AsignarDatosPension(string[] ncadena)
        {
            this.txtProveedorRazonSocial.Text = ncadena[0].ToString().Trim();
            this.txtProveedorCodigo.Text = ncadena[3].ToString().Trim();
            this.txtProveedorNroRUC.Text = ncadena[1].ToString().Trim();
            this.txtProveedorPseudoNombre.Text = ncadena[2].ToString().Trim();
        }

        private void btnBuscarTransportista_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarPension_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarAsistenciaDesdeProgramacion_Click(object sender, EventArgs e)
        {

            if (txtnroDniPension.Text.Trim() != string.Empty && txtProveedorRazonSocial.Text.Trim() != string.Empty && txtProveedorPseudoNombre.Text.Trim() != string.Empty && txtDocumentoFecha.Text != string.Empty)
            {
                RegistroAsistenciaRefrigerioGenerarAsistencia ofrm = new RegistroAsistenciaRefrigerioGenerarAsistencia(txtnroDniPension.Text.Trim(), txtProveedorRazonSocial.Text.Trim(), txtProveedorPseudoNombre.Text.Trim(), txtDocumentoFecha.Text);
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    if (ofrm.listaImportadaByProgramacion != null && ofrm.listaImportadaByProgramacion.ToList().Count > 0)
                    {
                        if (detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo != null)
                        {
                            detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();
                            detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva = ofrm.listaImportadaByProgramacion;
                            detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.AddRange(ofrm.listaImportadaByProgramacion);
                            dgvRegistrosAsistencias.CargarDatos(detalleMovimientoAsistenciaProcesadaRefrigerioByCodigo.ToDataTable<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>());
                            dgvRegistrosAsistencias.Refresh();

                            if (detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva != null && detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva.ToList().Count > 0)
                            {

                                int nroCenas, nroAlmuerzo, nroDesayunos = 0;
                                nroDesayunos = detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva.Count(x => x.TipoComida == 0);
                                nroAlmuerzo = detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva.Count(x => x.TipoComida == 1);
                                nroCenas = detalleMovimientoAsistenciaProcesadaRefrigerioByCodigoNueva.Count(x => x.TipoComida == 2);

                                txtRefrigerioTotalDesayunos.Text = nroDesayunos.ToString();
                                this.txtRefrigerioTotalAlmuerzos.Text = nroAlmuerzo.ToString();
                                this.txtRefrigerioTotalCenas.Text = nroCenas.ToString();
                            }



                        }
                    }
                    else
                    {

                    }
                }
            }


        }



        public string codigoDocumento { get; set; }

        private void bgwCargarObjeto_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgwHiloConsultarRegistros_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
