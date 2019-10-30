using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik;
using Telerik.WinControls.UI;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.Layouts;
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
using System.Data.SqlClient;
using System.Configuration;
using Telerik.WinControls.Data;
using TransportistaMto.Datos;


namespace Transportista
{
    public partial class PorcentajeDeAsistenciaARefrigeriosPorPeriodo : Form
    {
        private string periodoConsulta;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        private string periodo;
        private string año;
        private string mesDelAño;
        private string semanaDelAño;
        private string fechaDesde;
        private string fechaHasta;
        private string codigoProveedor;
        private string descripcionProveedor;
        private List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ListaAsistenciasTransferenciaMoviles;

        private List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ListaAsistenciasAgrupadas;
        private SJM_PensionesNegocios Modelo;
        private oConsultaConsolidadAsistenciaRefrigerio oConsulta;
        private RefrigeriosPensionesNegocios modeloAsistencias;
        private List<SJM_RefrigerioPensionesPersonalListaAsistenciaResult> ListadoAsistenciasTrabajosDiarioCampo;
        private PieSeries pieSeries;
        private string consumidorCodigo = string.Empty;
        private string codigoTrabajador;
        private DateTime? fechaAsistenciaLabores;
        private SJM_PensionesNegocios negocioAsistenciaPersonalHoras;
        private List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult> listadoAsistenciaByHoras;

        public PorcentajeDeAsistenciaARefrigeriosPorPeriodo()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();

        }

        public void Inicio()
        {
            try
            {
                #region
                periodoConsulta = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodoConsulta].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
                #endregion
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void CargarMeses()
        {
            Mes Meses = new Mes();

            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = Meses.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = Meses.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("13");
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

            /*
            DayOfWeek referenceDayOfWeek = DateTime.Now.DayOfWeek;
            DateTime mondayOfTheWeek, sundayOfTheWeek = DateTime.Now;

            mondayOfTheWeek = DateTime.Now;
            while (mondayOfTheWeek.DayOfWeek != DayOfWeek.Monday)
            {
                mondayOfTheWeek = mondayOfTheWeek.AddDays(-1);
            }

            sundayOfTheWeek = DateTime.Now;
            while (sundayOfTheWeek.DayOfWeek != DayOfWeek.Sunday)
            {
                sundayOfTheWeek = sundayOfTheWeek.AddDays(1);
            }
            */


            // txtSemana.Value = DiaDeLaSemana(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);


        }

        public static int DiaDeLaSemana(int day, int month, int year)
        {
            int[] mesCode = { 0, 6, 2, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
            int result = year % 100 + (year % 100) / 4 + day + mesCode[month];

            if (year / 100 == 17) result += 5;
            else if (year / 100 == 18) result += 3;
            else if (year / 100 == 19) result += 1;
            else if (year / 100 == 20) result += 0;
            else if (year / 100 == 21) result += -2;
            else if (year / 100 == 22) result += -4;

            //Vemos si es bisiesto y quitamos un día si
            //el mes es enero o febrero
            if (EsBisiesto(year) && (month == 1 || month == 2))
                result += -1;

            //Esto devuelve un número entre 0 y 7
            //que nos dá el día de la semana
            return result % 7;
        }

        private static bool EsBisiesto(int a)
        {
            return (a % 4 == 0 && a % 100 != 0) || a % 400 == 0;
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            try
            {
                periodo = this.txtPeriodo.Value.ToString() + Convert.ToDateTime(this.txtFechaDesde.Text).Month.ToString().PadLeft(2, '0');
                año = this.txtPeriodo.Value.ToString();
                mesDelAño = this.cboMes.SelectedValue.ToString().Trim();
                //semanaDelAño = this.cboMes.SelectedText.ToString().Trim();
                int x = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Convert.ToDateTime(this.txtFechaDesde.Text), CalendarWeekRule.FirstDay, Convert.ToDateTime(this.txtFechaDesde.Text).DayOfWeek);
                semanaDelAño = x.ToString().Trim();
                fechaDesde = this.txtFechaDesde.Text.ToString().Trim();
                fechaHasta = this.txtFechaHasta.Text.ToString().Trim();
                codigoProveedor = this.txtDNIProveedor.Text.ToString().Trim();
                descripcionProveedor = this.txtRazonSocialProveedor.Text.ToString().Trim();

                progresbarProceso.Visible = true;

                oConsulta = new oConsultaConsolidadAsistenciaRefrigerio();
                oConsulta.fechaDesde = this.txtFechaDesde.Text;
                oConsulta.fechaHasta = this.txtFechaHasta.Text;
                oConsulta.periodo = this.txtPeriodo.Value.ToString() + this.txtFechaDesde.Text.Substring(3, 2);
                oConsulta.año = this.txtPeriodo.Value.ToString();
                oConsulta.nroDniPension = this.txtDNIProveedor.Text;
                oConsulta.nroRuc = this.txtNroRucProveedor.Text.Trim();
                oConsulta.nombrePension = this.txtRazonSocialProveedor.Text.Trim();



                gbConsulta.Enabled = false;
                bgwProceso.RunWorkerAsync();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString().Trim() + "\nConsultar Datos", "MENSAJE DEL SISTEMA");
            }
        }

