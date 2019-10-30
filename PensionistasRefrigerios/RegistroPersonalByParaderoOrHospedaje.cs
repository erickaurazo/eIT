using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Collections;
using TransportistaMto.Datos;
using Transportista.Negocios;

using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Threading;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class RegistroPersonalByParaderoOrHospedaje : Form
    {
        private string periodo;
        private SJM_PersonaParaderoNegocios modelo;
        private List<SJM_PersonaParadero> listadoPersonalParadero;
        private SJM_PersonaParadero oSJM_PersonaParadero;
        private SJM_PersonaParadero oPersonaParadero;
        private string nombreArchivo;



        public RegistroPersonalByParaderoOrHospedaje()
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
                periodo = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JUAN SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void RegistroPersonalByParaderoOrHospedaje_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RegistroPersonalByParaderoOrHospedaje_Load(object sender, EventArgs e)
        {
            try
            {
                Listar();
                gbMantenimientoRegistros.Enabled = false;
                gbListadoParaderos.Enabled = true;
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnAtras.Enabled = false;
                btnAnular.Enabled = false;
                btnEliminar.Enabled = false;
                btnExportar.Enabled = true;
                btnSalir.Enabled = false;
                btnActualizarLista.Enabled = true;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Environment.MachineName.ToString().Trim() == "EAURAZOC" || Environment.MachineName.ToString().Trim() == "JGUERREROD" || Environment.MachineName.ToString().Trim() == "CLLONTOPF")
            {
                Eliminar();
            }
            else
            {
                MessageBox.Show("No tiene privilegios para realizar esta operación", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSubEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnSubAnularActivar_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void btnSubEliminar_Click(object sender, EventArgs e)
        {
            if (Environment.MachineName.ToString().Trim() == "EAURAZOC" || Environment.MachineName.ToString().Trim() == "JGUERREROD" || Environment.MachineName.ToString().Trim() == "CLLONTOPF")
            {
                Eliminar();
            }
            else
            {
                MessageBox.Show("No tiene privilegios para realizar esta operación", "MENSAJE DEL SISTEMA");
                return;
            }


        }

        private void Exportar()
        {
            if (this.dgvPersonal != null && dgvPersonal.Rows.Count > 0)
            {
                GenerarProcesoAExportar(this.dgvPersonal);
            }
        }

        private void Anular()
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;
            if (oSJM_PersonaParadero != null && (oSJM_PersonaParadero.estado == 1 || oSJM_PersonaParadero.estado == 0))
            {
                modelo = new SJM_PersonaParaderoNegocios();
                modelo.CambiarEstadoDocumento(periodo, oSJM_PersonaParadero);
                Listar();
            }
        }

        private void Atras()
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;
        }

        private void Grabar()
        {
            try
            {
                if (this.txtPersonalCodigo.Text.ToString().Trim() != "" && this.txtParaderoCodigo.Text.ToString().Trim() != "")
                {
                    #region Obtener objeto()
                    oPersonaParadero = new SJM_PersonaParadero();
                    oPersonaParadero.Id = Convert.ToInt32(this.txtId.Text);
                    oPersonaParadero.idCodigoPersonalGeneral = this.txtPersonalCodigo.Text.ToString().Trim();
                    oPersonaParadero.dniTrabajador = this.txtPersonalNumeroDocumento.Text.ToString().Trim();
                    oPersonaParadero.NombresTrabajador = this.txtPersonalNombresCompletos.Text.ToString().Trim();
                    oPersonaParadero.Fecha = DateTime.Now;
                    oPersonaParadero.FechaTransferencia = DateTime.Now;
                    oPersonaParadero.IdParadero = this.txtParaderoCodigo.Text.ToString().Trim();
                    oPersonaParadero.paradero = this.txtParaderoDescripcion.Text.ToString().Trim();
                    oPersonaParadero.direccion = this.txtDireccion.Text.ToString().Trim();
                    oPersonaParadero.estado = this.txtEstado.Text == "Activo".ToUpper() ? 1 : 0;
                    oPersonaParadero.contacto = txtContacto.Text.Trim();
                    oPersonaParadero.nroContacto = this.txtNumeroContacto.Text.Trim();

                    if (ValidarDuplicidadPersonal(periodo, oPersonaParadero) == false)
                    {
                        modelo.Registrar(periodo, oPersonaParadero);
                        MessageBox.Show("Registrado correctamente", "MENSAJE DEL SISTEMA");
                        Listar();
                        gbMantenimientoRegistros.Enabled = false;
                        gbListadoParaderos.Enabled = true;
                        btnNuevo.Enabled = true;
                        btnEditar.Enabled = true;
                        btnActualizarLista.Enabled = true;
                        btnGrabar.Enabled = false;
                        btnAtras.Enabled = false;
                        btnAnular.Enabled = false;
                        btnEliminar.Enabled = false;
                        btnExportar.Enabled = true;
                        btnSalir.Enabled = false;
                    }
                    else
                    {
                        //MessageBox.Show("Ya hay un colaborador registrado en la lista ", "MENSAJE DEL SISTEMA");
                        #region Editar()
                        modelo.Registrar(periodo, oPersonaParadero);
                        MessageBox.Show("Actualizado correctamente", "MENSAJE DEL SISTEMA");
                        Listar();
                        gbMantenimientoRegistros.Enabled = false;
                        gbListadoParaderos.Enabled = true;
                        btnNuevo.Enabled = true;
                        btnEditar.Enabled = true;
                        btnActualizarLista.Enabled = true;
                        btnGrabar.Enabled = false;
                        btnAtras.Enabled = false;
                        btnAnular.Enabled = false;
                        btnEliminar.Enabled = false;
                        btnExportar.Enabled = true;
                        btnSalir.Enabled = false;
                        #endregion                                                
                    }

                    #endregion
                }
                else
                {
                    MessageBox.Show("Ingrese codigo del personal valido & información del paradero ", "MENSAJE DEL SISTEMA");
                    return;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private bool ValidarDuplicidadPersonal(string periodo, SJM_PersonaParadero oPersonaParadero)
        {
            bool estado = false;
            if (periodo != null && oPersonaParadero.dniTrabajador != null)
            {
                modelo = new SJM_PersonaParaderoNegocios();
                estado = modelo.ValidarDuplicidadPersonal(periodo, oPersonaParadero);
            }

            return estado;
        }



        private void GenerarProcesoAExportar(RadGridView radGridView)
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

            nombreArchivo = this.saveFileDialog.FileName;
            bool openExportFile = false;
            this.exportVisualSettings = true;
            RunExportToExcelML(nombreArchivo, ref openExportFile, radGridView);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(nombreArchivo);
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
            excelExporter.SheetName = "Lista de Paraderos";
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

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.B | Keys.Control | Keys.Alt | Keys.Shift:
                    // ... Process Shift+Ctrl+Alt+B ...

                    return true; // signal that we've processed this key
            }

            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }

        private void Listar()
        {

            BarraSuperior.Enabled = false;
            ProgressBar.Visible = true;
            periodo = DateTime.Now.Year.ToString();
            bgwHilo.RunWorkerAsync();
        }

        private void CambiarEstado()
        {

        }

        private void Eliminar()
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;
            if (oSJM_PersonaParadero != null && (oSJM_PersonaParadero.estado == 1 || oSJM_PersonaParadero.estado == 0))
            {
                modelo = new SJM_PersonaParaderoNegocios();
                modelo.Eliminar(periodo, oSJM_PersonaParadero);
                Listar();
            }
        }

        private void Editar()
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;

            if (oSJM_PersonaParadero != null && oSJM_PersonaParadero.estado == 1)
            {
                gbMantenimientoRegistros.Enabled = true;
                btnActualizarLista.Enabled = false;
                gbListadoParaderos.Enabled = false;
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                btnAtras.Enabled = true;
                btnAnular.Enabled = true;
                btnEliminar.Enabled = true;
                btnExportar.Enabled = false;
                btnSalir.Enabled = true;
                this.txtPersonalCodigo.Focus();

            }
        }

        private void Nuevo()
        {
            oPersonaParadero = new SJM_PersonaParadero();
            LimpiarControlesFormularioMantenimiento();
            btnActualizarLista.Enabled = false;
            gbListadoParaderos.Enabled = false;
            gbMantenimientoRegistros.Enabled = true;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnAtras.Enabled = true;
            btnAnular.Enabled = true;
            btnEliminar.Enabled = true;
            btnExportar.Enabled = false;
            btnSalir.Enabled = true;
            this.txtEstado.Text = "ACTIVO";

            this.txtPersonalCodigo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            gbMantenimientoRegistros.Enabled = false;
            gbListadoParaderos.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnActualizarLista.Enabled = true;
            btnGrabar.Enabled = false;
            btnAtras.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnExportar.Enabled = true;
            btnSalir.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {

                modelo = new SJM_PersonaParaderoNegocios();
                listadoPersonalParadero = new List<SJM_PersonaParadero>();
                listadoPersonalParadero = modelo.ObtenerListadoPersonalParadero(periodo).ToList();


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
                dgvPersonal.DataSource = listadoPersonalParadero.ToDataTable<SJM_PersonaParadero>();
                dgvPersonal.Refresh();

                if (listadoPersonalParadero != null && listadoPersonalParadero.ToList().Count > 0)
                {
                    ResaltarResultados(dgvPersonal);
                }
                BarraSuperior.Enabled = true;
                ProgressBar.Visible = false;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                BarraSuperior.Enabled = true;
                return;
            }
        }

        private void ResaltarResultados(RadGridView grilla)
        {
            if (grilla != null && grilla.Rows.Count > 0)
            {
                for (int i = 0; i < grilla.Rows.Count; i++)
                {
                    if (grilla.Rows[i].Cells["chestado"].Value.ToString().Trim().ToUpper() == "0".ToUpper())
                    {
                        for (int j = 0; j < grilla.Columns.Count; j++)
                        {
                            grilla.Rows[i].Cells[j].Style.CustomizeFill = true;
                            grilla.Rows[i].Cells[j].Style.DrawFill = true;
                            grilla.Rows[i].Cells[j].Style.BackColor = Utiles.blancoHumo3D;
                            //dgvRegistros.Rows[i].Cells[j].Style.Font = new Font("Tahoma", 8, FontStyle.Bold); //
                        }
                    }
                }
            }
        }

        private void dgvPersonal_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControlesFormularioMantenimiento();
            btnSubAnularActivar.Enabled = false;
            btnSubEdicion.Enabled = false;
            btnSubEditar.Enabled = false;
            btnSubEliminar.Enabled = false;

            oSJM_PersonaParadero = new SJM_PersonaParadero();
            if (this.dgvPersonal != null && dgvPersonal.Rows.Count > 0)
            {
                if (dgvPersonal.CurrentRow != null && dgvPersonal.CurrentRow.Cells["chId"].Value != null && dgvPersonal.CurrentRow.Cells["chId"].Value.ToString().Trim() != "")
                {
                    this.txtId.Text = dgvPersonal.CurrentRow.Cells["chId"].Value.ToString().Trim();
                    this.txtPersonalCodigo.Text = dgvPersonal.CurrentRow.Cells["chidCodigoPersonalGeneral"].Value.ToString().Trim();
                    this.txtPersonalNombresCompletos.Text = dgvPersonal.CurrentRow.Cells["chNombresTrabajador"].Value != null ? dgvPersonal.CurrentRow.Cells["chNombresTrabajador"].Value.ToString().Trim() : "";
                    this.txtPersonalNumeroDocumento.Text = dgvPersonal.CurrentRow.Cells["chdniTrabajador"].Value != null ? dgvPersonal.CurrentRow.Cells["chdniTrabajador"].Value.ToString().Trim() : "";
                    this.txtEstado.Text = dgvPersonal.CurrentRow.Cells["chEstado"].Value.ToString() == "1" ? "Activo".ToUpper() : "Anulado".ToUpper();
                    this.txtDireccion.Text = dgvPersonal.CurrentRow.Cells["chDireccion"].Value != null ? dgvPersonal.CurrentRow.Cells["chDireccion"].Value.ToString().Trim() : "";
                    string paradero = (dgvPersonal.CurrentRow.Cells["chIdParadero"].Value != null || dgvPersonal.CurrentRow.Cells["chIdParadero"].Value.ToString().Trim() != "") ? dgvPersonal.CurrentRow.Cells["chIdParadero"].Value.ToString() : "";
                    this.txtContacto.Text = dgvPersonal.CurrentRow.Cells["chContacto"].Value != null ? dgvPersonal.CurrentRow.Cells["chContacto"].Value.ToString().Trim() : "";
                    this.txtNumeroContacto.Text = dgvPersonal.CurrentRow.Cells["chnroContacto"].Value != null ? dgvPersonal.CurrentRow.Cells["chnroContacto"].Value.ToString().Trim() : "";
                    string[] words = paradero.Split('-');
                    this.txtParaderoCodigo.Text = words[0].ToString().Trim();
                    this.txtParaderoDescripcion.Text = words[1].ToString().Trim();
                    oSJM_PersonaParadero = listadoPersonalParadero.Where(x => x.Id.ToString().Trim() == dgvPersonal.CurrentRow.Cells["chId"].Value.ToString().Trim()).Single();
                    btnSubAnularActivar.Enabled = true;
                    btnSubEdicion.Enabled = true;
                    btnSubEditar.Enabled = true;
                    btnSubEliminar.Enabled = true;
                    btnAnular.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
        }

        private void LimpiarControlesFormularioMantenimiento()
        {
            this.txtPersonalCodigo.Clear();
            this.txtPersonalNombresCompletos.Clear();
            this.txtPersonalNumeroDocumento.Clear();
            this.txtEstado.Clear();
            txtContacto.Clear();
            this.txtNumeroContacto.Clear();
            this.txtParaderoDescripcion.Clear();
            this.txtParaderoCodigo.Clear();
            this.txtId.Text = "0";
            this.txtDireccion.Clear();

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        public bool exportVisualSettings { get; set; }

        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }

            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }

        }

        private void btnGrabar_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }

            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }
        }

        private void subMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void gbMantenimientoRegistros_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }

            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }



        }

        private void dgvPersonal_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Editar();
            }

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Z)
            {
                Atras();
            }

        }

        private void txtPersonalNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }
        }

        private void txtPersonalNombresCompletos_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }
        }

        private void txtParaderoCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }
        }

        private void txtParaderoDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }
        }

        private void txtEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }
        }

        private void txtPersonalCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }
        }

        private void gbListadoParaderos_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Editar();
            }

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Z)
            {
                Atras();
            }

        }

        private void RegistroPersonalByParaderoOrHospedaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }

            if (e.KeyData == (Keys.Escape))
            {
                Cancelar();
            }

            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Cancelar();
            }

        }

        private void bgwHilo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            ProgressBar.Value = e.ProgressPercentage;
        }

        private void btnPersonalBuscar_Leave(object sender, EventArgs e)
        {
            string[] cadena = this.txtPersonalNombresCompletos.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPersonal(cadena);
            }



        }

        private void txtPersonalCodigo_Leave(object sender, EventArgs e)
        {
            string[] cadena = this.txtPersonalNombresCompletos.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPersonal(cadena);
            }
        }

        private void AsignarDatosPersonal(string[] ncadena)
        {
            this.txtPersonalNombresCompletos.Text = ncadena[1].ToString().Trim();
            this.txtPersonalNumeroDocumento.Text = ncadena[0].ToString().Trim();
        }

        private void btnPersonalBuscar_Click(object sender, EventArgs e)
        {
            string[] cadena = this.txtPersonalNombresCompletos.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPersonal(cadena);
            }
        }

        private void txtPersonalCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPersonalNumeroDocumento_Leave(object sender, EventArgs e)
        {
            string[] cadena = this.txtPersonalNombresCompletos.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPersonal(cadena);
            }
        }

        private void txtPersonalNombresCompletos_Leave(object sender, EventArgs e)
        {
            string[] cadena = this.txtPersonalNombresCompletos.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPersonal(cadena);
            }
        }

        private void barraPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Editar();
            }

            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.Z)
            {
                Atras();
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {

        }

        private void txtNumeroContacto_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
