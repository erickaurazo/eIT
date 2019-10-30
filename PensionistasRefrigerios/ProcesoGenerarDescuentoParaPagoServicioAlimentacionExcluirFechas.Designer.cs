namespace Transportista
{
    partial class ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDesactivar = new Telerik.WinControls.UI.RadButton();
            this.dgvDiasExcluidos = new MyControlsDataBinding.Controles.MyDataGridViewDetails(this.components);
            this.btnActivar = new Telerik.WinControls.UI.RadButton();
            this.BtnQuitar = new Telerik.WinControls.UI.RadButton();
            this.btnAgregar = new Telerik.WinControls.UI.RadButton();
            this.btnGrabar = new Telerik.WinControls.UI.RadButton();
            this.btnSalir = new Telerik.WinControls.UI.RadButton();
            this.btnRefrescarLista = new Telerik.WinControls.UI.RadButton();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.chId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chIdEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaplicaPension = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chaplicaTransporte = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chaplicaOtros = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnDesactivar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiasExcluidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActivar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnQuitar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescarLista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnDesactivar.Image = ((System.Drawing.Image)(resources.GetObject("btnDesactivar.Image")));
            this.btnDesactivar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDesactivar.Location = new System.Drawing.Point(41, 5);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(26, 30);
            this.btnDesactivar.TabIndex = 171;
            this.btnDesactivar.ThemeName = "Windows8";
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // dgvDiasExcluidos
            // 
            this.dgvDiasExcluidos.AllowUserToAddRows = false;
            this.dgvDiasExcluidos.AllowUserToDeleteRows = false;
            this.dgvDiasExcluidos.AllowUserToResizeColumns = false;
            this.dgvDiasExcluidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiasExcluidos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDiasExcluidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiasExcluidos.ColumnHeadersHeight = 65;
            this.dgvDiasExcluidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDiasExcluidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chId,
            this.chItem,
            this.chFecha,
            this.chObservacion,
            this.chIdEstado,
            this.chPeriodo,
            this.chaplicaPension,
            this.chaplicaTransporte,
            this.chaplicaOtros});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiasExcluidos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiasExcluidos.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDiasExcluidos.Location = new System.Drawing.Point(12, 39);
            this.dgvDiasExcluidos.Name = "dgvDiasExcluidos";
            this.dgvDiasExcluidos.P_EsEditable = false;
            this.dgvDiasExcluidos.P_FormatoDecimal = null;
            this.dgvDiasExcluidos.P_FormatoFecha = null;
            this.dgvDiasExcluidos.P_NombreColCorrelativa = null;
            this.dgvDiasExcluidos.P_NombreTabla = null;
            this.dgvDiasExcluidos.P_NumeroDigitos = 0;
            this.dgvDiasExcluidos.RowHeadersWidth = 25;
            this.dgvDiasExcluidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvDiasExcluidos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiasExcluidos.Size = new System.Drawing.Size(819, 414);
            this.dgvDiasExcluidos.TabIndex = 169;
            this.dgvDiasExcluidos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiasExcluidos_CellEndEdit);
            this.dgvDiasExcluidos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDiasExcluidos_CellValidating);
            this.dgvDiasExcluidos.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvDiasExcluidos_DefaultValuesNeeded);
            this.dgvDiasExcluidos.SelectionChanged += new System.EventHandler(this.dgvContratos_SelectionChanged);
            // 
            // btnActivar
            // 
            this.btnActivar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnActivar.Image = ((System.Drawing.Image)(resources.GetObject("btnActivar.Image")));
            this.btnActivar.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnActivar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.btnActivar.Location = new System.Drawing.Point(12, 5);
            this.btnActivar.Margin = new System.Windows.Forms.Padding(1);
            this.btnActivar.Name = "btnActivar";
            // 
            // 
            // 
            this.btnActivar.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnActivar.RootElement.AutoSize = false;
            this.btnActivar.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            this.btnActivar.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            this.btnActivar.Size = new System.Drawing.Size(26, 30);
            this.btnActivar.TabIndex = 170;
            this.btnActivar.ThemeName = "Windows8";
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // BtnQuitar
            // 
            this.BtnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuitar.Image")));
            this.BtnQuitar.Location = new System.Drawing.Point(805, 5);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(26, 30);
            this.BtnQuitar.TabIndex = 168;
            this.BtnQuitar.ThemeName = "Windows8";
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(774, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(26, 30);
            this.btnAgregar.TabIndex = 167;
            this.btnAgregar.ThemeName = "Windows8";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.Location = new System.Drawing.Point(651, 459);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(86, 27);
            this.btnGrabar.TabIndex = 172;
            this.btnGrabar.Text = "     &Grabar";
            this.btnGrabar.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.ThemeName = "Windows8";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(743, 459);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(86, 27);
            this.btnSalir.TabIndex = 173;
            this.btnSalir.Text = "     &Salir";
            this.btnSalir.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ThemeName = "Windows8";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRefrescarLista
            // 
            this.btnRefrescarLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefrescarLista.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescarLista.Image")));
            this.btnRefrescarLista.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefrescarLista.Location = new System.Drawing.Point(16, 459);
            this.btnRefrescarLista.Name = "btnRefrescarLista";
            this.btnRefrescarLista.Size = new System.Drawing.Size(125, 27);
            this.btnRefrescarLista.TabIndex = 174;
            this.btnRefrescarLista.Text = "     &Actualizar Lista";
            this.btnRefrescarLista.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefrescarLista.ThemeName = "Windows8";
            this.btnRefrescarLista.Click += new System.EventHandler(this.btnRefrescarLista_Click);
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(147, 461);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(498, 23);
            this.progressBar.TabIndex = 175;
            // 
            // chId
            // 
            this.chId.DataPropertyName = "idFechaExcluida";
            this.chId.HeaderText = "Id";
            this.chId.Name = "chId";
            this.chId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chId.Visible = false;
            this.chId.Width = 35;
            // 
            // chItem
            // 
            this.chItem.DataPropertyName = "Item";
            this.chItem.HeaderText = "Item";
            this.chItem.Name = "chItem";
            this.chItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chItem.Width = 35;
            // 
            // chFecha
            // 
            this.chFecha.DataPropertyName = "fecha";
            dataGridViewCellStyle1.Format = "d";
            this.chFecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.chFecha.HeaderText = "Fecha a excluir";
            this.chFecha.Name = "chFecha";
            this.chFecha.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chFecha.Width = 95;
            // 
            // chObservacion
            // 
            this.chObservacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chObservacion.DataPropertyName = "Observacion";
            this.chObservacion.HeaderText = "Descripción del día excluido";
            this.chObservacion.MaxInputLength = 500;
            this.chObservacion.Name = "chObservacion";
            this.chObservacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chObservacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chIdEstado
            // 
            this.chIdEstado.DataPropertyName = "Estado";
            this.chIdEstado.HeaderText = "IdEstado";
            this.chIdEstado.Name = "chIdEstado";
            this.chIdEstado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chIdEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chIdEstado.Visible = false;
            // 
            // chPeriodo
            // 
            this.chPeriodo.DataPropertyName = "periodo";
            this.chPeriodo.HeaderText = "Periodo";
            this.chPeriodo.Name = "chPeriodo";
            this.chPeriodo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chPeriodo.Visible = false;
            // 
            // chaplicaPension
            // 
            this.chaplicaPension.DataPropertyName = "aplicaPension";
            this.chaplicaPension.HeaderText = "Aplica para descuento por facturacion a pensión";
            this.chaplicaPension.Name = "chaplicaPension";
            this.chaplicaPension.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // chaplicaTransporte
            // 
            this.chaplicaTransporte.DataPropertyName = "aplicaTransporte";
            this.chaplicaTransporte.HeaderText = "Aplica para descuento por facturación a transporte";
            this.chaplicaTransporte.Name = "chaplicaTransporte";
            this.chaplicaTransporte.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // chaplicaOtros
            // 
            this.chaplicaOtros.DataPropertyName = "aplicaOtros";
            this.chaplicaOtros.HeaderText = "Aplica a otros descuentos";
            this.chaplicaOtros.Name = "chaplicaOtros";
            this.chaplicaOtros.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(841, 489);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnRefrescarLista);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.dgvDiasExcluidos);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.BtnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Name = "ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Excluir fecha para descuento del personal - Servicio de alimentación y transporte" +
    "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas_FormClosing);
            this.Load += new System.EventHandler(this.ProcesoGenerarDescuentoParaPagoServicioAlimentacionExcluirFechas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnDesactivar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiasExcluidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActivar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnQuitar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefrescarLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnDesactivar;
        private MyControlsDataBinding.Controles.MyDataGridViewDetails dgvDiasExcluidos;
        private Telerik.WinControls.UI.RadButton btnActivar;
        private Telerik.WinControls.UI.RadButton BtnQuitar;
        private Telerik.WinControls.UI.RadButton btnAgregar;
        private Telerik.WinControls.UI.RadButton btnGrabar;
        private Telerik.WinControls.UI.RadButton btnSalir;
        private Telerik.WinControls.UI.RadButton btnRefrescarLista;
        private System.ComponentModel.BackgroundWorker bgwHilo;
        private System.Windows.Forms.ProgressBar progressBar;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chId;
        private System.Windows.Forms.DataGridViewTextBoxColumn chItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn chFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn chObservacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn chIdEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn chPeriodo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chaplicaPension;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chaplicaTransporte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chaplicaOtros;
    }
}