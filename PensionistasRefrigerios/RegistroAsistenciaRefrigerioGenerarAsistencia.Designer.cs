namespace Transportista
{
    partial class RegistroAsistenciaRefrigerioGenerarAsistencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroAsistenciaRefrigerioGenerarAsistencia));
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn9 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn10 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn11 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn12 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbInformacion = new Telerik.WinControls.UI.RadGroupBox();
            this.btnListarTodoPersonalProgramacion = new System.Windows.Forms.Button();
            this.btnActualizarLista = new System.Windows.Forms.Button();
            this.btnConsultarPension = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtnroDniPension = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtProveedorRazonSocial = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.lblNombreComercial = new Telerik.WinControls.UI.RadLabel();
            this.txtProveedorPseudoNombre = new Telerik.WinControls.UI.RadTextBox();
            this.lblPension = new Telerik.WinControls.UI.RadLabel();
            this.gbListado = new Telerik.WinControls.UI.RadGroupBox();
            this.dgvPersonal = new Telerik.WinControls.UI.RadGridView();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.bgwProceso = new System.ComponentModel.BackgroundWorker();
            this.stsBarraEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroResultados = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbInformacion)).BeginInit();
            this.gbInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreComercial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProveedorPseudoNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPension)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbListado)).BeginInit();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal.MasterTemplate)).BeginInit();
            this.stsBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(807, 440);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(888, 440);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbInformacion
            // 
            this.gbInformacion.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInformacion.Controls.Add(this.btnListarTodoPersonalProgramacion);
            this.gbInformacion.Controls.Add(this.btnActualizarLista);
            this.gbInformacion.Controls.Add(this.btnConsultarPension);
            this.gbInformacion.Controls.Add(this.txtProveedorRazonSocial);
            this.gbInformacion.Controls.Add(this.lblNombreComercial);
            this.gbInformacion.Controls.Add(this.txtnroDniPension);
            this.gbInformacion.Controls.Add(this.txtProveedorPseudoNombre);
            this.gbInformacion.Controls.Add(this.lblPension);
            this.gbInformacion.HeaderText = "Información";
            this.gbInformacion.Location = new System.Drawing.Point(1, 4);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(962, 77);
            this.gbInformacion.TabIndex = 2;
            this.gbInformacion.Text = "Información";
            this.gbInformacion.ThemeName = "Windows8";
            // 
            // btnListarTodoPersonalProgramacion
            // 
            this.btnListarTodoPersonalProgramacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListarTodoPersonalProgramacion.Location = new System.Drawing.Point(850, 20);
            this.btnListarTodoPersonalProgramacion.Name = "btnListarTodoPersonalProgramacion";
            this.btnListarTodoPersonalProgramacion.Size = new System.Drawing.Size(107, 23);
            this.btnListarTodoPersonalProgramacion.TabIndex = 181;
            this.btnListarTodoPersonalProgramacion.Text = "Todo personal de la programación";
            this.btnListarTodoPersonalProgramacion.UseVisualStyleBackColor = true;
            this.btnListarTodoPersonalProgramacion.Click += new System.EventHandler(this.btnListarTodoPersonalProgramacion_Click);
            // 
            // btnActualizarLista
            // 
            this.btnActualizarLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarLista.Location = new System.Drawing.Point(850, 49);
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Size = new System.Drawing.Size(107, 23);
            this.btnActualizarLista.TabIndex = 4;
            this.btnActualizarLista.Text = "Actualizar lista";
            this.btnActualizarLista.UseVisualStyleBackColor = true;
            this.btnActualizarLista.Click += new System.EventHandler(this.btnActualizarLista_Click);
            // 
            // btnConsultarPension
            // 
            this.btnConsultarPension.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarPension.Image")));
            this.btnConsultarPension.Location = new System.Drawing.Point(72, 18);
            this.btnConsultarPension.Name = "btnConsultarPension";
            this.btnConsultarPension.P_CampoCodigo = "rtrim(nroDNI)";
            this.btnConsultarPension.P_CampoDescripcion = "ISNULL(RTRIM(CP.RAZON_SOCIAL),\'\') + \' / \' + isnull(RTRIM(NROrUC),\'\') + \' / \' + IS" +
    "NULL(RTRIM(PNS.PseudoNombre),\'\')  + \' / \' + rtrim(CAST(PNS.idpension as char(4))" +
    ")";
            this.btnConsultarPension.P_EsEditable = true;
            this.btnConsultarPension.P_EsModificable = true;
            this.btnConsultarPension.P_FilterByTextBox = null;
            this.btnConsultarPension.P_TablaConsulta = "SJ_RHPension PNS LEFT JOIN CLIEPROV CP ON PNS.NroRUC = CP.IdClieprov LEFT JOIN ES" +
    "TADOS E ON PNS.IdEstado=E.IdEstado where  PNS.IdEstado = \'AC\'";
            this.btnConsultarPension.P_TextBoxCodigo = this.txtnroDniPension;
            this.btnConsultarPension.P_TextBoxDescripcion = this.txtProveedorRazonSocial;
            this.btnConsultarPension.P_TituloFormulario = "Buscar RUC";
            this.btnConsultarPension.Size = new System.Drawing.Size(39, 23);
            this.btnConsultarPension.TabIndex = 1848;
            this.btnConsultarPension.UseVisualStyleBackColor = true;
            this.btnConsultarPension.Visible = false;
            // 
            // txtnroDniPension
            // 
            this.txtnroDniPension.BackColor = System.Drawing.Color.White;
            this.txtnroDniPension.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnroDniPension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtnroDniPension.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtnroDniPension.Location = new System.Drawing.Point(124, 21);
            this.txtnroDniPension.MaxLength = 16;
            this.txtnroDniPension.Name = "txtnroDniPension";
            this.txtnroDniPension.P_BotonEnlace = this.btnConsultarPension;
            this.txtnroDniPension.P_BuscarSoloCodigoExacto = false;
            this.txtnroDniPension.P_EsEditable = true;
            this.txtnroDniPension.P_EsModificable = true;
            this.txtnroDniPension.P_EsPrimaryKey = false;
            this.txtnroDniPension.P_ExigeInformacion = false;
            this.txtnroDniPension.P_NombreColumna = null;
            this.txtnroDniPension.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtnroDniPension.ReadOnly = true;
            this.txtnroDniPension.Size = new System.Drawing.Size(66, 20);
            this.txtnroDniPension.TabIndex = 1849;
            this.txtnroDniPension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProveedorRazonSocial
            // 
            this.txtProveedorRazonSocial.BackColor = System.Drawing.Color.White;
            this.txtProveedorRazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProveedorRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtProveedorRazonSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtProveedorRazonSocial.Location = new System.Drawing.Point(196, 21);
            this.txtProveedorRazonSocial.Name = "txtProveedorRazonSocial";
            this.txtProveedorRazonSocial.P_BotonEnlace = null;
            this.txtProveedorRazonSocial.P_BuscarSoloCodigoExacto = false;
            this.txtProveedorRazonSocial.P_EsEditable = false;
            this.txtProveedorRazonSocial.P_EsModificable = false;
            this.txtProveedorRazonSocial.P_EsPrimaryKey = false;
            this.txtProveedorRazonSocial.P_ExigeInformacion = false;
            this.txtProveedorRazonSocial.P_NombreColumna = null;
            this.txtProveedorRazonSocial.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtProveedorRazonSocial.ReadOnly = true;
            this.txtProveedorRazonSocial.Size = new System.Drawing.Size(477, 20);
            this.txtProveedorRazonSocial.TabIndex = 1850;
            // 
            // lblNombreComercial
            // 
            this.lblNombreComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreComercial.Location = new System.Drawing.Point(12, 47);
            this.lblNombreComercial.Name = "lblNombreComercial";
            this.lblNombreComercial.Size = new System.Drawing.Size(108, 16);
            this.lblNombreComercial.TabIndex = 1852;
            this.lblNombreComercial.Text = "Nombre comercial :";
            // 
            // txtProveedorPseudoNombre
            // 
            this.txtProveedorPseudoNombre.Location = new System.Drawing.Point(124, 45);
            this.txtProveedorPseudoNombre.MaxLength = 250;
            this.txtProveedorPseudoNombre.Name = "txtProveedorPseudoNombre";
            this.txtProveedorPseudoNombre.ReadOnly = true;
            this.txtProveedorPseudoNombre.Size = new System.Drawing.Size(549, 20);
            this.txtProveedorPseudoNombre.TabIndex = 1851;
            this.txtProveedorPseudoNombre.TabStop = false;
            this.txtProveedorPseudoNombre.ThemeName = "VisualStudio2012Light";
            // 
            // lblPension
            // 
            this.lblPension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPension.Location = new System.Drawing.Point(11, 21);
            this.lblPension.Name = "lblPension";
            this.lblPension.Size = new System.Drawing.Size(55, 16);
            this.lblPension.TabIndex = 1847;
            this.lblPension.Text = "Pensión :";
            // 
            // gbListado
            // 
            this.gbListado.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListado.Controls.Add(this.dgvPersonal);
            this.gbListado.HeaderText = "Listado Personal";
            this.gbListado.Location = new System.Drawing.Point(1, 87);
            this.gbListado.Name = "gbListado";
            this.gbListado.Size = new System.Drawing.Size(962, 347);
            this.gbListado.TabIndex = 3;
            this.gbListado.Text = "Listado Personal";
            this.gbListado.ThemeName = "Windows8";
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.AutoGenerateHierarchy = true;
            this.dgvPersonal.BackColor = System.Drawing.SystemColors.Control;
            this.dgvPersonal.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonal.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dgvPersonal.ForeColor = System.Drawing.Color.Black;
            this.dgvPersonal.GroupExpandAnimationType = Telerik.WinControls.UI.GridExpandAnimationType.Slide;
            this.dgvPersonal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvPersonal.Location = new System.Drawing.Point(2, 18);
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.MasterTemplate.AllowAddNewRow = false;
            this.dgvPersonal.MasterTemplate.AutoGenerateColumns = false;
            this.dgvPersonal.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn9.EnableExpressionEditor = false;
            gridViewCheckBoxColumn9.FieldName = "esSelecionado";
            gridViewCheckBoxColumn9.MinWidth = 20;
            gridViewCheckBoxColumn9.Name = "chesSelecionado";
            gridViewCheckBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn9.Width = 70;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "IdCodigoPersonal";
            gridViewTextBoxColumn7.HeaderText = "Código";
            gridViewTextBoxColumn7.Name = "chIdCodigoPersonal";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 96;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "NroDocumento";
            gridViewTextBoxColumn8.HeaderText = "NroDocumento";
            gridViewTextBoxColumn8.Name = "chNroDocumento";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 116;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "NombresCompletos";
            gridViewTextBoxColumn9.HeaderText = "Nombres completos";
            gridViewTextBoxColumn9.Name = "chNombresCompletos";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 392;
            gridViewCheckBoxColumn10.EnableExpressionEditor = false;
            gridViewCheckBoxColumn10.FieldName = "Desayuno";
            gridViewCheckBoxColumn10.HeaderText = "Desayuno";
            gridViewCheckBoxColumn10.MinWidth = 20;
            gridViewCheckBoxColumn10.Name = "chDesayuno";
            gridViewCheckBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn10.Width = 95;
            gridViewCheckBoxColumn11.EnableExpressionEditor = false;
            gridViewCheckBoxColumn11.FieldName = "Almuerzo";
            gridViewCheckBoxColumn11.HeaderText = "Almuerzo";
            gridViewCheckBoxColumn11.MinWidth = 20;
            gridViewCheckBoxColumn11.Name = "chAlmuerzo";
            gridViewCheckBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn11.Width = 104;
            gridViewCheckBoxColumn12.EnableExpressionEditor = false;
            gridViewCheckBoxColumn12.FieldName = "cena";
            gridViewCheckBoxColumn12.HeaderText = "cena";
            gridViewCheckBoxColumn12.MinWidth = 20;
            gridViewCheckBoxColumn12.Name = "chcena";
            gridViewCheckBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCheckBoxColumn12.Width = 73;
            this.dgvPersonal.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn9,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewCheckBoxColumn10,
            gridViewCheckBoxColumn11,
            gridViewCheckBoxColumn12});
            this.dgvPersonal.MasterTemplate.EnableFiltering = true;
            this.dgvPersonal.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
            this.dgvPersonal.MasterTemplate.ShowGroupedColumns = true;
            this.dgvPersonal.MasterTemplate.ShowHeaderCellButtons = true;
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPersonal.ShowHeaderCellButtons = true;
            this.dgvPersonal.Size = new System.Drawing.Size(958, 327);
            this.dgvPersonal.TabIndex = 0;
            this.dgvPersonal.Text = "radGridView1";
            this.dgvPersonal.ThemeName = "VisualStudio2012Light";
            // 
            // bgwProceso
            // 
            this.bgwProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProceso_DoWork);
            this.bgwProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProceso_RunWorkerCompleted);
            // 
            // stsBarraEstado
            // 
            this.stsBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.progressBar,
            this.lblNumeroResultados});
            this.stsBarraEstado.Location = new System.Drawing.Point(0, 466);
            this.stsBarraEstado.Name = "stsBarraEstado";
            this.stsBarraEstado.Size = new System.Drawing.Size(975, 22);
            this.stsBarraEstado.TabIndex = 180;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBar
            // 
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(250, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
            // 
            // RegistroAsistenciaRefrigerioGenerarAsistencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(975, 488);
            this.Controls.Add(this.stsBarraEstado);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.gbInformacion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Name = "RegistroAsistenciaRefrigerioGenerarAsistencia";
            this.Text = "Generar registro de asistencia a partir de programación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistroAsistenciaRefrigerioGenerarAsistencia_FormClosing);
            this.Load += new System.EventHandler(this.RegistroAsistenciaRefrigerioGenerarAsistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbInformacion)).EndInit();
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreComercial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProveedorPseudoNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPension)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbListado)).EndInit();
            this.gbListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.stsBarraEstado.ResumeLayout(false);
            this.stsBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private Telerik.WinControls.UI.RadGroupBox gbInformacion;
        private Telerik.WinControls.UI.RadGroupBox gbListado;
        private Telerik.WinControls.UI.RadGridView dgvPersonal;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnConsultarPension;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtnroDniPension;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtProveedorRazonSocial;
        private Telerik.WinControls.UI.RadLabel lblNombreComercial;
        private Telerik.WinControls.UI.RadTextBox txtProveedorPseudoNombre;
        private Telerik.WinControls.UI.RadLabel lblPension;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.Button btnActualizarLista;
        private System.ComponentModel.BackgroundWorker bgwProceso;
        private System.Windows.Forms.StatusStrip stsBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroResultados;
        private System.Windows.Forms.Button btnListarTodoPersonalProgramacion;
    }
}