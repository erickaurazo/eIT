using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Diagnostics;
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI;

namespace Transportista
{
    public partial class MonitoreoMovimientoPension : Telerik.WinControls.UI.RadForm
    {
        public MonitoreoMovimientoPension()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarMovimientoPension();
            btnActualizar.Enabled = false;
            btnSalir.Enabled = false;
            timer1.Start();
        }

        private void ActualizarMovimientoPension()
        {
            try
            {

                var watch = Stopwatch.StartNew();
                var elapsedMs = watch.ElapsedMilliseconds;
                this.lblTiempoTranscurrido.Text = elapsedMs.ToString();
                watch.Stop();

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
        }

        private void MonitoreoMovimientoPension_Load(object sender, EventArgs e)
        {

        }
    }
}
