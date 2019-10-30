using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Collections;
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls;
using System.IO;
using System.Configuration;

using TransportistaMto.Datos;
using Transportista.Negocios;

namespace Transportista
{
    public partial class CatalogoPensiones : Telerik.WinControls.UI.RadForm
    {
        private string Periodo;
        private string CodigoEstado;
        private int posicionX;
        private int posicionY;
        private SJ_RHPensionNegocio pensionNeg;
        private List<SJ_RHPensionListaResult> ListadoPension;
        private string CodigoPension;
        private string msg;
        private RadTextBox ControlCaja;
        private SJ_RHPension pension;
        private string NombreArchivo;
        private bool exportVisualSettings;
        private List<SJ_RHPensionTarifaListarXCodigoResult> ListadoTarifasxCodigo;
        private List<SJ_RHPensionTarifa> ListaTarifas;
        private List<SJ_RHPensionTarifa> ListaEliminadosTarifa = new List<SJ_RHPensionTarifa>();
        private string itemTarifa;

        public CatalogoPensiones()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            Inicio();
        }

        public void Inicio()
        {
            try
            {
                Periodo = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + Periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "CHRISTIAN";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Christian LLontop";
            }
            catch (Exception Ex)
            {
                throw Ex;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();

        }

        private void Editar()
        {
            if (dgvPension.Rows.Count > 0)
            {
                if (CodigoEstado != null)
                {
                    if (CodigoEstado != "")
                    {
                        #region
                        if (CodigoEstado != "AN")
                        {
                            #region
                            posicionX = this.dgvPension.CurrentRow.Index;
                            posicionY = this.dgvPension.CurrentColumn.Index;

                            ActivarDesactivarControlEdicion(true);
                            ActivarEdicionGrillaTarifa(true);
                            #endregion
                        }
                        else
                        {
                            RadMessageBox.Show("No tiene el estado para la edición", "Atención");
                        }
                        #endregion
                    }
                    else
                    {
                        RadMessageBox.Show("No tiene el estado para la edición", "Atención");
                    }
                }
                else
                {
                    RadMessageBox.Show("No tiene el estado para la edición", "Atención");
                }
            }
            else
            {
                RadMessageBox.Show("No hay elementos para una edicion", "Atención");
            }
        }

        private void ActivarEdicionGrillaTarifa(bool Estado)
        {
            if (Estado == true)
            {
                // Si el estado es activar (true), solo se activará fecha de Inicio, termino, Observacion, Estado
                for (int x = 0; x < this.dgvPension.ColumnCount; x++)
                {

                    if (
                        //dgvPension.Columns[x].Name == "chTipoRefrigerio" |
                        dgvPension.Columns[x].Name == "chPrecioPersona" |
                        dgvPension.Columns[x].Name == "chDesde" |
                        dgvPension.Columns[x].Name == "chHasta" |
                        dgvPension.Columns[x].Name == "chObservacionContrato" |
                        dgvPension.Columns[x].Name == "chEstadoContrato")
                    {
                        dgvPension.Columns[x].ReadOnly = !Estado;
                    }
                    else
                    {
                        dgvPension.Columns[x].ReadOnly = Estado;
                    }
                }
            }
            else
            {
                for (int x = 0; x < this.dgvPension.ColumnCount; x++)
                {
                    dgvPension.Columns[x].ReadOnly = !Estado;
                }
            }
        }

        private void ActivarDesactivarControlEdicion(bool Estado)
        {
            this.gbMantenimientoRegistros.Enabled = Estado;
            this.dgvPension.Enabled = !(Estado);
        }

        private void Pension_Load(object sender, EventArgs e)
        {
            ObtenerListaPensiones();
        }

        private void ObtenerListaPensiones()
        {
            try
            {
                gbPensiones.Enabled = false;
                gbMantenimientoRegistros.Enabled = false;
                mnPrincipal.Enabled = false;

                pensionNeg = new SJ_RHPensionNegocio();
                ListadoPension = new List<SJ_RHPensionListaResult>();
                ListadoPension = pensionNeg.ListadoPensiones();
                MostrarListaPensiones();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void MostrarListaPensiones()
        {
            try
            {
                this.dgvPension.DataSource = ListadoPension.ToDataTable<SJ_RHPensionListaResult>();
                this.dgvPension.Refresh();
                this.dgvPension.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

                gbPensiones.Enabled = true;
                gbMantenimientoRegistros.Enabled = true;
                mnPrincipal.Enabled = true;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                gbPensiones.Enabled = true;
                gbMantenimientoRegistros.Enabled = true;
                mnPrincipal.Enabled = true;
                return;
            }
            
        }

        private void CargarTarifasxCodigo(bool Estado)
        {
            if (Estado == true)
            {
                pensionNeg = new SJ_RHPensionNegocio();
                ListadoTarifasxCodigo = new List<SJ_RHPensionTarifaListarXCodigoResult>();
                ListadoTarifasxCodigo = pensionNeg.ListadoPensionesxTarifa(Convert.ToInt32(CodigoPension));
                dgvTarifa.CargarDatos(ListadoTarifasxCodigo.ToDataTable<SJ_RHPensionTarifaListarXCodigoResult>());
                dgvTarifa.Refresh();
            }
            else
            {
                pensionNeg = new SJ_RHPensionNegocio();
                ListadoTarifasxCodigo = new List<SJ_RHPensionTarifaListarXCodigoResult>();
                dgvTarifa.CargarDatos(ListadoTarifasxCodigo.ToDataTable<SJ_RHPensionTarifaListarXCodigoResult>());
                dgvTarifa.Refresh();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            try
            {
                ActivarDesactivarControlEdicion(false);
                ActivarEdicionGrillaTarifa(false);
                CargarTarifasxCodigo(true);
            }
            catch (Exception Ex)
            {                
                MessageBox.Show(Ex.Message,"MENSAJE DEL SISTEMA");
                return;
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            LimpiarFormulario();
            ActivarDesactivarControlEdicion(true);
            ActivarEdicionGrillaTarifa(true);
            chkAlmuerzo.Checked = true;
            chkCena.Checked = true;
            chkDesayuno.Checked = true;
            txtRUCNumero.Focus();
        }

        private void LimpiarFormulario()
        {
            this.txtCodigo.Clear();
            this.txtEstado.Text = "ACTIVO";
            this.txtIdEstado.Text = "AC";
            this.txtNombreComercial.Clear();
            this.txtRucDescripcion.Clear();
            this.txtRUCNumero.Clear();
            this.txtNroDNI.Clear();
            this.txtCapacidad.Value = 1;
            this.txtNombresCompletos.Clear();
            chkOtro.Checked = false;
            chkDesayuno.Checked = false;
            chkAlmuerzo.Checked = false;
            chkCena.Checked = false;
            this.txtRUCNumero.Focus();


            ListadoTarifasxCodigo = new List<SJ_RHPensionTarifaListarXCodigoResult>();
            dgvTarifa.CargarDatos(ListadoTarifasxCodigo.ToDataTable<SJ_RHPensionTarifaListarXCodigoResult>());
            dgvTarifa.Refresh();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Grabar()
        {
            if (ValidarFormulario() == true)
            {
                ObtenerObjetoPension();
                pensionNeg = new SJ_RHPensionNegocio();
                this.txtCodigo.Text = pensionNeg.RegistrarPension(pension, ListaTarifas, ListaEliminadosTarifa);
                ObtenerListaPensiones();
                CargarTarifasxCodigo(true);
                RadMessageBox.Show("Operación realizada Satisfactoriamente", "Sistema");
                dgvPension.CurrentRow = dgvPension.Rows[posicionX];
                ActivarDesactivarControlEdicion(false);
            }
            else
            {
                RadMessageBox.Show(msg);
                ControlCaja.Focus();
            }
        }

        private bool ValidarFormulario()
        {
            msg = string.Empty;
            bool Estado = true;
            ControlCaja = new RadTextBox();


            //if (this.txtCodigo.Text == "")
            //{
            //    msg += "No tiene registrado un Codigo de Registro \n";
            //    Estado = false;
            //    ControlCaja = txtCodigo;
            //}


            if (this.txtEstado.Text == "")
            {
                msg += "No tiene registrado un Estado Correcto \n";
                Estado = false;
                ControlCaja = txtCodigo;
            }

            if (this.txtIdEstado.Text == "")
            {
                msg += "No tiene registrado un Estado Correcto \n";
                Estado = false;
                ControlCaja = txtCodigo;
            }

            if (this.txtNombreComercial.Text == "")
            {
                msg += "Debe ingresar una descripcion del nombre comercial valida \n";
                Estado = false;
                ControlCaja = txtNombreComercial;
            }


            if (this.txtRucDescripcion.Text == "")
            {
                msg += "Debe ingresar un RUC valido \n";
                Estado = false;
                ControlCaja = txtNombresCompletos;
            }

            if (this.txtRUCNumero.Text == "")
            {
                msg += "Debe ingresar un RUC valido \n";
                Estado = false;
                ControlCaja = txtNombresCompletos;
            }

            if (this.txtNroDNI.Text == "")
            {
                msg += "Debe ingresar un DNI valido \n";
                Estado = false;
                ControlCaja = txtNroDNI;
            }

            if (this.txtNombresCompletos.Text == "")
            {
                msg += "Debe ingresar un DNI valido \n";
                Estado = false;
                ControlCaja = txtNombresCompletos;
            }
            return Estado;
        }

        private void ObtenerObjetoPension()
        {
            pension = new SJ_RHPension();
            pension.IdPension = this.txtCodigo.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtCodigo.Text.ToString().Trim()) : 0;
            pension.NroRuc = this.txtRUCNumero.Text.ToString().Trim() != "" ? Convert.ToString(this.txtRUCNumero.Text.ToString().Trim()) : "";
            pension.NroDNI = this.txtNroDNI.Text.ToString().Trim() != "" ? Convert.ToString(this.txtNroDNI.Text.ToString().Trim()) : "";
            pension.NombresCompletos = this.txtNombresCompletos.Text.ToString().Trim() != "" ? Convert.ToString(this.txtNombresCompletos.Text.ToString().Trim()) : "";
            pension.PseudoNombre = this.txtNombreComercial.Text.ToString().Trim() != "" ? Convert.ToString(this.txtNombreComercial.Text.ToString().Trim()) : "";

            if (chkDesayuno.Checked == true)
            {
                pension.EsDesayuno = 1;
            }
            else
            {
                pension.EsDesayuno = 0;
            }

            if (chkAlmuerzo.Checked == true)
            {
                pension.EsAlmuerzo = 1;
            }
            else
            {
                pension.EsAlmuerzo = 0;
            }

            if (chkCena.Checked == true)
            {
                pension.EsCena = 1;
            }
            else
            {
                pension.EsCena = 0;
            }

            if (chkOtro.Checked == true)
            {
                pension.EsOtro = 1;
            }
            else
            {
                pension.EsOtro = 0;
            }

            pension.IdEstado = this.txtIdEstado.Text.ToString().Trim() != "" ? Convert.ToString(this.txtIdEstado.Text.ToString().Trim()) : "AC";
            pension.capacidadAtencion = Convert.ToByte(this.txtCapacidad.Value);
            ListaTarifas = new List<SJ_RHPensionTarifa>();
            #region Obtener Detalle de Tarifas x Pension
            if (this.dgvTarifa != null)
            {
                if (this.dgvTarifa.Rows.Count > 0)
                {
                    foreach (DataGridViewRow fila in this.dgvTarifa.Rows)
                    {
                        if (fila.Cells["chTipoRefrigerio"].Value.ToString().Trim() != String.Empty)
                        {
                            try
                            {
                                SJ_RHPensionTarifa oTarifa = new SJ_RHPensionTarifa();
                                oTarifa.IdPension = fila.Cells["chIdPension"].Value != null ? Convert.ToInt32(fila.Cells["chIdPension"].Value.ToString().Trim()) : 0; ;
                                oTarifa.Item = fila.Cells["chItem"].Value != null ? fila.Cells["chItem"].Value.ToString().Trim() : "";
                                oTarifa.TipoRefrigerio = fila.Cells["chTipoRefrigerio"].Value != null ? fila.Cells["chTipoRefrigerio"].Value.ToString().Trim() : "";
                                oTarifa.PrecioPersona = fila.Cells["chPrecioPersona"].Value != null ? Convert.ToDecimal(fila.Cells["chPrecioPersona"].Value.ToString().Trim()) : 0;
                                oTarifa.ValidoDesde = fila.Cells["chValidoDesde"].Value != null ? Convert.ToDateTime(fila.Cells["chValidoDesde"].Value.ToString().Trim()) : (DateTime?)null;
                                oTarifa.ValidoHasta = fila.Cells["chValidoHasta"].Value != null ? Convert.ToDateTime(fila.Cells["chValidoHasta"].Value.ToString().Trim()) : (DateTime?)null;
                                oTarifa.Observacion = fila.Cells["chObservacion"].Value != null ? Convert.ToString(fila.Cells["chObservacion"].Value.ToString().Trim()) : "";
                                oTarifa.IdEstado = fila.Cells["chIdEstado"].Value != null ? fila.Cells["chIdEstado"].Value.ToString().Trim() : "AC";
                                ListaTarifas.Add(oTarifa);
                            }
                            catch (Exception Ex)
                            {
                                throw Ex;
                            }
                        }
                    }
                }
            }
            #endregion
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {

            if (dgvPension.Rows.Count > 0)
            {
                posicionX = this.dgvPension.CurrentRow.Index;
                posicionY = this.dgvPension.CurrentColumn.Index;
                //ObtenerListaPensiones();
                this.bgwHilo.RunWorkerAsync();
                dgvPension.CurrentRow = dgvPension.Rows[posicionX];
            }
            else
            {
               // ObtenerListaPensiones();
                this.bgwHilo.RunWorkerAsync();
            }


        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void Anular()
        {
            if (dgvPension.Rows.Count > 0)
            {
                if (CodigoEstado != null)
                {
                    if (CodigoEstado != "")
                    {
                        #region
                        if (CodigoEstado != "AN")
                        {
                            #region
                            posicionX = this.dgvPension.CurrentRow.Index;
                            posicionY = this.dgvPension.CurrentColumn.Index;

                            pensionNeg = new SJ_RHPensionNegocio();
                            pensionNeg.AnularPension(Convert.ToInt32(CodigoPension));
                            RadMessageBox.Show("Anulado correctamente", "Atención");
                            ObtenerListaPensiones();


                            #endregion
                        }
                        else
                        {
                            RadMessageBox.Show("No tiene el estado para la anulación", "Atención");
                        }
                        #endregion
                    }
                    else
                    {
                        RadMessageBox.Show("No tiene el estado para la anulación", "Atención");
                    }
                }
                else
                {
                    RadMessageBox.Show("No tiene el estado para la anulación", "Atención");
                }
            }
            else
            {
                RadMessageBox.Show("No hay elementos para una anulación", "Atención");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }

        private void EliminarRegistro()
        {
            if (dgvPension.Rows.Count > 0)
            {
                if (CodigoEstado != null)
                {
                    if (CodigoEstado != "")
                    {
                        #region
                        if (CodigoEstado != "AN")
                        {
                            #region
                            posicionX = this.dgvPension.CurrentRow.Index;
                            posicionY = this.dgvPension.CurrentColumn.Index;

                            pensionNeg = new SJ_RHPensionNegocio();
                            pensionNeg.EliminarPension(Convert.ToInt32(CodigoPension));
                            RadMessageBox.Show("Eliminado correctamente", "Atención");
                            ObtenerListaPensiones();

                            if (dgvPension.Rows.Count == 0)
                            {
                                LimpiarFormulario();
                                CargarTarifasxCodigo(false);
                            }

                            #endregion
                        }
                        else
                        {
                            RadMessageBox.Show("No tiene el estado para la eliminación", "Atención");
                        }
                        #endregion
                    }
                    else
                    {
                        RadMessageBox.Show("No tiene el estado para la eliminación", "Atención");
                    }
                }
                else
                {
                    RadMessageBox.Show("No tiene el estado para la eliminación", "Atención");
                }
            }
            else
            {
                RadMessageBox.Show("No hay elementos para una eliminación", "Atención");
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvPension != null)
            {
                if (dgvPension.Rows.Count > 0)
                {
                    Exportar(dgvPension);
                }
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

            NombreArchivo = this.saveFileDialog.FileName;
            bool openExportFile = false;
            this.exportVisualSettings = true;
            RunExportToExcelML(NombreArchivo, ref openExportFile, radGridView);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(NombreArchivo);
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
            excelExporter.SheetName = "Listado Pensiones";
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

        private void btnAgregarTarifa_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario() == true)
            {
                AgregarFilaTarifa();

            }
            else
            {
                RadMessageBox.Show(msg);
                ControlCaja.Focus();
            }
        }

        private void AgregarFilaTarifa()
        {
            try
            {
                if (this.dgvTarifa != null)
                {
                    ArrayList array = new ArrayList();
                    array.Add(this.txtCodigo.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtCodigo.Text.ToString().Trim()) : Convert.ToInt32(0)); // Codigo                   
                    array.Add((AsignarNumeroItemsGrilla(ObtenerUltimoNumeroItem(dgvTarifa)))); // item
                    array.Add(string.Empty); // TipoRefrigerio
                    array.Add(string.Empty); // Refrigerio
                    array.Add(Convert.ToDecimal(0.0)); // PrecioPersona
                    array.Add(DateTime.Now.ToPresentationDate()); // ValidoDesde
                    DateTime? ultimoDiaMes = Convert.ToDateTime("31/12/" + DateTime.Now.Year.ToString());
                    array.Add(ultimoDiaMes); // ValidoHasta                   
                    array.Add(string.Empty); // Observacion
                    array.Add("AC"); // IdEstado
                    array.Add("Activo"); // Estado                                        
                    this.dgvTarifa.AgregarFila(array);
                }
                else
                {
                    Formateador.MostrarMensajeAdvertencia(this, "Haga click en la Grilla a Modificar", "Validacion Ingreso de Datos");
                }
            }
            catch (Exception ex)
            {
                Formateador.ControlExcepcion(this, this.Name, ex);
            }
        }

        private int ObtenerUltimoNumeroItem(DataGridView grilla)
        {
            List<int> numItem = new List<int>();
            if (grilla.Rows.Count > 0)
            {

                foreach (DataGridViewRow filas in grilla.Rows)
                {
                    /* agrego la columna 1, por que en ambos caso la filla items esta situada en la colunmna 1*/
                    numItem.Add((filas.Cells[1].Value) != null ? Convert.ToInt32(filas.Cells[1].Value) : 0);
                }
            }
            else
            {
                numItem.Add(0);
            }

            return numItem.Max();

        }

        private string AsignarNumeroItemsGrilla(int numeroRegistros)
        {
            #region
            string item = "";
            numeroRegistros += 1;

            switch (numeroRegistros.ToString().Length)
            {
                case 1:
                    item = "00" + numeroRegistros.ToString();
                    break;

                case 2:
                    item = "0" + numeroRegistros.ToString();
                    break;

                case 3:
                    item = numeroRegistros.ToString();
                    break;

                default:
                    item = "";
                    break;
            }


            return item;
            #endregion
        }

        private void btnQuitarTarifa_Click(object sender, EventArgs e)
        {
            QuitarLineaTarifa();
        }

        private void QuitarLineaTarifa()
        {
            if (this.dgvTarifa != null)
            {
                #region
                if (this.dgvTarifa.CurrentRow != null)
                {
                    if (MessageBox.Show(this, "¿Desea eliminar el elemento seleccionado?", "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {

                            Int32 Codigo = (this.dgvTarifa.CurrentRow.Cells["chIdPension"].Value != null ? Convert.ToInt32(this.dgvTarifa.CurrentRow.Cells["chIdPension"].Value) : 0);
                            if (Codigo != 0)
                            {
                                string Item = ((this.dgvTarifa.CurrentRow.Cells["chItem"].Value != null | this.dgvTarifa.CurrentRow.Cells["chItem"].Value.ToString().Trim() != string.Empty) ? Convert.ToString(this.dgvTarifa.CurrentRow.Cells["chItem"].Value) : "");
                                if (Item != "")
                                {
                                    ListaEliminadosTarifa.Add(new SJ_RHPensionTarifa
                                    {
                                        IdPension = Codigo,
                                        Item = Item,
                                    });
                                }

                            }

                            dgvTarifa.Rows.Remove(dgvTarifa.CurrentRow);
                        }
                        catch (Exception Ex)
                        {
                            throw Ex;
                        }
                    }
                }
                #endregion
            }
        }

        private void dgvTarifa_KeyUp(object sender, KeyEventArgs e)
        {
            #region
            pensionNeg = new SJ_RHPensionNegocio();
            if (((DataGridView)sender).RowCount > 0)
            {
                if (((DataGridView)sender).CurrentCell.OwningColumn.Name == "chRefrigerio")
                {
                    if (e.KeyCode == Keys.F3)
                    {
                        frmBusquedaFormatoSimple busquedas = new frmBusquedaFormatoSimple();
                        busquedas.ListaGeneralResultado = pensionNeg.ListaRefrigerios();
                        busquedas.Text = "Buscar Refrigerios";
                        busquedas.txtTextoFiltro.Text = "";
                        if (busquedas.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            //idRetorno = busquedas.ObjetoRetorno.Codigo;
                            this.dgvTarifa.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chTipoRefrigerio"].Value = busquedas.ObjetoRetorno.Codigo;
                            this.dgvTarifa.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chRefrigerio"].Value = busquedas.ObjetoRetorno.Descripcion;
                        }
                    }
                }
            }
            #endregion
        }

        private void dgvTarifa_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvTarifa != null)
            {
                if (this.dgvTarifa.CurrentRow != null)
                {
                    itemTarifa = dgvTarifa.CurrentRow.Cells["chItem"].Value.ToString().Trim();
                }
            }
        }

        private void btnAltaTarifa_Click(object sender, EventArgs e)
        {
            if (itemTarifa != null)
            {
                if (itemTarifa != "")
                {
                    dgvTarifa.CurrentRow.Cells["chIdEstado"].Value = "AC";
                    dgvTarifa.CurrentRow.Cells["chEstado"].Value = "Activo";
                }
            }

        }

        private void btnAltaBaja_Click(object sender, EventArgs e)
        {
            if (itemTarifa != null)
            {
                if (itemTarifa != "")
                {
                    dgvTarifa.CurrentRow.Cells["chIdEstado"].Value = "CR";
                    dgvTarifa.CurrentRow.Cells["chEstado"].Value = "Cerrado";
                }
            }

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
        }

        private void btnRUC_Click(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            ObtenerListaPensiones();
        }

        private void CatalogoPensiones_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void dgvPension_SelectionChanged(object sender, EventArgs e)
        {
            #region Limpiar Grilla Tarifa
            CargarTarifasxCodigo(false);
            #endregion
            if (dgvPension.Rows.Count > 0)
            {
                #region
                if (dgvPension.CurrentRow != null)
                {
                    try
                    {
                        if (dgvPension.CurrentRow.Cells["chIdPension"].Value != null)
                        {
                            CodigoPension = dgvPension.CurrentRow.Cells["chIdPension"].Value.ToString().Trim();
                            this.txtCodigo.Text = CodigoPension;
                            this.txtEstado.Text = dgvPension.CurrentRow.Cells["chEstado"].Value.ToString().Trim();
                            CodigoEstado = dgvPension.CurrentRow.Cells["chIdEstado"].Value.ToString().Trim();
                            this.txtIdEstado.Text = CodigoEstado;
                            this.txtNombreComercial.Text = dgvPension.CurrentRow.Cells["chPseudoNombre"].Value.ToString().Trim();
                            this.txtRucDescripcion.Text = dgvPension.CurrentRow.Cells["chRazonSocial"].Value.ToString().Trim();
                            this.txtRUCNumero.Text = dgvPension.CurrentRow.Cells["chNroRuc"].Value.ToString().Trim();
                            this.txtNroDNI.Text = dgvPension.CurrentRow.Cells["chNroDNI"].Value.ToString().Trim();
                            this.txtNombresCompletos.Text = dgvPension.CurrentRow.Cells["chNombresCompletos"].Value.ToString().Trim();
                            this.txtCapacidad.Value = dgvPension.CurrentRow.Cells["chcapacidadAtencion"].Value != null ? Convert.ToInt32(dgvPension.CurrentRow.Cells["chcapacidadAtencion"].Value) : 1;

                            #region Desayuno()
                            if (dgvPension.CurrentRow.Cells["chEsDesayuno"].Value != null)
                            {
                                if (Convert.ToInt32(dgvPension.CurrentRow.Cells["chEsDesayuno"].Value) == 1)
                                {
                                    chkDesayuno.Checked = true;
                                }
                                else
                                {
                                    chkDesayuno.Checked = false;
                                }
                            }
                            else
                            {
                                chkDesayuno.Checked = false;
                            }
                            #endregion

                            #region Almuerzo()
                            if (dgvPension.CurrentRow.Cells["chEsAlmuerzo"].Value != null)
                            {
                                if (Convert.ToInt32(dgvPension.CurrentRow.Cells["chEsAlmuerzo"].Value) == 1)
                                {
                                    chkAlmuerzo.Checked = true;
                                }
                                else
                                {
                                    chkAlmuerzo.Checked = false;
                                }
                            }
                            else
                            {
                                chkAlmuerzo.Checked = false;
                            }
                            #endregion

                            #region Cena()
                            if (dgvPension.CurrentRow.Cells["chEsCena"].Value != null)
                            {
                                if (Convert.ToInt32(dgvPension.CurrentRow.Cells["chEsCena"].Value) == 1)
                                {
                                    chkCena.Checked = true;
                                }
                                else
                                {
                                    chkCena.Checked = false;
                                }
                            }
                            else
                            {
                                chkCena.Checked = false;
                            }
                            #endregion

                            #region Otros()
                            if (dgvPension.CurrentRow.Cells["chEsOtro"].Value != null)
                            {
                                if (Convert.ToInt32(dgvPension.CurrentRow.Cells["chEsOtro"].Value) == 1)
                                {
                                    chkOtro.Checked = true;
                                }
                                else
                                {
                                    chkOtro.Checked = false;
                                }
                            }
                            else
                            {
                                chkOtro.Checked = false;
                            }
                            #endregion

                            #region Grilla Tarifa x Codigo
                            CargarTarifasxCodigo(true);
                            #endregion
                        }
                        else
                        {
                            #region
                            this.txtCodigo.Clear();
                            this.txtEstado.Clear();
                            this.txtIdEstado.Clear();
                            this.txtNombreComercial.Clear();
                            this.txtRucDescripcion.Clear();
                            this.txtRUCNumero.Clear();
                            this.txtNroDNI.Clear();
                            this.txtNombresCompletos.Clear();
                            chkOtro.Checked = false;
                            chkDesayuno.Checked = false;
                            chkAlmuerzo.Checked = false;
                            chkCena.Checked = false;
                            CodigoEstado = "";
                            #endregion
                        }
                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                }
                #endregion
            }
        }

        private void txtRUCNumero_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txtRUCNumero_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtRUCNumero_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void txtRUCNumero_Leave(object sender, EventArgs e)
        {
            if (this.txtRUCNumero.Text.Trim() != string.Empty)
            {
                //this.txtNombresCompletos.Clear();
                if (EsNumero(this.txtRUCNumero.Text.Trim()) == true)
                {
                    this.txtNombresCompletos.Text = txtRucDescripcion.Text.Trim().ToUpper();
                }                
            }
            

            if (txtRUCNumero.Text.Trim() != string.Empty && txtRUCNumero.Text.Trim().Length == 11)
            {
                //this.txtRUCNumero.Clear();
                if (EsNumero(this.txtRUCNumero.Text.Trim()) == true)
                {
                    txtNroDNI.Text = txtRUCNumero.Text.Substring(2, 8);
                }
            }
        }

        private void dgvPension_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender,e);            
        }

       
        private void EdicionControlesTeclado(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Editar();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                Nuevo();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.A)
            {
                Anular();
            }

            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }
        }



        private void gbPensiones_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void gbMantenimientoRegistros_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void btnGrabar_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void gbTipoRefrigerio_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void dgvTarifa_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void txtRucDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void txtNroDNI_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void txtNombresCompletos_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void txtNombreComercial_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void chkDesayuno_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void chkAlmuerzo_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void chkCena_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void chkOtro_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void txtCapacidad_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void btnRUC_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void CatalogoPensiones_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void mnPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void stsBarraEstado_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void txtEstado_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private void txtIdEstado_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionControlesTeclado(sender, e);
        }

        private Boolean EsNumero(String numeroRuc)
        {
            try
            {
                int.Parse(numeroRuc);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

    }
}
