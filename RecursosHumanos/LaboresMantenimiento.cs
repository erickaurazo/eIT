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
    public partial class LaboresMantenimiento : Form
    {
        private string codigoUnicoAccesoSistema;
        private string codigoUsuario;
        private ActividadNegocio modelo;
        private List<ext_ListarActividadesResult> actividades;
        private List<ext_ListarLaboresByCodigoActividadResult> laboresByCodigoActividad;
        private LaborNegocio modeloLabor;
        private List<ext_ListarLaboresByCodigoActividadResult> listadoLimpiarGrillaLabores;
        private string fileName;
        private bool exportVisualSettings;

        public LaboresMantenimiento()
        {
            InitializeComponent();
        }

        public LaboresMantenimiento(string CodigoUnicoAccesoSistema, string codigoUsuario)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.codigoUnicoAccesoSistema = CodigoUnicoAccesoSistema;
            this.codigoUsuario = codigoUsuario;
            gbRegistros.Enabled = false;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
        }

        private void Labores_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            gbRegistros.Enabled = false;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            modelo = new ActividadNegocio();
            actividades = new List<ext_ListarActividadesResult>();
            actividades = modelo.ListadoTodasActividades(Program.ClaseCompartida.periodoElegido);
        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvRegistros.DataSource = actividades.ToDataTable<ext_ListarActividadesResult>();
            dgvRegistros.Refresh();
            gbRegistros.Enabled = !false;
            ProgressBar.Visible = !true;
        }

        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControl();
            if (dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                if (dgvRegistros.CurrentRow != null)
                {
                    if (dgvRegistros.CurrentRow.Cells["chcodigoActividad"].Value != null && dgvRegistros.CurrentRow.Cells["chcodigoActividad"].Value.ToString().Trim() != string.Empty)
                    {
                        string codigoActividad = dgvRegistros.CurrentRow.Cells["chcodigoActividad"].Value.ToString().Trim();

                        laboresByCodigoActividad = new List<ext_ListarLaboresByCodigoActividadResult>();
                        codigoActividad = dgvRegistros.CurrentRow.Cells["chcodigoActividad"].Value != null ? dgvRegistros.CurrentRow.Cells["chcodigoActividad"].Value.ToString().Trim() : string.Empty;
                        modeloLabor = new LaborNegocio();
                        laboresByCodigoActividad = modeloLabor.ListadoTodasLaboresByCodigoActividad(Program.ClaseCompartida.periodoElegido, codigoActividad);

                        this.txtCodigoActividad.Text = codigoActividad;
                        this.txtDescripcion.Text = dgvRegistros.CurrentRow.Cells["chDescripcion"].Value != null ? dgvRegistros.CurrentRow.Cells["chDescripcion"].Value.ToString().Trim() : string.Empty;
                        this.txtDescripcionCorta.Text = dgvRegistros.CurrentRow.Cells["chDescripcioncorta"].Value != null ? dgvRegistros.CurrentRow.Cells["chDescripcioncorta"].Value.ToString().Trim() : string.Empty;

                        this.txtEstado.Text = "ANULADO";
                        if ((dgvRegistros.CurrentRow.Cells["chEstado"].Value != null ? dgvRegistros.CurrentRow.Cells["chEstado"].Value.ToString().Trim() : string.Empty) == "1")
                        {
                            this.txtEstado.Text = "ACTIVO";
                        }

                        dgvLabores.DataSource = laboresByCodigoActividad.ToDataTable<ext_ListarLaboresByCodigoActividadResult>();
                        dgvLabores.Refresh();
                    }
                }
            }


        }

        private void LimpiarControl()
        {
            this.txtCodigoActividad.Clear();
            this.txtDescripcion.Clear();
            this.txtDescripcionCorta.Clear();
            this.txtEstado.Clear();

            listadoLimpiarGrillaLabores = new List<ext_ListarLaboresByCodigoActividadResult>();

            dgvLabores.DataSource = listadoLimpiarGrillaLabores.ToDataTable<ext_ListarLaboresByCodigoActividadResult>();
            dgvLabores.Refresh();
            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros != null)
            {
                if (dgvRegistros.Rows.Count > 0)
                {
                    Exportar(this.dgvRegistros);
                }
            }
        }

        private void btnExportarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvLabores != null)
            {
                if (dgvLabores.Rows.Count > 0)
                {
                    Exportar(this.dgvLabores);
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
            excelExporter.SheetName = "Labores";
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



    }
}
