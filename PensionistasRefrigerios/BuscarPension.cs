using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Collections;
using TransportistaMto.Datos;
using Transportista.Negocios;

using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class BuscarPension : Telerik.WinControls.UI.RadForm
    {
        private SJ_RHPensionNegocio pensionNeg;
        private List<SJ_RHPensionListaResult> ListadoPension;
        public SJ_RHPensionListaResult ObjetoBusquedaPension;
        public BuscarPension()
        {
            InitializeComponent();

            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        private void PensionBuscar_Load(object sender, EventArgs e)
        {
            ObtenerListaPensiones();
        }

        private void ObtenerListaPensiones()
        {
            try
            {
                pensionNeg = new SJ_RHPensionNegocio();
                ListadoPension = new List<SJ_RHPensionListaResult>();
                ListadoPension = pensionNeg.ListadoPensiones().Where(x => x.IdEstado.ToString().Trim().ToUpper() != "AN").ToList().OrderBy(x => x.PseudoNombre).ToList();
                MostrarListaPensiones();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void MostrarListaPensiones()
        {
            this.dgvPension.DataSource = ListadoPension.ToDataTable<SJ_RHPensionListaResult>();
            this.dgvPension.Refresh();
            this.dgvPension.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvPension_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarObjetoBusqueda();
            if (dgvPension != null && dgvPension.Rows.Count > 0)
            {
                #region
                if (dgvPension.CurrentRow != null && dgvPension.CurrentRow.Cells["chIdPension"].Value != null)
                {
                    try
                    {
                        if (dgvPension.CurrentRow.Cells["chIdPension"].Value.ToString() != "")
                        {
                            #region Obtener Objeto de busqueda()
                            ObjetoBusquedaPension = new SJ_RHPensionListaResult();
                            ObjetoBusquedaPension.IdPension = Convert.ToInt32(dgvPension.CurrentRow.Cells["chIdPension"].Value.ToString().Trim());
                            ObjetoBusquedaPension.Estado = dgvPension.CurrentRow.Cells["chEstado"].Value.ToString().Trim();
                            ObjetoBusquedaPension.IdEstado = dgvPension.CurrentRow.Cells["chIdEstado"].Value.ToString().Trim();
                            ObjetoBusquedaPension.PseudoNombre = dgvPension.CurrentRow.Cells["chPseudoNombre"].Value.ToString().Trim();
                            ObjetoBusquedaPension.NroRuc = dgvPension.CurrentRow.Cells["chNroRuc"].Value.ToString().Trim();
                            ObjetoBusquedaPension.RazonSocial = dgvPension.CurrentRow.Cells["chRazonSocial"].Value.ToString().Trim();
                            ObjetoBusquedaPension.NroDNI = dgvPension.CurrentRow.Cells["chNroDNI"].Value.ToString().Trim();
                            ObjetoBusquedaPension.NombresCompletos = dgvPension.CurrentRow.Cells["chNombresCompletos"].Value.ToString().Trim();
                            #endregion
                        }
                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                }
                #endregion
            }
        }

        private void LimpiarObjetoBusqueda()
        {
            ObjetoBusquedaPension = new SJ_RHPensionListaResult();
            ObjetoBusquedaPension.IdPension = Convert.ToInt32(0);
            ObjetoBusquedaPension.Estado = "";
            ObjetoBusquedaPension.IdEstado = "PE";
            ObjetoBusquedaPension.PseudoNombre = "";
            ObjetoBusquedaPension.NroRuc = "";
            ObjetoBusquedaPension.RazonSocial = "";
            ObjetoBusquedaPension.NroDNI = "";
            ObjetoBusquedaPension.NombresCompletos = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
