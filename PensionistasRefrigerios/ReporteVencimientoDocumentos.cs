using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Busquedas;
using System.Collections;
using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using Asistencia.Negocios;
using Asistencia.Datos;
using Asistencia.Helper;

namespace Asistencia
{
    public partial class ReporteVencimientoDocumentos : Form
    {
        private List<SJ_RHListadoVencimientoDocumentosByUnidadTransportesResult> expirationOfDocuments;
        private CarrierController model;
        private string period;
        private ExportToExcelHelper modelExcel;

        public ReporteVencimientoDocumentos()
        {
            InitializeComponent();
            RefreshList();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            model = new CarrierController();
            expirationOfDocuments = new List<SJ_RHListadoVencimientoDocumentosByUnidadTransportesResult>();
            expirationOfDocuments = model.GetExpirationOfDocumentsPerTransportationUnit(period);
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            dgvTransportista.DataSource = expirationOfDocuments;
            dgvTransportista.Refresh();
            gbList.Enabled = !false;
            cbPrincipal.Enabled = !false;
            ProgressBar.Visible = !true;
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            period = DateTime.Now.Year.ToString();
            gbList.Enabled = false;
            cbPrincipal.Enabled = false;
            ProgressBar.Visible = true;
            bgwHilo.RunWorkerAsync();
        }

        private void btnNotificar_Click(object sender, EventArgs e)
        {
            SendNofify();
        }

        private void SendNofify()
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportoToExcel();
        }

        private void ExportoToExcel()
        {
            modelExcel = new ExportToExcelHelper();
            modelExcel.ExportarToExcel(dgvTransportista, saveFileDialog);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.bgwHilo.IsBusy != true)
            {
                this.Close();
            }
        }

        private void ReporteVencimientoDocumentos_Load(object sender, EventArgs e)
        {

        }

        private void ReporteVencimientoDocumentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
