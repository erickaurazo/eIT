namespace RecursosHumanos
{
    partial class Historial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Historial));
            this.gbHistorial = new System.Windows.Forms.GroupBox();
            this.dgvHistorial = new MyControlsDataBinding.Controles.MyDataGridViewDetails(this.components);
            this.chEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chMaquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bgwHilo = new System.ComponentModel.BackgroundWorker();
            this.gbHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // gbHistorial
            // 
            this.gbHistorial.Controls.Add(this.dgvHistorial);
            this.gbHistorial.Location = new System.Drawing.Point(5, 67);
            this.gbHistorial.Name = "gbHistorial";
            this.gbHistorial.Size = new System.Drawing.Size(496, 311);
            this.gbHistorial.TabIndex = 5;
            this.gbHistorial.TabStop = false;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Honeydew;
            this.dgvHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistorial.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chEvento,
            this.chUsuario,
            this.chFecha,
            this.chMaquina});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistorial.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.GridColor = System.Drawing.SystemColors.Control;
            this.dgvHistorial.Location = new System.Drawing.Point(3, 16);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.P_EsEditable = false;
            this.dgvHistorial.P_FormatoDecimal = null;
            this.dgvHistorial.P_FormatoFecha = null;
            this.dgvHistorial.P_NombreColCorrelativa = null;
            this.dgvHistorial.P_NombreTabla = null;
            this.dgvHistorial.P_NumeroDigitos = 0;
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHistorial.RowHeadersWidth = 34;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(490, 292);
            this.dgvHistorial.TabIndex = 0;
            // 
            // chEvento
            // 
            this.chEvento.DataPropertyName = "evento";
            this.chEvento.HeaderText = "Evento";
            this.chEvento.Name = "chEvento";
            this.chEvento.ReadOnly = true;
            // 
            // chUsuario
            // 
            this.chUsuario.DataPropertyName = "usuario";
            this.chUsuario.HeaderText = "usuario";
            this.chUsuario.Name = "chUsuario";
            this.chUsuario.ReadOnly = true;
            // 
            // chFecha
            // 
            this.chFecha.DataPropertyName = "fecha";
            this.chFecha.HeaderText = "Fecha";
            this.chFecha.Name = "chFecha";
            this.chFecha.ReadOnly = true;
            this.chFecha.Width = 120;
            // 
            // chMaquina
            // 
            this.chMaquina.DataPropertyName = "maquina";
            this.chMaquina.HeaderText = "Maquina";
            this.chMaquina.Name = "chMaquina";
            this.chMaquina.ReadOnly = true;
            this.chMaquina.Width = 130;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightYellow;
            this.textBox1.Location = new System.Drawing.Point(6, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(496, 49);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // bgwHilo
            // 
            this.bgwHilo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHilo_DoWork);
            this.bgwHilo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwHilo_RunWorkerCompleted);
            // 
            // Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 390);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gbHistorial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Historial";
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.Historial_Load);
            this.gbHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHistorial;
        private MyControlsDataBinding.Controles.MyDataGridViewDetails dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn chEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn chUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn chFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn chMaquina;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker bgwHilo;
    }
}