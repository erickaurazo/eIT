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
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class RegistroAsistenciaPersonalAdministrativo : Form
    {
        AsistenciaPersonalAdministrativoDatos DB = new AsistenciaPersonalAdministrativoDatos();
        String sql;
        private MarcacionesPersonal marcacionPersonal;
        private int NumeroRegistros;
        private List<PersonalAdministrativo> listadoMarcacionAsistencia;
        private List<PersonalAdministrativo> personalRegistradoParaMarcarAsistencia;
        private PersonalAdministrativo personalAdministrativo;
        private string desde;
        private string hasta;
        private string periodo;
        private string idPersonalMarcacion = string.Empty;
        private AsistenciaTrabajadoresAdministrativoNegocio Modelo;
        private AsistenciaPersonalAdministrativoDatos AsistenciaModelo;

        public RegistroAsistenciaPersonalAdministrativo()
        {
            InitializeComponent();

            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();

            ListarPersonalRegistradoParaMarcarAsistencia();
            CargarMeses();
            this.txtFechaDesde.Text = DateTime.Now.ToString();
            this.txtFechaHasta.Text = DateTime.Now.ToString();
            Inicio();
        }

        public void Inicio()
        {
            try
            {
                periodo = DateTime.Now.Year.ToString();
                MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
                MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
                MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + periodo].ToString();
                MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
                MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
                MyControlsDataBinding.Extensions.Globales.Empresa = "EMPRESA AGRICOLA SAN JOSE SA";
                MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "EAURAZOC";
                MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "ERICK AURAZO";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DB.IniciarConexion("Z:\\att.mdb");
            //Creo el miembro de datos del DataGridView             
            dgvAsistenciaPersonalAdm.DataMember = "CHECKINOUT";
        }

        private void CargarMeses()
        {
            Mes Meses = new Mes();
            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = Meses.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = Meses.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("13");
        }

        private void ObtenerFechasIniciales()
        {
            this.txtPeriodo.Text = DateTime.Now.Year.ToString();
            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();
        }

        private void ObtenerFechasMes()
        {
            DateTime fecha1;
            DateTime fecha2;

            if (cboMes.SelectedValue.ToString() != "00")
            {
                #region
                this.txtFechaDesde.Enabled = false;
                this.txtFechaHasta.Enabled = false;
                if (cboMes.SelectedValue.ToString() == "12")
                {
                    #region Si es mes diciembre
                    fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString() + "/" + this.txtPeriodo.Text.ToString()));// 
                    fecha2 = Convert.ToDateTime("31/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Text.ToString());// 
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();
                    #endregion
                }
                else
                {
                    #region Si es mes 13 habilitar controles de fecha, caso contrario es un mes de enero a noviembre.
                    if (cboMes.SelectedValue.ToString() == "13")
                    {
                        this.txtFechaDesde.Enabled = true;
                        this.txtFechaHasta.Enabled = true;
                    }
                    else
                    {
                        fecha2 = Convert.ToDateTime("01/" + (Convert.ToInt32(cboMes.SelectedValue) + 1) + "/" + this.txtPeriodo.Text.ToString()).AddDays(-1);// 
                        fecha1 = Convert.ToDateTime("01/" + (cboMes.SelectedValue.ToString()) + "/" + this.txtPeriodo.Text.ToString());// 
                        this.txtFechaDesde.Text = fecha1.ToShortDateString();
                        this.txtFechaHasta.Text = fecha2.ToShortDateString();
                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                if (cboMes.SelectedValue.ToString() == "00")
                {
                    fecha2 = Convert.ToDateTime("31/12/" + this.txtPeriodo.Text.ToString());// 
                    fecha1 = Convert.ToDateTime("01/01/" + this.txtPeriodo.Text.ToString());//
                    this.txtFechaDesde.Text = fecha1.ToShortDateString();
                    this.txtFechaHasta.Text = fecha2.ToShortDateString();
                }
            }
        }

        private List<PersonalAdministrativo> ListarPersonalRegistradoParaMarcarAsistencia()
        {
            Modelo = new AsistenciaTrabajadoresAdministrativoNegocio();
            personalRegistradoParaMarcarAsistencia = Modelo.ObtenerListaTrabajadoresMarcanAsistencia().OrderBy(x => x.personal).ToList();
            return personalRegistradoParaMarcarAsistencia;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (idPersonalMarcacion != null && idPersonalMarcacion.ToString().Trim() != "")
            {
                #region
                desde = this.txtFechaDesde.Text;
                hasta = this.txtFechaHasta.Text;
                try
                {
                    Modelo = new AsistenciaTrabajadoresAdministrativoNegocio();
                    listadoMarcacionAsistencia = new List<PersonalAdministrativo>();
                    listadoMarcacionAsistencia = Modelo.ObtenerAsistenciasPersonalxDiaxCodigo(desde, hasta, idPersonalMarcacion, personalRegistradoParaMarcarAsistencia).ToList();
                    this.dgvAsistenciaPersonalAdm.DataSource = listadoMarcacionAsistencia.ToDataTable<PersonalAdministrativo>();

                    if (dgvAsistenciaPersonalAdm != null && dgvAsistenciaPersonalAdm.Rows.Count > 0)
                    {
                        ResaltarResultados();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                #endregion
            }
        }

        private void ResaltarResultados()
        {
            foreach (var item in dgvAsistenciaPersonalAdm.Rows)
            {
                if (item.Cells["chEstado"].Value != null && item.Cells["chEstado"].Value.ToString().Trim() == "ANULADO")
                {
                    for (int i = 0; i < dgvAsistenciaPersonalAdm.Columns.Count; i++)
                    {
                        this.dgvAsistenciaPersonalAdm.Rows[item.Index].Cells[i].Style.CustomizeFill = true;
                        this.dgvAsistenciaPersonalAdm.Rows[item.Index].Cells[i].Style.DrawFill = true;
                        this.dgvAsistenciaPersonalAdm.Rows[item.Index].Cells[i].Style.BackColor = Color.Peru;
                    }
                }
            }
        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            ObtenerFechasMes();
        }

        private void cboMes_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            ObtenerFechasMes();
        }

        private void btnBuscarTrabajador_Click(object sender, EventArgs e)
        {

            BuscarPersonalMarcaAsistencia ofrm = new BuscarPersonalMarcaAsistencia(personalRegistradoParaMarcarAsistencia);
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

        private void dgvAsistenciaPersonalAdm_Click(object sender, EventArgs e)
        {

        }

        private void dgvAsistenciaPersonalAdm_SelectionChanged(object sender, EventArgs e)
        {
            editarAsistencia.Enabled = false;
            anularAsistencia.Enabled = false;
            btnEditar.Enabled = false;
            btnAnular.Enabled = false;

            LimpiarObjetoSelecionado();
            if (this.dgvAsistenciaPersonalAdm != null && dgvAsistenciaPersonalAdm.Rows.Count > 0)
            {
                #region
                if (dgvAsistenciaPersonalAdm.CurrentRow != null && dgvAsistenciaPersonalAdm.CurrentRow.Cells["chcodigoMarcacion"].Value != null)
                {
                    try
                    {
                        if (dgvAsistenciaPersonalAdm.CurrentRow.Cells["chcodigoMarcacion"].Value.ToString() != "")
                        {
                            personalAdministrativo = new PersonalAdministrativo();
                            personalAdministrativo.codigoPersonal = (dgvAsistenciaPersonalAdm.CurrentRow.Cells["chcodigoMarcacion"].Value.ToString().Trim());
                            personalAdministrativo.personal = dgvAsistenciaPersonalAdm.CurrentRow.Cells["chNombres"].Value.ToString().Trim();
                            personalAdministrativo.nroDocumento = dgvAsistenciaPersonalAdm.CurrentRow.Cells["chnroDocumento"].Value.ToString().Trim();
                            personalAdministrativo.fecha = Convert.ToDateTime(dgvAsistenciaPersonalAdm.CurrentRow.Cells["chFecha"].Value.ToString().Trim());
                            personalAdministrativo.estado = dgvAsistenciaPersonalAdm.CurrentRow.Cells["chEstado"].Value.ToString().Trim();
                            if (personalAdministrativo.estado.ToString().Trim() == "ANULADO")
                            {
                                editarAsistencia.Enabled = false;
                                anularAsistencia.Enabled = true;
                                btnEditar.Enabled = false;
                                btnAnular.Enabled = true;
                            }

                            if (personalAdministrativo.estado.ToString().Trim() == "ACTIVO")
                            {
                                editarAsistencia.Enabled = true;
                                anularAsistencia.Enabled = true;
                                btnEditar.Enabled = true;
                                btnAnular.Enabled = true;
                            }
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

        private void LimpiarObjetoSelecionado()
        {
            personalAdministrativo = new PersonalAdministrativo();
            personalAdministrativo.codigoPersonal = string.Empty;
            personalAdministrativo.personal = string.Empty;
            personalAdministrativo.nroDocumento = string.Empty;
            personalAdministrativo.fecha = DateTime.Now;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarObjetoSelecionado();
            if (personalAdministrativo.codigoPersonal != null && personalAdministrativo.codigoPersonal == "")
            {
                RegistroAsistenciaPersonalAdministrativoMantenimiento ofrm = new RegistroAsistenciaPersonalAdministrativoMantenimiento(personalAdministrativo, personalRegistradoParaMarcarAsistencia);
                ofrm.Show();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (personalAdministrativo.codigoPersonal != null && personalAdministrativo.codigoPersonal != "")
            {
               
                RegistroAsistenciaPersonalAdministrativoMantenimiento ofrm = new RegistroAsistenciaPersonalAdministrativoMantenimiento(personalAdministrativo, personalRegistradoParaMarcarAsistencia);
                ofrm.Show();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void anularAsistencia_Click(object sender, EventArgs e)
        {
            if (personalAdministrativo.codigoPersonal != null && personalAdministrativo.codigoPersonal != "")
            {
                int filasAfectadadas = 0;
                AsistenciaModelo = new AsistenciaPersonalAdministrativoDatos();

                filasAfectadadas = AsistenciaModelo.Anular(personalAdministrativo);
                if (filasAfectadadas == 1) //Si se logro la insercion limpio el formulario             
                {
                    MessageBox.Show("Se Anulo correctamente sus datos");
                }
                else
                {
                    MessageBox.Show("Error en anular el registro");
                }


            }
        }

        private void editarAsistencia_Click(object sender, EventArgs e)
        {
            if (personalAdministrativo.codigoPersonal != null && personalAdministrativo.codigoPersonal != "")
            {
                RegistroAsistenciaPersonalAdministrativoMantenimiento ofrm = new RegistroAsistenciaPersonalAdministrativoMantenimiento(personalAdministrativo, personalRegistradoParaMarcarAsistencia);
                ofrm.Show();
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (personalAdministrativo.codigoPersonal != null && personalAdministrativo.codigoPersonal != "")
            {
                int filasAfectadadas = 0;
                AsistenciaModelo = new AsistenciaPersonalAdministrativoDatos();

                filasAfectadadas = AsistenciaModelo.Anular(personalAdministrativo);
                if (filasAfectadadas == 1) //Si se logro la insercion limpio el formulario             
                {
                    MessageBox.Show("Se Anulo correctamente sus datos");
                }
                else
                {
                    MessageBox.Show("Error en anular el registro");
                }


            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }



    }
}
