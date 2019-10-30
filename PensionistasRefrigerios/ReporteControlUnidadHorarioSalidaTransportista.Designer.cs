namespace Transportista
{
    partial class ReporteControlUnidadHorarioSalidaTransportista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteControlUnidadHorarioSalidaTransportista));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.gbCabecera = new Telerik.WinControls.UI.RadGroupBox();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.btnSalir = new Telerik.WinControls.UI.RadButton();
            this.btnImprimir = new Telerik.WinControls.UI.RadButton();
            this.btnVistaPrevia = new Telerik.WinControls.UI.RadButton();
            this.cboGarita = new Telerik.WinControls.UI.RadDropDownList();
            this.lblGarita = new Telerik.WinControls.UI.RadLabel();
            this.btnConsultar = new Telerik.WinControls.UI.RadButton();
            this.gbRegistros = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvAsistenciaPersonalAdm = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gbCabecera)).BeginInit();
            this.gbCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVistaPrevia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGarita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGarita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).BeginInit();
            this.gbRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaPersonalAdm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaPersonalAdm.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCabecera
            // 
            this.gbCabecera.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbCabecera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCabecera.Controls.Add(this.btnConsultar);
            this.gbCabecera.Controls.Add(this.txtFechaDesde);
            this.gbCabecera.Controls.Add(this.lblFechaDesde);
            this.gbCabecera.HeaderText = "Asignar fecha para impresión del reporte";
            this.gbCabecera.Location = new System.Drawing.Point(12, 12);
            this.gbCabecera.Name = "gbCabecera";
            this.gbCabecera.Size = new System.Drawing.Size(692, 82);
            this.gbCabecera.TabIndex = 0;
            this.gbCabecera.Text = "Asignar fecha para impresión del reporte";
            this.gbCabecera.ThemeName = "Windows8";
            this.gbCabecera.Click += new System.EventHandler(this.gbCabecera_Click);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.EditingControlDataGridView = null;
            this.txtFechaDesde.EditingControlFormattedValue = "  /  /";
            this.txtFechaDesde.EditingControlRowIndex = 0;
            this.txtFechaDesde.EditingControlValueChanged = true;
            this.txtFechaDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaDesde.Location = new System.Drawing.Point(73, 25);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaDesde.Size = new System.Drawing.Size(69, 20);
            this.txtFechaDesde.TabIndex = 186;
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(24, 28);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(43, 13);
            this.lblFechaDesde.TabIndex = 185;
            this.lblFechaDesde.Text = "Fecha :";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(610, 354);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(94, 36);
            this.btnSalir.TabIndex = 188;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.ThemeName = "Windows8";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(510, 354);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(94, 36);
            this.btnImprimir.TabIndex = 188;
            this.btnImprimir.Text = "   &Imprimir    ";
            this.btnImprimir.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.ThemeName = "Windows8";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVistaPrevia.Image = ((System.Drawing.Image)(resources.GetObject("btnVistaPrevia.Image")));
            this.btnVistaPrevia.Location = new System.Drawing.Point(400, 354);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(94, 36);
            this.btnVistaPrevia.TabIndex = 187;
            this.btnVistaPrevia.Text = "&Vista Previa  ";
            this.btnVistaPrevia.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVistaPrevia.ThemeName = "Windows8";
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // cboGarita
            // 
            this.cboGarita.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboGarita.Location = new System.Drawing.Point(86, 62);
            this.cboGarita.Name = "cboGarita";
            this.cboGarita.Size = new System.Drawing.Size(247, 20);
            this.cboGarita.TabIndex = 205;
            this.cboGarita.ThemeName = "VisualStudio2012Light";
            // 
            // lblGarita
            // 
            this.lblGarita.Location = new System.Drawing.Point(33, 65);
            this.lblGarita.Name = "lblGarita";
            this.lblGarita.Size = new System.Drawing.Size(42, 18);
            this.lblGarita.TabIndex = 204;
            this.lblGarita.Text = "Garita :";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(590, 45);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 25);
            this.btnConsultar.TabIndex = 189;
            this.btnConsultar.Text = "&Consultar ";
            this.btnConsultar.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.ThemeName = "Windows8";
            // 
            // gbRegistros
            // 
            this.gbRegistros.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRegistros.Controls.Add(this.dgvAsistenciaPersonalAdm);
            this.gbRegistros.HeaderText = "";
            this.gbRegistros.Location = new System.Drawing.Point(12, 100);
            this.gbRegistros.Name = "gbRegistros";
            this.gbRegistros.Size = new System.Drawing.Size(692, 248);
            this.gbRegistros.TabIndex = 206;
            this.gbRegistros.ThemeName = "VisualStudio2012Light";
            // 
            // dgvAsistenciaPersonalAdm
            // 
            this.dgvAsistenciaPersonalAdm.BackColor = System.Drawing.SystemColors.Control;
            this.dgvAsistenciaPersonalAdm.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvAsistenciaPersonalAdm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsistenciaPersonalAdm.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvAsistenciaPersonalAdm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvAsistenciaPersonalAdm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvAsistenciaPersonalAdm.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvAsistenciaPersonalAdm
            // 
            this.dgvAsistenciaPersonalAdm.MasterTemplate.AllowAddNewRow = false;
            this.dgvAsistenciaPersonalAdm.MasterTemplate.AutoGenerateColumns = false;
            this.dgvAsistenciaPersonalAdm.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "nroOrden";
            gridViewTextBoxColumn1.HeaderText = "Nro. orden";
            gridViewTextBoxColumn1.Name = "chnroOrden";
            gridViewTextBoxColumn1.Width = 66;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.ExcelExportFormatString = "{0:d}";
            gridViewDateTimeColumn1.ExcelExportType = Telerik.WinControls.UI.Export.DisplayFormatType.ShortDate;
            gridViewDateTimeColumn1.FieldName = "fecha";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            gridViewDateTimeColumn1.FormatString = "{0:d}";
            gridViewDateTimeColumn1.HeaderText = "Fecha";
            gridViewDateTimeColumn1.Name = "chfecha";
            gridViewDateTimeColumn1.Width = 54;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "categoriaMovilidad";
            gridViewTextBoxColumn2.HeaderText = "Categoría";
            gridViewTextBoxColumn2.Name = "chcategoriaMovilidad";
            gridViewTextBoxColumn2.Width = 120;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "transportista";
            gridViewTextBoxColumn3.HeaderText = "Empresa de Transporte";
            gridViewTextBoxColumn3.Name = "chtransportista";
            gridViewTextBoxColumn3.Width = 218;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "placa";
            gridViewTextBoxColumn4.HeaderText = "Placa";
            gridViewTextBoxColumn4.Name = "chplaca";
            gridViewTextBoxColumn4.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn4.Width = 91;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "puntoSalida";
            gridViewTextBoxColumn5.HeaderText = "Punto de Ingreso";
            gridViewTextBoxColumn5.Name = "chpuntoSalida";
            gridViewTextBoxColumn5.Width = 126;
            this.dgvAsistenciaPersonalAdm.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.dgvAsistenciaPersonalAdm.MasterTemplate.EnableAlternatingRowColor = true;
            this.dgvAsistenciaPersonalAdm.MasterTemplate.EnableFiltering = true;
            this.dgvAsistenciaPersonalAdm.MasterTemplate.MultiSelect = true;
            this.dgvAsistenciaPersonalAdm.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            sortDescriptor1.PropertyName = "chplaca";
            this.dgvAsistenciaPersonalAdm.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dgvAsistenciaPersonalAdm.Name = "dgvAsistenciaPersonalAdm";
            this.dgvAsistenciaPersonalAdm.ReadOnly = true;
            this.dgvAsistenciaPersonalAdm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvAsistenciaPersonalAdm.Size = new System.Drawing.Size(688, 228);
            this.dgvAsistenciaPersonalAdm.TabIndex = 17;
            this.dgvAsistenciaPersonalAdm.ThemeName = "VisualStudio2012Light";
            // 
            // ReporteControlUnidadHorarioSalidaTransportista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 400);
            this.Controls.Add(this.gbRegistros);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cboGarita);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblGarita);
            this.Controls.Add(this.btnVistaPrevia);
            this.Controls.Add(this.gbCabecera);
            this.Name = "ReporteControlUnidadHorarioSalidaTransportista";
            this.Text = "Reporte de control de unidades - Horario de salida de transportistas   ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteControlUnidadHorarioSalidaTransportista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbCabecera)).EndInit();
            this.gbCabecera.ResumeLayout(false);
            this.gbCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVistaPrevia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGarita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGarita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).EndInit();
            this.gbRegistros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaPersonalAdm.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaPersonalAdm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbCabecera;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private System.Windows.Forms.Label lblFechaDesde;
        private Telerik.WinControls.UI.RadButton btnImprimir;
        private Telerik.WinControls.UI.RadButton btnVistaPrevia;
        private Telerik.WinControls.UI.RadButton btnSalir;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.UI.RadDropDownList cboGarita;
        private Telerik.WinControls.UI.RadLabel lblGarita;
        private Telerik.WinControls.UI.RadButton btnConsultar;
        private Telerik.WinControls.UI.RadGroupBox gbRegistros;
        private Telerik.WinControls.UI.RadGridView dgvAsistenciaPersonalAdm;
    }
}