using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
using RecursosHumanos.Negocios;
using System.Configuration;
using DevSoftSolutionsControls;
using DevSoftSolutionsDataAccess;
using DevSoftSolutionsExtensions;
using System.Linq;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using System.Collections;
using MyControlsDataBinding.Controles;


namespace RecursosHumanos
{
    public partial class MarcacionPuertaMantenimiento : Form
    {
        private string codigoEditar;
        private string fechaEditar;
        private Datos.UsuarioMovimientoIngresoSistema usuario;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> listadoPersonal;
        private CheckInOutNegocio modelo;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult> listadoMarcacionPersonalByPersona;
        private string dniEditar = string.Empty;
        private List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> listadoPersonalAgrupado;
        private string nombresEditar;
        private int CorrelativoEditar;
        private MarcacionPuertaMantenimientoEdicionMarcacion oFormularioEdicion;
        private string codidoUsuarioBiometrico;
        private MarcacionPuertaMantenimientoImportarMarcacionByPersonal oFormularioImportar;
        private string fileName;
        private bool exportVisualSettings;
        private MarcacionPuertaMantenimientoTransferenciaMarcacion oFormularioTransferir;
        private string codigoUnicoMovimiento;
        private string codigoMovimiento;
        private string confirmacionMsg;
        private MarcacionPuertaMantenimientoImportarMarcacion oFormularioImportarByFecha;
        private string codigoPlanilla;
        private string semanaDesde;
        private string semanaHasta;
        private string periodoSelecionado;


        public MarcacionPuertaMantenimiento()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public MarcacionPuertaMantenimiento(string codigoEditar, string fechaEditar, Datos.UsuarioMovimientoIngresoSistema usuario, string codigoMovimiento, string codigoPlanilla, string semanaDesde, string semanaHasta, string periodoSelecionado)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.codigoEditar = codigoEditar;
            this.fechaEditar = fechaEditar;
            this.usuario = usuario;
            this.codigoMovimiento = codigoMovimiento;
            this.codigoPlanilla = codigoPlanilla;
            this.semanaDesde = semanaDesde;
            this.semanaHasta = semanaHasta;
            this.periodoSelecionado = periodoSelecionado;


            RadGridLocalizationProvider.CurrentProvider = new ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            gbDatosGenerales.Enabled = false;
            gbDetalleMarcacion.Enabled = false;
            gbListadoPersonal.Enabled = false;
            ProgressBarF.Visible = !false;
            bwgHilo.RunWorkerAsync();

        }

 

        private void MarcacionPuertaMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listadoPersonal = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
                listadoPersonalAgrupado = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
                modelo = new CheckInOutNegocio();
                listadoPersonal = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFecha(Program.ClaseCompartida.periodoElegido, this.fechaEditar, Program.ClaseCompartida.codigoTipoPlanilla, this.codigoEditar).ToList();

                listadoPersonalAgrupado = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaAgrupadoByMarcacionByPersona(listadoPersonal);

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvListadoPersonal.DataSource = listadoPersonalAgrupado.ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
                dgvListadoPersonal.Refresh();

                lblNroPersonas.Text = listadoPersonalAgrupado.Count.ToString();
                txtcodigoTransferencia.Text = this.codigoEditar;
                this.txtFecha.Text = this.fechaEditar;
                this.txtMovimientoAsistencia.Text = this.codigoMovimiento;
                lblFechaDescripcionLarga.Text = Convert.ToDateTime(this.fechaEditar).ToLongDateString().ToUpper();
                gbDatosGenerales.Enabled = !false;
                gbDetalleMarcacion.Enabled = !false;
                gbListadoPersonal.Enabled = !false;
                ProgressBarF.Visible = false;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHiloDetalleMarcacion_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listadoMarcacionPersonalByPersona = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult>();
                modelo = new CheckInOutNegocio();
                listadoMarcacionPersonalByPersona = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNI(Program.ClaseCompartida.periodoElegido, this.fechaEditar, Program.ClaseCompartida.codigoTipoPlanilla, this.codigoEditar, dniEditar).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void bgwHiloDetalleMarcacion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvDetalle.DataSource = listadoMarcacionPersonalByPersona.OrderBy(x => x.horaMarcacion).ToList().ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult>();
                dgvDetalle.Refresh();
                gbDatosGenerales.Enabled = !false;
                gbDetalleMarcacion.Enabled = !false;
                gbListadoPersonal.Enabled = !false;
                ProgressBarF.Visible = false;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnActualizarListado_Click(object sender, EventArgs e)
        {
            gbDatosGenerales.Enabled = false;
            gbDetalleMarcacion.Enabled = false;
            gbListadoPersonal.Enabled = false;
            ProgressBarF.Visible = !false;
            bwgHilo.RunWorkerAsync();
        }