        private void CargarListaPieSeries()
        {
            this.chartGrafico.Series.Clear();
            pieSeries = new PieSeries();
            pieSeries.ValueMember = "porcentaje";
            pieSeries.LegendTitleMember = "observacion";
            pieSeries.DataSource = ListaAsistenciasTransferenciaMoviles;
            pieSeries.ShowLabels = true;
            pieSeries.DrawLinesToLabels = true;
            pieSeries.SyncLinesToLabelsColor = true;
            this.chartGrafico.Series.Add(pieSeries);
            this.chartGrafico.ShowLegend = true;
            this.chartGrafico.View.Margin = new Padding(20);
            this.chartGrafico.Title = "Distribución de asistencia por consumidores";
            this.chartGrafico.ShowTitle = true;
            this.chartGrafico.ChartElement.TitlePosition = TitlePosition.Top;
            this.chartGrafico.ChartElement.TitleElement.TextAlignment = ContentAlignment.MiddleCenter;




        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CargarListaPieSeries();

            dgvResumen.DataSource = ListaAsistenciasTransferenciaMoviles.ToDataTable<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
            dgvResumen.Refresh();

            dgvAgrupado.DataSource = ListaAsistenciasAgrupadas.ToDataTable<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
            dgvAgrupado.Refresh();

            progresbarProceso.Visible = false;
            gbConsulta.Enabled = true;
        }

