namespace RecursosHumanos
{
    partial class MarcacionPuertaMantenimientoTransferenciaMarcacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarcacionPuertaMantenimientoTransferenciaMarcacion));
            this.gbEdicion = new System.Windows.Forms.GroupBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtFecha = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtMovimientoAsistencia = new Telerik.WinControls.UI.RadTextBox();
            this.txtDNI = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.lblCodigoTransferencia = new Telerik.WinControls.UI.RadLabel();
            this.txtCodigoTransferencia = new Telerik.WinControls.UI.RadTextBox();
            this.txtNombres = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.btnSalir = new Telerik.WinControls.UI.RadButton();
            this.btnRegistar = new Telerik.WinControls.UI.RadButton();
            this.lblDocumento = new Telerik.WinControls.UI.RadLabel();
            this.cboDocumentoCodigo = new Telerik.WinControls.UI.RadDropDownList();
            this.gbFechaTransferir = new System.Windows.Forms.GroupBox();
            this.txtFechaPersonalizable = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.chkFechaPersonalizble = new System.Windows.Forms.CheckBox();
            this.bwgHilo = new System.ComponentModel.BackgroundWorker();
            this.bgwTransferir = new System.ComponentModel.BackgroundWorker();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.gbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegistar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumentoCodigo)).BeginInit();
            this.gbFechaTransferir.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEdicion
            // 
            this.gbEdicion.Controls.Add(this.radLabel3);
            this.gbEdicion.Controls.Add(this.txtFecha);
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
            this.gbEdicion.Size = new System.Drawing.Size(511, 146);
            this.gbEdicion.TabIndex = 237;
            this.gbEdicion.TabStop = false;
            this.gbEdicion.Text = "Edición de Marcación";
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
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(21, 256);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 30);
            this.btnOK.TabIndex = 251;
            this.btnOK.Text = "    OK";
            this.btnOK.ThemeName = "Office2007Silver";
            this.btnOK.Visible = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(435, 258);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 30);
            this.btnSalir.TabIndex = 246;
            this.btnSalir.Text = "     Salir";
            this.btnSalir.ThemeName = "Office2007Silver";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRegistar
            // 
            this.btnRegistar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistar.Image")));
            this.btnRegistar.Location = new System.Drawing.Point(325, 258);
            this.btnRegistar.Name = "btnRegistar";
            this.btnRegistar.Size = new System.Drawing.Size(104, 30);
            this.btnRegistar.TabIndex = 244;
            this.btnRegistar.Text = "    Transferir";
            this.btnRegistar.ThemeName = "Office2007Silver";
            this.btnRegistar.Click += new System.EventHandler(this.btnRegistar_Click);
            // 
            // lblDocumento
            // 
            this.lblDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocumento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.Location = new System.Drawing.Point(121, 21);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(43, 18);
            this.lblDocumento.TabIndex = 252;
            this.lblDocumento.Text = "Fecha :";
            // 
            // cboDocumentoCodigo
            // 
            this.cboDocumentoCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDocumentoCodigo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboDocumentoCodigo.Location = new System.Drawing.Point(170, 19);
            this.cboDocumentoCodigo.Name = "cboDocumentoCodigo";
            this.cboDocumentoCodigo.Size = new System.Drawing.Size(254, 20);
            this.cboDocumentoCodigo.TabIndex = 253;
            this.cboDocumentoCodigo.ThemeName = "VisualStudio2012Light";
            // 
            // gbFechaTransferir
            // 
            this.gbFechaTransferir.Controls.Add(this.txtFechaPersonalizable);
            this.gbFechaTransferir.Controls.Add(this.chkFechaPersonalizble);
            this.gbFechaTransferir.Controls.Add(this.cboDocumentoCodigo);
            this.gbFechaTransferir.Controls.Add(this.lblDocumento);
            this.gbFechaTransferir.Location = new System.Drawing.Point(12, 161);
            this.gbFechaTransferir.Name = "gbFechaTransferir";
            this.gbFechaTransferir.Size = new System.Drawing.Size(511, 89);
            this.gbFechaTransferir.TabIndex = 254;
            this.gbFechaTransferir.TabStop = false;
            this.gbFechaTransferir.Text = "Fecha a transferir.";
            // 
            // txtFechaPersonalizable
            // 
            this.txtFechaPersonalizable.EditingControlDataGridView = null;
            this.txtFechaPersonalizable.EditingControlFormattedValue = "  /  /";
            this.txtFechaPersonalizable.EditingControlRowIndex = 0;
            this.txtFechaPersonalizable.EditingControlValueChanged = true;
            this.txtFechaPersonalizable.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaPersonalizable.Location = new System.Drawing.Point(189, 55);
            this.txtFechaPersonalizable.Mask = "00/00/0000";
            this.txtFechaPersonalizable.Name = "txtFechaPersonalizable";
            this.txtFechaPersonalizable.P_EsEditable = false;
            this.txtFechaPersonalizable.P_EsModificable = false;
            this.txtFechaPersonalizable.P_ExigeInformacion = false;
            this.txtFechaPersonalizable.P_Hora = null;
            this.txtFechaPersonalizable.P_NombreColumna = null;
            this.txtFechaPersonalizable.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFechaPersonalizable.ReadOnly = true;
            this.txtFechaPersonalizable.Size = new System.Drawing.Size(88, 20);
            this.txtFechaPersonalizable.TabIndex = 255;
            this.txtFechaPersonalizable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaPersonalizable.ValidatingType = typeof(System.DateTime);
            // 
            // chkFechaPersonalizble
            // 
            this.chkFechaPersonalizble.AutoSize = true;
            this.chkFechaPersonalizble.Location = new System.Drawing.Point(47, 58);
            this.chkFechaPersonalizble.Name = "chkFechaPersonalizble";
            this.chkFechaPersonalizble.Size = new System.Drawing.Size(127, 17);
            this.chkFechaPersonalizble.TabIndex = 254;
            this.chkFechaPersonalizble.Text = "Fecha Personalizable";
            this.chkFechaPersonalizble.UseVisualStyleBackColor = true;
            this.chkFechaPersonalizble.CheckedChanged += new System.EventHandler(this.chkFechaPersonalizble_CheckedChanged);
            // 
            // bwgHilo
            // 
            this.bwgHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwgHilo_DoWork);
            this.bwgHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwgHilo_RunWorkerCompleted);
            // 
            // bgwTransferir
            // 
            this.bgwTransferir.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTransferir_DoWork);
            this.bgwTransferir.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTransferir_RunWorkerCompleted);
            // 
            // MarcacionPuertaMantenimientoTransferenciaMarcacion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(529, 300);
            this.Controls.Add(this.gbFechaTransferir);
            this.Controls.Add(this.gbEdicion);
            this.Controls.Add(this.btnRegistar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarcacionPuertaMantenimientoTransferenciaMarcacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencia de marcación";
            this.Load += new System.EventHandler(this.MarcacionPuertaMantenimientoTransferenciaMarcacion_Load);
            this.gbEdicion.ResumeLayout(false);
            this.gbEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMovimientoAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCodigoTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegistar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumentoCodigo)).EndInit();
            this.gbFechaTransferir.ResumeLayout(false);
            this.gbFechaTransferir.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEdicion;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFecha;
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
        private Telerik.WinControls.UI.RadLabel lblDocumento;
        private Telerik.WinControls.UI.RadDropDownList cboDocumentoCodigo;
        private System.Windows.Forms.GroupBox gbFechaTransferir;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaPersonalizable;
        private System.Windows.Forms.CheckBox chkFechaPersonalizble;
        private System.ComponentModel.BackgroundWorker bwgHilo;
        private System.ComponentModel.BackgroundWorker bgwTransferir;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
    }
}