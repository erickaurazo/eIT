using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;


namespace Transportista
{
    public partial class MovimientoRecorridos : Telerik.WinControls.UI.RadForm
    {
        private Mes MesesNeg;
        public string Criterio;
        private List<SJ_RHMovimientoMovilidadListadoResult> ListaMovimientos;
        private List<SJ_RHMovimientoMovilidadListadoResult> ListaMovimientosF;
        private MovimientoMovilidadNegocio Negocio;
        private string desde;
        private string hasta;
        private string CodigoDocumento;
        private string fechaDocumento;
        private string idestado;
        private string fileName;
        private bool exportVisualSettings;
        private string estado = "";
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;

        public MovimientoRecorridos()
        {
            try
            {
                InitializeComponent();
                RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
                RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
                RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
                RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

                btnNuevo.Enabled = false;
                CargarMeses();
                ObtenerFechasIniciales();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "\nCargar Formulario de inicio", "ADVERTENCIA DEL SISTEMA");
                return;
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            this.dgvRecorridos.TableElement.BeginUpdate();
            //this.dgvRecorridos.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvRecorridos.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvRecorridos.MasterTemplate.AutoExpandGroups = true;
            this.dgvRecorridos.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvRecorridos.GroupDescriptors.Clear();
            this.dgvRecorridos.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chDocumento", "Registros: {0:N0}; ", GridAggregateFunction.Count));
            this.dgvRecorridos.MasterTemplate.SummaryRowsTop.Add(item);
        }

        private void MovimientoRecorridos_Load(object sender, EventArgs e)
        {
            ActivarControlesBusquedad(false);
            desde = this.txtFechaDesde.Text.ToString().Trim();
            hasta = this.txtFechaHasta.Text.ToString().Trim();

            if (rbtTodos.IsChecked == true)
            {
                Criterio = "";
            }

            if (rbtInternos.IsChecked == true)
            {
                Criterio = "L";
            }

            if (rbtInterLocalidades.IsChecked == true)
            {
                Criterio = "I";
            }

            bwgHilo.RunWorkerAsync();

        }

        private void ActivarControlesBusquedad(bool p)
        {
            btnConsultar.Enabled = p;
            this.txtAño.Enabled = p;
            this.cboMes.Enabled = p;
            this.rbtInterLocalidades.Enabled = p;
            this.rbtInternos.Enabled = p;
            this.rbtTodos.Enabled = p;
            ProgressBar.Enabled = !p;
            ProgressBar.Visible = !p;

        }

        private void ObtenerFechasIniciales()
        {
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);

            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);

