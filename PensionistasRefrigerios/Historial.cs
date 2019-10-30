using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Transportista.Negocios;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using System.Configuration;
using TransportistaMto.Datos;


namespace Transportista
{
    public partial class Historial : Form
    {

        List<HistorialObj> listadoHistorial;
        HistorialNegocio negocios;
        string codHistorial, formulario = string.Empty;
        private string tabla;

        public Historial()
        {
            InitializeComponent();
        }


        public Historial(string idHistorial, string oFormulario, string tabla)
        {

            try
            {
                InitializeComponent();
                codHistorial = idHistorial;
                this.tabla = tabla;
                this.formulario = oFormulario;
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }


        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                if (formulario == "0") /*0 ES PROPIO*/
                {
                    listadoHistorial = new List<HistorialObj>();
                    negocios = new HistorialNegocio();

                    listadoHistorial = negocios.ListarHistorialSJ(codHistorial.ToString().Trim().PadLeft(16, '0'), tabla).ToList();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (listadoHistorial != null)
                {
                    dgvHistorial.CargarDatos(listadoHistorial.ToDataTable<HistorialObj>());
                    dgvHistorial.Refresh();

                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void Historial_Load(object sender, EventArgs e)
        {

        }
    }
}
