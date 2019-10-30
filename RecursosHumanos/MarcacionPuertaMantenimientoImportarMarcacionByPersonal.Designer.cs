namespace RecursosHumanos
{
    partial class MarcacionPuertaMantenimientoImportarMarcacionByPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarcacionPuertaMantenimientoImportarMarcacionByPersonal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbEdicion = new System.Windows.Forms.GroupBox();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.btnActualizarListado = new Telerik.WinControls.UI.RadButton();
            this.dgvDetalle = new MyControlsDataBinding.Controles.MyDataGridViewDetails(this.components);
            this.chTipoMarcacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chnumeroMarcacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTipoMarcacionDescripion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chhoraMarcacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chcorrelativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtFecha = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.btnSalir = new Telerik.WinControls.UI.RadButton();
            this.btnRegistar = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtMovimientoAsistencia = new Telerik.WinControls.UI.RadTextBox();
            this.txtDNI = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.lblCodigoTransferencia = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigoTransferencia = new Telerik.WinControls.UI.RadTextBox();
            this.txtNombres = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.bwgHilo = new System.ComponentModel.BackgroundWorker();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.office2007SilverTheme1 = new Telerik.WinControls.Themes.Office2007SilverTheme();
            this.gbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizarListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegistar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoTransferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEdicion
            // 
            this.gbEdicion.Controls.Add(this.btnOK);
            this.gbEdicion.Controls.Add(this.btnActualizarListado);
            this.gbEdicion.Controls.Add(this.dgvDetalle);
            this.gbEdicion.Controls.Add(this.radLabel3);
            this.gbEdicion.Controls.Add(this.txtFecha);
            this.gbEdicion.Controls.Add(this.btnSalir);
            this.gbEdicion.Controls.Add(this.btnRegistar);
            this.gbEdicion.Controls.Add(this.radLabel2);
            this.gbEdicion.Controls.Add(this.radLabel4);
            this.gbEdicion.Controls.Add(this.radLabel1);
            this.gbEdicion.Controls.Add(this.txtMovimientoAsistencia);
            this.gbEdicion.Controls.Add(this.txtDNI);
            this.gbEdicion.Controls.Add(this.lblCodigoTransferencia);
            this.gbEdicion.Controls.Add(this.txtCodigoTransferencia);
            this.gbEdicion.Controls.Add(this.txtNombres);
            this.gbEdicion.Location = new System.Drawing.Point(12, 12);
            this.gbEdicion.Name = "gbEdicion";
            this.gbEdicion.Size = new System.Drawing.Size(511, 489);
            this.gbEdicion.TabIndex = 236;
            this.gbEdicion.TabStop = false;
            this.gbEdicion.Text = "Edición de Marcación";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(6, 451);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 30);
            this.btnOK.TabIndex = 251;
            this.btnOK.Text = "    Importar";
            this.btnOK.ThemeName = "Office2013Light";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnActualizarListado
            // 
            this.btnActualizarListado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarListado.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarListado.Image")));
            this.btnActualizarListado.Location = new System.Drawing.Point(383, 120);
            this.btnActualizarListado.Name = "btnActualizarListado";
            this.btnActualizarListado.Size = new System.Drawing.Size(122, 28);
            this.btnActualizarListado.TabIndex = 250;
            this.btnActualizarListado.Text = "Actualizar lista   ";
            this.btnActualizarListado.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarListado.ThemeName = "Office2013Light";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chTipoMarcacion,
            this.chnumeroMarcacion,
            this.chTipoMarcacionDescripion,
            this.chhoraMarcacion,
            this.chcorrelativo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalle.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.Location = new System.Drawing.Point(6, 154);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.P_EsEditable = true;
            this.dgvDetalle.P_FormatoDecimal = null;
            this.dgvDetalle.P_FormatoFecha = null;
            this.dgvDetalle.P_NombreColCorrelativa = null;
            this.dgvDetalle.P_NombreTabla = null;
            this.dgvDetalle.P_NumeroDigitos = 0;
            this.dgvDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            this.dgvDetalle.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(499, 291);
            this.dgvDetalle.TabIndex = 249;
            this.dgvDetalle.SelectionChanged += new System.EventHandler(this.dgvDetalle_SelectionChanged);
            this.dgvDetalle.DoubleClick += new System.EventHandler(this.dgvDetalle_DoubleClick);
            // 
            // chTipoMarcacion
            // 
            this.chTipoMarcacion.DataPropertyName = "TipoMarcacion";
            this.chTipoMarcacion.HeaderText = "Tipo Marcacion";
            this.chTipoMarcacion.Name = "chTipoMarcacion";
            this.chTipoMarcacion.ReadOnly = true;
            this.chTipoMarcacion.Visible = false;
            // 
            // chnumeroMarcacion
            // 
            this.chnumeroMarcacion.DataPropertyName = "numeroMarcacion";
            this.chnumeroMarcacion.FillWeight = 44.5694F;
            this.chnumeroMarcacion.HeaderText = "Nro Marcación";
            this.chnumeroMarcacion.Name = "chnumeroMarcacion";
            this.chnumeroMarcacion.ReadOnly = true;
            // 
            // chTipoMarcacionDescripion
            // 
            this.chTipoMarcacionDescripion.DataPropertyName = "TipoMarcacionDescripion";
            this.chTipoMarcacionDescripion.FillWeight = 103.1463F;
            this.chTipoMarcacionDescripion.HeaderText = "Marcación";
            this.chTipoMarcacionDescripion.Name = "chTipoMarcacionDescripion";
            this.chTipoMarcacionDescripion.ReadOnly = true;
            // 
            // chhoraMarcacion
            // 
            this.chhoraMarcacion.DataPropertyName = "horaMarcacion";
            this.chhoraMarcacion.FillWeight = 152.2843F;
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
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(356, 27);
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
            this.txtFecha.Location = new System.Drawing.Point(405, 26);
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
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(414, 453);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 30);
            this.btnSalir.TabIndex = 246;
            this.btnSalir.Text = "     Salir";
            this.btnSalir.ThemeName = "Office2013Light";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRegistar
            // 
            this.btnRegistar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistar.Image")));
            this.btnRegistar.Location = new System.Drawing.Point(318, 453);
            this.btnRegistar.Name = "btnRegistar";
            this.btnRegistar.Size = new System.Drawing.Size(88, 30);
            this.btnRegistar.TabIndex = 244;
            this.btnRegistar.Text = "    Importar";
            this.btnRegistar.ThemeName = "Office2013Light";
            this.btnRegistar.Click += new System.EventHandler(this.btnRegistar_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(123, 117);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(33, 18);
            this.radLabel2.TabIndex = 239;
            this.radLabel2.Text = "DNI :";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(33, 53);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(123, 18);
            this.radLabel4.TabIndex = 233;
            this.radLabel4.Text = "Cod. Mov. Asistencia :";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(95, 82);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(61, 18);
            this.radLabel1.TabIndex = 237;
            this.radLabel1.Text = "Nombres :";
            // 
            // txtMovimientoAsistencia
            // 
            this.txtMovimientoAsistencia.BackColor = System.Drawing.SystemColors.Control;
            this.txtMovimientoAsistencia.Enabled = false;
            this.txtMovimientoAsistencia.Location = new System.Drawing.Point(162, 53);
            this.txtMovimientoAsistencia.Name = "txtMovimientoAsistencia";
            this.txtMovimientoAsistencia.ReadOnly = true;
            this.txtMovimientoAsistencia.Size = new System.Drawing.Size(158, 20);
            this.txtMovimientoAsistencia.TabIndex = 234;
            this.txtMovimientoAsistencia.TabStop = false;
            this.txtMovimientoAsistencia.ThemeName = "VisualStudio2012Light";
            // 
            // txtDNI
            // 
            this.txtDNI.BackColor = System.Drawing.Color.White;
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNI.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtDNI.Location = new System.Drawing.Point(162, 113);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.P_BotonEnlace = null;
            this.txtDNI.P_BuscarSoloCodigoExacto = false;
            this.txtDNI.P_EsEditable = false;
            this.txtDNI.P_EsModificable = false;
            this.txtDNI.P_EsPrimaryKey = false;
            this.txtDNI.P_ExigeInformacion = false;
            this.txtDNI.P_NombreColumna = null;
            this.txtDNI.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtDNI.ReadOnly = true;
            this.txtDNI.Size = new System.Drawing.Size(95, 22);
            this.txtDNI.TabIndex = 238;
            this.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCodigoTransferencia
            // 
            this.lblCodigoTransferencia.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoTransferencia.Location = new System.Drawing.Point(47, 26);
            this.lblCodigoTransferencia.Name = "lblCodigoTransferencia";
            this.lblCodigoTransferencia.Size = new System.Drawing.Size(109, 18);
            this.lblCodigoTransferencia.TabIndex = 230;
            this.lblCodigoTransferencia.Text = "Cod. transferencia :";
            // 
            // txtCodigoTransferencia
            // 
            this.txtCodigoTransferencia.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodigoTransferencia.Enabled = false;
            this.txtCodigoTransferencia.Location = new System.Drawing.Point(162, 25);
            this.txtCodigoTransferencia.Name = "txtCodigoTransferencia";
            this.txtCodigoTransferencia.ReadOnly = true;
            this.txtCodigoTransferencia.Size = new System.Drawing.Size(158, 20);
            this.txtCodigoTransferencia.TabIndex = 231;
            this.txtCodigoTransferencia.TabStop = false;
            this.txtCodigoTransferencia.ThemeName = "VisualStudio2012Light";
            // 
            // txtNombres
            // 
            this.txtNombres.BackColor = System.Drawing.Color.White;
            this.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombres.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNombres.Location = new System.Drawing.Point(162, 81);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.P_BotonEnlace = null;
            this.txtNombres.P_BuscarSoloCodigoExacto = false;
            this.txtNombres.P_EsEditable = false;
            this.txtNombres.P_EsModificable = false;
            this.txtNombres.P_EsPrimaryKey = false;
            this.txtNombres.P_ExigeInformacion = false;
            this.txtNombres.P_NombreColumna = null;
            this.txtNombres.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtNombres.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(332, 22);
            this.txtNombres.TabIndex = 236;
            this.txtNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bwgHilo
            // 
            this.bwgHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwgHilo_DoWork);
            this.bwgHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwgHilo_RunWorkerCompleted);
            // 
            // MarcacionPuertaMantenimientoImportarMarcacionByPersonal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(532, 510);
            this.Controls.Add(this.gbEdicion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarcacionPuertaMantenimientoImportarMarcacionByPersonal";
            this.Text = "Importar marcación";
            this.Load += new System.EventHandler(this.MarcacionPuertaMantenimientoImportarMarcacion_Load);
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizarListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegistar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoTransferencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEdicion;
        private Telerik.WinControls.UI.RadButton btnSalir;
        private Telerik.WinControls.UI.RadButton btnRegistar;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtMovimientoAsistencia;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtDNI;
        private Telerik.WinControls.UI.RadLabel lblCodigoTransferencia;
        private Telerik.WinControls.UI.RadTextBox txtCodigoTransferencia;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtNombres;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFecha;
        private MyControlsDataBinding.Controles.MyDataGridViewDetails dgvDetalle;
        private System.ComponentModel.BackgroundWorker bwgHilo;
        private Telerik.WinControls.UI.RadButton btnActualizarListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTipoMarcacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chnumeroMarcacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chTipoMarcacionDescripion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chhoraMarcacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chcorrelativo;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Office2007SilverTheme office2007SilverTheme1;
    }
}