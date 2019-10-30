using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
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
    public partial class RutaBuscar : Telerik.WinControls.UI.RadForm
    {
        private string tipoMovimiento;
        private string codigoRutaExcluida;
        private TransportistaNeg Modelo;
        private List<SJ_RHListarDetalleTransportistaRutaResult> ListarRutas;
        public SJ_RHListarDetalleTransportistaRutaResult oRuta;

        public RutaBuscar()
        {
            InitializeComponent();
        }

        public RutaBuscar(string _tipoMovimiento, string _CodigoRutaExcluida)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.tipoMovimiento = _tipoMovimiento;
            this.codigoRutaExcluida = _CodigoRutaExcluida.ToString().Trim() != string.Empty ? _CodigoRutaExcluida.ToString().Trim() : "0";
            ObtenerLista();
        }

        private void ObtenerLista()
        {
            try
            {
                if (tipoMovimiento != string.Empty)
                {

                    // Cargar registos en la Grilla, en caso tenga registros
                    Modelo = new TransportistaNeg();
                    ListarRutas = new List<SJ_RHListarDetalleTransportistaRutaResult>();
                    try
                    {
                        ListarRutas = Modelo.ListarDetalleRuta(Convert.ToInt32(tipoMovimiento)).Where(x => x.IdRuta != Convert.ToInt32(codigoRutaExcluida)).ToList();
                    }
                    catch (Exception Ex)
                    {
                        
                        throw Ex;
                    }                    

                    this.dgvRutas.DataSource = ListarRutas.ToDataTable<SJ_RHListarDetalleTransportistaRutaResult>();
                    this.dgvRutas.Refresh();
                    this.dgvRutas.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                }
                else 
                {
                    // Cargar registos en la Grilla, en caso tenga registros
                    Modelo = new TransportistaNeg();
                    ListarRutas = new List<SJ_RHListarDetalleTransportistaRutaResult>();                    
                    this.dgvRutas.DataSource = ListarRutas.ToDataTable<SJ_RHListarDetalleTransportistaRutaResult>();
                    this.dgvRutas.Refresh();
                    this.dgvRutas.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill; 
                }

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void RutaBuscar_Load(object sender, EventArgs e)
        {
            ObtenerLista();
        }

        private void MasterTemplate_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRutas != null)
            {
                if (dgvRutas.CurrentRow != null)
                {
                    oRuta = new SJ_RHListarDetalleTransportistaRutaResult();
                    
                    oRuta.IdRuta = dgvRutas.CurrentRow.Cells["chCodRuta"].Value != null ? Convert.ToInt32(dgvRutas.CurrentRow.Cells["chCodRuta"].Value) : 0;
                    oRuta.Ruta = dgvRutas.CurrentRow.Cells["chDescripcionRuta"].Value != null ? Convert.ToString(dgvRutas.CurrentRow.Cells["chDescripcionRuta"].Value) : "";
                    oRuta.PrecioPersona = dgvRutas.CurrentRow.Cells["chPrecioPersona"].Value != null ? Convert.ToDecimal(dgvRutas.CurrentRow.Cells["chPrecioPersona"].Value) : (decimal?)null;
                    oRuta.PrecioFlete = dgvRutas.CurrentRow.Cells["chPrecioFlete"].Value != null ? Convert.ToDecimal(dgvRutas.CurrentRow.Cells["chPrecioFlete"].Value) : (decimal?)null;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