        private void dgvListadoPersonal_SelectionChanged(object sender, EventArgs e)
        {
            this.txtNombres.Clear();
            this.txtDNI.Clear();
            this.txtCodigoBiometricoPersonal.Clear();
            List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult> listaDetalleNueva = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();

            dgvDetalle.DataSource = listaDetalleNueva.ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
            dgvDetalle.Refresh();

            if (dgvListadoPersonal != null && dgvListadoPersonal.Rows.Count > 0)
            {
                if (dgvListadoPersonal.CurrentRow != null)
                {
                    if (dgvListadoPersonal.CurrentRow.Cells["chDNI"].Value != null && dgvListadoPersonal.CurrentRow.Cells["chDNI"].Value.ToString().Trim() != "")
                    {
                        if (dgvListadoPersonal.CurrentRow.Cells["chNombres"].Value != null && dgvListadoPersonal.CurrentRow.Cells["chNombres"].Value.ToString().Trim() != "")
                        {
                            dniEditar = dgvListadoPersonal.CurrentRow.Cells["chDNI"].Value != null ? dgvListadoPersonal.CurrentRow.Cells["chDNI"].Value.ToString().Trim() : string.Empty;
                            nombresEditar = dgvListadoPersonal.CurrentRow.Cells["chNombres"].Value != null ? dgvListadoPersonal.CurrentRow.Cells["chNombres"].Value.ToString().Trim() : string.Empty;
                            codidoUsuarioBiometrico = dgvListadoPersonal.CurrentRow.Cells["chcodigoUsuarioMarcacion"].Value != null ? dgvListadoPersonal.CurrentRow.Cells["chcodigoUsuarioMarcacion"].Value.ToString().Trim() : string.Empty;

                            this.txtNombres.Text = nombresEditar;
                            this.txtDNI.Text = dniEditar;
                            this.txtCodigoBiometricoPersonal.Text = codidoUsuarioBiometrico;

                        }

                    }
                }
            }
        }

