using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using System.IO;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using RecursosHumanos.reporte;

namespace RecursosHumanos
{
    public partial class Privilegios : Telerik.WinControls.UI.RadForm
    {
        private string periodo;
        private PrivilegiosNegocios Neg;
        private List<SJ_RHPrivilegiosAccesosSistemasResult> Listado;
        private List<PRIVILEGIOS> privilegios;
        private string codFormulario;
        private string descpFormuario;
        private string codUsuario;
        private string fileName;
        private bool exportVisualSettings;
        private List<SJ_RHPrivilegiosAccesosSistemasResult> ListadoFiltro;
        public Privilegios()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {

            this.dgvPrivilegios.TableElement.BeginUpdate();
            //this.dgvPrivilegios.Columns["chNombresTrabajador"].FormatString = "{0:N0}";
            this.LoadFreightSummary();
            this.dgvPrivilegios.TableElement.EndUpdate();




            base.OnLoad(e);
        }

        private void LoadFreightSummary()
        {
            this.dgvPrivilegios.MasterTemplate.AutoExpandGroups = true;
            this.dgvPrivilegios.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvPrivilegios.GroupDescriptors.Clear();
            this.dgvPrivilegios.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            item.Add(new GridViewSummaryItem("chCLAVE", "Registros: {0:N0}; ", GridAggregateFunction.Count));


            //this.dgvRefrigerios.MasterTemplate.SummaryRowsBottom.Add(item);
            this.dgvPrivilegios.MasterTemplate.SummaryRowsTop.Add(item);
        }




        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            try
            {
                Neg = new PrivilegiosNegocios();
                Listado = new List<SJ_RHPrivilegiosAccesosSistemasResult>();
                Listado = Neg.ObtenerListaPrivilegios(periodo);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarResultados();
        }

