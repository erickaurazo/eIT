using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
using System.Linq;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ProgramacionRefrigerioxPersonalMantenimiento : Telerik.WinControls.UI.RadForm
    {
        private string Periodo;
        private string Msg;
        private RadTextBox ControlValidar;
        private SJM_PensionesNegocios Modelo;
        private List<SJ_RHPensionRefrigerioBuscarPersonaxCodigoResult> listadoPersona;
        private List<SJ_RHPensionRefrigerioPersonaDetalle> ListaEliminadosDetalle = new List<SJ_RHPensionRefrigerioPersonaDetalle>();
        private string item;
        private SJ_RHPensionRefrigerioPersona oProgramacionRefrigerio;
        private SJ_RHPensionRefrigerioPersonaDetalle oDetalleprogramacionRefrigerio;
        private List<SJ_RHPensionRefrigerioPersonaDetalle> detalle;
        private SJ_RHPensionRefrigerioPersona ObjetoRefrigerioPersona;
        private SJ_RHPensionNegocio pensionNeg;
        private List<SJ_RHPensionListaResult> ListadoPensiones;
        private List<SJ_RHPensionRefrigerioPersonaDetalleListadoResult> ListarDetalle;
        private int codigoProgramacionAsistenciaRefrigerio;
        private List<SJ_RHPensionRefrigerioPersonalRegistradoResult> ListaCabecera;
        private TextBox nControlValidar;
        private SJM_PensionesNegocios Logica;
        private List<SJ_RHPensionRefrigerioPersona> listadoProgramacionRepetida;
        private int esRenovacion = 0;

        public ProgramacionRefrigerioxPersonalMantenimiento()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            Inicio();

            this.barraPrincipal.Enabled = true;
            this.gbPension.Enabled = true;
            this.gbInformacionGeneral.Enabled = true;
            this.gbTipoRefrigerio.Enabled = true;
            this.TabRegistros.Enabled = true;
            this.tabDetalle.Enabled = true;
            this.btnAgregar.Enabled = true;
            this.btnQuitar.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnExportar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnAnular.Enabled = true;
            this.btnAtras.Enabled = true;
            this.btnVistaPrevia.Enabled = true;
            this.btnImprimir.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.gbMantenimientoRegistros.Enabled = true;

        }

        public ProgramacionRefrigerioxPersonalMantenimiento(SJ_RHPensionRefrigerioPersona ObjetoRefrigerioPersona, int esRenovacion)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            Inicio();
            //ActivarEdicion(true);            
            this.ObjetoRefrigerioPersona = ObjetoRefrigerioPersona;
            this.txtCodigo.Text = this.ObjetoRefrigerioPersona.Id.ToString().Trim();
            this.esRenovacion = esRenovacion;

            MostrarDocumento();

            if (ObjetoRefrigerioPersona.IdEstado == "AN")
            {
                #region 
                this.barraPrincipal.Enabled = true;
                this.gbPension.Enabled = false;
                this.gbInformacionGeneral.Enabled = false;
                this.gbTipoRefrigerio.Enabled = false;
                this.TabRegistros.Enabled = false;
                this.tabDetalle.Enabled = true;
                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnExportar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnAnular.Enabled = true;
                this.btnAtras.Enabled = false;
                this.btnVistaPrevia.Enabled = false;
                this.btnImprimir.Enabled = false;
                this.btnEliminar.Enabled = true;
                this.gbMantenimientoRegistros.Enabled = true;
                #endregion
            }
            else if (ObjetoRefrigerioPersona.IdEstado == "AC")
            {
                #region
                this.barraPrincipal.Enabled = true;
                this.gbPension.Enabled = false;
                this.gbInformacionGeneral.Enabled = false;
                this.gbTipoRefrigerio.Enabled = true;
                this.TabRegistros.Enabled = true;
                this.tabDetalle.Enabled = true;
                this.btnAgregar.Enabled = true;
                this.btnQuitar.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnExportar.Enabled = false;
                this.btnGrabar.Enabled = true;
                this.btnAnular.Enabled = true;
                this.btnAtras.Enabled = true;
                this.btnVistaPrevia.Enabled = true;
                this.btnImprimir.Enabled = true;
                this.btnEliminar.Enabled = true;
                this.gbMantenimientoRegistros.Enabled = true;
                #endregion
            }
        }
        
        private void MostrarDocumento()
        {
            this.bwgHilo.RunWorkerAsync();
        }

        public void Inicio()
        {
            try
            {
                Periodo = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + Periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "CHRISTIAN";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Christian LLontop";
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtCodigo.Text.ToString().Trim() != "")
            {
                Editar();
            }

        }

        private void Editar()
        {
            if (this.txtIdEstado.Text != "AN")
            {
                this.barraPrincipal.Enabled = true;
                this.gbPension.Enabled = false;
                this.gbInformacionGeneral.Enabled = false;
                this.gbTipoRefrigerio.Enabled = true;
                this.TabRegistros.Enabled = true;
                this.tabDetalle.Enabled = true;
                this.btnAgregar.Enabled = true;
                this.btnQuitar.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnExportar.Enabled = false;
                this.btnGrabar.Enabled = true;
                this.btnAnular.Enabled = true;
                this.btnAtras.Enabled = true;
                this.btnVistaPrevia.Enabled = true;
                this.btnImprimir.Enabled = true;
                this.btnEliminar.Enabled = true;
                this.gbMantenimientoRegistros.Enabled = true;
            }
            else
            {
                MessageBox.Show("El documento no se pueda editar, por no tener el estado adecuado", "MENSAJE DE SISTEMA");
                return;
            }
        }

        private void ActivarEdicion(bool estado)
        {
            gbMantenimientoRegistros.Enabled = estado;
            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = false;
            this.btnExportar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnAnular.Enabled = true;
            this.btnAtras.Enabled = true;
            this.gbPension.Enabled = true;
            gbInformacionGeneral.Enabled = true;
            TabRegistros.Enabled = true;

        }

        private void RefrigerioxPersonalMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarTarifa_Click(object sender, EventArgs e)
        {
            if (ValidarGrabado() == true)
            {
                AgregarFila();
            }
            else
            {
                RadMessageBox.Show(Msg, "Atención");
                ControlValidar.Focus();
            }
        }

        private void AgregarFila()
        {
            try
            {
                if (this.dgvDetalle != null)
                {
                    ArrayList array = new ArrayList();
                    array.Add(this.txtCodigo.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtCodigo.Text.ToString().Trim()) : Convert.ToInt32(0)); // Codigo                   
                    array.Add((AsignarNumeroItemsGrilla(ObtenerUltimoNumeroItem(dgvDetalle)))); // item
                    array.Add(DateTime.Now.ToPresentationDate()); // ValidoDesde
                    DateTime? ultimoDiaMes = Convert.ToDateTime("31/12/" + DateTime.Now.Year.ToString());
                    array.Add(ultimoDiaMes); // ValidoHasta                   
                    array.Add(string.Empty); // Observacion
                    array.Add("AC"); // IdEstado
                    array.Add("Activo"); // Estado                                        
                    this.dgvDetalle.AgregarFila(array);
                }
                else
                {
                    Formateador.MostrarMensajeAdvertencia(this, "Haga click en la Grilla a Modificar", "Validacion Ingreso de Datos");
                }
            }
            catch (Exception ex)
            {
                Formateador.ControlExcepcion(this, this.Name, ex);
            }
        }

        private int ObtenerUltimoNumeroItem(DataGridView grilla)
        {
            List<int> numItem = new List<int>();
            if (grilla.Rows.Count > 0)
            {
                foreach (DataGridViewRow filas in grilla.Rows)
                {
                    /* agrego la columna 1, por que en ambos caso la filla items esta situada en la colunmna 1*/
                    numItem.Add((filas.Cells[1].Value) != null ? Convert.ToInt32(filas.Cells[1].Value) : 0);
                }
            }
            else
            {
                numItem.Add(0);
            }

            return numItem.Max();

        }

        private string AsignarNumeroItemsGrilla(int numeroRegistros)
        {
            #region
            string item = "";
            numeroRegistros += 1;

            switch (numeroRegistros.ToString().Length)
            {
                case 1:
                    item = "00" + numeroRegistros.ToString();
                    break;

                case 2:
                    item = "0" + numeroRegistros.ToString();
                    break;

                case 3:
                    item = numeroRegistros.ToString();
                    break;

                default:
                    item = "";
                    break;
            }


            return item;
            #endregion
        }

        private bool ValidarGrabado()
        {
            bool Estado = true;
            Msg = string.Empty;
            ControlValidar = new RadTextBox();
            nControlValidar = new TextBox();

            if (this.txtIdPension.Text.ToString().Trim() == "")
            {
                Msg += "Debe ingresar un código de pension \n";
                nControlValidar = this.txtRUCNumero;
                Estado = false;
            }
            else if (this.txtNroDNI.Text.ToString().Trim() == "")
            {
                Msg += "código de personal valido \n";
                nControlValidar = this.txtRUCNumero;
                Estado = false;
            }
            else
            {
                #region
                ObtenerSJ_RHPensionRefrigerioPersona();
                if (txtCodigo.Text != "")
                {
                    /* Es la edición de un documento */
                }
                else
                {
                    if (this.esRenovacion == 0)
                    {
                        #region
                        Estado = ValidarDuplicidadRegistro(Periodo, oProgramacionRefrigerio); /* Si es true, que me deje grabar, si es false tiene duplicidad */

                        if (Estado == false)
                        {
                            Msg += "Existe duplicidad con el personal \n";

                            foreach (var item in listadoProgramacionRepetida)
                            {
                                Msg += "En pensión : " + item.Pension + " tiene desayuno: " + (item.Desayuno.Value != 0 ? "SÍ" : "NO") + " tiene almuerzo: " + (item.Almuerzo.Value != 0 ? "SÍ" : "NO") + " tiene cena: " + (item.Cena.Value != 0 ? "SÍ" : "NO") + "\n";
                            }
                            nControlValidar = this.txtCodigoPersonal;
                        }
                        #endregion
                    }

                   
                }

                #endregion
            }

            return Estado;
        }

        private void btnQuitarTarifa_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                if (dgvDetalle.CurrentRow != null)
                {
                    QuitarFila();
                }
            }
        }

        private void QuitarFila()
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

                            Int32 Codigo = (this.dgvDetalle.CurrentRow.Cells["chId"].Value != null ? Convert.ToInt32(this.dgvDetalle.CurrentRow.Cells["chId"].Value) : 0);
                            if (Codigo != 0)
                            {
                                string Item = ((this.dgvDetalle.CurrentRow.Cells["chItem"].Value != null | this.dgvDetalle.CurrentRow.Cells["chItem"].Value.ToString().Trim() != string.Empty) ? Convert.ToString(this.dgvDetalle.CurrentRow.Cells["chItem"].Value) : "");
                                if (Item != "")
                                {
                                    ListaEliminadosDetalle.Add(new SJ_RHPensionRefrigerioPersonaDetalle
                                    {
                                        Id = Codigo,
                                        Item = Item,
                                    });
                                }

                            }

                            dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
                        }
                        catch (Exception Ex)
                        {
                            throw Ex;
                        }
                    }
                }
                #endregion
            }
        }

        private void btnAltaTarifa_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                if (item != "")
                {
                    this.dgvDetalle.CurrentRow.Cells["chIdEstado"].Value = "AC";
                    this.dgvDetalle.CurrentRow.Cells["chEstado"].Value = "Activo";
                }
            }
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvDetalle != null)
            {
                if (this.dgvDetalle.CurrentRow != null)
                {
                    item = dgvDetalle.CurrentRow.Cells["chItem"] != null ? dgvDetalle.CurrentRow.Cells["chItem"].Value.ToString().Trim() : "";
                }
            }
        }

        private void btnAltaBaja_Click(object sender, EventArgs e)
        {
            if (item != null)
            {
                if (item != "")
                {
                    dgvDetalle.CurrentRow.Cells["chIdEstado"].Value = "CR";
                    dgvDetalle.CurrentRow.Cells["chEstado"].Value = "Cerrado";
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();

        }

        private void Grabar()
        {
            if (this.txtIdEstado.Text != "AN")
            {
                ObtenerObjetoRefrigerioPersona();
                if (dgvDetalle != null && dgvDetalle.Rows.Count > 0)
                {
                    if (ValidarDuplicidadRegistro(Periodo, oProgramacionRefrigerio) == true) /* Si es true, que me deje grabar, si es false tiene duplicidad */
                    {
                        #region Validar Grabado()
                        if (ValidarGrabado() == true)
                        {
                            //ObtenerObjetoRefrigerioPersona();
                            Modelo = new SJM_PensionesNegocios();
                            if (this.esRenovacion == 1)
                            {
                                bool estadoAnulado = AnularTicketActivosPorCodigoPersonal(Periodo, oProgramacionRefrigerio);
                            }
                           
                            this.txtCodigo.Text = Modelo.RegistrarProgramacionRefrigerio(oProgramacionRefrigerio, detalle, ListaEliminadosDetalle).ToString();
                            RadMessageBox.Show("Grabado correctamente", "Atención");
                            this.esRenovacion = 0;
                            //ActivarEdicion(false);
                            //this.btnGrabar.Enabled = false;
                            this.barraPrincipal.Enabled = true;
                            this.gbPension.Enabled = false;
                            this.gbInformacionGeneral.Enabled = false;
                            this.gbTipoRefrigerio.Enabled = false;
                            this.TabRegistros.Enabled = false;
                            this.tabDetalle.Enabled = false;
                            this.btnAgregar.Enabled = false;
                            this.btnQuitar.Enabled = false;
                            this.btnNuevo.Enabled = true;
                            this.btnEditar.Enabled = true;
                            this.btnExportar.Enabled = false;
                            this.btnGrabar.Enabled = false;
                            this.btnAnular.Enabled = false;
                            this.btnAtras.Enabled = false;
                            btnSalir.Enabled = true;
                            this.btnVistaPrevia.Enabled = false;
                            this.btnImprimir.Enabled = false;
                            this.btnEliminar.Enabled = false;
                            this.gbMantenimientoRegistros.Enabled = true;
                        }
                        else
                        {
                            RadMessageBox.Show(Msg, "Atención");
                            ControlValidar.Focus();
                        }
                        #endregion
                    }
                    else
                    {
                        oProgramacionRefrigerio = new SJ_RHPensionRefrigerioPersona();
                        MessageBox.Show("Existe duplicidad del registro ", "ADVERTENCIA DEL SISTEMA");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("El registro debe contenener al menos un detalle del inicio y termino del beneficio del refrigerio ", "ADVERTENCIA DEL SISTEMA");
                    return;
                }


            }
            else
            {
                MessageBox.Show("El documento no se pueda editar, por no tener el estado adecuado", "MENSAJE DE SISTEMA");
                return;
            }
        }

        private void ObtenerObjetoRefrigerioPersona()
        {

            try
            {
                #region Obtener Objeto para registro()
                ObtenerSJ_RHPensionRefrigerioPersona();
                Modelo = new SJM_PensionesNegocios();

                #region Obtener detalle registro()
                detalle = new List<SJ_RHPensionRefrigerioPersonaDetalle>();
                if (dgvDetalle != null)
                {
                    #region Agregar elementos a la lista()
                    if (dgvDetalle.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow fila in this.dgvDetalle.Rows)
                        {
                            if (fila.Cells["chValidoDesde"].Value.ToString().Trim() != String.Empty)
                            {
                                oDetalleprogramacionRefrigerio = new SJ_RHPensionRefrigerioPersonaDetalle();
                                oDetalleprogramacionRefrigerio.Id = oProgramacionRefrigerio.Id;
                                oDetalleprogramacionRefrigerio.Item = fila.Cells["chItem"].Value != null ? fila.Cells["chItem"].Value.ToString().Trim() : "";
                                oDetalleprogramacionRefrigerio.ValidoDesde = fila.Cells["chValidoDesde"].Value != null ? Convert.ToDateTime(fila.Cells["chValidoDesde"].Value.ToString().Trim()) : (DateTime?)null;
                                oDetalleprogramacionRefrigerio.ValidoHasta = fila.Cells["chValidoHasta"].Value != null ? Convert.ToDateTime(fila.Cells["chValidoHasta"].Value.ToString().Trim()) : (DateTime?)null;
                                oDetalleprogramacionRefrigerio.Observacion = fila.Cells["chObservacion"].Value != null ? Convert.ToString(fila.Cells["chObservacion"].Value.ToString().Trim()) : "";
                                oDetalleprogramacionRefrigerio.IdEstado = fila.Cells["chIdEstado"].Value != null ? fila.Cells["chIdEstado"].Value.ToString().Trim() : "AC";
                                detalle.Add(oDetalleprogramacionRefrigerio);
                            }
                        }
                    }
                    #endregion
                }
                #endregion

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void ObtenerSJ_RHPensionRefrigerioPersona()
        {
            oProgramacionRefrigerio = new SJ_RHPensionRefrigerioPersona();
            oProgramacionRefrigerio.Id = this.txtCodigo.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtCodigo.Text.ToString().Trim()) : Convert.ToInt32(0);
            oProgramacionRefrigerio.idParaderoPersonal = this.txtCodigoPersonalParadero.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtCodigoPersonalParadero.Text.ToString().Trim()) : Convert.ToInt32(0);
            oProgramacionRefrigerio.IdCodigoPersonal = this.txtCodigoPersonal.Text.ToString().Trim();
            oProgramacionRefrigerio.NroDocumento = this.txtNroDNI.Text.ToString().Trim();
            oProgramacionRefrigerio.NombresCompletos = this.txtNombresCompletosTrabajador.Text.ToString().Trim();
            oProgramacionRefrigerio.IdSubPlanilla = this.txtIdSubPlanilla.Text.ToString().Trim();
            oProgramacionRefrigerio.SubPlanilla = this.txtSubPlanilla.Text.ToString().Trim();
            oProgramacionRefrigerio.Condicion = this.txtCondicion.Text.ToString().Trim();
            oProgramacionRefrigerio.IdPension = this.txtIdPension.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtIdPension.Text.ToString().Trim()) : (int?)null;
            oProgramacionRefrigerio.NroDNIPension = this.txtRucDNIResponsable.Text.ToString().Trim();
            oProgramacionRefrigerio.Pension = this.txtRucNombreComercial.Text.ToString().Trim();
            oProgramacionRefrigerio.Desayuno = this.chkDesayuno.Checked == true ? Convert.ToByte(1) : Convert.ToByte(0);
            oProgramacionRefrigerio.Almuerzo = this.chkAlmuerzo.Checked == true ? Convert.ToByte(1) : Convert.ToByte(0);
            oProgramacionRefrigerio.Cena = this.chkCena.Checked == true ? Convert.ToByte(1) : Convert.ToByte(0);
            oProgramacionRefrigerio.Otro = this.chkOtro.Checked == true ? Convert.ToByte(1) : Convert.ToByte(0);
            oProgramacionRefrigerio.IdEstado = this.txtIdEstado.Text.ToString().Trim();
        }





        private bool ValidarDuplicidadRegistro(string Periodo, SJ_RHPensionRefrigerioPersona oProgramacionRefrigerio)
        {
            /* Si es true, que me deje grabar, si es false tiene duplicidad */
            listadoProgramacionRepetida = new List<SJ_RHPensionRefrigerioPersona>();
            bool estado = true;
            try
            {
                if (this.esRenovacion == 0)
                {
                    Modelo = new SJM_PensionesNegocios();
                    listadoProgramacionRepetida = Modelo.ValidarDuplicidadRegistro(Periodo, oProgramacionRefrigerio);

                    if (listadoProgramacionRepetida != null && listadoProgramacionRepetida.ToList().Count > 0)
                    {
                        estado = false;
                    }
                }
                

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return false;
            }

            return estado;
        }


        private bool AnularTicketActivosPorCodigoPersonal(string Periodo, SJ_RHPensionRefrigerioPersona oProgramacionRefrigerio)
        {
            /* Si es true, que me deje grabar, si es false tiene duplicidad */
            listadoProgramacionRepetida = new List<SJ_RHPensionRefrigerioPersona>();
            bool estado = true;
            try
            {
                Modelo = new SJM_PensionesNegocios();
                listadoProgramacionRepetida = Modelo.AnularTicketsActivosPorCodigoPersonal(Periodo, oProgramacionRefrigerio);

                if (listadoProgramacionRepetida != null && listadoProgramacionRepetida.ToList().Count > 0)
                {
                    estado = false;
                }

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
            }

            return estado;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Atras();
        }

        private void Atras()
        {
            this.barraPrincipal.Enabled = true;
            this.gbPension.Enabled = false;
            this.gbInformacionGeneral.Enabled = false;
            this.gbTipoRefrigerio.Enabled = false;
            this.TabRegistros.Enabled = false;
            this.tabDetalle.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = false;
            this.btnExportar.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnAnular.Enabled = false;
            this.btnAtras.Enabled = false;
            this.btnVistaPrevia.Enabled = false;
            this.btnImprimir.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.gbMantenimientoRegistros.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            LimpiarFormulario();
            this.barraPrincipal.Enabled = true;
            this.gbPension.Enabled = true;
            this.gbInformacionGeneral.Enabled = true;
            this.gbTipoRefrigerio.Enabled = true;
            this.TabRegistros.Enabled = true;
            this.tabDetalle.Enabled = true;
            this.btnAgregar.Enabled = true;
            this.btnQuitar.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnExportar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnAnular.Enabled = true;
            this.btnAtras.Enabled = true;
            this.btnVistaPrevia.Enabled = true;
            this.btnImprimir.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.gbMantenimientoRegistros.Enabled = true;
        }

        private void LimpiarFormulario()
        {
            txtIdPension.Clear();
            txtRUCNumero.Clear();
            txtRucRazonSocial.Clear();
            txtRucDNIResponsable.Clear();
            txtRucNombresResponsable.Clear();
            txtRucNombreComercial.Clear();

            txtIdEstado.Text = "AC";
            txtEstado.Text = "ACTIVO";
            txtCodigo.Clear();
            txtCodigoPersonal.Clear();
            txtNroDNI.Clear();
            txtCondicion.Clear();
            txtNombresCompletosTrabajador.Clear();
            txtIdSubPlanilla.Clear();
            txtSubPlanilla.Clear();
            chkAlmuerzo.Checked = false;
            chkCena.Checked = false;
            chkDesayuno.Checked = false;
            chkOtro.Checked = false;

            if (dgvDetalle != null && dgvDetalle.Rows.Count > 0)
            {
                for (int i = 0; i < dgvDetalle.Rows.Count; i++)
                {
                    dgvDetalle.Rows.Remove(dgvDetalle.Rows[i]);
                }
            }

            oProgramacionRefrigerio = new SJ_RHPensionRefrigerioPersona();
            detalle = new List<SJ_RHPensionRefrigerioPersonaDetalle>();


        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (this.txtCodigo.Text.ToString().Trim() != "")
            {
                Anular();
            }

        }

        private void Anular()
        {
            try
            {
                ObtenerObjetoRefrigerioPersona();
                Modelo = new SJM_PensionesNegocios();
                Modelo.AnularProgramacionAsistenciaRefrigerioByTrabajador(Periodo, oProgramacionRefrigerio, 1);
                MessageBox.Show("El registro a cambiado correctamente el estado del documento", "Mensaje de Sistema");
                MostrarDocumento();
                //gbMantenimientoRegistros.Enabled = false;
                //this.txtIdEstado.Text = "AN";
                //this.txtEstado.Text = "ANULADO";

                if (oProgramacionRefrigerio.IdEstado.ToString().Trim() == "AN") /*va a pasar a activo*/
                {
                    this.barraPrincipal.Enabled = true;
                    this.gbPension.Enabled = false;
                    this.gbInformacionGeneral.Enabled = false;
                    this.gbTipoRefrigerio.Enabled = false;
                    this.TabRegistros.Enabled = false;
                    this.tabDetalle.Enabled = false;
                    this.btnAgregar.Enabled = false;
                    this.btnQuitar.Enabled = false;
                    this.btnNuevo.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnExportar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnAnular.Enabled = true;
                    this.btnAtras.Enabled = false;
                    this.btnVistaPrevia.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.gbMantenimientoRegistros.Enabled = true;
                }
                else if (this.txtIdEstado.Text.ToString().Trim() == "AC") /*va a pasar a anulado*/
                {
                    this.barraPrincipal.Enabled = true;
                    this.gbPension.Enabled = false;
                    this.gbInformacionGeneral.Enabled = false;
                    this.gbTipoRefrigerio.Enabled = false;
                    this.TabRegistros.Enabled = false;
                    this.tabDetalle.Enabled = false;
                    this.btnAgregar.Enabled = false;
                    this.btnQuitar.Enabled = false;
                    this.btnNuevo.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnExportar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnAnular.Enabled = true;
                    this.btnAtras.Enabled = false;
                    this.btnVistaPrevia.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.gbMantenimientoRegistros.Enabled = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMAS");
                return;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.bwgHilo.IsBusy == true)
            {

                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose",
                                "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Close();
            }
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            VistaPrevia();
        }

        private void VistaPrevia()
        {
            if (this.txtCodigo.Text.ToString().Trim() != "")
            {
                TicketPrivilegioRefrigerioImprimir oFrmDetalle = new TicketPrivilegioRefrigerioImprimir(this.txtCodigo.Text);
                oFrmDetalle.AgregarParametroCadena("@impresoPor", Environment.UserName.ToString().Trim().ToUpper());
                oFrmDetalle.ShowDialog();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.txtCodigo.Text.ToString().Trim() != "")
            {
                ImprimirTicket();
            }
        }

        private void ImprimirTicket()
        {
            VistaPrevia();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {

            if (this.txtCodigo.Text.ToString().Trim() != "")
            {
                if (Environment.MachineName.ToString().Trim() == "EAURAZOC" || Environment.MachineName.ToString().Trim() == "JGUERREROD" || Environment.MachineName.ToString().Trim() == "CLLONTOPF")
                {

                    Logica = new SJM_PensionesNegocios();
                    ObtenerSJ_RHPensionRefrigerioPersona();
                    Logica.EliminarProgramacionAsistenciaRefrigerioByTrabajador(Periodo, oProgramacionRefrigerio, 1);
                    Nuevo();

                    this.barraPrincipal.Enabled = true;
                    this.gbPension.Enabled = false;
                    this.gbInformacionGeneral.Enabled = false;
                    this.gbTipoRefrigerio.Enabled = false;
                    this.TabRegistros.Enabled = false;
                    this.tabDetalle.Enabled = false;
                    this.btnAgregar.Enabled = false;
                    this.btnQuitar.Enabled = false;
                    this.btnNuevo.Enabled = true;
                    this.btnEditar.Enabled = false;
                    this.btnExportar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnAnular.Enabled = false;
                    this.btnAtras.Enabled = false;
                    this.btnVistaPrevia.Enabled = false;
                    this.btnImprimir.Enabled = false;
                    this.btnEliminar.Enabled = false;
                    this.gbMantenimientoRegistros.Enabled = true;
                    MessageBox.Show("el registro fue eliminado correctamente", "MENSAJE DEL SISTEMA");
                }
                else
                {
                    MessageBox.Show("No tiene privilegios para realizar esta operación", "MENSAJE DEL SISTEMA");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Este documento no tiene codigo generado para la eliminación", "MENSAJE DEL SISTEMA");
                return;
            }


        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            ObtenerObjeto();
        }

        private void ObtenerObjeto()
        {
            try
            {
                ListaCabecera = new List<SJ_RHPensionRefrigerioPersonalRegistradoResult>();
                Modelo = new SJM_PensionesNegocios();
                ListaCabecera = Modelo.ObtenerListaPersonalRegistrado(this.ObjetoRefrigerioPersona.Id);

                if (ListaCabecera != null && ListaCabecera.ToList().Count == 1)
                {
                    int codigoObjeto = ListaCabecera.Single().Id;
                    Modelo = new SJM_PensionesNegocios();
                    ListarDetalle = new List<SJ_RHPensionRefrigerioPersonaDetalleListadoResult>();
                    ListarDetalle = Modelo.ObtenerListaPersonalRegistradoDetallado(codigoObjeto).ToList();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarObjeto();
        }

        private void PresentarObjeto()
        {
            if (ListaCabecera != null)
            {
                #region
                if (ListaCabecera.ToList().Count() > 0)
                {
                    this.txtCodigoPersonal.Text = ListaCabecera.FirstOrDefault().IdCodigoPersonal;
                    this.txtNroDNI.Text = ListaCabecera.FirstOrDefault().NroDocumento;
                    this.txtCondicion.Text = ListaCabecera.FirstOrDefault().Condicion;
                    this.txtNombresCompletosTrabajador.Text = ListaCabecera.FirstOrDefault().NombresCompletos;
                    this.txtSubPlanilla.Text = ListaCabecera.FirstOrDefault().SubPlanilla;
                    this.txtIdSubPlanilla.Text = ListaCabecera.FirstOrDefault().IdSubPlanilla;

                    this.txtCodigoPersonalParadero.Text = ListaCabecera.FirstOrDefault().idParaderoPersonal != null ? ListaCabecera.FirstOrDefault().idParaderoPersonal.ToString() : "";

                    this.txtIdPension.Text = ListaCabecera.FirstOrDefault().IdPension.ToString();
                    this.txtRucDNIResponsable.Text = ListaCabecera.FirstOrDefault().NroDNIPension;
                    this.txtRucNombreComercial.Text = ListaCabecera.FirstOrDefault().Pension;
                    //this.txtRUCNumero.Text = ListaCabecera.FirstOrDefault().ruc;
                    //this.txtRucRazonSocial.Text = ListaCabecera.FirstOrDefault().;
                    //this.txtRucNombresResponsable.Text = ListaCabecera.FirstOrDefault().;

                    this.txtEstado.Text = ListaCabecera.FirstOrDefault().IdEstado.ToString().Trim() == "AC" ? "ACTIVO" : "ANULADO";
                    this.txtIdEstado.Text = ListaCabecera.FirstOrDefault().IdEstado;

                    pensionNeg = new SJ_RHPensionNegocio();
                    ListadoPensiones = new List<SJ_RHPensionListaResult>();
                    ListadoPensiones = pensionNeg.ListadoPensiones().Where(x => x.IdPension == ListaCabecera.FirstOrDefault().IdPension).ToList();

                    if (ListadoPensiones != null)
                    {
                        if (ListadoPensiones.ToList().Count > 0)
                        {
                            this.txtRUCNumero.Text = ListadoPensiones.FirstOrDefault().NroRuc.ToString().Trim();
                            this.txtRucRazonSocial.Text = ListadoPensiones.FirstOrDefault().RazonSocial.ToString().Trim();
                            this.txtRucNombresResponsable.Text = ListadoPensiones.FirstOrDefault().NombresCompletos.ToString().Trim();
                        }

                    }

                    chkDesayuno.Checked = ListaCabecera.FirstOrDefault().Desayuno == 1 ? true : false;
                    chkAlmuerzo.Checked = ListaCabecera.FirstOrDefault().Almuerzo == 1 ? true : false;
                    chkCena.Checked = ListaCabecera.FirstOrDefault().Cena == 1 ? true : false;
                    chkOtro.Checked = ListaCabecera.FirstOrDefault().Otro == 1 ? true : false;

                    if (this.esRenovacion == 0)
                    {
                        if (ListarDetalle != null && ListarDetalle.ToList().Count > 0)
                        {
                            dgvDetalle.CargarDatos(ListarDetalle.ToDataTable<SJ_RHPensionRefrigerioPersonaDetalleListadoResult>());
                            dgvDetalle.Refresh();
                        }    
                    }
                    else
                    {
                        ListarDetalle = new List<SJ_RHPensionRefrigerioPersonaDetalleListadoResult>();
                        this.txtCodigo.Text = string.Empty;
                        oProgramacionRefrigerio = new SJ_RHPensionRefrigerioPersona();
                        oProgramacionRefrigerio.Id = 0;
                        gbPension.Enabled = true;
                        txtRUCNumero.Enabled = true;
                        txtRUCNumero.ReadOnly = false;
                        btnBuscarPension.Enabled = true;
                    }
                    

                    



                }
                #endregion
            }
        }

        private void ProgramacionRefrigerioxPersonalMantenimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bwgHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Close();
            }
        }

        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {
            ImprimirTicket();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            Historial ofrm = new Historial(this.txtCodigo.Text.ToString().Trim(), "0", "SJ_RHPensionRefrigerioPersona");
            ofrm.Text = "Historial del Registros";
            ofrm.ShowDialog();

            //Historial newMDIChild = new Historial(this.txtCodigo.Text.ToString().Trim(), "0", "SJ_RHPensionRefrigerioPersona");
            //newMDIChild.MdiParent = ConsolidadoAsistenciasRefrigerioByTransferencia.ActiveForm;
            //newMDIChild.Text = "Historial del Registros";
            //newMDIChild.ShowDialog();
            //newMDIChild.WindowState = FormWindowState.Maximized;

        }

        private void AsignarDatosPension(string[] ncadena)
        {
            this.txtRucRazonSocial.Text = ncadena[0].ToString().Trim();
            this.txtIdPension.Text = ncadena[4].ToString().Trim();
            //this.txtRUCNumero.Text = ncadena[0].ToString().Trim();
            this.txtRucDNIResponsable.Text = ncadena[1].ToString().Trim();
            this.txtRucNombresResponsable.Text = ncadena[2].ToString().Trim();
            this.txtRucNombreComercial.Text = ncadena[3].ToString().Trim();

        }

        private void AsignarDatosPersonal(string[] ncadena)
        {
            this.txtNroDNI.Text = ncadena[0].ToString().Trim();
            this.txtCondicion.Text = ncadena[4].ToString().Trim().ToUpper();
            this.txtNombresCompletosTrabajador.Text = ncadena[1].ToString().ToUpper().Trim();
            this.txtSubPlanilla.Text = ncadena[3].ToString().ToUpper().Trim();
            this.txtIdSubPlanilla.Text = ncadena[2].ToString().ToUpper().Trim();
            this.txtHospedajeDescripcion.Text = ncadena[5].ToString().ToUpper().Trim();
            this.txtCodigoPersonalParadero.Text = ncadena[6].ToString().ToUpper().Trim();
        }

        private void btnBuscarPension_Click(object sender, EventArgs e)
        {
            string[] cadena = this.txtRucRazonSocial.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPension(cadena);
            }
        }

        private void txtRUCNumero_Leave(object sender, EventArgs e)
        {

            string[] cadena = this.txtRucRazonSocial.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPension(cadena);
            }
        }

        private void btnBuscarPersonal_Click(object sender, EventArgs e)
        {



            string[] cadena = this.txtNombresCompletosTrabajador.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPersonal(cadena);
            }


        }

        private void txtCodigoPersonal_Leave(object sender, EventArgs e)
        {
            /*
            this.txtNroDNI.Text = "";
            this.txtCondicion.Text = "";
            this.txtNombresCompletosTrabajador.Text = "";
            this.txtSubPlanilla.Text = "";
            this.txtIdSubPlanilla.Text = "";
            */
            string[] cadena = this.txtNombresCompletosTrabajador.Text.ToString().Split('/');

            if (cadena.ToList().Count > 1)
            {
                AsignarDatosPersonal(cadena);
            }

        }

        private void btnBuscarPension_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtRUCNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }

        }

        private void txtRucRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void txtEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void txtRucDNIResponsable_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void txtRucNombresResponsable_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void txtRucNombreComercial_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void txtCodigoPersonal_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void txtNroDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void txtCondicion_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void txtNombresCompletosTrabajador_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void txtSubPlanilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void gbTipoRefrigerio_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void chkDesayuno_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void chkAlmuerzo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void chkCena_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void chkOtro_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void ProgramacionRefrigerioxPersonalMantenimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void gbMantenimientoRegistros_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void dgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void TabRegistros_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.G)
            {
                Grabar();
            }
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                Nuevo();
            }
            if (e.KeyData == (Keys.Control | Keys.Z))
            {
                Atras();
            }
            if (e.KeyData == (Keys.Control | Keys.E))
            {
                Atras();
            }
        }

        private void ProgramacionRefrigerioxPersonalMantenimiento_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (this.bwgHilo.IsBusy == true)
            {
                e.Cancel = true;
                MessageBox.Show("No puede cerrar la ventana, Existe un proceso ejecutandose", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            }
        }




    }
}
