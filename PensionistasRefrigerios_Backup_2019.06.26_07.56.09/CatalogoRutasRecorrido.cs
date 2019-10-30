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
using Transportista.Negocios;

using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class CatalogoRutasRecorrido : Telerik.WinControls.UI.RadForm
    {
        private string Periodo;
        private List<SJ_RHListaRutasResult> ListadoRutas;
        private string CodigoRuta;
        private string CodigoEstado;
        private int posicionX;
        private int posicionY;
        private string Mensaje;
        private SJ_RHRuta oRuta;
        private SJ_RHRutaNegocios rutaNeg;
        private bool exportVisualSettings;
        private string fileName;
        public CatalogoRutasRecorrido()
        {
            InitializeComponent();
            Inicio();
        }

        private void Inicio()
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

        private void FletePorMovilidad_Load(object sender, EventArgs e)
        {

            gbTransportista.Enabled = false;
            gbMantenimientoRegistros.Enabled = false;
            btnMenu.Enabled = false;
            bgwHilo.RunWorkerAsync();
        }

        private void ObtenerListaRutas()
        {
            SJ_RHRutaNegocios RutaNeg = new SJ_RHRutaNegocios();
            ListadoRutas = new List<SJ_RHListaRutasResult>();
            ListadoRutas = RutaNeg.ListarRutasDeRecorridos();

        }

        private void MostrarListarRutas()
        {
            this.dgvRutas.DataSource = ListadoRutas.ToDataTable<SJ_RHListaRutasResult>();
            this.dgvRutas.Refresh();
            this.dgvRutas.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ActivarDesactivarControlEdicion(bool Estado)
        {
            this.gbMantenimientoRegistros.Enabled = Estado;
            this.gbTransportista.Enabled = !(Estado);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActivarDesactivarControlEdicion(false);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosCabecera() == true)
            {
                try
                {
                    ObtenerObjeto("RUTAS");
                    RegistrarObjeto(oRuta);                    
                    RadMessageBox.Show("Operación realizada Satisfactoriamente", "Sistema");
                    dgvRutas.CurrentRow = dgvRutas.Rows[posicionX];
                    ActivarDesactivarControlEdicion(false);

                    gbTransportista.Enabled = false;
                    gbMantenimientoRegistros.Enabled = false;
                    btnMenu.Enabled = false;
                    bgwHilo.RunWorkerAsync();

                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
            else
            {
                RadMessageBox.Show(Mensaje);
            }
        }

        private void RegistrarObjeto(SJ_RHRuta oRuta)
        {
            try
            {
                if (oRuta == null)
                {
                    RadMessageBox.Show("No se puede guardar un ", "");
                }
                else
                {
                    rutaNeg = new SJ_RHRutaNegocios();
                    Int32 Codigo = rutaNeg.Registrar(oRuta);
                    this.txtCodigo.Text = Codigo.ToString();
                }


            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void ObtenerObjeto(string Objeto)
        {
            try
            {
                switch (Objeto)
                {
                    case "RUTAS":
                        #region Obtener Objeto Transportista()
                        try
                        {
                            oRuta = new SJ_RHRuta();
                            oRuta.Id = this.txtCodigo.Text.ToString() != "" ? Convert.ToInt32(this.txtCodigo.Text.ToString()) : 0;
                            oRuta.RutaOrigen = this.txtOrigenId.Text.ToString() != "" ? this.txtOrigenId.Text.ToString() : "";
                            oRuta.RutaDestino = this.txtDestinoId.Text.ToString() != "" ? this.txtDestinoId.Text.ToString() : "";
                            oRuta.Distancia = this.txtDistancia.Text.ToString() != "" ? Convert.ToDecimal(this.txtDistancia.Text.ToString()) : 0;
                            oRuta.TiempoViaje = this.txtDuracion.Text.ToString() != "" ? Convert.ToDecimal(this.txtDuracion.Text.ToString()) : 0;
                            oRuta.Observacion = this.txtObservacion.Text.ToString() != "" ? this.txtObservacion.Text.ToString() : "";
                            oRuta.IdEstado = this.txtIdEstado.Text.ToString();
                            oRuta.abreviaturaRutaOrigen = txtAbreviaturaRutaOrigen.Text.ToString() != "" ? this.txtAbreviaturaRutaOrigen.Text.ToString() : "";
                            oRuta.descripcionCortaOrigen = txtDescripcionCortaRutaOrigen.Text.ToString() != "" ? this.txtDescripcionCortaRutaOrigen.Text.ToString() : "";
                            oRuta.abreviaturaRuraDestino = txtAbreviaturaRutaDestino.Text.ToString() != "" ? this.txtAbreviaturaRutaDestino.Text.ToString() : "";
                            oRuta.descripcionCortaDestino = txtDescripcionCortaRutaDestino.Text.ToString() != "" ? this.txtDescripcionCortaRutaDestino.Text.ToString() : "";
                            oRuta.esIngreso = chkEsIngreso.Checked == true ? "1" : "0";
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString() + "\n Obtener Objeto de Transportista", "MENSAJE DE SISTEMA");
                            return;
                        }

                        #endregion
                        break;

                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "\n Capturar datos para registro", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private bool ValidarDatosCabecera()
        {
            Boolean estado = true;

            Mensaje = "";


            if (txtEstado.Text.ToString().Trim() == "")
            {
                Mensaje += "El documento debe tener un estado \n";
                estado = false;
            }

            if (txtOrigenId.Text.ToString().Trim() == "")
            {
                Mensaje += "El documento debe tener la ruta origen \n";
                estado = false;
            }

            if (txtDestinoId.Text.ToString().Trim() == "")
            {
                Mensaje += "El documento debe tener la ruta destino \n";
                estado = false;
            }


            if (txtDistancia.Text.ToString().Trim() == "")
            {
                Mensaje += "El documento debe tener la distancia aproximada \n";
                estado = false;
            }

            if (txtDuracion.Text.ToString().Trim() == "")
            {
                Mensaje += "El documento debe tener una duración aproximada del recorrido \n";
                estado = false;
            }



            return estado;
        }

        private void LimpiarFormulario()
        {
            this.txtCodigo.Clear();
            this.txtEstado.Clear();
            this.txtIdEstado.Clear();
            txtOrigenId.Clear();
            txtRutaOrigen.Clear();
            txtDistancia.Clear();
            txtObservacion.Clear();
            this.txtDuracion.Clear();
            txtDestinoId.Clear();
            txtRutaDestino.Clear();
            this.txtEstado.Text = "Activo";
            this.txtIdEstado.Text = "AC";
            txtOrigenId.Focus();



        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            ActivarDesactivarControlEdicion(true);
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            gbTransportista.Enabled = false;
            gbMantenimientoRegistros.Enabled = false;
            btnMenu.Enabled = false;
            bgwHilo.RunWorkerAsync();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (CodigoEstado != "")
            {
                if (CodigoEstado != "AN")
                {
                    posicionX = this.dgvRutas.CurrentRow.Index;
                    posicionY = this.dgvRutas.CurrentColumn.Index;
                    ActivarDesactivarControlEdicion(true);
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

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularRegistro();
        }

        private void AnularRegistro()
        {
            try
            {
                if (this.CodigoEstado != "")
                {
                    if (this.CodigoEstado != "AN")
                    {
                        posicionX = this.dgvRutas.CurrentRow.Index;
                        posicionY = this.dgvRutas.CurrentColumn.Index;

                        rutaNeg = new SJ_RHRutaNegocios();
                        rutaNeg.Anular(Convert.ToInt32(CodigoRuta));
                        RadMessageBox.Show("Anulado correctamente", "Atención");
                        ObtenerListaRutas();

                        dgvRutas.CurrentRow = dgvRutas.Rows[posicionX];
                    }
                    else
                    {
                        RadMessageBox.Show("No tiene el estado para la anulación del registro", "Atención");
                    }
                }
                else
                {
                    RadMessageBox.Show("No tiene el estado para la anulación del registro", "Atención");
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }

        private void EliminarRegistro()
        {
            try
            {
                if (this.CodigoEstado != "")
                {
                    if (this.CodigoEstado != "AN")
                    {
                        posicionX = this.dgvRutas.CurrentRow.Index;
                        posicionY = this.dgvRutas.CurrentColumn.Index;

                        rutaNeg = new SJ_RHRutaNegocios();
                        rutaNeg.Eliminar(Convert.ToInt32(CodigoRuta));
                        RadMessageBox.Show("Elimiado correctamente", "Atención");
                        ObtenerListaRutas();

                        if (dgvRutas.RowCount >= posicionX)
                        {
                            dgvRutas.CurrentRow = dgvRutas.Rows[posicionX];
                        }
                        else
                        {
                            dgvRutas.CurrentRow = dgvRutas.Rows[dgvRutas.RowCount];
                        }

                    }
                    else
                    {
                        RadMessageBox.Show("No tiene el estado para la eliminación del registro", "Atención");
                    }
                }
                else
                {
                    RadMessageBox.Show("No tiene el estado para la eliminación del registro", "Atención");
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvRutas != null)
            {
                if (dgvRutas.Rows.Count > 0)
                {
                    ExportarListaRuta();
                }
            }
        }

        private void ExportarListaRuta()
        {
            Exportar(dgvRutas);
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
            excelExporter.SheetName = "Listado Rutas";
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

        private void btnOrigen_Click(object sender, EventArgs e)
        {

        }

        private void dgvRutas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRutas.Rows.Count > 0)
            {
                #region
                if (dgvRutas.CurrentRow != null)
                {
                    try
                    {
                        CodigoRuta = dgvRutas.CurrentRow.Cells["chId"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chId"].Value.ToString()) : "";
                        this.txtCodigo.Text = CodigoRuta;
                        txtOrigenId.Text = dgvRutas.CurrentRow.Cells["chRutaOrigen"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chRutaOrigen"].Value.ToString()) : "";
                        txtRutaOrigen.Text =
                           ((dgvRutas.CurrentRow.Cells["chDepartamentoOrigen"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chDepartamentoOrigen"].Value.ToString()) : "") + " / " +
                            (dgvRutas.CurrentRow.Cells["chProvinciaOrigen"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chProvinciaOrigen"].Value.ToString()) : "") + " / " +
                            (dgvRutas.CurrentRow.Cells["chDistritoOrigen"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chDistritoOrigen"].Value.ToString()) : ""));
                        txtDistancia.Text = dgvRutas.CurrentRow.Cells["chDistancia"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chDistancia"].Value.ToString()) : "";
                        this.txtDuracion.Text = dgvRutas.CurrentRow.Cells["chDuracionViaje"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chDuracionViaje"].Value.ToString()) : "";
                        this.txtObservacion.Text = dgvRutas.CurrentRow.Cells["chObservacion"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chObservacion"].Value.ToString()) : "";
                        txtDestinoId.Text = dgvRutas.CurrentRow.Cells["chRutaDestino"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chRutaDestino"].Value.ToString()) : "";
                        txtRutaDestino.Text =
                            ((dgvRutas.CurrentRow.Cells["chDepartamentoDestino"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chDepartamentoDestino"].Value.ToString()) : "") + " / " +
                            (dgvRutas.CurrentRow.Cells["chProvinciaDestino"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chProvinciaDestino"].Value.ToString()) : "") + " / " +
                            (dgvRutas.CurrentRow.Cells["chDistritoDestino"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chDistritoDestino"].Value.ToString()) : ""));
                        CodigoEstado = dgvRutas.CurrentRow.Cells["chId"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chIdEstado"].Value.ToString()) : "";
                        this.txtIdEstado.Text = CodigoEstado;
                        this.txtEstado.Text = dgvRutas.CurrentRow.Cells["chId"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chEstado"].Value.ToString()) : "";

                        txtAbreviaturaRutaOrigen.Text = dgvRutas.CurrentRow.Cells["chabreviaturaRutaOrigen"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chabreviaturaRutaOrigen"].Value.ToString()) : "";
                        txtDescripcionCortaRutaOrigen.Text = dgvRutas.CurrentRow.Cells["chdescripcionCortaOrigen"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chdescripcionCortaOrigen"].Value.ToString()) : "";
                        txtAbreviaturaRutaDestino.Text = dgvRutas.CurrentRow.Cells["chabreviaturaRuraDestino"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chabreviaturaRuraDestino"].Value.ToString()) : "";
                        txtDescripcionCortaRutaDestino.Text = dgvRutas.CurrentRow.Cells["chdescripcionCortaDestino"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chdescripcionCortaDestino"].Value.ToString()) : "";

                        string esIngreso = dgvRutas.CurrentRow.Cells["chesIngreso"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chesIngreso"].Value.ToString()) : "0";

                        chkEsIngreso.Checked = false;

                        if (esIngreso == "1")
                        {
                            chkEsIngreso.Checked = !false;
                        }

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString() + "\n No se pueden asignar correctamente los valores a los controles ", "MENSAJE DE SISTEMA");
                        return;
                    }
                }
                #endregion
            }
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {

        }

        private void txtOrigenId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDestinoId_TextChanged(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            ObtenerListaRutas();
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MostrarListarRutas();
            gbTransportista.Enabled = !false;
            gbMantenimientoRegistros.Enabled = !false;
            btnMenu.Enabled = !false;
        }
    }
}
