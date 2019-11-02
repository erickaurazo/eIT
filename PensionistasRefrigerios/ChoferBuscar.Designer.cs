namespace Asistencia
{
    partial class ChoferBuscar
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoferBuscar));
            this.gbMovilidad = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvChofer = new Telerik.WinControls.UI.RadGridView();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            ((System.ComponentModel.ISupportInitialize)(this.gbMovilidad)).BeginInit();
            this.gbMovilidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChofer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChofer.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMovilidad
            // 
            this.gbMovilidad.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbMovilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMovilidad.Controls.Add(this.dgvChofer);
            this.gbMovilidad.HeaderText = "Listado de Choferes";
            this.gbMovilidad.Location = new System.Drawing.Point(0, 0);
            this.gbMovilidad.Name = "gbMovilidad";
            this.gbMovilidad.Size = new System.Drawing.Size(733, 432);
            this.gbMovilidad.TabIndex = 8;
            this.gbMovilidad.Text = "Listado de Choferes";
            this.gbMovilidad.ThemeName = "VisualStudio2012Light";
            // 
            // dgvChofer
            // 
            this.dgvChofer.BackColor = System.Drawing.Color.White;
            this.dgvChofer.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvChofer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChofer.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvChofer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvChofer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvChofer.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvChofer
            // 
            this.dgvChofer.MasterTemplate.AllowAddNewRow = false;
            this.dgvChofer.MasterTemplate.AllowColumnReorder = false;
            this.dgvChofer.MasterTemplate.AutoGenerateColumns = false;
            this.dgvChofer.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "chId";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "DNI";
            gridViewTextBoxColumn2.HeaderText = "DNI";
            gridViewTextBoxColumn2.Name = "chDNI";
            gridViewTextBoxColumn2.Width = 123;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Nombres";
            gridViewTextBoxColumn3.HeaderText = "Nombres";
            gridViewTextBoxColumn3.Name = "chNombres";
            gridViewTextBoxColumn3.Width = 418;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "TipoLicencia";
            gridViewTextBoxColumn4.HeaderText = "Licencia";
            gridViewTextBoxColumn4.Name = "chTipoLicencia";
            gridViewTextBoxColumn4.Width = 170;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "IdTransportista";
            gridViewTextBoxColumn5.HeaderText = "IdTransportista";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "chIdTransportista";
            gridViewTextBoxColumn5.Width = 47;
            this.dgvChofer.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.dgvChofer.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvChofer.MasterTemplate.EnableFiltering = true;
            this.dgvChofer.MasterTemplate.EnableGrouping = false;
            this.dgvChofer.MasterTemplate.EnableSorting = false;
            this.dgvChofer.Name = "dgvChofer";
            this.dgvChofer.Padding = new System.Windows.Forms.Padding(1);
            this.dgvChofer.ReadOnly = true;
            this.dgvChofer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvChofer.Size = new System.Drawing.Size(729, 412);
            this.dgvChofer.TabIndex = 0;
            this.dgvChofer.Text = "Choferes";
            this.dgvChofer.ThemeName = "VisualStudio2012Light";
            this.dgvChofer.SelectionChanged += new System.EventHandler(this.dgvChofer_SelectionChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(338, 435);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 24);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "Windows8";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(209, 435);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(106, 24);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ThemeName = "Windows8";
            // 
            // ChoferBuscar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(738, 460);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbMovilidad);
            this.Controls.Add(this.btnAceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChoferBuscar";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "... Buscar Chofer";
            this.ThemeName = "VisualStudio2012Light";
            this.Load += new System.EventHandler(this.ChoferBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbMovilidad)).EndInit();
            this.gbMovilidad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChofer.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChofer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbMovilidad;
        private Telerik.WinControls.UI.RadGridView dgvChofer;
        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadButton btnAceptar;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
    }
}
