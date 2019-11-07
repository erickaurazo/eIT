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
        private string _descripcionConexion;
        private object privilege;

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
                _descripcionConexion = ofrm.descripcionConexion != null ? ofrm.descripcionConexion.Trim() : string.Empty;
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
            GoExportaciones.Enabled = !true;
            GoMantenimiento.Enabled = !true;
            GoMaquinaria.Enabled = !true;
            GoSanidad.Enabled = !true;
            GoEvaluacionAgricola.Enabled = !true;
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
                            string nameForm = (itmOpcion.Name.ToUpper());
                            // Verifico sólo que tenga acceso al formulario para activar o desactivar su vista.
                            if (ValidateAccessByUserAndFormDescription(nameForm) == true)
                            {
                                //Aqui lo deshabilitamos
                                ((ToolStripMenuItem)itmOpcion).Enabled = true;
                                ((ToolStripMenuItem)itmOpcion).Visible = true;
                            }
                            else
                            {
                                //Puede ser padre --> si es padre lo valido y lo dejo pasar, caso contrario no le doy acceso
                                if (ValidateAccessByUserAndFormDescriptionIsParent(nameForm) == true)
                                {
                                    //Aqui lo deshabilitamos
                                    ((ToolStripMenuItem)itmOpcion).Enabled = true;
                                    ((ToolStripMenuItem)itmOpcion).Visible = true;
                                }
                            }

                        }
                        else if (itmOpcion.Name.ToUpper().Contains("GoTransportes".ToUpper()) && nombreModulo.ToUpper() == "GoTransportes".ToUpper())
                        {
                            string nameForm = (itmOpcion.Name.ToUpper());
                            // Verifico sólo que tenga acceso al formulario para activar o desactivar su vista.
                            if (ValidateAccessByUserAndFormDescription(nameForm) == true)
                            {
                                //Aqui lo deshabilitamos
                                ((ToolStripMenuItem)itmOpcion).Enabled = true;
                                ((ToolStripMenuItem)itmOpcion).Visible = true;
                            }
                            else
                            {
                                //Puede ser padre --> si es padre lo valido y lo dejo pasar, caso contrario no le doy acceso
                                if (ValidateAccessByUserAndFormDescriptionIsParent(nameForm) == true)
                                {
                                    //Aqui lo deshabilitamos
                                    ((ToolStripMenuItem)itmOpcion).Enabled = true;
                                    ((ToolStripMenuItem)itmOpcion).Visible = true;
                                }
                            }
                        }
                        else if (itmOpcion.Name.ToUpper().Contains("GoSistema".ToUpper()) && nombreModulo.ToUpper() == "GoSistema".ToUpper())
                        {
                            string nameForm = (itmOpcion.Name.ToUpper());
                            // Verifico sólo que tenga acceso al formulario para activar o desactivar su vista.
                            if (ValidateAccessByUserAndFormDescription(nameForm) == true)
                            {
                                //Aqui lo deshabilitamos
                                ((ToolStripMenuItem)itmOpcion).Enabled = true;
                                ((ToolStripMenuItem)itmOpcion).Visible = true;
                            }
                            else
                            {
                                //Puede ser padre --> si es padre lo valido y lo dejo pasar, caso contrario no le doy acceso
                                if (ValidateAccessByUserAndFormDescriptionIsParent(nameForm) == true)
                                {
                                    //Aqui lo deshabilitamos
                                    ((ToolStripMenuItem)itmOpcion).Enabled = true;
                                    ((ToolStripMenuItem)itmOpcion).Visible = true;
                                }
                            }
                        }
                        else
                        {
                            string nameForm = (itmOpcion.Name.ToUpper());
                            // Verifico sólo que tenga acceso al formulario para activar o desactivar su vista.
                            if (ValidateAccessByUserAndFormDescription(nameForm) == true)
                            {
                                //Aqui lo deshabilitamos
                                ((ToolStripMenuItem)itmOpcion).Enabled = true;
                                ((ToolStripMenuItem)itmOpcion).Visible = true;
                            }
                            else
                            {
                                //Puede ser padre --> si es padre lo valido y lo dejo pasar, caso contrario no le doy acceso
                                if (ValidateAccessByUserAndFormDescriptionIsParent(nameForm) == true)
                                {
                                    //Aqui lo deshabilitamos
                                    ((ToolStripMenuItem)itmOpcion).Enabled = true;
                                    ((ToolStripMenuItem)itmOpcion).Visible = true;
                                }
                            }
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

        public void CambiarOpcionesMenu(ToolStripItemCollection colOpcionesMenu, string nombreModulo, List<PrivilegesByUser> privilegesByUserByModule)
        {
            if (this.bgwHilo.IsBusy != true)
            {
                // recorrer el submenú
                foreach (ToolStripItem itmOpcion in colOpcionesMenu)
                {
                    // restaurar el tipo de letra original
                    // si es una opción de menú normal...
                    itmOpcion.Enabled = false;
                    itmOpcion.Visible = false;

                    if (itmOpcion.GetType() == typeof(ToolStripMenuItem))
                    {
                        #region 
                        // OJO que hay que colocar el texto que contiene el elemento ej. Imprimir
                        if (itmOpcion.Name.ToUpper().Contains("GoPlanilla".ToUpper()) && nombreModulo.ToUpper() == "GoPlanilla".ToUpper())
                        {
                            #region
                            string nameForm = (itmOpcion.Name.ToUpper());
                            // Verifico sólo que tenga acceso al formulario para activar o desactivar su vista.
                            if (ValidateAccessByUserAndFormDescription(nameForm, privilegesByUserByModule) == true)
                            {
                                //Aqui lo deshabilitamos
                                itmOpcion.Enabled = true;
                                itmOpcion.Visible = true;
                            }
                            else
                            {
                                //Puede ser padre --> si es padre lo valido y lo dejo pasar, caso contrario no le doy acceso
                                if (ValidateAccessByUserAndFormDescriptionIsParent(nameForm, privilegesByUserByModule) == true)
                                {
                                    //Aqui lo deshabilitamos
                                    itmOpcion.Enabled = true;
                                    itmOpcion.Visible = true;
                                }
                            }
                            #endregion  
                        }
                        else if (itmOpcion.Name.ToUpper().Contains("GoTransportes".ToUpper()) && nombreModulo.ToUpper() == "GoTransportes".ToUpper())
                        {
                            #region
                            string nameForm = (itmOpcion.Name.ToUpper());
                            // Verifico sólo que tenga acceso al formulario para activar o desactivar su vista.
                            if (ValidateAccessByUserAndFormDescription(nameForm, privilegesByUserByModule) == true)
                            {
                                //Aqui lo deshabilitamos
                                itmOpcion.Enabled = true;
                                itmOpcion.Visible = true;
                            }
                            else
                            {
                                //Puede ser padre --> si es padre lo valido y lo dejo pasar, caso contrario no le doy acceso
                                if (ValidateAccessByUserAndFormDescriptionIsParent(nameForm, privilegesByUserByModule) == true)
                                {
                                    //Aqui lo deshabilitamos
                                    itmOpcion.Enabled = true;
                                    itmOpcion.Visible = true;
                                }
                            }
                            #endregion  
                        }
                        else if (itmOpcion.Name.ToUpper().Contains("GoSistema".ToUpper()) && nombreModulo.ToUpper() == "GoSistema".ToUpper())
                        {
                            #region
                            string nameForm = (itmOpcion.Name.ToUpper());
                            // Verifico sólo que tenga acceso al formulario para activar o desactivar su vista.
                            if (ValidateAccessByUserAndFormDescription(nameForm, privilegesByUserByModule) == true)
                            {
                                //Aqui lo deshabilitamos
                                itmOpcion.Enabled = true;
                                itmOpcion.Visible = true;
                            }
                            else
                            {
                                //Puede ser padre --> si es padre lo valido y lo dejo pasar, caso contrario no le doy acceso
                                if (ValidateAccessByUserAndFormDescriptionIsParent(nameForm, privilegesByUserByModule) == true)
                                {
                                    //Aqui lo deshabilitamos
                                    itmOpcion.Enabled = true;
                                    itmOpcion.Visible = true;
                                }
                            }
                            #endregion  
                        }
                        else
                        {
                            #region
                            /*
                            string nameForm = (itmOpcion.Name.ToUpper());
                            // Verifico sólo que tenga acceso al formulario para activar o desactivar su vista.
                            if (ValidateAccessByUserAndFormDescription(nameForm) == true)
                            {
                                //Aqui lo deshabilitamos
                                ((ToolStripMenuItem)itmOpcion).Enabled = !true;
                                ((ToolStripMenuItem)itmOpcion).Visible = true;
                            }
                            else
                            {
                                //Puede ser padre --> si es padre lo valido y lo dejo pasar, caso contrario no le doy acceso
                                if (ValidateAccessByUserAndFormDescriptionIsParent(nameForm) == true)
                                {
                                    //Aqui lo deshabilitamos
                                    ((ToolStripMenuItem)itmOpcion).Enabled = !true;
                                    ((ToolStripMenuItem)itmOpcion).Visible = true;
                                }
                            }
                            */
                            #endregion
                        }
                        // si esta opción a su vez despliega un nuevo submenú
                        // llamar recursivamente a este método para cambiar sus opciones
                        if (((ToolStripMenuItem)itmOpcion).DropDownItems.Count > 0)
                        {
                            this.CambiarOpcionesMenu(((ToolStripMenuItem)itmOpcion).DropDownItems, nombreModulo, privilegesByUserByModule);
                        }
                        #endregion  
                    }
                }
            }
        }

        private bool ValidateAccessByUserAndFormDescriptionIsParent(string nameForm)
        {
            bool state = false;
            try
            {
                var result = privilegesByUser.Where(x =>
                x.nombreEnElSistema.Trim().ToUpper() == nameForm.Trim().ToUpper()
                ).ToList();


                if (result != null && result.ToList().Count == 1)
                {
                    string jerarquia = result.Single().jerarquia != null ? result.Single().jerarquia.Trim() : string.Empty;
                    var resultByJerarquia = privilegesByUser.Where(x => x.barraPadre.Trim() == jerarquia.Trim()).ToList();
                    if (resultByJerarquia != null && resultByJerarquia.ToList().Count > 1)
                    {
                        state = true;
                    }

                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "ADVERTENCIA DEL SISTEMA");
                return state;
            }

            return state;
        }

        private bool ValidateAccessByUserAndFormDescription(string nameForm)
        {
            bool state = false;
            try
            {
                var result = privilegesByUser.Where(x =>
                x.usuarioCodigo.Trim().ToUpper() == _user.IdUsuario.Trim().ToUpper() &&
                x.nombreEnElSistema.Trim().ToUpper() == nameForm.Trim().ToUpper()
                ).ToList();


                if (result != null && result.ToList().Count == 1)
                {
                    if (result.Single().consultar == 1)
                    {
                        state = true;
                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "ADVERTENCIA DEL SISTEMA");
                return state;
            }

            return state;
        }


        private bool ValidateAccessByUserAndFormDescriptionIsParent(string nameForm, List<PrivilegesByUser> privilegesByUserByModule)
        {
            bool state = false;
            try
            {
                var result = privilegesByUserByModule.Where(x =>
                x.nombreEnElSistema.Trim().ToUpper() == nameForm.Trim().ToUpper()
                ).ToList();


                if (result != null && result.ToList().Count == 1)
                {
                    string jerarquia = result.Single().jerarquia != null ? result.Single().jerarquia.Trim() : string.Empty;
                    var resultByJerarquia = privilegesByUser.Where(x => x.barraPadre.Trim() == jerarquia.Trim()).ToList();
                    if (resultByJerarquia != null && resultByJerarquia.ToList().Count > 1)
                    {
                        state = true;
                    }

                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "ADVERTENCIA DEL SISTEMA");
                return state;
            }

            return state;
        }

        private bool ValidateAccessByUserAndFormDescription(string nameForm, List<PrivilegesByUser> privilegesByUserByModule)
        {
            bool state = false;
            try
            {
                var result = privilegesByUserByModule.Where(x =>
                x.usuarioCodigo.Trim().ToUpper() == _user.IdUsuario.Trim().ToUpper() &&
                x.nombreEnElSistema.Trim().ToUpper() == nameForm.Trim().ToUpper()
                ).ToList();


                if (result != null && result.ToList().Count == 1)
                {
                    if (result.Single().consultar == 1)
                    {
                        state = true;
                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "ADVERTENCIA DEL SISTEMA");
                return state;
            }

            return state;
        }



        //, List<PrivilegesByUser> privilegesByUserByModule
        private void transportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string form2 = GoTransportesCatalogoTransportista.Name.ToString().Trim().ToUpper();

            var result = privilegesByUser.Where(x => x.nombreEnElSistema.Trim().ToUpper() == form2).ToList();
            PrivilegesByUser privilege = new PrivilegesByUser {  anular = 0, consultar = 0 , eliminar = 0 , imprimir = 0 , nuevo = 0 , ninguno = 1 , editar = 0};
            if (result != null && result.ToList().Count > 0)
            {                
                privilege = result.FirstOrDefault();
            }

            CatalogoEmpresaDeServicioDeTransporteDePersonal frmHijo = new CatalogoEmpresaDeServicioDeTransporteDePersonal(_conection, _user, _companyId, privilege);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void rutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTransportesCatalogoRutas frmHijo = new GoTransportesCatalogoRutas(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHReporteDeAsistenciaMóvilBuses_Click(object sender, EventArgs e)
        {
            GoTransportesReporteAsistenciaBuses frmHijo = new GoTransportesReporteAsistenciaBuses(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHparaderos_Click(object sender, EventArgs e)
        {
            GoTransportesCatalogoParaderos frmHijo = new GoTransportesCatalogoParaderos(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHpersonalPorParadero_Click(object sender, EventArgs e)
        {
            GoPlanillasCatalogoPersonaPorParadero frmHijo = new GoPlanillasCatalogoPersonaPorParadero(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void tipoDeBloqueoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoPlanillasCatalogoTiposDeBloqueo frmHijo = new GoPlanillasCatalogoTiposDeBloqueo(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHpersonalBloqueado_Click(object sender, EventArgs e)
        {
            GoPlanillasCatalogoPersonalBloqueado frmHijo = new GoPlanillasCatalogoPersonalBloqueado(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHRegistroAsistencia_Click(object sender, EventArgs e)
        {
            GoTransportesMovimientoAsistenciaBuses frmHijo = new GoTransportesMovimientoAsistenciaBuses(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHreporteDeAsistenciaObservados_Click(object sender, EventArgs e)
        {
            GoPlanillasReporteAsistenciasObservadas frmHijo = new GoPlanillasReporteAsistenciasObservadas(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHreporteDeAsistenciaEnPuertas_Click(object sender, EventArgs e)
        {
            GoPlanillasReporteAsistenciaPorPuerta frmHijo = new GoPlanillasReporteAsistenciaPorPuerta(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHReporteDeVencimientodEDocumentos_Click(object sender, EventArgs e)
        {
            GoTransportesReporteVencimientoDocumentos frmHijo = new GoTransportesReporteVencimientoDocumentos(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHmenu_Click(object sender, EventArgs e)
        {
            GoSistemaCatalogoModulos frmHijo = new GoSistemaCatalogoModulos(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHformularioDeSistema_Click(object sender, EventArgs e)
        {
            GoSistemaCatalogoFormularios frmHijo = new GoSistemaCatalogoFormularios(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;

        }

        private void GoPlanilla_Click(object sender, EventArgs e)
        {

            var privilegesByUserByModule = privilegesByUser.Where(x => x.nombreEnElSistema.ToUpper().Trim().Contains("GoPlanilla".ToUpper())).ToList();
            ActivarModulo("GoPlanilla", this, privilegesByUserByModule);
        }

        private void GoTransporte_Click(object sender, EventArgs e)
        {
            var privilegesByUserByModule = privilegesByUser.Where(x => x.nombreEnElSistema.ToUpper().Trim().Contains("GoTransportes".ToUpper())).ToList();
            ActivarModulo("GoTransportes", this, privilegesByUserByModule);
        }

        private void GoExportaciones_Click(object sender, EventArgs e)
        {
            var privilegesByUserByModule = privilegesByUser.Where(x => x.nombreEnElSistema.ToUpper().Trim().Contains("GoExportaciones".ToUpper())).ToList();
            ActivarModulo("GoExportaciones", this, privilegesByUserByModule);
        }

        private void GoMantenimiento_Click(object sender, EventArgs e)
        {
            var privilegesByUserByModule = privilegesByUser.Where(x => x.nombreEnElSistema.ToUpper().Trim().Contains("GoMantenimiento".ToUpper())).ToList();
            ActivarModulo("GoMantenimiento", this, privilegesByUserByModule);
        }

        private void GoMaquinaria_Click(object sender, EventArgs e)
        {
            var privilegesByUserByModule = privilegesByUser.Where(x => x.nombreEnElSistema.ToUpper().Trim().Contains("GoMaquinaria".ToUpper())).ToList();
            ActivarModulo("GoMaquinaria", this, privilegesByUserByModule);
        }

        private void GoEvaluacionAgricola_Click(object sender, EventArgs e)
        {
            var privilegesByUserByModule = privilegesByUser.Where(x => x.nombreEnElSistema.ToUpper().Trim().Contains("GoEvaluacionAgricola".ToUpper())).ToList();
            ActivarModulo("GoEvaluacionAgricola", this, privilegesByUserByModule);
        }

        private void GoSanidad_Click(object sender, EventArgs e)
        {
            var privilegesByUserByModule = privilegesByUser.Where(x => x.nombreEnElSistema.ToUpper().Trim().Contains("GoSanidad".ToUpper())).ToList();
            ActivarModulo("GoSanidad", this, privilegesByUserByModule);
        }

        private void GoSistema_Click(object sender, EventArgs e)
        {
            var privilegesByUserByModule = privilegesByUser.Where(x => x.nombreEnElSistema.ToUpper().Trim().Contains("GoSistema".ToUpper())).ToList();
            ActivarModulo("GoSistema", this, privilegesByUserByModule);
        }

        private void ActivarModulo(string moduleName, Menu menu, List<PrivilegesByUser> privilegesByUserByModule)
        {
            foreach (var opcion in menu.Controls)
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
                            CambiarOpcionesMenu(mnuitOpcion.DropDownItems, moduleName, privilegesByUserByModule);
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
            GoExportaciones.Enabled = !true;
            GoMantenimiento.Enabled = !true;
            GoMaquinaria.Enabled = !true;
            GoSanidad.Enabled = !true;
            GoEvaluacionAgricola.Enabled = !true;
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
            GoSistemaCatalogoUsers frmHijo = new GoSistemaCatalogoUsers(_conection, _user, _companyId);
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
            lblConexionDescripcion.Text = _descripcionConexion != null ? _descripcionConexion.Trim() : string.Empty;
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
            GoTransportesReporteIngresoBuses frmHijo = new GoTransportesReporteIngresoBuses(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void personalObservadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoPlanillasCatalogoPersonalBloqueado frmHijo = new GoPlanillasCatalogoPersonalBloqueado(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void GoPlanillasCatalogoPersonalPorParadero_Click(object sender, EventArgs e)
        {
            GoPlanillasCatalogoPersonaPorParadero frmHijo = new GoPlanillasCatalogoPersonaPorParadero(_conection, _user, _companyId);
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void GoSistemaUtilitariosIniciarSesion_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm != this)
                {
                    count += 1;
                }
            }

            if (count > 0)
            {
                MessageBox.Show("Debe cerrar las ventanas abiertas", "MENSAJE DEL SISTEMA");
                return;
            }
            else
            {
                Login ofrm = new Login();
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show("Bienvenido al Sistema", "Mensaje de Bienvenida");                
                    _user = ofrm.user;
                    _companyId = ofrm.companyId != null ? ofrm.companyId.Trim() : string.Empty;
                    _conection = ofrm.conection != null ? ofrm.conection.Trim() : string.Empty;
                    _descripcionConexion = ofrm.descripcionConexion != null ? ofrm.descripcionConexion.Trim() : string.Empty;
                    bgwHilo.RunWorkerAsync();
                }
                else
                {
                    //this.Dispose();
                    //this.Close();
                    statusStrip.Visible = true;
                }
            }
        }


        private void cerrarTodasLasVentanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm != this)
                {
                    childForm.Close();
                }
            }


        }
    }

}
