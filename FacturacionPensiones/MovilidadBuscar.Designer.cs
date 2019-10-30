namespace Transportista
{
    partial class MovilidadBuscar
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
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.gbMovilidad = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvTransportista = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMovilidad)).BeginInit();
            this.gbMovilidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportista.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(416, 440);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 24);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ThemeName = "TelerikMetro";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(295, 440);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(106, 24);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ThemeName = "TelerikMetro";
            // 
            // gbMovilidad
            // 
            this.gbMovilidad.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbMovilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMovilidad.Controls.Add(this.dgvTransportista);
            this.gbMovilidad.FooterImageIndex = -1;
            this.gbMovilidad.FooterImageKey = "";
            this.gbMovilidad.HeaderImageIndex = -1;
            this.gbMovilidad.HeaderImageKey = "";
            this.gbMovilidad.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.gbMovilidad.HeaderText = "Detalle";
            this.gbMovilidad.Location = new System.Drawing.Point(2, 4);
            this.gbMovilidad.Name = "gbMovilidad";
            this.gbMovilidad.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.gbMovilidad.Size = new System.Drawing.Size(776, 430);
            this.gbMovilidad.TabIndex = 4;
            this.gbMovilidad.Text = "Detalle";
            this.gbMovilidad.ThemeName = "Breeze";
            // 
            // dgvTransportista
            // 
            this.dgvTransportista.BackColor = System.Drawing.Color.White;
            this.dgvTransportista.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvTransportista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransportista.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvTransportista.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvTransportista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvTransportista.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvTransportista
            // 
            this.dgvTransportista.MasterTemplate.AllowAddNewRow = false;
            this.dgvTransportista.MasterTemplate.AllowColumnReorder = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "IdMovilidad";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "chIdMovilidad";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Placa";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Placa";
            gridViewTextBoxColumn2.Name = "chPlaca";
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "TipoMovilidad";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Tipo Movilidad";
            gridViewTextBoxColumn3.Name = "chTipoMovilidad";
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "PseudoNombre";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "PseudoNombre";
            gridViewTextBoxColumn4.Name = "chPseudoNombre";
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Ruc";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "Ruc";
            gridViewTextBoxColumn5.Name = "chRuc";
            gridViewTextBoxColumn5.Width = 90;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "RazonSocial";
            gridViewTextBoxColumn6.FormatString = "";
            gridViewTextBoxColumn6.HeaderText = "Razón Social";
            gridViewTextBoxColumn6.Name = "chRazonSocial";
            gridViewTextBoxColumn6.Width = 230;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "NumeroAsientos";
            gridViewTextBoxColumn7.HeaderText = "Nro Asientos";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "chNroAsientos";
            this.dgvTransportista.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.dgvTransportista.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvTransportista.MasterTemplate.EnableFiltering = true;
            this.dgvTransportista.MasterTemplate.EnableGrouping = false;
            this.dgvTransportista.MasterTemplate.EnableSorting = false;
            this.dgvTransportista.Name = "dgvTransportista";
            this.dgvTransportista.Padding = new System.Windows.Forms.Padding(1);
            this.dgvTransportista.ReadOnly = true;
            this.dgvTransportista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.dgvTransportista.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.dgvTransportista.Size = new System.Drawing.Size(772, 410);
            this.dgvTransportista.TabIndex = 0;
            this.dgvTransportista.Text = "Movilidades";
            this.dgvTransportista.ThemeName = "Desert";
            this.dgvTransportista.SelectionChanged += new System.EventHandler(this.MasterTemplate_SelectionChanged);
            // 
            // MovilidadBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(781, 466);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbMovilidad);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovilidadBuscar";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "MovilidadBuscar";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.MovilidadBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMovilidad)).EndInit();
            this.gbMovilidad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportista.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancelar;
        private Telerik.WinControls.UI.RadButton btnAceptar;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.RadGroupBox gbMovilidad;
        private Telerik.WinControls.UI.RadGridView dgvTransportista;
    }
}
