using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using TransportistaMto.Datos;
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
    public partial class MovimientoRegistroAsistenciaRefrigerio : Telerik.WinControls.UI.RadForm
    {
        private Mes MesesNeg;
        private List<SJ_RHMovimientoAsistenciaRefrigeriosResult> Listado;
        private SJM_PensionesNegocios negocios;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        private SJ_RHMovimientoAsistenciaPensionNegocios modelo;
        private List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> listado;
        private List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> listadoAgrupado;
        private string proveedorNroRUC = string.Empty;
        private string proveedorNombre = string.Empty;
        private string proveedorNombreComercial = string.Empty;
        private string proveedordni = string.Empty;
        private string proveedorCodigoPension = string.Empty;
        private string desde = string.Empty;
        private string hasta = string.Empty;
        private string periodo = string.Empty;
        private string codigo = string.Empty;
        private string dniPension = string.Empty;
        private string fecha = string.Empty;
        private SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult movimientoAsistencia;
        private SJ_RHMovimientoAsistenciaPension oMovimiento;

        public MovimientoRegistroAsistenciaRefrigerio()
        {
            InitializeComponent();
            CargarMeses();
            ObtenerFechasIniciales();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.dgvListado.TableElement.BeginUpdate();
            //this.dgvRecorridos.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvListado.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvListado.MasterTemplate.AutoExpandGroups = true;
            this.dgvListado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.GroupDescriptors.Clear();
        }

        private void ObtenerFechasIniciales()
        {
            this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);

            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
            this.txtPeriodo.Value = Convert.ToDecimal(DateTime.Now.Year);

            int numeroSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
            txtSemana.Value = numeroSemana;
            ObtenerFechasSemanalesByNumeroSemana();
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
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtPeriodo.Value.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Value.ToString());// 
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
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtPeriodo.Value.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Value.ToString());// 
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
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtPeriodo.Value.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtPeriodo.Value.ToString());//
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();

                }

            }
        }

        private void CargarMeses()
        {

            MesesNeg = new Mes();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = MesesNeg.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = MesesNeg.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void MovimientoAsistenciaRefrigerio_Load(object sender, EventArgs e)
        {

        }

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            //CargarDatos();
            EjecutarConsulta();
        }

        private void EjecutarConsulta()
        {
            try
            {
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                listado = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult>();
                listadoAgrupado = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult>();

                listado = modelo.ObtenerListadoMovimientoAsistenciasSinProcesarByPeriodo(desde, hasta, proveedorNroRUC).ToList();
                if (listado != null && listado.ToList().Count > 0)
                {
                    listadoAgrupado = modelo.AgruparListadoMovimientoAsistenciasProcesadasByCodigoMovimiento(listado).ToList();
                }


            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void CargarDatos()
        {

            try
            {
                Listado = new List<SJ_RHMovimientoAsistenciaRefrigeriosResult>();
                negocios = new SJM_PensionesNegocios();

                Listado = negocios.ListarMovimientosAsistenciaRefrigerio(desde, hasta, periodo).ToList();

            }
            catch (Exception Ex)
            {

                Ex.Message.ToString();
            }


        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //PresentarDatos();
            PresentarDatosConsulta();
        }

        private void PresentarDatos()
        {
            try
            {
                dgvListado.DataSource = Listado.ToDataTable<SJ_RHMovimientoAsistenciaRefrigeriosResult>();
                dgvListado.Refresh();
                progressBar.Visible = false;
                btnConsultar.Enabled = true;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void PresentarDatosConsulta()
        {
            try
            {
                dgvListado.DataSource = listadoAgrupado.ToDataTable<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult>();
                dgvListado.Refresh();

                if (listadoAgrupado != null && listadoAgrupado.ToList().Count > 0)
                {
                    ResaltarResultados();
                }


                btnConsultar.Enabled = !false;
                progressBar.Visible = false;
                gbLista.Enabled = !false;
                menuPrincipal.Enabled = !false;
            }
            catch (Exception Ex)
            {
                btnConsultar.Enabled = !false;
                progressBar.Visible = false;
                gbLista.Enabled = !false;
                menuPrincipal.Enabled = !false;

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ResaltarResultados()
        {
            try
            {
                if (listadoAgrupado != null && listadoAgrupado.ToList().Count > 0)
                {
                    foreach (Telerik.WinControls.UI.GridViewRowInfo row in dgvListado.Rows)
                    {
                        foreach (Telerik.WinControls.UI.GridViewCellInfo cell in row.Cells)
                        {
                            if (this.dgvListado.Rows[row.Index].Cells["chestadoRegistro"].Value.ToString().Trim() == "0")
                            {

                                this.dgvListado.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.CustomizeFill = true;
                                this.dgvListado.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.DrawFill = true;
                                //this.dgvMantenimiento.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.BackColor = Utiles.colorVerdeClaro;
                                this.dgvListado.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.BackColor = Utiles.blancoHumo3D;
                                this.dgvListado.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                btnConsultar.Enabled = false;
                progressBar.Visible = !false;
                gbLista.Enabled = false;
                progressBar.Visible = !false;
                menuPrincipal.Enabled = false;

                desde = this.txtFechaDesde.Text.ToString().Trim();
                hasta = this.txtFechaHasta.Text.ToString().Trim();
                periodo = this.txtPeriodo.Value.ToString().Trim();
                proveedorNroRUC = this.txtRUCProveedor.Text.Trim();
                proveedorNombre = this.txtRazonSocialProveedor.Text.Trim();
                proveedorNombreComercial = this.txtPseudoNombre.Text.Trim();
                proveedordni = this.txtnroDniPension.Text.Trim();
                proveedorCodigoPension = this.txtIdPension.Text.Trim();

                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                //MovimientoAsistenciaRefrigerioMatenimiento ofrm = new MovimientoAsistenciaRefrigerioMatenimiento();
                //ofrm.Show();

                

                string sinProceso = string.Empty;
                MovimientoAsistenciaRefrigerioMatenimiento newMDIChild = new MovimientoAsistenciaRefrigerioMatenimiento(sinProceso, proveedorNroRUC, proveedorNombre, proveedorNombreComercial, proveedordni, proveedorCodigoPension);
                newMDIChild.MdiParent = MovimientoRegistroAsistenciaRefrigerio.ActiveForm;
                newMDIChild.Show();
                newMDIChild.WindowState = FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void dgvListaAgrupada_SelectionChanged(object sender, EventArgs e)
        {
            codigo = string.Empty;
            if (dgvListado != null)
            {
                if (dgvListado.Rows.Count > 0)
                {
                    if (dgvListado.CurrentRow.Cells["chidMovimiento"].Value != null && dgvListado.CurrentRow.Cells["chidMovimiento"].Value.ToString().Trim() != string.Empty)
                    {
                        codigo = dgvListado.CurrentRow.Cells["chidMovimiento"].Value.ToString().Trim();
                        dniPension = dgvListado.CurrentRow.Cells["chPensionNroDNI"].Value.ToString().Trim();
                        fecha = dgvListado.CurrentRow.Cells["chFecha"].Value.ToString().Trim();
                    }
                }
            }
        }

        private void txtSemana_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasSemanalesByNumeroSemana();
        }

        private void ObtenerFechasSemanalesByNumeroSemana()
        {
            try
            {
                #region Asigar fechas por semana()

                modeloSemana = new SJ_SemanaNegocio();
                oSemana = new SJ_Semana();
                oSemanaConsulta = new SJ_Semana();
                oSemana.año = Convert.ToInt32(this.txtPeriodo.Value);
                oSemana.semana = Convert.ToInt32(this.txtSemana.Value);

                oSemanaConsulta = modeloSemana.ObtenerSemanaPorNroSemana(oSemana);
                this.txtFechaDesde.Text = oSemanaConsulta.desde.Value.ToPresentationDate();
                this.txtFechaHasta.Text = oSemanaConsulta.hasta.Value.ToPresentationDate();

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void txtnroDniPension_Leave(object sender, EventArgs e)
        {
            string[] cadena = this.txtRazonSocialProveedor.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPension(cadena);
            }
        }

        private void AsignarDatosPension(string[] ncadena)
        {
            this.txtRazonSocialProveedor.Text = ncadena[0].ToString().Trim();
            this.txtIdPension.Text = ncadena[3].ToString().Trim();
            this.txtRUCProveedor.Text = ncadena[1].ToString().Trim();
            this.txtPseudoNombre.Text = ncadena[2].ToString().Trim();
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            
            movimientoAsistencia = new SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult();
            oMovimiento = new SJ_RHMovimientoAsistenciaPension();
            movimientoAsistencia.idMovimiento = string.Empty;
            oMovimiento.idMovimiento = string.Empty;
            oMovimiento.idDocumento = string.Empty;

            if (dgvListado != null && dgvListado.Rows.Count > 0)
            {
                if (dgvListado.CurrentRow != null && dgvListado.CurrentRow.Cells["chIdMovimiento"].Value != null)
                {
                    if (dgvListado.CurrentRow.Cells["chIdMovimiento"].Value.ToString().Trim() != string.Empty)
                    {
                        string idMovimiento = dgvListado.CurrentRow.Cells["chIdMovimiento"].Value.ToString().Trim();
                        string idDocumento = dgvListado.CurrentRow.Cells["chdocumento"].Value != null ? dgvListado.CurrentRow.Cells["chdocumento"].Value.ToString().Substring(0, 3) : string.Empty;
                        string idEstado = dgvListado.CurrentRow.Cells["chidEstado"].Value != null ? dgvListado.CurrentRow.Cells["chidEstado"].Value.ToString().Trim() : string.Empty;
                        movimientoAsistencia = new SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult();
                        oMovimiento = new SJ_RHMovimientoAsistenciaPension();
                        movimientoAsistencia = listadoAgrupado.Where(x => x.idMovimiento.ToString().Trim() == idMovimiento).Single();
                        oMovimiento.idMovimiento = idMovimiento;
                        oMovimiento.idDocumento = idDocumento;
                        oMovimiento.idEstado = idEstado;
                    }
                }
            }
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            VerDetalleDocumento();
        }

        private void VerDetalleDocumento()
        {
            if (oMovimiento.idMovimiento != string.Empty)
            {
                MovimientoAsistenciaRefrigerioMatenimiento newMDIChild = new MovimientoAsistenciaRefrigerioMatenimiento(oMovimiento, oMovimiento.idDocumento.Trim());
                newMDIChild.MdiParent = RegistroAsistenciaRefrigerio.ActiveForm;
                newMDIChild.Show();
                newMDIChild.WindowState = FormWindowState.Maximized;
            }
        }
        
    }
}
