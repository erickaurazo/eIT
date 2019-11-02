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
        private string usuario;
        public Menu()
        {
            InitializeComponent();
        }

        private void pensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CatalogoPensiones frmHijo = new CatalogoPensiones();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void refrigerioPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void asistenciaARefrigeriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReporteAsistenciaRefrigerio frmHijo = new ReporteAsistenciaRefrigerio();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Login ofrm = new Login();
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("Bienvenido al Sistema", "Mensaje de Bienvenida");
                usuario = ofrm.usuario;
                lblUsuarioNombre.Text = ofrm.userSistema.IdUsuario != null ? ofrm.userSistema.IdUsuario : string.Empty;
                lblNombreDescripcion.Text = ofrm.userSistema.NombreCompleto != null ? ofrm.userSistema.NombreCompleto : string.Empty;
                ActivarModulo("", this);
            }
            else
            {
                this.Dispose();
                this.Close();
            }
            ActivarModulo("", this);
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
            RRHH.Enabled = true;
            RRHH.Visible = true;
        }

        public void CambiarOpcionesMenu(ToolStripItemCollection colOpcionesMenu, string nombreModulo)
        {
            // recorrer el submenú
            foreach (ToolStripItem itmOpcion in colOpcionesMenu)
            {
                // restaurar el tipo de letra original
                // si es una opción de menú normal...
                if (itmOpcion.GetType() == typeof(ToolStripMenuItem))
                {
                    // OJO que hay que colocar el texto que contiene el elemento ej. Imprimir
                    if (itmOpcion.Name.ToUpper().Contains("RRHH") && nombreModulo == "RRHH")
                    {
                        //Aqui lo deshabilitamos
                        ((ToolStripMenuItem)itmOpcion).Enabled = true;
                        ((ToolStripMenuItem)itmOpcion).Visible = true;
                    }
                    else if (itmOpcion.Name.ToUpper().Contains("CajaBancos".ToUpper()) && nombreModulo.ToUpper() == "CajaBancos".ToUpper())
                    {
                        ((ToolStripMenuItem)itmOpcion).Enabled = true;
                        ((ToolStripMenuItem)itmOpcion).Visible = true;
                    }
                    else if (itmOpcion.Name.ToUpper().Contains("SALIR".ToUpper()))
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

        private void transportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoEmpresaDeServicioDeTransporteDePersonal frmHijo = new CatalogoEmpresaDeServicioDeTransporteDePersonal();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void rutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoRutasRecorrido frmHijo = new CatalogoRutasRecorrido();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void facturacionTransportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void parteDeRecorridosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MovimientoRecorridos frmHijo = new MovimientoRecorridos();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void facturacionPensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FacturacionPensiones frmHijo = new FacturacionPensiones();
            //frmHijo.MdiParent = this;
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //frmHijo.Show();
            //statusStrip.Visible = false;
        }

        private void subirPlanillaDePagoDeEfectivoToolStripMenuItem_Click(object sender, EventArgs e)
        {




        }

        private void pagoDePlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }






        private void facturacionTransportistasToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void monitoreoMovimientoPensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MonitoreoMovimientoPension frmHijo = new MonitoreoMovimientoPension();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            ////frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void reporteDeDistribuciónDeAsistenciaPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReporteAsistenciaRefrigerioTransferencia frmHijo = new ReporteAsistenciaRefrigerioTransferencia();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            ////frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void reporteDeAsistenciaPersonalAdministrativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReporteAsistenciaPersonalAdministrativo frmHijo = new ReporteAsistenciaPersonalAdministrativo();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            ////frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void consolidadoDeAsistenciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void registroDeAsistenciaDelPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registroDeAsistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MovimientoAsistenciaRefrigerioMatenimiento frmHijo = new MovimientoAsistenciaRefrigerioMatenimiento();

        }

        private void registroDeAsistenciaPersonalAdministrativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RegistroAsistenciaPersonalAdministrativo frmHijo = new RegistroAsistenciaPersonalAdministrativo();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void consolidadoDeMovimientoDeTransportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ConsolidadoMovimientoMovilidades frmHijo = new ConsolidadoMovimientoMovilidades();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void reporteDeAsisternciaDePersonalPorHorasTrabajadasEnCampoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeAsisternciaDePersonalPorRendimientoTabajosConRacimosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeRefrigeriosPorSubPlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReporteRefrigeriosPorSubPlanilla frmHijo = new ReporteRefrigeriosPorSubPlanilla();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void RRHH_Click(object sender, EventArgs e)
        {
            ActivarModulo("RRHH", this);
        }

        private void cajaYBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivarModulo("CAJABANCOS", this);
        }

        private void reporteDeDuplicidadEnRefrigeriosPorDíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReportePersonalConDuplicidadRefrigerios frmHijo = new ReportePersonalConDuplicidadRefrigerios();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void RRHHReporteDeAsistenciaMóvilBuses_Click(object sender, EventArgs e)
        {
            ListadoAsistenciaTransferenciaBuses frmHijo = new ListadoAsistenciaTransferenciaBuses();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHpersonalPorPensión_Click(object sender, EventArgs e)
        {

        }

        private void consolidadDeAsistenciaAPensionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ConsolidadoAsistenciasRefrigerioByTransferencia frmHijo = new ConsolidadoAsistenciasRefrigerioByTransferencia();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void RRHHparaderos_Click(object sender, EventArgs e)
        {
            CatalogoParadero frmHijo = new CatalogoParadero();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHpersonalPorParadero_Click(object sender, EventArgs e)
        {
            CatalogoPersonaByParadero frmHijo = new CatalogoPersonaByParadero();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void tipoDeBloqueoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoTipoBloqueoAsistencia frmHijo = new CatalogoTipoBloqueoAsistencia();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHpersonalBloqueado_Click(object sender, EventArgs e)
        {
            CatalogoPersonalBloqueadoParaAsistencia frmHijo = new CatalogoPersonalBloqueadoParaAsistencia();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes_Click(object sender, EventArgs e)
        {
            //ReporteControlUnidadHorarioSalidaTransportista frmHijo = new ReporteControlUnidadHorarioSalidaTransportista();
            //frmHijo.MdiParent = this;
            //frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            //frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            //statusStrip.Visible = false;
        }

        private void RRHHRegistroAsistencia_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaDiarioByPuertaIngreso frmHijo = new ReporteAsistenciaDiarioByPuertaIngreso();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHreporteDeAsistenciaObservados_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaObservados frmHijo = new ReporteAsistenciaObservados();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHreporteDeAsistenciaEnPuertas_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaDiarioByPuertaIngreso frmHijo = new ReporteAsistenciaDiarioByPuertaIngreso();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void ReporteDeAsistenciaDePersonalPorBusesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RRHHReporteDeVencimientodEDocumentos_Click(object sender, EventArgs e)
        {

            ReporteVencimientoDocumentos frmHijo = new ReporteVencimientoDocumentos();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;

        }

        private void RRHHmenu_Click(object sender, EventArgs e)
        {

            Modulo frmHijo = new Modulo();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHformularioDeSistema_Click(object sender, EventArgs e)
        {

            Formularios frmHijo = new Formularios();
            frmHijo.MdiParent = this;
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
            
        }
    }

}
