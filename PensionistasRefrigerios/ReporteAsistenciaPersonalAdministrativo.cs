using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
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
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.ViewModels;
using Telerik.Pivot.Core.Aggregates;

using System.IO;
using System.Data.OleDb;
using System.Globalization;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;


namespace Transportista
{
    public partial class ReporteAsistenciaPersonalAdministrativo : Form
    {
        private string[] peopleList;
        private List<PersonalAdministrativo> listadoPersonal;
        private List<PersonalAdministrativo> listadoAsistencia;
        private string desde;
        private string hasta;
        private List<PersonalAdministrativo> ListadoObj;
        private PersonalAdministrativo objPersonalAdministrativo;
        private string fileName;
        private bool exportVisualSettings;
        private List<oFechaAsistencia> listaFechaAsistencia;
        private Telerik.WinControls.UI.Export.PivotExportToExcelML exporter;
        private bool subTotalVertical = false;
        private bool subTotalHorizontal = false;
        private List<PersonalAdministrativo> listadoConsolidadMensualAsistencia;
        private PersonalAdministrativo consolidadMensualAsistencia;
        private string areaTrabajo;
        private int esAdministracion;
        private int esUva;
        private int esPlanta;
        private int esTaller;
        private AsistenciaTrabajadoresAdministrativoNegocio Modelo;
        private List<PersonalAdministrativo> ListaMarcacionesTrabajadoresxDia;
        private List<PersonalAdministrativo> ListaMarcacionesTrabajadoresxMes;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;


        public ReporteAsistenciaPersonalAdministrativo()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            PivotGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.PivotGridLocalizationProviderEspanol();
            CargarMeses();
            ObtenerFechasIniciales();


            this.exporter = new Telerik.WinControls.UI.Export.PivotExportToExcelML(this.dgvGrillaPrivot);
            this.exporter.PivotExcelCellFormatting += new Telerik.WinControls.UI.Export.PivotExcelCellFormattingEvent(exporter_PivotExcelCellFormatting);
        }

