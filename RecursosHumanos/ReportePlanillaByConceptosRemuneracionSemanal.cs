using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyControlsDataBinding.Extensions;
using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using RecursosHumanos.Negocios;



namespace RecursosHumanos
{
    public partial class ReportePlanillaByConceptosRemuneracionSemanal : Form
    {
        private string idPlanilla;
        private string periodoPlanilla;
        private string semana;
        private List<Temp_ST_ReportePlanillaByConceptosRemuneracionSemanal> listadoResultadoConsulta;
        private string fileName;
        private bool exportVisualSettings;
        private MesNegocios mesN;
        private string desde;
        private string hasta;
        private string periodo;

        public ReportePlanillaByConceptosRemuneracionSemanal()
        {
            InitializeComponent();
            Inicio();
            CargarMesesAPresentacion();
        }


        public void Inicio()
        {

            MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
            MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
            MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + this.txtAño.Value.ToString()];
            MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
            MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
            MyControlsDataBinding.Extensions.Globales.Empresa = "AGROINDUSTRIAL ESTANISLAO DEL CHIMU SAC";
            MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
            MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "ERICK AURAZO";


            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);

            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);


            desde = this.txtFechaDesde.Text.Trim();
            hasta = this.txtFechaHasta.Text.Trim();
            periodo = this.txtAño.Value + this.txtFechaHasta.Text.Trim().Substring(3, 2);
  

        }


        private void CargarMesesAPresentacion()
        {

            //mesN = new MesNegocios();
            //cboMes.DisplayMember = "descripcion";
            //cboMes.ValueMember = "valor";
            ////cboMes.DataSource = mesN.listarMeses().Where(x => x.valor != "13" && x.valor != "00").ToList();
            //cboMes.DataSource = mesN.ListarMeses();
            //cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }


        private void gbDatosConsulta_Click(object sender, EventArgs e)
        {

        }

        private void tsbExcel_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void Exportar()
        {
            try
            {
                ReportePlanillaByConceptosRemuneracionSemanal oClase = new ReportePlanillaByConceptosRemuneracionSemanal();
                oClase.Exportar(dgvMovimientoPlanillaByConceptos);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void Exportar(RadGridView radGridView)
        {
            openFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (openFileDialog1.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(radGridView.ThemeName);
                RadMessageBox.Show("Ingrese nombre al archivo.");
                return;
            }

            fileName = this.openFileDialog1.FileName;
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
            excelExporter.SheetName = "Mov. Planilla";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
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


        private void tsbImprimir_Click(object sender, EventArgs e)
        {

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {

        }



        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MovimientoPlanillaNegocio oMovimientoPlanilla = new MovimientoPlanillaNegocio();
                listadoResultadoConsulta = new List<Temp_ST_ReportePlanillaByConceptosRemuneracionSemanal>();
                listadoResultadoConsulta = oMovimientoPlanilla.ObtenerListadoReportePlanillaByConceptoRemuneracio(idPlanilla, semana, periodoPlanilla).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Mensaje del sistema");
                return;
            }
        }

        private void Consultar()
        {
            #region Consultar()
            try
            {
                idPlanilla = this.txtPlanillaCodigo.Text.Trim();
                periodoPlanilla = this.txtAño.Value.ToString() + this.cboMes.SelectedValue.ToString();
                semana = this.txtSemana.Value.ToString();
                gbDatosConsulta.Enabled = false;
                gbDetalle.Enabled = false;
                ProgressBar.Visible = true;
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            #endregion
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Presentar();
        }

        private void Presentar()
        {
            #region Presentar()
            try
            {
                dgvMovimientoPlanillaByConceptos.DataSource = listadoResultadoConsulta;
                dgvMovimientoPlanillaByConceptos.Refresh();

                gbDatosConsulta.Enabled = !false;
                gbDetalle.Enabled = !false;
                ProgressBar.Visible = !true;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            #endregion
        }

        private void ReportePlanillaByConceptosRemuneracionSemanal_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            this.dgvMovimientoPlanillaByConceptos.TableElement.BeginUpdate();
            this.LoadFreightSummary();
            this.dgvMovimientoPlanillaByConceptos.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvMovimientoPlanillaByConceptos.MasterTemplate.AutoExpandGroups = true;
            this.dgvMovimientoPlanillaByConceptos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientoPlanillaByConceptos.GroupDescriptors.Clear();
            
            this.dgvMovimientoPlanillaByConceptos.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chDIAS_TRABAJADOS", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chDIAS_POR_RENDIMIENTO", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chHORAS_NORMALES", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chHORAS_EXTRAS_INC_25", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chHORAS_EXTRAS_INC_35", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chHORAS_DOBLES", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chDIAS_DESCANSO_MEDICO", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chDIAS_DE_LICENCIA_POR_PATERNIDAD_LEY_29409", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chBASICO_ACUMULADO", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chASIGNACION_FAMILIAR", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chINGRESOS_POR_RENDIMIENTO", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chIMP_EXT_1_25", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chIMP_EXT_1_35", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chIMPUESTO_HORAS_DOBLES", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chDOMINICAL", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chREINTEGROS", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chMOVILIDAD_POR_FUNCION", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chIMPORTE_DESCANSO_MEDICO", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chLICENCIA_POR_PATERNIDAD", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chBONIFICACION_ASISTENCIA", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chBONIFICACION_POR_ALIMENTACION", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chBONIFICACION_PRODUCCION", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chTOTAL_INGRESOS_AFECTOS", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chTOTAL_INGRESOS", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chONP", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chFONDO_PARA_AFP", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chSEGURO_AFP", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chCOMISION_VARIABLE", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chDSC_JUDIC_DEM_1", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chDESCUENTO_POR_PRESTAMO", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chDESCUENTO_POR_RESPONSABILIDAD", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chTOTAL_DESCUENTOS", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chNETO_A_PAGAR", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chESSALUD", "Sum: {0:N3}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chTOTAL_APORTES_DEL_EMPLEADOR", "Sum: {0:N3}; ", GridAggregateFunction.Sum));           
            this.dgvMovimientoPlanillaByConceptos.MasterTemplate.SummaryRowsTop.Add(item);

        }

        private void stsBarraEstado_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
