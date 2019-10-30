namespace Transportista
{
    partial class ReporteGeneracionDescuentosPorInasistenciasRefrigerios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteGeneracionDescuentosPorInasistenciasRefrigerios));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            this.gbDatosConsulta = new Telerik.WinControls.UI.RadGroupBox();
            this.btnExportarExcel = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btnImprimirVistaAgrupadoPorRefrigerio = new Telerik.WinControls.UI.RadButton();
            this.txtRazonSocialProveedor = new Telerik.WinControls.UI.RadTextBox();
            this.txtFechaHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtDNIProveedor = new Telerik.WinControls.UI.RadTextBox();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvPersonal = new Telerik.WinControls.UI.RadGridView();
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
            this.lblAvanceProceso = new System.Windows.Forms.ToolStripStatusLabel();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatosConsulta)).BeginInit();
            this.gbDatosConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimirVistaAgrupadoPorRefrigerio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazonSocialProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNIProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal.MasterTemplate)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // gbDatosConsulta
            // 
            this.gbDatosConsulta.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbDatosConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosConsulta.Controls.Add(this.btnExportarExcel);
            this.gbDatosConsulta.Controls.Add(this.radButton1);
            this.gbDatosConsulta.Controls.Add(this.btnImprimirVistaAgrupadoPorRefrigerio);
            this.gbDatosConsulta.Controls.Add(this.txtRazonSocialProveedor);
            this.gbDatosConsulta.Controls.Add(this.txtFechaHasta);
            this.gbDatosConsulta.Controls.Add(this.txtDNIProveedor);
            this.gbDatosConsulta.Controls.Add(this.txtFechaDesde);
            this.gbDatosConsulta.Controls.Add(this.radLabel3);
            this.gbDatosConsulta.Controls.Add(this.lblFechaDesde);
            this.gbDatosConsulta.Controls.Add(this.lblFechaHasta);
            this.gbDatosConsulta.Controls.Add(this.cboMes);
            this.gbDatosConsulta.Controls.Add(this.label5);
            this.gbDatosConsulta.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbDatosConsulta.HeaderText = "Datos de la consulta ";
            this.gbDatosConsulta.Location = new System.Drawing.Point(7, 4);
            this.gbDatosConsulta.Name = "gbDatosConsulta";
            this.gbDatosConsulta.Size = new System.Drawing.Size(887, 108);
            this.gbDatosConsulta.TabIndex = 0;
            this.gbDatosConsulta.Text = "Datos de la consulta ";
            this.gbDatosConsulta.ThemeName = "Breeze";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarExcel.Image")));
            this.btnExportarExcel.Location = new System.Drawing.Point(590, 29);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(81, 27);
            this.btnExportarExcel.TabIndex = 183;
            this.btnExportarExcel.Text = "Exportar   ";
            this.btnExportarExcel.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarExcel.ThemeName = "Windows8";
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Image = ((System.Drawing.Image)(resources.GetObject("radButton1.Image")));
            this.radButton1.Location = new System.Drawing.Point(794, 29);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(82, 27);
            this.radButton1.TabIndex = 183;
            this.radButton1.Text = "Imprimir  ";
            this.radButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.radButton1.ThemeName = "Windows8";
            // 
            // btnImprimirVistaAgrupadoPorRefrigerio
            // 
            this.btnImprimirVistaAgrupadoPorRefrigerio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirVistaAgrupadoPorRefrigerio.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirVistaAgrupadoPorRefrigerio.Image")));
            this.btnImprimirVistaAgrupadoPorRefrigerio.Location = new System.Drawing.Point(689, 29);
            this.btnImprimirVistaAgrupadoPorRefrigerio.Name = "btnImprimirVistaAgrupadoPorRefrigerio";
            this.btnImprimirVistaAgrupadoPorRefrigerio.Size = new System.Drawing.Size(91, 27);
            this.btnImprimirVistaAgrupadoPorRefrigerio.TabIndex = 182;
            this.btnImprimirVistaAgrupadoPorRefrigerio.Text = "Vista Previa  ";
            this.btnImprimirVistaAgrupadoPorRefrigerio.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirVistaAgrupadoPorRefrigerio.ThemeName = "Windows8";
            // 
            // txtRazonSocialProveedor
            // 
            this.txtRazonSocialProveedor.Location = new System.Drawing.Point(372, 75);
            this.txtRazonSocialProveedor.MaxLength = 250;
            this.txtRazonSocialProveedor.Name = "txtRazonSocialProveedor";
            this.txtRazonSocialProveedor.ReadOnly = true;
            this.txtRazonSocialProveedor.Size = new System.Drawing.Size(429, 20);
            this.txtRazonSocialProveedor.TabIndex = 25;
            this.txtRazonSocialProveedor.TabStop = false;
            this.txtRazonSocialProveedor.ThemeName = "VisualStudio2012Light";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.EditingControlDataGridView = null;
            this.txtFechaHasta.EditingControlFormattedValue = "  /  /";
            this.txtFechaHasta.EditingControlRowIndex = 0;
            this.txtFechaHasta.EditingControlValueChanged = true;
            this.txtFechaHasta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaHasta.Location = new System.Drawing.Point(89, 75);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.P_EsEditable = false;
            this.txtFechaHasta.P_EsModificable = false;
            this.txtFechaHasta.P_ExigeInformacion = false;
            this.txtFechaHasta.P_Hora = null;
            this.txtFechaHasta.P_NombreColumna = null;
            this.txtFechaHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFechaHasta.ReadOnly = true;
            this.txtFechaHasta.Size = new System.Drawing.Size(84, 20);
            this.txtFechaHasta.TabIndex = 21;
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtDNIProveedor
            // 
            this.txtDNIProveedor.Location = new System.Drawing.Point(252, 75);
            this.txtDNIProveedor.MaxLength = 8;
            this.txtDNIProveedor.Name = "txtDNIProveedor";
            this.txtDNIProveedor.ReadOnly = true;
            this.txtDNIProveedor.Size = new System.Drawing.Size(114, 20);
            this.txtDNIProveedor.TabIndex = 24;
            this.txtDNIProveedor.TabStop = false;
            this.txtDNIProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDNIProveedor.ThemeName = "VisualStudio2012Light";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.EditingControlDataGridView = null;
            this.txtFechaDesde.EditingControlFormattedValue = "  /  /";
            this.txtFechaDesde.EditingControlRowIndex = 0;
            this.txtFechaDesde.EditingControlValueChanged = true;
            this.txtFechaDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaDesde.Location = new System.Drawing.Point(6, 75);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFechaDesde.ReadOnly = true;
            this.txtFechaDesde.Size = new System.Drawing.Size(73, 20);
            this.txtFechaDesde.TabIndex = 19;
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(183, 78);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(63, 18);
            this.radLabel3.TabIndex = 22;
            this.radLabel3.Text = "Proveedor :";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(8, 59);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(44, 13);
            this.lblFechaDesde.TabIndex = 18;
            this.lblFechaDesde.Text = "Desde :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(93, 59);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(41, 13);
            this.lblFechaHasta.TabIndex = 20;
            this.lblFechaHasta.Text = "Hasta :";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Enabled = false;
            this.cboMes.Location = new System.Drawing.Point(10, 36);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(170, 20);
            this.cboMes.TabIndex = 17;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mes :";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.dgvPersonal);
            this.radGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox2.HeaderText = "Listado de Trabajadores";
            this.radGroupBox2.Location = new System.Drawing.Point(9, 118);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(887, 350);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Listado de Trabajadores";
            this.radGroupBox2.ThemeName = "Breeze";
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dgvPersonal.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonal.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvPersonal.ForeColor = System.Drawing.Color.Black;
            this.dgvPersonal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvPersonal.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.MasterTemplate.AllowAddNewRow = false;
            this.dgvPersonal.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "codigoPersonal";
            gridViewTextBoxColumn1.HeaderText = "Código de Personal";
            gridViewTextBoxColumn1.Name = "chCodigoPersonal";
            gridViewTextBoxColumn1.Width = 139;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "dniPersonal";
            gridViewTextBoxColumn2.HeaderText = "Número de DNI";
            gridViewTextBoxColumn2.Name = "chDniPersonal";
            gridViewTextBoxColumn2.Width = 164;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "nombres";
            gridViewTextBoxColumn3.HeaderText = "Nombres";
            gridViewTextBoxColumn3.Name = "chNombres";
            gridViewTextBoxColumn3.Width = 328;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Standard;
            gridViewTextBoxColumn4.FieldName = "diasAusentes";
            gridViewTextBoxColumn4.FormatString = "{0:N0}";
            gridViewTextBoxColumn4.HeaderText = "Nro. Días Ausente";
            gridViewTextBoxColumn4.Name = "chDiasAusente";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn4.Width = 124;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.Standard;
            gridViewTextBoxColumn5.FieldName = "importeDescuento";
            gridViewTextBoxColumn5.FormatString = "{0:N2}";
            gridViewTextBoxColumn5.HeaderText = "Importe para Descuento";
            gridViewTextBoxColumn5.Name = "chImporteDescuento";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Width = 114;
            this.dgvPersonal.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.ReadOnly = true;
            this.dgvPersonal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPersonal.Size = new System.Drawing.Size(883, 330);
            this.dgvPersonal.TabIndex = 0;
            this.dgvPersonal.ThemeName = "VisualStudio2012Light";
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
            this.lblNumeroResultados,
            this.lblAvanceProceso});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 472);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.stsBarraEstado.Size = new System.Drawing.Size(905, 22);
            this.stsBarraEstado.TabIndex = 181;
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
            this.ProgressBar.Size = new System.Drawing.Size(660, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
            // 
            // lblAvanceProceso
            // 
            this.lblAvanceProceso.Name = "lblAvanceProceso";
            this.lblAvanceProceso.Size = new System.Drawing.Size(0, 17);
            // 
            // ReporteGeneracionDescuentosPorInasistenciasRefrigerios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(905, 494);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.gbDatosConsulta);
            this.MaximizeBox = false;
            this.Name = "ReporteGeneracionDescuentosPorInasistenciasRefrigerios";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generación de descuentosPor por inasistencias a refrigerios a pensiones";
            this.ThemeName = "VisualStudio2012Light";
            this.Load += new System.EventHandler(this.GeneracionDescuentosPorInasistenciasRefrigerios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbDatosConsulta)).EndInit();
            this.gbDatosConsulta.ResumeLayout(false);
            this.gbDatosConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimirVistaAgrupadoPorRefrigerio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazonSocialProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNIProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private System.ComponentModel.BackgroundWorker bgwHilo;
        private Telerik.WinControls.UI.RadGroupBox gbDatosConsulta;
        private Telerik.WinControls.UI.RadTextBox txtRazonSocialProveedor;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaHasta;
        private Telerik.WinControls.UI.RadTextBox txtDNIProveedor;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
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
        private System.Windows.Forms.ToolStripStatusLabel lblAvanceProceso;
        private Telerik.WinControls.UI.RadGridView dgvPersonal;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton btnImprimirVistaAgrupadoPorRefrigerio;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.RadButton btnExportarExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
