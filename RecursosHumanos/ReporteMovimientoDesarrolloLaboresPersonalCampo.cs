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
    public partial class ReporteMovimientoDesarrolloLaboresPersonalCampo : Form
    {

        private MovimientoDesarrolloLaboresPersonalCampoNegocio modelo;
        private List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistencia;
        private List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistenciaConMasDeUnaLabor;
        private List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistenciaConMasDeUnaActividad;

        private string fileName;
        private bool exportVisualSettings;
        private string desde;
        private string hasta;
        private MesNegocios MesesNeg;
        private List<DesarrolloLaboresPersonalCampo> ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores;
        private object fFecha; /* Valor que ocupara mi filtro en la grilla agrupado con relacion a la fecha */
        private int fValor; /* Valor que ocupara mi filtro en la grilla agrupado*/
        private string nfFecha;
        private string nfCodigoPersonalGeneral; /* Valor que ocupara mi filtro en la grilla detalle para el codigo del personal*/
        private string nfIdActividad;  /* Valor que ocupara mi filtro en la grilla detalle para el codigo de la actividad*/
        private List<string> listaPlanillasInvolucradas;
        private int incluirActividad;
        private int incluirLabor;
        private List<string> listadoLaboresIncluidasEnVista;

        public ReporteMovimientoDesarrolloLaboresPersonalCampo()
        {
            InitializeComponent();
            CargarMeses();
            ObtenerFechasIniciales();

            RadGridLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();


        }

        protected override void OnLoad(EventArgs e)
        {

            this.dgvListadoByAgrupado.TableElement.BeginUpdate();
            this.dgvListadoByDetallado.TableElement.BeginUpdate();
            //this.dgvListado.Columns["chDocumento"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvListadoByAgrupado.TableElement.EndUpdate();
            this.dgvListadoByDetallado.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvListadoByAgrupado.MasterTemplate.AutoExpandGroups = true;
            this.dgvListadoByAgrupado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoByAgrupado.GroupDescriptors.Clear();
            this.dgvListadoByAgrupado.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items1 = new GridViewSummaryRowItem();
            items1.Add(new GridViewSummaryItem("chnombresTrabajador", "Registros : {0:N0}; ", GridAggregateFunction.Count));
            //items1.Add(new GridViewSummaryItem("chprecio", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            //items1.Add(new GridViewSummaryItem("chimporte", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            //items1.Add(new GridViewSummaryItem("chcantidad", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            //this.dgvListaAgrupada.MasterTemplate.SummaryRowsBottom.Add(items1);
            this.dgvListadoByAgrupado.MasterTemplate.SummaryRowsTop.Add(items1);


            this.dgvListadoByDetallado.MasterTemplate.AutoExpandGroups = true;
            this.dgvListadoByDetallado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoByDetallado.GroupDescriptors.Clear();
            this.dgvListadoByDetallado.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items2 = new GridViewSummaryRowItem();
            items2.Add(new GridViewSummaryItem("chnombresTrabajador", "Registros : {0:N0}; ", GridAggregateFunction.Count));
            //items1.Add(new GridViewSummaryItem("chprecio", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            //items1.Add(new GridViewSummaryItem("chimporte", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            //items1.Add(new GridViewSummaryItem("chcantidad", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            //this.dgvListaAgrupada.MasterTemplate.SummaryRowsBottom.Add(items1);
            this.dgvListadoByDetallado.MasterTemplate.SummaryRowsTop.Add(items2);


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

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                modelo = new MovimientoDesarrolloLaboresPersonalCampoNegocio();
                listadoAsistencia = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                listadoAsistenciaConMasDeUnaLabor = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores = new List<DesarrolloLaboresPersonalCampo>();

                listadoAsistencia = modelo.ObtenerListadoListadoAsistenaPersonalCampo("2014", desde, hasta, listaPlanillasInvolucradas).ToList();

                /*
                listadoAsistenciaConMasDeUnaActividad = modelo.ObtenerListadoPersonalEnMasdeUnaActividad(listadoAsistencia).ToList();
                listadoAsistenciaConMasDeUnaLabor = modelo.ObtenerListadoPersonalEnMasdeUnaLabor(listadoAsistencia).ToList();
                ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores = modelo.ObtenerListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores(listadoAsistenciaConMasDeUnaLabor, listadoAsistenciaConMasDeUnaActividad).ToList();
                */

                listadoAsistenciaConMasDeUnaLabor = modelo.ObtenerListadoPersonalEnMasdeUnaLabor(listadoAsistencia, incluirLabor).ToList();
                ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores = modelo.ObtenerListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores(listadoAsistenciaConMasDeUnaLabor);

            }
            catch (Exception Ex)
            {
                dgvListadoByAgrupado.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.dgvListadoByDetallado.DataSource = listadoAsistencia.ToDataTable<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                this.dgvListadoByDetallado.Refresh();

                //if (listadoAsistenciaConMasDeUnaActividad != null && listadoAsistenciaConMasDeUnaActividad.ToList().Count > 0)
                //{
                //    listadoAsistenciaConMasDeUnaLabor.AddRange(listadoAsistenciaConMasDeUnaActividad);
                //}

                this.dgvListadoByAgrupado.FilterDescriptors.Clear();
                this.dgvListadoByAgrupado.DataSource = listadoAsistenciaConMasDeUnaLabor.ToDataTable<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                this.dgvListadoByAgrupado.Refresh();
                this.dgvListadoByAgrupado.Enabled = true;


                this.dgvListadoByResumen.DataSource = ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores.ToDataTable<DesarrolloLaboresPersonalCampo>();
                this.dgvListadoByResumen.Refresh();

                GenerarGraficoPresentacion(ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores);

                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                gbGrupo.Enabled = true;
            }
            catch (Exception Ex)
            {
                gbGrupo.Enabled = true;
                dgvListadoByAgrupado.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void GenerarGraficoPresentacion(List<DesarrolloLaboresPersonalCampo> ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores)
        {
            this.charGrafico.Series.Clear();
            LineSeries series = new LineSeries();
            LineSeries series2 = new LineSeries();
            LineSeries series3 = new LineSeries();
            LineSeries series4 = new LineSeries();
            if (ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores != null && ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores.ToList().Count > 0)
            {
                series = new LineSeries();
                series2 = new LineSeries();
                series3 = new LineSeries();
                series4 = new LineSeries();
                foreach (var item in ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores)
                {

                    series.DataPoints.Add(new CategoricalDataPoint(item.unaLabor.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                    series.LegendTitle = "01 Labor";
                    series.ValueMember = "01 Labor";
                    series.CategoryMember = "01 Labor";

                    series2.DataPoints.Add(new CategoricalDataPoint(item.dosLabor.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                    series2.LegendTitle = "02 Labor";
                    series2.ValueMember = "02 Labor";
                    series2.CategoryMember = "02 Labor";


                    series3.DataPoints.Add(new CategoricalDataPoint(item.tresLabor.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                    series3.LegendTitle = "03 Labor";
                    series3.ValueMember = "03 Labor";
                    series3.CategoryMember = "03 Labor";


                    series4.DataPoints.Add(new CategoricalDataPoint(item.cuatroLabor.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                    series4.LegendTitle = "04 Labor";
                    series4.ValueMember = "04 Labor";
                    series4.CategoryMember = "04 Labor";
                }

            }

            this.charGrafico.Series.Add(series);
            this.charGrafico.Series.Add(series2);
            this.charGrafico.Series.Add(series3);
            this.charGrafico.Series.Add(series4);

            this.charGrafico.ShowLegend = true;
            this.charGrafico.LegendTitle = "Leyenda";
            this.charGrafico.ShowTitle = true;
            this.charGrafico.Title = "Reporte de movimiento de desarrollo de labores del personal de campo";
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

        private void GenerarGraficoPresentacion(List<DesarrolloLaboresPersonalCampo> ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores, List<string> listadoLaboresIncluirVista)
        {
            this.charGrafico.Series.Clear();

            LineSeries series = new LineSeries();
            LineSeries series2 = new LineSeries();
            LineSeries series3 = new LineSeries();
            LineSeries series4 = new LineSeries();
            if (ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores != null && ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores.ToList().Count > 0)
            {
                series = new LineSeries();
                series2 = new LineSeries();
                series3 = new LineSeries();
                series4 = new LineSeries();
                foreach (var item in ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores)
                {
                    foreach (var item2 in listadoLaboresIncluirVista)
                    {
                        if (item2 == "1")
                        {
                            series.DataPoints.Add(new CategoricalDataPoint(item.unaLabor.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                            series.LegendTitle = "01 Labor";
                            series.ValueMember = "01 Labor";
                            series.CategoryMember = "01 Labor";
                        }

                        if (item2 == "2")
                        {
                            series2.DataPoints.Add(new CategoricalDataPoint(item.dosLabor.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                            series2.LegendTitle = "02 Labor";
                            series2.ValueMember = "02 Labor";
                            series2.CategoryMember = "02 Labor";
                        }

                        if (item2 == "3")
                        {
                            series3.DataPoints.Add(new CategoricalDataPoint(item.tresLabor.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                            series3.LegendTitle = "03 Labor";
                            series3.ValueMember = "03 Labor";
                            series3.CategoryMember = "03 Labor";
                        }

                        if (item2 == "4")
                        {
                            series4.DataPoints.Add(new CategoricalDataPoint(item.cuatroLabor.Value, item.fecha.ToPresentationDate().Substring(0, 5)));
                            series4.LegendTitle = "04 Labor";
                            series4.ValueMember = "04 Labor";
                            series4.CategoryMember = "04 Labor";
                        }

                    }

                }

            }

            foreach (var item2 in listadoLaboresIncluirVista)
            {
                if (item2 == "1")
                {
                    this.charGrafico.Series.Add(series);
                }

                if (item2 == "2")
                {
                    this.charGrafico.Series.Add(series2);
                }

                if (item2 == "3")
                {
                    this.charGrafico.Series.Add(series3);
                }

                if (item2 == "4")
                {
                    this.charGrafico.Series.Add(series4);
                }
            }


            this.charGrafico.ShowLegend = true;
            this.charGrafico.LegendTitle = "Leyenda";
            this.charGrafico.ShowTitle = true;
            this.charGrafico.Title = "Reporte de movimiento de desarrollo de labores del personal de campo";
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar(dgvListadoByAgrupado);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Realizar consulta()
                incluirActividad = 0;
                incluirLabor = 0;

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


                #region Obtener criterios de operacion del reporte()
                if (chkLaboresRepetidasByActividad.Checked == true)
                {
                    incluirLabor = 1;
                }

                if (chkActividadesRepetidasByDia.Checked == true)
                {
                    incluirActividad = 1;
                }
                #endregion

                dgvListadoByAgrupado.Enabled = false;
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

        private void ReporteMovimientoDesarrolloLaboresPersonalCampo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReporteMovimientoDesarrolloLaboresPersonalCampo_Load(object sender, EventArgs e)
        {

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

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void btnExportarResumen_Click(object sender, EventArgs e)
        {
            Exportar(dgvListadoByResumen);
        }

        private void dgvListadoByResumen_SelectionChanged(object sender, EventArgs e)
        {
            fFecha = "";
            fValor = 0;

            try
            {
                #region MyRegion
                if (dgvListadoByResumen != null && dgvListadoByResumen.Rows.Count > 0)
                {
                    #region
                    if (dgvListadoByResumen.CurrentRow != null && dgvListadoByResumen.CurrentRow.Cells["chFECHA"].Value != "")
                    {
                        fFecha = dgvListadoByResumen.CurrentRow.Cells["chFECHA"].Value;
                        if (dgvListadoByResumen.CurrentCell != null)
                        {
                            #region MyRegion
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chUnaLabor")  
                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "1 Lab.".ToUpper())
                            {
                                fValor = 1;
                            }

                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chDosLabor")
                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "2 Lab.".ToUpper())
                            {
                                fValor = 2;
                            }
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chTresLabor")

                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "3 Lab.".ToUpper())
                            {
                                fValor = 3;
                            }
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chCuatroLabor")
                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "4 Lab.".ToUpper())
                            {
                                fValor = 4;
                            }
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chCincoLabor")
                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "5 Lab.".ToUpper())
                            {
                                fValor = 5;
                            }
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chSeisLabor")
                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "6 Lab.".ToUpper())
                            {
                                fValor = 6;
                            }
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chSieteLabor")
                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "7 Lab.".ToUpper())
                            {
                                fValor = 7;
                            }
                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "8 Lab.".ToUpper())
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chOchoLabor")
                            {
                                fValor = 8;
                            }
                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "9 Lab.".ToUpper())
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chNueveLabor")
                            {
                                fValor = 9;
                            }

                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "10 Lab.".ToUpper())
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chDiezLabor")
                            {
                                fValor = 10;
                            }
                            if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim().ToUpper() == "+10 Lab.".ToUpper())
                            //if (dgvListadoByResumen.CurrentRow.Cells[dgvListadoByResumen.CurrentCell.ColumnIndex].ColumnInfo.HeaderText.ToString().Trim() == "chmasDiez")
                            {
                                fValor = 11;
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

        private void dgvListadoByResumen_DoubleClick(object sender, EventArgs e)
        {


            if (dgvListadoByAgrupado.FilterDescriptors.Count > 0)
            {
                this.dgvListadoByAgrupado.FilterDescriptors.Clear();
            }

            if (((RadGridView)sender).CurrentRow != null && ((RadGridView)sender) != null)
            {
                #region
                if (fFecha != "" && fValor > 0)
                {
                    this.tabControl.SelectedPage = tabNumeroLabores;
                    //dgvListadoByAgrupado.Columns["chTOTAL_HORAS"].Prop

                    FilterDescriptor filter = new FilterDescriptor();
                    filter.PropertyName = "chTOTAL_HORAS";
                    filter.Operator = FilterOperator.IsEqualTo;
                    filter.Value = fValor.ToString();
                    filter.IsFilterEditor = true;

                    FilterDescriptor filter2 = new FilterDescriptor();
                    filter2.PropertyName = "chFECHA";
                    filter2.Operator = FilterOperator.IsEqualTo;
                    filter2.Value = Convert.ToDateTime(fFecha);
                    filter2.IsFilterEditor = true;


                    //CompositeFilterDescriptor filter2 = new CompositeFilterDescriptor();
                    //filter2.FilterDescriptors.Add(new FilterDescriptor("chFECHA", FilterOperator.IsGreaterThanOrEqualTo, fFecha.ToString().Substring(0, 10)));
                    //filter2.FilterDescriptors.Add(new FilterDescriptor("chFECHA", FilterOperator.IsLessThanOrEqualTo, fFecha.ToString().Substring(0, 10)));
                    //filter2.LogicalOperator = FilterLogicalOperator.And;


                    if (dgvListadoByAgrupado.FilterDescriptors.Count > 0)
                    {
                        this.dgvListadoByAgrupado.FilterDescriptors.Clear();
                    }

                    //dgvListadoByAgrupado.DataSource = listadoAsistenciaConMasDeUnaLabor.ToDataTable<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                    //dgvListadoByAgrupado.Refresh();

                    this.dgvListadoByAgrupado.FilterDescriptors.Add(filter);
                    this.dgvListadoByAgrupado.FilterDescriptors.Add(filter2);
                    dgvListadoByAgrupado.Refresh();
                    //this.dgvListadoByAgrupado.FilterDescriptors.AddRange(filter, filter2);

                    //this.dgvListadoByAgrupado.FilterDescriptors.Add(filter2);
                    //dgvListadoByAgrupado.fil
                }
                #endregion
            }




        }

        private void btnExportarListaDetalle_Click(object sender, EventArgs e)
        {
            Exportar(dgvListadoByDetallado);
        }

        private void dgvListadoByAgrupado_SelectionChanged(object sender, EventArgs e)
        {

            nfFecha = "";
            nfCodigoPersonalGeneral = "";
            nfIdActividad = "";

            try
            {
                #region MyRegion
                if (dgvListadoByAgrupado != null && dgvListadoByAgrupado.Rows.Count > 0)
                {
                    if (dgvListadoByAgrupado.CurrentRow != null && dgvListadoByAgrupado.CurrentRow.Cells["chFECHA"].Value != null && dgvListadoByAgrupado.CurrentRow.Cells["chIDCODIGOGENERAL"].Value != null && dgvListadoByAgrupado.CurrentRow.Cells["chIDACTIVIDAD"].Value != null)
                    {
                        if (dgvListadoByAgrupado.CurrentRow != null && dgvListadoByAgrupado.CurrentRow.Cells["chFECHA"].Value != "" && dgvListadoByAgrupado.CurrentRow.Cells["chIDCODIGOGENERAL"].Value.ToString().Trim() != "" && dgvListadoByAgrupado.CurrentRow.Cells["chIDACTIVIDAD"].Value.ToString().Trim() != "")
                        {

                            nfFecha = dgvListadoByAgrupado.CurrentRow.Cells["chFECHA"].Value.ToString().Trim();
                            nfCodigoPersonalGeneral = dgvListadoByAgrupado.CurrentRow.Cells["chIDCODIGOGENERAL"].Value.ToString().Trim();
                            nfIdActividad = dgvListadoByAgrupado.CurrentRow.Cells["chIDACTIVIDAD"].Value.ToString().Trim();
                        }
                    }
                }
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void dgvListadoByAgrupado_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (dgvListadoByDetallado.FilterDescriptors.Count > 0)
                {
                    this.dgvListadoByDetallado.FilterDescriptors.Clear();
                }

                if (((RadGridView)sender).CurrentRow != null && ((RadGridView)sender) != null)
                {
                    #region
                    if (nfFecha != "" && nfCodigoPersonalGeneral != "" && nfIdActividad != "")
                    {
                        this.tabControl.SelectedPage = tabLaboresByDiaByPersona;
                        //dgvListadoByAgrupado.Columns["chTOTAL_HORAS"].Prop

                        FilterDescriptor filter = new FilterDescriptor();
                        filter.PropertyName = "chIDCODIGOGENERAL";
                        filter.Operator = FilterOperator.IsEqualTo;
                        filter.Value = nfCodigoPersonalGeneral.ToString();
                        filter.IsFilterEditor = true;

                        /*
                        FilterDescriptor filter3 = new FilterDescriptor();
                        filter3.PropertyName = "chIDACTIVIDAD";
                        filter3.Operator = FilterOperator.IsEqualTo;
                        filter3.Value = nfIdActividad.ToString();
                        filter3.IsFilterEditor = true;
                         */

                        FilterDescriptor filter2 = new FilterDescriptor();
                        filter2.PropertyName = "chFECHA";
                        filter2.Operator = FilterOperator.IsEqualTo;
                        filter2.Value = Convert.ToDateTime(nfFecha);
                        filter2.IsFilterEditor = true;


                        //CompositeFilterDescriptor filter2 = new CompositeFilterDescriptor();
                        //filter2.FilterDescriptors.Add(new FilterDescriptor("chFECHA", FilterOperator.IsGreaterThanOrEqualTo, fFecha.ToString().Substring(0, 10)));
                        //filter2.FilterDescriptors.Add(new FilterDescriptor("chFECHA", FilterOperator.IsLessThanOrEqualTo, fFecha.ToString().Substring(0, 10)));
                        //filter2.LogicalOperator = FilterLogicalOperator.And;

                        if (dgvListadoByDetallado.FilterDescriptors.Count > 0)
                        {
                            this.dgvListadoByDetallado.FilterDescriptors.Clear();
                        }

                        //dgvListadoByAgrupado.DataSource = listadoAsistenciaConMasDeUnaLabor.ToDataTable<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                        //dgvListadoByAgrupado.Refresh();

                        this.dgvListadoByDetallado.FilterDescriptors.Add(filter);
                        this.dgvListadoByDetallado.FilterDescriptors.Add(filter2);

                        //this.dgvListadoByDetallado.BestFitColumns(BestFitColumnMode.AllCells);
                        //this.dgvListadoByDetallado.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                        this.dgvListadoByDetallado.AutoExpandGroups = true;
                        this.dgvListadoByDetallado.SortDescriptors.Add("chlabor", System.ComponentModel.ListSortDirection.Ascending);
                        this.dgvListadoByDetallado.GroupDescriptors.Add("chlabor", System.ComponentModel.ListSortDirection.Ascending);
                        this.dgvListadoByDetallado.MasterTemplate.DataView.PagingBeforeGrouping = true;

                        //this.dgvListadoByDetallado.FilterDescriptors.Add(filter3);
                        dgvListadoByDetallado.Refresh();
                        //this.dgvListadoByAgrupado.FilterDescriptors.AddRange(filter, filter2);

                        //this.dgvListadoByAgrupado.FilterDescriptors.Add(filter2);
                        //dgvListadoByAgrupado.fil
                    }
                    #endregion
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgvListadoByResumen_Click(object sender, EventArgs e)
        {
            if (dgvListadoByAgrupado.FilterDescriptors.Count > 0)
            {
                this.dgvListadoByAgrupado.FilterDescriptors.Clear();
            }

            if (dgvListadoByDetallado.FilterDescriptors.Count > 0)
            {
                this.dgvListadoByDetallado.FilterDescriptors.Clear();
            }


        }

        private void tabResumenByNumeroLabores_Paint(object sender, PaintEventArgs e)
        {
            if (dgvListadoByAgrupado.FilterDescriptors.Count > 0)
            {
                this.dgvListadoByAgrupado.FilterDescriptors.Clear();
            }

            if (dgvListadoByDetallado.FilterDescriptors.Count > 0)
            {
                this.dgvListadoByDetallado.FilterDescriptors.Clear();
            }
        }

        private void btnActualizarVistaGrafico_Click(object sender, EventArgs e)
        {
            listadoLaboresIncluidasEnVista = new List<string>();

            if (chkUnaLabor.Checked == true)
            {
                listadoLaboresIncluidasEnVista.Add("1");
            }
            if (chkDosLabor.Checked == true)
            {
                listadoLaboresIncluidasEnVista.Add("2");
            }
            if (chkTresLabor.Checked == true)
            {
                listadoLaboresIncluidasEnVista.Add("3");
            }
            if (chkCuatroLabor.Checked == true)
            {
                listadoLaboresIncluidasEnVista.Add("4");
            }


            GenerarGraficoPresentacion(ListadoPersonalEnMasdeUnaLaborResumidoPorCantidaPersonalEnLabores, listadoLaboresIncluidasEnVista);
        }

    }
}
