using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Configuration;
using Transportista.Negocios;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;

using Telerik.WinControls.UI;
//using System.Collections;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Data.OleDb;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class MovimientoRecorridosDistribucionPasajerosByParaderos : Form
    {
        private oMovilidad movilidad;
        private MovimientoMovilidadNegocio modelo;
        private List<Paradero> listadoParaderoActivos;
        private List<Paradero> listadoDistribucionPasajerosPorParadero;
        private List<Paradero> ObtenerListadoPresentacion;
        private List<Paradero> listaParaderosGenerar;
        private string codigoMovimientoRecorrido;
        private List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult> ListaPasajerosByParaderoByMovimiento;

        public MovimientoRecorridosDistribucionPasajerosByParaderos()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public MovimientoRecorridosDistribucionPasajerosByParaderos(oMovilidad movilidad)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.movilidad = movilidad;

            txtCodigoExterno.Text = this.movilidad.codigoMovimiento;
            txtPlacaInterLocalidad.Text = this.movilidad.placa;
            txtPseudonombreInterlocalidad.Text = this.movilidad.pseudonombre;
            txtRUCInterlocalidad.Text = this.movilidad.nroRUC;
            txtRazonSocialInterlocalidad.Text = this.movilidad.razonSocial;
            txtTipoMovilidadInterLocalidad.Text = this.movilidad.tipoMovilidad;
            txtChofeDNIRecorridoInterlocalidad.Text = this.movilidad.choferDNI;
            txtChoferNombresRecorridoInterLocalidad.Text = this.movilidad.chofer;
            txtNroAsientosInterlocalidad.Text = this.movilidad.numeroAsientos.ToString("N0");
            txtNumeroPersonasInterlocalidad.Text = movilidad.numeroPasajeros.ToString("N0");

            if (this.movilidad.esIdaVuelta == 1)
            {
                rbtIdaVuelta.IsChecked = true;
            }
            else
            {
                rbtIdaVuelta.IsChecked = false;
            }


            if (this.movilidad.esIda == 1)
            {
                rbtRecorridoOrigen.IsChecked = true;
            }
            else
            {
                rbtRecorridoOrigen.IsChecked = false;
            }

            if (this.movilidad.esVuelta == 1)
            {
                rbtRecorridoDestino.IsChecked = true;
            }
            else
            {
                rbtRecorridoDestino.IsChecked = false;
            }
            txtRutaOrigen.Text = this.movilidad.rutaOrigen;
            txtRutaDestino.Text = this.movilidad.rutaDestino;


            ObtenerListadoParaderos();
        }

        private void MovimientoRecorridosDistribucionParaderos_Load(object sender, EventArgs e)
        {

        }


        public void ObtenerListadoParaderos()
        {

            gbTransportistaInformacion.Enabled = false;
            gbRegistroMovimientoExterno.Enabled = false;
            gbProcedenciaExterno.Enabled = false;
            txtNumeroPersonasInterlocalidad.Enabled = false;
            btnGenerarDistribucion.Enabled = false;
            btnVistaPrevia.Enabled = false;
            btnActualizar.Enabled = false;
            gbDetallePasajeroByParadero.Enabled = false;
            gbResumenPasajerosByParadero.Enabled = false;
            ProgressBar.Visible = !false;



            bgwProceso01.RunWorkerAsync();
        }


        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                modelo = new MovimientoMovilidadNegocio();

                listadoParaderoActivos = new List<Paradero>();
                listadoDistribucionPasajerosPorParadero = new List<Paradero>();
                ObtenerListadoPresentacion = new List<Paradero>();
                listadoParaderoActivos = modelo.ObtenerListadoParaderosActivos(DateTime.Now.Year.ToString()).ToList();
                listadoDistribucionPasajerosPorParadero = modelo.ObtenerListadoAgrupadoDistribucionPasajerosPorParadero(DateTime.Now.Year.ToString(), txtCodigoExterno.Text.Trim()).ToList();
                ObtenerListadoPresentacion = modelo.ObtenerListadoDistribucionPasajerosPorParadero(DateTime.Now.Year.ToString(), listadoParaderoActivos, listadoDistribucionPasajerosPorParadero);


                ListaPasajerosByParaderoByMovimiento = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                ListaPasajerosByParaderoByMovimiento = modelo.ObtenerDocumentoDetalleMovimientosInterLocalidades(txtCodigoExterno.Text.Trim(), DateTime.Now.ToPresentationDate() ).ToList();


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwProceso01_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvListadoParadero.DataSource = ObtenerListadoPresentacion.ToList();
                dgvListadoParadero.Refresh();

                dgvDetallePasajeroByParadero.DataSource = ListaPasajerosByParaderoByMovimiento.ToList();
                dgvListadoParadero.Refresh();

                gbTransportistaInformacion.Enabled = !false;
                gbRegistroMovimientoExterno.Enabled = !false;
                gbProcedenciaExterno.Enabled = !false;
                txtNumeroPersonasInterlocalidad.Enabled = !false;
                btnGenerarDistribucion.Enabled = !false;
                btnVistaPrevia.Enabled = !false;
                btnActualizar.Enabled = !false;
                gbDetallePasajeroByParadero.Enabled = !false;
                gbResumenPasajerosByParadero.Enabled = !false;
                ProgressBar.Visible = false;


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgvListadoParadero_SelectionChanged(object sender, EventArgs e)
        {
            //dgvListadoParadero.CurrentRow.Cells["chSelecion"].Value = 0;
            //if (dgvListadoParadero != null && dgvListadoParadero.Rows.Count > 0)
            //{
            //    decimal? EsMayorCero = dgvListadoParadero.CurrentRow.Cells["chNumeroPersonas"].Value != null ? Convert.ToDecimal(dgvListadoParadero.CurrentRow.Cells["chNumeroPersonas"].Value.ToString()) : 0;
            //    if (EsMayorCero > 0)
            //    {
            //        dgvListadoParadero.CurrentRow.Cells["chSelecion"].Value = 1;
            //    }
            //}
        }


        protected override void OnLoad(EventArgs e)
        {
            this.dgvListadoParadero.TableElement.BeginUpdate();
            //this.dgvRecorridos.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvListadoParadero.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvListadoParadero.MasterTemplate.AutoExpandGroups = true;
            this.dgvListadoParadero.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoParadero.GroupDescriptors.Clear();
            this.dgvListadoParadero.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chNumeroPersonas", "Reg: {0:N0}; ", GridAggregateFunction.Sum));
            this.dgvListadoParadero.MasterTemplate.SummaryRowsTop.Add(item);
        }

        private void btnGenerarDistribucion_Click(object sender, EventArgs e)
        {
            listaParaderosGenerar = new List<Paradero>();
            codigoMovimientoRecorrido = this.txtCodigoExterno.Text.Trim();

            //foreach (Telerik.WinControls.UI.GridViewRowInfo row in dgvListadoParadero.Rows)
            foreach (Telerik.WinControls.UI.GridViewRowInfo row in dgvListadoParadero.Rows)
            {
                //if (row.Index >= 0)
                //{
                //foreach (Telerik.WinControls.UI.GridViewCellInfo cell in row.Cells)
                //{
                //if (cell.RowInfo.Index >= 0)
                //{
                if (row.Cells["chNumeroPersonas"].Value != null && Convert.ToInt32(row.Cells["chNumeroPersonas"].Value.ToString().Trim()) > 0)
                {
                    listaParaderosGenerar.Add(new Paradero { 
                        idParadero = row.Cells["chIdparadero"].Value.ToString().Trim(), 
                        numeroPasajeros = Convert.ToInt32(row.Cells["chNumeroPersonas"].Value.ToString().Trim()) ,
                        descripcionParadero = row.Cells["chParadero"].Value.ToString().Trim(),                     
                    
                    });
                    
                }
                //}
                //}
                //}
            }


            if (listaParaderosGenerar != null && listaParaderosGenerar.ToList().Count > 0)
            {
                gbTransportistaInformacion.Enabled = false;
                gbRegistroMovimientoExterno.Enabled = false;
                gbProcedenciaExterno.Enabled = false;
                txtNumeroPersonasInterlocalidad.Enabled = false;
                btnGenerarDistribucion.Enabled = false;
                btnVistaPrevia.Enabled = false;
                btnActualizar.Enabled = false;
                gbDetallePasajeroByParadero.Enabled = false;
                gbResumenPasajerosByParadero.Enabled = false;
                ProgressBar.Visible = !false;
                bgwProceso02.RunWorkerAsync();
            }



        }

        private void bgwProceso02_DoWork(object sender, DoWorkEventArgs e)
        {
            if (listaParaderosGenerar != null && listaParaderosGenerar.ToList().Count > 0)
            {
                modelo = new MovimientoMovilidadNegocio();
                modelo.GenerarDistribucionPasajerosByParadero(listaParaderosGenerar, codigoMovimientoRecorrido, DateTime.Now.Year.ToString());


                modelo = new MovimientoMovilidadNegocio();

                listadoParaderoActivos = new List<Paradero>();
                listadoDistribucionPasajerosPorParadero = new List<Paradero>();
                ObtenerListadoPresentacion = new List<Paradero>();
                listadoParaderoActivos = modelo.ObtenerListadoParaderosActivos(DateTime.Now.Year.ToString()).ToList();
                listadoDistribucionPasajerosPorParadero = modelo.ObtenerListadoAgrupadoDistribucionPasajerosPorParadero(DateTime.Now.Year.ToString(), txtCodigoExterno.Text.Trim()).ToList();
                ObtenerListadoPresentacion = modelo.ObtenerListadoDistribucionPasajerosPorParadero(DateTime.Now.Year.ToString(), listadoParaderoActivos, listadoDistribucionPasajerosPorParadero);

                ListaPasajerosByParaderoByMovimiento = new List<SJ_RHListarMovimientoMovilidadAsistenciaTrabajadorDetallexCodigoResult>();
                ListaPasajerosByParaderoByMovimiento = modelo.ObtenerDocumentoDetalleMovimientosInterLocalidades(txtCodigoExterno.Text.Trim(), DateTime.Now.ToPresentationDate()).ToList();



            }
        }

        private void bgwProceso02_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvListadoParadero.DataSource = ObtenerListadoPresentacion.ToList();
                dgvListadoParadero.Refresh();

                dgvDetallePasajeroByParadero.DataSource = ListaPasajerosByParaderoByMovimiento.ToList();
                dgvListadoParadero.Refresh();

                gbTransportistaInformacion.Enabled = !false;
                gbRegistroMovimientoExterno.Enabled = !false;
                gbProcedenciaExterno.Enabled = !false;
                txtNumeroPersonasInterlocalidad.Enabled = !false;
                btnGenerarDistribucion.Enabled = !false;
                btnVistaPrevia.Enabled = !false;
                btnActualizar.Enabled = !false;
                gbDetallePasajeroByParadero.Enabled = !false;
                gbResumenPasajerosByParadero.Enabled = !false;
                ProgressBar.Visible = false;


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }



       



    }
}
