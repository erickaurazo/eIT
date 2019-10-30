using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Transportista
{
    public partial class MovimientoRecorridos : Telerik.WinControls.UI.RadForm
    {
        public MovimientoRecorridos()
        {
            InitializeComponent();
            btnNuevo.Enabled = false;
        }

        private void MovimientoRecorridos_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (rbtInterLocalidades.IsChecked == true)
            {
                MovimientoRecorridosMantenimiento oFormulario = new MovimientoRecorridosMantenimiento("InterLocalidad");
                oFormulario.Show();
                oFormulario.WindowState = FormWindowState.Maximized;  
            }

            if (rbtInternos.IsChecked == true)
            {
                MovimientoRecorridosMantenimiento oFormulario = new MovimientoRecorridosMantenimiento("Interno");
                oFormulario.Show();
                oFormulario.WindowState = FormWindowState.Maximized;                              
            }
        }

        private void rbtTodos_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            btnNuevo.Enabled = false;
        }

        private void rbtInterLocalidades_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            btnNuevo.Enabled = true;
        }

        private void rbtInternos_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            btnNuevo.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

       
    }
}
