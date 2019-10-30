using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using RecursosHumanos.Negocios;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using System.Configuration;


namespace RecursosHumanos
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
                codHistorial = "001" + idHistorial;
                this.tabla = tabla;
                this.formulario = oFormulario;
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }



        private void Historial_Load(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            if (formulario == "0") /*0 ES PROPIO*/
            {
                listadoHistorial = new List<HistorialObj>();
                negocios = new HistorialNegocio();

                listadoHistorial = negocios.ListarHistorial(codHistorial.ToString().Trim().PadLeft(16, '0'), tabla).ToList();
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (listadoHistorial != null)
            {
                dgvHistorial.CargarDatos(listadoHistorial.ToDataTable<HistorialObj>());
                dgvHistorial.Refresh();

            }
        }
    }
}
