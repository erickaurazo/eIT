namespace Transportista
{
    partial class FacturacionMovilidadesImprimirResumen
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
            this.crvImprimirResumen = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvImprimirResumen
            // 
            this.crvImprimirResumen.ActiveViewIndex = -1;
            this.crvImprimirResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvImprimirResumen.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvImprimirResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvImprimirResumen.Location = new System.Drawing.Point(0, 0);
            this.crvImprimirResumen.Name = "crvImprimirResumen";
            this.crvImprimirResumen.Size = new System.Drawing.Size(797, 493);
            this.crvImprimirResumen.TabIndex = 0;
            this.crvImprimirResumen.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FacturacionMovilidadesImprimirResumen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(797, 493);
            this.Controls.Add(this.crvImprimirResumen);
            this.Name = "FacturacionMovilidadesImprimirResumen";
            this.Text = "Facturación Movilidades Imprimir Resumen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FacturacionMovilidadesImprimirResumen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvImprimirResumen;
    }
}