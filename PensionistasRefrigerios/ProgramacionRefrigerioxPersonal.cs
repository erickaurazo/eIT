using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Globalization;
using MyControlsDataBinding;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Collections;
using Transportista.Negocios;
using System.Configuration;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ProgramacionRefrigerioxPersonal : Telerik.WinControls.UI.RadForm
    {
        private string Periodo;
        private List<SJ_RHPensionRefrigerioPersonaListarResult> ListaPersonal;
        private List<SJ_RHPensionRefrigerioPersonaListarResult> ListaPersonalAgrupadoByTrabajador;
        private SJM_PensionesNegocios Logica;
        private SJ_RHPensionRefrigerioPersona oRefrigerioPersona;
        private SJM_PensionesNegocios Modelo;
        private string nombreArchivo;
        private string periodoConsulta;
        private List<SJ_RHPensionRefrigerioPersonaListarResult> listaPersonalByColaborador;
        private int consultarTodos = 0;
        private string periodo;
        private List<SJ_RHProgramacionRefrigerioResumenResult> listadoResumenProgramacionRefrigerio;

        public ProgramacionRefrigerioxPersonal()
        {
            InitializeComponent();

            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            this.dgvPersonal.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            Inicio();
        }

        private void RefrigerioxPersonal_Load(object sender, EventArgs e)
        {
            barraPrincipal.Enabled = false;
            gbRegistros.Enabled = false;
            bgwHilo.RunWorkerAsync();

        }

        protected override void OnLoad(EventArgs e)
        {

            this.dgvPersonal.TableElement.BeginUpdate();
            //this.dgvPersonal.Columns["chNombresCompletos"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvPersonal.TableElement.EndUpdate();
            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvPersonal.MasterTemplate.AutoExpandGroups = true;
            this.dgvPersonal.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonal.GroupDescriptors.Clear();
            this.dgvPersonal.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chNombresCompletos", "Registros: {0:N0}; ", GridAggregateFunction.Count));
            //this.dgvPersonal.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvPersonal.MasterTemplate.SummaryRowsTop.Add(item);


             this.dgvProgramacionResumen.MasterTemplate.AutoExpandGroups = true;
            this.dgvProgramacionResumen.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvProgramacionResumen.GroupDescriptors.Clear();
            this.dgvProgramacionResumen.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item2 = new GridViewSummaryRowItem();
            item2.Add(new GridViewSummaryItem("chnumeroComensales", "Sum: {0:N0}; ", GridAggregateFunction.Sum));
            item2.Add(new GridViewSummaryItem("chpension", "Sum: {0:N0}; ", GridAggregateFunction.Count));
            //this.dgvPersonal.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvProgramacionResumen.MasterTemplate.SummaryRowsTop.Add(item2);

            

        }

        private void MostrarLista()
        {
            try
            {
                this.dgvPersonal.DataSource = ListaPersonalAgrupadoByTrabajador.ToDataTable<SJ_RHPensionRefrigerioPersonaListarResult>();
                this.dgvPersonal.Refresh();

                this.dgvProgramacionResumen.DataSource = listadoResumenProgramacionRefrigerio.ToDataTable<SJ_RHProgramacionRefrigerioResumenResult>();
                this.dgvProgramacionResumen.Refresh();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
            

        }

        private void RealizarConsulta()
        {
            try
            {
                Logica = new SJM_PensionesNegocios();
                listadoResumenProgramacionRefrigerio = new List<SJ_RHProgramacionRefrigerioResumenResult>();
                ListaPersonal = new List<SJ_RHPensionRefrigerioPersonaListarResult>();

                listadoResumenProgramacionRefrigerio = Logica.ListarResumenProgramacionRefrigerio(periodoConsulta).ToList();

                if (consultarTodos == 1)
                {
                    ListaPersonal = Logica.ObtenerListadoProgramacionPersonalSinRenovarTickets(periodoConsulta).ToList();
                }
                else if (consultarTodos == 0)
                {
                    if (rbtActivos.IsChecked == true)
                    {
                        ListaPersonal = Logica.ObtenerListadoProgramacionRefrigerios(periodoConsulta,"AC").ToList();
                    }
                    if (rbtTodos.IsChecked == true)
                    {
                        ListaPersonal = Logica.ObtenerListadoProgramacionRefrigerios(periodoConsulta,"").ToList();
                    }
                   
                }


                ListaPersonalAgrupadoByTrabajador = Logica.ObtenerListadoRefrigerioByTrabajador(ListaPersonal).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }


        }

        public void Inicio()
        {
            try
            {
                periodoConsulta = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodoConsulta].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "ERICK AURAZO";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            Editar();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {

            try
            {
                ProgramacionRefrigerioxPersonalMantenimiento oFormulario = new ProgramacionRefrigerioxPersonalMantenimiento();
                oFormulario.Show();
                oFormulario.WindowState = FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }


        }

        private void dgvPersonal_SelectionChanged(object sender, EventArgs e)
        {
            oRefrigerioPersona = new SJ_RHPensionRefrigerioPersona();
            LimpiarObjetoPensionRefrigerioPersona();
            btnSubCambiarProgramacion.Enabled = false;
            btnSubModificarProgramacion.Enabled = false;

            btnEditar.Enabled = false;
            btnAnular.Enabled = false;

            if (dgvPersonal.Rows.Count > 0)
            {
                #region
                if (dgvPersonal.CurrentRow != null)
                {
                    try
                    {
                        if (dgvPersonal.CurrentRow.Cells["chId"].Value != null && dgvPersonal.CurrentRow.Cells["chId"].Value.ToString().Trim() != "")
                        {
                            #region Obtener Objeto
                            oRefrigerioPersona = new SJ_RHPensionRefrigerioPersona();
                            oRefrigerioPersona.Id = Convert.ToInt32(dgvPersonal.CurrentRow.Cells["chId"].Value.ToString().Trim());
                            oRefrigerioPersona.IdEstado = dgvPersonal.CurrentRow.Cells["chidestado"].Value != null ? dgvPersonal.CurrentRow.Cells["chidestado"].Value.ToString().Trim() : "AN";
                            oRefrigerioPersona.IdPension = dgvPersonal.CurrentRow.Cells["chIdPension"].Value != null ? Convert.ToInt32(dgvPersonal.CurrentRow.Cells["chIdPension"].Value) : 0;
                            oRefrigerioPersona.IdCodigoPersonal = dgvPersonal.CurrentRow.Cells["chIdCodigoPersonal"].Value != null ? dgvPersonal.CurrentRow.Cells["chIdCodigoPersonal"].Value.ToString().Trim() : "";
                            oRefrigerioPersona.NombresCompletos = dgvPersonal.CurrentRow.Cells["chNombresCompletos"].Value != null ? dgvPersonal.CurrentRow.Cells["chNombresCompletos"].Value.ToString().Trim() : "";

                            if (oRefrigerioPersona.IdPension != 0)
                            {
                                btnSubCambiarProgramacion.Enabled = true;
                                btnSubModificarProgramacion.Enabled = true;
                                btnEditar.Enabled = true;
                                btnAnular.Enabled = true;

                            }

                            #endregion
                        }
                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                }
                #endregion
            }
        }

        private void LimpiarObjetoPensionRefrigerioPersona()
        {
            try
            {
                #region Limpiar Objeto()
                oRefrigerioPersona = new SJ_RHPensionRefrigerioPersona();
                oRefrigerioPersona.Id = 0;
                oRefrigerioPersona.IdEstado = "";
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgvPersonal_DoubleClick(object sender, EventArgs e)
        {
            if (oRefrigerioPersona.Id != null)
            {
                if (oRefrigerioPersona.IdPension == 0)
                {

                    listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                    listaPersonalByColaborador = ListaPersonal.Where(x => x.IdCodigoPersonal.ToString().Trim() == oRefrigerioPersona.IdCodigoPersonal.ToString().Trim()).ToList();
                    ProgramacionRefrigerioxPersonalByPersonal oFrm = new ProgramacionRefrigerioxPersonalByPersonal(oRefrigerioPersona, listaPersonalByColaborador);
                    oFrm.ShowDialog();
                }
            }
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            consultarTodos = 0;
            Actualizar();
        }

        private void Actualizar()
        {
            try
            {
                barraPrincipal.Enabled = false;
                gbRegistros.Enabled = false;
                bgwHilo.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            RealizarConsulta();
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MostrarLista();
            barraPrincipal.Enabled = true;
            gbRegistros.Enabled = true;
            ResaltarResultados();
        }

        private void ResaltarResultados()
        {
            try
            {
                #region Resaltar Resultados()
                if (dgvPersonal != null && dgvPersonal.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvPersonal.Rows.Count; i++)
                    {
                        if ((dgvPersonal.Rows[i].Cells["chIdEstado"].Value != null ? dgvPersonal.Rows[i].Cells["chIdEstado"].Value.ToString().Trim() : "") == "AN")
                        {
                            for (int j = 0; j < dgvPersonal.Columns.Count; j++)
                            {
                                dgvPersonal.Rows[i].Cells[j].Style.CustomizeFill = true;
                                dgvPersonal.Rows[i].Cells[j].Style.DrawFill = true;
                                dgvPersonal.Rows[i].Cells[j].Style.BackColor = Utiles.blancoHumo3D;
                                //dgvRegistros.Rows[i].Cells[j].Style.Font = new Font("Tahoma", 8, FontStyle.Bold); //
                            }
                        }

                    }
                }
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void Anular()
        {

            try
            {
                if (oRefrigerioPersona.Id != null && oRefrigerioPersona.Id.ToString().Trim() != null)
                {
                    if (oRefrigerioPersona.IdPension != null && oRefrigerioPersona.IdPension > 0)
                    {
                        Logica = new SJM_PensionesNegocios();
                        Logica.AnularProgramacionAsistenciaRefrigerioByTrabajador(periodoConsulta, oRefrigerioPersona, 1);
                        Actualizar();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            Eliminar();

        }

        private void Eliminar()
        {
            try
            {
                if (Environment.MachineName.ToString().Trim() == "EAURAZOC" || Environment.MachineName.ToString().Trim() == "JGUERREROD" || Environment.MachineName.ToString().Trim() == "CLLONTOPF")
                {
                    if (oRefrigerioPersona.Id != null && oRefrigerioPersona.Id.ToString().Trim() != null)
                    {
                        if (oRefrigerioPersona.IdPension != null && oRefrigerioPersona.IdPension > 0)
                        {
                            Logica = new SJM_PensionesNegocios();
                            Logica.EliminarProgramacionAsistenciaRefrigerioByTrabajador(periodoConsulta, oRefrigerioPersona, 1);
                            Actualizar();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No tiene privilegios para realizar esta operación", "MENSAJE DEL SISTEMA");
                    return;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonal != null && dgvPersonal.Rows.Count > 0)
            {
                GenerarProcesoAExportar(this.dgvPersonal);
            }
        }

        private void GenerarProcesoAExportar(RadGridView radGridView)
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

            nombreArchivo = this.saveFileDialog.FileName;
            bool openExportFile = false;
            this.exportVisualSettings = true;
            RunExportToExcelML(nombreArchivo, ref openExportFile, radGridView);

            if (openExportFile)
            {
                try
                {
                    System.Diagnostics.Process.Start(nombreArchivo);
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
            excelExporter.SheetName = "Lista de Paraderos";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
            excelExporter.HiddenColumnOption = HiddenOption.DoNotExport;

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Close();
            }
        }

        private void moficiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void modificarEstadoProgramacion_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void dgvPersonal_KeyDown(object sender, KeyEventArgs e)
        {

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Editar();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                Nuevo();
            }

            if ((Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F5))
            {
                Actualizar();
            }

            if (e.KeyValue == 46)
            {
                Eliminar();
            }

            if ((Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.P))
            {
                VistaPrevia();
            }

        }

        private void Editar()
        {
            if (oRefrigerioPersona.Id != null)
            {
                #region 
                if (oRefrigerioPersona.Id != 0)
                {
                    if (oRefrigerioPersona.IdPension != 0)
                    {
                        ProgramacionRefrigerioxPersonalMantenimiento oFormulario = new ProgramacionRefrigerioxPersonalMantenimiento(oRefrigerioPersona, 0);
                        //oFormulario.WindowState = FormWindowState.Maximized;  
                        oFormulario.Show();
                    }
                    else if (oRefrigerioPersona.IdPension == 0)
                    {
                        #region 
                        listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                        listaPersonalByColaborador = ListaPersonal.Where(x => x.IdCodigoPersonal.ToString().Trim() == oRefrigerioPersona.IdCodigoPersonal.ToString().Trim()).ToList();

                        var listaAgrupada = (from item in listaPersonalByColaborador
                                             where item.Id != null
                                             group item by new { item.Id } into j
                                             select new SJ_RHPensionRefrigerioPersonaListarResult
                                             {
                                                 Id = j.Key.Id,
                                                 Almuerzo = j.FirstOrDefault().Almuerzo != null ? j.FirstOrDefault().Almuerzo : 0,
                                                 Cena = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Condicion = j.FirstOrDefault().Condicion != null ? j.FirstOrDefault().Condicion.Trim() : string.Empty,
                                                 Desayuno = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Estado = j.FirstOrDefault().Estado != null ? j.FirstOrDefault().Estado.Trim() : string.Empty,
                                                 IdCodigoPersonal = j.FirstOrDefault().IdCodigoPersonal != null ? j.FirstOrDefault().IdCodigoPersonal.Trim() : string.Empty,
                                                 IdEstado = j.FirstOrDefault().IdEstado != null ? j.FirstOrDefault().IdEstado.Trim() : string.Empty,
                                                 idParadero = j.FirstOrDefault().idParadero != null ? j.FirstOrDefault().idParadero.Trim() : string.Empty,
                                                 IdPension = j.FirstOrDefault().IdPension != null ? j.FirstOrDefault().IdPension : 0,
                                                 IdSubPlanilla = j.FirstOrDefault().IdSubPlanilla != null ? j.FirstOrDefault().IdSubPlanilla.Trim() : string.Empty,
                                                 Item = j.FirstOrDefault().Item != null ? j.FirstOrDefault().Item.Trim() : string.Empty,
                                                 NombresCompletos = j.FirstOrDefault().NombresCompletos != null ? j.FirstOrDefault().NombresCompletos.Trim() : string.Empty,
                                                 NroDNIPension = j.FirstOrDefault().NroDNIPension != null ? j.FirstOrDefault().NroDNIPension.Trim() : string.Empty,
                                                 NroDocumento = j.FirstOrDefault().NroDocumento != null ? j.FirstOrDefault().NroDocumento.Trim() : string.Empty,
                                                 Otro = j.FirstOrDefault().Otro != null ? j.FirstOrDefault().Otro : 0,
                                                 paradero = j.FirstOrDefault().paradero != null ? j.FirstOrDefault().paradero.Trim() : string.Empty,
                                                 Pension = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.Trim() : string.Empty,
                                                 SubPlanilla = j.FirstOrDefault().SubPlanilla != null ? j.FirstOrDefault().SubPlanilla.Trim() : string.Empty,
                                                 ValidoDesde = j.FirstOrDefault().ValidoDesde != null ? j.FirstOrDefault().ValidoDesde : (DateTime?)null,
                                                 ValidoHasta = j.FirstOrDefault().ValidoHasta != null ? j.FirstOrDefault().ValidoHasta : (DateTime?)null,
                                             }
                                                                          ).ToList();

                        ProgramacionRefrigerioxPersonalByPersonal oFrm = new ProgramacionRefrigerioxPersonalByPersonal(oRefrigerioPersona, listaAgrupada);
                        oFrm.ShowDialog();
                        #endregion
                    }
                }
                else
                {
                    if (oRefrigerioPersona.IdPension == 0)
                    {
                        #region 
                        listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                        listaPersonalByColaborador = ListaPersonal.Where(x => x.IdCodigoPersonal.ToString().Trim() == oRefrigerioPersona.IdCodigoPersonal.ToString().Trim()).ToList();


                        var listaAgrupada = (from item in listaPersonalByColaborador
                                             where item.Id != null
                                             group item by new { item.Id } into j
                                             select new SJ_RHPensionRefrigerioPersonaListarResult
                                             {
                                                 Id = j.Key.Id,
                                                 Almuerzo = j.FirstOrDefault().Almuerzo != null ? j.FirstOrDefault().Almuerzo : 0,
                                                 Cena = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Condicion = j.FirstOrDefault().Condicion != null ? j.FirstOrDefault().Condicion.Trim() : string.Empty,
                                                 Desayuno = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Estado = j.FirstOrDefault().Estado != null ? j.FirstOrDefault().Estado.Trim() : string.Empty,
                                                 IdCodigoPersonal = j.FirstOrDefault().IdCodigoPersonal != null ? j.FirstOrDefault().IdCodigoPersonal.Trim() : string.Empty,
                                                 IdEstado = j.FirstOrDefault().IdEstado != null ? j.FirstOrDefault().IdEstado.Trim() : string.Empty,
                                                 idParadero = j.FirstOrDefault().idParadero != null ? j.FirstOrDefault().idParadero.Trim() : string.Empty,
                                                 IdPension = j.FirstOrDefault().IdPension != null ? j.FirstOrDefault().IdPension : 0,
                                                 IdSubPlanilla = j.FirstOrDefault().IdSubPlanilla != null ? j.FirstOrDefault().IdSubPlanilla.Trim() : string.Empty,
                                                 Item = j.FirstOrDefault().Item != null ? j.FirstOrDefault().Item.Trim() : string.Empty,
                                                 NombresCompletos = j.FirstOrDefault().NombresCompletos != null ? j.FirstOrDefault().NombresCompletos.Trim() : string.Empty,
                                                 NroDNIPension = j.FirstOrDefault().NroDNIPension != null ? j.FirstOrDefault().NroDNIPension.Trim() : string.Empty,
                                                 NroDocumento = j.FirstOrDefault().NroDocumento != null ? j.FirstOrDefault().NroDocumento.Trim() : string.Empty,
                                                 Otro = j.FirstOrDefault().Otro != null ? j.FirstOrDefault().Otro : 0,
                                                 paradero = j.FirstOrDefault().paradero != null ? j.FirstOrDefault().paradero.Trim() : string.Empty,
                                                 Pension = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.Trim() : string.Empty,
                                                 SubPlanilla = j.FirstOrDefault().SubPlanilla != null ? j.FirstOrDefault().SubPlanilla.Trim() : string.Empty,
                                                 ValidoDesde = j.FirstOrDefault().ValidoDesde != null ? j.FirstOrDefault().ValidoDesde : (DateTime?)null,
                                                 ValidoHasta = j.FirstOrDefault().ValidoHasta != null ? j.FirstOrDefault().ValidoHasta : (DateTime?)null,
                                             }
                                                  ).ToList();

                        ProgramacionRefrigerioxPersonalByPersonal oFrm = new ProgramacionRefrigerioxPersonalByPersonal(oRefrigerioPersona, listaAgrupada);
                        oFrm.ShowDialog();
                        #endregion
                    }
                    else if (oRefrigerioPersona.IdPension > 0)
                    {
                        #region 
                        listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                        listaPersonalByColaborador = ListaPersonal.Where(x => x.IdCodigoPersonal.ToString().Trim() == oRefrigerioPersona.IdCodigoPersonal.ToString().Trim()).ToList();

                        var listaAgrupada = (from item in listaPersonalByColaborador
                                             where item.Id != null
                                             group item by new { item.Id } into j
                                             select new SJ_RHPensionRefrigerioPersonaListarResult
                                             {
                                                 Id = j.Key.Id,
                                                 Almuerzo = j.FirstOrDefault().Almuerzo != null ? j.FirstOrDefault().Almuerzo : 0,
                                                 Cena = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Condicion = j.FirstOrDefault().Condicion != null ? j.FirstOrDefault().Condicion.Trim() : string.Empty,
                                                 Desayuno = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Estado = j.FirstOrDefault().Estado != null ? j.FirstOrDefault().Estado.Trim() : string.Empty,
                                                 IdCodigoPersonal = j.FirstOrDefault().IdCodigoPersonal != null ? j.FirstOrDefault().IdCodigoPersonal.Trim() : string.Empty,
                                                 IdEstado = j.FirstOrDefault().IdEstado != null ? j.FirstOrDefault().IdEstado.Trim() : string.Empty,
                                                 idParadero = j.FirstOrDefault().idParadero != null ? j.FirstOrDefault().idParadero.Trim() : string.Empty,
                                                 IdPension = j.FirstOrDefault().IdPension != null ? j.FirstOrDefault().IdPension : 0,
                                                 IdSubPlanilla = j.FirstOrDefault().IdSubPlanilla != null ? j.FirstOrDefault().IdSubPlanilla.Trim() : string.Empty,
                                                 Item = j.FirstOrDefault().Item != null ? j.FirstOrDefault().Item.Trim() : string.Empty,
                                                 NombresCompletos = j.FirstOrDefault().NombresCompletos != null ? j.FirstOrDefault().NombresCompletos.Trim() : string.Empty,
                                                 NroDNIPension = j.FirstOrDefault().NroDNIPension != null ? j.FirstOrDefault().NroDNIPension.Trim() : string.Empty,
                                                 NroDocumento = j.FirstOrDefault().NroDocumento != null ? j.FirstOrDefault().NroDocumento.Trim() : string.Empty,
                                                 Otro = j.FirstOrDefault().Otro != null ? j.FirstOrDefault().Otro : 0,
                                                 paradero = j.FirstOrDefault().paradero != null ? j.FirstOrDefault().paradero.Trim() : string.Empty,
                                                 Pension = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.Trim() : string.Empty,
                                                 SubPlanilla = j.FirstOrDefault().SubPlanilla != null ? j.FirstOrDefault().SubPlanilla.Trim() : string.Empty,
                                                 ValidoDesde = j.FirstOrDefault().ValidoDesde != null ? j.FirstOrDefault().ValidoDesde : (DateTime?)null,
                                                 ValidoHasta = j.FirstOrDefault().ValidoHasta != null ? j.FirstOrDefault().ValidoHasta : (DateTime?)null,
                                             }
                                                  ).ToList();

                        ProgramacionRefrigerioxPersonalByPersonal oFrm = new ProgramacionRefrigerioxPersonalByPersonal(oRefrigerioPersona, listaAgrupada);
                        oFrm.ShowDialog();
                        #endregion
                    }
                }
                #endregion
            }
        }

        public bool exportVisualSettings { get; set; }

        private void ProgramacionRefrigerioxPersonal_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Editar();
            }

            if ((Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.F5))
            {
                Actualizar();
            }

            if ((Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.P))
            {
                VistaPrevia();
            }

            if (e.KeyValue == 46)
            {
                Eliminar();
            }

            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.N)
            {
                Nuevo();
            }


        }

        private void ProgramacionRefrigerioxPersonal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgwHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSubImprimirProgramacion_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            try
            {

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnSubVistaPreviaProgramacion_Click(object sender, EventArgs e)
        {
            VistaPrevia();
        }

        private void VistaPrevia()
        {
            try
            {
                if (oRefrigerioPersona.Id != null && oRefrigerioPersona.Id.ToString().Trim() != "")
                {
                    if (oRefrigerioPersona.IdPension > 0)
                    {
                        TicketPrivilegioRefrigerioImprimir oFrmDetalle = new TicketPrivilegioRefrigerioImprimir(oRefrigerioPersona.Id.ToString().Trim());
                        oFrmDetalle.AgregarParametroCadena("@impresoPor", Environment.UserName.ToString().Trim().ToUpper());
                        oFrmDetalle.ShowDialog();
                    }

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarTodos = 0;
            Actualizar();
        }

        private void btnGenerarProceso_Click(object sender, EventArgs e)
        {
            consultarTodos = 1;
            Actualizar();

        }

        private void btnRenovarTicket_Click(object sender, EventArgs e)
        {
            RenovarTicket();
        }

        private void RenovarTicket()
        {
            if (oRefrigerioPersona.Id != null)
            {
                #region
                if (oRefrigerioPersona.Id != 0)
                {
                    if (oRefrigerioPersona.IdPension != 0)
                    {
                        ProgramacionRefrigerioxPersonalMantenimiento oFormulario = new ProgramacionRefrigerioxPersonalMantenimiento(oRefrigerioPersona, 1);
                        //oFormulario.WindowState = FormWindowState.Maximized;  
                        oFormulario.Show();
                    }
                    else if (oRefrigerioPersona.IdPension == 0)
                    {
                        #region
                        listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                        listaPersonalByColaborador = ListaPersonal.Where(x => x.IdCodigoPersonal.ToString().Trim() == oRefrigerioPersona.IdCodigoPersonal.ToString().Trim()).ToList();

                        var listaAgrupada = (from item in listaPersonalByColaborador
                                             where item.Id != null
                                             group item by new { item.Id } into j
                                             select new SJ_RHPensionRefrigerioPersonaListarResult
                                             {
                                                 Id = j.Key.Id,
                                                 Almuerzo = j.FirstOrDefault().Almuerzo != null ? j.FirstOrDefault().Almuerzo : 0,
                                                 Cena = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Condicion = j.FirstOrDefault().Condicion != null ? j.FirstOrDefault().Condicion.Trim() : string.Empty,
                                                 Desayuno = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Estado = j.FirstOrDefault().Estado != null ? j.FirstOrDefault().Estado.Trim() : string.Empty,
                                                 IdCodigoPersonal = j.FirstOrDefault().IdCodigoPersonal != null ? j.FirstOrDefault().IdCodigoPersonal.Trim() : string.Empty,
                                                 IdEstado = j.FirstOrDefault().IdEstado != null ? j.FirstOrDefault().IdEstado.Trim() : string.Empty,
                                                 idParadero = j.FirstOrDefault().idParadero != null ? j.FirstOrDefault().idParadero.Trim() : string.Empty,
                                                 IdPension = j.FirstOrDefault().IdPension != null ? j.FirstOrDefault().IdPension : 0,
                                                 IdSubPlanilla = j.FirstOrDefault().IdSubPlanilla != null ? j.FirstOrDefault().IdSubPlanilla.Trim() : string.Empty,
                                                 Item = j.FirstOrDefault().Item != null ? j.FirstOrDefault().Item.Trim() : string.Empty,
                                                 NombresCompletos = j.FirstOrDefault().NombresCompletos != null ? j.FirstOrDefault().NombresCompletos.Trim() : string.Empty,
                                                 NroDNIPension = j.FirstOrDefault().NroDNIPension != null ? j.FirstOrDefault().NroDNIPension.Trim() : string.Empty,
                                                 NroDocumento = j.FirstOrDefault().NroDocumento != null ? j.FirstOrDefault().NroDocumento.Trim() : string.Empty,
                                                 Otro = j.FirstOrDefault().Otro != null ? j.FirstOrDefault().Otro : 0,
                                                 paradero = j.FirstOrDefault().paradero != null ? j.FirstOrDefault().paradero.Trim() : string.Empty,
                                                 Pension = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.Trim() : string.Empty,
                                                 SubPlanilla = j.FirstOrDefault().SubPlanilla != null ? j.FirstOrDefault().SubPlanilla.Trim() : string.Empty,
                                                 ValidoDesde = j.FirstOrDefault().ValidoDesde != null ? j.FirstOrDefault().ValidoDesde : (DateTime?)null,
                                                 ValidoHasta = j.FirstOrDefault().ValidoHasta != null ? j.FirstOrDefault().ValidoHasta : (DateTime?)null,
                                                 diasFinalizacion = j.FirstOrDefault().diasFinalizacion != null ? j.FirstOrDefault().diasFinalizacion : 0,
                                             }
                                                                          ).ToList();

                        ProgramacionRefrigerioxPersonalByPersonal oFrm = new ProgramacionRefrigerioxPersonalByPersonal(oRefrigerioPersona, listaAgrupada);
                        oFrm.ShowDialog();
                        #endregion
                    }
                }
                else
                {
                    if (oRefrigerioPersona.IdPension == 0)
                    {
                        #region
                        listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                        listaPersonalByColaborador = ListaPersonal.Where(x => x.IdCodigoPersonal.ToString().Trim() == oRefrigerioPersona.IdCodigoPersonal.ToString().Trim()).ToList();


                        var listaAgrupada = (from item in listaPersonalByColaborador
                                             where item.Id != null
                                             group item by new { item.Id } into j
                                             select new SJ_RHPensionRefrigerioPersonaListarResult
                                             {
                                                 Id = j.Key.Id,
                                                 Almuerzo = j.FirstOrDefault().Almuerzo != null ? j.FirstOrDefault().Almuerzo : 0,
                                                 Cena = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Condicion = j.FirstOrDefault().Condicion != null ? j.FirstOrDefault().Condicion.Trim() : string.Empty,
                                                 Desayuno = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Estado = j.FirstOrDefault().Estado != null ? j.FirstOrDefault().Estado.Trim() : string.Empty,
                                                 IdCodigoPersonal = j.FirstOrDefault().IdCodigoPersonal != null ? j.FirstOrDefault().IdCodigoPersonal.Trim() : string.Empty,
                                                 IdEstado = j.FirstOrDefault().IdEstado != null ? j.FirstOrDefault().IdEstado.Trim() : string.Empty,
                                                 idParadero = j.FirstOrDefault().idParadero != null ? j.FirstOrDefault().idParadero.Trim() : string.Empty,
                                                 IdPension = j.FirstOrDefault().IdPension != null ? j.FirstOrDefault().IdPension : 0,
                                                 IdSubPlanilla = j.FirstOrDefault().IdSubPlanilla != null ? j.FirstOrDefault().IdSubPlanilla.Trim() : string.Empty,
                                                 Item = j.FirstOrDefault().Item != null ? j.FirstOrDefault().Item.Trim() : string.Empty,
                                                 NombresCompletos = j.FirstOrDefault().NombresCompletos != null ? j.FirstOrDefault().NombresCompletos.Trim() : string.Empty,
                                                 NroDNIPension = j.FirstOrDefault().NroDNIPension != null ? j.FirstOrDefault().NroDNIPension.Trim() : string.Empty,
                                                 NroDocumento = j.FirstOrDefault().NroDocumento != null ? j.FirstOrDefault().NroDocumento.Trim() : string.Empty,
                                                 Otro = j.FirstOrDefault().Otro != null ? j.FirstOrDefault().Otro : 0,
                                                 paradero = j.FirstOrDefault().paradero != null ? j.FirstOrDefault().paradero.Trim() : string.Empty,
                                                 Pension = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.Trim() : string.Empty,
                                                 SubPlanilla = j.FirstOrDefault().SubPlanilla != null ? j.FirstOrDefault().SubPlanilla.Trim() : string.Empty,
                                                 ValidoDesde = j.FirstOrDefault().ValidoDesde != null ? j.FirstOrDefault().ValidoDesde : (DateTime?)null,
                                                 ValidoHasta = j.FirstOrDefault().ValidoHasta != null ? j.FirstOrDefault().ValidoHasta : (DateTime?)null,
                                                 diasFinalizacion = j.FirstOrDefault().diasFinalizacion != null ? j.FirstOrDefault().diasFinalizacion : 0,
                                             }
                                                  ).ToList();

                        ProgramacionRefrigerioxPersonalByPersonal oFrm = new ProgramacionRefrigerioxPersonalByPersonal(oRefrigerioPersona, listaAgrupada);
                        oFrm.ShowDialog();
                        #endregion
                    }
                    else if (oRefrigerioPersona.IdPension > 0)
                    {
                        #region
                        listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                        listaPersonalByColaborador = ListaPersonal.Where(x => x.IdCodigoPersonal.ToString().Trim() == oRefrigerioPersona.IdCodigoPersonal.ToString().Trim()).ToList();

                        var listaAgrupada = (from item in listaPersonalByColaborador
                                             where item.Id != null
                                             group item by new { item.Id } into j
                                             select new SJ_RHPensionRefrigerioPersonaListarResult
                                             {
                                                 Id = j.Key.Id,
                                                 Almuerzo = j.FirstOrDefault().Almuerzo != null ? j.FirstOrDefault().Almuerzo : 0,
                                                 Cena = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Condicion = j.FirstOrDefault().Condicion != null ? j.FirstOrDefault().Condicion.Trim() : string.Empty,
                                                 Desayuno = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                                                 Estado = j.FirstOrDefault().Estado != null ? j.FirstOrDefault().Estado.Trim() : string.Empty,
                                                 IdCodigoPersonal = j.FirstOrDefault().IdCodigoPersonal != null ? j.FirstOrDefault().IdCodigoPersonal.Trim() : string.Empty,
                                                 IdEstado = j.FirstOrDefault().IdEstado != null ? j.FirstOrDefault().IdEstado.Trim() : string.Empty,
                                                 idParadero = j.FirstOrDefault().idParadero != null ? j.FirstOrDefault().idParadero.Trim() : string.Empty,
                                                 IdPension = j.FirstOrDefault().IdPension != null ? j.FirstOrDefault().IdPension : 0,
                                                 IdSubPlanilla = j.FirstOrDefault().IdSubPlanilla != null ? j.FirstOrDefault().IdSubPlanilla.Trim() : string.Empty,
                                                 Item = j.FirstOrDefault().Item != null ? j.FirstOrDefault().Item.Trim() : string.Empty,
                                                 NombresCompletos = j.FirstOrDefault().NombresCompletos != null ? j.FirstOrDefault().NombresCompletos.Trim() : string.Empty,
                                                 NroDNIPension = j.FirstOrDefault().NroDNIPension != null ? j.FirstOrDefault().NroDNIPension.Trim() : string.Empty,
                                                 NroDocumento = j.FirstOrDefault().NroDocumento != null ? j.FirstOrDefault().NroDocumento.Trim() : string.Empty,
                                                 Otro = j.FirstOrDefault().Otro != null ? j.FirstOrDefault().Otro : 0,
                                                 paradero = j.FirstOrDefault().paradero != null ? j.FirstOrDefault().paradero.Trim() : string.Empty,
                                                 Pension = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.Trim() : string.Empty,
                                                 SubPlanilla = j.FirstOrDefault().SubPlanilla != null ? j.FirstOrDefault().SubPlanilla.Trim() : string.Empty,
                                                 ValidoDesde = j.FirstOrDefault().ValidoDesde != null ? j.FirstOrDefault().ValidoDesde : (DateTime?)null,
                                                 ValidoHasta = j.FirstOrDefault().ValidoHasta != null ? j.FirstOrDefault().ValidoHasta : (DateTime?)null,
                                                 diasFinalizacion = j.FirstOrDefault().diasFinalizacion != null ? j.FirstOrDefault().diasFinalizacion : 0,
                                             }
                                                  ).ToList();

                        ProgramacionRefrigerioxPersonalByPersonal oFrm = new ProgramacionRefrigerioxPersonalByPersonal(oRefrigerioPersona, listaAgrupada);
                        oFrm.ShowDialog();
                        #endregion
                    }
                }
                #endregion
            }
        }

        private void gbConsulta_Click(object sender, EventArgs e)
        {

        }

        private void bgwProceso02_DoWork(object sender, DoWorkEventArgs e)
        {
            Logica = new SJM_PensionesNegocios();
            ListaPersonal = new List<SJ_RHPensionRefrigerioPersonaListarResult>();

            if (consultarTodos == 1)
            {
                string resultado = Logica.AnularTicketsVencidoProgramacionRefrigerio(periodo);
            }
        }

        private void bgwProceso02_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                MessageBox.Show("PROCESO REALIZADO CORRECTAMENTE", "MENSAJE DEL SISTEMA");
                barraPrincipal.Enabled = !false;
                gbRegistros.Enabled = !false;
                
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void btnAnularTicketVencidos_Click(object sender, EventArgs e)
        {
            try
            {
                periodo = DateTime.Now.Year.ToString();
                barraPrincipal.Enabled = false;
                gbRegistros.Enabled = false;
                bgwProceso02.RunWorkerAsync();

                if (rbtActivos.IsChecked == true)
                {
                    consultarTodos = 1;
                    Actualizar();
                }
                if (rbtTodos.IsChecked == true)
                {
                    consultarTodos = 0;
                    Actualizar();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }


    }
}
