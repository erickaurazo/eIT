using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Configuration;
using System.Linq;
using System.IO;
using RecursosHumanos;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;

using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Localization;
using Telerik.Charting;
using Telerik.WinControls;

namespace RecursosHumanos
{
    public partial class ReporteRendimientoDiarioPersonalByActividad : Form
    {
        private MesNegocios MesesNeg;
        private string periodoConsulta;
        private string mensaje;
        private List<string> listaPlanillasInvolucradas;
        private string desde;
        private string hasta;
        private string idLabor;
        private string idActividad;
        private decimal basicoBruto;
        private decimal basicoNeto;
        private decimal valorPlantaRacimo;
        private decimal valorPlantaRacimoAdicional;
        private decimal estandarByLabor;
        private List<SJ_RRHHRendimientoDiarioPersonalCampoResult> listadoDetalle;
        private List<SJ_RRHHRendimientoDiarioPersonalCampoResult> listadoAgrupado;
        private RendimientoDiarioPersonalCampoNegocios modeloRendimiento;

        public ReporteRendimientoDiarioPersonalByActividad()
        {
            InitializeComponent();
            CargarMeses();
            periodoConsulta = DateTime.Now.Year.ToString();
            ObtenerFechasIniciales();
            RadGridLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new RecursosHumanos.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

        }
       
        protected override void OnLoad(EventArgs e)
        {
            this.dgvResumen.TableElement.BeginUpdate();            
            this.LoadFreightSummary();            
            this.dgvResumen.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvResumen.MasterTemplate.AutoExpandGroups = true;            
            this.dgvResumen.GroupDescriptors.Clear();
            this.dgvResumen.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem items1 = new GridViewSummaryRowItem();
            GridViewSummaryRowItem items2 = new GridViewSummaryRowItem();
            GridViewSummaryRowItem items3 = new GridViewSummaryRowItem();
           
            items3.Add(new GridViewSummaryItem("chtrabajador", "Registros : {0:N0}; ", ""));
            items3.Add(new GridViewSummaryItem("chtotalPago", "Min : {0:N2}; ", GridAggregateFunction.Min));
            items3.Add(new GridViewSummaryItem("chAvance", "Min : {0:N2}; ", GridAggregateFunction.Min));
            items3.Add(new GridViewSummaryItem("chstandar", "Min : {0:N2}; ", GridAggregateFunction.Min));
            items3.Add(new GridViewSummaryItem("chjornalDiario", "Min : {0:N2}; ", GridAggregateFunction.Min));
            items3.Add(new GridViewSummaryItem("chjornalDiarioExtra", "Min : {0:N2}; ", GridAggregateFunction.Min));
            items3.Add(new GridViewSummaryItem("chTotalPago", "Min : {0:N2}; ", GridAggregateFunction.Min));
            this.dgvResumen.MasterTemplate.SummaryRowsTop.Add(items3);
            items2.Add(new GridViewSummaryItem("chtrabajador", "Registros : {0:N0}; ", ""));
            items2.Add(new GridViewSummaryItem("chtotalPago", "Max : {0:N2}; ", GridAggregateFunction.Max));
            items2.Add(new GridViewSummaryItem("chAvance", "Max : {0:N2}; ", GridAggregateFunction.Max));
            items2.Add(new GridViewSummaryItem("chstandar", "Max : {0:N2}; ", GridAggregateFunction.Max));
            items2.Add(new GridViewSummaryItem("chjornalDiario", "Max : {0:N2}; ", GridAggregateFunction.Max));
            items2.Add(new GridViewSummaryItem("chjornalDiarioExtra", "Max : {0:N2}; ", GridAggregateFunction.Max));
            items2.Add(new GridViewSummaryItem("chTotalPago", "Max : {0:N2}; ", GridAggregateFunction.Max));
            this.dgvResumen.MasterTemplate.SummaryRowsTop.Add(items2);
            items1.Add(new GridViewSummaryItem("chtrabajador", "Registros : {0:N0}; ", GridAggregateFunction.Count));
            items1.Add(new GridViewSummaryItem("chtotalPago", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chAvance", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chstandar", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chjornalDiario", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chjornalDiarioExtra", "Sum : {0:N2}; ", GridAggregateFunction.Sum));
            items1.Add(new GridViewSummaryItem("chTotalPago", "Sum : {0:N2}; ", GridAggregateFunction.Sum));                        
            this.dgvResumen.MasterTemplate.SummaryRowsTop.Add(items1);            
            
        }

        private void CargarMeses()
        {
            MesesNeg = new MesNegocios();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = MesesNeg.ListarDoceMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void ObtenerFechasIniciales()
        {
            //this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);

            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);
        }

