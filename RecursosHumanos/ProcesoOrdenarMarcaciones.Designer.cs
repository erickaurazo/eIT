namespace RecursosHumanos
{
    partial class ProcesoOrdenarMarcaciones
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
            this.BtnProcesarOrdenamientoMarcaciones = new System.Windows.Forms.Button();
            this.bwgHilo = new System.ComponentModel.BackgroundWorker();
            this.btnSalir = new System.Windows.Forms.Button();
            this.BarraEstadoF = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBarF = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNumeroResultados = new System.Windows.Forms.ToolStripStatusLabel();
            this.BarraEstadoF.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnProcesarOrdenamientoMarcaciones
            // 
            this.BtnProcesarOrdenamientoMarcaciones.Location = new System.Drawing.Point(31, 24);
            this.BtnProcesarOrdenamientoMarcaciones.Name = "BtnProcesarOrdenamientoMarcaciones";
            this.BtnProcesarOrdenamientoMarcaciones.Size = new System.Drawing.Size(140, 23);
            this.BtnProcesarOrdenamientoMarcaciones.TabIndex = 0;
            this.BtnProcesarOrdenamientoMarcaciones.Text = "Ordenar marcaciones";
            this.BtnProcesarOrdenamientoMarcaciones.UseVisualStyleBackColor = true;
            this.BtnProcesarOrdenamientoMarcaciones.Click += new System.EventHandler(this.BtbProcesarOrdenamientoMarcaciones_Click);
            // 
            // bwgHilo
            // 
            this.bwgHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwgHilo_DoWork);
            this.bwgHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwgHilo_RunWorkerCompleted);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(190, 24);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // BarraEstadoF
            // 
            this.BarraEstadoF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ProgressBarF,
            this.lblNumeroResultados});
            this.BarraEstadoF.Location = new System.Drawing.Point(0, 66);
            this.BarraEstadoF.Name = "BarraEstadoF";
            this.BarraEstadoF.Size = new System.Drawing.Size(363, 22);
            this.BarraEstadoF.TabIndex = 182;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // ProgressBarF
            // 
            this.ProgressBarF.MarqueeAnimationSpeed = 25;
            this.ProgressBarF.Name = "ProgressBarF";
            this.ProgressBarF.Size = new System.Drawing.Size(160, 16);
            this.ProgressBarF.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBarF.Visible = false;
            // 
            // lblNumeroResultados
            // 
            this.lblNumeroResultados.Name = "lblNumeroResultados";
            this.lblNumeroResultados.Size = new System.Drawing.Size(0, 17);
            // 
            // ProcesoOrdenarMarcaciones
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(363, 88);
            this.Controls.Add(this.BarraEstadoF);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.BtnProcesarOrdenamientoMarcaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcesoOrdenarMarcaciones";
            this.Text = "Proceso ordenar marcaciones";
            this.BarraEstadoF.ResumeLayout(false);
            this.BarraEstadoF.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnProcesarOrdenamientoMarcaciones;
        private System.ComponentModel.BackgroundWorker bwgHilo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.StatusStrip BarraEstadoF;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBarF;
        private System.Windows.Forms.ToolStripStatusLabel lblNumeroResultados;
    }
}