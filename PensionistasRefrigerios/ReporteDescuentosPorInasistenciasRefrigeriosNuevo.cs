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
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using TransportistaMto.Datos;
namespace Transportista
{
    public partial class ReporteDescuentosPorInasistenciasRefrigeriosNuevo : Form
    {
        private string nombreDelMes;
        private string fechaDesde;
        private string fechaHasta;
        private string codigoProveedor;
        private string descripcionProveedor;
        private List<RefrigerioAgrupado> ListadoGeneralPensionistasAgrupado;
        private List<SJ_RHListaPersonalParaDescuentoPensionbyProveedorbyFechaResult> listado;
        private SJM_PensionesNegocios modelo;
        private string nombreArchivo;
        private bool exportVisualSettings;
        private string rucProveedor;
        private RefrigerioAgrupado asistenciaPersonal;

        public ReporteDescuentosPorInasistenciasRefrigeriosNuevo()
        {
            InitializeComponent();
        }

        public ReporteDescuentosPorInasistenciasRefrigeriosNuevo(string nombreDelMes, string fechaDesde, string fechaHasta, string codigoProveedor, string descripcionProveedor, List<RefrigerioAgrupado> ListadoGeneralPensionistasAgrupado, string rucProveedor)
        {
            // TODO: Complete member initialization
            InitializeComponent();

            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.nombreDelMes = nombreDelMes;
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.codigoProveedor = codigoProveedor;
            this.descripcionProveedor = descripcionProveedor;
            this.rucProveedor = rucProveedor;
            this.ListadoGeneralPensionistasAgrupado = ListadoGeneralPensionistasAgrupado;
            gbDatosConsulta.Enabled = false;
            gbResultado.Enabled = false;
            ProgressBar.Visible = true;
            bgwHilo.RunWorkerAsync();


        }

        private void GeneracionDescuentosPorInasistenciasRefrigeriosNuevo_Load(object sender, EventArgs e)
        {

        }


        


        private void LoadFreightSummary()
        {
            this.dgvResultados.MasterTemplate.AutoExpandGroups = true;
            this.dgvResultados.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.GroupDescriptors.Clear();
            this.dgvResultados.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chdniTrabajador", "Registros: {0:N0}; ", GridAggregateFunction.Count));
            item.Add(new GridViewSummaryItem("chimporteRefrigerio", "Sum: {0:N1}; ", GridAggregateFunction.Sum));

            //this.dgvRefrigerios.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvResultados.MasterTemplate.SummaryRowsTop.Add(item);
        }

        protected override void OnLoad(EventArgs e)
        {

            this.dgvResultados.TableElement.BeginUpdate();
            this.LoadFreightSummary();
            this.dgvResultados.TableElement.EndUpdate();
            base.OnLoad(e);
        }


        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            EjectarConsulta();
        }

