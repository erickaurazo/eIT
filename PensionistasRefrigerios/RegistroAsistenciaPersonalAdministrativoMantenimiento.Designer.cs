namespace Transportista
{
    partial class RegistroAsistenciaPersonalAdministrativoMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroAsistenciaPersonalAdministrativoMantenimiento));
            this.barraPrincipal = new Telerik.WinControls.UI.RadCommandBar();
            this.BarraSuperior = new Telerik.WinControls.UI.CommandBarRowElement();
            this.BarraModulo = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnRRHH = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarStripElement3 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnNuevo = new Telerik.WinControls.UI.CommandBarButton();
            this.btnEditar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnGuardar = new Telerik.WinControls.UI.CommandBarButton();
            this.btnAnular = new Telerik.WinControls.UI.CommandBarButton();
            this.btnSalir = new Telerik.WinControls.UI.CommandBarButton();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.gbMantenimiento = new Telerik.WinControls.UI.RadGroupBox();
            this.txtEstado = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarTrabajador = new MyControlsDataBinding.Controles.MyButtonSearchSimple(this.components);
            this.txtNroDni = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.txtTrabajador = new MyControlsDataBinding.Controles.MyTextBoxSearchSimple(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiaSemana = new Telerik.WinControls.UI.RadTextBox();
            this.txtFechaDesde = new MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barraPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMantenimiento)).BeginInit();
            this.gbMantenimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaSemana)).BeginInit();
            this.SuspendLayout();
            // 
            // barraPrincipal
            // 
            this.barraPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.barraPrincipal.Name = "barraPrincipal";
            this.barraPrincipal.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.BarraSuperior});
            this.barraPrincipal.Size = new System.Drawing.Size(606, 37);
            this.barraPrincipal.TabIndex = 1;
            this.barraPrincipal.ThemeName = "VisualStudio2012Light";
            // 
            // BarraSuperior
            // 
            this.BarraSuperior.BackColor = System.Drawing.SystemColors.Control;
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
            this.btnRRHH.Text = "     Recursos Humanos    ";
            this.btnRRHH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRRHH.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnRRHH.ToolTipText = "Recursos Humanos";
            // 
            // commandBarStripElement3
            // 
            this.commandBarStripElement3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement3.DisplayName = "commandBarStripElement3";
            this.commandBarStripElement3.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnGuardar,
            this.btnAnular,
            this.btnSalir});
            this.commandBarStripElement3.Name = "commandBarStripElement3";
            this.commandBarStripElement3.Text = "";
            this.commandBarStripElement3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.commandBarStripElement3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleDescription = "Nuevo";
            this.btnNuevo.AccessibleName = "Nuevo";
            this.btnNuevo.AutoSize = false;
            this.btnNuevo.Bounds = new System.Drawing.Rectangle(0, 0, 80, 35);
            this.btnNuevo.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.DisplayName = "Nuevo";
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "";
            this.btnNuevo.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnNuevo.ToolTipText = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AccessibleDescription = "Editar";
            this.btnEditar.AccessibleName = "Editar";
            this.btnEditar.AutoSize = false;
            this.btnEditar.Bounds = new System.Drawing.Rectangle(0, 0, 80, 35);
            this.btnEditar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEditar.DisplayName = "Editar";
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Text = "";
            this.btnEditar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnEditar.ToolTipText = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = false;
            this.btnGuardar.Bounds = new System.Drawing.Rectangle(0, 0, 80, 35);
            this.btnGuardar.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnGuardar.DisplayName = "commandBarButton1";
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "";
            this.btnGuardar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnGuardar.ToolTipText = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.AccessibleDescription = "Anular";
            this.btnAnular.AccessibleName = "Anular";
            this.btnAnular.AutoSize = false;
            this.btnAnular.Bounds = new System.Drawing.Rectangle(0, 0, 80, 35);
            this.btnAnular.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAnular.DisplayName = "Anular";
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Text = "";
            this.btnAnular.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAnular.ToolTipText = "Anular";
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleDescription = "Salir";
            this.btnSalir.AccessibleName = "Salir";
            this.btnSalir.AutoSize = false;
            this.btnSalir.Bounds = new System.Drawing.Rectangle(0, 0, 80, 35);
            this.btnSalir.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.DisplayName = "Salir";
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "";
            this.btnSalir.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnSalir.ToolTipText = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbMantenimiento
            // 
            this.gbMantenimiento.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbMantenimiento.Controls.Add(this.txtEstado);
            this.gbMantenimiento.Controls.Add(this.label4);
            this.gbMantenimiento.Controls.Add(this.btnBuscarTrabajador);
            this.gbMantenimiento.Controls.Add(this.label3);
            this.gbMantenimiento.Controls.Add(this.label2);
            this.gbMantenimiento.Controls.Add(this.txtDiaSemana);
            this.gbMantenimiento.Controls.Add(this.txtFechaDesde);
            this.gbMantenimiento.Controls.Add(this.label1);
            this.gbMantenimiento.Controls.Add(this.txtTrabajador);
            this.gbMantenimiento.Controls.Add(this.txtNroDni);
            this.gbMantenimiento.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbMantenimiento.HeaderText = "";
            this.gbMantenimiento.Location = new System.Drawing.Point(6, 41);
            this.gbMantenimiento.Name = "gbMantenimiento";
            this.gbMantenimiento.Size = new System.Drawing.Size(596, 101);
            this.gbMantenimiento.TabIndex = 2;
            this.gbMantenimiento.ThemeName = "VisualStudio2012Light";
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstado.Location = new System.Drawing.Point(436, 22);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(155, 20);
            this.txtEstado.TabIndex = 7;
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstado.ThemeName = "Windows8";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(492, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado :";
            // 
            // btnBuscarTrabajador
            // 
            this.btnBuscarTrabajador.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarTrabajador.Image")));
            this.btnBuscarTrabajador.Location = new System.Drawing.Point(7, 69);
            this.btnBuscarTrabajador.Name = "btnBuscarTrabajador";
            this.btnBuscarTrabajador.P_CampoCodigo = "";
            this.btnBuscarTrabajador.P_CampoDescripcion = "";
            this.btnBuscarTrabajador.P_EsEditable = true;
            this.btnBuscarTrabajador.P_EsModificable = true;
            this.btnBuscarTrabajador.P_FilterByTextBox = null;
            this.btnBuscarTrabajador.P_TablaConsulta = "";
            this.btnBuscarTrabajador.P_TextBoxCodigo = this.txtNroDni;
            this.btnBuscarTrabajador.P_TextBoxDescripcion = this.txtTrabajador;
            this.btnBuscarTrabajador.P_TituloFormulario = "";
            this.btnBuscarTrabajador.Size = new System.Drawing.Size(24, 23);
            this.btnBuscarTrabajador.TabIndex = 8;
            this.btnBuscarTrabajador.UseVisualStyleBackColor = true;
            this.btnBuscarTrabajador.Click += new System.EventHandler(this.btnBuscarTrabajador_Click);
            // 
            // txtNroDni
            // 
            this.txtNroDni.BackColor = System.Drawing.Color.White;
            this.txtNroDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtNroDni.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNroDni.Location = new System.Drawing.Point(36, 72);
            this.txtNroDni.MaxLength = 30;
            this.txtNroDni.Name = "txtNroDni";
            this.txtNroDni.P_BotonEnlace = null;
            this.txtNroDni.P_BuscarSoloCodigoExacto = false;
            this.txtNroDni.P_EsEditable = false;
            this.txtNroDni.P_EsModificable = false;
            this.txtNroDni.P_EsPrimaryKey = false;
            this.txtNroDni.P_ExigeInformacion = false;
            this.txtNroDni.P_NombreColumna = null;
            this.txtNroDni.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtNroDni.Size = new System.Drawing.Size(73, 20);
            this.txtNroDni.TabIndex = 9;
            this.txtNroDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTrabajador
            // 
            this.txtTrabajador.BackColor = System.Drawing.Color.White;
            this.txtTrabajador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtTrabajador.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTrabajador.Location = new System.Drawing.Point(115, 72);
            this.txtTrabajador.Name = "txtTrabajador";
            this.txtTrabajador.P_BotonEnlace = null;
            this.txtTrabajador.P_BuscarSoloCodigoExacto = false;
            this.txtTrabajador.P_EsEditable = false;
            this.txtTrabajador.P_EsModificable = false;
            this.txtTrabajador.P_EsPrimaryKey = false;
            this.txtTrabajador.P_ExigeInformacion = false;
            this.txtTrabajador.P_NombreColumna = null;
            this.txtTrabajador.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtTrabajador.ReadOnly = true;
            this.txtTrabajador.Size = new System.Drawing.Size(476, 20);
            this.txtTrabajador.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trabajador :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Día de la Semana :";
            // 
            // txtDiaSemana
            // 
            this.txtDiaSemana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDiaSemana.Location = new System.Drawing.Point(246, 22);
            this.txtDiaSemana.Name = "txtDiaSemana";
            this.txtDiaSemana.Size = new System.Drawing.Size(89, 20);
            this.txtDiaSemana.TabIndex = 6;
            this.txtDiaSemana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiaSemana.ThemeName = "Windows8";
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.EditingControlDataGridView = null;
            this.txtFechaDesde.EditingControlFormattedValue = "  /  /       :";
            this.txtFechaDesde.EditingControlRowIndex = 0;
            this.txtFechaDesde.EditingControlValueChanged = true;
            this.txtFechaDesde.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFechaDesde.Location = new System.Drawing.Point(7, 22);
            this.txtFechaDesde.Mask = "00/00/0000 00:00";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.P_EsEditable = false;
            this.txtFechaDesde.P_EsModificable = false;
            this.txtFechaDesde.P_ExigeInformacion = false;
            this.txtFechaDesde.P_Hora = null;
            this.txtFechaDesde.P_NombreColumna = null;
            this.txtFechaDesde.P_TipoDato = MyControlsDataBinding.Extensions.EnumTipoDato.Texto;
            this.txtFechaDesde.Size = new System.Drawing.Size(118, 20);
            this.txtFechaDesde.TabIndex = 4;
            this.txtFechaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            this.txtFechaDesde.Leave += new System.EventHandler(this.txtFechaDesde_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha :";
            // 
            // RegistroAsistenciaPersonalAdministrativoMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 147);
            this.Controls.Add(this.gbMantenimiento);
            this.Controls.Add(this.barraPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegistroAsistenciaPersonalAdministrativoMantenimiento";
            this.Text = "Mantenimiento del Registro de Asistencia del Personal Administrativo (Entradas y " +
    "Salidas)";
            this.Load += new System.EventHandler(this.RegistroAsistenciaPersonalAdministrativoMantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barraPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMantenimiento)).EndInit();
            this.gbMantenimiento.ResumeLayout(false);
            this.gbMantenimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaSemana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadCommandBar barraPrincipal;
        private Telerik.WinControls.UI.CommandBarRowElement BarraSuperior;
        private Telerik.WinControls.UI.CommandBarStripElement BarraModulo;
        private Telerik.WinControls.UI.CommandBarButton btnRRHH;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement3;
        private Telerik.WinControls.UI.CommandBarButton btnNuevo;
        private Telerik.WinControls.UI.CommandBarButton btnEditar;
        private Telerik.WinControls.UI.CommandBarButton btnGuardar;
        private Telerik.WinControls.UI.CommandBarButton btnAnular;
        private Telerik.WinControls.UI.CommandBarButton btnSalir;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private Telerik.WinControls.UI.RadGroupBox gbMantenimiento;
        private MyDataGridViewColumns.MyDataGridViewMaskedTextEditingControl txtFechaDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadTextBox txtDiaSemana;
        private System.Windows.Forms.Label label3;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtTrabajador;
        private MyControlsDataBinding.Controles.MyTextBoxSearchSimple txtNroDni;
        private MyControlsDataBinding.Controles.MyButtonSearchSimple btnBuscarTrabajador;
        private Telerik.WinControls.UI.RadTextBox txtEstado;
        private System.Windows.Forms.Label label4;
    }
}