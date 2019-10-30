namespace RecursosHumanos
{
    partial class ImprimirIngresosSalidasPersonalVistaPrevia
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
            this.crIngresoSalidaPersonal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crIngresoSalidaPersonal
            // 
            this.crIngresoSalidaPersonal.ActiveViewIndex = -1;
            this.crIngresoSalidaPersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crIngresoSalidaPersonal.Cursor = System.Windows.Forms.Cursors.Default;
            this.crIngresoSalidaPersonal.DisplayStatusBar = false;
            this.crIngresoSalidaPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crIngresoSalidaPersonal.Location = new System.Drawing.Point(0, 0);
            this.crIngresoSalidaPersonal.Name = "crIngresoSalidaPersonal";
            this.crIngresoSalidaPersonal.Size = new System.Drawing.Size(726, 555);
            this.crIngresoSalidaPersonal.TabIndex = 1;
            this.crIngresoSalidaPersonal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImprimirIngresosSalidasPersonalVistaPrevia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 555);
            this.Controls.Add(this.crIngresoSalidaPersonal);
            this.Name = "ImprimirIngresosSalidasPersonalVistaPrevia";
            this.Text = "ImprimirIngresosSalidasPersonalVistaPrevia";
            this.Load += new System.EventHandler(this.ImprimirIngresosSalidasPersonalVistaPrevia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crIngresoSalidaPersonal;
    }
}