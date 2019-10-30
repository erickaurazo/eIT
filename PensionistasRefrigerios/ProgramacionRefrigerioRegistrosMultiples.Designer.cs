namespace Transportista
{
    partial class ProgramacionRefrigerioRegistrosMultiples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramacionRefrigerioRegistrosMultiples));
            this.txtPensionCodigo = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.btnBuscarPension = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtPensionDescripcion = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtColaboradorNombres = new System.Windows.Forms.TextBox();
            this.txtColaboradoNumeroDni = new System.Windows.Forms.TextBox();
            this.lblNombresCompletos = new Telerik.WinControls.UI.RadLabel();
            this.txtParaderoDescripcion = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.btnParaderoBuscar = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtParaderoCodigo = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.lblParadero = new Telerik.WinControls.UI.RadLabel();
            this.gbTipoRefrigerio = new Telerik.WinControls.UI.RadGroupBox();
            this.chkCena = new Telerik.WinControls.UI.RadCheckBox();
            this.chkDesayuno = new Telerik.WinControls.UI.RadCheckBox();
            this.chkAlmuerzo = new Telerik.WinControls.UI.RadCheckBox();
            this.lblPlanilla = new Telerik.WinControls.UI.RadLabel();
            this.txtSubPlanilla = new System.Windows.Forms.TextBox();
            this.gbDetalle = new Telerik.WinControls.UI.RadGroupBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.dgvListado = new MyControlsDataBinding.Controles.MyDataGridViewDetails(this.components);
            this.chCodigoRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDNITrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chNombresTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chHospedajeCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chHospedajeDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPensionCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPensionDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chAlmuerzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDesayuno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chValidoDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chValidoHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chSubPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCodigoPersonalGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chcodigoSubPlanilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chIdHospedajePersonal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCabecera = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigoRegistro = new System.Windows.Forms.TextBox();
            this.txtCodigoSubPlanilla = new System.Windows.Forms.TextBox();
            this.txtCodigoPersonalGeneral = new System.Windows.Forms.TextBox();
            this.btnAgregarUnTrabajadorLista = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbValidesRefrigerio = new Telerik.WinControls.UI.RadGroupBox();
            this.txtValidoHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtValidoDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtFechaRegistro = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtRegistradoPor = new System.Windows.Forms.TextBox();
            this.lblRegistradoPor = new Telerik.WinControls.UI.RadLabel();
            this.lblFechaRegistro = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.subMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSubEdicion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSubEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSubAnularActivar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSubEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnMenuPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnRegistrar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnExportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnVistaPrevia = new Telerik.WinControls.UI.CommandBarButton();
            this.btnImprimir = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.bgwSubProceso = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombresCompletos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParadero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTipoRefrigerio)).BeginInit();
            this.gbTipoRefrigerio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDesayuno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlmuerzo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDetalle)).BeginInit();
            this.gbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbCabecera)).BeginInit();
            this.gbCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbValidesRefrigerio)).BeginInit();
            this.gbValidesRefrigerio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblRegistradoPor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            this.subMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPensionCodigo
            // 
            this.txtPensionCodigo.BackColor = System.Drawing.Color.White;
            this.txtPensionCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPensionCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtPensionCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPensionCodigo.Location = new System.Drawing.Point(464, 118);
            this.txtPensionCodigo.MaxLength = 12;
            this.txtPensionCodigo.Name = "txtPensionCodigo";
            this.txtPensionCodigo.P_BotonEnlace = this.btnBuscarPension;
            this.txtPensionCodigo.P_BuscarSoloCodigoExacto = false;
            this.txtPensionCodigo.P_EsEditable = true;
            this.txtPensionCodigo.P_EsModificable = true;
            this.txtPensionCodigo.P_EsPrimaryKey = false;
            this.txtPensionCodigo.P_ExigeInformacion = false;
            this.txtPensionCodigo.P_NombreColumna = null;
            this.txtPensionCodigo.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtPensionCodigo.Size = new System.Drawing.Size(46, 20);
            this.txtPensionCodigo.TabIndex = 18;
            this.txtPensionCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBuscarPension
            // 
            this.btnBuscarPension.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPension.Image")));
            this.btnBuscarPension.Location = new System.Drawing.Point(515, 92);
            this.btnBuscarPension.Name = "btnBuscarPension";
            this.btnBuscarPension.P_CampoCodigo = "CAST( PNS.IdPension AS varchar(4)) ";
            this.btnBuscarPension.P_CampoDescripcion = "rtrim(nroDNI), ISNULL(RTRIM(CP.RAZON_SOCIAL),\'\') + \' / \' + isnull(RTRIM(NROrUC),\'" +
    "\') + \' / \' + isnull(RTRIM(PseudoNombre),\'\')";
            this.btnBuscarPension.P_EsEditable = true;
            this.btnBuscarPension.P_EsModificable = true;
            this.btnBuscarPension.P_FilterByTextBox = null;
            this.btnBuscarPension.P_TablaConsulta = "SJ_RHPension PNS LEFT JOIN CLIEPROV CP ON PNS.NroRUC = CP.IdClieprov LEFT JOIN ES" +
    "TADOS E ON PNS.IdEstado=E.IdEstado where  PNS.IdEstado = \'AC\'";
            this.btnBuscarPension.P_TextBoxCodigo = this.txtPensionCodigo;
            this.btnBuscarPension.P_TextBoxDescripcion = this.txtPensionDescripcion;
            this.btnBuscarPension.P_TituloFormulario = "Buscar RUC";
            this.btnBuscarPension.Size = new System.Drawing.Size(39, 23);
            this.btnBuscarPension.TabIndex = 17;
            this.btnBuscarPension.UseVisualStyleBackColor = true;
            this.btnBuscarPension.Visible = false;
            // 
            // txtPensionDescripcion
            // 
            this.txtPensionDescripcion.BackColor = System.Drawing.Color.White;
            this.txtPensionDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPensionDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtPensionDescripcion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPensionDescripcion.Location = new System.Drawing.Point(516, 118);
            this.txtPensionDescripcion.Name = "txtPensionDescripcion";
            this.txtPensionDescripcion.P_BotonEnlace = null;
            this.txtPensionDescripcion.P_BuscarSoloCodigoExacto = false;
            this.txtPensionDescripcion.P_EsEditable = false;
            this.txtPensionDescripcion.P_EsModificable = false;
            this.txtPensionDescripcion.P_EsPrimaryKey = false;
            this.txtPensionDescripcion.P_ExigeInformacion = false;
            this.txtPensionDescripcion.P_NombreColumna = null;
            this.txtPensionDescripcion.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtPensionDescripcion.ReadOnly = true;
            this.txtPensionDescripcion.Size = new System.Drawing.Size(453, 20);
            this.txtPensionDescripcion.TabIndex = 19;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(459, 96);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(54, 18);
            this.radLabel3.TabIndex = 16;
            this.radLabel3.Text = "Pensión :";
            // 
            // txtColaboradorNombres
            // 
            this.txtColaboradorNombres.Location = new System.Drawing.Point(127, 64);
            this.txtColaboradorNombres.Name = "txtColaboradorNombres";
            this.txtColaboradorNombres.Size = new System.Drawing.Size(329, 23);
            this.txtColaboradorNombres.TabIndex = 9;
            // 
            // txtColaboradoNumeroDni
            // 
            this.txtColaboradoNumeroDni.Location = new System.Drawing.Point(53, 64);
            this.txtColaboradoNumeroDni.MaxLength = 8;
            this.txtColaboradoNumeroDni.Name = "txtColaboradoNumeroDni";
            this.txtColaboradoNumeroDni.Size = new System.Drawing.Size(70, 23);
            this.txtColaboradoNumeroDni.TabIndex = 8;
            this.txtColaboradoNumeroDni.TextChanged += new System.EventHandler(this.txtColaboradoNumeroDni_TextChanged);
            this.txtColaboradoNumeroDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColaboradoNumeroDni_KeyPress);
            this.txtColaboradoNumeroDni.Leave += new System.EventHandler(this.txtColaboradoNumeroDni_Leave);
            // 
            // lblNombresCompletos
            // 
            this.lblNombresCompletos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombresCompletos.Location = new System.Drawing.Point(17, 43);
            this.lblNombresCompletos.Name = "lblNombresCompletos";
            this.lblNombresCompletos.Size = new System.Drawing.Size(120, 18);
            this.lblNombresCompletos.TabIndex = 7;
            this.lblNombresCompletos.Text = "Nombres completos :";
            // 
            // txtParaderoDescripcion
            // 
            this.txtParaderoDescripcion.Location = new System.Drawing.Point(516, 64);
            this.txtParaderoDescripcion.MaxLength = 8;
            this.txtParaderoDescripcion.Name = "txtParaderoDescripcion";
            this.txtParaderoDescripcion.P_BotonEnlace = this.btnParaderoBuscar;
            this.txtParaderoDescripcion.P_BuscarSoloCodigoExacto = false;
            this.txtParaderoDescripcion.P_EsEditable = false;
            this.txtParaderoDescripcion.P_EsModificable = false;
            this.txtParaderoDescripcion.P_EsPrimaryKey = false;
            this.txtParaderoDescripcion.P_ExigeInformacion = false;
            this.txtParaderoDescripcion.P_NombreColumna = null;
            this.txtParaderoDescripcion.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtParaderoDescripcion.Size = new System.Drawing.Size(453, 23);
            this.txtParaderoDescripcion.TabIndex = 13;
            this.txtParaderoDescripcion.Text = "HOSPEDAJE - CASONA";
            // 
            // btnParaderoBuscar
            // 
            this.btnParaderoBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnParaderoBuscar.Image")));
            this.btnParaderoBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParaderoBuscar.Location = new System.Drawing.Point(600, 37);
            this.btnParaderoBuscar.Name = "btnParaderoBuscar";
            this.btnParaderoBuscar.P_CampoCodigo = "rtrim(IdParadero) ";
            this.btnParaderoBuscar.P_CampoDescripcion = "rtrim(DescripcionParadero)  ";
            this.btnParaderoBuscar.P_EsEditable = true;
            this.btnParaderoBuscar.P_EsModificable = true;
            this.btnParaderoBuscar.P_FilterByTextBox = null;
            this.btnParaderoBuscar.P_TablaConsulta = "SJ_Paraderos where estado = 1 and TIPO = \'P\'";
            this.btnParaderoBuscar.P_TextBoxCodigo = this.txtParaderoCodigo;
            this.btnParaderoBuscar.P_TextBoxDescripcion = this.txtParaderoDescripcion;
            this.btnParaderoBuscar.P_TituloFormulario = "Buscar paradero";
            this.btnParaderoBuscar.Size = new System.Drawing.Size(39, 23);
            this.btnParaderoBuscar.TabIndex = 11;
            this.btnParaderoBuscar.UseVisualStyleBackColor = true;
            this.btnParaderoBuscar.Visible = false;
            // 
            // txtParaderoCodigo
            // 
            this.txtParaderoCodigo.Location = new System.Drawing.Point(462, 64);
            this.txtParaderoCodigo.MaxLength = 8;
            this.txtParaderoCodigo.Name = "txtParaderoCodigo";
            this.txtParaderoCodigo.P_BotonEnlace = this.btnParaderoBuscar;
            this.txtParaderoCodigo.P_BuscarSoloCodigoExacto = false;
            this.txtParaderoCodigo.P_EsEditable = false;
            this.txtParaderoCodigo.P_EsModificable = false;
            this.txtParaderoCodigo.P_EsPrimaryKey = false;
            this.txtParaderoCodigo.P_ExigeInformacion = false;
            this.txtParaderoCodigo.P_NombreColumna = null;
            this.txtParaderoCodigo.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtParaderoCodigo.Size = new System.Drawing.Size(51, 23);
            this.txtParaderoCodigo.TabIndex = 12;
            this.txtParaderoCodigo.Text = "P037";
            this.txtParaderoCodigo.Leave += new System.EventHandler(this.txtParaderoCodigo_Leave);
            // 
            // lblParadero
            // 
            this.lblParadero.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParadero.Location = new System.Drawing.Point(461, 43);
            this.lblParadero.Name = "lblParadero";
            this.lblParadero.Size = new System.Drawing.Size(141, 18);
            this.lblParadero.TabIndex = 10;
            this.lblParadero.Text = "Paradero y/u Hospedaje :";
            // 
            // gbTipoRefrigerio
            // 
            this.gbTipoRefrigerio.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbTipoRefrigerio.Controls.Add(this.chkCena);
            this.gbTipoRefrigerio.Controls.Add(this.chkDesayuno);
            this.gbTipoRefrigerio.Controls.Add(this.chkAlmuerzo);
            this.gbTipoRefrigerio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipoRefrigerio.HeaderText = "Recibe los beneficio en refrigerios de :";
            this.gbTipoRefrigerio.Location = new System.Drawing.Point(464, 142);
            this.gbTipoRefrigerio.Name = "gbTipoRefrigerio";
            this.gbTipoRefrigerio.Size = new System.Drawing.Size(277, 47);
            this.gbTipoRefrigerio.TabIndex = 20;
            this.gbTipoRefrigerio.Text = "Recibe los beneficio en refrigerios de :";
            this.gbTipoRefrigerio.ThemeName = "Windows8";
            // 
            // chkCena
            // 
            this.chkCena.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCena.Location = new System.Drawing.Point(201, 24);
            this.chkCena.Name = "chkCena";
            this.chkCena.Size = new System.Drawing.Size(48, 18);
            this.chkCena.TabIndex = 23;
            this.chkCena.Text = "Cena";
            this.chkCena.ThemeName = "VisualStudio2012Light";
            this.chkCena.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // chkDesayuno
            // 
            this.chkDesayuno.Location = new System.Drawing.Point(13, 23);
            this.chkDesayuno.Name = "chkDesayuno";
            this.chkDesayuno.Size = new System.Drawing.Size(73, 18);
            this.chkDesayuno.TabIndex = 21;
            this.chkDesayuno.Text = "Desayuno";
            this.chkDesayuno.ThemeName = "VisualStudio2012Light";
            // 
            // chkAlmuerzo
            // 
            this.chkAlmuerzo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlmuerzo.Location = new System.Drawing.Point(110, 24);
            this.chkAlmuerzo.Name = "chkAlmuerzo";
            this.chkAlmuerzo.Size = new System.Drawing.Size(71, 18);
            this.chkAlmuerzo.TabIndex = 22;
            this.chkAlmuerzo.Text = "Almuerzo";
            this.chkAlmuerzo.ThemeName = "VisualStudio2012Light";
            this.chkAlmuerzo.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // lblPlanilla
            // 
            this.lblPlanilla.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanilla.Location = new System.Drawing.Point(16, 97);
            this.lblPlanilla.Name = "lblPlanilla";
            this.lblPlanilla.Size = new System.Drawing.Size(75, 18);
            this.lblPlanilla.TabIndex = 14;
            this.lblPlanilla.Text = "Sub Planilla :";
            // 
            // txtSubPlanilla
            // 
            this.txtSubPlanilla.Location = new System.Drawing.Point(22, 117);
            this.txtSubPlanilla.Name = "txtSubPlanilla";
            this.txtSubPlanilla.Size = new System.Drawing.Size(434, 23);
            this.txtSubPlanilla.TabIndex = 15;
            // 
            // gbDetalle
            // 
            this.gbDetalle.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalle.Controls.Add(this.btnQuitar);
            this.gbDetalle.Controls.Add(this.dgvListado);
            this.gbDetalle.HeaderText = "Listado de registros";
            this.gbDetalle.Location = new System.Drawing.Point(4, 234);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(1152, 202);
            this.gbDetalle.TabIndex = 3;
            this.gbDetalle.Text = "Listado de registros";
            this.gbDetalle.ThemeName = "Windows8";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.Location = new System.Drawing.Point(1110, 12);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(35, 26);
            this.btnQuitar.TabIndex = 1;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chCodigoRegistro,
            this.chDNITrabajador,
            this.chNombresTrabajador,
            this.chHospedajeCodigo,
            this.chHospedajeDescripcion,
            this.chPensionCodigo,
            this.chPensionDescripcion,
            this.chAlmuerzo,
            this.chDesayuno,
            this.chCena,
            this.chValidoDesde,
            this.chValidoHasta,
            this.chSubPlanilla,
            this.chCodigoPersonalGeneral,
            this.chcodigoSubPlanilla,
            this.chIdHospedajePersonal});
            this.dgvListado.Location = new System.Drawing.Point(2, 41);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.P_EsEditable = false;
            this.dgvListado.P_FormatoDecimal = null;
            this.dgvListado.P_FormatoFecha = null;
            this.dgvListado.P_NombreColCorrelativa = null;
            this.dgvListado.P_NombreTabla = null;
            this.dgvListado.P_NumeroDigitos = 0;
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(1148, 159);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // chCodigoRegistro
            // 
            this.chCodigoRegistro.DataPropertyName = "codigo";
            this.chCodigoRegistro.HeaderText = "CodigoRegistro";
            this.chCodigoRegistro.Name = "chCodigoRegistro";
            this.chCodigoRegistro.ReadOnly = true;
            this.chCodigoRegistro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chCodigoRegistro.Visible = false;
            // 
            // chDNITrabajador
            // 
            this.chDNITrabajador.DataPropertyName = "DNITrabajador";
            this.chDNITrabajador.HeaderText = "Dni Trabajador";
            this.chDNITrabajador.Name = "chDNITrabajador";
            this.chDNITrabajador.ReadOnly = true;
            this.chDNITrabajador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chDNITrabajador.Width = 75;
            // 
            // chNombresTrabajador
            // 
            this.chNombresTrabajador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chNombresTrabajador.DataPropertyName = "NombresTrabajador";
            this.chNombresTrabajador.HeaderText = "Nombres Trabajador";
            this.chNombresTrabajador.Name = "chNombresTrabajador";
            this.chNombresTrabajador.ReadOnly = true;
            this.chNombresTrabajador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chHospedajeCodigo
            // 
            this.chHospedajeCodigo.DataPropertyName = "HospedajeCodigo";
            this.chHospedajeCodigo.HeaderText = "HospedajeCodigo";
            this.chHospedajeCodigo.Name = "chHospedajeCodigo";
            this.chHospedajeCodigo.ReadOnly = true;
            this.chHospedajeCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chHospedajeCodigo.Visible = false;
            this.chHospedajeCodigo.Width = 70;
            // 
            // chHospedajeDescripcion
            // 
            this.chHospedajeDescripcion.DataPropertyName = "HospedajeDescripcion";
            this.chHospedajeDescripcion.HeaderText = "Hospedaje descripción";
            this.chHospedajeDescripcion.Name = "chHospedajeDescripcion";
            this.chHospedajeDescripcion.ReadOnly = true;
            this.chHospedajeDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chHospedajeDescripcion.Width = 200;
            // 
            // chPensionCodigo
            // 
            this.chPensionCodigo.DataPropertyName = "PensionCodigo";
            this.chPensionCodigo.HeaderText = "Pension Código";
            this.chPensionCodigo.Name = "chPensionCodigo";
            this.chPensionCodigo.ReadOnly = true;
            this.chPensionCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chPensionCodigo.Visible = false;
            this.chPensionCodigo.Width = 70;
            // 
            // chPensionDescripcion
            // 
            this.chPensionDescripcion.DataPropertyName = "PensionDescripcion";
            this.chPensionDescripcion.HeaderText = "Pensión descripción";
            this.chPensionDescripcion.Name = "chPensionDescripcion";
            this.chPensionDescripcion.ReadOnly = true;
            this.chPensionDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chPensionDescripcion.Width = 200;
            // 
            // chAlmuerzo
            // 
            this.chAlmuerzo.DataPropertyName = "Almuerzo";
            this.chAlmuerzo.HeaderText = "Almuerzo";
            this.chAlmuerzo.Name = "chAlmuerzo";
            this.chAlmuerzo.ReadOnly = true;
            this.chAlmuerzo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chAlmuerzo.Width = 55;
            // 
            // chDesayuno
            // 
            this.chDesayuno.DataPropertyName = "Desayuno";
            this.chDesayuno.HeaderText = "Desayuno";
            this.chDesayuno.Name = "chDesayuno";
            this.chDesayuno.ReadOnly = true;
            this.chDesayuno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chDesayuno.Width = 55;
            // 
            // chCena
            // 
            this.chCena.DataPropertyName = "Cena";
            this.chCena.HeaderText = "Cena";
            this.chCena.Name = "chCena";
            this.chCena.ReadOnly = true;
            this.chCena.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chCena.Width = 55;
            // 
            // chValidoDesde
            // 
            this.chValidoDesde.DataPropertyName = "ValidoDesde";
            this.chValidoDesde.HeaderText = "Valido desde";
            this.chValidoDesde.Name = "chValidoDesde";
            this.chValidoDesde.ReadOnly = true;
            this.chValidoDesde.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chValidoDesde.Width = 75;
            // 
            // chValidoHasta
            // 
            this.chValidoHasta.DataPropertyName = "ValidoHasta";
            this.chValidoHasta.HeaderText = "Valido hasta";
            this.chValidoHasta.Name = "chValidoHasta";
            this.chValidoHasta.ReadOnly = true;
            this.chValidoHasta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chValidoHasta.Width = 75;
            // 
            // chSubPlanilla
            // 
            this.chSubPlanilla.DataPropertyName = "SubPlanilla";
            this.chSubPlanilla.HeaderText = "SubPlanilla";
            this.chSubPlanilla.Name = "chSubPlanilla";
            this.chSubPlanilla.ReadOnly = true;
            this.chSubPlanilla.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chCodigoPersonalGeneral
            // 
            this.chCodigoPersonalGeneral.DataPropertyName = "codigoPersonalGeneral";
            this.chCodigoPersonalGeneral.HeaderText = "codigoPersonalGeneral";
            this.chCodigoPersonalGeneral.Name = "chCodigoPersonalGeneral";
            this.chCodigoPersonalGeneral.ReadOnly = true;
            this.chCodigoPersonalGeneral.Visible = false;
            // 
            // chcodigoSubPlanilla
            // 
            this.chcodigoSubPlanilla.DataPropertyName = "codigoSubPlanilla";
            this.chcodigoSubPlanilla.HeaderText = "codigoSubPlanilla";
            this.chcodigoSubPlanilla.Name = "chcodigoSubPlanilla";
            this.chcodigoSubPlanilla.ReadOnly = true;
            this.chcodigoSubPlanilla.Visible = false;
            // 
            // chIdHospedajePersonal
            // 
            this.chIdHospedajePersonal.DataPropertyName = "IdHospedajePersonal";
            this.chIdHospedajePersonal.HeaderText = "IdHospedajePersonal";
            this.chIdHospedajePersonal.Name = "chIdHospedajePersonal";
            this.chIdHospedajePersonal.ReadOnly = true;
            this.chIdHospedajePersonal.Visible = false;
            // 
            // gbCabecera
            // 
            this.gbCabecera.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbCabecera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCabecera.Controls.Add(this.radLabel2);
            this.gbCabecera.Controls.Add(this.txtCodigoRegistro);
            this.gbCabecera.Controls.Add(this.txtCodigoSubPlanilla);
            this.gbCabecera.Controls.Add(this.txtCodigoPersonalGeneral);
            this.gbCabecera.Controls.Add(this.btnAgregarUnTrabajadorLista);
            this.gbCabecera.Controls.Add(this.btnAgregar);
            this.gbCabecera.Controls.Add(this.gbValidesRefrigerio);
            this.gbCabecera.Controls.Add(this.txtFechaRegistro);
            this.gbCabecera.Controls.Add(this.txtRegistradoPor);
            this.gbCabecera.Controls.Add(this.lblRegistradoPor);
            this.gbCabecera.Controls.Add(this.lblFechaRegistro);
            this.gbCabecera.Controls.Add(this.lblNombresCompletos);
            this.gbCabecera.Controls.Add(this.btnBuscarPension);
            this.gbCabecera.Controls.Add(this.txtSubPlanilla);
            this.gbCabecera.Controls.Add(this.txtPensionDescripcion);
            this.gbCabecera.Controls.Add(this.lblPlanilla);
            this.gbCabecera.Controls.Add(this.txtPensionCodigo);
            this.gbCabecera.Controls.Add(this.gbTipoRefrigerio);
            this.gbCabecera.Controls.Add(this.radLabel3);
            this.gbCabecera.Controls.Add(this.txtParaderoDescripcion);
            this.gbCabecera.Controls.Add(this.txtColaboradorNombres);
            this.gbCabecera.Controls.Add(this.txtParaderoCodigo);
            this.gbCabecera.Controls.Add(this.txtColaboradoNumeroDni);
            this.gbCabecera.Controls.Add(this.btnParaderoBuscar);
            this.gbCabecera.Controls.Add(this.lblParadero);
            this.gbCabecera.Controls.Add(this.radLabel1);
            this.gbCabecera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCabecera.HeaderText = "Datos del colaborador";
            this.gbCabecera.Location = new System.Drawing.Point(2, 39);
            this.gbCabecera.Name = "gbCabecera";
            this.gbCabecera.Size = new System.Drawing.Size(1157, 194);
            this.gbCabecera.TabIndex = 2;
            this.gbCabecera.Text = "Datos del colaborador";
            this.gbCabecera.ThemeName = "Windows8";
            this.gbCabecera.Click += new System.EventHandler(this.gbCabecera_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.Location = new System.Drawing.Point(983, 141);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(89, 18);
            this.radLabel2.TabIndex = 214;
            this.radLabel2.Text = "CodigoRegistro :";
            this.radLabel2.Visible = false;
            // 
            // txtCodigoRegistro
            // 
            this.txtCodigoRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoRegistro.Location = new System.Drawing.Point(983, 163);
            this.txtCodigoRegistro.MaxLength = 50;
            this.txtCodigoRegistro.Name = "txtCodigoRegistro";
            this.txtCodigoRegistro.Size = new System.Drawing.Size(169, 23);
            this.txtCodigoRegistro.TabIndex = 213;
            this.txtCodigoRegistro.Visible = false;
            // 
            // txtCodigoSubPlanilla
            // 
            this.txtCodigoSubPlanilla.Location = new System.Drawing.Point(159, 158);
            this.txtCodigoSubPlanilla.Name = "txtCodigoSubPlanilla";
            this.txtCodigoSubPlanilla.Size = new System.Drawing.Size(33, 23);
            this.txtCodigoSubPlanilla.TabIndex = 212;
            this.txtCodigoSubPlanilla.Visible = false;
            // 
            // txtCodigoPersonalGeneral
            // 
            this.txtCodigoPersonalGeneral.Location = new System.Drawing.Point(287, 22);
            this.txtCodigoPersonalGeneral.MaxLength = 8;
            this.txtCodigoPersonalGeneral.Name = "txtCodigoPersonalGeneral";
            this.txtCodigoPersonalGeneral.Size = new System.Drawing.Size(169, 23);
            this.txtCodigoPersonalGeneral.TabIndex = 212;
            this.txtCodigoPersonalGeneral.Visible = false;
            // 
            // btnAgregarUnTrabajadorLista
            // 
            this.btnAgregarUnTrabajadorLista.Location = new System.Drawing.Point(325, 152);
            this.btnAgregarUnTrabajadorLista.Name = "btnAgregarUnTrabajadorLista";
            this.btnAgregarUnTrabajadorLista.Size = new System.Drawing.Size(131, 32);
            this.btnAgregarUnTrabajadorLista.TabIndex = 26;
            this.btnAgregarUnTrabajadorLista.Text = "Agregar a lista ";
            this.btnAgregarUnTrabajadorLista.UseVisualStyleBackColor = true;
            this.btnAgregarUnTrabajadorLista.Click += new System.EventHandler(this.btnAgregarUnTrabajadorLista_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(22, 152);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(131, 32);
            this.btnAgregar.TabIndex = 25;
            this.btnAgregar.Text = "Agregar a lista ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbValidesRefrigerio
            // 
            this.gbValidesRefrigerio.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbValidesRefrigerio.Controls.Add(this.txtValidoHasta);
            this.gbValidesRefrigerio.Controls.Add(this.txtValidoDesde);
            this.gbValidesRefrigerio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbValidesRefrigerio.HeaderText = "Validez de refrigerios";
            this.gbValidesRefrigerio.Location = new System.Drawing.Point(747, 142);
            this.gbValidesRefrigerio.Name = "gbValidesRefrigerio";
            this.gbValidesRefrigerio.Size = new System.Drawing.Size(222, 47);
            this.gbValidesRefrigerio.TabIndex = 24;
            this.gbValidesRefrigerio.Text = "Validez de refrigerios";
            this.gbValidesRefrigerio.ThemeName = "Windows8";
            // 
            // txtValidoHasta
            // 
            this.txtValidoHasta.EditingControlDataGridView = null;
            this.txtValidoHasta.EditingControlFormattedValue = "  /  /";
            this.txtValidoHasta.EditingControlRowIndex = 0;
            this.txtValidoHasta.EditingControlValueChanged = true;
            this.txtValidoHasta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtValidoHasta.Location = new System.Drawing.Point(116, 21);
            this.txtValidoHasta.Mask = "00/00/0000";
            this.txtValidoHasta.Name = "txtValidoHasta";
            this.txtValidoHasta.P_EsEditable = false;
            this.txtValidoHasta.P_EsModificable = false;
            this.txtValidoHasta.P_ExigeInformacion = false;
            this.txtValidoHasta.P_Hora = null;
            this.txtValidoHasta.P_NombreColumna = null;
            this.txtValidoHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtValidoHasta.Size = new System.Drawing.Size(89, 23);
            this.txtValidoHasta.TabIndex = 26;
            this.txtValidoHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValidoHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtValidoDesde
            // 
            this.txtValidoDesde.EditingControlDataGridView = null;
            this.txtValidoDesde.EditingControlFormattedValue = "  /  /";
            this.txtValidoDesde.EditingControlRowIndex = 0;
            this.txtValidoDesde.EditingControlValueChanged = true;
            this.txtValidoDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtValidoDesde.Location = new System.Drawing.Point(16, 22);
            this.txtValidoDesde.Mask = "00/00/0000";
            this.txtValidoDesde.Name = "txtValidoDesde";
            this.txtValidoDesde.P_EsEditable = false;
            this.txtValidoDesde.P_EsModificable = false;
            this.txtValidoDesde.P_ExigeInformacion = false;
            this.txtValidoDesde.P_Hora = null;
            this.txtValidoDesde.P_NombreColumna = null;
            this.txtValidoDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtValidoDesde.Size = new System.Drawing.Size(89, 23);
            this.txtValidoDesde.TabIndex = 25;
            this.txtValidoDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValidoDesde.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFechaRegistro.EditingControlDataGridView = null;
            this.txtFechaRegistro.EditingControlFormattedValue = "  /  /";
            this.txtFechaRegistro.EditingControlRowIndex = 0;
            this.txtFechaRegistro.EditingControlValueChanged = true;
            this.txtFechaRegistro.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaRegistro.Location = new System.Drawing.Point(1058, 21);
            this.txtFechaRegistro.Mask = "00/00/0000";
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.P_EsEditable = false;
            this.txtFechaRegistro.P_EsModificable = false;
            this.txtFechaRegistro.P_ExigeInformacion = false;
            this.txtFechaRegistro.P_Hora = null;
            this.txtFechaRegistro.P_NombreColumna = null;
            this.txtFechaRegistro.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaRegistro.Size = new System.Drawing.Size(89, 23);
            this.txtFechaRegistro.TabIndex = 6;
            this.txtFechaRegistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaRegistro.ValidatingType = typeof(System.DateTime);
            // 
            // txtRegistradoPor
            // 
            this.txtRegistradoPor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRegistradoPor.Location = new System.Drawing.Point(113, 22);
            this.txtRegistradoPor.MaxLength = 10;
            this.txtRegistradoPor.Name = "txtRegistradoPor";
            this.txtRegistradoPor.Size = new System.Drawing.Size(167, 23);
            this.txtRegistradoPor.TabIndex = 4;
            // 
            // lblRegistradoPor
            // 
            this.lblRegistradoPor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistradoPor.Location = new System.Drawing.Point(18, 21);
            this.lblRegistradoPor.Name = "lblRegistradoPor";
            this.lblRegistradoPor.Size = new System.Drawing.Size(92, 18);
            this.lblRegistradoPor.TabIndex = 3;
            this.lblRegistradoPor.Text = "Registrado por :";
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaRegistro.Location = new System.Drawing.Point(970, 22);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(82, 18);
            this.lblFechaRegistro.TabIndex = 5;
            this.lblFechaRegistro.Text = "Fecha registro :";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(16, 85);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(105, 15);
            this.radLabel1.TabIndex = 27;
            this.radLabel1.Text = "* Solo por número DNI";
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
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 439);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1164, 22);
            this.stsBarraEstado.TabIndex = 211;
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
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // subMenu
            // 
            this.subMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSubEdicion});
            this.subMenu.Name = "subMenu";
            this.subMenu.Size = new System.Drawing.Size(114, 26);
            // 
            // btnSubEdicion
            // 
            this.btnSubEdicion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSubEditar,
            this.btnSubAnularActivar,
            this.btnSubEliminar});
            this.btnSubEdicion.Name = "btnSubEdicion";
            this.btnSubEdicion.Size = new System.Drawing.Size(113, 22);
            this.btnSubEdicion.Text = "Edición";
            // 
            // btnSubEditar
            // 
            this.btnSubEditar.AutoSize = false;
            this.btnSubEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnSubEditar.Image")));
            this.btnSubEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSubEditar.Name = "btnSubEditar";
            this.btnSubEditar.Size = new System.Drawing.Size(168, 28);
            this.btnSubEditar.Text = "Editar";
            // 
            // btnSubAnularActivar
            // 
            this.btnSubAnularActivar.AutoSize = false;
            this.btnSubAnularActivar.Image = ((System.Drawing.Image)(resources.GetObject("btnSubAnularActivar.Image")));
            this.btnSubAnularActivar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSubAnularActivar.Name = "btnSubAnularActivar";
            this.btnSubAnularActivar.Size = new System.Drawing.Size(168, 28);
            this.btnSubAnularActivar.Text = "Anular y/o activar";
            // 
            // btnSubEliminar
            // 
            this.btnSubEliminar.AutoSize = false;
            this.btnSubEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnSubEliminar.Image")));
            this.btnSubEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSubEliminar.Name = "btnSubEliminar";
            this.btnSubEliminar.Size = new System.Drawing.Size(168, 28);
            this.btnSubEliminar.Text = "Eliminar";
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.btnMenuPrincipal.Size = new System.Drawing.Size(1164, 37);
            this.btnMenuPrincipal.TabIndex = 1;
            this.btnMenuPrincipal.ThemeName = "VisualStudio2012Light";
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
            this.btnRegistrar,
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
            this.btnNuevo.Bounds = new System.Drawing.Rectangle(0, 0, 100, 35);
            this.btnNuevo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.DisplayName = "Nuevo";
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "";
            this.btnNuevo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.ToolTipText = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.AccessibleDescription = "Registrar";
            this.btnRegistrar.AccessibleName = "Registrar";
            this.btnRegistrar.AutoSize = false;
            this.btnRegistrar.Bounds = new System.Drawing.Rectangle(0, 0, 75, 35);
            this.btnRegistrar.DisplayName = "Registrar";
            this.btnRegistrar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrar.Image")));
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.AccessibleDescription = "Exportar";
            this.btnExportar.AccessibleName = "Exportar";
            this.btnExportar.AutoSize = false;
            this.btnExportar.Bounds = new System.Drawing.Rectangle(0, 0, 100, 35);
            this.btnExportar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnExportar.DisplayName = "Exportar";
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Text = "";
            this.btnExportar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnExportar.ToolTipText = "Exportar";
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.AutoSize = false;
            this.btnVistaPrevia.Bounds = new System.Drawing.Rectangle(0, 0, 85, 35);
            this.btnVistaPrevia.DisplayName = "Vista previa";
            this.btnVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("btnVistaPrevia.Image")));
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Text = "";
            this.btnVistaPrevia.ToolTipText = "Vista Previa";
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.AutoSize = false;
            this.btnImprimir.Bounds = new System.Drawing.Rectangle(0, 0, 85, 35);
            this.btnImprimir.DisplayName = "Imprimir";
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Text = "";
            this.btnImprimir.ToolTipText = "Imprimir";
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleDescription = "Salir";
            this.btnSalir.AccessibleName = "Salir";
            this.btnSalir.AutoSize = false;
            this.btnSalir.Bounds = new System.Drawing.Rectangle(0, 0, 100, 35);
            this.btnSalir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.DisplayName = "Salir";
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "";
            this.btnSalir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.ToolTipText = "Salir";
            // 
            // bgwSubProceso
            // 
            this.bgwSubProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSubProceso_DoWork);
            this.bgwSubProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSubProceso_RunWorkerCompleted);
            // 
            // ProgramacionRefrigerioRegistrosMultiples
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1164, 461);
            this.Controls.Add(this.btnMenuPrincipal);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.gbCabecera);
            this.Controls.Add(this.gbDetalle);
            this.Name = "ProgramacionRefrigerioRegistrosMultiples";
            this.Text = "Registros múltiples para la programación de refrigerio ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProgramacionRefrigerioRegistrosMultiples_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombresCompletos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblParadero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTipoRefrigerio)).EndInit();
            this.gbTipoRefrigerio.ResumeLayout(false);
            this.gbTipoRefrigerio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDesayuno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlmuerzo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDetalle)).EndInit();
            this.gbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbCabecera)).EndInit();
            this.gbCabecera.ResumeLayout(false);
            this.gbCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbValidesRefrigerio)).EndInit();
            this.gbValidesRefrigerio.ResumeLayout(false);
            this.gbValidesRefrigerio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblRegistradoPor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFechaRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.subMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMenuPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtPensionCodigo;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnBuscarPension;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtPensionDescripcion;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.TextBox txtColaboradorNombres;
        private System.Windows.Forms.TextBox txtColaboradoNumeroDni;
        private Telerik.WinControls.UI.RadLabel lblNombresCompletos;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtParaderoDescripcion;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnParaderoBuscar;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtParaderoCodigo;
        private Telerik.WinControls.UI.RadLabel lblParadero;
        private Telerik.WinControls.UI.RadGroupBox gbTipoRefrigerio;
        private Telerik.WinControls.UI.RadCheckBox chkCena;
        private Telerik.WinControls.UI.RadCheckBox chkDesayuno;
        private Telerik.WinControls.UI.RadCheckBox chkAlmuerzo;
        private Telerik.WinControls.UI.RadLabel lblPlanilla;
        private System.Windows.Forms.TextBox txtSubPlanilla;
        private Telerik.WinControls.UI.RadGroupBox gbDetalle;
        private Telerik.WinControls.UI.RadGroupBox gbCabecera;
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
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private System.ComponentModel.BackgroundWorker bgwHilo;
        private System.Windows.Forms.ToolTip toolTip;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.ContextMenuStrip subMenu;
        private System.Windows.Forms.ToolStripMenuItem btnSubEdicion;
        private System.Windows.Forms.ToolStripMenuItem btnSubEditar;
        private System.Windows.Forms.ToolStripMenuItem btnSubAnularActivar;
        private System.Windows.Forms.ToolStripMenuItem btnSubEliminar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Telerik.WinControls.UI.RadLabel lblFechaRegistro;
        private Telerik.WinControls.UI.RadLabel lblRegistradoPor;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaRegistro;
        private System.Windows.Forms.TextBox txtRegistradoPor;
        private Telerik.WinControls.UI.RadGroupBox gbValidesRefrigerio;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtValidoHasta;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtValidoDesde;
        private Telerik.WinControls.UI.RadCommandBar btnMenuPrincipal;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnExportar;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.CommandBarButton btnVistaPrevia;
        private Telerik.WinControls.UI.CommandBarButton btnImprimir;
        private MyControlsDataBinding.Controles.MyDataGridViewDetails dgvListado;
        private Telerik.WinControls.UI.CommandBarButton btnRegistrar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAgregarUnTrabajadorLista;
        private System.Windows.Forms.Button btnQuitar;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.TextBox txtCodigoPersonalGeneral;
        private System.Windows.Forms.TextBox txtCodigoSubPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCodigoRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDNITrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn chNombresTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn chHospedajeCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chHospedajeDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPensionCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPensionDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chAlmuerzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDesayuno;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCena;
        private System.Windows.Forms.DataGridViewTextBoxColumn chValidoDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn chValidoHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSubPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCodigoPersonalGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn chcodigoSubPlanilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn chIdHospedajePersonal;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.TextBox txtCodigoRegistro;
        private System.ComponentModel.BackgroundWorker bgwSubProceso;
    }
}