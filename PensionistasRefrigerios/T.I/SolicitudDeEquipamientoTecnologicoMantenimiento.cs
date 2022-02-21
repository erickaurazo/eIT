using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Asistencia.Datos;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using Asistencia.Negocios;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Busquedas;
using Asistencia.Helper;
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Globalization;
using Telerik.WinControls.Data;
using System.Threading;
using Telerik.WinControls.UI.Localization;


namespace ComparativoHorasVisualSATNISIRA.T.I
{
    public partial class SolicitudDeEquipamientoTecnologicoMantenimiento : Form
    {
        #region Variables()
        private ComboBoxHelper comboHelper;
        private List<Grupo> documentos, series, tipoSolicitudes;
        private SAS_SolicitudDeEquipamientoTecnologico solicitud;
        private List<SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo> sedesEnSolicitud;
        private List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware> HardwareEnSolicitud;
        private List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware> SoftwareEnSolicitud;
        private List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult> listadoHardwareEnBlanco;
        private List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedesResult> listadoSedesEnBlanco;
        private List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult> listadoSoftwareEnBlanco;
        private List<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult> listadoHardwareById;
        private SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult solicitydById;
        private List<SAS_SolicitudDeEquipamientoTecnologicoSedesByIdResult> listadoSedesById;
        private List<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult> listadoSoftwareById;
        private SAS_SolicitudDeEquipamientoTecnologicoController modelo;
        private string _conection;
        private SAS_USUARIOS _user2;
        private string _companyId;
        private PrivilegesByUser privilege;
        private List<SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo> sedesEnSolicitudRegistro;

        public List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware> HardwareEnSolicitudRegistro { get; private set; }
        public List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware> SoftwareEnSolicitudRegistro { get; private set; }
        public List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware> HardwareEnSolicitudRegistroEliminar { get; private set; }
        public List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware> SoftwareEnSolicitudRegistroEliminar { get; private set; }
        #endregion

        public SolicitudDeEquipamientoTecnologicoMantenimiento()
        {
            InitializeComponent();
            Inicio();
            CargarCombos();

        }

        public SolicitudDeEquipamientoTecnologicoMantenimiento(string _conection, SAS_USUARIOS _user2, string _companyId, PrivilegesByUser privilege, SAS_SolicitudDeEquipamientoTecnologico solicitud)
        {
            InitializeComponent();
            Inicio();
            CargarCombos();
            this._conection = _conection;
            this._user2 = _user2;
            this._companyId = _companyId;
            this.privilege = privilege;
            this.solicitud = solicitud;
            CargarObjeto();
        }

        private void CargarCombos()
        {
            try
            {
                comboHelper = new ComboBoxHelper();
                documentos = new List<Grupo>();
                series = new List<Grupo>();
                tipoSolicitudes = new List<Grupo>();




                documentos = comboHelper.GetDocumentTypeForForm("SAS", "Equipamiento tecnologico");
                cboDocumento.DisplayMember = "Descripcion";
                cboDocumento.ValueMember = "Codigo";
                cboDocumento.DataSource = documentos.ToList();

                series = comboHelper.GetDocumentSeriesForForm("SAS", "Equipamiento tecnologico");
                cboSerie.DisplayMember = "Descripcion";
                cboSerie.ValueMember = "Codigo";
                cboSerie.DataSource = series.ToList();

                tipoSolicitudes = comboHelper.GetRequestTypes("SAS", "Equipamiento tecnologico");
                cboTipoSolicitud.DisplayMember = "Descripcion";
                cboTipoSolicitud.ValueMember = "Codigo";
                cboTipoSolicitud.DataSource = tipoSolicitudes.OrderBy(x => x.Descripcion).ToList();
                cboTipoSolicitud.SelectedValue = "1";



            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Mensajes del sistema");
                return;
            }
        }

