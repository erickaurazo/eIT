using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Transportista.Negocios;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ReporteAsistenciaRefrigerio : RadForm
    {
        #region declaracion de variables()
        private RefrigeriosPensionesNegocios PensionModelo;
        private List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult> ListadoGeneralPensionistas;
        private string fechaDesde;
        private string fechaHasta;
        private string nombreArchivo;
        private bool exportVisualSettings;
        private List<RefrigerioAgrupado> ListadoGeneralPensionistasAgrupado;
        private string codigoProveedor;
        private PersonalCampo personal;
        private List<RefrigerioAgrupado> listadoResumenAsistenciaRefrigerios;
        private List<IndicadorAsistencia> listaAsistenciaxRendimiento;
        private List<IndicadorAsistencia> listaAsistenciaxHorasTrabajadas;
        private string periodo;
        private List<SJ_RHDistribucionFacturacion> listadoDistribucionMovimientoFacturacionPensiones;
        private string codigoReporte;
        private string año;
        private string mesDelAño;
        private string semanaDelAño;
        private string descripcionProveedor;
        private RefrigerioAgrupado asistenciaPersonal;
        private string periodoConsulta;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        private ExportToExcelML excelExporter;
        #endregion

        public ReporteAsistenciaRefrigerio()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            //lblUsuario.Text = UsuarioGlobales.sjUsuario.IdUsuario;
            Inicio();
            CargarMeses();
            ComprobarEstadoDiaActual();
            ObtenerFechasIniciales();


        }

        private void LoadFreightSummary()
        {
            this.dgvDetalleAsistencia.MasterTemplate.AutoExpandGroups = true;
            this.dgvDetalleAsistencia.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleAsistencia.GroupDescriptors.Clear();
            this.dgvDetalleAsistencia.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chNombresTrabajador", "Registros: {0:N0}; ", GridAggregateFunction.Count));


            //this.dgvRefrigerios.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvDetalleAsistencia.MasterTemplate.SummaryRowsTop.Add(item);
        }

        protected override void OnLoad(EventArgs e)
        {

            this.dgvDetalleAsistencia.TableElement.BeginUpdate();
            this.dgvDetalleAsistencia.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvDetalleAsistencia.TableElement.EndUpdate();




            this.dgvDetalleAsistenciaFormatos.TableElement.BeginUpdate();
            this.dgvDetalleAsistenciaFormatos.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            LoadFreightSummaryAgrupado();
            this.dgvDetalleAsistenciaFormatos.TableElement.EndUpdate();


            this.dgvAsistenciaResumen.TableElement.BeginUpdate();
            this.dgvAsistenciaResumen.TableElement.EndUpdate();

            this.dgvDistribucionSubPlanillaIca.TableElement.BeginUpdate();
            this.dgvDistribucionSubPlanillaIca.TableElement.EndUpdate();

            this.dgvDistribucionSubPlanillaSinIca.TableElement.BeginUpdate();
            this.dgvDistribucionSubPlanillaSinIca.TableElement.EndUpdate();

            base.OnLoad(e);
        }

        private void LoadFreightSummaryAgrupado()
        {
            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoExpandGroups = true;
            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleAsistenciaFormatos.GroupDescriptors.Clear();
            this.dgvDetalleAsistenciaFormatos.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items1 = new GridViewSummaryRowItem();
            items1.Add(new GridViewSummaryItem("chNombresTrabajador", "Total Trabajadores: {0:N0}; ", GridAggregateFunction.Count));
            items1.Add(new GridViewSummaryItem("chNroDesayuno", "  {0:N0} ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chNroAlmuerzo", " {0:N0} ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chNroCena", " {0:N0} ", GridAggregateFunction.Sum));
            //this.dgvListaAgrupada.MasterTemplate.SummaryRowsBottom.Add(items1);
            this.dgvDetalleAsistenciaFormatos.MasterTemplate.SummaryRowsTop.Add(items1);




            this.dgvAsistenciaResumen.MasterTemplate.AutoExpandGroups = true;
            this.dgvAsistenciaResumen.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistenciaResumen.GroupDescriptors.Clear();
            this.dgvAsistenciaResumen.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem itemsResumen = new GridViewSummaryRowItem();
            itemsResumen.Add(new GridViewSummaryItem("chNroDesayuno", " Total : {0:N0} ", GridAggregateFunction.Sum));
            itemsResumen.Add(new GridViewSummaryItem("chNroAlmuerzo", " Total : {0:N0} ", GridAggregateFunction.Sum));
            itemsResumen.Add(new GridViewSummaryItem("chNroCena", " Total : {0:N0} ", GridAggregateFunction.Sum));
            itemsResumen.Add(new GridViewSummaryItem("chTotalRefrigerios", " Total : {0:N0} ", GridAggregateFunction.Sum));
            itemsResumen.Add(new GridViewSummaryItem("chImporte", " Total : {0:c} ", GridAggregateFunction.Sum));
            itemsResumen.Add(new GridViewSummaryItem("chImporteDesayuno", " Sum. : {0:c} ", GridAggregateFunction.Sum));
            itemsResumen.Add(new GridViewSummaryItem("chImporteAlmuerzo", " Sum. : {0:c} ", GridAggregateFunction.Sum));
            itemsResumen.Add(new GridViewSummaryItem("chImporteCena", " Sum. : {0:c} ", GridAggregateFunction.Sum));
            this.dgvAsistenciaResumen.MasterTemplate.SummaryRowsTop.Add(itemsResumen);


            this.dgvDistribucionSubPlanillaIca.MasterTemplate.AutoExpandGroups = true;
            this.dgvDistribucionSubPlanillaIca.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.dgvDistribucionSubPlanillaIca.GroupDescriptors.Clear();
            this.dgvDistribucionSubPlanillaIca.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));

            GridViewSummaryRowItem itemsSubPlanillaIca = new GridViewSummaryRowItem();
            itemsSubPlanillaIca.Add(new GridViewSummaryItem("chcostoDistribuido", " Sum, : {0:c} ", GridAggregateFunction.Sum));
            itemsSubPlanillaIca.Add(new GridViewSummaryItem("chSubPlanilla", " Registros. : {0:N0} ", GridAggregateFunction.Count));
            this.dgvDistribucionSubPlanillaIca.MasterTemplate.SummaryRowsTop.Add(itemsSubPlanillaIca);

            this.dgvDistribucionSubPlanillaSinIca.MasterTemplate.AutoExpandGroups = true;
            this.dgvDistribucionSubPlanillaSinIca.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            this.dgvDistribucionSubPlanillaSinIca.GroupDescriptors.Clear();
            this.dgvDistribucionSubPlanillaSinIca.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));

            GridViewSummaryRowItem itemsSubPlanillaSinIca = new GridViewSummaryRowItem();
            itemsSubPlanillaSinIca.Add(new GridViewSummaryItem("chcostoDistribuido", " Sum, : {0:c} ", GridAggregateFunction.Sum));
            itemsSubPlanillaSinIca.Add(new GridViewSummaryItem("chSubPlanilla", " Registros. : {0:N0} ", GridAggregateFunction.Count));
            this.dgvDistribucionSubPlanillaSinIca.MasterTemplate.SummaryRowsTop.Add(itemsSubPlanillaSinIca);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PensionesRefrigerio_Load(object sender, EventArgs e)
        {
            tabControl.Pages.Remove(tabDistribucionSubPlanillaIca);
            tabControl.Pages.Remove(tabDistribucionSubPlanillas);
        }

        public void Inicio()
        {
            try
            {
                #region
                periodoConsulta = DateTime.Now.Year.ToString();
                Globales.Servidor = ConfigurationManager.AppSettings["Servidor"];
                Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"];
                Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodoConsulta];
                Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"];
                Globales.IdEmpresa = "001";
                Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                Globales.UsuarioSistema = "ERICK";
                Globales.NombreUsuarioSistema = "Erick Aurazo";
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.Trim(), "MENSAJE DEL SISTEMA");
                return;
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


            int numeroSemana = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
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
                        fecha2 = Convert.ToDateTime(string.Format("01/{0}/{1}", Convert.ToInt32(cboMes.SelectedValue) + 1, this.txtPeriodo.Text.Trim())).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime(string.Format("01/{0}/{1}", cboMes.SelectedValue.ToString(), this.txtPeriodo.Text.Trim()));// 
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

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();



        }

        private void ComprobarEstadoDiaActual()
        {
            if (chkDiaActual.Checked == true)
            {
                txtPeriodo.Enabled = false;
                this.cboMes.Enabled = false;
                this.txtFechaDesde.Enabled = false;
                this.txtFechaHasta.Enabled = false;

                this.txtFechaDesde.Text = DateTime.Now.ToShortDateString();
                this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();

            }
            else
            {
                txtPeriodo.Enabled = true;
                this.cboMes.Enabled = true;
                this.txtFechaDesde.Enabled = false;
                this.txtFechaHasta.Enabled = false;
                ObtenerFechasMes();
            }
        }

        private void txtPeriodo_Leave(object sender, EventArgs e)
        {
            if (this.txtPeriodo.Text.ToString().Trim().Length == 4)
            {
                ObtenerFechasMes();
            }
            else
            {
                MessageBox.Show("No contiene el formato correcto de año");
            }
        }

        private void chkDiaActual_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ComprobarEstadoDiaActual();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();


        }

        private void Consultar()
        {
            try
            {
                periodo = this.txtPeriodo.Value + Convert.ToDateTime(this.txtFechaDesde.Text).Month.ToString().PadLeft(2, '0');
                año = this.txtPeriodo.Value.ToString();
                mesDelAño = this.cboMes.SelectedValue.ToString().Trim();
                //semanaDelAño = this.cboMes.SelectedText.ToString().Trim();
                int x = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Convert.ToDateTime(this.txtFechaDesde.Text), CalendarWeekRule.FirstDay, Convert.ToDateTime(this.txtFechaDesde.Text).DayOfWeek);
                semanaDelAño = x.ToString().Trim();
                fechaDesde = this.txtFechaDesde.Text.Trim();
                fechaHasta = this.txtFechaHasta.Text.Trim();
                codigoProveedor = this.txtDNIProveedor.Text.Trim();
                descripcionProveedor = this.txtRazonSocialProveedor.Text.Trim();
                ProgressBar.Visible = true;
                gbConsulta.Enabled = false;
                btnGenerarDocumentoParaDescuento.Enabled = false;
                btnGenerarReporteDescuentoPersonal.Enabled = false;
                btnReportePersonalDesconocido.Enabled = false;
                btnPersonalNoAsignadoPension.Enabled = false;
                bgwSubProceso.RunWorkerAsync();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString().Trim() + "\nConsultar Datos", "MENSAJE DEL SISTEMA");
            }
        }

        private void RealizarConsulta()
        {

            try
            {
                codigoReporte = "";
                /* Consultar lista de asistencias y vistas de facturación y generar Distribucion por rendimiento */
                if (chkGenerarDistribucionHorasRendimiento.Checked == true)
                {
                    #region Generar distribucion por horas y rendimiento()
                    #region Obtener Codigo para generar los reportes();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    codigoReporte = PensionModelo.GenerarCodigoMovimiento();
                    #endregion

                    try
                    {
                        #region Generar lista del reporte de Vista para Entrega a las facturas de los proveedores de servicio de alimentacion()
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        PensionModelo.GenerarReporteParaFacturacionDetalladoPorRefrigeriosPorDia(fechaDesde, fechaHasta, codigoProveedor, codigoReporte);
                        #endregion
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString().Trim() + "\nConsultar lista de asistencias y vistas de facturación y generar Distribucion por rendimiento", "MENSAJE DEL SISTEMA");
                    }

                    #region Obtener lista Detalle de asistencia refrigerios por dia()
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistas = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                        ListadoGeneralPensionistas = PensionModelo.ListarRefriferioPensionistasGeneral(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Consultando Asistencia a Refrigerios";
                    }
                    catch (Exception Ex)
                    {

                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener lista Detalle de asistencia refrigerios por día", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistasAgrupado = new List<RefrigerioAgrupado>();
                        ListadoGeneralPensionistasAgrupado = PensionModelo.ListadoRefriferioPensionistasGeneralAgrupado(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Generando presentacíón de Asistencias";
                    }
                    catch (Exception Ex)
                    {

                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener Lista Resumen de Asistencia()
                    listadoResumenAsistenciaRefrigerios = new List<RefrigerioAgrupado>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listadoResumenAsistenciaRefrigerios = PensionModelo.ObtenerListaResumenAsistenciaRefrigerios(ListadoGeneralPensionistasAgrupado).ToList();
                    //lblAvanceProceso.Text = "Calculando Importes para la Facturación";
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento SubPlanilla Ica(PAM)
                    listaAsistenciaxRendimiento = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listaAsistenciaxRendimiento = PensionModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxRendimientoxConsumidor(periodo, "", fechaDesde, fechaHasta, fechaDesde, "001", ListadoGeneralPensionistas).ToList();
                    //lblAvanceProceso.Text = "Consultando Asistencia del personal a Labores (Por número de Racimos)";
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento Todas las planillas menos SubPlanilla Ica(PAM)
                    listaAsistenciaxHorasTrabajadas = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    //listaAsistenciaxHorasTrabajadas = PensionesModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidor(fechaDesde, fechaHasta, "", ListadoGeneralPensionistas).ToList();
                    listaAsistenciaxHorasTrabajadas = PensionModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidorICA(fechaDesde, fechaHasta, "", ListadoGeneralPensionistas).ToList();

                    if (listaAsistenciaxHorasTrabajadas != null && listaAsistenciaxHorasTrabajadas.ToList().Count > 0)
                    {
                        listaAsistenciaxHorasTrabajadasIca = new List<IndicadorAsistencia>();
                        listaAsistenciaxHorasTrabajadasIca = listaAsistenciaxHorasTrabajadas.Where(x => x.subPlanilla.Contains("ICA")).ToList();
                        listaAsistenciaxHorasTrabajadasSinIca = listaAsistenciaxHorasTrabajadas.Where(x => !x.subPlanilla.Contains("ICA")).ToList();
                    }

                    //var personalHorasIca = listaAsistenciaxHorasTrabajadas.Where(x=> x.

                    //if (true)
                    //{

                    //}

                    //lblAvanceProceso.Text = "Consultando Asistencia del personal a Labores (Por horas trabajadas)";
                    #endregion

                    #region Generar Distribucion de las Asistecias Para Costos()

                    listadoDistribucionMovimientoFacturacionPensiones = new List<SJ_RHDistribucionFacturacion>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listadoDistribucionMovimientoFacturacionPensiones = PensionModelo.GenerarDistribucionMovimientoFacturacionPensiones(listaAsistenciaxRendimiento, listaAsistenciaxHorasTrabajadasIca, listaAsistenciaxHorasTrabajadas, ListadoGeneralPensionistas, fechaDesde, fechaHasta, codigoProveedor).ToList();
                    #endregion
                    #endregion
                }

                /* Consultar lista de asistencias y vistas de facturación y generar Distribucion por importe del documento de venta */
                if (chkGenerarDistribucionPorImporteDocumentoVenta.Checked == true)
                {
                    #region Generar distribucion por el importe del documento de venta()
                    #region Obtener Codigo para generar los reportes();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    codigoReporte = PensionModelo.GenerarCodigoMovimiento();
                    #endregion

                    try
                    {
                        #region Generar lista del reporte de Vista para Entrega a las facturas de los proveedores de servicio de alimentacion()
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        PensionModelo.GenerarReporteParaFacturacionDetalladoPorRefrigeriosPorDia(fechaDesde, fechaHasta, codigoProveedor, codigoReporte);
                        #endregion
                    }
                    catch (Exception Ex)
                    {

                        MessageBox.Show(Ex.ToString().Trim() + "\nConsultar lista de asistencias y vistas de facturación y generar Distribucion por importe del documento de venta", "MENSAJE DEL SISTEMA");
                    }

                    #region Obtener lista Detalle de asistencia refrigerios por dia()
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistas = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                        ListadoGeneralPensionistas = PensionModelo.ListarRefriferioPensionistasGeneral(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Consultando Asistencia a Refrigerios";
                    }
                    catch (Exception Ex)
                    {

                        MessageBox.Show(Ex.Message.Trim(), "MENSAJE DEL SISTEMA");
                        return;
                    }
                    #endregion

                    #region Obtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistasAgrupado = new List<RefrigerioAgrupado>();
                        ListadoGeneralPensionistasAgrupado = PensionModelo.ListadoRefriferioPensionistasGeneralAgrupado(fechaDesde, fechaHasta, codigoProveedor).ToList();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.Trim(), "MENSAJE DEL SISTEMA");
                        return;
                    }
                    #endregion

                    #region Obtener Lista Resumen de Asistencia()
                    listadoResumenAsistenciaRefrigerios = new List<RefrigerioAgrupado>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listadoResumenAsistenciaRefrigerios = PensionModelo.ObtenerListaResumenAsistenciaRefrigerios(ListadoGeneralPensionistasAgrupado).ToList();

                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento SubPlanilla Ica(PAM)
                    listaAsistenciaxRendimiento = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listaAsistenciaxRendimiento = PensionModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxRendimientoxConsumidor(periodo, "", fechaDesde, fechaHasta, fechaDesde, "001", ListadoGeneralPensionistas).ToList();
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento Todas las planillas menos SubPlanilla Ica(PAM)
                    listaAsistenciaxHorasTrabajadas = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();

                    listaAsistenciaxHorasTrabajadas = PensionModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidorICA(fechaDesde, fechaHasta, "", ListadoGeneralPensionistas).ToList();
                    if (listaAsistenciaxHorasTrabajadas != null && listaAsistenciaxHorasTrabajadas.ToList().Count > 0)
                    {
                        listaAsistenciaxHorasTrabajadasIca = new List<IndicadorAsistencia>();
                        listaAsistenciaxHorasTrabajadasIca = listaAsistenciaxHorasTrabajadas.Where(x => x.subPlanilla.Contains("ICA")).ToList();
                        listaAsistenciaxHorasTrabajadasSinIca = listaAsistenciaxHorasTrabajadas.Where(x => !x.subPlanilla.Contains("ICA")).ToList();
                    }
                    #endregion

                    #region Generar Distribucion de las Asistecias Para Costos()
                    listadoDistribucionMovimientoFacturacionPensiones = new List<SJ_RHDistribucionFacturacion>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listadoDistribucionMovimientoFacturacionPensiones = PensionModelo.GenerarDistribucionMovimientoFacturacionPensionesxImporteDocumentoVenta(listaAsistenciaxRendimiento, listaAsistenciaxHorasTrabajadasIca, listaAsistenciaxHorasTrabajadas, ListadoGeneralPensionistas, fechaDesde, fechaHasta, codigoProveedor).ToList();
                    #endregion

                    #endregion
                }

                /* Consultar lista de asistencias y vistas de facturación */
                if (chkGenerarDistribucionHorasRendimiento.Checked == false && chkGenerarDistribucionPorImporteDocumentoVenta.Checked == false)
                {
                    #region Realizar consultas sin generar distribucion()
                    #region Obtener Codigo para generar los reportes();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    codigoReporte = PensionModelo.GenerarCodigoMovimiento();
                    #endregion

                    try
                    {
                        #region Generar lista del reporte de Vista para Entrega a las facturas de los proveedores de servicio de alimentacion()
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        PensionModelo.GenerarReporteParaFacturacionDetalladoPorRefrigeriosPorDia(fechaDesde, fechaHasta, codigoProveedor, codigoReporte);
                        #endregion
                    }
                    catch (Exception Ex)
                    {

                        MessageBox.Show(Ex.ToString().Trim() + "\nConsultar lista de asistencias y vistas de facturación", "MENSAJE DEL SISTEMA");
                    }


                    #region Obtener lista Detalle de asistencia refrigerios por dia()
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistas = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                        ListadoGeneralPensionistas = PensionModelo.ListarRefriferioPensionistasGeneral(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Consultando Asistencia a Refrigerios";
                    }
                    catch (Exception Ex)
                    {

                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener lista Detalle de asistencia refrigerios por dia", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistasAgrupado = new List<RefrigerioAgrupado>();
                        ListadoGeneralPensionistasAgrupado = PensionModelo.ListadoRefriferioPensionistasGeneralAgrupado(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Generando presentacíón de Asistencias";
                    }
                    catch (Exception Ex)
                    {

                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener Lista Resumen de Asistencia()

                    try
                    {
                        listadoResumenAsistenciaRefrigerios = new List<RefrigerioAgrupado>();
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        listadoResumenAsistenciaRefrigerios = PensionModelo.ObtenerListaResumenAsistenciaRefrigerios(ListadoGeneralPensionistasAgrupado).ToList();
                        //lblAvanceProceso.Text = "Calculando Importes para la Facturación";
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener Lista Resumen de Asistencia", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento SubPlanilla Ica(PAM)
                    listaAsistenciaxRendimiento = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();

                    //lblAvanceProceso.Text = "Consultando Asistencia del personal a Labores (Por número de Racimos)";
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento Todas las planillas menos SubPlanilla Ica(PAM)
                    listaAsistenciaxHorasTrabajadas = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();

                    #endregion

                    #region Generar Distribucion de las Asistecias Para Costos()

                    listadoDistribucionMovimientoFacturacionPensiones = new List<SJ_RHDistribucionFacturacion>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    //listadoDistribucionMovimientoFacturacionPensiones = PensionesModelo.GenerarDistribucionMovimientoFacturacionPensiones(listaAsistenciaxRendimiento, listaAsistenciaxHorasTrabajadasIca, listaAsistenciaxHorasTrabajadas, ListadoGeneralPensionistas, fechaDesde, fechaHasta, codigoProveedor).ToList();
                    #endregion
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString().Trim() + "\nRealizar Consulta", "MENSAJE DEL SISTEMA");
            }

        }

        private void PresentarInformacion()
        {
            btnGenerarDocumentoParaDescuento.Enabled = false;
            btnImprimirVistaAgrupadoPorRefrigerio.Enabled = false;
            btnExportarGrillaAgrupadoPorRefrigerio.Enabled = false;

            try
            {
                lblAvanceProceso.Text = "";
                #region Vincular resultado de Consulta de Listado de Asistencia detallada con Grilla ()

                try
                {
                    #region Vincular resultado de Consulta de Listado de Asistencia detallada con Grilla ()
                    dgvDetalleAsistencia.DataSource = ListadoGeneralPensionistas.ToDataTable<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                    dgvDetalleAsistencia.Refresh();
                    #endregion
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.Trim(), "MENSAJE DEL SISTEMA");
                    return;
                }

                #endregion

                #region Vincular resultado de Consulta de Listado de Asistencia detallada con Grilla Formato Desayuno - Almuerzo - Cena ()
                try
                {


                    dgvDetalleAsistenciaFormatos.DataSource = ListadoGeneralPensionistasAgrupado.ToDataTable<RefrigerioAgrupado>();
                    dgvDetalleAsistenciaFormatos.Refresh();
                    this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    ResaltarResultadosDuplicidadPensiones();
                    ResaltarResultadosDuplicidadRefrigerios();

                    if (ListadoGeneralPensionistasAgrupado != null && ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
                    {
                        btnGenerarDocumentoParaDescuento.Enabled = false;
                        btnGenerarReporteDescuentoPersonal.Enabled = true;
                        btnImprimirVistaAgrupadoPorRefrigerio.Enabled = true;
                        btnExportarGrillaAgrupadoPorRefrigerio.Enabled = true;
                        btnReportePersonalDesconocido.Enabled = true;
                        btnPersonalNoAsignadoPension.Enabled = true;

                    }
                }
                catch (Exception Ex)
                {

                    Ex.Message.ToString();
                    return;
                }
                #endregion

                #region Vincular resultado de Consulta de Listado de Asistencia resumen con Grilla()

                try
                {
                    //dgvAsistenciaResumen.DataSource = listadoResumenAsistenciaRefrigerios.ToDataTable<RefrigerioAgrupado>();
                    //dgvAsistenciaResumen.Refresh();

                    if (rbtAgrupadoIcayOtrasSubPlanillas.IsChecked == true)
                    {
                        if (listadoResumenAsistenciaRefrigerios != null && listadoResumenAsistenciaRefrigerios.ToList().Count > 0)
                        {
                            PresentarResultadoAgrupadoPlanillasIcaPlanillasOtras();
                        }
                    }

                    if (rbtAgrupadoPorSubPlanillas.IsChecked == true)
                    {
                        if (listadoResumenAsistenciaRefrigerios != null && listadoResumenAsistenciaRefrigerios.ToList().Count > 0)
                        {
                            PresentarResultadoAgrupadoPlanillas();

                        }
                    }



                }
                catch (Exception Ex)
                {

                    Ex.Message.ToString();
                }


                #endregion

                #region Vincular resultado de la generacion de Distribucion con las Grillas SubPlanillas Ica, y el resto de subPlanillas()

                var resultadoSubPlanillaIca = listadoDistribucionMovimientoFacturacionPensiones.Where(x => x.SubPlanilla.Contains("ICA")).ToList();
                var resultadoSubPlanillaMenosIca = listadoDistribucionMovimientoFacturacionPensiones.Where(x => !x.SubPlanilla.Trim().ToUpper().Contains("ICA")).ToList();


                if (resultadoSubPlanillaIca != null && resultadoSubPlanillaIca.ToList().Count > 0)
                {
                    dgvDistribucionSubPlanillaIca.DataSource = resultadoSubPlanillaIca.ToDataTable<SJ_RHDistribucionFacturacion>();
                    dgvDistribucionSubPlanillaIca.Refresh();
                }
                else
                {
                    resultadoSubPlanillaIca = new List<SJ_RHDistribucionFacturacion>();
                    dgvDistribucionSubPlanillaIca.DataSource = resultadoSubPlanillaIca.ToDataTable<SJ_RHDistribucionFacturacion>();
                    dgvDistribucionSubPlanillaIca.Refresh();
                }

                if (resultadoSubPlanillaMenosIca != null && resultadoSubPlanillaMenosIca.ToList().Count > 0)
                {
                    dgvDistribucionSubPlanillaSinIca.DataSource = resultadoSubPlanillaMenosIca.ToDataTable<SJ_RHDistribucionFacturacion>();
                    dgvDistribucionSubPlanillaSinIca.Refresh();
                }
                else
                {
                    resultadoSubPlanillaMenosIca = new List<SJ_RHDistribucionFacturacion>();
                    dgvDistribucionSubPlanillaSinIca.DataSource = resultadoSubPlanillaMenosIca.ToDataTable<SJ_RHDistribucionFacturacion>();
                    dgvDistribucionSubPlanillaSinIca.Refresh();
                }

                #endregion

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString().Trim() + "\nPresentar Informacion", "MENSAJE DEL SISTEMA");
            }

            ///var RutaArchivo = "C:\\ficheroDistribucionPensiones.txt";
            //StreamReader streamReader = new StreamReader(RutaArchivo);
            //string recuperarTextoNotificacion = streamReader.ReadToEnd();
            //if (recuperarTextoNotificacion.ToString().Trim().Length > 0)
            //{
            //    System.Diagnostics.Process.Start(RutaArchivo);
            //}


        }

        private void ResaltarResultadosDuplicidadRefrigerios()
        {
            for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
            {
                if (Convert.ToInt32(dgvDetalleAsistenciaFormatos.Rows[y].Cells["chnroDesayuno"].Value) > 1)
                {
                    this.dgvDetalleAsistenciaFormatos.Rows[y].Cells["chDesayuno"].Style.CustomizeFill = true;
                    this.dgvDetalleAsistenciaFormatos.Rows[y].Cells["chDesayuno"].Style.DrawFill = true;
                    this.dgvDetalleAsistenciaFormatos.Rows[y].Cells["chDesayuno"].Style.BackColor = Color.OrangeRed;
                }
                if (Convert.ToInt32(dgvDetalleAsistenciaFormatos.Rows[y].Cells["chnroAlmuerzo"].Value) > 1)
                {
                    this.dgvDetalleAsistenciaFormatos.Rows[y].Cells["chAlmuerzo"].Style.CustomizeFill = true;
                    this.dgvDetalleAsistenciaFormatos.Rows[y].Cells["chAlmuerzo"].Style.DrawFill = true;
                    this.dgvDetalleAsistenciaFormatos.Rows[y].Cells["chAlmuerzo"].Style.BackColor = Color.OrangeRed;
                }
                if (Convert.ToInt32(dgvDetalleAsistenciaFormatos.Rows[y].Cells["chnroCena"].Value) > 1)
                {
                    this.dgvDetalleAsistenciaFormatos.Rows[y].Cells["chCena"].Style.CustomizeFill = true;
                    this.dgvDetalleAsistenciaFormatos.Rows[y].Cells["chCena"].Style.DrawFill = true;
                    this.dgvDetalleAsistenciaFormatos.Rows[y].Cells["chCena"].Style.BackColor = Color.OrangeRed;
                }
            }



        }

        private void ResaltarResultadosDuplicidadPensiones()
        {
            for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
            {
                if (Convert.ToInt32(dgvDetalleAsistenciaFormatos.Rows[y].Cells["chNroRefrigeriosxPension"].Value) > 1)
                {
                    for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                    {
                        this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                        this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                        this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void ResaltarInasistencias(bool Estado)
        {

            if (Estado == true)
            {
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chInasistencia"].Value).ToString().Trim() == "NO")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.DarkSalmon;
                        }
                    }
                }
            }
            else
            {
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chInasistencia"].Value).ToString().Trim() == "NO")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.White;
                        }
                    }
                }
            }

        }

        private void ResaltarDescanzoMedico(bool Estado)
        {
            if (Estado == true)
            {
                #region
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chDescanzoMedico"].Value).ToString().Trim() == "SI")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.SkyBlue;
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chDescanzoMedico"].Value).ToString().Trim() == "SI")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.White;
                        }
                    }
                }
                #endregion
            }
        }

        private void ResaltarLicenciaPermiso(bool Estado)
        {
            if (Estado == true)
            {
                #region
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chLicenciaPermiso"].Value).ToString().Trim() == "SI")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.OliveDrab;
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chLicenciaPermiso"].Value).ToString().Trim() == "SI")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.White;
                        }
                    }
                }
                #endregion
            }
        }

        private void ResaltarSuspencion(bool Estado)
        {
            if (Estado == true)
            {
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chSuspencion"].Value).ToString().Trim() == "SI")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.Gray;
                        }
                    }
                }
            }
            else
            {
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chSuspencion"].Value).ToString().Trim() == "SI")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.White;
                        }
                    }
                }
            }

        }

        private void ResaltarVacaciones(bool Estado)
        {
            if (Estado == true)
            {
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chVacaciones"].Value).ToString().Trim() == "SI")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.Blue;
                        }
                    }
                }
            }
            else
            {
                for (int y = 0; y < this.dgvDetalleAsistenciaFormatos.RowCount; y++)
                {
                    if ((dgvDetalleAsistenciaFormatos.Rows[y].Cells["chVacaciones"].Value).ToString().Trim() == "SI")
                    {
                        for (int x = 0; x < this.dgvDetalleAsistenciaFormatos.ColumnCount; x++)
                        {
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.CustomizeFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.DrawFill = true;
                            this.dgvDetalleAsistenciaFormatos.Rows[y].Cells[x].Style.BackColor = Color.White;
                        }
                    }
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
            excelExporter = new ExportToExcelML(grilla) { SheetName = "Refrigerio Pensión", SummariesExportOption = SummariesOption.ExportAll, SheetMaxRows = ExcelMaxRows._1048576, ExportVisualSettings = this.exportVisualSettings, HiddenColumnOption = HiddenOption.DoNotExport };

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

        private void chkDuplicidadRefrigerio_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (ListadoGeneralPensionistasAgrupado != null)
            {
                if (ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
                {
                    if (chkDuplicidadPensiones.Checked == true)
                    {
                        if (chkDuplicidadRefrigerio.Checked == true)
                        {
                            dgvDetalleAsistenciaFormatos.DataSource = ListadoGeneralPensionistasAgrupado.ToDataTable<RefrigerioAgrupado>();
                            dgvDetalleAsistenciaFormatos.Refresh();
                            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            ResaltarResultadosDuplicidadPensiones();
                            ResaltarResultadosDuplicidadRefrigerios();
                        }
                        else
                        {
                            dgvDetalleAsistenciaFormatos.DataSource = ListadoGeneralPensionistasAgrupado.ToDataTable<RefrigerioAgrupado>();
                            dgvDetalleAsistenciaFormatos.Refresh();
                            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            ResaltarResultadosDuplicidadPensiones();
                        }


                    }
                    else
                    {
                        if (chkDuplicidadRefrigerio.Checked == true)
                        {

                            dgvDetalleAsistenciaFormatos.DataSource = ListadoGeneralPensionistasAgrupado.ToDataTable<RefrigerioAgrupado>();
                            dgvDetalleAsistenciaFormatos.Refresh();
                            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            ResaltarResultadosDuplicidadRefrigerios();
                        }
                        else
                        {
                            dgvDetalleAsistenciaFormatos.DataSource = ListadoGeneralPensionistasAgrupado.ToDataTable<RefrigerioAgrupado>();
                            dgvDetalleAsistenciaFormatos.Refresh();
                            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                        }
                    }



                }
            }
        }

        private void chkDuplicidadPensiones_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (ListadoGeneralPensionistasAgrupado != null)
            {
                if (ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
                {
                    if (chkDuplicidadRefrigerio.Checked == true)
                    {
                        if (chkDuplicidadPensiones.Checked == true)
                        {
                            dgvDetalleAsistenciaFormatos.DataSource = ListadoGeneralPensionistasAgrupado.ToDataTable<RefrigerioAgrupado>();
                            dgvDetalleAsistenciaFormatos.Refresh();
                            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            ResaltarResultadosDuplicidadPensiones();
                            ResaltarResultadosDuplicidadRefrigerios();
                        }
                        else
                        {
                            dgvDetalleAsistenciaFormatos.DataSource = ListadoGeneralPensionistasAgrupado.ToDataTable<RefrigerioAgrupado>();
                            dgvDetalleAsistenciaFormatos.Refresh();
                            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            ResaltarResultadosDuplicidadRefrigerios();
                        }
                    }
                    else
                    {
                        if (chkDuplicidadPensiones.Checked == true)
                        {
                            dgvDetalleAsistenciaFormatos.DataSource = ListadoGeneralPensionistasAgrupado.ToDataTable<RefrigerioAgrupado>();
                            dgvDetalleAsistenciaFormatos.Refresh();
                            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            ResaltarResultadosDuplicidadPensiones();
                        }
                        else
                        {
                            dgvDetalleAsistenciaFormatos.DataSource = ListadoGeneralPensionistasAgrupado.ToDataTable<RefrigerioAgrupado>();
                            dgvDetalleAsistenciaFormatos.Refresh();
                            this.dgvDetalleAsistenciaFormatos.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                        }


                    }
                }
            }
        }

        private void chkAsistencia_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAsistencia.Checked == true)
            {
                ResaltarInasistencias(true);
            }
            else
            {
                ResaltarInasistencias(false);
            }
        }

        private void chkDescanzoMedico_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkDescanzoMedico.Checked == true)
            {
                ResaltarDescanzoMedico(true);
            }
            else
            {
                ResaltarDescanzoMedico(false);
            }
        }

        private void chkLicenciaYPermisos_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkLicenciaYPermisos.Checked == true)
            {
                ResaltarLicenciaPermiso(true);
            }
            else
            {
                ResaltarLicenciaPermiso(false);
            }
        }

        private void chkSuspencion_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkSuspencion.Checked == true)
            {
                ResaltarSuspencion(true);
            }
            else
            {
                ResaltarSuspencion(false);
            }
        }

        private void chkVacaciones_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkVacaciones.Checked == true)
            {
                ResaltarVacaciones(true);
            }
            else
            {
                ResaltarVacaciones(false);
            }
        }

        private void bgwHiloAgrupado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                PresentarInformacion();
                ProgressBar.Visible = false;
                gbConsulta.Enabled = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message + "\nPresentar datos agrupados");

            }
        }

        private void bgwHiloAgrupado_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                codigoReporte = "";
                /* Consultar lista de asistencias y vistas de facturación y generar Distribucion por rendimiento */
                if (chkGenerarDistribucionHorasRendimiento.Checked == true)
                {
                    #region Generar distribucion por horas y rendimiento()
                    #region Obtener Codigo para generar los reportes();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    codigoReporte = PensionModelo.GenerarCodigoMovimiento();
                    #endregion

                    try
                    {
                        #region Generar lista del reporte de Vista para Entrega a las facturas de los proveedores de servicio de alimentacion()
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        PensionModelo.GenerarReporteParaFacturacionDetalladoPorRefrigeriosPorDia(fechaDesde, fechaHasta, codigoProveedor, codigoReporte);
                        #endregion
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString().Trim() + "\nConsultar lista de asistencias y vistas de facturación y generar Distribucion por rendimiento", "MENSAJE DEL SISTEMA");
                    }

                    #region Obtener lista Detalle de asistencia refrigerios por dia()
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistas = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                        ListadoGeneralPensionistas = PensionModelo.ListarRefriferioPensionistasGeneral(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Consultando Asistencia a Refrigerios";
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener lista Detalle de asistencia refrigerios por día", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistasAgrupado = new List<RefrigerioAgrupado>();
                        ListadoGeneralPensionistasAgrupado = PensionModelo.ListadoRefriferioPensionistasGeneralAgrupado(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Generando presentacíón de Asistencias";
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener Lista Resumen de Asistencia()
                    listadoResumenAsistenciaRefrigerios = new List<RefrigerioAgrupado>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listadoResumenAsistenciaRefrigerios = PensionModelo.ObtenerListaResumenAsistenciaRefrigerios(ListadoGeneralPensionistasAgrupado).ToList();
                    //lblAvanceProceso.Text = "Calculando Importes para la Facturación";
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento SubPlanilla Ica(PAM)
                    listaAsistenciaxRendimiento = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listaAsistenciaxRendimiento = PensionModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxRendimientoxConsumidor(periodo, "", fechaDesde, fechaHasta, fechaDesde, "001", ListadoGeneralPensionistas).ToList();
                    //lblAvanceProceso.Text = "Consultando Asistencia del personal a Labores (Por número de Racimos)";
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento Todas las planillas menos SubPlanilla Ica(PAM)
                    listaAsistenciaxHorasTrabajadas = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    //listaAsistenciaxHorasTrabajadas = PensionesModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidor(fechaDesde, fechaHasta, "", ListadoGeneralPensionistas).ToList();
                    listaAsistenciaxHorasTrabajadas = PensionModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidorICA(fechaDesde, fechaHasta, "", ListadoGeneralPensionistas).ToList();

                    if (listaAsistenciaxHorasTrabajadas != null && listaAsistenciaxHorasTrabajadas.ToList().Count > 0)
                    {
                        listaAsistenciaxHorasTrabajadasIca = new List<IndicadorAsistencia>();
                        listaAsistenciaxHorasTrabajadasIca = listaAsistenciaxHorasTrabajadas.Where(x => x.subPlanilla.Contains("ICA")).ToList();
                        listaAsistenciaxHorasTrabajadasSinIca = listaAsistenciaxHorasTrabajadas.Where(x => !x.subPlanilla.Contains("ICA")).ToList();
                    }

                    //var personalHorasIca = listaAsistenciaxHorasTrabajadas.Where(x=> x.

                    //if (true)
                    //{

                    //}

                    //lblAvanceProceso.Text = "Consultando Asistencia del personal a Labores (Por horas trabajadas)";
                    #endregion

                    #region Generar Distribucion de las Asistecias Para Costos()

                    listadoDistribucionMovimientoFacturacionPensiones = new List<SJ_RHDistribucionFacturacion>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listadoDistribucionMovimientoFacturacionPensiones = PensionModelo.GenerarDistribucionMovimientoFacturacionPensiones(listaAsistenciaxRendimiento, listaAsistenciaxHorasTrabajadasIca, listaAsistenciaxHorasTrabajadas, ListadoGeneralPensionistas, fechaDesde, fechaHasta, codigoProveedor).ToList();
                    #endregion
                    #endregion
                }

                /* Consultar lista de asistencias y vistas de facturación y generar Distribucion por importe del documento de venta */
                if (chkGenerarDistribucionPorImporteDocumentoVenta.Checked == true)
                {
                    #region Generar distribucion por el importe del documento de venta()
                    #region Obtener Codigo para generar los reportes();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    codigoReporte = PensionModelo.GenerarCodigoMovimiento();
                    #endregion

                    try
                    {
                        #region Generar lista del reporte de Vista para Entrega a las facturas de los proveedores de servicio de alimentacion()
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        PensionModelo.GenerarReporteParaFacturacionDetalladoPorRefrigeriosPorDia(fechaDesde, fechaHasta, codigoProveedor, codigoReporte);
                        #endregion
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString().Trim() + "\nConsultar lista de asistencias y vistas de facturación y generar Distribucion por importe del documento de venta", "MENSAJE DEL SISTEMA");
                    }

                    #region Obtener lista Detalle de asistencia refrigerios por dia()
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistas = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                        ListadoGeneralPensionistas = PensionModelo.ListarRefriferioPensionistasGeneral(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Consultando Asistencia a Refrigerios";
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMA");
                        return;
                    }
                    #endregion

                    #region Obtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistasAgrupado = new List<RefrigerioAgrupado>();
                        ListadoGeneralPensionistasAgrupado = PensionModelo.ListadoRefriferioPensionistasGeneralAgrupado(fechaDesde, fechaHasta, codigoProveedor).ToList();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMA");
                        return;
                    }
                    #endregion

                    #region Obtener Lista Resumen de Asistencia()
                    listadoResumenAsistenciaRefrigerios = new List<RefrigerioAgrupado>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listadoResumenAsistenciaRefrigerios = PensionModelo.ObtenerListaResumenAsistenciaRefrigerios(ListadoGeneralPensionistasAgrupado).ToList();

                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento SubPlanilla Ica(PAM)
                    listaAsistenciaxRendimiento = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listaAsistenciaxRendimiento = PensionModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxRendimientoxConsumidor(periodo, "", fechaDesde, fechaHasta, fechaDesde, "001", ListadoGeneralPensionistas).ToList();
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento Todas las planillas menos SubPlanilla Ica(PAM)
                    listaAsistenciaxHorasTrabajadas = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();

                    listaAsistenciaxHorasTrabajadas = PensionModelo.ObtenerListaAsistenciaPersonalGeneralxPeriodoxHorasxConsumidorICA(fechaDesde, fechaHasta, "", ListadoGeneralPensionistas).ToList();
                    if (listaAsistenciaxHorasTrabajadas != null && listaAsistenciaxHorasTrabajadas.ToList().Count > 0)
                    {
                        listaAsistenciaxHorasTrabajadasIca = new List<IndicadorAsistencia>();
                        listaAsistenciaxHorasTrabajadasIca = listaAsistenciaxHorasTrabajadas.Where(x => x.subPlanilla.Contains("ICA")).ToList();
                        listaAsistenciaxHorasTrabajadasSinIca = listaAsistenciaxHorasTrabajadas.Where(x => !x.subPlanilla.Contains("ICA")).ToList();
                    }
                    #endregion

                    #region Generar Distribucion de las Asistecias Para Costos()
                    listadoDistribucionMovimientoFacturacionPensiones = new List<SJ_RHDistribucionFacturacion>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    listadoDistribucionMovimientoFacturacionPensiones = PensionModelo.GenerarDistribucionMovimientoFacturacionPensionesxImporteDocumentoVenta(listaAsistenciaxRendimiento, listaAsistenciaxHorasTrabajadasIca, listaAsistenciaxHorasTrabajadas, ListadoGeneralPensionistas, fechaDesde, fechaHasta, codigoProveedor).ToList();
                    #endregion

                    #endregion
                }

                /* Consultar lista de asistencias y vistas de facturación */
                if (chkGenerarDistribucionHorasRendimiento.Checked == false && chkGenerarDistribucionPorImporteDocumentoVenta.Checked == false)
                {
                    #region Realizar consultas sin generar distribucion()
                    #region Obtener Codigo para generar los reportes();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    codigoReporte = PensionModelo.GenerarCodigoMovimiento();
                    #endregion

                    try
                    {
                        #region Generar lista del reporte de Vista para Entrega a las facturas de los proveedores de servicio de alimentacion()
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        PensionModelo.GenerarReporteParaFacturacionDetalladoPorRefrigeriosPorDia(fechaDesde, fechaHasta, codigoProveedor, codigoReporte);
                        #endregion
                    }
                    catch (Exception Ex)
                    { 
                        MessageBox.Show(Ex.ToString().Trim() + "\nConsultar lista de asistencias y vistas de facturación", "MENSAJE DEL SISTEMA");
                        return;
                    }


                    #region Obtener lista Detalle de asistencia refrigerios por dia()
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistas = new List<SJ_RHListarAsistenciaRefrigeriosxTransferenciaParaFacturacionResult>();
                        ListadoGeneralPensionistas = PensionModelo.ListarRefriferioPensionistasGeneral(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Consultando Asistencia a Refrigerios";
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener lista Detalle de asistencia refrigerios por dia", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena
                    try
                    {
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        ListadoGeneralPensionistasAgrupado = new List<RefrigerioAgrupado>();
                        ListadoGeneralPensionistasAgrupado = PensionModelo.ListadoRefriferioPensionistasGeneralAgrupado(fechaDesde, fechaHasta, codigoProveedor).ToList();
                        //lblAvanceProceso.Text = "Generando presentacíón de Asistencias";
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener lista Detalle de asistencia refrigerios por dia() // Formato Desayuno - Almuerzo - Cena", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener Lista Resumen de Asistencia()

                    try
                    {
                        listadoResumenAsistenciaRefrigerios = new List<RefrigerioAgrupado>();
                        PensionModelo = new RefrigeriosPensionesNegocios();
                        listadoResumenAsistenciaRefrigerios = PensionModelo.ObtenerListaResumenAsistenciaRefrigerios(ListadoGeneralPensionistasAgrupado).ToList();
                        //lblAvanceProceso.Text = "Calculando Importes para la Facturación";
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString().Trim() + "\nObtener Lista Resumen de Asistencia", "MENSAJE DEL SISTEMA");
                    }
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento SubPlanilla Ica(PAM)
                    listaAsistenciaxRendimiento = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();

                    //lblAvanceProceso.Text = "Consultando Asistencia del personal a Labores (Por número de Racimos)";
                    #endregion

                    #region Obtener Lista de Asistencia por Rendimiento Todas las planillas menos SubPlanilla Ica(PAM)
                    listaAsistenciaxHorasTrabajadas = new List<IndicadorAsistencia>();
                    PensionModelo = new RefrigeriosPensionesNegocios();

                    #endregion

                    #region Generar Distribucion de las Asistecias Para Costos()

                    listadoDistribucionMovimientoFacturacionPensiones = new List<SJ_RHDistribucionFacturacion>();
                    PensionModelo = new RefrigeriosPensionesNegocios();
                    //listadoDistribucionMovimientoFacturacionPensiones = PensionesModelo.GenerarDistribucionMovimientoFacturacionPensiones(listaAsistenciaxRendimiento, listaAsistenciaxHorasTrabajadasIca, listaAsistenciaxHorasTrabajadas, ListadoGeneralPensionistas, fechaDesde, fechaHasta, codigoProveedor).ToList();
                    #endregion
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString().Trim() + "\nRealizar Consulta", "MENSAJE DEL SISTEMA");
            }

        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void btnBuscarTransportista_Click(object sender, EventArgs e)
        {
            this.txtDNIProveedor.Clear();
            this.txtRazonSocialProveedor.Clear();
            BuscarPension oFrm = new BuscarPension();
            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                if (oFrm.ObjetoBusquedaPension != null)
                {
                    try
                    {
                        this.txtDNIProveedor.Text = oFrm.ObjetoBusquedaPension.NroDNI;
                        this.txtRazonSocialProveedor.Text = oFrm.ObjetoBusquedaPension.RazonSocial.ToString().Trim().ToUpper();
                        this.txtNroRucProveedor.Text = oFrm.ObjetoBusquedaPension.NroRuc;
                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                }
            }
        }

        private void dgvRefrigerios_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvListaAgrupadaAsistenciaPensiones_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                btnSubrHistorialDeAsistenciaARefrigerios.Enabled = false;
                btnSubConsumoEnPension.Enabled = false;

                if (dgvDetalleAsistenciaFormatos != null && dgvDetalleAsistenciaFormatos.Rows.Count > 0)
                {
                    if (dgvDetalleAsistenciaFormatos.CurrentRow != null && dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chDNITrabajador"].Value != null)
                    {
                        personal = new PersonalCampo();
                        personal.nroDNI = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chDNITrabajador"].Value.ToString().Trim();
                        personal.Nombres = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chNombresTrabajador"].Value.ToString().Trim();
                        personal.nroDNIPension = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chDNIPension"].Value.ToString().Trim();
                        personal.pension = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chPension"].Value.ToString().Trim();
                        personal.estado = "ACTIVO";
                        personal.fecha = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chFecha"].Value.ToString().Trim() != "" ? Convert.ToDateTime(dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chFecha"].Value) : DateTime.Now;
                        personal.fechaDesde = this.txtFechaDesde.Text.ToString().Trim();
                        personal.fechaHasta = this.txtFechaHasta.Text.ToString().Trim();
                        string refigerio = string.Empty;

                        if (Convert.ToInt32(dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chNroDesayuno"].Value) > 0)
                        {
                            refigerio += "DESAYUNO - ";
                        }

                        if (Convert.ToInt32(dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chNroAlmuerzo"].Value) > 0)
                        {
                            refigerio += "ALMUERZO - ";
                        }

                        if (Convert.ToInt32(dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chNroCena"].Value) > 0)
                        {
                            refigerio += "CENA";
                        }

                        personal.refriferio = refigerio;

                        btnSubrHistorialDeAsistenciaARefrigerios.Enabled = true;
                        btnSubConsumoEnPension.Enabled = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString() + "\n. Asignar Personal de campo", "MENSAJE DEL SISTEMA");
                return;
            }


        }

        private void btnExportarGrillaResumenAsistencias_Click(object sender, EventArgs e)
        {
            if (dgvAsistenciaResumen != null && dgvAsistenciaResumen.Rows.Count > 0)
            {
                Exportar(this.dgvAsistenciaResumen);
            }
            //dgvAsistenciaResumen

        }

        private void btnExportarGrillaAgrupadoPorRefrigerio_Click(object sender, EventArgs e)
        {
            if (dgvDetalleAsistenciaFormatos != null && dgvDetalleAsistenciaFormatos.Rows.Count > 0)
            {
                Exportar(this.dgvDetalleAsistenciaFormatos);
            }
            //dgvDetalleAsistenciaFormato
        }

        private void btnExportarGrillaDetalleDeAsistencia_Click(object sender, EventArgs e)
        {
            if (dgvDetalleAsistencia != null && dgvDetalleAsistencia.Rows.Count > 0)
            {
                Exportar(this.dgvDetalleAsistencia);
            }
            //dgvDetalleAsistencia
        }

        private void btnExportarGrillaDistribucionSubPlanillaIca_Click(object sender, EventArgs e)
        {
            if (dgvDistribucionSubPlanillaIca != null && dgvDistribucionSubPlanillaIca.Rows.Count > 0)
            {
                Exportar(this.dgvDistribucionSubPlanillaIca);
            }
            //dgvDistribucionSubPlanillaIca
        }

        private void btnExportarGrillaDistribucionSubPlanillaSinIca_Click(object sender, EventArgs e)
        {
            if (dgvDistribucionSubPlanillaSinIca != null && dgvDistribucionSubPlanillaSinIca.Rows.Count > 0)
            {
                Exportar(this.dgvDistribucionSubPlanillaSinIca);
            }
            //dgvDistribucionSubPlanillaSinIca
        }

        public List<IndicadorAsistencia> listaAsistenciaxHorasTrabajadasIca { get; set; }
        public List<IndicadorAsistencia> listaAsistenciaxHorasTrabajadasSinIca { get; set; }

        private void rbtAgrupadoPorSubPlanillas_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtAgrupadoPorSubPlanillas.IsChecked == true)
            {
                if (dgvAsistenciaResumen != null && dgvAsistenciaResumen.Rows.Count > 0)
                {
                    PresentarResultadoAgrupadoPlanillas();

                }
            }

        }

        private void PresentarResultadoAgrupadoPlanillasIcaPlanillasOtras()
        {

            try
            {
                #region MyRegion

                var listaOrigen = listadoResumenAsistenciaRefrigerios.ToList();
                listadoVistaAgrupadoSubPlanillasIcaOtros = new List<RefrigerioAgrupado>();

                var ListaSubPlanillasIca = listaOrigen.Where(x => x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList();

                var listaDiasAsistencia = (from item in ListaSubPlanillasIca
                                           group item by new { item.Fecha.Value } into j
                                           select new
                                           {
                                               fecha = j.Key.Value,
                                           }
                                               ).ToList();

                //listadoResumenAsistenciaRefrigerios = new List<RefrigerioAgrupado>();

                foreach (var item in listaDiasAsistencia)
                {
                    var listaResultado = ListaSubPlanillasIca.Where(x => x.Fecha.Value == item.fecha).ToList();

                    if (listaResultado != null && listaResultado.ToList().Count > 0)
                    {
                        RefrigerioAgrupado resultadoSubPlanilla = new RefrigerioAgrupado();
                        resultadoSubPlanilla.Fecha = item.fecha;
                        resultadoSubPlanilla.CodPension = listaResultado.FirstOrDefault().CodPension != null ? listaResultado.FirstOrDefault().CodPension.ToString().Trim() : "";
                        resultadoSubPlanilla.Pension = listaResultado.FirstOrDefault().Pension != null ? listaResultado.FirstOrDefault().Pension.ToString().Trim() : "";
                        resultadoSubPlanilla.nroDesayuno = listaResultado.Where(x => x.nroDesayuno > 0) != null ? listaResultado.Sum(x => x.nroDesayuno != null ? x.nroDesayuno : 0) : 0;
                        resultadoSubPlanilla.nroAlmuerzo = listaResultado.Where(x => x.nroAlmuerzo > 0) != null ? listaResultado.Sum(x => x.nroAlmuerzo != null ? x.nroAlmuerzo : 0) : 0;
                        resultadoSubPlanilla.nroCena = listaResultado.Where(x => x.nroCena > 0) != null ? listaResultado.Sum(x => x.nroCena != null ? x.nroCena : 0) : 0;
                        resultadoSubPlanilla.ImporteDesayuno = listaResultado.Where(x => x.ImporteDesayuno > 0) != null ? listaResultado.Sum(x => x.ImporteDesayuno != null ? x.ImporteDesayuno : 0) : 0;
                        resultadoSubPlanilla.ImporteAlmuerzo = listaResultado.Where(x => x.ImporteAlmuerzo > 0) != null ? listaResultado.Sum(x => x.ImporteAlmuerzo != null ? x.ImporteAlmuerzo : 0) : 0;
                        resultadoSubPlanilla.ImporteCena = listaResultado.Where(x => x.ImporteCena > 0) != null ? listaResultado.Sum(x => x.ImporteCena != null ? x.ImporteCena : 0) : 0;
                        resultadoSubPlanilla.nroRefrigeriosxPension = listaResultado.Where(x => x.nroRefrigeriosxPension > 0) != null ? listaResultado.Sum(x => x.nroRefrigeriosxPension != null ? x.nroRefrigeriosxPension : 0) : 0;
                        resultadoSubPlanilla.SubPlanilla = "ICA";
                        resultadoSubPlanilla.Importe = listaResultado.Where(x => x.Importe > 0) != null ? listaResultado.Sum(x => x.Importe != null ? x.Importe : 0) : 0;
                        listadoVistaAgrupadoSubPlanillasIcaOtros.Add(resultadoSubPlanilla);
                    }
                }


                var ListaSubPlanillaDifrenteIca = listaOrigen.Where(x => !x.SubPlanilla.ToString().Trim().ToUpper().Contains("ICA")).ToList();

                if (ListaSubPlanillaDifrenteIca != null && ListaSubPlanillaDifrenteIca.ToList().Count > 0)
                {
                    listadoVistaAgrupadoSubPlanillasIcaOtros.AddRange(ListaSubPlanillaDifrenteIca);
                }

                dgvAsistenciaResumen.DataSource = listadoVistaAgrupadoSubPlanillasIcaOtros.OrderBy(x => x.SubPlanilla).OrderBy(x => x.Fecha).ToList().ToDataTable<RefrigerioAgrupado>();
                dgvAsistenciaResumen.Refresh();

                #endregion
            }
            catch (Exception Ex)
            {
                throw Ex;
            }



        }

        private void rbtAgrupadoIcayOtrasSubPlanillas_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (rbtAgrupadoIcayOtrasSubPlanillas.IsChecked == true)
            {
                if (dgvAsistenciaResumen != null && dgvAsistenciaResumen.Rows.Count > 0)
                {
                    PresentarResultadoAgrupadoPlanillasIcaPlanillasOtras();
                }
            }

        }

        private void PresentarResultadoAgrupadoPlanillas()
        {
            try
            {
                var listaOrigen = listadoResumenAsistenciaRefrigerios.ToList();
                dgvAsistenciaResumen.DataSource = listaOrigen.ToDataTable<RefrigerioAgrupado>();
                dgvAsistenciaResumen.Refresh();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void btnImprimirVistaResumen_Click(object sender, EventArgs e)
        {
            /* GrabarResultadosEnTablaTemporal */
            /* Asiganar un codigo de Reporte y cargar el reporte */
            #region
            string rucProveedor, proveedorDescripcion, semanaFacturacion = string.Empty;

            if (listadoVistaAgrupadoSubPlanillasIcaOtros != null && listadoVistaAgrupadoSubPlanillasIcaOtros.ToList().Count > 0)
            {
                #region Generar vista del reporte ()

                PensionModelo = new RefrigeriosPensionesNegocios();
                string codigoReporteResumen = PensionModelo.GenerarCodigoMovimiento();

                PensionModelo.RegistrarResultadosConsultaRefrigeriosAgrupados(listadoVistaAgrupadoSubPlanillasIcaOtros, codigoReporteResumen);

                rucProveedor = this.txtNroRucProveedor.Text.ToString().Trim();
                proveedorDescripcion = txtRazonSocialProveedor.Text.ToString().Trim();
                //semanaFacturacion = Convert.ToDateTime(this.txtFechaDesde.Text).

                int xSemanaFacturacionReporte = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Convert.ToDateTime(this.txtFechaDesde.Text), CalendarWeekRule.FirstDay, Convert.ToDateTime(this.txtFechaDesde.Text).DayOfWeek);
                semanaFacturacion = xSemanaFacturacionReporte.ToString().Trim();

                fechaDesde = this.txtFechaDesde.Text.ToString().Trim();
                fechaHasta = this.txtFechaHasta.Text.ToString().Trim();


                ImprimirReporteFacturacionPensionistaPorSemanaFacturacion ofrm = new ImprimirReporteFacturacionPensionistaPorSemanaFacturacion(codigoReporteResumen);
                ofrm.AgregarParametroCadena("@RucProveedor", rucProveedor.ToString().Trim()); /* nro Ruc */
                ofrm.AgregarParametroCadena("@ProveedorDescripcion", proveedorDescripcion.ToString().Trim()); /* Razon social */
                ofrm.AgregarParametroCadena("@fechaDesde", fechaDesde.ToString().Trim());
                ofrm.AgregarParametroCadena("@fechaHasta", fechaHasta.ToString().Trim());
                ofrm.AgregarParametroCadena("@semanaFacturacion", semanaFacturacion.ToString().Trim());
                ofrm.AgregarParametroCadena("@impresoPor", Environment.UserName.ToString().Trim().ToUpper());
                ofrm.AgregarParametroCadena("@codigo", codigoReporteResumen.ToString().Trim());
                ofrm.Show();
                #endregion
            }
            #endregion

        }

        public List<RefrigerioAgrupado> listadoVistaAgrupadoSubPlanillasIcaOtros { get; set; }

        private void btnImprimirVistaAgrupadoPorRefrigerio_Click(object sender, EventArgs e)
        {
            #region Vista previa del reporte de asistencia agrupada por tipo de refrigerio()
            string rucProveedor, proveedorDescripcion, semanaFacturacion = string.Empty;

            if (ListadoGeneralPensionistasAgrupado != null && ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
            {
                #region Generar vista del reporte ()

                //PensionesModelo.RegistrarResultadosConsultaRefrigeriosAgrupados(listadoVistaAgrupadoSubPlanillasIcaOtros, codigoReporte);

                rucProveedor = this.txtNroRucProveedor.Text.ToString().Trim();
                proveedorDescripcion = txtRazonSocialProveedor.Text.ToString().Trim();
                //semanaFacturacion = Convert.ToDateTime(this.txtFechaDesde.Text).

                //int x = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Convert.ToDateTime(this.txtFechaDesde.Text), CalendarWeekRule.FirstDay, Convert.ToDateTime(this.txtFechaDesde.Text).DayOfWeek);
                semanaFacturacion = txtSemana.Value.ToString();

                fechaDesde = this.txtFechaDesde.Text.ToString().Trim();
                fechaHasta = this.txtFechaHasta.Text.ToString().Trim();

                ImprimirReporteParaFacturacionSemanaRefrigerios ofrm = new ImprimirReporteParaFacturacionSemanaRefrigerios(codigoReporte);
                ofrm.AgregarParametroCadena("@RucProveedor", rucProveedor.ToString().Trim()); /* nro Ruc */
                ofrm.AgregarParametroCadena("@ProveedorDescripcion", proveedorDescripcion.ToString().Trim()); /* Razon social */
                ofrm.AgregarParametroCadena("@fechaDesde", fechaDesde.ToString().Trim());
                ofrm.AgregarParametroCadena("@fechaHasta", fechaHasta.ToString().Trim());
                ofrm.AgregarParametroCadena("@semanaFacturacion", semanaFacturacion.ToString().Trim());
                ofrm.AgregarParametroCadena("@impresoPor", Environment.UserName.ToString().Trim().ToUpper());
                ofrm.AgregarParametroCadena("@codigo", codigoReporte.ToString().Trim());
                ofrm.Show();
                #endregion
            }
            #endregion
        }

        private void rbtGenerarDistribucionPorImporteDocumentoVenta_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (this.chkGenerarDistribucionPorImporteDocumentoVenta.Checked == true)
            {
                this.chkGenerarDistribucionHorasRendimiento.Checked = false;
            }
        }

        private void rbtGenerarDistribucionHorasRendimiento_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (this.chkGenerarDistribucionHorasRendimiento.Checked == true)
            {
                this.chkGenerarDistribucionPorImporteDocumentoVenta.Checked = false;
            }
        }

        private void btnConsolidarDistribucionIca_Click(object sender, EventArgs e)
        {
            if (listadoDistribucionMovimientoFacturacionPensiones != null && listadoDistribucionMovimientoFacturacionPensiones.ToList().Count > 0)
            {
                if (fechaDesde != null && fechaHasta != null && codigoProveedor != null && fechaDesde != "" && fechaHasta != "" && codigoProveedor != "")
                {
                    try
                    {
                        string subPlanilla = "ICA";
                        var listadoAsistenciaSoloPersonalIca = listadoDistribucionMovimientoFacturacionPensiones.Where(x => x.SubPlanilla.Contains("ICA")).ToList();

                        if (listadoAsistenciaSoloPersonalIca != null && listadoAsistenciaSoloPersonalIca.ToList().Count > 0)
                        {
                            DistribucionConsumoRefrigeriosxPensionxPeriodo ofrm = new DistribucionConsumoRefrigeriosxPensionxPeriodo(periodo, año, mesDelAño, semanaDelAño, fechaDesde, fechaHasta, codigoProveedor, descripcionProveedor, listadoAsistenciaSoloPersonalIca, subPlanilla);
                            ofrm.Show();
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }

        private void btnConsolidarDistribucionTodasSubPlanillasMenosIca_Click(object sender, EventArgs e)
        {
            if (listadoDistribucionMovimientoFacturacionPensiones != null && listadoDistribucionMovimientoFacturacionPensiones.ToList().Count > 0)
            {
                if (fechaDesde != null && fechaHasta != null && codigoProveedor != null && fechaDesde != "" && fechaHasta != "" && codigoProveedor != "")
                {
                    try
                    {
                        string subPlanilla = "ICA";
                        var listadoAsistenciaSoloPersonalIca = listadoDistribucionMovimientoFacturacionPensiones.Where(x => !x.SubPlanilla.Contains("ICA")).ToList();

                        if (listadoAsistenciaSoloPersonalIca != null && listadoAsistenciaSoloPersonalIca.ToList().Count > 0)
                        {
                            DistribucionConsumoRefrigeriosxPensionxPeriodo ofrm = new DistribucionConsumoRefrigeriosxPensionxPeriodo(periodo, año, mesDelAño, semanaDelAño, fechaDesde, fechaHasta, codigoProveedor, descripcionProveedor, listadoAsistenciaSoloPersonalIca, subPlanilla);
                            ofrm.Show();
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }

        private void btnGenerarDocumentoParaDescuento_Click(object sender, EventArgs e)
        {
            if (ListadoGeneralPensionistasAgrupado != null && ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
            {
                string nombreDelMes, fechaDesde, fechaHasta, codigoProveedor, descripcionProveedor = string.Empty;

                nombreDelMes = cboMes.SelectedItem.ToString();
                fechaDesde = this.txtFechaDesde.Text;
                fechaHasta = this.txtFechaHasta.Text;
                codigoProveedor = this.txtDNIProveedor.Text;
                descripcionProveedor = this.txtRazonSocialProveedor.Text;

                ReporteGeneracionDescuentosPorInasistenciasRefrigerios oFormulario = new ReporteGeneracionDescuentosPorInasistenciasRefrigerios(nombreDelMes, fechaDesde, fechaHasta, codigoProveedor, descripcionProveedor, ListadoGeneralPensionistasAgrupado);
                oFormulario.Show();
            }
        }

        private void btnReporteDescuentoPersonal_Click(object sender, EventArgs e)
        {
            if (ListadoGeneralPensionistasAgrupado != null && ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
            {
                string nombreDelMes, fechaDesde, fechaHasta, codigoProveedor, descripcionProveedor, rucProveedor = string.Empty;

                nombreDelMes = cboMes.SelectedItem.ToString().Trim();
                fechaDesde = this.txtFechaDesde.Text;
                fechaHasta = this.txtFechaHasta.Text;
                codigoProveedor = this.txtDNIProveedor.Text.ToString().Trim();
                descripcionProveedor = this.txtRazonSocialProveedor.Text.ToString().Trim();
                rucProveedor = this.txtNroRucProveedor.Text.ToString().Trim();

                ReporteDescuentosPorInasistenciasRefrigeriosNuevo oFormulario = new ReporteDescuentosPorInasistenciasRefrigeriosNuevo(nombreDelMes, fechaDesde, fechaHasta, codigoProveedor, descripcionProveedor, ListadoGeneralPensionistasAgrupado, rucProveedor);
                oFormulario.Show();
            }
        }

        private void btnReportePersonalDesconocido_Click(object sender, EventArgs e)
        {

            VerReportePersonalDesconocido();
        }

        private void VerReportePersonalDesconocido()
        {
            #region Vista previa del reporte de asistencia agrupada por tipo de refrigerio()
            try
            {
                string rucProveedor, proveedorDescripcion, semanaFacturacion, dniPension = string.Empty;

                if (ListadoGeneralPensionistasAgrupado != null && ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
                {
                    #region Generar vista del reporte ()
                    //PensionesModelo.RegistrarResultadosConsultaRefrigeriosAgrupados(listadoVistaAgrupadoSubPlanillasIcaOtros, codigoReporte);
                    rucProveedor = this.txtNroRucProveedor.Text.ToString().Trim();
                    dniPension = this.txtDNIProveedor.Text.ToString().Trim();
                    proveedorDescripcion = txtRazonSocialProveedor.Text.ToString().Trim();
                    //semanaFacturacion = Convert.ToDateTime(this.txtFechaDesde.Text).
                    int x = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Convert.ToDateTime(this.txtFechaDesde.Text), CalendarWeekRule.FirstDay, Convert.ToDateTime(this.txtFechaDesde.Text).DayOfWeek);
                    semanaFacturacion = x.ToString().Trim();
                    fechaDesde = this.txtFechaDesde.Text.ToString().Trim();
                    fechaHasta = this.txtFechaHasta.Text.ToString().Trim();
                    ReportePersonalDesconocidoByPensionByPeriodoFacturacionVistaPrevia ofrm = new ReportePersonalDesconocidoByPensionByPeriodoFacturacionVistaPrevia(dniPension, fechaDesde, fechaHasta);
                    ofrm.AgregarParametroCadena("@RucProveedor", rucProveedor.ToString().Trim()); /* nro Ruc */
                    ofrm.AgregarParametroCadena("@ProveedorDescripcion", proveedorDescripcion.ToString().Trim()); /* Razon social */
                    ofrm.AgregarParametroCadena("@fechaDesde", fechaDesde.ToString().Trim());
                    ofrm.AgregarParametroCadena("@fechaHasta", fechaHasta.ToString().Trim());
                    ofrm.AgregarParametroCadena("@semanaFacturacion", semanaFacturacion.ToString().Trim());
                    ofrm.AgregarParametroCadena("@impresoPor", Environment.UserName.ToString().Trim().ToUpper());
                    //ofrm.AgregarParametroCadena("@codigo", codigoReporte.ToString().Trim());
                    ofrm.Show();
                    #endregion
                }
            }
            catch (SqlException Ex)
            {
                #region 
                foreach (SqlError sError in Ex.Errors)
                {

                    switch (sError.Number)
                    {
                        case 17:
                            MessageBox.Show("El servidor no existe, por favor verifique el nombre");
                            break;
                        case 18452:    //Login failed for user '%ls'. Reason: Not associated with a trusted SQL Server connection.
                            MessageBox.Show("Especifique un usuario y password");
                            break;
                        case 18456: //Login failed for user '%ls'.
                            MessageBox.Show("El usuario o password es incorrecto");
                            break;
                        case 4060:    //Cannot open database requested in login '%.*ls'. Login fails.
                            MessageBox.Show("El usuario no tiene permisos para acceder a la base de datos ");
                            break;
                        case 208:    //Invalid object name '%ls'."
                            MessageBox.Show("El nombre del objeto es incorrecto, para mayor información consulte la lnea :" + sError.LineNumber);
                            break;
                        default:
                            MessageBox.Show(sError.Message);
                            break;
                    }
                }
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString() + " Visualizar reporte de personal desconocido", "MENSAJE DEL SISTEMA");
                return;
            }

            #endregion
        }

        private void btnSubConsumoEnPension_Click(object sender, EventArgs e)
        {
            ConsumoPorPension();
        }

        private void btnSubAsociarAParadero_Click(object sender, EventArgs e)
        {
            AsociarAHospedaje();
        }

        private void btnSubDetalleDeAsistencia_Click(object sender, EventArgs e)
        {
            DetalleAsistencia("HORAS");
        }

        private void btnSubrHistorialDeAsistenciaARefrigerios_Click(object sender, EventArgs e)
        {
            DetalleAsistenciaRefrigerios();
        }

        private void DetalleAsistencia(string tipoResultado)
        {
            try
            {
                if (asistenciaPersonal.CodigoPersonal != null)
                {
                    if (tipoResultado == "HORAS")
                    {

                        ReporteAsistenciaPersonalLaboresCampoxHoras ofrm = new ReporteAsistenciaPersonalLaboresCampoxHoras(fechaDesde, fechaHasta, asistenciaPersonal.CodigoPersonal);
                        ofrm.WindowState = FormWindowState.Normal;
                        ofrm.Show();
                    }
                    else if (tipoResultado == "RENDIMIENTO")
                    {
                        ReporteAsistenciaPersonalLaboresCampoxRendimiento ofrm = new ReporteAsistenciaPersonalLaboresCampoxRendimiento(fechaDesde, fechaHasta, asistenciaPersonal.CodigoPersonal);
                        ofrm.WindowState = FormWindowState.Normal;
                        ofrm.Show();

                    }

                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMAS");
                return;
            }
        }

        private void AsociarAHospedaje()
        {
            try
            {
                if (asistenciaPersonal.CodigoPersonal != null)
                {
                    ProgramacionRefrigerioRegistrosMultiples ofrm = new ProgramacionRefrigerioRegistrosMultiples(asistenciaPersonal);
                    ofrm.Show();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMAS");
                return;
            }
        }

        private void ConsumoPorPension()
        {
            try
            {
                if (asistenciaPersonal.CodigoPersonal != null && asistenciaPersonal.CodPension != null)
                {

                    ModificarDNITrabajador oFormulario = new ModificarDNITrabajador(asistenciaPersonal);
                    oFormulario.Show();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMAS");
                return;
            }
        }

        private void DetalleAsistenciaRefrigerios()
        {
            try
            {
                if (asistenciaPersonal.CodigoPersonal != null)
                {

                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMAS");
                return;
            }
        }

        private void dgvDetalleAsistenciaFormatos_SelectionChanged(object sender, EventArgs e)
        {
            btnSubAsociarAParadero.Enabled = false;
            btnSubConsumoEnPension.Enabled = false;
            btnSubDetalleDeAsistenciaHoras.Enabled = false;
            btnSubDetalleDeAsistenciaRendimiento.Enabled = false;
            btnSubrHistorialDeAsistenciaARefrigerios.Enabled = false;

            if (dgvDetalleAsistenciaFormatos != null && dgvDetalleAsistenciaFormatos.Rows.Count > 0)
            {
                if (dgvDetalleAsistenciaFormatos.CurrentRow != null && dgvDetalleAsistenciaFormatos.CurrentCell != null)
                {
                    if (dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chCodigoPersonal"].Value != null && dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chCodigoPersonal"].Value.ToString().Trim() != "")
                    {
                        asistenciaPersonal = new RefrigerioAgrupado();
                        asistenciaPersonal.CodigoPersonal = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chCodigoPersonal"].Value != null ? dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chCodigoPersonal"].Value.ToString() : "";
                        asistenciaPersonal.DNITrabajador = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chDNITrabajador"].Value != null ? dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chDNITrabajador"].Value.ToString() : "";
                        asistenciaPersonal.idHospedaje = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chIdHospedaje"].Value != null ? dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chIdHospedaje"].Value.ToString() : "";
                        asistenciaPersonal.Trabajador = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chNombresTrabajador"].Value != null ? dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chNombresTrabajador"].Value.ToString() : "";
                        asistenciaPersonal.Pension = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chPension"].Value != null ? dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chPension"].Value.ToString() : "";
                        asistenciaPersonal.CodPension = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chDNIPension"].Value != null ? dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chDNIPension"].Value.ToString() : "";
                        asistenciaPersonal.Fecha = dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chFecha"].Value != null ? Convert.ToDateTime(dgvDetalleAsistenciaFormatos.CurrentRow.Cells["chFecha"].Value) : DateTime.Now;

                        if (asistenciaPersonal != null && asistenciaPersonal.idHospedaje != "S/P")
                        {
                            btnSubAsociarAParadero.Enabled = false;
                            btnSubConsumoEnPension.Enabled = true;
                            btnSubDetalleDeAsistenciaHoras.Enabled = true;
                            btnSubDetalleDeAsistenciaRendimiento.Enabled = true;
                            btnSubrHistorialDeAsistenciaARefrigerios.Enabled = true;
                        }
                        else
                        {
                            btnSubAsociarAParadero.Enabled = true;
                            btnSubConsumoEnPension.Enabled = true;
                            btnSubDetalleDeAsistenciaHoras.Enabled = true;
                            btnSubDetalleDeAsistenciaRendimiento.Enabled = true;
                            btnSubrHistorialDeAsistenciaARefrigerios.Enabled = true;
                        }

                    }
                }
            }
        }

        private void btnSubDetalleDeAsistenciaRendimiento_Click(object sender, EventArgs e)
        {
            DetalleAsistencia("RENDIMIENTO");
        }

        private void btnBuscarTransportista_Leave(object sender, EventArgs e)
        {
            string[] cadena = this.txtRazonSocialProveedor.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPersonal(cadena);
            }
        }

        private void AsignarDatosPersonal(string[] ncadena)
        {
            this.txtNroRucProveedor.Text = ncadena[1].ToString().Trim();
            this.txtRazonSocialProveedor.Text = ncadena[0].ToString().Trim();
        }

        private void txtDNIProveedor_Leave(object sender, EventArgs e)
        {
            string[] cadena = this.txtRazonSocialProveedor.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPersonal(cadena);
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

        private void gbConsulta_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonalNoAsignadoPension_Click(object sender, EventArgs e)
        {
            VerReportePersonalNoAsignadoPension();
        }

        private void VerReportePersonalNoAsignadoPension()
        {
            #region Vista previa del reporte de asistencia agrupada por tipo de refrigerio()
            try
            {
                string rucProveedor, proveedorDescripcion, semanaFacturacion, dniPension = string.Empty;

                if (ListadoGeneralPensionistasAgrupado != null && ListadoGeneralPensionistasAgrupado.ToList().Count > 0)
                {
                    #region Generar vista del reporte ()
                    //PensionesModelo.RegistrarResultadosConsultaRefrigeriosAgrupados(listadoVistaAgrupadoSubPlanillasIcaOtros, codigoReporte);
                    rucProveedor = this.txtNroRucProveedor.Text.ToString().Trim();
                    dniPension = this.txtDNIProveedor.Text.ToString().Trim();
                    proveedorDescripcion = txtRazonSocialProveedor.Text.ToString().Trim();
                    //semanaFacturacion = Convert.ToDateTime(this.txtFechaDesde.Text).
                    int x = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Convert.ToDateTime(this.txtFechaDesde.Text), CalendarWeekRule.FirstDay, Convert.ToDateTime(this.txtFechaDesde.Text).DayOfWeek);
                    semanaFacturacion = x.ToString().Trim();
                    fechaDesde = this.txtFechaDesde.Text.ToString().Trim();
                    fechaHasta = this.txtFechaHasta.Text.ToString().Trim();
                    ReportePersonalNoAsignadoPensionVistaPrevia ofrm = new ReportePersonalNoAsignadoPensionVistaPrevia(dniPension, fechaDesde, fechaHasta);
                    ofrm.AgregarParametroCadena("@RucProveedor", rucProveedor.ToString().Trim()); /* nro Ruc */
                    ofrm.AgregarParametroCadena("@ProveedorDescripcion", proveedorDescripcion.ToString().Trim()); /* Razon social */
                    ofrm.AgregarParametroCadena("@fechaDesde", fechaDesde.ToString().Trim());
                    ofrm.AgregarParametroCadena("@fechaHasta", fechaHasta.ToString().Trim());
                    ofrm.AgregarParametroCadena("@semanaFacturacion", semanaFacturacion.ToString().Trim());
                    ofrm.AgregarParametroCadena("@impresoPor", Environment.UserName.ToString().Trim().ToUpper());
                    //ofrm.AgregarParametroCadena("@codigo", codigoReporte.ToString().Trim());
                    ofrm.Show();
                    #endregion
                }
            }
            catch (SqlException Ex)
            {
                #region
                foreach (SqlError sError in Ex.Errors)
                {

                    switch (sError.Number)
                    {
                        case 17:
                            MessageBox.Show("El servidor no existe, por favor verifique el nombre");
                            break;
                        case 18452:    //Login failed for user '%ls'. Reason: Not associated with a trusted SQL Server connection.
                            MessageBox.Show("Especifique un usuario y password");
                            break;
                        case 18456: //Login failed for user '%ls'.
                            MessageBox.Show("El usuario o password es incorrecto");
                            break;
                        case 4060:    //Cannot open database requested in login '%.*ls'. Login fails.
                            MessageBox.Show("El usuario no tiene permisos para acceder a la base de datos ");
                            break;
                        case 208:    //Invalid object name '%ls'."
                            MessageBox.Show("El nombre del objeto es incorrecto, para mayor información consulte la lnea :" + sError.LineNumber);
                            break;
                        default:
                            MessageBox.Show(sError.Message);
                            break;
                    }
                }
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString() + " Visualizar reporte de personal desconocido", "MENSAJE DEL SISTEMA");
                return;
            }

            #endregion
        }




    }
}
