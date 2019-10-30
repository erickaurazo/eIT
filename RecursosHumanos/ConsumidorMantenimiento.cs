using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using RecursosHumanos.Negocios;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using RecursosHumanos.Datos;

namespace RecursosHumanos
{
    public partial class ConsumidorMantenimiento : Form
    {
        private string codigoUnicoAccesoSistema;
        private string codigoUsuario;
        private ConsumidorNegocio modelo;
        private List<ext_ListarConsumidorResult> listado;
        private string fileName;
        private bool exportVisualSettings;

        public ConsumidorMantenimiento()
        {
            InitializeComponent();
        }

        public ConsumidorMantenimiento(string CodigoUnicoAccesoSistema, string codigoUsuario)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.codigoUnicoAccesoSistema = CodigoUnicoAccesoSistema;
            this.codigoUsuario = codigoUsuario;
            gbRegistros.Enabled = false;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
        }

        private void Consumidor_Load(object sender, EventArgs e)
        {
            
        }

        private void CargarNodos(List<ext_ListarConsumidorResult> listadoConsumidores)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
                
            }
        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            modelo = new ConsumidorNegocio();
            listado = new List<ext_ListarConsumidorResult>();
            listado = modelo.ObtenerTodosConsumidores(Program.ClaseCompartida.periodoElegido);


        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //dgvRegistros.DataSource = listado.ToDataTable<ext_ListarConsumidorResult>();
            //dgvRegistros.Refresh();
            CargarNodos(listado);
            gbRegistros.Enabled = !false;
            ProgressBar.Visible = !true;


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            gbRegistros.Enabled = false;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
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
