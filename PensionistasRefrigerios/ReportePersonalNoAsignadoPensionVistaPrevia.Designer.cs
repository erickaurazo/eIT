﻿namespace Transportista
{
    partial class ReportePersonalNoAsignadoPensionVistaPrevia
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
            this.crvImprimir = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvImprimir
            // 
            this.crvImprimir.ActiveViewIndex = -1;
            this.crvImprimir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvImprimir.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvImprimir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvImprimir.Location = new System.Drawing.Point(0, 0);
            this.crvImprimir.Name = "crvImprimir";
            this.crvImprimir.Size = new System.Drawing.Size(771, 444);
            this.crvImprimir.TabIndex = 3;
            this.crvImprimir.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportePersonalNoAsignadoPensionVistaPrevia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(771, 444);
            this.Controls.Add(this.crvImprimir);
            this.Name = "ReportePersonalNoAsignadoPensionVistaPrevia";
            this.Text = "Reporte de personal no asignado a pensión";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportePersonalNoAsignadoPensionVistaPrevia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvImprimir;
    }
}