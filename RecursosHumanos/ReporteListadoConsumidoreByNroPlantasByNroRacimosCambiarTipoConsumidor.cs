using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecursosHumanos
{
    public partial class ReporteListadoConsumidoreByNroPlantasByNroRacimosCambiarTipoConsumidor : Form
    {
        private string codigoConsumidor;
        private string consumidorDescripcion;
        private ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult oConsumidor;
        private ConsumidorEtiquetaNegocio consumidorEtiquetaNegocio;
        private List<CONSUMIDORETIQUETA> listadoEtiquetas;
        private CONSUMIDOR oConsumidorEdicion;
        private ConsumidorNegocio modeloConsumidor;

        public ReporteListadoConsumidoreByNroPlantasByNroRacimosCambiarTipoConsumidor()
        {
            InitializeComponent();
            LlenarCombo();
        }

        public ReporteListadoConsumidoreByNroPlantasByNroRacimosCambiarTipoConsumidor(string codigoConsumidor, string consumidorDescripcion, ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult oConsumidor)
        {
            InitializeComponent();
            LlenarCombo();
            this.codigoConsumidor = codigoConsumidor;
            this.consumidorDescripcion = consumidorDescripcion;
            this.oConsumidor = oConsumidor;

            this.txtConsumidorCodigo.Text = codigoConsumidor;
            this.txtConsumidorDescripcion.Text = consumidorDescripcion;
            this.cboEtiquetaConsumidor.SelectedValue = oConsumidor.tipo;



        }

        private void LlenarCombo()
        {


            listadoEtiquetas = new List<CONSUMIDORETIQUETA>();
            consumidorEtiquetaNegocio = new ConsumidorEtiquetaNegocio();
            listadoEtiquetas = consumidorEtiquetaNegocio.ObtenerListadoEtiquetasByConsumidor();

            cboEtiquetaConsumidor.DisplayMember = "descripcion";
            cboEtiquetaConsumidor.ValueMember = "simbolo";
            cboEtiquetaConsumidor.DataSource = listadoEtiquetas;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReporteListadoConsumidoreByNroPlantasByNroRacimosCambiarTipoConsumidor_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarYSalir_Click(object sender, EventArgs e)
        {

            if (this.txtConsumidorCodigo.Text != string.Empty && this.txtConsumidorDescripcion.Text != string.Empty)
            {
                oConsumidorEdicion = new CONSUMIDOR();
                oConsumidorEdicion.IDCONSUMIDOR = this.txtConsumidorCodigo.Text.Trim();
                oConsumidorEdicion.IDEMPRESA = "001";
                oConsumidorEdicion.TIPO = Convert.ToChar(cboEtiquetaConsumidor.SelectedValue.ToString().Trim());
                Grabar();
            }
           
        }

        private void Grabar()
        {
            try
            {
                bwgHilo.RunWorkerAsync();
                gbConsumidor.Enabled = false;
                gbDatosAModificar.Enabled = false;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            modeloConsumidor = new ConsumidorNegocio();
            modeloConsumidor.ActualizarEtiquetaConsumidor(oConsumidorEdicion);

        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Proceso satisfactorio", "MENSAJE DEL SISTEMA");
            gbConsumidor.Enabled = !false;
            gbDatosAModificar.Enabled = !false;
        }
    }
}
