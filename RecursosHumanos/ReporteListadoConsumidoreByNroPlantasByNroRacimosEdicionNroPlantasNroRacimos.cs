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
    public partial class ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos : Form
    {
        private string codigoConsumidor;
        private string consumidorDescripcion;
        private ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult oConsumidor;
        private DCONSUMIDOR_SIEMBRA oDConsumidorSiembra;
        private ASJ_ConsumidorByRacimo oConsumidorByRacimo;
        private DCONSUMIDOR_SIEMBRANegocio modeloNroPlanta;
        private ASJ_ConsumidorByRacimoNegocio modeloNroRacimo;

        public ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos()
        {
            InitializeComponent();
        }



        public ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos(string codigoConsumidor, string consumidorDescripcion, ASJ_ObtenerListadoConsumidorByAreaByRacimoNyNumeroPlantasResult oConsumidor) 
        {
            InitializeComponent();
            this.codigoConsumidor = codigoConsumidor;
            this.consumidorDescripcion = consumidorDescripcion;
            this.oConsumidor = oConsumidor;
            this.txtNroPlantas.Value = oConsumidor.numeroPlantas;
            this.txtNumeroRacimos.Value = oConsumidor.racimos;
            this.txtConsumidorCodigo.Text = codigoConsumidor;
            this.txtConsumidorDescripcion.Text = consumidorDescripcion;
            this.txtNroPlantas.Value = oConsumidor.numeroPlantas;
            this.txtNumeroRacimos.Value = oConsumidor.racimos;

        }

        private void btnRegistrarYSalir_Click(object sender, EventArgs e)
        {
            if (this.txtConsumidorCodigo.Text  != string.Empty && this.txtConsumidorDescripcion.Text != string.Empty)
            {
                oDConsumidorSiembra = new DCONSUMIDOR_SIEMBRA();
                oDConsumidorSiembra.idconsumidor = this.codigoConsumidor;
                oDConsumidorSiembra.idsiembra = this.oConsumidor.codigoSiembra.Trim();
                oDConsumidorSiembra.nroplantas = this.txtNroPlantas.Value;

                oConsumidorByRacimo = new ASJ_ConsumidorByRacimo();
                oConsumidorByRacimo.idConsumidor = this.codigoConsumidor;
                oConsumidorByRacimo.numeroRacimos = this.txtNumeroRacimos.Value;

                Grabar();
            }
            
        }

        private void Grabar(  )
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

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos_Load(object sender, EventArgs e)
        {

        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            modeloNroPlanta = new DCONSUMIDOR_SIEMBRANegocio();
            modeloNroRacimo = new ASJ_ConsumidorByRacimoNegocio();
            modeloNroPlanta.ActualizarNumeroPlantasEnConsumidor(oDConsumidorSiembra);
            modeloNroRacimo.Registrar(oConsumidorByRacimo);



        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Proceso satisfactorio", "MENSAJE DEL SISTEMA");
            gbConsumidor.Enabled = false;
            gbDatosAModificar.Enabled = false;
        }
    }
}