        private void ObtenerFechasMes()
        {
            DateTime fecha1;
            DateTime fecha2;

            if (cboMes.SelectedValue.ToString() != "00")
            {
                #region
                this.txtFechaDesde.Enabled = false;
                this.txtFechaHasta.Enabled = false;
                if (cboMes.SelectedValue.ToString() == "12")
                {
                    #region Si es mes diciembre
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtAño.Value.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtAño.Value.ToString());// 
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();
                    #endregion

                }
                else
                {
                    #region Si es mes 13 habilitar controles de fecha, caso contrario es un mes de enero a noviembre.
                    if (cboMes.SelectedValue.ToString() == "13")
                    {
                        this.txtFechaDesde.Enabled = true;
                        this.txtFechaHasta.Enabled = true;


                    }
                    else
                    {
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtAño.Value.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtAño.Value.ToString());// 
                        this.txtFechaDesde.Text = fecha1.ToShortDateString();
                        this.txtFechaHasta.Text = fecha2.ToShortDateString();


                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                if (cboMes.SelectedValue.ToString() == "00")
                {
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtAño.Value.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtAño.Value.ToString());//
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();

                }

            }
        }

        public void Inicio()
        {
            try
            {
                periodoConsulta = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodoConsulta].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "CHRISTIAN";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Christian LLontop";
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

        }

        private void btnActividadBuscar_Click(object sender, EventArgs e)
        {
            this.btnLaborBuscar.P_TablaConsulta = "labores where idactividad = " + this.txtActividadCodigo.Text.ToString().Trim();
            this.txtLaborCodigo.Focus();
        }

        private void btnLaborBuscar_Click(object sender, EventArgs e)
        {

        }

        private void ReporteRendimientoDiarioPersonal_Load(object sender, EventArgs e)
        {
            txtFechaDesde.Focus();
        }

        private void txtActividadCodigo_Leave(object sender, EventArgs e)
        {
            btnLaborBuscar.P_TablaConsulta = "labores where idactividad = " + this.txtActividadCodigo.Text.ToString().Trim();
            //txtActividadDescripcion.Focus();
            //  this.txtLaborCodigo.Focus();

        }

        private void txtBasicoBruto_Leave(object sender, EventArgs e)
        {
            //this.txtBasicoNeto.Focus();
        }

        private void txtBasicoNeto_Leave(object sender, EventArgs e)
        {
            //this.txtValorPlantaRacimo.Focus();
        }

        private void txtValorPlantaRacimo_Leave(object sender, EventArgs e)
        {
            //this.txtValorPlantaRacimoAdicional.Focus();
        }

        private void txtValorPlantaRacimoAdicional_Leave(object sender, EventArgs e)
        {
            //this.txtEstandarByLabor.Focus();
        }

        private void btnLaborBuscar_Leave(object sender, EventArgs e)
        {
            //this.txtLaborCodigo.Focus();
        }

        private void txtLaborCodigo_Leave(object sender, EventArgs e)
        {
            //this.txtLaborDescripion.Focus();
            //this.txtBasicoBruto.Focus();
        }

