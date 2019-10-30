using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Configuration;
using System.Linq;
using System.IO;
using RecursosHumanos;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;

using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Localization;
using Telerik.Charting;
using Telerik.WinControls;

namespace RecursosHumanos
{
    public partial class ReporteDeHorasDesarrolladasEnLaboresDeCampoByPersonal : Form
    {

        #region Variables para el grafico()

        private BindingSource lineCombineModes, areaCombineModes;
        private List<string> chartTypes;
        private string selectedChartType;
        private ChartSeriesCombineMode selectedCombineMode;
        private bool showLabels;

        #endregion


        private MesNegocios MesesNeg;
        private List<string> listaPlanillasInvolucradas;
        private string desde;
        private string hasta;
        private HorasTrabajadasByPersonalCampoNegocio modelo;
        private List<DesarrolloLaboresPersonalCampo> ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores;
        private List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistencia;
        private MovimientoDesarrolloLaboresPersonalCampoNegocio modeloLabores;
        private List<HoraTrabajadaByPersonalCampo> ListadoResumenHorasAcumuladasByPersonalByDia;
        private string fileName;
        private bool exportVisualSettings;
        private string fFecha;
        private decimal? fValor;
        private decimal? fValor2;
        private List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistenciaAgrupado;
        private string nfFecha;
        private string nfCodigoPersonalGeneral;

        public ReporteDeHorasDesarrolladasEnLaboresDeCampoByPersonal()
        {
            InitializeComponent();
            CargarMeses();
            ObtenerFechasIniciales();

            RadGridLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

        }
        
        private void GenerarGraficoPresentacion()
        {
            LineSeries series = new LineSeries();
            series.DataPoints.Add(new CategoricalDataPoint(500, "ENERO"));
            series.DataPoints.Add(new CategoricalDataPoint(300, "FEBRERO"));
            series.DataPoints.Add(new CategoricalDataPoint(400, "MARZO"));
            series.DataPoints.Add(new CategoricalDataPoint(250, "ABRIL"));
            series.DataPoints.Add(new CategoricalDataPoint(050, "MAYO"));
            series.DataPoints.Add(new CategoricalDataPoint(550, "JUNIO"));
            series.DataPoints.Add(new CategoricalDataPoint(750, "JULIO"));
            this.charGrafico.Series.Add(series);

            //LineSeries series2 = new LineSeries();
            //series2.DataPoints.Add(new CategoricalDataPoint(900, "ENERO"));
            //series2.DataPoints.Add(new CategoricalDataPoint(100, "FEBRERO"));
            //series2.DataPoints.Add(new CategoricalDataPoint(800, "MARZO"));
            //series2.DataPoints.Add(new CategoricalDataPoint(350, "ABRIL"));
            //series2.DataPoints.Add(new CategoricalDataPoint(450, "MAYO"));
            //series2.DataPoints.Add(new CategoricalDataPoint(650, "JUNIO"));
            //series2.DataPoints.Add(new CategoricalDataPoint(680, "JULIO"));
            // this.charGrafico.Series.Add(series2);

            CartesianArea area = this.charGrafico.GetArea<CartesianArea>();
            area.ShowGrid = true;
            CartesianGrid grid = area.GetGrid<CartesianGrid>();
            grid.DrawHorizontalStripes = true;
            grid.DrawVerticalStripes = true;
            grid.DrawHorizontalFills = true;
            grid.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;


            foreach (CartesianSeries seriesGrafico in this.charGrafico.Series)
            {
                seriesGrafico.ShowLabels = true;
            }
        }

