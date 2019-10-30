namespace Transportista
{
    partial class ModificarLongitudCreacionCodigosPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarLongitudCreacionCodigosPersonal));
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.rbtCincoDigitos = new Telerik.WinControls.UI.RadRadioButton();
            this.rbtOchoDigitos = new Telerik.WinControls.UI.RadRadioButton();
            this.gbLongitudCreacionCodigos = new Telerik.WinControls.UI.RadGroupBox();
            this.Salir = new Telerik.WinControls.UI.RadButton();
            this.btnActualizar = new Telerik.WinControls.UI.RadButton();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.rbtCincoDigitos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtOchoDigitos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbLongitudCreacionCodigos)).BeginInit();
            this.gbLongitudCreacionCodigos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rbtCincoDigitos
            // 
            this.rbtCincoDigitos.Location = new System.Drawing.Point(24, 41);
            this.rbtCincoDigitos.Name = "rbtCincoDigitos";
            this.rbtCincoDigitos.Size = new System.Drawing.Size(117, 18);
            this.rbtCincoDigitos.TabIndex = 0;
            this.rbtCincoDigitos.Text = "Registro a 5 dígitos";
            this.rbtCincoDigitos.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rbtCincoDigitos_ToggleStateChanged);
            // 
            // rbtOchoDigitos
            // 
            this.rbtOchoDigitos.Location = new System.Drawing.Point(331, 41);
            this.rbtOchoDigitos.Name = "rbtOchoDigitos";
            this.rbtOchoDigitos.Size = new System.Drawing.Size(117, 18);
            this.rbtOchoDigitos.TabIndex = 1;
            this.rbtOchoDigitos.Text = "Registro a 8 dígitos";
            this.rbtOchoDigitos.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rbtOchoDigitos_ToggleStateChanged);
            // 
            // gbLongitudCreacionCodigos
            // 
            this.gbLongitudCreacionCodigos.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbLongitudCreacionCodigos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLongitudCreacionCodigos.Controls.Add(this.rbtCincoDigitos);
            this.gbLongitudCreacionCodigos.Controls.Add(this.rbtOchoDigitos);
            this.gbLongitudCreacionCodigos.HeaderText = "Longitud para la creación de codigo del personal";
            this.gbLongitudCreacionCodigos.Location = new System.Drawing.Point(12, 9);
            this.gbLongitudCreacionCodigos.Name = "gbLongitudCreacionCodigos";
            this.gbLongitudCreacionCodigos.Size = new System.Drawing.Size(492, 100);
            this.gbLongitudCreacionCodigos.TabIndex = 2;
            this.gbLongitudCreacionCodigos.Text = "Longitud para la creación de codigo del personal";
            this.gbLongitudCreacionCodigos.ThemeName = "Breeze";
            // 
            // Salir
            // 
            this.Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Salir.Image = ((System.Drawing.Image)(resources.GetObject("Salir.Image")));
            this.Salir.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.Salir.Location = new System.Drawing.Point(408, 131);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(89, 25);
            this.Salir.TabIndex = 202;
            this.Salir.Text = "   Cerrar";
            this.Salir.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Salir.ThemeName = "Office2010Blue";
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(303, 131);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 25);
            this.btnActualizar.TabIndex = 201;
            this.btnActualizar.Text = "   &Actualizar";
            this.btnActualizar.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.ThemeName = "Office2010Blue";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // ModificarLongitudCreacionCodigosPersonal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(516, 178);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.gbLongitudCreacionCodigos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModificarLongitudCreacionCodigosPersonal";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar la Longitud para la Creacion de Codigos Personal ";
            this.ThemeName = "Windows8";
            this.Load += new System.EventHandler(this.ModificarLongitudCreacionCodigosPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbtCincoDigitos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtOchoDigitos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbLongitudCreacionCodigos)).EndInit();
            this.gbLongitudCreacionCodigos.ResumeLayout(false);
            this.gbLongitudCreacionCodigos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnActualizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadRadioButton rbtCincoDigitos;
        private Telerik.WinControls.UI.RadRadioButton rbtOchoDigitos;
        private Telerik.WinControls.UI.RadGroupBox gbLongitudCreacionCodigos;
        private Telerik.WinControls.UI.RadButton Salir;
        private Telerik.WinControls.UI.RadButton btnActualizar;
        private System.ComponentModel.BackgroundWorker bgwHilo;
    }
}
