namespace Transportista
{
    partial class ProcesoGenerarDescuentoParaPagoServicioAlimentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesoGenerarDescuentoParaPagoServicioAlimentacion));
            this.gbProceso = new Telerik.WinControls.UI.RadGroupBox();
            this.btnBuscarTransportista = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtDNIProveedor = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtRazonSocialProveedor = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.btnProgramarExclusion = new Telerik.WinControls.UI.RadButton();
            this.txtSemana = new Telerik.WinControls.UI.RadSpinEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechaHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtPeriodo = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.btnGenerar = new Telerik.WinControls.UI.RadButton();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.stsBarraEstado = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            ((System.ComponentModel.ISupportInitialize)(this.gbProceso)).BeginInit();
            this.gbProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProgramarExclusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProceso
            // 
            this.gbProceso.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbProceso.Controls.Add(this.btnBuscarTransportista);
            this.gbProceso.Controls.Add(this.btnProgramarExclusion);
            this.gbProceso.Controls.Add(this.txtRazonSocialProveedor);
            this.gbProceso.Controls.Add(this.txtSemana);
            this.gbProceso.Controls.Add(this.txtDNIProveedor);
            this.gbProceso.Controls.Add(this.label2);
            this.gbProceso.Controls.Add(this.txtFechaHasta);
            this.gbProceso.Controls.Add(this.txtFechaDesde);
            this.gbProceso.Controls.Add(this.txtPeriodo);
            this.gbProceso.Controls.Add(this.radLabel3);
            this.gbProceso.Controls.Add(this.label1);
            this.gbProceso.Controls.Add(this.lblFechaDesde);
            this.gbProceso.Controls.Add(this.lblFechaHasta);
            this.gbProceso.Controls.Add(this.btnGenerar);
            this.gbProceso.Controls.Add(this.cboMes);
            this.gbProceso.Controls.Add(this.label5);
            this.gbProceso.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProceso.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbProceso.HeaderText = "Proceso ...";
            this.gbProceso.Location = new System.Drawing.Point(3, 5);
            this.gbProceso.Name = "gbProceso";
            this.gbProceso.Size = new System.Drawing.Size(816, 115);
            this.gbProceso.TabIndex = 0;
            this.gbProceso.Text = "Proceso ...";
            this.gbProceso.ThemeName = "VisualStudio2012Light";
            // 
            // btnBuscarTransportista
            // 
            this.btnBuscarTransportista.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarTransportista.Image")));
            this.btnBuscarTransportista.Location = new System.Drawing.Point(595, 58);
            this.btnBuscarTransportista.Name = "btnBuscarTransportista";
            this.btnBuscarTransportista.P_CampoCodigo = "rtrim(nroDNI)";
            this.btnBuscarTransportista.P_CampoDescripcion = "ISNULL(RTRIM(CP.RAZON_SOCIAL),\'\') + \' / \' + isnull(RTRIM(NROrUC),\'\')";
            this.btnBuscarTransportista.P_EsEditable = true;
            this.btnBuscarTransportista.P_EsModificable = true;
            this.btnBuscarTransportista.P_FilterByTextBox = null;
            this.btnBuscarTransportista.P_TablaConsulta = "SJ_RHPension PNS LEFT JOIN CLIEPROV CP ON PNS.NroRUC = CP.IdClieprov LEFT JOIN ES" +
    "TADOS E ON PNS.IdEstado=E.IdEstado where  PNS.IdEstado = \'AC\'";
            this.btnBuscarTransportista.P_TextBoxCodigo = this.txtDNIProveedor;
            this.btnBuscarTransportista.P_TextBoxDescripcion = this.txtRazonSocialProveedor;
            this.btnBuscarTransportista.P_TituloFormulario = "Buscar RUC";
            this.btnBuscarTransportista.Size = new System.Drawing.Size(39, 23);
            this.btnBuscarTransportista.TabIndex = 184;
            this.btnBuscarTransportista.UseVisualStyleBackColor = true;
            this.btnBuscarTransportista.Visible = false;
            // 
            // txtDNIProveedor
            // 
            this.txtDNIProveedor.BackColor = System.Drawing.Color.White;
            this.txtDNIProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDNIProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtDNIProveedor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDNIProveedor.Location = new System.Drawing.Point(73, 84);
            this.txtDNIProveedor.MaxLength = 16;
            this.txtDNIProveedor.Name = "txtDNIProveedor";
            this.txtDNIProveedor.P_BotonEnlace = this.btnBuscarTransportista;
            this.txtDNIProveedor.P_BuscarSoloCodigoExacto = false;
            this.txtDNIProveedor.P_EsEditable = true;
            this.txtDNIProveedor.P_EsModificable = true;
            this.txtDNIProveedor.P_EsPrimaryKey = false;
            this.txtDNIProveedor.P_ExigeInformacion = false;
            this.txtDNIProveedor.P_NombreColumna = null;
            this.txtDNIProveedor.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtDNIProveedor.Size = new System.Drawing.Size(108, 20);
            this.txtDNIProveedor.TabIndex = 182;
            this.txtDNIProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRazonSocialProveedor
            // 
            this.txtRazonSocialProveedor.BackColor = System.Drawing.Color.White;
            this.txtRazonSocialProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazonSocialProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtRazonSocialProveedor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRazonSocialProveedor.Location = new System.Drawing.Point(186, 84);
            this.txtRazonSocialProveedor.Name = "txtRazonSocialProveedor";
            this.txtRazonSocialProveedor.P_BotonEnlace = null;
            this.txtRazonSocialProveedor.P_BuscarSoloCodigoExacto = false;
            this.txtRazonSocialProveedor.P_EsEditable = false;
            this.txtRazonSocialProveedor.P_EsModificable = false;
            this.txtRazonSocialProveedor.P_EsPrimaryKey = false;
            this.txtRazonSocialProveedor.P_ExigeInformacion = false;
            this.txtRazonSocialProveedor.P_NombreColumna = null;
            this.txtRazonSocialProveedor.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtRazonSocialProveedor.ReadOnly = true;
            this.txtRazonSocialProveedor.Size = new System.Drawing.Size(448, 20);
            this.txtRazonSocialProveedor.TabIndex = 183;
            // 
            // btnProgramarExclusion
            // 
            this.btnProgramarExclusion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProgramarExclusion.Image = ((System.Drawing.Image)(resources.GetObject("btnProgramarExclusion.Image")));
            this.btnProgramarExclusion.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProgramarExclusion.Location = new System.Drawing.Point(640, 25);
            this.btnProgramarExclusion.Name = "btnProgramarExclusion";
            this.btnProgramarExclusion.Size = new System.Drawing.Size(171, 40);
            this.btnProgramarExclusion.TabIndex = 44;
            this.btnProgramarExclusion.Text = "   &Programar exclusiones";
            this.btnProgramarExclusion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgramarExclusion.ThemeName = "Windows8";
            this.btnProgramarExclusion.Click += new System.EventHandler(this.btnExlcuirFechasParaDescuento_Click);
            // 
            // txtSemana
            // 
            this.txtSemana.Location = new System.Drawing.Point(73, 58);
            this.txtSemana.Maximum = new decimal(new int[] {
            53,
            0,
            0,
            0});
            this.txtSemana.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSemana.Name = "txtSemana";
            // 
            // 
            // 
            this.txtSemana.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtSemana.Size = new System.Drawing.Size(62, 20);
            this.txtSemana.TabIndex = 34;
            this.txtSemana.TabStop = false;
            this.txtSemana.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSemana.ThemeName = "Windows8";
            this.txtSemana.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSemana.ValueChanged += new System.EventHandler(this.txtSemana_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Semana :";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.EditingControlDataGridView = null;
            this.txtFechaHasta.EditingControlFormattedValue = "  /  /";
            this.txtFechaHasta.EditingControlRowIndex = 0;
            this.txtFechaHasta.EditingControlValueChanged = true;
            this.txtFechaHasta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaHasta.Location = new System.Drawing.Point(330, 58);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.P_EsEditable = false;
            this.txtFechaHasta.P_EsModificable = false;
            this.txtFechaHasta.P_ExigeInformacion = false;
            this.txtFechaHasta.P_Hora = null;
            this.txtFechaHasta.P_NombreColumna = null;
            this.txtFechaHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFechaHasta.Size = new System.Drawing.Size(77, 22);
            this.txtFechaHasta.TabIndex = 38;
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.EditingControlDataGridView = null;
            this.txtFechaDesde.EditingControlFormattedValue = "  /  /";
            this.txtFechaDesde.EditingControlRowIndex = 0;
            this.txtFechaDesde.EditingControlValueChanged = true;
            this.txtFechaDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaDesde.Location = new System.Drawing.Point(191, 58);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFechaDesde.Size = new System.Drawing.Size(73, 22);
            this.txtFechaDesde.TabIndex = 36;
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(73, 30);
            this.txtPeriodo.Maximum = new decimal(new int[] {
            2025,
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
            this.txtPeriodo.Size = new System.Drawing.Size(62, 20);
            this.txtPeriodo.TabIndex = 30;
            this.txtPeriodo.TabStop = false;
            this.txtPeriodo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeriodo.ThemeName = "Windows8";
            this.txtPeriodo.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.txtPeriodo.ValueChanged += new System.EventHandler(this.txtPeriodo_ValueChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(2, 85);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(67, 16);
            this.radLabel3.TabIndex = 39;
            this.radLabel3.Text = "Proveedor :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Año :";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(137, 61);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(51, 13);
            this.lblFechaDesde.TabIndex = 35;
            this.lblFechaDesde.Text = "Desde :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(281, 61);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(48, 13);
            this.lblFechaHasta.TabIndex = 37;
            this.lblFechaHasta.Text = "Hasta :";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.Location = new System.Drawing.Point(640, 69);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(171, 38);
            this.btnGenerar.TabIndex = 43;
            this.btnGenerar.Text = "     &Generar descuentos";
            this.btnGenerar.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.ThemeName = "Windows8";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(186, 30);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(256, 20);
            this.cboMes.TabIndex = 32;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(145, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Mes :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stsBarraEstado
            // 
            this.stsBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.lblResultado});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 130);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.stsBarraEstado.Size = new System.Drawing.Size(835, 22);
            this.stsBarraEstado.TabIndex = 181;
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = false;
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(820, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // lblResultado
            // 
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 17);
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // ProcesoGenerarDescuentoParaPagoServicioAlimentacion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(835, 152);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.gbProceso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcesoGenerarDescuentoParaPagoServicioAlimentacion";
            this.Text = "Generar proceso para el descuento para pago por el servicio de alimentación";
            this.Load += new System.EventHandler(this.GenerarDescuentoParaPagoServicioAlimentacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbProceso)).EndInit();
            this.gbProceso.ResumeLayout(false);
            this.gbProceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProgramarExclusion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbProceso;
        private Telerik.WinControls.UI.RadSpinEditor txtSemana;
        private System.Windows.Forms.Label label2;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaHasta;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private Telerik.WinControls.UI.RadSpinEditor txtPeriodo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.UI.RadButton btnGenerar;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip stsBarraEstado;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblResultado;
        private System.ComponentModel.BackgroundWorker bgwHilo;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.RadButton btnProgramarExclusion;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtRazonSocialProveedor;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtDNIProveedor;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnBuscarTransportista;
    }
}