        private void GenerarGraficoPresentacion(List<HoraTrabajadaByPersonalCampo> ListadoResumenHorasAcumuladasByPersonalByDia)
        {
            LineSeries series = new LineSeries();
            LineSeries series2 = new LineSeries();
            LineSeries series3 = new LineSeries();
            LineSeries series4 = new LineSeries();
            if (ListadoResumenHorasAcumuladasByPersonalByDia != null && ListadoResumenHorasAcumuladasByPersonalByDia.ToList().Count > 0)
            {
                series = new LineSeries();
                series2 = new LineSeries();
                series3 = new LineSeries();
                series4 = new LineSeries();
                foreach (var item in ListadoResumenHorasAcumuladasByPersonalByDia)
                {

                    series.DataPoints.Add(new CategoricalDataPoint(item.criterio1.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                    series.LegendTitle = "Entre 0 y 5";
                    series.ValueMember = "Entre 0 y 5";
                    series.CategoryMember = "Horas1";

                    series2.DataPoints.Add(new CategoricalDataPoint(item.criterio2.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                    series2.LegendTitle = "Desde 6 hasta 8";
                    series.ValueMember = "Desde 6 hasta 8";
                    series.CategoryMember = "Horas2";

                    series3.DataPoints.Add(new CategoricalDataPoint(item.criterio3.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                    series3.LegendTitle = "Desde 8 hasta 9.6";
                    series.ValueMember = "Desde 8 hasta 9.6";
                    series.CategoryMember = "Horas3";

                    series4.DataPoints.Add(new CategoricalDataPoint(item.criterio4.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                    series4.LegendTitle = "Mayor a 9.6";
                    series.ValueMember = "Mayor a 9.6";
                    series.CategoryMember = "Horas4";
                }

            }

            this.charGrafico.Series.Add(series);
            this.charGrafico.Series.Add(series2);
            this.charGrafico.Series.Add(series3);
            this.charGrafico.Series.Add(series4);

            this.charGrafico.ShowLegend = true;
            this.charGrafico.LegendTitle = "Leyenda";
            this.charGrafico.ShowTitle = true;
            this.charGrafico.Title = "Reporte de horas desarrolladas en labores de campo by personal";
            this.charGrafico.ChartElement.TitlePosition = TitlePosition.Top;
            this.charGrafico.ChartElement.TitleElement.Padding = new System.Windows.Forms.Padding(this.charGrafico.View.Margin.Left, 10, 0, 0);


            CartesianArea area = this.charGrafico.GetArea<CartesianArea>();
            area.ShowGrid = true;
            CartesianGrid grid = area.GetGrid<CartesianGrid>();
            grid.DrawHorizontalStripes = true;
            grid.DrawVerticalStripes = true;
            grid.DrawHorizontalFills = true;
            grid.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;


            foreach (CartesianSeries seriesGrafico in this.charGrafico.Series)
            {
                seriesGrafico.ShowLabels = true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {

            try
            {

                //GenerarGraficoPresentacion();

                this.dgvResumen.TableElement.BeginUpdate();
                this.dgvDetalle.TableElement.BeginUpdate();
                this.dgvAgrupado.TableElement.BeginUpdate();
                //this.dgvListado.Columns["chDocumento"].FormatString = "{0:N0}";
                this.LoadFreightSummary();
                this.dgvResumen.TableElement.EndUpdate();
                this.dgvAgrupado.TableElement.EndUpdate();
                this.dgvDetalle.TableElement.EndUpdate();
                base.OnLoad(e);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;

            }

        }

        private void LoadFreightSummary()
        {
            this.dgvResumen.MasterTemplate.AutoExpandGroups = true;
            this.dgvResumen.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvResumen.GroupDescriptors.Clear();
            this.dgvResumen.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items1 = new GridViewSummaryRowItem();
            items1.Add(new GridViewSummaryItem("chnombresTrabajador", "Registros : {0:N0}; ", GridAggregateFunction.Count));
            items1.Add(new GridViewSummaryItem("chCriterio1", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chCriterio2", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chCriterio3", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chCriterio4", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chtotal", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            //this.dgvListaAgrupada.MasterTemplate.SummaryRowsBottom.Add(items1);
            this.dgvResumen.MasterTemplate.SummaryRowsTop.Add(items1);


            this.dgvAgrupado.MasterTemplate.AutoExpandGroups = true;
            this.dgvAgrupado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvAgrupado.GroupDescriptors.Clear();
            this.dgvAgrupado.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items3 = new GridViewSummaryRowItem();
            items3.Add(new GridViewSummaryItem("chnombresTrabajador", "Registros : {0:N0}; ", GridAggregateFunction.Count));
            this.dgvAgrupado.MasterTemplate.SummaryRowsTop.Add(items3);


            this.dgvDetalle.MasterTemplate.AutoExpandGroups = true;
            this.dgvDetalle.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.GroupDescriptors.Clear();
            this.dgvDetalle.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items2 = new GridViewSummaryRowItem();
            items2.Add(new GridViewSummaryItem("chnombresTrabajador", "Registros : {0:N0}; ", GridAggregateFunction.Count));
            this.dgvDetalle.MasterTemplate.SummaryRowsTop.Add(items2);


        }

        private void ObtenerFechasIniciales()
        {
            //this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);

            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);
        }

        private void ObtenerFechasMes()
        {
            DateTime fecha1;
            DateTime fecha2;

            if (cboMes.SelectedValue.ToString() != "00")
            {
                #region
                this.txtFechaDesde.Enabled = false;
                this.txtFechaHasta.Enabled = false;
                if (cboMes.SelectedValue.ToString() == "12")
                {
                    #region Si es mes diciembre
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtAño.Value.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtAño.Value.ToString());// 
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();
                    #endregion

                }
                else
                {
                    #region Si es mes 13 habilitar controles de fecha, caso contrario es un mes de enero a noviembre.
                    if (cboMes.SelectedValue.ToString() == "13")
                    {
                        this.txtFechaDesde.Enabled = true;
                        this.txtFechaHasta.Enabled = true;


                    }
                    else
                    {
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtAño.Value.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtAño.Value.ToString());// 
                        this.txtFechaDesde.Text = fecha1.ToShortDateString();
                        this.txtFechaHasta.Text = fecha2.ToShortDateString();


                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                if (cboMes.SelectedValue.ToString() == "00")
                {
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtAño.Value.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtAño.Value.ToString());//
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();

                }

            }
        }

        private void CargarMeses()
        {

            MesesNeg = new MesNegocios();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = MesesNeg.ListarDoceMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Realizar consulta()
                #region Obtener planillas involudradas()
                listaPlanillasInvolucradas = new List<string>();

                if (chkEma.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("EMA");
                }

                if (chkEmp.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("EMP");
                }

                if (chkObm.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("OBM");
                }

                if (chkPas.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("PAS");
                }

                if (chkPam.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("PAM");
                }

                if (chkPoa.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("POA");
                }

                if (chkPra.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("PRA");
                }
                #endregion
                dgvResumen.Enabled = false;
                tabControl.Enabled = false;
                gbGrupo.Enabled = false;
                desde = this.txtFechaDesde.Text.ToString().Trim();
                hasta = this.txtFechaHasta.Text.ToString().Trim();
                btnConsultar.Enabled = false;
                progressBar.Visible = true;
                bgwHilo.RunWorkerAsync();
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores = new List<DesarrolloLaboresPersonalCampo>();
                ListadoResumenHorasAcumuladasByPersonalByDia = new List<HoraTrabajadaByPersonalCampo>();
                listadoAsistenciaAgrupado = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                listadoAsistencia = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                modeloLabores = new MovimientoDesarrolloLaboresPersonalCampoNegocio();
                modelo = new HorasTrabajadasByPersonalCampoNegocio();

                listadoAsistencia = modeloLabores.ObtenerListadoListadoAsistenaPersonalCampo("2014", desde, hasta, listaPlanillasInvolucradas).ToList();
                listadoAsistenciaAgrupado = modelo.ObtenerListadoHorasAcumuladasByPersonalByDia(listadoAsistencia);
                ListadoResumenHorasAcumuladasByPersonalByDia = modelo.ObtenerListadoResumenHorasAcumuladasByPersonalByDia(listadoAsistenciaAgrupado);
            }
            catch (Exception Ex)
            {
                dgvResumen.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                tabControl.Enabled = true;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {


                this.dgvDetalle.DataSource = listadoAsistencia.ToDataTable<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                this.dgvDetalle.Refresh();

                this.dgvAgrupado.DataSource = listadoAsistenciaAgrupado.ToDataTable<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                this.dgvAgrupado.Refresh();



                this.dgvResumen.FilterDescriptors.Clear();
                this.dgvResumen.DataSource = ListadoResumenHorasAcumuladasByPersonalByDia.ToDataTable<HoraTrabajadaByPersonalCampo>();
                this.dgvResumen.Refresh();

                GenerarGraficoPresentacion(ListadoResumenHorasAcumuladasByPersonalByDia);

                this.dgvResumen.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                gbGrupo.Enabled = true;
                tabControl.Enabled = true;
            }
            catch (Exception Ex)
            {
                tabControl.Enabled = true;
                gbGrupo.Enabled = true;
                dgvResumen.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnExportarResumen_Click(object sender, EventArgs e)
        {
            if (ListadoResumenHorasAcumuladasByPersonalByDia != null && ListadoResumenHorasAcumuladasByPersonalByDia.ToList().Count > 0)
            {
                Exportar(this.dgvResumen);
            }
        }

        private void btnExportarListaDetalle_Click(object sender, EventArgs e)
        {
            if (listadoAsistencia != null && listadoAsistencia.ToList().Count > 0)
            {
                Exportar(this.dgvDetalle);
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
            excelExporter.SheetName = "Asistencias EASJ";
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
                return;
            }
        }

        private void ReporteDeHorasDesarrolladasEnLaboresDeCampoByPersonal_Load(object sender, EventArgs e)
        {

        }

        private void dgvListadoByAgrupado2_SelectionChanged(object sender, EventArgs e)
        {
            fFecha = "";
            fValor = 0;
            fValor2 = 0;
            try
            {
                #region MyRegion
                if (dgvResumen != null && dgvResumen.Rows.Count > 0)
                {
                    #region
                    if (dgvResumen.CurrentRow != null && dgvResumen.CurrentRow.Cells["chFECHA"].Value != "")
                    {
                        fFecha = dgvResumen.CurrentRow.Cells["chFECHA"].Value.ToString();
                        if (dgvResumen.CurrentCell != null)
                        {
                            #region MyRegion
                            if (dgvResumen.CurrentRow.Cells[dgvResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "Entre 0 y 5".ToUpper())
                            {
                                fValor = Convert.ToDecimal(0.0000001);
                                fValor2 = 6;
                            }
                            if (dgvResumen.CurrentRow.Cells[dgvResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "desde 6 hasta 8".ToUpper())
                            {
                                fValor = 6;
                                fValor2 = 8;
                            }
                            if (dgvResumen.CurrentRow.Cells[dgvResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "desde 8 hasta 9.6".ToUpper())
                            {
                                fValor = 8;
                                fValor2 = Convert.ToDecimal(9.6);
                            }
                            if (dgvResumen.CurrentRow.Cells[dgvResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "Mayor a 9.6".ToUpper())
                            {
                                fValor2 = 24;
                                fValor = Convert.ToDecimal(9.6);
                            }

                            #endregion
                        }
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void dgvListadoByAgrupado2_DoubleClick(object sender, EventArgs e)
        {

            if (fFecha != "" && fValor > 0 && fValor2 > 0)
            {

                if (this.dgvAgrupado.FilterDescriptors.Count > 0)
                {
                    this.dgvAgrupado.FilterDescriptors.Clear();
                }

                if (((RadGridView)sender).CurrentRow != null && ((RadGridView)sender) != null)
                {
                    #region
                    if (fFecha != "" && fValor > 0)
                    {
                        this.tabControl.SelectedPage = tabAgrupado;

                        FilterDescriptor filter2 = new FilterDescriptor();
                        filter2.PropertyName = "chFECHA";
                        filter2.Operator = FilterOperator.IsEqualTo;
                        filter2.Value = Convert.ToDateTime(fFecha);
                        filter2.IsFilterEditor = true;

                        CompositeFilterDescriptor filter = new CompositeFilterDescriptor();
                        filter.FilterDescriptors.Add(new FilterDescriptor("chTOTAL_HORAS", FilterOperator.IsGreaterThan, Convert.ToDecimal(fValor)));
                        filter.FilterDescriptors.Add(new FilterDescriptor("chTOTAL_HORAS", FilterOperator.IsLessThanOrEqualTo, Convert.ToDecimal(fValor2)));
                        filter.LogicalOperator = FilterLogicalOperator.And;

                        this.dgvAgrupado.FilterDescriptors.Add(filter2);
                        this.dgvAgrupado.FilterDescriptors.Add(filter);
                        this.dgvAgrupado.Refresh();
                    }
                    #endregion
                }


            }
        }

        private void dgvAgrupado_SelectionChanged(object sender, EventArgs e)
        {
            nfFecha = "";
            nfCodigoPersonalGeneral = "";
            try
            {

                if (dgvAgrupado != null && dgvAgrupado.Rows.Count > 0)
                {
                    if (dgvAgrupado.CurrentRow != null && dgvAgrupado.CurrentRow.Cells["chFECHA"].Value != null && dgvAgrupado.CurrentRow.Cells["chIDCODIGOGENERAL"].Value != null && dgvAgrupado.CurrentRow.Cells["chIDACTIVIDAD"].Value != null)
                    {
                        if (dgvAgrupado.CurrentRow != null && dgvAgrupado.CurrentRow.Cells["chFECHA"].Value != "" && dgvAgrupado.CurrentRow.Cells["chIDCODIGOGENERAL"].Value.ToString().Trim() != "" && dgvAgrupado.CurrentRow.Cells["chIDACTIVIDAD"].Value.ToString().Trim() != "")
                        {
                            nfFecha = dgvAgrupado.CurrentRow.Cells["chFECHA"].Value.ToString().Trim();
                            nfCodigoPersonalGeneral = dgvAgrupado.CurrentRow.Cells["chIDCODIGOGENERAL"].Value.ToString().Trim();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgvAgrupado_DoubleClick(object sender, EventArgs e)
        {
            if (((RadGridView)sender).CurrentRow != null && ((RadGridView)sender) != null)
            {
                #region
                if (nfFecha != "" && nfCodigoPersonalGeneral != "")
                {
                    if (this.dgvDetalle.FilterDescriptors.Count > 0)
                    {
                        this.dgvDetalle.FilterDescriptors.Clear();
                    }

                    this.tabControl.SelectedPage = tabDetalle;
                    FilterDescriptor filter = new FilterDescriptor();
                    filter.PropertyName = "chIDCODIGOGENERAL";
                    filter.Operator = FilterOperator.IsEqualTo;
                    filter.Value = nfCodigoPersonalGeneral.ToString();
                    filter.IsFilterEditor = true;

                    FilterDescriptor filter2 = new FilterDescriptor();
                    filter2.PropertyName = "chFECHA";
                    filter2.Operator = FilterOperator.IsEqualTo;
                    filter2.Value = Convert.ToDateTime(nfFecha);
                    filter2.IsFilterEditor = true;

                    this.dgvDetalle.FilterDescriptors.Add(filter);
                    this.dgvDetalle.FilterDescriptors.Add(filter2);
                    this.dgvDetalle.Refresh();
                }
                #endregion
            }
        }

        private void btnExportarAgrupado_Click(object sender, EventArgs e)
        {
            if (listadoAsistenciaAgrupado != null && listadoAsistenciaAgrupado.ToList().Count > 0)
            {
                Exportar(this.dgvAgrupado);
            }
        }

    }
}