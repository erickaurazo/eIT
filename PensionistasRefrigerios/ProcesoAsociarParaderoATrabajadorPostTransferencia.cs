using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Transportista.Negocios;
using TransportistaMto.Datos;
using System.Configuration;


namespace Transportista
{
    public partial class ProcesoAsociarParaderoATrabajadorPostTransferencia : Form
    {
        private DateTime FechaInicio;
        private DateTime FechaTermino;
        private Mes MesesNeg;
        private string periodo;
        private string desde;
        private string hasta;
        public ProcesoAsociarParaderoATrabajadorPostTransferencia()
        {
            InitializeComponent();
            CargarMeses();
            ObtenerFechasIniciales();
        }



        private void ObtenerFechasIniciales()
        {
            this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);
            this.txtFechaDesde.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);
            
            FechaInicio = Convert.ToDateTime(this.txtFechaDesde.Text);
            FechaTermino = Convert.ToDateTime(this.txtFechaDesde.Text);
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
                        this.txtFechaDesde.ReadOnly = false;
                        this.txtFechaHasta.ReadOnly = false;
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

        private void ObtenerFechasDias()
        {
            if (EsFecha(this.txtFechaDesde.Text))
            {
                //FechaInicio = Convert.ToDateTime(this.txtFechaDesde.Text);
                //FechaTermino = Convert.ToDateTime(this.txtFechaDesde.Text);
                //this.txtFechaDesde.Text = FechaInicio.ToShortDateString();
                //this.txtFechaHasta.Text = FechaTermino.ToShortDateString();
            }
            else
            {
                MessageBox.Show("FECHA INCORRECTA");
                FechaInicio = DateTime.Now;
                FechaTermino = DateTime.Now;
                this.txtFechaDesde.Text = FechaInicio.ToShortDateString();
                this.txtFechaHasta.Text = FechaTermino.ToShortDateString();
            }
        }

        public static Boolean EsFecha(String fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CargarMeses()
        {

            MesesNeg = new Mes();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = MesesNeg.ListarMeses().ToList();
            //cboMes.SelectedValue = DateTime.Now.ToString("13");
            cboMes.SelectedValue = DateTime.Now.Month.ToString().PadLeft(2, '0');
        }


        private void ProcesoAsociarParaderoATrabajadorPostTransferencia_Load(object sender, EventArgs e)
        {

        }



        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
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

        private void bgwSubProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SJM_PensionesNegocios modelo = new SJM_PensionesNegocios();
                modelo.ProcesoAsociarParaderoATrabajadorPostTransferencia(periodo, desde, hasta);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwSubProceso_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void bgwSubProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                MessageBox.Show("Proceso realizado con éxito", "MENSAJE DEL SISTEMA");
                gbFiltro.Enabled = true;
                pgProceso.Visible = false;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnProgramarExclusion_Click(object sender, EventArgs e)
        {
            periodo = DateTime.Now.Year.ToString();
            desde = this.txtFechaDesde.Text;
            hasta = this.txtFechaHasta.Text;
            gbFiltro.Enabled = false;
            pgProceso.Visible = true;
            EjecutarProceso();
        }

        private void EjecutarProceso()
        {

            bgwSubProceso.RunWorkerAsync();
        }
    }
}
