namespace Transportista
{
    partial class RutaBuscar
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.btnCancelar = new Telerik.WinControls.UI.RadButton();
            this.gbMovilidad = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvRutas = new Telerik.WinControls.UI.RadGridView();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
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
            this.btnCancelar.Location = new System.Drawing.Point(333, 442);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 24);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "TelerikMetro";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbMovilidad
            // 
            this.gbMovilidad.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbMovilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMovilidad.Controls.Add(this.dgvRutas);
            this.gbMovilidad.FooterImageIndex = -1;
            this.gbMovilidad.FooterImageKey = "";
            this.gbMovilidad.HeaderImageIndex = -1;
            this.gbMovilidad.HeaderImageKey = "";
            this.gbMovilidad.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.gbMovilidad.HeaderText = "Ruta por Unidad Móvil";
            this.gbMovilidad.Location = new System.Drawing.Point(1, 1);
            this.gbMovilidad.Name = "gbMovilidad";
            this.gbMovilidad.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.gbMovilidad.Size = new System.Drawing.Size(728, 432);
            this.gbMovilidad.TabIndex = 7;
            this.gbMovilidad.Text = "Ruta por Unidad Móvil";
            this.gbMovilidad.ThemeName = "Breeze";
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
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Id";
            gridViewTextBoxColumn7.HeaderText = "chIdRuta";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "chIdRuta";
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Item";
            gridViewTextBoxColumn8.HeaderText = "chItemRuta";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "chItemRuta";
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "IdRuta";
            gridViewTextBoxColumn9.HeaderText = "chCodRuta";
            gridViewTextBoxColumn9.Name = "chCodRuta";
            gridViewTextBoxColumn9.Width = 90;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "Ruta";
            gridViewTextBoxColumn10.HeaderText = "chDescripcionRuta";
            gridViewTextBoxColumn10.Name = "chDescripcionRuta";
            gridViewTextBoxColumn10.Width = 350;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "PrecioPersona";
            gridViewTextBoxColumn11.HeaderText = "S./ Precio Persona";
            gridViewTextBoxColumn11.Name = "chPrecioPersona";
            gridViewTextBoxColumn11.Width = 130;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "PrecioFlete";
            gridViewTextBoxColumn12.HeaderText = "S./ Precio Flete";
            gridViewTextBoxColumn12.Name = "chPrecioFlete";
            gridViewTextBoxColumn12.Width = 130;
            this.dgvRutas.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.dgvRutas.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvRutas.MasterTemplate.EnableFiltering = true;
            this.dgvRutas.MasterTemplate.EnableGrouping = false;
            this.dgvRutas.MasterTemplate.EnableSorting = false;
            this.dgvRutas.Name = "dgvRutas";
            this.dgvRutas.Padding = new System.Windows.Forms.Padding(1);
            this.dgvRutas.ReadOnly = true;
            this.dgvRutas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.dgvRutas.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.dgvRutas.Size = new System.Drawing.Size(724, 412);
            this.dgvRutas.TabIndex = 0;
            this.dgvRutas.Text = "Movilidades";
            this.dgvRutas.ThemeName = "Desert";
            this.dgvRutas.SelectionChanged += new System.EventHandler(this.MasterTemplate_SelectionChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(207, 441);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(106, 24);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ThemeName = "TelerikMetro";
            // 
            // RutaBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 467);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbMovilidad);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RutaBuscar";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ruta Buscar";
            this.ThemeName = "ControlDefault";
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
    }
}
