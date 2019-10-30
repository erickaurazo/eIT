using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MyControlsDataBinding.Extensions;

using System.Linq;
using TransportistaMto.Datos;
using Transportista.Negocios;

namespace Transportista
{
    public partial class ProgramacionRefrigerioRegistrosMultiplesVistaImpresion : Form
    {
        private SJ_RHPensionRefrigerioPersonaNegocio modelo;
        private List<SJ_RHPensionRefrigerioPersonaByAgrupadoCodigoRegistradoResult> listado;
        private SJ_RHPensionRefrigerioPersonaByAgrupadoCodigoRegistradoResult registroAgrupado;
        private List<SJ_RHPensionRefrigerioPersonasByDetalleCodigoRegistradoResult> listadoDetalle;

        public ProgramacionRefrigerioRegistrosMultiplesVistaImpresion()
        {
            InitializeComponent();
            Actualizar();
        }

        private void bgwProceso1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                modelo = new SJ_RHPensionRefrigerioPersonaNegocio();
                listado = new List<SJ_RHPensionRefrigerioPersonaByAgrupadoCodigoRegistradoResult>();
                listado = modelo.ObtenerListaProgramacionAGrupadaByCodigoRegistro().ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "ADVERTENCIA DEL SISTEMA");
                return;
            }
            
        }

        private void bgwProceso1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvAgrupado.DataSource = listado.ToDataTable<SJ_RHPensionRefrigerioPersonaByAgrupadoCodigoRegistradoResult>();
                dgvAgrupado.Refresh();
                barraPrincipal.Enabled = !false;
                gbListadoAgrupado.Enabled = !false;
                gbDetalle.Enabled = !false;
                ProgressBar.Visible = !true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ADVERTENCIA DEL SISTEMA");
                barraPrincipal.Enabled = !false;
                gbListadoAgrupado.Enabled = !false;
                gbDetalle.Enabled = !false;
                ProgressBar.Visible = !true;
                return;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            Actualizar();

        }

        private void Actualizar()
        {
            try
            {
                barraPrincipal.Enabled = false;
                gbListadoAgrupado.Enabled = false;
                gbDetalle.Enabled = false;
                ProgressBar.Visible = true;
                bgwProceso1.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "ADVERTENCIA DEL SISTEMA");
                return;
            }
        }

        private void dgvAgrupado_SelectionChanged(object sender, EventArgs e)
        {
            registroAgrupado = new SJ_RHPensionRefrigerioPersonaByAgrupadoCodigoRegistradoResult() { codigoregistrado = "" };

            if (dgvAgrupado != null && dgvAgrupado.CurrentRow != null)
            {
                string codigoRegistro = dgvAgrupado.CurrentRow.Cells["chcodigoregistrado"].Value != null ? dgvAgrupado.CurrentRow.Cells["chcodigoregistrado"].Value.ToString().Trim() : "";
                var resultoResultado = listado.Where(x => x.codigoregistrado.Trim() == codigoRegistro).ToList();
                if (resultoResultado != null && resultoResultado.ToList().Count > 0)
                {
                    registroAgrupado = resultoResultado.Single();
                }
            }
        }

        private void dgvAgrupado_DoubleClick(object sender, EventArgs e)
        {
            if (registroAgrupado != null && registroAgrupado.codigoregistrado != null && registroAgrupado.codigoregistrado != "")
            {
                try
                {
                    barraPrincipal.Enabled = false;
                    gbListadoAgrupado.Enabled = false;
                    gbDetalle.Enabled = false;
                    ProgressBar.Visible = true;
                    bgwProceso2.RunWorkerAsync();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message, "ADVERTENCIA DEL SISTEMA");
                    return;
                }

            }
        }

        private void bgwProceso2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                modelo = new SJ_RHPensionRefrigerioPersonaNegocio();
                listadoDetalle = new List<SJ_RHPensionRefrigerioPersonasByDetalleCodigoRegistradoResult>();
                listadoDetalle = modelo.ObtenerDetalleProgramacionByCodigoRegistro(registroAgrupado.codigoregistrado.Trim()).ToList();


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "ADVERTENCIA DEL SISTEMA");
                return;
            }

        }

        private void bgwProceso2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvDetalle.DataSource = listadoDetalle.ToDataTable<SJ_RHPensionRefrigerioPersonasByDetalleCodigoRegistradoResult>();
                dgvDetalle.Refresh();
                barraPrincipal.Enabled = !false;
                gbListadoAgrupado.Enabled = !false;
                gbDetalle.Enabled = !false;
                ProgressBar.Visible = !true;

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "ADVERTENCIA DEL SISTEMA");
                barraPrincipal.Enabled = !false;
                gbListadoAgrupado.Enabled = !false;
                gbDetalle.Enabled = !false;
                ProgressBar.Visible = !true;
                return;
            }

        }

        private void ProgramacionRefrigerioRegistrosMultiplesVistaImpresion_Load(object sender, EventArgs e)
        {

        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            VistaPrevia();
        }

        private void VistaPrevia()
        {
            try
            {
                if (registroAgrupado.codigoregistrado != "" && registroAgrupado.registradoPor != "")
                {
                    TicketsPrivilegiosRefrigerioImprimir oFrmDetalle = new TicketsPrivilegiosRefrigerioImprimir(registroAgrupado.codigoregistrado.Trim());
                    oFrmDetalle.AgregarParametroCadena("@impresoPor", registroAgrupado.registradoPor.Trim());
                    oFrmDetalle.ShowDialog();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ADVERTENCIA DEL SISTEMA");
                return;
            }
        }

        private void btnSubVistaPrevia_Click(object sender, EventArgs e)
        {
            VistaPrevia();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.bgwProceso1.IsBusy == true || this.bgwProceso2.IsBusy == true)
            {               
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Close();
            }
        }

        private void ProgramacionRefrigerioRegistrosMultiplesVistaImpresion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwProceso1.IsBusy == true || this.bgwProceso2.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }


    }
}
