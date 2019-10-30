using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using RecursosHumanos.Negocios;
using System.Configuration;
using DevSoftSolutionsControls;
using DevSoftSolutionsDataAccess;
using DevSoftSolutionsExtensions;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using System.Collections;
using MyControlsDataBinding.Controles;
using System.Data;
using System.Drawing;

namespace RecursosHumanos
{
    public partial class PeriodoPlanillaEdicion : Form
    {
        string codigoUnicoAccesoSistema;
        string codigoUsuario;

        public PeriodoPlanillaEdicion()
        {
            InitializeComponent();
        }

        public PeriodoPlanillaEdicion(string CodigoUnicoAccesoSistema, string CodigoUsuario)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.codigoUnicoAccesoSistema = CodigoUnicoAccesoSistema;
            this.codigoUsuario = CodigoUsuario;
            Inicio(); 
        }

        private void PeriodoPlanillaEdicion_Load(object sender, EventArgs e)
        {
            Inicio();
        }

        public void Inicio()
        {
            try
            {
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + Program.ClaseCompartida.periodoElegido.Substring(0, 4)].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EXOTIC'S PRODUCER PACKERS";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }


    }
}
