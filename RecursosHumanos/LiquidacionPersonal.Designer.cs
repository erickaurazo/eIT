namespace RecursosHumanos
{
    partial class LiquidacionPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiquidacionPersonal));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.menuPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnExportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.gbLista = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvPersonalLiquidado = new Telerik.WinControls.UI.RadGridView();
            this.gbConsulta = new Telerik.WinControls.UI.RadGroupBox();
            this.cboPlanilla = new Telerik.WinControls.UI.RadDropDownList();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtAño = new Telerik.WinControls.UI.RadSpinEditor();
            this.btnConsultar = new Telerik.WinControls.UI.RadButton();
            this.txtFechaHasta = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.txtFechaDesde = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.bwgHilo = new System.ComponentModel.BackgroundWorker();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbLista)).BeginInit();
            this.gbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalLiquidado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalLiquidado.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).BeginInit();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior,
            this.commandBarRowElement1});
            this.menuPrincipal.Size = new System.Drawing.Size(1241, 60);
            this.menuPrincipal.TabIndex = 167;
            this.menuPrincipal.Text = "Nuevo";
            this.menuPrincipal.ThemeName = "VisualStudio2012Light";
            // 
            // BarraSuperior
            // 
            this.BarraSuperior.MinSize = new System.Drawing.Size(25, 25);
            this.BarraSuperior.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.BarraModulo,
            this.commandBarStripElement3});
            this.BarraSuperior.Text = "";
            // 
            // BarraModulo
            // 
            this.BarraModulo.DisplayName = "commandBarStripElement2";
            this.BarraModulo.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnRRHH});
            this.BarraModulo.Name = "commandBarStripElement2";
            this.BarraModulo.Text = "";
            // 
            // btnRRHH
            // 
            this.btnRRHH.AccessibleDescription = "RecursosHumanos";
            this.btnRRHH.AccessibleName = "RecursosHumanos";
            this.btnRRHH.DisplayName = "Recursos Humanos";
            this.btnRRHH.DrawText = true;
            this.btnRRHH.Image = ((System.Drawing.Image)(resources.GetObject("btnRRHH.Image")));
            this.btnRRHH.Name = "btnRRHH";
            this.btnRRHH.Text = "     Recursos Humanos";
            this.btnRRHH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRRHH.ToolTipText = "Recursos Humanos";
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnExportar,
            this.btnSalir});
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            this.commandBarStripElement3.Text = "";
            this.commandBarStripElement3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportar
            // 
            this.btnExportar.AccessibleDescription = "Exportar";
            this.btnExportar.AccessibleName = "Exportar";
            this.btnExportar.AutoSize = false;
            this.btnExportar.Bounds = new System.Drawing.Rectangle(0, 0, 80, 28);
            this.btnExportar.DisplayName = "Exportar";
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Text = "Exportar";
            this.btnExportar.ToolTipText = "Exportar";
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleDescription = "Salir";
            this.btnSalir.AccessibleName = "Salir";
            this.btnSalir.AutoSize = false;
            this.btnSalir.Bounds = new System.Drawing.Rectangle(0, 0, 80, 28);
            this.btnSalir.DisplayName = "Salir";
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir";
            this.btnSalir.ToolTipText = "Salir";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            // 
            // gbLista
            // 
            this.gbLista.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLista.Controls.Add(this.dgvPersonalLiquidado);
            this.gbLista.HeaderText = "Listado";
            this.gbLista.Location = new System.Drawing.Point(4, 101);
            this.gbLista.Name = "gbLista";
            this.gbLista.Size = new System.Drawing.Size(1237, 399);
            this.gbLista.TabIndex = 168;
            this.gbLista.Text = "Listado";
            this.gbLista.ThemeName = "VisualStudio2012Light";
            // 
            // dgvPersonalLiquidado
            // 
            this.dgvPersonalLiquidado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgvPersonalLiquidado.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPersonalLiquidado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonalLiquidado.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvPersonalLiquidado.ForeColor = System.Drawing.Color.Black;
            this.dgvPersonalLiquidado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvPersonalLiquidado.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvPersonalLiquidado
            // 
            this.dgvPersonalLiquidado.MasterTemplate.AllowAddNewRow = false;
            this.dgvPersonalLiquidado.MasterTemplate.AllowColumnReorder = false;
            this.dgvPersonalLiquidado.MasterTemplate.AutoGenerateColumns = false;
            this.dgvPersonalLiquidado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "idmovimiento";
            gridViewTextBoxColumn1.HeaderText = "idmovimiento";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "chidmovimiento";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "idcodigogeneral";
            gridViewTextBoxColumn2.HeaderText = "Cod. Empleado";
            gridViewTextBoxColumn2.Name = "chidcodigogeneral";
            gridViewTextBoxColumn2.Width = 74;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "ApeNom";
            gridViewTextBoxColumn3.HeaderText = "Nombres";
            gridViewTextBoxColumn3.Name = "chApeNom";
            gridViewTextBoxColumn3.Width = 198;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "documento";
            gridViewTextBoxColumn4.HeaderText = "Documento";
            gridViewTextBoxColumn4.Name = "chdocumento";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 119;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "operacion";
            gridViewTextBoxColumn5.HeaderText = "Nro Operación";
            gridViewTextBoxColumn5.Name = "choperacion";
            gridViewTextBoxColumn5.Width = 109;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "afp_dsc";
            gridViewTextBoxColumn6.HeaderText = "AFP";
            gridViewTextBoxColumn6.Name = "chafp_dsc";
            gridViewTextBoxColumn6.Width = 128;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "estado_pers";
            gridViewTextBoxColumn7.HeaderText = "Situacion Emp.";
            gridViewTextBoxColumn7.Name = "chestado_pers";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn7.Width = 128;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "calculo";
            gridViewTextBoxColumn8.FormatString = "{0:C}";
            gridViewTextBoxColumn8.HeaderText = "Cálculo";
            gridViewTextBoxColumn8.Name = "chcalculo";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 84;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "estado_doc";
            gridViewTextBoxColumn9.HeaderText = "Estado Doc";
            gridViewTextBoxColumn9.Name = "chestado_doc";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn9.Width = 119;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "dsc_motivo";
            gridViewTextBoxColumn10.HeaderText = "Motivo";
            gridViewTextBoxColumn10.Name = "chdsc_motivo";
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn10.Width = 119;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "fecha_ingreso";
            gridViewTextBoxColumn11.FormatString = "{0:d}";
            gridViewTextBoxColumn11.HeaderText = "Ingreso";
            gridViewTextBoxColumn11.Name = "chfecha_ingreso";
            gridViewTextBoxColumn11.Width = 74;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "fecha_cese";
            gridViewTextBoxColumn12.FormatString = "{0:d}";
            gridViewTextBoxColumn12.HeaderText = "Cesado";
            gridViewTextBoxColumn12.Name = "chfecha_cese";
            gridViewTextBoxColumn12.Width = 73;
            this.dgvPersonalLiquidado.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.dgvPersonalLiquidado.MasterTemplate.EnableFiltering = true;
            this.dgvPersonalLiquidado.Name = "dgvPersonalLiquidado";
            this.dgvPersonalLiquidado.ReadOnly = true;
            this.dgvPersonalLiquidado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPersonalLiquidado.Size = new System.Drawing.Size(1233, 379);
            this.dgvPersonalLiquidado.TabIndex = 158;
            this.dgvPersonalLiquidado.Text = "Registros";
            this.dgvPersonalLiquidado.ThemeName = "VisualStudio2012Light";
            // 
            // gbConsulta
            // 
            this.gbConsulta.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsulta.Controls.Add(this.cboPlanilla);
            this.gbConsulta.Controls.Add(this.label1);
            this.gbConsulta.Controls.Add(this.progressBar);
            this.gbConsulta.Controls.Add(this.radLabel1);
            this.gbConsulta.Controls.Add(this.txtAño);
            this.gbConsulta.Controls.Add(this.btnConsultar);
            this.gbConsulta.Controls.Add(this.txtFechaHasta);
            this.gbConsulta.Controls.Add(this.txtFechaDesde);
            this.gbConsulta.Controls.Add(this.cboMes);
            this.gbConsulta.Controls.Add(this.label5);
            this.gbConsulta.Controls.Add(this.lblFechaDesde);
            this.gbConsulta.Controls.Add(this.lblFechaHasta);
            this.gbConsulta.HeaderText = "Consulta";
            this.gbConsulta.Location = new System.Drawing.Point(4, 40);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(1237, 55);
            this.gbConsulta.TabIndex = 170;
            this.gbConsulta.Text = "Consulta";
            this.gbConsulta.ThemeName = "VisualStudio2012Light";
            // 
            // cboPlanilla
            // 
            this.cboPlanilla.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboPlanilla.Location = new System.Drawing.Point(417, 28);
            this.cboPlanilla.Name = "cboPlanilla";
            this.cboPlanilla.Size = new System.Drawing.Size(239, 20);
            this.cboPlanilla.TabIndex = 169;
            this.cboPlanilla.ThemeName = "VisualStudio2012Light";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 168;
            this.label1.Text = "Planilla :";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(767, 22);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(167, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 167;
            this.progressBar.Visible = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(6, 30);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(32, 18);
            this.radLabel1.TabIndex = 166;
            this.radLabel1.Text = "Año :";
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
            this.txtAño.Size = new System.Drawing.Size(46, 20);
            this.txtAño.TabIndex = 165;
            this.txtAño.TabStop = false;
            this.txtAño.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAño.ThemeName = "Windows8";
            this.txtAño.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.txtAño.ValueChanged += new System.EventHandler(this.txtAño_ValueChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(673, 20);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 28);
            this.btnConsultar.TabIndex = 159;
            this.btnConsultar.Text = "&Consultar ";
            this.btnConsultar.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.ThemeName = "Windows8";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(328, 28);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(74, 20);
            this.txtFechaHasta.TabIndex = 161;
            this.txtFechaHasta.TabStop = false;
            this.txtFechaHasta.Text = "__/__/____";
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaHasta.ThemeName = "VisualStudio2012Light";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(250, 29);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(66, 20);
            this.txtFechaDesde.TabIndex = 160;
            this.txtFechaDesde.TabStop = false;
            this.txtFechaDesde.Text = "__/__/____";
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ThemeName = "VisualStudio2012Light";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(94, 28);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(146, 20);
            this.cboMes.TabIndex = 158;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 156;
            this.label5.Text = "Mes :";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(261, 13);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(44, 13);
            this.lblFechaDesde.TabIndex = 154;
            this.lblFechaDesde.Text = "Desde :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(342, 14);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(41, 13);
            this.lblFechaHasta.TabIndex = 155;
            this.lblFechaHasta.Text = "Hasta :";
            // 
            // bwgHilo
            // 
            this.bwgHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwgHilo_DoWork);
            this.bwgHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwgHilo_RunWorkerCompleted);
            // 
            // LiquidacionPersonal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1247, 500);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.gbLista);
            this.Name = "LiquidacionPersonal";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Liquidación Personal";
            this.ThemeName = "VisualStudio2012Light";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LiquidacionPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbLista)).EndInit();
            this.gbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalLiquidado.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalLiquidado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).EndInit();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar menuPrincipal;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnExportar;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.RadGroupBox gbLista;
        private Telerik.WinControls.UI.RadGridView dgvPersonalLiquidado;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.RadGroupBox gbConsulta;
        private System.Windows.Forms.ProgressBar progressBar;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadSpinEditor txtAño;
        private Telerik.WinControls.UI.RadButton btnConsultar;
        private Telerik.WinControls.UI.RadMaskedEditBox txtFechaHasta;
        private Telerik.WinControls.UI.RadMaskedEditBox txtFechaDesde;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.UI.RadDropDownList cboPlanilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.ComponentModel.BackgroundWorker bwgHilo;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
    }
}