        public void Inicio()
        {
            try
            {
                Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                Globales.BaseDatos = ConfigurationManager.AppSettings["SAS"].ToString();
                Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                Globales.IdEmpresa = "001";
                Globales.Empresa = "SOCIEDAD AGRICOLA SATURNO";
                Globales.UsuarioSistema = "EAURAZO";
                Globales.NombreUsuarioSistema = "ERICK AURAZO";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void SolicitudDeEquipamientoTecnologicoMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkTemporal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTemporal.Checked == true)
            {
                txtVencimiento.Enabled = true;
            }
            else
            {
                txtVencimiento.Enabled = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        public static void Limpiar(Control control, GroupBox gb)
        {
            // Checar todos los textbox del formulario
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedIndex = 0;
                }
            }
            foreach (var combo in gb.Controls)
            {
                if (combo is TextBox)
                {
                    ((TextBox)combo).Clear();
                }
                if (combo is ComboBox)
                {
                    ((ComboBox)combo).SelectedIndex = 0;
                }
                if (combo is RadTextBox)
                {
                    ((RadTextBox)combo).Clear();
                }
                if (combo is MyTextBox)
                {
                    ((MyTextBox)combo).Clear();
                }
                if (combo is MyTextBoxSearchSimple)
                {
                    ((MyTextBoxSearchSimple)combo).Clear();
                }
                if (combo is MyTextSearch)
                {
                    ((MyTextSearch)combo).Clear();
                }
                if (combo is MyMaskedDate)
                {
                    ((MyMaskedDate)combo).Clear();
                }
                if (combo is MyMaskedDateTime)
                {
                    ((MyMaskedDateTime)combo).Clear();
                }
            }
        }

        private void Nuevo()
        {
            #region Nuevo
            btnNuevo.Enabled = false;
            BarraPrincipal.Enabled = false;
            progressBar1.Visible = true;
            gbDatosPersonal.Enabled = false;
            gbDetale.Enabled = false;
            gbDocumento.Enabled = false;
            gbJustificacion.Enabled = false;
            gbUbicacion.Enabled = false;

            //1.- Limpiar objetos y listar

            solicitud = new SAS_SolicitudDeEquipamientoTecnologico();
            solicitud.id = 0;
            sedesEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo>();
            HardwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware>();
            SoftwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware>();
            listadoHardwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult>();
            listadoSedesEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedesResult>();
            listadoSoftwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult>();
            listadoHardwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult>();
            solicitydById = new SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult();
            listadoSedesById = new List<SAS_SolicitudDeEquipamientoTecnologicoSedesByIdResult>();
            listadoSoftwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult>();

            //2.- Limpiar formulario
            Limpiar(this, gbDatosPersonal);
            Limpiar(this, gbDetale);
            Limpiar(this, gbDocumento);
            Limpiar(this, gbJustificacion);
            Limpiar(this, gbUbicacion);

            //3.- Cargar objeto y listas en blanco

            //4.- Presentar objetos y listas en los formularios
            bgwHilo.RunWorkerAsync();
            #endregion
        }

        private void CargarObjeto()
        {
            #region Nuevo
            btnNuevo.Enabled = false;
            BarraPrincipal.Enabled = false;
            progressBar1.Visible = true;
            gbDatosPersonal.Enabled = false;
            gbDetale.Enabled = false;
            gbDocumento.Enabled = false;
            gbJustificacion.Enabled = false;
            gbUbicacion.Enabled = false;

            //1.- Limpiar objetos y listar

            //solicitud = new SAS_SolicitudDeEquipamientoTecnologico();
            //solicitud.id = 0;
            sedesEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo>();
            HardwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware>();
            SoftwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware>();
            listadoHardwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult>();
            listadoSedesEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedesResult>();
            listadoSoftwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult>();
            listadoHardwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult>();
            solicitydById = new SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult();
            listadoSedesById = new List<SAS_SolicitudDeEquipamientoTecnologicoSedesByIdResult>();
            listadoSoftwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult>();

            //2.- Limpiar formulario
            Limpiar(this, gbDatosPersonal);
            Limpiar(this, gbDetale);
            Limpiar(this, gbDocumento);
            Limpiar(this, gbJustificacion);
            Limpiar(this, gbUbicacion);

            //3.- Cargar objeto y listas en blanco

            //4.- Presentar objetos y listas en los formularios
            bgwHilo.RunWorkerAsync();
            #endregion
        }

