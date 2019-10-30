﻿using System;
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
    public partial class ActualizarPlaca : Form
    {
        private string periodo;
        private SJ_ListarAsistenciaSalidaUnidadesTransportePersonalByPeriodoResult registroResumen;
        private ASJ_RegistroTransferenciaTransportesNegocio negocio;
        private string placaNueva;
        private string codigoRuta;

        public ActualizarPlaca()
        {
            InitializeComponent();
            Inicio();
        }

        public ActualizarPlaca(string periodo, SJ_ListarAsistenciaSalidaUnidadesTransportePersonalByPeriodoResult registroResumen)
        {
            InitializeComponent();
            Inicio();
            this.periodo = periodo;
            this.registroResumen = registroResumen;
            this.txtFecha.Text = registroResumen.fecha;
            this.txtEmpresaTransporteRUC.Text = registroResumen.categoriaMovilidad != null ? registroResumen.categoriaMovilidad : string.Empty;
            this.txtEmpresaTransporte.Text = registroResumen.empresaTransporte != null ? registroResumen.empresaTransporte : string.Empty;
            this.txtPlaca.Text = registroResumen.placa != null ? registroResumen.placa : string.Empty;
            this.txtRuta.Text = registroResumen.ruta != null ? registroResumen.ruta : string.Empty;

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

        private void ActualizarPlaca_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            placaNueva = this.txtPlacaCodigoNuevo.Text.Trim();
            codigoRuta = this.txtRutaCodigo.Text.Trim();
            gbDestino.Enabled = false;
            gbRegistro.Enabled = false;

            bgwHilo.RunWorkerAsync();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            negocio = new ASJ_RegistroTransferenciaTransportesNegocio();
            negocio.ActualizarPlaca(periodo, registroResumen, placaNueva, codigoRuta);
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("ACTUALIZACION SATISFACTORIA", "MENSAJE DEL SISTEMA");
            gbDestino.Enabled = !false;
            gbRegistro.Enabled = !false;
            
        }
    }
}