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
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ConsolidadoMovimientoMovilidades : Telerik.WinControls.UI.RadForm
    {
        private Mes MesesNeg;
        private string periodo;
        private string desde;
        private string hasta;
        private string codigoProveedor;
        private List<SJ_RHMovimientMovilidadPendientesFacturacionResult> ListadoPendientesFacturacion;
        private MovimientoMovilidadNegocio negocio;
        private int incluirRecorridoInterno;
        private int incluirRecorridoInterlocalidades;
        private string incluirDestinoUcupe;
        private string mes;
        private string proveedor;
        private string nombreMes;
        private List<SJ_RHDocPagarDetalle> ListadetalleFacturacion;
        private int numeroitem;
        private System.Windows.Forms.DialogResult dr;
        private List<SJ_RHMovimientMovilidadPendientesFacturacionResult> ListadoPendientesFacturacionF;
        private string fileName;
        private bool exportVisualSettings;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        public ConsolidadoMovimientoMovilidades()
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


        protected override void OnLoad(EventArgs e)
        {
            this.dgvDetalle.TableElement.BeginUpdate();
            //this.dgvDetalle.Columns["chPlaca"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvDetalle.TableElement.EndUpdate();
            base.OnLoad(e);
        }


        private void LoadFreightSummary()
        {
            this.dgvDetalle.MasterTemplate.AutoExpandGroups = true;
            this.dgvDetalle.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.GroupDescriptors.Clear();
            this.dgvDetalle.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items1 = new GridViewSummaryRowItem();
            items1.Add(new GridViewSummaryItem("chPlaca", "Count: {0:N0}; ", GridAggregateFunction.Count));
            items1.Add(new GridViewSummaryItem("chPromedioPersona", "Prom.  {0:N3} ", GridAggregateFunction.Avg));
            items1.Add(new GridViewSummaryItem("chPrecio", "Prom.  {0:N3} ", GridAggregateFunction.Avg));
            items1.Add(new GridViewSummaryItem("chNroPersonas", "Prom. {0:N0} ", GridAggregateFunction.Avg));
            items1.Add(new GridViewSummaryItem("chSubTotal", "Sum. {0:N3} ", GridAggregateFunction.Sum));

            //this.dgvListaAgrupada.MasterTemplate.SummaryRowsBottom.Add(items1);
            this.dgvDetalle.MasterTemplate.SummaryRowsTop.Add(items1);
        }




        private void FacturacionMovilidades_Load(object sender, EventArgs e)
        {

        }


        private void ObtenerFechasIniciales()
        {
            //this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);

            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);
            int numeroSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
            txtSemana.Value = numeroSemana;

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
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtPeriodo.Value.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Value.ToString());// 
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
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtPeriodo.Value.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Value.ToString());// 
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
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtPeriodo.Value.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtPeriodo.Value.ToString());//
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

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            HabilitarControlsBusqueda(false);
            AsignarValoresConsulta();
            bgwHilo.RunWorkerAsync();


        }

        private void HabilitarControlsBusqueda(bool estado)
        {
            btnConsultar.Enabled = estado;
            this.ProgressBar.Visible = !estado;
            txtPeriodo.Enabled = estado;
            cboMes.Enabled = estado;
            gbIncluir.Enabled = estado;
            btnBuscarTransportista.Enabled = estado;
            txtFechaDesde.ReadOnly = !estado;
            txtFechaHasta.ReadOnly = !estado;

        }

        private void AsignarValoresConsulta()
        {
            try
            {
                mes = this.txtFechaHasta.Value.ToString().Trim().Substring(3, 2);
                nombreMes = this.cboMes.SelectedItem.Text.ToString().Trim();
                periodo = this.txtPeriodo.Value.ToString().Trim();
                desde = this.txtFechaDesde.Text.ToString().Trim();
                hasta = this.txtFechaHasta.Text.ToString().Trim();
                codigoProveedor = this.txtRUCTransportista.Text.ToString().Trim() != "" ? Convert.ToString(this.txtRUCTransportista.Text.ToString().Trim()) : "";
                proveedor = txtRazonSocialTransportista.Text.ToString().Trim();
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        }

        private void btnBuscarTransportista_Click(object sender, EventArgs e)
        {
            BuscarMovilidadTransportePersonalCampo ofrm = new BuscarMovilidadTransportePersonalCampo("AMBOS");
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                #region
                if (ofrm.oMovilidad != null)
                {
                    #region Asignar valores de consulta a controles()
                    this.txtRUCTransportista.Text = ofrm.oMovilidad.RUC;
                    this.txtRazonSocialTransportista.Text = ofrm.oMovilidad.RazonSocial;
                    #endregion
                }
                else
                {
                    #region Limpiar controles de Transportista()
                    this.txtRUCTransportista.Clear();
                    this.txtRazonSocialTransportista.Clear();
                    #endregion
                }
                #endregion
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarDatos();
        }

        private void PresentarDatos()
        {
            try
            {
                #region Ejecuto los Filtros()
                if (chkRecorridoInterlocalidades.Checked == true)
                {
                    VisualizarItemsMovimiento("Interlocalidades", chkRecorridoInterlocalidades, 1);
                }

                if (chkRecorridoInterno.Checked == true)
                {
                    VisualizarItemsMovimiento("RecorridoInterno", chkRecorridoInterno, 1);
                }

                if (chkRecorridoUcupe.Checked == true)
                {
                    VisualizarItemsMovimiento("Ucupe", chkRecorridoUcupe, 1);
                }


                if (chkSelRecorrido.Checked == true)
                {
                    SelecionarItems("Recorrido Interno", chkSelRecorrido, 1);
                }


                if (chkSelNroPersona.Checked == true)
                {
                    SelecionarItems("Número Personas", chkSelNroPersona, 1);
                }

                if (chkSelFlete.Checked == true)
                {
                    SelecionarItems("Por flete", chkSelFlete, 1);
                }
                #endregion

                dgvDetalle.DataSource = ListadoPendientesFacturacion.Where(x => x.IdEstado.ToString().Trim() == "PE").ToList().ToDataTable<SJ_RHMovimientMovilidadPendientesFacturacionResult>();
                dgvDetalle.Refresh();
                HabilitarControlsBusqueda(true);
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        }

        private void PresentarDatosFiltros()
        {
            try
            {
                #region Ejecuto los Filtros()
                //if (chkRecorridoInterlocalidades.Checked == true)
                //{
                //    VisualizarItemsMovimiento("Interlocalidades", chkRecorridoInterlocalidades, 0);
                //}

                //if (chkRecorridoInterno.Checked == true)
                //{
                //    VisualizarItemsMovimiento("RecorridoInterno", chkRecorridoInterno, 0);
                //}

                //if (chkRecorridoUcupe.Checked == true)
                //{
                //    VisualizarItemsMovimiento("Ucupe", chkRecorridoUcupe, 0);
                //}


                //if (chkSelRecorrido.Checked == true)
                //{
                //    SelecionarItems("Recorrido Interno", chkSelRecorrido, 0);
                //}


                //if (chkSelNroPersona.Checked == true)
                //{
                //    SelecionarItems("Número Personas", chkSelNroPersona, 0);
                //}

                //if (chkSelFlete.Checked == true)
                //{
                //    SelecionarItems("Por flete", chkSelFlete, 0);
                //}
                #endregion

                dgvDetalle.DataSource = ListadoPendientesFacturacion.Where(x => x.IdEstado.ToString().Trim() == "PE").ToList().ToDataTable<SJ_RHMovimientMovilidadPendientesFacturacionResult>();
                dgvDetalle.Refresh();
                HabilitarControlsBusqueda(true);
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarConsulta();

        }

        private void EjecutarConsulta()
        {
            try
            {
                ListadoPendientesFacturacion = new List<SJ_RHMovimientMovilidadPendientesFacturacionResult>();
                negocio = new MovimientoMovilidadNegocio();

                ListadoPendientesFacturacion = negocio.ListarMovimientoPendientesFacturacionxProveedor(codigoProveedor, desde, hasta, periodo).ToList();

            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        }

        private void chkRecorridoInterno_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            VisualizarItemsMovimiento("RecorridoInterno", chkRecorridoInterno, 0);
        }

        private void chkRecorridoInterlocalidades_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            VisualizarItemsMovimiento("Interlocalidades", chkRecorridoInterlocalidades, 0);
        }

        private void chkRecorridoUcupe_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            VisualizarItemsMovimiento("Ucupe", chkRecorridoUcupe, 0);
        }

        private void btnGenerarFacturacion_Click(object sender, EventArgs e)
        {

            if (this.txtRUCTransportista.Text.ToString().Trim() != "" && this.txtRazonSocialTransportista.Text.ToString().Trim() != "")
            {
                ListadetalleFacturacion = new List<SJ_RHDocPagarDetalle>();
                ObtenerListaCheckActivados();

                if (ListadetalleFacturacion != null)
                {
                    #region
                    if (ListadetalleFacturacion.ToList().Count > 0)
                    {
                        FacturacionMovilidadesEdicion ofrm = new FacturacionMovilidadesEdicion(mes, nombreMes, codigoProveedor, proveedor, ListadetalleFacturacion);
                        ofrm.MdiParent = ConsolidadoMovimientoMovilidades.ActiveForm;
                        ofrm.WindowState = FormWindowState.Maximized;
                        ofrm.Show();
                        //ofrm.MdiParent = ConsolidadoMovimientoMovilidades.ActiveForm;
                        /*
                        if (ofrm.ShowDialog() == DialogResult.OK)
                        {
                            if (ofrm.esGrabado == "OK")
                            {
                                //MessageBox.Show("Grabado");
                                /* Quitar de la lista actual, la lista de los check selecionados, 
                                 * y para la proxima busquedad no deberia mostrarlos 
                                 * debido a que ya cambio a un estado procesado los movimiento de movilidades

                                //var codigos = (from item in ListadetalleFacturacion
                                //               group item by new { item.codigoMovimiento } into j
                                //               select new
                                //               {
                                //                   cod = j.Key.codigoMovimiento.ToString().Trim(),
                                //               }
                                //                   ).ToList();


                                //var lista = (from item in ListadoPendientesFacturacion
                                //             where !(item.Codigo.Contains(codigos.ToString().Trim()))
                                //             select item).ToList();


                                HabilitarControlsBusqueda(false);
                                AsignarValoresConsulta();
                                bgwHilo.RunWorkerAsync();
                            }
                            else
                            {
                                //MessageBox.Show("Cancelado");
                            }

                        }
                        else
                        {
                            if (ofrm.esGrabado == "OK")
                            {
                                ////MessageBox.Show("Grabado");



                                HabilitarControlsBusqueda(false);
                                AsignarValoresConsulta();
                                bgwHilo.RunWorkerAsync();
                            }
                            else
                            {
                                //MessageBox.Show("Cancelado");
                            }
                        }
                    }
                    
                         
                }*/

                    }
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("Ingrese proveedor", "MENSAJE DEL SISTEMA");
                return;
            }

            
        }

        private void ObtenerListaCheckActivados()
        {
            numeroitem = 1;
            if (dgvDetalle != null)
            {
                if (dgvDetalle.Rows.Count > 0)
                {
                    #region Agregar a una Lista las filas con Check()

                    foreach (var item in dgvDetalle.Rows)
                    {
                        // que no tome en cuenta ningun registro que no este asociado a un movimiento de transporte
                        if (item.Cells["chCodigoMovimiento"].Value != null && item.Cells["chCodigoMovimiento"].Value.ToString().Trim() != "")
                        {
                            #region Agregar a Lista de CheckActivados()

                            if (item.Cells["chSelecionado"].Value != null && item.Cells["chSelecionado"].Value.ToString().Trim() != "")
                            {
                                if (Convert.ToInt32(item.Cells["chSelecionado"].Value) == 1)
                                {
                                    #region Agregar a Lista()
                                    SJ_RHDocPagarDetalle detalle = new SJ_RHDocPagarDetalle();
                                    detalle.Codigo = "";
                                    detalle.item = AsignarFormatoItem(numeroitem);
                                    detalle.codigoMovimiento = item.Cells["chCodigoMovimiento"].Value != null ? item.Cells["chCodigoMovimiento"].Value.ToString().Trim() : "";
                                    detalle.codServicio = "630100400000001";
                                    detalle.descripcionServicio = "TRANSPORTE DE PERSONAL";
                                    detalle.cantidad = 1;
                                    detalle.unidadMedida = "DIA";
                                    detalle.documento = item.Cells["chDocumento"].Value != null ? item.Cells["chDocumento"].Value.ToString().Trim() : "";
                                    detalle.fecha = item.Cells["chFecha"].Value != null ? Convert.ToDateTime(item.Cells["chFecha"].Value.ToString().Trim()) : (DateTime?)null;
                                    detalle.placa = item.Cells["chPlaca"].Value != null ? item.Cells["chPlaca"].Value.ToString().Trim() : "";


                                    //detalle.idTipoTransporte = item.Cells["chSelecionado"].Value != null ? item.Cells["chSelecionado"].Value.ToString().Trim() : "";
                                    detalle.tipoTransporte = item.Cells["chTipoTransporte"].Value != null ? item.Cells["chTipoTransporte"].Value.ToString().Trim() : "";

                                    detalle.recorridoIda = item.Cells["chRecorridoIda"].Value != null ? item.Cells["chRecorridoIda"].Value.ToString().Trim() : "";
                                    detalle.recorridoRegreso = item.Cells["chRecorridoVuelta"].Value != null ? item.Cells["chRecorridoVuelta"].Value.ToString().Trim() : "";

                                    detalle.nroPersonas = item.Cells["chNroPersonas"].Value != null ? Convert.ToInt32(item.Cells["chNroPersonas"].Value.ToString().Trim()) : 0;
                                    detalle.precio = item.Cells["chPrecio"].Value != null ? Convert.ToDecimal(item.Cells["chPrecio"].Value.ToString().Trim()) : 0;
                                    detalle.vventa = item.Cells["chSubTotal"].Value != null ? Convert.ToDecimal(item.Cells["chSubTotal"].Value.ToString().Trim()) : 0;
                                    detalle.igv = item.Cells["chIgv"].Value != null ? Convert.ToDecimal(item.Cells["chIgv"].Value.ToString().Trim()) : 0;

                                    detalle.promedioPersona = item.Cells["chPromedioPersona"].Value != null ? Convert.ToDecimal(item.Cells["chPromedioPersona"].Value.ToString().Trim()) : 0;
                                    detalle.importe = item.Cells["chTotal"].Value != null ? Convert.ToDecimal(item.Cells["chTotal"].Value.ToString().Trim()) : 0;
                                    detalle.importeMof = item.Cells["chTotal"].Value != null ? Convert.ToDecimal(item.Cells["chTotal"].Value.ToString().Trim()) : 0;
                                    detalle.importeMex = 0;
                                    detalle.chofer = item.Cells["chChofer"].Value != null ? item.Cells["chChofer"].Value.ToString().Trim() : "";
                                    detalle.categoriaMovilidad = item.Cells["chCategoriaMovilidad"].Value != null ? item.Cells["chCategoriaMovilidad"].Value.ToString().Trim() : "";
                                    ListadetalleFacturacion.Add(detalle);
                                    numeroitem += 1;
                                    #endregion
                                }
                            }

                            #endregion
                        }
                    }

                    #endregion
                }
            }
        }

        private string AsignarFormatoItem(int numeroitem)
        {

            switch (numeroitem.ToString().Length)
            {
                case 1:
                    return "00" + numeroitem.ToString();
                    break;
                case 2:
                    return "0" + numeroitem.ToString();
                    break;
                case 3:
                    return numeroitem.ToString();
                    break;
                default:
                    return numeroitem.ToString();
                    break;
            }
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            SumarElementosSeleccionadosGrilla(sender);
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

        private void chkSelRecorrido_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            SelecionarItems("Recorrido Interno", chkSelRecorrido, 0);
        }

        private void chkSelNroPersona_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            SelecionarItems("Número Personas", chkSelNroPersona, 0);
        }

        private void chkSelFlete_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            SelecionarItems("Por flete", chkSelFlete, 0);
        }

        private void SelecionarItems(string grupoSelecion, RadCheckBox control, int controlBuscar)
        {
            if (ListadoPendientesFacturacion != null)
            {
                if (ListadoPendientesFacturacion.ToList().Count > 0)
                {

                    //List<Grupo> codigoSelecionados = (from item in  ListadoPendientesFacturacion.Where(x => x.RegistroMovimiento.ToString().Trim() == "Recorrido Interno")
                    //                                      group item by new {item.Codigo} into j
                    //                                      select new Grupo
                    //                                      {
                    //                                          Codigo = j.Key.Codigo.ToString().Trim()
                    //                                      }
                    //                                      ).ToList();   

                    var codigoSelecionados = ListadoPendientesFacturacion.Where(x => x.RegistroMovimiento.ToString().Trim() == grupoSelecion && x.IdEstado.ToString().Trim() == "PE").Select(x => x.Codigo.ToString().Trim()).ToList();

                    negocio = new MovimientoMovilidadNegocio();


                    if (control.Checked == true)
                    {
                        ListadoPendientesFacturacionF = new List<SJ_RHMovimientMovilidadPendientesFacturacionResult>();
                        ListadoPendientesFacturacionF = negocio.ActivarListaVista(1, codigoSelecionados, ListadoPendientesFacturacion);
                        ListadoPendientesFacturacion = ListadoPendientesFacturacionF;
                        if (controlBuscar == 1)
                        {

                        }
                        else
                        {
                            PresentarDatosFiltros();
                        }
                    }
                    else
                    {
                        ListadoPendientesFacturacionF = new List<SJ_RHMovimientMovilidadPendientesFacturacionResult>();
                        ListadoPendientesFacturacionF = negocio.ActivarListaVista(0, codigoSelecionados, ListadoPendientesFacturacion);
                        ListadoPendientesFacturacion = ListadoPendientesFacturacionF;
                        if (controlBuscar == 1)
                        {

                        }
                        else
                        {
                            PresentarDatosFiltros();
                        }
                    }
                }
            }
        }

        private void VisualizarItemsMovimiento(string grupoVista, RadCheckBox control, int controlBuscar)
        {
            if (ListadoPendientesFacturacion != null)
            {
                if (ListadoPendientesFacturacion.ToList().Count > 0)
                {
                    negocio = new MovimientoMovilidadNegocio();


                    var codigoSelecionados = new List<string>();

                    switch (grupoVista)
                    {
                        case "RecorridoInterno":
                            codigoSelecionados = ListadoPendientesFacturacion.Where(x => x.Movimiento.ToString().Trim() == "03").Select(x => x.Codigo.ToString().Trim()).ToList();
                            break;

                        case "Interlocalidades":
                            codigoSelecionados = ListadoPendientesFacturacion.Where(x => x.Movimiento.ToString().Trim() != "03").Select(x => x.Codigo.ToString().Trim()).ToList();
                            break;

                        case "Ucupe":
                            codigoSelecionados = ListadoPendientesFacturacion.Where(x => x.idCampoDestino.ToString().Trim() == "002").Select(x => x.Codigo.ToString().Trim()).ToList();
                            break;
                        default:
                            break;
                    }


                    if (control.Checked == true)
                    {
                        ListadoPendientesFacturacionF = new List<SJ_RHMovimientMovilidadPendientesFacturacionResult>();
                        ListadoPendientesFacturacionF = negocio.VisualizarLista(1, codigoSelecionados, ListadoPendientesFacturacion);
                        ListadoPendientesFacturacion = ListadoPendientesFacturacionF;
                        if (controlBuscar == 1)
                        {

                        }
                        else
                        {
                            PresentarDatosFiltros();
                        }

                    }
                    else
                    {
                        ListadoPendientesFacturacionF = new List<SJ_RHMovimientMovilidadPendientesFacturacionResult>();
                        ListadoPendientesFacturacionF = negocio.VisualizarLista(0, codigoSelecionados, ListadoPendientesFacturacion);
                        ListadoPendientesFacturacion = ListadoPendientesFacturacionF;
                        if (controlBuscar == 1)
                        {

                        }
                        else
                        {
                            PresentarDatosFiltros();
                        }
                    }
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle != null)
            {
                if (dgvDetalle.Rows.Count > 0)
                {
                    Exportar(this.dgvDetalle);
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
                oSemana.año = Convert.ToInt32(this.txtPeriodo.Value);
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




    }
}