        private void ActualizarSoftware()
        {
            #region Nuevo
            btnNuevo.Enabled = false;
            btnSoftwareActualizarListado.Enabled = !true;
            btnHardwareActualizarLista.Enabled = !true;
            BarraPrincipal.Enabled = false;
            progressBar1.Visible = true;
            gbDatosPersonal.Enabled = false;
            gbDetale.Enabled = false;
            gbDocumento.Enabled = false;
            gbJustificacion.Enabled = false;
            gbUbicacion.Enabled = false;

            //1.- Limpiar objetos y listar

            //solicitud = new SAS_SolicitudDeEquipamientoTecnologico();
            //solicitud.id = 0;
            //sedesEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo>();
            //HardwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware>();
            //SoftwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware>();
            //listadoHardwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult>();
            //listadoSedesEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedesResult>();
            listadoSoftwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult>();
            //listadoHardwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult>();
            //solicitydById = new SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult();
            //listadoSedesById = new List<SAS_SolicitudDeEquipamientoTecnologicoSedesByIdResult>();
            //listadoSoftwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult>();

            //2.- Limpiar formulario
            //Limpiar(this, gbDatosPersonal);
            //Limpiar(this, gbDetale);
            //Limpiar(this, gbDocumento);
            //Limpiar(this, gbJustificacion);
            //Limpiar(this, gbUbicacion);

            //3.- Cargar objeto y listas en blanco

            //4.- Presentar objetos y listas en los formularios
            bgwSoftware.RunWorkerAsync();
            #endregion
        }

        private void ActualizarHardware()
        {
            #region Nuevo
            btnNuevo.Enabled = false;
            btnSoftwareActualizarListado.Enabled = !true;
            btnHardwareActualizarLista.Enabled = !true;
            BarraPrincipal.Enabled = false;
            progressBar1.Visible = true;
            gbDatosPersonal.Enabled = false;
            gbDetale.Enabled = false;
            gbDocumento.Enabled = false;
            gbJustificacion.Enabled = false;
            gbUbicacion.Enabled = false;

            //1.- Limpiar objetos y listar

            //solicitud = new SAS_SolicitudDeEquipamientoTecnologico();
            //solicitud.id = 0;
            //sedesEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo>();
            //HardwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware>();
            //SoftwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware>();
            listadoHardwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult>();
            //listadoSedesEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedesResult>();
            //listadoSoftwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult>();
            //listadoHardwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult>();
            //solicitydById = new SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult();
            //listadoSedesById = new List<SAS_SolicitudDeEquipamientoTecnologicoSedesByIdResult>();
            //listadoSoftwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult>();

            //2.- Limpiar formulario
            //Limpiar(this, gbDatosPersonal);
            //Limpiar(this, gbDetale);
            //Limpiar(this, gbDocumento);
            //Limpiar(this, gbJustificacion);
            //Limpiar(this, gbUbicacion);

            //3.- Cargar objeto y listas en blanco

            //4.- Presentar objetos y listas en los formularios
            bgwHardware.RunWorkerAsync();
            #endregion
        }

        private void txtPersonalCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                btnInicioContrato.P_TablaConsulta = "personal_empresa where idcodigogeneral = '" + this.txtPersonalCodigo.Text.Trim() + " '";
            }
            catch (Exception Ex)
            {

                throw Ex;
                return;
            }

