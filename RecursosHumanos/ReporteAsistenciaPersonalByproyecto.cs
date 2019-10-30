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
    public partial class ReporteAsistenciaPersonalByproyecto : Form
    {
        private MesNegocios MesesNeg;
        private List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoAsistencia;
        private MovimientoDesarrolloLaboresPersonalCampoNegocio modeloLabores;
        private List<string> listaPlanillasInvolucradas;
        private string desde;
        private string hasta;
        private List<AsistenciaByProyectoDiaria> listadoAsistenciaResumenByPeriodoByHoras;
        private List<AsistenciaByProyectoDiaria> listadoAsistenciaResumenByPeriodoByPersonas;
        private AsistenciaByProyectoDiarioNegocios modelo;
        private GrupoNegocio oGrupoNegocios;
        private string fileName;
        private bool exportVisualSettings;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;

        public ReporteAsistenciaPersonalByproyecto()
        {
            InitializeComponent();
            CargarMeses();
            CargarVistaReporte();
            ObtenerFechasIniciales();

            RadGridLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();


        }

        private void ReporteAsistenciaPersonalByproyecto_Load(object sender, EventArgs e)
        {
            tabControl.Pages.Remove(tabDetalle);
            tabControl.Pages.Remove(tabGrafico);
            tabControl.Pages.Remove(tabAgrupado);
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
            items1.Add(new GridViewSummaryItem("chnombreDia", "Reg. {0:N0}; ", GridAggregateFunction.Count));
            items1.Add(new GridViewSummaryItem("chAreasVerdes", "{0:N0}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chCanaSanJuan", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chCanaTablazosHuacaBlanca", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chConstanciasFallecimiento", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chEvaluaciones", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chFertiRiego", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chLaboratorio", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chPalta", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chPlanta", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chSanidad", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chServiciosGenerales", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chTaller", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chUcupe", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chVigilancia", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chSinProyecto", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chtotal", "{0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chOtros", "{0:N2}; ", GridAggregateFunction.Sum));

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


            int numeroSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, System.Globalization.CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
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

        private void CargarVistaReporte()
        {
            oGrupoNegocios = new GrupoNegocio();
            cboVistaReporte.DisplayMember = "Descripcion";
            cboVistaReporte.ValueMember = "Codigo";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboVistaReporte.DataSource = oGrupoNegocios.ListarVistaByReporte().ToList();

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
                listadoAsistencia = new List<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                modeloLabores = new MovimientoDesarrolloLaboresPersonalCampoNegocio();
                modelo = new AsistenciaByProyectoDiarioNegocios();
                listadoAsistencia = modeloLabores.ObtenerListadoListadoAsistenaPersonalCampo("2014", desde, hasta, listaPlanillasInvolucradas).ToList();


                listadoAsistenciaResumenByPeriodoByHoras = new List<AsistenciaByProyectoDiaria>();
                listadoAsistenciaResumenByPeriodoByPersonas = new List<AsistenciaByProyectoDiaria>();
                //listadoAsistenciaResumenByPeriodo = modelo.ObtenerAsistenciaAgrupadaByProyectoByNroPersonas(listadoAsistencia).ToList();
                listadoAsistenciaResumenByPeriodoByHoras = modelo.ObtenerAsistenciaDetalleByProyectoByNroHorasAcumuladasTrabajadas(listadoAsistencia).ToList();
                listadoAsistenciaResumenByPeriodoByPersonas = modelo.ObtenerAsistenciaDetalleByProyectoByNroPersonas(listadoAsistencia).ToList();

            }
            catch (Exception Ex)
            {
                dgvResumen.Enabled = true;
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
                /*
                this.dgvDetalle.DataSource = listadoAsistencia.ToDataTable<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                this.dgvDetalle.Refresh();

                this.dgvAgrupado.DataSource = listadoAsistenciaAgrupado.ToDataTable<SJ_RHListarAsistenciaPersonalByPeriodoResult>();
                this.dgvAgrupado.Refresh();

                */

                if (cboVistaReporte.SelectedIndex >= 0)
                {
                    if (cboVistaReporte.SelectedValue.ToString().Trim() == "PER")
                    {
                        this.dgvResumen.FilterDescriptors.Clear();
                        this.dgvResumen.DataSource = listadoAsistenciaResumenByPeriodoByPersonas.ToDataTable<AsistenciaByProyectoDiaria>();
                        this.dgvResumen.Refresh();
                    }
                    else if (cboVistaReporte.SelectedValue.ToString().Trim() == "HOR")
                    {
                        this.dgvResumen.FilterDescriptors.Clear();
                        this.dgvResumen.DataSource = listadoAsistenciaResumenByPeriodoByHoras.ToDataTable<AsistenciaByProyectoDiaria>();
                        this.dgvResumen.Refresh();
                    }
                }

                //GenerarGraficoPresentacion(listadoAsistenciaResumenByPeriodo);
                this.dgvResumen.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                gbGrupo.Enabled = true;
            }
            catch (Exception Ex)
            {

                gbGrupo.Enabled = true;
                dgvResumen.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
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

        private void ReporteAsistenciaPersonalByproyecto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboVistaReporte_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboVistaReporte.SelectedIndex >= 0)
            {
                if (cboVistaReporte.SelectedValue.ToString().Trim() == "PER")
                {
                    if (listadoAsistenciaResumenByPeriodoByPersonas != null && listadoAsistenciaResumenByPeriodoByPersonas.ToList().Count > 0)
                    {
                        this.dgvResumen.FilterDescriptors.Clear();
                        this.dgvResumen.DataSource = listadoAsistenciaResumenByPeriodoByPersonas.ToDataTable<AsistenciaByProyectoDiaria>();
                        this.dgvResumen.Refresh();
                    }
                }
                else if (cboVistaReporte.SelectedValue.ToString().Trim() == "HOR")
                {
                    if (listadoAsistenciaResumenByPeriodoByHoras != null && listadoAsistenciaResumenByPeriodoByHoras.ToList().Count > 0)
                    {
                        this.dgvResumen.FilterDescriptors.Clear();
                        this.dgvResumen.DataSource = listadoAsistenciaResumenByPeriodoByHoras.ToDataTable<AsistenciaByProyectoDiaria>();
                        this.dgvResumen.Refresh();
                    }

                }
            }
        }

        private void btnExportarResumen_Click(object sender, EventArgs e)
        {
            Exportar(dgvResumen);
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

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboMes.SelectedIndex >= 0)
            {
                ObtenerFechasMes();
            }

        }

        private void btnExportarAgrupado_Click(object sender, EventArgs e)
        {
            Exportar(this.dgvAgrupado);
        }

        private void btnExportarListaDetalle_Click(object sender, EventArgs e)
        {
            Exportar(this.dgvDetalle);
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
                oSemana.año = Convert.ToInt32(this.txtAño.Value);
                oSemana.semana = Convert.ToInt32(this.txtSemana.Value);
                oSemanaConsulta = modeloSemana.ObtenerSemanaPorNroSemana(oSemana, DateTime.Now.Year.ToString());
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

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
