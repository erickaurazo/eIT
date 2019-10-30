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
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas : Form
    {
        private PensionFacturacionPensionDiasExcluidosNegocios modelo = new PensionFacturacionPensionDiasExcluidosNegocios();
        private List<SJ_RHListarDiasExcluidosParaFacturacionPensionResult> listadoDiasByConsulta = new List<SJ_RHListarDiasExcluidosParaFacturacionPensionResult>();
        private List<SJ_RHPensionFacturacionPensionDiasExcluido> listaEliminados = new List<SJ_RHPensionFacturacionPensionDiasExcluido>();
        private List<SJ_RHPensionFacturacionPensionDiasExcluido> listaDiasExcluidasDescuento = new List<SJ_RHPensionFacturacionPensionDiasExcluido>();
        private SJ_RHListarDiasExcluidosParaFacturacionPensionResult oDiaExcluidoByLista = new SJ_RHListarDiasExcluidosParaFacturacionPensionResult();
        private SJ_RHPensionFacturacionPensionDiasExcluido oDiaExcluido = new SJ_RHPensionFacturacionPensionDiasExcluido();
        private List<SJ_RHPensionFacturacionPensionDiasExcluido> listadoGrillaRegistrar = new List<SJ_RHPensionFacturacionPensionDiasExcluido>();
        private string periodo;
        private string Mensaje;
        List<PeriodoDia> listaDiasGrilla = new List<PeriodoDia>();
        private string mensaje = string.Empty;

        public ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (ValidarDatosGrilla() == true)
            {
                AgregarLinea();
            }
            else
            {
                RadMessageBox.Show(Mensaje);
            }
        }

        private Boolean EsFecha(String fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<PeriodoDia> ObtenerListadofechasByGrilla(MyDataGridViewDetails grilla)
        {
            listaDiasGrilla = new List<PeriodoDia>();
            if (grilla != null && grilla.Rows.Count > 0)
            {
                foreach (DataGridViewRow Row in grilla.Rows)
                {
                    listaDiasGrilla.Add(new PeriodoDia { dia = Convert.ToDateTime(Convert.ToString(Row.Cells["chfecha"].Value)) });
                }
            }
            else
            {
                listaDiasGrilla.Add(new PeriodoDia { dia = Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString().Substring(0, 10)) });
            }


            return listaDiasGrilla.OrderBy(x => x.dia).ToList();
        }

        private void AgregarLinea()
        {
            try
            {
                if (this.dgvDiasExcluidos != null)
                {

                    string fecha = string.Empty;
                    string nfecha = DateTime.Now.AddDays(0).ToShortDateString().Substring(0, 10);
                    List<PeriodoDia> listaDiasGrilla1 = new List<PeriodoDia>();
                    listaDiasGrilla1 = ObtenerListadofechasByGrilla(dgvDiasExcluidos);
                    ArrayList array = new ArrayList();
                    array.Add(0); // idFechaExcluida                
                    array.Add((AsignarNumeroItemsGrilla(ObtenerUltimoNumeroItem(dgvDiasExcluidos)))); // item
                    array.Add(listaDiasGrilla1.Max(x => x.dia).AddDays(1).ToShortDateString()); // fecha
                    array.Add("DÍA EXCLUIDO POR ").ToString().Trim().ToUpper(); // descripcion
                    array.Add(1); // idestado  
                    array.Add(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0')); // periodo
                    array.Add(1); // Aplica Pension
                    array.Add(1); // Aplica Transporte
                    array.Add(0); // Aplica Otros                                                      
                    this.dgvDiasExcluidos.AgregarFila(array);

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

        private bool ValidarDatosGrilla()
        {
            bool estado = false;
            if (dgvDiasExcluidos != null && dgvDiasExcluidos.Rows.Count > 0)
            {
                #region
                //List<PeriodoDia> fechas = new List<PeriodoDia>();
                //foreach (DataGridViewRow item in dgvDiasExcluidos.Rows)
                //{
                //listaDiasExcluidasDescuento.Add(new SJ_RHPensionFacturacionPensionDiasExcluido
                //{
                //    idFechaExcluida = (item.Cells["chid"].Value != null ? Convert.ToInt32(item.Cells["chid"].Value) : 0),
                //    item = (item.Cells["chItem"].Value != null ? Convert.ToString(item.Cells["chItem"].Value) : ""),
                //    fecha = (item.Cells["chfecha"].Value != null ? Convert.ToDateTime(item.Cells["chItem"].Value) : DateTime.Now),
                //    observacion = (item.Cells["chObservacion"].Value != null ? Convert.ToString(item.Cells["chObservacion"].Value) : ""),
                //    estado = (item.Cells["chIdEstado"].Value != null ? Convert.ToByte(item.Cells["chIdEstado"].Value) : Convert.ToByte(0)),
                //    periodo = "",
                //    machine = Environment.MachineName,
                //    usuarioRegistro = Environment.UserName,
                //    fechaRegistro = DateTime.Now,
                //    aplicaPension = (item.Cells["chaplicaPensapion"].Value != null ? Convert.ToByte(item.Cells["chaplicaPension"].Value) : Convert.ToByte(0)),
                //    aplicaTransporte = (item.Cells["chaplicaTransporte"].Value != null ? Convert.ToByte(item.Cells["chaplicaTransporte"].Value) : Convert.ToByte(0)),
                //    aplicaOtros = (item.Cells["chaplicaOtros"].Value != null ? Convert.ToByte(item.Cells["chaplicaOtros"].Value) : Convert.ToByte(0)),
                //}
                //);
                //}
                estado = true;
                #endregion
            }
            else
            {
                Mensaje += "No hay elementos para el registro ";
            }

            //Mensaje += "";
            return estado;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            QuitarLinea();
        }

        private void QuitarLinea()
        {
            if (this.dgvDiasExcluidos != null)
            {
                if (this.dgvDiasExcluidos.CurrentRow != null && this.dgvDiasExcluidos.CurrentRow.Cells["chId"].Value != null)
                {
                    if (MessageBox.Show(this, "¿Desea eliminar el elemento seleccionado?", "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Int32 Codigo = (this.dgvDiasExcluidos.CurrentRow.Cells["chId"].Value.ToString().Trim() != "" ? Convert.ToInt32(this.dgvDiasExcluidos.CurrentRow.Cells["chId"].Value) : 0);
                            string Item = ((this.dgvDiasExcluidos.CurrentRow.Cells["chItem"].Value != null || this.dgvDiasExcluidos.CurrentRow.Cells["chItem"].Value.ToString().Trim() != "") ? Convert.ToString(this.dgvDiasExcluidos.CurrentRow.Cells["chItem"].Value) : "");
                            if (Codigo != 0)
                            {
                                listaEliminados.Add(new SJ_RHPensionFacturacionPensionDiasExcluido
                                {
                                    idFechaExcluida = Codigo,
                                    item = Item,
                                });

                            }

                            dgvDiasExcluidos.Rows.Remove(dgvDiasExcluidos.CurrentRow);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString() + "No se puede eliminar el item selecionado", "MENSAJE DE TEXTO");
                            return;
                        }
                    }
                }
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {

        }

        private void btnRefrescarLista_Click(object sender, EventArgs e)
        {
            RealizarConsulta();
        }

        private void RealizarConsulta()
        {
            try
            {
                #region Realizar consulta()
                this.btnActivar.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.btnDesactivar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnSalir.Enabled = false;
                this.btnRefrescarLista.Enabled = false;
                dgvDiasExcluidos.Enabled = false;
                progressBar.Visible = true;

                periodo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0');
                bgwHilo.RunWorkerAsync();
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            btnGrabar.Enabled = false;
            dgvDiasExcluidos.Enabled = false;
            progressBar.Visible = true;

            try
            {
                if (VerificarDuplicidadFechasEnGrilla() == true)
                {
                    listadoGrillaRegistrar = ObtenerListadoGrilla();

                    if (listadoGrillaRegistrar != null && listadoGrillaRegistrar.ToList().Count > 0)
                    {
                        #region Registrar()
                        modelo = new PensionFacturacionPensionDiasExcluidosNegocios();
                        modelo.Registrar(listadoGrillaRegistrar, listaEliminados);
                        MessageBox.Show("Registrados correctamente", "MENSAJE DE SISTEMA");
                        RealizarConsulta();
                        btnGrabar.Enabled = true;
                        dgvDiasExcluidos.Enabled = true;
                        progressBar.Visible = false;
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("No hay elementos para el registro", "MENSAJE DE SISTEMA");
                        btnGrabar.Enabled = true;
                        dgvDiasExcluidos.Enabled = true;
                        progressBar.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show(mensaje);
                    return;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "MENSAJE DEL SISTEMA");
                btnGrabar.Enabled = true;
                dgvDiasExcluidos.Enabled = true;
                progressBar.Visible = false;
                return;
            }
        }

        private List<SJ_RHPensionFacturacionPensionDiasExcluido> ObtenerListadoGrilla()
        {
            List<SJ_RHPensionFacturacionPensionDiasExcluido> listadoGrillaProcesar = new List<SJ_RHPensionFacturacionPensionDiasExcluido>();
            try
            {
                if (dgvDiasExcluidos.Rows.Count > 0)
                {

                    foreach (DataGridViewRow filas in dgvDiasExcluidos.Rows)
                    {
                        SJ_RHPensionFacturacionPensionDiasExcluido oItem = new SJ_RHPensionFacturacionPensionDiasExcluido();
                        oItem.idFechaExcluida = filas.Cells["chId"].Value != null ? Convert.ToInt32(filas.Cells["chId"].Value) : 0;
                        oItem.item = filas.Cells["chItem"].Value != null ? Convert.ToString(filas.Cells["chItem"].Value) : "";
                        oItem.fecha = filas.Cells["chFecha"].Value != null ? Convert.ToDateTime(filas.Cells["chFecha"].Value) : DateTime.Now;
                        oItem.observacion = filas.Cells["chObservacion"].Value != null ? Convert.ToString(filas.Cells["chObservacion"].Value) : "";
                        oItem.estado = filas.Cells["chIdEstado"].Value != null ? Convert.ToByte(filas.Cells["chIdEstado"].Value) : Convert.ToByte(0);
                        oItem.periodo = filas.Cells["chPeriodo"].Value != null ? Convert.ToString(filas.Cells["chPeriodo"].Value) : "";
                        oItem.machine = Environment.MachineName;
                        oItem.usuarioRegistro = Environment.UserName;
                        oItem.fechaRegistro = DateTime.Now;

                        var aPension = (filas.Cells["chaplicaPension"].Value != null || filas.Cells["chaplicaPension"].Value.ToString().Trim() != "") ? Convert.ToString(filas.Cells["chaplicaPension"].Value.ToString().Trim()) : "0";
                        var aTransporte = (filas.Cells["chaplicaTransporte"].Value != null || filas.Cells["chaplicaTransporte"].Value.ToString().Trim() != "") ? Convert.ToString(filas.Cells["chaplicaTransporte"].Value.ToString().Trim()) : "0";
                        var aOtros = (filas.Cells["chaplicaOtros"].Value != null || filas.Cells["chaplicaOtros"].Value.ToString().Trim() != "") ? Convert.ToString(filas.Cells["chaplicaOtros"].Value.ToString().Trim()) : "0";
                        oItem.aplicaPension = (aPension != null && aPension != "") ? Convert.ToByte(aPension) : Convert.ToByte(0);
                        oItem.aplicaTransporte = (aTransporte != null && aTransporte != "") ? Convert.ToByte(aTransporte) : Convert.ToByte(0);
                        oItem.aplicaOtros = (aOtros != null && aOtros != "") ? Convert.ToByte(aOtros) : Convert.ToByte(0);
                        listadoGrillaProcesar.Add(oItem);
                    }
                }
            }
            catch (Exception Ex)
            {
                listadoGrillaProcesar = new List<SJ_RHPensionFacturacionPensionDiasExcluido>();
                MessageBox.Show(Ex.Message.ToString() + "\n obtener lista para registro.", "MENSAJE DEL SISTEMA");
                return listadoGrillaProcesar;
            }

            return listadoGrillaProcesar;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void dgvContratos_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas_Load(object sender, EventArgs e)
        {
            RealizarConsulta();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listadoDiasByConsulta = new List<SJ_RHListarDiasExcluidosParaFacturacionPensionResult>();
                listadoDiasByConsulta = modelo.ObtenerListadoDiasExcluidoByFacturacion(periodo).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMAS");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //this.dgvDiasExcluidos.DataSource = listadoDias.ToDataTable<SJ_RHListarDiasExcluidosParaFacturacionPensionResult>();
                this.dgvDiasExcluidos.CargarDatos(listadoDiasByConsulta.ToDataTable<SJ_RHListarDiasExcluidosParaFacturacionPensionResult>());
                this.dgvDiasExcluidos.Refresh();

                this.btnActivar.Enabled = true;
                this.btnAgregar.Enabled = true;
                this.btnDesactivar.Enabled = true;
                this.btnGrabar.Enabled = true;
                this.btnSalir.Enabled = true;
                this.btnRefrescarLista.Enabled = true;
                dgvDiasExcluidos.Enabled = true;
                progressBar.Visible = false;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "MENSAJE DEL SISTEMAS");
                this.btnActivar.Enabled = true;
                this.btnAgregar.Enabled = true;
                this.btnDesactivar.Enabled = true;
                this.btnGrabar.Enabled = true;
                this.btnSalir.Enabled = true;
                this.btnRefrescarLista.Enabled = true;
                dgvDiasExcluidos.Enabled = true;
                progressBar.Visible = false;
                return;

            }

        }

        private void dgvDiasExcluidos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Validamos si no es una fila nueva
            if (!dgvDiasExcluidos.Rows[e.RowIndex].IsNewRow)
            {
                //Sólo controlamos el dato de la columna 0
                if (e.ColumnIndex == 2)
                {
                    if (!this.EsFecha(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("El dato introducido no es de tipo fecha", "Error de validación",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvDiasExcluidos.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo fecha";
                        e.Cancel = true;
                    }
                    else
                    {
                        List<PeriodoDia> listaDiasGrilla2 = new List<PeriodoDia>();
                        listaDiasGrilla2 = ObtenerListadofechasByGrilla(dgvDiasExcluidos).ToList();
                        PeriodoDia nuevaFecha = new PeriodoDia();
                        nuevaFecha.dia = Convert.ToDateTime(e.FormattedValue);
                        var ResultadoCoincidencias = listaDiasGrilla2.Where(x => x.dia == Convert.ToDateTime(e.FormattedValue)).ToList();
                        if ((ResultadoCoincidencias != null && ResultadoCoincidencias.ToList().Count > 1))
                        {
                            MessageBox.Show("El dato introducido ya se encuentra asociado a la lista", "Error de registro de datos",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvDiasExcluidos.Rows[e.RowIndex].ErrorText = "El dato introducido ya se encuentra registrado en la grilla actual";
                            e.Cancel = true;
                        }

                    }
                }
            }
        }

        private bool VerificarDuplicidadFechasEnGrilla()
        {
            bool resultado = true;
            List<PeriodoDia> listaDiasGrilla2 = new List<PeriodoDia>();
            listaDiasGrilla2 = ObtenerListadofechasByGrilla(dgvDiasExcluidos).ToList();

            if (listaDiasGrilla2 != null && listaDiasGrilla2.ToList().Count > 0)
            {

                var listadoDias = (from dia in listaDiasGrilla2
                                   where dia.dia != null
                                   group dia by new { dia.dia } into j
                                   select new { oDia = j.Key.dia }
                                       ).ToList();

                foreach (var item in listadoDias)
                {

                    var resultadoCoincidencia = listaDiasGrilla2.Where(x => x.dia == item.oDia).ToList();

                    if (resultadoCoincidencia != null && resultadoCoincidencia.ToList().Count > 1)
                    {
                        resultado = false;
                        mensaje = ("Se tiene duplicidad en la entrada del registro con la fecha" + item.oDia.ToShortDateString());
                        break;
                    }

                }
            }

            return resultado;

        }

        private void dgvDiasExcluidos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvDiasExcluidos.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dgvDiasExcluidos_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[2].Value = DateTime.Now.Date.ToShortDateString();
        }


    }
}
