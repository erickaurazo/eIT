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


namespace RecursosHumanos
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }



        private void Sistema_Click(object sender, EventArgs e)
        {

        }

        private void horasEfectivasTrabajadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiasEfectivosRemunerados frmHijo = new DiasEfectivosRemunerados();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void movilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Transportista frmHijo = new Transportista();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }



        private void recorridosInternosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MovimientoRecorridosMantenimiento frmHijo = new MovimientoRecorridosMantenimiento("Interno");
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void RecorridoInterLocalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MovimientoRecorridosMantenimiento frmHijo = new MovimientoRecorridosMantenimiento("InterLocalidad");
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void recorridoDeMovilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MovimientoRecorridos frmHijo = new MovimientoRecorridos();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void fleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Rutas frmHijo = new Rutas();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;

        }

        private void movilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void personalLiquidadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiquidacionPersonal frmHijo = new LiquidacionPersonal();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void privilegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Privilegios frmHijo = new Privilegios();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios frmHijo = new Usuarios();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;

        }

        private void reporteDeAsistenciaSemanal_Click(object sender, EventArgs e)
        {
            
        }

        private void ingresoSalidaEnPuertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlIngresoSalidaPersonal frmHijo = new ControlIngresoSalidaPersonal();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
            
        }
    }
}
