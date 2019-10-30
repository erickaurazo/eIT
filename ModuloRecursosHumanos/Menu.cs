using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Transportista;
using RecursosHumanos;



namespace ModuloRecursosHumanos
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
            CatalogoPensiones frmHijo = new CatalogoPensiones() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void refrigerioPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramacionRefrigerioxPersonal frmHijo = new ProgramacionRefrigerioxPersonal() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }


        private void Menu_Load(object sender, EventArgs e)
        {
            Acceso ofrm = new Acceso();
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("Bienvenido al Sistema", "Mensaje de Bienvenida");
                if (ofrm.userSistema != null)
                {
                    usuario = ofrm.usuario;
                    lblUsuarioNombre.Text = ofrm.userSistema.IdUsuario ?? string.Empty;
                    lblNombreDescripcion.Text = ofrm.userSistema.UserNombres ?? string.Empty;
                    ActivarModulo("", this);
                }
                else
                {
                    this.Dispose();
                    this.Close();
                }
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
                if (opcion is MenuStrip)
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

            CajaBancos.Enabled = true;
            CajaBancos.Visible = true;
            TRANSPORTE.Enabled = true;
            TRANSPORTE.Visible = true;
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
                    else if (itmOpcion.Name.ToUpper().Contains("TRANSPORTE".ToUpper()) && nombreModulo.ToUpper() == "TRANSPORTE".ToUpper())
                    {
                        ((ToolStripMenuItem)itmOpcion).Enabled = true;
                        ((ToolStripMenuItem)itmOpcion).Visible = true;
                    }

                    else if (itmOpcion.Name.ToUpper().Contains("SALIR".ToUpper()))
                    {
                        ((ToolStripMenuItem)itmOpcion).Enabled = true;
                        ((ToolStripMenuItem)itmOpcion).Visible = true;
                    }
                    else if (itmOpcion.Name.ToUpper().Contains("SISTEMA".ToUpper()) && nombreModulo != "")
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
            CatalogoEmpresasServiciosTransportePersonalCampo frmHijo = new CatalogoEmpresasServiciosTransportePersonalCampo() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void rutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoRutasRecorrido frmHijo = new CatalogoRutasRecorrido() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void parteDeRecorridosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovimientoRecorridos frmHijo = new MovimientoRecorridos();
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void facturacionPensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacturacionPensiones frmHijo = new FacturacionPensiones() { MdiParent = this, WindowState = FormWindowState.Maximized, AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit };
            frmHijo.Show();
            statusStrip.Visible = false;
        }

        private void subirPlanillaDePagoDeEfectivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PagoCaja frmHijo = new PagoCaja() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;


        }

        private void pagoDePlanillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PagoRegistroPlanilla frmHijo = new PagoRegistroPlanilla() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }






        private void facturacionTransportistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacturacionMovilidades frmHijo = new FacturacionMovilidades() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;

        }

        private void monitoreoMovimientoPensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonitoreoMovimientoPension frmHijo = new MonitoreoMovimientoPension() { MdiParent = this };
            frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void registroDeAsistenciaPersonalAdministrativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroAsistenciaPersonalAdministrativo frmHijo = new RegistroAsistenciaPersonalAdministrativo() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void consolidadoDeMovimientoDeTransportistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsolidadoMovimientoMovilidades frmHijo = new ConsolidadoMovimientoMovilidades() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHH_Click(object sender, EventArgs e)
        {
            ActivarModulo("RRHH", this);
        }

        private void cajaYBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivarModulo("CAJABANCOS", this);
        }

        private void RRHHPrivilegiosDelSistema_Click(object sender, EventArgs e)
        {
            Privilegios frmHijo = new Privilegios() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHModificarLongitudDeDigitosParaRegistroDeTrabajadores_Click(object sender, EventArgs e)
        {
            ModificarLongitudCreacionCodigosPersonal frmHijo = new ModificarLongitudCreacionCodigosPersonal() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Normal;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void CajaBancosSolicitudARendir_Click(object sender, EventArgs e)
        {

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RRHHsincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios_Click(object sender, EventArgs e)
        {
            ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios frmHijo = new ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Normal;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }



        private void RRHHTransferirAsistenciasEntrePeriodosPorProveedor_Click(object sender, EventArgs e)
        {
            TrasnferirAsistenciaPensionByProveedor frmHijo = new TrasnferirAsistenciaPensionByProveedor() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHConsolidadoAsistenciaRefrigeriosCampo_Click(object sender, EventArgs e)
        {
            ConsolidadoAsistenciasRefrigerioByTransferencia frmHijo = new ConsolidadoAsistenciasRefrigerioByTransferencia() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHGenerarDescuentoParaPagoServicioAlimentacion_Click(object sender, EventArgs e)
        {

            ProcesoGenerarDescuentoParaPagoServicioAlimentacion frmHijo = new ProcesoGenerarDescuentoParaPagoServicioAlimentacion() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Normal;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void reporteDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RRHHExclusiónDePeriodosParaFacturaciónDeServicioDeAlmentacionYTransporte_Click(object sender, EventArgs e)
        {
            ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas frmHijo = new ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHCatalogoDePersonalPorParaderoHospedaje_Click(object sender, EventArgs e)
        {
            RegistroPersonalByParaderoOrHospedaje frmHijo = new RegistroPersonalByParaderoOrHospedaje() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHcatálogoDeParaderosEnElServicioDeTransportePersonal_Click(object sender, EventArgs e)
        {
            CatalogoUbicacionParaderos frmHijo = new CatalogoUbicacionParaderos() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHReporteDeRendimientoPorDiaPersonal_Click(object sender, EventArgs e)
        {

        }

        private void RRHHRegistroMúltipleDeBeneficiosAlPersonal_Click(object sender, EventArgs e)
        {
            ProgramacionRefrigerioRegistrosMultiples frmHijo = new ProgramacionRefrigerioRegistrosMultiples() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHPersonalAdministrativo_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaPersonalAdministrativo frmHijo = new ReporteAsistenciaPersonalAdministrativo() { MdiParent = this };
            frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHhorasAcumuladasPorDiaDeTrabajo_Click(object sender, EventArgs e)
        {
            ReporteDeHorasDesarrolladasEnLaboresDeCampoByPersonal frmHijo = new ReporteDeHorasDesarrolladasEnLaboresDeCampoByPersonal() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHHorasTrabajadasDelPersonalCampo_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaPersonalLaboresCampoxHoras frmHijo = new ReporteAsistenciaPersonalLaboresCampoxHoras() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHRendimientoDelPersonalDeCampo_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaPersonalLaboresCampoxRendimiento frmHijo = new ReporteAsistenciaPersonalLaboresCampoxRendimiento() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHPorProyecto_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaPersonalByproyecto frmHijo = new ReporteAsistenciaPersonalByproyecto() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHcontrolDeHorariosDeSalidaDeLasUnidadesDeTransporte_Click(object sender, EventArgs e)
        {
            ReporteControlUnidadHorarioSalidaTransportista frmHijo = new ReporteControlUnidadHorarioSalidaTransportista() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Normal;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void duplicidadDeRefrigeriosPorPersonaYPorDíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportePersonalConDuplicidadRefrigerios frmHijo = new ReportePersonalConDuplicidadRefrigerios() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void refrigeriosPorSubPlanillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteRefrigeriosPorSubPlanilla frmHijo = new ReporteRefrigeriosPorSubPlanilla() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void asistenciaARefrigeriosDesdeLaTransferenciaMóvilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaRefrigerioTransferencia frmHijo = new ReporteAsistenciaRefrigerioTransferencia() { MdiParent = this };
            frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHAsistenciaARefrigerios_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaRefrigerio frmHijo = new ReporteAsistenciaRefrigerio() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHAsociarParaderoATrabajadorPostTransferencia_Click(object sender, EventArgs e)
        {
            ProcesoAsociarParaderoATrabajadorPostTransferencia frmHijo = new ProcesoAsociarParaderoATrabajadorPostTransferencia() { MdiParent = this };
            frmHijo.Show();
            //frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHConsolidadoRegistroDeAsistenciasRefrigerioProcesadas_Click(object sender, EventArgs e)
        {
            ConsolidadoAsistenciasRefrigerioProcesadas frmHijo = new ConsolidadoAsistenciasRefrigerioProcesadas() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHregistroDeAsistenciaARefigeriosDeCampo_Click(object sender, EventArgs e)
        {
            MovimientoRegistroAsistenciaRefrigerio frmHijo = new MovimientoRegistroAsistenciaRefrigerio() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHMovimientoDeAsistenciaARefrigeriosProcesadas_Click(object sender, EventArgs e)
        {
            RegistroAsistenciaRefrigerio frmHijo = new RegistroAsistenciaRefrigerio() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;

        }


        private void RRHHPorcentajeDeAsistenciaARefrigeriosPorPeriodo_Click(object sender, EventArgs e)
        {
            PorcentajeDeAsistenciaARefrigeriosPorPeriodo frmHijo = new PorcentajeDeAsistenciaARefrigeriosPorPeriodo() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHProgramacionRefrigerioRegistrosMultiplesVistaImpresion_Click(object sender, EventArgs e)
        {

        }

        private void RRHHActualizarNombreDeColaboradoresPostTransfenciaDeAsistenciaRefrigerio_Click(object sender, EventArgs e)
        {
            ActualizarNombresColaboradorpostTrasnferencia frmHijo = new ActualizarNombresColaboradorpostTrasnferencia() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHAnularAsistenciasDuplicadasDeAsistenciaMovilDePensiones_Click(object sender, EventArgs e)
        {
            AnularAsistenciasDuplicadasAsistenciaPension frmHijo = new AnularAsistenciasDuplicadasAsistenciaPension() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHActualizarIncosistenciaProgramacionDeRefrigerios_Click(object sender, EventArgs e)
        {
            ActualizarInconsistenciaProgramacionDeRefrigerios frmHijo = new ActualizarInconsistenciaProgramacionDeRefrigerios() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHOtrosDocumentosPersonalGeneral_Click(object sender, EventArgs e)
        {
            SeguimientoMemorandum frmHijo = new SeguimientoMemorandum() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void reporteDePagoPorRendimientoPorDiaByActividadYLaborToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteRendimientoDiarioPersonalByActividad frmHijo = new ReporteRendimientoDiarioPersonalByActividad() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void reporteDePagoPorRendimientoPorDiaByActividadYLaborToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReporteMovimientoDesarrolloLaboresPersonalCampo frmHijo = new ReporteMovimientoDesarrolloLaboresPersonalCampo() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void programacionDeRefrigerioParaRegistrosMúltiplesVistaImpresiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramacionRefrigerioRegistrosMultiplesVistaImpresion frmHijo = new ProgramacionRefrigerioRegistrosMultiplesVistaImpresion() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void RRHHanalisisPorTransferenciaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteAsistenciaRefrigerioTransferenciaAnalisisGrafico frmHijo = new ReporteAsistenciaRefrigerioTransferenciaAnalisisGrafico() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;

        }

        private void TRANSPORTEParaderos_Click(object sender, EventArgs e)
        {
            CatalogoUbicacionParaderos frmHijo = new CatalogoUbicacionParaderos() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;
        }

        private void TRANSPORTE_Click(object sender, EventArgs e)
        {
            ActivarModulo("TRANSPORTE", this);
        }

        private void TRANSPORTEdistribucionDePasajerosPorParaderos_Click(object sender, EventArgs e)
        {
            ReporteDistribucionPasajerosByParadero frmHijo = new ReporteDistribucionPasajerosByParadero() { MdiParent = this };
            frmHijo.Show();
            frmHijo.WindowState = FormWindowState.Maximized;
            frmHijo.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            statusStrip.Visible = false;

        }

        private void SISTEMAnewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SISTEMAcascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SISTEMAtileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SISTEMAtileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SISTEMAcloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SISTEMAarrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
