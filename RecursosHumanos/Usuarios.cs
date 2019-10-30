using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using RecursosHumanos.reporte;

namespace RecursosHumanos
{
    public partial class Usuarios : Form
    {
        private bool exportVisualSettings;
        private string fileName;
        private string periodo;
        private string idusuario;
        private string nombres;
        private List<SJ_PrivilegiosListaUsuarioSistemaResult> Listado;
        private UsuarioNeg Modelo;
        private string idestado;
        private string idcodigoGeneral;
        private USUARIO nUsuario;
        public Usuarios()
        {
            InitializeComponent();

            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);
            periodo = this.txtAño.Value.ToString();

            Consultar();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            UsuariosEdicion Ofrm = new UsuariosEdicion();
            Ofrm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //dgvUsuarios.Enabled = true;


            if (nombres != "" && idusuario != "")
            {
                UsuariosEdicion Ofrm = new UsuariosEdicion(periodo, idusuario);
                Ofrm.ShowDialog();
            }

        }

        private void btnExportarLista_Click(object sender, EventArgs e)
        {
            try
            {
                Exportar(this.dgvUsuarios);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

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

            fileName = this.saveFileDialog.FileName.ToString();
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
            excelExporter.SheetName = "Privilegios";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            try
            {
                btnConsultar.Enabled = false;
                txtAño.Enabled = false;
                progressBar.Visible = true;
                periodo = this.txtAño.Value.ToString();
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios != null)
            {
                #region MyRegion
                if (dgvUsuarios.Rows.Count > 0)
                {
                    if (dgvUsuarios.CurrentRow != null)
                    {
                        #region MyRegion
                        if (dgvUsuarios.CurrentRow.Cells["chIDUSUARIO"].Value != null)

                            #region
                            if (dgvUsuarios.CurrentRow.Cells["chNombres"].Value != null)
                            {
                                if (dgvUsuarios.CurrentRow.Cells["chNombres"].Value.ToString().Trim() != "")
                                {
                                    #region MyRegion
                                    nUsuario = new USUARIO();
                                    idusuario = dgvUsuarios.CurrentRow.Cells["chIDUSUARIO"].Value != null ? dgvUsuarios.CurrentRow.Cells["chIDUSUARIO"].Value.ToString().Trim() : "";
                                    nombres = dgvUsuarios.CurrentRow.Cells["chNombres"].Value != null ? dgvUsuarios.CurrentRow.Cells["chNombres"].Value.ToString().Trim() : "";
                                    idestado = dgvUsuarios.CurrentRow.Cells["chEstado"].Value != null ? dgvUsuarios.CurrentRow.Cells["chEstado"].Value.ToString().Trim() : "";
                                    idcodigoGeneral = dgvUsuarios.CurrentRow.Cells["chIdCodigoGeneral"].Value != null ? dgvUsuarios.CurrentRow.Cells["chIdCodigoGeneral"].Value.ToString().Trim() : "";
                                    nUsuario.IDUSUARIO = idusuario;
                                    nUsuario.USR_NOMBRES = nombres;
                                    nUsuario.ESTADO = Convert.ToInt32(idestado);
                                    nUsuario.idCodigoGeneral = idcodigoGeneral;

                                    #endregion
                                }
                                else
                                {
                                    #region Valor en Blanco()
                                    idusuario = "";
                                    nombres = "";
                                    idestado = "";
                                    idcodigoGeneral = "";
                                    #endregion
                                }
                            }
                            else
                            {
                                #region Valor en Blanco()
                                idusuario = "";
                                nombres = "";
                                idestado = "";
                                idcodigoGeneral = "";
                                #endregion
                            }
                            #endregion
                    }
                    else
                    {
                        #region Valor en Blanco()
                        idusuario = "";
                        nombres = "";
                        idestado = "";
                        idcodigoGeneral = "";
                        #endregion
                    }
                        #endregion
                }
                else
                {
                    #region Valor en Blanco()
                    idusuario = "";
                    nombres = "";
                    idestado = "";
                    idcodigoGeneral = "";
                    #endregion
                }
            }
            else
            {
                #region Valor en Blanco()
                idusuario = "";
                nombres = "";
                idestado = "";
                idcodigoGeneral = "";
                #endregion
            }
                #endregion

        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarInformacion();
        }

        private void PresentarInformacion()
        {
            try
            {
                dgvUsuarios.DataSource = Listado.ToDataTable<SJ_PrivilegiosListaUsuarioSistemaResult>();
                dgvUsuarios.Refresh();

                btnConsultar.Enabled = true;
                txtAño.Enabled = true;
                progressBar.Visible = false;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            CargarInformacion();
        }

        private void CargarInformacion()
        {
            try
            {
                Listado = new List<SJ_PrivilegiosListaUsuarioSistemaResult>();
                Modelo = new UsuarioNeg();
                Listado = Modelo.ObtenerListaUsuarioSistema(periodo).ToList();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            if (nombres != "" && idusuario != "")
            {
                UsuariosEdicion Ofrm = new UsuariosEdicion(periodo, idusuario);
                Ofrm.ShowDialog();
            }
        }

        private void btnAltaBaja_Click(object sender, EventArgs e)
        {
            if (idestado != "")
            {

            }
        }

        private void registrarBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idestado != "" && idusuario != "")
            {
                if (idestado != "0")
                {
                    if (idcodigoGeneral != "")
                    {
                        Modelo = new UsuarioNeg();
                        if (Modelo.VerificarFinalizacionContratoTrabajador(periodo, idcodigoGeneral).ToList().Count == 1)
                        {
                            Modelo = new UsuarioNeg();
                            //USUARIO oUsuario = new USUARIO();
                            //oUsuario.IDUSUARIO = idusuario;
                            //oUsuario.IDUSUARIO = idestado;
                            Modelo.CambioEstadoUsuario(periodo, nUsuario);
                            MessageBox.Show("Se ha registrado correctamente el estado del colaborador", "Mensaje de Sistema");
                            Consultar();
                        }
                        else
                        {
                            MessageBox.Show("No se encontro coincidencia entre la fecha de termino de contrato y el periodo actual", "Atención");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tiene asignado un codigo de personal", "Atención");
                    }
                }
                else
                {
                    MessageBox.Show("No tiene el estado para realizar esta operación", "Atención");
                }
            }
        }

        private void registrarAltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idestado != "" && idusuario != "")
            {
                if (idestado != "1")
                {
                    if (idcodigoGeneral != "")
                    {
                        if (Modelo.VerificarFinalizacionAperturaTrabajador(periodo, idcodigoGeneral).ToList().Count == 1)
                        {
                            Modelo = new UsuarioNeg();
                            //USUARIO oUsuario = new USUARIO();
                            //oUsuario.IDUSUARIO = idusuario;
                            //oUsuario.IDUSUARIO = idestado;
                            Modelo.CambioEstadoUsuario(periodo, nUsuario);
                            MessageBox.Show("Se ha registrado correctamente el estado del colaborador", "Mensaje de Sistema");
                            Consultar();
                        }
                        else
                        {
                            MessageBox.Show("No se encontro coincidencia entre la fecha de apertura de contrato y el periodo actual", "Atención");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tiene asignado un codigo de personal", "Atención");
                    }
                }
                else
                {
                    MessageBox.Show("No tiene el estado para realizar esta operación", "Atención");
                }
            }
        }

        private void detalleDePrivilegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nombres != "" && idusuario != "")
            {
                UsuariosEdicion Ofrm = new UsuariosEdicion(periodo, idusuario);
                Ofrm.ShowDialog();
            }
        }

        private void notificarAltaSinVerificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idestado != "" && idusuario != "")
            {
                if (idestado != "1")
                {
                    if (idcodigoGeneral != "")
                    {

                        Modelo = new UsuarioNeg();
                        //USUARIO oUsuario = new USUARIO();
                        //oUsuario.IDUSUARIO = idusuario;
                        //oUsuario.IDUSUARIO = idestado;
                        Modelo.CambioEstadoUsuario(periodo, nUsuario);
                        MessageBox.Show("Se ha registrado correctamente el estado del colaborador", "Mensaje de Sistema");
                        Consultar();
                    }
                    else
                    {
                        MessageBox.Show("No tiene asignado un codigo de personal", "Atención");
                    }
                }
                else
                {
                    MessageBox.Show("No tiene el estado para realizar esta operación", "Atención");
                }
            }
        }

        private void notificarBajaSinVerificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idestado != "" && idusuario != "")
            {
                if (idestado != "0")
                {
                    if (idcodigoGeneral != "")
                    {
                        Modelo = new UsuarioNeg();

                        Modelo = new UsuarioNeg();
                        //USUARIO oUsuario = new USUARIO();
                        //oUsuario.IDUSUARIO = idusuario;
                        //oUsuario.IDUSUARIO = idestado;
                        Modelo.CambioEstadoUsuario(periodo, nUsuario);
                        MessageBox.Show("Se ha registrado correctamente el estado del colaborador", "Mensaje de Sistema");
                        Consultar();

                    }
                    else
                    {
                        MessageBox.Show("No tiene asignado un codigo de personal", "Atención");
                    }
                }
                else
                {
                    MessageBox.Show("No tiene el estado para realizar esta operación", "Atención");
                }
            }
        }


    }
}
