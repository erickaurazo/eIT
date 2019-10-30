using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

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
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.Aggregates;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class HistorialAsistenciaPersonalRefrigerios : Form
    {
        private PersonalCampo personal;
        private List<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult> listadoHistorialAsistenciaTrabajador;
        private List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult> listadoRefrigeriosRecibidosxTrabajadorxDia;
        private SJM_PensionesNegocios Modelo;

        public HistorialAsistenciaPersonalRefrigerios()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public HistorialAsistenciaPersonalRefrigerios(PersonalCampo personal)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.personal = personal;
            PresentarDatos();
        }

        private void PresentarDatos()
        {
            this.txtRefigerio.Text = this.personal.refriferio.ToString().Trim().ToUpper();
            this.txtProveedor.Text = this.personal.pension.ToString().Trim().ToUpper();
            this.txtTrabajador.Text = this.personal.nroDNI.ToString().Trim() + " - " + this.personal.Nombres.ToString().Trim().ToUpper();
            this.txtFecha.Text = this.personal.fecha.Value.ToShortDateString();
            this.txtEstado.Text = this.txtEstado.Text.ToString().Trim();


            listadoHistorialAsistenciaTrabajador = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult>();
            listadoRefrigeriosRecibidosxTrabajadorxDia = new List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult>();

            Modelo = new SJM_PensionesNegocios();
            listadoHistorialAsistenciaTrabajador = Modelo.ObtnerListaHistorialRefrigerioxTrabajador(this.personal.fecha.ToPresentationDate(), "", personal.nroDNI).ToList();
            listadoRefrigeriosRecibidosxTrabajadorxDia = Modelo.ObtnerListaRefrigerioRecibidosxTrabajadorxDia(personal.nroDNI, this.personal.fecha.ToPresentationDate(), this.personal.fecha.ToPresentationDate()).ToList();

            dgvRefrigerioRecibido.DataSource = listadoRefrigeriosRecibidosxTrabajadorxDia.ToDataTable<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult>();
            dgvRefrigerioRecibido.Refresh();


            dgvPivotHistorialAsistencia.DataSource = listadoHistorialAsistenciaTrabajador.ToDataTable<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult>();
            Refresh();

            if (dgvPivotHistorialAsistencia.AggregateDescriptions.Count > 0)
            {
                this.dgvPivotHistorialAsistencia.AggregateDescriptions.RemoveAt(0);
            }
            else
            {
                this.dgvPivotHistorialAsistencia.AggregateDescriptions.Add(new PropertyAggregateDescription() { PropertyName = "Asistencia", AggregateFunction = AggregateFunctions.Count });
            }

        }

        private void HistorialAsistenciaPersonalRefrigerios_Load(object sender, EventArgs e)
        {

        }
    }
}
