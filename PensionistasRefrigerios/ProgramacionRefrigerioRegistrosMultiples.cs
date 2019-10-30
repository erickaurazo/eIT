using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using System.Collections;
using Transportista.Negocios;

using System.Configuration;
using System.Linq;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ProgramacionRefrigerioRegistrosMultiples : Form
    {
        private string mensaje;

        List<ProgramacionRefrigerioMultiples> listadoProgramacion = new List<ProgramacionRefrigerioMultiples>();
        private TextBox control;
        private SJM_PensionesNegocios Logica;
        private SJ_ListadoPersonalGeneral registroPersonalGeneral;
        private RefrigerioAgrupado asistenciaRefrigerio;
        private string nuevoCodigoRegistro = string.Empty;
        private int maximoIngresos = 1;
        private SJ_RHPensionRefrigerioPersonaNegocio modelo;
        private List<ProgramacionRefrigerioMultiples> listadoProgramacionRefrigerios;

        public ProgramacionRefrigerioRegistrosMultiples()
        {
            maximoIngresos = 200;
            InitializeComponent();
            Inicio();
            this.btnAgregarUnTrabajadorLista.Visible = false;
            this.btnAgregar.Visible = true;
            Nuevo();
        }

        public ProgramacionRefrigerioRegistrosMultiples(RefrigerioAgrupado asistenciaRefrigerio)
        {
            maximoIngresos = 1;
            InitializeComponent();
            Inicio();
            this.asistenciaRefrigerio = asistenciaRefrigerio;
            this.txtColaboradoNumeroDni.Text = this.asistenciaRefrigerio.DNITrabajador != null ? this.asistenciaRefrigerio.DNITrabajador.ToString().Trim() : "";
            this.txtParaderoCodigo.Text = "P037";
            this.txtParaderoDescripcion.Text = "HOSPEDAJE - CASONA";
            this.txtPensionCodigo.Text = this.asistenciaRefrigerio.Pension != null ? this.asistenciaRefrigerio.Pension.ToString().Trim() : "";
            this.txtPensionDescripcion.Text = "";
            this.txtColaboradoNumeroDni.ReadOnly = true;
            this.btnAgregarUnTrabajadorLista.Visible = true;
            this.btnAgregar.Visible = false;


        }

        private void ProgramacionRefrigerioRegistrosMultiples_Load(object sender, EventArgs e)
        {
            this.txtColaboradoNumeroDni.Focus();
        }

        public void Inicio()
        {
            try
            {
                #region
                txtRegistradoPor.Text = Environment.UserName.ToString();
                txtFechaRegistro.Text = DateTime.Now.ToShortDateString();
                txtRegistradoPor.ReadOnly = true;
                this.txtFechaRegistro.ReadOnly = true;
                txtValidoDesde.Text = DateTime.Now.ToShortDateString();
                this.txtValidoHasta.Text = DateTime.Now.AddDays(30).ToShortDateString();

                periodoConsulta = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodoConsulta].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "ERICK";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "Erick Aurazo";
                #endregion
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public string periodoConsulta { get; set; }

        private void txtColaboradoNumeroDni_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.txtColaboradoNumeroDni.Text.ToString().Trim().Length == 8)
                {

                    Logica = new SJM_PensionesNegocios();
                    registroPersonalGeneral = new SJ_ListadoPersonalGeneral();
                    registroPersonalGeneral = Logica.ObtenerRegistroPersonalGeneral(this.txtColaboradoNumeroDni.Text.ToString().Trim());
                    this.txtColaboradorNombres.Text = registroPersonalGeneral.nombresCompletos.ToString().Trim();
                    this.txtSubPlanilla.Text = registroPersonalGeneral.subPlanilla.ToString().Trim();
                    this.txtCodigoPersonalGeneral.Text = registroPersonalGeneral.codigoGeneral != null ? registroPersonalGeneral.codigoGeneral.ToString().Trim() : "";
                    this.txtCodigoSubPlanilla.Text = registroPersonalGeneral.tipoPersonal != null ? registroPersonalGeneral.tipoPersonal.ToString().Trim() : "";
                }
                else
                {
                    LimpiarTodoMenosDatosPersonal();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void AgregarALista()
        {
            if (Validar(maximoIngresos) == true)
            {
                try
                {
                    #region
                    if (this.dgvListado != null)
                    {
                        ProgramacionRefrigerioMultiples oProgramacion = new ProgramacionRefrigerioMultiples();
                        oProgramacion.codigo = 0;
                        //oProgramacion.idHospedajePersonal = this.txtCodigoParaderoHospedajePersonal.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtCodigoParaderoHospedajePersonal.Text.ToString().Trim()) : 0;
                        oProgramacion.dniTrabajador = this.txtColaboradoNumeroDni.Text.ToString().Trim();
                        oProgramacion.nombresTrabajador = this.txtColaboradorNombres.Text.ToString().Trim();
                        oProgramacion.hospedajeCodigo = this.txtParaderoCodigo.Text.ToString().Trim();
                        oProgramacion.hospedajeDescripcion = this.txtParaderoDescripcion.Text.ToString().Trim();
                        oProgramacion.pensionCodigo = this.txtPensionCodigo.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtPensionCodigo.Text.ToString().Trim()) : 0;
                        oProgramacion.pensionDescripcion = this.txtPensionDescripcion.Text.ToString().Trim();
                        oProgramacion.almuerzo = chkAlmuerzo.Checked == true ? 1 : 0;
                        oProgramacion.desayuno = chkDesayuno.Checked == true ? 1 : 0;
                        oProgramacion.cena = chkCena.Checked == true ? 1 : 0;
                        oProgramacion.validoDesde = this.txtValidoDesde.Text.ToString().Trim() != "" ? Convert.ToDateTime(this.txtValidoDesde.Text.ToString().Trim()) : (DateTime.Now);
                        oProgramacion.validoHasta = this.txtValidoHasta.Text.ToString().Trim() != "" ? Convert.ToDateTime(this.txtValidoHasta.Text.ToString().Trim()) : (DateTime.Now.AddDays(180));
                        oProgramacion.subPlanilla = this.txtSubPlanilla.Text.ToString().Trim();
                        oProgramacion.codigoPersonalGeneral = this.txtCodigoPersonalGeneral.Text.ToString().Trim();
                        oProgramacion.codigoSubPlanilla = this.txtCodigoSubPlanilla.Text.ToString().Trim();

                        listadoProgramacion.Add(oProgramacion);
                        ArrayList array = new ArrayList();
                        array.Add(oProgramacion.codigo); // oProgramacion.codigo                   
                        array.Add(oProgramacion.dniTrabajador); // oProgramacion.dniTrabajador
                        array.Add(oProgramacion.nombresTrabajador); // oProgramacion.nombresTrabajador                    
                        array.Add(oProgramacion.hospedajeCodigo); // oProgramacion.hospedajeCodigo                   
                        array.Add(oProgramacion.hospedajeDescripcion); // oProgramacion.hospedajeDescripcion
                        array.Add(oProgramacion.pensionCodigo); // oProgramacion.pensionCodigo
                        array.Add(oProgramacion.pensionDescripcion); // oProgramacion.pensionDescripcion 
                        array.Add(oProgramacion.almuerzo); // oProgramacion.almuerzo 
                        array.Add(oProgramacion.desayuno); // oProgramacion.desayuno 
                        array.Add(oProgramacion.cena); // oProgramacion.cena 
                        array.Add(oProgramacion.validoDesde); // oProgramacion.validoDesde 
                        array.Add(oProgramacion.validoHasta); // oProgramacion.validoHasta 
                        array.Add(oProgramacion.subPlanilla); // oProgramacion.subPlanilla   
                        array.Add(oProgramacion.codigoPersonalGeneral); // oProgramacion.codigoPersonalGeneral
                        array.Add(oProgramacion.codigoSubPlanilla); // oProgramacion.codigoSubPlanilla     
                        array.Add(oProgramacion.idHospedajePersonal); // oProgramacion.idHospedajePersonal   

                        this.dgvListado.AgregarFila(array);
                        LimpiarTodoMenosDatosPersonal();
                    }
                    else
                    {
                        Formateador.MostrarMensajeAdvertencia(this, "Haga click en la Grilla a Modificar", "Validacion Ingreso de Datos");
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    Formateador.ControlExcepcion(this, this.Name, ex);
                }
            }
            else
            {
                MessageBox.Show(mensaje, "ADVERTENCIA DEL SISTEMA");
                return;
            }
        }

        private void AgregaUnTrabajadorALista()
        {
            if (Validar(maximoIngresos) == true)
            {
                try
                {
                    #region
                    if (this.dgvListado != null)
                    {
                        ProgramacionRefrigerioMultiples oProgramacion = new ProgramacionRefrigerioMultiples();
                        oProgramacion.codigo = 0;
                        oProgramacion.dniTrabajador = this.txtColaboradoNumeroDni.Text.ToString().Trim();
                        oProgramacion.nombresTrabajador = this.txtColaboradorNombres.Text.ToString().Trim();
                        oProgramacion.hospedajeCodigo = this.txtParaderoCodigo.Text.ToString().Trim();
                        oProgramacion.hospedajeDescripcion = this.txtParaderoDescripcion.Text.ToString().Trim();
                        oProgramacion.pensionCodigo = this.txtPensionCodigo.Text.ToString().Trim() != "" ? Convert.ToInt32(this.txtPensionCodigo.Text.ToString().Trim()) : 0;
                        oProgramacion.pensionDescripcion = this.txtPensionDescripcion.Text.ToString().Trim();
                        oProgramacion.almuerzo = chkAlmuerzo.Checked == true ? 1 : 0;
                        oProgramacion.desayuno = chkDesayuno.Checked == true ? 1 : 0;
                        oProgramacion.cena = chkCena.Checked == true ? 1 : 0;
                        oProgramacion.validoDesde = this.txtValidoDesde.Text.ToString().Trim() != "" ? Convert.ToDateTime(this.txtValidoDesde.Text.ToString().Trim()) : (DateTime.Now);
                        oProgramacion.validoHasta = this.txtValidoHasta.Text.ToString().Trim() != "" ? Convert.ToDateTime(this.txtValidoHasta.Text.ToString().Trim()) : (DateTime.Now.AddDays(180));
                        oProgramacion.subPlanilla = this.txtSubPlanilla.Text.ToString().Trim();
                        oProgramacion.codigoPersonalGeneral = this.txtCodigoPersonalGeneral.Text.ToString().Trim();
                        oProgramacion.codigoSubPlanilla = this.txtCodigoSubPlanilla.Text.ToString().Trim();
                        listadoProgramacion.Add(oProgramacion);
                        ArrayList array = new ArrayList();
                        array.Add(oProgramacion.codigo); // oProgramacion.codigo                   
                        array.Add(oProgramacion.dniTrabajador); // oProgramacion.dniTrabajador
                        array.Add(oProgramacion.nombresTrabajador); // oProgramacion.nombresTrabajador                    
                        array.Add(oProgramacion.hospedajeCodigo); // oProgramacion.hospedajeCodigo                   
                        array.Add(oProgramacion.hospedajeDescripcion); // oProgramacion.hospedajeDescripcion
                        array.Add(oProgramacion.pensionCodigo); // oProgramacion.pensionCodigo
                        array.Add(oProgramacion.pensionDescripcion); // oProgramacion.pensionDescripcion 
                        array.Add(oProgramacion.almuerzo); // oProgramacion.almuerzo 
                        array.Add(oProgramacion.desayuno); // oProgramacion.desayuno 
                        array.Add(oProgramacion.cena); // oProgramacion.cena 
                        array.Add(oProgramacion.validoDesde); // oProgramacion.validoDesde 
                        array.Add(oProgramacion.validoHasta); // oProgramacion.validoHasta 
                        array.Add(oProgramacion.subPlanilla); // oProgramacion.subPlanilla                         
                        array.Add(oProgramacion.codigoPersonalGeneral); // oProgramacion.codigoPersonalGeneral
                        array.Add(oProgramacion.codigoSubPlanilla); // oProgramacion.codigoSubPlanilla
                        this.dgvListado.AgregarFila(array);
                        //LimpiarTodoMenosDatosPersonal();
                    }
                    else
                    {
                        Formateador.MostrarMensajeAdvertencia(this, "Haga click en la Grilla a Modificar", "Validacion Ingreso de Datos");
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    Formateador.ControlExcepcion(this, this.Name, ex);
                }
            }
            else
            {
                MessageBox.Show(mensaje, "ADVERTENCIA DEL SISTEMA");
                return;
            }
        }

        private void LimpiarTodoMenosDatosPersonal()
        {
            try
            {
                this.txtColaboradoNumeroDni.Clear();
                this.txtColaboradorNombres.Clear();
                this.txtSubPlanilla.Clear();
                //this.txtColaboradoNumeroDni.Focus();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                //control.Focus();
                return;
            }
        }

        private void LimpiarControles()
        {
            try
            {
                this.txtColaboradoNumeroDni.Clear();
                this.txtColaboradorNombres.Clear();
                this.txtSubPlanilla.Clear();
                this.txtColaboradoNumeroDni.Clear();
                this.txtCodigoRegistro.Clear();
                this.txtCodigoPersonalGeneral.Clear();
                this.txtCodigoSubPlanilla.Clear();
                this.txtColaboradorNombres.Clear();
                this.txtSubPlanilla.Clear();
                this.chkDesayuno.Checked = false;
                this.chkCena.Checked = false;
                this.txtColaboradoNumeroDni.Focus();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                //control.Focus();
                return;
            }
        }


        private bool Validar(int parametroMaximoControl)
        {
            control = new TextBox();
            mensaje = "";
            bool estado = false;
            if (this.txtColaboradoNumeroDni.Text.ToString().Trim() != null)
            {
                #region
                if (this.txtColaboradoNumeroDni.Text.ToString().Trim().Length == 8)
                {
                    #region
                    int desayuno, almuerzo, cena = 0;
                    desayuno = chkDesayuno.Checked == true ? 1 : 0;
                    almuerzo = chkAlmuerzo.Checked == true ? 1 : 0;
                    cena = chkCena.Checked == true ? 1 : 0;

                    if (parametroMaximoControl > 1)
                    {
                        #region Validar en lista de grilla y registrados en la base de datos()

                        #region Validar registros en la base de datos()
                        /*1.- Obtener toda la información del colaborador que esta registrado en la programación de refrigerios */
                        var ListadoProgramacionPersonalBaseDatos = Logica.ObtenerListadoProgramacionPersonalBaseDatosByTrabajador(this.txtColaboradoNumeroDni.Text.ToString()).ToList();

                        /*2.- Si existe alguna coincidencia de la lista anterior, tengo que evaluar para que el tipo de refrigerios no se duplique */
                        if (ListadoProgramacionPersonalBaseDatos != null && ListadoProgramacionPersonalBaseDatos.ToList().Count > 0)
                        {
                            #region
                            int oDesayuno = Convert.ToInt32(ListadoProgramacionPersonalBaseDatos.Max(x => x.Desayuno != null ? x.Desayuno : 0));
                            int oAlmuerzo = Convert.ToInt32(ListadoProgramacionPersonalBaseDatos.Max(x => x.Almuerzo != null ? x.Almuerzo : 0));
                            int oCena = Convert.ToInt32(ListadoProgramacionPersonalBaseDatos.Max(x => x.Cena != null ? x.Cena : 0));

                            if (oDesayuno == 1 && desayuno == 1)
                            {
                                control = txtColaboradoNumeroDni;
                                mensaje += "Ya existe un registro con el refrigerio desayuno registrado en el sistema \n";
                                foreach (var item in ListadoProgramacionPersonalBaseDatos)
                                {
                                    mensaje += item.Pension + " / Desayuno " + (item.Desayuno.Value != 0 ? "SÍ" : "NO");
                                }

                                //LimpiarTodoMenosDatosPersonal();
                            }
                            else if (oAlmuerzo == 1 && almuerzo == 1)
                            {
                                control = txtColaboradoNumeroDni;
                                mensaje += "Ya existe un registro con el refrigerio almuerzo registrado en el sistema \n";
                                foreach (var item in ListadoProgramacionPersonalBaseDatos)
                                {
                                    mensaje += item.Pension + " / Almuerzo " + (item.Almuerzo.Value != 0 ? "SÍ" : "NO");

                                }
                                //LimpiarTodoMenosDatosPersonal();
                            }
                            else if (oCena == 1 && cena == 1)
                            {
                                control = txtColaboradoNumeroDni;
                                mensaje += "Ya existe un registro con el refrigerio cena registrado en el sistema \n";
                                foreach (var item in ListadoProgramacionPersonalBaseDatos)
                                {
                                    mensaje += item.Pension + " / Cena " + (item.Almuerzo.Value != 0 ? "SÍ" : "NO");

                                }
                                //LimpiarTodoMenosDatosPersonal();
                            }
                            else
                            {

                                //var listaCoincidenciaListaProgramacionRefrigerios = listadoProgramacion.Where(x => x.dniTrabajador.ToString().Trim() == this.txtColaboradoNumeroDni.Text.ToString()).ToList();
                                estado = true;
                            }
                            #endregion
                        }
                        else
                        {
                            #region validar registros en la lista de la grilla()
                            var listaCoincidenciaListaActual = listadoProgramacion.Where(x => x.dniTrabajador.ToString().Trim() == this.txtColaboradoNumeroDni.Text.ToString()).ToList();
                            if (listaCoincidenciaListaActual.ToList().Count > 0)
                            {
                                #region
                                int oDesayuno = listaCoincidenciaListaActual.Max(x => x.desayuno);
                                int oAlmuerzo = listaCoincidenciaListaActual.Max(x => x.almuerzo);
                                int oCena = listaCoincidenciaListaActual.Max(x => x.cena);

                                if (oDesayuno == 1 && desayuno == 1)
                                {
                                    control = txtColaboradoNumeroDni;
                                    mensaje += "Ya existe un registro que incluye desayuno en la lista actual \n";
                                    foreach (var item in listaCoincidenciaListaActual)
                                    {
                                        mensaje += item.pensionDescripcion + " / Desayuno " + (item.almuerzo != 0 ? "SÍ" : "NO");
                                    }
                                    //LimpiarTodoMenosDatosPersonal();
                                }
                                else if (oAlmuerzo == 1 && almuerzo == 1)
                                {
                                    control = txtColaboradoNumeroDni;
                                    mensaje += "Ya existe un registro que incluye almuerzo en la lista actual \n";
                                    foreach (var item in listaCoincidenciaListaActual)
                                    {
                                        mensaje += item.pensionDescripcion + " / Almuerzo " + (item.almuerzo != 0 ? "SÍ" : "NO");
                                    }
                                    //LimpiarTodoMenosDatosPersonal();
                                }
                                else if (oCena == 1 && cena == 1)
                                {
                                    control = txtColaboradoNumeroDni;
                                    mensaje += "Ya existe un registro que incluye cena en la lista actual \n";
                                    foreach (var item in listaCoincidenciaListaActual)
                                    {
                                        mensaje += item.pensionDescripcion + " / Cena " + (item.cena != 0 ? "SÍ" : "NO");
                                    }
                                    //LimpiarTodoMenosDatosPersonal();
                                }
                                else
                                {

                                    //var listaCoincidenciaListaProgramacionRefrigerios = listadoProgramacion.Where(x => x.dniTrabajador.ToString().Trim() == this.txtColaboradoNumeroDni.Text.ToString()).ToList();
                                    estado = true;
                                }
                                #endregion
                            }
                            else
                            {
                                estado = true;
                            }
                            #endregion
                        }
                        #endregion



                        #endregion
                    }
                    else if (parametroMaximoControl == 1)
                    {
                        #region MyRegion

                        #region Validar registros en la base de datos()
                        var ListadoProgramacionPersonalBaseDatos = Logica.ObtenerListadoProgramacionPersonalBaseDatosByTrabajador(this.txtColaboradoNumeroDni.Text.ToString()).ToList();

                        if (ListadoProgramacionPersonalBaseDatos != null && ListadoProgramacionPersonalBaseDatos.ToList().Count > 0)
                        {
                            #region
                            int oDesayuno = Convert.ToInt32(ListadoProgramacionPersonalBaseDatos.Max(x => x.Desayuno != null ? x.Desayuno : 0));
                            int oAlmuerzo = Convert.ToInt32(ListadoProgramacionPersonalBaseDatos.Max(x => x.Almuerzo != null ? x.Almuerzo : 0));
                            int oCena = Convert.ToInt32(ListadoProgramacionPersonalBaseDatos.Max(x => x.Cena != null ? x.Cena : 0));

                            if (oDesayuno == 1 && desayuno == 1)
                            {
                                control = txtColaboradoNumeroDni;
                                mensaje += "Ya existe un registro con el refrigerio desayuno registrado en el sistema \n";
                                foreach (var item in ListadoProgramacionPersonalBaseDatos)
                                {
                                    mensaje += item.Pension + " / Desayuno " + (item.Desayuno.Value != 0 ? "SÍ" : "NO");
                                }

                                // LimpiarTodoMenosDatosPersonal();
                            }
                            else if (oAlmuerzo == 1 && almuerzo == 1)
                            {
                                control = txtColaboradoNumeroDni;
                                mensaje += "Ya existe un registro con el refrigerio almuerzo registrado en el sistema \n";
                                foreach (var item in ListadoProgramacionPersonalBaseDatos)
                                {
                                    mensaje += item.Pension + " / Almuerzo " + (item.Almuerzo.Value != 0 ? "SÍ" : "NO");
                                }

                                LimpiarTodoMenosDatosPersonal();
                            }
                            else if (oCena == 1 && cena == 1)
                            {
                                control = txtColaboradoNumeroDni;
                                mensaje += "Ya existe un registro con el refrigerio cena registrado en el sistema \n";
                                foreach (var item in ListadoProgramacionPersonalBaseDatos)
                                {
                                    mensaje += item.Pension + " / Cena " + (item.Cena.Value != 0 ? "SÍ" : "NO");
                                }

                                //LimpiarTodoMenosDatosPersonal();
                            }
                            else
                            {

                                //var listaCoincidenciaListaProgramacionRefrigerios = listadoProgramacion.Where(x => x.dniTrabajador.ToString().Trim() == this.txtColaboradoNumeroDni.Text.ToString()).ToList();
                                estado = true;
                            }
                            #endregion
                        }
                        #endregion


                        #region validar registros en la lista de la grilla()
                        var listaCoincidenciaListaActual = listadoProgramacion.Where(x => x.dniTrabajador.ToString().Trim() == this.txtColaboradoNumeroDni.Text.ToString()).ToList();

                        if (listaCoincidenciaListaActual.ToList().Count > 0)
                        {
                            #region
                            int oDesayuno = listaCoincidenciaListaActual.Max(x => x.desayuno);
                            int oAlmuerzo = listaCoincidenciaListaActual.Max(x => x.almuerzo);
                            int oCena = listaCoincidenciaListaActual.Max(x => x.cena);

                            if (oDesayuno == 1 && desayuno == 1)
                            {
                                control = txtColaboradoNumeroDni;
                                mensaje += "Ya existe un registro que incluye desayuno en la lista actual \n";
                                foreach (var item in listaCoincidenciaListaActual)
                                {
                                    mensaje += item.pensionDescripcion + " / Desayuno " + (item.desayuno != 0 ? "SÍ" : "NO");
                                }
                                //LimpiarTodoMenosDatosPersonal();
                            }
                            else if (oAlmuerzo == 1 && almuerzo == 1)
                            {
                                control = txtColaboradoNumeroDni;
                                mensaje += "Ya existe un registro que incluye almuerzo en la lista actual \n";
                                foreach (var item in listaCoincidenciaListaActual)
                                {
                                    mensaje += item.pensionDescripcion + " / Almuerzo " + (item.almuerzo != 0 ? "SÍ" : "NO");
                                }
                                //LimpiarTodoMenosDatosPersonal();
                            }
                            else if (oCena == 1 && cena == 1)
                            {
                                control = txtColaboradoNumeroDni;
                                mensaje += "Ya existe un registro que incluye cena en la lista actual \n";
                                foreach (var item in listaCoincidenciaListaActual)
                                {
                                    mensaje += item.pensionDescripcion + " / Cena " + (item.cena != 0 ? "SÍ" : "NO");
                                }
                                //LimpiarTodoMenosDatosPersonal();
                            }
                            else
                            {

                                //var listaCoincidenciaListaProgramacionRefrigerios = listadoProgramacion.Where(x => x.dniTrabajador.ToString().Trim() == this.txtColaboradoNumeroDni.Text.ToString()).ToList();
                                estado = true;
                            }
                            #endregion
                        }
                        else
                        {
                            estado = true;
                            if (listaCoincidenciaListaActual.ToList().Count > 0)
                            {
                                estado = false;
                                mensaje += "Sólo se puede asociar un solo trabajador a la lista \n";
                                //LimpiarTodoMenosDatosPersonal();
                            }



                        }
                        #endregion

                        #endregion
                    }
                    else
                    {

                    }

                    #endregion
                }
                else
                {
                    control = txtColaboradoNumeroDni;
                    mensaje += "La longitud del dni no contiene 8 dígitos \n";
                }
                #endregion
            }
            else
            {
                control = txtColaboradoNumeroDni;
                mensaje += "Ingrese un número de DNI valido \n";
            }

            return estado;
        }

        private void txtColaboradoNumeroDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            try
            {
                btnMenuPrincipal.Enabled = false;
                gbCabecera.Enabled = false;
                gbDetalle.Enabled = false;
                ProgressBar.Visible = true;

                listadoProgramacion = new List<ProgramacionRefrigerioMultiples>();
                dgvListado.CargarDatos(listadoProgramacion.ToDataTable<ProgramacionRefrigerioMultiples>());
                dgvListado.Refresh();
                LimpiarTodoMenosDatosPersonal();
                bgwSubProceso.RunWorkerAsync();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void txtColaboradoNumeroDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarALista();
        }

        private void gbCabecera_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarUnTrabajadorLista_Click(object sender, EventArgs e)
        {
            AgregaUnTrabajadorALista();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarElementoLista();
        }

        private void QuitarElementoLista()
        {
            try
            {
                if (this.dgvListado != null && listadoProgramacion != null && listadoProgramacion.ToList().Count > 0)
                {
                    if (this.dgvListado.CurrentRow != null && this.dgvListado.CurrentRow.Cells["chDNITrabajador"].Value != null)
                    {
                        if (MessageBox.Show(this, "¿Desea eliminar el elemento seleccionado?", "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                listadoProgramacion.RemoveAt(dgvListado.CurrentRow.Index);
                                dgvListado.Rows.Remove(dgvListado.CurrentRow);
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.Message.ToString() + "No se puede eliminar el item selecionado", "MENSAJE DE TEXTO");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "");
                return;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();


        }

        private void Listar()
        {
            try
            {
                listadoProgramacionRefrigerios = new List<ProgramacionRefrigerioMultiples>();
                modelo = new SJ_RHPensionRefrigerioPersonaNegocio();
                listadoProgramacionRefrigerios = modelo.ListarItemGuardados(periodoConsulta, listadoProgramacion);
                //MessageBox.Show("", "");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "");
                return;
            }
        }

        private void Registrar()
        {
            btnMenuPrincipal.Enabled = false;
            gbCabecera.Enabled = false;
            gbDetalle.Enabled = false;
            ProgressBar.Visible = true;
            bgwHilo.RunWorkerAsync();
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                QuitarElementoLista();
            }
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                modelo = new SJ_RHPensionRefrigerioPersonaNegocio();
                modelo.Registrar(periodoConsulta, listadoProgramacion, nuevoCodigoRegistro);
                Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "ADVERTENCIA DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnMenuPrincipal.Enabled = true;
            gbCabecera.Enabled = true;
            gbDetalle.Enabled = true;
            ProgressBar.Visible = false;
            MessageBox.Show("Operación realizada satisfactoriamente", "MENSAJE DEL SISTEMA");

            if (listadoProgramacionRefrigerios != null && listadoProgramacionRefrigerios.ToList().Count > 0)
            {
                dgvListado.CargarDatos(listadoProgramacionRefrigerios.ToDataTable<ProgramacionRefrigerioMultiples>());
                dgvListado.Refresh();
            }


        }

        private void txtParaderoCodigo_Leave(object sender, EventArgs e)
        {
            //string[] cadena = this.txtParaderoDescripcion.Text.ToString().Split('/');

            //if (cadena.ToList().Count > 1)
            //{
            //    AsignarDatosHospedaje(cadena);
            //}
        }

        private void AsignarDatosHospedaje(string[] ncadena)
        {
            this.txtParaderoDescripcion.Text = ncadena[0].ToString().Trim();
            //this.txtCodigoParaderoHospedajePersonal.Text = ncadena[1].ToString().Trim();
        }

        private void bgwSubProceso_DoWork(object sender, DoWorkEventArgs e)
        {
            modelo = new SJ_RHPensionRefrigerioPersonaNegocio();
            nuevoCodigoRegistro = modelo.ObtenerCodigoRegistro();
        }

        private void bgwSubProceso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.txtCodigoRegistro.Text = nuevoCodigoRegistro;
            btnMenuPrincipal.Enabled = true;
            gbCabecera.Enabled = true;
            gbDetalle.Enabled = true;
            ProgressBar.Visible = false;

        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            VistaPrevia();
        }

        private void VistaPrevia()
        {
            if (this.txtCodigoRegistro.Text.ToString().Trim() != "")
            {
                TicketsPrivilegiosRefrigerioImprimir oFrmDetalle = new TicketsPrivilegiosRefrigerioImprimir(this.txtCodigoRegistro.Text);
                oFrmDetalle.AgregarParametroCadena("@impresoPor", Environment.UserName.ToString().Trim().ToUpper());
                oFrmDetalle.ShowDialog();
            }
        }
    }
}
