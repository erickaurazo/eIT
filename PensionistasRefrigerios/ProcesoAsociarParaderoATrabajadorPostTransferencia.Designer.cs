namespace Transportista
{
    partial class ProcesoAsociarParaderoATrabajadorPostTransferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesoAsociarParaderoATrabajadorPostTransferencia));
            this.gbFiltro = new Telerik.WinControls.UI.RadGroupBox();
            this.pgProceso = new System.Windows.Forms.ProgressBar();
            this.btnProgramarExclusion = new Telerik.WinControls.UI.RadButton();
            this.txtFechaHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtPeriodo = new Telerik.WinControls.UI.RadSpinEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.bgwSubProceso = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gbFiltro)).BeginInit();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProgramarExclusion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltro
            // 
            this.gbFiltro.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbFiltro.Controls.Add(this.pgProceso);
            this.gbFiltro.Controls.Add(this.btnProgramarExclusion);
            this.gbFiltro.Controls.Add(this.txtFechaHasta);
            this.gbFiltro.Controls.Add(this.txtFechaDesde);
            this.gbFiltro.Controls.Add(this.txtPeriodo);
            this.gbFiltro.Controls.Add(this.label1);
            this.gbFiltro.Controls.Add(this.lblFechaDesde);
            this.gbFiltro.Controls.Add(this.lblFechaHasta);
            this.gbFiltro.Controls.Add(this.cboMes);
            this.gbFiltro.Controls.Add(this.label5);
            this.gbFiltro.HeaderText = "Proceso ...";
            this.gbFiltro.Location = new System.Drawing.Point(5, 3);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(615, 99);
            this.gbFiltro.TabIndex = 1;
            this.gbFiltro.Text = "Proceso ...";
            this.gbFiltro.ThemeName = "VisualStudio2012Light";
            // 
            // pgProceso
            // 
            this.pgProceso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pgProceso.Location = new System.Drawing.Point(391, 28);
            this.pgProceso.MarqueeAnimationSpeed = 25;
            this.pgProceso.Name = "pgProceso";
            this.pgProceso.Size = new System.Drawing.Size(218, 23);
            this.pgProceso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgProceso.TabIndex = 45;
            this.pgProceso.Visible = false;
            // 
            // btnProgramarExclusion
            // 
            this.btnProgramarExclusion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProgramarExclusion.Image = ((System.Drawing.Image)(resources.GetObject("btnProgramarExclusion.Image")));
            this.btnProgramarExclusion.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProgramarExclusion.Location = new System.Drawing.Point(392, 58);
            this.btnProgramarExclusion.Name = "btnProgramarExclusion";
            this.btnProgramarExclusion.Size = new System.Drawing.Size(218, 36);
            this.btnProgramarExclusion.TabIndex = 44;
            this.btnProgramarExclusion.Text = "   &Asociar paraderos a transferencia";
            this.btnProgramarExclusion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgramarExclusion.ThemeName = "VisualStudio2012Light";
            this.btnProgramarExclusion.Click += new System.EventHandler(this.btnProgramarExclusion_Click);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.EditingControlDataGridView = null;
            this.txtFechaHasta.EditingControlFormattedValue = "  /  /";
            this.txtFechaHasta.EditingControlRowIndex = 0;
            this.txtFechaHasta.EditingControlValueChanged = true;
            this.txtFechaHasta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaHasta.Location = new System.Drawing.Point(293, 72);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.P_EsEditable = false;
            this.txtFechaHasta.P_EsModificable = false;
            this.txtFechaHasta.P_ExigeInformacion = false;
            this.txtFechaHasta.P_Hora = null;
            this.txtFechaHasta.P_NombreColumna = null;
            this.txtFechaHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFechaHasta.Size = new System.Drawing.Size(77, 20);
            this.txtFechaHasta.TabIndex = 38;
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.EditingControlDataGridView = null;
            this.txtFechaDesde.EditingControlFormattedValue = "  /  /";
            this.txtFechaDesde.EditingControlRowIndex = 0;
            this.txtFechaDesde.EditingControlValueChanged = true;
            this.txtFechaDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaDesde.Location = new System.Drawing.Point(141, 72);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Fecha;
            this.txtFechaDesde.Size = new System.Drawing.Size(73, 20);
            this.txtFechaDesde.TabIndex = 36;
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(41, 28);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Año :";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(91, 76);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(44, 13);
            this.lblFechaDesde.TabIndex = 35;
            this.lblFechaDesde.Text = "Desde :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(247, 76);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(41, 13);
            this.lblFechaHasta.TabIndex = 37;
            this.lblFechaHasta.Text = "Hasta :";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(105, 46);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(265, 20);
            this.cboMes.TabIndex = 32;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Mes :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bgwSubProceso
            // 
            this.bgwSubProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSubProceso_DoWork);
            this.bgwSubProceso.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSubProceso_ProgressChanged);
            this.bgwSubProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSubProceso_RunWorkerCompleted);
            // 
            // ProcesoAsociarParaderoATrabajadorPostTransferencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(626, 114);
            this.Controls.Add(this.gbFiltro);
            this.Name = "ProcesoAsociarParaderoATrabajadorPostTransferencia";
            this.Text = "Proceso asociar paradero al trabajador post transferencia";
            this.Load += new System.EventHandler(this.ProcesoAsociarParaderoATrabajadorPostTransferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbFiltro)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProgramarExclusion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbFiltro;
        private Telerik.WinControls.UI.RadButton btnProgramarExclusion;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaHasta;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private Telerik.WinControls.UI.RadSpinEditor txtPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private System.Windows.Forms.ProgressBar pgProceso;
        private System.ComponentModel.BackgroundWorker bgwSubProceso;
    }
}