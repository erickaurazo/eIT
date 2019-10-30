using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Configuration;
using Transportista.Datos;
using Transportista.Negocios;


namespace Transportista
{
    public partial class MovimientoRecorridosMantenimiento : Telerik.WinControls.UI.RadForm
    {
        private string Periodo;
        private DocumentoNeg documentoNeg;
        private List<Grupo> ListaSerie;
        private List<Grupo> ListaIdDocumento;

        public MovimientoRecorridosMantenimiento()
        {
            InitializeComponent();
            Inicio();
            CargarDatosIniciales();
        }



        private void CargarDatosIniciales()
        {
            this.txtFechaMovimientoInterlocalidad.Text = DateTime.Now.ToShortDateString();
            this.txtFechaMovimientoInterno.Text = DateTime.Now.ToShortDateString();
        }

        public MovimientoRecorridosMantenimiento(string TabSelecionado)
        {
            InitializeComponent();

            switch (TabSelecionado)
            {
                case "InterLocalidad":
                    tabRegistros.SelectedPage = tabRecorridoInterLocalidad;
                    this.tabRegistros.Pages.Remove(tabRecorridoInterno);
                    Inicio();
                    CargarDatosIniciales();
                    MostrarCboIdDocumento("INTERLOCALIDAD");
                    MostrarCboSerie("INTERLOCALIDAD");
                    break;

                case "Interno":
                    tabRegistros.SelectedPage = tabRecorridoInterno;
                    this.tabRegistros.Pages.Remove(tabRecorridoInterLocalidad);
                    Inicio();
                    CargarDatosIniciales();
                    MostrarCboIdDocumento("INTERNO");
                    MostrarCboSerie("INTERNO");
                    break;
                default:
                    Inicio();
                    CargarDatosIniciales();
                    break;
            }
        }

        private void MostrarCboSerie(string tipoMovimiento)
        {
            documentoNeg = new DocumentoNeg();
            ListaSerie = new List<Grupo>();
            ListaSerie = documentoNeg.ObtenerNumeroSerie(tipoMovimiento);

            if (ListaSerie != null)
            {
                cboIdSerieInterLocalidad.DataSource = ListaSerie;
                cboIdSerieInterLocalidad.DisplayMember = "Codigo";
                cboIdSerieInterLocalidad.ValueMember = "Descripcion";
                cboIdSerieInterLocalidad.SelectedIndex = 0;
                //cboIdSerieInterLocalidad.Enabled = false;

                cboSerieInterno.DataSource = ListaSerie;
                cboSerieInterno.DisplayMember = "Codigo";
                cboSerieInterno.ValueMember = "Descripcion";
                cboSerieInterno.SelectedIndex = 0;
                //cboSerieInterno.Enabled = false;

                string NumeroDocumentoInterLocal, NumeroDocumentoIntero = string.Empty;
                NumeroDocumentoInterLocal = documentoNeg.ObtenerNumeroDocumento(tipoMovimiento, cboIdSerieInterLocalidad.SelectedValue.ToString().Trim());
                NumeroDocumentoIntero = documentoNeg.ObtenerNumeroDocumento(tipoMovimiento, cboSerieInterno.SelectedValue.ToString().Trim());

                txtNumeroDocumentoInterLocalidad.Text = NumeroDocumentoInterLocal;
                txtNumeroDocumentoInterno.Text = NumeroDocumentoIntero;

                this.txtIdEstadoInterlocalidad.Text = "PE";
                this.txtIdEstadoInterno.Text = "PE";

                this.txtEstadoInterLocalidad.Text = "PENDIENTE";
                this.txtEstadoInterno.Text = "PENDIENTE";

            }

        }

        private void MostrarCboIdDocumento(string tipoMovimiento)
        {
            documentoNeg = new DocumentoNeg();
            ListaIdDocumento = new List<Grupo>();
            ListaIdDocumento = documentoNeg.ObtenerIdDocumento(tipoMovimiento);

            if (ListaIdDocumento != null)
            {
                cboIdDocumentoInterLocalidad.DataSource = ListaIdDocumento;
                cboIdDocumentoInterLocalidad.DisplayMember = "Codigo";
                cboIdDocumentoInterLocalidad.ValueMember = "Descripcion";
                cboIdDocumentoInterLocalidad.SelectedIndex = 0;
                //cboIdDocumentoInterLocalidad.Enabled = false;

                cboIdDocumentoInterno.DataSource = ListaIdDocumento;
                cboIdDocumentoInterno.DisplayMember = "Codigo";
                cboIdDocumentoInterno.ValueMember = "Descripcion";
                cboIdDocumentoInterno.SelectedIndex = 0;
                //cboIdDocumentoInterno.Enabled = false;
            }
        }

