using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.Pivot.Core;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.Charting;
using Telerik.Pivot.Core.Aggregates;
using System.IO;
using Telerik.WinControls.UI.Localization;
using Telerik.Pivot.Core.ViewModels;
using TransportistaMto.Datos;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI.Export;
using TransportistaMto.Datos;


namespace Transportista
{
    public partial class ReporteRefrigeriosPorSubPlanilla : Form
    {


        private LocalDataSourceProvider provider;
        private PivotGroupNode firstNode;
        private int añoConsulta;
        private SJM_PensionesNegocios negocio;
        private List<SJ_ReporteRefigeriosSubPlanilla> lista;


        public ReporteRefrigeriosPorSubPlanilla()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            PivotGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.PivotGridLocalizationProviderEspanol();
            this.LoadSettings();


//            Theme theme = Theme.ReadCSSText(@" 
//                                            theme 
//                                            { 
//                                            name: ControlDefault; 
//                                            elementType: Telerik.WinControls.UI.RadChartElement; 
//                                            controlType: Telerik.WinControls.UI.RadChartView; 
//                                            } 
//                                            Bar 
//                                            { 
//                                            HeightAspectRatio 
//                                            { 
//                                            Value: 100; 
//                                            EndValue: 150; 
//                                            MaxValue: 150; 
//                                            Frames: 200; 
//                                            Interval: 140; 
//                                            EasingType: InOutCubic; 
//                                            RandomDelay: 500; 
//                                            RemoveAfterApply: true; 
//                                            } 
//                                            } 
//                                            ");
//            ThemeRepository.Add(theme, false);


            this.checkBoxDelayUpdates.ToggleStateChanged += new StateChangedEventHandler(checkBox_ToggleStateChanged);
            this.checkBoxSelectionOnly.ToggleStateChanged += new StateChangedEventHandler(checkBox_ToggleStateChanged);
            this.checkBoxColumnSubTotals.ToggleStateChanged += new StateChangedEventHandler(checkBox_ToggleStateChanged);
            this.checkBoxRowSubTotals.ToggleStateChanged += new StateChangedEventHandler(checkBox_ToggleStateChanged);
            this.checkBoxColumnGrandTotals.ToggleStateChanged += new StateChangedEventHandler(checkBox_ToggleStateChanged);
            this.checkBoxRowGrandTotals.ToggleStateChanged += new StateChangedEventHandler(checkBox_ToggleStateChanged);
            this.radioRows.ToggleStateChanged += new StateChangedEventHandler(radioRows_ToggleStateChanged);
            this.radioColumns.ToggleStateChanged += new StateChangedEventHandler(radioRows_ToggleStateChanged);
            this.radioBarSeries.ToggleStateChanged += new StateChangedEventHandler(radioSeries_ToggleStateChanged);
            this.radioLineSeries.ToggleStateChanged += new StateChangedEventHandler(radioSeries_ToggleStateChanged);
            this.radioAreaSeries.ToggleStateChanged += new StateChangedEventHandler(radioSeries_ToggleStateChanged);
            this.dgvRegistros.ChartDataProvider.UpdateCompleted += new EventHandler(ChartDataProvider_UpdateCompleted);

        }



