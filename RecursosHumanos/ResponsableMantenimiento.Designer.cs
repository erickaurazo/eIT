﻿namespace RecursosHumanos
{
    partial class ResponsableMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResponsableMantenimiento));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.menuPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnAgregar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnQuitar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnGrabar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnAtras = new Telerik.WinControls.UI.CommandBarButton();
            this.btnAnular = new Telerik.WinControls.UI.CommandBarButton();
            this.btnHistorial = new Telerik.WinControls.UI.CommandBarButton();
            this.btnImportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnExportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.subMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sbmeditarMovimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.sbmAnularMovimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.sbmEliminarMovimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.stsBarraEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPromedio = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecuento = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSumaSeleccionada = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTiempoTranscurrido = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroResultados = new System.Windows.Forms.ToolStripStatusLabel();
            this.bwgHilo = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gbRegistros = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvRegistros = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).BeginInit();
            this.subMenu.SuspendLayout();
            this.stsBarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).BeginInit();
            this.gbRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.menuPrincipal.Size = new System.Drawing.Size(1261, 35);
            this.menuPrincipal.TabIndex = 183;
            this.menuPrincipal.Text = "Nuevo";
            this.menuPrincipal.ThemeName = "VisualStudio2012Light";
            // 
            // BarraSuperior
            // 
            this.BarraSuperior.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BarraSuperior.MinSize = new System.Drawing.Size(25, 25);
            this.BarraSuperior.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.BarraModulo,
            this.commandBarStripElement3});
            this.BarraSuperior.Text = "";
            this.BarraSuperior.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // BarraModulo
            // 
            this.BarraModulo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BarraModulo.DisplayName = "commandBarStripElement2";
            this.BarraModulo.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnRRHH});
            this.BarraModulo.Name = "commandBarStripElement2";
            this.BarraModulo.Text = "";
            this.BarraModulo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnRRHH
            // 
            this.btnRRHH.AccessibleDescription = "RecursosHumanos";
            this.btnRRHH.AccessibleName = "RecursosHumanos";
            this.btnRRHH.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRRHH.DisplayName = "Recursos Humanos";
            this.btnRRHH.DrawText = true;
            this.btnRRHH.Image = ((System.Drawing.Image)(resources.GetObject("btnRRHH.Image")));
            this.btnRRHH.Name = "btnRRHH";
            this.btnRRHH.Text = "Recursos Humanos";
            this.btnRRHH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRRHH.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRRHH.ToolTipText = "Recursos Humanos";
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnAgregar,
            this.btnQuitar,
            this.btnGrabar,
            this.btnAtras,
            this.btnAnular,
            this.btnHistorial,
            this.btnImportar,
            this.btnExportar,
            this.btnSalir});
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            this.commandBarStripElement3.Text = "";
            this.commandBarStripElement3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandBarStripElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleDescription = "Nuevo";
            this.btnNuevo.AccessibleName = "Nuevo";
            this.btnNuevo.AutoSize = false;
            this.btnNuevo.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnNuevo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.DisplayName = "Nuevo";
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "";
            this.btnNuevo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.ToolTipText = "Nuevo";
            // 
            // btnEditar
            // 
            this.btnEditar.AccessibleDescription = "Editar";
            this.btnEditar.AccessibleName = "Editar";
            this.btnEditar.AutoSize = false;
            this.btnEditar.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnEditar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEditar.DisplayName = "Editar";
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "";
            this.btnEditar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEditar.ToolTipText = "Editar Registro";
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = false;
            this.btnAgregar.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnAgregar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAgregar.DisplayName = "commandBarButton1";
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Text = "";
            this.btnAgregar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnQuitar
            // 
            this.btnQuitar.AutoSize = false;
            this.btnQuitar.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnQuitar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnQuitar.DisplayName = "commandBarButton2";
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Text = "";
            this.btnQuitar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnGrabar
            // 
            this.btnGrabar.AccessibleDescription = "Grabar";
            this.btnGrabar.AccessibleName = "Grabar";
            this.btnGrabar.AutoSize = false;
            this.btnGrabar.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnGrabar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnGrabar.DisplayName = "Grabar";
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Text = "";
            this.btnGrabar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnGrabar.ToolTipText = "Grabar";
            // 
            // btnAtras
            // 
            this.btnAtras.AccessibleDescription = "Atrás";
            this.btnAtras.AccessibleName = "Atrás";
            this.btnAtras.AutoSize = false;
            this.btnAtras.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnAtras.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAtras.DisplayName = "Atrás";
            this.btnAtras.Enabled = false;
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Text = "";
            this.btnAtras.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnAnular
            // 
            this.btnAnular.AccessibleDescription = "Anular";
            this.btnAnular.AccessibleName = "Anular";
            this.btnAnular.AutoSize = false;
            this.btnAnular.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnAnular.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAnular.DisplayName = "Anular";
            this.btnAnular.Enabled = false;
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Text = "";
            this.btnAnular.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAnular.ToolTipText = "Anular Registro";
            // 
            // btnHistorial
            // 
            this.btnHistorial.AccessibleDescription = "Historial";
            this.btnHistorial.AccessibleName = "Historial";
            this.btnHistorial.AutoSize = false;
            this.btnHistorial.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnHistorial.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnHistorial.DisplayName = "Historial";
            this.btnHistorial.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorial.Image")));
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Text = "";
            this.btnHistorial.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnHistorial.ToolTipText = "Historial";
            // 
            // btnImportar
            // 
            this.btnImportar.AccessibleDescription = "Importar ";
            this.btnImportar.AccessibleName = "Importar ";
            this.btnImportar.AutoSize = false;
            this.btnImportar.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnImportar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnImportar.DisplayName = "commandBarButton1";
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Text = "";
            this.btnImportar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnExportar
            // 
            this.btnExportar.AccessibleDescription = "Exportar";
            this.btnExportar.AccessibleName = "Exportar";
            this.btnExportar.AutoSize = false;
            this.btnExportar.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnExportar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnExportar.DisplayName = "Exportar";
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Text = "";
            this.btnExportar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnExportar.ToolTipText = "Exportar";
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleDescription = "Salir";
            this.btnSalir.AccessibleName = "Salir";
            this.btnSalir.AutoSize = false;
            this.btnSalir.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnSalir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.DisplayName = "Salir";
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "";
            this.btnSalir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.ToolTipText = "Salir";
            // 
            // subMenu
            // 
            this.subMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbmeditarMovimiento,
            this.sbmAnularMovimiento,
            this.sbmEliminarMovimiento});
            this.subMenu.Name = "subMenu";
            this.subMenu.Size = new System.Drawing.Size(126, 94);
            // 
            // sbmeditarMovimiento
            // 
            this.sbmeditarMovimiento.Image = ((System.Drawing.Image)(resources.GetObject("sbmeditarMovimiento.Image")));
            this.sbmeditarMovimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sbmeditarMovimiento.Name = "sbmeditarMovimiento";
            this.sbmeditarMovimiento.Size = new System.Drawing.Size(125, 30);
            this.sbmeditarMovimiento.Text = "Editar";
            // 
            // sbmAnularMovimiento
            // 
            this.sbmAnularMovimiento.Image = ((System.Drawing.Image)(resources.GetObject("sbmAnularMovimiento.Image")));
            this.sbmAnularMovimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sbmAnularMovimiento.Name = "sbmAnularMovimiento";
            this.sbmAnularMovimiento.Size = new System.Drawing.Size(125, 30);
            this.sbmAnularMovimiento.Text = "Anular";
            // 
            // sbmEliminarMovimiento
            // 
            this.sbmEliminarMovimiento.Image = ((System.Drawing.Image)(resources.GetObject("sbmEliminarMovimiento.Image")));
            this.sbmEliminarMovimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sbmEliminarMovimiento.Name = "sbmEliminarMovimiento";
            this.sbmEliminarMovimiento.Size = new System.Drawing.Size(125, 30);
            this.sbmEliminarMovimiento.Text = "Eliminar";
            // 
            // stsBarraEstado
            // 
            this.stsBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel6,
            this.lblPromedio,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel4,
            this.lblRecuento,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.lblSumaSeleccionada,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel8,
            this.lblTiempoTranscurrido,
            this.ProgressBar,
            this.lblNumeroResultados});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 752);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1261, 22);
            this.stsBarraEstado.TabIndex = 185;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel6.Text = "Promedio";
            // 
            // lblPromedio
            // 
            this.lblPromedio.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(32, 17);
            this.lblPromedio.Text = "0.00";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel5.Text = "       ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel4.Text = "Recuento";
            // 
            // lblRecuento
            // 
            this.lblRecuento.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblRecuento.Name = "lblRecuento";
            this.lblRecuento.Size = new System.Drawing.Size(14, 17);
            this.lblRecuento.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel3.Text = "       ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel2.Text = "Suma";
            // 
            // lblSumaSeleccionada
            // 
            this.lblSumaSeleccionada.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSumaSeleccionada.Name = "lblSumaSeleccionada";
            this.lblSumaSeleccionada.Size = new System.Drawing.Size(32, 17);
            this.lblSumaSeleccionada.Text = "0.00";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel7.Text = "     ";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(132, 17);
            this.toolStripStatusLabel8.Text = "  Tiempo Transcurrido : ";
            // 
            // lblTiempoTranscurrido
            // 
            this.lblTiempoTranscurrido.Name = "lblTiempoTranscurrido";
            this.lblTiempoTranscurrido.Size = new System.Drawing.Size(49, 17);
            this.lblTiempoTranscurrido.Text = "00:00:00";
            // 
            // ProgressBar
            // 
            this.ProgressBar.MarqueeAnimationSpeed = 25;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(160, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
            // 
            // gbRegistros
            // 
            this.gbRegistros.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbRegistros.Controls.Add(this.dgvRegistros);
            this.gbRegistros.HeaderText = "  Actividades";
            this.gbRegistros.Location = new System.Drawing.Point(12, 41);
            this.gbRegistros.Name = "gbRegistros";
            this.gbRegistros.Size = new System.Drawing.Size(605, 703);
            this.gbRegistros.TabIndex = 207;
            this.gbRegistros.Text = "  Actividades";
            this.gbRegistros.ThemeName = "Office2007Silver";
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.AutoGenerateHierarchy = true;
            this.dgvRegistros.BackColor = System.Drawing.SystemColors.Control;
            this.dgvRegistros.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistros.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dgvRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvRegistros.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.MasterTemplate.AllowAddNewRow = false;
            this.dgvRegistros.MasterTemplate.AllowRowReorder = true;
            this.dgvRegistros.MasterTemplate.AutoGenerateColumns = false;
            this.dgvRegistros.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "CodigoEmpresa";
            gridViewTextBoxColumn6.HeaderText = "CodigoEmpresa";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "chCodigoEmpresa";
            gridViewTextBoxColumn6.Width = 475;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "CodigoActividad";
            gridViewTextBoxColumn7.HeaderText = "Cod. Actividad";
            gridViewTextBoxColumn7.Name = "chCodigoActividad";
            gridViewTextBoxColumn7.Width = 91;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Descripcion";
            gridViewTextBoxColumn8.HeaderText = "Descripción";
            gridViewTextBoxColumn8.Name = "chDescripcion";
            gridViewTextBoxColumn8.Width = 392;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Descripcioncorta";
            gridViewTextBoxColumn9.HeaderText = "Desc. Corta";
            gridViewTextBoxColumn9.Name = "chDescripcioncorta";
            gridViewTextBoxColumn9.Width = 102;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "estado";
            gridViewTextBoxColumn10.HeaderText = "Estado";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "chEstado";
            gridViewTextBoxColumn10.Width = 46;
            this.dgvRegistros.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.dgvRegistros.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvRegistros.MasterTemplate.EnableFiltering = true;
            this.dgvRegistros.MasterTemplate.MultiSelect = true;
            this.dgvRegistros.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvRegistros.Size = new System.Drawing.Size(601, 683);
            this.dgvRegistros.TabIndex = 0;
            this.dgvRegistros.ThemeName = "VisualStudio2012Light";
            // 
            // ResponsableMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 774);
            this.Controls.Add(this.gbRegistros);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.menuPrincipal);
            this.Name = "ResponsableMantenimiento";
            this.Text = "Responsable ";
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).EndInit();
            this.subMenu.ResumeLayout(false);
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).EndInit();
            this.gbRegistros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar menuPrincipal;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnEditar;
        private Telerik.WinControls.UI.CommandBarButton btnAgregar;
        private Telerik.WinControls.UI.CommandBarButton btnQuitar;
        private Telerik.WinControls.UI.CommandBarButton btnGrabar;
        private Telerik.WinControls.UI.CommandBarButton btnAtras;
        private Telerik.WinControls.UI.CommandBarButton btnAnular;
        private Telerik.WinControls.UI.CommandBarButton btnHistorial;
        private Telerik.WinControls.UI.CommandBarButton btnImportar;
        private Telerik.WinControls.UI.CommandBarButton btnExportar;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private System.Windows.Forms.ContextMenuStrip subMenu;
        private System.Windows.Forms.ToolStripMenuItem sbmeditarMovimiento;
        private System.Windows.Forms.ToolStripMenuItem sbmAnularMovimiento;
        private System.Windows.Forms.ToolStripMenuItem sbmEliminarMovimiento;
        private System.Windows.Forms.StatusStrip stsBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblPromedio;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblRecuento;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblSumaSeleccionada;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempoTranscurrido;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroResultados;
        private System.ComponentModel.BackgroundWorker bwgHilo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Telerik.WinControls.UI.RadGroupBox gbRegistros;
        private Telerik.WinControls.UI.RadGridView dgvRegistros;
    }
}