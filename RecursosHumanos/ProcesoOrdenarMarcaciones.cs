using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using RecursosHumanos.Negocios;
using System.Configuration;
using DevSoftSolutionsControls;
using DevSoftSolutionsDataAccess;
using DevSoftSolutionsExtensions;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using System.Collections;
using MyControlsDataBinding.Controles;
using System.Data;
using System.Drawing;


namespace RecursosHumanos
{
    public partial class ProcesoOrdenarMarcaciones : Form
    {
        CheckInOutNegocio modelo = new CheckInOutNegocio();
        string _periodoElegido = string.Empty;

        public ProcesoOrdenarMarcaciones()
        {
            InitializeComponent();
        }


        public ProcesoOrdenarMarcaciones(string CodigoUnicoAccesoSistema, string codigoUsuario, string codigoTipoPlanilla, string semanaPlanilla, string periodoElegido)
        {
            InitializeComponent();
            _periodoElegido = periodoElegido;
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                modelo = new CheckInOutNegocio();
                string variable = modelo.ActualizarNumeroMarcacionesTransferenciaAsistencia(_periodoElegido);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "");
                return;
            }

        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("PROCESO EXITOSO", "MENSAJE DEL SISTEMA");
            BtnProcesarOrdenamientoMarcaciones.Enabled = false;
            ProgressBarF.Visible = true;
        }

        private void BtbProcesarOrdenamientoMarcaciones_Click(object sender, EventArgs e)
        {
            BtnProcesarOrdenamientoMarcaciones.Enabled = false;
            ProgressBarF.Visible = true;
            bwgHilo.RunWorkerAsync();
        }
    }
}
