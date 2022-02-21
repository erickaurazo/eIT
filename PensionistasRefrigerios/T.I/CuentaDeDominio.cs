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
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Globalization;
using Telerik.WinControls.Data;
using System.Threading;
using Telerik.WinControls.UI.Localization;

namespace ComparativoHorasVisualSATNISIRA.T.I
{
    public partial class CuentaDeDominio : Form
    {

        private PrivilegesByUser privilege;
        private string _companyId;
        private string _conection;
        private SAS_USUARIOS _user2;
        private string fileName;
        private bool exportVisualSettings;
        private List<SAS_CuentasDominioListado> listado;
        private SAS_CuentasDominioController model;
        private SAS_CuentasDominio odetalle;
        private SAS_CuentasDominioListado odetalleSelecionado;
        private List<SAS_CuentasDominioDetalleByIdResult> listDetails;
        private int lastItem;
        private string msgError;
        private List<SAS_CuentasDominioDetalle> detalleEliminados = new List<SAS_CuentasDominioDetalle>();
        private List<SAS_CuentasDominioDetalle> detalle = new List<SAS_CuentasDominioDetalle>();
        object result;

        public CuentaDeDominio()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            Inicio();
            Actualizar();
        }

        public CuentaDeDominio(string _conection, SAS_USUARIOS _user2, string _companyId, PrivilegesByUser privilege)
        {
            try
            {
                InitializeComponent();
                RadGridLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.GridLocalizationProviderEspanol();
                RadPageViewLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
                RadWizardLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadWizardLocalizationProviderEspañol();
                RadMessageLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
                Inicio();
                this._conection = _conection;
                this._user2 = _user2;
                this._companyId = _companyId;
                this.privilege = privilege;
                Actualizar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            CambiarEstado();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opción no habilitada", "Advertencia del sistema");
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

        private void btnChangeStateDetail_Click(object sender, EventArgs e)
        {
            CambiarEstadoItemDetalle();
        }
   
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AgregarItemDetalle();
        }

        private string ObtenerItemDetalle(int numeroRegistros)
        {
            #region Get item for grid detail() 
            numeroRegistros += 1;
            return numeroRegistros.ToString().PadLeft(3, '0');
            #endregion
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDetail != null)
                {
                    #region delete item() 
                    if (dgvDetail.CurrentRow != null && dgvDetail.CurrentRow.Cells["chId"].Value != null)
                    {
                        //if (MessageBox.Show(this, "¿Desea eliminar el elemento seleccionado?", "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        try
                        {

                            Int32 dispositivoCodigo = (dgvDetail.CurrentRow.Cells["chId"].Value.ToString().Trim() != "" ? Convert.ToInt32(dgvDetail.CurrentRow.Cells["chId"].Value) : 0);
                            if (dispositivoCodigo != 0)
                            {
                                string itemIP = ((dgvDetail.CurrentRow.Cells["chItem"].Value != null | dgvDetail.CurrentRow.Cells["chItem"].Value.ToString().Trim() != string.Empty) ? (dgvDetail.CurrentRow.Cells["chItem"].Value.ToString()) : string.Empty);
                                if (dispositivoCodigo != 0 && itemIP != string.Empty)
                                {

                                    detalleEliminados.Add(new SAS_CuentasDominioDetalle
                                    {
                                        id = dispositivoCodigo,
                                        item = itemIP,
                                    });
                                }
                            }

                            dgvDetail.Rows.Remove(dgvDetail.CurrentRow);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString() + "No se puede eliminar el item selecionado", "MENSAJE DE TEXTO");
                            return;
                        }
                        //}
                    }
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnVerResumen_Click(object sender, EventArgs e)
        {
            VerResumen();
        }
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }
 
