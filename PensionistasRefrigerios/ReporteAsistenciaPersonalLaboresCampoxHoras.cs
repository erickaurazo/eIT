using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Transportista.Negocios;
using System.Configuration;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ReporteAsistenciaPersonalLaboresCampoxHoras : Form
    {

        private Mes MesesNeg;
        private string fechaDesde = string.Empty;
        private string fechaHasta = string.Empty;
        private string fileName = string.Empty;
        private bool exportVisualSettings = false;
        private List<IndicadorAsistencia> ListaAsistenciaPersonalGeneralByPlanillaRRHH;
        private List<IndicadorAsistencia> ListaAsistenciaPersonalGeneralByPlanillaMNovilesVid;
        private RefrigeriosPensionesNegocios Modelo;
        private string idPlanilla = string.Empty;
        private string codigoGeneral = string.Empty;
        private string periodoConsulta = string.Empty;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        private int esConsultaPlanillaRRHH = 0;
        private int esConsultaPlanillaMovilesVID = 0;



        public ReporteAsistenciaPersonalLaboresCampoxHoras()
        {
            InitializeComponent();
            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();
        }

        public ReporteAsistenciaPersonalLaboresCampoxHoras(string fechaDesde, string fechaHasta, string codigoGeneral)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.codigoGeneral = codigoGeneral;
            this.txtFechaDesde.Text = fechaDesde;
            this.txtFechaHasta.Text = fechaHasta;
            this.txtCodigoPersonal.Text = codigoGeneral;
            Consultar();
        }


        public void Inicio()
        {
            try
            {
                #region

                periodoConsulta = DateTime.Now.Year.ToString();
                Globales.Servidor = ConfigurationManager.AppSettings["Servidor"];
                Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"];
                Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodoConsulta];
                Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"];
                Globales.IdEmpresa = "001";
                Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                Globales.UsuarioSistema = "ERICK";
                Globales.NombreUsuarioSistema = "Erick Aurazo";
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.Trim(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ObtenerFechasIniciales()
        {
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);
            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();


            modeloSemana = new SJ_SemanaNegocio();
            oSemana = new SJ_Semana();
            oSemanaConsulta = new SJ_Semana();
            oSemana.año = Convert.ToInt32(this.txtAño.Value);
            oSemana.semana = Convert.ToInt32(this.txtSemana.Value);

            oSemanaConsulta = modeloSemana.ObtenerSemanaPorNroSemana(oSemana);


            int numeroSemana = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
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
                    fecha1 = Convert.ToDateTime("01/" + (string.Format("{0}/{1}", cboMes.SelectedValue, this.txtAño.Value)));// 
                    fecha2 = Convert.ToDateTime(string.Format("31/{0}/{1}", cboMes.SelectedValue, this.txtAño.Value));// 
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
                        fecha2 = Convert.ToDateTime(string.Format("01/{0}/{1}", Convert.ToInt32(cboMes.SelectedValue) + 1, this.txtAño.Value)).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime(string.Format("01/{0}/{1}", cboMes.SelectedValue, this.txtAño.Value));// 
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
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtAño.Value);// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtAño.Value);//
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
                ListaAsistenciaPersonalGeneralByPlanillaRRHH = new List<IndicadorAsistencia>();
                ListaAsistenciaPersonalGeneralByPlanillaMNovilesVid = new List<IndicadorAsistencia>();

                if (esConsultaPlanillaRRHH == 1)
                {                    
                    Modelo = new RefrigeriosPensionesNegocios();
                    ListaAsistenciaPersonalGeneralByPlanillaRRHH = Modelo.ObtenerListaAsistenciaPersonalGeneralByHoras(fechaDesde, fechaHasta, idPlanilla, codigoGeneral).ToList();
                }

                if (esConsultaPlanillaMovilesVID == 1)
                {
                    Modelo = new RefrigeriosPensionesNegocios();
                    ListaAsistenciaPersonalGeneralByPlanillaMNovilesVid = Modelo.ObtenerListaAsistenciaPersonalGeneralByHorasByPlanillaMovilesVID(fechaDesde, fechaHasta, idPlanilla, codigoGeneral).ToList();
                }
                
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.Trim(), "MENSAJE DEL SISTEMA");
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
                #region Presentar Datos()

                dgvListadoAsistencia.DataSource = ListaAsistenciaPersonalGeneralByPlanillaRRHH.ToDataTable<IndicadorAsistencia>();
                dgvListadoAsistencia.Refresh();

                ProgressBar.Visible = false;
                gbConsulta.Enabled = true;
                gbListadoAsistencias.Enabled = true;
                #endregion
            }
            catch (Exception Ex)
            {
                gbConsulta.Enabled = true;
                gbListadoAsistencias.Enabled = true;
                MessageBox.Show(Ex.Message.Trim(), "MENSAJE DE TEXTO");
                return;
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

                if (chkRRHH.Checked == false && chkMovilesVid.Checked == false)
                {           
         
                }
                else
                {
                    esConsultaPlanillaRRHH = chkRRHH.Checked == true ? 1 : 0;
                    esConsultaPlanillaMovilesVID = chkMovilesVid.Checked == true ? 1 : 0;
                    gbConsulta.Enabled = false;
                    gbListadoAsistencias.Enabled = false;
                    fechaDesde = this.txtFechaDesde.Text;
                    fechaHasta = this.txtFechaHasta.Text;
                    codigoGeneral = this.txtCodigoPersonal.Text.Trim();
                    idPlanilla = "PAS";
                    ProgressBar.Visible = true;
                    gbConsulta.Enabled = false;
                    bgwHilo.RunWorkerAsync();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.Trim(), "MENSAJE DE TEXTO");
                return;
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
            ExportToExcelML excelExporter = new ExportToExcelML(grilla) { SheetName = "Lista Asistencia", SummariesExportOption = SummariesOption.ExportAll, SheetMaxRows = ExcelMaxRows._1048576, ExportVisualSettings = this.exportVisualSettings, HiddenColumnOption = HiddenOption.DoNotExport };


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
                oSemanaConsulta = modeloSemana.ObtenerSemanaPorNroSemana(oSemana);
                this.txtFechaDesde.Text = oSemanaConsulta.desde.Value.ToPresentationDate();
                this.txtFechaHasta.Text = oSemanaConsulta.hasta.Value.ToPresentationDate();

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ReporteAsistenciaPersonalLaboresCampoxHoras_Load(object sender, EventArgs e)
        {

        }




    }
}
