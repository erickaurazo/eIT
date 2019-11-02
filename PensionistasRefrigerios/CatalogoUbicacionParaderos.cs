using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using MyControlsDataBinding.Extensions;

using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using Asistencia.Datos;
using Asistencia.Negocios;

namespace Asistencia
{
    public partial class CatalogoUbicacionParaderos : Form
    {
        private string periodo;
        private WhereaboutsController modelo;
        private List<Paradero> ListaParaderos;
        private Paradero oParadero;
        private SJ_Paraderos oParaderoRegistro;
        private string nombreArchivo;
        private bool exportVisualSettings;
        private List<Grupo> listadoTipoParadero;

        public CatalogoUbicacionParaderos()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            Inicio();
            CargarComboTipoParadero();

        }

        private void CargarComboTipoParadero()
        {
            modelo = new WhereaboutsController();
            listadoTipoParadero = new List<Grupo>();
            listadoTipoParadero = modelo.ObtenerListadoTipoParaderos();
            this.cboTipo.DisplayMember = "Descripcion";
            this.cboTipo.ValueMember = "Codigo";
            this.cboTipo.DataSource = listadoTipoParadero.ToList();            
        }

        public void Inicio()
        {
            try
            {
                periodo = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "ERICK AURAZO";

               


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void CatalogoUbicacionParaderos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                modelo = new WhereaboutsController();
                ListaParaderos = new List<Paradero>();
                ListaParaderos = modelo.ObtenerListaParaderos(periodo).ToList();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            RealizarConsulta();
        }

        private void RealizarConsulta()
        {
            BarraSuperior.Enabled = false;
            periodo = DateTime.Now.Year.ToString();
            bgwHilo.RunWorkerAsync();

        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvPension.DataSource = ListaParaderos.ToDataTable<Paradero>();
                dgvPension.Refresh();

                if (ListaParaderos != null && ListaParaderos.ToList().Count > 0)
                {
                    ResaltarResultados(dgvPension);

                }
                BarraSuperior.Enabled = true;

            }
            catch (Exception Ex)
            {
                BarraSuperior.Enabled = true;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ResaltarResultados(RadGridView grilla)
        {
            if (grilla != null && grilla.Rows.Count > 0)
            {
                for (int i = 0; i < grilla.Rows.Count; i++)
                {
                    if (grilla.Rows[i].Cells["chEstado"].Value.ToString().Trim().ToUpper() == "0".ToUpper())
                    {
                        for (int j = 0; j < grilla.Columns.Count; j++)
                        {
                            grilla.Rows[i].Cells[j].Style.CustomizeFill = true;
                            grilla.Rows[i].Cells[j].Style.DrawFill = true;
                            grilla.Rows[i].Cells[j].Style.BackColor = Utiles.blancoHumo3D;
                            //dgvRegistros.Rows[i].Cells[j].Style.Font = new Font("Tahoma", 8, FontStyle.Bold); //
                        }
                    }
                }
            }
        }

        private void CatalogoUbicacionParaderos_Load(object sender, EventArgs e)
        {
            RealizarConsulta();
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;
            btnActualizarLista.Enabled = true;
        }

        private void dgvPension_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControlesFormularioMantenimiento();
            btnSubAnularActivar.Enabled = false;
            btnSubEdicion.Enabled = false;
            btnSubEditar.Enabled = false;
            btnSubEliminar.Enabled = false;

            oParadero = new Paradero();
            if (dgvPension != null && dgvPension.Rows.Count > 0)
            {
                if (dgvPension.CurrentRow != null && dgvPension.CurrentRow.Cells["chIdParadero"].Value != null && dgvPension.CurrentRow.Cells["chIdParadero"].Value.ToString().Trim() != string.Empty);
                {
                    this.txtCodigo.Text = dgvPension.CurrentRow.Cells["chIdParadero"].Value.ToString().Trim();
                    this.txtDescripcionParadero.Text = dgvPension.CurrentRow.Cells["chParadero"].Value != null ? dgvPension.CurrentRow.Cells["chParadero"].Value.ToString().Trim() : string.Empty;
                    this.txtObservación.Text = dgvPension.CurrentRow.Cells["chObservacion"].Value != null ? dgvPension.CurrentRow.Cells["chObservacion"].Value.ToString().Trim() : string.Empty;
                    this.txtEstado.Text = dgvPension.CurrentRow.Cells["chEstado"].Value.ToString() == "1" ? "Activo".ToUpper() : "Anulado".ToUpper();
                    this.cboTipo.SelectedValue = dgvPension.CurrentRow.Cells["chTipoCodigo"].Value != null ? dgvPension.CurrentRow.Cells["chTipoCodigo"].Value.ToString().Trim() : string.Empty;
                    oParadero = ListaParaderos.Where(x => x.idParadero.ToString().Trim() == dgvPension.CurrentRow.Cells["chIdParadero"].Value.ToString().Trim()).Single();                                            
                    btnSubAnularActivar.Enabled = true;
                    btnSubEdicion.Enabled = true;
                    btnSubEditar.Enabled = true;
                    btnSubEliminar.Enabled = true;
                }
            }
        }

        private void LimpiarControlesFormularioMantenimiento()
        {
            this.txtCodigo.Clear();
            this.txtDescripcionParadero.Clear();
            this.txtEstado.Clear();
            this.txtObservación.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }

        private void EditarRegistro()
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;

            if (oParadero != null && oParadero.estado == 1)
            {
                gbMantenimientoRegistros.Enabled = true;
                btnActualizarLista.Enabled = false;
                gbListadoParaderos.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnAtras.Enabled = true;
                btnAnular.Enabled = true;
                btnEliminar.Enabled = true;
                btnExportar.Enabled = false;
                btnSalir.Enabled = true;
                this.txtDescripcionParadero.Focus();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void Registrar()
        {
            try
            {
                if (this.txtDescripcionParadero.Text.ToString().Trim() != "")
                {
                    #region Obtener objeto()
                    oParaderoRegistro = new SJ_Paraderos();
                    oParaderoRegistro.IdParadero = this.txtCodigo.Text.ToString().Trim();
                    oParaderoRegistro.DescripcionParadero = this.txtDescripcionParadero.Text.ToString().Trim();
                    oParaderoRegistro.Observacion = this.txtObservación.Text.ToString().Trim();
                    oParaderoRegistro.ESTADO = this.txtEstado.Text == "Activo".ToUpper() ? 1 : 0;
                    oParaderoRegistro.tipo = this.cboTipo.SelectedValue != null ? Convert.ToChar(this.cboTipo.SelectedValue.ToString()) : Convert.ToChar("T");
                    modelo.Registrar(periodo, oParaderoRegistro);
                    MessageBox.Show("Registrado correctamente", "MENSAJE DEL SISTEMA");
                    RealizarConsulta();
                    gbMantenimientoRegistros.Enabled = false;
                    gbListadoParaderos.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnActualizarLista.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnAtras.Enabled = false;
                    btnAnular.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnExportar.Enabled = true;
                    btnSalir.Enabled = false;
                    #endregion
                }
                else
                {
                    MessageBox.Show("DEBE INGRESAR UNA DESCRIPCION DEL PARADERO", "MENSAJE DEL SISTEMA");
                    return;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GenenarNuevoRegistro();
        }

        private void GenenarNuevoRegistro()
        {
            LimpiarControlesFormularioMantenimiento();
            btnActualizarLista.Enabled = false;
            gbListadoParaderos.Enabled = false;
            gbMantenimientoRegistros.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnAtras.Enabled = true;
            btnAnular.Enabled = true;
            btnEliminar.Enabled = true;
            btnExportar.Enabled = false;
            btnSalir.Enabled = true;
            this.txtEstado.Text = "ACTIVO";
            this.txtDescripcionParadero.Focus();


        }

        private void gbMantenimientoRegistros_Click(object sender, EventArgs e)
        {

        }

        private void CatalogoUbicacionParaderos_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GenenarNuevoRegistro();
            }

        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.B | Keys.Control | Keys.Alt | Keys.Shift:
                    // ... Process Shift+Ctrl+Alt+B ...

                    return true; // signal that we've processed this key
            }

            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }

        private void gbMantenimientoRegistros_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Registrar();
            }

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GenenarNuevoRegistro();
            }

            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

        }

        private void dgvPension_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                EditarRegistro();
            }

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GenenarNuevoRegistro();
            }


        }

        private void txtDescripcionParadero_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Registrar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GenenarNuevoRegistro();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

        }

        private void txtObservación_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Registrar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GenenarNuevoRegistro();
            }

            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }
        }

        private void txtEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Registrar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GenenarNuevoRegistro();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }
        }

        private void gbListadoParaderos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GenenarNuevoRegistro();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void Anular()
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;
            if (oParadero != null && (oParadero.estado == 1 || oParadero.estado == 0))
            {
                modelo = new WhereaboutsController();
                modelo.CambiarEstadoDocumento(periodo, oParadero);
                RealizarConsulta();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Environment.MachineName.ToString().Trim() == "EAURAZOC" || Environment.MachineName.ToString().Trim() == "JGUERREROD" || Environment.MachineName.ToString().Trim() == "CLLONTOPF")
            {
                Eliminar();
            }
            else
            {
                MessageBox.Show("No tiene privilegios para realizar esta operación", "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void Eliminar()
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;
            if (oParadero != null && (oParadero.estado == 1 || oParadero.estado == 0))
            {
                modelo = new WhereaboutsController();
                modelo.Eliminar(periodo, oParadero);
                RealizarConsulta();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void Exportar()
        {
            if (dgvPension != null && dgvPension.Rows.Count > 0)
            {
                GenerarProcesoAExportar(this.dgvPension);
            }
        }

        private void GenerarProcesoAExportar(RadGridView radGridView)
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

            nombreArchivo = this.saveFileDialog.FileName;
            bool openExportFile = false;
            this.exportVisualSettings = true;
            RunExportToExcelML(nombreArchivo, ref openExportFile, radGridView);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(nombreArchivo);
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
            excelExporter.SheetName = "Lista de Paraderos";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
            excelExporter.HiddenColumnOption = HiddenOption.DoNotExport;

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

        private void txtDescripcionParadero_Leave(object sender, EventArgs e)
        {
            this.txtObservación.Focus();
        }

        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Registrar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GenenarNuevoRegistro();
            }

            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }
        }

        private void btnGrabar_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Registrar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                GenenarNuevoRegistro();
            }

            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }
        }

        private void btnSubEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }

        private void btnSubAnularActivar_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void btnSubEliminar_Click(object sender, EventArgs e)
        {
            if (Environment.MachineName.ToString().Trim() == "EAURAZOC" || Environment.MachineName.ToString().Trim() == "JGUERREROD" || Environment.MachineName.ToString().Trim() == "CLLONTOPF")
            {
                Eliminar();
            }
            else
            {
                MessageBox.Show("No tiene privilegios para realizar esta operación", "MENSAJE DEL SISTEMA");
                return;
            }
        }





    }
}
