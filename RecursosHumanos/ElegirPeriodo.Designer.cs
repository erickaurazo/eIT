namespace RecursosHumanos
{
    partial class ElegirPeriodo
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.txtAño = new Telerik.WinControls.UI.RadSpinEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnAceptar);
            this.radGroupBox1.Controls.Add(this.radLabel7);
            this.radGroupBox1.Controls.Add(this.txtAño);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.Controls.Add(this.cboMes);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Elegir periodo de trabajo";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(391, 99);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Elegir periodo de trabajo";
            this.radGroupBox1.ThemeName = "VisualStudio2012Light";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(259, 70);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 24);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ThemeName = "VisualStudio2012Light";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(39, 35);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(32, 18);
            this.radLabel7.TabIndex = 6;
            this.radLabel7.Text = "Año :";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(75, 34);
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
            this.txtAño.TabIndex = 7;
            this.txtAño.TabStop = false;
            this.txtAño.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAño.ThemeName = "Windows8";
            this.txtAño.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(130, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mes :";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(168, 34);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(201, 20);
            this.cboMes.TabIndex = 9;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // ElegirPeriodo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(417, 134);
            this.Controls.Add(this.radGroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ElegirPeriodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Elegir Periodo";
            this.Load += new System.EventHandler(this.ElegirPeriodo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadSpinEditor txtAño;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private Telerik.WinControls.UI.RadButton btnAceptar;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
    }
}