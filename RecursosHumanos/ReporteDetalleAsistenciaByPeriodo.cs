using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using System.Threading;
using CrystalDecisions.CrystalReports.Engine;
using RecursosHumanos.Negocios;
using RecursosHumanos.Negocios;
namespace RecursosHumanos
{
    public partial class ReporteDetalleAsistenciaByPeriodo : Form
    {
        private string oCodigoUnicoAccesoSistema;
        private string ocodigoUsuario;
        private string ocodigoTipoPlanilla;
        private string osemanaPlanilla;
        private UsuarioMovimientoIngresoSistemaNegocio usuarioMovimientoIngresoSistemaModelo;
        private MesNegocios MesesNeg;
        private UsuarioMovimientoIngresoSistema usuario;
        private string fechaDesde;
        private string fechaHasta;
        private AsistenciaNegocio modelo;
        private List<ext_ListadoAsistenciaSinceMovimientoPlanillaResult> listado;
        private string fileName;
        private bool exportVisualSettings;
        public ReporteDetalleAsistenciaByPeriodo()
        {
            InitializeComponent();
        }



        public ReporteDetalleAsistenciaByPeriodo(string codigoUnicoAccesoSistema, string codigoUsuario, string codigoTipoPlanilla, string semanaPlanilla)
        {
            InitializeComponent();
            this.oCodigoUnicoAccesoSistema = codigoUnicoAccesoSistema;
            this.ocodigoUsuario = codigoUsuario;
            this.ocodigoTipoPlanilla = codigoTipoPlanilla;
            this.osemanaPlanilla = semanaPlanilla;

            usuarioMovimientoIngresoSistemaModelo = new UsuarioMovimientoIngresoSistemaNegocio();
            usuario = new UsuarioMovimientoIngresoSistema();
            usuario.codigoAcceso = codigoUnicoAccesoSistema;
            usuario = usuarioMovimientoIngresoSistemaModelo.ObtenerMovimientoIngresoSistemaByCodigoMovimiento(usuario);
            Program.ClaseCompartida.periodoElegido = usuario.periodoElegido != null ? usuario.periodoElegido : string.Empty;
            Program.ClaseCompartida.codigoTipoPlanilla = usuario.codigoPlanillaElegida != null ? usuario.codigoPlanillaElegida : string.Empty;
            Program.ClaseCompartida.semanaPlanilla = usuario.semanaPlanillaElegida != null ? usuario.semanaPlanillaElegida : string.Empty;
            RadGridLocalizationProvider.CurrentProvider = new ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();
        }

        public void Inicio()
        {
            try
            {
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + Program.ClaseCompartida.periodoElegido.Substring(0, 4)].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EXOTIC'S PRODUCER PACKERS";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
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


        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboMes.SelectedIndex >= 0)
            {
                ObtenerFechasMes();
            }
        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            modelo = new AsistenciaNegocio();
            listado = new List<ext_ListadoAsistenciaSinceMovimientoPlanillaResult>();
            listado = modelo.ObtenerDetalleAsistenciaByPeriodo(Program.ClaseCompartida.periodoElegido, fechaDesde, fechaHasta).ToList();
        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvRegistros.DataSource = listado.ToDataTable<ext_ListadoAsistenciaSinceMovimientoPlanillaResult>();
            dgvRegistros.Refresh();
            gbConsulta.Enabled = !false;
            dgvRegistros.Enabled = !false;
            ProgressBarF.Visible = !true;
        }

        private void ReporteDetalleAsistenciaByPeriodo_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            fechaDesde = this.txtFechaDesde.Text;
            fechaHasta = this.txtFechaHasta.Text;

            if (fechaDesde != string.Empty && fechaHasta != string.Empty)
            {
                gbConsulta.Enabled = false;
                dgvRegistros.Enabled = false;
                ProgressBarF.Visible = true;
                bwgHilo.RunWorkerAsync();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void ExportarExcel()
        {
            if (dgvRegistros != null)
            {
                if (dgvRegistros.Rows.Count > 0)
                {
                    Exportar(this.dgvRegistros);
                }
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
            excelExporter.SheetName = "Rpt Sistema";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
            excelExporter.HiddenColumnOption = HiddenOption.DoNotExport; /* no mostrar columnas ocultas*/
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



    }
}
