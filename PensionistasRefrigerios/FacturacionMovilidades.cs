using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using TransportistaMto.Datos;
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
    public partial class FacturacionMovilidades : Telerik.WinControls.UI.RadForm
    {
        private Mes MesesNeg;
        private string desde;
        private string hasta;
        private string periodo;
        private SJ_RHDocPagarNegocio modelo;
        private SJ_RHDocPagarAsociadoNegocios modeloDocumentoAsociado;
        private List<SJ_RHDocPagarListarxPeriodoResult> Listado;
        private string codigo;
        private string documentoFac;
        private string fechaDoc;
        private string rucProveedor;
        private string proveedorDescripcion;
        private string proveedorDocumento;
        private string proveedorFechaDoc;
        private FacturacionMovilidadesImprimirResumen vistaPreviaReporte;
        private FacturacionMovilidadesImprimirDetalle vistaPreviaReporteDetalle;
        private string fileName;
        private bool exportVisualSettings;
        private int reportePresentar = 0;
        private string documentoFacAsociada;

        public FacturacionMovilidades()
        {
            try
            {
                InitializeComponent();
                RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
                RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
                RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
                RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
                CargarMeses();
                ObtenerFechasIniciales();
                ObtenerValoresConsultaBuscar();
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                return;
            }
        }

        private void ObtenerFechasIniciales()
        {
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);

            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);
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

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                modelo = new SJ_RHDocPagarNegocio();
                Listado = new List<SJ_RHDocPagarListarxPeriodoResult>();
                Listado = modelo.ListarDocumentosAPagar(periodo, desde, hasta).ToList();
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
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
                HabilitarControlesxBusqueda(false);
                ObtenerValoresConsultaBuscar();
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        }

        private void ObtenerValoresConsultaBuscar()
        {
            try
            {
                desde = this.txtFechaDesde.Text.ToString().Trim();
                hasta = this.txtFechaHasta.Text.ToString().Trim();
                periodo = this.txtAño.Value.ToString().Trim();
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        }

        private void HabilitarControlesxBusqueda(bool estado)
        {
            btnConsultar.Enabled = estado;
            cboMes.Enabled = estado;
            progressBar.Visible = !estado;
            this.txtFechaDesde.Enabled = estado;
            this.txtFechaHasta.Enabled = estado;
            this.txtAño.Enabled = estado;
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarDatos();
        }

        private void PresentarDatos()
        {
            try
            {
                dgvListaResultados.DataSource = Listado.ToDataTable<SJ_RHDocPagarListarxPeriodoResult>();
                dgvListaResultados.Refresh();
                HabilitarControlesxBusqueda(true);
            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.dgvListaResultados.TableElement.BeginUpdate();
            //this.dgvRecorridos.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvListaResultados.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvListaResultados.MasterTemplate.AutoExpandGroups = true;
            this.dgvListaResultados.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvListaResultados.GroupDescriptors.Clear();
            this.dgvListaResultados.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chNombresTrabajador", "# Reg: {0:N0}; ", GridAggregateFunction.Count));
            item.Add(new GridViewSummaryItem("chimporte", "Sum: {0:N2}; ", GridAggregateFunction.Sum));
            //this.dgvRefrigerios.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvListaResultados.MasterTemplate.SummaryRowsTop.Add(item);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (codigo != "")
            {
                FacturacionMovilidadesEdicion ofrm = new FacturacionMovilidadesEdicion(codigo, periodo);
                ofrm.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FacturacionMovilidades_Load(object sender, EventArgs e)
        {

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {
                SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                docPagar.codigo = codigo;
                modelo = new SJ_RHDocPagarNegocio();
                modelo.AnularDocumentoDeFacturacion(docPagar);
                MessageBox.Show("Se ha registrado correctamente el cambio de estado", "MENSAJE DEL SISTEMA");
                Consultar();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public string estadoDocumento { get; set; }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (this.dgvListaResultados != null)
            {
                if (dgvListaResultados.Rows.Count > 0)
                {
                    Exportar(this.dgvListaResultados);
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
            excelExporter.SheetName = "Fac. Transportista";
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



        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void ObtenerDatosParaReporte()
        {
            try
            {


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "Realizar consulta para mostrar reporte", "MENSAJE DEL SISTEMA");
                menuPrincipal.Enabled = true;
                return;
            }
        }


        private void PresentarReportes()
        {
            try
            {
                if (reportePresentar == 0)
                {
                    vistaPreviaReporte = new FacturacionMovilidadesImprimirResumen(codigo);
                    vistaPreviaReporte.AgregarParametroCadena("@Documento", documentoFac.ToString().Trim());
                    vistaPreviaReporte.AgregarParametroCadena("@FechaDoc", fechaDoc.ToString().Trim());
                    vistaPreviaReporte.AgregarParametroCadena("@RucProveedor", rucProveedor.ToString().Trim());
                    vistaPreviaReporte.AgregarParametroCadena("@ProveedorDescripcion", proveedorDescripcion.ToString().Trim());
                    vistaPreviaReporte.AgregarParametroCadena("@ProveedorDocumento", proveedorDocumento.ToString().Trim());
                    vistaPreviaReporte.AgregarParametroCadena("@ProveedorFechaDoc", proveedorFechaDoc.ToString().Trim());
                    vistaPreviaReporte.AgregarParametroCadena("@codigo", codigo.ToString().Trim());
                    vistaPreviaReporte.AgregarParametroCadena("@nombreUsuario", Environment.UserName.ToString().Trim());
                    vistaPreviaReporte.ShowDialog();
                }
                else if (reportePresentar == 1)
                {
                    vistaPreviaReporteDetalle = new FacturacionMovilidadesImprimirDetalle(codigo);
                    vistaPreviaReporteDetalle.AgregarParametroCadena("@Documento", documentoFac.ToString().Trim());
                    vistaPreviaReporteDetalle.AgregarParametroCadena("@FechaDoc", fechaDoc.ToString().Trim());
                    vistaPreviaReporteDetalle.AgregarParametroCadena("@RucProveedor", rucProveedor.ToString().Trim());
                    vistaPreviaReporteDetalle.AgregarParametroCadena("@ProveedorDescripcion", proveedorDescripcion.ToString().Trim());
                    vistaPreviaReporteDetalle.AgregarParametroCadena("@ProveedorDocumento", proveedorDocumento.ToString().Trim());
                    vistaPreviaReporteDetalle.AgregarParametroCadena("@ProveedorFechaDoc", proveedorFechaDoc.ToString().Trim());
                    vistaPreviaReporteDetalle.AgregarParametroCadena("@codigo", codigo.ToString().Trim());
                    vistaPreviaReporteDetalle.AgregarParametroCadena("@nombreUsuario", Environment.UserName.ToString().Trim());
                    vistaPreviaReporteDetalle.AgregarParametroCadena("@documentoAsociado", documentoFacAsociada);
                    vistaPreviaReporteDetalle.ShowDialog();
                }





                menuPrincipal.Enabled = true;
                progressBar.Visible = false;
                lblresultados.Text = "";
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString() + "Presentar reporte", "MENSAJE DEL SISTEMA");
                menuPrincipal.Enabled = true;
                progressBar.Visible = false;
                lblresultados.Text = "";
                return;
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            if (codigo != null && codigo != "")
            {
                bgwImprimir.RunWorkerAsync();
            }
        }

        private void dgvLista_Click(object sender, EventArgs e)
        {

        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {

            SumarElementosSeleccionadosGrilla(sender);

            btnImprimir.Enabled = false;
            btnVistaPrevia.Enabled = false;
            btnAnular.Enabled = false;
            btnEliminar.Enabled = false;
            btnEliminar.Enabled = false;

            sbmAnularDocumentoVenta.Enabled = false;
            sbmeditarDocumentoVenta.Enabled = false;
            sbmEliminarDocumentoVenta.Enabled = false;
            sbmImprimirDocumentoVenta.Enabled = false;
            sbmDocumentoDePagoDetallado.Enabled = false;
            sbmDocumentoDePagoResumido.Enabled = false;
            sbmVerDistribucionDocumentoVenta.Enabled = false;
            sbmVerVistaPreviaDocumentoVenta.Enabled = false;

            codigo = "";
            periodo = this.txtAño.Value.ToString().Trim();
            estadoDocumento = "";
            documentoFac = "";
            fechaDoc = "";
            rucProveedor = "";
            proveedorDescripcion = "";
            proveedorDocumento = "";
            proveedorFechaDoc = "";
            documentoFacAsociada = "";


            if (dgvListaResultados != null && dgvListaResultados.CurrentRow != null)
            {
                if (dgvListaResultados.Rows.Count > 0)
                {
                    if (dgvListaResultados.CurrentRow.Cells["chCodigo"].Value != null && dgvListaResultados.CurrentRow != null)
                    {
                        if (dgvListaResultados.CurrentRow.Cells["chCodigo"].Value.ToString().Trim() != "")
                        {
                            codigo = dgvListaResultados.CurrentRow.Cells["chCodigo"].Value != null ? dgvListaResultados.CurrentRow.Cells["chCodigo"].Value.ToString().Trim() : "";
                            periodo = this.txtAño.Value.ToString().Trim();
                            estadoDocumento = dgvListaResultados.CurrentRow.Cells["chEstado"].Value != null ? dgvListaResultados.CurrentRow.Cells["chEstado"].Value.ToString().Trim() : "";
                            documentoFac = dgvListaResultados.CurrentRow.Cells["chDocumento"].Value != null ? dgvListaResultados.CurrentRow.Cells["chDocumento"].Value.ToString().Trim() : "";
                            fechaDoc = dgvListaResultados.CurrentRow.Cells["chFecha"].Value != null ? dgvListaResultados.CurrentRow.Cells["chFecha"].Value.ToString().Trim() : "";
                            rucProveedor = dgvListaResultados.CurrentRow.Cells["chidclieprov"].Value != null ? dgvListaResultados.CurrentRow.Cells["chidclieprov"].Value.ToString().Trim() : "";
                            proveedorDescripcion = dgvListaResultados.CurrentRow.Cells["chProveedor"].Value != null ? dgvListaResultados.CurrentRow.Cells["chProveedor"].Value.ToString().Trim() : "";
                            proveedorDocumento = dgvListaResultados.CurrentRow.Cells["chDocumentoProveedor"].Value != null ? dgvListaResultados.CurrentRow.Cells["chDocumentoProveedor"].Value.ToString().Trim() : "";
                            proveedorFechaDoc = dgvListaResultados.CurrentRow.Cells["chFecha"].Value != null ? dgvListaResultados.CurrentRow.Cells["chFecha"].Value.ToString().Trim() : "";
                            documentoFacAsociada = "";
                            if (codigo != null && codigo.ToString().Trim() != "")
                            {
                                modeloDocumentoAsociado = new SJ_RHDocPagarAsociadoNegocios();
                                SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                                docPagar.codigo = codigo.ToString().Trim();
                                SJ_RHDocPagarAsociado docAsociado = modeloDocumentoAsociado.ObtenerObjeto(docPagar);
                                if (docAsociado.numero != null && docAsociado.serie != null)
                                {
                                    if (docAsociado.numero.ToString().Trim() != "" && docAsociado.serie.ToString().Trim() != "")
                                    {
                                        documentoFacAsociada = docAsociado.idDocumento.ToString().Trim() + " - " + docAsociado.serie.ToString().Trim() + " - " + docAsociado.numero.ToString().Trim();
                                    }
                                }
                            }

                            btnImprimir.Enabled = true;
                            btnVistaPrevia.Enabled = true;
                            btnAnular.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnExportar.Enabled = true;
                            sbmDocumentoDePagoDetallado.Enabled = true;
                            sbmDocumentoDePagoResumido.Enabled = true;
                            sbmAnularDocumentoVenta.Enabled = true;
                            sbmeditarDocumentoVenta.Enabled = true;
                            sbmEliminarDocumentoVenta.Enabled = true;
                            sbmImprimirDocumentoVenta.Enabled = true;
                            sbmVerDistribucionDocumentoVenta.Enabled = true;
                            sbmVerVistaPreviaDocumentoVenta.Enabled = true;

                        }
                    }
                }
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {

                FacturacionMovilidadesEdicion newMDIChild = new FacturacionMovilidadesEdicion(codigo, periodo);
                newMDIChild.MdiParent = FacturacionMovilidades.ActiveForm;
                newMDIChild.Show();
                newMDIChild.WindowState = FormWindowState.Maximized;

            }
        }

        private void sbmVerVistaPreviaDocumentoVenta_Click(object sender, EventArgs e)
        {

        }

        private void bgwImprimir_DoWork(object sender, DoWorkEventArgs e)
        {
            ObtenerDatosParaReporte();
        }

        private void bgwImprimir_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarReportes();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {
                SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                docPagar.codigo = codigo;
                modelo = new SJ_RHDocPagarNegocio();
                modelo.EliminarDocumentoDeFacturacion(docPagar);
                MessageBox.Show("Se ha elimiado correctamente el cambio de estado", "MENSAJE DEL SISTEMA");
                Consultar();
            }
        }

        private void sbmEliminarDocumentoVenta_Click(object sender, EventArgs e)
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {
                SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                docPagar.codigo = codigo;
                modelo = new SJ_RHDocPagarNegocio();
                modelo.EliminarDocumentoDeFacturacion(docPagar);
                MessageBox.Show("Se ha elimiado correctamente el cambio de estado", "MENSAJE DEL SISTEMA");
                Consultar();
            }
        }

        private void sbmAnularDocumentoVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnAnularDocumento_Click(object sender, EventArgs e)
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {
                SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                docPagar.codigo = codigo;
                modelo = new SJ_RHDocPagarNegocio();
                modelo.AnularDocumentoDeFacturacion(docPagar);
                MessageBox.Show("Se ha registrado correctamente el cambio de estado", "MENSAJE DEL SISTEMA");
                Consultar();
            }
        }

        private void btnEditarDocumento_Click(object sender, EventArgs e)
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {
                FacturacionMovilidadesEdicion newMDIChild = new FacturacionMovilidadesEdicion(codigo, periodo);
                newMDIChild.MdiParent = FacturacionMovilidades.ActiveForm;
                newMDIChild.Show();
                newMDIChild.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnEliminarDocumento_Click(object sender, EventArgs e)
        {
            if (codigo != null && codigo.ToString().Trim() != "")
            {
                SJ_RHDocPagar docPagar = new SJ_RHDocPagar();
                docPagar.codigo = codigo;
                modelo = new SJ_RHDocPagarNegocio();
                modelo.EliminarDocumentoDeFacturacion(docPagar);
                MessageBox.Show("Se ha elimiado correctamente el cambio de estado", "MENSAJE DEL SISTEMA");
                Consultar();
            }
        }

        private void btnImprimirResumen_Click(object sender, EventArgs e)
        {
            if (this.dgvListaResultados != null)
            {
                if (dgvListaResultados.Rows.Count > 0)
                {
                    ImprimirVistaResumen(Listado);
                }
            }
        }

        private void ImprimirVistaResumen(List<SJ_RHDocPagarListarxPeriodoResult> Listado)
        {
            throw new NotImplementedException();
        }

        private void documentoDePagoResumidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportePresentar = 0;
            if (codigo != null && codigo != "")
            {
                progressBar.Visible = true;
                lblresultados.Text = "Generando reporte";
                bgwImprimir.RunWorkerAsync();
            }
        }

        private void documentoDePagoDetalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportePresentar = 1;
            if (codigo != null && codigo != "")
            {
                progressBar.Visible = true;
                lblresultados.Text = "Generando reporte";
                bgwImprimir.RunWorkerAsync();
            }
        }

    }
}
