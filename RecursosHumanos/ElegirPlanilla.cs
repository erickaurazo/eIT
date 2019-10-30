using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using System.Threading;
using CrystalDecisions.CrystalReports.Engine;
using RecursosHumanos.Negocios;
using RecursosHumanos.Negocios;
using System.Globalization;

namespace RecursosHumanos
{
    public partial class ElegirPlanilla : Form
    {
        private DateTime FechaInicio;
        private DateTime FechaTermino;
        private PlanillaPeriodo oPeriodoPlanilla;
        private PeriodoPlanillaNegocio oPeriodoPlanillaNegocio;
        private List<PlanillaPeriodo> ListaPeriodoPlanilla;
        private Mes MesesNeg;
        private PlanillaNegocios planillaNegocios;
        private string periodoSeleccionado;
        private string CodigoUnicoAccesoSistema;
        private string p_2;
        private UsuarioMovimientoIngresoSistemaNegocio modeloSesionUsuario;
        private UsuarioMovimientoIngresoSistema infoSession;
        private PlanillaPeriodo oPeriodoPlanillaElegida;
        private PlanillaPeriodo oPeriodoPlanillaSeleccionada;

        public ElegirPlanilla()
        {
            InitializeComponent();
            CargarAño();
            CargarMeses();
            CargarComboPlanillas();
            ObtenerFechasIniciales();
        }

