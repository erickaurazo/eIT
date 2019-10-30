namespace RecursosHumanos
{
    partial class ElegirPlanilla
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
            this.lblSemana = new System.Windows.Forms.Label();
            this.txtFechaHasta = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.txtPeriodo = new Telerik.WinControls.UI.RadSpinEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.cboMes = new Telerik.WinControls.UI.RadDropDownList();
            this.label5 = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.cboSemana = new Telerik.WinControls.UI.RadDropDownList();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPlanilla = new Telerik.WinControls.UI.RadDropDownList();
            this.btnAceptar = new Telerik.WinControls.UI.RadButton();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.tableAdapterManager1 = new RecursosHumanos.ImprimirIngresoSalidaPersonalDSTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSemana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSemana
            // 
            this.lblSemana.AutoSize = true;
            this.lblSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana.Location = new System.Drawing.Point(24, 106);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Size = new System.Drawing.Size(60, 13);
            this.lblSemana.TabIndex = 8;
            this.lblSemana.Text = "Semana :";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.EditingControlDataGridView = null;
            this.txtFechaHasta.EditingControlFormattedValue = "  /  /";
            this.txtFechaHasta.EditingControlRowIndex = 0;
            this.txtFechaHasta.EditingControlValueChanged = true;
            this.txtFechaHasta.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaHasta.Location = new System.Drawing.Point(380, 105);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.P_EsEditable = false;
            this.txtFechaHasta.P_EsModificable = false;
            this.txtFechaHasta.P_ExigeInformacion = false;
            this.txtFechaHasta.P_Hora = null;
            this.txtFechaHasta.P_NombreColumna = null;
            this.txtFechaHasta.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaHasta.ReadOnly = true;
            this.txtFechaHasta.Size = new System.Drawing.Size(98, 20);
            this.txtFechaHasta.TabIndex = 13;
            this.txtFechaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.EditingControlDataGridView = null;
            this.txtFechaDesde.EditingControlFormattedValue = "  /  /";
            this.txtFechaDesde.EditingControlRowIndex = 0;
            this.txtFechaDesde.EditingControlValueChanged = true;
            this.txtFechaDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaDesde.Location = new System.Drawing.Point(214, 103);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaDesde.ReadOnly = true;
            this.txtFechaDesde.Size = new System.Drawing.Size(99, 20);
            this.txtFechaDesde.TabIndex = 11;
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(89, 66);
            this.txtPeriodo.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.txtPeriodo.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.txtPeriodo.Name = "txtPeriodo";
            // 
            // 
            // 
            this.txtPeriodo.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.txtPeriodo.Size = new System.Drawing.Size(62, 20);
            this.txtPeriodo.TabIndex = 5;
            this.txtPeriodo.TabStop = false;
            this.txtPeriodo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeriodo.ThemeName = "Windows8";
            this.txtPeriodo.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.txtPeriodo.ValueChanged += new System.EventHandler(this.txtPeriodo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Año :";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(157, 107);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(55, 13);
            this.lblFechaDesde.TabIndex = 10;
            this.lblFechaDesde.Text = " Desde :";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(324, 108);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(52, 13);
            this.lblFechaHasta.TabIndex = 12;
            this.lblFechaHasta.Text = " Hasta :";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboMes.Location = new System.Drawing.Point(214, 66);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(264, 20);
            this.cboMes.TabIndex = 7;
            this.cboMes.ThemeName = "VisualStudio2012Light";
            this.cboMes.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(174, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mes :";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.cboSemana);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.cboPlanilla);
            this.radGroupBox1.Controls.Add(this.btnAceptar);
            this.radGroupBox1.Controls.Add(this.txtPeriodo);
            this.radGroupBox1.Controls.Add(this.lblSemana);
            this.radGroupBox1.Controls.Add(this.label5);
            this.radGroupBox1.Controls.Add(this.txtFechaHasta);
            this.radGroupBox1.Controls.Add(this.cboMes);
            this.radGroupBox1.Controls.Add(this.txtFechaDesde);
            this.radGroupBox1.Controls.Add(this.lblFechaDesde);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.lblFechaHasta);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Elegir opción";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(510, 167);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Elegir opción";
            this.radGroupBox1.ThemeName = "VisualStudio2012Light";
            this.radGroupBox1.Click += new System.EventHandler(this.radGroupBox1_Click);
            // 
            // cboSemana
            // 
            this.cboSemana.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboSemana.Location = new System.Drawing.Point(90, 103);
            this.cboSemana.Name = "cboSemana";
            this.cboSemana.Size = new System.Drawing.Size(61, 20);
            this.cboSemana.TabIndex = 9;
            this.cboSemana.ThemeName = "VisualStudio2012Light";
            this.cboSemana.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboSemana_SelectedIndexChanged);
            this.cboSemana.Leave += new System.EventHandler(this.cboSemana_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Planilla :";
            // 
            // cboPlanilla
            // 
            this.cboPlanilla.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cboPlanilla.Location = new System.Drawing.Point(89, 34);
            this.cboPlanilla.Name = "cboPlanilla";
            this.cboPlanilla.Size = new System.Drawing.Size(389, 20);
            this.cboPlanilla.TabIndex = 3;
            this.cboPlanilla.ThemeName = "VisualStudio2012Light";
            this.cboPlanilla.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cboPlanilla_SelectedIndexChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(369, 140);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 24);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ThemeName = "VisualStudio2012Light";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = RecursosHumanos.ImprimirIngresoSalidaPersonalDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // ElegirPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 194);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ElegirPlanilla";
            this.Text = "Elegir planilla para trabajar";
            this.Load += new System.EventHandler(this.SelecionTipoPlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSemana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlanilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSemana;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaHasta;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private Telerik.WinControls.UI.RadSpinEditor txtPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private Telerik.WinControls.UI.RadDropDownList cboMes;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnAceptar;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadDropDownList cboPlanilla;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.UI.RadDropDownList cboSemana;
        private ImprimirIngresoSalidaPersonalDSTableAdapters.TableAdapterManager tableAdapterManager1;
    }
}