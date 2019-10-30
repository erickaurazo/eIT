using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Configuration;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using System.Globalization;
using Transportista.Negocios;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class RegistroAsistenciaPersonalAdministrativoMantenimiento : Form
    {
        AsistenciaPersonalAdministrativoDatos AsistenciaModelo = new AsistenciaPersonalAdministrativoDatos();
        private string idPersonalMarcacion;
        private PersonalAdministrativo personalAdministrativo;
        private PersonalAdministrativo personalAdministrativoRegistro;
        private List<PersonalAdministrativo> personalRegistradoParaMarcarAsistencia;
        private string sql;
        private AsistenciaTrabajadoresAdministrativoNegocio Modelo;

        public RegistroAsistenciaPersonalAdministrativoMantenimiento()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public RegistroAsistenciaPersonalAdministrativoMantenimiento(PersonalAdministrativo personalAdministrativo, List<PersonalAdministrativo> personalRegistradoParaMarcarAsistencia)
        {
            // TODO: Complete member initialization
            InitializeComponent();

            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            this.personalAdministrativo = personalAdministrativo;
            this.personalRegistradoParaMarcarAsistencia = personalRegistradoParaMarcarAsistencia;
            AsignarObjetoaControles(this.personalAdministrativo);

            if (personalAdministrativo.codigoPersonal != null && personalAdministrativo.codigoPersonal.ToString().Trim() != "")
            {
                this.txtDiaSemana.ReadOnly = true;
                txtNroDni.ReadOnly = true;
                this.txtTrabajador.ReadOnly = true;
                this.txtFechaDesde.ReadOnly = false;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnAnular.Enabled = true;
                btnNuevo.Enabled = true;
                btnSalir.Enabled = true;
                gbMantenimiento.Enabled = false;
                this.txtEstado.Text = "ACTIVO";
            }
            else
            {
                this.txtDiaSemana.ReadOnly = true;
                txtNroDni.ReadOnly = true;
                this.txtTrabajador.ReadOnly = true;
                this.txtFechaDesde.ReadOnly = false;
                btnEditar.Enabled = false;
                btnGuardar.Enabled = true;
                btnAnular.Enabled = false;
                btnNuevo.Enabled = false;
                btnSalir.Enabled = true;
                gbMantenimiento.Enabled = true;
                this.txtEstado.Text = "ACTIVO";
            }

        }

        private void AsignarObjetoaControles(PersonalAdministrativo personalAdministrativo)
        {
            this.txtNroDni.Text = personalAdministrativo.nroDocumento;
            idPersonalMarcacion = personalAdministrativo.codigoPersonal;
            this.txtTrabajador.Text = personalAdministrativo.personal;
            this.txtFechaDesde.Text = personalAdministrativo.fecha.Value.ToString();
            this.txtDiaSemana.Text = personalAdministrativo.fecha.Value.ToString("dddd", new CultureInfo("es-ES"));
        }

        private void AsignarControlesAObjeto()
        {
            try
            {
                personalAdministrativoRegistro = new PersonalAdministrativo();
                personalAdministrativoRegistro.codigoPersonal = idPersonalMarcacion;
                personalAdministrativoRegistro.fecha = Convert.ToDateTime(this.txtFechaDesde.Text);
            }
            catch (Exception Ex)
            {

                throw Ex;
            }



        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
            btnAnular.Enabled = false;
            btnNuevo.Enabled = false;
            btnSalir.Enabled = true;
            gbMantenimiento.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;
            btnAnular.Enabled = false;
            btnNuevo.Enabled = false;
            btnSalir.Enabled = true;
            gbMantenimiento.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Registrar()
                if (idPersonalMarcacion != null && idPersonalMarcacion.ToString().Trim() != "")
                {
                    AsignarControlesAObjeto();

                    List<PersonalAdministrativo> listadoMarcacionAsistencia = new List<PersonalAdministrativo>();
                    Modelo = new AsistenciaTrabajadoresAdministrativoNegocio();
                    listadoMarcacionAsistencia = Modelo.ObtenerAsistenciasPersonalxDiaxCodigo(personalAdministrativo.fecha.Value.ToShortDateString(), personalAdministrativo.fecha.Value.ToShortDateString(), idPersonalMarcacion, personalRegistradoParaMarcarAsistencia).ToList();

                    if (listadoMarcacionAsistencia != null && listadoMarcacionAsistencia.ToList().Count > 0)
                    {
                        #region Actualizar()
                        int acb = listadoMarcacionAsistencia.Where(x => x.fecha.Value == personalAdministrativo.fecha.Value).ToList().Count;
                        if (listadoMarcacionAsistencia.Where(x => x.fecha.Value == personalAdministrativo.fecha.Value).ToList().Count == 1)
                        {
                            #region Actualizar()
                            sql = "UPDATE CHECKINOUT";
                            sql += " SET CHECKTIME = #" + String.Format("{0:MM/dd/yyyy hh:mm:ss}", personalAdministrativoRegistro.fecha.Value) + "#";
                            sql += " WHERE USERID  = " + Convert.ToInt32(personalAdministrativo.codigoPersonal.Trim());
                            sql += " AND CHECKTIME = #" + String.Format("{0:MM/dd/yyyy HH:mm:ss}", personalAdministrativo.fecha.Value) + "#";
                            int insert = AsistenciaModelo.EjecutarConsultaSQL(sql);
                            if (insert == 1) //Si se logro la insercion limpio el formulario             
                            {
                                MessageBox.Show("Se registro correctamente sus datos");
                                gbMantenimiento.Enabled = false;
                            }
                            #endregion
                        }
                        else
                        {
                            #region Registrar()
                            sql = "INSERT INTO CHECKINOUT (USERID,CHECKTIME,CHECKTYPE,VERIFYCODE,SENSORID,Memoinfo,WorkCode,sn,UserExtFmt)";
                            sql += "VALUES(" + Convert.ToInt32(idPersonalMarcacion);
                            sql += ",  #" + String.Format("{0:MM/dd/yyyy hh:mm:ss}", personalAdministrativoRegistro.fecha.Value) + "#";
                            sql += ", #I#,1,102,#terminal# ,0,6095143600474,1";

                            int insert = AsistenciaModelo.EjecutarConsultaSQL(sql);
                            if (insert == 1) //Si se logro la insercion limpio el formulario             
                            {
                                MessageBox.Show("Se insertaron correctamente sus datos");
                                gbMantenimiento.Enabled = false;
                                personalAdministrativo = personalAdministrativoRegistro;

                            }
                            else MessageBox.Show("Hubo un error al insertar los datos");
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        #region Registrar()
                        sql = "INSERT INTO CHECKINOUT (USERID,CHECKTIME,CHECKTYPE,VERIFYCODE,SENSORID,Memoinfo,WorkCode,sn,UserExtFmt)";
                        sql += "VALUES(" + Convert.ToInt32(idPersonalMarcacion);
                        sql += ",  #" + String.Format("{0:MM/dd/yyyy hh:mm:ss}", personalAdministrativoRegistro.fecha.Value) + "#";
                        sql += ", #I#,1,102,#terminal# ,0,6095143600474,1";

                        int insert = AsistenciaModelo.EjecutarConsultaSQL(sql);
                        if (insert == 1) //Si se logro la insercion limpio el formulario             
                        {
                            MessageBox.Show("Se insertaron correctamente sus datos");
                            gbMantenimiento.Enabled = false;
                            personalAdministrativo = personalAdministrativoRegistro;

                        }
                        else MessageBox.Show("Hubo un error al insertar los datos");
                        #endregion
                    }

                    btnEditar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnAnular.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnSalir.Enabled = true;
                }
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }



        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            #region Anular()
            int filasAfectadadas = 0;
            AsistenciaModelo = new AsistenciaPersonalAdministrativoDatos();

            filasAfectadadas = AsistenciaModelo.Anular(personalAdministrativo);
            if (filasAfectadadas == 1) //Si se logro la insercion limpio el formulario             
            {
                MessageBox.Show("Se Anulo correctamente sus datos");
                this.txtEstado.Text = "ANULADO";
                this.gbMantenimiento.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.btnAnular.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnSalir.Enabled = true;
                this.personalAdministrativo = personalAdministrativoRegistro;
            }
            else
            {
                MessageBox.Show("Hubo un error al anular los datos");
            }
            #endregion

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarTrabajador_Click(object sender, EventArgs e)
        {
            BuscarPersonalMarcaAsistencia ofrm = new BuscarPersonalMarcaAsistencia(this.personalRegistradoParaMarcarAsistencia);
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                #region
                if (ofrm.ObjetoBusqueda != null)
                {
                    #region
                    this.txtNroDni.Text = ofrm.ObjetoBusqueda.nroDocumento;
                    idPersonalMarcacion = ofrm.ObjetoBusqueda.codigoPersonal;
                    this.txtTrabajador.Text = ofrm.ObjetoBusqueda.personal;
                    #endregion
                }
                else
                {
                    this.txtNroDni.Text = "";
                    idPersonalMarcacion = "";
                    this.txtTrabajador.Text = "";

                }
                #endregion
            }
        }

        private void RegistroAsistenciaPersonalAdministrativoMantenimiento_Load(object sender, EventArgs e)
        {

        }

        private void txtFechaDesde_Leave(object sender, EventArgs e)
        {
            this.txtDiaSemana.Text = personalAdministrativo.fecha.Value.ToString("dddd", new CultureInfo("es-ES"));
        }
    }
}
