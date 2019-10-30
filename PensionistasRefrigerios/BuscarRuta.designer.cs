namespace Transportista
{
    partial class BuscarRuta
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.gbMovilidad = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvRutas = new Telerik.WinControls.UI.RadGridView();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMovilidad)).BeginInit();
            this.gbMovilidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(388, 348);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 24);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "Windows8";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbMovilidad
            // 
            this.gbMovilidad.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbMovilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMovilidad.Controls.Add(this.dgvRutas);
            this.gbMovilidad.HeaderText = "Ruta por Unidad Móvil";
            this.gbMovilidad.Location = new System.Drawing.Point(0, 0);
            this.gbMovilidad.Name = "gbMovilidad";
            this.gbMovilidad.Size = new System.Drawing.Size(828, 341);
            this.gbMovilidad.TabIndex = 7;
            this.gbMovilidad.Text = "Ruta por Unidad Móvil";
            this.gbMovilidad.ThemeName = "VisualStudio2012Light";
            // 
            // dgvRutas
            // 
            this.dgvRutas.BackColor = System.Drawing.Color.White;
            this.dgvRutas.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvRutas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRutas.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvRutas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvRutas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvRutas.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvRutas
            // 
            this.dgvRutas.MasterTemplate.AllowAddNewRow = false;
            this.dgvRutas.MasterTemplate.AllowColumnReorder = false;
            this.dgvRutas.MasterTemplate.AutoGenerateColumns = false;
            this.dgvRutas.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "chIdRuta";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "chIdRuta";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Item";
            gridViewTextBoxColumn2.HeaderText = "chItemRuta";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "chItemRuta";
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "IdRuta";
            gridViewTextBoxColumn3.HeaderText = "Cod. Ruta";
            gridViewTextBoxColumn3.Name = "chCodRuta";
            gridViewTextBoxColumn3.Width = 94;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Ruta";
            gridViewTextBoxColumn4.HeaderText = "Ruta";
            gridViewTextBoxColumn4.Name = "chDescripcionRuta";
            gridViewTextBoxColumn4.Width = 365;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "PrecioPersona";
            gridViewTextBoxColumn5.HeaderText = "S./ Precio Persona";
            gridViewTextBoxColumn5.Name = "chPrecioPersona";
            gridViewTextBoxColumn5.Width = 135;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "PrecioFlete";
            gridViewTextBoxColumn6.HeaderText = "S./ Precio Flete";
            gridViewTextBoxColumn6.Name = "chPrecioFlete";
            gridViewTextBoxColumn6.Width = 135;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "PrecioVuelta";
            gridViewTextBoxColumn7.HeaderText = "Precio Vuelta";
            gridViewTextBoxColumn7.Name = "chPrecioVuelta";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 79;
            this.dgvRutas.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.dgvRutas.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvRutas.MasterTemplate.EnableFiltering = true;
            this.dgvRutas.MasterTemplate.EnableGrouping = false;
            this.dgvRutas.MasterTemplate.EnableSorting = false;
            this.dgvRutas.Name = "dgvRutas";
            this.dgvRutas.Padding = new System.Windows.Forms.Padding(1);
            this.dgvRutas.ReadOnly = true;
            this.dgvRutas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvRutas.Size = new System.Drawing.Size(824, 321);
            this.dgvRutas.TabIndex = 0;
            this.dgvRutas.Text = "Movilidades";
            this.dgvRutas.ThemeName = "VisualStudio2012Light";
            this.dgvRutas.SelectionChanged += new System.EventHandler(this.MasterTemplate_SelectionChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(263, 347);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(106, 24);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ThemeName = "Windows8";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // BuscarRuta
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(834, 372);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbMovilidad);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuscarRuta";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ruta Buscar";
            this.ThemeName = "VisualStudio2012Light";
            this.Load += new System.EventHandler(this.RutaBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMovilidad)).EndInit();
            this.gbMovilidad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadGroupBox gbMovilidad;
        private Telerik.WinControls.UI.RadGridView dgvRutas;
        private Telerik.WinControls.UI.RadButton btnAceptar;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
    }
}
