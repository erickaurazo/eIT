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
using System.Data.SqlClient;
using System.Configuration;
using Telerik.WinControls.Data;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ActualizarNombresColaboradorpostTrasnferencia : Form
    {
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        private string desde;
        private string hasta;


        public ActualizarNombresColaboradorpostTrasnferencia()
        {
            InitializeComponent();
            CargarMeses();
            ObtenerFechasIniciales();
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

        private void bgwProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SJM_PensionesNegocios modelo = new SJM_PensionesNegocios();
                modelo.ActualizarNombresColaboradorPostTransferencia(desde, hasta);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MessageBox.Show("Proceso generado correctamente", "MENSAJE DEL SISTEMA");
                gbProceso.Enabled = !false;
                ProgressBar.Visible = false;
            }
            catch (Exception Ex)
            {
                gbProceso.Enabled = !false;
                ProgressBar.Visible = false;
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ActualizarNombresColaboradorpostTrasnferencia_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizarNombres_Click(object sender, EventArgs e)
        {
            ActualizarNombres();
        }


        private void ActualizarNombres()
        {
            try
            {
                desde = this.txtFechaDesde.Text;
                hasta = this.txtFechaHasta.Text;
                if (desde != "" && hasta != "")
                {
                    if (IsDate(desde) == true && IsDate(hasta))
                    {
                        gbProceso.Enabled = false;
                        ProgressBar.Visible = !false;
                        bgwProceso.RunWorkerAsync();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private bool IsDate(string fecha)
        {
            /*DateTime dt;
            return DateTime.TryParse(fecha, out dt);*/

            bool esFecha = true;
            try
            {
                DateTime dt = DateTime.Parse(fecha);
            }
            catch
            {

                esFecha = false;
            }

            return esFecha;
        }

        private void txtSemana_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasSemanalesByNumeroSemana();
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

    }
}
