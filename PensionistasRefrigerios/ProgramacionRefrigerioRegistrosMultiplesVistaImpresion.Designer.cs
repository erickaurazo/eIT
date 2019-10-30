namespace Transportista
{
    partial class ProgramacionRefrigerioRegistrosMultiplesVistaImpresion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramacionRefrigerioRegistrosMultiplesVistaImpresion));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.barraPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnActualizar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnExportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnVistaPrevia = new Telerik.WinControls.UI.CommandBarButton();
            this.btnImprimir = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.dgvAgrupado = new Telerik.WinControls.UI.RadGridView();
            this.subMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSubVistaPrevia = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDetalle = new MyControlsDataBinding.Controles.MyDataGridViewDetails(this.components);
            this.chid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chIdParaderoPersonal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chidCodigoGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chNroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chNombresCompletos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chidPension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDesayuno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chAlmuerzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbListadoAgrupado = new Telerik.WinControls.UI.RadGroupBox();
            this.gbDetalle = new Telerik.WinControls.UI.RadGroupBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblresultados = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUltimoMantenimiento = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.bgwProceso1 = new System.ComponentModel.BackgroundWorker();
            this.bgwProceso2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.barraPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgrupado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgrupado.MasterTemplate)).BeginInit();
            this.subMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbListadoAgrupado)).BeginInit();
            this.gbListadoAgrupado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDetalle)).BeginInit();
            this.gbDetalle.SuspendLayout();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraPrincipal
            // 
            this.barraPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraPrincipal.Enabled = false;
            this.barraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.barraPrincipal.Name = "barraPrincipal";
            this.barraPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior,
            this.commandBarRowElement1});
            this.barraPrincipal.Size = new System.Drawing.Size(1030, 66);
            this.barraPrincipal.TabIndex = 1;
            this.barraPrincipal.ThemeName = "VisualStudio2012Light";
            // 
            // BarraSuperior
            // 
            this.BarraSuperior.BackColor = System.Drawing.SystemColors.Control;
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
            this.btnRRHH.Text = "     Recursos Humanos";
            this.btnRRHH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRRHH.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRRHH.ToolTipText = "Recursos Humanos";
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnActualizar,
            this.btnExportar,
            this.btnVistaPrevia,
            this.btnImprimir,
            this.btnSalir});
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            this.commandBarStripElement3.Text = "";
            this.commandBarStripElement3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandBarStripElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnActualizar
            // 
            this.btnActualizar.AccessibleDescription = "Refrescar";
            this.btnActualizar.AccessibleName = "Refrescar";
            this.btnActualizar.AutoSize = false;
            this.btnActualizar.Bounds = new System.Drawing.Rectangle(0, 0, 95, 34);
            this.btnActualizar.DisplayName = "Actualizar";
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Text = "Refrescar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.AccessibleDescription = "Exportar";
            this.btnExportar.AccessibleName = "Exportar";
            this.btnExportar.AutoSize = false;
            this.btnExportar.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnExportar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnExportar.DisplayName = "Exportar";
            this.btnExportar.Enabled = false;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Text = "";
            this.btnExportar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnExportar.ToolTipText = "Exportar";
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.AccessibleDescription = "Vista previa";
            this.btnVistaPrevia.AccessibleName = "Vista previa";
            this.btnVistaPrevia.AutoSize = false;
            this.btnVistaPrevia.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnVistaPrevia.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnVistaPrevia.DisplayName = "Vista previa";
            this.btnVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("btnVistaPrevia.Image")));
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Text = "";
            this.btnVistaPrevia.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.AccessibleDescription = "Imprimir";
            this.btnImprimir.AccessibleName = "Imprimir";
            this.btnImprimir.AutoSize = false;
            this.btnImprimir.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnImprimir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnImprimir.DisplayName = "Imprimir";
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Tag = "Imprimir";
            this.btnImprimir.Text = "";
            this.btnImprimir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleDescription = "Salir";
            this.btnSalir.AccessibleName = "Salir";
            this.btnSalir.AutoSize = false;
            this.btnSalir.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnSalir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.DisplayName = "Salir";
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "";
            this.btnSalir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.ToolTipText = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            // 
            // dgvAgrupado
            // 
            this.dgvAgrupado.BackColor = System.Drawing.SystemColors.Control;
            this.dgvAgrupado.ContextMenuStrip = this.subMenu;
            this.dgvAgrupado.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvAgrupado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAgrupado.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvAgrupado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAgrupado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvAgrupado.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvAgrupado
            // 
            this.dgvAgrupado.MasterTemplate.AllowAddNewRow = false;
            this.dgvAgrupado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "codigoregistrado";
            gridViewTextBoxColumn5.HeaderText = "codigoregistrado";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "chcodigoregistrado";
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "fechaRegistro";
            gridViewTextBoxColumn6.HeaderText = "Fecha registro";
            gridViewTextBoxColumn6.Name = "chfechaRegistro";
            gridViewTextBoxColumn6.Width = 134;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "registradoPor";
            gridViewTextBoxColumn7.HeaderText = "Registrado por";
            gridViewTextBoxColumn7.Name = "chregistradoPor";
            gridViewTextBoxColumn7.Width = 182;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "nroRegistros";
            gridViewTextBoxColumn8.HeaderText = "nroRegistros";
            gridViewTextBoxColumn8.Name = "chnroRegistros";
            gridViewTextBoxColumn8.Width = 86;
            this.dgvAgrupado.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.dgvAgrupado.MasterTemplate.EnableFiltering = true;
            this.dgvAgrupado.MasterTemplate.MultiSelect = true;
            this.dgvAgrupado.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dgvAgrupado.Name = "dgvAgrupado";
            this.dgvAgrupado.ReadOnly = true;
            this.dgvAgrupado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvAgrupado.Size = new System.Drawing.Size(418, 367);
            this.dgvAgrupado.TabIndex = 2;
            this.dgvAgrupado.ThemeName = "VisualStudio2012Light";
            this.dgvAgrupado.SelectionChanged += new System.EventHandler(this.dgvAgrupado_SelectionChanged);
            this.dgvAgrupado.DoubleClick += new System.EventHandler(this.dgvAgrupado_DoubleClick);
            // 
            // subMenu
            // 
            this.subMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSubVistaPrevia});
            this.subMenu.Name = "subMenu";
            this.subMenu.Size = new System.Drawing.Size(143, 34);
            // 
            // btnSubVistaPrevia
            // 
            this.btnSubVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("btnSubVistaPrevia.Image")));
            this.btnSubVistaPrevia.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSubVistaPrevia.Name = "btnSubVistaPrevia";
            this.btnSubVistaPrevia.Size = new System.Drawing.Size(160, 30);
            this.btnSubVistaPrevia.Text = "Vista previa";
            this.btnSubVistaPrevia.Click += new System.EventHandler(this.btnSubVistaPrevia_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chid,
            this.chIdParaderoPersonal,
            this.chidCodigoGeneral,
            this.chNroDocumento,
            this.chNombresCompletos,
            this.chidPension,
            this.chPension,
            this.chDesayuno,
            this.chAlmuerzo,
            this.chCena});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(2, 18);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.P_EsEditable = false;
            this.dgvDetalle.P_FormatoDecimal = null;
            this.dgvDetalle.P_FormatoFecha = null;
            this.dgvDetalle.P_NombreColCorrelativa = null;
            this.dgvDetalle.P_NombreTabla = null;
            this.dgvDetalle.P_NumeroDigitos = 0;
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetalle.Size = new System.Drawing.Size(561, 367);
            this.dgvDetalle.TabIndex = 3;
            // 
            // chid
            // 
            this.chid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chid.DataPropertyName = "id";
            this.chid.HeaderText = "Id";
            this.chid.Name = "chid";
            this.chid.ReadOnly = true;
            this.chid.Visible = false;
            // 
            // chIdParaderoPersonal
            // 
            this.chIdParaderoPersonal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chIdParaderoPersonal.DataPropertyName = "IdParaderoPersonal";
            this.chIdParaderoPersonal.HeaderText = "IdParaderoPersonal";
            this.chIdParaderoPersonal.Name = "chIdParaderoPersonal";
            this.chIdParaderoPersonal.ReadOnly = true;
            this.chIdParaderoPersonal.Visible = false;
            // 
            // chidCodigoGeneral
            // 
            this.chidCodigoGeneral.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chidCodigoGeneral.DataPropertyName = "idCodigoPersonal";
            this.chidCodigoGeneral.HeaderText = "idCodigoGeneral";
            this.chidCodigoGeneral.Name = "chidCodigoGeneral";
            this.chidCodigoGeneral.ReadOnly = true;
            // 
            // chNroDocumento
            // 
            this.chNroDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chNroDocumento.DataPropertyName = "NroDocumento";
            this.chNroDocumento.HeaderText = "NroDocumento";
            this.chNroDocumento.Name = "chNroDocumento";
            this.chNroDocumento.ReadOnly = true;
            // 
            // chNombresCompletos
            // 
            this.chNombresCompletos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chNombresCompletos.DataPropertyName = "NombresCompletos";
            this.chNombresCompletos.HeaderText = "NombresCompletos";
            this.chNombresCompletos.Name = "chNombresCompletos";
            this.chNombresCompletos.ReadOnly = true;
            // 
            // chidPension
            // 
            this.chidPension.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chidPension.DataPropertyName = "idPension";
            this.chidPension.HeaderText = "idPension";
            this.chidPension.Name = "chidPension";
            this.chidPension.ReadOnly = true;
            this.chidPension.Visible = false;
            // 
            // chPension
            // 
            this.chPension.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chPension.DataPropertyName = "Pension";
            this.chPension.HeaderText = "Pension";
            this.chPension.Name = "chPension";
            this.chPension.ReadOnly = true;
            // 
            // chDesayuno
            // 
            this.chDesayuno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chDesayuno.DataPropertyName = "Desayuno";
            this.chDesayuno.HeaderText = "Desayuno";
            this.chDesayuno.Name = "chDesayuno";
            this.chDesayuno.ReadOnly = true;
            this.chDesayuno.Visible = false;
            // 
            // chAlmuerzo
            // 
            this.chAlmuerzo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chAlmuerzo.DataPropertyName = "Almuerzo";
            this.chAlmuerzo.HeaderText = "Almuerzo";
            this.chAlmuerzo.Name = "chAlmuerzo";
            this.chAlmuerzo.ReadOnly = true;
            // 
            // chCena
            // 
            this.chCena.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chCena.DataPropertyName = "Cena";
            this.chCena.HeaderText = "Cena";
            this.chCena.Name = "chCena";
            this.chCena.ReadOnly = true;
            // 
            // gbListadoAgrupado
            // 
            this.gbListadoAgrupado.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbListadoAgrupado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbListadoAgrupado.Controls.Add(this.dgvAgrupado);
            this.gbListadoAgrupado.HeaderText = "Registro de impresiones";
            this.gbListadoAgrupado.Location = new System.Drawing.Point(12, 40);
            this.gbListadoAgrupado.Name = "gbListadoAgrupado";
            this.gbListadoAgrupado.Size = new System.Drawing.Size(422, 387);
            this.gbListadoAgrupado.TabIndex = 4;
            this.gbListadoAgrupado.Text = "Registro de impresiones";
            this.gbListadoAgrupado.ThemeName = "VisualStudio2012Light";
            // 
            // gbDetalle
            // 
            this.gbDetalle.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalle.Controls.Add(this.dgvDetalle);
            this.gbDetalle.HeaderText = "Detalle por grupo de registro ";
            this.gbDetalle.Location = new System.Drawing.Point(453, 40);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(565, 387);
            this.gbDetalle.TabIndex = 5;
            this.gbDetalle.Text = "Detalle por grupo de registro ";
            this.gbDetalle.ThemeName = "VisualStudio2012Light";
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
            this.ProgressBar,
            this.lblresultados,
            this.lblUltimoMantenimiento});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 429);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1030, 22);
            this.stsBarraEstado.TabIndex = 212;
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
            // ProgressBar
            // 
            this.ProgressBar.Enabled = false;
            this.ProgressBar.MarqueeAnimationSpeed = 5;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(350, 16);
            this.ProgressBar.Step = 5;
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.Visible = false;
            // 
            // lblresultados
            // 
            this.lblresultados.Name = "lblresultados";
            this.lblresultados.Size = new System.Drawing.Size(182, 17);
            this.lblresultados.Text = "No se encontraron #  de registros";
            // 
            // lblUltimoMantenimiento
            // 
            this.lblUltimoMantenimiento.Name = "lblUltimoMantenimiento";
            this.lblUltimoMantenimiento.Size = new System.Drawing.Size(0, 17);
            // 
            // bgwProceso1
            // 
            this.bgwProceso1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProceso1_DoWork);
            this.bgwProceso1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProceso1_RunWorkerCompleted);
            // 
            // bgwProceso2
            // 
            this.bgwProceso2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProceso2_DoWork);
            this.bgwProceso2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProceso2_RunWorkerCompleted);
            // 
            // ProgramacionRefrigerioRegistrosMultiplesVistaImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 451);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.gbDetalle);
            this.Controls.Add(this.gbListadoAgrupado);
            this.Controls.Add(this.barraPrincipal);
            this.Name = "ProgramacionRefrigerioRegistrosMultiplesVistaImpresion";
            this.Text = "Programación refrigerio registros múltiples vista en la impresión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramacionRefrigerioRegistrosMultiplesVistaImpresion_FormClosing);
            this.Load += new System.EventHandler(this.ProgramacionRefrigerioRegistrosMultiplesVistaImpresion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barraPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgrupado.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgrupado)).EndInit();
            this.subMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbListadoAgrupado)).EndInit();
            this.gbListadoAgrupado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbDetalle)).EndInit();
            this.gbDetalle.ResumeLayout(false);
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar barraPrincipal;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnExportar;
        private Telerik.WinControls.UI.CommandBarButton btnVistaPrevia;
        private Telerik.WinControls.UI.CommandBarButton btnImprimir;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.RadGridView dgvAgrupado;
        private MyControlsDataBinding.Controles.MyDataGridViewDetails dgvDetalle;
        private Telerik.WinControls.UI.RadGroupBox gbListadoAgrupado;
        private Telerik.WinControls.UI.RadGroupBox gbDetalle;
        private System.Windows.Forms.ToolTip toolTip;
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
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblresultados;
        private System.Windows.Forms.ToolStripStatusLabel lblUltimoMantenimiento;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ContextMenuStrip subMenu;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.UI.CommandBarButton btnActualizar;
        private System.ComponentModel.BackgroundWorker bgwProceso1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private System.ComponentModel.BackgroundWorker bgwProceso2;
        private System.Windows.Forms.ToolStripMenuItem btnSubVistaPrevia;
        private System.Windows.Forms.DataGridViewTextBoxColumn chid;
        private System.Windows.Forms.DataGridViewTextBoxColumn chIdParaderoPersonal;
        private System.Windows.Forms.DataGridViewTextBoxColumn chidCodigoGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn chNroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn chNombresCompletos;
        private System.Windows.Forms.DataGridViewTextBoxColumn chidPension;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPension;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDesayuno;
        private System.Windows.Forms.DataGridViewTextBoxColumn chAlmuerzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCena;
    }
}