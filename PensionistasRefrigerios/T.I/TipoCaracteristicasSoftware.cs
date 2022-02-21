﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Asistencia.Datos;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using Asistencia.Negocios;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Busquedas;
using Asistencia.Helper;
using Telerik.WinControls.UI.Localization;

namespace ComparativoHorasVisualSATNISIRA.T.I
{
    public partial class TipoCaracteristicasSoftware : Form
    {
        private PrivilegesByUser privilege;
        private string _companyId;
        private string _conection;
        private SAS_USUARIOS _user2;
        private bool exportVisualSettings;
        private string fileName;
        private SAS_DispositivoTipoSoftwareController model;
        private List<SAS_DispositivoTipoSoftwareListado> listado;
        private SAS_DispositivoTipoSoftware otipo;
        private ComboBoxHelper comboHelper;
        private List<Grupo> clasificacionesSoftware;
        private SAS_DispositivoTipoSoftwareListado oDetalle;
        private SAS_DispositivoTipoSoftware oDetalleTipoSoftware;

        public TipoCaracteristicasSoftware()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            CargarCombos();
            Actualizar();


        }

        private void CargarCombos()
        {
            try
            {
                comboHelper = new ComboBoxHelper();
                clasificacionesSoftware = new List<Grupo>();

                clasificacionesSoftware = comboHelper.GetComboBoxTypeOfSoftware("SAS");
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.ValueMember = "Codigo";
                cboCategoria.DataSource = clasificacionesSoftware.ToList();
                cboCategoria.SelectedValue = "000";

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Mensajes del sistema");
                return;
            }
        }

