using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
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


    public partial class MovimientoRecorridosImportarAsistenciaDesdeMoviles : Form
    {

        List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult> oLitadoIngreso = new List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult>();
        List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult> oLitadoSalida = new List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult>();
        public List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult> oLitadoSelecionadoByIngreso = new List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult>();
        public List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult> oLitadoSelecionadoBySalida = new List<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult>();
        private oCabeceraImportacionParteTransporteTercerosByMovil odatosCabeceraFormulario;
        private MovimientoMovilidadNegocio modelo;
        private int numeroitem;

        public MovimientoRecorridosImportarAsistenciaDesdeMoviles()
        {
            InitializeComponent();


        }

        public MovimientoRecorridosImportarAsistenciaDesdeMoviles(oCabeceraImportacionParteTransporteTercerosByMovil odatosCabeceraFormulario)
        {
            InitializeComponent();
            this.odatosCabeceraFormulario = odatosCabeceraFormulario;
            gbDocumentoRegistro.Enabled = false;
            gbProcedencia.Enabled = false;
            gbTransportistaInformacion.Enabled = false;
            dgvListadoTrabajadoresIngreso.Enabled = false;
            bgwHilo.RunWorkerAsync();

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                modelo = new MovimientoMovilidadNegocio();
                string periodo = (this.odatosCabeceraFormulario.fechaDocumento.Substring(6, 4) + this.odatosCabeceraFormulario.fechaDocumento.Substring(3, 2).PadLeft(2, '0'));
                oLitadoIngreso = modelo.ObtenerListadoMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRuta(periodo, this.odatosCabeceraFormulario.codigoFormulario, this.odatosCabeceraFormulario.unidadMovilPlaca, Convert.ToInt32(this.odatosCabeceraFormulario.rutaOrigenCodigo), this.odatosCabeceraFormulario.conductorDNI, this.odatosCabeceraFormulario.fechaDocumento, 'I').ToList();
                oLitadoSalida = modelo.ObtenerListadoMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRuta(periodo, this.odatosCabeceraFormulario.codigoFormulario, this.odatosCabeceraFormulario.unidadMovilPlaca, Convert.ToInt32(this.odatosCabeceraFormulario.rutaDestinoCodigo), this.odatosCabeceraFormulario.conductorDNI, this.odatosCabeceraFormulario.fechaDocumento, 'S').ToList();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void MovimientoRecorridosImportarAsistenciaDesdeMoviles_Load(object sender, EventArgs e)
        {

        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {



                this.txtEmpresaCodigo.Text = this.odatosCabeceraFormulario.empresaCodigo != null ? this.odatosCabeceraFormulario.empresaCodigo : string.Empty;
                this.txtEmpresaDescripcion.Text = this.odatosCabeceraFormulario.empresaDescripcion != null ? this.odatosCabeceraFormulario.empresaDescripcion : string.Empty;
                this.txtCodigoFormulario.Text = this.odatosCabeceraFormulario.codigoFormulario != null ? this.odatosCabeceraFormulario.codigoFormulario : string.Empty;
                this.txtPeriodoNombre.Text = this.odatosCabeceraFormulario.periodo != null ? this.odatosCabeceraFormulario.periodo : string.Empty;
                this.txtPeriodo.Text = this.odatosCabeceraFormulario.periodoFormato != null ? this.odatosCabeceraFormulario.periodoFormato : string.Empty;
                this.txtEstadoDocumentoCodigo.Text = this.odatosCabeceraFormulario.estadoCodigo != null ? this.odatosCabeceraFormulario.estadoCodigo : string.Empty;
                this.txtEstadoDocumentoDescripcion.Text = this.odatosCabeceraFormulario.estadoDescripcion != null ? this.odatosCabeceraFormulario.estadoDescripcion : string.Empty;
                this.txtNumeroManualExterno.Text = this.odatosCabeceraFormulario.numeroManual != null ? this.odatosCabeceraFormulario.numeroManual : string.Empty;
                this.cboIdDocumento.Text = this.odatosCabeceraFormulario.codigoDocumento != null ? this.odatosCabeceraFormulario.codigoDocumento : string.Empty;
                this.cboSerie.Text = this.odatosCabeceraFormulario.serieDocumento != null ? this.odatosCabeceraFormulario.serieDocumento : string.Empty;
                this.txtNumeroDocumento.Text = this.odatosCabeceraFormulario.numeroDocumento != null ? this.odatosCabeceraFormulario.numeroDocumento : string.Empty;
                this.txtFechaDocumento.Text = this.odatosCabeceraFormulario.fechaDocumento != null ? this.odatosCabeceraFormulario.fechaDocumento : string.Empty;
                this.txtTransportistaCodigo.Text = this.odatosCabeceraFormulario.unidadMovilCodigo != null ? this.odatosCabeceraFormulario.unidadMovilCodigo : string.Empty;
                this.txtPlaca.Text = this.odatosCabeceraFormulario.unidadMovilPlaca != null ? this.odatosCabeceraFormulario.unidadMovilPlaca : string.Empty;
                this.txtRUC.Text = this.odatosCabeceraFormulario.unidadMovilRUC != null ? this.odatosCabeceraFormulario.unidadMovilRUC : string.Empty;
                this.txtTipoMovilidad.Text = this.odatosCabeceraFormulario.unidadMovilTipoMovilidad != null ? this.odatosCabeceraFormulario.unidadMovilTipoMovilidad : string.Empty;
                this.txtPseudonombre.Text = this.odatosCabeceraFormulario.unidadMovilNombreComercial != null ? this.odatosCabeceraFormulario.unidadMovilNombreComercial : string.Empty;
                this.txtRazonSocial.Text = this.odatosCabeceraFormulario.unidadMovilRazonSocial != null ? this.odatosCabeceraFormulario.unidadMovilRazonSocial : string.Empty;
                this.txtNroAsientos.Text = this.odatosCabeceraFormulario.unidadMovilNumeroAsientos != null ? this.odatosCabeceraFormulario.unidadMovilNumeroAsientos : string.Empty;
                this.txtChoferCodigo.Text = this.odatosCabeceraFormulario.conductorCodigo != null ? this.odatosCabeceraFormulario.conductorCodigo : string.Empty;
                this.txtChofeDNI.Text = this.odatosCabeceraFormulario.conductorDNI != null ? this.odatosCabeceraFormulario.conductorDNI : string.Empty;
                this.txtChoferNombres.Text = this.odatosCabeceraFormulario.conductorNombres != null ? this.odatosCabeceraFormulario.conductorNombres : string.Empty;
                this.txtRutaOrigen.Text = this.odatosCabeceraFormulario.rutaOrigenDescripcion != null ? this.odatosCabeceraFormulario.rutaOrigenDescripcion : string.Empty;
                this.txtPrecioProcedenciaOrigen.Text = this.odatosCabeceraFormulario.rutaOrigenPrecio != null ? this.odatosCabeceraFormulario.rutaOrigenPrecio : string.Empty;
                this.txtItemIda.Text = this.odatosCabeceraFormulario.rutaOrigenItem != null ? this.odatosCabeceraFormulario.rutaOrigenItem : string.Empty;
                this.txtCodigoRutaOrigen.Text = this.odatosCabeceraFormulario.rutaOrigenCodigo != null ? this.odatosCabeceraFormulario.rutaOrigenCodigo : string.Empty;
                this.txtRutaDestino.Text = this.odatosCabeceraFormulario.rutaDestinoDescripcion != null ? this.odatosCabeceraFormulario.rutaDestinoDescripcion : string.Empty;
                this.txtPrecioProcedenciaDestino.Text = this.odatosCabeceraFormulario.rutDestinoPrecio != null ? this.odatosCabeceraFormulario.rutDestinoPrecio : string.Empty;
                this.txtItemRegreso.Text = this.odatosCabeceraFormulario.rutaDestinoItem != null ? this.odatosCabeceraFormulario.rutaDestinoItem : string.Empty;
                this.txtCodigoRutaDestino.Text = this.odatosCabeceraFormulario.rutaDestinoCodigo != null ? this.odatosCabeceraFormulario.rutaDestinoCodigo : string.Empty;

                dgvListadoTrabajadoresIngreso.DataSource = oLitadoIngreso.ToDataTable<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult>();
                dgvListadoTrabajadoresIngreso.Refresh();

                dgvListadoTrabajadoresSalida.DataSource = oLitadoSalida.ToDataTable<SJ_RHObtenerMarcacionesFromMovilParaParteDiarioTransporteByPlacaByFechaByConductorByRutaResult>();
                dgvListadoTrabajadoresSalida.Refresh();

                gbDocumentoRegistro.Enabled = !false;
                gbProcedencia.Enabled = !false;
                gbTransportistaInformacion.Enabled = !false;
                dgvListadoTrabajadoresIngreso.Enabled = !false;

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            numeroitem = 1;
            if (dgvListadoTrabajadoresIngreso.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgvListadoTrabajadoresIngreso.Rows)
                {
                    if (item.Cells["chSelecionar"].Value != null && item.Cells["chSelecionar"].Value.ToString().Trim() != string.Empty)
                    {
                        if (Convert.ToInt32(item.Cells["chSelecionar"].Value) == 1)
                        {
                            var resultado = oLitadoIngreso.Where(x => x.idRegistroMovil == Convert.ToInt32(item.Cells["chidRegistroMovil"].Value)).ToList();

                            if (resultado.Count > 0)
                            {
                                oLitadoSelecionadoByIngreso.AddRange(resultado);
                            }
                        }
                        numeroitem = +1;
                    }
                }
            }

            if (dgvListadoTrabajadoresSalida.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgvListadoTrabajadoresSalida.Rows)
                {
                    if (item.Cells["chSelecionarS"].Value != null && item.Cells["chSelecionarS"].Value.ToString().Trim() != string.Empty)
                    {
                        if (Convert.ToInt32(item.Cells["chSelecionarS"].Value) == 1)
                        {
                            var resultado = oLitadoSalida.Where(x => x.idRegistroMovil == Convert.ToInt32(item.Cells["chidRegistroMovilS"].Value)).ToList();

                            if (resultado.Count > 0)
                            {
                                oLitadoSelecionadoBySalida.AddRange(resultado);
                            }
                        }
                        numeroitem = +1;
                    }
                }
            }



        }
    }
}