        private void PresentarResultados()
        {
            ListadoFiltro = new List<SJ_RHPrivilegiosAccesosSistemasResult>();
            try
            {
                if (chkUsuariosActivos.Checked == true)
                {
                    var listaActivos = Listado.Where(x => x.ESTADO == 1).ToList();
                    ListadoFiltro.AddRange(listaActivos);
                }

                if (chkUsuariosInactivos.Checked == true)
                {
                    var listaInactivos = Listado.Where(x => x.ESTADO == 0).ToList();
                    ListadoFiltro.AddRange(listaInactivos);
                }

                // No se ha seleccionado nada
                if (chkUsuariosActivos.Checked == false && chkUsuariosInactivos.Checked == false)
                {

                    ListadoFiltro = new List<SJ_RHPrivilegiosAccesosSistemasResult>();
                }

                dgvPrivilegios.DataSource = ListadoFiltro.ToDataTable<SJ_RHPrivilegiosAccesosSistemasResult>();
                dgvPrivilegios.Refresh();

                ProgressBar.Visible = false;
                this.btnConsultar.Enabled = true;
                this.txtAño.Enabled = true;

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            periodo = this.txtAño.Value.ToString();
            bgwHilo.RunWorkerAsync();
            ProgressBar.Visible = true;
            this.btnConsultar.Enabled = false;
            this.txtAño.Enabled = false;
        }

        private void Privilegios_Load(object sender, EventArgs e)
        {
            this.txtAño.Value = Convert.ToDecimal(DateTime.Now.Year);
            periodo = this.txtAño.Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            dgvPrivilegios.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dgvPrivilegios.Enabled = false;
            ObtenerListaObjetos();

        }

        private void ObtenerListaObjetos()
        {
            privilegios = new List<PRIVILEGIOS>();

            foreach (var item in dgvPrivilegios.Rows)
            {
                if (item.Cells["chCLAVE"].Value != null && item.Cells["chCLAVE"].Value.ToString().Trim() != "")
                {
                    privilegio = new PRIVILEGIOS();
                    privilegio.IDEMPRESA = item.Cells["chidEmpresa"].Value != null ? item.Cells["chidEmpresa"].Value.ToString().Trim() : "";
                    privilegio.IDUSUARIO = item.Cells["chidUsuario"].Value != null ? item.Cells["chidUsuario"].Value.ToString().Trim() : "";
                    privilegio.CLAVE = item.Cells["chCLAVE"].Value != null ? item.Cells["chCLAVE"].Value.ToString().Trim() : "";


                    privilegio.NINGUNO = 0;
                    privilegio.CONSULTA = 0;
                    privilegio.EXPORTA_IMPRIME = 0;
                    privilegio.NUEVO = 0;
                    privilegio.MODIFICA = 0;
                    privilegio.ANULA = 0;
                    privilegio.ELIMINA = 0;
                    privilegio.VER_LOGS = 0;
                    privilegios.Add(privilegio);
                }

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public PRIVILEGIOS privilegio { get; set; }

        private void dgvPrivilegios_DoubleClick(object sender, EventArgs e)
        {


            if (codFormulario.ToString().Trim() != "")
            {
                PrivilegiosEdicion oFormulario = new PrivilegiosEdicion(codFormulario, descpFormuario, codUsuario, periodo);
                oFormulario.ShowDialog();
            }


        }

        private void dgvPrivilegios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPrivilegios != null)
            {
                #region MyRegion
                if (dgvPrivilegios.Rows.Count > 0)
                {
                    if (dgvPrivilegios.CurrentRow != null)
                    {
                        #region MyRegion
                        if (dgvPrivilegios.CurrentRow.Cells["chCLAVE"].Value != null)
                        {
                            #region
                            if (dgvPrivilegios.CurrentRow.Cells["chCLAVE"].Value.ToString().Trim() != "")
                            {
                                #region MyRegion
                                codFormulario = dgvPrivilegios.CurrentRow.Cells["chClave"].Value != null ? dgvPrivilegios.CurrentRow.Cells["chClave"].Value.ToString().Trim() : "";
                                descpFormuario = dgvPrivilegios.CurrentRow.Cells["chDESCRIPCION"].Value != null ? dgvPrivilegios.CurrentRow.Cells["chDESCRIPCION"].Value.ToString().Trim() : "";
                                codUsuario = dgvPrivilegios.CurrentRow.Cells["chIDUSUARIO"].Value != null ? dgvPrivilegios.CurrentRow.Cells["chIDUSUARIO"].Value.ToString().Trim() : "";
                                #endregion
                            }
                            else
                            {
                                #region Valor en Blanco()
                                codFormulario = "";
                                descpFormuario = "";
                                codUsuario = "";
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            #region Valor en Blanco()
                            codFormulario = "";
                            descpFormuario = "";
                            codUsuario = "";
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        #region Valor en Blanco()
                        codFormulario = "";
                        descpFormuario = "";
                        codUsuario = "";
                        #endregion
                    }
                }
                else
                {
                    #region Valor en Blanco()
                    codFormulario = "";
                    descpFormuario = "";
                    codUsuario = "";
                    #endregion
                }
                #endregion
            }
            else
            {
                #region Valor en Blanco()
                codFormulario = "";
                descpFormuario = "";
                codUsuario = "";
                #endregion
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PrivilegiosEdicion oFormulario = new PrivilegiosEdicion(periodo);
            oFormulario.ShowDialog();
        }

        private void btnEliminarDuplicados_Click(object sender, EventArgs e)
        {
            try
            {
                Neg = new PrivilegiosNegocios();
                Neg.EliminarElemetosDuplicados();
                RadMessageBox.Show("Se han eliminado los elementos duplicados", "Mensaje Sistema");
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        private void btnExportarLista_Click(object sender, EventArgs e)
        {
            Exportar(this.dgvPrivilegios);
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
            excelExporter.SheetName = "Privilegios";
            excelExporter.SummariesExportOption = SummariesOption.ExportAll;
            excelExporter.SheetMaxRows = ExcelMaxRows._1048576;
            excelExporter.ExportVisualSettings = this.exportVisualSettings;
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

        private void chkUsuariosActivos_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (Listado != null)
            {
                if (Listado.ToList().Count > 0)
                {
                    PresentarResultados();
                }
            }

            

        }

        private void chkUsuariosInactivos_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (Listado != null)
            {
                if (Listado.ToList().Count > 0)
                {
                    PresentarResultados();
                }
            }
        }





    }
}