        public TipoCaracteristicasSoftware(string _conection, SAS_USUARIOS _user2, string _companyId, PrivilegesByUser privilege)
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this._conection = _conection;
            this._user2 = _user2;
            this._companyId = _companyId;
            this.privilege = privilege;
            CargarCombos();
            Actualizar();
        }

        private void TipoCaracteristicasSoftware_Load(object sender, EventArgs e)
        {
            //CargarCombos();

            btnGrabar.Enabled = false;
            gbEdit.Enabled = false;
            gbList.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.dgvRegistro.TableElement.BeginUpdate();
            this.LoadFreightSummary();
            this.dgvRegistro.TableElement.EndUpdate();

            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvRegistro.MasterTemplate.AutoExpandGroups = true;
            this.dgvRegistro.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistro.GroupDescriptors.Clear();
            this.dgvRegistro.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items1 = new GridViewSummaryRowItem();
            items1.Add(new GridViewSummaryItem("chdescripcion", "Count : {0:N2}; ", GridAggregateFunction.Count));
            this.dgvRegistro.MasterTemplate.SummaryRowsTop.Add(items1);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            try
            {
                otipo = new SAS_DispositivoTipoSoftware();
                otipo.id = 0;
                otipo.descripcion = string.Empty;
                otipo.nombreCorto = string.Empty;
                otipo.estado = 0;
                otipo.observación = string.Empty;
                Limpiar();
                Cancelar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMAS");
                return;
            }
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            Actualizar();

            btnGrabar.Enabled = false;
            gbEdit.Enabled = false;
            gbList.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void Actualizar()
        {
            try
            {
                //btnMenu.Enabled = true;
                //gbEdit.Enabled = true;
                //gbList.Enabled = true;
                progressBar1.Visible = false;
                bgwHilo.RunWorkerAsync();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMAS");
                throw;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cancelar();
            btnCancelar.Enabled = true;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            CambiarEstado();
        }

        private void CambiarEstado()
        {
            try
            {
                ObtenerObjeto();
                if (oDetalleTipoSoftware.descripcion != string.Empty)
                {
                    model = new SAS_DispositivoTipoSoftwareController();
                    int resultado = 0;
                    resultado = model.ChangeState("SAS", oDetalleTipoSoftware);
                    if (resultado == 2)
                    {
                        MessageBox.Show("Se cambio el estado correctamente", "Confirmación de anulación");
                        Actualizar();
                    }
                    else if (resultado == 3)
                    {
                        MessageBox.Show("Se cambio el estado correctamente", "Confirmación de Activación");
                        Actualizar();
                    }
                    btnGrabar.Enabled = false;
                    gbEdit.Enabled = false;
                    gbList.Enabled = true;
                    btnEditar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Debe incluir una descripción", "Advertencia del sistema");
                    this.txtDescripcion.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No tiene privilegios para esta acción", "ADVERTENCIA DEL SISTEMA");
            return;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            if (dgvRegistro != null)
            {
                if (dgvRegistro.Rows.Count > 0)
                {
                    Exportar(dgvRegistro);
                }

                else
                {
                    MessageBox.Show("No tiene privilegios para esta acción", "ADVERTENCIA DEL SISTEMA");
                    return;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void TipoCaracteristicasSoftware_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Exportar(RadGridView radGridView)
        {
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(radGridView.ThemeName);
                RadMessageBox.Show("Ingrese nombre al archivo.");
                return;
            }

            fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;
            this.exportVisualSettings = true;
            RunExportToExcelML(fileName, ref openExportFile, radGridView);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("El archivo no pudo ser ejecutado por el sistema.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Abrir Archivo", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private void RunExportToExcelML(string fileName, ref bool openExportFile, RadGridView grilla)
        {
            ExportToExcelML excelExporter = new ExportToExcelML(grilla);
            excelExporter.SheetName = "Listado registros";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
            excelExporter.HiddenColumnOption = HiddenOption.DoNotExport;


            try
            {
                excelExporter.RunExport(fileName);
                RadMessageBox.SetThemeName(grilla.ThemeName);
                DialogResult dr = RadMessageBox.Show("La exportación ha sido generada correctamente. Desea abrir el Archivo?",
                    "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(grilla.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                model = new SAS_DispositivoTipoSoftwareController();
                listado = new List<SAS_DispositivoTipoSoftwareListado>();
                listado = model.GetTypeDevices("SAS");
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvRegistro.DataSource = listado.OrderBy(x => x.descripcion).ToList().ToDataTable<SAS_DispositivoTipoSoftwareListado>();
                dgvRegistro.Refresh();

                //btnMenu.Enabled = true;
                //gbEdit.Enabled = true;
                //gbList.Enabled = true;
                progressBar1.Visible = false;

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerObjeto();
                if (oDetalleTipoSoftware.descripcion != string.Empty)
                {
                    model = new SAS_DispositivoTipoSoftwareController();
                    int resultado = 0;
                    resultado = model.Register("SAS", oDetalleTipoSoftware);
                    if (resultado == 1)
                    {
                        MessageBox.Show("Se actualizó correctamente", "Mensaje del sistema");
                        Actualizar();
                    }
                    else if (resultado == 0)
                    {
                        MessageBox.Show("Se registro correctamente", "Mensaje del sistema");
                        Actualizar();
                    }
                    btnGrabar.Enabled = false;
                    gbEdit.Enabled = false;
                    gbList.Enabled = true;
                    btnEditar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Debe incluir una descripción", "Advertencia del sistema");
                    this.txtDescripcion.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

        }

        private void ObtenerObjeto()
        {
            try
            {
                oDetalleTipoSoftware = new SAS_DispositivoTipoSoftware();
                oDetalleTipoSoftware.id = (this.txtCodigo.Text != string.Empty || this.txtCodigo.Text.Trim() != "") ? Convert.ToInt32(this.txtCodigo.Text.Trim()) : 0;
                oDetalleTipoSoftware.descripcion = (this.txtDescripcion.Text != string.Empty || this.txtDescripcion.Text.Trim() != "") ? (this.txtDescripcion.Text.Trim()) : string.Empty;
                oDetalleTipoSoftware.nombreCorto = (this.txtAbreviatura.Text != string.Empty || this.txtAbreviatura.Text.Trim() != "") ? (this.txtAbreviatura.Text.Trim()) : string.Empty;
                oDetalleTipoSoftware.estado = (this.txtIdEstado.Text != string.Empty || this.txtIdEstado.Text.Trim() != "") ? Convert.ToInt32(this.txtIdEstado.Text.Trim()) : 0;
                oDetalleTipoSoftware.observación = (this.txtObservacion.Text != string.Empty || this.txtObservacion.Text.Trim() != "") ? (this.txtObservacion.Text.Trim()) : string.Empty;
                oDetalleTipoSoftware.enFormatoSolicitud = chkPresenteEnSolicitud.Checked == true ? 1 : 0;
                oDetalleTipoSoftware.tipoSoftware = cboCategoria.SelectedValue.ToString().Trim();

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
        }

        private void dgvRegistro_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region 
                oDetalle = new SAS_DispositivoTipoSoftwareListado();
                if (dgvRegistro != null && dgvRegistro.Rows.Count > 0)
                {
                    if (dgvRegistro.CurrentRow != null)
                    {
                        if (dgvRegistro.CurrentRow.Cells["chid"].Value != null)
                        {
                            if (dgvRegistro.CurrentRow.Cells["chid"].Value.ToString() != string.Empty)
                            {
                                int codigo = (dgvRegistro.CurrentRow.Cells["chid"].Value != null ? Convert.ToInt32(dgvRegistro.CurrentRow.Cells["chid"].Value) : 0);
                                var resultado = listado.Where(x => x.id == codigo).ToList();
                                if (resultado.ToList().Count == 1)
                                {
                                    oDetalle = resultado.Single();
                                    oDetalle.id = codigo;
                                    AsingarObjeto(oDetalle);
                                }
                                else if (resultado.ToList().Count > 1)
                                {
                                    oDetalle = resultado.ElementAt(0);
                                    oDetalle.id = codigo;
                                    AsingarObjeto(oDetalle);
                                }
                                else
                                {
                                    Limpiar();
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Mensaje del sistema");
                return;
            }
        }

        private void AsingarObjeto(SAS_DispositivoTipoSoftwareListado oDetalle)
        {
            try
            {
                this.txtAbreviatura.Text = oDetalle.nombreCorto != null ? oDetalle.nombreCorto.Trim() : string.Empty;
                this.txtCodigo.Text = oDetalle.id != null ? oDetalle.id.ToString().Trim() : "0";
                this.txtDescripcion.Text = oDetalle.descripcion != null ? oDetalle.descripcion.Trim() : string.Empty;
                this.txtEstado.Text = oDetalle.estado != null ? (oDetalle.estado == 1 ? "ACTIVO" : "ANULADO") : "ANULADO";
                this.txtIdEstado.Text = oDetalle.estado != null ? oDetalle.estado.ToString().Trim() : "0";
                //this.cboCategoria.SelectedValue = oDetalle.tipoSoftware != null ? oDetalle.tipoSoftware.ToString().Trim() : "000";
                this.txtObservacion.Text = oDetalle.observación != null ? oDetalle.observación.Trim() : string.Empty;
                this.cboCategoria.SelectedValue = oDetalle.tipoSoftware != null ? oDetalle.tipoSoftware.ToString().Trim() : "000";

                if (oDetalle.enFormatoSolicitud == 1)
                {
                    this.chkPresenteEnSolicitud.Checked = true;
                }
                else
                {
                    this.chkPresenteEnSolicitud.Checked = !true;
                }



            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Mensaje del sistema");
                return;
            }
        }

        private void Limpiar()
        {
            try
            {
                oDetalle = new SAS_DispositivoTipoSoftwareListado();
                oDetalle.id = 0;
                oDetalle.descripcion = string.Empty;
                oDetalle.nombreCorto = string.Empty;
                oDetalle.estado = 0;
                oDetalle.observación = string.Empty;
                oDetalle.enFormatoSolicitud = 0;
                oDetalle.tipoSoftware = "000";
                oDetalle.tipoSoftwareDescripcion = string.Empty;

                this.txtAbreviatura.Text = string.Empty;
                this.txtCodigo.Text = string.Empty;
                this.txtDescripcion.Text = string.Empty;
                this.txtObservacion.Text = string.Empty;
                this.txtEstado.Text = "ACTIVO";
                this.txtIdEstado.Text = "1";
                cboCategoria.SelectedValue = "000";
                this.chkPresenteEnSolicitud.Checked = false;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Mensaje del sistema");
                return;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = false;
            gbEdit.Enabled = false;
            gbList.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void Cancelar()
        {

            btnGrabar.Enabled = !false;
            gbEdit.Enabled = !false;
            gbList.Enabled = !true;
            btnEditar.Enabled = !true;
            btnCancelar.Enabled = !true;

        }



    }
}
