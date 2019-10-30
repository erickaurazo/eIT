using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TransportistaMto.Datos;
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
using Telerik.WinControls.UI.Localization;

namespace Transportista
{
    public partial class FacturacionPensionesEdicion : Telerik.WinControls.UI.RadForm
    {
        public FacturacionPensionesEdicion()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        private void CargarMeses()
        {
            Mes Meses = new Mes();

            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = Meses.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = Meses.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void CargarTipoDocumentoVenta()
        {
            DocumentoNegocio Grupo = new DocumentoNegocio();

            cboIdDocumentoMovimiento.DisplayMember = "descripcion";
            cboIdDocumentoMovimiento.ValueMember = "valor";
            //cboMes.DataSource = Meses.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboIdDocumentoMovimiento.DataSource = Grupo.ObtenerIdDocumentoVentaProveedor().ToList();
            //cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void CargarSerieDocumentoVenta()
        {
            DocumentoNegocio Grupo = new DocumentoNegocio();

            cboSerieMovimiento.DisplayMember = "descripcion";
            cboSerieMovimiento.ValueMember = "valor";
            //cboMes.DataSource = Meses.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboSerieMovimiento.DataSource = Grupo.ObtenerSeriesDocumentoVentaProveedor().ToList();
            //cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void ObtenerFechasIniciales()
        {
            this.txtPeriodo.Value = DateTime.Now.Year;
            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            txtFechaDocumentoVenta.Text = DateTime.Now.ToShortDateString();
            this.txtNumeroDocumento.Text = "0000000";
            this.txtIdEstado.Text = "PE";
            this.txtEstado.Text = "Pendiente";
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
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtPeriodo.Value.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Value.ToString());// 
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FacturacionPensiones_Load(object sender, EventArgs e)
        {
            CargarMeses();
            ObtenerFechasIniciales();
            CargarTipoDocumentoVenta();
            CargarSerieDocumentoVenta();
        }

        private void txtPeriodo_Leave(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void btnBuscarPension_Click(object sender, EventArgs e)
        {
            BuscarPension oFrm = new BuscarPension();
            if (oFrm.ShowDialog() == DialogResult.OK)
            {
                if (oFrm.ObjetoBusquedaPension != null)
                {
                    try
                    {
                        // llenar los controles
                        this.txtIdPension.Text = oFrm.ObjetoBusquedaPension.IdPension.ToString();
                        this.txtRUCNumero.Text = oFrm.ObjetoBusquedaPension.NroRuc;
                        this.txtRucRazonSocial.Text = oFrm.ObjetoBusquedaPension.PseudoNombre.ToString().Trim();
                        txtNroDNIPension.Text = oFrm.ObjetoBusquedaPension.NroDNI.ToString().Trim();
                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                }
            }
        }

        private void txtNumeroDocumento_Leave(object sender, EventArgs e)
        {
            if (this.txtNumeroDocumento.Text.ToString().Trim().Length < 7)
            {

                switch (this.txtNumeroDocumento.Text.ToString().Trim().Length)
                {
                    case 6:
                        this.txtNumeroDocumento.Text = "0" + this.txtNumeroDocumento.Text.ToString().Trim();
                        break;
                    case 5:
                        this.txtNumeroDocumento.Text = "00" + this.txtNumeroDocumento.Text.ToString().Trim();
                        break;
                    case 4:
                        this.txtNumeroDocumento.Text = "000" + this.txtNumeroDocumento.Text.ToString().Trim();
                        break;
                    case 3:
                        this.txtNumeroDocumento.Text = "0000" + this.txtNumeroDocumento.Text.ToString().Trim();
                        break;
                    case 2:
                        this.txtNumeroDocumento.Text = "000000" + this.txtNumeroDocumento.Text.ToString().Trim();
                        break;
                    case 1:
                        this.txtNumeroDocumento.Text = "0000000" + this.txtNumeroDocumento.Text.ToString().Trim();
                        break;
                    case 0:
                        this.txtNumeroDocumento.Text = "00000000";
                        break;
                    default:
                        break;
                }
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void gbConsulta_Click(object sender, EventArgs e)
        {

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {

        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnProcesar_Click_1(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {

        }


    }
}
