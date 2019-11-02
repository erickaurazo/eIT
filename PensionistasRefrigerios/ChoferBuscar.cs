using System;
using System.Collections.Generic;
using Telerik.WinControls;
using MyControlsDataBinding.Extensions;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using Asistencia.Negocios;
using Asistencia.Datos;


namespace Asistencia
{
    public partial class ChoferBuscar : Telerik.WinControls.UI.RadForm
    {
        private string rucTransportista;
        private string periodo;
        private CarrierController Negocios;
        private List<SJ_RHTransportistaChoferListarResult> Choferes;
        public SJ_RHTransportistaChoferListarResult Chofer;

        public ChoferBuscar()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Asistencia.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();


        }

        public ChoferBuscar(string rucTransportista, string periodo)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.rucTransportista = rucTransportista;
            this.periodo = periodo;
        }

        private void ChoferBuscar_Load(object sender, EventArgs e)
        {
            ObtenerLista();
        }

        private void ObtenerLista()
        {
            if (rucTransportista != null)
            {
                if (rucTransportista != "")
                {
                    if (this.periodo != "")
                    {
                        Negocios = new CarrierController();
                        Choferes = new List<SJ_RHTransportistaChoferListarResult>();

                        Choferes = Negocios.ObtenerListaChoferesxTransportista(rucTransportista, this.periodo).ToList();

                        this.dgvChofer.DataSource = Choferes.ToDataTable<SJ_RHTransportistaChoferListarResult>();
                        this.dgvChofer.Refresh();
                        this.dgvChofer.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
        }

        private void dgvChofer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvChofer != null)
                {
                    #region
                    if (dgvChofer.CurrentRow != null)
                    {

                        if (dgvChofer.CurrentRow.Cells["chId"].Value != null)
                        {
                            Chofer = new SJ_RHTransportistaChoferListarResult();
                            Chofer.Id = dgvChofer.CurrentRow.Cells["chId"].Value != null ? Convert.ToInt32(dgvChofer.CurrentRow.Cells["chId"].Value) : 0;
                            Chofer.DNI = dgvChofer.CurrentRow.Cells["chDNI"].Value != null ? Convert.ToString(dgvChofer.CurrentRow.Cells["chDNI"].Value) : "";
                            Chofer.Nombres = dgvChofer.CurrentRow.Cells["chNombres"].Value != null ? Convert.ToString(dgvChofer.CurrentRow.Cells["chNombres"].Value) : "";
                            Chofer.TipoLicencia = dgvChofer.CurrentRow.Cells["chTipoLicencia"].Value != null ? Convert.ToString(dgvChofer.CurrentRow.Cells["chTipoLicencia"].Value) : "";
                            Chofer.IdTransportista = dgvChofer.CurrentRow.Cells["chIdTransportista"].Value != null ? Convert.ToInt32(dgvChofer.CurrentRow.Cells["chIdTransportista"].Value) : 0;
                        }
                        else
                        {
                            Chofer = new SJ_RHTransportistaChoferListarResult();
                            Chofer.Id = 0;
                            Chofer.DNI = "";
                            Chofer.Nombres = "";
                            Chofer.TipoLicencia = "";
                            Chofer.IdTransportista = 0;
                        }
                    }
                    else
                    {
                        Chofer = new SJ_RHTransportistaChoferListarResult();
                        Chofer.Id = 0;
                        Chofer.DNI = "";
                        Chofer.Nombres = "";
                        Chofer.TipoLicencia = "";
                        Chofer.IdTransportista = 0;
                    }
                    #endregion
                }
                else
                {
                    Chofer = new SJ_RHTransportistaChoferListarResult();
                    Chofer.Id = 0;
                    Chofer.DNI = "";
                    Chofer.Nombres = "";
                    Chofer.TipoLicencia = "";
                    Chofer.IdTransportista = 0;
                }
            }
            catch (Exception Ex)
            {
                
                throw Ex;
            }
           
        }
    }
}
