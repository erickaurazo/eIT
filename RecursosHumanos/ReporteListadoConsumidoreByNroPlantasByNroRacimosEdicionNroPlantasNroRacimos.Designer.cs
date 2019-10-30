namespace RecursosHumanos
{
    partial class ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos));
            this.menuPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.btnRegistrarYSalir = new System.Windows.Forms.Button();
            this.gbConsumidor = new System.Windows.Forms.GroupBox();
            this.txtConsumidorDescripcion = new System.Windows.Forms.TextBox();
            this.txtConsumidorCodigo = new System.Windows.Forms.TextBox();
            this.gbDatosAModificar = new System.Windows.Forms.GroupBox();
            this.lblNroPlantas = new System.Windows.Forms.Label();
            this.lblNroRacimos = new System.Windows.Forms.Label();
            this.txtNroPlantas = new System.Windows.Forms.NumericUpDown();
            this.txtNumeroRacimos = new System.Windows.Forms.NumericUpDown();
            this.bwgHilo = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).BeginInit();
            this.gbConsumidor.SuspendLayout();
            this.gbDatosAModificar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroPlantas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroRacimos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.menuPrincipal.Size = new System.Drawing.Size(497, 35);
            this.menuPrincipal.TabIndex = 188;
            this.menuPrincipal.Text = "Nuevo";
            this.menuPrincipal.ThemeName = "VisualStudio2012Light";
            // 
            // BarraSuperior
            // 
            this.BarraSuperior.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BarraSuperior.MinSize = new System.Drawing.Size(25, 25);
            this.BarraSuperior.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.BarraModulo,
            this.commandBarStripElement3});
            this.BarraSuperior.Text = "";
            this.BarraSuperior.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // BarraModulo
            // 
            this.BarraModulo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.BarraModulo.DisplayName = "commandBarStripElement2";
            this.BarraModulo.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnRRHH});
            this.BarraModulo.Name = "commandBarStripElement2";
            this.BarraModulo.Text = "";
            this.BarraModulo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnRRHH
            // 
            this.btnRRHH.AccessibleDescription = "RecursosHumanos";
            this.btnRRHH.AccessibleName = "RecursosHumanos";
            this.btnRRHH.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRRHH.DisplayName = "Recursos Humanos";
            this.btnRRHH.DrawText = true;
            this.btnRRHH.Image = ((System.Drawing.Image)(resources.GetObject("btnRRHH.Image")));
            this.btnRRHH.Name = "btnRRHH";
            this.btnRRHH.Text = "   Almacén  ";
            this.btnRRHH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRRHH.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRRHH.ToolTipText = "Recursos Humanos";
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnEditar,
            this.btnGuardar,
            this.btnSalir});
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            this.commandBarStripElement3.Text = "";
            this.commandBarStripElement3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandBarStripElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnEditar
            // 
            this.btnEditar.AccessibleDescription = "Editar";
            this.btnEditar.AccessibleName = "Editar";
            this.btnEditar.AutoSize = false;
            this.btnEditar.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnEditar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEditar.DisplayName = "Editar";
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "";
            this.btnEditar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleDescription = "Guardar";
            this.btnGuardar.AccessibleName = "Guardar";
            this.btnGuardar.AutoSize = false;
            this.btnGuardar.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnGuardar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnGuardar.DisplayName = "Nuevo";
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "";
            this.btnGuardar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleDescription = "Salir";
            this.btnSalir.AccessibleName = "Salir";
            this.btnSalir.AutoSize = false;
            this.btnSalir.Bounds = new System.Drawing.Rectangle(0, 0, 95, 35);
            this.btnSalir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.DisplayName = "Salir";
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "";
            this.btnSalir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.ToolTipText = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRegistrarYSalir
            // 
            this.btnRegistrarYSalir.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRegistrarYSalir.Location = new System.Drawing.Point(386, 158);
            this.btnRegistrarYSalir.Name = "btnRegistrarYSalir";
            this.btnRegistrarYSalir.Size = new System.Drawing.Size(99, 24);
            this.btnRegistrarYSalir.TabIndex = 191;
            this.btnRegistrarYSalir.Text = "Registrar y salir";
            this.btnRegistrarYSalir.UseVisualStyleBackColor = true;
            this.btnRegistrarYSalir.Click += new System.EventHandler(this.btnRegistrarYSalir_Click);
            // 
            // gbConsumidor
            // 
            this.gbConsumidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConsumidor.Controls.Add(this.txtConsumidorDescripcion);
            this.gbConsumidor.Controls.Add(this.txtConsumidorCodigo);
            this.gbConsumidor.Location = new System.Drawing.Point(9, 41);
            this.gbConsumidor.Name = "gbConsumidor";
            this.gbConsumidor.Size = new System.Drawing.Size(476, 51);
            this.gbConsumidor.TabIndex = 193;
            this.gbConsumidor.TabStop = false;
            this.gbConsumidor.Text = "Consumidor";
            // 
            // txtConsumidorDescripcion
            // 
            this.txtConsumidorDescripcion.Location = new System.Drawing.Point(145, 20);
            this.txtConsumidorDescripcion.Name = "txtConsumidorDescripcion";
            this.txtConsumidorDescripcion.ReadOnly = true;
            this.txtConsumidorDescripcion.Size = new System.Drawing.Size(325, 20);
            this.txtConsumidorDescripcion.TabIndex = 1;
            // 
            // txtConsumidorCodigo
            // 
            this.txtConsumidorCodigo.Location = new System.Drawing.Point(15, 20);
            this.txtConsumidorCodigo.Name = "txtConsumidorCodigo";
            this.txtConsumidorCodigo.ReadOnly = true;
            this.txtConsumidorCodigo.Size = new System.Drawing.Size(114, 20);
            this.txtConsumidorCodigo.TabIndex = 0;
            // 
            // gbDatosAModificar
            // 
            this.gbDatosAModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosAModificar.Controls.Add(this.txtNumeroRacimos);
            this.gbDatosAModificar.Controls.Add(this.txtNroPlantas);
            this.gbDatosAModificar.Controls.Add(this.lblNroRacimos);
            this.gbDatosAModificar.Controls.Add(this.lblNroPlantas);
            this.gbDatosAModificar.Location = new System.Drawing.Point(9, 98);
            this.gbDatosAModificar.Name = "gbDatosAModificar";
            this.gbDatosAModificar.Size = new System.Drawing.Size(476, 54);
            this.gbDatosAModificar.TabIndex = 194;
            this.gbDatosAModificar.TabStop = false;
            this.gbDatosAModificar.Text = "Datos a modificar";
            // 
            // lblNroPlantas
            // 
            this.lblNroPlantas.AutoSize = true;
            this.lblNroPlantas.Location = new System.Drawing.Point(27, 22);
            this.lblNroPlantas.Name = "lblNroPlantas";
            this.lblNroPlantas.Size = new System.Drawing.Size(68, 13);
            this.lblNroPlantas.TabIndex = 1;
            this.lblNroPlantas.Text = "Nro Plantas :";
            // 
            // lblNroRacimos
            // 
            this.lblNroRacimos.AutoSize = true;
            this.lblNroRacimos.Location = new System.Drawing.Point(326, 19);
            this.lblNroRacimos.Name = "lblNroRacimos";
            this.lblNroRacimos.Size = new System.Drawing.Size(74, 13);
            this.lblNroRacimos.TabIndex = 2;
            this.lblNroRacimos.Text = "Nro Racimos :";
            // 
            // txtNroPlantas
            // 
            this.txtNroPlantas.Location = new System.Drawing.Point(101, 19);
            this.txtNroPlantas.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.txtNroPlantas.Name = "txtNroPlantas";
            this.txtNroPlantas.Size = new System.Drawing.Size(68, 20);
            this.txtNroPlantas.TabIndex = 3;
            // 
            // txtNumeroRacimos
            // 
            this.txtNumeroRacimos.Location = new System.Drawing.Point(402, 15);
            this.txtNumeroRacimos.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.txtNumeroRacimos.Name = "txtNumeroRacimos";
            this.txtNumeroRacimos.Size = new System.Drawing.Size(68, 20);
            this.txtNumeroRacimos.TabIndex = 4;
            // 
            // bwgHilo
            // 
            this.bwgHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwgHilo_DoWork);
            this.bwgHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwgHilo_RunWorkerCompleted);
            // 
            // ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(497, 196);
            this.Controls.Add(this.gbDatosAModificar);
            this.Controls.Add(this.gbConsumidor);
            this.Controls.Add(this.btnRegistrarYSalir);
            this.Controls.Add(this.menuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos";
            this.Text = "Edición de consumidor - Nro. Plantas / Nro. Racimo";
            this.Load += new System.EventHandler(this.ReporteListadoConsumidoreByNroPlantasByNroRacimosEdicionNroPlantasNroRacimos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuPrincipal)).EndInit();
            this.gbConsumidor.ResumeLayout(false);
            this.gbConsumidor.PerformLayout();
            this.gbDatosAModificar.ResumeLayout(false);
            this.gbDatosAModificar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroPlantas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroRacimos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar menuPrincipal;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnEditar;
        private Telerik.WinControls.UI.CommandBarButton btnGuardar;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private System.Windows.Forms.Button btnRegistrarYSalir;
        private System.Windows.Forms.GroupBox gbConsumidor;
        private System.Windows.Forms.TextBox txtConsumidorDescripcion;
        private System.Windows.Forms.TextBox txtConsumidorCodigo;
        private System.Windows.Forms.GroupBox gbDatosAModificar;
        private System.Windows.Forms.Label lblNroRacimos;
        private System.Windows.Forms.Label lblNroPlantas;
        private System.Windows.Forms.NumericUpDown txtNumeroRacimos;
        private System.Windows.Forms.NumericUpDown txtNroPlantas;
        private System.ComponentModel.BackgroundWorker bwgHilo;
    }
}