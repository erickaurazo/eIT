namespace ModuloRecursosHumanos
{
    partial class Acceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceso));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnDetalle = new System.Windows.Forms.Panel();
            this.lblErrorContraseña = new System.Windows.Forms.Label();
            this.lblErrorUsuario = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.cboBasesDatos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMensajeUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(177, 209);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(96, 209);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // pnDetalle
            // 
            this.pnDetalle.Controls.Add(this.lblErrorContraseña);
            this.pnDetalle.Controls.Add(this.lblErrorUsuario);
            this.pnDetalle.Controls.Add(this.cboEmpresa);
            this.pnDetalle.Controls.Add(this.cboBasesDatos);
            this.pnDetalle.Controls.Add(this.label2);
            this.pnDetalle.Controls.Add(this.label1);
            this.pnDetalle.Controls.Add(this.txtContraseña);
            this.pnDetalle.Controls.Add(this.txtUsuario);
            this.pnDetalle.Controls.Add(this.lblContraseña);
            this.pnDetalle.Controls.Add(this.lblUsuario);
            this.pnDetalle.Location = new System.Drawing.Point(5, 94);
            this.pnDetalle.Name = "pnDetalle";
            this.pnDetalle.Size = new System.Drawing.Size(356, 109);
            this.pnDetalle.TabIndex = 6;
            // 
            // lblErrorContraseña
            // 
            this.lblErrorContraseña.AutoSize = true;
            this.lblErrorContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorContraseña.ForeColor = System.Drawing.Color.IndianRed;
            this.lblErrorContraseña.Location = new System.Drawing.Point(18, 87);
            this.lblErrorContraseña.Name = "lblErrorContraseña";
            this.lblErrorContraseña.Size = new System.Drawing.Size(12, 13);
            this.lblErrorContraseña.TabIndex = 10;
            this.lblErrorContraseña.Text = "*";
            this.lblErrorContraseña.Visible = false;
            // 
            // lblErrorUsuario
            // 
            this.lblErrorUsuario.AutoSize = true;
            this.lblErrorUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorUsuario.ForeColor = System.Drawing.Color.IndianRed;
            this.lblErrorUsuario.Location = new System.Drawing.Point(41, 63);
            this.lblErrorUsuario.Name = "lblErrorUsuario";
            this.lblErrorUsuario.Size = new System.Drawing.Size(12, 13);
            this.lblErrorUsuario.TabIndex = 9;
            this.lblErrorUsuario.Text = "*";
            this.lblErrorUsuario.Visible = false;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.Enabled = false;
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(114, 36);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(232, 21);
            this.cboEmpresa.TabIndex = 4;
            // 
            // cboBasesDatos
            // 
            this.cboBasesDatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBasesDatos.Enabled = false;
            this.cboBasesDatos.FormattingEnabled = true;
            this.cboBasesDatos.Location = new System.Drawing.Point(114, 11);
            this.cboBasesDatos.Name = "cboBasesDatos";
            this.cboBasesDatos.Size = new System.Drawing.Size(232, 21);
            this.cboBasesDatos.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Empresa :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base de Datos :";
            // 
            // txtContraseña
            // 
            this.txtContraseña.AcceptsTab = true;
            this.txtContraseña.Location = new System.Drawing.Point(114, 83);
            this.txtContraseña.MaxLength = 25;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(232, 20);
            this.txtContraseña.TabIndex = 8;
            this.txtContraseña.UseSystemPasswordChar = true;
            this.txtContraseña.AcceptsTabChanged += new System.EventHandler(this.txtContraseña_AcceptsTabChanged);
            this.txtContraseña.TabIndexChanged += new System.EventHandler(this.txtContraseña_TabIndexChanged);
            this.txtContraseña.TextChanged += new System.EventHandler(this.txtContraseña_TextChanged);
            this.txtContraseña.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseña_KeyPress);
            this.txtContraseña.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtContraseña_KeyUp);
            this.txtContraseña.Leave += new System.EventHandler(this.txtContraseña_Leave);
            this.txtContraseña.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtContraseña_PreviewKeyDown);
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Location = new System.Drawing.Point(114, 60);
            this.txtUsuario.MaxLength = 25;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(232, 20);
            this.txtUsuario.TabIndex = 6;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(34, 87);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(67, 13);
            this.lblContraseña.TabIndex = 7;
            this.lblContraseña.Text = "Contraseña :";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(52, 61);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(49, 13);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuario :";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(96, 209);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblMensajeUsuario
            // 
            this.lblMensajeUsuario.AutoSize = true;
            this.lblMensajeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            this.lblMensajeUsuario.ForeColor = System.Drawing.Color.IndianRed;
            this.lblMensajeUsuario.Location = new System.Drawing.Point(12, 237);
            this.lblMensajeUsuario.Name = "lblMensajeUsuario";
            this.lblMensajeUsuario.Size = new System.Drawing.Size(54, 13);
            this.lblMensajeUsuario.TabIndex = 8;
            this.lblMensajeUsuario.Text = "Mensaje";
            this.lblMensajeUsuario.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Acceso
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(373, 259);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMensajeUsuario);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pnDetalle);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Acceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso Sistema";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnDetalle.ResumeLayout(false);
            this.pnDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel pnDetalle;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.ComboBox cboBasesDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblErrorContraseña;
        private System.Windows.Forms.Label lblErrorUsuario;
        private System.Windows.Forms.Label lblMensajeUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}