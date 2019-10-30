using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace Transportista
{
    public partial class PagoCajaSubirPlanilla : Form
    {
        public PagoCajaSubirPlanilla()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        private void cbtAsignarCajeros_Click(object sender, EventArgs e)
        {
            PagoCajaSubirPlanillaAsignarCajeros Ofrm = new PagoCajaSubirPlanillaAsignarCajeros();
            Ofrm.ShowDialog();
        }

        private void PagoCajaSubirPlanilla_Load(object sender, EventArgs e)
        {

        }
    }
}
