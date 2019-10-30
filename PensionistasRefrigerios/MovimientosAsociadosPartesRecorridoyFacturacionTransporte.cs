using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
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
using Transportista.Negocios;

using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class MovimientosAsociadosPartesRecorridoyFacturacionTransporte : Form
    {
        private SJ_RHListarCatalogoEmpresasTransportePersonalCampoResult oDatosUnidadTransporte;
        private List<MovimientoTransporte> listadoMovimientoByIdTrasportista;
        private TransportistaNegocio modelo;

        public MovimientosAsociadosPartesRecorridoyFacturacionTransporte()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public MovimientosAsociadosPartesRecorridoyFacturacionTransporte(SJ_RHListarCatalogoEmpresasTransportePersonalCampoResult oDatosUnidadTransporte)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.oDatosUnidadTransporte = oDatosUnidadTransporte;
            gbDatosUnidadTransporte.Enabled = false;
            gbDetalleMovimiento.Enabled = false;
            //progressBar.Visible = true;

            if (this.oDatosUnidadTransporte != null && this.oDatosUnidadTransporte.Id != null)
            {
                gbDatosUnidadTransporte.Enabled = false;
                gbDetalleMovimiento.Enabled = false;
                progressBar.Visible = true;
                bgwHilo.RunWorkerAsync();
            }
        }

        private void MovimientosAsociadosPartesRecorridoyFacturacionTransporte_Load(object sender, EventArgs e)
        {


        }


        protected override void OnLoad(EventArgs e)
        {
            this.dgvDetalleMovimiento.TableElement.BeginUpdate();
            //this.dgvRecorridos.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvDetalleMovimiento.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvDetalleMovimiento.MasterTemplate.AutoExpandGroups = true;
            this.dgvDetalleMovimiento.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleMovimiento.GroupDescriptors.Clear();
            this.dgvDetalleMovimiento.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chDocumentoMovimiento", "# Reg: {0:N0}; ", GridAggregateFunction.Count));
            item.Add(new GridViewSummaryItem("chvalorVenta", "Sum: {0:N2}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chigv", "Sum: {0:N2}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chimportePagar", "Sum: {0:N2}; ", GridAggregateFunction.Sum));
            //this.dgvRefrigerios.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvDetalleMovimiento.MasterTemplate.SummaryRowsTop.Add(item);
        }


        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                listadoMovimientoByIdTrasportista = new List<MovimientoTransporte>();
                modelo = new TransportistaNegocio();
                listadoMovimientoByIdTrasportista = modelo.ObtenerListadoMovimientoByIdTrasportista(this.oDatosUnidadTransporte);

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {


                this.txtCodigo.Text = this.oDatosUnidadTransporte.Id != null ? this.oDatosUnidadTransporte.Id.ToString().PadLeft(7,'0') : "";
                this.txtEstado.Text = this.oDatosUnidadTransporte.Estado != null ? this.oDatosUnidadTransporte.Estado.ToString() : "";
                this.txtRUCNumero.Text = this.oDatosUnidadTransporte.RUC != null ? this.oDatosUnidadTransporte.RUC.ToString() : "";
                this.txtRucDescripcion.Text = this.oDatosUnidadTransporte.RazonSocial != null ? this.oDatosUnidadTransporte.RazonSocial.ToString() : "";
                this.txtNombreComercial.Text = this.oDatosUnidadTransporte.PseudoNombre != null ? this.oDatosUnidadTransporte.PseudoNombre.ToString() : "";
                this.txtNumeroPlaca.Text = this.oDatosUnidadTransporte.Placa.ToString();

                dgvDetalleMovimiento.DataSource = listadoMovimientoByIdTrasportista.ToDataTable<MovimientoTransporte>();
                dgvDetalleMovimiento.Refresh();
                gbDatosUnidadTransporte.Enabled = true;
                gbDetalleMovimiento.Enabled = true;
                progressBar.Visible = false;

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void dgvDetalleMovimiento_SelectionChanged(object sender, EventArgs e)
        {
            SumarElementosSeleccionadosGrilla(sender);
        }


        public void SumarElementosSeleccionadosGrilla(object senderGrilla)
        {
            try
            {
                if (((RadGridView)senderGrilla).CurrentRow != null && ((RadGridView)senderGrilla).CurrentCell != null)
                {
                    int fila = ((RadGridView)senderGrilla).CurrentRow.Index;
                    int columna = ((RadGridView)senderGrilla).CurrentCell.ColumnIndex;

                    decimal SumaSeleccionada = 0;
                    decimal promedioSeleccionado = 0;
                    int recuento = 0;

                    //foreach (DataGridViewCell celda in ((DataGridView)senderGrilla).SelectedCells)
                    foreach (GridViewCellInfo celda in ((RadGridView)senderGrilla).SelectedCells)
                    {
                        if (celda.Value != null)
                        {
                            string tipoDato = celda.Value.GetType().Name.ToString();
                            if (tipoDato != null && tipoDato != string.Empty)
                            {
                                #region
                                if (tipoDato == "Double" || tipoDato == "Decimal" || tipoDato == "Int" || tipoDato == "Integer" || tipoDato == "Int32")
                                {
                                    SumaSeleccionada += Convert.ToDecimal(celda.Value != null ? celda.Value : 0);
                                    if (Convert.ToDecimal(celda.Value != null ? celda.Value : 0) == 0)
                                    {

                                    }
                                    else
                                    {
                                        recuento++;
                                        promedioSeleccionado = (SumaSeleccionada / recuento);
                                    }

                                }
                                else
                                {
                                    SumaSeleccionada = 0;
                                    recuento = 0;
                                    promedioSeleccionado = 0;
                                    break;
                                }
                                #endregion
                            }
                            else
                            {
                                #region
                                SumaSeleccionada = 0;
                                recuento = 0;
                                promedioSeleccionado = 0;
                                break;
                                #endregion
                            }
                            this.lblSumaSeleccionada.Text = SumaSeleccionada.ToDecimalPresentation();
                            this.lblRecuento.Text = recuento.ToString();

                            this.lblPromedio.Text = promedioSeleccionado.ToDecimalPresentation();
                        }


                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



    }
}
