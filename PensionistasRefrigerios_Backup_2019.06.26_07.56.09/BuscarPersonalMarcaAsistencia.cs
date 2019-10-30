using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Configuration;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using System.Globalization;
using Transportista.Negocios;
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class BuscarPersonalMarcaAsistencia : Form
    {
        public PersonalAdministrativo ObjetoBusqueda;
        private List<PersonalAdministrativo> personalRegistradoParaMarcarAsistencia;
        public BuscarPersonalMarcaAsistencia()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public BuscarPersonalMarcaAsistencia(List<PersonalAdministrativo> personalRegistradoParaMarcarAsistencia)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.personalRegistradoParaMarcarAsistencia = personalRegistradoParaMarcarAsistencia;
            this.dgvRegistros.DataSource = this.personalRegistradoParaMarcarAsistencia.ToDataTable<PersonalAdministrativo>();
            this.dgvRegistros.Refresh();
        }

        private void dgvRegistros_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarObjetoBusqueda();
            if (this.dgvRegistros != null && dgvRegistros.Rows.Count > 0)
            {
                #region
                if (dgvRegistros.CurrentRow != null && dgvRegistros.CurrentRow.Cells["chcodigoMarcacion"].Value != null)
                {
                    try
                    {
                        if (dgvRegistros.CurrentRow.Cells["chcodigoMarcacion"].Value.ToString() != "")
                        {
                            #region Obtener Objeto de busqueda()
                            ObjetoBusqueda = new PersonalAdministrativo();
                            ObjetoBusqueda.codigoPersonal = (dgvRegistros.CurrentRow.Cells["chcodigoMarcacion"].Value.ToString().Trim());
                            ObjetoBusqueda.personal = dgvRegistros.CurrentRow.Cells["chNombres"].Value.ToString().Trim();
                            ObjetoBusqueda.nroDocumento = dgvRegistros.CurrentRow.Cells["chnroDocumento"].Value.ToString().Trim();
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
            ObjetoBusqueda = new PersonalAdministrativo();
            ObjetoBusqueda.codigoPersonal = string.Empty;
            ObjetoBusqueda.personal = string.Empty;
            ObjetoBusqueda.nroDocumento = string.Empty;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void BuscarPersonalMarcaAsistencia_Load(object sender, EventArgs e)
        {

        }






    }
}
