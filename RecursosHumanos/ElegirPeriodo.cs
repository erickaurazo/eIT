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

namespace RecursosHumanos
{
    public partial class ElegirPeriodo : Form
    {
        private MesNegocios MesesNeg;

        private string periodoSeleccionado = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0');
        private string codigoUnicoAccesoSistema;
        private string NombreUsuarioElegido;
        private string periodoPlanillaElegido;
        private string semanaElegido;
        private string CodigoPlanillaElegido;


        public ElegirPeriodo()
        {
            InitializeComponent();
            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();
        }

        public ElegirPeriodo(string codigoUnicoAccesoSistema)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.codigoUnicoAccesoSistema = codigoUnicoAccesoSistema;
            Program.ClaseCompartida.CodigoUnicoAccesoSistema = codigoUnicoAccesoSistema;
            
            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();
        }

        private void ElegirPeriodo_Load(object sender, EventArgs e)
        {

        }

        public void Inicio()
        {
            try
            {



                periodoSeleccionado = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0');
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + DateTime.Now.Year.ToString()].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "Exotics Producers Packers SAC";
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
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);
        }

        private void ObtenerFechasMes()
        {
            DateTime fecha1;
            DateTime fecha2;

            if (cboMes.SelectedValue.ToString() != "00")
            {
                #region

                if (cboMes.SelectedValue.ToString() == "12")
                {
                    #region Si es mes diciembre
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtAño.Value.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtAño.Value.ToString());// 

                    #endregion
                }
                else
                {
                    #region Si es mes 13 habilitar controles de fecha, caso contrario es un mes de enero a noviembre.
                    if (cboMes.SelectedValue.ToString() == "13")
                    {

                    }
                    else
                    {
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtAño.Value.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtAño.Value.ToString());// 

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


                }

            }
        }

        private void CargarMeses()
        {
            MesesNeg = new MesNegocios();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = MesesNeg.ListarDoceMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                periodoSeleccionado = this.txtAño.Value.ToString() + this.cboMes.SelectedValue.ToString();
               

                UsuarioMovimientoIngresoSistemaNegocio modelomovimientoDeUsuario = new UsuarioMovimientoIngresoSistemaNegocio();
                UsuarioMovimientoIngresoSistema movimientoDeUsuario = new UsuarioMovimientoIngresoSistema();
                movimientoDeUsuario.codigoAcceso = Program.ClaseCompartida.CodigoUnicoAccesoSistema;
                movimientoDeUsuario.periodoElegido = periodoSeleccionado;
                modelomovimientoDeUsuario.ActualizarPeriodo(movimientoDeUsuario, periodoSeleccionado);
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }


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
