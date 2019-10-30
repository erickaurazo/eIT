namespace RecursosHumanos
{
    partial class MarcacionPuertaMantenimientoEdicionMarcacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarcacionPuertaMantenimientoEdicionMarcacion));
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtMovimientoAsistencia = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtFecha = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.lblCodigoTransferencia = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigoTransferencia = new Telerik.WinControls.UI.RadTextBox();
            this.gbEdicion = new System.Windows.Forms.GroupBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigoBiometrico = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.txtMarcacion = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.cboTipoMarcacion = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtCorrelativo = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtDNI = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtNombres = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.btnSalir = new Telerik.WinControls.UI.RadButton();
            this.btnRegistar = new Telerik.WinControls.UI.RadButton();
            this.stsBarraEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTiempoTranscurrido = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarF = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroResultados = new System.Windows.Forms.ToolStripStatusLabel();
            this.bwgHilo = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoTransferencia)).BeginInit();
            this.gbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoMarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegistar)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(6, 56);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(120, 18);
            this.radLabel4.TabIndex = 233;
            this.radLabel4.Text = "Cod. Mov Asistencia :";
            // 
            // txtMovimientoAsistencia
            // 
            this.txtMovimientoAsistencia.Location = new System.Drawing.Point(133, 56);
            this.txtMovimientoAsistencia.Name = "txtMovimientoAsistencia";
            this.txtMovimientoAsistencia.ReadOnly = true;
            this.txtMovimientoAsistencia.Size = new System.Drawing.Size(176, 20);
            this.txtMovimientoAsistencia.TabIndex = 234;
            this.txtMovimientoAsistencia.TabStop = false;
            this.txtMovimientoAsistencia.ThemeName = "VisualStudio2012Light";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(333, 27);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(43, 18);
            this.radLabel3.TabIndex = 227;
            this.radLabel3.Text = "Fecha :";
            // 
            // txtFecha
            // 
            this.txtFecha.EditingControlDataGridView = null;
            this.txtFecha.EditingControlFormattedValue = "  /  /";
            this.txtFecha.EditingControlRowIndex = 0;
            this.txtFecha.EditingControlValueChanged = true;
            this.txtFecha.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFecha.Location = new System.Drawing.Point(376, 27);
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
            this.txtFecha.TabIndex = 232;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFecha.ValidatingType = typeof(System.DateTime);
            // 
            // lblCodigoTransferencia
            // 
            this.lblCodigoTransferencia.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoTransferencia.Location = new System.Drawing.Point(17, 27);
            this.lblCodigoTransferencia.Name = "lblCodigoTransferencia";
            this.lblCodigoTransferencia.Size = new System.Drawing.Size(109, 18);
            this.lblCodigoTransferencia.TabIndex = 230;
            this.lblCodigoTransferencia.Text = "Cod. transferencia :";
            // 
            // txtCodigoTransferencia
            // 
            this.txtCodigoTransferencia.Location = new System.Drawing.Point(133, 25);
            this.txtCodigoTransferencia.Name = "txtCodigoTransferencia";
            this.txtCodigoTransferencia.ReadOnly = true;
            this.txtCodigoTransferencia.Size = new System.Drawing.Size(176, 20);
            this.txtCodigoTransferencia.TabIndex = 231;
            this.txtCodigoTransferencia.TabStop = false;
            this.txtCodigoTransferencia.ThemeName = "VisualStudio2012Light";
            // 
            // gbEdicion
            // 
            this.gbEdicion.Controls.Add(this.radLabel7);
            this.gbEdicion.Controls.Add(this.txtCodigoBiometrico);
            this.gbEdicion.Controls.Add(this.radLabel6);
            this.gbEdicion.Controls.Add(this.txtMarcacion);
            this.gbEdicion.Controls.Add(this.cboTipoMarcacion);
            this.gbEdicion.Controls.Add(this.radLabel8);
            this.gbEdicion.Controls.Add(this.radLabel5);
            this.gbEdicion.Controls.Add(this.txtCorrelativo);
            this.gbEdicion.Controls.Add(this.radLabel2);
            this.gbEdicion.Controls.Add(this.radLabel4);
            this.gbEdicion.Controls.Add(this.radLabel1);
            this.gbEdicion.Controls.Add(this.txtMovimientoAsistencia);
            this.gbEdicion.Controls.Add(this.txtDNI);
            this.gbEdicion.Controls.Add(this.lblCodigoTransferencia);
            this.gbEdicion.Controls.Add(this.txtCodigoTransferencia);
            this.gbEdicion.Controls.Add(this.radLabel3);
            this.gbEdicion.Controls.Add(this.txtFecha);
            this.gbEdicion.Controls.Add(this.txtNombres);
            this.gbEdicion.Location = new System.Drawing.Point(12, 11);
            this.gbEdicion.Name = "gbEdicion";
            this.gbEdicion.Size = new System.Drawing.Size(484, 204);
            this.gbEdicion.TabIndex = 235;
            this.gbEdicion.TabStop = false;
            this.gbEdicion.Text = "Edición de Marcación";
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(313, 58);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(98, 18);
            this.radLabel7.TabIndex = 248;
            this.radLabel7.Text = "Cod. Biométrico :";
            this.radLabel7.Visible = false;
            // 
            // txtCodigoBiometrico
            // 
            this.txtCodigoBiometrico.BackColor = System.Drawing.Color.White;
            this.txtCodigoBiometrico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoBiometrico.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtCodigoBiometrico.Location = new System.Drawing.Point(417, 56);
            this.txtCodigoBiometrico.Name = "txtCodigoBiometrico";
            this.txtCodigoBiometrico.P_BotonEnlace = null;
            this.txtCodigoBiometrico.P_BuscarSoloCodigoExacto = false;
            this.txtCodigoBiometrico.P_EsEditable = false;
            this.txtCodigoBiometrico.P_EsModificable = false;
            this.txtCodigoBiometrico.P_EsPrimaryKey = false;
            this.txtCodigoBiometrico.P_ExigeInformacion = false;
            this.txtCodigoBiometrico.P_NombreColumna = null;
            this.txtCodigoBiometrico.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtCodigoBiometrico.ReadOnly = true;
            this.txtCodigoBiometrico.Size = new System.Drawing.Size(47, 22);
            this.txtCodigoBiometrico.TabIndex = 247;
            this.txtCodigoBiometrico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoBiometrico.Visible = false;
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(84, 178);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(43, 18);
            this.radLabel6.TabIndex = 244;
            this.radLabel6.Text = "Fecha :";
            // 
            // txtMarcacion
            // 
            this.txtMarcacion.EditingControlDataGridView = null;
            this.txtMarcacion.EditingControlFormattedValue = "  /  /       :  :";
            this.txtMarcacion.EditingControlRowIndex = 0;
            this.txtMarcacion.EditingControlValueChanged = true;
            this.txtMarcacion.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtMarcacion.Location = new System.Drawing.Point(134, 178);
            this.txtMarcacion.Mask = "00/00/0000 00:00:00";
            this.txtMarcacion.Name = "txtMarcacion";
            this.txtMarcacion.P_EsEditable = false;
            this.txtMarcacion.P_EsModificable = false;
            this.txtMarcacion.P_ExigeInformacion = false;
            this.txtMarcacion.P_Hora = null;
            this.txtMarcacion.P_NombreColumna = null;
            this.txtMarcacion.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtMarcacion.Size = new System.Drawing.Size(118, 20);
            this.txtMarcacion.TabIndex = 245;
            this.txtMarcacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboTipoMarcacion
            // 
            this.cboTipoMarcacion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboTipoMarcacion.Location = new System.Drawing.Point(134, 149);
            this.cboTipoMarcacion.Name = "cboTipoMarcacion";
            this.cboTipoMarcacion.Size = new System.Drawing.Size(150, 20);
            this.cboTipoMarcacion.TabIndex = 242;
            this.cboTipoMarcacion.ThemeName = "VisualStudio2012Light";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(37, 150);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(95, 18);
            this.radLabel8.TabIndex = 243;
            this.radLabel8.Text = "Tipo Marcación :";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(305, 117);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(72, 18);
            this.radLabel5.TabIndex = 241;
            this.radLabel5.Text = "Correlativo :";
            this.radLabel5.Visible = false;
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.BackColor = System.Drawing.Color.White;
            this.txtCorrelativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorrelativo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtCorrelativo.Location = new System.Drawing.Point(377, 116);
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.P_BotonEnlace = null;
            this.txtCorrelativo.P_BuscarSoloCodigoExacto = false;
            this.txtCorrelativo.P_EsEditable = false;
            this.txtCorrelativo.P_EsModificable = false;
            this.txtCorrelativo.P_EsPrimaryKey = false;
            this.txtCorrelativo.P_ExigeInformacion = false;
            this.txtCorrelativo.P_NombreColumna = null;
            this.txtCorrelativo.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtCorrelativo.ReadOnly = true;
            this.txtCorrelativo.Size = new System.Drawing.Size(88, 22);
            this.txtCorrelativo.TabIndex = 240;
            this.txtCorrelativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCorrelativo.Visible = false;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(93, 120);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(33, 18);
            this.radLabel2.TabIndex = 239;
            this.radLabel2.Text = "DNI :";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(66, 85);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(61, 18);
            this.radLabel1.TabIndex = 237;
            this.radLabel1.Text = "Nombres :";
            // 
            // txtDNI
            // 
            this.txtDNI.BackColor = System.Drawing.Color.White;
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNI.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtDNI.Location = new System.Drawing.Point(133, 117);
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
            this.txtDNI.Size = new System.Drawing.Size(85, 22);
            this.txtDNI.TabIndex = 238;
            this.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNombres
            // 
            this.txtNombres.BackColor = System.Drawing.Color.White;
            this.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombres.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNombres.Location = new System.Drawing.Point(133, 85);
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
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(411, 221);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 32);
            this.btnSalir.TabIndex = 246;
            this.btnSalir.Text = "     Salir";
            this.btnSalir.ThemeName = "Office2007Silver";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRegistar
            // 
            this.btnRegistar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistar.Image")));
            this.btnRegistar.Location = new System.Drawing.Point(317, 221);
            this.btnRegistar.Name = "btnRegistar";
            this.btnRegistar.Size = new System.Drawing.Size(88, 32);
            this.btnRegistar.TabIndex = 244;
            this.btnRegistar.Text = "     Registrar";
            this.btnRegistar.ThemeName = "Office2007Silver";
            this.btnRegistar.Click += new System.EventHandler(this.btnRegistar_Click);
            // 
            // stsBarraEstado
            // 
            this.stsBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel8,
            this.lblTiempoTranscurrido,
            this.progressBarF,
            this.lblNumeroResultados});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 262);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(504, 22);
            this.stsBarraEstado.TabIndex = 236;
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
            // progressBarF
            // 
            this.progressBarF.MarqueeAnimationSpeed = 25;
            this.progressBarF.Name = "progressBarF";
            this.progressBarF.Size = new System.Drawing.Size(160, 16);
            this.progressBarF.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarF.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
            // 
            // bwgHilo
            // 
            this.bwgHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwgHilo_DoWork);
            this.bwgHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwgHilo_RunWorkerCompleted);
            // 
            // MarcacionPuertaMantenimientoEdicionMarcacion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(504, 284);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.gbEdicion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegistar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarcacionPuertaMantenimientoEdicionMarcacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar de marcación en biometrico";
            this.Load += new System.EventHandler(this.MarcacionPuertaMantenimientoTransferirMarcacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoTransferencia)).EndInit();
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoMarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegistar)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtMovimientoAsistencia;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFecha;
        private Telerik.WinControls.UI.RadLabel lblCodigoTransferencia;
        private Telerik.WinControls.UI.RadTextBox txtCodigoTransferencia;
        private System.Windows.Forms.GroupBox gbEdicion;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtCorrelativo;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtDNI;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtNombres;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtMarcacion;
        private Telerik.WinControls.UI.RadDropDownList cboTipoMarcacion;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadButton btnRegistar;
        private System.Windows.Forms.StatusStrip stsBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempoTranscurrido;
        private System.Windows.Forms.ToolStripProgressBar progressBarF;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroResultados;
        private System.ComponentModel.BackgroundWorker bwgHilo;
        private Telerik.WinControls.UI.RadButton btnSalir;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtCodigoBiometrico;

    }
}