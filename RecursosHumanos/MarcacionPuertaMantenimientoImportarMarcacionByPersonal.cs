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
    public partial class MarcacionPuertaMantenimientoImportarMarcacionByPersonal : Form
    {
        private string nombres;
        private string dni;
        private string codigoBiometricoPersona;
        private string AsistenciaCodigoMovimiento;
        private string fecha;
        private int correlativo;
        private string codigoTransferencia;

        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult> listadoMarcacionPersonalByPersonaDiaAnterior;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult> listadoMarcacionPersonalByPersonaDiaDiaPosterior;
        private CheckInOutNegocio modelo;
        private int CorrelativoTransferir;

        public MarcacionPuertaMantenimientoImportarMarcacionByPersonal()
        {
            InitializeComponent();
        }

        public MarcacionPuertaMantenimientoImportarMarcacionByPersonal(string nombres, string dni, string codigoBiometricoPersona, string AsistenciaCodigoMovimiento, string fecha, int correlativo, string codigoTransferencia)
        {
            // TODO: Complete member initialization
            InitializeComponent();

            this.nombres = nombres;
            this.dni = dni;
            this.codigoBiometricoPersona = codigoBiometricoPersona;
            this.AsistenciaCodigoMovimiento = AsistenciaCodigoMovimiento;
            this.fecha = fecha;
            this.correlativo = correlativo;
            this.codigoTransferencia = codigoTransferencia;

            this.txtNombres.Text = this.nombres;
            this.txtDNI.Text = this.dni;
            this.txtCodigoTransferencia.Text = this.codigoTransferencia;
            this.txtMovimientoAsistencia.Text = AsistenciaCodigoMovimiento;
            this.txtFecha.Text = fecha;
            this.txtCodigoTransferencia.Focus();

            gbEdicion.Enabled = false;
            bwgHilo.RunWorkerAsync();


        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listadoMarcacionPersonalByPersonaDiaAnterior = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult>();
                listadoMarcacionPersonalByPersonaDiaDiaPosterior = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult>();

                modelo = new CheckInOutNegocio();
                listadoMarcacionPersonalByPersonaDiaAnterior = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNI(Program.ClaseCompartida.periodoElegido, Convert.ToDateTime(this.fecha).AddDays(-1).ToShortDateString(), Program.ClaseCompartida.codigoTipoPlanilla, this.codigoTransferencia, this.dni).ToList();

                modelo = new CheckInOutNegocio();
                listadoMarcacionPersonalByPersonaDiaDiaPosterior = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNI(Program.ClaseCompartida.periodoElegido, Convert.ToDateTime(this.fecha).AddDays(1).ToShortDateString(), Program.ClaseCompartida.codigoTipoPlanilla, this.codigoTransferencia, this.dni).ToList();

                listadoMarcacionPersonalByPersonaDiaAnterior.AddRange(listadoMarcacionPersonalByPersonaDiaDiaPosterior);

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void MarcacionPuertaMantenimientoImportarMarcacion_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {

            if (this.txtMovimientoAsistencia.Text.Trim() == string.Empty)
            {
                if (CorrelativoTransferir != 0)
                {
                    TransferirAsistenciaDesdeCorrelativoAFecha(CorrelativoTransferir, this.fecha);
                }
                this.btnOK.PerformClick();
            }
            else
            {
                MessageBox.Show("No se puede importar este registro, por que está siendo referenciado a un movimiento de Asistencia", "MENSAJE DEL SISTEMA");
                return;
            }

           
            
        }

        private void TransferirAsistenciaDesdeCorrelativoAFecha(int CorrelativoTransferir, string fechaAsistencia)
        {
            modelo = new CheckInOutNegocio();
            modelo.TransferirAsistenciaDesdeCorrelativoAFecha(Program.ClaseCompartida.periodoElegido, this.fecha, CorrelativoTransferir, this.codigoTransferencia);

        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvDetalle.DataSource = listadoMarcacionPersonalByPersonaDiaAnterior.OrderBy(x => x.horaMarcacion).ToList().ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult>();
            dgvDetalle.Refresh();
            gbEdicion.Enabled = !false;

        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            CorrelativoTransferir = 0;

            if (dgvDetalle != null && dgvDetalle.Rows.Count > 0)
            {
                if (dgvDetalle.CurrentRow != null)
                {
                    if (dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value != null && dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value.ToString().Trim() != "")
                    {
                        CorrelativoTransferir = dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value != null ? Convert.ToInt32(dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value) : 0;

                    }
                }
            }
        }

        private void dgvDetalle_DoubleClick(object sender, EventArgs e)
        {
            if (CorrelativoTransferir != 0)
            {
                TransferirAsistenciaDesdeCorrelativoAFecha(CorrelativoTransferir, this.fecha);
            }
            this.btnOK.PerformClick();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
