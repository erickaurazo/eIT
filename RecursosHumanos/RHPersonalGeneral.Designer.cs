namespace RecursosHumanos
{
    partial class RHPersonalGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RHPersonalGeneral));
            this.stsBarraEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPromedio = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecuento = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSumaSeleccionada = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroFilas = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbRegistros = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvRegistros = new Telerik.WinControls.UI.RadGridView();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtAño = new Telerik.WinControls.UI.RadSpinEditor();
            this.btnConsultar = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tsbMenu = new System.Windows.Forms.ToolStrip();
            this.BtnRRHH = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnAnular = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.ExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.stsBarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).BeginInit();
            this.gbRegistros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            this.tsbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsBarraEstado
            // 
            this.stsBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel6,
            this.lblPromedio,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel4,
            this.lblRecuento,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.lblSumaSeleccionada,
            this.toolStripStatusLabel7,
            this.progressBar,
            this.lblNumeroFilas});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 402);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(962, 22);
            this.stsBarraEstado.TabIndex = 193;
            this.stsBarraEstado.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel6.Text = "Promedio";
            // 
            // lblPromedio
            // 
            this.lblPromedio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(32, 17);
            this.lblPromedio.Text = "0.00";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel5.Text = "       ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel4.Text = "Recuento";
            // 
            // lblRecuento
            // 
            this.lblRecuento.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecuento.Name = "lblRecuento";
            this.lblRecuento.Size = new System.Drawing.Size(14, 17);
            this.lblRecuento.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel3.Text = "       ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel2.Text = "Suma";
            // 
            // lblSumaSeleccionada
            // 
            this.lblSumaSeleccionada.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumaSeleccionada.Name = "lblSumaSeleccionada";
            this.lblSumaSeleccionada.Size = new System.Drawing.Size(32, 17);
            this.lblSumaSeleccionada.Text = "0.00";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel7.Text = "     ";
            // 
            // progressBar
            // 
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // lblNumeroFilas
            // 
            this.lblNumeroFilas.Name = "lblNumeroFilas";
            this.lblNumeroFilas.Size = new System.Drawing.Size(145, 17);
            this.lblNumeroFilas.Text = "Se encontraron # registros";
            // 
            // gbRegistros
            // 
            this.gbRegistros.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRegistros.Controls.Add(this.dgvRegistros);
            this.gbRegistros.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbRegistros.HeaderText = "Registros";
            this.gbRegistros.Location = new System.Drawing.Point(5, 98);
            this.gbRegistros.Name = "gbRegistros";
            this.gbRegistros.Size = new System.Drawing.Size(945, 291);
            this.gbRegistros.TabIndex = 192;
            this.gbRegistros.Text = "Registros";
            this.gbRegistros.ThemeName = "VisualStudio2012Light";
            this.gbRegistros.Click += new System.EventHandler(this.gbRegistros_Click);
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.BackColor = System.Drawing.SystemColors.Control;
            this.dgvRegistros.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistros.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvRegistros.ForeColor = System.Drawing.Color.Black;
            this.dgvRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvRegistros.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvRegistros
            // 
            this.dgvRegistros.MasterTemplate.AllowAddNewRow = false;
            this.dgvRegistros.MasterTemplate.AutoGenerateColumns = false;
            this.dgvRegistros.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistros.MasterTemplate.EnableFiltering = true;
            this.dgvRegistros.MasterTemplate.MultiSelect = true;
            this.dgvRegistros.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dgvRegistros.Name = "dgvRegistros";
            this.dgvRegistros.ReadOnly = true;
            this.dgvRegistros.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvRegistros.Size = new System.Drawing.Size(941, 271);
            this.dgvRegistros.TabIndex = 0;
            this.dgvRegistros.ThemeName = "VisualStudio2012Light";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.txtAño);
            this.radGroupBox1.Controls.Add(this.btnConsultar);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Configuracion del Filtro";
            this.radGroupBox1.Location = new System.Drawing.Point(5, 38);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(945, 58);
            this.radGroupBox1.TabIndex = 191;
            this.radGroupBox1.Text = "Configuracion del Filtro";
            this.radGroupBox1.ThemeName = "VisualStudio2012Light";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(40, 29);
            this.txtAño.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.txtAño.Name = "txtAño";
            // 
            // 
            // 
            this.txtAño.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtAño.Size = new System.Drawing.Size(46, 20);
            this.txtAño.TabIndex = 187;
            this.txtAño.TabStop = false;
            this.txtAño.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAño.ThemeName = "Windows8";
            this.txtAño.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(92, 23);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 29);
            this.btnConsultar.TabIndex = 178;
            this.btnConsultar.Text = "&Consultar ";
            this.btnConsultar.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.ThemeName = "Windows8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 184;
            this.label1.Text = "Año :";
            // 
            // tsbMenu
            // 
            this.tsbMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.tsbMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsbMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnRRHH,
            this.toolStripSeparator1,
            this.btnNuevo,
            this.btnEditar,
            this.btnAnular,
            this.btnEliminar,
            this.ExportarExcel,
            this.tsbSalir});
            this.tsbMenu.Location = new System.Drawing.Point(0, 0);
            this.tsbMenu.Name = "tsbMenu";
            this.tsbMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsbMenu.Size = new System.Drawing.Size(627, 38);
            this.tsbMenu.TabIndex = 190;
            // 
            // BtnRRHH
            // 
            this.BtnRRHH.Image = ((System.Drawing.Image)(resources.GetObject("BtnRRHH.Image")));
            this.BtnRRHH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRRHH.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnRRHH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRRHH.Name = "BtnRRHH";
            this.BtnRRHH.Size = new System.Drawing.Size(108, 35);
            this.BtnRRHH.Text = "   RR.HH.          ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnNuevo
            // 
            this.btnNuevo.AutoSize = false;
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(85, 35);
            this.btnNuevo.Text = "Nuevo";
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = false;
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(85, 35);
            this.btnEditar.Text = "Editar";
            // 
            // btnAnular
            // 
            this.btnAnular.AutoSize = false;
            this.btnAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAnular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(85, 35);
            this.btnAnular.Text = "toolStripButton5";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = false;
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(85, 35);
            this.btnEliminar.Text = "Eliminar";
            // 
            // ExportarExcel
            // 
            this.ExportarExcel.AutoSize = false;
            this.ExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("ExportarExcel.Image")));
            this.ExportarExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportarExcel.Name = "ExportarExcel";
            this.ExportarExcel.Size = new System.Drawing.Size(85, 35);
            this.ExportarExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ExportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbSalir
            // 
            this.tsbSalir.AutoSize = false;
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(85, 35);
            this.tsbSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // RHPersonalGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 424);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.gbRegistros);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.tsbMenu);
            this.Name = "RHPersonalGeneral";
            this.Text = "Listado de Personal General";
            this.Load += new System.EventHandler(this.RHPersonalGeneral_Load);
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbRegistros)).EndInit();
            this.gbRegistros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            this.tsbMenu.ResumeLayout(false);
            this.tsbMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblPromedio;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblRecuento;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblSumaSeleccionada;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroFilas;
        private Telerik.WinControls.UI.RadGroupBox gbRegistros;
        private Telerik.WinControls.UI.RadGridView dgvRegistros;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private System.ComponentModel.BackgroundWorker bgwHilo;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadSpinEditor txtAño;
        private Telerik.WinControls.UI.RadButton btnConsultar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStrip tsbMenu;
        private System.Windows.Forms.ToolStripButton BtnRRHH;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnAnular;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton ExportarExcel;
        private System.Windows.Forms.ToolStripButton tsbSalir;
    }
}