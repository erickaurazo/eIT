namespace Transportista
{
    partial class ReporteAsistenciaRefrigerioTransferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteAsistenciaRefrigerioTransferencia));
            Telerik.Pivot.Core.PropertyAggregateDescription propertyAggregateDescription1 = new Telerik.Pivot.Core.PropertyAggregateDescription();
            Telerik.Pivot.Core.SumAggregateFunction sumAggregateFunction1 = new Telerik.Pivot.Core.SumAggregateFunction();
            Telerik.Pivot.Core.DateTimeGroupDescription dateTimeGroupDescription1 = new Telerik.Pivot.Core.DateTimeGroupDescription();
            Telerik.Pivot.Core.GroupNameComparer groupNameComparer1 = new Telerik.Pivot.Core.GroupNameComparer();
            Telerik.Pivot.Core.PropertyGroupDescription propertyGroupDescription1 = new Telerik.Pivot.Core.PropertyGroupDescription();
            Telerik.Pivot.Core.GroupNameComparer groupNameComparer2 = new Telerik.Pivot.Core.GroupNameComparer();
            Telerik.Pivot.Core.PropertyGroupDescription propertyGroupDescription2 = new Telerik.Pivot.Core.PropertyGroupDescription();
            Telerik.Pivot.Core.GroupNameComparer groupNameComparer3 = new Telerik.Pivot.Core.GroupNameComparer();
            Telerik.Pivot.Core.PropertyGroupDescription propertyGroupDescription3 = new Telerik.Pivot.Core.PropertyGroupDescription();
            Telerik.Pivot.Core.GroupNameComparer groupNameComparer4 = new Telerik.Pivot.Core.GroupNameComparer();
            Telerik.Pivot.Core.PropertyGroupDescription propertyGroupDescription4 = new Telerik.Pivot.Core.PropertyGroupDescription();
            Telerik.Pivot.Core.GroupNameComparer groupNameComparer5 = new Telerik.Pivot.Core.GroupNameComparer();
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gbConsulta = new Telerik.WinControls.UI.RadGroupBox();
            this.btnActualizarNombresTrabajador = new Telerik.WinControls.UI.RadButton();
            this.btnAnularDuplicidadAsistencias = new Telerik.WinControls.UI.RadButton();
            this.btnGrafico = new Telerik.WinControls.UI.RadButton();
            this.btnBuscarTransportista = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtDNIProveedor = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtRazonSocialProveedor = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtSemana = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblSemana = new System.Windows.Forms.Label();
            this.txtFechaHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.gbVistaReporte = new Telerik.WinControls.UI.RadGroupBox();
            this.chkIncluirSubTotalesHorizontal = new Telerik.WinControls.UI.RadCheckBox();
            this.chkIncluirSubTotalesVertical = new Telerik.WinControls.UI.RadCheckBox();
            this.chkIncluirDesconocido = new Telerik.WinControls.UI.RadCheckBox();
            this.txtPeriodo = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.btnConsultar = new Telerik.WinControls.UI.RadButton();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.menuPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnExportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            this.gbRegistros = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvGrillaPrivot = new Telerik.WinControls.UI.RadPivotGrid();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.bgwProceso02 = new System.ComponentModel.BackgroundWorker();
            this.bgwProceso03 = new System.ComponentModel.BackgroundWorker();
            this.stsBarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).BeginInit();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizarNombresTrabajador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnularDuplicidadAsistencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbVistaReporte)).BeginInit();
            this.gbVistaReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncluirSubTotalesHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncluirSubTotalesVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncluirDesconocido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).BeginInit();
            this.gbRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaPrivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
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
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 467);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1282, 22);
            this.stsBarraEstado.TabIndex = 180;
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
            // gbConsulta
            // 
            this.gbConsulta.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsulta.Controls.Add(this.btnActualizarNombresTrabajador);
            this.gbConsulta.Controls.Add(this.btnAnularDuplicidadAsistencias);
            this.gbConsulta.Controls.Add(this.btnGrafico);
            this.gbConsulta.Controls.Add(this.btnBuscarTransportista);
            this.gbConsulta.Controls.Add(this.txtRazonSocialProveedor);
            this.gbConsulta.Controls.Add(this.txtDNIProveedor);
            this.gbConsulta.Controls.Add(this.txtSemana);
            this.gbConsulta.Controls.Add(this.lblSemana);
            this.gbConsulta.Controls.Add(this.txtFechaHasta);
            this.gbConsulta.Controls.Add(this.txtFechaDesde);
            this.gbConsulta.Controls.Add(this.gbVistaReporte);
            this.gbConsulta.Controls.Add(this.txtPeriodo);
            this.gbConsulta.Controls.Add(this.radLabel3);
            this.gbConsulta.Controls.Add(this.label1);
            this.gbConsulta.Controls.Add(this.lblFechaDesde);
            this.gbConsulta.Controls.Add(this.lblFechaHasta);
            this.gbConsulta.Controls.Add(this.btnConsultar);
            this.gbConsulta.Controls.Add(this.cboMes);
            this.gbConsulta.Controls.Add(this.label5);
            this.gbConsulta.HeaderText = "";
            this.gbConsulta.Location = new System.Drawing.Point(5, 36);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(1270, 112);
            this.gbConsulta.TabIndex = 181;
            this.gbConsulta.ThemeName = "Windows8";
            // 
            // btnActualizarNombresTrabajador
            // 
            this.btnActualizarNombresTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarNombresTrabajador.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarNombresTrabajador.Image")));
            this.btnActualizarNombresTrabajador.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarNombresTrabajador.Location = new System.Drawing.Point(1130, 78);
            this.btnActualizarNombresTrabajador.Name = "btnActualizarNombresTrabajador";
            this.btnActualizarNombresTrabajador.Size = new System.Drawing.Size(130, 27);
            this.btnActualizarNombresTrabajador.TabIndex = 198;
            this.btnActualizarNombresTrabajador.Text = " &Actualizar nombres ";
            this.btnActualizarNombresTrabajador.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarNombresTrabajador.ThemeName = "Windows8";
            this.btnActualizarNombresTrabajador.Click += new System.EventHandler(this.btnActualizarNombresTrabajador_Click);
            // 
            // btnAnularDuplicidadAsistencias
            // 
            this.btnAnularDuplicidadAsistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnularDuplicidadAsistencias.Image = ((System.Drawing.Image)(resources.GetObject("btnAnularDuplicidadAsistencias.Image")));
            this.btnAnularDuplicidadAsistencias.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnularDuplicidadAsistencias.Location = new System.Drawing.Point(1004, 79);
            this.btnAnularDuplicidadAsistencias.Name = "btnAnularDuplicidadAsistencias";
            this.btnAnularDuplicidadAsistencias.Size = new System.Drawing.Size(121, 27);
            this.btnAnularDuplicidadAsistencias.TabIndex = 197;
            this.btnAnularDuplicidadAsistencias.Text = " &Anular duplicidad";
            this.btnAnularDuplicidadAsistencias.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnularDuplicidadAsistencias.ThemeName = "Windows8";
            this.btnAnularDuplicidadAsistencias.Click += new System.EventHandler(this.btnAnularDuplicidadAsistencias_Click);
            // 
            // btnGrafico
            // 
            this.btnGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrafico.Image = ((System.Drawing.Image)(resources.GetObject("btnGrafico.Image")));
            this.btnGrafico.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrafico.Location = new System.Drawing.Point(881, 80);
            this.btnGrafico.Name = "btnGrafico";
            this.btnGrafico.Size = new System.Drawing.Size(114, 27);
            this.btnGrafico.TabIndex = 196;
            this.btnGrafico.Text = "  &Ver Distribución";
            this.btnGrafico.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrafico.ThemeName = "Windows8";
            this.btnGrafico.Click += new System.EventHandler(this.btnGrafico_Click);
            // 
            // btnBuscarTransportista
            // 
            this.btnBuscarTransportista.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarTransportista.Image")));
            this.btnBuscarTransportista.Location = new System.Drawing.Point(36, 82);
            this.btnBuscarTransportista.Name = "btnBuscarTransportista";
            this.btnBuscarTransportista.P_CampoCodigo = "rtrim(nroDNI)";
            this.btnBuscarTransportista.P_CampoDescripcion = "rtrim(nroDNI), ISNULL(RTRIM(CP.RAZON_SOCIAL),\'\') + \' / \' + isnull(RTRIM(NROrUC),\'" +
    "\') + \' / \' + isnull(RTRIM(PseudoNombre),\'\') ";
            this.btnBuscarTransportista.P_EsEditable = true;
            this.btnBuscarTransportista.P_EsModificable = true;
            this.btnBuscarTransportista.P_FilterByTextBox = null;
            this.btnBuscarTransportista.P_TablaConsulta = "SJ_RHPension PNS LEFT JOIN CLIEPROV CP ON PNS.NroRUC = CP.IdClieprov LEFT JOIN ES" +
    "TADOS E ON PNS.IdEstado=E.IdEstado where  PNS.IdEstado = \'AC\'";
            this.btnBuscarTransportista.P_TextBoxCodigo = this.txtDNIProveedor;
            this.btnBuscarTransportista.P_TextBoxDescripcion = this.txtRazonSocialProveedor;
            this.btnBuscarTransportista.P_TituloFormulario = "Buscar RUC";
            this.btnBuscarTransportista.Size = new System.Drawing.Size(39, 23);
            this.btnBuscarTransportista.TabIndex = 193;
            this.btnBuscarTransportista.UseVisualStyleBackColor = true;
            this.btnBuscarTransportista.Visible = false;
            this.btnBuscarTransportista.Click += new System.EventHandler(this.btnBuscarTransportista_Click_1);
            // 
            // txtDNIProveedor
            // 
            this.txtDNIProveedor.BackColor = System.Drawing.Color.White;
            this.txtDNIProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDNIProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtDNIProveedor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDNIProveedor.Location = new System.Drawing.Point(79, 84);
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
            this.txtDNIProveedor.TabIndex = 194;
            this.txtDNIProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRazonSocialProveedor
            // 
            this.txtRazonSocialProveedor.BackColor = System.Drawing.Color.White;
            this.txtRazonSocialProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRazonSocialProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtRazonSocialProveedor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRazonSocialProveedor.Location = new System.Drawing.Point(192, 84);
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
            this.txtRazonSocialProveedor.Size = new System.Drawing.Size(390, 20);
            this.txtRazonSocialProveedor.TabIndex = 195;
            // 
            // txtSemana
            // 
            this.txtSemana.Location = new System.Drawing.Point(6, 58);
            this.txtSemana.Maximum = new decimal(new int[] {
            55,
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
            this.txtSemana.Size = new System.Drawing.Size(59, 20);
            this.txtSemana.TabIndex = 192;
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
            // lblSemana
            // 
            this.lblSemana.AutoSize = true;
            this.lblSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana.Location = new System.Drawing.Point(5, 43);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Size = new System.Drawing.Size(60, 13);
            this.lblSemana.TabIndex = 191;
            this.lblSemana.Text = "Semana :";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.EditingControlDataGridView = null;
            this.txtFechaHasta.EditingControlFormattedValue = "  /  /";
            this.txtFechaHasta.EditingControlRowIndex = 0;
            this.txtFechaHasta.EditingControlValueChanged = true;
            this.txtFechaHasta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaHasta.Location = new System.Drawing.Point(180, 58);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.P_EsEditable = false;
            this.txtFechaHasta.P_EsModificable = false;
            this.txtFechaHasta.P_ExigeInformacion = false;
            this.txtFechaHasta.P_Hora = null;
            this.txtFechaHasta.P_NombreColumna = null;
            this.txtFechaHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaHasta.Size = new System.Drawing.Size(81, 20);
            this.txtFechaHasta.TabIndex = 190;
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
            this.txtFechaDesde.Location = new System.Drawing.Point(79, 58);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaDesde.Size = new System.Drawing.Size(84, 20);
            this.txtFechaDesde.TabIndex = 189;
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // gbVistaReporte
            // 
            this.gbVistaReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbVistaReporte.Controls.Add(this.chkIncluirSubTotalesHorizontal);
            this.gbVistaReporte.Controls.Add(this.chkIncluirSubTotalesVertical);
            this.gbVistaReporte.Controls.Add(this.chkIncluirDesconocido);
            this.gbVistaReporte.HeaderText = "Vista del resultado de la consulta";
            this.gbVistaReporte.Location = new System.Drawing.Point(683, 7);
            this.gbVistaReporte.Name = "gbVistaReporte";
            this.gbVistaReporte.Size = new System.Drawing.Size(194, 101);
            this.gbVistaReporte.TabIndex = 188;
            this.gbVistaReporte.Text = "Vista del resultado de la consulta";
            this.gbVistaReporte.ThemeName = "Windows8";
            // 
            // chkIncluirSubTotalesHorizontal
            // 
            this.chkIncluirSubTotalesHorizontal.Location = new System.Drawing.Point(12, 75);
            this.chkIncluirSubTotalesHorizontal.Name = "chkIncluirSubTotalesHorizontal";
            this.chkIncluirSubTotalesHorizontal.Size = new System.Drawing.Size(131, 18);
            this.chkIncluirSubTotalesHorizontal.TabIndex = 185;
            this.chkIncluirSubTotalesHorizontal.Text = "SubTotales horizontal";
            this.chkIncluirSubTotalesHorizontal.ThemeName = "VisualStudio2012Light";
            this.chkIncluirSubTotalesHorizontal.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkIncluirSubTotalesHorizontal_ToggleStateChanged);
            // 
            // chkIncluirSubTotalesVertical
            // 
            this.chkIncluirSubTotalesVertical.Location = new System.Drawing.Point(12, 49);
            this.chkIncluirSubTotalesVertical.Name = "chkIncluirSubTotalesVertical";
            this.chkIncluirSubTotalesVertical.Size = new System.Drawing.Size(117, 18);
            this.chkIncluirSubTotalesVertical.TabIndex = 184;
            this.chkIncluirSubTotalesVertical.Text = "SubTotales vertical";
            this.chkIncluirSubTotalesVertical.ThemeName = "VisualStudio2012Light";
            this.chkIncluirSubTotalesVertical.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkIncluirSubTotalesVertical_ToggleStateChanged);
            // 
            // chkIncluirDesconocido
            // 
            this.chkIncluirDesconocido.Location = new System.Drawing.Point(12, 22);
            this.chkIncluirDesconocido.Name = "chkIncluirDesconocido";
            this.chkIncluirDesconocido.Size = new System.Drawing.Size(167, 18);
            this.chkIncluirDesconocido.TabIndex = 0;
            this.chkIncluirDesconocido.Text = "Incluir Personal Desconocido";
            this.chkIncluirDesconocido.ThemeName = "VisualStudio2012Light";
            this.chkIncluirDesconocido.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkIncluirDesconocido_ToggleStateChanged);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(5, 20);
            this.txtPeriodo.Maximum = new decimal(new int[] {
            2020,
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
            this.txtPeriodo.Size = new System.Drawing.Size(60, 20);
            this.txtPeriodo.TabIndex = 187;
            this.txtPeriodo.TabStop = false;
            this.txtPeriodo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeriodo.ThemeName = "Windows8";
            this.txtPeriodo.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            this.txtPeriodo.ValueChanged += new System.EventHandler(this.txtPeriodo_ValueChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(6, 86);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(67, 16);
            this.radLabel3.TabIndex = 184;
            this.radLabel3.Text = "Proveedor :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 166;
            this.label1.Text = "Año :";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(84, 42);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(51, 13);
            this.lblFechaDesde.TabIndex = 162;
            this.lblFechaDesde.Text = "Desde :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(178, 42);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(48, 13);
            this.lblFechaHasta.TabIndex = 163;
            this.lblFechaHasta.Text = "Hasta :";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.Location = new System.Drawing.Point(590, 80);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 27);
            this.btnConsultar.TabIndex = 159;
            this.btnConsultar.Text = "     &Consultar ";
            this.btnConsultar.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.ThemeName = "Windows8";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(79, 20);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(182, 20);
            this.cboMes.TabIndex = 158;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(77, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 156;
            this.label5.Text = "Mes :";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.menuPrincipal.Size = new System.Drawing.Size(1282, 37);
            this.menuPrincipal.TabIndex = 182;
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
            this.btnRRHH.Text = "     Recursos Humanos    ";
            this.btnRRHH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRRHH.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRRHH.ToolTipText = "Recursos Humanos";
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnExportar,
            this.btnSalir});
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            this.commandBarStripElement3.Text = "";
            this.commandBarStripElement3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandBarStripElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnExportar
            // 
            this.btnExportar.AccessibleDescription = "Exportar";
            this.btnExportar.AccessibleName = "Exportar";
            this.btnExportar.AutoSize = false;
            this.btnExportar.Bounds = new System.Drawing.Rectangle(0, 0, 105, 35);
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
            this.btnSalir.Bounds = new System.Drawing.Rectangle(0, 0, 105, 35);
            this.btnSalir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.DisplayName = "Salir";
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "";
            this.btnSalir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.ToolTipText = "Salir";
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // gbRegistros
            // 
            this.gbRegistros.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRegistros.Controls.Add(this.dgvGrillaPrivot);
            this.gbRegistros.HeaderText = "";
            this.gbRegistros.Location = new System.Drawing.Point(5, 154);
            this.gbRegistros.Name = "gbRegistros";
            this.gbRegistros.Size = new System.Drawing.Size(1270, 310);
            this.gbRegistros.TabIndex = 183;
            this.gbRegistros.ThemeName = "VisualStudio2012Light";
            // 
            // dgvGrillaPrivot
            // 
            propertyAggregateDescription1.AggregateFunction = sumAggregateFunction1;
            propertyAggregateDescription1.CustomName = null;
            propertyAggregateDescription1.PropertyName = null;
            propertyAggregateDescription1.StringFormat = null;
            propertyAggregateDescription1.StringFormatSelector = null;
            propertyAggregateDescription1.TotalFormat = null;
            this.dgvGrillaPrivot.AggregateDescriptions.Add(propertyAggregateDescription1);
            this.dgvGrillaPrivot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dateTimeGroupDescription1.CustomName = "Fecha";
            dateTimeGroupDescription1.GroupComparer = groupNameComparer1;
            dateTimeGroupDescription1.GroupFilter = null;
            dateTimeGroupDescription1.PropertyName = "fecha";
            dateTimeGroupDescription1.ShowGroupsWithNoData = false;
            dateTimeGroupDescription1.SortOrder = Telerik.Pivot.Core.SortOrder.Ascending;
            dateTimeGroupDescription1.Step = Telerik.Pivot.Core.DateTimeStep.Day;
            propertyGroupDescription1.CustomName = "Día de Semana";
            propertyGroupDescription1.GroupComparer = groupNameComparer2;
            propertyGroupDescription1.GroupFilter = null;
            propertyGroupDescription1.PropertyName = "dia";
            propertyGroupDescription1.ShowGroupsWithNoData = false;
            propertyGroupDescription1.SortOrder = Telerik.Pivot.Core.SortOrder.Descending;
            propertyGroupDescription2.CustomName = "Refrigerio";
            propertyGroupDescription2.GroupComparer = groupNameComparer3;
            propertyGroupDescription2.GroupFilter = null;
            propertyGroupDescription2.PropertyName = "tipoComida";
            propertyGroupDescription2.ShowGroupsWithNoData = true;
            propertyGroupDescription2.SortOrder = Telerik.Pivot.Core.SortOrder.Ascending;
            this.dgvGrillaPrivot.ColumnGroupDescriptions.Add(dateTimeGroupDescription1);
            this.dgvGrillaPrivot.ColumnGroupDescriptions.Add(propertyGroupDescription1);
            this.dgvGrillaPrivot.ColumnGroupDescriptions.Add(propertyGroupDescription2);
            this.dgvGrillaPrivot.ColumnWidth = 70;
            this.dgvGrillaPrivot.EmptyValueString = "-";
            this.dgvGrillaPrivot.Location = new System.Drawing.Point(0, 8);
            this.dgvGrillaPrivot.Name = "dgvGrillaPrivot";
            propertyGroupDescription3.CustomName = "NombresPension";
            propertyGroupDescription3.GroupComparer = groupNameComparer4;
            propertyGroupDescription3.GroupFilter = null;
            propertyGroupDescription3.PropertyName = "NombresPension";
            propertyGroupDescription3.ShowGroupsWithNoData = false;
            propertyGroupDescription3.SortOrder = Telerik.Pivot.Core.SortOrder.Ascending;
            propertyGroupDescription4.CustomName = "NombresTrabajador";
            propertyGroupDescription4.GroupComparer = groupNameComparer5;
            propertyGroupDescription4.GroupFilter = null;
            propertyGroupDescription4.PropertyName = "NombresTrabajador";
            propertyGroupDescription4.ShowGroupsWithNoData = false;
            propertyGroupDescription4.SortOrder = Telerik.Pivot.Core.SortOrder.Ascending;
            this.dgvGrillaPrivot.RowGroupDescriptions.Add(propertyGroupDescription3);
            this.dgvGrillaPrivot.RowGroupDescriptions.Add(propertyGroupDescription4);
            this.dgvGrillaPrivot.RowHeadersLayout = Telerik.WinControls.UI.PivotLayout.Compact;
            this.dgvGrillaPrivot.ShowFilterArea = true;
            this.dgvGrillaPrivot.Size = new System.Drawing.Size(1265, 297);
            this.dgvGrillaPrivot.TabIndex = 0;
            this.dgvGrillaPrivot.ThemeName = "Windows8";
            this.dgvGrillaPrivot.SelectionChanged += new System.EventHandler(this.dgvGrillaPrivot_SelectionChanged);
            // 
            // bgwProceso02
            // 
            this.bgwProceso02.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProceso02_DoWork);
            this.bgwProceso02.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProceso02_RunWorkerCompleted);
            // 
            // bgwProceso03
            // 
            this.bgwProceso03.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProceso03_DoWork);
            this.bgwProceso03.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProceso03_RunWorkerCompleted);
            // 
            // ReporteAsistenciaRefrigerioTransferencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1282, 489);
            this.Controls.Add(this.gbRegistros);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.stsBarraEstado);
            this.Name = "ReporteAsistenciaRefrigerioTransferencia";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Reporte de asistencias a refrigerio desde los móviles";
            this.ThemeName = "Windows8";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteAsistenciasRefrigerioTransferencia_Load);
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).EndInit();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizarNombresTrabajador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAnularDuplicidadAsistencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbVistaReporte)).EndInit();
            this.gbVistaReporte.ResumeLayout(false);
            this.gbVistaReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncluirSubTotalesHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncluirSubTotalesVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncluirDesconocido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).EndInit();
            this.gbRegistros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaPrivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Telerik.WinControls.UI.RadGroupBox gbConsulta;
        private Telerik.WinControls.UI.RadSpinEditor txtPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.UI.RadButton btnConsultar;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadCommandBar menuPrincipal;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnExportar;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private System.ComponentModel.BackgroundWorker bgwHilo;
        private Telerik.WinControls.UI.RadGroupBox gbRegistros;
        private Telerik.WinControls.UI.RadPivotGrid dgvGrillaPrivot;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGroupBox gbVistaReporte;
        private Telerik.WinControls.UI.RadCheckBox chkIncluirDesconocido;
        private Telerik.WinControls.UI.RadCheckBox chkIncluirSubTotalesHorizontal;
        private Telerik.WinControls.UI.RadCheckBox chkIncluirSubTotalesVertical;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaHasta;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private Telerik.WinControls.UI.RadSpinEditor txtSemana;
        private System.Windows.Forms.Label lblSemana;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnBuscarTransportista;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtDNIProveedor;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtRazonSocialProveedor;
        private Telerik.WinControls.UI.RadButton btnGrafico;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.RadButton btnActualizarNombresTrabajador;
        private Telerik.WinControls.UI.RadButton btnAnularDuplicidadAsistencias;
        private System.ComponentModel.BackgroundWorker bgwProceso02;
        private System.ComponentModel.BackgroundWorker bgwProceso03;
    }
}
