namespace RecursosHumanos
{
    partial class ProcesoTransferenciaMarcacionesDeBiometricoASistemaDeAsistencia
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
            this.gbTransferencia = new Telerik.WinControls.UI.RadGroupBox();
            this.txtFechaHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.txtPeriodo = new Telerik.WinControls.UI.RadSpinEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.btnTransferirMarcaciones = new Telerik.WinControls.UI.RadButton();
            this.btnTransferirUsuarios = new Telerik.WinControls.UI.RadButton();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.pbTransferenciaInformacion = new System.Windows.Forms.ProgressBar();
            this.bgwHiloTransferenciaMarcaciones = new System.ComponentModel.BackgroundWorker();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.bgwHiloTransferenciaUsuarios = new System.ComponentModel.BackgroundWorker();
            this.bgwGenerarTareosDiarios = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gbTransferencia)).BeginInit();
            this.gbTransferencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransferirMarcaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransferirUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTransferencia
            // 
            this.gbTransferencia.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbTransferencia.Controls.Add(this.txtFechaHasta);
            this.gbTransferencia.Controls.Add(this.txtFechaDesde);
            this.gbTransferencia.Controls.Add(this.lblFechaDesde);
            this.gbTransferencia.Controls.Add(this.radLabel7);
            this.gbTransferencia.Controls.Add(this.lblFechaHasta);
            this.gbTransferencia.Controls.Add(this.txtPeriodo);
            this.gbTransferencia.Controls.Add(this.label5);
            this.gbTransferencia.Controls.Add(this.cboMes);
            this.gbTransferencia.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbTransferencia.HeaderText = "Transferencia de información";
            this.gbTransferencia.Location = new System.Drawing.Point(12, 12);
            this.gbTransferencia.Name = "gbTransferencia";
            this.gbTransferencia.Size = new System.Drawing.Size(409, 126);
            this.gbTransferencia.TabIndex = 1;
            this.gbTransferencia.Text = "Transferencia de información";
            this.gbTransferencia.ThemeName = "Windows8";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.EditingControlDataGridView = null;
            this.txtFechaHasta.EditingControlFormattedValue = "  /  /";
            this.txtFechaHasta.EditingControlRowIndex = 0;
            this.txtFechaHasta.EditingControlValueChanged = true;
            this.txtFechaHasta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaHasta.Location = new System.Drawing.Point(313, 93);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.P_EsEditable = false;
            this.txtFechaHasta.P_EsModificable = false;
            this.txtFechaHasta.P_ExigeInformacion = false;
            this.txtFechaHasta.P_Hora = null;
            this.txtFechaHasta.P_NombreColumna = null;
            this.txtFechaHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaHasta.Size = new System.Drawing.Size(79, 20);
            this.txtFechaHasta.TabIndex = 9;
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.EditingControlDataGridView = null;
            this.txtFechaDesde.EditingControlFormattedValue = "  /  /";
            this.txtFechaDesde.EditingControlRowIndex = 0;
            this.txtFechaDesde.EditingControlValueChanged = true;
            this.txtFechaDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaDesde.Location = new System.Drawing.Point(314, 63);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaDesde.Size = new System.Drawing.Size(76, 20);
            this.txtFechaDesde.TabIndex = 7;
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(251, 68);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(55, 13);
            this.lblFechaDesde.TabIndex = 6;
            this.lblFechaDesde.Text = " Desde :";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(10, 35);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(32, 18);
            this.radLabel7.TabIndex = 2;
            this.radLabel7.Text = "Año :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(252, 96);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(52, 13);
            this.lblFechaHasta.TabIndex = 8;
            this.lblFechaHasta.Text = " Hasta :";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(48, 34);
            this.txtPeriodo.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.txtPeriodo.Minimum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.txtPeriodo.Name = "txtPeriodo";
            // 
            // 
            // 
            this.txtPeriodo.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtPeriodo.Size = new System.Drawing.Size(75, 20);
            this.txtPeriodo.TabIndex = 3;
            this.txtPeriodo.TabStop = false;
            this.txtPeriodo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeriodo.ThemeName = "VisualStudio2012Light";
            this.txtPeriodo.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.txtPeriodo.ValueChanged += new System.EventHandler(this.txtAño_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(132, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mes :";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(170, 34);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(220, 20);
            this.cboMes.TabIndex = 5;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // btnTransferirMarcaciones
            // 
            this.btnTransferirMarcaciones.Location = new System.Drawing.Point(436, 90);
            this.btnTransferirMarcaciones.Name = "btnTransferirMarcaciones";
            this.btnTransferirMarcaciones.Size = new System.Drawing.Size(144, 24);
            this.btnTransferirMarcaciones.TabIndex = 11;
            this.btnTransferirMarcaciones.Text = "Transferir Marcaciones";
            this.btnTransferirMarcaciones.ThemeName = "Windows8";
            this.btnTransferirMarcaciones.Click += new System.EventHandler(this.btnTransferirMarcaciones_Click);
            // 
            // btnTransferirUsuarios
            // 
            this.btnTransferirUsuarios.Location = new System.Drawing.Point(436, 49);
            this.btnTransferirUsuarios.Name = "btnTransferirUsuarios";
            this.btnTransferirUsuarios.Size = new System.Drawing.Size(144, 24);
            this.btnTransferirUsuarios.TabIndex = 10;
            this.btnTransferirUsuarios.Text = "Transferir Usuarios";
            this.btnTransferirUsuarios.ThemeName = "Windows8";
            this.btnTransferirUsuarios.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // pbTransferenciaInformacion
            // 
            this.pbTransferenciaInformacion.Location = new System.Drawing.Point(12, 144);
            this.pbTransferenciaInformacion.MarqueeAnimationSpeed = 25;
            this.pbTransferenciaInformacion.Name = "pbTransferenciaInformacion";
            this.pbTransferenciaInformacion.Size = new System.Drawing.Size(568, 19);
            this.pbTransferenciaInformacion.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbTransferenciaInformacion.TabIndex = 12;
            this.pbTransferenciaInformacion.Visible = false;
            // 
            // bgwHiloTransferenciaMarcaciones
            // 
            this.bgwHiloTransferenciaMarcaciones.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHiloTransferenciaMarcaciones_DoWork);
            this.bgwHiloTransferenciaMarcaciones.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHiloTransferenciaMarcaciones_RunWorkerCompleted);
            // 
            // bgwHiloTransferenciaUsuarios
            // 
            this.bgwHiloTransferenciaUsuarios.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHiloTransferenciaUsuarios_DoWork);
            this.bgwHiloTransferenciaUsuarios.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHiloTransferenciaUsuarios_RunWorkerCompleted);
            // 
            // bgwGenerarTareosDiarios
            // 
            this.bgwGenerarTareosDiarios.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGenerarTareosDiarios_DoWork);
            this.bgwGenerarTareosDiarios.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGenerarTareosDiarios_RunWorkerCompleted);
            // 
            // ProcesoTransferenciaMarcacionesDeBiometricoASistemaDeAsistencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(592, 164);
            this.Controls.Add(this.btnTransferirMarcaciones);
            this.Controls.Add(this.pbTransferenciaInformacion);
            this.Controls.Add(this.gbTransferencia);
            this.Controls.Add(this.btnTransferirUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcesoTransferenciaMarcacionesDeBiometricoASistemaDeAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transferencia de información de biométrico a sistema de asistencia";
            this.Load += new System.EventHandler(this.ProcesoTransferenciaMarcacionesDeBiometricoASistemaDeAsistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbTransferencia)).EndInit();
            this.gbTransferencia.ResumeLayout(false);
            this.gbTransferencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransferirMarcaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTransferirUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbTransferencia;
        private Telerik.WinControls.UI.RadButton btnTransferirUsuarios;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadSpinEditor txtPeriodo;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaHasta;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private System.Windows.Forms.ProgressBar pbTransferenciaInformacion;
        private System.ComponentModel.BackgroundWorker bgwHiloTransferenciaMarcaciones;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.UI.RadButton btnTransferirMarcaciones;
        private System.ComponentModel.BackgroundWorker bgwHiloTransferenciaUsuarios;
        private System.ComponentModel.BackgroundWorker bgwGenerarTareosDiarios;
    }
}