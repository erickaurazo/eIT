using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class BuscarPersonal : Telerik.WinControls.UI.RadForm
    {
        private SJM_PensionesNegocios Negocios;
        private List<SJ_RHPensionRefrigerioBuscarPersonaResult> Listado;
        public SJ_RHPensionRefrigerioBuscarPersonaResult ObjetoBusquedaPersonal;

        public BuscarPersonal()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {

            this.dgvPersonalGeneral.TableElement.BeginUpdate();
            this.dgvPersonalGeneral.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvPersonalGeneral.TableElement.EndUpdate();



            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvPersonalGeneral.MasterTemplate.AutoExpandGroups = true;
            this.dgvPersonalGeneral.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonalGeneral.GroupDescriptors.Clear();
            this.dgvPersonalGeneral.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chNombresTrabajador", "Registros: {0:N0}; ", GridAggregateFunction.Count));
            //this.dgvPersonalGeneral.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvPersonalGeneral.MasterTemplate.SummaryRowsTop.Add(item);
        }

        private void PersonalBuscar_Load(object sender, EventArgs e)
        {
            ObtenerLista();
        }

        private void ObtenerLista()
        {
            try
            {
                Negocios = new SJM_PensionesNegocios();
                Listado = new List<SJ_RHPensionRefrigerioBuscarPersonaResult>();
                Listado = Negocios.ObtenerListaPersonalNuevo();
                MostrarLista();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void MostrarLista()
        {
            this.dgvPersonalGeneral.DataSource = Listado.ToDataTable<SJ_RHPensionRefrigerioBuscarPersonaResult>();
            this.dgvPersonalGeneral.Refresh();
            this.dgvPersonalGeneral.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarObjetoBuscarPersonal()
        {
            try
            {
                ObjetoBusquedaPersonal = new SJ_RHPensionRefrigerioBuscarPersonaResult();
                ObjetoBusquedaPersonal.IdCodigoPersonal = "";
                ObjetoBusquedaPersonal.NRODocumento = "";
                ObjetoBusquedaPersonal.NombresTrabajador = "";
                ObjetoBusquedaPersonal.IdSubPlanilla = "";
                ObjetoBusquedaPersonal.SubPlanilla = "";
                ObjetoBusquedaPersonal.Condicion = "";
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void dgvPersonalGeneral_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarObjetoBuscarPersonal();
            if (dgvPersonalGeneral.Rows.Count > 0)
            {
                #region
                if (dgvPersonalGeneral.CurrentRow != null)
                {
                    try
                    {
                        if (dgvPersonalGeneral.CurrentRow.Cells["chIdCodigoPersonal"].Value != null)
                        {
                            if (dgvPersonalGeneral.CurrentRow.Cells["chIdCodigoPersonal"].Value.ToString().Trim() != "")
                            {
                                ObjetoBusquedaPersonal = new SJ_RHPensionRefrigerioBuscarPersonaResult();
                                ObjetoBusquedaPersonal.IdCodigoPersonal = Convert.ToString(dgvPersonalGeneral.CurrentRow.Cells["chIdCodigoPersonal"].Value.ToString().Trim());
                                ObjetoBusquedaPersonal.NRODocumento = dgvPersonalGeneral.CurrentRow.Cells["chNRODocumento"].Value.ToString().Trim();
                                ObjetoBusquedaPersonal.NombresTrabajador = dgvPersonalGeneral.CurrentRow.Cells["chNombresTrabajador"].Value.ToString().Trim();
                                ObjetoBusquedaPersonal.IdSubPlanilla = dgvPersonalGeneral.CurrentRow.Cells["chIdSubPlanilla"].Value.ToString().Trim();
                                ObjetoBusquedaPersonal.SubPlanilla = dgvPersonalGeneral.CurrentRow.Cells["chSubPlanilla"].Value.ToString().Trim();
                                ObjetoBusquedaPersonal.Condicion = dgvPersonalGeneral.CurrentRow.Cells["chCondicion"].Value.ToString().Trim();
                            }
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
    }
}
