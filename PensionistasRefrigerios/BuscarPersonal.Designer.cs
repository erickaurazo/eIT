namespace Transportista
{
    partial class BuscarPersonal
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.gbPensiones = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvPersonalGeneral = new Telerik.WinControls.UI.RadGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbPensiones)).BeginInit();
            this.gbPensiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalGeneral.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(438, 394);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 24);
            this.btnAceptar.TabIndex = 31;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ThemeName = "Windows8";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(330, 394);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 24);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "Windows8";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbPensiones
            // 
            this.gbPensiones.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbPensiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPensiones.Controls.Add(this.dgvPersonalGeneral);
            this.gbPensiones.HeaderText = "Personal General";
            this.gbPensiones.Location = new System.Drawing.Point(0, 0);
            this.gbPensiones.Name = "gbPensiones";
            this.gbPensiones.Padding = new System.Windows.Forms.Padding(2, 22, 2, 2);
            this.gbPensiones.Size = new System.Drawing.Size(813, 388);
            this.gbPensiones.TabIndex = 29;
            this.gbPensiones.Text = "Personal General";
            this.gbPensiones.ThemeName = "Windows8";
            // 
            // dgvPersonalGeneral
            // 
            this.dgvPersonalGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dgvPersonalGeneral.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPersonalGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonalGeneral.EnableHotTracking = false;
            this.dgvPersonalGeneral.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvPersonalGeneral.ForeColor = System.Drawing.Color.Black;
            this.dgvPersonalGeneral.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvPersonalGeneral.Location = new System.Drawing.Point(2, 22);
            // 
            // dgvPersonalGeneral
            // 
            this.dgvPersonalGeneral.MasterTemplate.AllowAddNewRow = false;
            this.dgvPersonalGeneral.MasterTemplate.AllowColumnReorder = false;
            this.dgvPersonalGeneral.MasterTemplate.AutoGenerateColumns = false;
            this.dgvPersonalGeneral.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "IdCodigoPersonal";
            gridViewTextBoxColumn7.HeaderText = "Código Personal";
            gridViewTextBoxColumn7.Name = "chIdCodigoPersonal";
            gridViewTextBoxColumn7.Width = 129;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "NRODocumento";
            gridViewTextBoxColumn8.HeaderText = "DNI";
            gridViewTextBoxColumn8.Name = "chNRODocumento";
            gridViewTextBoxColumn8.Width = 97;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "NombresTrabajador";
            gridViewTextBoxColumn9.HeaderText = "Nombres Trabajador";
            gridViewTextBoxColumn9.Name = "chNombresTrabajador";
            gridViewTextBoxColumn9.Width = 279;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "IdSubPlanilla";
            gridViewTextBoxColumn10.HeaderText = "IdSubPlanilla";
            gridViewTextBoxColumn10.IsVisible = false;
            gridViewTextBoxColumn10.Name = "chIdSubPlanilla";
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "SubPlanilla";
            gridViewTextBoxColumn11.HeaderText = "SubPlanilla";
            gridViewTextBoxColumn11.Name = "chSubPlanilla";
            gridViewTextBoxColumn11.Width = 161;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "Condicion";
            gridViewTextBoxColumn12.HeaderText = "Condición";
            gridViewTextBoxColumn12.Name = "chCondicion";
            gridViewTextBoxColumn12.Width = 129;
            this.dgvPersonalGeneral.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.dgvPersonalGeneral.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvPersonalGeneral.MasterTemplate.EnableFiltering = true;
            this.dgvPersonalGeneral.MasterTemplate.EnableGrouping = false;
            this.dgvPersonalGeneral.MasterTemplate.EnableSorting = false;
            this.dgvPersonalGeneral.Name = "dgvPersonalGeneral";
            this.dgvPersonalGeneral.ReadOnly = true;
            this.dgvPersonalGeneral.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPersonalGeneral.ShowGroupPanel = false;
            this.dgvPersonalGeneral.Size = new System.Drawing.Size(809, 364);
            this.dgvPersonalGeneral.TabIndex = 0;
            this.dgvPersonalGeneral.ThemeName = "VisualStudio2012Light";
            this.dgvPersonalGeneral.SelectionChanged += new System.EventHandler(this.dgvPersonalGeneral_SelectionChanged);
            // 
            // BuscarPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(815, 419);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbPensiones);
            this.Name = "BuscarPersonal";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "... Buscar Personal";
            this.ThemeName = "VisualStudio2012Light";
            this.Load += new System.EventHandler(this.PersonalBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbPensiones)).EndInit();
            this.gbPensiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalGeneral.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnAceptar;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadGroupBox gbPensiones;
        private Telerik.WinControls.UI.RadGridView dgvPersonalGeneral;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
    }
}