        private void CargarMeses()
        {
            Mes Meses = new Mes();

            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = Meses.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = Meses.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void ObtenerFechasIniciales()
        {
            this.txtPeriodo.Text = DateTime.Now.Year.ToString();
            this.txtFechaDesde.Text = DateTime.Now.ToShortDateString();
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();

            int numeroSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
            txtSemana.Value = numeroSemana;
            ObtenerFechasSemanalesByNumeroSemana();

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
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtPeriodo.Text.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Text.ToString());// 
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
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtPeriodo.Text.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Text.ToString());// 
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
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtPeriodo.Text.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtPeriodo.Text.ToString());//
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                ComprobarAreasParaResultado();
                desde = this.txtFechaDesde.Text.ToString();
                hasta = this.txtFechaHasta.Text.ToString();
                btnConsultar.Enabled = false;
                gbConsulta.Enabled = false;
                progressBar.Visible = true;
                this.menuPrincipal.Enabled = false;
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void PresentarAsistencias()
        {
            try
            {
                #region Presentar Datos()
                dgvAsistencias.DataSource = ListaMarcacionesTrabajadoresxDia.OrderBy(x => x.personal).ToList().ToDataTable<PersonalAdministrativo>();
                dgvAsistencias.Refresh();

                if (ListaMarcacionesTrabajadoresxMes != null && ListaMarcacionesTrabajadoresxMes.ToList().Count > 0)
                {
                    dgvGrillaPrivot.DataSource = ListaMarcacionesTrabajadoresxMes.ToDataTable<PersonalAdministrativo>();
                    if (dgvGrillaPrivot.AggregateDescriptions.Count > 0)
                    {
                    }
                    else
                    {
                        //this.dgvGrillaPrivot.AggregateDescriptions.Add(new PropertyAggregateDescription() { PropertyName = "Asistio", AggregateFunction = AggregateFunctions.Sum });
                        this.dgvGrillaPrivot.AggregateDescriptions.Add(new PropertyAggregateDescription() { PropertyName = "HorasTrabajadas", AggregateFunction = AggregateFunctions.Sum });
                    }
                    dgvGrillaPrivot.Refresh();
                    ObtenerValorChecksubTotalVertical();
                    ObtenerValorChecksubTotalHorizontal();
                    ObtenerValorCheckTotalVertical();
                    ObtenerValorCheckTotalHorizontal();
                }
                else
                {
                    ListaMarcacionesTrabajadoresxMes = new List<PersonalAdministrativo>();
                    dgvGrillaPrivot.DataSource = ListaMarcacionesTrabajadoresxMes.ToDataTable<PersonalAdministrativo>();
                    if (dgvGrillaPrivot.AggregateDescriptions.Count > 0)
                    {
                        this.dgvGrillaPrivot.AggregateDescriptions.RemoveAt(0);
                    }
                    ObtenerValorChecksubTotalVertical();
                    ObtenerValorChecksubTotalHorizontal();
                    ObtenerValorCheckTotalVertical();
                    ObtenerValorCheckTotalHorizontal();
                    dgvGrillaPrivot.Refresh();
                }
                #endregion
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void AsistenciaPersonalAdministrativo_Load(object sender, EventArgs e)
        {

        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvAsistencias != null && dgvAsistencias.Rows.Count > 0)
            {
                Exportar(dgvAsistencias);
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
            excelExporter.SheetName = "Asistencia Pers.";
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

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                #region Ejecutar Consulta()
                Modelo = new AsistenciaTrabajadoresAdministrativoNegocio();
                ListaMarcacionesTrabajadoresxDia = new List<PersonalAdministrativo>();
                ListaMarcacionesTrabajadoresxDia = Modelo.ObtenerListaMarcacionesTrabajadoresxDia(desde, hasta, esAdministracion, esUva, esTaller, esPlanta).ToList();

                if (ListaMarcacionesTrabajadoresxDia != null && ListaMarcacionesTrabajadoresxDia.ToList().Count > 0)
                {
                    ListaMarcacionesTrabajadoresxMes = new List<PersonalAdministrativo>();
                    ListaMarcacionesTrabajadoresxMes = Modelo.ObtenerListaMarcacionesTrabajadoresxMes(ListaMarcacionesTrabajadoresxDia).ToList();
                }
                else
                {
                    ListaMarcacionesTrabajadoresxMes = new List<PersonalAdministrativo>();
                    //ListaMarcacionesTrabajadoresxMes = Modelo.ObtenerListaMarcacionesTrabajadoresxMes(ListaMarcacionesTrabajadoresxDia).ToList();
                }


                //ObtenerListaPersonal();
                //ObtenerListaMarcaciones();
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString());
                return;
            }

        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarAsistencias();
            btnConsultar.Enabled = true;
            gbConsulta.Enabled = true;
            progressBar.Visible = false;
            this.menuPrincipal.Enabled = true;
        }

        void exporter_PivotExcelCellFormatting(object sender, Telerik.WinControls.UI.Export.ExcelPivotCellExportingEventArgs e)
        {
            this.progressBar.Maximum = e.RowsCount + 1;
            if (this.progressBar.Value < this.progressBar.Maximum)
            {
                this.progressBar.Value++;
            }

            //decimal value = 0;
            //if (decimal.TryParse(e.Cell.Text, out value))
            //{
            //    if (value > 1000)
            //        e.Cell.BackColor = System.Drawing.Color.Red;
            //    if (value < 100)
            //        e.Cell.BackColor = System.Drawing.Color.Green;
            //}

            Application.DoEvents();
        }

        private void btnExportarReporteAgrupadoxMes_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel ML|*.xls";
            saveFileDialog1.Title = "Exportar archivo de xlsx a :"; saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                this.exporter.RunExport(saveFileDialog1.FileName);
                MessageBox.Show("La exportacion fue realizada correctamente " + saveFileDialog1.FileName, "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.progressBar.Value = 0;
                try
                {
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
                finally
                {
                }
            }
        }

        private void chkIncluirSubTotalesVertical_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ObtenerValorChecksubTotalVertical();
        }

        private void chkIncluirSubTotalesHorizontal_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ObtenerValorChecksubTotalHorizontal();
        }

        private void ObtenerValorChecksubTotalVertical()
        {
            if (chkIncluirSubTotalesVertical.Checked == true)
            {
                subTotalVertical = true;
                if (ListaMarcacionesTrabajadoresxDia != null && ListaMarcacionesTrabajadoresxDia.ToList().Count > 0)
                {
                    dgvGrillaPrivot.ColumnsSubTotalsPosition = TotalsPos.First;
                }
            }
            else
            {
                subTotalVertical = false;
                if (ListaMarcacionesTrabajadoresxDia != null && ListaMarcacionesTrabajadoresxDia.ToList().Count > 0)
                {
                    dgvGrillaPrivot.ColumnsSubTotalsPosition = TotalsPos.None;
                }
            }
        }

        private void ObtenerValorChecksubTotalHorizontal()
        {
            if (chkIncluirSubTotalesHorizontal.Checked == true)
            {
                subTotalHorizontal = true;
                if (ListaMarcacionesTrabajadoresxDia != null && ListaMarcacionesTrabajadoresxDia.ToList().Count > 0)
                {
                    dgvGrillaPrivot.RowsSubTotalsPosition = TotalsPos.First;
                }
            }
            else
            {
                subTotalHorizontal = false;
                if (ListaMarcacionesTrabajadoresxDia != null && ListaMarcacionesTrabajadoresxDia.ToList().Count > 0)
                {
                    dgvGrillaPrivot.RowsSubTotalsPosition = TotalsPos.None;
                }
            }
        }

        private void ObtenerValorCheckTotalVertical()
        {
            if (this.chkIncluirTotalesVerticales.Checked == true)
            {
                subTotalVertical = true;
                if (ListaMarcacionesTrabajadoresxDia != null && ListaMarcacionesTrabajadoresxDia.ToList().Count > 0)
                {
                    dgvGrillaPrivot.ColumnGrandTotalsPosition = TotalsPos.First;
                }
            }
            else
            {
                subTotalVertical = false;
                if (ListaMarcacionesTrabajadoresxDia != null && ListaMarcacionesTrabajadoresxDia.ToList().Count > 0)
                {
                    dgvGrillaPrivot.ColumnGrandTotalsPosition = TotalsPos.None;
                }
            }
        }

        private void ObtenerValorCheckTotalHorizontal()
        {
            if (chkIncluirTotalesHorizontales.Checked == true)
            {
                subTotalHorizontal = true;
                if (ListaMarcacionesTrabajadoresxDia != null && ListaMarcacionesTrabajadoresxDia.ToList().Count > 0)
                {
                    dgvGrillaPrivot.RowGrandTotalsPosition = TotalsPos.First;
                }
            }
            else
            {
                subTotalHorizontal = false;
                if (ListaMarcacionesTrabajadoresxDia != null && ListaMarcacionesTrabajadoresxDia.ToList().Count > 0)
                {
                    dgvGrillaPrivot.RowGrandTotalsPosition = TotalsPos.None;
                }
            }
        }

        private void chkIncluirTotalesHorizontales_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ObtenerValorCheckTotalHorizontal();
        }

        private void chkIncluirTotalesVerticales_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ObtenerValorCheckTotalVertical();
        }

        private void chkAdministracion_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAdministracion.Checked == true)
            {
                esAdministracion = 1;
            }
            else
            {
                esAdministracion = 0;
            }
        }

        private void chkUva_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

            if (chkUva.Checked == true)
            {
                esUva = 1;
            }
            else
            {
                esUva = 0;
            }
        }

        private void ComprobarAreasParaResultado()
        {
            if (chkUva.Checked == true)
            {
                esUva = 1;
            }
            else
            {
                esUva = 0;
            }

            if (chkPlanta.Checked == true)
            {
                esPlanta = 1;
            }
            else
            {
                esPlanta = 0;
            }

            if (chkTaller.Checked == true)
            {
                esTaller = 1;
            }
            else
            {
                esTaller = 0;
            }

            if (chkAdministracion.Checked == true)
            {
                esAdministracion = 1;
            }
            else
            {
                esAdministracion = 0;
            }
        }

        private void chkPlanta_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkPlanta.Checked == true)
            {
                esPlanta = 1;
            }
            else
            {
                esPlanta = 0;
            }
        }

        private void chkTaller_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void txtSemana_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasSemanalesByNumeroSemana();
        }

        private void ObtenerFechasSemanalesByNumeroSemana()
        {
            try
            {
                #region Asigar fechas por semana()
                modeloSemana = new SJ_SemanaNegocio();
                oSemana = new SJ_Semana();
                oSemanaConsulta = new SJ_Semana();
                oSemana.año = Convert.ToInt32(this.txtPeriodo.Value);
                oSemana.semana = Convert.ToInt32(this.txtSemana.Value);
                oSemanaConsulta = modeloSemana.ObtenerSemanaPorNroSemana(oSemana);
                this.txtFechaDesde.Text = oSemanaConsulta.desde.Value.ToPresentationDate();
                this.txtFechaHasta.Text = oSemanaConsulta.hasta.Value.ToPresentationDate();

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

    }
}
