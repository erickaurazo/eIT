namespace Transportista
{
    partial class BuscarPersonalMarcaAsistencia
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.dgvRegistros = new Telerik.WinControls.UI.RadGridView();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.BackColor = System.Drawing.SystemColors.Control;
            this.dgvRegistros.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistros.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvRegistros.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvRegistros.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.MasterTemplate.AllowAddNewRow = false;
            this.dgvRegistros.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "codigoPersonal";
            gridViewTextBoxColumn1.HeaderText = "Cod. Mar.";
            gridViewTextBoxColumn1.Name = "chcodigoMarcacion";
            gridViewTextBoxColumn1.Width = 57;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "NroDocumento";
            gridViewTextBoxColumn2.HeaderText = "Nro Doc.";
            gridViewTextBoxColumn2.Name = "chNroDocumento";
            gridViewTextBoxColumn2.Width = 80;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "personal";
            gridViewTextBoxColumn3.HeaderText = "Trabajador";
            gridViewTextBoxColumn3.Name = "chNombres";
            gridViewTextBoxColumn3.Width = 272;
            this.dgvRegistros.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.dgvRegistros.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvRegistros.MasterTemplate.EnableFiltering = true;
            this.dgvRegistros.MasterTemplate.ShowGroupedColumns = true;
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvRegistros.Size = new System.Drawing.Size(425, 376);
            this.dgvRegistros.TabIndex = 0;
            this.dgvRegistros.ThemeName = "VisualStudio2012Light";
            this.dgvRegistros.SelectionChanged += new System.EventHandler(this.dgvRegistros_SelectionChanged);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.dgvRegistros);
            this.radGroupBox1.HeaderText = "Listado de Personal";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(429, 396);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Listado de Personal";
            this.radGroupBox1.ThemeName = "VisualStudio2012Light";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(108, 405);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 24);
            this.btnAceptar.TabIndex = 30;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ThemeName = "Windows8";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(216, 405);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 24);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "Windows8";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BuscarPersonalMarcaAsistencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(435, 435);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BuscarPersonalMarcaAsistencia";
            this.Text = "Buscar Personal Administrativo que Marca Asistencia";
            this.Load += new System.EventHandler(this.BuscarPersonalMarcaAsistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dgvRegistros;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnAceptar;
        private Telerik.WinControls.UI.RadButton btnCancelar;
    }
}