namespace Asistencia
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHH = new System.Windows.Forms.ToolStripMenuItem();
            this.Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHCatalogoTransportistas = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHparaderos = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHpersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHpersonalGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHpersonalPorParadero = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHpersonalBloqueado = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHRutasRecorridoTransportista = new System.Windows.Forms.ToolStripMenuItem();
            this.RRH3HPrivilegiosDelSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHtipoDeBloqueo = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHModuloSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHformularioDeSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RR3HHRegistroDeAsistenciaPersonalAdministrativo = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHRegistroAsistencia = new System.Windows.Forms.ToolStripMenuItem();
            this.procesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarListadoParaSincronizacionATabletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RRH3HReporteDeAsistenciaPersonalAdministrativo = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHReporteDeAsistenciaMóvilBuses = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeAsistenciaDePersonalPorBusesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHreporteDeAsistenciaObservados = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHreporteDeAsistenciaEnPuertas = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHReporteDeVencimientodEDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuarioNombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNombreDescripcion = new System.Windows.Forms.ToolStripStatusLabel();
            this.privilegiosYAccesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu,
            this.procesoToolStripMenuItem,
            this.toolsMenu,
            this.utilitariosToolStripMenuItem,
            this.windowsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(663, 24);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "MenuPrincipal";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RRHH,
            this.Salir});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(60, 20);
            this.fileMenu.Text = "&Sistema";
            // 
            // RRHH
            // 
            this.RRHH.Image = ((System.Drawing.Image)(resources.GetObject("RRHH.Image")));
            this.RRHH.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RRHH.Name = "RRHH";
            this.RRHH.Size = new System.Drawing.Size(157, 22);
            this.RRHH.Text = "Administrativos";
            this.RRHH.Click += new System.EventHandler(this.RRHH_Click);
            // 
            // Salir
            // 
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(157, 22);
            this.Salir.Text = "&Salir";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RRHHCatalogoTransportistas,
            this.RRHHparaderos,
            this.RRHHpersonal,
            this.RRHHRutasRecorridoTransportista,
            this.RRH3HPrivilegiosDelSistema,
            this.RRHHtipoDeBloqueo,
            this.RRHHModuloSistema,
            this.RRHHformularioDeSistema,
            this.privilegiosYAccesosToolStripMenuItem,
            this.configuracionDelSistemaToolStripMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(51, 20);
            this.editMenu.Text = "Tablas";
            // 
            // RRHHCatalogoTransportistas
            // 
            this.RRHHCatalogoTransportistas.Name = "RRHHCatalogoTransportistas";
            this.RRHHCatalogoTransportistas.Size = new System.Drawing.Size(259, 22);
            this.RRHHCatalogoTransportistas.Text = "Catálogo de empresa de transporte";
            this.RRHHCatalogoTransportistas.Click += new System.EventHandler(this.transportistaToolStripMenuItem_Click);
            // 
            // RRHHparaderos
            // 
            this.RRHHparaderos.Name = "RRHHparaderos";
            this.RRHHparaderos.Size = new System.Drawing.Size(259, 22);
            this.RRHHparaderos.Text = "Paraderos";
            this.RRHHparaderos.Click += new System.EventHandler(this.RRHHparaderos_Click);
            // 
            // RRHHpersonal
            // 
            this.RRHHpersonal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RRHHpersonalGeneral,
            this.RRHHpersonalPorParadero,
            this.RRHHpersonalBloqueado});
            this.RRHHpersonal.Name = "RRHHpersonal";
            this.RRHHpersonal.Size = new System.Drawing.Size(259, 22);
            this.RRHHpersonal.Text = "Personal";
            // 
            // RRHHpersonalGeneral
            // 
            this.RRHHpersonalGeneral.Name = "RRHHpersonalGeneral";
            this.RRHHpersonalGeneral.Size = new System.Drawing.Size(190, 22);
            this.RRHHpersonalGeneral.Text = "Personal general";
            // 
            // RRHHpersonalPorParadero
            // 
            this.RRHHpersonalPorParadero.Name = "RRHHpersonalPorParadero";
            this.RRHHpersonalPorParadero.Size = new System.Drawing.Size(190, 22);
            this.RRHHpersonalPorParadero.Text = "Personal por paradero";
            this.RRHHpersonalPorParadero.Click += new System.EventHandler(this.RRHHpersonalPorParadero_Click);
            // 
            // RRHHpersonalBloqueado
            // 
            this.RRHHpersonalBloqueado.Name = "RRHHpersonalBloqueado";
            this.RRHHpersonalBloqueado.Size = new System.Drawing.Size(190, 22);
            this.RRHHpersonalBloqueado.Text = "Personal bloqueado";
            this.RRHHpersonalBloqueado.Click += new System.EventHandler(this.RRHHpersonalBloqueado_Click);
            // 
            // RRHHRutasRecorridoTransportista
            // 
            this.RRHHRutasRecorridoTransportista.Name = "RRHHRutasRecorridoTransportista";
            this.RRHHRutasRecorridoTransportista.Size = new System.Drawing.Size(259, 22);
            this.RRHHRutasRecorridoTransportista.Text = "Rutas para transporte";
            this.RRHHRutasRecorridoTransportista.Click += new System.EventHandler(this.rutaToolStripMenuItem_Click);
            // 
            // RRH3HPrivilegiosDelSistema
            // 
            this.RRH3HPrivilegiosDelSistema.Enabled = false;
            this.RRH3HPrivilegiosDelSistema.Name = "RRH3HPrivilegiosDelSistema";
            this.RRH3HPrivilegiosDelSistema.Size = new System.Drawing.Size(259, 22);
            this.RRH3HPrivilegiosDelSistema.Text = "Privilegios de Sistema";
            // 
            // RRHHtipoDeBloqueo
            // 
            this.RRHHtipoDeBloqueo.Name = "RRHHtipoDeBloqueo";
            this.RRHHtipoDeBloqueo.Size = new System.Drawing.Size(259, 22);
            this.RRHHtipoDeBloqueo.Text = "Tipo de bloqueo para asistencia";
            this.RRHHtipoDeBloqueo.Click += new System.EventHandler(this.tipoDeBloqueoToolStripMenuItem_Click);
            // 
            // RRHHModuloSistema
            // 
            this.RRHHModuloSistema.Name = "RRHHModuloSistema";
            this.RRHHModuloSistema.Size = new System.Drawing.Size(259, 22);
            this.RRHHModuloSistema.Text = "Modulo de sistema";
            this.RRHHModuloSistema.Click += new System.EventHandler(this.RRHHmenu_Click);
            // 
            // RRHHformularioDeSistema
            // 
            this.RRHHformularioDeSistema.Name = "RRHHformularioDeSistema";
            this.RRHHformularioDeSistema.Size = new System.Drawing.Size(259, 22);
            this.RRHHformularioDeSistema.Text = "Formulario de Sistema";
            this.RRHHformularioDeSistema.Click += new System.EventHandler(this.RRHHformularioDeSistema_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RR3HHRegistroDeAsistenciaPersonalAdministrativo,
            this.RRHHRegistroAsistencia});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(84, 20);
            this.viewMenu.Text = "Movimiento";
            // 
            // RR3HHRegistroDeAsistenciaPersonalAdministrativo
            // 
            this.RR3HHRegistroDeAsistenciaPersonalAdministrativo.Name = "RR3HHRegistroDeAsistenciaPersonalAdministrativo";
            this.RR3HHRegistroDeAsistenciaPersonalAdministrativo.Size = new System.Drawing.Size(318, 22);
            this.RR3HHRegistroDeAsistenciaPersonalAdministrativo.Text = "Registro de Asistencia Personal Administrativo";
            this.RR3HHRegistroDeAsistenciaPersonalAdministrativo.Click += new System.EventHandler(this.registroDeAsistenciaPersonalAdministrativoToolStripMenuItem_Click);
            // 
            // RRHHRegistroAsistencia
            // 
            this.RRHHRegistroAsistencia.Name = "RRHHRegistroAsistencia";
            this.RRHHRegistroAsistencia.Size = new System.Drawing.Size(318, 22);
            this.RRHHRegistroAsistencia.Text = "Registro de asistencia";
            this.RRHHRegistroAsistencia.Click += new System.EventHandler(this.RRHHRegistroAsistencia_Click);
            // 
            // procesoToolStripMenuItem
            // 
            this.procesoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarListadoParaSincronizacionATabletToolStripMenuItem});
            this.procesoToolStripMenuItem.Name = "procesoToolStripMenuItem";
            this.procesoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.procesoToolStripMenuItem.Text = "Proceso";
            // 
            // actualizarListadoParaSincronizacionATabletToolStripMenuItem
            // 
            this.actualizarListadoParaSincronizacionATabletToolStripMenuItem.Name = "actualizarListadoParaSincronizacionATabletToolStripMenuItem";
            this.actualizarListadoParaSincronizacionATabletToolStripMenuItem.Size = new System.Drawing.Size(311, 22);
            this.actualizarListadoParaSincronizacionATabletToolStripMenuItem.Text = "Actualizar listado para sincronizacion a tablet";
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RRH3HReporteDeAsistenciaPersonalAdministrativo,
            this.RRHHReporteDeAsistenciaMóvilBuses,
            this.RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes,
            this.reporteDeAsistenciaDePersonalPorBusesToolStripMenuItem,
            this.RRHHreporteDeAsistenciaObservados,
            this.RRHHreporteDeAsistenciaEnPuertas,
            this.RRHHReporteDeVencimientodEDocumentos});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(65, 20);
            this.toolsMenu.Text = "&Reportes";
            // 
            // RRH3HReporteDeAsistenciaPersonalAdministrativo
            // 
            this.RRH3HReporteDeAsistenciaPersonalAdministrativo.AutoSize = false;
            this.RRH3HReporteDeAsistenciaPersonalAdministrativo.Name = "RRH3HReporteDeAsistenciaPersonalAdministrativo";
            this.RRH3HReporteDeAsistenciaPersonalAdministrativo.Size = new System.Drawing.Size(469, 25);
            this.RRH3HReporteDeAsistenciaPersonalAdministrativo.Text = "Reporte de Asistencia Personal Administrativo";
            this.RRH3HReporteDeAsistenciaPersonalAdministrativo.Click += new System.EventHandler(this.reporteDeAsistenciaPersonalAdministrativoToolStripMenuItem_Click);
            // 
            // RRHHReporteDeAsistenciaMóvilBuses
            // 
            this.RRHHReporteDeAsistenciaMóvilBuses.AutoSize = false;
            this.RRHHReporteDeAsistenciaMóvilBuses.Name = "RRHHReporteDeAsistenciaMóvilBuses";
            this.RRHHReporteDeAsistenciaMóvilBuses.Size = new System.Drawing.Size(469, 25);
            this.RRHHReporteDeAsistenciaMóvilBuses.Text = "Reporte de asistencia móvil buses";
            this.RRHHReporteDeAsistenciaMóvilBuses.Click += new System.EventHandler(this.RRHHReporteDeAsistenciaMóvilBuses_Click);
            // 
            // RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes
            // 
            this.RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes.Name = "RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes";
            this.RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes.Size = new System.Drawing.Size(366, 22);
            this.RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes.Text = "Reportes de Ingreso y Salida de unidades de transportes";
            this.RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes.Click += new System.EventHandler(this.RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes_Click);
            // 
            // reporteDeAsistenciaDePersonalPorBusesToolStripMenuItem
            // 
            this.reporteDeAsistenciaDePersonalPorBusesToolStripMenuItem.Name = "reporteDeAsistenciaDePersonalPorBusesToolStripMenuItem";
            this.reporteDeAsistenciaDePersonalPorBusesToolStripMenuItem.Size = new System.Drawing.Size(366, 22);
            this.reporteDeAsistenciaDePersonalPorBusesToolStripMenuItem.Text = "Reporte de asistencia de personal por buses";
            this.reporteDeAsistenciaDePersonalPorBusesToolStripMenuItem.Click += new System.EventHandler(this.ReporteDeAsistenciaDePersonalPorBusesToolStripMenuItem_Click);
            // 
            // RRHHreporteDeAsistenciaObservados
            // 
            this.RRHHreporteDeAsistenciaObservados.Name = "RRHHreporteDeAsistenciaObservados";
            this.RRHHreporteDeAsistenciaObservados.Size = new System.Drawing.Size(366, 22);
            this.RRHHreporteDeAsistenciaObservados.Text = "Reporte de asistencia observados";
            this.RRHHreporteDeAsistenciaObservados.Click += new System.EventHandler(this.RRHHreporteDeAsistenciaObservados_Click);
            // 
            // RRHHreporteDeAsistenciaEnPuertas
            // 
            this.RRHHreporteDeAsistenciaEnPuertas.Name = "RRHHreporteDeAsistenciaEnPuertas";
            this.RRHHreporteDeAsistenciaEnPuertas.Size = new System.Drawing.Size(366, 22);
            this.RRHHreporteDeAsistenciaEnPuertas.Text = "Reporte de asistencia en garita";
            this.RRHHreporteDeAsistenciaEnPuertas.Click += new System.EventHandler(this.RRHHreporteDeAsistenciaEnPuertas_Click);
            // 
            // RRHHReporteDeVencimientodEDocumentos
            // 
            this.RRHHReporteDeVencimientodEDocumentos.Name = "RRHHReporteDeVencimientodEDocumentos";
            this.RRHHReporteDeVencimientodEDocumentos.Size = new System.Drawing.Size(366, 22);
            this.RRHHReporteDeVencimientodEDocumentos.Text = "Reporte de vencimientod e documentos";
            this.RRHHReporteDeVencimientodEDocumentos.Click += new System.EventHandler(this.RRHHReporteDeVencimientodEDocumentos_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(66, 20);
            this.windowsMenu.Text = "&Ventanas";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.newWindowToolStripMenuItem.Text = "&Nueva ventana";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascada";
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileVerticalToolStripMenuItem.Text = "Mosaico &vertical";
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Mosaico &horizontal";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.closeAllToolStripMenuItem.Text = "C&errar todo";
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Organizar iconos";
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(53, 20);
            this.helpMenu.Text = "Ay&uda";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblUsuarioNombre,
            this.lblNombre,
            this.lblNombreDescripcion});
            this.statusStrip.Location = new System.Drawing.Point(0, 407);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(663, 22);
            this.statusStrip.TabIndex = 17;
            this.statusStrip.Text = "StatusStrip";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 17);
            this.lblUsuario.Text = "Usuario :";
            // 
            // lblUsuarioNombre
            // 
            this.lblUsuarioNombre.AutoSize = false;
            this.lblUsuarioNombre.Name = "lblUsuarioNombre";
            this.lblUsuarioNombre.Size = new System.Drawing.Size(200, 17);
            this.lblUsuarioNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(59, 17);
            this.lblNombre.Text = "Nombre :";
            // 
            // lblNombreDescripcion
            // 
            this.lblNombreDescripcion.AutoSize = false;
            this.lblNombreDescripcion.Name = "lblNombreDescripcion";
            this.lblNombreDescripcion.Size = new System.Drawing.Size(400, 17);
            this.lblNombreDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // privilegiosYAccesosToolStripMenuItem
            // 
            this.privilegiosYAccesosToolStripMenuItem.Name = "privilegiosYAccesosToolStripMenuItem";
            this.privilegiosYAccesosToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.privilegiosYAccesosToolStripMenuItem.Text = "Privilegios y accesos";
            // 
            // configuracionDelSistemaToolStripMenuItem
            // 
            this.configuracionDelSistemaToolStripMenuItem.Name = "configuracionDelSistemaToolStripMenuItem";
            this.configuracionDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.configuracionDelSistemaToolStripMenuItem.Text = "Configuracion del sistema";
            // 
            // utilitariosToolStripMenuItem
            // 
            this.utilitariosToolStripMenuItem.Name = "utilitariosToolStripMenuItem";
            this.utilitariosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.utilitariosToolStripMenuItem.Text = "Utilitarios";
            // 
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(663, 429);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Menu";
            this.Text = "Agrícola San José S.A  - Sullana - Piura - Perú  V 1.1.20";
            this.toolTip.SetToolTip(this, "20.08.19");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem RRHH;
        private System.Windows.Forms.ToolStripMenuItem Salir;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem RRHHCatalogoTransportistas;
        private System.Windows.Forms.ToolStripMenuItem RRHHRutasRecorridoTransportista;
        private System.Windows.Forms.ToolStripMenuItem procesoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RRH3HPrivilegiosDelSistema;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioNombre;
        private System.Windows.Forms.ToolStripStatusLabel lblNombre;
        private System.Windows.Forms.ToolStripStatusLabel lblNombreDescripcion;
        private System.Windows.Forms.ToolStripMenuItem RRH3HReporteDeAsistenciaPersonalAdministrativo;
        private System.Windows.Forms.ToolStripMenuItem RR3HHRegistroDeAsistenciaPersonalAdministrativo;
        private System.Windows.Forms.ToolStripMenuItem RRHHReporteDeAsistenciaMóvilBuses;
        private System.Windows.Forms.ToolStripMenuItem RRHHpersonal;
        private System.Windows.Forms.ToolStripMenuItem RRHHpersonalGeneral;
        private System.Windows.Forms.ToolStripMenuItem RRHHpersonalPorParadero;
        private System.Windows.Forms.ToolStripMenuItem RRHHpersonalBloqueado;
        private System.Windows.Forms.ToolStripMenuItem RRHHtipoDeBloqueo;
        private System.Windows.Forms.ToolStripMenuItem RRHHRegistroAsistencia;
        private System.Windows.Forms.ToolStripMenuItem RRHHparaderos;
        private System.Windows.Forms.ToolStripMenuItem RRHHreportesDeIngresoYSalidaDeUnidadesDeTransportes;
        private System.Windows.Forms.ToolStripMenuItem actualizarListadoParaSincronizacionATabletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeAsistenciaDePersonalPorBusesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RRHHreporteDeAsistenciaObservados;
        private System.Windows.Forms.ToolStripMenuItem RRHHreporteDeAsistenciaEnPuertas;
        private System.Windows.Forms.ToolStripMenuItem RRHHReporteDeVencimientodEDocumentos;
        private System.Windows.Forms.ToolStripMenuItem RRHHModuloSistema;
        private System.Windows.Forms.ToolStripMenuItem RRHHformularioDeSistema;
        private System.Windows.Forms.ToolStripMenuItem privilegiosYAccesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionDelSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitariosToolStripMenuItem;
    }
}