        private void EjectarConsulta()
        {
            try
            {
                listado = new List<SJ_RHListaPersonalParaDescuentoPensionbyProveedorbyFechaResult>();
                modelo = new SJM_PensionesNegocios();
                listado = modelo.ListarNombresPersonalParaReporteDescuentoByPensionByProveedorByPeriodo(this.codigoProveedor, this.fechaDesde, this.fechaHasta).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "\n. Ejecución de consulta ", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarDatos();
        }

        private void PresentarDatos()
        {
            try
            {

                this.txtFechaDesde.Text = this.fechaDesde;
                this.txtFechaHasta.Text = this.fechaHasta;
                this.txtRazonSocialProveedor.Text = this.descripcionProveedor;
                this.txtDNIProveedor.Text = this.codigoProveedor != "" ? this.codigoProveedor : "TODOS";
                cboMes.Text = this.nombreDelMes;
                dgvResultados.DataSource = listado.ToDataTable<SJ_RHListaPersonalParaDescuentoPensionbyProveedorbyFechaResult>();
                dgvResultados.Refresh();
                gbDatosConsulta.Enabled = true;
                gbResultado.Enabled = true;
                ProgressBar.Visible = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString() + "\n. Presentar información ", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvResultados.Rows.Count > 0)
            {
                Exportar(this.dgvResultados);
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
            excelExporter.SheetName = "Personal para Dscto";
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

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            string nroRucProveedor, proveedorDescripcion, semanaFacturacion = string.Empty;

            if (ListadoGeneralPensionistasAgrupado != null && ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
            {
                #region Generar vista del reporte ()

                //PensionesModelo.RegistrarResultadosConsultaRefrigeriosAgrupados(listadoVistaAgrupadoSubPlanillasIcaOtros, codigoReporte);

                nroRucProveedor = this.rucProveedor;
                proveedorDescripcion = txtRazonSocialProveedor.Text.ToString().Trim();
                //semanaFacturacion = Convert.ToDateTime(this.txtFechaDesde.Text).

                int x = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Convert.ToDateTime(this.txtFechaDesde.Text), CalendarWeekRule.FirstDay, Convert.ToDateTime(this.txtFechaDesde.Text).DayOfWeek);
                semanaFacturacion = x.ToString().Trim();

                fechaDesde = this.txtFechaDesde.Text.ToString().Trim();
                fechaHasta = this.txtFechaHasta.Text.ToString().Trim();

                ReportePersonalByDescuentoByInasistenciaByPensionByPeriodoFacturacionVistaPrevia ofrm = new ReportePersonalByDescuentoByInasistenciaByPensionByPeriodoFacturacionVistaPrevia(codigoProveedor, fechaDesde, fechaHasta);
                ofrm.AgregarParametroCadena("@RucProveedor", nroRucProveedor.ToString().Trim()); /* nro Ruc */
                ofrm.AgregarParametroCadena("@ProveedorDescripcion", proveedorDescripcion.ToString().Trim()); /* Razon social */
                ofrm.AgregarParametroCadena("@fechaDesde", fechaDesde.ToString().Trim());
                ofrm.AgregarParametroCadena("@fechaHasta", fechaHasta.ToString().Trim());
                ofrm.AgregarParametroCadena("@semanaFacturacion", semanaFacturacion.ToString().Trim());
                ofrm.AgregarParametroCadena("@impresoPor", Environment.UserName.ToString().Trim().ToUpper());
                //ofrm.AgregarParametroCadena("@codigo", codigoReporte.ToString().Trim());
                ofrm.Show();
                #endregion
            }
        }

        private void dgvResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultados != null && dgvResultados.Rows.Count > 0)
            {
                if (dgvResultados.CurrentRow != null && dgvResultados.CurrentCell != null)
                {
                    if (dgvResultados.CurrentRow.Cells["chCodigoPersonal"].Value != null && dgvResultados.CurrentRow.Cells["chCodigoPersonal"].Value.ToString().Trim() != string.Empty)
                    {
                        asistenciaPersonal = new RefrigerioAgrupado();
                        asistenciaPersonal.CodigoPersonal = dgvResultados.CurrentRow.Cells["chCodigoPersonal"].Value != null ? dgvResultados.CurrentRow.Cells["chCodigoPersonal"].Value.ToString().Trim() : string.Empty ;
                    }
                }
            }
        }

        private void btnSubDetalleDeAsistenciaHoras_Click(object sender, EventArgs e)
        {
            DetalleAsistencia("HORAS");
        }

        private void btnSubDetalleDeAsistenciaRendimiento_Click(object sender, EventArgs e)
        {
            DetalleAsistencia("RENDIMIENTO");
        }

        private void DetalleAsistencia(string tipoResultado)
        {
            try
            {
                if (asistenciaPersonal.CodigoPersonal != null)
                {
                    if (tipoResultado == "HORAS")
                    {
                        fechaDesde = this.txtFechaDesde.Text; 
                        fechaHasta = this.txtFechaHasta.Text;
                        ReporteAsistenciaPersonalLaboresCampoxHoras ofrm = new ReporteAsistenciaPersonalLaboresCampoxHoras(fechaDesde, fechaHasta, asistenciaPersonal.CodigoPersonal);
                        ofrm.WindowState = FormWindowState.Normal;
                        ofrm.Show();
                    }
                    else if (tipoResultado == "RENDIMIENTO")
                    {
                        fechaDesde = this.txtFechaDesde.Text;
                        fechaHasta = this.txtFechaHasta.Text;
                        ReporteAsistenciaPersonalLaboresCampoxRendimiento ofrm = new ReporteAsistenciaPersonalLaboresCampoxRendimiento(fechaDesde, fechaHasta, asistenciaPersonal.CodigoPersonal);
                        ofrm.WindowState = FormWindowState.Normal;
                        ofrm.Show();

                    }

                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMAS");
                return;
            }
        }




    }
}