        public void Inicio()
        {
            try
            {
                Periodo = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + Periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SANJUAN SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "CHRISTIAN";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Christian LLontop";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        private void RegistroMovimientoMovilidad_Load(object sender, EventArgs e)
        {

        }



        private void btnBuscarMovilidad_Click(object sender, EventArgs e)
        {
            MovilidadBuscar ofrm = new MovilidadBuscar("INTERLOCALIDAD");
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                if (ofrm.oMovilidad != null)
                {
                    this.txtPlacaInterLocalidad.Text = ofrm.oMovilidad.Placa;
                    this.txtRUCInterlocalidad.Text = ofrm.oMovilidad.RUC;
                    this.txtRazonSocialInterlocalidad.Text = ofrm.oMovilidad.RazonSocial;
                    this.txtPseudonombreInterlocalidad.Text = ofrm.oMovilidad.PseudoNombre;
                    this.txtNroAsientosInterlocalidad.Text = ofrm.oMovilidad.NumeroAsientos.ToString();
                    this.txtTipoMovilidadInterLocalidad.Text = ofrm.oMovilidad.TipoMovilidad.ToString();
                    this.txtIdMovil.Text = ofrm.oMovilidad.Id.ToString();

                    if (ofrm.oMovilidad.Placa.ToString().Trim() != string.Empty)
                    {
                        gbRegistroPersonas.Enabled = true;
                        gbProcedenciaInterlocalidad.Enabled = true;
                        gbRegistroMovimientoInterlocalidad.Enabled = true;

                    }
                    else
                    {
                        gbRegistroPersonas.Enabled = false;
                        gbProcedenciaInterlocalidad.Enabled = false;
                        gbRegistroMovimientoInterlocalidad.Enabled = false;


                        this.txtRutaDestino.Clear();
                        this.txtCodigoRutaDestino.Clear();
                        this.txtPrecioDestinoInterprocedencia.Clear();
                        this.txtCodigoRutaOrigen.Clear();
                        this.txtRutaOrigen.Clear();
                        this.txtPrecioProcedenciaInterlocalidad.Clear();
                    }


                }
                else
                {
                    gbRegistroPersonas.Enabled = false;
                    gbProcedenciaInterlocalidad.Enabled = false;
                    gbRegistroMovimientoInterlocalidad.Enabled = false;
                }
            }
        }

        private void rbtIdaVuelta_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.btnBuscarRutaDestino.Enabled = true;
            this.btnBuscarRutaOrigen.Enabled = true;

            this.txtCodigoRutaDestino.Enabled = true;
            this.txtCodigoRutaOrigen.Enabled = true;

            this.txtRutaDestino.Enabled = true;
            this.txtRutaOrigen.Enabled = true;

        }

        private void rbtIda_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.btnBuscarRutaDestino.Enabled = false;
            this.btnBuscarRutaOrigen.Enabled = true;

            this.txtCodigoRutaDestino.Enabled = false;
            this.txtCodigoRutaOrigen.Enabled = true;

            this.txtRutaDestino.Enabled = false;
            this.txtRutaOrigen.Enabled = true;

            this.txtRutaDestino.Clear();
            this.txtCodigoRutaDestino.Clear();

            this.txtPrecioDestinoInterprocedencia.Clear();

        }

        private void rbtVuelta_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            this.btnBuscarRutaDestino.Enabled = true;
            this.btnBuscarRutaOrigen.Enabled = false;

            this.txtCodigoRutaDestino.Enabled = true;
            this.txtCodigoRutaOrigen.Enabled = false;

            this.txtRutaDestino.Enabled = true;
            this.txtRutaOrigen.Enabled = false;

