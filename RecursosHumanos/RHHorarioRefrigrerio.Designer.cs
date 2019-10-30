namespace RecursosHumanos
{
    partial class RHHorarioRefrigrerio
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RHHorarioRefrigrerio));
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
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
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroFilas = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gbEdicion = new Telerik.WinControls.UI.RadGroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMinutosSalida = new Telerik.WinControls.UI.RadSpinEditor();
            this.txtHoraSalida = new Telerik.WinControls.UI.RadSpinEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinutosEntrada = new Telerik.WinControls.UI.RadSpinEditor();
            this.txtHoraIngreso = new Telerik.WinControls.UI.RadSpinEditor();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblHoraSalida = new System.Windows.Forms.Label();
            this.lblHoraIngreso = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.gbListado = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvListado = new Telerik.WinControls.UI.RadGridView();
            this.gbConsulta = new Telerik.WinControls.UI.RadGroupBox();
            this.txtAño = new Telerik.WinControls.UI.RadSpinEditor();
            this.btnConsultar = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tsbMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnAtras = new System.Windows.Forms.ToolStripButton();
            this.btnHistorial = new System.Windows.Forms.ToolStripButton();
            this.btnAnular = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.stsBarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbEdicion)).BeginInit();
            this.gbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutosSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutosEntrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraIngreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbListado)).BeginInit();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).BeginInit();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            this.tsbMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.progressBar,
            this.lblNumeroFilas});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 558);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(1220, 22);
            this.stsBarraEstado.TabIndex = 195;
            this.stsBarraEstado.Text = "statusStrip1";
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
            this.lblPromedio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblRecuento.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblSumaSeleccionada.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // progressBar
            // 
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // lblNumeroFilas
            // 
            this.lblNumeroFilas.Name = "lblNumeroFilas";
            this.lblNumeroFilas.Size = new System.Drawing.Size(145, 17);
            this.lblNumeroFilas.Text = "Se encontraron # registros";
            // 
            // gbEdicion
            // 
            this.gbEdicion.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbEdicion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEdicion.Controls.Add(this.label7);
            this.gbEdicion.Controls.Add(this.txtMinutosSalida);
            this.gbEdicion.Controls.Add(this.txtHoraSalida);
            this.gbEdicion.Controls.Add(this.label6);
            this.gbEdicion.Controls.Add(this.txtMinutosEntrada);
            this.gbEdicion.Controls.Add(this.txtHoraIngreso);
            this.gbEdicion.Controls.Add(this.txtDescripcion);
            this.gbEdicion.Controls.Add(this.txtCodigo);
            this.gbEdicion.Controls.Add(this.lblHoraSalida);
            this.gbEdicion.Controls.Add(this.lblHoraIngreso);
            this.gbEdicion.Controls.Add(this.lblDescripcion);
            this.gbEdicion.Controls.Add(this.lblCodigo);
            this.gbEdicion.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbEdicion.HeaderText = "Edición";
            this.gbEdicion.Location = new System.Drawing.Point(662, 114);
            this.gbEdicion.Name = "gbEdicion";
            this.gbEdicion.Size = new System.Drawing.Size(546, 433);
            this.gbEdicion.TabIndex = 198;
            this.gbEdicion.Text = "Edición";
            this.gbEdicion.ThemeName = "Windows8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 193;
            this.label7.Text = " :  ";
            // 
            // txtMinutosSalida
            // 
            this.txtMinutosSalida.Location = new System.Drawing.Point(94, 228);
            this.txtMinutosSalida.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtMinutosSalida.Name = "txtMinutosSalida";
            // 
            // 
            // 
            this.txtMinutosSalida.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtMinutosSalida.Size = new System.Drawing.Size(46, 20);
            this.txtMinutosSalida.TabIndex = 192;
            this.txtMinutosSalida.TabStop = false;
            this.txtMinutosSalida.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinutosSalida.ThemeName = "Windows8";
            this.txtMinutosSalida.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txtHoraSalida
            // 
            this.txtHoraSalida.Location = new System.Drawing.Point(22, 228);
            this.txtHoraSalida.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.txtHoraSalida.Name = "txtHoraSalida";
            // 
            // 
            // 
            this.txtHoraSalida.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtHoraSalida.Size = new System.Drawing.Size(46, 20);
            this.txtHoraSalida.TabIndex = 191;
            this.txtHoraSalida.TabStop = false;
            this.txtHoraSalida.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraSalida.ThemeName = "Windows8";
            this.txtHoraSalida.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 190;
            this.label6.Text = " :  ";
            // 
            // txtMinutosEntrada
            // 
            this.txtMinutosEntrada.Location = new System.Drawing.Point(94, 168);
            this.txtMinutosEntrada.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtMinutosEntrada.Name = "txtMinutosEntrada";
            // 
            // 
            // 
            this.txtMinutosEntrada.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtMinutosEntrada.Size = new System.Drawing.Size(46, 20);
            this.txtMinutosEntrada.TabIndex = 189;
            this.txtMinutosEntrada.TabStop = false;
            this.txtMinutosEntrada.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinutosEntrada.ThemeName = "Windows8";
            this.txtMinutosEntrada.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txtHoraIngreso
            // 
            this.txtHoraIngreso.Location = new System.Drawing.Point(22, 168);
            this.txtHoraIngreso.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.txtHoraIngreso.Name = "txtHoraIngreso";
            // 
            // 
            // 
            this.txtHoraIngreso.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtHoraIngreso.Size = new System.Drawing.Size(46, 20);
            this.txtHoraIngreso.TabIndex = 188;
            this.txtHoraIngreso.TabStop = false;
            this.txtHoraIngreso.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraIngreso.ThemeName = "Windows8";
            this.txtHoraIngreso.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(22, 99);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(370, 20);
            this.txtDescripcion.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(22, 48);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(92, 20);
            this.txtCodigo.TabIndex = 4;
            // 
            // lblHoraSalida
            // 
            this.lblHoraSalida.AutoSize = true;
            this.lblHoraSalida.Location = new System.Drawing.Point(19, 211);
            this.lblHoraSalida.Name = "lblHoraSalida";
            this.lblHoraSalida.Size = new System.Drawing.Size(69, 13);
            this.lblHoraSalida.TabIndex = 3;
            this.lblHoraSalida.Text = "Hora Salida.";
            // 
            // lblHoraIngreso
            // 
            this.lblHoraIngreso.AutoSize = true;
            this.lblHoraIngreso.Location = new System.Drawing.Point(19, 152);
            this.lblHoraIngreso.Name = "lblHoraIngreso";
            this.lblHoraIngreso.Size = new System.Drawing.Size(77, 13);
            this.lblHoraIngreso.TabIndex = 2;
            this.lblHoraIngreso.Text = "Hora Ingreso.";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(19, 83);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(70, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción.";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(19, 28);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(48, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código.";
            // 
            // gbListado
            // 
            this.gbListado.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbListado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbListado.Controls.Add(this.dgvListado);
            this.gbListado.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbListado.HeaderText = "Registros";
            this.gbListado.Location = new System.Drawing.Point(12, 114);
            this.gbListado.Name = "gbListado";
            this.gbListado.Size = new System.Drawing.Size(644, 433);
            this.gbListado.TabIndex = 200;
            this.gbListado.Text = "Registros";
            this.gbListado.ThemeName = "Windows8";
            // 
            // dgvListado
            // 
            this.dgvListado.BackColor = System.Drawing.SystemColors.Control;
            this.dgvListado.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvListado.ForeColor = System.Drawing.Color.Black;
            this.dgvListado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvListado.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvListado
            // 
            this.dgvListado.MasterTemplate.AllowAddNewRow = false;
            this.dgvListado.MasterTemplate.AutoGenerateColumns = false;
            this.dgvListado.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "IdHorario";
            gridViewTextBoxColumn7.HeaderText = "Código";
            gridViewTextBoxColumn7.Name = "chIdHorario";
            gridViewTextBoxColumn7.Width = 144;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Descripcion";
            gridViewTextBoxColumn8.HeaderText = "Descripción";
            gridViewTextBoxColumn8.Name = "chDescripcion";
            gridViewTextBoxColumn8.Width = 477;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "REFHDESDE";
            gridViewTextBoxColumn9.HeaderText = "Desde (Hora)";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "chREFHDESDE";
            gridViewTextBoxColumn9.Width = 200;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "REFMDESDE";
            gridViewTextBoxColumn10.HeaderText = "Desde (Minuto)";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "chREFMDESDE";
            gridViewTextBoxColumn10.Width = 160;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "REFHHASTA";
            gridViewTextBoxColumn11.HeaderText = "Hasta (Hora)";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "chREFHHASTA";
            gridViewTextBoxColumn11.Width = 133;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "REFMHASTA";
            gridViewTextBoxColumn12.HeaderText = "Hasta (minuto)";
            gridViewTextBoxColumn12.IsVisible = false;
            gridViewTextBoxColumn12.Name = "chREFMHASTA";
            gridViewTextBoxColumn12.Width = 116;
            this.dgvListado.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.dgvListado.MasterTemplate.EnableFiltering = true;
            this.dgvListado.MasterTemplate.MultiSelect = true;
            this.dgvListado.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvListado.Size = new System.Drawing.Size(640, 413);
            this.dgvListado.TabIndex = 0;
            this.dgvListado.ThemeName = "Windows8";
            this.dgvListado.SelectionChanged += new System.EventHandler(this.dgvListado_SelectionChanged);
            // 
            // gbConsulta
            // 
            this.gbConsulta.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsulta.Controls.Add(this.txtAño);
            this.gbConsulta.Controls.Add(this.btnConsultar);
            this.gbConsulta.Controls.Add(this.label1);
            this.gbConsulta.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbConsulta.HeaderText = "Configuracion del Filtro";
            this.gbConsulta.Location = new System.Drawing.Point(12, 50);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(1196, 58);
            this.gbConsulta.TabIndex = 199;
            this.gbConsulta.Text = "Configuracion del Filtro";
            this.gbConsulta.ThemeName = "Windows8";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(40, 29);
            this.txtAño.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.txtAño.Minimum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.txtAño.Name = "txtAño";
            // 
            // 
            // 
            this.txtAño.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtAño.Size = new System.Drawing.Size(46, 20);
            this.txtAño.TabIndex = 187;
            this.txtAño.TabStop = false;
            this.txtAño.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAño.ThemeName = "Windows8";
            this.txtAño.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(92, 23);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 29);
            this.btnConsultar.TabIndex = 178;
            this.btnConsultar.Text = "&Consultar ";
            this.btnConsultar.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.ThemeName = "Windows8";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 184;
            this.label1.Text = "Año :";
            // 
            // tsbMenu
            // 
            this.tsbMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsbMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btnNuevo,
            this.btnEditar,
            this.btnGuardar,
            this.btnAtras,
            this.btnHistorial,
            this.btnAnular,
            this.btnEliminar,
            this.btnExportar,
            this.btnSalir});
            this.tsbMenu.Location = new System.Drawing.Point(0, 0);
            this.tsbMenu.Name = "tsbMenu";
            this.tsbMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsbMenu.Size = new System.Drawing.Size(1220, 38);
            this.tsbMenu.TabIndex = 201;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(110, 35);
            this.toolStripButton1.Text = "         RR.HH.      ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnNuevo
            // 
            this.btnNuevo.AutoSize = false;
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(115, 35);
            this.btnNuevo.Text = "Nuevo";
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = false;
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(115, 35);
            this.btnEditar.Text = "Editar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = false;
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(115, 35);
            this.btnGuardar.Text = "Guardar";
            // 
            // btnAtras
            // 
            this.btnAtras.AutoSize = false;
            this.btnAtras.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAtras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(115, 35);
            this.btnAtras.Text = "Atras";
            // 
            // btnHistorial
            // 
            this.btnHistorial.AutoSize = false;
            this.btnHistorial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHistorial.Enabled = false;
            this.btnHistorial.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorial.Image")));
            this.btnHistorial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHistorial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(115, 35);
            this.btnHistorial.Text = "Historial";
            // 
            // btnAnular
            // 
            this.btnAnular.AutoSize = false;
            this.btnAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnular.Enabled = false;
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAnular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(115, 35);
            this.btnAnular.Text = "toolStripButton5";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = false;
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(115, 35);
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnExportar
            // 
            this.btnExportar.AutoSize = false;
            this.btnExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportar.Enabled = false;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(115, 35);
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = false;
            this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(115, 35);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // RHHorarioRefrigrerio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 580);
            this.Controls.Add(this.tsbMenu);
            this.Controls.Add(this.gbEdicion);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.stsBarraEstado);
            this.Name = "RHHorarioRefrigrerio";
            this.Text = "Horarios de refrigrerio";
            this.Load += new System.EventHandler(this.RHHorarioRefrigrerio_Load);
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbEdicion)).EndInit();
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutosSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutosEntrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraIngreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbListado)).EndInit();
            this.gbListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).EndInit();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            this.tsbMenu.ResumeLayout(false);
            this.tsbMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwHilo;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
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
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroFilas;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Telerik.WinControls.UI.RadGroupBox gbEdicion;
        private System.Windows.Forms.Label label7;
        private Telerik.WinControls.UI.RadSpinEditor txtMinutosSalida;
        private Telerik.WinControls.UI.RadSpinEditor txtHoraSalida;
        private System.Windows.Forms.Label label6;
        private Telerik.WinControls.UI.RadSpinEditor txtMinutosEntrada;
        private Telerik.WinControls.UI.RadSpinEditor txtHoraIngreso;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblHoraSalida;
        private System.Windows.Forms.Label lblHoraIngreso;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private Telerik.WinControls.UI.RadGroupBox gbListado;
        private Telerik.WinControls.UI.RadGridView dgvListado;
        private Telerik.WinControls.UI.RadGroupBox gbConsulta;
        private Telerik.WinControls.UI.RadSpinEditor txtAño;
        private Telerik.WinControls.UI.RadButton btnConsultar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tsbMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnAtras;
        private System.Windows.Forms.ToolStripButton btnHistorial;
        private System.Windows.Forms.ToolStripButton btnAnular;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private System.Windows.Forms.ToolStripButton btnSalir;
    }
}