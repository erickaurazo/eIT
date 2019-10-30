namespace RecursosHumanos
{
    partial class DiasEfectivosRemunerados
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiasEfectivosRemunerados));
            this.gbListadoDetalle = new System.Windows.Forms.GroupBox();
            this.dgvResultado = new MyControlsDataBinding.Controles.MyDataGridViewDetails(this.components);
            this.idCodigoGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chMaterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDiasEfectivosRemunerados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chIdUnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chIdSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chIdMaquinaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chMaquinaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chHoras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chIdEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCabecera = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPlanillaCodigo = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtPlanillaCodigo = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtTPlanillaDescripcion = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.picFiltro = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaInicio = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtFechaFinal = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtTextoBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.Planilla = new System.Windows.Forms.Label();
            this.tsbMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
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
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblresultados = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUltimoMantenimiento = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbListadoDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.gbCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFiltro)).BeginInit();
            this.tsbMenu.SuspendLayout();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbListadoDetalle
            // 
            this.gbListadoDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListadoDetalle.Controls.Add(this.dgvResultado);
            this.gbListadoDetalle.Location = new System.Drawing.Point(3, 121);
            this.gbListadoDetalle.Name = "gbListadoDetalle";
            this.gbListadoDetalle.Size = new System.Drawing.Size(1203, 292);
            this.gbListadoDetalle.TabIndex = 13;
            this.gbListadoDetalle.TabStop = false;
            this.gbListadoDetalle.Text = "Registro";
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvResultado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResultado.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvResultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvResultado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCodigoGeneral,
            this.chPaterno,
            this.chMaterno,
            this.chNombres,
            this.chDni,
            this.chDiasEfectivosRemunerados});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResultado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultado.GridColor = System.Drawing.SystemColors.Control;
            this.dgvResultado.Location = new System.Drawing.Point(3, 16);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.P_EsEditable = false;
            this.dgvResultado.P_FormatoDecimal = null;
            this.dgvResultado.P_FormatoFecha = null;
            this.dgvResultado.P_NombreColCorrelativa = null;
            this.dgvResultado.P_NombreTabla = null;
            this.dgvResultado.P_NumeroDigitos = 0;
            this.dgvResultado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultado.Size = new System.Drawing.Size(1197, 273);
            this.dgvResultado.TabIndex = 14;
            // 
            // idCodigoGeneral
            // 
            this.idCodigoGeneral.DataPropertyName = "idcodigogeneral";
            this.idCodigoGeneral.HeaderText = "Código";
            this.idCodigoGeneral.Name = "idCodigoGeneral";
            // 
            // chPaterno
            // 
            this.chPaterno.DataPropertyName = "PATERNO";
            this.chPaterno.HeaderText = "Apellido paterno";
            this.chPaterno.Name = "chPaterno";
            this.chPaterno.Width = 250;
            // 
            // chMaterno
            // 
            this.chMaterno.DataPropertyName = "MATERNO";
            this.chMaterno.HeaderText = "Apellido Materno";
            this.chMaterno.Name = "chMaterno";
            this.chMaterno.Width = 250;
            // 
            // chNombres
            // 
            this.chNombres.DataPropertyName = "Nombres";
            this.chNombres.HeaderText = "Nombres";
            this.chNombres.Name = "chNombres";
            this.chNombres.Width = 300;
            // 
            // chDni
            // 
            this.chDni.DataPropertyName = "DNI";
            this.chDni.HeaderText = "DNI";
            this.chDni.Name = "chDni";
            // 
            // chDiasEfectivosRemunerados
            // 
            this.chDiasEfectivosRemunerados.DataPropertyName = "DIAS_EFECTIVOS_REMUNERADOS";
            this.chDiasEfectivosRemunerados.HeaderText = "Días efectivos remunerados";
            this.chDiasEfectivosRemunerados.Name = "chDiasEfectivosRemunerados";
            this.chDiasEfectivosRemunerados.Width = 150;
            // 
            // chIdUnico
            // 
            this.chIdUnico.DataPropertyName = "idUnico";
            this.chIdUnico.HeaderText = "idUnico";
            this.chIdUnico.Name = "chIdUnico";
            this.chIdUnico.ReadOnly = true;
            this.chIdUnico.Visible = false;
            // 
            // chIdSucursal
            // 
            this.chIdSucursal.DataPropertyName = "idSucursal";
            this.chIdSucursal.HeaderText = "idSucursal";
            this.chIdSucursal.Name = "chIdSucursal";
            this.chIdSucursal.ReadOnly = true;
            this.chIdSucursal.Visible = false;
            // 
            // chSucursal
            // 
            this.chSucursal.DataPropertyName = "suc_dsc";
            this.chSucursal.HeaderText = "Sucursal";
            this.chSucursal.Name = "chSucursal";
            this.chSucursal.ReadOnly = true;
            this.chSucursal.Width = 180;
            // 
            // chFecha
            // 
            this.chFecha.DataPropertyName = "fecha";
            dataGridViewCellStyle3.Format = "d";
            this.chFecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.chFecha.HeaderText = "Fecha";
            this.chFecha.Name = "chFecha";
            this.chFecha.ReadOnly = true;
            this.chFecha.Width = 150;
            // 
            // chDocumento
            // 
            this.chDocumento.DataPropertyName = "documento";
            this.chDocumento.HeaderText = "Documento";
            this.chDocumento.Name = "chDocumento";
            this.chDocumento.ReadOnly = true;
            this.chDocumento.Width = 150;
            // 
            // chIdMaquinaria
            // 
            this.chIdMaquinaria.DataPropertyName = "idconsumidormaquinaria";
            this.chIdMaquinaria.HeaderText = "Cod. Maquinaria";
            this.chIdMaquinaria.Name = "chIdMaquinaria";
            this.chIdMaquinaria.ReadOnly = true;
            // 
            // chMaquinaria
            // 
            this.chMaquinaria.DataPropertyName = "maq_dsc";
            this.chMaquinaria.HeaderText = "Maquinaria";
            this.chMaquinaria.Name = "chMaquinaria";
            this.chMaquinaria.ReadOnly = true;
            this.chMaquinaria.Width = 300;
            // 
            // chHoras
            // 
            this.chHoras.DataPropertyName = "horas_trab1";
            this.chHoras.HeaderText = "Horas";
            this.chHoras.Name = "chHoras";
            this.chHoras.ReadOnly = true;
            // 
            // chEstado
            // 
            this.chEstado.DataPropertyName = "est_dsc";
            this.chEstado.HeaderText = "Estado";
            this.chEstado.Name = "chEstado";
            this.chEstado.ReadOnly = true;
            // 
            // chIdEstado
            // 
            this.chIdEstado.DataPropertyName = "idEstado";
            this.chIdEstado.HeaderText = "IdEstado";
            this.chIdEstado.Name = "chIdEstado";
            this.chIdEstado.ReadOnly = true;
            this.chIdEstado.Visible = false;
            // 
            // gbCabecera
            // 
            this.gbCabecera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCabecera.Controls.Add(this.label4);
            this.gbCabecera.Controls.Add(this.btnPlanillaCodigo);
            this.gbCabecera.Controls.Add(this.txtPlanillaCodigo);
            this.gbCabecera.Controls.Add(this.txtTPlanillaDescripcion);
            this.gbCabecera.Controls.Add(this.picFiltro);
            this.gbCabecera.Controls.Add(this.label1);
            this.gbCabecera.Controls.Add(this.txtFechaInicio);
            this.gbCabecera.Controls.Add(this.txtFechaFinal);
            this.gbCabecera.Controls.Add(this.txtTextoBusqueda);
            this.gbCabecera.Controls.Add(this.label2);
            this.gbCabecera.Controls.Add(this.btnBuscar);
            this.gbCabecera.Controls.Add(this.Planilla);
            this.gbCabecera.Location = new System.Drawing.Point(0, 34);
            this.gbCabecera.Name = "gbCabecera";
            this.gbCabecera.Size = new System.Drawing.Size(1203, 81);
            this.gbCabecera.TabIndex = 1;
            this.gbCabecera.TabStop = false;
            this.gbCabecera.Text = "Filtrado por rango de fechas";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1008, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "N° DNI :";
            // 
            // btnPlanillaCodigo
            // 
            this.btnPlanillaCodigo.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanillaCodigo.Image")));
            this.btnPlanillaCodigo.Location = new System.Drawing.Point(46, 48);
            this.btnPlanillaCodigo.Name = "btnPlanillaCodigo";
            this.btnPlanillaCodigo.P_CampoCodigo = "RTRIM(IDPLANILLA)";
            this.btnPlanillaCodigo.P_CampoDescripcion = "RTRIM(DESCRIPCION)";
            this.btnPlanillaCodigo.P_EsEditable = true;
            this.btnPlanillaCodigo.P_EsModificable = true;
            this.btnPlanillaCodigo.P_FilterByTextBox = null;
            this.btnPlanillaCodigo.P_TablaConsulta = "planilla";
            this.btnPlanillaCodigo.P_TextBoxCodigo = this.txtPlanillaCodigo;
            this.btnPlanillaCodigo.P_TextBoxDescripcion = this.txtTPlanillaDescripcion;
            this.btnPlanillaCodigo.P_TituloFormulario = "Turno";
            this.btnPlanillaCodigo.Size = new System.Drawing.Size(24, 23);
            this.btnPlanillaCodigo.TabIndex = 9;
            this.btnPlanillaCodigo.UseVisualStyleBackColor = true;
            // 
            // txtPlanillaCodigo
            // 
            this.txtPlanillaCodigo.BackColor = System.Drawing.Color.White;
            this.txtPlanillaCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtPlanillaCodigo.Location = new System.Drawing.Point(76, 50);
            this.txtPlanillaCodigo.Name = "txtPlanillaCodigo";
            this.txtPlanillaCodigo.P_BotonEnlace = this.btnPlanillaCodigo;
            this.txtPlanillaCodigo.P_BuscarSoloCodigoExacto = false;
            this.txtPlanillaCodigo.P_EsEditable = false;
            this.txtPlanillaCodigo.P_EsModificable = false;
            this.txtPlanillaCodigo.P_EsPrimaryKey = false;
            this.txtPlanillaCodigo.P_ExigeInformacion = false;
            this.txtPlanillaCodigo.P_NombreColumna = null;
            this.txtPlanillaCodigo.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtPlanillaCodigo.Size = new System.Drawing.Size(64, 20);
            this.txtPlanillaCodigo.TabIndex = 10;
            this.txtPlanillaCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTPlanillaDescripcion
            // 
            this.txtTPlanillaDescripcion.BackColor = System.Drawing.Color.White;
            this.txtTPlanillaDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtTPlanillaDescripcion.Location = new System.Drawing.Point(146, 50);
            this.txtTPlanillaDescripcion.Name = "txtTPlanillaDescripcion";
            this.txtTPlanillaDescripcion.P_BotonEnlace = null;
            this.txtTPlanillaDescripcion.P_BuscarSoloCodigoExacto = false;
            this.txtTPlanillaDescripcion.P_EsEditable = false;
            this.txtTPlanillaDescripcion.P_EsModificable = false;
            this.txtTPlanillaDescripcion.P_EsPrimaryKey = false;
            this.txtTPlanillaDescripcion.P_ExigeInformacion = false;
            this.txtTPlanillaDescripcion.P_NombreColumna = null;
            this.txtTPlanillaDescripcion.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtTPlanillaDescripcion.ReadOnly = true;
            this.txtTPlanillaDescripcion.Size = new System.Drawing.Size(347, 20);
            this.txtTPlanillaDescripcion.TabIndex = 11;
            // 
            // picFiltro
            // 
            this.picFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picFiltro.Image = ((System.Drawing.Image)(resources.GetObject("picFiltro.Image")));
            this.picFiltro.Location = new System.Drawing.Point(1174, 17);
            this.picFiltro.Name = "picFiltro";
            this.picFiltro.Size = new System.Drawing.Size(16, 16);
            this.picFiltro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFiltro.TabIndex = 96;
            this.picFiltro.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde :";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.EditingControlDataGridView = null;
            this.txtFechaInicio.EditingControlFormattedValue = "  /  /";
            this.txtFechaInicio.EditingControlRowIndex = 0;
            this.txtFechaInicio.EditingControlValueChanged = true;
            this.txtFechaInicio.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaInicio.Location = new System.Drawing.Point(76, 19);
            this.txtFechaInicio.Mask = "00/00/0000";
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.P_EsEditable = false;
            this.txtFechaInicio.P_EsModificable = false;
            this.txtFechaInicio.P_ExigeInformacion = false;
            this.txtFechaInicio.P_Hora = null;
            this.txtFechaInicio.P_NombreColumna = null;
            this.txtFechaInicio.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaInicio.Size = new System.Drawing.Size(72, 20);
            this.txtFechaInicio.TabIndex = 3;
            this.txtFechaInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaInicio.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.EditingControlDataGridView = null;
            this.txtFechaFinal.EditingControlFormattedValue = "  /  /";
            this.txtFechaFinal.EditingControlRowIndex = 0;
            this.txtFechaFinal.EditingControlValueChanged = true;
            this.txtFechaFinal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaFinal.Location = new System.Drawing.Point(211, 18);
            this.txtFechaFinal.Mask = "00/00/0000";
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.P_EsEditable = false;
            this.txtFechaFinal.P_EsModificable = false;
            this.txtFechaFinal.P_ExigeInformacion = false;
            this.txtFechaFinal.P_Hora = null;
            this.txtFechaFinal.P_NombreColumna = null;
            this.txtFechaFinal.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaFinal.Size = new System.Drawing.Size(70, 20);
            this.txtFechaFinal.TabIndex = 5;
            this.txtFechaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaFinal.ValidatingType = typeof(System.DateTime);
            // 
            // txtTextoBusqueda
            // 
            this.txtTextoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextoBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTextoBusqueda.Enabled = false;
            this.txtTextoBusqueda.Location = new System.Drawing.Point(1061, 14);
            this.txtTextoBusqueda.Name = "txtTextoBusqueda";
            this.txtTextoBusqueda.Size = new System.Drawing.Size(111, 20);
            this.txtTextoBusqueda.TabIndex = 7;
            this.txtTextoBusqueda.TextChanged += new System.EventHandler(this.txtTextoBusqueda_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasta :";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(508, 37);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 34);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Planilla
            // 
            this.Planilla.AutoSize = true;
            this.Planilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Planilla.Location = new System.Drawing.Point(3, 54);
            this.Planilla.Name = "Planilla";
            this.Planilla.Size = new System.Drawing.Size(46, 13);
            this.Planilla.TabIndex = 8;
            this.Planilla.Text = "Planilla :";
            // 
            // tsbMenu
            // 
            this.tsbMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.tsbMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsbMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.ExportarExcel,
            this.tsbSalir});
            this.tsbMenu.Location = new System.Drawing.Point(0, 0);
            this.tsbMenu.Name = "tsbMenu";
            this.tsbMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsbMenu.Size = new System.Drawing.Size(194, 31);
            this.tsbMenu.TabIndex = 97;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(129, 28);
            this.toolStripButton1.Text = "Recursos Humanos";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // ExportarExcel
            // 
            this.ExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("ExportarExcel.Image")));
            this.ExportarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportarExcel.Name = "ExportarExcel";
            this.ExportarExcel.Size = new System.Drawing.Size(28, 28);
            this.ExportarExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(28, 28);
            this.tsbSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.toolStripStatusLabel7,
            this.ProgressBar,
            this.lblresultados,
            this.lblUltimoMantenimiento});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 416);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1218, 22);
            this.stsBarraEstado.TabIndex = 95;
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
            // DiasEfectivosRemunerados
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1218, 438);
            this.Controls.Add(this.gbListadoDetalle);
            this.Controls.Add(this.gbCabecera);
            this.Controls.Add(this.tsbMenu);
            this.Controls.Add(this.stsBarraEstado);
            this.Name = "DiasEfectivosRemunerados";
            this.Text = "Días efectivos remunerados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DiasEfectivosRemunerados_Load);
            this.gbListadoDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.gbCabecera.ResumeLayout(false);
            this.gbCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFiltro)).EndInit();
            this.tsbMenu.ResumeLayout(false);
            this.tsbMenu.PerformLayout();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListadoDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn chIdUnico;
        private System.Windows.Forms.DataGridViewTextBoxColumn chIdSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn chFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn chIdMaquinaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn chMaquinaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn chHoras;
        private System.Windows.Forms.DataGridViewTextBoxColumn chEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn chIdEstado;
        private System.Windows.Forms.GroupBox gbCabecera;
        private System.Windows.Forms.PictureBox picFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTextoBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ToolStrip tsbMenu;
        private System.Windows.Forms.ToolStripButton ExportarExcel;
        private System.Windows.Forms.ToolStripButton tsbSalir;
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
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblresultados;
        private System.Windows.Forms.ToolStripStatusLabel lblUltimoMantenimiento;
        private System.Windows.Forms.Label label4;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaInicio;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaFinal;
        private System.Windows.Forms.Label Planilla;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnPlanillaCodigo;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtPlanillaCodigo;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtTPlanillaDescripcion;
        private MyControlsDataBinding.Controles.MyDataGridViewDetails dgvResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCodigoGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn chMaterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn chNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDiasEfectivosRemunerados;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

