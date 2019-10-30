using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using MyControlsDataBinding.Extensions;
using System.Configuration;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;


namespace RecursosHumanos
{
    public partial class RHHorarioRefrigrerio : Form
    {
        private string periodo = string.Empty;
        private HorarioRefrigerioNegocio modelo;
        private List<HORARIO_REFRIGERIO> listado;

        public RHHorarioRefrigrerio()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            gbConsulta.Enabled = false;
            gbListado.Enabled = false;
            gbEdicion.Enabled = false;
            progressBar.Visible = true;
            bgwHilo.RunWorkerAsync();
            periodo = this.txtAño.Value.ToString();
        }

        private void RHHorarioRefrigrerio_Load(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                modelo = new HorarioRefrigerioNegocio();
                listado = new List<HORARIO_REFRIGERIO>();
                listado = modelo.ListarHorariosDeRefrigerio(periodo);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvListado.DataSource = listado;
                dgvListado.Refresh();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

            gbConsulta.Enabled = !false;
            gbListado.Enabled = !false;
            gbEdicion.Enabled = !false;
            progressBar.Visible = false;
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {

            this.txtCodigo.Clear();
            this.txtDescripcion.Clear();
            this.txtHoraIngreso.Value = Convert.ToDecimal(0);
            this.txtMinutosEntrada.Value = Convert.ToDecimal(0);
            this.txtHoraSalida.Value = Convert.ToDecimal(0);
            this.txtMinutosSalida.Value = Convert.ToDecimal(0);
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnAnular.Enabled = false;
            btnGuardar.Enabled = false;
            btnAtras.Enabled = false;
            btnHistorial.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = false;


            btnSalir.Enabled = true;


            if (dgvListado != null && dgvListado.Rows.Count > 0)
            {
                if (dgvListado.CurrentRow != null)
                {
                    if (dgvListado.CurrentRow != null && dgvListado.CurrentRow.Cells["chIdHorario"].Value != null)
                    {
                        if (dgvListado.CurrentRow != null && dgvListado.CurrentRow.Cells["chIdHorario"].Value != "")
                        {
                            this.txtCodigo.Text = dgvListado.CurrentRow.Cells["chIdHorario"].Value.ToString();
                            this.txtDescripcion.Text = dgvListado.CurrentRow.Cells["chDescripcion"].Value.ToString();
                            this.txtHoraIngreso.Value = Convert.ToDecimal(dgvListado.CurrentRow.Cells["chREFHDESDE"].Value != null ? 0 : dgvListado.CurrentRow.Cells["chREFHDESDE"].Value);
                            this.txtMinutosEntrada.Value = Convert.ToDecimal(dgvListado.CurrentRow.Cells["chREFMDESDE"].Value != null ? 0 : dgvListado.CurrentRow.Cells["chREFMDESDE"].Value);

                            this.txtHoraSalida.Value = Convert.ToDecimal(dgvListado.CurrentRow.Cells["chREFHHASTA"].Value != null ? 0 : dgvListado.CurrentRow.Cells["chREFHHASTA"].Value);
                            this.txtMinutosSalida.Value = Convert.ToDecimal(dgvListado.CurrentRow.Cells["chREFMHASTA"].Value != null ? 0 : dgvListado.CurrentRow.Cells["chREFMHASTA"].Value);

                            btnGuardar.Enabled = false;
                            btnNuevo.Enabled = true;
                            btnEditar.Enabled = !false;
                            btnAnular.Enabled = false;
                            btnAtras.Enabled = !false;
                            btnHistorial.Enabled = !false;
                            btnEliminar.Enabled = false;
                            btnExportar.Enabled = !false;

                        }
                    }
                }
            }
        }


    }
}