        private void bgwProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            RealizarConsultaBD();
        }

        private void RealizarConsultaBD()
        {
            try
            {
                #region Ejecutar Consulta()
                ListaAsistenciasTransferenciaMoviles = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                ListaAsistenciasAgrupadas = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                Modelo = new SJM_PensionesNegocios();
                var oListaAsistenciasTransferenciaMoviles = Modelo.ObtenerListaAsistenciasPersonalPendientesMovimientoAsistencia(oConsulta.año, oConsulta.fechaDesde, oConsulta.fechaHasta, oConsulta.nroDniPension).ToList();
                ListaAsistenciasAgrupadas = Modelo.ObtenerListadoAsistenciaByConsumidores(oListaAsistenciasTransferenciaMoviles, oConsulta.año, oConsulta.fechaDesde, oConsulta.fechaHasta);
                ListaAsistenciasTransferenciaMoviles = Modelo.ObtenerListadoAsistenciaByConsumidoresAgrupado(ListaAsistenciasAgrupadas).ToList();
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void PorcentajeDeAsistenciaARefrigeriosPorPeriodo_Load(object sender, EventArgs e)
        {

        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboMes.SelectedIndex >= 0)
            {
                ObtenerFechasMes();
            }
        }

        private void txtSemana_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasSemanalesByNumeroSemana();
        }


        private void LoadFreightSummary()
        {
            this.dgvResumen.MasterTemplate.AutoExpandGroups = true;
            this.dgvResumen.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvResumen.GroupDescriptors.Clear();
            this.dgvResumen.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chConsumidorDescripcion", "Registros: {0:N0}; ", GridAggregateFunction.Count));
            this.dgvResumen.MasterTemplate.SummaryRowsTop.Add(item);



            this.dgvAgrupado.MasterTemplate.AutoExpandGroups = true;
            this.dgvAgrupado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvAgrupado.GroupDescriptors.Clear();
            this.dgvAgrupado.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item2 = new GridViewSummaryRowItem();
            item2.Add(new GridViewSummaryItem("chNombresTrabajador", "Registros: {0:N0}; ", GridAggregateFunction.Count));
            this.dgvAgrupado.MasterTemplate.SummaryRowsTop.Add(item2);



            this.dgvDetalle.MasterTemplate.AutoExpandGroups = true;
            this.dgvDetalle.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.GroupDescriptors.Clear();
            this.dgvDetalle.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item3 = new GridViewSummaryRowItem();
            item3.Add(new GridViewSummaryItem("chLabor", "Registros: {0:N0}; ", GridAggregateFunction.Count));
            item3.Add(new GridViewSummaryItem("chhorasTrabajadas", "Registros: {0:N0}; ", GridAggregateFunction.Sum));
            item3.Add(new GridViewSummaryItem("chracimosTrabajador", "Registros: {0:N0}; ", GridAggregateFunction.Sum));
            this.dgvDetalle.MasterTemplate.SummaryRowsTop.Add(item3);

        }

        protected override void OnLoad(EventArgs e)
        {

            this.dgvAgrupado.TableElement.BeginUpdate();
            this.dgvResumen.TableElement.BeginUpdate();
            this.LoadFreightSummary();
            this.dgvAgrupado.TableElement.EndUpdate();
            this.dgvResumen.TableElement.EndUpdate();
            base.OnLoad(e);



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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvResumen_SelectionChanged(object sender, EventArgs e)
        {
            consumidorCodigo = string.Empty;
            SumarElementosSeleccionadosGrilla(sender);

            if (dgvResumen != null && dgvResumen.Rows.Count > 0)
            {
                if (dgvResumen.CurrentRow != null && dgvResumen.CurrentRow.Cells["chConsumidor"].Value != "" && dgvResumen.CurrentRow.Cells["chConsumidor"].Value != null)
                {
                    consumidorCodigo = dgvResumen.CurrentRow.Cells["chConsumidor"].Value.ToString().Trim();
                }
            }
        }

        private void dgvResumen_DoubleClick(object sender, EventArgs e)
        {
            if (consumidorCodigo != string.Empty)
            {
                tabControl.SelectedPage = tabAgrupado;
                FilterDescriptor filter = new FilterDescriptor();
                filter.PropertyName = "chConsumidor";
                filter.Operator = FilterOperator.IsEqualTo;
                filter.Value = consumidorCodigo.ToString();
                filter.IsFilterEditor = true;
                if (this.dgvAgrupado.FilterDescriptors.Count > 0)
                {
                    this.dgvAgrupado.FilterDescriptors.Clear();
                }
                this.dgvAgrupado.FilterDescriptors.Add(filter);
                dgvAgrupado.Refresh();

            }
        }

        private void dgvAgrupado_SelectionChanged(object sender, EventArgs e)
        {
            codigoTrabajador = string.Empty;
            fechaAsistenciaLabores = (DateTime?)null;
            SumarElementosSeleccionadosGrilla(sender);


            if (dgvAgrupado != null && dgvAgrupado.Rows.Count > 0)
            {
                if (dgvAgrupado.CurrentRow != null && dgvAgrupado.CurrentRow.Cells["chCodigoGeneral"].Value != "" && dgvAgrupado.CurrentRow.Cells["chCodigoGeneral"].Value != null)
                {
                    if (dgvAgrupado.CurrentRow != null && dgvAgrupado.CurrentRow.Cells["chFecha"].Value != "" && dgvAgrupado.CurrentRow.Cells["chFecha"].Value != null)
                    {
                        codigoTrabajador = dgvAgrupado.CurrentRow.Cells["chCodigoGeneral"].Value.ToString().Trim();
                        fechaAsistenciaLabores = dgvAgrupado.CurrentRow.Cells["chFecha"].Value != null ? Convert.ToDateTime(dgvAgrupado.CurrentRow.Cells["chFecha"].Value) : (DateTime?)null;
                    }
                }
            }
        }

        private void dgvAgrupado_DoubleClick(object sender, EventArgs e)
        {
            if (codigoTrabajador != string.Empty && fechaAsistenciaLabores != (DateTime?)null)
            {
                tabControl.SelectedPage = tabDetalle;
                negocioAsistenciaPersonalHoras = new SJM_PensionesNegocios();
                listadoAsistenciaByHoras = new List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
                listadoAsistenciaByHoras = negocioAsistenciaPersonalHoras.ObtenerlistadoAsistenciasByHorasByTrabajadasByPeriodo(fechaAsistenciaLabores.ToPresentationDate(), fechaAsistenciaLabores.ToPresentationDate(), codigoTrabajador.ToString().Trim()).ToList();

                dgvDetalle.DataSource = listadoAsistenciaByHoras.ToDataTable<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
                dgvDetalle.Refresh();
            }
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            SumarElementosSeleccionadosGrilla(sender);
        }



    }
}
