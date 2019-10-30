namespace Transportista
{
    partial class ActualizarNombresColaboradorpostTrasnferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarNombresColaboradorpostTrasnferencia));
            this.gbProceso = new Telerik.WinControls.UI.RadGroupBox();
            this.txtSemana = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblSemana = new System.Windows.Forms.Label();
            this.txtFechaHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.btnActualizarNombres = new Telerik.WinControls.UI.RadButton();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtPeriodo = new Telerik.WinControls.UI.RadSpinEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.stsBarraEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progresbarProceso = new System.Windows.Forms.ToolStripProgressBar();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroResultados = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAvanceProceso = new System.Windows.Forms.ToolStripStatusLabel();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.bgwProceso = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gbProceso)).BeginInit();
            this.gbProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizarNombres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProceso
            // 
            this.gbProceso.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbProceso.Controls.Add(this.txtSemana);
            this.gbProceso.Controls.Add(this.lblSemana);
            this.gbProceso.Controls.Add(this.txtFechaHasta);
            this.gbProceso.Controls.Add(this.btnActualizarNombres);
            this.gbProceso.Controls.Add(this.txtFechaDesde);
            this.gbProceso.Controls.Add(this.txtPeriodo);
            this.gbProceso.Controls.Add(this.label1);
            this.gbProceso.Controls.Add(this.lblFechaDesde);
            this.gbProceso.Controls.Add(this.lblFechaHasta);
            this.gbProceso.Controls.Add(this.cboMes);
            this.gbProceso.Controls.Add(this.label5);
            this.gbProceso.HeaderText = "";
            this.gbProceso.Location = new System.Drawing.Point(0, 0);
            this.gbProceso.Name = "gbProceso";
            this.gbProceso.Size = new System.Drawing.Size(573, 99);
            this.gbProceso.TabIndex = 3;
            this.gbProceso.ThemeName = "Windows8";
            // 
            // txtSemana
            // 
            this.txtSemana.Location = new System.Drawing.Point(8, 71);
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
            this.txtSemana.TabIndex = 184;
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
            this.lblSemana.Location = new System.Drawing.Point(7, 54);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Size = new System.Drawing.Size(60, 13);
            this.lblSemana.TabIndex = 183;
            this.lblSemana.Text = "Semana :";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.EditingControlDataGridView = null;
            this.txtFechaHasta.EditingControlFormattedValue = "  /  /";
            this.txtFechaHasta.EditingControlRowIndex = 0;
            this.txtFechaHasta.EditingControlValueChanged = true;
            this.txtFechaHasta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaHasta.Location = new System.Drawing.Point(187, 70);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.P_EsEditable = false;
            this.txtFechaHasta.P_EsModificable = false;
            this.txtFechaHasta.P_ExigeInformacion = false;
            this.txtFechaHasta.P_Hora = null;
            this.txtFechaHasta.P_NombreColumna = null;
            this.txtFechaHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFechaHasta.Size = new System.Drawing.Size(83, 20);
            this.txtFechaHasta.TabIndex = 38;
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // btnActualizarNombres
            // 
            this.btnActualizarNombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarNombres.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarNombres.Image")));
            this.btnActualizarNombres.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarNombres.Location = new System.Drawing.Point(321, 57);
            this.btnActualizarNombres.Name = "btnActualizarNombres";
            this.btnActualizarNombres.Size = new System.Drawing.Size(235, 36);
            this.btnActualizarNombres.TabIndex = 44;
            this.btnActualizarNombres.Text = "   &Actualizar nombre de colaboradores";
            this.btnActualizarNombres.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarNombres.ThemeName = "Windows8";
            this.btnActualizarNombres.Click += new System.EventHandler(this.btnActualizarNombres_Click);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.EditingControlDataGridView = null;
            this.txtFechaDesde.EditingControlFormattedValue = "  /  /";
            this.txtFechaDesde.EditingControlRowIndex = 0;
            this.txtFechaDesde.EditingControlValueChanged = true;
            this.txtFechaDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaDesde.Location = new System.Drawing.Point(81, 70);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFechaDesde.Size = new System.Drawing.Size(83, 20);
            this.txtFechaDesde.TabIndex = 36;
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(8, 28);
            this.txtPeriodo.Maximum = new decimal(new int[] {
            2025,
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
            this.txtPeriodo.Size = new System.Drawing.Size(56, 20);
            this.txtPeriodo.TabIndex = 30;
            this.txtPeriodo.TabStop = false;
            this.txtPeriodo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeriodo.ThemeName = "Windows8";
            this.txtPeriodo.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.txtPeriodo.ValueChanged += new System.EventHandler(this.txtPeriodo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Año :";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(78, 55);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(51, 13);
            this.lblFechaDesde.TabIndex = 35;
            this.lblFechaDesde.Text = "Desde :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(184, 53);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(48, 13);
            this.lblFechaHasta.TabIndex = 37;
            this.lblFechaHasta.Text = "Hasta :";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(81, 28);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(265, 20);
            this.cboMes.TabIndex = 32;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(78, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Mes :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stsBarraEstado
            // 
            this.stsBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.progresbarProceso,
            this.ProgressBar,
            this.lblNumeroResultados,
            this.lblAvanceProceso});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 107);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.stsBarraEstado.Size = new System.Drawing.Size(578, 22);
            this.stsBarraEstado.TabIndex = 183;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // progresbarProceso
            // 
            this.progresbarProceso.MarqueeAnimationSpeed = 10;
            this.progresbarProceso.Name = "progresbarProceso";
            this.progresbarProceso.Size = new System.Drawing.Size(200, 17);
            this.progresbarProceso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progresbarProceso.Visible = false;
            // 
            // ProgressBar
            // 
            this.ProgressBar.MarqueeAnimationSpeed = 25;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(660, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
            // 
            // lblAvanceProceso
            // 
            this.lblAvanceProceso.Name = "lblAvanceProceso";
            this.lblAvanceProceso.Size = new System.Drawing.Size(0, 17);
            // 
            // bgwProceso
            // 
            this.bgwProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProceso_DoWork);
            this.bgwProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProceso_RunWorkerCompleted);
            // 
            // ActualizarNombresColaboradorpostTrasnferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 129);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.gbProceso);
            this.Name = "ActualizarNombresColaboradorpostTrasnferencia";
            this.Text = "Actualizar nombres de colaborador post transferencia";
            this.Load += new System.EventHandler(this.ActualizarNombresColaboradorpostTrasnferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbProceso)).EndInit();
            this.gbProceso.ResumeLayout(false);
            this.gbProceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizarNombres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbProceso;
        private Telerik.WinControls.UI.RadSpinEditor txtSemana;
        private System.Windows.Forms.Label lblSemana;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaHasta;
        private Telerik.WinControls.UI.RadButton btnActualizarNombres;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private Telerik.WinControls.UI.RadSpinEditor txtPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip stsBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar progresbarProceso;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroResultados;
        private System.Windows.Forms.ToolStripStatusLabel lblAvanceProceso;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private System.ComponentModel.BackgroundWorker bgwProceso;
    }
}