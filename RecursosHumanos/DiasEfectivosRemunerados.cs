using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Collections;
using System.Configuration;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;



namespace RecursosHumanos
{
    public partial class DiasEfectivosRemunerados : Form
    {
        string año, fechaIni, fechaFin, idplan = "";
        List<sj_GetHorasEfectivasRemuneradasResult> listado = new List<sj_GetHorasEfectivasRemuneradasResult>();
        DiasEfectivosNegocios diasEfectivosNegocios = new DiasEfectivosNegocios();

        public DiasEfectivosRemunerados()
        {
            InitializeComponent();
            this.ProgressBar.Visible = false;
            obtenerFechasIniciales();
            Inicio();
        }


        private void obtenerFechasIniciales()
        {
            this.txtFechaInicio.Text = "01" + DateTime.Now.ToString().Substring(3, 7);
            this.txtFechaFinal.Text = DateTime.Now.ToString();
        }


        public Boolean Validar()
        { 
            Boolean estado = false;
            string mensaje = string.Empty;

            if (txtPlanillaCodigo.Text == "")
            {
                estado = false ;
                mensaje += "Falta ingresar el tipo de planilla";
                this.txtPlanillaCodigo.Focus();
            }
            else
            {
                estado = true;
            }


            if (estado == true)
            {
                
            }
            else
            {
                MessageBox.Show(mensaje);
            }


            return estado;
        }

        public void Inicio()
        {
            try
            {
                año = this.txtFechaFinal.Text.ToString().Trim().Substring(6, 4);
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + año].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "CHRISTIAN";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Christian LLontop";
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void DiasEfectivosRemunerados_Load(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            listado = new List<sj_GetHorasEfectivasRemuneradasResult>();
            diasEfectivosNegocios = new DiasEfectivosNegocios();
            try
            {
                listado = diasEfectivosNegocios.GetListado(fechaIni, fechaFin, idplan).ToList();
            }
            catch (Exception Ex)
            {
                
                MessageBox.Show(Ex.Message);
            }
            
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ProgressBar.Visible = false;
            if (listado.ToList().Count > 0)
            {
                this.lblresultados.Text = "Se encontraron " + listado.ToList().Count + " registros";
                this.dgvResultado.CargarDatos(listado.ToDataTable<sj_GetHorasEfectivasRemuneradasResult>());
                this.dgvResultado.Refresh();
                this.gbCabecera.Enabled = true;
                //this.tsbBusqueda.Enabled = true;
            }
            else
            {
                this.dgvResultado.CargarDatos(listado.ToDataTable<sj_GetHorasEfectivasRemuneradasResult>());
                this.dgvResultado.Refresh();
                //this.tsbBusqueda.Enabled = false;
                this.lblresultados.Text = "No se encontraron registros";
                this.gbCabecera.Enabled = true;
                this.txtTextoBusqueda.Enabled = false;
                this.txtTextoBusqueda.Clear();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fechaIni = this.txtFechaInicio.Text.ToString().Trim();
            fechaFin = this.txtFechaFinal.Text.ToString().Trim();
            idplan = this.txtPlanillaCodigo.Text.ToString().Trim();

            if (Validar() == true)
            {
                gbCabecera.Enabled = false;
                this.ProgressBar.Visible = true;
                bgwHilo.RunWorkerAsync();
            }
            else
            {
                this.ProgressBar.Visible = false;
                gbCabecera.Enabled = true;
            }            
        }

        private void tsbBusqueda_Click(object sender, EventArgs e)
        {
            this.txtTextoBusqueda.Enabled = true;
            this.txtTextoBusqueda.Focus();
        }

        private void txtTextoBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatosTextBox();
        }

        private void FiltrarDatosTextBox()
        {
            if (this.txtTextoBusqueda.Text != "")
            {
                List<sj_GetHorasEfectivasRemuneradasResult> listaFiltrada = new List<sj_GetHorasEfectivasRemuneradasResult>();
                listaFiltrada = listado.Where(x => x.DNI.ToUpper().Contains(this.txtTextoBusqueda.Text.ToUpper().Trim())).ToList();
                this.dgvResultado.CargarDatos(listaFiltrada.ToDataTable<sj_GetHorasEfectivasRemuneradasResult>());
                this.dgvResultado.Refresh();
            }
            else
            {
                this.dgvResultado.CargarDatos(listado.ToDataTable<sj_GetHorasEfectivasRemuneradasResult>());
                this.dgvResultado.Refresh();
            }
        }

    }
}
