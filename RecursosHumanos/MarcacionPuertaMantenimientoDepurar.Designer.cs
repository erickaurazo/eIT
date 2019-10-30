namespace RecursosHumanos
{
    partial class MarcacionPuertaMantenimientoDepurar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarcacionPuertaMantenimientoDepurar));
            this.gbEdicion = new System.Windows.Forms.GroupBox();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.btnActualizarListado = new Telerik.WinControls.UI.RadButton();
            this.dgvDetalle = new MyControlsDataBinding.Controles.MyDataGridViewDetails(this.components);
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtFecha = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.btnSalir = new Telerik.WinControls.UI.RadButton();
            this.btnQuitar = new Telerik.WinControls.UI.RadButton();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtMovimientoAsistencia = new Telerik.WinControls.UI.RadTextBox();
            this.lblCodigoTransferencia = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigoTransferencia = new Telerik.WinControls.UI.RadTextBox();
            this.bwgHilo = new System.ComponentModel.BackgroundWorker();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.chcodigoUsuarioMarcacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chdni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTipoMarcacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chnumeroMarcacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTipoMarcacionDescripion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chhoraMarcacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chcorrelativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalRegistros = new Telerik.WinControls.UI.RadLabel();
            this.BtnEliminarAll = new Telerik.WinControls.UI.RadButton();
            this.bwgEliminacionMasiva = new System.ComponentModel.BackgroundWorker();
            this.stsBarraEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTiempoTranscurrido = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBarF = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroResultados = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizarListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEliminarAll)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEdicion
            // 
            this.gbEdicion.Controls.Add(this.BtnEliminarAll);
            this.gbEdicion.Controls.Add(this.lblTotalRegistros);
            this.gbEdicion.Controls.Add(this.btnOK);
            this.gbEdicion.Controls.Add(this.btnActualizarListado);
            this.gbEdicion.Controls.Add(this.dgvDetalle);
            this.gbEdicion.Controls.Add(this.radLabel3);
            this.gbEdicion.Controls.Add(this.txtFecha);
            this.gbEdicion.Controls.Add(this.btnSalir);
            this.gbEdicion.Controls.Add(this.btnQuitar);
            this.gbEdicion.Controls.Add(this.radLabel4);
            this.gbEdicion.Controls.Add(this.txtMovimientoAsistencia);
            this.gbEdicion.Controls.Add(this.lblCodigoTransferencia);
            this.gbEdicion.Controls.Add(this.txtCodigoTransferencia);
            this.gbEdicion.Location = new System.Drawing.Point(0, 0);
            this.gbEdicion.Name = "gbEdicion";
            this.gbEdicion.Size = new System.Drawing.Size(631, 489);
            this.gbEdicion.TabIndex = 237;
            this.gbEdicion.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(316, 449);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 27);
            this.btnOK.TabIndex = 251;
            this.btnOK.Text = "    Importar";
            this.btnOK.ThemeName = "Office2013Light";
            this.btnOK.Visible = false;
            // 
            // btnActualizarListado
            // 
            this.btnActualizarListado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarListado.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarListado.Image")));
            this.btnActualizarListado.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnActualizarListado.Location = new System.Drawing.Point(557, 48);
            this.btnActualizarListado.Name = "btnActualizarListado";
            this.btnActualizarListado.Size = new System.Drawing.Size(31, 27);
            this.btnActualizarListado.TabIndex = 250;
            this.btnActualizarListado.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarListado.ThemeName = "Office2013Light";
            this.btnActualizarListado.Click += new System.EventHandler(this.btnActualizarListado_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chcodigoUsuarioMarcacion,
            this.chdni,
            this.chNombres,
            this.chTipoMarcacion,
            this.chnumeroMarcacion,
            this.chTipoMarcacionDescripion,
            this.chhoraMarcacion,
            this.chcorrelativo});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDetalle.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.Location = new System.Drawing.Point(6, 79);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.P_EsEditable = true;
            this.dgvDetalle.P_FormatoDecimal = null;
            this.dgvDetalle.P_FormatoFecha = null;
            this.dgvDetalle.P_NombreColCorrelativa = null;
            this.dgvDetalle.P_NombreTabla = null;
            this.dgvDetalle.P_NumeroDigitos = 0;
            this.dgvDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDetalle.RowHeadersWidth = 10;
            this.dgvDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgvDetalle.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(619, 366);
            this.dgvDetalle.TabIndex = 249;
            this.dgvDetalle.SelectionChanged += new System.EventHandler(this.dgvDetalle_SelectionChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(490, 17);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(43, 18);
            this.radLabel3.TabIndex = 247;
            this.radLabel3.Text = "Fecha :";
            // 
            // txtFecha
            // 
            this.txtFecha.EditingControlDataGridView = null;
            this.txtFecha.EditingControlFormattedValue = "  /  /";
            this.txtFecha.EditingControlRowIndex = 0;
            this.txtFecha.EditingControlValueChanged = true;
            this.txtFecha.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFecha.Location = new System.Drawing.Point(539, 16);
            this.txtFecha.Mask = "00/00/0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.P_EsEditable = false;
            this.txtFecha.P_EsModificable = false;
            this.txtFecha.P_ExigeInformacion = false;
            this.txtFecha.P_Hora = null;
            this.txtFecha.P_NombreColumna = null;
            this.txtFecha.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(88, 20);
            this.txtFecha.TabIndex = 248;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFecha.ValidatingType = typeof(System.DateTime);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(534, 449);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 27);
            this.btnSalir.TabIndex = 246;
            this.btnSalir.Text = "     Grabar  ";
            this.btnSalir.ThemeName = "Office2013Light";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.Location = new System.Drawing.Point(594, 48);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(31, 27);
            this.btnQuitar.TabIndex = 244;
            this.btnQuitar.ThemeName = "Office2013Light";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(10, 45);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(123, 18);
            this.radLabel4.TabIndex = 233;
            this.radLabel4.Text = "Cod. Mov. Asistencia :";
            // 
            // txtMovimientoAsistencia
            // 
            this.txtMovimientoAsistencia.BackColor = System.Drawing.SystemColors.Control;
            this.txtMovimientoAsistencia.Enabled = false;
            this.txtMovimientoAsistencia.Location = new System.Drawing.Point(139, 45);
            this.txtMovimientoAsistencia.Name = "txtMovimientoAsistencia";
            this.txtMovimientoAsistencia.ReadOnly = true;
            this.txtMovimientoAsistencia.Size = new System.Drawing.Size(158, 20);
            this.txtMovimientoAsistencia.TabIndex = 234;
            this.txtMovimientoAsistencia.TabStop = false;
            this.txtMovimientoAsistencia.ThemeName = "VisualStudio2012Light";
            // 
            // lblCodigoTransferencia
            // 
            this.lblCodigoTransferencia.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoTransferencia.Location = new System.Drawing.Point(24, 18);
            this.lblCodigoTransferencia.Name = "lblCodigoTransferencia";
            this.lblCodigoTransferencia.Size = new System.Drawing.Size(109, 18);
            this.lblCodigoTransferencia.TabIndex = 230;
            this.lblCodigoTransferencia.Text = "Cod. transferencia :";
            // 
            // txtCodigoTransferencia
            // 
            this.txtCodigoTransferencia.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodigoTransferencia.Enabled = false;
            this.txtCodigoTransferencia.Location = new System.Drawing.Point(139, 17);
            this.txtCodigoTransferencia.Name = "txtCodigoTransferencia";
            this.txtCodigoTransferencia.ReadOnly = true;
            this.txtCodigoTransferencia.Size = new System.Drawing.Size(158, 20);
            this.txtCodigoTransferencia.TabIndex = 231;
            this.txtCodigoTransferencia.TabStop = false;
            this.txtCodigoTransferencia.ThemeName = "VisualStudio2012Light";
            // 
            // bwgHilo
            // 
            this.bwgHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwgHilo_DoWork);
            this.bwgHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwgHilo_RunWorkerCompleted);
            // 
            // chcodigoUsuarioMarcacion
            // 
            this.chcodigoUsuarioMarcacion.DataPropertyName = "codigoUsuarioMarcacion";
            this.chcodigoUsuarioMarcacion.FillWeight = 45F;
            this.chcodigoUsuarioMarcacion.HeaderText = "Cod.";
            this.chcodigoUsuarioMarcacion.Name = "chcodigoUsuarioMarcacion";
            // 
            // chdni
            // 
            this.chdni.DataPropertyName = "dni";
            this.chdni.FillWeight = 75F;
            this.chdni.HeaderText = "DNI";
            this.chdni.Name = "chdni";
            // 
            // chNombres
            // 
            this.chNombres.DataPropertyName = "Nombres";
            this.chNombres.HeaderText = "Nombres";
            this.chNombres.Name = "chNombres";
            // 
            // chTipoMarcacion
            // 
            this.chTipoMarcacion.DataPropertyName = "TipoMarcacion";
            this.chTipoMarcacion.FillWeight = 75F;
            this.chTipoMarcacion.HeaderText = "Tipo Marcacion";
            this.chTipoMarcacion.Name = "chTipoMarcacion";
            this.chTipoMarcacion.ReadOnly = true;
            this.chTipoMarcacion.Visible = false;
            // 
            // chnumeroMarcacion
            // 
            this.chnumeroMarcacion.DataPropertyName = "numeroMarcacion";
            this.chnumeroMarcacion.FillWeight = 45F;
            this.chnumeroMarcacion.HeaderText = "Nro Marcación";
            this.chnumeroMarcacion.Name = "chnumeroMarcacion";
            this.chnumeroMarcacion.ReadOnly = true;
            // 
            // chTipoMarcacionDescripion
            // 
            this.chTipoMarcacionDescripion.DataPropertyName = "TipoMarcacionDescripion";
            this.chTipoMarcacionDescripion.FillWeight = 85F;
            this.chTipoMarcacionDescripion.HeaderText = "Marcación";
            this.chTipoMarcacionDescripion.Name = "chTipoMarcacionDescripion";
            this.chTipoMarcacionDescripion.ReadOnly = true;
            // 
            // chhoraMarcacion
            // 
            this.chhoraMarcacion.DataPropertyName = "horaMarcacion";
            this.chhoraMarcacion.FillWeight = 85F;
            this.chhoraMarcacion.HeaderText = "Hora de Marcación";
            this.chhoraMarcacion.Name = "chhoraMarcacion";
            this.chhoraMarcacion.ReadOnly = true;
            // 
            // chcorrelativo
            // 
            this.chcorrelativo.DataPropertyName = "correlativo";
            this.chcorrelativo.HeaderText = "Correlativo";
            this.chcorrelativo.Name = "chcorrelativo";
            this.chcorrelativo.ReadOnly = true;
            this.chcorrelativo.Visible = false;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistros.Location = new System.Drawing.Point(12, 454);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(123, 18);
            this.lblTotalRegistros.TabIndex = 240;
            this.lblTotalRegistros.Text = "TOTAL DE REGISTROS";
            // 
            // BtnEliminarAll
            // 
            this.BtnEliminarAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEliminarAll.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminarAll.Image")));
            this.BtnEliminarAll.Location = new System.Drawing.Point(410, 449);
            this.BtnEliminarAll.Name = "BtnEliminarAll";
            this.BtnEliminarAll.Size = new System.Drawing.Size(118, 27);
            this.BtnEliminarAll.TabIndex = 245;
            this.BtnEliminarAll.Text = " Eliminar todo";
            this.BtnEliminarAll.ThemeName = "Office2013Light";
            this.BtnEliminarAll.Click += new System.EventHandler(this.BtnEliminarAll_Click);
            // 
            // bwgEliminacionMasiva
            // 
            this.bwgEliminacionMasiva.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwgEliminacionMasiva_DoWork);
            this.bwgEliminacionMasiva.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwgEliminacionMasiva_RunWorkerCompleted);
            // 
            // stsBarraEstado
            // 
            this.stsBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel8,
            this.lblTiempoTranscurrido,
            this.ProgressBarF,
            this.lblNumeroResultados});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 481);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(634, 22);
            this.stsBarraEstado.TabIndex = 238;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
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
            // ProgressBarF
            // 
            this.ProgressBarF.MarqueeAnimationSpeed = 25;
            this.ProgressBarF.Name = "ProgressBarF";
            this.ProgressBarF.Size = new System.Drawing.Size(160, 16);
            this.ProgressBarF.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBarF.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
            // 
            // MarcacionPuertaMantenimientoDepurar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 503);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.gbEdicion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarcacionPuertaMantenimientoDepurar";
            this.Text = "Depurar de marcación";
            this.Load += new System.EventHandler(this.MarcacionPuertaMantenimientoDepurar_Load);
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizarListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnEliminarAll)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEdicion;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadButton btnActualizarListado;
        private MyControlsDataBinding.Controles.MyDataGridViewDetails dgvDetalle;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFecha;
        private Telerik.WinControls.UI.RadButton btnSalir;
        private Telerik.WinControls.UI.RadButton btnQuitar;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtMovimientoAsistencia;
        private Telerik.WinControls.UI.RadLabel lblCodigoTransferencia;
        private Telerik.WinControls.UI.RadTextBox txtCodigoTransferencia;
        private System.ComponentModel.BackgroundWorker bwgHilo;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chcodigoUsuarioMarcacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chdni;
        private System.Windows.Forms.DataGridViewTextBoxColumn chNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTipoMarcacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chnumeroMarcacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTipoMarcacionDescripion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chhoraMarcacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chcorrelativo;
        private Telerik.WinControls.UI.RadLabel lblTotalRegistros;
        private Telerik.WinControls.UI.RadButton BtnEliminarAll;
        private System.ComponentModel.BackgroundWorker bwgEliminacionMasiva;
        private System.Windows.Forms.StatusStrip stsBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempoTranscurrido;
        private System.Windows.Forms.ToolStripProgressBar ProgressBarF;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroResultados;
    }
}