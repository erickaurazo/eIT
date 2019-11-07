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
            this.GoPlanilla = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransporte = new System.Windows.Forms.ToolStripMenuItem();
            this.GoExportaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.GoMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.GoMaquinaria = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.GoSanidad = new System.Windows.Forms.ToolStripMenuItem();
            this.GoEvaluacionAgricola = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.GoSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesCatalogoTransportista = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaCatalogoFormularios = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesCatalogoParaderos = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillasCatalogoPersonalBloqueado = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillasCatalogoPersonalPorParadero = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaCatalogoUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaCatalogoModulos = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesCatalogoRutas = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillasCatalogoTiposDeBloqueo = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesMovimientoAsistenciaBuses = new System.Windows.Forms.ToolStripMenuItem();
            this.procesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillaProcesoActualizarListaSincronizacionATablets = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesReporteAsistenciaBuses = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesReporteIngresoBuses = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillasReporteAsistenciasObservadas = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillasReporteAsistenciaPorPuerta = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesReporteVencimientoDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaUtilitariosIniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaUtilitariosCloseAllWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuarioNombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNombreDescripcion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConexión = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConexionDescripcion = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
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
            this.utilitariosToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(677, 24);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "MenuPrincipal";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoPlanilla,
            this.GoTransporte,
            this.GoExportaciones,
            this.toolStripSeparator1,
            this.GoMantenimiento,
            this.GoMaquinaria,
            this.toolStripSeparator3,
            this.GoSanidad,
            this.GoEvaluacionAgricola,
            this.toolStripSeparator2,
            this.GoSistema,
            this.GoSalir,
            this.toolStripSeparator4});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(60, 20);
            this.fileMenu.Text = "&Sistema";
            // 
            // GoPlanilla
            // 
            this.GoPlanilla.Image = ((System.Drawing.Image)(resources.GetObject("GoPlanilla.Image")));
            this.GoPlanilla.Name = "GoPlanilla";
            this.GoPlanilla.Size = new System.Drawing.Size(192, 22);
            this.GoPlanilla.Text = "Planillas";
            this.GoPlanilla.Click += new System.EventHandler(this.GoPlanilla_Click);
            // 
            // GoTransporte
            // 
            this.GoTransporte.Image = ((System.Drawing.Image)(resources.GetObject("GoTransporte.Image")));
            this.GoTransporte.Name = "GoTransporte";
            this.GoTransporte.Size = new System.Drawing.Size(192, 22);
            this.GoTransporte.Text = "Transporte";
            this.GoTransporte.Click += new System.EventHandler(this.GoTransporte_Click);
            // 
            // GoExportaciones
            // 
            this.GoExportaciones.Enabled = false;
            this.GoExportaciones.Image = ((System.Drawing.Image)(resources.GetObject("GoExportaciones.Image")));
            this.GoExportaciones.Name = "GoExportaciones";
            this.GoExportaciones.Size = new System.Drawing.Size(192, 22);
            this.GoExportaciones.Text = "Exportaciones";
            this.GoExportaciones.Click += new System.EventHandler(this.GoExportaciones_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // GoMantenimiento
            // 
            this.GoMantenimiento.Enabled = false;
            this.GoMantenimiento.Image = ((System.Drawing.Image)(resources.GetObject("GoMantenimiento.Image")));
            this.GoMantenimiento.Name = "GoMantenimiento";
            this.GoMantenimiento.Size = new System.Drawing.Size(192, 22);
            this.GoMantenimiento.Text = "Mantenimiento";
            this.GoMantenimiento.Click += new System.EventHandler(this.GoMantenimiento_Click);
            // 
            // GoMaquinaria
            // 
            this.GoMaquinaria.Enabled = false;
            this.GoMaquinaria.Image = ((System.Drawing.Image)(resources.GetObject("GoMaquinaria.Image")));
            this.GoMaquinaria.Name = "GoMaquinaria";
            this.GoMaquinaria.Size = new System.Drawing.Size(192, 22);
            this.GoMaquinaria.Text = "Maquinaria";
            this.GoMaquinaria.Click += new System.EventHandler(this.GoMaquinaria_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // GoSanidad
            // 
            this.GoSanidad.Enabled = false;
            this.GoSanidad.Image = ((System.Drawing.Image)(resources.GetObject("GoSanidad.Image")));
            this.GoSanidad.Name = "GoSanidad";
            this.GoSanidad.Size = new System.Drawing.Size(192, 22);
            this.GoSanidad.Text = "Sanidad | FitoSanidad";
            this.GoSanidad.Click += new System.EventHandler(this.GoSanidad_Click);
            // 
            // GoEvaluacionAgricola
            // 
            this.GoEvaluacionAgricola.Enabled = false;
            this.GoEvaluacionAgricola.Image = ((System.Drawing.Image)(resources.GetObject("GoEvaluacionAgricola.Image")));
            this.GoEvaluacionAgricola.Name = "GoEvaluacionAgricola";
            this.GoEvaluacionAgricola.Size = new System.Drawing.Size(192, 22);
            this.GoEvaluacionAgricola.Text = "Evaluaciones agrícolas";
            this.GoEvaluacionAgricola.Click += new System.EventHandler(this.GoEvaluacionAgricola_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // GoSistema
            // 
            this.GoSistema.Image = ((System.Drawing.Image)(resources.GetObject("GoSistema.Image")));
            this.GoSistema.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GoSistema.Name = "GoSistema";
            this.GoSistema.Size = new System.Drawing.Size(192, 22);
            this.GoSistema.Text = "Sistema";
            this.GoSistema.Click += new System.EventHandler(this.GoSistema_Click);
            // 
            // GoSalir
            // 
            this.GoSalir.Name = "GoSalir";
            this.GoSalir.Size = new System.Drawing.Size(192, 22);
            this.GoSalir.Text = "&Salir";
            this.GoSalir.Click += new System.EventHandler(this.GoSalir_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(189, 6);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoTransportesCatalogoTransportista,
            this.GoSistemaCatalogoFormularios,
            this.GoTransportesCatalogoParaderos,
            this.GoPlanillasCatalogoPersonalBloqueado,
            this.GoPlanillasCatalogoPersonalPorParadero,
            this.GoSistemaCatalogoUsers,
            this.GoSistemaCatalogoModulos,
            this.GoTransportesCatalogoRutas,
            this.GoPlanillasCatalogoTiposDeBloqueo});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(51, 20);
            this.editMenu.Text = "Tablas";
            // 
            // GoTransportesCatalogoTransportista
            // 
            this.GoTransportesCatalogoTransportista.Name = "GoTransportesCatalogoTransportista";
            this.GoTransportesCatalogoTransportista.Size = new System.Drawing.Size(259, 22);
            this.GoTransportesCatalogoTransportista.Text = "Catálogo de empresa de transporte";
            this.GoTransportesCatalogoTransportista.Visible = false;
            this.GoTransportesCatalogoTransportista.Click += new System.EventHandler(this.transportistaToolStripMenuItem_Click);
            // 
            // GoSistemaCatalogoFormularios
            // 
            this.GoSistemaCatalogoFormularios.Name = "GoSistemaCatalogoFormularios";
            this.GoSistemaCatalogoFormularios.Size = new System.Drawing.Size(259, 22);
            this.GoSistemaCatalogoFormularios.Text = "Formulario de Sistema";
            this.GoSistemaCatalogoFormularios.Visible = false;
            this.GoSistemaCatalogoFormularios.Click += new System.EventHandler(this.RRHHformularioDeSistema_Click);
            // 
            // GoTransportesCatalogoParaderos
            // 
            this.GoTransportesCatalogoParaderos.Name = "GoTransportesCatalogoParaderos";
            this.GoTransportesCatalogoParaderos.Size = new System.Drawing.Size(259, 22);
            this.GoTransportesCatalogoParaderos.Text = "Paraderos";
            this.GoTransportesCatalogoParaderos.Visible = false;
            this.GoTransportesCatalogoParaderos.Click += new System.EventHandler(this.RRHHparaderos_Click);
            // 
            // GoPlanillasCatalogoPersonalBloqueado
            // 
            this.GoPlanillasCatalogoPersonalBloqueado.Name = "GoPlanillasCatalogoPersonalBloqueado";
            this.GoPlanillasCatalogoPersonalBloqueado.Size = new System.Drawing.Size(259, 22);
            this.GoPlanillasCatalogoPersonalBloqueado.Text = "Personal observado";
            this.GoPlanillasCatalogoPersonalBloqueado.Click += new System.EventHandler(this.personalObservadoToolStripMenuItem_Click);
            // 
            // GoPlanillasCatalogoPersonalPorParadero
            // 
            this.GoPlanillasCatalogoPersonalPorParadero.Name = "GoPlanillasCatalogoPersonalPorParadero";
            this.GoPlanillasCatalogoPersonalPorParadero.Size = new System.Drawing.Size(259, 22);
            this.GoPlanillasCatalogoPersonalPorParadero.Text = "Personal por paradero";
            this.GoPlanillasCatalogoPersonalPorParadero.Click += new System.EventHandler(this.GoPlanillasCatalogoPersonalPorParadero_Click);
            // 
            // GoSistemaCatalogoUsers
            // 
            this.GoSistemaCatalogoUsers.Name = "GoSistemaCatalogoUsers";
            this.GoSistemaCatalogoUsers.Size = new System.Drawing.Size(259, 22);
            this.GoSistemaCatalogoUsers.Text = "Privilegios y accesos";
            this.GoSistemaCatalogoUsers.Visible = false;
            this.GoSistemaCatalogoUsers.Click += new System.EventHandler(this.GoSistemaCatalogoPrivilegios_Click);
            // 
            // GoSistemaCatalogoModulos
            // 
            this.GoSistemaCatalogoModulos.Name = "GoSistemaCatalogoModulos";
            this.GoSistemaCatalogoModulos.Size = new System.Drawing.Size(259, 22);
            this.GoSistemaCatalogoModulos.Text = "Modulo de sistema";
            this.GoSistemaCatalogoModulos.Visible = false;
            this.GoSistemaCatalogoModulos.Click += new System.EventHandler(this.RRHHmenu_Click);
            // 
            // GoTransportesCatalogoRutas
            // 
            this.GoTransportesCatalogoRutas.Name = "GoTransportesCatalogoRutas";
            this.GoTransportesCatalogoRutas.Size = new System.Drawing.Size(259, 22);
            this.GoTransportesCatalogoRutas.Text = "Rutas para transporte";
            this.GoTransportesCatalogoRutas.Visible = false;
            this.GoTransportesCatalogoRutas.Click += new System.EventHandler(this.rutaToolStripMenuItem_Click);
            // 
            // GoPlanillasCatalogoTiposDeBloqueo
            // 
            this.GoPlanillasCatalogoTiposDeBloqueo.Name = "GoPlanillasCatalogoTiposDeBloqueo";
            this.GoPlanillasCatalogoTiposDeBloqueo.Size = new System.Drawing.Size(259, 22);
            this.GoPlanillasCatalogoTiposDeBloqueo.Text = "Tipo de bloqueo para asistencia";
            this.GoPlanillasCatalogoTiposDeBloqueo.Visible = false;
            this.GoPlanillasCatalogoTiposDeBloqueo.Click += new System.EventHandler(this.tipoDeBloqueoToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoTransportesMovimientoAsistenciaBuses});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(84, 20);
            this.viewMenu.Text = "Movimiento";
            // 
            // GoTransportesMovimientoAsistenciaBuses
            // 
            this.GoTransportesMovimientoAsistenciaBuses.Name = "GoTransportesMovimientoAsistenciaBuses";
            this.GoTransportesMovimientoAsistenciaBuses.Size = new System.Drawing.Size(187, 22);
            this.GoTransportesMovimientoAsistenciaBuses.Text = "Registro de asistencia";
            this.GoTransportesMovimientoAsistenciaBuses.Visible = false;
            this.GoTransportesMovimientoAsistenciaBuses.Click += new System.EventHandler(this.RRHHRegistroAsistencia_Click);
            // 
            // procesoToolStripMenuItem
            // 
            this.procesoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoPlanillaProcesoActualizarListaSincronizacionATablets});
            this.procesoToolStripMenuItem.Name = "procesoToolStripMenuItem";
            this.procesoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.procesoToolStripMenuItem.Text = "Proceso";
            // 
            // GoPlanillaProcesoActualizarListaSincronizacionATablets
            // 
            this.GoPlanillaProcesoActualizarListaSincronizacionATablets.Name = "GoPlanillaProcesoActualizarListaSincronizacionATablets";
            this.GoPlanillaProcesoActualizarListaSincronizacionATablets.Size = new System.Drawing.Size(311, 22);
            this.GoPlanillaProcesoActualizarListaSincronizacionATablets.Text = "Actualizar listado para sincronizacion a tablet";
            this.GoPlanillaProcesoActualizarListaSincronizacionATablets.Visible = false;
            this.GoPlanillaProcesoActualizarListaSincronizacionATablets.Click += new System.EventHandler(this.GoPlanillaProcesoActualizarListaSincronizacionATablets_Click);
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoTransportesReporteAsistenciaBuses,
            this.GoTransportesReporteIngresoBuses,
            this.GoPlanillasReporteAsistenciasObservadas,
            this.GoPlanillasReporteAsistenciaPorPuerta,
            this.GoTransportesReporteVencimientoDocumentos});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(65, 20);
            this.toolsMenu.Text = "&Reportes";
            // 
            // GoTransportesReporteAsistenciaBuses
            // 
            this.GoTransportesReporteAsistenciaBuses.AutoSize = false;
            this.GoTransportesReporteAsistenciaBuses.Name = "GoTransportesReporteAsistenciaBuses";
            this.GoTransportesReporteAsistenciaBuses.Size = new System.Drawing.Size(469, 25);
            this.GoTransportesReporteAsistenciaBuses.Text = "Reporte de asistencia móvil buses";
            this.GoTransportesReporteAsistenciaBuses.Visible = false;
            this.GoTransportesReporteAsistenciaBuses.Click += new System.EventHandler(this.RRHHReporteDeAsistenciaMóvilBuses_Click);
            // 
            // GoTransportesReporteIngresoBuses
            // 
            this.GoTransportesReporteIngresoBuses.Name = "GoTransportesReporteIngresoBuses";
            this.GoTransportesReporteIngresoBuses.Size = new System.Drawing.Size(366, 22);
            this.GoTransportesReporteIngresoBuses.Text = "Reportes de Ingreso y Salida de unidades de transportes";
            this.GoTransportesReporteIngresoBuses.Visible = false;
            this.GoTransportesReporteIngresoBuses.Click += new System.EventHandler(this.GoTransportesReporteIngresoSalidaBuses_Click);
            // 
            // GoPlanillasReporteAsistenciasObservadas
            // 
            this.GoPlanillasReporteAsistenciasObservadas.Name = "GoPlanillasReporteAsistenciasObservadas";
            this.GoPlanillasReporteAsistenciasObservadas.Size = new System.Drawing.Size(366, 22);
            this.GoPlanillasReporteAsistenciasObservadas.Text = "Reporte de asistencia observados";
            this.GoPlanillasReporteAsistenciasObservadas.Visible = false;
            this.GoPlanillasReporteAsistenciasObservadas.Click += new System.EventHandler(this.RRHHreporteDeAsistenciaObservados_Click);
            // 
            // GoPlanillasReporteAsistenciaPorPuerta
            // 
            this.GoPlanillasReporteAsistenciaPorPuerta.Name = "GoPlanillasReporteAsistenciaPorPuerta";
            this.GoPlanillasReporteAsistenciaPorPuerta.Size = new System.Drawing.Size(366, 22);
            this.GoPlanillasReporteAsistenciaPorPuerta.Text = "Reporte de asistencia en garita";
            this.GoPlanillasReporteAsistenciaPorPuerta.Visible = false;
            this.GoPlanillasReporteAsistenciaPorPuerta.Click += new System.EventHandler(this.RRHHreporteDeAsistenciaEnPuertas_Click);
            // 
            // GoTransportesReporteVencimientoDocumentos
            // 
            this.GoTransportesReporteVencimientoDocumentos.Name = "GoTransportesReporteVencimientoDocumentos";
            this.GoTransportesReporteVencimientoDocumentos.Size = new System.Drawing.Size(366, 22);
            this.GoTransportesReporteVencimientoDocumentos.Text = "Reporte de vencimiento de documentos";
            this.GoTransportesReporteVencimientoDocumentos.Visible = false;
            this.GoTransportesReporteVencimientoDocumentos.Click += new System.EventHandler(this.RRHHReporteDeVencimientodEDocumentos_Click);
            // 
            // utilitariosToolStripMenuItem
            // 
            this.utilitariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoSistemaUtilitariosIniciarSesion,
            this.GoSistemaUtilitariosCloseAllWindows});
            this.utilitariosToolStripMenuItem.Name = "utilitariosToolStripMenuItem";
            this.utilitariosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.utilitariosToolStripMenuItem.Text = "Utilitarios";
            // 
            // GoSistemaUtilitariosIniciarSesion
            // 
            this.GoSistemaUtilitariosIniciarSesion.Name = "GoSistemaUtilitariosIniciarSesion";
            this.GoSistemaUtilitariosIniciarSesion.Size = new System.Drawing.Size(205, 22);
            this.GoSistemaUtilitariosIniciarSesion.Text = "Selecionar empresa";
            this.GoSistemaUtilitariosIniciarSesion.Visible = false;
            this.GoSistemaUtilitariosIniciarSesion.Click += new System.EventHandler(this.GoSistemaUtilitariosIniciarSesion_Click);
            // 
            // GoSistemaUtilitariosCloseAllWindows
            // 
            this.GoSistemaUtilitariosCloseAllWindows.Name = "GoSistemaUtilitariosCloseAllWindows";
            this.GoSistemaUtilitariosCloseAllWindows.Size = new System.Drawing.Size(205, 22);
            this.GoSistemaUtilitariosCloseAllWindows.Text = "Cerrar todas las ventanas";
            this.GoSistemaUtilitariosCloseAllWindows.Click += new System.EventHandler(this.cerrarTodasLasVentanasToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblUsuarioNombre,
            this.lblNombre,
            this.lblNombreDescripcion,
            this.lblConexión,
            this.lblConexionDescripcion});
            this.statusStrip.Location = new System.Drawing.Point(0, 400);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(677, 22);
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
            this.lblUsuarioNombre.Size = new System.Drawing.Size(100, 17);
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
            this.lblNombreDescripcion.Size = new System.Drawing.Size(200, 17);
            this.lblNombreDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConexión
            // 
            this.lblConexión.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexión.Name = "lblConexión";
            this.lblConexión.Size = new System.Drawing.Size(65, 17);
            this.lblConexión.Text = "Conexión :";
            // 
            // lblConexionDescripcion
            // 
            this.lblConexionDescripcion.AutoSize = false;
            this.lblConexionDescripcion.Name = "lblConexionDescripcion";
            this.lblConexionDescripcion.Size = new System.Drawing.Size(200, 17);
            this.lblConexionDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(677, 422);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Menu";
            this.Text = "Agrícola San José S.A  | Sullana | Piura | Perú  | V 1.2";
            this.toolTip.SetToolTip(this, "06.11.19");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesCatalogoTransportista;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesCatalogoRutas;
        private System.Windows.Forms.ToolStripMenuItem procesoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioNombre;
        private System.Windows.Forms.ToolStripStatusLabel lblNombre;
        private System.Windows.Forms.ToolStripStatusLabel lblNombreDescripcion;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesReporteAsistenciaBuses;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillasCatalogoTiposDeBloqueo;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesMovimientoAsistenciaBuses;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesCatalogoParaderos;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesReporteIngresoBuses;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillaProcesoActualizarListaSincronizacionATablets;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillasReporteAsistenciasObservadas;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillasReporteAsistenciaPorPuerta;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesReporteVencimientoDocumentos;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaCatalogoModulos;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaCatalogoFormularios;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaCatalogoUsers;
        private System.Windows.Forms.ToolStripMenuItem utilitariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem GoSistema;
        private System.Windows.Forms.ToolStripMenuItem GoPlanilla;
        private System.Windows.Forms.ToolStripMenuItem GoTransporte;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem GoMaquinaria;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem GoSanidad;
        private System.Windows.Forms.ToolStripMenuItem GoEvaluacionAgricola;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem GoSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem GoMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem GoExportaciones;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaUtilitariosIniciarSesion;
        private System.ComponentModel.BackgroundWorker bgwHilo;
        private System.Windows.Forms.ToolStripStatusLabel lblConexión;
        private System.Windows.Forms.ToolStripStatusLabel lblConexionDescripcion;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillasCatalogoPersonalBloqueado;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillasCatalogoPersonalPorParadero;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaUtilitariosCloseAllWindows;
    }
}