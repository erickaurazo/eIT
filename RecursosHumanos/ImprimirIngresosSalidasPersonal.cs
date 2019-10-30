using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Configuration;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;

namespace RecursosHumanos
{
    public partial class ImprimirIngresosSalidasPersonal : Form
    {
        private Mes MesesNeg;
        private string periodo = DateTime.Now.Year.ToString();
        private PlanillasRRHHNegocio planillaRRHHNegocio;
        private SubPlanillasRRHH subplanillaRRHHNegocio;
        private IngresoSalidaPersonalNegocio modelo;
        private List<ST_RepoteMarcacionPersonal> resultadoConsulta;
        private List<ST_RepoteMarcacionPersonalByCodigoPersonalListadoResult> resultadoParaMostrar;
        private string codigoConsulta;
        private string idPlanilla;
        private string desde;
        private string hasta;
        private string idCodigoPersonal;
        private string idsubplanilla;

        public ImprimirIngresosSalidasPersonal()
        {
            InitializeComponent();
            Inicio();
            CargarMeses();
            CargarPlanillas();
            CargarSubPlanillas();
            ObtenerFechasIniciales();
        }

        private void ImprimirIngresosSalidasPersonal_Load(object sender, EventArgs e)
        {

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
            try
            {
                MesesNeg = new Mes();
                cboMes.DisplayMember = "descripcion";
                cboMes.ValueMember = "valor";
                //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
                cboMes.DataSource = MesesNeg.ListarMeses().ToList();
                cboMes.SelectedValue = DateTime.Now.ToString("MM");
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void CargarPlanillas()
        {
            try
            {
                planillaRRHHNegocio = new PlanillasRRHHNegocio();
                cboPlanilla.DisplayMember = "descripcion";
                cboPlanilla.ValueMember = "idplanilla";
                //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
                cboPlanilla.DataSource = planillaRRHHNegocio.ListadoPlanillasActivas(periodo).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }


        private void CargarSubPlanillas()
        {
            try
            {
                subplanillaRRHHNegocio = new SubPlanillasRRHH();
                cbSubPlanilla.DisplayMember = "descripcion";
                cbSubPlanilla.ValueMember = "idgrupoTrabajo";
                //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
                cbSubPlanilla.DataSource = subplanillaRRHHNegocio.ListadoSubPlanillasActivas(periodo).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }



        public void Inicio()
        {
            try
            {
                periodo = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "AGROINDUSTRIAL ESTANISLAO DEL CHIMU SAC";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "EAURAZOC";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
            }
            catch (Exception Ex)
            {
                throw Ex;
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

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                idPlanilla = this.cboPlanilla.SelectedValue.ToString().Trim();
                desde = this.txtFechaDesde.Text;
                hasta = this.txtFechaHasta.Text;
                idCodigoPersonal = this.txtPersonalOrigenCodigo.Text.Trim();
                idsubplanilla = this.cbSubPlanilla.SelectedValue.ToString();
                gbCodigoPersonal.Enabled = false;
                gbPeriodoReporte.Enabled = false;
                gbTipoPlanilla.Enabled = false;
                pogressBar.Visible = true;

                bgwHiloVistaPrevia.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                bgwHiloImprimir.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHiloImprimir_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgwHiloVistaPrevia_DoWork(object sender, DoWorkEventArgs e)
        {

            modelo = new IngresoSalidaPersonalNegocio();
            resultadoConsulta = new List<ST_RepoteMarcacionPersonal>();
            resultadoParaMostrar = new List<ST_RepoteMarcacionPersonalByCodigoPersonalListadoResult>();
            codigoConsulta = string.Empty;


            codigoConsulta = modelo.ObtenerCodigoUnicoDeConsulta(periodo);
            resultadoConsulta = modelo.ListadoMarcacionPersonalPuertaByPeriodo(periodo, codigoConsulta, idPlanilla, idsubplanilla, idCodigoPersonal, desde, hasta);

        }

        private void bgwHiloImprimir_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void bgwHiloVistaPrevia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (resultadoConsulta != null)
            {
                ImprimirIngresosSalidasPersonalVistaPrevia ofrm = new ImprimirIngresosSalidasPersonalVistaPrevia(codigoConsulta);
                ofrm.Show();
            }
            gbCodigoPersonal.Enabled = !false;
            gbPeriodoReporte.Enabled = !false;
            gbTipoPlanilla.Enabled = !false;
            pogressBar.Visible = !true;

        }


    }
}