            int numeroSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, System.Globalization.CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
            txtSemana.Value = numeroSemana;
            ObtenerFechasSemanalesByNumeroSemana();

        }

        private void ObtenerFechasMes()
        {
            DateTime fecha1;
            DateTime fecha2;

            if (cboMes.SelectedValue.ToString() != "00")
            {
                #region
                this.txtFechaDesde.Enabled = false;
                this.txtFechaHasta.Enabled = false;
                if (cboMes.SelectedValue.ToString() == "12")
                {
                    #region Si es mes diciembre
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtAño.Value.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtAño.Value.ToString());// 
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();
                    #endregion

                }
                else
                {
                    #region Si es mes 13 habilitar controles de fecha, caso contrario es un mes de enero a noviembre.
                    if (cboMes.SelectedValue.ToString() == "13")
                    {
                        this.txtFechaDesde.Enabled = true;
                        this.txtFechaHasta.Enabled = true;


                    }
                    else
                    {
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtAño.Value.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtAño.Value.ToString());// 
                        this.txtFechaDesde.Text = fecha1.ToShortDateString();
                        this.txtFechaHasta.Text = fecha2.ToShortDateString();


                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                if (cboMes.SelectedValue.ToString() == "00")
                {
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtAño.Value.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtAño.Value.ToString());//
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();

                }

            }
        }

        private void CargarMeses()
        {

            MesesNeg = new Mes();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = MesesNeg.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Nuevo();

        }

        private void Nuevo()
        {

            if (rbtInterLocalidades.IsChecked == true)
            {
                MovimientoRecorridosMantenimiento oFormulario = new MovimientoRecorridosMantenimiento("InterLocalidad");
                oFormulario.MdiParent = MovimientoRecorridos.ActiveForm;
                oFormulario.Show();
                oFormulario.WindowState = FormWindowState.Maximized;
                oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            }

            if (rbtInternos.IsChecked == true)
            {
                MovimientoRecorridosMantenimiento oFormulario = new MovimientoRecorridosMantenimiento("Interno");
                oFormulario.MdiParent = MovimientoRecorridos.ActiveForm;
                oFormulario.Show();
                oFormulario.WindowState = FormWindowState.Maximized;
                oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            }
        }

        private void rbtTodos_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            btnNuevo.Enabled = false;
            Criterio = "";
            if (ListaMovimientos != null)
            {
                if (ListaMovimientos.ToList().Count > 0)
                {
                    ListaMovimientosF = new List<SJ_RHMovimientoMovilidadListadoResult>();
                    ListaMovimientosF = ListaMovimientos.ToList();
                    this.dgvRecorridos.DataSource = ListaMovimientosF.ToDataTable<SJ_RHMovimientoMovilidadListadoResult>();
                    dgvRecorridos.Refresh();
                }
            }
        }

        private void rbtInterLocalidades_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            btnNuevo.Enabled = true;
            Criterio = "I";
            if (ListaMovimientos != null)
            {
                if (ListaMovimientos.ToList().Count > 0)
                {
                    ListaMovimientosF = new List<SJ_RHMovimientoMovilidadListadoResult>();
                    ListaMovimientosF = ListaMovimientos.Where(x => x.idDocumento == "MTI").ToList();
                    this.dgvRecorridos.DataSource = ListaMovimientosF.ToDataTable<SJ_RHMovimientoMovilidadListadoResult>();
                    dgvRecorridos.Refresh();
                }
            }
        }

        private void rbtInternos_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            btnNuevo.Enabled = true;
            Criterio = "L";
            if (ListaMovimientos != null)
            {
                if (ListaMovimientos.ToList().Count > 0)
                {
                    ListaMovimientosF = new List<SJ_RHMovimientoMovilidadListadoResult>();
                    ListaMovimientosF = ListaMovimientos.Where(x => x.idDocumento == "MTL").ToList();
                    this.dgvRecorridos.DataSource = ListaMovimientosF.ToDataTable<SJ_RHMovimientoMovilidadListadoResult>();
                    dgvRecorridos.Refresh();
                }
            }
        }

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (estado == "")
            {
                if (ListaMovimientosF != null)
                {
                    this.dgvRecorridos.DataSource = ListaMovimientosF.ToDataTable<SJ_RHMovimientoMovilidadListadoResult>();
                    dgvRecorridos.Refresh();
                    ResaltarResultados();
                }
                
            }
            else
            {
                this.dgvRecorridos.DataSource = ListaMovimientosF.Where(x => x.IdEstado.ToUpper().Trim() == estado.ToUpper().Trim()).ToList().ToDataTable<SJ_RHMovimientoMovilidadListadoResult>();
                dgvRecorridos.Refresh();
                ResaltarResultados();
            }

            ActivarControlesBusquedad(true);
        }

        private void ResaltarResultados()
        {
            for (int i = 0; i < dgvRecorridos.Rows.Count; i++)
            {
                if (this.dgvRecorridos.Rows[i].Cells["chIdEstado"].Value != null)
                {
                    if (this.dgvRecorridos.Rows[i].Cells["chIdEstado"].Value.ToString().Trim() != "")
                    {
                        if (this.dgvRecorridos.Rows[i].Cells["chIdEstado"].Value.ToString() == "AN")
                        {
                            for (int j = 0; j < this.dgvRecorridos.Columns.Count; j++)
                            {
                                this.dgvRecorridos.Rows[i].Cells[j].Style.CustomizeFill = true;
                                this.dgvRecorridos.Rows[i].Cells[j].Style.DrawFill = true;
                                this.dgvRecorridos.Rows[i].Cells[j].Style.BackColor = Utiles.blancoHumo3D;
                            }
                        }
                    }
                }
            }
        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            RealizarConsulta();
        }

        private void RealizarConsulta()
        {
            ListaMovimientos = new List<SJ_RHMovimientoMovilidadListadoResult>();
            Negocio = new MovimientoMovilidadNegocio();

            ListaMovimientos = Negocio.ListarMovimientosDeRecorridosPorPeriodos(desde, hasta).ToList();

            switch (Criterio)
            {
                case "":
                    ListaMovimientosF = new List<SJ_RHMovimientoMovilidadListadoResult>();
                    ListaMovimientosF = ListaMovimientos.ToList();
                    break;

                case "L":
                    ListaMovimientosF = new List<SJ_RHMovimientoMovilidadListadoResult>();
                    ListaMovimientosF = ListaMovimientos.Where(x => x.idDocumento == "MTL").ToList();
                    break;

                case "I":
                    ListaMovimientosF = new List<SJ_RHMovimientoMovilidadListadoResult>();
                    ListaMovimientosF = ListaMovimientos.Where(x => x.idDocumento == "MTI").ToList();
                    break;

                default:
                    break;
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Consultar();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Mensaje del sistema");
                return;
            }
           
        }

        private void Consultar()
        {
            desde = this.txtFechaDesde.Text.ToString().Trim();
            hasta = this.txtFechaHasta.Text.ToString().Trim();

            if (rbtTodos.IsChecked == true)
            {
                Criterio = "";
            }

            if (rbtInternos.IsChecked == true)
            {
                Criterio = "L";
            }

            if (rbtInterLocalidades.IsChecked == true)
            {
                Criterio = "I";
            }


            if (rbtAnulados.IsChecked == true)
            {
                estado = "AN";
            }

            if (this.rbtPendientes.IsChecked == true)
            {
                estado = "PE";
            }


            if (this.rbtTodosEstados.IsChecked == true)
            {
                estado = "";
            }


            if (this.rbtProcesados.IsChecked == true)
            {
                estado = "PR";
            }



            ActivarControlesBusquedad(false);
            bwgHilo.RunWorkerAsync();
        }

        public void SumarElementosSeleccionadosGrilla(object senderGrilla)
        {
            try
            {
                if (((RadGridView)senderGrilla).CurrentRow != null && ((RadGridView)senderGrilla).CurrentCell != null)
                {
                    int fila = ((RadGridView)senderGrilla).CurrentRow.Index;
                    int columna = ((RadGridView)senderGrilla).CurrentCell.ColumnIndex;

                    decimal SumaSeleccionada = 0;
                    decimal promedioSeleccionado = 0;
                    int recuento = 0;

                    //foreach (DataGridViewCell celda in ((DataGridView)senderGrilla).SelectedCells)
                    foreach (GridViewCellInfo celda in ((RadGridView)senderGrilla).SelectedCells)
                    {
                        if (celda.Value != null)
                        {
                            string tipoDato = celda.Value.GetType().Name.ToString();
                            if (tipoDato != null && tipoDato != string.Empty)
                            {
                                #region
                                if (tipoDato == "Double" || tipoDato == "Decimal")
                                {
                                    SumaSeleccionada += Convert.ToDecimal(celda.Value != null ? celda.Value : 0);
                                    if (Convert.ToDecimal(celda.Value != null ? celda.Value : 0) == 0)
                                    {

                                    }
                                    else
                                    {
                                        recuento++;
                                    }

                                    promedioSeleccionado = (SumaSeleccionada / recuento);
                                }
                                else
                                {
                                    SumaSeleccionada = 0;
                                    recuento = 0;
                                    promedioSeleccionado = 0;
                                    break;
                                }
                                #endregion
                            }
                            else
                            {
                                #region
                                SumaSeleccionada = 0;
                                recuento = 0;
                                promedioSeleccionado = 0;
                                break;
                                #endregion
                            }
                            this.lblSumaSeleccionada.Text = SumaSeleccionada.ToDecimalPresentation();
                            this.lblRecuento.Text = recuento.ToString();

                            this.lblPromedio.Text = promedioSeleccionado.ToDecimalPresentation();
                        }


                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void dgvRecorridos_SelectionChanged(object sender, EventArgs e)
        {
            CodigoDocumento = "";
            fechaDocumento = "";
            idTipoDocumento = "";
            idestado = "";
            sbmAnularMovimiento.Enabled = false;
            sbmeditarMovimiento.Enabled = false;
            sbmEliminarMovimiento.Enabled = false;

            SumarElementosSeleccionadosGrilla(sender);

            if (dgvRecorridos != null && dgvRecorridos.Rows.Count > 0)
            {
                if (dgvRecorridos.CurrentRow != null)
                {
                    if (dgvRecorridos.CurrentRow.Cells["chCodigo"].Value != null && dgvRecorridos.CurrentRow.Cells["chCodigo"].Value.ToString().Trim() != "")
                    {
                        CodigoDocumento = dgvRecorridos.CurrentRow.Cells["chCodigo"].Value != null ? dgvRecorridos.CurrentRow.Cells["chCodigo"].Value.ToString().Trim() : "";
                        fechaDocumento = dgvRecorridos.CurrentRow.Cells["chFecha"].Value != null ? dgvRecorridos.CurrentRow.Cells["chFecha"].Value.ToString().Trim() : "";
                        idTipoDocumento = dgvRecorridos.CurrentRow.Cells["chidDocumento"].Value != null ? dgvRecorridos.CurrentRow.Cells["chidDocumento"].Value.ToString().Trim() : "";
                        idestado = dgvRecorridos.CurrentRow.Cells["chIdEstado"].Value != null ? dgvRecorridos.CurrentRow.Cells["chIdEstado"].Value.ToString().Trim() : "";


                        if (CodigoDocumento != "")
                        {
                            sbmAnularMovimiento.Enabled = true;
                            sbmeditarMovimiento.Enabled = true;
                            sbmEliminarMovimiento.Enabled = true;
                        }

                        sbmEliminarMovimiento.Enabled = false;
                        if (idestado.ToString().Trim() == "PE")
                        {
                            sbmEliminarMovimiento.Enabled = true;
                        }
                    }

                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();

        }

        private void Editar()
        {
            if (CodigoDocumento != null && CodigoDocumento.ToString().Trim() != "")
            {
                MovimientoRecorridosMantenimiento oFormulario = new MovimientoRecorridosMantenimiento(CodigoDocumento, fechaDocumento, idTipoDocumento);
                //oFormulario.MdiParent = MovimientoRecorridos.ActiveForm;
                oFormulario.Show();
                oFormulario.WindowState = FormWindowState.Maximized;
                oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            }
        }

        private void dgvRecorridos_DoubleClick(object sender, EventArgs e)
        {
            //if (CodigoDocumento != null && CodigoDocumento.ToString().Trim() != "")
            //{
            //    MovimientoRecorridosMantenimiento oFormulario = new MovimientoRecorridosMantenimiento(CodigoDocumento, fechaDocumento, idTipoDocumento);
            //    oFormulario.MdiParent = MovimientoRecorridos.ActiveForm;
            //    oFormulario.Show();
            //    oFormulario.WindowState = FormWindowState.Maximized;
            //    oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //}

            Editar();
        }

        public string idTipoDocumento { get; set; }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void ExportarExcel()
        {
            if (dgvRecorridos != null)
            {
                if (dgvRecorridos.Rows.Count > 0)
                {
                    Exportar(this.dgvRecorridos);
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
            excelExporter.SheetName = "Mov. Recorrido";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
            excelExporter.HiddenColumnOption = HiddenOption.DoNotExport; /* no mostrar columnas ocultas*/
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

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void Anular()
        {
            if (idestado == "PE" | idestado == "AN")
            {
                // SOLO SE PUEDEN ANULAR LOS DOCUMENTO QUE TENGAN EL ESTADO PE
                try
                {
                    Negocio = new MovimientoMovilidadNegocio();
                    Negocio.AnularMovimiento(fechaDocumento.Substring(6, 4).ToString(), CodigoDocumento);
                    MessageBox.Show("El documento ha cambiado de estado satisfactoriamente", "CONFIRMACION DEL SISTEMA");
                    ActivarControlesBusquedad(false);
                    bwgHilo.RunWorkerAsync();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.ToString() + "Anular movimiento", "MENSAJE DEL SISTEMA");
                    return;

                }
            }
            else
            {
                MessageBox.Show("No tiene el estado para anular el movimiento", "MENSAJE DEL SISTEMA");
            }
        }

        private void gbLista_Click(object sender, EventArgs e)
        {

        }

        private void editarMovimiento_Click(object sender, EventArgs e)
        {
            if (CodigoDocumento != null && CodigoDocumento.ToString().Trim() != "")
            {
                MovimientoRecorridosMantenimiento oFormulario = new MovimientoRecorridosMantenimiento(CodigoDocumento, fechaDocumento, idTipoDocumento);
                oFormulario.MdiParent = MovimientoRecorridos.ActiveForm;
                oFormulario.Show();
                oFormulario.WindowState = FormWindowState.Maximized;
                oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            }
        }

        private void anularMovimiento_Click(object sender, EventArgs e)
        {
            if (idestado == "PE" | idestado == "AN")
            {
                // SOLO SE PUEDEN ANULAR LOS DOCUMENTO QUE TENGAN EL ESTADO PE
                try
                {
                    Negocio = new MovimientoMovilidadNegocio();
                    Negocio.AnularMovimiento(fechaDocumento.Substring(6, 4).ToString(), CodigoDocumento);
                    MessageBox.Show("El documento ha cambiado de estado satisfactoriamente", "CONFIRMACION DEL SISTEMA");
                    ActivarControlesBusquedad(false);
                    bwgHilo.RunWorkerAsync();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.ToString() + "Anular movimiento", "MENSAJE DEL SISTEMA");
                    return;

                }
            }
            else
            {
                MessageBox.Show("No tiene el estado para anular el movimiento", "MENSAJE DEL SISTEMA");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            if (idestado == "PE")
            {
                // SOLO SE PUEDEN ANULAR LOS DOCUMENTO QUE TENGAN EL ESTADO PE
                try
                {
                    Negocio = new MovimientoMovilidadNegocio();
                    SJ_RHMovimientoMovilidad movimiento = new SJ_RHMovimientoMovilidad();
                    movimiento.Codigo = CodigoDocumento;
                    Negocio.EliminarMovimiento(movimiento);
                    MessageBox.Show("El documento ha sido eliminado satisfactoriamente", "CONFIRMACION DEL SISTEMA");
                    ActivarControlesBusquedad(false);
                    bwgHilo.RunWorkerAsync();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.ToString() + "Anular movimiento", "MENSAJE DEL SISTEMA");
                    return;
                }
            }
            else
            {
                MessageBox.Show("No tiene el estado para eliminar el movimiento", "MENSAJE DEL SISTEMA");
            }
        }

        private void sbmEliminarMovimiento_Click(object sender, EventArgs e)
        {
            if (idestado == "PE")
            {
                // SOLO SE PUEDEN ANULAR LOS DOCUMENTO QUE TENGAN EL ESTADO PE
                try
                {
                    Negocio = new MovimientoMovilidadNegocio();
                    SJ_RHMovimientoMovilidad movimiento = new SJ_RHMovimientoMovilidad();
                    movimiento.Codigo = CodigoDocumento;
                    Negocio.EliminarMovimiento(movimiento);
                    MessageBox.Show("El documento ha sido eliminado satisfactoriamente", "CONFIRMACION DEL SISTEMA");
                    ActivarControlesBusquedad(false);
                    bwgHilo.RunWorkerAsync();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.ToString() + "Anular movimiento", "MENSAJE DEL SISTEMA");
                    return;
                }
            }
            else
            {
                MessageBox.Show("No tiene el estado para eliminar el movimiento", "MENSAJE DEL SISTEMA");
            }
        }

        private void gbConsulta_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaDesde_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtSemana_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasSemanalesByNumeroSemana();
        }

        private void ObtenerFechasSemanalesByNumeroSemana()
        {
            try
            {
                #region Asigar fechas por semana()
                modeloSemana = new SJ_SemanaNegocio();
                oSemana = new SJ_Semana();
                oSemanaConsulta = new SJ_Semana();
                oSemana.año = Convert.ToInt32(this.txtAño.Value);
                oSemana.semana = Convert.ToInt32(this.txtSemana.Value);
                oSemanaConsulta = modeloSemana.ObtenerSemanaPorNroSemana(oSemana);
                this.txtFechaDesde.Text = oSemanaConsulta.desde.Value.ToPresentationDate();
                this.txtFechaHasta.Text = oSemanaConsulta.hasta.Value.ToPresentationDate();

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }


        private void EdicionDesdeTeclado(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Editar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
               
            }
            if (e.KeyData == (Keys.Escape))
            {                
            }
        }

        private void menuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void radGroupBox1_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void gbLista_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void dgvRecorridos_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void btnConsultar_KeyDown(object sender, KeyEventArgs e)
        {
            EdicionDesdeTeclado(sender, e);
        }

        private void subMenu_Opening(object sender, CancelEventArgs e)
        {

        }

    }
}
