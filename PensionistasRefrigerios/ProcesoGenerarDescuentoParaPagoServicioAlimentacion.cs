using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Transportista.Negocios;
using System.Configuration;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ProcesoGenerarDescuentoParaPagoServicioAlimentacion : Form
    {
        private Mes MesesNeg;
        private DateTime FechaInicio;
        private DateTime FechaTermino;
        private List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ListaAsistenciasPersonalPendientesMovimientoAsistencia;
        private SJM_PensionesNegocios Modelo;
        private oConsultaConsolidadAsistenciaRefrigerio oConsulta;
        private RefrigeriosPensionesNegocios modeloAsistencias;
        private List<SJM_RefrigerioPensionesPersonalListaAsistenciaResult> ListadoAsistenciasTrabajosDiarioCampo;
        private List<SJM_Pensione> listadoAsistenciaByDescuento;
        private string Periodo;
        private List<SJ_RHPensionFacturacionPensionDiasExcluido> listadoDiasExcluidosaDescuentoByPeriodo;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        private string periodoConsulta;

        public ProcesoGenerarDescuentoParaPagoServicioAlimentacion()
        {
            InitializeComponent();
            CargarMeses();
            ObtenerFechasIniciales();
            Inicio();
        }

        public void Inicio()
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
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void ObtenerFechasIniciales()
        {
            try
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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarDescuento();
        }

        private void GenerarDescuento()
        {
            progressBar.Visible = true;
            gbProceso.Enabled = false;
            btnGenerar.Enabled = false;
            btnProgramarExclusion.Enabled = false;
            progressBar.Visible = true;
            bgwHilo.RunWorkerAsync();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarProceso();
        }

        private void EjecutarProceso()
        {
            try
            {

                oConsulta = new oConsultaConsolidadAsistenciaRefrigerio();
                oConsulta.fechaDesde = this.txtFechaDesde.Text;
                oConsulta.fechaHasta = this.txtFechaHasta.Text;
                oConsulta.periodo = this.txtPeriodo.Value.ToString() + this.txtFechaDesde.Text.Substring(3, 2);
                oConsulta.año = this.txtPeriodo.Value.ToString();
                oConsulta.nombrePension = this.txtRazonSocialProveedor.Text.Trim();
                oConsulta.nroDniPension = this.txtDNIProveedor.Text.ToString().Trim();
                /* 0.- Actualizar el nombre de los desconocidos */
                Modelo = new SJM_PensionesNegocios();
                Modelo.ProcesoCorregirNombresPersonalDesconocido(oConsulta.fechaDesde.ToString().Trim(), oConsulta.fechaHasta.ToString().Trim(), oConsulta.nroDniPension.ToString().Trim());

                /* 1.- Actualizar todas las asienticas a pendientes*/
                Modelo = new SJM_PensionesNegocios();
                Modelo.ProcesoActualizarAsistenciaRefrigeriosAEstadoPendiente(oConsulta.fechaDesde.ToString().Trim(), oConsulta.fechaHasta.ToString().Trim(), oConsulta.nroDniPension.ToString().Trim());
                /* 2.- Anular asistencias duplicadas por persona, pension y tipo de refigerio y fecha */
                for (int i = 0; i < 2; i++)
                {
                    Modelo = new SJM_PensionesNegocios();
                    Modelo.ProcesoAnularAsistenciaDuplicadasByAsistenciasRefrigerios(oConsulta.fechaDesde.ToString().Trim(), oConsulta.fechaHasta.ToString().Trim(), oConsulta.nroDniPension.ToString().Trim()); 
                }
                

                /* 3. Generar descuento por Inasistencia */
                /* 3.1 Obtener lista de asistencias del personal (TRANSFERENCIAS DEL MOVIL) con estado pendientes del movimiento asistencia por periodo */
                ListaAsistenciasPersonalPendientesMovimientoAsistencia = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
                Modelo = new SJM_PensionesNegocios();
                ListaAsistenciasPersonalPendientesMovimientoAsistencia = Modelo.ObtenerListaAsistenciasPersonalPendientesMovimientoAsistencia(oConsulta.año, oConsulta.fechaDesde, oConsulta.fechaHasta, oConsulta.nroDniPension).ToList();
                /* 3.2 Obtener el lista de asistencia de labores de campo por horas */
                modeloAsistencias = new RefrigeriosPensionesNegocios();
                ListadoAsistenciasTrabajosDiarioCampo = new List<SJM_RefrigerioPensionesPersonalListaAsistenciaResult>();
                ListadoAsistenciasTrabajosDiarioCampo = modeloAsistencias.ObtenerListaAsistenciaPlanillaRRHHLaboresCampo(oConsulta.fechaDesde, oConsulta.fechaHasta).ToList();
                /* 3.3 Obtener listar de días excluidos a descuento por periodo */
                Modelo = new SJM_PensionesNegocios();
                listadoDiasExcluidosaDescuentoByPeriodo = new List<SJ_RHPensionFacturacionPensionDiasExcluido>();
                listadoDiasExcluidosaDescuentoByPeriodo = Modelo.ListarDiasExcluidosaDescuentoByPeriodo(oConsulta.fechaDesde, oConsulta.fechaHasta).ToList();
                /* 3.4 Generar descuento por Inasistencia */
                if (ListaAsistenciasPersonalPendientesMovimientoAsistencia != null && ListaAsistenciasPersonalPendientesMovimientoAsistencia.ToList().Count > 0)
                {
                    if (ListadoAsistenciasTrabajosDiarioCampo != null && ListadoAsistenciasTrabajosDiarioCampo.ToList().Count > 0)
                    {
                        /* 3.4.1 Generar descuento por Inasistencia */
                        /* Aquí aplico la logica de cuando descontar, criterios de descuento */
                        listadoAsistenciaByDescuento = new List<SJM_Pensione>();
                        listadoAsistenciaByDescuento = Modelo.GenerarListaPersonalParaDescuento(ListaAsistenciasPersonalPendientesMovimientoAsistencia, ListadoAsistenciasTrabajosDiarioCampo, listadoDiasExcluidosaDescuentoByPeriodo).ToList();
                    }
                }



            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarResultadoConsulta();
        }

        private void PresentarResultadoConsulta()
        {
            try
            {
                int contado = listadoAsistenciaByDescuento != null ? listadoAsistenciaByDescuento.ToList().Count : 0;
                MessageBox.Show("Se realizo el descuento respectivo al personal por el servicio de alimentación", "MENSAJE DE SISTEMA");
                gbProceso.Enabled = true;
                progressBar.Visible = false;
                btnGenerar.Enabled = true;
                btnProgramarExclusion.Enabled = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DE SISTEMA");
                gbProceso.Enabled = true;
                progressBar.Visible = false;
                btnGenerar.Enabled = true;
                btnProgramarExclusion.Enabled = true;
                return;
            }
        }

        private void GenerarDescuentoParaPagoServicioAlimentacion_Load(object sender, EventArgs e)
        {

        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void btnBuscarTransportista_Click(object sender, EventArgs e)
        {

            this.txtRazonSocialProveedor.Clear();
            this.txtDNIProveedor.Clear();

            BuscarPension oFrm = new BuscarPension();
            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                if (oFrm.ObjetoBusquedaPension != null)
                {
                    try
                    {

                        this.txtRazonSocialProveedor.Text = oFrm.ObjetoBusquedaPension.RazonSocial;
                        this.txtDNIProveedor.Text = oFrm.ObjetoBusquedaPension.NroDNI.ToString().Trim();
                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                }
            }
        }

        private void btnExlcuirFechasParaDescuento_Click(object sender, EventArgs e)
        {
            ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas ofrm = new ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas();
            ofrm.WindowState = FormWindowState.Normal;

            ofrm.ShowDialog();
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
