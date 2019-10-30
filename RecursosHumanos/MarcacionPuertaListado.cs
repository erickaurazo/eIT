using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using RecursosHumanos.Negocios;
using System.Configuration;
using DevSoftSolutionsControls;
using DevSoftSolutionsDataAccess;
using DevSoftSolutionsExtensions;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using System.Collections;
using MyControlsDataBinding.Controles;

namespace RecursosHumanos
{
    public partial class MarcacionPuertaListado : Form
    {
        private string p;
        private string p_2;
        private string p_3;
        private string p_4;
        private string codigoUnicoAccesoSistema;
        private string codigoUsuario;
        private string codigoTipoPlanilla;
        private string semanaPlanilla;
        private UsuarioMovimientoIngresoSistemaNegocio usuarioMovimientoIngresoSistemaModelo;
        private UsuarioMovimientoIngresoSistema usuario;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekResult> listadoMarcacionesBiometricoByPlanillaByWeek;
        private CheckInOutNegocio modeloMarcacionBiometrico;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupadoResult> listadoMarcacionesBiometricoByPlanillaByWeekAgrupado;
        private string codigoEditar;
        private string fechaEditar;
        private MarcacionPuertaMantenimiento oFormulario;
        private string fileName;
        private bool exportVisualSettings;
        private string codigoMovimiento;

        //private UsuarioMovimientoIngresoSistema _conexionUsuario;
        //private global::ModuloLogistica.Controller.UsuarioMovimientoIngresoSistema conexionUsuario;

        public MarcacionPuertaListado()
        {
            InitializeComponent();
        }

        public MarcacionPuertaListado(UsuarioMovimientoIngresoSistema conexionUsuario)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            //this._conexionUsuario = conexionUsuario;
            Program.ClaseCompartida.periodoElegido = conexionUsuario.periodoElegido != null ? conexionUsuario.periodoElegido : string.Empty;
            Program.ClaseCompartida.codigoTipoPlanilla = conexionUsuario.codigoPlanillaElegida != null ? conexionUsuario.codigoPlanillaElegida : string.Empty;
            Program.ClaseCompartida.semanaPlanilla = conexionUsuario.semanaPlanillaElegida != null ? conexionUsuario.semanaPlanillaElegida : string.Empty;
            Program.ClaseCompartida.CodigoUnicoAccesoSistema = conexionUsuario.codigoAcceso != null ? conexionUsuario.codigoAcceso : string.Empty;
            Program.ClaseCompartida.codigoUsuario = conexionUsuario.IdUsuario != null ? conexionUsuario.IdUsuario : string.Empty;
            Program.ClaseCompartida.fechaAcceso = conexionUsuario.fechaAcceso != null ? conexionUsuario.fechaAcceso : DateTime.Now;
            Program.ClaseCompartida.desde = conexionUsuario.desde != null ? conexionUsuario.desde : DateTime.Now;
            Program.ClaseCompartida.hasta = conexionUsuario.hasta != null ? conexionUsuario.hasta : DateTime.Now;
            Program.ClaseCompartida.nombreUsuario = conexionUsuario.nombreUsuario != null ? conexionUsuario.nombreUsuario : string.Empty;

            RadGridLocalizationProvider.CurrentProvider = new ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            lblPeriodoNombre.Text = Program.ClaseCompartida.periodoElegido + " - " + Program.ClaseCompartida.semanaPlanilla;

            lblPlanillaNombre.Text = Program.ClaseCompartida.codigoTipoPlanilla;
            gbRegistros.Enabled = !true;
            menuPrincipal.Enabled = !true;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
        }

        public MarcacionPuertaListado(string codigoUnicoAccesoSistema, string codigoUsuario, string codigoTipoPlanilla, string semanaPlanilla)
        {
            InitializeComponent();
            this.codigoUnicoAccesoSistema = codigoUnicoAccesoSistema;
            this.codigoUsuario = codigoUsuario;
            this.codigoTipoPlanilla = codigoTipoPlanilla;
            this.semanaPlanilla = semanaPlanilla;

            usuarioMovimientoIngresoSistemaModelo = new UsuarioMovimientoIngresoSistemaNegocio();
            usuario = new UsuarioMovimientoIngresoSistema();
            usuario.codigoAcceso = codigoUnicoAccesoSistema;
            usuario = usuarioMovimientoIngresoSistemaModelo.ObtenerMovimientoIngresoSistemaByCodigoMovimiento(usuario);

            Program.ClaseCompartida.periodoElegido = usuario.periodoElegido != null ? usuario.periodoElegido : string.Empty;
            Program.ClaseCompartida.codigoTipoPlanilla = usuario.codigoPlanillaElegida != null ? usuario.codigoPlanillaElegida : string.Empty;
            Program.ClaseCompartida.semanaPlanilla = usuario.semanaPlanillaElegida != null ? usuario.semanaPlanillaElegida : string.Empty;
            Program.ClaseCompartida.CodigoUnicoAccesoSistema = usuario.codigoAcceso != null ? usuario.codigoAcceso : string.Empty;
            Program.ClaseCompartida.codigoUsuario = usuario.IdUsuario != null ? usuario.IdUsuario : string.Empty;
            Program.ClaseCompartida.fechaAcceso = usuario.fechaAcceso != null ? usuario.fechaAcceso : DateTime.Now;
            Program.ClaseCompartida.desde = usuario.desde != null ? usuario.desde : DateTime.Now;
            Program.ClaseCompartida.hasta = usuario.hasta != null ? usuario.hasta : DateTime.Now;
            Program.ClaseCompartida.nombreUsuario = usuario.nombreUsuario != null ? usuario.nombreUsuario : string.Empty;
            RadGridLocalizationProvider.CurrentProvider = new ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            lblPeriodoNombre.Text = Program.ClaseCompartida.periodoElegido + " - " + semanaPlanilla;
            lblPlanillaNombre.Text = codigoTipoPlanilla;
            gbRegistros.Enabled = !true;
            menuPrincipal.Enabled = !true;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
        }


