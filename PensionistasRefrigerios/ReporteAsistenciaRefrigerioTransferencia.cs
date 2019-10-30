using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.ViewModels;
using Telerik.WinControls.UI;
using Telerik.Pivot.Core.Aggregates;
using TransportistaMto.Datos;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ReporteAsistenciaRefrigerioTransferencia : Telerik.WinControls.UI.RadForm
    {
        #region Declaracion variables()
        private Telerik.WinControls.UI.Export.PivotExportToExcelML exporter;
        private string desde;
        private string hasta;
        private string idPension;
        private SJM_PensionesNegocios modelo;
        private List<SJ_RHConsultarHistorialAsistenciaRefrigerioxPensionResult> listadoAsistenciaTransferenciaMovilPension;
        private bool esDesconocido = false;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        private List<SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupadoResult> listadoAsistenciaTransferenciaMovilPensionAgrupado;
        #endregion

        public ReporteAsistenciaRefrigerioTransferencia()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            PivotGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.PivotGridLocalizationProviderEspanol();
            ObtenerFechasIniciales();
            CargarMeses();
            this.exporter = new Telerik.WinControls.UI.Export.PivotExportToExcelML(this.dgvGrillaPrivot);
            this.exporter.PivotExcelCellFormatting += new Telerik.WinControls.UI.Export.PivotExcelCellFormattingEvent(exporter_PivotExcelCellFormatting);
        }

        void exporter_PivotExcelCellFormatting(object sender, Telerik.WinControls.UI.Export.ExcelPivotCellExportingEventArgs e)
        {
            this.ProgressBar.Maximum = e.RowsCount + 1;
            if (this.ProgressBar.Value < this.ProgressBar.Maximum)
            {
                this.ProgressBar.Value++;
            }
            //decimal value = 0;
            //if (decimal.TryParse(e.Cell.Text, out value))
            //{
            //    if (value > 1000)
            //        e.Cell.BackColor = System.Drawing.Color.Red;
            //    if (value < 100)
            //        e.Cell.BackColor = System.Drawing.Color.Green;
            //}
            Application.DoEvents();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel ML|*.xls";
            saveFileDialog1.Title = "Export to File"; saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                this.exporter.RunExport(saveFileDialog1.FileName);
                MessageBox.Show("La exportacion fue realizada correctamente " + saveFileDialog1.FileName, "Mensaje de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ProgressBar.Value = 0;
                try
                {
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                }
                finally
                {
                }
            }
        }

        private void btnBuscarTransportista_Click(object sender, EventArgs e)
        {
            //this.txtDNIProveedor.Clear();
            //this.txtRazonSocialProveedor.Clear();
            //BuscarPension oFrm = new BuscarPension();
            //if (oFrm.ShowDialog() == DialogResult.OK)
            //{
            //    if (oFrm.ObjetoBusquedaPension != null)
            //    {
            //        try
            //        {
            //            this.txtRUCProveedor.Text = oFrm.ObjetoBusquedaPension.NroDNI;
            //            this.txtDNIProveedor.Text = oFrm.ObjetoBusquedaPension.RazonSocial;
            //        }
            //        catch (Exception Ex)
            //        {
            //            throw Ex;
            //        }
            //    }
            //}
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (this.txtDNIProveedor.Text != null)
            {
                ProgressBar.Visible = true;
                gbConsulta.Enabled = false;
                Consultar();
            }
        }

        private void Consultar()
        {
            try
            {
                desde = this.txtFechaDesde.Text.ToString().Trim();
                hasta = this.txtFechaHasta.Text.ToString().Trim();
                idPension = this.txtDNIProveedor.Text.ToString().Trim();
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            ListarPersonal();
        }

        private void ListarPersonal()
        {
            try
            {
                #region
                modelo = new SJM_PensionesNegocios();
                listadoAsistenciaTransferenciaMovilPension = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioxPensionResult>();
                listadoAsistenciaTransferenciaMovilPensionAgrupado = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupadoResult>();
                var listadoConsulta = modelo.ObtnerListaHistorialRefrigerioxPension(desde, hasta, idPension).ToList();

                //if (chkIncluirDesconocido.Checked == false)
                //{
                //    var personalDesconocido = listadoConsulta.Where(x => x.NombresTrabajador.Contains("DESCONOCIDO")).ToList();

                //    personalDesconocido = (from items in listadoConsulta
                //               where !(personalDesconocido.Contains(items.NombresTrabajador.ToString()))
                //               select items
                //          ).ToList();

                //}

                if (idPension.Trim() != "")
                {
                    listadoAsistenciaTransferenciaMovilPensionAgrupado = modelo.ObtnerListaAsistenciasValidasRefrigerioAgrupado(desde, hasta, idPension).ToList();
                }
                else
                {
                    modelo = new SJM_PensionesNegocios();
                    idPension = modelo.ObtenerDniPension();

                    listadoAsistenciaTransferenciaMovilPensionAgrupado = modelo.ObtnerListaAsistenciasValidasRefrigerioAgrupado(desde, hasta, idPension).ToList();
                }



                if (esDesconocido == true)
                {
                    /* incluir */
                    listadoAsistenciaTransferenciaMovilPension = modelo.ObtnerListaHistorialRefrigerioxPension(desde, hasta, idPension).ToList();
                }
                else
                {
                    /* No incluir */
                    listadoAsistenciaTransferenciaMovilPension = listadoConsulta.Where(x => (x.NombresTrabajador).ToString().Trim().Substring(0, 11) != "Desconocido".ToUpper()).ToList();
                }

                #endregion
            }
            catch (Exception Ex)
            {
                #region
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
                #endregion
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarListadoAsistenciaPersonal();
        }

        private void PresentarListadoAsistenciaPersonal()
        {
            try
            {
                #region
                if (listadoAsistenciaTransferenciaMovilPension != null && listadoAsistenciaTransferenciaMovilPension.ToList().Count > 0)
                {
                    dgvGrillaPrivot.DataSource = listadoAsistenciaTransferenciaMovilPension.ToDataTable<SJ_RHConsultarHistorialAsistenciaRefrigerioxPensionResult>();

                    if (dgvGrillaPrivot.AggregateDescriptions.Count > 0)
                    {
                        //this.dgvGrillaPrivot.AggregateDescriptions.RemoveAt(0);
                    }
                    else
                    {
                        this.dgvGrillaPrivot.AggregateDescriptions.Add(new PropertyAggregateDescription() { PropertyName = "Asistencia", AggregateFunction = AggregateFunctions.Count });
                    }

                    //dgvGrillaPrivot.ColumnsSubTotalsPosition = TotalsPos.None;
                    //dgvGrillaPrivot.ColumnGrandTotalsPosition = TotalsPos.None;
                    //dgvGrillaPrivot.RowGrandTotalsPosition = TotalsPos.None;
                    //dgvGrillaPrivot.RowsSubTotalsPosition = TotalsPos.None;
                    dgvGrillaPrivot.Refresh();
                }
                else
                {
                    listadoAsistenciaTransferenciaMovilPension = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioxPensionResult>();
                    dgvGrillaPrivot.DataSource = listadoAsistenciaTransferenciaMovilPension.ToDataTable<SJ_RHConsultarHistorialAsistenciaRefrigerioxPensionResult>();
                    if (dgvGrillaPrivot.AggregateDescriptions.Count > 0)
                    {
                        this.dgvGrillaPrivot.AggregateDescriptions.RemoveAt(0);
                    }

                    //ObtenerValorChecksubTotalVertical();
                    //ObtenerValorChecksubTotalHorizontal();

                    //dgvGrillaPrivot.ColumnsSubTotalsPosition = TotalsPos.None;
                    //dgvGrillaPrivot.ColumnGrandTotalsPosition = TotalsPos.None;
                    //dgvGrillaPrivot.RowGrandTotalsPosition = TotalsPos.None;
                    //dgvGrillaPrivot.RowsSubTotalsPosition = TotalsPos.None;

                    dgvGrillaPrivot.Refresh();
                }

                gbConsulta.Enabled = true;
                ProgressBar.Visible = false;
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ReporteAsistenciasRefrigerioTransferencia_Load(object sender, EventArgs e)
        {

        }

        private void CargarMeses()
        {
            Mes Meses = new Mes();

            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = Meses.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = Meses.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void ObtenerFechasIniciales()
        {
            this.txtPeriodo.Text = DateTime.Now.Year.ToString();
            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();


            modeloSemana = new SJ_SemanaNegocio();
            oSemana = new SJ_Semana();
            oSemanaConsulta = new SJ_Semana();
            oSemana.año = Convert.ToInt32(this.txtPeriodo.Value);
            oSemana.semana = Convert.ToInt32(this.txtSemana.Value);

            oSemanaConsulta = modeloSemana.ObtenerSemanaPorNroSemana(oSemana);


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
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtPeriodo.Text.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Text.ToString());// 
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
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtPeriodo.Text.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Text.ToString());// 
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
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtPeriodo.Text.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtPeriodo.Text.ToString());//
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();
                }
            }
        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void chkIncluirDesconocido_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ObtenerValorCheckDesconocido();
        }

        private void ObtenerValorCheckDesconocido()
        {
            if (chkIncluirDesconocido.Checked == true)
            {
                esDesconocido = true;
            }
            else
            {
                esDesconocido = false;
            }
        }

        private void chkIncluirSubTotalesVertical_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ObtenerValorChecksubTotalVertical();
        }

        private void chkIncluirSubTotalesHorizontal_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ObtenerValorChecksubTotalHorizontal();
        }

        private void ObtenerValorChecksubTotalVertical()
        {
            if (chkIncluirSubTotalesVertical.Checked == true)
            {
                subTotalVertical = true;
                if (listadoAsistenciaTransferenciaMovilPension != null && listadoAsistenciaTransferenciaMovilPension.ToList().Count > 0)
                {
                    dgvGrillaPrivot.ColumnsSubTotalsPosition = TotalsPos.First;
                    //dgvGrillaPrivot.ColumnGrandTotalsPosition = TotalsPos.None;
                }
            }
            else
            {
                subTotalVertical = false;
                if (listadoAsistenciaTransferenciaMovilPension != null && listadoAsistenciaTransferenciaMovilPension.ToList().Count > 0)
                {
                    dgvGrillaPrivot.ColumnsSubTotalsPosition = TotalsPos.None;
                    //dgvGrillaPrivot.ColumnGrandTotalsPosition = TotalsPos.None;
                }
            }
        }

        private void ObtenerValorChecksubTotalHorizontal()
        {
            if (chkIncluirSubTotalesHorizontal.Checked == true)
            {
                subTotalHorizontal = true;
                if (listadoAsistenciaTransferenciaMovilPension != null && listadoAsistenciaTransferenciaMovilPension.ToList().Count > 0)
                {
                    dgvGrillaPrivot.RowsSubTotalsPosition = TotalsPos.First;
                    //dgvGrillaPrivot.RowGrandTotalsPosition = TotalsPos.None;
                }
            }
            else
            {
                subTotalHorizontal = false;
                if (listadoAsistenciaTransferenciaMovilPension != null && listadoAsistenciaTransferenciaMovilPension.ToList().Count > 0)
                {
                    dgvGrillaPrivot.RowsSubTotalsPosition = TotalsPos.None;
                    //dgvGrillaPrivot.RowGrandTotalsPosition = TotalsPos.None;
                }
            }
        }

        public bool subTotalVertical { get; set; }

        public bool subTotalHorizontal { get; set; }

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

        private void dgvGrillaPrivot_SelectionChanged(object sender, EventArgs e)
        {

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

                                    promedioSeleccionado = (SumaSeleccionada / (recuento > 0 ? recuento : 1));
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
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            if (listadoAsistenciaTransferenciaMovilPension != null && listadoAsistenciaTransferenciaMovilPension.ToList().Count > 0)
            {
                oFechaAsistencia datosConsulta = new oFechaAsistencia();
                datosConsulta.anio = Convert.ToInt32(this.txtPeriodo.Value);
                datosConsulta.numeroSemana = Convert.ToInt32(this.txtSemana.Value);
                datosConsulta.numeroMes = cboMes.SelectedValue != null ? cboMes.SelectedValue.ToString().Trim() : string.Empty;
                datosConsulta.fechaDesde = this.txtFechaDesde.Text.Trim();
                datosConsulta.fechaHasta = this.txtFechaHasta.Text.Trim();


                ReporteAsistenciaRefrigerioTransferenciaAnalisisGrafico ofrm = new ReporteAsistenciaRefrigerioTransferenciaAnalisisGrafico(listadoAsistenciaTransferenciaMovilPensionAgrupado, datosConsulta );
                ofrm.ShowDialog();
            }
        }

        private void btnAnularDuplicidadAsistencias_Click(object sender, EventArgs e)
        {

            try
            {
                desde = this.txtFechaDesde.Text;
                hasta = this.txtFechaHasta.Text;
                AnularDuplicidadAsistencias();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
           
        }

        private void AnularDuplicidadAsistencias()
        {
            if (this.txtDNIProveedor.Text != null)
            {
                ProgressBar.Visible = true;
                gbConsulta.Enabled = false;
                bgwProceso02.RunWorkerAsync();
            }
        }

        private void btnActualizarNombresTrabajador_Click(object sender, EventArgs e)
        {

            try
            {
                desde = this.txtFechaDesde.Text;
                hasta = this.txtFechaHasta.Text;
                ActualizarNombresTrabajador();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
                      
        }

        private void ActualizarNombresTrabajador()
        {
            if (this.txtDNIProveedor.Text != null)
            {
                ProgressBar.Visible = true;
                gbConsulta.Enabled = false;
                bgwProceso03.RunWorkerAsync();
            }
        }

        private void bgwProceso02_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SJM_PensionesNegocios modelo = new SJM_PensionesNegocios();
                modelo.ActualizarNombresColaboradorPostTransferencia(desde, hasta);
                ListarPersonal();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
            
        }

        private void bgwProceso02_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                PresentarListadoAsistenciaPersonal();
                MessageBox.Show("PROCESO REALIZADO CON ÉXITO", "MENSAJE DEL SISTEMA");
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;

            }
        }

        private void bgwProceso03_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SJM_PensionesNegocios modelo = new SJM_PensionesNegocios();
                modelo.AnularDuplicidadAsistencia(desde, hasta);
                ListarPersonal();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
           
        }

        private void bgwProceso03_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                PresentarListadoAsistenciaPersonal();
                MessageBox.Show("PROCESO REALIZADO CON ÉXITO", "MENSAJE DEL SISTEMA");
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;

            }
        }

        private void btnBuscarTransportista_Click_1(object sender, EventArgs e)
        {

        }

    }

}