        private void CargarAño()
        {
            try
            {
                this.txtPeriodo.Value = Convert.ToInt32(infoSession.periodoElegido.Substring(0, 4));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        public ElegirPlanilla(string CodigoUnicoAccesoSistema, string codigoUsuario)
        {
            // TODO: Complete member initialization Program.ClaseCompartida.CodigoUnicoAccesoSistema, Program.ClaseCompartida.codigoUsuario
            InitializeComponent();
            this.CodigoUnicoAccesoSistema = CodigoUnicoAccesoSistema;
            Program.ClaseCompartida.CodigoUnicoAccesoSistema = CodigoUnicoAccesoSistema;
            Program.ClaseCompartida.codigoUsuario = codigoUsuario;
            this.codigoUsuario = codigoUsuario;

            infoSession = new UsuarioMovimientoIngresoSistema();
            infoSession.codigoAcceso = Program.ClaseCompartida.CodigoUnicoAccesoSistema;

            modeloSesionUsuario = new UsuarioMovimientoIngresoSistemaNegocio();
            infoSession = modeloSesionUsuario.ObtenerMovimientoIngresoSistemaByCodigoMovimiento(infoSession);


            CargarAño();
            CargarMeses();
            CargarComboPlanillas();
            ObtenerFechasIniciales();
        }

        private void ObtenerFechasIniciales()
        {
            try
            {
                //this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);
                this.cboPlanilla.SelectedValue = "OAS";
                //this.cboMes.SelectedValue = DateTime.Now.Month.ToString().PadLeft(2, '0');
                this.cboMes.SelectedValue = (infoSession.periodoElegido.Substring(4, 2));
                // Cargar combo de semanas si es planilla OAS
                CargarComboSemanas(DateTime.Now.ToPresentationDate(), this.cboPlanilla.SelectedValue.ToString().Trim(), infoSession.periodoElegido.Substring(0, 4));
                cboSemana.SelectedValue = oPeriodoPlanilla.semana;
                // Obtener semana 
                LLenarCamposFechaBySemana(DateTime.Now.ToPresentationDate(), this.cboPlanilla.SelectedValue.ToString().Trim(), DateTime.Now.Year.ToString(), oPeriodoPlanilla.semana);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }

        }

        private void LLenarCamposFechaBySemana(string fecha, string idplanilla, string periodo, string semana)
        {
            //oPeriodoPlanilla = new PlanillaPeriodo();
            //oPeriodoPlanilla.semana = oPeriodoPlanilla.semana;
            oPeriodoPlanillaNegocio = new PeriodoPlanillaNegocio();
            oPeriodoPlanillaSeleccionada = new PlanillaPeriodo();
            oPeriodoPlanillaSeleccionada = oPeriodoPlanillaNegocio.ObtenerSemanaByPlanillaBySemana(DateTime.Now.ToPresentationDate(), this.cboPlanilla.SelectedValue.ToString().Trim(), DateTime.Now.Year.ToString(), semana);
            FechaInicio = Convert.ToDateTime(oPeriodoPlanillaSeleccionada.fechaInicio);
            FechaTermino = Convert.ToDateTime(oPeriodoPlanillaSeleccionada.fechaFinal);
            this.txtFechaDesde.Text = FechaInicio.ToShortDateString();
            this.txtFechaHasta.Text = FechaTermino.ToShortDateString();
            cboSemana.SelectedValue = oPeriodoPlanilla.semana;
        }

        private void LLenarCamposFechaBySemanaByNumeroDeSemana(string periodo, string idplanilla, string semana)
        {
            oPeriodoPlanilla = new PlanillaPeriodo();
            oPeriodoPlanilla.periodo = periodo;
            oPeriodoPlanilla.CodigoPlanilla = idplanilla;
            oPeriodoPlanilla.semana = semana;
            oPeriodoPlanillaNegocio = new PeriodoPlanillaNegocio();

            oPeriodoPlanillaElegida = new PlanillaPeriodo();
            oPeriodoPlanillaElegida = oPeriodoPlanillaNegocio.ObtenerSemanaByPlanillaByNumeroDeSemana(periodo, idplanilla, semana);

            FechaInicio = Convert.ToDateTime(oPeriodoPlanillaElegida.fechaInicio);
            FechaTermino = Convert.ToDateTime(oPeriodoPlanillaElegida.fechaFinal);
            this.txtFechaDesde.Text = FechaInicio.ToShortDateString();
            this.txtFechaHasta.Text = FechaTermino.ToShortDateString();
        }

        private void CargarComboSemanas(string fecha, string idplanilla, string periodo)
        {

            try
            {
                ListaPeriodoPlanilla = new List<PlanillaPeriodo>();
                oPeriodoPlanillaNegocio = new PeriodoPlanillaNegocio();
                ListaPeriodoPlanilla = oPeriodoPlanillaNegocio.ListarPeriodoPlanillaPorCodigoPlanilla(fecha, idplanilla, periodo).ToList();
                cboSemana.DisplayMember = "semana";
                cboSemana.ValueMember = "semana";
                cboSemana.DataSource = ListaPeriodoPlanilla.ToList();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }


        }

        private void CargarComboSemanasByNumeroMes(string periodo, string idplanilla, string numeroDeMes)
        {

            ListaPeriodoPlanilla = new List<PlanillaPeriodo>();
            oPeriodoPlanillaNegocio = new PeriodoPlanillaNegocio();

            ListaPeriodoPlanilla = oPeriodoPlanillaNegocio.ListarPeriodoPlanillaPorCodigoPlanillaByNumeroDeMes(periodo, idplanilla, numeroDeMes).ToList();

            cboSemana.DisplayMember = "semana";
            cboSemana.ValueMember = "semana";
            cboSemana.DataSource = ListaPeriodoPlanilla.ToList();

        }

        private void ObtenerFechasSemanalesByNumeroSemana()
        {
            try
            {
                #region Asigar fechas por semana()
                oPeriodoPlanillaNegocio = new PeriodoPlanillaNegocio();
                oPeriodoPlanilla = new PlanillaPeriodo();
                ListaPeriodoPlanilla = new List<PlanillaPeriodo>();

                //ListaPeriodoPlanilla = oPeriodoPlanillaNegocio.ListarPeriodoPlanillaPorCodigoPlanilla(DateTime.Now, Program.ClaseCompartida.codigoTipoPlanilla, 

                //this.txtFechaDesde.Text = oSemanaConsulta.desde.Value.ToPresentationDate();
                //this.txtFechaHasta.Text = oSemanaConsulta.hasta.Value.ToPresentationDate();

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
            ////cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = MesesNeg.ListarDoceMeses().ToList();
            cboMes.SelectedValue = infoSession.periodoElegido.Substring(4,2);
            //cboMes.SelectedValue = DateTime.Now.Month.ToString().PadLeft(2, '0');
        }

        private void CargarComboPlanillas()
        {

            planillaNegocios = new PlanillaNegocios();
            cboPlanilla.DisplayMember = "descripcion";
            cboPlanilla.ValueMember = "codigoPlanilla";
            cboPlanilla.DataSource = planillaNegocios.ListarPlanillas(Program.ClaseCompartida.periodoElegido).ToList();
            cboPlanilla.SelectedValue = "OAS";
        }

        private void SelecionTipoPlanilla_Load(object sender, EventArgs e)
        {

        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void cboPlanilla_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboPlanilla.SelectedIndex >= 0)
            {
                if (cboPlanilla.SelectedValue.ToString().Trim() == "OAS")
                {
                    lblSemana.Visible = !false;
                    this.cboSemana.Visible = !false;
                }
                else if (cboPlanilla.SelectedValue.ToString().Trim() == "EAM")
                {
                    lblSemana.Visible = false;
                    this.cboSemana.Visible = false;

                }
                else if (cboPlanilla.SelectedValue.ToString().Trim() == "PRA")
                {
                    lblSemana.Visible = false;
                    this.cboSemana.Visible = false;
                }
                else
                {

                }

            }
        }

        private void ObtenerFechasSemana()
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

        private void txtSemana_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboMes.SelectedIndex >= 0)
            {
                string codigoPlanilla = this.cboPlanilla.SelectedValue != null ? this.cboPlanilla.SelectedValue.ToString() : "OAS";
                if (lblSemana.Visible == true)
                {
                    CargarComboSemanasByNumeroMes(this.txtPeriodo.Value.ToString(), codigoPlanilla, this.cboMes.SelectedValue.ToString());
                }
                else
                {
                    ObtenerFechasMes();
                }

            }
        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboSemana_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboSemana.SelectedIndex >= 0)
            {
                // Asignar semana
                if ((this.cboPlanilla.SelectedValue != null ? this.cboPlanilla.SelectedValue.ToString() : string.Empty) == "OAS")
                {
                    string codigoPlanilla = this.cboPlanilla.SelectedValue != null ? this.cboPlanilla.SelectedValue.ToString() : "OAS";
                    LLenarCamposFechaBySemanaByNumeroDeSemana(this.txtPeriodo.Value.ToString(), codigoPlanilla, cboSemana.SelectedValue.ToString());
                }
                else
                {
                    this.txtFechaDesde.Text = string.Empty;
                    this.txtFechaHasta.Text = string.Empty;
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                periodoSeleccionado = this.txtPeriodo.Value.ToString() + this.cboMes.SelectedValue.ToString();
                UsuarioMovimientoIngresoSistemaNegocio modelomovimientoDeUsuario = new UsuarioMovimientoIngresoSistemaNegocio();
                UsuarioMovimientoIngresoSistema movimientoDeUsuario = new UsuarioMovimientoIngresoSistema();
                movimientoDeUsuario.codigoAcceso = Program.ClaseCompartida.CodigoUnicoAccesoSistema;
                movimientoDeUsuario.periodoElegido = periodoSeleccionado;
                movimientoDeUsuario.semanaPlanillaElegida = cboSemana.SelectedValue.ToString();
                movimientoDeUsuario.codigoPlanillaElegida = cboPlanilla.SelectedValue.ToString();
                movimientoDeUsuario.IdUsuario = Program.ClaseCompartida.codigoUsuario;
                movimientoDeUsuario.desde = Convert.ToDateTime(this.txtFechaDesde.Text);
                movimientoDeUsuario.hasta = Convert.ToDateTime(this.txtFechaHasta.Text);
                movimientoDeUsuario.fechaAcceso = DateTime.Now;

                modelomovimientoDeUsuario.ActualizarPlanilla(movimientoDeUsuario, periodoSeleccionado);
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }

        }

        public string codigoUsuario { get; set; }

        private void cboSemana_Leave(object sender, EventArgs e)
        {
            if (cboSemana.SelectedIndex >= 0)
            {
                // Asignar semana
                string codigoPlanilla = this.cboPlanilla.SelectedValue != null ? this.cboPlanilla.SelectedValue.ToString() : "OAS";
                LLenarCamposFechaBySemanaByNumeroDeSemana(this.txtPeriodo.Value.ToString(), codigoPlanilla, cboSemana.SelectedValue.ToString());

            }
        }
    }
}
