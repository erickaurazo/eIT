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
using TransportistaMto.Datos;
using Transportista.Negocios;
using Transportista;
using Telerik.WinControls.UI.Localization;

namespace Transportista
{
    public partial class ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios : Form
    {
        private Mes MesesNeg;
        private SJM_PensionesNegocios modelo;
        private string desde;
        private string hasta;

        public ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios()
        {
            InitializeComponent();
            CargarMeses();
            ObtenerFechasIniciales();
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

            try
            {
                #region Obtener Fechas Mes()


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
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString() + "\n. Asignar fechas por periodo o mes", "MENSAJE DEL SISTEMA");
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

        private void SincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios_Load(object sender, EventArgs e)
        {

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
                modelo = new SJM_PensionesNegocios();
                modelo.SincronizarAsistenciasCampoParaDescuentoPorInasistenciasRefrigerios(desde, hasta);

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString() + "\nEjecutar Consulta");
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarConsulta();

        }

        private void EnviarNotificacion()
        {

        }

        private void PresentarConsulta()
        {
            btnActualizar.Enabled = false;
            try
            {
                MessageBox.Show("Se ha sincronizado correctamente la asistencias", "MENSAJE DEL SISTEMA");
                this.btnActualizar.Enabled = true;
                this.btnSalir.Enabled = true;
                this.gbLongitudCreacionCodigos.Enabled = true;
                EnviarNotificacion();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString() + "\nPresentar Información");
                btnActualizar.Enabled = false;
                return;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                desde = this.txtFechaDesde.Text;
                hasta = this.txtFechaHasta.Text;
                btnActualizar.Enabled = false;
                btnSalir.Enabled = false;
                gbLongitudCreacionCodigos.Enabled = false;
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {
                btnActualizar.Enabled = true;
                btnSalir.Enabled = true;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMA");
                return;
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

        private void ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
