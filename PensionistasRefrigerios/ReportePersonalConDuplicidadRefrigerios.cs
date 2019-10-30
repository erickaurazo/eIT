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
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ReportePersonalConDuplicidadRefrigerios : Form
    {
        private Mes MesesNeg;
        private string desde;
        private string hasta;
        private SJM_PensionesNegocios modelo;
        private List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult> listado;
        private List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ListaAsistenciasPersonalPendientesMovimientoAsistencia;
        private List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult> ObtenerListaResumen;
        private List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult> ObtenerListaDetalle;
        private string nombreArchivo;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;

        public ReportePersonalConDuplicidadRefrigerios()
        {
            try
            {
                InitializeComponent();
                RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
                RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
                RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
                RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
                CargarMeses();
                ObtenerFechasIniciales();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "\nCargar Formulario de inicio", "ADVERTENCIA DEL SISTEMA");
            }
        }

        private void ObtenerFechasIniciales()
        {
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);

            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);

            modeloSemana = new SJ_SemanaNegocio();
            oSemana = new SJ_Semana();
            oSemanaConsulta = new SJ_Semana();
            oSemana.año = Convert.ToInt32(this.txtAño.Value);
            oSemana.semana = Convert.ToInt32(this.txtSemana.Value);

            oSemanaConsulta = modeloSemana.ObtenerSemanaPorNroSemana(oSemana);


            int numeroSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
            txtSemana.Value = numeroSemana;


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

            MesesNeg = new Mes();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = MesesNeg.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarConsulta();
        }

        private void EjecutarConsulta()
        {
            try
            {
                modelo = new SJM_PensionesNegocios();
                listado = new List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult>();
                listado = modelo.ListarPersonasConDuplicidadEnRefrigeriosPorDia(desde, hasta).ToList();


                modelo = new SJM_PensionesNegocios();
                ListaAsistenciasPersonalPendientesMovimientoAsistencia = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                ListaAsistenciasPersonalPendientesMovimientoAsistencia = modelo.ObtenerListaAsistenciasPersonalPendientesMovimientoAsistencia("2014", desde, hasta, "").Where(x => x.estado == 1).ToList();

                ObtenerListaResumen = new List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult>();
                ObtenerListaDetalle = new List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult>();
                ObtenerListaResumen = modelo.ListarPersonasConDuplicidadEnRefrigerioResumen(listado, ListaAsistenciasPersonalPendientesMovimientoAsistencia).ToList();
                //ObtenerListaDetalle = modelo.ListarPersonasConDuplicidadEnRefrigerioDetalle(listado, ListaAsistenciasPersonalPendientesMovimientoAsistencia).ToList();


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "\nEjecutar consulta", "ADVERTENCIA DEL SISTEMA");
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

                dgvRegistros.DataSource = ObtenerListaResumen.ToDataTable<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult>();
                dgvRegistros.Refresh();

                ProgressBar.Visible = false;
                gbConsulta.Enabled = true;
                gbDetalle.Enabled = true;

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "\nPresentar reporte", "ADVERTENCIA DEL SISTEMA");
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            try
            {
                desde = this.txtFechaDesde.Text.ToString().Trim();
                hasta = this.txtFechaHasta.Text.ToString().Trim();
                ProgressBar.Visible = true;
                gbConsulta.Enabled = false;
                gbDetalle.Enabled = false;
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "\nConsultar reporte", "ADVERTENCIA DEL SISTEMA");
            }
        }

        private void ReportePersonalConDuplicidadRefrigerios_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {

            this.dgvRegistros.TableElement.BeginUpdate();

            this.LoadFreightSummary();
            this.dgvRegistros.TableElement.EndUpdate();
            base.OnLoad(e);
        }


        private void LoadFreightSummary()
        {
            this.dgvRegistros.MasterTemplate.AutoExpandGroups = true;
            this.dgvRegistros.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistros.GroupDescriptors.Clear();
            this.dgvRegistros.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chrefrigerio", "N° Reg: {0:N0}; ", GridAggregateFunction.Count));
            item.Add(new GridViewSummaryItem("chimporteRefrigerio", "Sum: {0:N2}; ", GridAggregateFunction.Sum));
            //this.dgvPersonal.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvRegistros.MasterTemplate.SummaryRowsTop.Add(item);

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                Exportar(this.dgvRegistros);
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
            excelExporter.SheetName = "Refrigerios Duplicados";
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



        public bool exportVisualSettings { get; set; }

        private void txtSemana_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasSemanalesByNumeroSemana();
        }
    }
}
