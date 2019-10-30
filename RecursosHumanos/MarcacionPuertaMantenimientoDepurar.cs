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
    public partial class MarcacionPuertaMantenimientoDepurar : Form
    {
        private string codigoTransferencia;
        private string codigoMovimientoAsistencia;
        private string codigoPlanilla;
        private string semanaDesde;
        private string semanaHasta;
        private string EstadoDescripcion;
        private string fecha;
        private string periodoSelecionado;
        private int correlativoTransferir;
        private CheckInOutNegocio modelo;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult> listadoMarcacionPersonalByPersonaDiaAnterior;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult> listadoMarcacionPersonalByPersonaDiaDiaPosterior;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> listadoPersonal;
        private CheckInOutNegocio oModeloCheckInOutNegocio;

        public MarcacionPuertaMantenimientoDepurar()
        {
            InitializeComponent();
        }

        public MarcacionPuertaMantenimientoDepurar(string codigoTransferencia, string codigoMovimientoAsistencia, string EstadoDescripcion, string fecha, string codigoPlanilla, string semanaDesde, string semanaHasta, string periodoSelecionado)
        {
            // TODO: Complete member initialization
            // 
            InitializeComponent();
            this.codigoTransferencia = codigoTransferencia;
            this.codigoMovimientoAsistencia = codigoMovimientoAsistencia;
            this.codigoPlanilla = codigoPlanilla;
            this.semanaDesde = semanaDesde;
            this.semanaHasta = semanaHasta;
            this.EstadoDescripcion = EstadoDescripcion;
            this.fecha = fecha;
            this.periodoSelecionado = periodoSelecionado;

            txtCodigoTransferencia.Text = codigoTransferencia;
            txtMovimientoAsistencia.Text = codigoMovimientoAsistencia;
            txtFecha.Text = fecha;

            gbEdicion.Enabled = false;
            bwgHilo.RunWorkerAsync();

        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            modelo = new CheckInOutNegocio();
            listadoPersonal = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
            listadoPersonal = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaDesconocidos(Program.ClaseCompartida.periodoElegido, this.fecha, Program.ClaseCompartida.codigoTipoPlanilla, this.codigoTransferencia).ToList();

        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblTotalRegistros.Text = "Se han encontrado " + listadoPersonal.Count.ToString() + " registros";
            dgvDetalle.DataSource = listadoPersonal.OrderBy(x => x.horaMarcacion).ToList().ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
            dgvDetalle.Refresh();
            gbEdicion.Enabled = !false;

        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            correlativoTransferir = 0;

            if (dgvDetalle != null && dgvDetalle.Rows.Count > 0)
            {
                if (dgvDetalle.CurrentRow != null)
                {
                    if (dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value != null && dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value.ToString().Trim() != "")
                    {
                        correlativoTransferir = dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value != null ? Convert.ToInt32(dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value) : 0;

                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnOK.PerformClick();

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            gbEdicion.Enabled = false;
            if (this.txtMovimientoAsistencia.Text.Trim() == string.Empty)
            {
                if (correlativoTransferir != 0)
                {
                    CheckInOut check = new CheckInOut();
                    check.correlativo = correlativoTransferir;
                    oModeloCheckInOutNegocio = new CheckInOutNegocio();
                    oModeloCheckInOutNegocio.EliminarMarcacionBiometricoByCorrelativo(this.periodoSelecionado, check);

                    bwgHilo.RunWorkerAsync();
                }

            }
            else
            {
                MessageBox.Show("No se puede importar este registro, por que está siendo referenciado a un movimiento de Asistencia", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void MarcacionPuertaMantenimientoDepurar_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizarListado_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminarAll_Click(object sender, EventArgs e)
        {

            if (this.txtMovimientoAsistencia.Text.Trim() == string.Empty)
            {
                if (listadoPersonal.ToList().Count > 0)
                {
                    //Eliminar toda la lista
                    gbEdicion.Enabled = false;
                    ProgressBarF.Visible = true;
                    bwgEliminacionMasiva.RunWorkerAsync();
                }
               
            }
            else
            {
                MessageBox.Show("No se puede importar este registro, por que está siendo referenciado a un movimiento de Asistencia", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bwgEliminacionMasiva_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var item in listadoPersonal)
            {
                if (item.correlativo != 0)
                {
                    CheckInOut check = new CheckInOut();
                    check.correlativo = item.correlativo;
                    oModeloCheckInOutNegocio = new CheckInOutNegocio();
                    oModeloCheckInOutNegocio.EliminarMarcacionBiometricoByCorrelativo(this.periodoSelecionado, check);
                }
            }
            modelo = new CheckInOutNegocio();
            listadoPersonal = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
            listadoPersonal = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaDesconocidos(Program.ClaseCompartida.periodoElegido, this.fecha, Program.ClaseCompartida.codigoTipoPlanilla, this.codigoTransferencia).ToList();

        }

        private void bwgEliminacionMasiva_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblTotalRegistros.Text = "Se han encontrado " + listadoPersonal.Count.ToString() + " registros";
            dgvDetalle.DataSource = listadoPersonal.OrderBy(x => x.horaMarcacion).ToList().ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
            dgvDetalle.Refresh();
            gbEdicion.Enabled = !false;
            ProgressBarF.Visible = !true;
        }


    }
}