        private void MarcacionPuertaListado_Load(object sender, EventArgs e)
        {

        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (chkActualizarMarcacionByFechaUnica.Checked == true)
                {
                    modeloMarcacionBiometrico = new CheckInOutNegocio();
                    modeloMarcacionBiometrico.ActualizarFechaTransferenciaByFechas(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.desde.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.hasta.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.codigoTipoPlanilla);
                }

                listadoMarcacionesBiometricoByPlanillaByWeek = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekResult>();
                listadoMarcacionesBiometricoByPlanillaByWeekAgrupado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupadoResult>();

                modeloMarcacionBiometrico = new CheckInOutNegocio();
                //listadoMarcacionesBiometricoByPlanillaByWeek = modeloMarcacionBiometrico.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeek(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.desde.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.hasta.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.codigoTipoPlanilla).ToList();
                listadoMarcacionesBiometricoByPlanillaByWeekAgrupado = modeloMarcacionBiometrico.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupado(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.desde.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.hasta.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.codigoTipoPlanilla).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvRegistros.DataSource = listadoMarcacionesBiometricoByPlanillaByWeekAgrupado.OrderBy(x=> x.fechaAsistencia.Value).ToList().ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupadoResult>();
                dgvRegistros.Refresh();
                gbRegistros.Enabled = true;
                menuPrincipal.Enabled = true;
                ProgressBar.Visible = !true;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgvRegistros_Click(object sender, EventArgs e)
        {

        }

        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {
            codigoEditar = string.Empty;
            fechaEditar = string.Empty;
            codigoMovimiento = string.Empty;

            if (dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                if (dgvRegistros.CurrentRow != null)
                {
                    if (dgvRegistros.CurrentRow.Cells["chcodigoTransferencia"].Value != null && dgvRegistros.CurrentRow.Cells["chcodigoTransferencia"].Value.ToString().Trim() != "")
                    {
                        codigoEditar = dgvRegistros.CurrentRow.Cells["chcodigoTransferencia"].Value != null ? dgvRegistros.CurrentRow.Cells["chcodigoTransferencia"].Value.ToString().Trim() : string.Empty;
                        fechaEditar = dgvRegistros.CurrentRow.Cells["chfechaAsistencia"].Value != null ? dgvRegistros.CurrentRow.Cells["chfechaAsistencia"].Value.ToString().Trim() : string.Empty;
                        codigoMovimiento = dgvRegistros.CurrentRow.Cells["chCodigoMovimientoAsistencia"].Value != null ? dgvRegistros.CurrentRow.Cells["chCodigoMovimientoAsistencia"].Value.ToString().Trim() : string.Empty;


                    }
                }
            }

            gbRegistros.Enabled = true;
            menuPrincipal.Enabled = true;
            ProgressBar.Visible = !true;
        }

        private void dgvRegistros_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (codigoEditar != string.Empty && fechaEditar != string.Empty)
                {
                    Editar(codigoEditar, "001", Program.ClaseCompartida.periodoElegido, fechaEditar, codigoMovimiento);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        private void Editar(string codigoEditar, string empresaCodigo, string periodo, string fechaEditar, string codigoMovimiento)
        {
            try
            {
                empresaCodigo = "001";
                periodo = Program.ClaseCompartida.periodoElegido;
                oFormulario = new MarcacionPuertaMantenimiento(codigoEditar, fechaEditar, usuario, codigoMovimiento, Program.ClaseCompartida.codigoTipoPlanilla, Program.ClaseCompartida.desde.ToPresentationDate(), Program.ClaseCompartida.hasta.ToPresentationDate(), Program.ClaseCompartida.periodoElegido);
                //oFormulario.MdiParent = RegistroAsistenciaPersonalGarita.ActiveForm;                
                //oFormulario.WindowState = FormWindowState.Maximized;
                //oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                oFormulario.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigoEditar != string.Empty && fechaEditar != string.Empty)
                {
                    Editar(codigoEditar, "001", Program.ClaseCompartida.periodoElegido, fechaEditar, codigoMovimiento);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            gbRegistros.Enabled = !true;
            menuPrincipal.Enabled = !true;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }


        private void ExportarExcel()
        {
            if (dgvRegistros != null)
            {
                if (dgvRegistros.Rows.Count > 0)
                {
                    Exportar(this.dgvRegistros);
                }
            }
        }

        private void Exportar(RadGridView radGridView)
        {
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(radGridView.ThemeName);
                RadMessageBox.Show("Ingrese nombre al archivo.");
                return;
            }

            fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;
            this.exportVisualSettings = true;
            RunExportToExcelML(fileName, ref openExportFile, radGridView);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("El archivo no pudo ser ejecutado por el sistema.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Abrir Archivo", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private void RunExportToExcelML(string fileName, ref bool openExportFile, RadGridView grilla)
        {
            ExportToExcelML excelExporter = new ExportToExcelML(grilla);
            excelExporter.SheetName = "Rpt Sistema";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
            excelExporter.HiddenColumnOption = HiddenOption.DoNotExport; /* no mostrar columnas ocultas*/
            try
            {
                excelExporter.RunExport(fileName);
                RadMessageBox.SetThemeName(grilla.ThemeName);
                DialogResult dr = RadMessageBox.Show("La exportación ha sido generada correctamente. Desea abrir el Archivo?",
                    "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(grilla.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }




    }

}
