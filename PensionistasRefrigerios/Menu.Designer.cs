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
            this.GoSistemaCatalogoConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesCatalogoEmpresaTransporte = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaCatalogoFormularios = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesCatalogoParadero = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillaCatalogoPersonal = new System.Windows.Forms.ToolStripMenuItem();
            this.RRHHpersonalGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillaCatalogoPersonalAsignarParadero = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillaCatalogoPersonalObservados = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaCatalogoPrivilegios = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaCatalogoModulos = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesCatalogoRuta = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillaCatalogoTipoObservado = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillaMovimientoRegistroAsistencia = new System.Windows.Forms.ToolStripMenuItem();
            this.procesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillaProcesoActualizarListaSincronizacionATablets = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesReporteAsistenciaByTablets = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesReporteIngresoSalidaBuses = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillaReporteAsistenciaObservadas = new System.Windows.Forms.ToolStripMenuItem();
            this.GoPlanillaReporteReporteAsistencia = new System.Windows.Forms.ToolStripMenuItem();
            this.GoTransportesReporteVencimientoDocumentos = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaUtilitariosElegirPeriodo = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaNewWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistematileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemacloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.GoSistemaArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuarioNombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNombreDescripcion = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            this.lblConexión = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConexionDescripcion = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.menuStrip.Size = new System.Drawing.Size(1203, 24);
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
            this.GoSistemaCatalogoConfiguracion,
            this.GoTransportesCatalogoEmpresaTransporte,
            this.GoSistemaCatalogoFormularios,
            this.GoTransportesCatalogoParadero,
            this.GoPlanillaCatalogoPersonal,
            this.GoSistemaCatalogoPrivilegios,
            this.GoSistemaCatalogoModulos,
            this.GoTransportesCatalogoRuta,
            this.GoPlanillaCatalogoTipoObservado});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(51, 20);
            this.editMenu.Text = "Tablas";
            // 
            // GoSistemaCatalogoConfiguracion
            // 
            this.GoSistemaCatalogoConfiguracion.Name = "GoSistemaCatalogoConfiguracion";
            this.GoSistemaCatalogoConfiguracion.Size = new System.Drawing.Size(259, 22);
            this.GoSistemaCatalogoConfiguracion.Text = "Configuracion del sistema";
            this.GoSistemaCatalogoConfiguracion.Visible = false;
            this.GoSistemaCatalogoConfiguracion.Click += new System.EventHandler(this.GoSistemaCatalogoConfiguracion_Click);
            // 
            // GoTransportesCatalogoEmpresaTransporte
            // 
            this.GoTransportesCatalogoEmpresaTransporte.Name = "GoTransportesCatalogoEmpresaTransporte";
            this.GoTransportesCatalogoEmpresaTransporte.Size = new System.Drawing.Size(259, 22);
            this.GoTransportesCatalogoEmpresaTransporte.Text = "Catálogo de empresa de transporte";
            this.GoTransportesCatalogoEmpresaTransporte.Visible = false;
            this.GoTransportesCatalogoEmpresaTransporte.Click += new System.EventHandler(this.transportistaToolStripMenuItem_Click);
            // 
            // GoSistemaCatalogoFormularios
            // 
            this.GoSistemaCatalogoFormularios.Name = "GoSistemaCatalogoFormularios";
            this.GoSistemaCatalogoFormularios.Size = new System.Drawing.Size(259, 22);
            this.GoSistemaCatalogoFormularios.Text = "Formulario de Sistema";
            this.GoSistemaCatalogoFormularios.Visible = false;
            this.GoSistemaCatalogoFormularios.Click += new System.EventHandler(this.RRHHformularioDeSistema_Click);
            // 
            // GoTransportesCatalogoParadero
            // 
            this.GoTransportesCatalogoParadero.Name = "GoTransportesCatalogoParadero";
            this.GoTransportesCatalogoParadero.Size = new System.Drawing.Size(259, 22);
            this.GoTransportesCatalogoParadero.Text = "Paraderos";
            this.GoTransportesCatalogoParadero.Visible = false;
            this.GoTransportesCatalogoParadero.Click += new System.EventHandler(this.RRHHparaderos_Click);
            // 
            // GoPlanillaCatalogoPersonal
            // 
            this.GoPlanillaCatalogoPersonal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RRHHpersonalGeneral,
            this.GoPlanillaCatalogoPersonalAsignarParadero,
            this.GoPlanillaCatalogoPersonalObservados});
            this.GoPlanillaCatalogoPersonal.Name = "GoPlanillaCatalogoPersonal";
            this.GoPlanillaCatalogoPersonal.Size = new System.Drawing.Size(259, 22);
            this.GoPlanillaCatalogoPersonal.Text = "Personal";
            this.GoPlanillaCatalogoPersonal.Visible = false;
            // 
            // RRHHpersonalGeneral
            // 
            this.RRHHpersonalGeneral.Name = "RRHHpersonalGeneral";
            this.RRHHpersonalGeneral.Size = new System.Drawing.Size(190, 22);
            this.RRHHpersonalGeneral.Text = "Personal general";
            this.RRHHpersonalGeneral.Click += new System.EventHandler(this.RRHHpersonalGeneral_Click);
            // 
            // GoPlanillaCatalogoPersonalAsignarParadero
            // 
            this.GoPlanillaCatalogoPersonalAsignarParadero.Name = "GoPlanillaCatalogoPersonalAsignarParadero";
            this.GoPlanillaCatalogoPersonalAsignarParadero.Size = new System.Drawing.Size(190, 22);
            this.GoPlanillaCatalogoPersonalAsignarParadero.Text = "Personal por paradero";
            this.GoPlanillaCatalogoPersonalAsignarParadero.Click += new System.EventHandler(this.RRHHpersonalPorParadero_Click);
            // 
            // GoPlanillaCatalogoPersonalObservados
            // 
            this.GoPlanillaCatalogoPersonalObservados.Name = "GoPlanillaCatalogoPersonalObservados";
            this.GoPlanillaCatalogoPersonalObservados.Size = new System.Drawing.Size(190, 22);
            this.GoPlanillaCatalogoPersonalObservados.Text = "Personal bloqueado";
            this.GoPlanillaCatalogoPersonalObservados.Click += new System.EventHandler(this.RRHHpersonalBloqueado_Click);
            // 
            // GoSistemaCatalogoPrivilegios
            // 
            this.GoSistemaCatalogoPrivilegios.Name = "GoSistemaCatalogoPrivilegios";
            this.GoSistemaCatalogoPrivilegios.Size = new System.Drawing.Size(259, 22);
            this.GoSistemaCatalogoPrivilegios.Text = "Privilegios y accesos";
            this.GoSistemaCatalogoPrivilegios.Visible = false;
            this.GoSistemaCatalogoPrivilegios.Click += new System.EventHandler(this.GoSistemaCatalogoPrivilegios_Click);
            // 
            // GoSistemaCatalogoModulos
            // 
            this.GoSistemaCatalogoModulos.Name = "GoSistemaCatalogoModulos";
            this.GoSistemaCatalogoModulos.Size = new System.Drawing.Size(259, 22);
            this.GoSistemaCatalogoModulos.Text = "Modulo de sistema";
            this.GoSistemaCatalogoModulos.Visible = false;
            this.GoSistemaCatalogoModulos.Click += new System.EventHandler(this.RRHHmenu_Click);
            // 
            // GoTransportesCatalogoRuta
            // 
            this.GoTransportesCatalogoRuta.Name = "GoTransportesCatalogoRuta";
            this.GoTransportesCatalogoRuta.Size = new System.Drawing.Size(259, 22);
            this.GoTransportesCatalogoRuta.Text = "Rutas para transporte";
            this.GoTransportesCatalogoRuta.Visible = false;
            this.GoTransportesCatalogoRuta.Click += new System.EventHandler(this.rutaToolStripMenuItem_Click);
            // 
            // GoPlanillaCatalogoTipoObservado
            // 
            this.GoPlanillaCatalogoTipoObservado.Name = "GoPlanillaCatalogoTipoObservado";
            this.GoPlanillaCatalogoTipoObservado.Size = new System.Drawing.Size(259, 22);
            this.GoPlanillaCatalogoTipoObservado.Text = "Tipo de bloqueo para asistencia";
            this.GoPlanillaCatalogoTipoObservado.Visible = false;
            this.GoPlanillaCatalogoTipoObservado.Click += new System.EventHandler(this.tipoDeBloqueoToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoPlanillaMovimientoRegistroAsistencia});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(84, 20);
            this.viewMenu.Text = "Movimiento";
            // 
            // GoPlanillaMovimientoRegistroAsistencia
            // 
            this.GoPlanillaMovimientoRegistroAsistencia.Name = "GoPlanillaMovimientoRegistroAsistencia";
            this.GoPlanillaMovimientoRegistroAsistencia.Size = new System.Drawing.Size(187, 22);
            this.GoPlanillaMovimientoRegistroAsistencia.Text = "Registro de asistencia";
            this.GoPlanillaMovimientoRegistroAsistencia.Visible = false;
            this.GoPlanillaMovimientoRegistroAsistencia.Click += new System.EventHandler(this.RRHHRegistroAsistencia_Click);
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
            this.GoTransportesReporteAsistenciaByTablets,
            this.GoTransportesReporteIngresoSalidaBuses,
            this.GoPlanillaReporteAsistenciaObservadas,
            this.GoPlanillaReporteReporteAsistencia,
            this.GoTransportesReporteVencimientoDocumentos});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(65, 20);
            this.toolsMenu.Text = "&Reportes";
            // 
            // GoTransportesReporteAsistenciaByTablets
            // 
            this.GoTransportesReporteAsistenciaByTablets.AutoSize = false;
            this.GoTransportesReporteAsistenciaByTablets.Name = "GoTransportesReporteAsistenciaByTablets";
            this.GoTransportesReporteAsistenciaByTablets.Size = new System.Drawing.Size(469, 25);
            this.GoTransportesReporteAsistenciaByTablets.Text = "Reporte de asistencia móvil buses";
            this.GoTransportesReporteAsistenciaByTablets.Visible = false;
            this.GoTransportesReporteAsistenciaByTablets.Click += new System.EventHandler(this.RRHHReporteDeAsistenciaMóvilBuses_Click);
            // 
            // GoTransportesReporteIngresoSalidaBuses
            // 
            this.GoTransportesReporteIngresoSalidaBuses.Name = "GoTransportesReporteIngresoSalidaBuses";
            this.GoTransportesReporteIngresoSalidaBuses.Size = new System.Drawing.Size(366, 22);
            this.GoTransportesReporteIngresoSalidaBuses.Text = "Reportes de Ingreso y Salida de unidades de transportes";
            this.GoTransportesReporteIngresoSalidaBuses.Visible = false;
            this.GoTransportesReporteIngresoSalidaBuses.Click += new System.EventHandler(this.GoTransportesReporteIngresoSalidaBuses_Click);
            // 
            // GoPlanillaReporteAsistenciaObservadas
            // 
            this.GoPlanillaReporteAsistenciaObservadas.Name = "GoPlanillaReporteAsistenciaObservadas";
            this.GoPlanillaReporteAsistenciaObservadas.Size = new System.Drawing.Size(366, 22);
            this.GoPlanillaReporteAsistenciaObservadas.Text = "Reporte de asistencia observados";
            this.GoPlanillaReporteAsistenciaObservadas.Visible = false;
            this.GoPlanillaReporteAsistenciaObservadas.Click += new System.EventHandler(this.RRHHreporteDeAsistenciaObservados_Click);
            // 
            // GoPlanillaReporteReporteAsistencia
            // 
            this.GoPlanillaReporteReporteAsistencia.Name = "GoPlanillaReporteReporteAsistencia";
            this.GoPlanillaReporteReporteAsistencia.Size = new System.Drawing.Size(366, 22);
            this.GoPlanillaReporteReporteAsistencia.Text = "Reporte de asistencia en garita";
            this.GoPlanillaReporteReporteAsistencia.Visible = false;
            this.GoPlanillaReporteReporteAsistencia.Click += new System.EventHandler(this.RRHHreporteDeAsistenciaEnPuertas_Click);
            // 
            // GoTransportesReporteVencimientoDocumentos
            // 
            this.GoTransportesReporteVencimientoDocumentos.Name = "GoTransportesReporteVencimientoDocumentos";
            this.GoTransportesReporteVencimientoDocumentos.Size = new System.Drawing.Size(366, 22);
            this.GoTransportesReporteVencimientoDocumentos.Text = "Reporte de vencimientod e documentos";
            this.GoTransportesReporteVencimientoDocumentos.Visible = false;
            this.GoTransportesReporteVencimientoDocumentos.Click += new System.EventHandler(this.RRHHReporteDeVencimientodEDocumentos_Click);
            // 
            // utilitariosToolStripMenuItem
            // 
            this.utilitariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoSistemaUtilitariosElegirPeriodo});
            this.utilitariosToolStripMenuItem.Name = "utilitariosToolStripMenuItem";
            this.utilitariosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.utilitariosToolStripMenuItem.Text = "Utilitarios";
            // 
            // GoSistemaUtilitariosElegirPeriodo
            // 
            this.GoSistemaUtilitariosElegirPeriodo.Name = "GoSistemaUtilitariosElegirPeriodo";
            this.GoSistemaUtilitariosElegirPeriodo.Size = new System.Drawing.Size(147, 22);
            this.GoSistemaUtilitariosElegirPeriodo.Text = "Elegir periodo";
            this.GoSistemaUtilitariosElegirPeriodo.Visible = false;
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoSistemaNewWindows,
            this.GoSistemaCascade,
            this.GoSistematileVertical,
            this.GoSistemaTileHorizontal,
            this.GoSistemacloseAll,
            this.GoSistemaArrangeIcons});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(66, 20);
            this.windowsMenu.Text = "&Ventanas";
            // 
            // GoSistemaNewWindows
            // 
            this.GoSistemaNewWindows.Name = "GoSistemaNewWindows";
            this.GoSistemaNewWindows.Size = new System.Drawing.Size(175, 22);
            this.GoSistemaNewWindows.Text = "&Nueva ventana";
            this.GoSistemaNewWindows.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
            // 
            // GoSistemaCascade
            // 
            this.GoSistemaCascade.Name = "GoSistemaCascade";
            this.GoSistemaCascade.Size = new System.Drawing.Size(175, 22);
            this.GoSistemaCascade.Text = "&Cascada";
            // 
            // GoSistematileVertical
            // 
            this.GoSistematileVertical.Name = "GoSistematileVertical";
            this.GoSistematileVertical.Size = new System.Drawing.Size(175, 22);
            this.GoSistematileVertical.Text = "Mosaico &vertical";
            // 
            // GoSistemaTileHorizontal
            // 
            this.GoSistemaTileHorizontal.Name = "GoSistemaTileHorizontal";
            this.GoSistemaTileHorizontal.Size = new System.Drawing.Size(175, 22);
            this.GoSistemaTileHorizontal.Text = "Mosaico &horizontal";
            // 
            // GoSistemacloseAll
            // 
            this.GoSistemacloseAll.Name = "GoSistemacloseAll";
            this.GoSistemacloseAll.Size = new System.Drawing.Size(175, 22);
            this.GoSistemacloseAll.Text = "C&errar todo";
            // 
            // GoSistemaArrangeIcons
            // 
            this.GoSistemaArrangeIcons.Name = "GoSistemaArrangeIcons";
            this.GoSistemaArrangeIcons.Size = new System.Drawing.Size(175, 22);
            this.GoSistemaArrangeIcons.Text = "&Organizar iconos";
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
            this.lblNombreDescripcion,
            this.lblConexión,
            this.lblConexionDescripcion});
            this.statusStrip.Location = new System.Drawing.Point(0, 433);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1203, 22);
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
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
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
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1203, 455);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Menu";
            this.Text = "Agrícola San José S.A  | Sullana | Piura | Perú  | V 1.1.20";
            this.toolTip.SetToolTip(this, "20.08.19");
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
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaNewWindows;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaCascade;
        private System.Windows.Forms.ToolStripMenuItem GoSistematileVertical;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem GoSistemacloseAll;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaArrangeIcons;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesCatalogoEmpresaTransporte;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesCatalogoRuta;
        private System.Windows.Forms.ToolStripMenuItem procesoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioNombre;
        private System.Windows.Forms.ToolStripStatusLabel lblNombre;
        private System.Windows.Forms.ToolStripStatusLabel lblNombreDescripcion;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesReporteAsistenciaByTablets;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillaCatalogoPersonal;
        private System.Windows.Forms.ToolStripMenuItem RRHHpersonalGeneral;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillaCatalogoPersonalAsignarParadero;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillaCatalogoPersonalObservados;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillaCatalogoTipoObservado;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillaMovimientoRegistroAsistencia;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesCatalogoParadero;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesReporteIngresoSalidaBuses;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillaProcesoActualizarListaSincronizacionATablets;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillaReporteAsistenciaObservadas;
        private System.Windows.Forms.ToolStripMenuItem GoPlanillaReporteReporteAsistencia;
        private System.Windows.Forms.ToolStripMenuItem GoTransportesReporteVencimientoDocumentos;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaCatalogoModulos;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaCatalogoFormularios;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaCatalogoPrivilegios;
        private System.Windows.Forms.ToolStripMenuItem GoSistemaCatalogoConfiguracion;
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
        private System.Windows.Forms.ToolStripMenuItem GoSistemaUtilitariosElegirPeriodo;
        private System.ComponentModel.BackgroundWorker bgwHilo;
        private System.Windows.Forms.ToolStripStatusLabel lblConexión;
        private System.Windows.Forms.ToolStripStatusLabel lblConexionDescripcion;
    }
}