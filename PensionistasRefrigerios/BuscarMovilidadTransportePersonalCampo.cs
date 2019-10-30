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
using TransportistaMto.Datos;
using Transportista.Negocios;
using System.Linq;
using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class BuscarMovilidadTransportePersonalCampo : Telerik.WinControls.UI.RadForm
    {
        private List<SJ_RHListarTransportistasResult> ListadoTransportista;
        public SJ_RHListarTransportistasResult oMovilidad;
        private string tipoMovimiento;
        private TransportistaNegocio transportistaNeg;

        public BuscarMovilidadTransportePersonalCampo()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public BuscarMovilidadTransportePersonalCampo(string _tipoMovimiento)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.tipoMovimiento = _tipoMovimiento;
        }

        private void ObtenerListaTransportistas()
        {
            switch (tipoMovimiento)
            {
                case "INTERLOCALIDAD": // Externo
                    transportistaNeg = new TransportistaNegocio();
                    ListadoTransportista = new List<SJ_RHListarTransportistasResult>();
                    var obtenerResultado = transportistaNeg.ListarTransportistasActivos().Where(x => x.EsInterLocal.Value == 1).ToList();
                    ListadoTransportista = AgruparByPlaca(obtenerResultado);

                    break;
                case "INTERNO": //Interno
                    transportistaNeg = new TransportistaNegocio();
                    ListadoTransportista = new List<SJ_RHListarTransportistasResult>();
                    ListadoTransportista = transportistaNeg.ListarTransportistasActivos().Where(x => x.EsMovilidadLocal.Value == 1 && x.PrecioVuelta > 0 && x.PrecioVuelta < 12).ToList();
                    //var obtenerResultado2 = transportistaNeg.ListarTransportistasActivos().Where(x => x.EsMovilidadLocal.Value == 1).ToList();
                    //ListadoTransportista = AgruparByPlaca(obtenerResultado2);

                    break;
                case "AMBOS": //Interno
                    transportistaNeg = new TransportistaNegocio();
                    ListadoTransportista = new List<SJ_RHListarTransportistasResult>();

                    ListadoTransportista = (from items in transportistaNeg.ListarTransportistasActivos().ToList()
                                            where items.RUC != null
                                            group items by new { items.RUC , items.Placa } into j
                                            select new SJ_RHListarTransportistasResult
                                            {
                                                Id = 0,

                                                RUC = j.Key.RUC.ToString().Trim(),
                                                RazonSocial = j.FirstOrDefault().RazonSocial != null ? Convert.ToString(j.FirstOrDefault().RazonSocial).Trim() : "",
                                                Placa = j.Key.Placa.ToString().Trim(),
                                                PseudoNombre = j.FirstOrDefault().PseudoNombre != null ? Convert.ToString(j.FirstOrDefault().PseudoNombre).Trim() : "",
                                                IdTipoMovilidad = "Varios",
                                                TipoMovilidad = "Varios",
                                                NumeroAsientos = 0,
                                                PesoMaximo = 0,
                                                EsMovilidadLocal = 1,
                                                EsInterLocal = 1,
                                                AnioFabricacion = "2014",
                                                Marca = "Varios",
                                                Modelo = "Varios",
                                                IdEstado = "AC",
                                                Estado = "ACTIVO",
                                                PrecioVuelta = 0,
                                            }).ToList();

                    break;
                default:
                    transportistaNeg = new TransportistaNegocio();
                    ListadoTransportista = new List<SJ_RHListarTransportistasResult>();
                    break;
            }



            MostrarListarTransportista();

        }

        private List<SJ_RHListarTransportistasResult> AgruparByPlaca(List<SJ_RHListarTransportistasResult> ListadoTransportista)
        {
            List<SJ_RHListarTransportistasResult> nuevaListado = new List<SJ_RHListarTransportistasResult>();
            if (ListadoTransportista != null && ListadoTransportista.ToList().Count > 0)
            {

                var listadoCodigoUnicoTransportista = (from item in ListadoTransportista
                                                       where item.Id != null && item.Id > 0
                                                       group item by new { item.Id , item.Placa} into j
                                                       select new
                                                       {
                                                           codigo = j.Key.Id,
                                                           nroPlaca = j.Key.Placa,
                                                       }).ToList();


                if (listadoCodigoUnicoTransportista != null && listadoCodigoUnicoTransportista.ToList().Count > 0)
                {
                    foreach (var codigoByPlaca in listadoCodigoUnicoTransportista)
                    {
                        var resultadoConsulta = ListadoTransportista.Where(x => x.Id == codigoByPlaca.codigo).ToList();
                        SJ_RHListarTransportistasResult oPlaca = new SJ_RHListarTransportistasResult();
                        oPlaca.Id = codigoByPlaca.codigo;
                        oPlaca.RUC = resultadoConsulta.FirstOrDefault().RUC != null ? resultadoConsulta.FirstOrDefault().RUC.ToString().Trim() : "";
                        oPlaca.RazonSocial = resultadoConsulta.FirstOrDefault().RazonSocial != null ? resultadoConsulta.FirstOrDefault().RazonSocial.ToString().Trim() : "";
                        //oPlaca.Placa = resultadoConsulta.FirstOrDefault().Placa != null ? resultadoConsulta.FirstOrDefault().Placa.ToString().Trim() : "";

                        oPlaca.Placa = codigoByPlaca.nroPlaca; /*agregado el 12.04.16 */
                        oPlaca.PseudoNombre = resultadoConsulta.FirstOrDefault().PseudoNombre != null ? resultadoConsulta.FirstOrDefault().PseudoNombre.ToString().Trim() : "";
                        oPlaca.IdTipoMovilidad = resultadoConsulta.FirstOrDefault().IdTipoMovilidad != null ? resultadoConsulta.FirstOrDefault().IdTipoMovilidad.ToString().Trim() : "";
                        oPlaca.TipoMovilidad = resultadoConsulta.FirstOrDefault().TipoMovilidad != null ? resultadoConsulta.FirstOrDefault().TipoMovilidad.ToString().Trim() : "";
                        oPlaca.NumeroAsientos = resultadoConsulta.FirstOrDefault().NumeroAsientos != null ? resultadoConsulta.FirstOrDefault().NumeroAsientos : 0;
                        oPlaca.PesoMaximo = resultadoConsulta.FirstOrDefault().PesoMaximo != null ? resultadoConsulta.FirstOrDefault().PesoMaximo : 0;
                        oPlaca.EsMovilidadLocal = resultadoConsulta.FirstOrDefault().EsMovilidadLocal != null ? resultadoConsulta.FirstOrDefault().EsMovilidadLocal : 0;
                        oPlaca.EsInterLocal = resultadoConsulta.FirstOrDefault().EsInterLocal != null ? resultadoConsulta.FirstOrDefault().EsInterLocal : 0;
                        oPlaca.AnioFabricacion = resultadoConsulta.FirstOrDefault().AnioFabricacion != null ? resultadoConsulta.FirstOrDefault().AnioFabricacion.ToString().Trim() : "";
                        oPlaca.Marca = resultadoConsulta.FirstOrDefault().Marca != null ? resultadoConsulta.FirstOrDefault().Marca.ToString().Trim() : "";
                        oPlaca.Modelo = resultadoConsulta.FirstOrDefault().Modelo != null ? resultadoConsulta.FirstOrDefault().Modelo.ToString().Trim() : "";
                        oPlaca.IdEstado = resultadoConsulta.FirstOrDefault().IdEstado != null ? resultadoConsulta.FirstOrDefault().IdEstado.ToString().Trim() : "";
                        oPlaca.item = "";
                        oPlaca.Estado = resultadoConsulta.FirstOrDefault().Estado != null ? resultadoConsulta.FirstOrDefault().Estado.ToString().Trim() : "";
                        oPlaca.PrecioVuelta = 0;
                        nuevaListado.Add(oPlaca);
                    }
                }


            }
            return nuevaListado;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void dgvTransportista_SelectionChanged(object sender, EventArgs e)
        {
            oMovilidad = new SJ_RHListarTransportistasResult();
            oMovilidad.Id = 0;
            oMovilidad.Placa = "";
            oMovilidad.RUC = "";
            oMovilidad.RazonSocial = "";
            oMovilidad.NumeroAsientos = 0;
            oMovilidad.PseudoNombre = "";
            oMovilidad.TipoMovilidad = "";
            oMovilidad.PrecioVuelta = 0;
            oMovilidad.item = "";

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
                    oMovilidad.PrecioVuelta = dgvTransportista.CurrentRow.Cells["chPrecioVuelta"].Value != null ? Convert.ToDecimal(dgvTransportista.CurrentRow.Cells["chPrecioVuelta"].Value) : 0;
                    oMovilidad.item = dgvTransportista.CurrentRow.Cells["chItem"].Value != null ? Convert.ToString(dgvTransportista.CurrentRow.Cells["chItem"].Value) : "";
                }
            }

        }

    }
}
