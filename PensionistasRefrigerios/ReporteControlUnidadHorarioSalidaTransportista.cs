using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using TransportistaMto.Datos;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using TransportistaMto.Negocios;

namespace Transportista
{
    public partial class ReporteControlUnidadHorarioSalidaTransportista : Form
    {
        private string fechaDesde;
        private string fechaHasta;
        private List<Garita> listadoPuertasDeGarita;
        private GaritaNegocio garitaNegocio;

        public ReporteControlUnidadHorarioSalidaTransportista()
        {
            InitializeComponent();
            CargarCombGaritas();
            this.txtFechaDesde.Text = DateTime.Now.ToShortDateString();
        }


        public void CargarCombGaritas()
        {
            listadoPuertasDeGarita = new List<Garita>();
            garitaNegocio = new GaritaNegocio();
            cboGarita.ValueMember = "codigo";
            cboGarita.DisplayMember = "descripcion";
            cboGarita.DataSource = garitaNegocio.Listado().ToList();
            cboGarita.SelectedValue = string.Empty;
        }


        private void ReporteControlUnidadHorarioSalidaTransportista_Load(object sender, EventArgs e)
        {

        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            fechaDesde = Convert.ToDateTime(this.txtFechaDesde.Text).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); ;
            fechaHasta = Convert.ToDateTime(this.txtFechaDesde.Text).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); ;

            ReporteControlUnidadHorarioSalidaTransportistaVistaPrevia ofrm = new ReporteControlUnidadHorarioSalidaTransportistaVistaPrevia(fechaDesde, fechaHasta);
            ofrm.AgregarParametroCadena("@Documento", "      "); /* nro Ruc */
            ofrm.AgregarParametroCadena("@nombreUsuario", Environment.UserName); /* Razon social */
            ofrm.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void gbCabecera_Click(object sender, EventArgs e)
        {

        }
    }
}
