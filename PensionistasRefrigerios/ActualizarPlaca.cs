using System;
using System.ComponentModel;
using System.Windows.Forms;
using MyControlsDataBinding.Extensions;
using System.Configuration;
using Asistencia.Datos;
using Asistencia.Negocios;


namespace Asistencia
{
    public partial class ActualizarPlaca : Form
    {
        
        private SJ_ListarAsistenciaSalidaUnidadesTransportePersonalByPeriodoResult registroResumen;
        private RegistroTransferenciaTransportesController negocio;
        private string placaNueva;
        private string codigoRuta;
        private string _conection;
        private SJ_ListarAsistenciaSalidaUnidadesTransportePersonalByPeriodoResult _registroResumen;

        public ActualizarPlaca()
        {
            InitializeComponent();
            Inicio();
        }

        public ActualizarPlaca(SJ_ListarAsistenciaSalidaUnidadesTransportePersonalByPeriodoResult registroResumen, string conection, string companyId, ASJ_USUARIOS user)
        {
            InitializeComponent();
            Inicio();
            _conection = conection;
            _registroResumen = registroResumen;
            
            txtFecha.Text = _registroResumen.fecha;
            txtEmpresaTransporteRUC.Text = _registroResumen.categoriaMovilidad != null ? _registroResumen.categoriaMovilidad : string.Empty;
            txtEmpresaTransporte.Text = _registroResumen.empresaTransporte != null ? _registroResumen.empresaTransporte : string.Empty;
            txtPlaca.Text = _registroResumen.placa != null ? _registroResumen.placa : string.Empty;
            txtRuta.Text = _registroResumen.ruta != null ? _registroResumen.ruta : string.Empty;

        }

        public void Inicio()
        {
            try
            {                
                Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                Globales.BaseDatos = ConfigurationManager.AppSettings[_conection].ToString();
                Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                Globales.IdEmpresa = "001";
                Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                Globales.UsuarioSistema = "EAURAZO";
                Globales.NombreUsuarioSistema = "ERICK AURAZO";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ActualizarPlaca_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            placaNueva = this.txtPlacaCodigoNuevo.Text.Trim();
            codigoRuta = this.txtRutaCodigo.Text.Trim();
            gbDestino.Enabled = false;
            gbRegistro.Enabled = false;

            bgwHilo.RunWorkerAsync();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            negocio = new RegistroTransferenciaTransportesController();
            negocio.UpdatePlaca(_conection, registroResumen, placaNueva, codigoRuta);
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("ACTUALIZACION SATISFACTORIA", "MENSAJE DEL SISTEMA");
            gbDestino.Enabled = !false;
            gbRegistro.Enabled = !false;
            
        }
    }
}
