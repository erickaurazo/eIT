namespace Transportista
{
    partial class PagoCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagoCaja));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnAnular = new Telerik.WinControls.UI.CommandBarButton();
            this.btnExportar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnAtras = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.gbConsulta = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.txtAño = new Telerik.WinControls.UI.RadSpinEditor();
            this.cboMeses = new Telerik.WinControls.UI.RadDropDownList();
            this.label3 = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
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
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTiempoTranscurrido = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroResultados = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).BeginInit();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.radCommandBar1.Size = new System.Drawing.Size(949, 32);
            this.radCommandBar1.TabIndex = 162;
            this.radCommandBar1.ThemeName = "VisualStudio2012Light";
            // 
            // BarraSuperior
            // 
            this.BarraSuperior.BackColor = System.Drawing.SystemColors.Control;
            this.BarraSuperior.MinSize = new System.Drawing.Size(25, 25);
            this.BarraSuperior.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.BarraModulo,
            this.commandBarStripElement3});
            this.BarraSuperior.Text = "";
            // 
            // BarraModulo
            // 
            this.BarraModulo.DisplayName = "commandBarStripElement2";
            this.BarraModulo.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnRRHH});
            this.BarraModulo.Name = "commandBarStripElement2";
            this.BarraModulo.Text = "";
            // 
            // btnRRHH
            // 
            this.btnRRHH.AccessibleDescription = "RecursosHumanos";
            this.btnRRHH.AccessibleName = "RecursosHumanos";
            this.btnRRHH.DisplayName = "Recursos Humanos";
            this.btnRRHH.DrawText = true;
            this.btnRRHH.Image = ((System.Drawing.Image)(resources.GetObject("btnRRHH.Image")));
            this.btnRRHH.Name = "btnRRHH";
            this.btnRRHH.Text = "Recursos Humanos";
            this.btnRRHH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRRHH.ToolTipText = "Recursos Humanos";
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnAnular,
            this.btnExportar,
            this.btnAtras,
            this.btnSalir});
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            this.commandBarStripElement3.Text = "";
            this.commandBarStripElement3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleDescription = "Nuevo";
            this.btnNuevo.AccessibleName = "Nuevo";
            this.btnNuevo.AutoSize = false;
            this.btnNuevo.Bounds = new System.Drawing.Rectangle(0, 0, 55, 30);
            this.btnNuevo.DisplayName = "Nuevo";
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "";
            this.btnNuevo.ToolTipText = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AccessibleDescription = "Editar";
            this.btnEditar.AccessibleName = "Editar";
            this.btnEditar.AutoSize = false;
            this.btnEditar.Bounds = new System.Drawing.Rectangle(0, 0, 55, 30);
            this.btnEditar.DisplayName = "Editar";
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "";
            this.btnEditar.ToolTipText = "Editar";
            // 
            // btnAnular
            // 
            this.btnAnular.AccessibleDescription = "Anular";
            this.btnAnular.AccessibleName = "Anular";
            this.btnAnular.AutoSize = false;
            this.btnAnular.Bounds = new System.Drawing.Rectangle(0, 0, 55, 30);
            this.btnAnular.DisplayName = "Anular";
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Text = "";
            this.btnAnular.ToolTipText = "Anular";
            // 
            // btnExportar
            // 
            this.btnExportar.AccessibleDescription = "Exportar";
            this.btnExportar.AccessibleName = "Exportar";
            this.btnExportar.AutoSize = false;
            this.btnExportar.Bounds = new System.Drawing.Rectangle(0, 0, 55, 30);
            this.btnExportar.DisplayName = "Exportar";
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Text = "";
            this.btnExportar.ToolTipText = "Exportar";
            // 
            // btnAtras
            // 
            this.btnAtras.AccessibleDescription = "Atras";
            this.btnAtras.AccessibleName = "Atras";
            this.btnAtras.AutoSize = false;
            this.btnAtras.Bounds = new System.Drawing.Rectangle(0, 0, 55, 30);
            this.btnAtras.DisplayName = "Atras";
            this.btnAtras.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras.Image")));
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Text = "";
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleDescription = "Salir";
            this.btnSalir.AccessibleName = "Salir";
            this.btnSalir.AutoSize = false;
            this.btnSalir.Bounds = new System.Drawing.Rectangle(0, 0, 55, 30);
            this.btnSalir.DisplayName = "Salir";
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "";
            this.btnSalir.ToolTipText = "Salir";
            // 
            // gbConsulta
            // 
            this.gbConsulta.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsulta.Controls.Add(this.radLabel7);
            this.gbConsulta.Controls.Add(this.txtAño);
            this.gbConsulta.Controls.Add(this.cboMeses);
            this.gbConsulta.Controls.Add(this.label3);
            this.gbConsulta.HeaderText = "Plantilla de Planilla por Pagar";
            this.gbConsulta.Location = new System.Drawing.Point(3, 37);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(934, 52);
            this.gbConsulta.TabIndex = 179;
            this.gbConsulta.Text = "Plantilla de Planilla por Pagar";
            this.gbConsulta.ThemeName = "VisualStudio2012Light";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(9, 28);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(32, 18);
            this.radLabel7.TabIndex = 180;
            this.radLabel7.Text = "Año :";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(47, 26);
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
            this.txtAño.TabIndex = 179;
            this.txtAño.TabStop = false;
            this.txtAño.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAño.ThemeName = "Windows8";
            this.txtAño.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            // 
            // cboMeses
            // 
            this.cboMeses.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMeses.Location = new System.Drawing.Point(138, 28);
            this.cboMeses.Name = "cboMeses";
            this.cboMeses.Size = new System.Drawing.Size(211, 20);
            this.cboMeses.TabIndex = 158;
            this.cboMeses.ThemeName = "VisualStudio2012Light";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 156;
            this.label3.Text = "Mes :";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.radGridView1);
            this.radGroupBox1.HeaderText = "Listado de Planillas";
            this.radGroupBox1.Location = new System.Drawing.Point(7, 93);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(934, 335);
            this.radGroupBox1.TabIndex = 180;
            this.radGroupBox1.Text = "Listado de Planillas";
            this.radGroupBox1.ThemeName = "VisualStudio2012Light";
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.SystemColors.Control;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(2, 18);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.Name = "chId";
            gridViewTextBoxColumn1.Width = 53;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Periodo";
            gridViewTextBoxColumn2.Name = "chPeriodo";
            gridViewTextBoxColumn2.Width = 95;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "Responsable";
            gridViewTextBoxColumn3.Name = "chResponsable";
            gridViewTextBoxColumn3.Width = 264;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "total Planilla";
            gridViewTextBoxColumn4.Name = "chtotalPlanilla";
            gridViewTextBoxColumn4.Width = 105;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "IdEstado";
            gridViewTextBoxColumn5.Name = "chIdEstado";
            gridViewTextBoxColumn5.Width = 53;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "Estado";
            gridViewTextBoxColumn6.Name = "chEstado";
            gridViewTextBoxColumn6.Width = 191;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.HeaderText = "Quincenal";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "chQuincenal";
            gridViewCheckBoxColumn1.Width = 79;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Mensual";
            gridViewTextBoxColumn7.Name = "chMensual";
            gridViewTextBoxColumn7.Width = 79;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn7});
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(930, 315);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.ThemeName = "VisualStudio2012Light";
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
            this.toolStripStatusLabel8,
            this.lblTiempoTranscurrido,
            this.ProgressBar,
            this.lblNumeroResultados});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 431);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(949, 22);
            this.stsBarraEstado.TabIndex = 182;
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
            this.lblPromedio.Font = new System.Drawing.Font("Tahoma", 9F);
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
            this.lblRecuento.Font = new System.Drawing.Font("Tahoma", 9F);
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
            this.lblSumaSeleccionada.Font = new System.Drawing.Font("Tahoma", 9F);
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
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(132, 17);
            this.toolStripStatusLabel8.Text = "  Tiempo Transcurrido : ";
            // 
            // lblTiempoTranscurrido
            // 
            this.lblTiempoTranscurrido.Name = "lblTiempoTranscurrido";
            this.lblTiempoTranscurrido.Size = new System.Drawing.Size(49, 17);
            this.lblTiempoTranscurrido.Text = "00:00:00";
            // 
            // ProgressBar
            // 
            this.ProgressBar.MarqueeAnimationSpeed = 25;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(160, 16);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
            // 
            // PagoCaja
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(949, 453);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.radCommandBar1);
            this.Name = "PagoCaja";
            this.Text = "Pago Caja ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PagoCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbConsulta)).EndInit();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnEditar;
        private Telerik.WinControls.UI.CommandBarButton btnAnular;
        private Telerik.WinControls.UI.CommandBarButton btnExportar;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.UI.CommandBarButton btnAtras;
        private Telerik.WinControls.UI.RadGroupBox gbConsulta;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadSpinEditor txtAño;
        private Telerik.WinControls.UI.RadDropDownList cboMeses;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempoTranscurrido;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroResultados;
    }
}