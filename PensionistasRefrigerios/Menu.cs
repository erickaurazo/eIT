using Asistencia.Datos;
using Asistencia.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asistencia
{
    public partial class Menu : Form
    {
        private ASJ_USUARIOS _user;
        private string _companyId;
        private string _conection;
        private UsersController modelPrivileges;
        private List<PrivilegesByUser> privilegesByUser;

        public Menu()
        {
            InitializeComponent();
            Login ofrm = new Login();
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("Bienvenido al Sistema", "Mensaje de Bienvenida");                
                _user = ofrm.user;
                _companyId = ofrm.companyId != null ? ofrm.companyId.Trim() : string.Empty;
                _conection = ofrm.conection != null ? ofrm.conection.Trim() : string.Empty;
                bgwHilo.RunWorkerAsync();
            }
            else
            {
                this.Dispose();
                this.Close();
            }
            //ActivarModulo(string.Empty, this);
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void ActivarModulo(string nombreModulo, Control control)
        {
            foreach (var opcion in control.Controls)
            {
                if (opcion is System.Windows.Forms.MenuStrip)
                {
                    foreach (ToolStripMenuItem mnuitOpcion in menuStrip.Items)
                    {
                        // si esta opción despliega un submenú
                        // llamar a un método para hacer cambios
                        // en las opciones del submenú
                        if (mnuitOpcion.DropDownItems.Count > 0)
                        {
                            CambiarOpcionesMenu(mnuitOpcion.DropDownItems, nombreModulo);
                        }
                    }
                }
            }

            //CajaBancos.Enabled = true;
            //CajaBancos.Visible = true;
            GoSistema.Enabled = true;
            GoSistema.Visible = true;
            GoTransporte.Enabled = true;
            GoTransporte.Visible = true;
            GoPlanilla.Enabled = true;
            GoPlanilla.Visible = true;
            GoExportaciones.Enabled = true;
            GoMantenimiento.Enabled = true;
            GoMaquinaria.Enabled = true;
            GoSanidad.Enabled = true;
            GoEvaluacionAgricola.Enabled = true;
            GoSistema.Enabled = true;
            GoSalir.Enabled = true;

            GoExportaciones.Visible = true;
            GoMantenimiento.Visible = true;
            GoMaquinaria.Visible = true;
            GoSanidad.Visible = true;
            GoEvaluacionAgricola.Visible = true;
            GoSistema.Visible = true;
            GoSalir.Visible = true;

        }

        public void CambiarOpcionesMenu(ToolStripItemCollection colOpcionesMenu, string nombreModulo)
        {
            if (this.bgwHilo.IsBusy != true)
            {
                // recorrer el submenú
                foreach (ToolStripItem itmOpcion in colOpcionesMenu)
                {
                    // restaurar el tipo de letra original
                    // si es una opción de menú normal...
                    if (itmOpcion.GetType() == typeof(ToolStripMenuItem))
                    {
                        // OJO que hay que colocar el texto que contiene el elemento ej. Imprimir
                        if (itmOpcion.Name.ToUpper().Contains("GoPlanilla".ToUpper()) && nombreModulo.ToUpper() == "GoPlanilla".ToUpper())
                        {
                            //Aqui lo deshabilitamos
                            ((ToolStripMenuItem)itmOpcion).Enabled = true;
                            ((ToolStripMenuItem)itmOpcion).Visible = true;
                        }
                        else if (itmOpcion.Name.ToUpper().Contains("GoTransportes".ToUpper()) && nombreModulo.ToUpper() == "GoTransportes".ToUpper())
                        {
                            ((ToolStripMenuItem)itmOpcion).Enabled = true;
                            ((ToolStripMenuItem)itmOpcion).Visible = true;
                        }
                        else if (itmOpcion.Name.ToUpper().Contains("GoSistema".ToUpper()) && nombreModulo.ToUpper() == "GoSistema".ToUpper())
                        {
                            ((ToolStripMenuItem)itmOpcion).Enabled = true;
                            ((ToolStripMenuItem)itmOpcion).Visible = true;
                        }
                        else
                        {
                            ((ToolStripMenuItem)itmOpcion).Enabled = false;
                            ((ToolStripMenuItem)itmOpcion).Visible = false;
                        }
                        // si esta opción a su vez despliega un nuevo submenú
                        // llamar recursivamente a este método para cambiar sus opciones
                        if (((ToolStripMenuItem)itmOpcion).DropDownItems.Count > 0)
                        {
                            this.CambiarOpcionesMenu(((ToolStripMenuItem)itmOpcion).DropDownItems, nombreModulo);
                        }

                    }
                }
            }
        }

        private void transportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoEmpresaDeServicioDeTransporteDePersonal frmHijo = new CatalogoEmpresaDeServicioDeTransporteDePersonal(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void rutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoRutasRecorrido frmHijo = new CatalogoRutasRecorrido(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHReporteDeAsistenciaMóvilBuses_Click(object sender, EventArgs e)
        {
            ListadoAsistenciaTransferenciaBuses frmHijo = new ListadoAsistenciaTransferenciaBuses(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHparaderos_Click(object sender, EventArgs e)
        {
            CatalogoParadero frmHijo = new CatalogoParadero(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHpersonalPorParadero_Click(object sender, EventArgs e)
        {
            CatalogoPersonaByParadero frmHijo = new CatalogoPersonaByParadero(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void tipoDeBloqueoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoTipoBloqueoAsistencia frmHijo = new CatalogoTipoBloqueoAsistencia(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHpersonalBloqueado_Click(object sender, EventArgs e)
        {
            CatalogoPersonalBloqueadoParaAsistencia frmHijo = new CatalogoPersonalBloqueadoParaAsistencia(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHRegistroAsistencia_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaDiarioByPuertaIngreso frmHijo = new ReporteAsistenciaDiarioByPuertaIngreso(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHreporteDeAsistenciaObservados_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaObservados frmHijo = new ReporteAsistenciaObservados(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHreporteDeAsistenciaEnPuertas_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaDiarioByPuertaIngreso frmHijo = new ReporteAsistenciaDiarioByPuertaIngreso(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHReporteDeVencimientodEDocumentos_Click(object sender, EventArgs e)
        {
            ReporteVencimientoDocumentos frmHijo = new ReporteVencimientoDocumentos(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHmenu_Click(object sender, EventArgs e)
        {
            Modulo frmHijo = new Modulo(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHformularioDeSistema_Click(object sender, EventArgs e)
        {
            Formularios frmHijo = new Formularios(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;

        }

        private void GoPlanilla_Click(object sender, EventArgs e)
        {
            ActivarModulo("GoPlanilla", this);
        }

        private void GoTransporte_Click(object sender, EventArgs e)
        {
            ActivarModulo("GoTransportes", this);
        }

        private void GoExportaciones_Click(object sender, EventArgs e)
        {
            ActivarModulo("GoEvaluaciones", this);
        }

        private void GoMantenimiento_Click(object sender, EventArgs e)
        {
            ActivarModulo("GoEvaluaciones", this);
        }

        private void GoMaquinaria_Click(object sender, EventArgs e)
        {
            ActivarModulo("GoEvaluaciones", this);
        }

        private void GoEvaluacionAgricola_Click(object sender, EventArgs e)
        {
            ActivarModulo("GoEvaluaciones", this);
        }

        private void GoSanidad_Click(object sender, EventArgs e)
        {
            ActivarModulo("GoEvaluaciones", this);
        }

        private void GoSistema_Click(object sender, EventArgs e)
        {
            ActivarModulo("GoSistema", this);
        }

        private void GoSalir_Click(object sender, EventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void GoSistemaCatalogoPrivilegios_Click(object sender, EventArgs e)
        {
            Users frmHijo = new Users(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            GetPrivilesByUser();
        }

        private void GetPrivilesByUser()
        {
            try
            {
                modelPrivileges = new UsersController();
                privilegesByUser = new List<PrivilegesByUser>();
                privilegesByUser = modelPrivileges.GetListPrivilegesByUser(_conection, _user.IdUsuario.Trim(), _companyId.Trim());
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblUsuarioNombre.Text = _user.IdUsuario != null ? _user.IdUsuario : string.Empty;
            lblNombreDescripcion.Text = _user.NombreCompleto != null ? _user.NombreCompleto : string.Empty;
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusStrip.Visible == true)
            {
                statusStrip.Visible = false;
            }
            else
            {
                statusStrip.Visible = true;
            }


        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GoSistemaCatalogoConfiguracion_Click(object sender, EventArgs e)
        {

        }

        private void RRHHpersonalGeneral_Click(object sender, EventArgs e)
        {

        }

        private void GoPlanillaProcesoActualizarListaSincronizacionATablets_Click(object sender, EventArgs e)
        {

        }

        private void GoTransportesReporteIngresoSalidaBuses_Click(object sender, EventArgs e)
        {
            Users frmHijo = new Users();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }
    }

}
