namespace Transportista
{
    partial class ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios));
            this.gbLongitudCreacionCodigos = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.txtAño = new Telerik.WinControls.UI.RadSpinEditor();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.txtFechaHasta = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.txtFechaDesde = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.btnSalir = new Telerik.WinControls.UI.RadButton();
            this.btnActualizar = new Telerik.WinControls.UI.RadButton();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gbLongitudCreacionCodigos)).BeginInit();
            this.gbLongitudCreacionCodigos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLongitudCreacionCodigos
            // 
            this.gbLongitudCreacionCodigos.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbLongitudCreacionCodigos.Controls.Add(this.radLabel7);
            this.gbLongitudCreacionCodigos.Controls.Add(this.txtAño);
            this.gbLongitudCreacionCodigos.Controls.Add(this.lblFechaHasta);
            this.gbLongitudCreacionCodigos.Controls.Add(this.txtFechaHasta);
            this.gbLongitudCreacionCodigos.Controls.Add(this.lblFechaDesde);
            this.gbLongitudCreacionCodigos.Controls.Add(this.txtFechaDesde);
            this.gbLongitudCreacionCodigos.Controls.Add(this.label5);
            this.gbLongitudCreacionCodigos.Controls.Add(this.cboMes);
            this.gbLongitudCreacionCodigos.HeaderText = "Actualizar y/o Sincronizar Asistencias";
            this.gbLongitudCreacionCodigos.Location = new System.Drawing.Point(1, 0);
            this.gbLongitudCreacionCodigos.Name = "gbLongitudCreacionCodigos";
            this.gbLongitudCreacionCodigos.Size = new System.Drawing.Size(336, 107);
            this.gbLongitudCreacionCodigos.TabIndex = 3;
            this.gbLongitudCreacionCodigos.Text = "Actualizar y/o Sincronizar Asistencias";
            this.gbLongitudCreacionCodigos.ThemeName = "Breeze";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(33, 21);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(32, 18);
            this.radLabel7.TabIndex = 212;
            this.radLabel7.Text = "Año :";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(26, 39);
            this.txtAño.Maximum = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            this.txtAño.Minimum = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.txtAño.Name = "txtAño";
            // 
            // 
            // 
            this.txtAño.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtAño.Size = new System.Drawing.Size(46, 20);
            this.txtAño.TabIndex = 211;
            this.txtAño.TabStop = false;
            this.txtAño.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAño.ThemeName = "Windows8";
            this.txtAño.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.txtAño.ValueChanged += new System.EventHandler(this.txtAño_ValueChanged);
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(223, 66);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(41, 13);
            this.lblFechaHasta.TabIndex = 206;
            this.lblFechaHasta.Text = "Hasta :";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(221, 81);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(91, 20);
            this.txtFechaHasta.TabIndex = 210;
            this.txtFechaHasta.TabStop = false;
            this.txtFechaHasta.Text = "__/__/____";
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaHasta.ThemeName = "VisualStudio2012Light";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(79, 66);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(44, 13);
            this.lblFechaDesde.TabIndex = 205;
            this.lblFechaDesde.Text = "Desde :";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(79, 81);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.MaskType = Telerik.WinControls.UI.MaskType.Standard;
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(89, 20);
            this.txtFechaDesde.TabIndex = 209;
            this.txtFechaDesde.TabStop = false;
            this.txtFechaDesde.Text = "__/__/____";
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ThemeName = "VisualStudio2012Light";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(135, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Mes :";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(78, 39);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(234, 20);
            this.cboMes.TabIndex = 208;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(237, 113);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(89, 25);
            this.btnSalir.TabIndex = 204;
            this.btnSalir.Text = "   Cerrar";
            this.btnSalir.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ThemeName = "Windows8";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(131, 113);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 25);
            this.btnActualizar.TabIndex = 203;
            this.btnActualizar.Text = "   &Actualizar";
            this.btnActualizar.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.ThemeName = "Windows8";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(340, 146);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.gbLongitudCreacionCodigos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proceso : Actualizar y/o Sincronizar Asistencias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcesoSincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios_FormClosing);
            this.Load += new System.EventHandler(this.SincronizarAsistenciasParaRealizarDescuentosPorAsistenciasARefrigerios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbLongitudCreacionCodigos)).EndInit();
            this.gbLongitudCreacionCodigos.ResumeLayout(false);
            this.gbLongitudCreacionCodigos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbLongitudCreacionCodigos;
        private Telerik.WinControls.UI.RadButton btnSalir;
        private Telerik.WinControls.UI.RadButton btnActualizar;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadSpinEditor txtAño;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.UI.RadMaskedEditBox txtFechaHasta;
        private System.Windows.Forms.Label lblFechaDesde;
        private Telerik.WinControls.UI.RadMaskedEditBox txtFechaDesde;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private System.ComponentModel.BackgroundWorker bgwHilo;
    }
}