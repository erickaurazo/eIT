using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using RecursosHumanos.Negocios;
using System.Linq;
using RecursosHumanos.Datos;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;

namespace RecursosHumanos
{
    public partial class PersonalBloqueado : Form
    {
        private List<ASJ_ObtenerListadoDePersonalbloqueadoResult> listado;
        private Asj_PersonalbloqueoNegocio modelo;

        public PersonalBloqueado()
        {
            InitializeComponent();
        }

        private void PersonalBloqueado_Load(object sender, EventArgs e)
        {
            gbListado.Enabled = false;
            gbMantenimientoRegistros.Enabled = false;
            ProgressBar.Visible = true;
            mnPrincipal.Enabled = false;
            bgwHilo.RunWorkerAsync();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            listado = new List<ASJ_ObtenerListadoDePersonalbloqueadoResult>();
            modelo = new Asj_PersonalbloqueoNegocio();

            listado = modelo.ObtenerListadoDePersonalbloqueado(DateTime.Now.Year.ToString()).ToList();

        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvRegistros.DataSource = listado.ToDataTable<ASJ_ObtenerListadoDePersonalbloqueadoResult>();
            dgvRegistros.Refresh();
            gbListado.Enabled = !false;
            gbMantenimientoRegistros.Enabled = !false;
            ProgressBar.Visible = !true;
            mnPrincipal.Enabled = !false;

        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            gbListado.Enabled = false;
            gbMantenimientoRegistros.Enabled = false;
            ProgressBar.Visible = true;
            mnPrincipal.Enabled = false;
            bgwHilo.RunWorkerAsync();
        }
    }
}