        private void dgvListadoPersonal_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (dniEditar != string.Empty && nombresEditar != string.Empty)
                {
                    Editar(dniEditar, "001", Program.ClaseCompartida.periodoElegido, fechaEditar);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }
        }

        private void Editar(string dniEditar, string empresaCodigo, string periodo, string fechaEditar)
        {
            try
            {

                gbDatosGenerales.Enabled = false;
                gbDetalleMarcacion.Enabled = false;
                gbListadoPersonal.Enabled = false;
                ProgressBarF.Visible = !false;
                bgwHiloDetalleMarcacion.RunWorkerAsync();
                this.txtNombres.Text = nombresEditar;
                this.txtDNI.Text = dniEditar;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;

            }
        }

        private void btnGenerarAsistencia_Click(object sender, EventArgs e)
        {
            gbDatosGenerales.Enabled = false;
            gbListadoPersonal.Enabled = false;
            gbDetalleMarcacion.Enabled = false;
            ProgressBarF.Visible = true;
            bgwGenerarAsistencia.RunWorkerAsync();
        }

        private void btnOrdenarMarcaciones_Click(object sender, EventArgs e)
        {
            gbDatosGenerales.Enabled = false;
            gbDetalleMarcacion.Enabled = false;
            gbListadoPersonal.Enabled = false;
            ProgressBarF.Visible = !false;
            bwgOrdenarMarcaciones.RunWorkerAsync();
        }

        private void bwgOrdenarMarcaciones_DoWork(object sender, DoWorkEventArgs e)
        {
            modelo = new CheckInOutNegocio();
            modelo.ActualizarNumeroMarcacionesTransferenciaAsistenciaByFecha(Program.ClaseCompartida.periodoElegido, this.fechaEditar, this.txtcodigoTransferencia.Text.Trim());

            listadoMarcacionPersonalByPersona = new List<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNIResult>();
            modelo = new CheckInOutNegocio();
            listadoMarcacionPersonalByPersona = modelo.ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaByDNI(Program.ClaseCompartida.periodoElegido, this.fechaEditar, Program.ClaseCompartida.codigoTipoPlanilla, this.codigoEditar, dniEditar).ToList();
        }

        private void bwgOrdenarMarcaciones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvListadoPersonal.DataSource = listadoPersonalAgrupado.ToDataTable<ext_ObtenerListadoAllTransferenciaAsistenciaBiometroByWeekByFechaResult>();
                dgvListadoPersonal.Refresh();
                lblNroPersonas.Text = listadoPersonalAgrupado.Count.ToString();
                txtcodigoTransferencia.Text = this.codigoEditar;
                this.txtFecha.Text = this.fechaEditar;
                lblFechaDescripcionLarga.Text = Convert.ToDateTime(this.fechaEditar).ToLongDateString().ToUpper();
                gbDatosGenerales.Enabled = !false;
                gbDetalleMarcacion.Enabled = !false;
                gbListadoPersonal.Enabled = !false;
                ProgressBarF.Visible = false;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtcodigoTransferencia.Text.Trim() != "")
                {
                    Historial ofrm = new Historial(this.txtcodigoTransferencia.Text.ToString().Trim(), "0", "CheckInOut");
                    ofrm.Text = "Historial del documento de Facturación";
                    ofrm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El documento actual no contiene historial", "MENSAJE DEL SISTEMA");
                }

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void btnAgregarMarcacion_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnQuitarMarcacion_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarFila(CorrelativoEditar);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                QuitarFila(CorrelativoEditar);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void QuitarFila(int CorrelativoEditar)
        {
            if (this.dgvDetalle != null)
            {
                #region
                if (this.dgvDetalle.CurrentRow != null)
                {
                    if (MessageBox.Show(this, "¿Desea eliminar el elemento seleccionado?", "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            CheckInOut detalleEliminar = new CheckInOut();
                            detalleEliminar.correlativo = CorrelativoEditar;
                            modelo.EliminarMarcacionBiometricoByCorrelativo(Program.ClaseCompartida.periodoElegido, detalleEliminar);
                            dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
                        }
                        catch
                        {
                            Formateador.MostrarMensajeAdvertencia(this, "Seleccione un elemento de la grilla para eliminar ", "Validacion Ingreso de Datos");
                            return;
                        }
                    }
                    else
                    {
                        Formateador.MostrarMensajeAdvertencia(this, "Seleccione un elemento de la grilla para eliminar ", "Validacion Ingreso de Datos");
                    }
                }
                else
                {
                    Formateador.MostrarMensajeAdvertencia(this, "Haga click en la Grilla a Modificar", "Validacion Ingreso de Datos");
                }
                #endregion
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            oFormularioEdicion = new MarcacionPuertaMantenimientoEdicionMarcacion(CorrelativoEditar);
            //oFormulario.MdiParent = RegistroAsistenciaPersonalGarita.ActiveForm;                
            //oFormulario.WindowState = FormWindowState.Maximized;
            //oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            oFormularioEdicion.ShowDialog();
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            CorrelativoEditar = 0;

            if (dgvDetalle != null && dgvDetalle.Rows.Count > 0)
            {
                if (dgvDetalle.CurrentRow != null)
                {
                    if (dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value != null && dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value.ToString().Trim() != "")
                    {
                        CorrelativoEditar = dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value != null ? Convert.ToInt32(dgvDetalle.CurrentRow.Cells["chcorrelativo"].Value) : 0;

                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (this.txtNombres.Text != string.Empty
                && this.txtDNI.Text != string.Empty
                && this.txtCodigoBiometricoPersonal.Text != string.Empty
                && this.txtcodigoTransferencia.Text != string.Empty
                && this.txtFecha.Text != string.Empty)
            {

                string nombres = this.txtNombres.Text;
                string dni = this.txtDNI.Text;
                string codigoBiometricoPersona = this.txtCodigoBiometricoPersonal.Text;
                string AsistenciaCodigoMovimiento = txtcodigoTransferencia.Text;
                string fecha = this.txtFecha.Text;
                int correlativo = 0;

                oFormularioEdicion = new MarcacionPuertaMantenimientoEdicionMarcacion(nombres, dni, codigoBiometricoPersona, AsistenciaCodigoMovimiento, fecha, correlativo, this.codigoMovimiento.ToString());
                //oFormulario.MdiParent = RegistroAsistenciaPersonalGarita.ActiveForm;                
                //oFormulario.WindowState = FormWindowState.Maximized;
                //oFormulario.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                oFormularioEdicion.ShowDialog();
            }
        }

        private void btnImportarAsistencia_Click(object sender, EventArgs e)
        {
            if (this.txtNombres.Text != string.Empty
               && this.txtDNI.Text != string.Empty
               && this.txtCodigoBiometricoPersonal.Text != string.Empty
               && this.txtcodigoTransferencia.Text != string.Empty
               && this.txtFecha.Text != string.Empty)
            {

                string nombres = this.txtNombres.Text;
                string dni = this.txtDNI.Text;
                string codigoBiometricoPersona = this.txtCodigoBiometricoPersonal.Text;
                string AsistenciaCodigoMovimiento = txtMovimientoAsistencia.Text;
                string CodigoTransferencia = txtcodigoTransferencia.Text;
                string fecha = this.txtFecha.Text;
                int correlativo = 0;

                oFormularioImportar = new MarcacionPuertaMantenimientoImportarMarcacionByPersonal(nombres, dni, codigoBiometricoPersona, AsistenciaCodigoMovimiento, fecha, correlativo, CodigoTransferencia.ToString());
                if (oFormularioImportar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        /* Volvermos a refrescar */
                        gbDatosGenerales.Enabled = false;
                        gbDetalleMarcacion.Enabled = false;
                        gbListadoPersonal.Enabled = false;
                        ProgressBarF.Visible = !false;
                        bwgHilo.RunWorkerAsync();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                        return;
                    }
                }
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            if (this.txtNombres.Text != string.Empty
              && this.txtDNI.Text != string.Empty
              && this.txtCodigoBiometricoPersonal.Text != string.Empty
              && this.txtcodigoTransferencia.Text != string.Empty
              && this.txtFecha.Text != string.Empty)
            {

                string nombres = this.txtNombres.Text;
                string dni = this.txtDNI.Text;
                string codigoBiometricoPersona = this.txtCodigoBiometricoPersonal.Text;
                string AsistenciaCodigoMovimiento = txtMovimientoAsistencia.Text;
                string CodigoTransferencia = txtcodigoTransferencia.Text;
                string fecha = this.txtFecha.Text;

                oFormularioTransferir = new MarcacionPuertaMantenimientoTransferenciaMarcacion(nombres, dni, codigoBiometricoPersona, AsistenciaCodigoMovimiento, fecha, CorrelativoEditar, CodigoTransferencia);
                if (oFormularioTransferir.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        /* Volvermos a refrescar */
                        gbDatosGenerales.Enabled = false;
                        gbDetalleMarcacion.Enabled = false;
                        gbListadoPersonal.Enabled = false;
                        ProgressBarF.Visible = !false;
                        bwgHilo.RunWorkerAsync();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                        return;
                    }
                }
            }
        }

        private void dgvListadoPersonal_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dniEditar != string.Empty && nombresEditar != string.Empty)
            //    {
            //        Editar(dniEditar, "001", Program.ClaseCompartida.periodoElegido, fechaEditar);
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message, "Mensaje del Sistema");
            //    return;
            //}
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnExportarPersonalByHoras_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void ExportarExcel()
        {
            if (dgvListadoPersonal != null)
            {
                if (dgvListadoPersonal.Rows.Count > 0)
                {
                    Exportar(this.dgvListadoPersonal);
                }
            }
        }

        private void Exportar(RadGridView radGridView)
        {
            saveFileDialog.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (saveFileDialog.FileName.Equals(String.Empty))
            {
                RadMessageBox.SetThemeName(radGridView.ThemeName);
                RadMessageBox.Show("Ingrese nombre al archivo.");
                return;
            }

            fileName = this.saveFileDialog.FileName;
            bool openExportFile = false;
            this.exportVisualSettings = true;
            RunExportToExcelML(fileName, ref openExportFile, radGridView);


            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    string message = String.Format("El archivo no pudo ser ejecutado por el sistema.\nError message: {0}", ex.Message);
                    RadMessageBox.Show(message, "Abrir Archivo", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private void RunExportToExcelML(string fileName, ref bool openExportFile, RadGridView grilla)
        {
            ExportToExcelML excelExporter = new ExportToExcelML(grilla);
            excelExporter.SheetName = "Rpt Sistema";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
            excelExporter.HiddenColumnOption = HiddenOption.DoNotExport; /* no mostrar columnas ocultas*/
            try
            {
                excelExporter.RunExport(fileName);
                RadMessageBox.SetThemeName(grilla.ThemeName);
                DialogResult dr = RadMessageBox.Show("La exportación ha sido generada correctamente. Desea abrir el Archivo?",
                    "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openExportFile = true;
                }
            }
            catch (IOException ex)
            {
                RadMessageBox.SetThemeName(grilla.ThemeName);
                RadMessageBox.Show(this, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void bgwGenerarAsistencia_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                /* Verificar que las asistencias no tengan 0 */
                confirmacionMsg = string.Empty;
                if (listadoPersonalAgrupado.Where(x => x.horasAcumuladas == 0).ToList().Count == 0)
                {
                    if (this.txtMovimientoAsistencia.Text == string.Empty)
                    {
                        /* Crear código único para Generar el movimiento de Asistencia */
                        codigoUnicoMovimiento = modelo.ObtenerCodigoUnicoTransferencia(Program.ClaseCompartida.periodoElegido);

                        /* Enviar toda la lista para generar en un nuevo registro de Asistencia y Generar cabecera y detalle de Asistencia */
                        modelo.GenerarMovimientoAsistenciaDesdeMarcaciondeBiometricoByDia(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.codigoTipoPlanilla, Program.ClaseCompartida.semanaPlanilla, Program.ClaseCompartida.desde, Program.ClaseCompartida.hasta, this.txtFecha.Text, listadoPersonalAgrupado, codigoUnicoMovimiento, txtcodigoTransferencia.Text.Trim());


                        /* Actualizar en todas las tablas de checkinout el codigo del movimiento de asisntencia (generado en paso2) */
                        modelo.ActualizarMarcacionesBiometroConMovimientoAsistencia(Program.ClaseCompartida.periodoElegido, this.txtFecha.Text, codigoUnicoMovimiento);

                        confirmacionMsg += "Se ha generado correctamente el movimiento de Asistencia";
                    }
                    else
                    {
                        confirmacionMsg += "Ya existe generado una asistencia desde este registro";
                        //MessageBox.Show("Ya existe generado una asistencia desde este registro", "MENSAJE DEL SISTEMA");
                        //return;
                    }

                }
                else
                {
                    confirmacionMsg += "No se puede generar asistencia con 0.00 horas";
                    //MessageBox.Show("No se puede generar asistencia con 0.00 horas", "MENSAJE DEL SISTEMA");
                    return;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }

        }

        private void bgwGenerarAsistencia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {

                if (confirmacionMsg == "Se ha generado correctamente el movimiento de Asistencia")
                {
                    /* Grabar en la caja de texto de movimiento de Asistencia la Asistencia */
                    this.txtMovimientoAsistencia.Text = codigoUnicoMovimiento;
                }

                /* Enviar mensaje de confirmación */
                MessageBox.Show(confirmacionMsg, "MENSAJE DEL SISTEMA");

                /*Habilitar controles*/
                gbDatosGenerales.Enabled = !false;
                gbListadoPersonal.Enabled = !false;
                gbDetalleMarcacion.Enabled = !false;
                ProgressBarF.Visible = !true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                return;
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void btnImportarMarcacionByAsistencia_Click(object sender, EventArgs e)
        {
            #region ImportarMarcacionByAsistencia() 
            oFormularioImportarByFecha = new MarcacionPuertaMantenimientoImportarMarcacion(txtcodigoTransferencia.Text.Trim(), txtMovimientoAsistencia.Text.Trim(), txtEstadoDescripcion.Text.Trim(), txtFecha.Text.Trim(), this.codigoPlanilla, this.semanaDesde, this.semanaHasta, periodoSelecionado);
            if (oFormularioImportarByFecha.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /* Volvermos a refrescar */
                    gbDatosGenerales.Enabled = false;
                    gbDetalleMarcacion.Enabled = false;
                    gbListadoPersonal.Enabled = false;
                    ProgressBarF.Visible = !false;
                    bwgHilo.RunWorkerAsync();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                    return;
                }
            }
            #endregion
        }

        private void BtnDepurar_Click(object sender, EventArgs e)
        {
            #region ImportarMarcacionByAsistencia()
            MarcacionPuertaMantenimientoDepurar oFormularioMarcacionPuertaMantenimientoDepurar = new MarcacionPuertaMantenimientoDepurar();
            oFormularioMarcacionPuertaMantenimientoDepurar = new MarcacionPuertaMantenimientoDepurar(txtcodigoTransferencia.Text.Trim(), txtMovimientoAsistencia.Text.Trim(), txtEstadoDescripcion.Text.Trim(), txtFecha.Text.Trim(), this.codigoPlanilla, this.semanaDesde, this.semanaHasta, periodoSelecionado);
            if (oFormularioMarcacionPuertaMantenimientoDepurar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /* Volvermos a refrescar */
                    gbDatosGenerales.Enabled = false;
                    gbDetalleMarcacion.Enabled = false;
                    gbListadoPersonal.Enabled = false;
                    ProgressBarF.Visible = !false;
                    bwgHilo.RunWorkerAsync();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Mensaje del Sistema");
                    return;
                }
            }
            #endregion
        }

       


    }
}
