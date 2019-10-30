namespace RecursosHumanos
{
    partial class Usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuarios));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.gbConsulta = new Telerik.WinControls.UI.RadGroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.txtAño = new Telerik.WinControls.UI.RadSpinEditor();
            this.btnConsultar = new Telerik.WinControls.UI.RadButton();
            this.gbPrivilegios = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvUsuarios = new Telerik.WinControls.UI.RadGridView();
            this.subMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.registrarBajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarAltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleDePrivilegiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificarAltaSinVerificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificarBajaSinVerificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnAdministracionSistema = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnAltaBaja = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnExportarLista = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator4 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).BeginInit();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbPrivilegios)).BeginInit();
            this.gbPrivilegios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios.MasterTemplate)).BeginInit();
            this.subMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConsulta
            // 
            this.gbConsulta.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsulta.Controls.Add(this.progressBar);
            this.gbConsulta.Controls.Add(this.radLabel7);
            this.gbConsulta.Controls.Add(this.txtAño);
            this.gbConsulta.Controls.Add(this.btnConsultar);
            this.gbConsulta.FooterImageIndex = -1;
            this.gbConsulta.FooterImageKey = "";
            this.gbConsulta.HeaderImageIndex = -1;
            this.gbConsulta.HeaderImageKey = "";
            this.gbConsulta.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.gbConsulta.HeaderText = "Consulta";
            this.gbConsulta.Location = new System.Drawing.Point(10, 40);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.gbConsulta.Size = new System.Drawing.Size(1008, 55);
            this.gbConsulta.TabIndex = 164;
            this.gbConsulta.Text = "Consulta";
            this.gbConsulta.ThemeName = "Office2010Silver";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(188, 27);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(367, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 167;
            this.progressBar.Visible = false;
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(6, 30);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(32, 18);
            this.radLabel7.TabIndex = 166;
            this.radLabel7.Text = "Año :";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(42, 29);
            this.txtAño.Maximum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.txtAño.Name = "txtAño";
            // 
            // 
            // 
            this.txtAño.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtAño.ShowBorder = true;
            this.txtAño.Size = new System.Drawing.Size(46, 20);
            this.txtAño.TabIndex = 165;
            this.txtAño.TabStop = false;
            this.txtAño.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAño.ThemeName = "Office2010Silver";
            this.txtAño.Value = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(94, 24);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 28);
            this.btnConsultar.TabIndex = 159;
            this.btnConsultar.Text = "&Consultar ";
            this.btnConsultar.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.ThemeName = "Office2010Silver";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gbPrivilegios
            // 
            this.gbPrivilegios.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbPrivilegios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPrivilegios.Controls.Add(this.dgvUsuarios);
            this.gbPrivilegios.FooterImageIndex = -1;
            this.gbPrivilegios.FooterImageKey = "";
            this.gbPrivilegios.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbPrivilegios.HeaderImageIndex = -1;
            this.gbPrivilegios.HeaderImageKey = "";
            this.gbPrivilegios.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.gbPrivilegios.HeaderText = "Listado de Usuarios";
            this.gbPrivilegios.Location = new System.Drawing.Point(10, 106);
            this.gbPrivilegios.Name = "gbPrivilegios";
            this.gbPrivilegios.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.gbPrivilegios.Size = new System.Drawing.Size(1008, 253);
            this.gbPrivilegios.TabIndex = 163;
            this.gbPrivilegios.Text = "Listado de Usuarios";
            this.gbPrivilegios.ThemeName = "Office2010Silver";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.BackColor = System.Drawing.SystemColors.Control;
            this.dgvUsuarios.ContextMenuStrip = this.subMenu;
            this.dgvUsuarios.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvUsuarios.ForeColor = System.Drawing.Color.Black;
            this.dgvUsuarios.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvUsuarios.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.MasterTemplate.AllowAddNewRow = false;
            this.dgvUsuarios.MasterTemplate.AutoGenerateColumns = false;
            this.dgvUsuarios.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "IDUSUARIO";
            gridViewTextBoxColumn1.HeaderText = "Id. Usuario";
            gridViewTextBoxColumn1.Name = "chIDUSUARIO";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 136;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "usr_iniciales";
            gridViewTextBoxColumn2.HeaderText = "Iniciales";
            gridViewTextBoxColumn2.Name = "chIniciales";
            gridViewTextBoxColumn2.Width = 93;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "usr_nombres";
            gridViewTextBoxColumn3.HeaderText = "Nombres";
            gridViewTextBoxColumn3.Name = "chNombres";
            gridViewTextBoxColumn3.Width = 370;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Cargo";
            gridViewTextBoxColumn4.HeaderText = "Cargo";
            gridViewTextBoxColumn4.Name = "chCargo";
            gridViewTextBoxColumn4.Width = 88;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Area";
            gridViewTextBoxColumn5.HeaderText = "Area";
            gridViewTextBoxColumn5.Name = "chArea";
            gridViewTextBoxColumn5.Width = 73;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Email";
            gridViewTextBoxColumn6.HeaderText = "Email";
            gridViewTextBoxColumn6.Name = "chEmail";
            gridViewTextBoxColumn6.Width = 206;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Estado";
            gridViewTextBoxColumn7.HeaderText = "Estado";
            gridViewTextBoxColumn7.Name = "chEstado";
            gridViewTextBoxColumn7.Width = 23;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "idCodigoGeneral";
            gridViewTextBoxColumn8.HeaderText = "idCodigoGeneral";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "chidCodigoGeneral";
            gridViewTextBoxColumn8.Width = 46;
            this.dgvUsuarios.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.dgvUsuarios.MasterTemplate.EnableFiltering = true;
            this.dgvUsuarios.MasterTemplate.MultiSelect = true;
            this.dgvUsuarios.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvUsuarios.Size = new System.Drawing.Size(1004, 233);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.ThemeName = "Office2010Silver";
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            this.dgvUsuarios.DoubleClick += new System.EventHandler(this.dgvUsuarios_DoubleClick);
            // 
            // subMenu
            // 
            this.subMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarBajaToolStripMenuItem,
            this.registrarAltaToolStripMenuItem,
            this.detalleDePrivilegiosToolStripMenuItem,
            this.notificarAltaSinVerificarToolStripMenuItem,
            this.notificarBajaSinVerificarToolStripMenuItem});
            this.subMenu.Name = "subMenu";
            this.subMenu.Size = new System.Drawing.Size(268, 114);
            // 
            // registrarBajaToolStripMenuItem
            // 
            this.registrarBajaToolStripMenuItem.Name = "registrarBajaToolStripMenuItem";
            this.registrarBajaToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.registrarBajaToolStripMenuItem.Text = "Registrar y Notificar Baja ";
            this.registrarBajaToolStripMenuItem.Click += new System.EventHandler(this.registrarBajaToolStripMenuItem_Click);
            // 
            // registrarAltaToolStripMenuItem
            // 
            this.registrarAltaToolStripMenuItem.Name = "registrarAltaToolStripMenuItem";
            this.registrarAltaToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.registrarAltaToolStripMenuItem.Text = "Registrar y Notificar Alta";
            this.registrarAltaToolStripMenuItem.Click += new System.EventHandler(this.registrarAltaToolStripMenuItem_Click);
            // 
            // detalleDePrivilegiosToolStripMenuItem
            // 
            this.detalleDePrivilegiosToolStripMenuItem.Name = "detalleDePrivilegiosToolStripMenuItem";
            this.detalleDePrivilegiosToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.detalleDePrivilegiosToolStripMenuItem.Text = "Detalle de Privilegios";
            this.detalleDePrivilegiosToolStripMenuItem.Click += new System.EventHandler(this.detalleDePrivilegiosToolStripMenuItem_Click);
            // 
            // notificarAltaSinVerificarToolStripMenuItem
            // 
            this.notificarAltaSinVerificarToolStripMenuItem.Name = "notificarAltaSinVerificarToolStripMenuItem";
            this.notificarAltaSinVerificarToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.notificarAltaSinVerificarToolStripMenuItem.Text = "Registrar y Notificar Alta sin Verificar";
            this.notificarAltaSinVerificarToolStripMenuItem.Click += new System.EventHandler(this.notificarAltaSinVerificarToolStripMenuItem_Click);
            // 
            // notificarBajaSinVerificarToolStripMenuItem
            // 
            this.notificarBajaSinVerificarToolStripMenuItem.Name = "notificarBajaSinVerificarToolStripMenuItem";
            this.notificarBajaSinVerificarToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.notificarBajaSinVerificarToolStripMenuItem.Text = "Registrar y Notificar Baja sin Verificar";
            this.notificarBajaSinVerificarToolStripMenuItem.Click += new System.EventHandler(this.notificarBajaSinVerificarToolStripMenuItem_Click);
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.AutoSize = true;
            this.menuPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.menuPrincipal.Size = new System.Drawing.Size(1030, 34);
            this.menuPrincipal.TabIndex = 165;
            this.menuPrincipal.Text = "Nuevo";
            this.menuPrincipal.ThemeName = "Office2010Silver";
            // 
            // BarraSuperior
            // 
            this.BarraSuperior.DisplayName = "";
            this.BarraSuperior.MinSize = new System.Drawing.Size(25, 25);
            this.BarraSuperior.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.BarraModulo,
            this.commandBarStripElement3});
            this.BarraSuperior.Text = "";
            // 
            // BarraModulo
            // 
            this.BarraModulo.DisplayName = "commandBarStripElement2";
            this.BarraModulo.FloatingForm = null;
            this.BarraModulo.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnAdministracionSistema});
            this.BarraModulo.Name = "commandBarStripElement2";
            this.BarraModulo.Text = "";
            // 
            // btnAdministracionSistema
            // 
            this.btnAdministracionSistema.AccessibleDescription = "AdministracionSistema";
            this.btnAdministracionSistema.AccessibleName = "AdministracionSistema";
            this.btnAdministracionSistema.DisplayName = "AdministracionSistema";
            this.btnAdministracionSistema.DrawText = true;
            this.btnAdministracionSistema.Image = ((System.Drawing.Image)(resources.GetObject("btnAdministracionSistema.Image")));
            this.btnAdministracionSistema.Name = "btnAdministracionSistema";
            this.btnAdministracionSistema.Text = "Administración Sistema";
            this.btnAdministracionSistema.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdministracionSistema.ToolTipText = "Recursos Humanos";
            this.btnAdministracionSistema.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.FloatingForm = null;
            this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.commandBarSeparator1,
            this.btnAltaBaja,
            this.commandBarSeparator3,
            this.btnExportarLista,
            this.commandBarSeparator2,
            this.btnSalir,
            this.commandBarSeparator4});
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            this.commandBarStripElement3.Text = "";
            this.commandBarStripElement3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleDescription = "Nuevo";
            this.btnNuevo.AccessibleName = "Nuevo";
            this.btnNuevo.AutoSize = false;
            this.btnNuevo.Bounds = new System.Drawing.Rectangle(0, 0, 35, 30);
            this.btnNuevo.DisplayName = "Nuevo";
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "";
            this.btnNuevo.ToolTipText = "Registrar Nuevo Privilegio";
            this.btnNuevo.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AccessibleDescription = "Editar";
            this.btnEditar.AccessibleName = "Editar";
            this.btnEditar.AutoSize = false;
            this.btnEditar.Bounds = new System.Drawing.Rectangle(0, 0, 35, 30);
            this.btnEditar.DisplayName = "Editar";
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "";
            this.btnEditar.ToolTipText = "Editar Privilegio";
            this.btnEditar.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
            this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // btnAltaBaja
            // 
            this.btnAltaBaja.AccessibleDescription = "AltaBaja";
            this.btnAltaBaja.AccessibleName = "AltaBaja";
            this.btnAltaBaja.AutoSize = false;
            this.btnAltaBaja.Bounds = new System.Drawing.Rectangle(0, 0, 35, 30);
            this.btnAltaBaja.DisplayName = "Alta y Baja";
            this.btnAltaBaja.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaBaja.Image")));
            this.btnAltaBaja.Name = "btnAltaBaja";
            this.btnAltaBaja.Text = "btnAltaBaja";
            this.btnAltaBaja.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnAltaBaja.Click += new System.EventHandler(this.btnAltaBaja_Click);
            // 
            // commandBarSeparator3
            // 
            this.commandBarSeparator3.AccessibleDescription = "commandBarSeparator3";
            this.commandBarSeparator3.AccessibleName = "commandBarSeparator3";
            this.commandBarSeparator3.DisplayName = "commandBarSeparator3";
            this.commandBarSeparator3.Name = "commandBarSeparator3";
            this.commandBarSeparator3.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator3.VisibleInOverflowMenu = false;
            // 
            // btnExportarLista
            // 
            this.btnExportarLista.AccessibleDescription = "Exportar";
            this.btnExportarLista.AccessibleName = "Exportar";
            this.btnExportarLista.AutoSize = false;
            this.btnExportarLista.Bounds = new System.Drawing.Rectangle(0, 0, 35, 30);
            this.btnExportarLista.DisplayName = "Exportar";
            this.btnExportarLista.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarLista.Image")));
            this.btnExportarLista.Name = "btnExportarLista";
            this.btnExportarLista.Text = "";
            this.btnExportarLista.ToolTipText = "Exportar Lista de Privilegios";
            this.btnExportarLista.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnExportarLista.Click += new System.EventHandler(this.btnExportarLista_Click);
            // 
            // commandBarSeparator2
            // 
            this.commandBarSeparator2.AccessibleDescription = "commandBarSeparator2";
            this.commandBarSeparator2.AccessibleName = "commandBarSeparator2";
            this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
            this.commandBarSeparator2.Name = "commandBarSeparator2";
            this.commandBarSeparator2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator2.VisibleInOverflowMenu = false;
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleDescription = "Salir";
            this.btnSalir.AccessibleName = "Salir";
            this.btnSalir.AutoSize = false;
            this.btnSalir.Bounds = new System.Drawing.Rectangle(0, 0, 35, 30);
            this.btnSalir.DisplayName = "Salir";
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "";
            this.btnSalir.ToolTipText = "Salir";
            this.btnSalir.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // commandBarSeparator4
            // 
            this.commandBarSeparator4.AccessibleDescription = "commandBarSeparator4";
            this.commandBarSeparator4.AccessibleName = "commandBarSeparator4";
            this.commandBarSeparator4.DisplayName = "commandBarSeparator4";
            this.commandBarSeparator4.Name = "commandBarSeparator4";
            this.commandBarSeparator4.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator4.VisibleInOverflowMenu = false;
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // Usuarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1030, 371);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.gbPrivilegios);
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Usuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).EndInit();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbPrivilegios)).EndInit();
            this.gbPrivilegios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.subMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbConsulta;
        private System.Windows.Forms.ProgressBar progressBar;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadSpinEditor txtAño;
        private Telerik.WinControls.UI.RadButton btnConsultar;
        private Telerik.WinControls.UI.RadGroupBox gbPrivilegios;
        private Telerik.WinControls.UI.RadGridView dgvUsuarios;
        private Telerik.WinControls.UI.RadCommandBar menuPrincipal;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnAdministracionSistema;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnEditar;
        private Telerik.WinControls.UI.CommandBarButton btnExportarLista;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.ComponentModel.BackgroundWorker bgwHilo;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarButton btnAltaBaja;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator4;
        private System.Windows.Forms.ContextMenuStrip subMenu;
        private System.Windows.Forms.ToolStripMenuItem registrarBajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarAltaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detalleDePrivilegiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificarAltaSinVerificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificarBajaSinVerificarToolStripMenuItem;
    }
}