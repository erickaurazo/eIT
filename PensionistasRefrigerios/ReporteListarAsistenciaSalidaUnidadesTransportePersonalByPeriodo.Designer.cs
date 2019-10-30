namespace Transportista
{
    partial class ReporteListarAsistenciaSalidaUnidadesTransportePersonalByPeriodo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteListarAsistenciaSalidaUnidadesTransportePersonalByPeriodo));
            this.gbRegistros = new Telerik.WinControls.UI.RadGroupBox();
            this.tabControl = new Telerik.WinControls.UI.RadPageView();
            this.tabAsistenciaResumen = new Telerik.WinControls.UI.RadPageViewPage();
            this.dgvAsistenciaResumen = new Telerik.WinControls.UI.RadGridView();
            this.tabAsistenciaDetalle = new Telerik.WinControls.UI.RadPageViewPage();
            this.dgvDetalle = new Telerik.WinControls.UI.RadGridView();
            this.gbConsulta = new Telerik.WinControls.UI.RadGroupBox();
            this.cboGarita = new Telerik.WinControls.UI.RadDropDownList();
            this.txtFechaHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPeriodo = new Telerik.WinControls.UI.RadSpinEditor();
            this.btnConsultar = new Telerik.WinControls.UI.RadButton();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGarita = new Telerik.WinControls.UI.RadLabel();
            this.menuPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnExportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.subMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarAsistencia = new System.Windows.Forms.ToolStripMenuItem();
            this.anularAsistencia = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTiempoTranscurrido = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroResultados = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).BeginInit();
            this.gbRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabAsistenciaResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaResumen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaResumen.MasterTemplate)).BeginInit();
            this.tabAsistenciaDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).BeginInit();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGarita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGarita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).BeginInit();
            this.subMenu.SuspendLayout();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRegistros
            // 
            this.gbRegistros.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRegistros.Controls.Add(this.tabControl);
            this.gbRegistros.HeaderText = "";
            this.gbRegistros.Location = new System.Drawing.Point(6, 144);
            this.gbRegistros.Name = "gbRegistros";
            this.gbRegistros.Size = new System.Drawing.Size(1135, 327);
            this.gbRegistros.TabIndex = 205;
            this.gbRegistros.ThemeName = "VisualStudio2012Light";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabAsistenciaResumen);
            this.tabControl.Controls.Add(this.tabAsistenciaDetalle);
            this.tabControl.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
            this.tabControl.Location = new System.Drawing.Point(9, 23);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedPage = this.tabAsistenciaDetalle;
            this.tabControl.Size = new System.Drawing.Size(1112, 282);
            this.tabControl.TabIndex = 2;
            this.tabControl.ThemeName = "VisualStudio2012Light";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.tabControl.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.LeftScroll;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.tabControl.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.tabControl.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Bottom;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.tabControl.GetChildAt(0))).ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
            // 
            // tabAsistenciaResumen
            // 
            this.tabAsistenciaResumen.BackColor = System.Drawing.SystemColors.Control;
            this.tabAsistenciaResumen.Controls.Add(this.dgvAsistenciaResumen);
            this.tabAsistenciaResumen.ItemSize = new System.Drawing.SizeF(546F, 24F);
            this.tabAsistenciaResumen.Location = new System.Drawing.Point(5, 5);
            this.tabAsistenciaResumen.Name = "tabAsistenciaResumen";
            this.tabAsistenciaResumen.Size = new System.Drawing.Size(1102, 247);
            this.tabAsistenciaResumen.Text = "Resumen de Asistencias";
            // 
            // dgvAsistenciaResumen
            // 
            this.dgvAsistenciaResumen.BackColor = System.Drawing.SystemColors.Control;
            this.dgvAsistenciaResumen.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvAsistenciaResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsistenciaResumen.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvAsistenciaResumen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAsistenciaResumen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvAsistenciaResumen.Location = new System.Drawing.Point(0, 0);
            // 
            // dgvAsistenciaResumen
            // 
            this.dgvAsistenciaResumen.MasterTemplate.AllowAddNewRow = false;
            this.dgvAsistenciaResumen.MasterTemplate.AutoGenerateColumns = false;
            this.dgvAsistenciaResumen.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistenciaResumen.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvAsistenciaResumen.MasterTemplate.EnableFiltering = true;
            this.dgvAsistenciaResumen.MasterTemplate.MultiSelect = true;
            this.dgvAsistenciaResumen.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dgvAsistenciaResumen.Name = "dgvAsistenciaResumen";
            this.dgvAsistenciaResumen.ReadOnly = true;
            this.dgvAsistenciaResumen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvAsistenciaResumen.Size = new System.Drawing.Size(1102, 247);
            this.dgvAsistenciaResumen.TabIndex = 17;
            this.dgvAsistenciaResumen.ThemeName = "VisualStudio2012Light";
            // 
            // tabAsistenciaDetalle
            // 
            this.tabAsistenciaDetalle.Controls.Add(this.dgvDetalle);
            this.tabAsistenciaDetalle.ItemSize = new System.Drawing.SizeF(546F, 24F);
            this.tabAsistenciaDetalle.Location = new System.Drawing.Point(5, 5);
            this.tabAsistenciaDetalle.Name = "tabAsistenciaDetalle";
            this.tabAsistenciaDetalle.Size = new System.Drawing.Size(1102, 247);
            this.tabAsistenciaDetalle.Text = "Asistencia detallada";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.BackColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvDetalle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 0);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.MasterTemplate.AllowAddNewRow = false;
            this.dgvDetalle.MasterTemplate.AutoGenerateColumns = false;
            this.dgvDetalle.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvDetalle.MasterTemplate.EnableFiltering = true;
            this.dgvDetalle.MasterTemplate.MultiSelect = true;
            this.dgvDetalle.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvDetalle.Size = new System.Drawing.Size(1102, 247);
            this.dgvDetalle.TabIndex = 18;
            this.dgvDetalle.ThemeName = "VisualStudio2012Light";
            // 
            // gbConsulta
            // 
            this.gbConsulta.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsulta.Controls.Add(this.cboGarita);
            this.gbConsulta.Controls.Add(this.txtFechaHasta);
            this.gbConsulta.Controls.Add(this.txtFechaDesde);
            this.gbConsulta.Controls.Add(this.radLabel7);
            this.gbConsulta.Controls.Add(this.label1);
            this.gbConsulta.Controls.Add(this.label2);
            this.gbConsulta.Controls.Add(this.txtPeriodo);
            this.gbConsulta.Controls.Add(this.btnConsultar);
            this.gbConsulta.Controls.Add(this.cboMes);
            this.gbConsulta.Controls.Add(this.label5);
            this.gbConsulta.Controls.Add(this.lblGarita);
            this.gbConsulta.HeaderText = "";
            this.gbConsulta.Location = new System.Drawing.Point(8, 39);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(1133, 99);
            this.gbConsulta.TabIndex = 204;
            this.gbConsulta.ThemeName = "Windows8";
            // 
            // cboGarita
            // 
            this.cboGarita.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboGarita.Location = new System.Drawing.Point(75, 76);
            this.cboGarita.Name = "cboGarita";
            this.cboGarita.Size = new System.Drawing.Size(247, 20);
            this.cboGarita.TabIndex = 203;
            this.cboGarita.ThemeName = "VisualStudio2012Light";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.EditingControlDataGridView = null;
            this.txtFechaHasta.EditingControlFormattedValue = "  /  /";
            this.txtFechaHasta.EditingControlRowIndex = 0;
            this.txtFechaHasta.EditingControlValueChanged = true;
            this.txtFechaHasta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaHasta.Location = new System.Drawing.Point(231, 47);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.P_EsEditable = false;
            this.txtFechaHasta.P_EsModificable = false;
            this.txtFechaHasta.P_ExigeInformacion = false;
            this.txtFechaHasta.P_Hora = null;
            this.txtFechaHasta.P_NombreColumna = null;
            this.txtFechaHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaHasta.Size = new System.Drawing.Size(73, 20);
            this.txtFechaHasta.TabIndex = 193;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.EditingControlDataGridView = null;
            this.txtFechaDesde.EditingControlFormattedValue = "  /  /";
            this.txtFechaDesde.EditingControlRowIndex = 0;
            this.txtFechaDesde.EditingControlValueChanged = true;
            this.txtFechaDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaDesde.Location = new System.Drawing.Point(103, 47);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaDesde.Size = new System.Drawing.Size(73, 20);
            this.txtFechaDesde.TabIndex = 192;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(8, 3);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(32, 18);
            this.radLabel7.TabIndex = 166;
            this.radLabel7.Text = "Año :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 190;
            this.label1.Text = "Desde :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 191;
            this.label2.Text = "Hasta :";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(5, 22);
            this.txtPeriodo.Maximum = new decimal(new int[] {
            2040,
            0,
            0,
            0});
            this.txtPeriodo.Minimum = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.txtPeriodo.Name = "txtPeriodo";
            // 
            // 
            // 
            this.txtPeriodo.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtPeriodo.Size = new System.Drawing.Size(46, 20);
            this.txtPeriodo.TabIndex = 165;
            this.txtPeriodo.TabStop = false;
            this.txtPeriodo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeriodo.ThemeName = "VisualStudio2012Light";
            this.txtPeriodo.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(1031, 71);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 25);
            this.btnConsultar.TabIndex = 159;
            this.btnConsultar.Text = "&Consultar ";
            this.btnConsultar.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.ThemeName = "Windows8";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(57, 22);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(247, 20);
            this.cboMes.TabIndex = 158;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(60, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 156;
            this.label5.Text = "Mes :";
            // 
            // lblGarita
            // 
            this.lblGarita.Location = new System.Drawing.Point(22, 79);
            this.lblGarita.Name = "lblGarita";
            this.lblGarita.Size = new System.Drawing.Size(42, 18);
            this.lblGarita.TabIndex = 11;
            this.lblGarita.Text = "Garita :";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.menuPrincipal.Size = new System.Drawing.Size(1153, 35);
            this.menuPrincipal.TabIndex = 203;
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
            this.btnRRHH.Text = "     Recursos Humanos";
            this.btnRRHH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRRHH.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRRHH.ToolTipText = "     Recursos Humanos";
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
            this.editarAsistencia,
            this.anularAsistencia});
            this.subMenu.Name = "subMenu";
            this.subMenu.Size = new System.Drawing.Size(166, 48);
            // 
            // editarAsistencia
            // 
            this.editarAsistencia.Name = "editarAsistencia";
            this.editarAsistencia.Size = new System.Drawing.Size(165, 22);
            this.editarAsistencia.Text = "Editar Asistencia";
            // 
            // anularAsistencia
            // 
            this.anularAsistencia.Name = "anularAsistencia";
            this.anularAsistencia.Size = new System.Drawing.Size(165, 22);
            this.anularAsistencia.Text = "Anular Asistencia";
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
            this.toolStripProgressBar1,
            this.lblNumeroResultados});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 478);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1153, 22);
            this.stsBarraEstado.TabIndex = 206;
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
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 25;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(160, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
            // 
            // ReporteListarAsistenciaSalidaUnidadesTransportePersonalByPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 500);
            this.Controls.Add(this.gbRegistros);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.stsBarraEstado);
            this.Name = "ReporteListarAsistenciaSalidaUnidadesTransportePersonalByPeriodo";
            this.Text = "Reporte de listado de asistencia de ingreso y salida de personal por unidades de " +
    "transportePersonal por periodo";
            this.Load += new System.EventHandler(this.ReporteListarAsistenciaSalidaUnidadesTransportePersonalByPeriodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).EndInit();
            this.gbRegistros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabAsistenciaResumen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaResumen.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaResumen)).EndInit();
            this.tabAsistenciaDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).EndInit();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGarita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGarita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).EndInit();
            this.subMenu.ResumeLayout(false);
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbRegistros;
        private Telerik.WinControls.UI.RadPageView tabControl;
        private Telerik.WinControls.UI.RadPageViewPage tabAsistenciaResumen;
        private Telerik.WinControls.UI.RadGridView dgvAsistenciaResumen;
        private Telerik.WinControls.UI.RadPageViewPage tabAsistenciaDetalle;
        private Telerik.WinControls.UI.RadGridView dgvDetalle;
        private Telerik.WinControls.UI.RadGroupBox gbConsulta;
        private Telerik.WinControls.UI.RadDropDownList cboGarita;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaHasta;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadSpinEditor txtPeriodo;
        private Telerik.WinControls.UI.RadButton btnConsultar;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadLabel lblGarita;
        private Telerik.WinControls.UI.RadCommandBar menuPrincipal;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnExportar;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private System.Windows.Forms.ContextMenuStrip subMenu;
        private System.Windows.Forms.ToolStripMenuItem editarAsistencia;
        private System.Windows.Forms.ToolStripMenuItem anularAsistencia;
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempoTranscurrido;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroResultados;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
    }
}