namespace Transportista
{
    partial class ProgramacionRefrigerioxPersonalMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramacionRefrigerioxPersonalMantenimiento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAltaBaja = new Telerik.WinControls.UI.RadButton();
            this.btnAltaTarifa = new Telerik.WinControls.UI.RadButton();
            this.btnQuitar = new Telerik.WinControls.UI.RadButton();
            this.btnAgregar = new Telerik.WinControls.UI.RadButton();
            this.btnImprimirTicket = new Telerik.WinControls.UI.RadButton();
            this.gbMantenimientoRegistros = new Telerik.WinControls.UI.RadGroupBox();
            this.gbInformacionGeneral = new Telerik.WinControls.UI.RadGroupBox();
            this.txtHospedajeDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.lblParaderoDescripcion = new Telerik.WinControls.UI.RadLabel();
            this.txtNombresCompletosTrabajador = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtCodigoPersonal = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.btnBuscarPersonal = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtSubPlanilla = new Telerik.WinControls.UI.RadTextBox();
            this.txtIdSubPlanilla = new Telerik.WinControls.UI.RadTextBox();
            this.txtCondicion = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.txtNroDNI = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.gbPension = new Telerik.WinControls.UI.RadGroupBox();
            this.txtCodigoPersonalParadero = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.txtRUCNumero = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.btnBuscarPension = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtRucRazonSocial = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtIdPension = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigo = new Telerik.WinControls.UI.RadTextBox();
            this.txtIdEstado = new Telerik.WinControls.UI.RadTextBox();
            this.txtRucDNIResponsable = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.txtRucNombresResponsable = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtEstado = new Telerik.WinControls.UI.RadTextBox();
            this.txtRucNombreComercial = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.TabRegistros = new Telerik.WinControls.UI.RadPageView();
            this.tabDetalle = new Telerik.WinControls.UI.RadPageViewPage();
            this.dgvDetalle = new MyControlsDataBinding.Controles.MyDataGridViewDetails(this.components);
            this.chId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chValidoDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextColumn();
            this.chValidoHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextColumn();
            this.chObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chIdEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTipoRefrigerio = new Telerik.WinControls.UI.RadGroupBox();
            this.chkOtro = new Telerik.WinControls.UI.RadCheckBox();
            this.chkCena = new Telerik.WinControls.UI.RadCheckBox();
            this.chkDesayuno = new Telerik.WinControls.UI.RadCheckBox();
            this.chkAlmuerzo = new Telerik.WinControls.UI.RadCheckBox();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.bwgHilo = new System.ComponentModel.BackgroundWorker();
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
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnAnular = new Telerik.WinControls.UI.CommandBarButton();
            this.btnEliminar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnGrabar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnAtras = new Telerik.WinControls.UI.CommandBarButton();
            this.btnHistorial = new Telerik.WinControls.UI.CommandBarButton();
            this.btnExportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnVistaPrevia = new Telerik.WinControls.UI.CommandBarButton();
            this.btnImprimir = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.barraPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            ((System.ComponentModel.ISupportInitialize)(this.btnAltaBaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAltaTarifa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimirTicket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMantenimientoRegistros)).BeginInit();
            this.gbMantenimientoRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbInformacionGeneral)).BeginInit();
            this.gbInformacionGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHospedajeDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParaderoDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdSubPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCondicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroDNI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbPension)).BeginInit();
            this.gbPension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoPersonalParadero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdPension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRucDNIResponsable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRucNombresResponsable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRucNombreComercial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabRegistros)).BeginInit();
            this.TabRegistros.SuspendLayout();
            this.tabDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTipoRefrigerio)).BeginInit();
            this.gbTipoRefrigerio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkOtro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDesayuno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlmuerzo)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAltaBaja
            // 
            this.btnAltaBaja.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnAltaBaja.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaBaja.Image")));
            this.btnAltaBaja.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAltaBaja.Location = new System.Drawing.Point(35, 3);
            this.btnAltaBaja.Name = "btnAltaBaja";
            this.btnAltaBaja.Size = new System.Drawing.Size(26, 30);
            this.btnAltaBaja.TabIndex = 39;
            this.btnAltaBaja.ThemeName = "VisualStudio2012Light";
            this.toolTip.SetToolTip(this.btnAltaBaja, "Baja de Tarifa");
            this.btnAltaBaja.Click += new System.EventHandler(this.btnAltaBaja_Click);
            // 
            // btnAltaTarifa
            // 
            this.btnAltaTarifa.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnAltaTarifa.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaTarifa.Image")));
            this.btnAltaTarifa.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAltaTarifa.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.btnAltaTarifa.Location = new System.Drawing.Point(6, 3);
            this.btnAltaTarifa.Margin = new System.Windows.Forms.Padding(1);
            this.btnAltaTarifa.Name = "btnAltaTarifa";
            // 
            // 
            // 
            this.btnAltaTarifa.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAltaTarifa.RootElement.AutoSize = false;
            this.btnAltaTarifa.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            this.btnAltaTarifa.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            this.btnAltaTarifa.Size = new System.Drawing.Size(26, 30);
            this.btnAltaTarifa.TabIndex = 38;
            this.btnAltaTarifa.ThemeName = "VisualStudio2012Light";
            this.toolTip.SetToolTip(this.btnAltaTarifa, "Alta de Tarifa");
            this.btnAltaTarifa.Click += new System.EventHandler(this.btnAltaTarifa_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnQuitar.Location = new System.Drawing.Point(1050, 3);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(26, 30);
            this.btnQuitar.TabIndex = 41;
            this.btnQuitar.ThemeName = "VisualStudio2012Light";
            this.toolTip.SetToolTip(this.btnQuitar, "Quitar un Registro de la Lista");
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitarTarifa_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.btnAgregar.Location = new System.Drawing.Point(1020, 3);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(1);
            this.btnAgregar.Name = "btnAgregar";
            // 
            // 
            // 
            this.btnAgregar.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregar.RootElement.AutoSize = false;
            this.btnAgregar.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            this.btnAgregar.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            this.btnAgregar.Size = new System.Drawing.Size(26, 30);
            this.btnAgregar.TabIndex = 40;
            this.btnAgregar.ThemeName = "VisualStudio2012Light";
            this.toolTip.SetToolTip(this.btnAgregar, "Agregar un Registro nuevo");
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregarTarifa_Click);
            // 
            // btnImprimirTicket
            // 
            this.btnImprimirTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirTicket.Image")));
            this.btnImprimirTicket.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.btnImprimirTicket.Location = new System.Drawing.Point(956, 116);
            this.btnImprimirTicket.Margin = new System.Windows.Forms.Padding(1);
            this.btnImprimirTicket.Name = "btnImprimirTicket";
            // 
            // 
            // 
            this.btnImprimirTicket.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnImprimirTicket.RootElement.AutoSize = false;
            this.btnImprimirTicket.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            this.btnImprimirTicket.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            this.btnImprimirTicket.Size = new System.Drawing.Size(127, 32);
            this.btnImprimirTicket.TabIndex = 20;
            this.btnImprimirTicket.Text = "Imprimir ticket";
            this.btnImprimirTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnImprimirTicket.ThemeName = "Windows8";
            this.toolTip.SetToolTip(this.btnImprimirTicket, "Agregar un Registro nuevo");
            this.btnImprimirTicket.Click += new System.EventHandler(this.btnImprimirTicket_Click);
            // 
            // gbMantenimientoRegistros
            // 
            this.gbMantenimientoRegistros.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbMantenimientoRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMantenimientoRegistros.Controls.Add(this.gbInformacionGeneral);
            this.gbMantenimientoRegistros.Controls.Add(this.gbPension);
            this.gbMantenimientoRegistros.Controls.Add(this.TabRegistros);
            this.gbMantenimientoRegistros.Controls.Add(this.btnImprimirTicket);
            this.gbMantenimientoRegistros.Controls.Add(this.gbTipoRefrigerio);
            this.gbMantenimientoRegistros.Enabled = false;
            this.gbMantenimientoRegistros.HeaderText = "";
            this.gbMantenimientoRegistros.Location = new System.Drawing.Point(5, 42);
            this.gbMantenimientoRegistros.Name = "gbMantenimientoRegistros";
            this.gbMantenimientoRegistros.Padding = new System.Windows.Forms.Padding(2, 22, 2, 2);
            this.gbMantenimientoRegistros.Size = new System.Drawing.Size(1091, 441);
            this.gbMantenimientoRegistros.TabIndex = 2;
            this.gbMantenimientoRegistros.Tag = "";
            this.gbMantenimientoRegistros.ThemeName = "Windows8";
            this.gbMantenimientoRegistros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gbMantenimientoRegistros_KeyDown);
            // 
            // gbInformacionGeneral
            // 
            this.gbInformacionGeneral.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbInformacionGeneral.Controls.Add(this.txtHospedajeDescripcion);
            this.gbInformacionGeneral.Controls.Add(this.lblParaderoDescripcion);
            this.gbInformacionGeneral.Controls.Add(this.txtNombresCompletosTrabajador);
            this.gbInformacionGeneral.Controls.Add(this.txtCodigoPersonal);
            this.gbInformacionGeneral.Controls.Add(this.btnBuscarPersonal);
            this.gbInformacionGeneral.Controls.Add(this.txtSubPlanilla);
            this.gbInformacionGeneral.Controls.Add(this.txtIdSubPlanilla);
            this.gbInformacionGeneral.Controls.Add(this.txtCondicion);
            this.gbInformacionGeneral.Controls.Add(this.radLabel11);
            this.gbInformacionGeneral.Controls.Add(this.txtNroDNI);
            this.gbInformacionGeneral.Controls.Add(this.radLabel10);
            this.gbInformacionGeneral.Controls.Add(this.radLabel6);
            this.gbInformacionGeneral.Controls.Add(this.radLabel8);
            this.gbInformacionGeneral.Controls.Add(this.radLabel9);
            this.gbInformacionGeneral.Enabled = false;
            this.gbInformacionGeneral.HeaderText = "Información del trabajador";
            this.gbInformacionGeneral.Location = new System.Drawing.Point(0, 105);
            this.gbInformacionGeneral.Name = "gbInformacionGeneral";
            this.gbInformacionGeneral.Size = new System.Drawing.Size(747, 110);
            this.gbInformacionGeneral.TabIndex = 21;
            this.gbInformacionGeneral.Text = "Información del trabajador";
            this.gbInformacionGeneral.ThemeName = "Windows8";
            // 
            // txtHospedajeDescripcion
            // 
            this.txtHospedajeDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHospedajeDescripcion.Location = new System.Drawing.Point(411, 80);
            this.txtHospedajeDescripcion.MaxLength = 250;
            this.txtHospedajeDescripcion.Name = "txtHospedajeDescripcion";
            this.txtHospedajeDescripcion.ReadOnly = true;
            this.txtHospedajeDescripcion.Size = new System.Drawing.Size(322, 20);
            this.txtHospedajeDescripcion.TabIndex = 33;
            this.txtHospedajeDescripcion.TabStop = false;
            this.txtHospedajeDescripcion.ThemeName = "VisualStudio2012Light";
            // 
            // lblParaderoDescripcion
            // 
            this.lblParaderoDescripcion.Location = new System.Drawing.Point(340, 82);
            this.lblParaderoDescripcion.Name = "lblParaderoDescripcion";
            this.lblParaderoDescripcion.Size = new System.Drawing.Size(65, 18);
            this.lblParaderoDescripcion.TabIndex = 28;
            this.lblParaderoDescripcion.Text = "Hospedaje :";
            // 
            // txtNombresCompletosTrabajador
            // 
            this.txtNombresCompletosTrabajador.BackColor = System.Drawing.Color.White;
            this.txtNombresCompletosTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombresCompletosTrabajador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtNombresCompletosTrabajador.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNombresCompletosTrabajador.Location = new System.Drawing.Point(129, 54);
            this.txtNombresCompletosTrabajador.Name = "txtNombresCompletosTrabajador";
            this.txtNombresCompletosTrabajador.P_BotonEnlace = null;
            this.txtNombresCompletosTrabajador.P_BuscarSoloCodigoExacto = false;
            this.txtNombresCompletosTrabajador.P_EsEditable = false;
            this.txtNombresCompletosTrabajador.P_EsModificable = false;
            this.txtNombresCompletosTrabajador.P_EsPrimaryKey = false;
            this.txtNombresCompletosTrabajador.P_ExigeInformacion = false;
            this.txtNombresCompletosTrabajador.P_NombreColumna = null;
            this.txtNombresCompletosTrabajador.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtNombresCompletosTrabajador.ReadOnly = true;
            this.txtNombresCompletosTrabajador.Size = new System.Drawing.Size(604, 20);
            this.txtNombresCompletosTrabajador.TabIndex = 30;
            this.txtNombresCompletosTrabajador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombresCompletosTrabajador_KeyDown);
            // 
            // txtCodigoPersonal
            // 
            this.txtCodigoPersonal.BackColor = System.Drawing.Color.White;
            this.txtCodigoPersonal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtCodigoPersonal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCodigoPersonal.Location = new System.Drawing.Point(177, 22);
            this.txtCodigoPersonal.MaxLength = 12;
            this.txtCodigoPersonal.Name = "txtCodigoPersonal";
            this.txtCodigoPersonal.P_BotonEnlace = this.btnBuscarPersonal;
            this.txtCodigoPersonal.P_BuscarSoloCodigoExacto = false;
            this.txtCodigoPersonal.P_EsEditable = true;
            this.txtCodigoPersonal.P_EsModificable = true;
            this.txtCodigoPersonal.P_EsPrimaryKey = false;
            this.txtCodigoPersonal.P_ExigeInformacion = false;
            this.txtCodigoPersonal.P_NombreColumna = null;
            this.txtCodigoPersonal.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtCodigoPersonal.Size = new System.Drawing.Size(102, 20);
            this.txtCodigoPersonal.TabIndex = 24;
            this.txtCodigoPersonal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoPersonal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoPersonal_KeyDown);
            this.txtCodigoPersonal.Leave += new System.EventHandler(this.txtCodigoPersonal_Leave);
            // 
            // btnBuscarPersonal
            // 
            this.btnBuscarPersonal.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPersonal.Image")));
            this.btnBuscarPersonal.Location = new System.Drawing.Point(132, 21);
            this.btnBuscarPersonal.Name = "btnBuscarPersonal";
            this.btnBuscarPersonal.P_CampoCodigo = "rtrim(PG.IDCODIGOGENERAL)";
            this.btnBuscarPersonal.P_CampoDescripcion = resources.GetString("btnBuscarPersonal.P_CampoDescripcion");
            this.btnBuscarPersonal.P_EsEditable = true;
            this.btnBuscarPersonal.P_EsModificable = true;
            this.btnBuscarPersonal.P_FilterByTextBox = null;
            this.btnBuscarPersonal.P_TablaConsulta = resources.GetString("btnBuscarPersonal.P_TablaConsulta");
            this.btnBuscarPersonal.P_TextBoxCodigo = this.txtCodigoPersonal;
            this.btnBuscarPersonal.P_TextBoxDescripcion = this.txtNombresCompletosTrabajador;
            this.btnBuscarPersonal.P_TituloFormulario = "Buscar RUC";
            this.btnBuscarPersonal.Size = new System.Drawing.Size(39, 23);
            this.btnBuscarPersonal.TabIndex = 23;
            this.btnBuscarPersonal.UseVisualStyleBackColor = true;
            this.btnBuscarPersonal.Click += new System.EventHandler(this.btnBuscarPersonal_Click);
            // 
            // txtSubPlanilla
            // 
            this.txtSubPlanilla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubPlanilla.Location = new System.Drawing.Point(129, 80);
            this.txtSubPlanilla.MaxLength = 250;
            this.txtSubPlanilla.Name = "txtSubPlanilla";
            this.txtSubPlanilla.ReadOnly = true;
            this.txtSubPlanilla.Size = new System.Drawing.Size(206, 20);
            this.txtSubPlanilla.TabIndex = 32;
            this.txtSubPlanilla.TabStop = false;
            this.txtSubPlanilla.ThemeName = "VisualStudio2012Light";
            this.txtSubPlanilla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubPlanilla_KeyDown);
            // 
            // txtIdSubPlanilla
            // 
            this.txtIdSubPlanilla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdSubPlanilla.Location = new System.Drawing.Point(11, 80);
            this.txtIdSubPlanilla.MaxLength = 250;
            this.txtIdSubPlanilla.Name = "txtIdSubPlanilla";
            this.txtIdSubPlanilla.ReadOnly = true;
            this.txtIdSubPlanilla.Size = new System.Drawing.Size(40, 20);
            this.txtIdSubPlanilla.TabIndex = 30;
            this.txtIdSubPlanilla.TabStop = false;
            this.txtIdSubPlanilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdSubPlanilla.ThemeName = "VisualStudio2012Light";
            this.txtIdSubPlanilla.Visible = false;
            // 
            // txtCondicion
            // 
            this.txtCondicion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCondicion.Location = new System.Drawing.Point(572, 22);
            this.txtCondicion.MaxLength = 8;
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.ReadOnly = true;
            this.txtCondicion.Size = new System.Drawing.Size(161, 20);
            this.txtCondicion.TabIndex = 28;
            this.txtCondicion.TabStop = false;
            this.txtCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCondicion.ThemeName = "VisualStudio2012Light";
            this.txtCondicion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCondicion_KeyDown);
            // 
            // radLabel11
            // 
            this.radLabel11.Location = new System.Drawing.Point(504, 25);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(62, 18);
            this.radLabel11.TabIndex = 27;
            this.radLabel11.Text = "Condición :";
            // 
            // txtNroDNI
            // 
            this.txtNroDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroDNI.Location = new System.Drawing.Point(363, 22);
            this.txtNroDNI.MaxLength = 8;
            this.txtNroDNI.Name = "txtNroDNI";
            this.txtNroDNI.ReadOnly = true;
            this.txtNroDNI.Size = new System.Drawing.Size(109, 20);
            this.txtNroDNI.TabIndex = 26;
            this.txtNroDNI.TabStop = false;
            this.txtNroDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNroDNI.ThemeName = "VisualStudio2012Light";
            this.txtNroDNI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroDNI_KeyDown);
            // 
            // radLabel10
            // 
            this.radLabel10.Location = new System.Drawing.Point(57, 82);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(66, 18);
            this.radLabel10.TabIndex = 31;
            this.radLabel10.Text = "SubPlanilla :";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(29, 25);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(91, 18);
            this.radLabel6.TabIndex = 22;
            this.radLabel6.Text = "Codigo Personal:";
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(304, 25);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(53, 18);
            this.radLabel8.TabIndex = 25;
            this.radLabel8.Text = "Nro DNI :";
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(5, 55);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(115, 18);
            this.radLabel9.TabIndex = 29;
            this.radLabel9.Text = "Nombres Completos :";
            // 
            // gbPension
            // 
            this.gbPension.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbPension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPension.Controls.Add(this.txtCodigoPersonalParadero);
            this.gbPension.Controls.Add(this.radLabel12);
            this.gbPension.Controls.Add(this.txtRUCNumero);
            this.gbPension.Controls.Add(this.txtRucRazonSocial);
            this.gbPension.Controls.Add(this.txtIdPension);
            this.gbPension.Controls.Add(this.btnBuscarPension);
            this.gbPension.Controls.Add(this.radLabel1);
            this.gbPension.Controls.Add(this.txtCodigo);
            this.gbPension.Controls.Add(this.txtIdEstado);
            this.gbPension.Controls.Add(this.txtRucDNIResponsable);
            this.gbPension.Controls.Add(this.radLabel7);
            this.gbPension.Controls.Add(this.txtRucNombresResponsable);
            this.gbPension.Controls.Add(this.radLabel3);
            this.gbPension.Controls.Add(this.txtEstado);
            this.gbPension.Controls.Add(this.txtRucNombreComercial);
            this.gbPension.Controls.Add(this.radLabel2);
            this.gbPension.Controls.Add(this.radLabel5);
            this.gbPension.Controls.Add(this.radLabel4);
            this.gbPension.Enabled = false;
            this.gbPension.HeaderText = "";
            this.gbPension.Location = new System.Drawing.Point(0, 0);
            this.gbPension.Name = "gbPension";
            this.gbPension.Size = new System.Drawing.Size(1091, 100);
            this.gbPension.TabIndex = 3;
            this.gbPension.ThemeName = "Windows8";
            // 
            // txtCodigoPersonalParadero
            // 
            this.txtCodigoPersonalParadero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoPersonalParadero.Enabled = false;
            this.txtCodigoPersonalParadero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCodigoPersonalParadero.Location = new System.Drawing.Point(924, 39);
            this.txtCodigoPersonalParadero.Name = "txtCodigoPersonalParadero";
            this.txtCodigoPersonalParadero.Size = new System.Drawing.Size(159, 20);
            this.txtCodigoPersonalParadero.TabIndex = 184;
            this.txtCodigoPersonalParadero.TabStop = false;
            this.txtCodigoPersonalParadero.ThemeName = "VisualStudio2012Light";
            this.txtCodigoPersonalParadero.Visible = false;
            // 
            // radLabel12
            // 
            this.radLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel12.Location = new System.Drawing.Point(776, 40);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(142, 18);
            this.radLabel12.TabIndex = 183;
            this.radLabel12.Text = "Código personal paradero :";
            this.radLabel12.Visible = false;
            // 
            // txtRUCNumero
            // 
            this.txtRUCNumero.BackColor = System.Drawing.Color.White;
            this.txtRUCNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRUCNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtRUCNumero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRUCNumero.Location = new System.Drawing.Point(177, 7);
            this.txtRUCNumero.MaxLength = 12;
            this.txtRUCNumero.Name = "txtRUCNumero";
            this.txtRUCNumero.P_BotonEnlace = this.btnBuscarPension;
            this.txtRUCNumero.P_BuscarSoloCodigoExacto = false;
            this.txtRUCNumero.P_EsEditable = true;
            this.txtRUCNumero.P_EsModificable = true;
            this.txtRUCNumero.P_EsPrimaryKey = false;
            this.txtRUCNumero.P_ExigeInformacion = false;
            this.txtRUCNumero.P_NombreColumna = null;
            this.txtRUCNumero.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtRUCNumero.Size = new System.Drawing.Size(128, 20);
            this.txtRUCNumero.TabIndex = 7;
            this.txtRUCNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRUCNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRUCNumero_KeyDown);
            this.txtRUCNumero.Leave += new System.EventHandler(this.txtRUCNumero_Leave);
            // 
            // btnBuscarPension
            // 
            this.btnBuscarPension.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPension.Image")));
            this.btnBuscarPension.Location = new System.Drawing.Point(132, 6);
            this.btnBuscarPension.Name = "btnBuscarPension";
            this.btnBuscarPension.P_CampoCodigo = " RTRIM(PNS.NroRuc)";
            this.btnBuscarPension.P_CampoDescripcion = "ISNULL(RTRIM(CP.RAZON_SOCIAL),\'\')  + \' / \' + RTRIM(PNS.NroDNI)   + \' / \' +  ISNUL" +
    "L(RTRIM(PNS.NombresCompletos),\'\')  + \' / \' +  RTRIM(PNS.PseudoNombre) + \' / \' + " +
    "CAST( PNS.IdPension AS varchar(4)) ";
            this.btnBuscarPension.P_EsEditable = true;
            this.btnBuscarPension.P_EsModificable = true;
            this.btnBuscarPension.P_FilterByTextBox = null;
            this.btnBuscarPension.P_TablaConsulta = "SJ_RHPension PNS LEFT JOIN CLIEPROV CP ON PNS.NroRUC = CP.IdClieprov LEFT JOIN ES" +
    "TADOS E ON PNS.IdEstado=E.IdEstado where  PNS.IdEstado = \'AC\'";
            this.btnBuscarPension.P_TextBoxCodigo = this.txtRUCNumero;
            this.btnBuscarPension.P_TextBoxDescripcion = this.txtRucRazonSocial;
            this.btnBuscarPension.P_TituloFormulario = "Buscar RUC";
            this.btnBuscarPension.Size = new System.Drawing.Size(39, 23);
            this.btnBuscarPension.TabIndex = 6;
            this.btnBuscarPension.UseVisualStyleBackColor = true;
            this.btnBuscarPension.Click += new System.EventHandler(this.btnBuscarPension_Click);
            this.btnBuscarPension.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnBuscarPension_KeyDown);
            // 
            // txtRucRazonSocial
            // 
            this.txtRucRazonSocial.BackColor = System.Drawing.Color.White;
            this.txtRucRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRucRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtRucRazonSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRucRazonSocial.Location = new System.Drawing.Point(311, 7);
            this.txtRucRazonSocial.Name = "txtRucRazonSocial";
            this.txtRucRazonSocial.P_BotonEnlace = null;
            this.txtRucRazonSocial.P_BuscarSoloCodigoExacto = false;
            this.txtRucRazonSocial.P_EsEditable = false;
            this.txtRucRazonSocial.P_EsModificable = false;
            this.txtRucRazonSocial.P_EsPrimaryKey = false;
            this.txtRucRazonSocial.P_ExigeInformacion = false;
            this.txtRucRazonSocial.P_NombreColumna = null;
            this.txtRucRazonSocial.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtRucRazonSocial.ReadOnly = true;
            this.txtRucRazonSocial.Size = new System.Drawing.Size(422, 20);
            this.txtRucRazonSocial.TabIndex = 8;
            this.txtRucRazonSocial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRucRazonSocial_KeyDown);
            // 
            // txtIdPension
            // 
            this.txtIdPension.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdPension.Location = new System.Drawing.Point(11, 10);
            this.txtIdPension.MaxLength = 8;
            this.txtIdPension.Name = "txtIdPension";
            this.txtIdPension.ReadOnly = true;
            this.txtIdPension.Size = new System.Drawing.Size(40, 20);
            this.txtIdPension.TabIndex = 4;
            this.txtIdPension.TabStop = false;
            this.txtIdPension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdPension.ThemeName = "VisualStudio2012Light";
            this.txtIdPension.Visible = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Location = new System.Drawing.Point(813, 71);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(105, 18);
            this.radLabel1.TabIndex = 18;
            this.radLabel1.Text = "Código del registro:";
            this.radLabel1.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Enabled = false;
            this.txtCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCodigo.Location = new System.Drawing.Point(924, 68);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(159, 20);
            this.txtCodigo.TabIndex = 19;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.ThemeName = "VisualStudio2012Light";
            this.txtCodigo.Visible = false;
            // 
            // txtIdEstado
            // 
            this.txtIdEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdEstado.Location = new System.Drawing.Point(836, 8);
            this.txtIdEstado.Name = "txtIdEstado";
            this.txtIdEstado.Size = new System.Drawing.Size(32, 20);
            this.txtIdEstado.TabIndex = 10;
            this.txtIdEstado.TabStop = false;
            this.txtIdEstado.Text = "AC";
            this.txtIdEstado.ThemeName = "VisualStudio2012Light";
            this.txtIdEstado.Visible = false;
            // 
            // txtRucDNIResponsable
            // 
            this.txtRucDNIResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRucDNIResponsable.Location = new System.Drawing.Point(129, 40);
            this.txtRucDNIResponsable.MaxLength = 8;
            this.txtRucDNIResponsable.Name = "txtRucDNIResponsable";
            this.txtRucDNIResponsable.ReadOnly = true;
            this.txtRucDNIResponsable.Size = new System.Drawing.Size(150, 20);
            this.txtRucDNIResponsable.TabIndex = 14;
            this.txtRucDNIResponsable.TabStop = false;
            this.txtRucDNIResponsable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRucDNIResponsable.ThemeName = "VisualStudio2012Light";
            this.txtRucDNIResponsable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRucDNIResponsable_KeyDown);
            // 
            // radLabel7
            // 
            this.radLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel7.Location = new System.Drawing.Point(770, 11);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(55, 18);
            this.radLabel7.TabIndex = 9;
            this.radLabel7.Text = "IdEstado :";
            this.radLabel7.Visible = false;
            // 
            // txtRucNombresResponsable
            // 
            this.txtRucNombresResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRucNombresResponsable.Location = new System.Drawing.Point(285, 40);
            this.txtRucNombresResponsable.MaxLength = 250;
            this.txtRucNombresResponsable.Name = "txtRucNombresResponsable";
            this.txtRucNombresResponsable.ReadOnly = true;
            this.txtRucNombresResponsable.Size = new System.Drawing.Size(448, 20);
            this.txtRucNombresResponsable.TabIndex = 15;
            this.txtRucNombresResponsable.TabStop = false;
            this.txtRucNombresResponsable.ThemeName = "VisualStudio2012Light";
            this.txtRucNombresResponsable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRucNombresResponsable_KeyDown);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(72, 10);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(51, 18);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Pensión :";
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstado.Location = new System.Drawing.Point(924, 9);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(159, 20);
            this.txtEstado.TabIndex = 12;
            this.txtEstado.TabStop = false;
            this.txtEstado.Text = "ACTIVO";
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstado.ThemeName = "VisualStudio2012Light";
            this.txtEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEstado_KeyDown);
            // 
            // txtRucNombreComercial
            // 
            this.txtRucNombreComercial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRucNombreComercial.Location = new System.Drawing.Point(129, 66);
            this.txtRucNombreComercial.MaxLength = 250;
            this.txtRucNombreComercial.Name = "txtRucNombreComercial";
            this.txtRucNombreComercial.ReadOnly = true;
            this.txtRucNombreComercial.Size = new System.Drawing.Size(604, 20);
            this.txtRucNombreComercial.TabIndex = 17;
            this.txtRucNombreComercial.TabStop = false;
            this.txtRucNombreComercial.ThemeName = "VisualStudio2012Light";
            this.txtRucNombreComercial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRucNombreComercial_KeyDown);
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.Location = new System.Drawing.Point(873, 11);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(45, 18);
            this.radLabel2.TabIndex = 11;
            this.radLabel2.Text = "Estado :";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(48, 41);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(75, 18);
            this.radLabel5.TabIndex = 13;
            this.radLabel5.Text = "Responsable :";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(17, 68);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(106, 18);
            this.radLabel4.TabIndex = 16;
            this.radLabel4.Text = "Nombre Comercial :";
            // 
            // TabRegistros
            // 
            this.TabRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabRegistros.Controls.Add(this.tabDetalle);
            this.TabRegistros.Location = new System.Drawing.Point(5, 221);
            this.TabRegistros.Name = "TabRegistros";
            this.TabRegistros.SelectedPage = this.tabDetalle;
            this.TabRegistros.Size = new System.Drawing.Size(1086, 202);
            this.TabRegistros.TabIndex = 34;
            this.TabRegistros.Text = "TabMantenimiento";
            this.TabRegistros.ThemeName = "Windows8";
            this.TabRegistros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabRegistros_KeyDown);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.TabRegistros.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.LeftScroll;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.TabRegistros.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.TabRegistros.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Bottom;
            // 
            // tabDetalle
            // 
            this.tabDetalle.Controls.Add(this.btnAltaBaja);
            this.tabDetalle.Controls.Add(this.dgvDetalle);
            this.tabDetalle.Controls.Add(this.btnAltaTarifa);
            this.tabDetalle.Controls.Add(this.btnQuitar);
            this.tabDetalle.Controls.Add(this.btnAgregar);
            this.tabDetalle.Enabled = false;
            this.tabDetalle.ItemSize = new System.Drawing.SizeF(1064F, 26F);
            this.tabDetalle.Location = new System.Drawing.Point(5, 5);
            this.tabDetalle.Name = "tabDetalle";
            this.tabDetalle.Size = new System.Drawing.Size(1076, 168);
            this.tabDetalle.Text = "Detalle";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersHeight = 30;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chId,
            this.chItem,
            this.chValidoDesde,
            this.chValidoHasta,
            this.chObservacion,
            this.chIdEstado,
            this.chEstado});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDetalle.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 37);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.P_EsEditable = false;
            this.dgvDetalle.P_FormatoDecimal = null;
            this.dgvDetalle.P_FormatoFecha = null;
            this.dgvDetalle.P_NombreColCorrelativa = null;
            this.dgvDetalle.P_NombreTabla = null;
            this.dgvDetalle.P_NumeroDigitos = 0;
            this.dgvDetalle.RowHeadersWidth = 10;
            this.dgvDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDetalle.Size = new System.Drawing.Size(1073, 128);
            this.dgvDetalle.TabIndex = 42;
            this.dgvDetalle.SelectionChanged += new System.EventHandler(this.dgvDetalle_SelectionChanged);
            this.dgvDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDetalle_KeyDown);
            // 
            // chId
            // 
            this.chId.DataPropertyName = "Id";
            this.chId.HeaderText = "Código";
            this.chId.Name = "chId";
            this.chId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chId.Visible = false;
            this.chId.Width = 35;
            // 
            // chItem
            // 
            this.chItem.DataPropertyName = "Item";
            this.chItem.HeaderText = "Item";
            this.chItem.Name = "chItem";
            this.chItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chItem.Width = 70;
            // 
            // chValidoDesde
            // 
            this.chValidoDesde.DataPropertyName = "ValidoDesde";
            dataGridViewCellStyle10.Format = "d";
            this.chValidoDesde.DefaultCellStyle = dataGridViewCellStyle10;
            this.chValidoDesde.HeaderText = "Desde";
            this.chValidoDesde.Mask = "00/00/0000";
            this.chValidoDesde.Name = "chValidoDesde";
            this.chValidoDesde.P_EsEditable = false;
            this.chValidoDesde.P_EsModificable = false;
            this.chValidoDesde.P_EsPrimaryKey = false;
            this.chValidoDesde.P_ExigeInformacion = false;
            this.chValidoDesde.P_NombreColumna = null;
            this.chValidoDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.chValidoDesde.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chValidoDesde.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chValidoDesde.Width = 75;
            // 
            // chValidoHasta
            // 
            this.chValidoHasta.DataPropertyName = "ValidoHasta";
            dataGridViewCellStyle11.Format = "d";
            this.chValidoHasta.DefaultCellStyle = dataGridViewCellStyle11;
            this.chValidoHasta.HeaderText = "Hasta";
            this.chValidoHasta.Mask = "00/00/0000";
            this.chValidoHasta.Name = "chValidoHasta";
            this.chValidoHasta.P_EsEditable = false;
            this.chValidoHasta.P_EsModificable = false;
            this.chValidoHasta.P_EsPrimaryKey = false;
            this.chValidoHasta.P_ExigeInformacion = false;
            this.chValidoHasta.P_NombreColumna = null;
            this.chValidoHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.chValidoHasta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chValidoHasta.Width = 75;
            // 
            // chObservacion
            // 
            this.chObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chObservacion.DataPropertyName = "Observacion";
            this.chObservacion.HeaderText = "Observación";
            this.chObservacion.MaxInputLength = 500;
            this.chObservacion.Name = "chObservacion";
            this.chObservacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chObservacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chIdEstado
            // 
            this.chIdEstado.DataPropertyName = "IdEstado";
            this.chIdEstado.HeaderText = "IdEstado";
            this.chIdEstado.Name = "chIdEstado";
            this.chIdEstado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chIdEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chIdEstado.Visible = false;
            // 
            // chEstado
            // 
            this.chEstado.DataPropertyName = "Estado";
            this.chEstado.HeaderText = "Estado";
            this.chEstado.Name = "chEstado";
            this.chEstado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chEstado.Width = 120;
            // 
            // gbTipoRefrigerio
            // 
            this.gbTipoRefrigerio.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbTipoRefrigerio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTipoRefrigerio.Controls.Add(this.chkOtro);
            this.gbTipoRefrigerio.Controls.Add(this.chkCena);
            this.gbTipoRefrigerio.Controls.Add(this.chkDesayuno);
            this.gbTipoRefrigerio.Controls.Add(this.chkAlmuerzo);
            this.gbTipoRefrigerio.Enabled = false;
            this.gbTipoRefrigerio.HeaderText = "Recibe los beneficio en refrigerios de :";
            this.gbTipoRefrigerio.Location = new System.Drawing.Point(754, 157);
            this.gbTipoRefrigerio.Name = "gbTipoRefrigerio";
            this.gbTipoRefrigerio.Size = new System.Drawing.Size(333, 57);
            this.gbTipoRefrigerio.TabIndex = 33;
            this.gbTipoRefrigerio.Text = "Recibe los beneficio en refrigerios de :";
            this.gbTipoRefrigerio.ThemeName = "Windows8";
            this.gbTipoRefrigerio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gbTipoRefrigerio_KeyDown);
            // 
            // chkOtro
            // 
            this.chkOtro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOtro.Location = new System.Drawing.Point(275, 28);
            this.chkOtro.Name = "chkOtro";
            this.chkOtro.Size = new System.Drawing.Size(46, 18);
            this.chkOtro.TabIndex = 37;
            this.chkOtro.Text = "Otro";
            this.chkOtro.ThemeName = "VisualStudio2012Light";
            this.chkOtro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkOtro_KeyDown);
            // 
            // chkCena
            // 
            this.chkCena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCena.Location = new System.Drawing.Point(201, 28);
            this.chkCena.Name = "chkCena";
            this.chkCena.Size = new System.Drawing.Size(48, 18);
            this.chkCena.TabIndex = 36;
            this.chkCena.Text = "Cena";
            this.chkCena.ThemeName = "VisualStudio2012Light";
            this.chkCena.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCena_KeyDown);
            // 
            // chkDesayuno
            // 
            this.chkDesayuno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDesayuno.Location = new System.Drawing.Point(12, 28);
            this.chkDesayuno.Name = "chkDesayuno";
            this.chkDesayuno.Size = new System.Drawing.Size(73, 18);
            this.chkDesayuno.TabIndex = 34;
            this.chkDesayuno.Text = "Desayuno";
            this.chkDesayuno.ThemeName = "VisualStudio2012Light";
            this.chkDesayuno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkDesayuno_KeyDown);
            // 
            // chkAlmuerzo
            // 
            this.chkAlmuerzo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAlmuerzo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlmuerzo.Location = new System.Drawing.Point(110, 28);
            this.chkAlmuerzo.Name = "chkAlmuerzo";
            this.chkAlmuerzo.Size = new System.Drawing.Size(71, 18);
            this.chkAlmuerzo.TabIndex = 35;
            this.chkAlmuerzo.Text = "Almuerzo";
            this.chkAlmuerzo.ThemeName = "VisualStudio2012Light";
            this.chkAlmuerzo.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.chkAlmuerzo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAlmuerzo_KeyDown);
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            this.commandBarStripElement1.Text = "";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            // 
            // bwgHilo
            // 
            this.bwgHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwgHilo_DoWork);
            this.bwgHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwgHilo_RunWorkerCompleted);
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
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 486);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1108, 22);
            this.stsBarraEstado.TabIndex = 182;
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
            this.ProgressBar.Size = new System.Drawing.Size(460, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
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
            this.btnNuevo,
            this.btnEditar,
            this.btnAnular,
            this.btnEliminar,
            this.btnGrabar,
            this.btnAtras,
            this.btnHistorial,
            this.btnExportar,
            this.btnVistaPrevia,
            this.btnImprimir,
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
            this.btnNuevo.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnNuevo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.DisplayName = "Nuevo";
            this.btnNuevo.Enabled = false;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "";
            this.btnNuevo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.ToolTipText = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AccessibleDescription = "Editar";
            this.btnEditar.AccessibleName = "Editar";
            this.btnEditar.AutoSize = false;
            this.btnEditar.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnEditar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEditar.DisplayName = "Editar";
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "";
            this.btnEditar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEditar.ToolTipText = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.AccessibleDescription = "Anular";
            this.btnAnular.AccessibleName = "Anular";
            this.btnAnular.AutoSize = false;
            this.btnAnular.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnAnular.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAnular.DisplayName = "Anular";
            this.btnAnular.Enabled = false;
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Text = "";
            this.btnAnular.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAnular.ToolTipText = "Anular";
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = false;
            this.btnEliminar.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnEliminar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEliminar.DisplayName = "Eliminar";
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "";
            this.btnEliminar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.AccessibleDescription = "Grabar";
            this.btnGrabar.AccessibleName = "Grabar";
            this.btnGrabar.AutoSize = false;
            this.btnGrabar.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnGrabar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnGrabar.DisplayName = "Grabar";
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Text = "";
            this.btnGrabar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnGrabar.ToolTipText = "Grabar Registro";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.AccessibleDescription = "Atrás";
            this.btnAtras.AccessibleName = "Atrás";
            this.btnAtras.AutoSize = false;
            this.btnAtras.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnAtras.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAtras.DisplayName = "Atrás";
            this.btnAtras.Enabled = false;
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Text = "";
            this.btnAtras.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.AutoSize = false;
            this.btnHistorial.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnHistorial.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnHistorial.DisplayName = "Historial";
            this.btnHistorial.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorial.Image")));
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Text = "";
            this.btnHistorial.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
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
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.AccessibleDescription = "Vista previa";
            this.btnVistaPrevia.AccessibleName = "Vista previa";
            this.btnVistaPrevia.AutoSize = false;
            this.btnVistaPrevia.Bounds = new System.Drawing.Rectangle(0, 0, 83, 34);
            this.btnVistaPrevia.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnVistaPrevia.DisplayName = "Vista previa";
            this.btnVistaPrevia.Enabled = false;
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
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            // barraPrincipal
            // 
            this.barraPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraPrincipal.Enabled = false;
            this.barraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.barraPrincipal.Name = "barraPrincipal";
            this.barraPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.barraPrincipal.Size = new System.Drawing.Size(1108, 36);
            this.barraPrincipal.TabIndex = 0;
            this.barraPrincipal.ThemeName = "VisualStudio2012Light";
            // 
            // ProgramacionRefrigerioxPersonalMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1108, 508);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.barraPrincipal);
            this.Controls.Add(this.gbMantenimientoRegistros);
            this.Name = "ProgramacionRefrigerioxPersonalMantenimiento";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Registro de asignación del personal para casa-pensión";
            this.ThemeName = "VisualStudio2012Light";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramacionRefrigerioxPersonalMantenimiento_FormClosing_1);
            this.Load += new System.EventHandler(this.RefrigerioxPersonalMantenimiento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProgramacionRefrigerioxPersonalMantenimiento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnAltaBaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAltaTarifa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimirTicket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMantenimientoRegistros)).EndInit();
            this.gbMantenimientoRegistros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbInformacionGeneral)).EndInit();
            this.gbInformacionGeneral.ResumeLayout(false);
            this.gbInformacionGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHospedajeDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParaderoDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdSubPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCondicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroDNI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbPension)).EndInit();
            this.gbPension.ResumeLayout(false);
            this.gbPension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoPersonalParadero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdPension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRucDNIResponsable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRucNombresResponsable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRucNombreComercial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabRegistros)).EndInit();
            this.TabRegistros.ResumeLayout(false);
            this.tabDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTipoRefrigerio)).EndInit();
            this.gbTipoRefrigerio.ResumeLayout(false);
            this.gbTipoRefrigerio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkOtro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDesayuno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlmuerzo)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private Telerik.WinControls.UI.RadGroupBox gbMantenimientoRegistros;
        private Telerik.WinControls.UI.RadPageView TabRegistros;
        private Telerik.WinControls.UI.RadPageViewPage tabDetalle;
        private Telerik.WinControls.UI.RadButton btnAltaBaja;
        private MyControlsDataBinding.Controles.MyDataGridViewDetails dgvDetalle;
        private Telerik.WinControls.UI.RadButton btnAltaTarifa;
        private Telerik.WinControls.UI.RadButton btnQuitar;
        private Telerik.WinControls.UI.RadButton btnAgregar;
        private Telerik.WinControls.UI.RadTextBox txtRucDNIResponsable;
        private Telerik.WinControls.UI.RadTextBox txtRucNombresResponsable;
        private Telerik.WinControls.UI.RadGroupBox gbTipoRefrigerio;
        private Telerik.WinControls.UI.RadCheckBox chkOtro;
        private Telerik.WinControls.UI.RadCheckBox chkCena;
        private Telerik.WinControls.UI.RadCheckBox chkDesayuno;
        private Telerik.WinControls.UI.RadCheckBox chkAlmuerzo;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtIdEstado;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtRucNombreComercial;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtCodigo;
        private Telerik.WinControls.UI.RadTextBox txtEstado;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadGroupBox gbPension;
        private Telerik.WinControls.UI.RadGroupBox gbInformacionGeneral;
        private Telerik.WinControls.UI.RadTextBox txtNroDNI;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadTextBox txtCondicion;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadTextBox txtSubPlanilla;
        private Telerik.WinControls.UI.RadTextBox txtIdSubPlanilla;
        private Telerik.WinControls.UI.RadTextBox txtIdPension;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chId;
        private System.Windows.Forms.DataGridViewTextBoxColumn chItem;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextColumn chValidoDesde;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextColumn chValidoHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn chObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chIdEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn chEstado;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.RadButton btnImprimirTicket;
        private System.ComponentModel.BackgroundWorker bwgHilo;
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
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnEditar;
        private Telerik.WinControls.UI.CommandBarButton btnAnular;
        private Telerik.WinControls.UI.CommandBarButton btnEliminar;
        private Telerik.WinControls.UI.CommandBarButton btnGrabar;
        private Telerik.WinControls.UI.CommandBarButton btnAtras;
        private Telerik.WinControls.UI.CommandBarButton btnHistorial;
        private Telerik.WinControls.UI.CommandBarButton btnExportar;
        private Telerik.WinControls.UI.CommandBarButton btnVistaPrevia;
        private Telerik.WinControls.UI.CommandBarButton btnImprimir;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.RadCommandBar barraPrincipal;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtRUCNumero;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnBuscarPension;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtRucRazonSocial;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtCodigoPersonal;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnBuscarPersonal;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtNombresCompletosTrabajador;
        private Telerik.WinControls.UI.RadTextBox txtCodigoPersonalParadero;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private Telerik.WinControls.UI.RadTextBox txtHospedajeDescripcion;
        private Telerik.WinControls.UI.RadLabel lblParaderoDescripcion;
    }
}
