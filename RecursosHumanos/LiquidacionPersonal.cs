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
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;


namespace RecursosHumanos
{
    public partial class LiquidacionPersonal : Telerik.WinControls.UI.RadForm
    {
        private MesNegocios MesesNeg;
        private string periodo;
        private string planilla;
        private PersonalLiquidado negocios;
        private List<SJ_RHPersonalLiquidadoResult> ListapersonalLiquidado;
        public LiquidacionPersonal()
        {
            InitializeComponent();
            CargarMeses();
            ObtenerFechasIniciales();
            CargarTipoPlanilla();
        }

        private void LiquidacionPersonal_Load(object sender, EventArgs e)
        {

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
            cboMes.DataSource = MesesNeg.ListarDoceMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            //cboMes.DataSource = MesesNeg.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void CargarTipoPlanilla()
        {

            planillaNeg = new PlanillaNegocios();
            this.cboPlanilla.DisplayMember = "Planilla";
            this.cboPlanilla.ValueMember = "idPlanilla";
            this.cboPlanilla.DataSource = planillaNeg.Listar(this.txtAño.Value.ToString());
            //cboMes.DataSource = MesesNeg.ListarMeses().ToList();
            cboPlanilla.SelectedValue = "PAM";
        }


        protected override void OnLoad(EventArgs e)
        {
            this.dgvPersonalLiquidado.TableElement.BeginUpdate();
            //this.dgvRecorridos.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvPersonalLiquidado.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvPersonalLiquidado.MasterTemplate.AutoExpandGroups = true;
            this.dgvPersonalLiquidado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonalLiquidado.GroupDescriptors.Clear();
        }

        public PlanillaNegocios planillaNeg { get; set; }

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ObtenerFechasMes();
            }
            catch (Exception Ex)
            {
                
                throw Ex;
            }
           
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                ObtenerFechasMes();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            negocios = new PersonalLiquidado();
            ListapersonalLiquidado = new List<SJ_RHPersonalLiquidadoResult>();
            ListapersonalLiquidado = negocios.Listar(periodo, planilla).ToList();

        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MostrarLista();
            ActivarControlBusquedad(true);

        }

        private void ActivarControlBusquedad(bool p)
        {
            progressBar.Enabled = !p;
            progressBar.Visible = !p;
            this.btnConsultar.Enabled = p;
            this.txtAño.Enabled = p;
            this.cboMes.Enabled = p;
            this.cboPlanilla.Enabled = p;
            this.txtFechaDesde.Enabled = !p;
            this.txtFechaHasta.Enabled = !p;
        }

        private void MostrarLista()
        {
            this.dgvPersonalLiquidado.DataSource = ListapersonalLiquidado.ToDataTable<SJ_RHPersonalLiquidadoResult>();
            this.dgvPersonalLiquidado.Refresh();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            periodo = Convert.ToDateTime(this.txtFechaHasta.Text).Year.ToString() + (Convert.ToDateTime(this.txtFechaHasta.Text).Month.ToString().Length == 2 ? Convert.ToDateTime(this.txtFechaHasta.Text).Month.ToString() : "0" + Convert.ToDateTime(this.txtFechaHasta.Text).Month.ToString());
            planilla = Convert.ToString(this.cboPlanilla.SelectedValue.ToString().Trim());

            bwgHilo.RunWorkerAsync();
            ActivarControlBusquedad(false);
            
        }
    }
}
