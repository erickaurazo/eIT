using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
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
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ReporteGeneracionDescuentosPorInasistenciasRefrigerios : Telerik.WinControls.UI.RadForm
    {
        private string nombreMes;
        private string fechaDesde;
        private string fechaHasta;
        private string codigoProveedor;
        private string descripcionProveedor;
        private List<RefrigerioAgrupado> ListadoGeneralPensionistasAgrupado;
        private List<DescuentoByInasistenciaRefrigerio> listado;
        private RefrigeriosPensionesNegocios modelo;
        private string nombreArchivo;
        private bool exportVisualSettings;

        public ReporteGeneracionDescuentosPorInasistenciasRefrigerios()
        {
            InitializeComponent();
        }



        public ReporteGeneracionDescuentosPorInasistenciasRefrigerios(string nombreMes, string fechaDesde, string fechaHasta, string codigoProveedor, string descripcionProveedor, List<RefrigerioAgrupado> ListadoGeneralPensionistasAgrupado)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.nombreMes = nombreMes;
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.codigoProveedor = codigoProveedor;
            this.descripcionProveedor = descripcionProveedor;
            this.ListadoGeneralPensionistasAgrupado = ListadoGeneralPensionistasAgrupado;
            bgwHilo.RunWorkerAsync();
        }



        private void LoadFreightSummary()
        {
            this.dgvPersonal.MasterTemplate.AutoExpandGroups = true;
            this.dgvPersonal.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonal.GroupDescriptors.Clear();
            this.dgvPersonal.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chNombres", "Registros: {0:N0}; ", GridAggregateFunction.Count));
            item.Add(new GridViewSummaryItem("chImporteDescuento", "Registros: {0:N2}; ", GridAggregateFunction.Sum));
            //this.dgvRefrigerios.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvPersonal.MasterTemplate.SummaryRowsTop.Add(item);
        }

        protected override void OnLoad(EventArgs e)
        {

            this.dgvPersonal.TableElement.BeginUpdate();            
            this.LoadFreightSummary();
            this.dgvPersonal.TableElement.EndUpdate();
        }

        private void GeneracionDescuentosPorInasistenciasRefrigerios_Load(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                listado = new List<DescuentoByInasistenciaRefrigerio>();
                modelo = new RefrigeriosPensionesNegocios();
                listado = modelo.AgruparListaInasistenciaRefrigerios(this.ListadoGeneralPensionistasAgrupado);

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message + "\nRealizar consulta", "MENSAJE DE SISTEMAS");
            }

        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                cboMes.Text = this.nombreMes;
                this.txtFechaDesde.Text = this.fechaDesde;
                this.txtFechaHasta.Text = this.fechaHasta;
                this.txtDNIProveedor.Text = this.codigoProveedor;
                this.txtRazonSocialProveedor.Text = this.descripcionProveedor;

                dgvPersonal.DataSource = listado.OrderBy(x => x.nombres).ToList();
                dgvPersonal.Refresh();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message + "\nPresentar datos", "MENSAJE DE SISTEMAS");
            }



        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonal != null && dgvPersonal.Rows.Count > 0)
            {
                Exportar(this.dgvPersonal);
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
            excelExporter.SheetName = "Seguimiento Asistencias";
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



    }
}
