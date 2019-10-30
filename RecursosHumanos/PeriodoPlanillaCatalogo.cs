using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using RecursosHumanos.Negocios;
using System.Configuration;
using DevSoftSolutionsControls;
using DevSoftSolutionsDataAccess;
using DevSoftSolutionsExtensions;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using System.Collections;
using MyControlsDataBinding.Controles;
namespace RecursosHumanos
{
    public partial class PeriodoPlanillaCatalogo : Form
    {
        private string codigoUnicoAccesoSistema;
        private string codigoUsuario;
        private string fileName;
        private bool exportVisualSettings;
        private PeriodoPlanillaNegocio modelo;
        private List<ext_ListarPeriodoPlanillaResult> listadoPeriodoPlanilla;
        private List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaResult> listadoLimpiarGrillaSemana;
        private List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaResult> listadoDetalleSemana;

        public PeriodoPlanillaCatalogo()
        {
            InitializeComponent();
        }

        public PeriodoPlanillaCatalogo(string CodigoUnicoAccesoSistema, string codigoUsuario)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.codigoUnicoAccesoSistema = CodigoUnicoAccesoSistema;
            this.codigoUsuario = codigoUsuario;
            gbRegistros.Enabled = false;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
        }

        private void Semanas_Load(object sender, EventArgs e)
        {

        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            modelo = new PeriodoPlanillaNegocio();
            listadoPeriodoPlanilla = new List<ext_ListarPeriodoPlanillaResult>();
            listadoPeriodoPlanilla = modelo.ListarPeridosPlanilla(Program.ClaseCompartida.periodoElegido);

        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            dgvRegistros.DataSource = listadoPeriodoPlanilla.ToDataTable<ext_ListarPeriodoPlanillaResult>();
            dgvRegistros.Refresh();
            gbRegistros.Enabled = !false;
            ProgressBar.Visible = !true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            gbRegistros.Enabled = false;
            ProgressBar.Visible = true;
            bwgHilo.RunWorkerAsync();
        }

        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControl();
            if (dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                if (dgvRegistros.CurrentRow != null)
                {
                    if (dgvRegistros.CurrentRow.Cells["chcodigoPlanilla"].Value != null && dgvRegistros.CurrentRow.Cells["chcodigoPlanilla"].Value.ToString().Trim() != string.Empty)
                    {
                        /*Ejecuta consulta y muestra en la grilla y ademas llena los controles.*/
                        string codigoPlanilla = dgvRegistros.CurrentRow.Cells["chcodigoPlanilla"].Value != null ? dgvRegistros.CurrentRow.Cells["chcodigoPlanilla"].Value.ToString().Trim() : string.Empty;
                        string anio = dgvRegistros.CurrentRow.Cells["chAnio"].Value != null ? dgvRegistros.CurrentRow.Cells["chAnio"].Value.ToString().Trim() : string.Empty;
                        listadoDetalleSemana = new List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaResult>();
                        modelo = new PeriodoPlanillaNegocio();
                        listadoDetalleSemana = modelo.ListarSemanaByCodigoPlanillaByPerido(Program.ClaseCompartida.periodoElegido, codigoPlanilla, anio);
                        dgvSemana.DataSource = listadoDetalleSemana.ToDataTable<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaResult>();
                        dgvSemana.Refresh();

                        this.txtAnio.Text = dgvRegistros.CurrentRow.Cells["chAnio"].Value != null ? dgvRegistros.CurrentRow.Cells["chAnio"].Value.ToString().Trim() : string.Empty;
                        this.txtCodigoPlanilla.Text = dgvRegistros.CurrentRow.Cells["chcodigoPlanilla"].Value != null ? dgvRegistros.CurrentRow.Cells["chcodigoPlanilla"].Value.ToString().Trim() : string.Empty;
                        this.txtPlanillaDescripcion.Text = dgvRegistros.CurrentRow.Cells["chPlanilla"].Value != null ? dgvRegistros.CurrentRow.Cells["chPlanilla"].Value.ToString().Trim() : string.Empty;
                        
                    }
                }
            }
        }

        private void LimpiarControl()
        {
            this.txtAnio.Clear();
            this.txtCodigoPlanilla.Clear();
            this.txtPlanillaDescripcion.Clear();
            listadoLimpiarGrillaSemana = new List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaResult>();
            dgvSemana.DataSource = listadoLimpiarGrillaSemana.ToDataTable<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaResult>();
            dgvSemana.Refresh();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            try
            {

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PeriodoPlanillaEdicion ofrm = new PeriodoPlanillaEdicion(this.codigoUnicoAccesoSistema, this.codigoUsuario);
            ofrm.Show();
        }
    }
}