            //personal_empresa where idcodigogeneral = ''
        }

        private void txtPersonal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btnInicioContrato.P_TablaConsulta = "personal_empresa where idcodigogeneral = '" + this.txtPersonalCodigo.Text.Trim() + " '";
            }
            catch (Exception Ex)
            {

                throw Ex;
                return;
            }
        }

        private void txtPersonalCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                btnInicioContrato.P_TablaConsulta = "personal_empresa where idcodigogeneral = '" + this.txtPersonalCodigo.Text.Trim() + " '";
            }
            catch (Exception Ex)
            {

                throw Ex;
                return;
            }
        }

        private void txtPersonal_Leave(object sender, EventArgs e)
        {
            try
            {
                btnInicioContrato.P_TablaConsulta = "personal_empresa where idcodigogeneral = '" + this.txtPersonalCodigo.Text.Trim() + " '";
            }
            catch (Exception Ex)
            {

                throw Ex;
                return;
            }
        }

        private void txtPersonal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                btnInicioContrato.P_TablaConsulta = "personal_empresa where idcodigogeneral = '" + this.txtPersonalCodigo.Text.Trim() + " '";
            }
            catch (Exception Ex)
            {

                throw Ex;
                return;
            }
        }

        private void btnActualizarListado_Click(object sender, EventArgs e)
        {
            ActualizarSoftware();
        }

        private void bgwSoftware_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listadoSoftwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult>();
                listadoSoftwareEnBlanco = modelo.GetSoftwareDetailBlanklistingForRequest("SAS", solicitud);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwSoftware_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dgvSoftware.CargarDatos(listadoSoftwareEnBlanco.ToDataTable<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult>());
                dgvSoftware.Refresh();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

            btnNuevo.Enabled = !false;
            BarraPrincipal.Enabled = !false;
            progressBar1.Visible = !true;
            gbDatosPersonal.Enabled = !false;
            gbDetale.Enabled = !false;
            gbDocumento.Enabled = !false;
            gbJustificacion.Enabled = !false;
            gbUbicacion.Enabled = !false;
            btnSoftwareActualizarListado.Enabled = true;
            btnHardwareActualizarLista.Enabled = true;
        }

        private void tabSoftware_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bgwHardware_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listadoHardwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult>();
                listadoHardwareEnBlanco = modelo.GetHardwareDetailBlanklistingForRequest("SAS", solicitud);
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

        }

        private void bgwHardware_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                #region 
                dgvHardware.CargarDatos(listadoHardwareEnBlanco.ToDataTable<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult>());
                dgvHardware.Refresh();

                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

            btnNuevo.Enabled = !false;
            BarraPrincipal.Enabled = !false;
            progressBar1.Visible = !true;
            gbDatosPersonal.Enabled = !false;
            gbDetale.Enabled = !false;
            gbDocumento.Enabled = !false;
            gbJustificacion.Enabled = !false;
            gbUbicacion.Enabled = !false;
            btnSoftwareActualizarListado.Enabled = true;
            btnHardwareActualizarLista.Enabled = true;

        }

        private void btnActualizarListadoHardware_Click(object sender, EventArgs e)
        {
            ActualizarHardware();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.txtIdEstado.Text == "PE")
            {
                #region Grabar()

                Registrar();
                #endregion
            }
            else
            {
                MessageBox.Show("El documento no tiene el estado para grabar", "Advertencia del sistema");
                return;
            }
        }

        private void Registrar()
        {
            try
            {
                /*1.- Instanciar objetos y listas de cero */
                solicitud = new SAS_SolicitudDeEquipamientoTecnologico();
                solicitud.id = 0;
                sedesEnSolicitudRegistro = new List<SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo>();
                HardwareEnSolicitudRegistro = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware>();
                SoftwareEnSolicitudRegistro = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware>();

                HardwareEnSolicitudRegistroEliminar = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware>();
                SoftwareEnSolicitudRegistroEliminar = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware>();


                /*2.- Asignar objetos y listas desde controles */
                solicitud.id = this.txtCodigo.Text != string.Empty ? Convert.ToInt32(this.txtCodigo.Text) : 0;
                solicitud.fecha = Convert.ToDateTime(this.txtFecha.Text);
                solicitud.idCodigoGeneral = this.txtPersonalCodigo.Text.Trim();
                solicitud.nombresCompletos = this.txtPersonal.Text.Trim();
                solicitud.esExterno = (chkEsExterno.Checked == true ? 1 : 0);

                solicitud.fechaDeVencimiento = Convert.ToDateTime(this.txtVencimiento.Text);
                solicitud.esTemporal = (chkTemporal.Checked == true ? 1 : 0);
                solicitud.justificacion = this.txtJustificacion.Text.Trim();
                solicitud.estadoCodigo = txtIdEstado.Text.Trim();
                solicitud.usuarioEnAtencion = this._user2.IdUsuario.Trim();
                solicitud.tipoSolicitud = this.cboTipoSolicitud.SelectedValue != null ? Convert.ToInt32(this.cboTipoSolicitud.SelectedValue) : 0;
                solicitud.vencimientoContrato = Convert.ToDateTime(this.txtVencimientoContrato.Text.Trim());
                solicitud.itemInicioContrato = txtInicioContratoCodigo.Text.Trim(); ;
                solicitud.tipoContrato = (rbtPermanente.Checked == true ? 1 : 0);


                /*3.- Registrar Objetos y lista detalles */
                for (int i = 1; i <= 5; i++)
                {
                    SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo sedeEnSolicitudRegistro = new SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo();
                    //sedeEnSolicitudRegistro.
                }


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void dgvSoftware_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.dgvSoftware.CurrentRow.Cells["chElegidoSoftware"].Value.ToString() == "1")
            {
                modelo = new SAS_SolicitudDeEquipamientoTecnologicoController();
                if (((DataGridView)sender).RowCount > 0)
                {
                    #region Tipo de Perfil de accesso de Software() 
                    if (((DataGridView)sender).CurrentCell.OwningColumn.Name == "chPerfilAcceso")
                    {
                        if (e.KeyCode == Keys.F3)
                        {
                            frmBusquedaFormatoSimple search = new frmBusquedaFormatoSimple();
                            search.ListaGeneralResultado = modelo.GetListOfProfiles("SAS");
                            search.Text = "Buscar tipo de perfil de Acceso";
                            search.txtTextoFiltro.Text = "";
                            if (search.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                //idRetorno = busquedas.ObjetoRetorno.Codigo;
                                this.dgvSoftware.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chPerfilDeAcceso"].Value = search.ObjetoRetorno.Codigo;
                                this.dgvSoftware.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chPerfilAcceso"].Value = search.ObjetoRetorno.Descripcion;
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        private void dgvSoftware_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dgvSoftware_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)//set your checkbox column index instead of 2
            {   //When you check
                if (Convert.ToBoolean(dgvSoftware.Rows[e.RowIndex].Cells["chElegidoSoftware"].EditedFormattedValue) == true)
                {
                    //EXAMPLE OF OTHER CODE
                    // dgvSoftware.Rows[e.RowIndex].Cells[5].Value = DateTime.Now.ToShortDateString();

                    //SET BY CODE THE CHECK BOX
                    // dgvSoftware.Rows[e.RowIndex].Cells[2].Value = 1;
                }
                else //When you decheck
                {
                    if (this.dgvSoftware.CurrentRow.Cells["chPerfilAcceso"].Value.ToString() != string.Empty)
                    {
                        this.dgvSoftware.CurrentRow.Cells["chPerfilDeAcceso"].Value = string.Empty;
                        this.dgvSoftware.CurrentRow.Cells["chPerfilAcceso"].Value = string.Empty;
                    }
                }
            }

        }

        private void dgvSoftware_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvSoftware_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSoftware_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgvSoftware_Leave(object sender, EventArgs e)
        {
            //if (this.dgvSoftware.CurrentRow.Cells["chElegidoSoftware"].Value.ToString() == "0" || this.dgvSoftware.CurrentRow.Cells["chElegidoSoftware"].Value.ToString() == string.Empty)
            //{
            //    if (this.dgvSoftware.CurrentRow.Cells["chPerfilAcceso"].Value.ToString() != string.Empty)
            //    {
            //        this.dgvSoftware.CurrentRow.Cells["chPerfilDeAcceso"].Value = string.Empty;
            //        this.dgvSoftware.CurrentRow.Cells["chPerfilAcceso"].Value = string.Empty;
            //    }
            //}
        }

        private void dgvSoftware_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                #region 
                //solicitud = new SAS_SolicitudDeEquipamientoTecnologico();
                sedesEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoSedeDeTrabajo>();
                HardwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeHardware>();
                SoftwareEnSolicitud = new List<SAS_SolicitudDeEquipamientoTecnologicoTipoDeSoftware>();

                modelo = new SAS_SolicitudDeEquipamientoTecnologicoController();
                solicitydById = new SAS_SolicitudDeEquipamientoTecnologicoListadoByIdResult();
                solicitydById = modelo.ListRequestsById("SAS", solicitud);

                if (solicitud != null)
                {
                    if (solicitud.id == 0)
                    {
                        listadoHardwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult>();
                        listadoHardwareEnBlanco = modelo.GetHardwareDetailBlanklistingForRequest("SAS", solicitud);

                        listadoSedesEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSedesResult>();
                        listadoSedesEnBlanco = modelo.ObtainABlankListOfTheDetailsOfTheVenues("SAS", solicitud);

                        listadoSoftwareEnBlanco = new List<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult>();
                        listadoSoftwareEnBlanco = modelo.GetSoftwareDetailBlanklistingForRequest("SAS", solicitud);
                    }
                    else
                    {
                        listadoHardwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult>();
                        listadoHardwareById = modelo.GetListOfHardwareDetailByRequestId("SAS", solicitud);

                        listadoSedesById = new List<SAS_SolicitudDeEquipamientoTecnologicoSedesByIdResult>();
                        listadoSedesById = modelo.GetDetailedListOfVenuesByRequestId("SAS", solicitud);

                        listadoSoftwareById = new List<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult>();
                        listadoSoftwareById = modelo.GetListOfSoftwareDetailByRequestId("SAS", solicitud);

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

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                #region 
                if (solicitud != null)
                {

                    this.txtCodigo.Text = solicitydById.id != null ? solicitydById.id.ToString().Trim() : "0";
                    this.txtEmpresaCodigo.Text = "001";
                    this.txtEmpresa.Text = "SOCIEDAD AGRICOLA SATURNO SA";
                    this.txtSucursalCodigo.Text = "001";
                    this.txtSucursal.Text = "SEDE LOGISTICA AGRICOLA";
                    this.txtIdEstado.Text = solicitydById.estadoCodigo != null ? solicitydById.estadoCodigo.Trim() : "PE";
                    this.txtEstado.Text = solicitydById.estado != null ? solicitydById.estado.Trim() : "PENDIENTE";
                    this.txtCorrelativo.Text = solicitydById.id.ToString().PadLeft(8, '0');
                    this.txtFecha.Text = solicitydById.fecha.ToPresentationDate();
                    this.cboTipoSolicitud.SelectedValue = solicitydById.idTipoSolicitud.ToString();
                    this.txtPersonalCodigo.Text = solicitydById.idCodigoGeneral != null ? solicitydById.idCodigoGeneral.Trim() : string.Empty;
                    this.txtPersonal.Text = solicitydById.nombresCompletos != null ? solicitydById.nombresCompletos.Trim() : string.Empty;
                    this.txtInicioContratoCodigo.Text = solicitydById.itemInicioContrato != null ? solicitydById.itemInicioContrato.Trim() : string.Empty;
                    this.txtInicioContrato.Text = solicitydById.itemInicioContrato != null ? solicitydById.itemInicioContrato.Trim() : string.Empty;
                    this.txtVencimiento.Text = solicitydById.fechaDeVencimiento.ToPresentationDate();
                    this.txtVencimiento.Enabled = true;

                    chkTemporal.Checked = false;
                    if (solicitydById.esTemporal == 1)
                    {
                        chkTemporal.Checked = true;
                    }

                    if (solicitydById.tipoContrato == 0)
                    {
                        rbtPermanente.Checked = false;
                        rbtTemporal.Checked = false;
                    }
                    else if (solicitydById.tipoContrato == 1)
                    {
                        rbtPermanente.Checked = true;
                        rbtTemporal.Checked = false;
                    }
                    else if (solicitydById.tipoContrato == 2)
                    {
                        rbtPermanente.Checked = false;
                        rbtTemporal.Checked = true;
                    }

                    this.txtVencimientoContrato.Text = solicitydById.vencimientoContrato.ToPresentationDate();
                    this.txtJustificacion.Text = solicitydById.justificacion != null ? solicitydById.justificacion.Trim() : "PE";

                    if (solicitud.id == 0)
                    {
                        #region Nuevo() 
                        dgvHardware.CargarDatos(listadoHardwareEnBlanco.ToDataTable<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoHardwareResult>());
                        dgvHardware.Refresh();

                        dgvSoftware.CargarDatos(listadoSoftwareEnBlanco.ToDataTable<SAS_SolicitudDeEquipamientoTecnologicoEnBlancoSoftwareResult>());
                        dgvSoftware.Refresh();

                        chkColca01.Checked = false;
                        chkPacking.Checked = false;
                        chkColca03.Checked = false;
                        chkOficinasLima.Checked = false;
                        chkOficinasLima.Checked = false;
                        chkCasona.Checked = false;

                        if (listadoSedesEnBlanco != null)
                        {
                            if (listadoSedesEnBlanco.ToList().Count > 0)
                            {
                                foreach (var item in listadoSedesEnBlanco)
                                {
                                    if (item.sede.Trim().ToUpper() == "Colca 01".ToUpper() && item.estado == 1)
                                    {
                                        chkColca01.Checked = true;
                                    }
                                    if (item.sede.Trim().ToUpper() == "Packing".ToUpper() && item.estado == 1)
                                    {
                                        chkPacking.Checked = true;
                                    }
                                    if (item.sede.Trim().ToUpper() == "Colca 03".ToUpper() && item.estado == 1)
                                    {
                                        chkColca03.Checked = true;
                                    }
                                    if (item.sede.Trim().ToUpper() == "Sede Lima".ToUpper() && item.estado == 1)
                                    {
                                        chkOficinasLima.Checked = true;
                                    }
                                    if (item.sede.Trim().ToUpper() == "Casona".ToUpper() && item.estado == 1)
                                    {
                                        chkCasona.Checked = true;
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region Lectura de registro Existente() 
                        chkColca01.Checked = false;
                        chkPacking.Checked = false;
                        chkColca03.Checked = false;
                        chkOficinasLima.Checked = false;
                        chkOficinasLima.Checked = false;
                        chkCasona.Checked = false;

                        if (listadoSedesById != null)
                        {
                            if (listadoSedesById.ToList().Count > 0)
                            {
                                foreach (var item in listadoSedesById)
                                {
                                    if (item.sede.Trim().ToUpper() == "Colca 01".ToUpper() && item.estado == 1)
                                    {
                                        chkColca01.Checked = true;
                                    }
                                    if (item.sede.Trim().ToUpper() == "Packing".ToUpper() && item.estado == 1)
                                    {
                                        chkPacking.Checked = true;
                                    }
                                    if (item.sede.Trim().ToUpper() == "Colca 03".ToUpper() && item.estado == 1)
                                    {
                                        chkColca03.Checked = true;
                                    }
                                    if (item.sede.Trim().ToUpper() == "Sede Lima".ToUpper() && item.estado == 1)
                                    {
                                        chkOficinasLima.Checked = true;
                                    }
                                    if (item.sede.Trim().ToUpper() == "Casona".ToUpper() && item.estado == 1)
                                    {
                                        chkCasona.Checked = true;
                                    }
                                }
                            }
                        }

                        dgvHardware.CargarDatos(listadoHardwareById.ToDataTable<SAS_SolicitudDeEquipamientoTecnologicoHardwareByIdResult>());
                        dgvHardware.Refresh();

                        dgvSoftware.CargarDatos(listadoSoftwareById.ToDataTable<SAS_SolicitudDeEquipamientoTecnologicoSoftwareByIdResult>());
                        dgvSoftware.Refresh();
                        #endregion
                    }
                }

                #endregion

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }

            btnNuevo.Enabled = !false;
            BarraPrincipal.Enabled = !false;
            progressBar1.Visible = !true;
            gbDatosPersonal.Enabled = !false;
            gbDetale.Enabled = !false;
            gbDocumento.Enabled = !false;
            gbJustificacion.Enabled = !false;
            gbUbicacion.Enabled = !false;



        }
    }
}