        private void CuentaDeDominio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvRegistro_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region 
                odetalleSelecionado = new SAS_CuentasDominioListado();
                if (dgvRegistro != null && dgvRegistro.Rows.Count > 0)
                {
                    if (dgvRegistro.CurrentRow != null)
                    {
                        if (dgvRegistro.CurrentRow.Cells["chId"].Value != null)
                        {
                            if (dgvRegistro.CurrentRow.Cells["chId"].Value.ToString() != string.Empty)
                            {
                                int codigo = (dgvRegistro.CurrentRow.Cells["chId"].Value != null ? (int)Convert.ChangeType(dgvRegistro.CurrentRow.Cells["chId"].Value, typeof(Int32)) : 0);
                                var resultado = listado.Where(x => x.id == codigo).ToList();
                                if (resultado.ToList().Count == 1)
                                {
                                    odetalleSelecionado = resultado.Single();
                                    odetalleSelecionado.id = codigo;
                                    AsignarControlesAObjetoParaRegistro(odetalleSelecionado);
                                }
                                else if (resultado.ToList().Count > 1)
                                {
                                    odetalleSelecionado = resultado.ElementAt(0);
                                    odetalleSelecionado.id = codigo;
                                    AsignarControlesAObjetoParaRegistro(odetalleSelecionado);
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
                throw;
            }

        }

        private void AsignarControlesAObjetoParaRegistro(SAS_CuentasDominioListado oDetalle)
        {
            try
            {
                this.txtCodigo.Text = oDetalle.id != null ? oDetalle.id.ToString().Trim() : string.Empty;
                this.txtIdCodigoGeneral.Text = oDetalle.idcodigoGeneral != null ? oDetalle.idcodigoGeneral.Trim() : string.Empty;
                this.txtNombres.Text = oDetalle.nombres != null ? oDetalle.nombres.Trim() : (oDetalle.nombresCompleto != null ? oDetalle.nombresCompleto.Trim() : string.Empty);
                this.txtCuenta.Text = oDetalle.cuenta != null ? oDetalle.cuenta.Trim() : string.Empty;
                this.txtclave.Text = oDetalle.clave != null ? oDetalle.clave.Trim() : string.Empty;
                this.txtObservaciones.Text = oDetalle.observaciones != null ? oDetalle.observaciones.Trim() : string.Empty;
                this.txtEstado.Text = (oDetalle.estado != null ? Convert.ToInt32(oDetalle.estado) : 1) == 1 ? "ACTIVO" : "ANULADO";
                this.txtCodigoSolicitud.Text = oDetalle.codigoSolicitud != null ? oDetalle.codigoSolicitud.ToString() : string.Empty;

                this.txtPerfilDeAccesoCodigo.Text = oDetalle.idPerfilCuenta != null ? oDetalle.idPerfilCuenta.ToString() : string.Empty;
                this.txtPerfilDeAcceso.Text = oDetalle.perfil != null ? oDetalle.perfil.ToString() : string.Empty;

                if (oDetalle.esCorportativo == 1)
                {
                    chkEsCuentaCorporativa.Checked = true;
                }
                else
                {
                    chkEsCuentaCorporativa.Checked = !true;
                }

                if (oDetalle.vienesDesdeSolicitud == 1)
                {
                    chkActivoEnReporte.Checked = true;
                }
                else
                {
                    chkActivoEnReporte.Checked = !true;
                }

                this.txtFechaDeActivación.Text = oDetalle.fechaActivacion != (DateTime?)null ? oDetalle.fechaActivacion.ToPresentationDate() : string.Empty;
                this.txtFechaBaja.Text = oDetalle.fechaBaja != (DateTime?)null ? oDetalle.fechaBaja.ToPresentationDate() : string.Empty;



                listDetails = new List<SAS_CuentasDominioDetalleByIdResult>();
                SAS_CuentasDominio account = new SAS_CuentasDominio();
                account.id = oDetalle.id;
                listDetails = model.GetDomainAccountsDetailById("SAS", account); // Obtener listado detalle

                lastItem = 0;

                if (listDetails != null)
                {
                    if (listDetails.Count > 0)
                    {
                        lastItem = Convert.ToInt32(listDetails.Max(X => X.item) + 1);
                    }
                }

                dgvDetail.CargarDatos(listDetails.ToDataTable<SAS_CuentasDominioDetalleByIdResult>());
                dgvDetail.Refresh();
                msgError += "OK GRILLA DEtalle ";


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString() + msgError, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            //Thread t = new Thread((ThreadStart)(() =>
            //{
            try
            {
                listado = new List<SAS_CuentasDominioListado>();
                model = new SAS_CuentasDominioController();
                listado = model.GetListOfDomainAccounts("SAS");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
            //}));

            //t.SetApartmentState(ApartmentState.STA);
            //t.Start();
            //t.Join();
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                dgvRegistro.DataSource = listado.OrderBy(x => x.cuenta).ToList().ToDataTable<SAS_CuentasDominioListado>();
                dgvRegistro.Refresh();
                progressBar1.Visible = false;

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

        }

        private void CuentaDeDominio_Load(object sender, EventArgs e)
        {
            btnGrabar.Enabled = false;
            gbEdit.Enabled = false;
            gbList.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        
        private void dgvDetail_KeyUp(object sender, KeyEventArgs e)
        {
            model = new SAS_CuentasDominioController();
            if (((DataGridView)sender).RowCount > 0)
            {
                #region Tipo de detalle() 
                if (((DataGridView)sender).CurrentCell.OwningColumn.Name == "chtipo")
                {
                    if (e.KeyCode == Keys.F3)
                    {
                        frmBusquedaFormatoSimple search = new frmBusquedaFormatoSimple();
                        search.ListaGeneralResultado = model.FeatureType("SAS");
                        search.Text = "Buscar tipo de característica";
                        search.txtTextoFiltro.Text = "";
                        if (search.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            //idRetorno = busquedas.ObjetoRetorno.Codigo;
                            this.dgvDetail.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chidTipo"].Value = search.ObjetoRetorno.Codigo;
                            this.dgvDetail.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chtipo"].Value = search.ObjetoRetorno.Descripcion;
                        }
                    }
                }
                #endregion
            }
        }

        private void btnEnivarCorreo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opción no habilitada", "Advertencia del sistema");
            return;
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opción no habilitada", "Advertencia del sistema");
            return;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opción no habilitada", "Advertencia del sistema");
            return;
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opción no habilitada", "Advertencia del sistema");
            return;
        }


        #region Métodos() 
        public void Inicio()
        {
            try
            {
                Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                Globales.BaseDatos = ConfigurationManager.AppSettings["SAS"].ToString();
                Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                Globales.IdEmpresa = "001";
                Globales.Empresa = "SOCIEDAD AGRICOLA SATURNO";
                Globales.UsuarioSistema = "EAURAZO";
                Globales.NombreUsuarioSistema = "ERICK AURAZO";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.dgvRegistro.TableElement.BeginUpdate();
                this.LoadFreightSummary();
                this.dgvRegistro.TableElement.EndUpdate();

                base.OnLoad(e);
            }
            catch (TargetInvocationException ex)
            {
                result = ex.InnerException.Message;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

        }

        private void LoadFreightSummary()
        {

            try
            {
                this.dgvRegistro.MasterTemplate.AutoExpandGroups = true;
                this.dgvRegistro.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                this.dgvRegistro.GroupDescriptors.Clear();
                this.dgvRegistro.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
                GridViewSummaryRowItem items1 = new GridViewSummaryRowItem();
                items1.Add(new GridViewSummaryItem("chcuenta", "Count : {0:N2}; ", GridAggregateFunction.Count));
                this.dgvRegistro.MasterTemplate.SummaryRowsTop.Add(items1);
            }
            //catch (TargetInvocationException ex)
            //{
            //    result = ex.InnerException.Message;
            //}
            //catch (Exception ex)
            //{
            //    result = ex.Message;
            //}
            catch (FilterExpressionException ex)
            {
                FilterDescriptor wrongFilter = this.dgvRegistro.Columns["chcuenta"].FilterDescriptor;
                double correctValue = 12.5;
                FilterDescriptor filterDescriptor =
                    new FilterDescriptor(wrongFilter.PropertyName, wrongFilter.Operator, correctValue);
                filterDescriptor.IsFilterEditor = wrongFilter.IsFilterEditor;

                this.dgvRegistro.FilterDescriptors.Remove(wrongFilter);
                this.dgvRegistro.FilterDescriptors.Add(filterDescriptor);

                MessageBox.Show(ex.Message.ToString(), "MENSAJE DEL SISTEMAS");
                return;
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

        private void Nuevo()
        {
            try
            {
                Limpiar();
                Editar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMAS");
                return;
            }
        }

        private void Cancelar()
        {
            gbEdit.Enabled = false;
            gbList.Enabled = true;
            btnGrabar.Enabled = false;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void Limpiar()
        {
            #region Limpiar() 
            try
            {
                #region variables en blanco()               
                odetalle = new SAS_CuentasDominio();
                odetalle.id = 0;
                odetalle.idPerfilCuenta = 1;
                odetalle.cuenta = string.Empty;
                odetalle.idcodigoGeneral = string.Empty;
                odetalle.vienesDesdeSolicitud = 0;
                odetalle.estado = 1;
                odetalle.codigoSolicitud = 0;
                odetalle.observaciones = string.Empty;
                odetalle.fechaActivacion = DateTime.Now;
                odetalle.fechaBaja = DateTime.Now;
                odetalle.esCorportativo = 0;
                odetalle.clave = string.Empty;
                odetalle.nombres = string.Empty;

                odetalleSelecionado = new SAS_CuentasDominioListado();
                odetalleSelecionado.id = 0;
                odetalleSelecionado.cuenta = string.Empty;
                odetalleSelecionado.idcodigoGeneral = string.Empty;
                odetalleSelecionado.vienesDesdeSolicitud = 0;
                odetalleSelecionado.estado = 1;
                odetalleSelecionado.codigoSolicitud = 0;
                odetalleSelecionado.observaciones = string.Empty;
                odetalleSelecionado.fechaActivacion = DateTime.Now;
                odetalleSelecionado.fechaBaja = DateTime.Now;
                odetalleSelecionado.esCorportativo = 0;
                odetalleSelecionado.clave = string.Empty;
                odetalleSelecionado.nombres = string.Empty;
                odetalleSelecionado.idPerfilCuenta = 0;
                odetalleSelecionado.perfil = string.Empty;

                this.txtCodigo.Text = "0";
                this.txtEstado.Text = "ACTIVO";
                this.txtIdEstado.Text = "1";
                this.txtCuenta.Text = string.Empty;
                this.txtIdCodigoGeneral.Text = string.Empty;
                this.txtNombres.Text = string.Empty;
                this.txtclave.Text = string.Empty;
                this.txtObservaciones.Text = string.Empty;
                this.chkActivoEnReporte.Checked = false;
                this.chkEsCuentaCorporativa.Checked = false;
                this.txtCodigoSolicitud.Text = string.Empty;
                this.txtPerfilDeAccesoCodigo.Text = string.Empty;
                this.txtPerfilDeAcceso.Text = string.Empty;
                this.txtFechaDeActivación.Text = string.Empty;
                this.txtFechaBaja.Text = string.Empty;
                #endregion
                ClearGridDetail();
                detalle = new List<SAS_CuentasDominioDetalle>();
                detalleEliminados = new List<SAS_CuentasDominioDetalle>();
                lastItem = 0;


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Mensaje del sistema");
                return;
            }
            #endregion
        }

        private void ClearGridDetail()
        {
            try
            {
                if (this.dgvDetail != null)
                {
                    if (this.dgvDetail.Rows.Count > 0)
                    {
                        int tope = dgvDetail.Rows.Count;
                        for (int i = 0; i < tope; i++)
                        {
                            dgvDetail.Rows.RemoveAt(0);
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
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
                return;
            }
        }

        private void VerResumen()
        {
            
        }

        private void Editar()
        {
            gbEdit.Enabled = true;
            gbList.Enabled = false;
            btnGrabar.Enabled = true;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void Consultar()
        {
            Actualizar();

            btnGrabar.Enabled = false;
            gbEdit.Enabled = false;
            gbList.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void Registrar()
        {
            try
            {
                ObtenerObjeto();
                model = new SAS_CuentasDominioController();
                int resultado = model.Register("SAS", odetalle, detalleEliminados, detalle);
                btnGrabar.Enabled = !false;
                btnCancelar.Enabled = !false;
                if (resultado == 0)
                {
                    MessageBox.Show("El registro " + this.txtCodigo.Text.Trim() + " se registró satisfactoriamente", "Confirmación del sistema");
                }
                else if (resultado == 1)
                {
                    MessageBox.Show("El registro " + this.txtCodigo.Text.Trim() + " se actualizó satisfactoriamente", "Confirmación del sistema");
                }
                Actualizar();
                btnGrabar.Enabled = false;
                gbEdit.Enabled = false;
                gbList.Enabled = true;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
                detalleEliminados = new List<SAS_CuentasDominioDetalle>();
                detalle = new List<SAS_CuentasDominioDetalle>();
                lastItem = 0;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ObtenerObjeto()
        {

            try
            {
                odetalle = new SAS_CuentasDominio();
                odetalle.id = Convert.ToInt32(this.txtCodigo.Text);
                odetalle.cuenta = this.txtCuenta.Text.Trim();
                odetalle.idcodigoGeneral = this.txtIdCodigoGeneral.Text.Trim();
                odetalle.vienesDesdeSolicitud = chkActivoEnReporte.Checked == true ? 1 : 0;
                odetalle.estado = this.txtIdEstado.Text.ToString().Trim() == "1" ? 1 : 0;
                odetalle.codigoSolicitud = this.txtCodigoSolicitud.Text != string.Empty ? Convert.ToInt32(this.txtCodigoSolicitud.Text) : 0;
                odetalle.observaciones = this.txtObservaciones.Text.Trim();
                odetalle.fechaActivacion = DateTime.Now;
                odetalle.fechaBaja = DateTime.Now;
                odetalle.esCorportativo = chkEsCuentaCorporativa.Checked == true ? 1 : 0;
                odetalle.clave = this.txtclave.Text.Trim();
                odetalle.nombres = this.txtNombres.Text.Trim();
                odetalle.idPerfilCuenta = this.txtPerfilDeAccesoCodigo.Text.Trim() != null ? Convert.ToInt32(this.txtPerfilDeAccesoCodigo.Text) : 1;

                #region Obtener detalle()
                detalle = new List<SAS_CuentasDominioDetalle>();
                if (this.dgvDetail != null)
                {
                    if (this.dgvDetail.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow fila in this.dgvDetail.Rows)
                        {
                            if (fila.Cells["chId"].Value.ToString().Trim() != String.Empty)
                            {
                                try
                                {
                                    #region Obtener detalle por linea detalle() 
                                    SAS_CuentasDominioDetalle oAcountDetail = new SAS_CuentasDominioDetalle();
                                    oAcountDetail.id = fila.Cells["chId"].Value != null ? Convert.ToInt32(fila.Cells["chId"].Value.ToString().Trim()) : 0;
                                    oAcountDetail.item = fila.Cells["chItem"].Value != null ? fila.Cells["chItem"].Value.ToString().Trim() : string.Empty;
                                    oAcountDetail.idTipo = fila.Cells["chidTipo"].Value != null ? Convert.ToByte(fila.Cells["chidTipo"].Value.ToString().Trim()) : Convert.ToInt32(1);
                                    oAcountDetail.link = fila.Cells["chlink"].Value != null ? fila.Cells["chlink"].Value.ToString().Trim() : string.Empty;
                                    oAcountDetail.descripcion = fila.Cells["chdescripcion"].Value != null ? fila.Cells["chdescripcion"].Value.ToString().Trim() : string.Empty;
                                    oAcountDetail.estado = fila.Cells["chestado"].Value != null ? Convert.ToInt32(fila.Cells["chestado"].Value.ToString().Trim()) : Convert.ToInt32(1);
                                    oAcountDetail.creadoPor = Environment.UserName;
                                    detalle.Add(oAcountDetail);
                                    #endregion
                                }
                                catch (Exception Ex)
                                {
                                    MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                                    return;
                                }

                            }
                        }

                    }
                }


                #endregion


            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
        }

        private void CambiarEstado()
        {
            try
            {

                ObtenerObjeto();
                #region Cambiar Estado
                if (odetalle.cuenta != string.Empty)
                {
                    model = new SAS_CuentasDominioController();
                    int resultado = 0;
                    resultado = model.ChangeState("SAS", odetalle);
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
                    this.txtCuenta.Focus();
                    return;
                }
                #endregion
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
        }

        private void CambiarEstadoItemDetalle()
        {
            try
            {

                if (dgvDetail.CurrentRow.Cells["chestado"].Value.ToString() == "1")
                {
                    dgvDetail.CurrentRow.Cells["chestado"].Value = "0";
                    dgvDetail.CurrentRow.Cells["chestadoDescripcion"].Value = "ANULADO";
                }
                else
                {
                    dgvDetail.CurrentRow.Cells["chestado"].Value = "1";
                    dgvDetail.CurrentRow.Cells["chestadoDescripcion"].Value = "ACTIVO";
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void AgregarItemDetalle()
        {
            try
            {
                #region add Item()
                if (dgvDetail != null)
                {
                    ArrayList array = new ArrayList();
                    array.Add(Convert.ToDecimal(txtCodigo.Text.Trim() != String.Empty ? txtCodigo.Text.Trim() : "0")); // id                 
                    array.Add((ObtenerItemDetalle(lastItem))); // item
                    array.Add(1); // idTipo
                    array.Add("BackUp"); // tipocuenta         
                    array.Add(string.Empty); // link                                                     
                    array.Add(string.Empty); // descripcion
                    array.Add(1); // IdEstado
                    array.Add("ACTIVO"); // Estado                              
                    dgvDetail.AgregarFila(array);
                    lastItem += 1;
                }
                else
                {
                    Formateador.MostrarMensajeAdvertencia(this, "Haga click en la Grilla a Modificar", "Validacion Ingreso de Datos");
                }
                #endregion
            }
            catch (Exception ex)
            {
                Formateador.ControlExcepcion(this, this.Name, ex);
            }
        }
        #endregion

    }
}
