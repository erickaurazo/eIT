using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using RecursosHumanos.Negocios;
using RecursosHumanos.Datos;

namespace RecursosHumanos
{
    public partial class MarcacionPuertaMantenimientoTransferenciaMarcacion : Form
    {
        private string nombres;
        private string dni;
        private string codigoBiometricoPersona;
        private string AsistenciaCodigoMovimiento;
        private string fecha;
        private int correlativo;
        private string CodigoTransferencia;
        private List<GrupoH> listadoDias;
        private GrupoNegocio modelo;
        private DateTime fechaTransferir;
        private CheckInOutNegocio modeloMarcacion;

        public MarcacionPuertaMantenimientoTransferenciaMarcacion()
        {
            InitializeComponent();
        }

        public MarcacionPuertaMantenimientoTransferenciaMarcacion(string nombres, string dni, string codigoBiometricoPersona, string AsistenciaCodigoMovimiento, string fecha, int correlativo, string CodigoTransferencia)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.nombres = nombres;
            this.dni = dni;
            this.codigoBiometricoPersona = codigoBiometricoPersona;
            this.AsistenciaCodigoMovimiento = AsistenciaCodigoMovimiento;
            this.fecha = fecha;
            this.correlativo = correlativo;
            this.CodigoTransferencia = CodigoTransferencia;
            this.txtNombres.Text = this.nombres;
            this.txtDNI.Text = this.dni;
            this.txtCodigoTransferencia.Text = this.CodigoTransferencia;
            this.txtMovimientoAsistencia.Text = AsistenciaCodigoMovimiento;
            this.txtFecha.Text = fecha;
            this.txtCodigoTransferencia.Focus();

            gbEdicion.Enabled = false;
            gbFechaTransferir.Enabled = false;
            bwgHilo.RunWorkerAsync();

        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            listadoDias = new List<GrupoH>();
            modelo = new GrupoNegocio();
            listadoDias = modelo.ObtenerListadoDosDiasAnterioresDosDiasPosteriores(this.fecha);

        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.cboDocumentoCodigo.DisplayMember = "descripcion";
                this.cboDocumentoCodigo.ValueMember = "valor";
                this.cboDocumentoCodigo.DataSource = listadoDias;
                gbEdicion.Enabled = !false;
                gbFechaTransferir.Enabled = !false;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void MarcacionPuertaMantenimientoTransferenciaMarcacion_Load(object sender, EventArgs e)
        {
            ComprobarCheck();
        }

        private void ComprobarCheck()
        {
            if (chkFechaPersonalizble.Checked == true)
            {
                cboDocumentoCodigo.Enabled = false;
                this.txtFechaPersonalizable.Enabled = true;
                this.txtFechaPersonalizable.ReadOnly = false;
            }
            else
            {

                cboDocumentoCodigo.Enabled = true;
                this.txtFechaPersonalizable.Enabled = !true;
                this.txtFechaPersonalizable.ReadOnly = !false;
                this.txtFechaPersonalizable.Clear();
            }
        }

        private void chkFechaPersonalizble_CheckedChanged(object sender, EventArgs e)
        {
            ComprobarCheck();
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            if (txtMovimientoAsistencia.Text.Trim() == string.Empty)
            {
                if (chkFechaPersonalizble.Checked == true)
                {
                    fechaTransferir = Convert.ToDateTime(this.txtFechaPersonalizable.Text);
                }
                else
                {
                    fechaTransferir = Convert.ToDateTime(cboDocumentoCodigo.SelectedValue);
                }
                bgwTransferir.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("No se puede importar este registro, por que está siendo referenciado a un movimiento de Asistencia", "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void bgwTransferir_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                modeloMarcacion = new CheckInOutNegocio();
                CheckInOut oCheckInOut = new CheckInOut();
                oCheckInOut = modeloMarcacion.ObtenerMarcacionBiometricoByCorrelativo(Program.ClaseCompartida.periodoElegido, this.correlativo);
                oCheckInOut.fechaAsistencia = fechaTransferir;
                oCheckInOut.codigoTransferencia = txtMovimientoAsistencia.Text;
                modeloMarcacion.GrabarMarcacionBiometrico(Program.ClaseCompartida.periodoElegido, oCheckInOut, this.CodigoTransferencia.ToString());
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void bgwTransferir_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnOK.PerformClick();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
