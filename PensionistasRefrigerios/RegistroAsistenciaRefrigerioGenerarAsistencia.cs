using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Configuration;
using System.Collections;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class RegistroAsistenciaRefrigerioGenerarAsistencia : Form
    {
        public List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult> listaImportadaByProgramacion;
        private string dniPension;
        private string razonSocial;
        private string nombreComercial;
        private string fechaRegistro;
        private SJ_RHMovimientoAsistenciaPensionNegocios modelo;
        private List<SJ_RHListadoPersonalByProgramacionByPensionResult> listadoPersonal;
        private SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult item;

        public RegistroAsistenciaRefrigerioGenerarAsistencia()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public RegistroAsistenciaRefrigerioGenerarAsistencia(string dniPension, string razonSocial, string nombreComercial, string fechaRegistro)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.dniPension = dniPension;
            this.razonSocial = razonSocial;
            this.nombreComercial = nombreComercial;
            this.fechaRegistro = fechaRegistro;

            this.txtnroDniPension.Text = dniPension;
            this.txtProveedorPseudoNombre.Text = nombreComercial;
            this.txtProveedorRazonSocial.Text = razonSocial;
            Actualizar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GenerarLista();
        }

        private void GenerarLista()
        {
            this.listaImportadaByProgramacion = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult>();

            if (dgvPersonal != null && dgvPersonal.Rows.Count > 0)
            {
                foreach (Telerik.WinControls.UI.GridViewRowInfo fila in dgvPersonal.Rows)
                {
                    string activo, desayuno, almuerzo, cena, dniTrabajador, nombresTrabajador = string.Empty;
                    activo = fila.Cells["chesSelecionado"].Value != null ? fila.Cells["chesSelecionado"].Value.ToString().Trim() : string.Empty;
                    

                    if (activo == "1")
                    {
                        desayuno = fila.Cells["chdesayuno"].Value != null ? fila.Cells["chdesayuno"].Value.ToString().Trim() : string.Empty;
                        almuerzo = fila.Cells["chalmuerzo"].Value != null ? fila.Cells["chalmuerzo"].Value.ToString().Trim() : string.Empty;
                        cena = fila.Cells["chcena"].Value != null ? fila.Cells["chcena"].Value.ToString().Trim() : string.Empty;
                        dniTrabajador = fila.Cells["chNroDocumento"].Value != null ? fila.Cells["chNroDocumento"].Value.ToString().Trim() : string.Empty;
                        nombresTrabajador = fila.Cells["chNombresCompletos"].Value != null ? fila.Cells["chNombresCompletos"].Value.ToString().Trim() : string.Empty;

                        if (desayuno == "1")
                        {
                           item = new SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult();
                           item.codigoMovimiento = string.Empty;
                           item.item = 0;
                           item.codigo = string.Empty;
                           item.codigoTransferencia = 0;
                           item.DniPension = this.txtnroDniPension.Text.Trim();
                           item.NombresPension = this.razonSocial;
                           item.DniTrabajador = dniTrabajador;
                           item.NombresTrabajador = nombresTrabajador;
                           item.TipoComida = 0;
                           item.Refrigerio = "DESAYUNO";
                           item.FechaPension = Convert.ToDateTime(this.fechaRegistro);
                           item.FechaRegistro = DateTime.Now;
                           item.EsProcesado = 0;
                           item.idParadero = "";
                           item.glosa = "ASISTENCIA GENERADA MANUALMENTE";
                           listaImportadaByProgramacion.Add(item);
                        }

                        if (almuerzo == "1")
                        {
                            item = new SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult();
                            item.codigoMovimiento = string.Empty;
                            item.item = 0;
                            item.codigo = string.Empty;
                            item.codigoTransferencia = 0;
                            item.DniPension = this.txtnroDniPension.Text.Trim();
                            item.NombresPension = this.razonSocial;
                            item.DniTrabajador = dniTrabajador;
                            item.NombresTrabajador = nombresTrabajador;
                            item.TipoComida = 1;
                            item.Refrigerio = "ALMUERZO";
                            item.FechaPension = Convert.ToDateTime(this.fechaRegistro);
                            item.FechaRegistro = DateTime.Now;
                            item.EsProcesado = 0;
                            item.idParadero = "";
                            item.glosa = "ASISTENCIA GENERADA MANUALMENTE";
                            listaImportadaByProgramacion.Add(item);
                        }

                        if (cena == "1")
                        {
                            item = new SJ_RHListadoMovimientoAsistenciasProcesadasByCodigoResult();
                            item.codigoMovimiento = string.Empty;
                            item.item = 0;
                            item.codigo = string.Empty;
                            item.codigoTransferencia = 0;
                            item.DniPension = this.txtnroDniPension.Text.Trim();
                            item.NombresPension = this.razonSocial;
                            item.DniTrabajador = dniTrabajador;
                            item.NombresTrabajador = nombresTrabajador;
                            item.TipoComida = 2;
                            item.Refrigerio = "CENA";
                            item.FechaPension = Convert.ToDateTime(this.fechaRegistro);
                            item.FechaRegistro = DateTime.Now;
                            item.EsProcesado = 0;
                            item.idParadero = "";
                            item.glosa = "ASISTENCIA GENERADA MANUALMENTE";
                            listaImportadaByProgramacion.Add(item);
                        }

                    }
                }
            }
        }

        private void RegistroAsistenciaRefrigerioGenerarAsistencia_Load(object sender, EventArgs e)
        {

        }



        private void bgwProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
            listadoPersonal = new List<SJ_RHListadoPersonalByProgramacionByPensionResult>();
            listadoPersonal = modelo.ObtenerListadoPersonalPorProgramacionRefrigerio(this.dniPension, this.fechaRegistro).ToList();
        }

        private void bgwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvPersonal.DataSource = listadoPersonal.ToDataTable<SJ_RHListadoPersonalByProgramacionByPensionResult>();
            dgvPersonal.Refresh();

            gbInformacion.Enabled = !false;
            gbListado.Enabled = !false;
            progressBar.Visible = false;
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            this.dniPension = this.txtnroDniPension.Text;
            Actualizar();
        }

        private void Actualizar()
        {
            gbInformacion.Enabled = false;
            gbListado.Enabled = false;
            progressBar.Visible = !false;
            bgwProceso.RunWorkerAsync();
        }

        private void RegistroAsistenciaRefrigerioGenerarAsistencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwProceso.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListarTodoPersonalProgramacion_Click(object sender, EventArgs e)
        {
            this.dniPension = string.Empty;
            Actualizar();
        }


    }
}
