namespace Transportista
{
    partial class BuscarPension
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.gbPensiones = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvPension = new Telerik.WinControls.UI.RadGridView();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            ((System.ComponentModel.ISupportInitialize)(this.gbPensiones)).BeginInit();
            this.gbPensiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPension.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPensiones
            // 
            this.gbPensiones.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbPensiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPensiones.Controls.Add(this.dgvPension);
            this.gbPensiones.HeaderText = "";
            this.gbPensiones.Location = new System.Drawing.Point(-1, 0);
            this.gbPensiones.Name = "gbPensiones";
            this.gbPensiones.Padding = new System.Windows.Forms.Padding(2, 22, 2, 2);
            this.gbPensiones.Size = new System.Drawing.Size(534, 429);
            this.gbPensiones.TabIndex = 1;
            this.gbPensiones.ThemeName = "Windows8";
            // 
            // dgvPension
            // 
            this.dgvPension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgvPension.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPension.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvPension.ForeColor = System.Drawing.Color.Black;
            this.dgvPension.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvPension.Location = new System.Drawing.Point(2, 22);
            // 
            // dgvPension
            // 
            this.dgvPension.MasterTemplate.AllowAddNewRow = false;
            this.dgvPension.MasterTemplate.AutoGenerateColumns = false;
            this.dgvPension.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "IdPension";
            gridViewTextBoxColumn1.HeaderText = "IdPension";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "chIdPension";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "NroRuc";
            gridViewTextBoxColumn2.HeaderText = "Nro Ruc";
            gridViewTextBoxColumn2.Name = "chNroRuc";
            gridViewTextBoxColumn2.Width = 108;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "RazonSocial";
            gridViewTextBoxColumn3.HeaderText = "Razon Social";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "chRazonSocial";
            gridViewTextBoxColumn3.Width = 230;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "NroDNI";
            gridViewTextBoxColumn4.HeaderText = "Nro DNI";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "chNroDNI";
            gridViewTextBoxColumn4.Width = 74;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "NombresCompletos";
            gridViewTextBoxColumn5.HeaderText = "Nombres Completos";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "chNombresCompletos";
            gridViewTextBoxColumn5.Width = 137;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "IdEstado";
            gridViewTextBoxColumn6.HeaderText = "IdEstado";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "chIdEstado";
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "PseudoNombre";
            gridViewTextBoxColumn7.HeaderText = "Descripción";
            gridViewTextBoxColumn7.Name = "chPseudoNombre";
            gridViewTextBoxColumn7.Width = 405;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Estado";
            gridViewTextBoxColumn8.HeaderText = "Estado";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "chEstado";
            gridViewTextBoxColumn8.Width = 139;
            this.dgvPension.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.dgvPension.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvPension.MasterTemplate.EnableFiltering = true;
            this.dgvPension.Name = "dgvPension";
            this.dgvPension.ReadOnly = true;
            this.dgvPension.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPension.Size = new System.Drawing.Size(530, 405);
            this.dgvPension.TabIndex = 0;
            this.dgvPension.ThemeName = "VisualStudio2012Light";
            this.dgvPension.SelectionChanged += new System.EventHandler(this.dgvPension_SelectionChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(127, 432);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 24);
            this.btnAceptar.TabIndex = 28;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ThemeName = "Windows8";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(235, 432);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 24);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "Windows8";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BuscarPension
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(532, 457);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbPensiones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarPension";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "... Buscar Pensión ";
            this.ThemeName = "VisualStudio2012Light";
            this.Load += new System.EventHandler(this.PensionBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbPensiones)).EndInit();
            this.gbPensiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPension.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbPensiones;
        private Telerik.WinControls.UI.RadGridView dgvPension;
        private Telerik.WinControls.UI.RadButton btnAceptar;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
    }
}
