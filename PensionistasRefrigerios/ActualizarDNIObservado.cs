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
using TransportistaMto.Negocios;


namespace Transportista
{
    public partial class ActualizarDNIObservado : Form
    {
        private string periodo;
        private string iDCONTROLINGRESO;
        private string iTEM;
        private string nombres;
        private string dni;

        public ControlIngresoSalidaPersonalNegocio AsistenciaModelo { get; private set; }

        public ActualizarDNIObservado()
        {
            InitializeComponent();
            Inicio();
        }



        public ActualizarDNIObservado(string periodo, string iDCONTROLINGRESO, string iTEM, string nombres, string dni) 
        {
            InitializeComponent();
            this.iDCONTROLINGRESO = iDCONTROLINGRESO;
            this.iTEM = iTEM;
            this.periodo = periodo;
            this.nombres = nombres;
            this.dni = dni;

            this.txtdniObservado.Text = this.dni;
            this.txtNombresObservador.Text = this.nombres;

            Inicio();
        }

        private void ActualizarDNIObservado_Load(object sender, EventArgs e)
        {

        }

        public void Inicio()
        {
            try
            {
                periodo = DateTime.Now.Year.ToString();
                Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodo].ToString();
                Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                Globales.IdEmpresa = "001";
                Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                Globales.UsuarioSistema = "EAURAZO";
                Globales.NombreUsuarioSistema = "ERICK AURAZO";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.iDCONTROLINGRESO != string.Empty && this.iTEM != string.Empty)
                {
                    if (this.txtDNI.Text.Trim() != string.Empty && this.txtNombres.Text.Trim() != string.Empty)
                    {
                        AsistenciaModelo = new ControlIngresoSalidaPersonalNegocio();
                        AsistenciaModelo.ActualizarDNIAsistenciaObservada(this.periodo, this.iDCONTROLINGRESO, this.iTEM, this.txtDNI.Text.Trim());
                        MessageBox.Show("Actualizado correctamente","MENSAJE DEL SISTEMA");
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
               
            }
         
        }
    }
}
