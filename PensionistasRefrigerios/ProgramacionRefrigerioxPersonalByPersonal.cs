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
    public partial class ProgramacionRefrigerioxPersonalByPersonal : Form
    {
        private SJ_RHPensionRefrigerioPersona oRefrigerioPersona;
        private SJ_RHPensionRefrigerioPersona oRefrigerioPersonaSelecionado;
        private List<SJ_RHPensionRefrigerioPersonaListarResult> listaPersonalByColaborador;
        private List<SJ_RHPensionRefrigerioPersonaListarResult> listaPersonalByColaboradorSelecionados;
        private SJM_PensionesNegocios Logica;
        private string periodoConsulta;

        public ProgramacionRefrigerioxPersonalByPersonal()
        {
            InitializeComponent();
        }

        public ProgramacionRefrigerioxPersonalByPersonal(SJ_RHPensionRefrigerioPersona ObjetoRefrigerioPersona, List<SJ_RHPensionRefrigerioPersonaListarResult> listaPersonalByColaborador)
        {
            // TODO: Complete member initialization
            try
            {
                InitializeComponent();
                this.oRefrigerioPersona = ObjetoRefrigerioPersona;
                listaPersonalByColaboradorSelecionados = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                this.listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                this.listaPersonalByColaborador = listaPersonalByColaborador;
                dgvProgramacion.DataSource = listaPersonalByColaborador.ToDataTable<SJ_RHPensionRefrigerioPersonaListarResult>();
                dgvProgramacion.Refresh();
                if (listaPersonalByColaborador != null && listaPersonalByColaborador.ToList().Count > 0)
                {
                    ResaltarResultado(dgvProgramacion);
                }

                periodoConsulta = DateTime.Now.Year.ToString();
                this.txtColaboradorCodigo.Text = ObjetoRefrigerioPersona.IdCodigoPersonal != null ? ObjetoRefrigerioPersona.IdCodigoPersonal.ToString().Trim() : "";
                this.txtColaboradorNombres.Text = ObjetoRefrigerioPersona.NombresCompletos != null ? ObjetoRefrigerioPersona.NombresCompletos.ToString().Trim() : "";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ProgramacionRefrigerioxPersonalByPersonal_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            //this.dgvProgramacion.TableElement.BeginUpdate();
            //this.LoadFreightSummary();
            //this.dgvProgramacion.TableElement.EndUpdate();            
        }

        private void LoadFreightSummary()
        {
            //this.dgvProgramacion.GroupDescriptors.Clear();
            //this.dgvProgramacion.GroupDescriptors.Add(new GridGroupByExpression("CustomerID Group By CustomerID"));
            //GridViewSummaryRowItem item = new GridViewSummaryRowItem();
            //item.Add(new GridViewSummaryItem("chPension", "Reg: {0:N0}; ", GridAggregateFunction.Count));
            //this.dgvProgramacion.MasterTemplate.SummaryRowsTop.Add(item);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Editar()
        {
            if (oRefrigerioPersonaSelecionado.Id != (int?)null)
            {
                if (oRefrigerioPersonaSelecionado.Id != 0)
                {
                    if (oRefrigerioPersonaSelecionado.IdPension != 0)
                    {
                        if (oRefrigerioPersonaSelecionado.IdEstado != "AN")
                        {
                            ProgramacionRefrigerioxPersonalMantenimiento oFormulario = new ProgramacionRefrigerioxPersonalMantenimiento(oRefrigerioPersonaSelecionado, 0);
                            oFormulario.Show();
                        }
                    }
                }
            }
        }


        private void Anular()
        {
            try
            {
                Logica = new SJM_PensionesNegocios();
                Logica.AnularProgramacionAsistenciaRefrigerioByTrabajador(periodoConsulta, oRefrigerioPersonaSelecionado, 1);
                Actualizar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void Actualizar()
        {
            barraPrincipal.Enabled = false;
            ProgressBar.Visible = true;
            gbDatosTrabajador.Enabled = false;
            gbDetalleRegistroColaborador.Enabled = false;
            bgwHilo.RunWorkerAsync();
        }

        private void Eliminar()
        {
            if (Environment.MachineName.ToString().Trim() == "EAURAZOC" || Environment.MachineName.ToString().Trim() == "JGUERREROD" || Environment.MachineName.ToString().Trim() == "CLLONTOPF")
            {
                try
                {
                    Logica = new SJM_PensionesNegocios();
                    Logica.EliminarProgramacionAsistenciaRefrigerioByTrabajador(periodoConsulta, oRefrigerioPersonaSelecionado, 1);
                    Actualizar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                    return;
                }
            }
            else
            {
                MessageBox.Show("No tiene privilegios para realizar esta operación", "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void dgvProgramacion_SelectionChanged(object sender, EventArgs e)
        {
            oRefrigerioPersonaSelecionado = new SJ_RHPensionRefrigerioPersona();
            btnSubCambiarProgramacion.Enabled = false;
            btnSubModificarProgramacion.Enabled = false;
            btnEditar.Enabled = false;
            btnAnular.Enabled = false;
            btnSubVistaPreviaProgramacion.Enabled = false;
            btnSubImprimirProgramacion.Enabled = false;
            btnImprimir.Enabled = false;
            btnVistaPrevia.Enabled = false;

            if (this.dgvProgramacion.Rows.Count > 0)
            {
                #region
                if (dgvProgramacion.CurrentRow != null)
                {
                    try
                    {
                        if (dgvProgramacion.CurrentRow.Cells["chId"].Value != null && dgvProgramacion.CurrentRow.Cells["chId"].Value.ToString().Trim() != "")
                        {
                            #region Obtener Objeto
                            oRefrigerioPersonaSelecionado = new SJ_RHPensionRefrigerioPersona();
                            oRefrigerioPersonaSelecionado.Id = Convert.ToInt32(dgvProgramacion.CurrentRow.Cells["chId"].Value.ToString().Trim());
                            oRefrigerioPersonaSelecionado.IdEstado = dgvProgramacion.CurrentRow.Cells["chidestado"].Value != null ? dgvProgramacion.CurrentRow.Cells["chidestado"].Value.ToString().Trim() : "AN";
                            oRefrigerioPersonaSelecionado.IdPension = dgvProgramacion.CurrentRow.Cells["chIdPension"].Value != null ? Convert.ToInt32(dgvProgramacion.CurrentRow.Cells["chIdPension"].Value) : 0;
                            oRefrigerioPersonaSelecionado.Pension = dgvProgramacion.CurrentRow.Cells["chPension"].Value != null ? Convert.ToString(dgvProgramacion.CurrentRow.Cells["chPension"].Value) : "";
                            oRefrigerioPersonaSelecionado.IdCodigoPersonal = dgvProgramacion.CurrentRow.Cells["chIdCodigoPersonal"].Value != null ? dgvProgramacion.CurrentRow.Cells["chIdCodigoPersonal"].Value.ToString().Trim() : "";
                            if (oRefrigerioPersonaSelecionado.IdPension != 0)
                            {
                                if (oRefrigerioPersonaSelecionado.IdEstado != "AN")
                                {
                                    btnSubCambiarProgramacion.Enabled = true;
                                    btnSubModificarProgramacion.Enabled = true;
                                    btnEditar.Enabled = true;
                                    btnAnular.Enabled = true;
                                    btnSubVistaPreviaProgramacion.Enabled = true;
                                    btnSubImprimirProgramacion.Enabled = true;
                                    btnImprimir.Enabled = true;
                                    btnVistaPrevia.Enabled = true;
                                }
                                else
                                {
                                    btnSubCambiarProgramacion.Enabled = true;
                                    btnSubModificarProgramacion.Enabled = false;
                                    btnEditar.Enabled = false;
                                    btnAnular.Enabled = true;
                                    btnSubVistaPreviaProgramacion.Enabled = false;
                                    btnSubImprimirProgramacion.Enabled = false;
                                    btnImprimir.Enabled = false;
                                    btnVistaPrevia.Enabled = false;
                                }

                            }
                            #endregion
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                        return;
                    }
                }
                #endregion
            }
        }

        private void btnSubCambiarProgramacion_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void btnSubModificarProgramacion_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Logica = new SJM_PensionesNegocios();
                listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                listaPersonalByColaborador = Logica.ObtenerProgramacionAsistenciaRefrigerioByTrabajador(periodoConsulta, oRefrigerioPersonaSelecionado);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvProgramacion.DataSource = listaPersonalByColaborador.ToDataTable<SJ_RHPensionRefrigerioPersonaListarResult>();
                dgvProgramacion.Refresh();

                if (listaPersonalByColaborador != null && listaPersonalByColaborador.ToList().Count > 0)
                {
                    ResaltarResultado(dgvProgramacion);
                }
                barraPrincipal.Enabled = true;
                ProgressBar.Visible = false;
                gbDatosTrabajador.Enabled = true;
                gbDetalleRegistroColaborador.Enabled = true;

                if (listaPersonalByColaborador.ToList().Count == 0)
                {
                    this.txtColaboradorCodigo.Clear();
                    this.txtColaboradorNombres.Clear();
                    oRefrigerioPersonaSelecionado = new SJ_RHPensionRefrigerioPersona();
                    listaPersonalByColaborador = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
                    dgvProgramacion.DataSource = listaPersonalByColaborador.ToDataTable<SJ_RHPensionRefrigerioPersonaListarResult>();
                    dgvProgramacion.Refresh();
                    btnActualizar.Enabled = false;
                    btnAnular.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnSubCambiarProgramacion.Enabled = false;
                    btnSubModificarProgramacion.Enabled = false;
                    dgvProgramacion.Enabled = false;
                    gbDatosTrabajador.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                barraPrincipal.Enabled = true;
                ProgressBar.Visible = false;
                gbDatosTrabajador.Enabled = true;
                gbDetalleRegistroColaborador.Enabled = true;
                return;
            }
        }

        private void ResaltarResultado(RadGridView dgvProgramacion)
        {
            foreach (Telerik.WinControls.UI.GridViewRowInfo row in dgvProgramacion.Rows)
            {
                foreach (Telerik.WinControls.UI.GridViewCellInfo cell in row.Cells)
                {
                    if (this.dgvProgramacion.Rows[row.Index].Cells["chIdEstado"].Value.ToString().Trim() == "AN")
                    {
                        this.dgvProgramacion.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.CustomizeFill = true;
                        this.dgvProgramacion.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.DrawFill = true;
                        //this.dgvMantenimiento.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.BackColor = Utiles.colorVerdeClaro;
                        this.dgvProgramacion.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.BackColor = Utiles.blancoHumo3D;
                        this.dgvProgramacion.Rows[row.Index].Cells[cell.ColumnInfo.Index].Style.Font = new Font("Microsoft Sans Serif", 7, FontStyle.Bold);
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dgvProgramacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Editar();
            }

            if ((Control.ModifierKeys == Keys.F2))
            {
                Actualizar();
            }
            
            if (e.KeyValue == 46)
            {
                Eliminar();
            }

            if ((Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.I))
            {
                VistaPrevia();
            }

            
           
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            VistaPrevia();
        }

        private void VistaPrevia()
        {
            try
            {
                if (oRefrigerioPersonaSelecionado.Id != null && oRefrigerioPersonaSelecionado.Id.ToString().Trim() != "")
                {
                    TicketPrivilegioRefrigerioImprimir oFrmDetalle = new TicketPrivilegioRefrigerioImprimir(oRefrigerioPersonaSelecionado.Id.ToString().Trim());
                    oFrmDetalle.ShowDialog();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
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

        private void renovarTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenovarTicket();
        }

        private void RenovarTicket()
        {
            if (oRefrigerioPersonaSelecionado.Id != (int?)null)
            {
                if (oRefrigerioPersonaSelecionado.Id != 0)
                {
                    if (oRefrigerioPersonaSelecionado.IdPension != 0)
                    {
                        if (oRefrigerioPersonaSelecionado.IdEstado != "AN")
                        {
                            ProgramacionRefrigerioxPersonalMantenimiento oFormulario = new ProgramacionRefrigerioxPersonalMantenimiento(oRefrigerioPersonaSelecionado, 1);
                            oFormulario.Show();
                        }
                    }
                }
            }
        }



    }
}