        private void LoadSettings()
        {
            try
            {
                this.charRegistros.ChartElement.LegendPosition = LegendPosition.Right;
                this.charRegistros.ChartElement.LegendElement.Alignment = ContentAlignment.TopCenter;
                this.checkBoxDelayUpdates.Checked = this.dgvRegistros.ChartDataProvider.DelayUpdate;
                this.checkBoxSelectionOnly.Checked = this.dgvRegistros.ChartDataProvider.SelectionOnly;
                this.checkBoxColumnSubTotals.Checked = this.dgvRegistros.ChartDataProvider.IncludeColumnSubTotals;
                this.checkBoxRowSubTotals.Checked = this.dgvRegistros.ChartDataProvider.IncludeRowSubTotals;
                this.checkBoxColumnGrandTotals.Checked = this.dgvRegistros.ChartDataProvider.IncludeColumnGrandTotals;
                this.checkBoxRowGrandTotals.Checked = this.dgvRegistros.ChartDataProvider.IncludeRowGrandTotals;

                if (this.dgvRegistros.ChartDataProvider.SeriesAxis == PivotAxis.Rows)
                {
                    this.radioRows.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                }
                else
                {
                    this.radioColumns.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                }

                if (this.dgvRegistros.ChartDataProvider.GeneratedSeriesType == GeneratedSeriesType.Bar)
                {
                    this.radioBarSeries.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                }
                else if (this.dgvRegistros.ChartDataProvider.GeneratedSeriesType == GeneratedSeriesType.Line)
                {
                    this.radioLineSeries.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                }

                else if (this.dgvRegistros.ChartDataProvider.GeneratedSeriesType == GeneratedSeriesType.Area)
                {
                    this.radioAreaSeries.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
                }


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void SetupAxes()
        {
            try
            {
                LinearAxis verticalAxis = new LinearAxis();
                verticalAxis.ShowLabels = true;
                verticalAxis.AxisType = AxisType.Second;
                CategoricalAxis horizontalAxis = new CategoricalAxis();
                horizontalAxis.LabelFitMode = AxisLabelFitMode.MultiLine;
                horizontalAxis.ShowLabels = true;
                this.charRegistros.Area.Axes.Add(horizontalAxis);
                this.charRegistros.Area.Axes.Add(verticalAxis);

                foreach (CartesianSeries seriesGrafico in this.charRegistros.Series)
                {
                    seriesGrafico.ShowLabels = true;
                }

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        void UpdateAxesPlotMode()
        {
            CategoricalAxis axis = this.charRegistros.Axes[0] as CategoricalAxis;
            if (axis != null)
            {
                if (this.dgvRegistros.ChartDataProvider.GeneratedSeriesType == GeneratedSeriesType.Bar)
                {
                    axis.PlotMode = Telerik.Charting.AxisPlotMode.BetweenTicks;
                    axis.ShowLabels = true;
                }
                else
                {
                    axis.PlotMode = Telerik.Charting.AxisPlotMode.OnTicksPadded;
                    axis.ShowLabels = true;
                }

                foreach (CartesianSeries seriesGrafico in this.charRegistros.Series)
                {
                    seriesGrafico.ShowLabels = true;
                }
            }
        }

        void UpdateSeriesCombineMode()
        {
            if (this.dgvRegistros.ChartDataProvider.GeneratedSeriesType != GeneratedSeriesType.Bar)
            {
                foreach (CartesianSeries series in this.charRegistros.Series)
                {
                    series.CombineMode = ChartSeriesCombineMode.Stack;
                    series.ShowLabels = true;
                }
            }

            foreach (CartesianSeries series in this.charRegistros.Series)
            {
                //series.CombineMode = ChartSeriesCombineMode.Stack;
                series.ShowLabels = true;
                series.VerticalAxis.LabelInterval = 10;
                series.HorizontalAxis.LabelInterval = 10;

            }
        }

        void radioSeries_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (this.radioBarSeries.IsChecked)
            {
                this.dgvRegistros.ChartDataProvider.GeneratedSeriesType = GeneratedSeriesType.Bar;

                foreach (CartesianSeries seriesGrafico in this.charRegistros.Series)
                {
                    seriesGrafico.ShowLabels = true;
                }


            }
            else if (this.radioAreaSeries.IsChecked)
            {
                this.dgvRegistros.ChartDataProvider.GeneratedSeriesType = GeneratedSeriesType.Area;
            }
            else if (this.radioLineSeries.IsChecked)
            {
                this.dgvRegistros.ChartDataProvider.GeneratedSeriesType = GeneratedSeriesType.Line;
            }
            UpdateAxesPlotMode();
        }

        void ChartDataProvider_UpdateCompleted(object sender, EventArgs e)
        {
            UpdateSeriesCombineMode();
        }

        void radioRows_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.dgvRegistros.ChartDataProvider.SeriesAxis = this.radioRows.IsChecked ? PivotAxis.Rows : PivotAxis.Columns;

            foreach (CartesianSeries seriesGrafico in this.charRegistros.Series)
            {
                seriesGrafico.ShowLabels = true;
            }

        }

        void checkBox_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (sender == this.checkBoxDelayUpdates)
            {
                this.dgvRegistros.ChartDataProvider.DelayUpdate = this.checkBoxDelayUpdates.Checked;
            }
            else if (sender == this.checkBoxSelectionOnly)
            {
                this.dgvRegistros.ChartDataProvider.SelectionOnly = this.checkBoxSelectionOnly.Checked;
            }
            else if (sender == this.checkBoxColumnSubTotals)
            {
                this.dgvRegistros.ChartDataProvider.IncludeColumnSubTotals = this.checkBoxColumnSubTotals.Checked;
            }
            else if (sender == this.checkBoxRowSubTotals)
            {
                this.dgvRegistros.ChartDataProvider.IncludeRowSubTotals = this.checkBoxRowSubTotals.Checked;
            }
            else if (sender == this.checkBoxColumnGrandTotals)
            {
                this.dgvRegistros.ChartDataProvider.IncludeColumnGrandTotals = this.checkBoxColumnGrandTotals.Checked;
            }
            else if (sender == this.checkBoxRowGrandTotals)
            {
                this.dgvRegistros.ChartDataProvider.IncludeRowGrandTotals = this.checkBoxRowGrandTotals.Checked;
            }
        }

        private void ReporteRefrigeriosPorAño_Load(object sender, EventArgs e)
        {
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            PivotGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.PivotGridLocalizationProviderEspanol();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            añoConsulta = Convert.ToInt32(this.txtPeriodo.Value);
            gbConsulta.Enabled = false;
            bgwHilo.RunWorkerAsync();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarConsulta();
        }

        private void EjecutarConsulta()
        {
            try
            {
                negocio = new SJM_PensionesNegocios();
                lista = new List<SJ_ReporteRefigeriosSubPlanilla>();
                lista = negocio.ListarAsistenciasPersonalPorSubPlanilla(añoConsulta).ToList();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarInformacion();
        }

        private void PresentarInformacion()
        {
            try
            {
                try
                {
                    if (lista != null && lista.ToList().Count > 0)
                    {
                        #region

                        this.dgvRegistros.DataSource = lista.ToList().ToDataTable<SJ_ReporteRefigeriosSubPlanilla>();
                        if (this.dgvRegistros.AggregateDescriptions.Count > 0) { }
                        else
                        {
                            this.dgvRegistros.AggregateDescriptions.Add(new PropertyAggregateDescription() { PropertyName = "nroAsistencias", CustomName = "nroAsistencias", AggregateFunction = AggregateFunctions.Sum });
                            this.charRegistros.DataSource = this.dgvRegistros;

                            //charRegistros.Series
                            //series.setShowLabels(true);
                            //axis.setShowLabels(false);


                            PivotGroupNode firstNode = this.dgvRegistros.PivotGridElement.ColumnRootGroup.Children[0];
                            this.dgvRegistros.PivotGridElement.SelectColumn(firstNode);
                            //this.dgvRegistros.ChartDataProvider.ChartView.ShowSmartLabels = true;    
                            this.dgvRegistros.Refresh();


                            foreach (var series in charRegistros.Series)
                            {
                                series.ShowLabels = true;
                            }

                        }
                        #endregion
                        gbConsulta.Enabled = true;
                    }
                    else
                    {
                        #region
                        this.lista = new List<SJ_ReporteRefigeriosSubPlanilla>();
                        this.dgvRegistros.DataSource = this.lista.ToDataTable<SJ_ReporteRefigeriosSubPlanilla>();

                        if (this.dgvRegistros.AggregateDescriptions.Count > 0)
                        {
                            this.dgvRegistros.AggregateDescriptions.RemoveAt(0);
                            gbConsulta.Enabled = true;

                        }
                        #endregion
                    }

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void SubTotalColumna()
        {
            if (chkSubTotalesColumna.Checked == true)
            {
                //subTotalVertical = true;
                if (lista != null && lista.ToList().Count > 0)
                {
                    dgvRegistros.ColumnsSubTotalsPosition = TotalsPos.First;
                }
            }
            else
            {
                //subTotalVertical = false;
                if (lista != null && lista.ToList().Count > 0)
                {
                    dgvRegistros.ColumnsSubTotalsPosition = TotalsPos.None;
                }
            }
        }

        private void TotalColumna()
        {
            if (chkTotalesColumna.Checked == true)
            {
                //subTotalVertical = true;
                if (lista != null && lista.ToList().Count > 0)
                {
                    dgvRegistros.ColumnGrandTotalsPosition = TotalsPos.First;
                }
            }
            else
            {
                //subTotalVertical = false;
                if (lista != null && lista.ToList().Count > 0)
                {
                    dgvRegistros.ColumnGrandTotalsPosition = TotalsPos.None;
                }
            }
        }

        private void SubTotalFila()
        {
            if (chkSubTotalesFila.Checked == true)
            {
                //subTotalHorizontal = true;
                if (lista != null && lista.ToList().Count > 0)
                {
                    dgvRegistros.RowsSubTotalsPosition = TotalsPos.First;
                }
            }
            else
            {
                //subTotalHorizontal = false;
                if (lista != null && lista.ToList().Count > 0)
                {
                    dgvRegistros.RowsSubTotalsPosition = TotalsPos.None;
                }
            }
        }

        private void TotalFila()
        {
            if (chkTotalesFila.Checked == true)
            {
                //subTotalHorizontal = true;
                if (lista != null && lista.ToList().Count > 0)
                {
                    dgvRegistros.RowGrandTotalsPosition = TotalsPos.First;
                }
            }
            else
            {
                //subTotalHorizontal = false;
                if (lista != null && lista.ToList().Count > 0)
                {
                    dgvRegistros.RowGrandTotalsPosition = TotalsPos.None;
                }
            }
        }

        private void chkSubTotalesColumna_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            SubTotalColumna();
        }

        private void chkSubTotalesFila_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            SubTotalFila();
        }

        private void chkTotalesColumna_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            TotalColumna();
        }

        private void chkTotalesFila_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            TotalFila();
        }

        private void checkBoxDelayUpdates_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }


    }
}
