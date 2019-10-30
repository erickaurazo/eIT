using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Localization;

namespace RecursosHumanos
{
    public partial class ReporteListadoConsumidoreByNroPlantasByNroRacimos : Form
    {
        private string periodoConsulta;
        private ASJ_ConsumidorByRacimoNegocio negocios;
        private List<ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult> listado;
        private string codigoConsumidor = string.Empty;
        private string consumidorDescripcion = string.Empty;
        private ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult oConsumidor;
        private string fileName;
        private bool exportVisualSettings;

        public ReporteListadoConsumidoreByNroPlantasByNroRacimos()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            periodoConsulta = DateTime.Now.Year.ToString();
            ProgressBar.Visible = true;
            gbDatosConsulta.Enabled = false;
            gbDetalle.Enabled = false;
            bgwHilo.RunWorkerAsync();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.dgvResultado.TableElement.BeginUpdate();
            this.LoadFreightSummary();
            this.dgvResultado.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvResultado.MasterTemplate.AutoExpandGroups = true;
            this.dgvResultado.GroupDescriptors.Clear();
            this.dgvResultado.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items = new GridViewSummaryRowItem();
            items.Add(new GridViewSummaryItem("chconsumidor", "Registros : {0:N0}; ", GridAggregateFunction.Count));
            items.Add(new GridViewSummaryItem("chareaConsumidor", "Sum : {0:N0}; ", GridAggregateFunction.Sum));
            items.Add(new GridViewSummaryItem("chnumeroPlantas", "Sum : {0:N0}; ", GridAggregateFunction.Sum));
            items.Add(new GridViewSummaryItem("chcamas_surcos", "Sum : {0:N0}; ", GridAggregateFunction.Sum));
            items.Add(new GridViewSummaryItem("chrayas", "Sum : {0:N0}; ", GridAggregateFunction.Sum));
            items.Add(new GridViewSummaryItem("chracimos", "Sum : {0:N0}; ", GridAggregateFunction.Sum));
            this.dgvResultado.MasterTemplate.SummaryRowsTop.Add(items);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            RealizarConsulta();
        }

        private void RealizarConsulta()
        {
            periodoConsulta = DateTime.Now.Year.ToString();
            ProgressBar.Visible = true;
            gbDatosConsulta.Enabled = false;
            gbDetalle.Enabled = false;
            bgwHilo.RunWorkerAsync();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listado = new List<ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult>();
                negocios = new ASJ_ConsumidorByRacimoNegocio();
                listado = negocios.ObtenerListadoConsumidoresByRacimoByNroPlantas(periodoConsulta).ToList();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvResultado.DataSource = listado;
            dgvResultado.Refresh();
            ProgressBar.Visible = !true;
            gbDatosConsulta.Enabled = !false;
            gbDetalle.Enabled = !false;

        }

        private void ReporteListadoConsumidoreByNroPlantasByNroRacimos_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void ExportarExcel()
        {
            if (dgvResultado != null)
            {
                if (dgvResultado.Rows.Count > 0)
                {
                    Exportar(this.dgvResultado);
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
            excelExporter.SheetName = "Consumidores";
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

        private void dgvResultado_SelectionChanged(object sender, EventArgs e)
        {
            codigoConsumidor = string.Empty;
            oConsumidor = new ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult();
            if (dgvResultado.Rows.Count > 0)
            {
                if (dgvResultado.CurrentRow != null)
                {
                    if (dgvResultado.CurrentRow.Cells["chcodigoConsumidor"].Value.ToString() != string.Empty)
                    {
                        codigoConsumidor = dgvResultado.CurrentRow.Cells["chcodigoConsumidor"].Value.ToString().Trim();
                        consumidorDescripcion = dgvResultado.CurrentRow.Cells["chconsumidor"].Value.ToString().Trim();
                        var resultadoCoincidenciaGrilla = listado.Where(x => x.codigoConsumidor == codigoConsumidor).ToList();

                        if (resultadoCoincidenciaGrilla != null && resultadoCoincidenciaGrilla.ToList().Count == 1)
                        {
                            oConsumidor = listado.Where(x => x.codigoConsumidor.Trim() == codigoConsumidor.Trim()).Single();
                        }
                    }
                }
            }
        }

        private void sbActualizarNroPlantasRacimos_Click(object sender, EventArgs e)
        {
            if (codigoConsumidor != string.Empty)
            {

                ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos oFrom = new ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos(codigoConsumidor, consumidorDescripcion, oConsumidor);
                if (oFrom.ShowDialog() == DialogResult.OK)
                {
                    /// RealizarConsulta();
                }
            }
        }

        private void sbmActualizarTipoConsumidor_Click(object sender, EventArgs e)
        {
            if (codigoConsumidor != string.Empty)
            {
                ReporteListadoConsumidoreByNroPlantasByNroRacimosCambiarTipoConsumidor oFrom = new ReporteListadoConsumidoreByNroPlantasByNroRacimosCambiarTipoConsumidor(codigoConsumidor, consumidorDescripcion, oConsumidor);
                oFrom.ShowDialog();
            }
        }
    }
}
