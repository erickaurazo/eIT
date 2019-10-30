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
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class DistribucionConsumoRefrigeriosxPensionxPeriodo : Form
    {
        private string periodo;
        private string año;
        private string mesDelAño;
        private string semanaDelAño;
        private string fechaDesde;
        private string fechaHasta;
        private string codigoProveedor;
        private string descripcionProveedor;
        private List<SJ_RHDistribucionFacturacion> listadoDistribucionMovimientoFacturacionPensiones;
        private List<SJ_RHDistribucionFacturacion> listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidor;
        private List<SJ_RHDistribucionFacturacion> listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidorxRefrigerio;
        private string subPlanilla;

        public DistribucionConsumoRefrigeriosxPensionxPeriodo()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            PivotGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.PivotGridLocalizationProviderEspanol();
        }

        public DistribucionConsumoRefrigeriosxPensionxPeriodo(string periodo, string año, string mesDelAño, string semanaDelAño, string fechaDesde, string fechaHasta, string codigoProveedor, string descripcionProveedor, List<SJ_RHDistribucionFacturacion> listadoDistribucionMovimientoFacturacionPensiones, string subPlanilla)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.periodo = periodo;
            this.año = año;
            this.mesDelAño = mesDelAño;
            this.semanaDelAño = semanaDelAño;
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.codigoProveedor = codigoProveedor;
            this.descripcionProveedor = descripcionProveedor;
            this.listadoDistribucionMovimientoFacturacionPensiones = listadoDistribucionMovimientoFacturacionPensiones;
            this.subPlanilla = subPlanilla;

            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            PivotGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.PivotGridLocalizationProviderEspanol();

            EnlazarDatosFormularioAnteriorAControles();
        }

        private void EnlazarDatosFormularioAnteriorAControles()
        {
            try
            {
                this.txtDNIProveedor.Text = this.codigoProveedor;
                this.txtSemana.Text = this.semanaDelAño;
                this.txtFechaDesde.Text = this.fechaDesde;
                this.txtFechaHasta.Text = this.fechaHasta;
                this.txtRazonSocialProveedor.Text = this.descripcionProveedor;
                this.txtSemana.Text = this.semanaDelAño;
                this.txtSubPlanilla.Text = this.subPlanilla;
                this.txtPeriodo.Text = this.año;
                this.cboMes.Text = this.mesDelAño;
                listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidor = new List<SJ_RHDistribucionFacturacion>();

                #region Agrupar lista por Consumidor()

                if (this.listadoDistribucionMovimientoFacturacionPensiones != null && this.listadoDistribucionMovimientoFacturacionPensiones.ToList().Count > 0)
                {
                    /* Obtengo listado de consumidores afectados en la distribucion */
                    var listaConsumidores = (from consumidor in this.listadoDistribucionMovimientoFacturacionPensiones
                                             where consumidor.idConsumidor != null && consumidor.idConsumidor.Trim() != ""
                                             group consumidor by new { consumidor.idConsumidor } into j
                                             select new
                                             {
                                                 codigoConsumidor = j.Key.idConsumidor.ToString().Trim(),
                                                 consumidor = j.FirstOrDefault().consumidor.ToString().Trim().ToUpper(),
                                             }).ToList();

                    foreach (var itemConsumidor in listaConsumidores)
                    {
                        var listaAgrupadaporConsumidor = listadoDistribucionMovimientoFacturacionPensiones.Where(x => x.idConsumidor == itemConsumidor.codigoConsumidor).ToList();
                        if (listaAgrupadaporConsumidor != null && listaAgrupadaporConsumidor.ToList().Count > 0)
                        {
                            decimal? CostoDistribuidoAgrupadoxConsumidor = listaAgrupadaporConsumidor.Sum(x => x.costoDistribuido != (decimal?)null ? x.costoDistribuido : 0);
                            listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidor.Add(new SJ_RHDistribucionFacturacion { idConsumidor = itemConsumidor.codigoConsumidor, consumidor = itemConsumidor.consumidor, costoDistribuido = CostoDistribuidoAgrupadoxConsumidor });
                        }
                    }
                }

                dgvCostosAgrupadosxConsumidor.DataSource = listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidor.ToDataTable<SJ_RHDistribucionFacturacion>();
                dgvCostosAgrupadosxConsumidor.Refresh();


                #endregion

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DistribucionConsumoRefrigeriosxPensionxPeriodo_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.dgvDistribucionxRefrigerios.TableElement.BeginUpdate();
                LoadFreightSummaryAgrupado();
                this.dgvDistribucionxRefrigerios.TableElement.EndUpdate();
                base.OnLoad(e);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void LoadFreightSummaryAgrupado()
        {
            try
            {
                this.dgvCostosAgrupadosxConsumidor.GroupDescriptors.Clear();
                //this.dgvCostosAgrupadosxConsumidor.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
                GridViewSummaryRowItem item = new GridViewSummaryRowItem();
                item.Add(new GridViewSummaryItem("chcostoDistribuidoTotalizado", " Sum, : {0:c} ", GridAggregateFunction.Sum));
                this.dgvCostosAgrupadosxConsumidor.MasterTemplate.SummaryRowsTop.Add(item);
                this.dgvDistribucionxRefrigerios.GroupDescriptors.Clear();
                this.dgvDistribucionxRefrigerios.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
                GridViewSummaryRowItem itemsxRefrigerios = new GridViewSummaryRowItem();
                itemsxRefrigerios.Add(new GridViewSummaryItem("chcostoDistribuidoxRefrigeriosxRefrigerio", " Sum, : {0:c} ", GridAggregateFunction.Sum));
                this.dgvDistribucionxRefrigerios.MasterTemplate.SummaryRowsTop.Add(itemsxRefrigerios);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void dgvDistribucionSubPlanillaIca_SelectionChanged(object sender, EventArgs e)
        {
            listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidorxRefrigerio = new List<SJ_RHDistribucionFacturacion>();
            try
            {
                #region
                if (dgvCostosAgrupadosxConsumidor != null && dgvCostosAgrupadosxConsumidor.Rows.Count > 0)
                {
                    if (listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidor != null && listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidor.ToList().Count > 0)
                    {
                        if (dgvCostosAgrupadosxConsumidor.CurrentRow.Cells["chidConsumidorTotalizado"].Value != null && dgvCostosAgrupadosxConsumidor.CurrentRow.Cells["chidConsumidorTotalizado"].Value.ToString().Trim() != "")
                        {
                            string idConsumidorGrillaTotalizada = (dgvCostosAgrupadosxConsumidor.CurrentRow.Cells["chidConsumidorTotalizado"].Value != null ? dgvCostosAgrupadosxConsumidor.CurrentRow.Cells["chidConsumidorTotalizado"].Value.ToString() : "");
                            string ConsumidorGrillaTotalizada = (dgvCostosAgrupadosxConsumidor.CurrentRow.Cells["chConsumidorTotalizado"].Value != null ? dgvCostosAgrupadosxConsumidor.CurrentRow.Cells["chConsumidorTotalizado"].Value.ToString() : "");

                            var listadoDesayunos = listadoDistribucionMovimientoFacturacionPensiones.Where(x => x.glosa.Contains("DESAYUNO")).ToList();
                            var listadoAlmuerzos = listadoDistribucionMovimientoFacturacionPensiones.Where(x => x.glosa.Contains("ALMUERZO")).ToList();
                            var listadoCenas = listadoDistribucionMovimientoFacturacionPensiones.Where(x => x.glosa.Contains("CENA")).ToList();

                            if (listadoDesayunos != null && listadoDesayunos.ToList().Count > 0)
                            {
                                decimal? CostoDistribuidoAgrupadoxConsumidorxRefrigerio = listadoDesayunos.Sum(x => x.costoDistribuido != (decimal?)null ? x.costoDistribuido : 0);
                                listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidorxRefrigerio.Add(new SJ_RHDistribucionFacturacion { idConsumidor = idConsumidorGrillaTotalizada, consumidor = ConsumidorGrillaTotalizada, costoDistribuido = CostoDistribuidoAgrupadoxConsumidorxRefrigerio, glosa = "Total de importes por Desayunos" });
                            }

                            if (listadoAlmuerzos != null && listadoAlmuerzos.ToList().Count > 0)
                            {
                                decimal? CostoDistribuidoAgrupadoxConsumidorxRefrigerio = listadoAlmuerzos.Sum(x => x.costoDistribuido != (decimal?)null ? x.costoDistribuido : 0);
                                listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidorxRefrigerio.Add(new SJ_RHDistribucionFacturacion { idConsumidor = idConsumidorGrillaTotalizada, consumidor = ConsumidorGrillaTotalizada, costoDistribuido = CostoDistribuidoAgrupadoxConsumidorxRefrigerio, glosa = "Total de importes por Almuerzos" });
                            }

                            if (listadoCenas != null && listadoCenas.ToList().Count > 0)
                            {
                                decimal? CostoDistribuidoAgrupadoxConsumidorxRefrigerio = listadoCenas.Sum(x => x.costoDistribuido != (decimal?)null ? x.costoDistribuido : 0);
                                listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidorxRefrigerio.Add(new SJ_RHDistribucionFacturacion { idConsumidor = idConsumidorGrillaTotalizada, consumidor = ConsumidorGrillaTotalizada, costoDistribuido = CostoDistribuidoAgrupadoxConsumidorxRefrigerio, glosa = "Total de importes por Cenas" });
                            }

                        }
                    }
                }
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }

            dgvDistribucionxRefrigerios.DataSource = listadoDistribucionMovimientoFacturacionPensionesAgrupadoxConsumidorxRefrigerio.ToDataTable<SJ_RHDistribucionFacturacion>();
            dgvDistribucionxRefrigerios.Refresh();


        }

        private void dgvDistribucionxRefrigerios_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

    }
}