            this.txtRutaOrigen.Clear();
            this.txtCodigoRutaOrigen.Clear();
            this.txtPrecioProcedenciaInterlocalidad.Clear();
        }





        private void rbtNumeroPersonas_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (this.txtPlacaInterLocalidad.Text.ToString().Trim() != string.Empty)
            {
                gbRegistroPersonas.Enabled = true;
            }
            else
            {
                gbRegistroPersonas.Enabled = false;
            }
        }

        private void rbtFlete_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (this.txtPlacaInterLocalidad.Text.ToString().Trim() != string.Empty)
            {
                gbRegistroPersonas.Enabled = true;
            }
            else
            {
                gbRegistroPersonas.Enabled = false;
            }
        }

        private void btnBuscarRutaOrigen_Click(object sender, EventArgs e)
        {
            RutaBuscar ofrm = new RutaBuscar(this.txtIdMovil.Text.ToString().Trim(), this.txtCodigoRutaDestino.Text);
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                if (ofrm.oRuta != null)
                {
                    if (ofrm.oRuta.IdRuta.ToString().Trim() != string.Empty)
                    {
                        this.txtCodigoRutaOrigen.Text = ofrm.oRuta.IdRuta.ToString();
                        this.txtRutaOrigen.Text = ofrm.oRuta.Ruta.ToString().Trim();

                        if (this.rbtFlete.IsChecked == true)
                        {
                            this.txtPrecioProcedenciaInterlocalidad.Text = ofrm.oRuta.PrecioFlete.ToString().Trim();
                            RealizarCalculo();
                        }
                        else
                        {
                            this.txtPrecioProcedenciaInterlocalidad.Text = ofrm.oRuta.PrecioPersona.ToString().Trim();
                            RealizarCalculo();
                        }
                    }
                    else
                    {
                        this.txtCodigoRutaOrigen.Clear();
                        this.txtRutaOrigen.Clear();
                        this.txtPrecioProcedenciaInterlocalidad.Clear();
                        RealizarCalculo();
                    }
                }
                else
                {

                }
            }
        }

        private void RealizarCalculo()
        {
            decimal? MontoxRutaOrigen, MontoxRutaDestino, CantidadPersona, Precio, SubTotal, IGV, Total = 0;
            MontoxRutaOrigen = (this.txtPrecioProcedenciaInterlocalidad.Text.ToString().Trim() != "" | this.txtPrecioProcedenciaInterlocalidad.Text != null) ? Convert.ToDecimal(this.txtPrecioProcedenciaInterlocalidad.Text.ToString().Trim()) : 0;
            MontoxRutaDestino = (this.txtPrecioDestinoInterprocedencia.Text.ToString().Trim() != "" ) ? Convert.ToDecimal(this.txtPrecioDestinoInterprocedencia.Text.ToString().Trim()) : 0;
            CantidadPersona = (this.txtNumeroPersonasInterlocalidad.Text.ToString().Trim() != "" ) ? Convert.ToDecimal(this.txtNumeroPersonasInterlocalidad.Text.ToString().Trim()) : 0;


            if (MontoxRutaOrigen != (decimal?)null || MontoxRutaDestino != (decimal?)null || CantidadPersona != (decimal?)null)
            {
                Precio = (MontoxRutaOrigen + MontoxRutaDestino);
                SubTotal = (Precio * CantidadPersona);
                IGV = (SubTotal * Convert.ToDecimal(0.18));
                Total = SubTotal + IGV;

                txtPrecioInterlocalidad.Text = Precio.Value.ToString();
                txtSubTotalInterlocalidad.Text = SubTotal.Value.ToString();
                txtIGVInterlocalidad.Text = IGV.Value.ToString();
                txtTotalInterlocalidad.Text = Total.Value.ToString();


            }
            else
            {
                txtPromedioPersona.Clear();
                txtPrecioInterlocalidad.Clear();
                txtSubTotalInterlocalidad.Clear();
                txtIGVInterlocalidad.Clear();
                txtTotalInterlocalidad.Clear();
            }
        }

        private void btnBuscarRutaDestino_Click(object sender, EventArgs e)
        {
            RutaBuscar ofrm = new RutaBuscar(this.txtIdMovil.Text.ToString().Trim(), txtCodigoRutaOrigen.Text.ToString().Trim());
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                if (ofrm.oRuta != null)
                {
                    if (ofrm.oRuta.IdRuta.ToString().Trim() != string.Empty)
                    {
                        this.txtCodigoRutaDestino.Text = ofrm.oRuta.IdRuta.ToString();
                        this.txtRutaDestino.Text = ofrm.oRuta.Ruta.ToString().Trim();

                        if (this.rbtFlete.IsChecked == true)
                        {
                            this.txtPrecioDestinoInterprocedencia.Text = ofrm.oRuta.PrecioFlete.ToString().Trim();
                            RealizarCalculo();
                        }
                        else
                        {
                            this.txtPrecioDestinoInterprocedencia.Text = ofrm.oRuta.PrecioPersona.ToString().Trim();
                            RealizarCalculo();
                        }
                    }
                    else
                    {
                        this.txtCodigoRutaDestino.Clear();
                        this.txtRutaDestino.Clear();
                        this.txtPrecioDestinoInterprocedencia.Clear();
                        RealizarCalculo();
                    }
                }
                else
                {

                }
            }
        }

        private void txtNumeroPersonasInterlocalidad_Leave(object sender, EventArgs e)
        {
            RealizarCalculo();
        }

        private void btnBuscarMovilInterno_Click(object sender, EventArgs e)
        {

        }










    }
}
