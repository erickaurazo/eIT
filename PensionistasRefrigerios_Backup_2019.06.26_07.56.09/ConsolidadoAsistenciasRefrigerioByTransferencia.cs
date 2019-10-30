using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Configuration;
using System.Collections;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ConsolidadoAsistenciasRefrigerioByTransferencia : Telerik.WinControls.UI.RadForm
    {
        private string vistaListado = "T";
        private Mes MesesNeg;
        private DateTime FechaInicio;
        private DateTime FechaTermino;
        private List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ListaAsistenciasPersonalPendientesMovimientoAsistencia;
        private SJM_PensionesNegocios Modelo;
        private SJM_Pensione oTransferenciaAsistencia;
        private string NombreArchivo;
        private bool exportVisualSettings;
        private List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia;

        private oConsultaConsolidadAsistenciaRefrigerio oConsulta;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        private SJ_RHMovimientoAsistenciaPensionNegocios modelo;
        private List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult> listadoMovimientoAsistenciaRefrigerios;

        public ConsolidadoAsistenciasRefrigerioByTransferencia()
        {
            InitializeComponent();
            Inicio();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            CargarMeses();
            ObtenerFechasIniciales();
        }

        public void Inicio()
        {
            try
            {

                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + DateTime.Now.Year.ToString()].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "ERICK AURAZO";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void ObtenerFechasIniciales()
        {

            this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);
            this.txtFechaDesde.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);
            FechaInicio = Convert.ToDateTime(this.txtFechaDesde.Text);
            FechaTermino = Convert.ToDateTime(this.txtFechaDesde.Text);
            int numeroSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
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
                        this.txtFechaDesde.ReadOnly = false;
                        this.txtFechaHasta.ReadOnly = false;
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

        private void ObtenerFechasDias()
        {
            if (EsFecha(this.txtFechaDesde.Text))
            {
                //FechaInicio = Convert.ToDateTime(this.txtFechaDesde.Text);
                //FechaTermino = Convert.ToDateTime(this.txtFechaDesde.Text);
                //this.txtFechaDesde.Text = FechaInicio.ToShortDateString();
                //this.txtFechaHasta.Text = FechaTermino.ToShortDateString();
            }
            else
            {
                MessageBox.Show("FECHA INCORRECTA");
                FechaInicio = DateTime.Now;
                FechaTermino = DateTime.Now;
                this.txtFechaDesde.Text = FechaInicio.ToShortDateString();
                this.txtFechaHasta.Text = FechaTermino.ToShortDateString();
            }
        }

        public static Boolean EsFecha(String fecha)
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

        private void CargarMeses()
        {

            MesesNeg = new Mes();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = MesesNeg.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("13");
        }

        private void ConsolidadoAsistenciasPensionistas_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            this.dgvRegistros.TableElement.BeginUpdate();
            //this.dgvDetalle.Columns["chPlaca"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvRegistros.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvRegistros.MasterTemplate.AutoExpandGroups = true;
            this.dgvRegistros.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistros.GroupDescriptors.Clear();
            this.dgvRegistros.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items1 = new GridViewSummaryRowItem();
            items1.Add(new GridViewSummaryItem("chDniTrabajador", "Count: {0:N0}; ", GridAggregateFunction.Count));
            //this.dgvListaAgrupada.MasterTemplate.SummaryRowsBottom.Add(items1);
            this.dgvRegistros.MasterTemplate.SummaryRowsTop.Add(items1);
        }

        private void btnBuscarTransportista_Click(object sender, EventArgs e)
        {
            this.txtRUCProveedor.Clear();
            this.txtRazonSocialProveedor.Clear();
            this.txtRazonSocialProveedor.Clear();
            this.txtIdPension.Clear();
            this.txtPseudoNombre.Clear();
            this.txtnroDniPension.Clear();

            BuscarPension oFrm = new BuscarPension();
            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                if (oFrm.ObjetoBusquedaPension != null)
                {
                    try
                    {
                        this.txtRUCProveedor.Text = oFrm.ObjetoBusquedaPension.NroRuc;
                        this.txtRazonSocialProveedor.Text = oFrm.ObjetoBusquedaPension.RazonSocial;
                        this.txtIdPension.Text = oFrm.ObjetoBusquedaPension.IdPension.ToString();
                        //this.txtRucDNIResponsable.Text = oFrm.ObjetoBusquedaPension.NroDNI;
                        this.txtPseudoNombre.Text = oFrm.ObjetoBusquedaPension.PseudoNombre.ToString().Trim();
                        this.txtnroDniPension.Text = oFrm.ObjetoBusquedaPension.NroDNI.ToString().Trim();
                        //this.txtRucNombreComercial.Text = oFrm.ObjetoBusquedaPension.PseudoNombre;

                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                }
            }
        }

        private void rbtTodos_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            vistaListado = "T";
            if (ListaAsistenciasPersonalPendientesMovimientoAsistencia != null && ListaAsistenciasPersonalPendientesMovimientoAsistencia.ToList().Count > 0)
            {
                var resultado = ListaAsistenciasPersonalPendientesMovimientoAsistencia.ToList();
                dgvRegistros.DataSource = resultado.ToDataTable<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                dgvRegistros.Refresh();
                lblresultados.Text = "Se encontraron # " + resultado.ToList().Count.ToString("N2") + "  de registros";
                ResaltarResultados();
            }
        }

        private void rbtPendientes_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            vistaListado = "P";
            if (ListaAsistenciasPersonalPendientesMovimientoAsistencia != null && ListaAsistenciasPersonalPendientesMovimientoAsistencia.ToList().Count > 0)
            {
                var resultadoP = ListaAsistenciasPersonalPendientesMovimientoAsistencia.Where(x => x.NombresTrabajador.ToString().Trim() != "DESCONOCIDO" && x.estado == 1).ToList();
                dgvRegistros.DataSource = resultadoP.ToDataTable<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                dgvRegistros.Refresh();
                lblresultados.Text = "Se encontraron # " + resultadoP.ToList().Count.ToString("N2") + "  de registros";
                ResaltarResultados();
            }
        }

        private void rbtDesconocidos_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            vistaListado = "D";
            if (ListaAsistenciasPersonalPendientesMovimientoAsistencia != null && ListaAsistenciasPersonalPendientesMovimientoAsistencia.ToList().Count > 0)
            {
                var resultadoD = ListaAsistenciasPersonalPendientesMovimientoAsistencia.Where(x => x.NombresTrabajador.ToString().Trim() == "DESCONOCIDO" && x.estado == 1).ToList();
                dgvRegistros.DataSource = resultadoD.ToDataTable<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                dgvRegistros.Refresh();
                lblresultados.Text = "Se encontraron # " + resultadoD.ToList().Count.ToString("N2") + "  de registros";
                ResaltarResultados();
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
                oConsulta = new oConsultaConsolidadAsistenciaRefrigerio();
                oConsulta.fechaDesde = this.txtFechaDesde.Text;
                oConsulta.fechaHasta = this.txtFechaHasta.Text;
                oConsulta.periodo = this.txtPeriodo.Value.ToString() + this.txtFechaDesde.Text.Substring(3, 2);
                oConsulta.año = this.txtPeriodo.Value.ToString();
                oConsulta.nroDniPension = this.txtnroDniPension.Text;
                oConsulta.nroRuc = this.txtRUCProveedor.Text.Trim();
                oConsulta.IdPension = this.txtIdPension.Text.Trim();
                oConsulta.nombrePension = this.txtRazonSocialProveedor.Text.Trim();
                oConsulta.nombreComercial = this.txtPseudoNombre.Text.Trim();

                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(Convert.ToInt32(this.txtFechaDesde.Text.Substring(3, 2)));
                oConsulta.nombresMes = nombreMes.ToUpper();

                //if (nroDniPension != null && nroDniPension.ToString().Trim() != "")
                //{
                btnConsultar.Enabled = false;
                btnGenerarProceso.Enabled = false;
                menuPrincipal.Enabled = false;
                ProgressBar.Visible = true;
                gbConsulta.Enabled = false;
                bgwHilo.RunWorkerAsync();
                //}
                //else
                //{
                //    MessageBox.Show("Debe ingresar una pensión valida", "Mensaje del Sistema");
                //    this.txtRUCProveedor.Focus();
                //}
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }

        private void EjecutarConsultar()
        {
            try
            {
                #region Ejecutar Consulta()
                ListaAsistenciasPersonalPendientesMovimientoAsistencia = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                Modelo = new SJM_PensionesNegocios();
                ListaAsistenciasPersonalPendientesMovimientoAsistencia = Modelo.ObtenerListaAsistenciasPersonalPendientesMovimientoAsistencia(oConsulta.año, oConsulta.fechaDesde, oConsulta.fechaHasta, oConsulta.nroDniPension).ToList();

                var listadoAsistenciasPersonalAnuladosMovimientoAsistencia = Modelo.ObtenerListaAsistenciasPersonalAnuladosMovimientoAsistencia(oConsulta.año, oConsulta.fechaDesde, oConsulta.fechaHasta, oConsulta.nroDniPension).ToList();

                ListaAsistenciasPersonalPendientesMovimientoAsistencia.AddRange(listadoAsistenciasPersonalAnuladosMovimientoAsistencia);
                /*agrego lista de desconocido*/

                Modelo = new SJM_PensionesNegocios();
                var ListaAsistenciasPersonalDesconocidoPendientesMovimientoAsistencia = Modelo.ObtenerListaAsistenciasPersonalDesconocidoPendientesMovimientoAsistencia(oConsulta.año, oConsulta.fechaDesde, oConsulta.fechaHasta, oConsulta.nroDniPension).ToList();

                if (ListaAsistenciasPersonalDesconocidoPendientesMovimientoAsistencia != null && ListaAsistenciasPersonalDesconocidoPendientesMovimientoAsistencia.ToList().Count > 0)
                {
                    ListaAsistenciasPersonalPendientesMovimientoAsistencia.AddRange(ListaAsistenciasPersonalDesconocidoPendientesMovimientoAsistencia);
                }

                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void PresentarResultados()
        {
            try
            {
                #region Presentar Resultados()
                if (ListaAsistenciasPersonalPendientesMovimientoAsistencia != null && ListaAsistenciasPersonalPendientesMovimientoAsistencia.ToList().Count > 0)
                {
                    switch (vistaListado)
                    {
                        case "T":  /*  listar todos los registros incluyendo los desconocido y conocidos no procesados */
                            ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                            ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia = ListaAsistenciasPersonalPendientesMovimientoAsistencia.ToList();
                            dgvRegistros.DataSource = ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia.ToDataTable<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                            dgvRegistros.Refresh();
                            lblresultados.Text = "Se encontraron # " + ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia.ToList().Count.ToString("N0") + "  de registros";
                            ResaltarResultados();
                            break;

                        case "P":  /*  listar todos los registros conocidos no procesados */
                            ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                            ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia = ListaAsistenciasPersonalPendientesMovimientoAsistencia.Where(x => x.NombresTrabajador.ToString().Trim() != "DESCONOCIDO" && x.estado == 1).ToList();
                            dgvRegistros.DataSource = ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia.ToDataTable<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                            dgvRegistros.Refresh();
                            lblresultados.Text = "Se encontraron # " + ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia.ToList().Count.ToString("N0") + "  de registros";
                            ResaltarResultados();
                            break;

                        case "D": /*  listar todos los registros desconocido  no procesados */
                            ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                            ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia = ListaAsistenciasPersonalPendientesMovimientoAsistencia.Where(x => x.NombresTrabajador.ToString().Trim() == "DESCONOCIDO" && x.estado == 1).ToList();
                            dgvRegistros.DataSource = ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia.ToDataTable<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                            dgvRegistros.Refresh();
                            lblresultados.Text = "Se encontraron # " + ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia.ToList().Count.ToString("N0") + "  de registros";
                            ResaltarResultados();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    ListaAsistenciasPersonalPendientesMovimientoAsistencia = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                    dgvRegistros.DataSource = ListaAsistenciasPersonalPendientesMovimientoAsistencia.ToDataTable<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                    RadMessageBox.Show("No se encontraron coincidencia en la consulta", "Mensaje de Sistema");
                    dgvRegistros.Refresh();
                    lblresultados.Text = "No se encontraron #  de registros";
                }
                btnConsultar.Enabled = true;
                btnGenerarProceso.Enabled = true;
                menuPrincipal.Enabled = true;
                ProgressBar.Visible = false;
                gbConsulta.Enabled = true;
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString().Trim() + "\nPresentar información", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ResaltarResultados()
        {
            if (dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                for (int i = 0; i < dgvRegistros.Rows.Count; i++)
                {
                    if (dgvRegistros.Rows[i].Cells["chNombresTrabajador"].Value.ToString().Trim().ToUpper() == "DESCONOCIDO".ToUpper())
                    {
                        for (int j = 0; j < dgvRegistros.Columns.Count; j++)
                        {
                            dgvRegistros.Rows[i].Cells[j].Style.CustomizeFill = true;
                            dgvRegistros.Rows[i].Cells[j].Style.DrawFill = true;
                            dgvRegistros.Rows[i].Cells[j].Style.BackColor = Utiles.colorCelesteMedio;
                            //dgvRegistros.Rows[i].Cells[j].Style.Font = new Font("Tahoma", 8, FontStyle.Bold); //
                        }
                    }

                    if (dgvRegistros.Rows[i].Cells["chEstado"].Value.ToString().Trim().ToUpper() == "0")
                    {
                        for (int j = 0; j < dgvRegistros.Columns.Count; j++)
                        {
                            dgvRegistros.Rows[i].Cells[j].Style.CustomizeFill = true;
                            dgvRegistros.Rows[i].Cells[j].Style.DrawFill = true;
                            dgvRegistros.Rows[i].Cells[j].Style.BackColor = Utiles.blancoHumo3D;

                        }
                    }

                    if (dgvRegistros.Rows[i].Cells["chEstado"].Value.ToString().Trim().ToUpper() == "2")
                    {
                        for (int j = 0; j < dgvRegistros.Columns.Count; j++)
                        {
                            dgvRegistros.Rows[i].Cells[j].Style.CustomizeFill = true;
                            dgvRegistros.Rows[i].Cells[j].Style.DrawFill = true;
                            dgvRegistros.Rows[i].Cells[j].Style.BackColor = Utiles.colorAmarilloClaro;
                            //dgvRegistros.Rows[i].Cells[j].Style.Font = new Font("Tahoma", 8, FontStyle.Bold); //
                        }
                    }

                }
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //ObtenerFechasMes(); 01/01/2015
            //string aed = this.txtFechaDesde.Text.Substring(0, 3);
            //FechaInicio = Convert.ToDateTime(this.txtFechaDesde.Text.Substring(0, 3) + this.cboMes.SelectedValue.ToString() + "/" + txtPeriodo.Value.ToString());
            //FechaTermino = Convert.ToDateTime(this.txtFechaDesde.Text.Substring(0, 3) + this.cboMes.SelectedValue.ToString() + "/" + txtPeriodo.Value.ToString());
            //this.txtFechaDesde.Text = FechaInicio.ToShortDateString();
            //this.txtFechaHasta.Text = FechaTermino.ToShortDateString();
            //ObtenerFechasDias();

            ObtenerFechasMes();
        }

        private void txtPeriodo_Leave(object sender, EventArgs e)
        {

            string aed = this.txtFechaDesde.Text.Substring(0, 6);
            FechaInicio = Convert.ToDateTime(this.txtFechaDesde.Text.Substring(0, 6) + txtPeriodo.Value.ToString());
            FechaTermino = Convert.ToDateTime(this.txtFechaDesde.Text.Substring(0, 6) + txtPeriodo.Value.ToString());

            this.txtFechaDesde.Text = FechaInicio.ToShortDateString();
            this.txtFechaHasta.Text = FechaTermino.ToShortDateString();
        }

        private void txtFechaDesde_Leave(object sender, EventArgs e)
        {
            //ObtenerFechasDias();
        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
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

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarConsultar();
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarResultados();
        }

        private void gbSelecionar_Click(object sender, EventArgs e)
        {

        }

        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {
            oTransferenciaAsistencia = new SJM_Pensione();
            oTransferenciaAsistencia.IdPension = 0;
            modificarDNIAsistenciaRefrigerios.Enabled = false;
            modificarDNIPersonalGeneral.Enabled = false;
            modificarDNI.Enabled = false;
            transferirAsistenciaAOtraPension.Enabled = false;
            transferirAsistenciaAOtraFecha.Enabled = false;
            anularAsistencia.Enabled = true;
            btnVerDetalleDeAsistencia.Enabled = false;
            anularAsistencia.Text = "Activar Asistencia";


            if (dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                if (dgvRegistros.CurrentRow != null && dgvRegistros.CurrentRow.Cells["chidMovimientoTransferencia"].Value != null)
                {
                    if (dgvRegistros.CurrentRow.Cells["chidMovimientoTransferencia"].Value.ToString().Trim() != "")
                    {
                        #region Obtener Objeto SJM_Pensiones()
                        oTransferenciaAsistencia = new SJM_Pensione();
                        oTransferenciaAsistencia.IdPension = dgvRegistros.CurrentRow.Cells["chidMovimientoTransferencia"].Value != null ? Convert.ToInt32(dgvRegistros.CurrentRow.Cells["chidMovimientoTransferencia"].Value) : 0;
                        oTransferenciaAsistencia.DniPension = dgvRegistros.CurrentRow.Cells["chDniPension"].Value != null ? Convert.ToString(dgvRegistros.CurrentRow.Cells["chDniPension"].Value) : "";
                        oTransferenciaAsistencia.NombresPension = dgvRegistros.CurrentRow.Cells["chNombresPension"].Value != null ? Convert.ToString(dgvRegistros.CurrentRow.Cells["chNombresPension"].Value) : "";
                        oTransferenciaAsistencia.DniTrabajador = dgvRegistros.CurrentRow.Cells["chDniTrabajador"].Value != null ? Convert.ToString(dgvRegistros.CurrentRow.Cells["chDniTrabajador"].Value) : "";
                        oTransferenciaAsistencia.NombresTrabajador = dgvRegistros.CurrentRow.Cells["chNombresTrabajador"].Value != null ? Convert.ToString(dgvRegistros.CurrentRow.Cells["chNombresTrabajador"].Value) : "";
                        oTransferenciaAsistencia.TipoComida = dgvRegistros.CurrentRow.Cells["chidRefrigerio"].Value != null ? Convert.ToInt32(dgvRegistros.CurrentRow.Cells["chidRefrigerio"].Value) : 0;
                        oTransferenciaAsistencia.FechaPension = dgvRegistros.CurrentRow.Cells["chFechaRefrigerio"].Value != null ? Convert.ToDateTime(dgvRegistros.CurrentRow.Cells["chFechaRefrigerio"].Value) : (DateTime?)null;
                        oTransferenciaAsistencia.estado = dgvRegistros.CurrentRow.Cells["chEstado"].Value != null ? Convert.ToByte(dgvRegistros.CurrentRow.Cells["chEstado"].Value) : Convert.ToByte(1);
                        oTransferenciaAsistencia.EsProcesado = dgvRegistros.CurrentRow.Cells["chEsProcesado"].Value != null ? Convert.ToByte(dgvRegistros.CurrentRow.Cells["chEsProcesado"].Value) : Convert.ToByte(0);

                        if (oTransferenciaAsistencia.IdPension > 0)
                        {
                            #region Desactivar subMenu()
                            if (oTransferenciaAsistencia.estado == 1)
                            {
                                modificarDNI.Enabled = true;
                                modificarDNIAsistenciaRefrigerios.Enabled = true;
                                modificarDNIPersonalGeneral.Enabled = true;
                                anularAsistencia.Enabled = true;
                                transferirAsistenciaAOtraPension.Enabled = false;
                                transferirAsistenciaAOtraFecha.Enabled = true;
                                btnVerDetalleDeAsistencia.Enabled = !false;
                                anularAsistencia.Text = "Anular Asistencia";
                            }
                            #endregion
                        }
                        #endregion
                    }

                }
            }
        }

        private void anularAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AnularAsistenciaTransferida();

        }

        private void AnularAsistenciaTransferida()
        {
            if (oTransferenciaAsistencia.IdPension > 0 && oTransferenciaAsistencia.IdPension != (int?)null)
            {
                try
                {
                    Modelo = new SJM_PensionesNegocios();
                    SJM_Pensione oTransferenciaAsistenciaA = new SJM_Pensione();
                    oTransferenciaAsistenciaA = oTransferenciaAsistencia;
                    Modelo.AnularAsistenciaTransferida(oConsulta.año, oTransferenciaAsistenciaA.IdPension);
                    MessageBox.Show("Registrado correctamente", "Mensaje del Sistema");
                    //Consultar();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                    return;
                }
            }
        }

        private void modificarDNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oTransferenciaAsistencia.IdPension > 0 && oTransferenciaAsistencia.IdPension != (int?)null)
            {
                try
                {
                    SJM_Pensione oTransferenciaAsistenciaDNI = new SJM_Pensione();
                    oTransferenciaAsistenciaDNI = oTransferenciaAsistencia;
                    ModificarDNITrabajador oFormulario = new ModificarDNITrabajador(oTransferenciaAsistenciaDNI);
                    oFormulario.Show();
                    //Modelo = new MovimientoAsistenciaRefrigerioNeg();
                    //Modelo.AnularAsistenciaTransferida(periodo, oTransferenciaAsistencia.IdPension);
                    //MessageBox.Show("Registrado correctamente", "Mensaje del Sistema");
                    //Consultar();
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                Exportar(dgvRegistros);
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
                //RadMessageBox.SetThemeName(radGridView.ThemeName);
                RadMessageBox.Show("Ingrese nombre al archivo.");
                return;
            }

            NombreArchivo = this.saveFileDialog.FileName;
            bool openExportFile = false;
            this.exportVisualSettings = true;
            RunExportToExcelML(NombreArchivo, ref openExportFile, radGridView);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(NombreArchivo);
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
            excelExporter.SheetName = "Consolidado de Asist.";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
            excelExporter.HiddenColumnOption = HiddenOption.DoNotExport;


            try
            {
                excelExporter.RunExport(fileName);
                //RadMessageBox.SetThemeName(grilla.ThemeName);
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

        private void txtFechaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ObtenerFechasDias();
        }

        private void modificarDNIPersonalGeneral_Click(object sender, EventArgs e)
        {
            if (oTransferenciaAsistencia.IdPension > 0 && oTransferenciaAsistencia.IdPension != (int?)null)
            {
                try
                {
                    SJM_Pensione oTransferenciaAsistenciaPersonalGeneralM = new SJM_Pensione();
                    oTransferenciaAsistenciaPersonalGeneralM = oTransferenciaAsistencia;
                    oTransferenciaAsistenciaPersonalGeneralM.DniPension = "00000000";
                    ModificarDNITrabajador oFormulario = new ModificarDNITrabajador(oTransferenciaAsistenciaPersonalGeneralM);
                    oFormulario.Show();
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }
        }

        private void modificarDNIAsistenciaRefrigerios_Click(object sender, EventArgs e)
        {
            if (oTransferenciaAsistencia.IdPension > 0 && oTransferenciaAsistencia.IdPension != (int?)null)
            {
                try
                {
                    SJM_Pensione oTransferenciaAsistenciaAsistenciaRefrigerios = new SJM_Pensione();
                    oTransferenciaAsistenciaAsistenciaRefrigerios = oTransferenciaAsistencia;
                    oTransferenciaAsistenciaAsistenciaRefrigerios.DniPension = "00000001";
                    ModificarDNITrabajador oFormulario = new ModificarDNITrabajador(oTransferenciaAsistenciaAsistenciaRefrigerios);
                    oFormulario.Show();
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }
        }

        private void transferirAsistenciaAOtraFecha_Click(object sender, EventArgs e)
        {

            if (oTransferenciaAsistencia.IdPension > 0 && oTransferenciaAsistencia.IdPension != (int?)null)
            {
                try
                {
                    SJM_Pensione oTransferenciaAsistenciaAsistenciaRefrigerios = new SJM_Pensione();
                    oTransferenciaAsistenciaAsistenciaRefrigerios = oTransferenciaAsistencia;
                    //                    oTransferenciaAsistenciaAsistenciaRefrigerios.DniPension = "00000001";
                    ModificarFechaAsistenciaRefrigerio oFormulario = new ModificarFechaAsistenciaRefrigerio(oTransferenciaAsistenciaAsistenciaRefrigerios);
                    oFormulario.Show();
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Prueba visualizar generacion de txt()
        //guardarTextoBOM();
        //leerTextoBOM();
        //prueba();
        #endregion

        private void prueba()
        {
            // crear el path
            var archivo = @"C:\logTemp.txt";

            // eliminar el fichero si ya existe
            if (File.Exists(archivo))
                File.Delete(archivo);

            // crear el fichero
            using (var fileStream = File.Create(archivo))
            {
                var texto = new UTF8Encoding(true).GetBytes("Aqui va el texto que desean volvar al fichero");
                fileStream.Write(texto, 0, texto.Length);
                fileStream.Flush();


                System.Diagnostics.Process.Start(archivo);


            }
        }

        private static void guardarTextoBOM()
        {
            const string fic = @"C:\logTemp.txt";
            string texto = "Érase una vez una vieja con un moño...";

            System.IO.StreamWriter sw =
                new System.IO.StreamWriter(fic, false, System.Text.Encoding.UTF8);
            sw.WriteLine(texto);
            sw.Close();
        }


        private static void leerTextoBOM()
        {
            const string fic = @"C:\logTemp.txt";
            string texto;

            System.IO.StreamReader sr =
                new System.IO.StreamReader(fic, System.Text.Encoding.Default, true);
            texto = sr.ReadToEnd();
            sr.Close();

            //Console.WriteLine(texto);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void txtnroDniPension_Leave(object sender, EventArgs e)
        {
            string[] cadena = this.txtRazonSocialProveedor.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPension(cadena);
            }

            if (this.txtPseudoNombre.Text != "" && this.txtRazonSocialProveedor.Text.ToString().Trim() == "")
            {
                this.txtPseudoNombre.Clear();
                this.txtnroDniPension.Clear();
                this.txtRUCProveedor.Clear();
            }
        }

        private void AsignarDatosPension(string[] ncadena)
        {
            this.txtRazonSocialProveedor.Text = ncadena[0].ToString().Trim();
            this.txtIdPension.Text = ncadena[3].ToString().Trim();
            this.txtRUCProveedor.Text = ncadena[1].ToString().Trim();
            this.txtPseudoNombre.Text = ncadena[2].ToString().Trim();
        }

        private void btnBuscarTransportista_Click_1(object sender, EventArgs e)
        {
            string[] cadena = this.txtRazonSocialProveedor.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPension(cadena);
            }
        }

        private void txtSemana_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasSemanalesByNumeroSemana();
        }

        private void btnGenerarProceso_Click(object sender, EventArgs e)
        {
            GenerarProcesoAsistencia();
        }

        private void GenerarProcesoAsistencia()
        {
            /*Validar el ingreso de la consulta antes de copiar toda la informacion consultada para ser incluida como la cabecera del formulario              del registro de los movimientos             */
            var listadoAsistenciaSinDesconocidos = ListaResultadoAsistenciasPersonalPendientesMovimientoAsistencia.Where(x => x.NombresTrabajador.Trim() != "DESCONOCIDO" && x.estado == 1).ToList();
            if (oConsulta.nroDniPension != "" && (listadoAsistenciaSinDesconocidos != null && listadoAsistenciaSinDesconocidos.ToList().Count > 0) && (oConsulta.fechaDesde == oConsulta.fechaHasta))
            {
                /* incluir datos de la consulta en el siguiente formulario */
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                listadoMovimientoAsistenciaRefrigerios = new List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult>();
                listadoMovimientoAsistenciaRefrigerios = modelo.ObtenerMovimientoAsistenciaRefrigerioByPeriodo("", oConsulta.nroDniPension, oConsulta.fechaDesde, oConsulta.fechaHasta).ToList();

                if (listadoMovimientoAsistenciaRefrigerios != null && listadoMovimientoAsistenciaRefrigerios.ToList().Count > 0)
                {
                    MovimientoAsistenciaRefrigerioMatenimiento ofrm = new MovimientoAsistenciaRefrigerioMatenimiento(oConsulta);
                    ofrm.MdiParent = ConsolidadoAsistenciasRefrigerioByTransferencia.ActiveForm;
                    ofrm.Show();
                    //newMDIChild.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    MessageBox.Show("No existen elementos para realizar el registro del movimiento de asistencia", "MENSAJE DEL SISTENA");
                }
            }
            else
            {
                MessageBox.Show("el criterio de consulta no cumple con los parametros para la generación del movimiento de asistencia.\nVerificar que el RUC del proveedor. \nVerificar que la fecha de inicio y termino coincidan. \nVerificar que el resultado de la consulta contenga al menos un registro ", "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnVerDetalleDeAsistencia_Click(object sender, EventArgs e)
        {

            if (oConsulta.fechaDesde != null && oConsulta.fechaDesde != string.Empty && oConsulta.fechaHasta != null && oConsulta.fechaHasta != string.Empty && oTransferenciaAsistencia.DniTrabajador != null && oTransferenciaAsistencia.DniTrabajador != string.Empty)
            {
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                string idCodigoGeneral = modelo.ObtnerCodigoPersonal(oTransferenciaAsistencia.DniTrabajador);
                ReporteAsistenciaPersonalLaboresCampoxHoras ofrm = new ReporteAsistenciaPersonalLaboresCampoxHoras(oConsulta.fechaDesde, oConsulta.fechaHasta, idCodigoGeneral);
                ofrm.ShowDialog();
            }

        }

        private void btnAnularAsistenciaPorNoCorresponderAPension_Click(object sender, EventArgs e)
        {
            AnularAsistenciaTransferidaByNoAsignacionPension();
        }

        private void AnularAsistenciaTransferidaByNoAsignacionPension()
        {
            if (oTransferenciaAsistencia.IdPension > 0 && oTransferenciaAsistencia.IdPension != (int?)null)
            {
                try
                {
                    Modelo = new SJM_PensionesNegocios();
                    SJM_Pensione oTransferenciaAsistenciaA = new SJM_Pensione();
                    oTransferenciaAsistenciaA = oTransferenciaAsistencia;
                    Modelo.AnularAsistenciaTransferida(oConsulta.año, oTransferenciaAsistenciaA.IdPension, 3);
                    MessageBox.Show("Proceso realizado correctamente", "Mensaje del Sistema");
                    //Consultar();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                    return;
                }
            }
        }

        private void btnExcluirDeProcesoDeDescuento_Click(object sender, EventArgs e)
        {
            ExcluirDeProcesoDeDescuento();
        }

        private void ExcluirDeProcesoDeDescuento()
        {
            if (oTransferenciaAsistencia.IdPension > 0 && oTransferenciaAsistencia.IdPension != (int?)null)
            {
                try
                {
                    Modelo = new SJM_PensionesNegocios();
                    SJM_Pensione oTransferenciaAsistenciaA = new SJM_Pensione();
                    oTransferenciaAsistenciaA = oTransferenciaAsistencia;
                    Modelo.ExcluirDeProcesoDeDescuento(oConsulta.año, oTransferenciaAsistenciaA.IdPension, 3);
                    MessageBox.Show("Proceso realizado correctamente", "Mensaje del Sistema");
                    //Consultar();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                    return;
                }
            }
        }


    }
}
