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
using Telerik.WinControls.UI.Localization;

namespace RecursosHumanos
{
    public partial class ReportAsistenciaPersonalASJBySistemasVarios : Form
    {
        private string fechaDesde;
        private string fechaHasta;
        private string idcodigoGeneral;
        private List<RPT_ASISTENCIASResult> listado;
        private RegistroAsistenciaASJNegocio negocio;
        private List<RPT_ASISTENCIASResult> listadoAgrupado;
        private string fileName;

        public ReportAsistenciaPersonalASJBySistemasVarios()
        {
            InitializeComponent();
            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();
            RadGridLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
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

            items.Add(new GridViewSummaryItem("chNombres", "Registros : {0:N0}; ", GridAggregateFunction.Count));
            items.Add(new GridViewSummaryItem("chControlAsistencia", "Sum : {0:N0}; ", GridAggregateFunction.Sum));
            items.Add(new GridViewSummaryItem("chControlTareo", "Sum : {0:N0}; ", GridAggregateFunction.Sum));
            items.Add(new GridViewSummaryItem("chNisira", "Sum : {0:N0}; ", GridAggregateFunction.Sum));
            items.Add(new GridViewSummaryItem("chTotalMarcaciones", "Sum : {0:N0}; ", GridAggregateFunction.Sum));
            this.dgvResultado.MasterTemplate.SummaryRowsTop.Add(items);

        }

        private void ObtenerFechasIniciales()
        {
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);
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

        public void Inicio()
        {
            try
            {
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + DateTime.Now.Year.ToString()].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "EAURAZO";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }


        /* ejecuta en 2do plano */
        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            listado = new List<RPT_ASISTENCIASResult>();
            listadoAgrupado = new List<RPT_ASISTENCIASResult>();
            negocio = new RegistroAsistenciaASJNegocio();
            listado = negocio.ObtenerListadoPersonalByPeriodo(fechaDesde, fechaHasta, idcodigoGeneral).ToList();

            listadoAgrupado = negocio.AgruparListadoPersonalByPeriodoByPersonal(listado).ToList();

        }

        /* ahora que quieres que haga con el resultado*/
        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvResultado.DataSource = listadoAgrupado.ToDataTable<RPT_ASISTENCIASResult>();
            dgvResultado.Refresh();
            gbDatosConsulta.Enabled = true;
            gbResultado.Enabled = true;
            ProgressBar.Visible = !true;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                gbDatosConsulta.Enabled = !true;
                gbResultado.Enabled = !true;
                ProgressBar.Visible = true;


                fechaDesde = Convert.ToDateTime(this.txtFechaDesde.Text).ToString("yyyyMMdd");
                fechaHasta = Convert.ToDateTime(this.txtFechaHasta.Text).ToString("yyyyMMdd");
                idcodigoGeneral = string.Empty;

                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE ERROR");
                return;
            }




        }

        private void ReportAsistenciaPersonalASJBySistemasVarios_Load(object sender, EventArgs e)
        {

        }

        public MesNegocios MesesNeg { get; set; }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboMes.SelectedIndex >= 0)
            {
                ObtenerFechasMes();
            }
        }

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {

            ObtenerFechasMes();

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvResultado.Rows.Count > 0)
            {
                Exportar(dgvResultado);
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
            excelExporter.SheetName = "Asistencias";
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





        public bool exportVisualSettings { get; set; }

        private void ReportAsistenciaPersonalASJBySistemasVarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {

                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Close();
            }
        }
    }
}
