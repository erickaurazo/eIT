namespace Transportista
{
    partial class ImprimirReporteFacturacionPensionistaPorSemanaFacturacion
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
            this.crvImprimirDetalle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvImprimirDetalle
            // 
            this.crvImprimirDetalle.ActiveViewIndex = -1;
            this.crvImprimirDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvImprimirDetalle.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvImprimirDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvImprimirDetalle.Location = new System.Drawing.Point(0, 0);
            this.crvImprimirDetalle.Name = "crvImprimirDetalle";
            this.crvImprimirDetalle.Size = new System.Drawing.Size(775, 501);
            this.crvImprimirDetalle.TabIndex = 1;
            this.crvImprimirDetalle.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImprimirReporteFacturacionPensionistaPorSemanaFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 501);
            this.Controls.Add(this.crvImprimirDetalle);
            this.Name = "ImprimirReporteFacturacionPensionistaPorSemanaFacturacion";
            this.Text = "ImprimirReporteFacturacionPensionistaPorSemanaFacturacion";
            this.Load += new System.EventHandler(this.ImprimirReporteFacturacionPensionistaPorSemanaFacturacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvImprimirDetalle;
    }
}