        private void txtLaborDescripion_Leave(object sender, EventArgs e)
        {
            //this.txtBasicoBruto.Focus();
        }

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            if (txtAño.Value != null)
            {
                ObtenerFechasMes();
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboMes.SelectedIndex >= 0)
            {
                ObtenerFechasMes();
            }
        }

        private void txtActividadDescripcion_Leave(object sender, EventArgs e)
        {
            //this.txtLaborCodigo.Focus();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (ValidarConsulta() == true)
            {
                #region Obtener planillas involudradas()
                listaPlanillasInvolucradas = new List<string>();

                if (chkEma.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("EMA");
                }

                if (chkEmp.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("EMP");
                }

                if (chkObm.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("OBM");
                }

                if (chkPas.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("PAS");
                }

                if (chkPam.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("PAM");
                }

                if (chkPoa.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("POA");
                }

                if (chkPra.Checked == true)
                {
                    listaPlanillasInvolucradas.Add("PRA");
                }
                #endregion
                listadoDetalle = new List<SJ_RRHHRendimientoDiarioPersonalCampoResult>();
                listadoAgrupado = new List<SJ_RRHHRendimientoDiarioPersonalCampoResult>();
                modeloRendimiento = new RendimientoDiarioPersonalCampoNegocios();


                desde = this.txtFechaDesde.Text.ToString().Trim();
                hasta = this.txtFechaHasta.Text.ToString().Trim();
                idLabor = this.txtLaborCodigo.Text.ToString().Trim();
                idActividad = this.txtActividadCodigo.Text.ToString().Trim();
                basicoBruto = txtBasicoBruto.Text.ToString().Trim() != null ? Convert.ToDecimal(txtBasicoBruto.Text.ToString().Trim()) : 0;
                basicoNeto = txtBasicoNeto.Text.ToString().Trim() != null ? Convert.ToDecimal(txtBasicoNeto.Text.ToString().Trim()) : 0;
                valorPlantaRacimo = txtValorPlantaRacimo.Text.ToString().Trim() != null ? Convert.ToDecimal(txtValorPlantaRacimo.Text.ToString().Trim()) : 0;
                valorPlantaRacimoAdicional = txtValorPlantaRacimoAdicional.Text.ToString().Trim() != null ? Convert.ToDecimal(txtValorPlantaRacimoAdicional.Text.ToString().Trim()) : 0;
                estandarByLabor = txtEstandarByLabor.Text.ToString().Trim() != null ? Convert.ToDecimal(txtEstandarByLabor.Text.ToString().Trim()) : 0;
                dgvResumen.Enabled = false;
                gbGrupo.Enabled = false;
                btnConsultar.Enabled = false;
                progressBar.Visible = true;

                bgwHilo.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show(mensaje, "MENSAJE DEL SISTEMA");
                dgvResumen.Enabled = true;
                gbGrupo.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                return;
            }


        }

        private bool ValidarConsulta()
        {
            mensaje = string.Empty;
            bool estado = true;

            if (this.txtActividadCodigo.Text.ToString().Trim() == "")
            {
                mensaje += "\nFalta ingresar una actividad. ";
                estado = false;

            }

            if (this.txtLaborCodigo.Text.ToString().Trim() == "")
            {
                mensaje += "\nFalta ingresar una labor. ";
                estado = false;
            }

            if (txtBasicoBruto.Text.ToString().Trim() == "")
            {
                mensaje += "\nIngrese un monto al básico bruto. ";
                estado = false;
            }

            if (txtBasicoNeto.Text.ToString().Trim() == "")
            {
                mensaje += "\nIngrese un monto al básico neto. ";
                estado = false;
            }


            if (txtEstandarByLabor.Text.ToString().Trim() == "")
            {
                mensaje += "\nIngrese un monto al estándar por labor. ";
                estado = false;
            }

            if (txtValorPlantaRacimoAdicional.Text.ToString().Trim() == "")
            {
                mensaje += "\nIngrese un monto al valor adicional por planta o racimo. ";
                estado = false;
            }

            if (txtValorPlantaRacimo.Text.ToString().Trim() == "")
            {
                mensaje += "\nIngrese un monto al valor por planta o racimo ";
                estado = false;
            }

            return estado;

        }

        private void txtBasicoBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBasicoBruto.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void txtBasicoNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBasicoNeto.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void txtValorPlantaRacimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorPlantaRacimo.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void txtValorPlantaRacimoAdicional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtValorPlantaRacimoAdicional.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void txtEstandarByLabor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEstandarByLabor.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            RealizarConsulta();
        }

        private void RealizarConsulta()
        {
            try
            {
                #region Realizar consulta()
                listadoDetalle = new List<SJ_RRHHRendimientoDiarioPersonalCampoResult>();
                listadoAgrupado = new List<SJ_RRHHRendimientoDiarioPersonalCampoResult>();
                modeloRendimiento = new RendimientoDiarioPersonalCampoNegocios();

                listadoDetalle = modeloRendimiento.ObtenerListadoRendimientoDiarioPersonalCampo(periodoConsulta, desde, hasta, idActividad, idLabor).ToList();
                listadoAgrupado = modeloRendimiento.ObtenerListadoRendimientoDiarioPersonalCampoAgrupadoByPersonaByDia(listadoDetalle, basicoBruto, basicoNeto, valorPlantaRacimo, valorPlantaRacimoAdicional, estandarByLabor);
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                dgvResumen.Enabled = false;
                gbGrupo.Enabled = false;
                btnConsultar.Enabled = false;
                progressBar.Visible = true;
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarInformacion();
        }

        private void PresentarInformacion()
        {
            try
            {
                dgvResumen.DataSource = listadoAgrupado.ToDataTable<SJ_RRHHRendimientoDiarioPersonalCampoResult>();
                dgvResumen.Refresh();
                dgvResumen.Enabled = true;
                gbGrupo.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
            }
            catch (Exception Ex)
            {
                dgvResumen.Enabled = true;
                gbGrupo.Enabled = true;
                btnConsultar.Enabled = true;
                progressBar.Visible = false;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
            }
        }
    }
}
