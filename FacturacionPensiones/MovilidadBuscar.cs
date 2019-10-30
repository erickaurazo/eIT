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
using Transportista.Datos;
using Transportista.Negocios;
using System.Linq;
using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;

namespace Transportista
{
    public partial class MovilidadBuscar : Telerik.WinControls.UI.RadForm
    {
        private List<SJ_RHListarTransportistasResult> ListadoTransportista;
        public SJ_RHListarTransportistasResult oMovilidad;
        private string tipoMovimiento;
        private TransportistaNeg transportistaNeg;

        public MovilidadBuscar()
        {
            InitializeComponent();
        }

        public MovilidadBuscar(string _tipoMovimiento)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.tipoMovimiento = _tipoMovimiento;
        }

        private void ObtenerListaTransportistas()
        {
            switch (tipoMovimiento)
            {
                case "INTERLOCALIDAD":
                     transportistaNeg = new TransportistaNeg();
                    ListadoTransportista = new List<SJ_RHListarTransportistasResult>();
                    ListadoTransportista = transportistaNeg.ListarTransportistasActivos().Where(x => x.EsInterLocal.Value == 1).ToList();
                    break;
                case "INERNO":
                     transportistaNeg = new TransportistaNeg();
                    ListadoTransportista = new List<SJ_RHListarTransportistasResult>();
                    ListadoTransportista = transportistaNeg.ListarTransportistasActivos().Where(x => x.EsMovilidadLocal.Value == 1).ToList();
                    break;
                default:
                     transportistaNeg = new TransportistaNeg();
                    ListadoTransportista = new List<SJ_RHListarTransportistasResult>();
                    break;
            }



            MostrarListarTransportista();

        }

        private void MostrarListarTransportista()
        {
            this.dgvTransportista.DataSource = ListadoTransportista.ToDataTable<SJ_RHListarTransportistasResult>();
            this.dgvTransportista.Refresh();
            this.dgvTransportista.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MovilidadBuscar_Load(object sender, EventArgs e)
        {
            ObtenerListaTransportistas();
        }

        private void MasterTemplate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTransportista != null)
            {
                if (dgvTransportista.CurrentRow != null)
                {
                    oMovilidad = new SJ_RHListarTransportistasResult();
                    oMovilidad.Id = dgvTransportista.CurrentRow.Cells["chIdMovilidad"].Value != null ? Convert.ToInt32(dgvTransportista.CurrentRow.Cells["chIdMovilidad"].Value) : 0;
                    oMovilidad.Placa = dgvTransportista.CurrentRow.Cells["chPlaca"].Value != null ? Convert.ToString(dgvTransportista.CurrentRow.Cells["chPlaca"].Value) : "";
                    oMovilidad.RUC = dgvTransportista.CurrentRow.Cells["chRuc"].Value != null ? Convert.ToString(dgvTransportista.CurrentRow.Cells["chRuc"].Value) : "";
                    oMovilidad.RazonSocial = dgvTransportista.CurrentRow.Cells["chRazonSocial"].Value != null ? Convert.ToString(dgvTransportista.CurrentRow.Cells["chRazonSocial"].Value) : "";
                    oMovilidad.NumeroAsientos = dgvTransportista.CurrentRow.Cells["chNroAsientos"].Value != null ? Convert.ToInt32(dgvTransportista.CurrentRow.Cells["chNroAsientos"].Value) : (Int32?)null;
                    oMovilidad.PseudoNombre = dgvTransportista.CurrentRow.Cells["chPseudoNombre"].Value != null ? Convert.ToString(dgvTransportista.CurrentRow.Cells["chPseudoNombre"].Value) : "";
                    oMovilidad.TipoMovilidad = dgvTransportista.CurrentRow.Cells["chTipoMovilidad"].Value != null ? Convert.ToString(dgvTransportista.CurrentRow.Cells["chTipoMovilidad"].Value) : "";

                }
            }
        }



    }
}
