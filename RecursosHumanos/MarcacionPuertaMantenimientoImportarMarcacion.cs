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
    public partial class MarcacionPuertaMantenimientoImportarMarcacion : Form
    {
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekResult> listadoMarcacionesBiometricoByPlanillaByWeek;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupadoResult> listadoMarcacionesBiometricoByPlanillaByWeekAgrupado;
        private CheckInOutNegocio modeloMarcacionBiometrico;
        private string codigoDeTransferencia = string.Empty;
        private string fechaDeRegistroAsistencia = string.Empty;
        private string codigoMovimientoAsistencia = string.Empty;
        private string EstadoAsistencia = string.Empty;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> ListadoAllTransferenciaAsistenciaBiometroByWeekByFecha;
        private CheckInOutNegocio modelo;
        private decimal? correlativoRegistro = 0;
        private string nombreTrabajadorTransferido;
        private string dniTrabajadorTransferido;
        private string fechaTransferencia;
        private string codigoTransferencia;
        private string MovimientoAsistencia;
        private string EstadodelRegistro;
        private string FechaRegistro;
        private string codigoPlanilla;
        private string semanaDesde;
        private string semanaHasta;
        private string periodoSelecionado;


        public MarcacionPuertaMantenimientoImportarMarcacion()
        {
            InitializeComponent();
            gbMovimientoDestino.Enabled = !true;
            gbMovimientoOrigen.Enabled = !true;

            RadGridLocalizationProvider.CurrentProvider = new ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            Program.ClaseCompartida.periodoElegido = "201812";
            Program.ClaseCompartida.desde = Convert.ToDateTime("03/12/2018");
            Program.ClaseCompartida.hasta = Convert.ToDateTime("11/12/2018");
            Program.ClaseCompartida.codigoTipoPlanilla = "OAS";

            bwgHilo.RunWorkerAsync();
        }

        public MarcacionPuertaMantenimientoImportarMarcacion(string codigoTransferencia, string MovimientoAsistencia, string EstadodelRegistro, string FechaRegistro, string codigoPlanilla, string semanaDesde, string semanaHasta, string periodoSelecionado)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            gbMovimientoDestino.Enabled = !true;
            gbMovimientoOrigen.Enabled = !true;

            RadGridLocalizationProvider.CurrentProvider = new ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            this.codigoTransferencia = codigoTransferencia;
            this.MovimientoAsistencia = MovimientoAsistencia;
            this.EstadodelRegistro = EstadodelRegistro;
            this.FechaRegistro = FechaRegistro;
            this.codigoPlanilla = codigoPlanilla;
            this.semanaDesde = semanaDesde;
            this.semanaHasta = semanaHasta;
            this.periodoSelecionado = periodoSelecionado;



            Program.ClaseCompartida.periodoElegido = this.periodoSelecionado;
            Program.ClaseCompartida.desde = Convert.ToDateTime(this.semanaDesde);
            Program.ClaseCompartida.hasta = Convert.ToDateTime(this.semanaHasta);
            Program.ClaseCompartida.codigoTipoPlanilla = codigoPlanilla;

            txtCodigoTransferenciaDestino.Text = codigoTransferencia;
            txtMovimientoAsistenciaDestino.Text = MovimientoAsistencia;
            txtFechaDestino.Text = FechaRegistro;
            txtEstadoRegistroAsistenciaDestino.Text = EstadodelRegistro;

            bwgHilo.RunWorkerAsync();

        }

        private void MarcacionPuertaMantenimientoImportarMarcacion_Load(object sender, EventArgs e)
        {

        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listadoMarcacionesBiometricoByPlanillaByWeek = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekResult>();
                listadoMarcacionesBiometricoByPlanillaByWeekAgrupado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupadoResult>();

                modeloMarcacionBiometrico = new CheckInOutNegocio();
                //listadoMarcacionesBiometricoByPlanillaByWeek = modeloMarcacionBiometrico.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeek(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.desde.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.hasta.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.codigoTipoPlanilla).ToList();
                listadoMarcacionesBiometricoByPlanillaByWeekAgrupado = modeloMarcacionBiometrico.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupado(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.desde.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.hasta.ToPresentationDate().Substring(0, 10), Program.ClaseCompartida.codigoTipoPlanilla).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                gbEdicion.Enabled = true;
                dgvRegistros.DataSource = listadoMarcacionesBiometricoByPlanillaByWeekAgrupado.OrderBy(x => x.fechaAsistencia.Value).ToList().ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekAgrupadoResult>();
                dgvRegistros.Refresh();
                gbMovimientoDestino.Enabled = true;
                gbMovimientoOrigen.Enabled = true;


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {

            codigoDeTransferencia = string.Empty;
            fechaDeRegistroAsistencia = string.Empty;
            codigoMovimientoAsistencia = string.Empty;
            EstadoAsistencia = string.Empty;

            if (dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                if (dgvRegistros.CurrentRow != null)
                {
                    if (dgvRegistros.CurrentRow.Cells["chcodigoTransferencia"].Value != null && dgvRegistros.CurrentRow.Cells["chcodigoTransferencia"].Value.ToString().Trim() != "")
                    {
                        codigoDeTransferencia = dgvRegistros.CurrentRow.Cells["chcodigoTransferencia"].Value != null ? dgvRegistros.CurrentRow.Cells["chcodigoTransferencia"].Value.ToString().Trim() : string.Empty;
                        fechaDeRegistroAsistencia = dgvRegistros.CurrentRow.Cells["chfechaAsistencia"].Value != null ? dgvRegistros.CurrentRow.Cells["chfechaAsistencia"].Value.ToString().Trim() : string.Empty;
                        codigoMovimientoAsistencia = dgvRegistros.CurrentRow.Cells["chCodigoMovimientoAsistencia"].Value != null ? dgvRegistros.CurrentRow.Cells["chCodigoMovimientoAsistencia"].Value.ToString().Trim() : string.Empty;
                        EstadoAsistencia = dgvRegistros.CurrentRow.Cells["chestado"].Value != null ? dgvRegistros.CurrentRow.Cells["chestado"].Value.ToString().Trim() : string.Empty;

                    }
                }
            }
        }

        private void dgvRegistros_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (codigoDeTransferencia != string.Empty && codigoDeTransferencia != string.Empty)
                {
                    txtCodigoTransferenciaOrigen.Text = codigoDeTransferencia;
                    txtEstadoRegistroAsistenciaOrigen.Text = EstadoAsistencia;
                    txtMovimientoAsistenciaOrigen.Text = codigoMovimientoAsistencia;
                    txtFechaOrigen.Text = fechaDeRegistroAsistencia;
                    bwgHiloListadoAsistenciaByFecha.RunWorkerAsync();

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        private void bwgHiloListadoAsistenciaByFecha_DoWork(object sender, DoWorkEventArgs e)
        {
            ListadoAllTransferenciaAsistenciaBiometroByWeekByFecha = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
            modelo = new CheckInOutNegocio();

            ListadoAllTransferenciaAsistenciaBiometroByWeekByFecha = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFecha(Program.ClaseCompartida.periodoElegido, fechaDeRegistroAsistencia, Program.ClaseCompartida.codigoTipoPlanilla, codigoDeTransferencia).ToList();


        }

        private void bwgHiloListadoAsistenciaByFecha_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgwListadoMarcacionesByFecha.DataSource = ListadoAllTransferenciaAsistenciaBiometroByWeekByFecha.ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
            dgwListadoMarcacionesByFecha.Refresh();
        }

        private void dgwListadoMarcacionesByFecha_SelectionChanged(object sender, EventArgs e)
        {
            correlativoRegistro = 0;
            nombreTrabajadorTransferido = string.Empty;

            if (dgwListadoMarcacionesByFecha != null && dgwListadoMarcacionesByFecha.Rows.Count > 0)
            {
                if (dgwListadoMarcacionesByFecha.CurrentRow != null)
                {
                    if (dgwListadoMarcacionesByFecha.CurrentRow.Cells["chcorrelativo"].Value != null && Convert.ToDecimal(dgwListadoMarcacionesByFecha.CurrentRow.Cells["chcorrelativo"].Value) != 0)
                    {
                        if (dgwListadoMarcacionesByFecha.CurrentRow.Cells["chNombres"].Value != null && dgwListadoMarcacionesByFecha.CurrentRow.Cells["chNombres"].Value.ToString().Trim() != string.Empty)
                        {
                            correlativoRegistro = (dgwListadoMarcacionesByFecha.CurrentRow.Cells["chcorrelativo"].Value != null ? Convert.ToDecimal(dgwListadoMarcacionesByFecha.CurrentRow.Cells["chcorrelativo"].Value) : 0);
                            nombreTrabajadorTransferido = dgwListadoMarcacionesByFecha.CurrentRow.Cells["chNombres"].Value.ToString();
                            dniTrabajadorTransferido = dgwListadoMarcacionesByFecha.CurrentRow.Cells["chdni"].Value.ToString();
                            fechaTransferencia = txtFechaDestino.Text.ToString();
                        }
                    }
                }
            }
        }

        private void dgwListadoMarcacionesByFecha_DoubleClick(object sender, EventArgs e)
        {
            if (correlativoRegistro != 0 && nombreTrabajadorTransferido != string.Empty)
            {
                this.txtNombres.Text = nombreTrabajadorTransferido;
                this.txtDNI.Text = dniTrabajadorTransferido;
                this.txtCodigoCorrelativo.Text = correlativoRegistro.Value.ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {

            /*TIENE QUE TENER CODIGO DE ORIGEN ES DECIR DEL DIA QUE LO VOY A IMPORTAR*/
            if (this.txtCodigoTransferenciaOrigen.Text.Trim() != string.Empty)
            {
                /* Si tiene movimiento de asistencia no debe dejar importar */
                if (txtMovimientoAsistenciaOrigen.Text.Trim() != string.Empty)
                {
                    MessageBox.Show("No se puede importar este registro origen, por que está siendo referenciado a un movimiento de Asistencia", "MENSAJE DEL SISTEMA");
                    return;
                }
                else /*Si esta vacion se procede */
                {
                    /* el si codigo al registo del dia donde quiero transferir no esta en blanco se sigue */
                    if (txtCodigoTransferenciaDestino.Text.Trim() != string.Empty)
                    {
                        if (txtMovimientoAsistenciaDestino.Text.Trim() == string.Empty)
                        {
                            if (this.txtCodigoCorrelativo.Text != string.Empty)
                            {
                                if (correlativoRegistro != 0)
                                {
                                    modelo = new CheckInOutNegocio();
                                    modelo.TransferirAsistenciaDesdeCorrelativoByCodigoTransferencia(Program.ClaseCompartida.periodoElegido, fechaTransferencia, Convert.ToInt32(correlativoRegistro), this.txtCodigoTransferenciaDestino.Text.ToString().Trim());
                                    MessageBox.Show("Transferencia satisfactoria", "MENSAJE DEL SISTEMA");
                                    this.btnOK.PerformClick();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se ha seleccionado registro para transferir", "MENSAJE DEL SISTEMA");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede importar este registro destino, por que está siendo referenciado a un movimiento de Asistencia", "MENSAJE DEL SISTEMA");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe código de transferencia destino para este día", "MENSAJE DEL SISTEMA");
                        return;
                    }

                }


            }
            else
            {
                MessageBox.Show("No existe código de transferencia origen para este día", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgwListadoMarcacionesByFecha_Click(object sender, EventArgs e)
        {

        }

        private void TransferirAsistenciaDesdeCorrelativoAFecha(int CorrelativoTransferir, string fechaAsistencia)
        {

        }


    }
}
