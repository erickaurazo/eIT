using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Transportista.Negocios;
using Transportista;
using Telerik.WinControls.UI.Localization;
using System.Configuration;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ReporteAsistenciaPersonalLaboresCampoxRendimiento : Form
    {

        private Mes MesesNeg;
        private string fechaDesde;
        private string fechaHasta;
        private string fileName;
        private bool exportVisualSettings;
        private List<IndicadorAsistencia> ListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidor;
        private RefrigeriosPensionesNegocios Modelo;
        private string idPlanilla;
        private string periodoDesde;
        private string periodoHasta;
        private string codigoGeneral;
        private string periodoConsulta;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;



        public ReporteAsistenciaPersonalLaboresCampoxRendimiento()
        {
            InitializeComponent();
            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();
        }

        public ReporteAsistenciaPersonalLaboresCampoxRendimiento(string fechaDesde, string fechaHasta, string codigoGeneral)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            Inicio();
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.codigoGeneral = codigoGeneral;
            CargarMeses();
            ObtenerFechasIniciales();
            this.txtCodigoPersonal.Text = this.codigoGeneral;
            this.txtFechaDesde.Text = fechaDesde;
            this.txtFechaHasta.Text = fechaHasta;
            Consultar();
        }

        private void ReporteAsistenciaPersonalLaboresCampoxRendimiento_Load(object sender, EventArgs e)
        {

        }

        public void Inicio()
        {
            try
            {
                #region

                periodoConsulta = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodoConsulta].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
                #endregion
            }
            catch (Exception Ex)
            {
                throw Ex;
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

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarConsulta();
        }

        private void EjecutarConsulta()
        {
            try
            {
                #region Ejecutar Consulta()

                ListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidor = new List<IndicadorAsistencia>();
                Modelo = new RefrigeriosPensionesNegocios();
                ListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidor = Modelo.ObtenerListaAsistenciaPersonalGeneraByRendimiento(periodoDesde, idPlanilla, fechaDesde, fechaHasta, periodoHasta, "001", codigoGeneral).ToList();
                #endregion
            }
            catch (Exception Ex)
            {

                throw Ex;
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
                #region Presentar Datos()

                dgvListadoAsistencia.DataSource = ListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidor.ToDataTable<IndicadorAsistencia>();
                dgvListadoAsistencia.Refresh();

                ProgressBar.Visible = false;
                gbConsulta.Enabled = true;
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            try
            {
                codigoGeneral = this.txtCodigoPersonal.Text.ToString().Trim();
                fechaDesde = this.txtFechaDesde.Text;
                fechaHasta = this.txtFechaHasta.Text;
                periodoDesde = Convert.ToDateTime(this.txtFechaDesde.Text).Year.ToString() + Convert.ToDateTime(this.txtFechaDesde.Text).Month.ToString().PadLeft(2, '0');
                periodoHasta = Convert.ToDateTime(this.txtFechaHasta.Text).Year.ToString() + Convert.ToDateTime(this.txtFechaHasta.Text).Month.ToString().PadLeft(2, '0');
                idPlanilla = "PAS";
                ProgressBar.Visible = true;
                gbConsulta.Enabled = false;
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void Exportar()
        {
            if (dgvListadoAsistencia != null && dgvListadoAsistencia.Rows.Count > 0)
            {
                Exportar(dgvListadoAsistencia);
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
            excelExporter.SheetName = "Lista Asistencia";
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

        private void txtSemana_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
