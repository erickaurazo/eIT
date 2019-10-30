using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
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
using System.Configuration;
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class RegistroAsistenciaRefrigerio : Form
    {
        private string periodo;
        private string desde;
        private string hasta;
        private string rucProveedor;
        private SJ_RHMovimientoAsistenciaPensionNegocios modelo;
        private List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> listado;
        private List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult> listadoAgrupado;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;
        private SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult movimientoAsistencia;
        private SJ_RHMovimientoAsistenciaPension oMovimiento;
        public RegistroAsistenciaRefrigerio()
        {
            InitializeComponent();
            Inicio();
            CargarMeses();
            ObtenerFechasIniciales();
        }

        public void Inicio()
        {
            try
            {
                periodo = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodo].ToString();
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
            this.dgvListado.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chRazon_Social", "Registros: {0:N0}; ", GridAggregateFunction.Count));
            item.Add(new GridViewSummaryItem("chAlmuerzo", "Registros: {0:N0}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chDesayuno", "Registros: {0:N0}; ", GridAggregateFunction.Sum));
            item.Add(new GridViewSummaryItem("chCena", "Registros: {0:N0}; ", GridAggregateFunction.Sum));
            this.dgvListado.MasterTemplate.SummaryRowsTop.Add(item);
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            VerDetalleDocumento();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void Anular()
        {
            #region Anular() 
            try
            {
                #region Anular documento();
                if (oMovimiento.idMovimiento != string.Empty)
                {
                    modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                    modelo.Anular(oMovimiento);
                    Consultar();
                }
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
            #endregion
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            #region Eliminar() 
            try
            {
                #region Eliminar documento();
                if (oMovimiento.idMovimiento != string.Empty)
                {
                    modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                    modelo.Eliminar(oMovimiento);
                    Consultar();
                }
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
            #endregion
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void ExportarExcel()
        {
            throw new NotImplementedException();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubEditar_Click(object sender, EventArgs e)
        {
            VerDetalleDocumento();
        }

        private void btnSubAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void btnSubEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            try
            {
                ProgressBar.Visible = true;
                desde = this.txtFechaDesde.Text.ToString().Trim();
                hasta = this.txtFechaHasta.Text.ToString().Trim();
                rucProveedor = this.txtRUCProveedor.Text.ToString().Trim();
                menuPrincipal.Enabled = false;
                gbConsulta.Enabled = false;
                gbDetalle.Enabled = false;
                bgwSubProceso.RunWorkerAsync();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwSubProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            EjecutarConsulta();
        }

        private void EjecutarConsulta()
        {
            try
            {
                modelo = new SJ_RHMovimientoAsistenciaPensionNegocios();
                listado = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult>();
                listadoAgrupado = new List<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult>();
                listado = modelo.ObtenerListadoMovimientoAsistenciasProcesadasByPeriodo(desde, hasta, rucProveedor).ToList();
                if (listado != null && listado.ToList().Count > 0)
                {
                    listadoAgrupado = modelo.AgruparListadoMovimientoAsistenciasProcesadasByCodigoMovimiento(listado).ToList();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwSubProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarDatos();
        }

        private void PresentarDatos()
        {
            try
            {
                dgvListado.DataSource = listadoAgrupado.ToDataTable<SJ_RHListadoMovimientoAsistenciasProcesadasByPeriodoResult>();
                dgvListado.Refresh();
                ResaltarResultados();
                menuPrincipal.Enabled = true;
                gbConsulta.Enabled = true;
                gbDetalle.Enabled = true;
                ProgressBar.Visible = false;
            }
            catch (Exception Ex)
            {
                menuPrincipal.Enabled = true;
                gbConsulta.Enabled = true;
                gbDetalle.Enabled = true;
                ProgressBar.Visible = false;

                throw Ex;
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
                                this.dgvListado.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.Font = new Font("Microsoft Sans Serif", 7, FontStyle.Bold);
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

        public Mes MesesNeg { get; set; }

        private void txtAño_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
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

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboMes.SelectedIndex >= 0)
            {
                ObtenerFechasMes();
            }
        }

        private void MovimientoAsistenciaRefrigerio_Load(object sender, EventArgs e)
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

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                VerDetalleDocumento();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
        }

    }
}
