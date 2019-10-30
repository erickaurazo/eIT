using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
using Transportista.Negocios;

namespace Transportista
{
    public partial class ConsolidadoAsistenciasRefrigerioProcesadas : Form
    {
        private DateTime FechaInicio;
        private DateTime FechaTermino;
        private Mes MesesNeg;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemanaConsulta;
        private SJ_Semana oSemana;

        public ConsolidadoAsistenciasRefrigerioProcesadas()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            CargarMeses();
            ObtenerFechasIniciales();
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

        private void btnGenerarFacturacion_Click(object sender, EventArgs e)
        {

            if (txtDNIProveedor.Text.ToString().Trim() != "")
            {
                FacturacionPensionesEdicion oFrm = new FacturacionPensionesEdicion();
                oFrm.Show();
            }


        }

        private void ConsolidadoAsistenciasRefrigerioProcesadas_Load(object sender, EventArgs e)
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
    }
}
