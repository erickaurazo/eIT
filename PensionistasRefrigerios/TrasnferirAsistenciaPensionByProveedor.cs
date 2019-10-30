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
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class TrasnferirAsistenciaPensionByProveedor : Form
    {
        private RefrigeriosPensionesNegocios modelo;
        private string desde;
        private string hasta;
        private string idClienteProveedor;
        private List<SJ_RRHHListarAsistenciasPendientesProcesoByProveedorByPeriodoResult> listadoAsistenciaPendientes;
        private Mes MesesNeg;


        public TrasnferirAsistenciaPensionByProveedor()
        {
            InitializeComponent();
            CargarMeses();
            ObtenerFechasIniciales();
        }

        private void ObtenerFechasIniciales()
        {
            //this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);

            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);
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
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtPeriodo.Value.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Value.ToString());// 
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
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtPeriodo.Value.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Value.ToString());// 
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
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtPeriodo.Value.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtPeriodo.Value.ToString());//
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

        private void btnBuscarTransportista_Click(object sender, EventArgs e)
        {
            this.txtRUCProveedor.Clear();
            this.txtRazonSocialProveedor.Clear();
            this.txtRazonSocialProveedor.Clear();


            BuscarPension oFrm = new BuscarPension();
            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                if (oFrm.ObjetoBusquedaPension != null)
                {
                    try
                    {
                        this.txtRUCProveedor.Text = oFrm.ObjetoBusquedaPension.NroDNI;
                        this.txtRazonSocialProveedor.Text = oFrm.ObjetoBusquedaPension.RazonSocial;
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                        return;
                    }
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                desde = this.txtFechaDesde.Text.ToString().Trim();
                hasta = this.txtFechaHasta.Text.ToString().Trim();
                idClienteProveedor = this.txtRUCProveedor.Text.ToString().Trim();
                gbConsulta.Enabled = false;
                gbListaResultado.Enabled = false;
                ProgressBar.Visible = true;
                bwgHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "Ejecutar consulta", "ADVERTENCIA DEL SISTEMA");
                return;
            }

        }

        private void TrasnferirAsistenciaPensionByProveedor_Load(object sender, EventArgs e)
        {

        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                modelo = new RefrigeriosPensionesNegocios();
                listadoAsistenciaPendientes = new List<SJ_RRHHListarAsistenciasPendientesProcesoByProveedorByPeriodoResult>();
                listadoAsistenciaPendientes = modelo.ObtenerAsistenciasPendientesProcesoByProveedorByPeriodo(idClienteProveedor, desde, hasta).ToList();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "consultar datos", "ADVERTENCIA DEL SISTEMA");
                return;
            }


        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvDetalle.DataSource = listadoAsistenciaPendientes.ToDataTable<SJ_RRHHListarAsistenciasPendientesProcesoByProveedorByPeriodoResult>();
                dgvDetalle.Refresh();

                gbConsulta.Enabled = true;
                gbListaResultado.Enabled = true;
                ProgressBar.Visible = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "Presentar datos de la consulta", "ADVERTENCIA DEL SISTEMA");
                return;
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }
    }
}
