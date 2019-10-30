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
    public partial class SeguimientoMemorandum : Form
    {
        private string idPlanilla = string.Empty;
        private List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult> listado;
        private SJ_RHOtrosMovimientoPlanillaNegocios modelo;
        private List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult> listadoDetallePorConcepto;
        private SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult iOtrosDocumentos;
        private string idPlanillaConsulta = string.Empty;

        public SeguimientoMemorandum()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgwProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            listado = new List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult>();
            modelo = new SJ_RHOtrosMovimientoPlanillaNegocios();
            listado = modelo.ObtenerListadoPivot(DateTime.Now.Year.ToString(), idPlanilla).ToList();
            listadoDetallePorConcepto = new List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult>();
        }

        private void bgwProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvMemorandum.DataSource = listado.ToDataTable<SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult>();
            dgvMemorandum.Refresh();
            gbLista.Enabled = !false;
            gbDetalle.Enabled = !false;
            menuPrincipal.Enabled = !false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            idPlanilla = string.Empty;
            gbLista.Enabled = false;
            gbDetalle.Enabled = false;
            menuPrincipal.Enabled = false;
            bgwProceso.RunWorkerAsync();
        }

        private void dgvMemorandum_SelectionChanged(object sender, EventArgs e)
        {
            limpiarControles();
            if (dgvMemorandum != null && dgvMemorandum.CurrentRow != null && dgvMemorandum.CurrentRow.Cells["chiddocumento"] != null)
            {
                if (dgvMemorandum.CurrentRow.Cells["chiddocumento"].Value != string.Empty)
                {
                    iOtrosDocumentos.tipo = dgvMemorandum.CurrentRow.Cells["chtipo"].Value != null ? dgvMemorandum.CurrentRow.Cells["chtipo"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.iddocumento = dgvMemorandum.CurrentRow.Cells["chiddocumento"].Value != null ? dgvMemorandum.CurrentRow.Cells["chiddocumento"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.idMotivoMovimiento = dgvMemorandum.CurrentRow.Cells["chidMotivoMovimiento"].Value != null ? dgvMemorandum.CurrentRow.Cells["chidMotivoMovimiento"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.idMotivoMemo = dgvMemorandum.CurrentRow.Cells["chidMotivoMemo"].Value != null ? dgvMemorandum.CurrentRow.Cells["chidMotivoMemo"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.tipoDocumentoMovimiento = dgvMemorandum.CurrentRow.Cells["chtipoDocumentoMovimiento"].Value != null ? dgvMemorandum.CurrentRow.Cells["chtipoDocumentoMovimiento"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.motivoMovimiento = dgvMemorandum.CurrentRow.Cells["chmotivoMovimiento"].Value != null ? dgvMemorandum.CurrentRow.Cells["chmotivoMovimiento"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.memorandum = dgvMemorandum.CurrentRow.Cells["chmemorandum"].Value != null ? dgvMemorandum.CurrentRow.Cells["chmemorandum"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.PAM = dgvMemorandum.CurrentRow.Cells["chPAM"].Value != null ? dgvMemorandum.CurrentRow.Cells["chPAM"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.PAS = dgvMemorandum.CurrentRow.Cells["chPAS"].Value != null ? dgvMemorandum.CurrentRow.Cells["chPAS"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.EMA = dgvMemorandum.CurrentRow.Cells["chEMA"].Value != null ? dgvMemorandum.CurrentRow.Cells["chEMA"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.PRA = dgvMemorandum.CurrentRow.Cells["chPRA"].Value != null ? dgvMemorandum.CurrentRow.Cells["chPRA"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.OBM = dgvMemorandum.CurrentRow.Cells["chOBM"].Value != null ? dgvMemorandum.CurrentRow.Cells["chOBM"].Value.ToString() : string.Empty;
                    iOtrosDocumentos.EMP = dgvMemorandum.CurrentRow.Cells["chEMP"].Value != null ? dgvMemorandum.CurrentRow.Cells["chEMP"].Value.ToString() : string.Empty;
                }
            }
        }

        private void limpiarControles()
        {
            try
            {
                iOtrosDocumentos = new SJ_RHMovimientoOtrosDocumentosPersonalGeneralPivotResult();
                idPlanillaConsulta = string.Empty;
                this.txtConcepto.Clear();
                this.txtMemorandum.Clear();
                this.txtMotivo.Clear();
                this.txtPlanillaCodigo.Clear();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgvMemorandum_DoubleClick(object sender, EventArgs e)
        {
            if (iOtrosDocumentos.tipo != null && iOtrosDocumentos != null)
            {
                switch (dgvMemorandum.Columns[dgvMemorandum.CurrentCell.ColumnIndex].Name)
                {
                    case "chPAM":
                        idPlanillaConsulta = "PAM";
                        gbLista.Enabled = false;
                        gbDetalle.Enabled = false;
                        menuPrincipal.Enabled = false;
                        bgwProceso2.RunWorkerAsync();
                        break;

                    case "chPAS":
                        idPlanillaConsulta = "PAS";
                        gbLista.Enabled = false;
                        gbDetalle.Enabled = false;
                        menuPrincipal.Enabled = false;
                        bgwProceso2.RunWorkerAsync();
                        break;

                    case "chEMA":
                        idPlanillaConsulta = "EMA";
                        gbLista.Enabled = false;
                        gbDetalle.Enabled = false;
                        menuPrincipal.Enabled = false;
                        bgwProceso2.RunWorkerAsync();
                        break;

                    case "chPRA":
                        idPlanillaConsulta = "PRA";
                        gbLista.Enabled = false;
                        gbDetalle.Enabled = false;
                        menuPrincipal.Enabled = false;
                        bgwProceso2.RunWorkerAsync();
                        break;


                    case "chOBM":
                        gbLista.Enabled = false;
                        gbDetalle.Enabled = false;
                        menuPrincipal.Enabled = false;
                        idPlanillaConsulta = "OBM";
                        bgwProceso2.RunWorkerAsync();
                        break;


                    case "chEMP":
                        idPlanillaConsulta = "EMP";
                        gbLista.Enabled = false;
                        gbDetalle.Enabled = false;
                        menuPrincipal.Enabled = false;
                        bgwProceso2.RunWorkerAsync();
                        break;

                    default:
                        idPlanillaConsulta = "";
                        break;
                }
            }
        }

        private void bgwProceso2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                

                modelo = new SJ_RHOtrosMovimientoPlanillaNegocios();                
                listadoDetallePorConcepto = new List<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult>();
                listadoDetallePorConcepto = modelo.ObtenerListadoPorConceptoByPlanilla(DateTime.Now.Year.ToString(), iOtrosDocumentos, idPlanillaConsulta).ToList();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwProceso2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                txtConcepto.Text = iOtrosDocumentos.tipoDocumentoMovimiento != null ? iOtrosDocumentos.tipoDocumentoMovimiento : string.Empty;
                txtMotivo.Text = iOtrosDocumentos.motivoMovimiento != null ? iOtrosDocumentos.motivoMovimiento : string.Empty;
                txtMemorandum.Text = iOtrosDocumentos.memorandum != null ? iOtrosDocumentos.memorandum : string.Empty;
                this.txtPlanillaCodigo.Text = idPlanillaConsulta != null ? idPlanillaConsulta : string.Empty;
                dgvDetalle.DataSource = listadoDetallePorConcepto.ToDataTable<SJ_RHMovimientoOtrosDocumentosPersonalGeneralByTipoDocumentoResult>();
                dgvDetalle.Refresh();

                gbLista.Enabled = !false;
                gbDetalle.Enabled = !false;
                menuPrincipal.Enabled = !false;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgvMemorandum_Click(object sender, EventArgs e)
        {

        }

        private void SeguimientoMemorandum_Load(object sender, EventArgs e)
        {

        }
    }
}
