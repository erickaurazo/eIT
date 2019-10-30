namespace RecursosHumanos
{
    partial class ReportAsistenciaPersonalASJBySistemasVarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAsistenciaPersonalASJBySistemasVarios));
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            this.menuPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnExportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.gbDatosConsulta = new Telerik.WinControls.UI.RadGroupBox();
            this.lblAño = new Telerik.WinControls.UI.RadLabel();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.txtAño = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.btnConsultar = new Telerik.WinControls.UI.RadButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFechaHasta = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.txtFechaDesde = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
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
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.gbResultado = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvResultado = new Telerik.WinControls.UI.RadGridView();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatosConsulta)).BeginInit();
            this.gbDatosConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbResultado)).BeginInit();
            this.gbResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.menuPrincipal.Size = new System.Drawing.Size(1185, 37);
            this.menuPrincipal.TabIndex = 185;
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
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
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
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbDatosConsulta
            // 
            this.gbDatosConsulta.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbDatosConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosConsulta.Controls.Add(this.lblAño);
            this.gbDatosConsulta.Controls.Add(this.lblFechaHasta);
            this.gbDatosConsulta.Controls.Add(this.txtAño);
            this.gbDatosConsulta.Controls.Add(this.lblFechaDesde);
            this.gbDatosConsulta.Controls.Add(this.btnConsultar);
            this.gbDatosConsulta.Controls.Add(this.label5);
            this.gbDatosConsulta.Controls.Add(this.txtFechaHasta);
            this.gbDatosConsulta.Controls.Add(this.cboMes);
            this.gbDatosConsulta.Controls.Add(this.txtFechaDesde);
            this.gbDatosConsulta.HeaderText = "";
            this.gbDatosConsulta.Location = new System.Drawing.Point(12, 41);
            this.gbDatosConsulta.Name = "gbDatosConsulta";
            this.gbDatosConsulta.Size = new System.Drawing.Size(1161, 70);
            this.gbDatosConsulta.TabIndex = 186;
            this.gbDatosConsulta.ThemeName = "Windows8";
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(8, 15);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(32, 18);
            this.lblAño.TabIndex = 2;
            this.lblAño.Text = "Año :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(204, 45);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(41, 13);
            this.lblFechaHasta.TabIndex = 8;
            this.lblFechaHasta.Text = "Hasta :";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(43, 13);
            this.txtAño.Maximum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.txtAño.Minimum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.txtAño.Name = "txtAño";
            // 
            // 
            // 
            this.txtAño.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtAño.Size = new System.Drawing.Size(46, 20);
            this.txtAño.TabIndex = 3;
            this.txtAño.TabStop = false;
            this.txtAño.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAño.ThemeName = "VisualStudio2012Light";
            this.txtAño.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.txtAño.ValueChanged += new System.EventHandler(this.txtAño_ValueChanged);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(95, 45);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(44, 13);
            this.lblFechaDesde.TabIndex = 6;
            this.lblFechaDesde.Text = "Desde :";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(1057, 30);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 28);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "&Consultar ";
            this.btnConsultar.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.ThemeName = "VisualStudio2012Light";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mes :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtFechaHasta.Location = new System.Drawing.Point(251, 43);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(70, 20);
            this.txtFechaHasta.TabIndex = 9;
            this.txtFechaHasta.TabStop = false;
            this.txtFechaHasta.Text = "__/__/____";
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaHasta.ThemeName = "Windows8";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(134, 13);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(187, 20);
            this.cboMes.TabIndex = 5;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtFechaDesde.Location = new System.Drawing.Point(134, 43);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(66, 20);
            this.txtFechaDesde.TabIndex = 7;
            this.txtFechaDesde.TabStop = false;
            this.txtFechaDesde.Text = "__/__/____";
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ThemeName = "Windows8";
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
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
            this.ProgressBar});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 482);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1185, 22);
            this.stsBarraEstado.TabIndex = 187;
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
            this.lblPromedio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblRecuento.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblSumaSeleccionada.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumaSeleccionada.Name = "lblSumaSeleccionada";
            this.lblSumaSeleccionada.Size = new System.Drawing.Size(32, 17);
            this.lblSumaSeleccionada.Text = "0.00";
            // 
            // ProgressBar
            // 
            this.ProgressBar.MarqueeAnimationSpeed = 25;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(300, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.Visible = false;
            // 
            // gbResultado
            // 
            this.gbResultado.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultado.Controls.Add(this.dgvResultado);
            this.gbResultado.HeaderText = "";
            this.gbResultado.Location = new System.Drawing.Point(12, 117);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(1161, 362);
            this.gbResultado.TabIndex = 188;
            this.gbResultado.ThemeName = "Windows8";
            // 
            // dgvResultado
            // 
            this.dgvResultado.BackColor = System.Drawing.SystemColors.Control;
            this.dgvResultado.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultado.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvResultado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvResultado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvResultado.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvResultado
            // 
            this.dgvResultado.MasterTemplate.AllowAddNewRow = false;
            this.dgvResultado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDate;
            gridViewDateTimeColumn1.FieldName = "Fecha";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            gridViewDateTimeColumn1.FormatString = "{0:d}";
            gridViewDateTimeColumn1.HeaderText = "Fecha";
            gridViewDateTimeColumn1.Name = "chFecha";
            gridViewDateTimeColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDateTimeColumn1.Width = 103;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "IdCodigoGeneral";
            gridViewTextBoxColumn1.HeaderText = "DNI";
            gridViewTextBoxColumn1.Name = "chIdCodigoGeneral";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 137;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Nombres";
            gridViewTextBoxColumn2.HeaderText = "Nombres";
            gridViewTextBoxColumn2.Name = "chNombres";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 324;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Estado";
            gridViewTextBoxColumn3.HeaderText = "Estado";
            gridViewTextBoxColumn3.Name = "chEstado";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 117;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "ControlAsistencia";
            gridViewDecimalColumn1.HeaderText = "ControlAsistencia";
            gridViewDecimalColumn1.Name = "chControlAsistencia";
            gridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn1.Width = 117;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.FieldName = "ControlTareo";
            gridViewDecimalColumn2.HeaderText = "ControlTareo";
            gridViewDecimalColumn2.Name = "chControlTareo";
            gridViewDecimalColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn2.Width = 117;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.FieldName = "Nisira";
            gridViewDecimalColumn3.HeaderText = "Sistema NISIRA";
            gridViewDecimalColumn3.Name = "chNisira";
            gridViewDecimalColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn3.Width = 117;
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.FieldName = "TotalMarcaciones";
            gridViewDecimalColumn4.HeaderText = "Total de marcaciones";
            gridViewDecimalColumn4.Name = "chTotalMarcaciones";
            gridViewDecimalColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn4.Width = 114;
            this.dgvResultado.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewDecimalColumn1,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4});
            this.dgvResultado.MasterTemplate.EnableFiltering = true;
            this.dgvResultado.MasterTemplate.ShowHeaderCellButtons = true;
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvResultado.ShowHeaderCellButtons = true;
            this.dgvResultado.Size = new System.Drawing.Size(1157, 342);
            this.dgvResultado.TabIndex = 0;
            this.dgvResultado.Text = "radGridView1";
            this.dgvResultado.ThemeName = "VisualStudio2012Light";
            // 
            // ReportAsistenciaPersonalASJBySistemasVarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1185, 504);
            this.Controls.Add(this.gbResultado);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.gbDatosConsulta);
            this.Controls.Add(this.menuPrincipal);
            this.Name = "ReportAsistenciaPersonalASJBySistemasVarios";
            this.Text = "Report de asistencia personal ASJ - Asistencia puerta / Tareo SisAgri / NISIRA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportAsistenciaPersonalASJBySistemasVarios_FormClosing);
            this.Load += new System.EventHandler(this.ReportAsistenciaPersonalASJBySistemasVarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatosConsulta)).EndInit();
            this.gbDatosConsulta.ResumeLayout(false);
            this.gbDatosConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbResultado)).EndInit();
            this.gbResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
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
        private Telerik.WinControls.UI.CommandBarButton btnExportar;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.RadGroupBox gbDatosConsulta;
        private Telerik.WinControls.UI.RadLabel lblAño;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.UI.RadSpinEditor txtAño;
        private System.Windows.Forms.Label lblFechaDesde;
        private Telerik.WinControls.UI.RadButton btnConsultar;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadMaskedEditBox txtFechaHasta;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private Telerik.WinControls.UI.RadMaskedEditBox txtFechaDesde;
        private System.ComponentModel.BackgroundWorker bgwHilo;
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
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private Telerik.WinControls.UI.RadGroupBox gbResultado;
        private Telerik.WinControls.UI.RadGridView dgvResultado;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

    }
}