namespace RecursosHumanos
{
    partial class ImprimirIngresosSalidasPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImprimirIngresosSalidasPersonal));
            this.lblPlanilla = new System.Windows.Forms.Label();
            this.cboPlanilla = new Telerik.WinControls.UI.RadDropDownList();
            this.cbSubPlanilla = new Telerik.WinControls.UI.RadDropDownList();
            this.lblSubPlanilla = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.btnPersonalOrigen = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtPersonalOrigenCodigo = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtPersonalOrigenNombresCompletos = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtAño = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.lblMes = new System.Windows.Forms.Label();
            this.gbTipoPlanilla = new Telerik.WinControls.UI.RadGroupBox();
            this.gbCodigoPersonal = new Telerik.WinControls.UI.RadGroupBox();
            this.gbPeriodoReporte = new Telerik.WinControls.UI.RadGroupBox();
            this.txtFechaHasta = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.txtFechaDesde = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.btnImprimir = new Telerik.WinControls.UI.RadButton();
            this.btnVistaPrevia = new Telerik.WinControls.UI.RadButton();
            this.stsBarraEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pogressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.Impresora = new System.Windows.Forms.PrintDialog();
            this.bgwHiloImprimir = new System.ComponentModel.BackgroundWorker();
            this.bgwHiloVistaPrevia = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTipoPlanilla)).BeginInit();
            this.gbTipoPlanilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbCodigoPersonal)).BeginInit();
            this.gbCodigoPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbPeriodoReporte)).BeginInit();
            this.gbPeriodoReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVistaPrevia)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPlanilla
            // 
            this.lblPlanilla.AutoSize = true;
            this.lblPlanilla.Location = new System.Drawing.Point(32, 30);
            this.lblPlanilla.Name = "lblPlanilla";
            this.lblPlanilla.Size = new System.Drawing.Size(50, 13);
            this.lblPlanilla.TabIndex = 0;
            this.lblPlanilla.Text = "Planilla :";
            // 
            // cboPlanilla
            // 
            this.cboPlanilla.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboPlanilla.Location = new System.Drawing.Point(86, 27);
            this.cboPlanilla.Name = "cboPlanilla";
            this.cboPlanilla.Size = new System.Drawing.Size(266, 20);
            this.cboPlanilla.TabIndex = 178;
            this.cboPlanilla.ThemeName = "Windows8";
            // 
            // cbSubPlanilla
            // 
            this.cbSubPlanilla.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbSubPlanilla.Location = new System.Drawing.Point(445, 27);
            this.cbSubPlanilla.Name = "cbSubPlanilla";
            this.cbSubPlanilla.Size = new System.Drawing.Size(299, 20);
            this.cbSubPlanilla.TabIndex = 180;
            this.cbSubPlanilla.ThemeName = "Windows8";
            // 
            // lblSubPlanilla
            // 
            this.lblSubPlanilla.AutoSize = true;
            this.lblSubPlanilla.Location = new System.Drawing.Point(370, 31);
            this.lblSubPlanilla.Name = "lblSubPlanilla";
            this.lblSubPlanilla.Size = new System.Drawing.Size(70, 13);
            this.lblSubPlanilla.TabIndex = 179;
            this.lblSubPlanilla.Text = "SubPlanilla :";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(38, 35);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(45, 13);
            this.lblDesde.TabIndex = 181;
            this.lblDesde.Text = "Desde :";
            // 
            // btnPersonalOrigen
            // 
            this.btnPersonalOrigen.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonalOrigen.Image")));
            this.btnPersonalOrigen.Location = new System.Drawing.Point(89, 31);
            this.btnPersonalOrigen.Name = "btnPersonalOrigen";
            this.btnPersonalOrigen.P_CampoCodigo = "RTRIM(IDCODIGOGENERAL)";
            this.btnPersonalOrigen.P_CampoDescripcion = "rtrim(ISNULL(A_PATERNO,\'\'))+\' \'+rtrim(ISNULL(A_MATERNO,\'\')) + \' \' + rtrim(ISNULL(" +
    "NOMBRES,\'\'))";
            this.btnPersonalOrigen.P_EsEditable = false;
            this.btnPersonalOrigen.P_EsModificable = false;
            this.btnPersonalOrigen.P_FilterByTextBox = null;
            this.btnPersonalOrigen.P_TablaConsulta = "Personal_General";
            this.btnPersonalOrigen.P_TextBoxCodigo = this.txtPersonalOrigenCodigo;
            this.btnPersonalOrigen.P_TextBoxDescripcion = this.txtPersonalOrigenNombresCompletos;
            this.btnPersonalOrigen.P_TituloFormulario = null;
            this.btnPersonalOrigen.Size = new System.Drawing.Size(25, 23);
            this.btnPersonalOrigen.TabIndex = 201;
            this.btnPersonalOrigen.UseVisualStyleBackColor = true;
            // 
            // txtPersonalOrigenCodigo
            // 
            this.txtPersonalOrigenCodigo.Location = new System.Drawing.Point(117, 33);
            this.txtPersonalOrigenCodigo.MaxLength = 20;
            this.txtPersonalOrigenCodigo.Name = "txtPersonalOrigenCodigo";
            this.txtPersonalOrigenCodigo.P_BotonEnlace = this.btnPersonalOrigen;
            this.txtPersonalOrigenCodigo.P_BuscarSoloCodigoExacto = false;
            this.txtPersonalOrigenCodigo.P_EsEditable = false;
            this.txtPersonalOrigenCodigo.P_EsModificable = false;
            this.txtPersonalOrigenCodigo.P_EsPrimaryKey = false;
            this.txtPersonalOrigenCodigo.P_ExigeInformacion = false;
            this.txtPersonalOrigenCodigo.P_NombreColumna = null;
            this.txtPersonalOrigenCodigo.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtPersonalOrigenCodigo.Size = new System.Drawing.Size(94, 20);
            this.txtPersonalOrigenCodigo.TabIndex = 199;
            // 
            // txtPersonalOrigenNombresCompletos
            // 
            this.txtPersonalOrigenNombresCompletos.BackColor = System.Drawing.Color.White;
            this.txtPersonalOrigenNombresCompletos.Location = new System.Drawing.Point(218, 33);
            this.txtPersonalOrigenNombresCompletos.Name = "txtPersonalOrigenNombresCompletos";
            this.txtPersonalOrigenNombresCompletos.P_BotonEnlace = this.btnPersonalOrigen;
            this.txtPersonalOrigenNombresCompletos.P_BuscarSoloCodigoExacto = false;
            this.txtPersonalOrigenNombresCompletos.P_EsEditable = false;
            this.txtPersonalOrigenNombresCompletos.P_EsModificable = false;
            this.txtPersonalOrigenNombresCompletos.P_EsPrimaryKey = false;
            this.txtPersonalOrigenNombresCompletos.P_ExigeInformacion = false;
            this.txtPersonalOrigenNombresCompletos.P_NombreColumna = null;
            this.txtPersonalOrigenNombresCompletos.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtPersonalOrigenNombresCompletos.ReadOnly = true;
            this.txtPersonalOrigenNombresCompletos.Size = new System.Drawing.Size(531, 20);
            this.txtPersonalOrigenNombresCompletos.TabIndex = 200;
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(114, 33);
            this.txtAño.Maximum = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.txtAño.Minimum = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            this.txtAño.Name = "txtAño";
            // 
            // 
            // 
            this.txtAño.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtAño.Size = new System.Drawing.Size(46, 20);
            this.txtAño.TabIndex = 208;
            this.txtAño.TabStop = false;
            this.txtAño.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAño.ThemeName = "Windows8";
            this.txtAño.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.txtAño.ValueChanged += new System.EventHandler(this.txtAño_ValueChanged);
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.Location = new System.Drawing.Point(78, 36);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(32, 13);
            this.lblAnio.TabIndex = 207;
            this.lblAnio.Text = "Año :";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(215, 33);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(285, 20);
            this.cboMes.TabIndex = 206;
            this.cboMes.ThemeName = "Windows8";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(177, 36);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(33, 13);
            this.lblMes.TabIndex = 205;
            this.lblMes.Text = "Mes :";
            // 
            // gbTipoPlanilla
            // 
            this.gbTipoPlanilla.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbTipoPlanilla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTipoPlanilla.Controls.Add(this.lblSubPlanilla);
            this.gbTipoPlanilla.Controls.Add(this.lblPlanilla);
            this.gbTipoPlanilla.Controls.Add(this.cboPlanilla);
            this.gbTipoPlanilla.Controls.Add(this.cbSubPlanilla);
            this.gbTipoPlanilla.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbTipoPlanilla.HeaderText = "Elegir planilla y subplanilla";
            this.gbTipoPlanilla.Location = new System.Drawing.Point(14, 7);
            this.gbTipoPlanilla.Name = "gbTipoPlanilla";
            this.gbTipoPlanilla.Size = new System.Drawing.Size(755, 58);
            this.gbTipoPlanilla.TabIndex = 209;
            this.gbTipoPlanilla.Text = "Elegir planilla y subplanilla";
            this.gbTipoPlanilla.ThemeName = "Windows8";
            // 
            // gbCodigoPersonal
            // 
            this.gbCodigoPersonal.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbCodigoPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCodigoPersonal.Controls.Add(this.btnPersonalOrigen);
            this.gbCodigoPersonal.Controls.Add(this.lblDesde);
            this.gbCodigoPersonal.Controls.Add(this.txtPersonalOrigenCodigo);
            this.gbCodigoPersonal.Controls.Add(this.txtPersonalOrigenNombresCompletos);
            this.gbCodigoPersonal.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbCodigoPersonal.HeaderText = "Código del personal";
            this.gbCodigoPersonal.Location = new System.Drawing.Point(9, 72);
            this.gbCodigoPersonal.Name = "gbCodigoPersonal";
            this.gbCodigoPersonal.Size = new System.Drawing.Size(760, 68);
            this.gbCodigoPersonal.TabIndex = 210;
            this.gbCodigoPersonal.Text = "Código del personal";
            this.gbCodigoPersonal.ThemeName = "Windows8";
            // 
            // gbPeriodoReporte
            // 
            this.gbPeriodoReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbPeriodoReporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPeriodoReporte.Controls.Add(this.txtFechaHasta);
            this.gbPeriodoReporte.Controls.Add(this.txtFechaDesde);
            this.gbPeriodoReporte.Controls.Add(this.lblFechaDesde);
            this.gbPeriodoReporte.Controls.Add(this.lblFechaHasta);
            this.gbPeriodoReporte.Controls.Add(this.txtAño);
            this.gbPeriodoReporte.Controls.Add(this.lblMes);
            this.gbPeriodoReporte.Controls.Add(this.cboMes);
            this.gbPeriodoReporte.Controls.Add(this.lblAnio);
            this.gbPeriodoReporte.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbPeriodoReporte.HeaderText = "Periodo del reporte";
            this.gbPeriodoReporte.Location = new System.Drawing.Point(12, 146);
            this.gbPeriodoReporte.Name = "gbPeriodoReporte";
            this.gbPeriodoReporte.Size = new System.Drawing.Size(757, 103);
            this.gbPeriodoReporte.TabIndex = 211;
            this.gbPeriodoReporte.Text = "Periodo del reporte";
            this.gbPeriodoReporte.ThemeName = "Windows8";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(318, 73);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(74, 20);
            this.txtFechaHasta.TabIndex = 212;
            this.txtFechaHasta.TabStop = false;
            this.txtFechaHasta.Text = "__/__/____";
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaHasta.ThemeName = "VisualStudio2012Light";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(215, 74);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(78, 20);
            this.txtFechaDesde.TabIndex = 211;
            this.txtFechaDesde.TabStop = false;
            this.txtFechaDesde.Text = "__/__/____";
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ThemeName = "VisualStudio2012Light";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(223, 57);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(44, 13);
            this.lblFechaDesde.TabIndex = 209;
            this.lblFechaDesde.Text = "Desde :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(296, 56);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(41, 13);
            this.lblFechaHasta.TabIndex = 210;
            this.lblFechaHasta.Text = "Hasta :";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(285, 271);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(101, 31);
            this.btnImprimir.TabIndex = 212;
            this.btnImprimir.Text = "     Imprimir";
            this.btnImprimir.ThemeName = "Windows8";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("btnVistaPrevia.Image")));
            this.btnVistaPrevia.Location = new System.Drawing.Point(411, 271);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(101, 31);
            this.btnVistaPrevia.TabIndex = 213;
            this.btnVistaPrevia.Text = "     Vista previa";
            this.btnVistaPrevia.ThemeName = "Windows8";
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // stsBarraEstado
            // 
            this.stsBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.pogressBar});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 307);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(776, 22);
            this.stsBarraEstado.TabIndex = 214;
            this.stsBarraEstado.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // pogressBar
            // 
            this.pogressBar.MarqueeAnimationSpeed = 25;
            this.pogressBar.Name = "pogressBar";
            this.pogressBar.Size = new System.Drawing.Size(600, 16);
            this.pogressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pogressBar.Visible = false;
            // 
            // Impresora
            // 
            this.Impresora.AllowSelection = true;
            this.Impresora.UseEXDialog = true;
            // 
            // bgwHiloImprimir
            // 
            this.bgwHiloImprimir.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHiloImprimir_DoWork);
            this.bgwHiloImprimir.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHiloImprimir_RunWorkerCompleted);
            // 
            // bgwHiloVistaPrevia
            // 
            this.bgwHiloVistaPrevia.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHiloVistaPrevia_DoWork);
            this.bgwHiloVistaPrevia.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHiloVistaPrevia_RunWorkerCompleted);
            // 
            // ImprimirIngresosSalidasPersonal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(776, 329);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.btnVistaPrevia);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.gbPeriodoReporte);
            this.Controls.Add(this.gbCodigoPersonal);
            this.Controls.Add(this.gbTipoPlanilla);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImprimirIngresosSalidasPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir ingresos y salidas del personal";
            this.Load += new System.EventHandler(this.ImprimirIngresosSalidasPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSubPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTipoPlanilla)).EndInit();
            this.gbTipoPlanilla.ResumeLayout(false);
            this.gbTipoPlanilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbCodigoPersonal)).EndInit();
            this.gbCodigoPersonal.ResumeLayout(false);
            this.gbCodigoPersonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbPeriodoReporte)).EndInit();
            this.gbPeriodoReporte.ResumeLayout(false);
            this.gbPeriodoReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVistaPrevia)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlanilla;
        private Telerik.WinControls.UI.RadDropDownList cboPlanilla;
        private Telerik.WinControls.UI.RadDropDownList cbSubPlanilla;
        private System.Windows.Forms.Label lblSubPlanilla;
        private System.Windows.Forms.Label lblDesde;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnPersonalOrigen;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtPersonalOrigenCodigo;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtPersonalOrigenNombresCompletos;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private Telerik.WinControls.UI.RadSpinEditor txtAño;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblMes;
        private Telerik.WinControls.UI.RadGroupBox gbTipoPlanilla;
        private Telerik.WinControls.UI.RadGroupBox gbCodigoPersonal;
        private Telerik.WinControls.UI.RadGroupBox gbPeriodoReporte;
        private Telerik.WinControls.UI.RadButton btnImprimir;
        private Telerik.WinControls.UI.RadButton btnVistaPrevia;
        private System.Windows.Forms.StatusStrip stsBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar pogressBar;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PrintDialog Impresora;
        private Telerik.WinControls.UI.RadMaskedEditBox txtFechaHasta;
        private Telerik.WinControls.UI.RadMaskedEditBox txtFechaDesde;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.ComponentModel.BackgroundWorker bgwHiloImprimir;
        private System.ComponentModel.BackgroundWorker bgwHiloVistaPrevia;
    }
}