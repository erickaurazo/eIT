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
    public partial class MovimientoAsistenciaListado : Telerik.WinControls.UI.RadForm
    {
        private string codigoUnicoAccesoSistema;
        private string codigoUsuario;
        private string codigoTipoPlanilla;
        private string semanaPlanilla;
        private List<ObtenerListadoAsistenciaByPlanillaBySemanaResult> listadoAsistencias;
        private AsistenciaNegocio asistenciaNegocio;
        private UsuarioMovimientoIngresoSistemaNegocio usuarioMovimientoIngresoSistemaModelo;
        private UsuarioMovimientoIngresoSistema usuario;
        private string codigo;
        private MovimientoAsistenciaMantenimiento oFormulario;
        private string empresaCodigo;
        private string codigoEditar = string.Empty;
        private string periodo;
        private string fileName;
        private bool exportVisualSettings;
        private string codigoTransferencia;


        public MovimientoAsistenciaListado()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public MovimientoAsistenciaListado(string codigoUnicoAccesoSistema, string codigoUsuario, string codigoTipoPlanilla, string semanaPlanilla)
        {
            // TODO: Complete member initialization
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

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                asistenciaNegocio = new AsistenciaNegocio();
                listadoAsistencias = new List<ObtenerListadoAsistenciaByPlanillaBySemanaResult>();
                listadoAsistencias = asistenciaNegocio.ObtenerMovimientosAsistenciaByPeriodosByPlanilla(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.codigoTipoPlanilla, Program.ClaseCompartida.semanaPlanilla).ToList();

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
                dgvRegistros.DataSource = listadoAsistencias.ToDataTable<ObtenerListadoAsistenciaByPlanillaBySemanaResult>();
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

        private void MovimientoAsistenciaListado_Load(object sender, EventArgs e)
        {

        }

        private void dgvRegistros_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (codigoEditar != string.Empty)
                {
                    Editar(codigoEditar, "001", Program.ClaseCompartida.periodoElegido);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        private void Editar(string codigoEditar, string empresaCodigo, string periodo)
        {
            try
            {
                empresaCodigo = "001";
                periodo = Program.ClaseCompartida.periodoElegido;
                oFormulario = new MovimientoAsistenciaMantenimiento(codigoEditar, usuario);
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                empresaCodigo = "001";
                periodo = Program.ClaseCompartida.periodoElegido;
                oFormulario = new MovimientoAsistenciaMantenimiento(codigoEditar, usuario);
                //oFormulario.MdiParent = RegistroAsistenciaPersonalGarita.ActiveForm;

                oFormulario.WindowState = FormWindowState.Maximized;
                oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                oFormulario.Show();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        private void dgvRegistros_Leave(object sender, EventArgs e)
        {

        }

        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {
            codigoEditar = string.Empty;
            codigoTransferencia = string.Empty;

            if (dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                if (dgvRegistros.CurrentRow != null)
                {
                    if (dgvRegistros.CurrentRow.Cells["chcodigoAsistencia"].Value != null && dgvRegistros.CurrentRow.Cells["chcodigoAsistencia"].Value.ToString().Trim() != "")
                    {
                        codigoEditar = dgvRegistros.CurrentRow.Cells["chcodigoAsistencia"].Value != null ? dgvRegistros.CurrentRow.Cells["chcodigoAsistencia"].Value.ToString().Trim() : string.Empty;
                        codigoTransferencia = dgvRegistros.CurrentRow.Cells["chcodigoReferencia"].Value != null ? dgvRegistros.CurrentRow.Cells["chcodigoReferencia"].Value.ToString().Trim() : string.Empty;
                    }
                }
            }

            gbRegistros.Enabled = true;
            menuPrincipal.Enabled = true;
            ProgressBar.Visible = !true;

        }

        private void EdicionDesdeTeclado(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {

            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Editar();
            }
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                Anular();
            }
            if (e.KeyData == (Keys.Control | Keys.D))
            {
                Elimiar();
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

        private void Anular()
        {
            if (codigoEditar != null && codigoEditar.ToString().Trim() != "")
            {
                asistenciaNegocio = new AsistenciaNegocio();
                asistenciaNegocio.AnularDocumento(Program.ClaseCompartida.periodoElegido, codigoEditar, codigoTransferencia);
                Consultar();

            }
        }

        private void Elimiar()
        {
            if (codigoEditar != null && codigoEditar.ToString().Trim() != "")
            {
                asistenciaNegocio = new AsistenciaNegocio();
                asistenciaNegocio.EliminarDocumento(Program.ClaseCompartida.periodoElegido, codigoEditar, codigoTransferencia);
                Consultar();
            }
        }



        private void Editar()
        {
            if (codigoEditar != null && codigoEditar.ToString().Trim() != "")
            {
                empresaCodigo = "001";
                periodo = Program.ClaseCompartida.periodoElegido;
                oFormulario = new MovimientoAsistenciaMantenimiento(codigoEditar, usuario);
                oFormulario.Show();

            }
        }

        private void Nuevo()
        {
            if (codigoEditar != null && codigoEditar.ToString().Trim() != "")
            {
                empresaCodigo = "001";
                periodo = Program.ClaseCompartida.periodoElegido;
                codigoEditar = string.Empty;
                oFormulario = new MovimientoAsistenciaMantenimiento(codigoEditar, usuario);
                //oFormulario.MdiParent = RegistroAsistenciaPersonalGarita.ActiveForm;

                oFormulario.WindowState = FormWindowState.Maximized;
                oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                oFormulario.Show();
            }
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
            excelExporter.SheetName = "Asistencia";
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


        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void dgvRegistros_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            gbRegistros.Enabled = !true;
            menuPrincipal.Enabled = !true;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
        }


        private void sbmeditarMovimiento_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void sbmAnularMovimiento_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void sbmEliminarMovimiento_Click(object sender, EventArgs e)
        {
            Elimiar();
        }


    }
}
