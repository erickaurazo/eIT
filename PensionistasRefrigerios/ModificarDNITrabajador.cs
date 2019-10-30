using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Export;
using System.IO;
using System.Configuration;
using System.Collections;
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.Aggregates;
using Telerik.WinControls.UI.Localization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ModificarDNITrabajador : Telerik.WinControls.UI.RadForm
    {
        private SJM_Pensione oTransferenciaAsistencia;
        private List<PersonalCampo> listadoPersonalCampo;
        private PersonalCampo personalCampo;
        private List<PersonalCampo> listadoPersonalCampoDisponible;
        private SJM_PensionesNegocios Modelo;
        private PersonalCampo personalCampoDisponible;
        private List<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult> listadoHistorialAsistenciaTrabajador = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult>();
        private List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult> listadoRefrigeriosRecibidosxTrabajadorxDia;
        private RefrigerioAgrupado asistenciaPersonal;

        public ModificarDNITrabajador()
        {
            InitializeComponent();
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
        }

        public ModificarDNITrabajador(SJM_Pensione oTransferenciaAsistencia)
        {
            // TODO: Complete member initialization
            InitializeComponent();

            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            PivotGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.PivotGridLocalizationProviderEspanol();
            this.oTransferenciaAsistencia = oTransferenciaAsistencia;
            this.dgvPivotHistorialAsistencia.Dock = DockStyle.Fill;
            this.dgvPivotHistorialAsistencia.PivotGridElement.ShowFilterArea = true;
            PresentarDatos();
        }

        public ModificarDNITrabajador(RefrigerioAgrupado asistenciaPersonal)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.asistenciaPersonal = asistenciaPersonal;
            RadGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.GridLocalizationProviderEspanol();
            RadPageViewLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadPageViewLocalizationProviderEspañol();
            RadWizardLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadWizardLocalizationProviderEspañol();
            RadMessageLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.RadMessageBoxLocalizationProviderEspañol();
            PivotGridLocalizationProvider.CurrentProvider = new Transportista.ClaseTelerik.PivotGridLocalizationProviderEspanol();
            this.dgvPivotHistorialAsistencia.Dock = DockStyle.Fill;
            this.dgvPivotHistorialAsistencia.PivotGridElement.ShowFilterArea = true;

            Consultar();

        }

        private void Consultar()
        {
            this.btnAceptar.Enabled = false;
            btnAnular.Enabled = false;
            this.gbDatosPensionRefrigerio.Enabled = false;
            this.dgvTrabajador.Enabled = false;
            this.dgvRefrigerioRecibido.Enabled = false;
            this.dgvDisponibles.Enabled = false;
            this.dgvPivotHistorialAsistencia.Enabled = false;
            bgwHilo.RunWorkerAsync();

        }

        private void PresentarDatos()
        {
            #region
            try
            {
                #region Presentar Datos()

                listadoPersonalCampoDisponible = new List<PersonalCampo>();
                Modelo = new SJM_PensionesNegocios();
                this.txtDNIProveedor.Text = this.oTransferenciaAsistencia.DniPension.ToString().Trim();
                this.txtProveedor.Text = this.oTransferenciaAsistencia.NombresPension.ToString().Trim();


                switch (this.oTransferenciaAsistencia.TipoComida)
                {
                    case 0:
                        this.txtRefigerio.Text = "DESAYUNO";
                        listadoPersonalCampoDisponible = Modelo.ObtenerListaPosiblesAsistenciasTrabajadores(1, 0, 0, this.oTransferenciaAsistencia.FechaPension.Value.ToPresentationDate(), 0, this.oTransferenciaAsistencia.DniPension.ToString().Trim()).ToList();
                        break;

                    case 1:
                        this.txtRefigerio.Text = "ALMUERZO";
                        listadoPersonalCampoDisponible = Modelo.ObtenerListaPosiblesAsistenciasTrabajadores(0, 1, 0, this.oTransferenciaAsistencia.FechaPension.Value.ToPresentationDate(), 1, this.oTransferenciaAsistencia.DniPension.ToString().Trim()).ToList();
                        break;

                    case 2:
                        this.txtRefigerio.Text = "CENA";
                        listadoPersonalCampoDisponible = Modelo.ObtenerListaPosiblesAsistenciasTrabajadores(0, 0, 1, this.oTransferenciaAsistencia.FechaPension.Value.ToPresentationDate(), 2, this.oTransferenciaAsistencia.DniPension.ToString().Trim()).ToList();
                        break;

                    default:
                        this.txtRefigerio.Text = "OTRO";
                        break;
                }

                switch (this.oTransferenciaAsistencia.EsProcesado)
                {
                    case 0:
                        this.txtEstado.Text = "PENDIENTE";
                        break;

                    case 1:
                        this.txtEstado.Text = "PROCESADO";
                        break;

                    default:
                        this.txtEstado.Text = "SIN ESTADO";
                        break;
                }


                this.txtFecha.Text = this.oTransferenciaAsistencia.FechaPension.Value.ToPresentationDate();
                this.txtCodigoMovimiento.Text = this.oTransferenciaAsistencia.IdPension.ToString().Trim();

                /* Agregar el trabajador desconocido */
                listadoPersonalCampo = new List<PersonalCampo>();
                personalCampo = new PersonalCampo();
                personalCampo.nroDNI = this.oTransferenciaAsistencia.DniTrabajador.ToString().Trim();
                personalCampo.Nombres = this.oTransferenciaAsistencia.NombresTrabajador.ToString().Trim();
                listadoPersonalCampo.Add(personalCampo);

                dgvTrabajador.DataSource = listadoPersonalCampo.ToDataTable<PersonalCampo>();
                dgvTrabajador.Refresh();

                dgvDisponibles.DataSource = listadoPersonalCampoDisponible.ToDataTable<PersonalCampo>();
                dgvDisponibles.Refresh();


                #endregion
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            #endregion
        }

        private void ModificarDNITrabajador_Load(object sender, EventArgs e)
        {

        }

        private void dgvDisponibles_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarObjetoPersonalDisponible();
            listadoHistorialAsistenciaTrabajador = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult>();
            listadoRefrigeriosRecibidosxTrabajadorxDia = new List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult>();
            dgvRefrigerioRecibido.DataSource = listadoRefrigeriosRecibidosxTrabajadorxDia.ToDataTable<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult>();
            dgvRefrigerioRecibido.Refresh();


            if (dgvDisponibles != null && dgvDisponibles.Rows.Count > 0)
            {
                if (dgvDisponibles.CurrentRow != null && dgvDisponibles.CurrentRow.Cells["chNroDniTrabajador"].Value != null)
                {
                    personalCampoDisponible = new PersonalCampo();
                    personalCampoDisponible.nroDNI = dgvDisponibles.CurrentRow.Cells["chNroDniTrabajador"].Value.ToString().Trim();
                    personalCampoDisponible.Nombres = dgvDisponibles.CurrentRow.Cells["chNombresCompletos"].Value != null ? dgvDisponibles.CurrentRow.Cells["chNombresCompletos"].Value.ToString().Trim() : "";

                    listadoHistorialAsistenciaTrabajador = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult>();
                    listadoRefrigeriosRecibidosxTrabajadorxDia = new List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult>();

                    Modelo = new SJM_PensionesNegocios();
                    listadoHistorialAsistenciaTrabajador = Modelo.ObtnerListaHistorialRefrigerioxTrabajador(this.oTransferenciaAsistencia.FechaPension.ToPresentationDate(), this.oTransferenciaAsistencia.DniPension, personalCampoDisponible.nroDNI).ToList();
                    listadoRefrigeriosRecibidosxTrabajadorxDia = Modelo.ObtnerListaRefrigerioRecibidosxTrabajadorxDia(personalCampoDisponible.nroDNI, this.oTransferenciaAsistencia.FechaPension.ToPresentationDate(), this.oTransferenciaAsistencia.FechaPension.ToPresentationDate()).ToList();

                    dgvRefrigerioRecibido.DataSource = listadoRefrigeriosRecibidosxTrabajadorxDia.ToDataTable<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult>();
                    dgvRefrigerioRecibido.Refresh();

                    this.dgvPivotHistorialAsistencia.DataSource = listadoHistorialAsistenciaTrabajador.ToDataTable<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult>();

                    if (dgvPivotHistorialAsistencia.AggregateDescriptions.Count > 0)
                    {
                        //this.dgvPivotHistorialAsistencia.AggregateDescriptions.RemoveAt(0);
                    }
                    else
                    {
                        this.dgvPivotHistorialAsistencia.AggregateDescriptions.Add(new PropertyAggregateDescription() { PropertyName = "Asistencia", AggregateFunction = AggregateFunctions.Count });
                    }


                    this.dgvPivotHistorialAsistencia.Refresh();
                }
                else
                {
                    this.dgvPivotHistorialAsistencia.DataSource = listadoHistorialAsistenciaTrabajador.ToDataTable<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult>();
                    //this.dgvPivotHistorialAsistencia.AggregateDescriptions.Add(new PropertyAggregateDescription() { PropertyName = "Asistencia", AggregateFunction = AggregateFunctions.Count });
                    if (dgvPivotHistorialAsistencia.AggregateDescriptions.Count > 0)
                    {
                        this.dgvPivotHistorialAsistencia.AggregateDescriptions.RemoveAt(0);
                    }

                    this.dgvPivotHistorialAsistencia.Refresh();
                }
            }
        }

        private void LimpiarObjetoPersonalDisponible()
        {
            #region
            try
            {
                #region Limpiar Objeto()
                personalCampoDisponible = new PersonalCampo();
                personalCampoDisponible.nroDNI = "";
                personalCampoDisponible.Nombres = "";
                #endregion
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            #endregion
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            /*El nuevo DNI tiene que existir en la tabla disponible */
            if (personalCampoDisponible.nroDNI != null && personalCampoDisponible.nroDNI.ToString().Trim() != "")
            {
                if (personalCampoDisponible.Nombres != null && personalCampoDisponible.Nombres.ToString().Trim() != "")
                {
                    /*El codigo del movimiento tiene que existir y ser mayor a 0 */
                    if (this.oTransferenciaAsistencia.IdPension != null && this.oTransferenciaAsistencia.IdPension != 0)
                    {
                        ActualizarDniTrabajador();
                        btnAceptar.Enabled = false;
                        gbDatosPensionRefrigerio.Enabled = false;
                        gbDisponibles.Enabled = false;
                        gbHistorialAsistenciaRefrigerio.Enabled = false;
                        gbTrabajador.Enabled = false;
                    }
                    else
                    {
                        RadMessageBox.Show("El código del movimiento no es correcto.", "MENSAJE DEL SISTEMA");
                    }
                }
                else
                {
                    RadMessageBox.Show("El Nombre del nuevo travabajor no esta existe", "MENSAJE DEL SISTEMA");
                }
            }
            else
            {
                RadMessageBox.Show("No se ha selecionado personal disponible para actualizar DNI del trabajador", "MENSAJE DEL SISTEMA");

            }
        }

        private void ActualizarDniTrabajador()
        {
            #region
            try
            {
                #region Actualizar DNI()
                Modelo = new SJM_PensionesNegocios();
                Modelo.ActualizarNumeroDNITrabajor(this.oTransferenciaAsistencia, personalCampoDisponible);
                RadMessageBox.Show("Actualizado Correctamente", "MENSAJE DEL SISTEMA");
                #endregion
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            #endregion
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

            Modelo = new SJM_PensionesNegocios();
            Modelo.AnularAsistenciaTransferida(this.txtFecha.Text.Substring(6, 4), oTransferenciaAsistencia.IdPension);
            MessageBox.Show("Registrado correctamente", "Mensaje del Sistema");

            gbDatosPensionRefrigerio.Enabled = false;
            this.gbDisponibles.Enabled = false;
            this.gbHistorialAsistenciaRefrigerio.Enabled = false;
            this.gbRefrigeriosRecibidosxTrabajador.Enabled = false;
            this.gbTrabajador.Enabled = false;
        }

        private void gbDatosPensionRefrigerio_Click(object sender, EventArgs e)
        {

        }

        private void bgwHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            RealizarConsulta();
        }

        private void RealizarConsulta()
        {

            try
            {
                #region Presentar Datos()

                this.oTransferenciaAsistencia = new SJM_Pensione();
                this.oTransferenciaAsistencia.FechaPension = this.asistenciaPersonal.Fecha != null ? Convert.ToDateTime(this.asistenciaPersonal.Fecha.Value) : DateTime.Now;
                this.oTransferenciaAsistencia.DniPension = this.asistenciaPersonal.CodPension != null ? this.asistenciaPersonal.CodPension.ToString().Trim() : "";
                //personalCampoDisponible.nroDNI = this.asistenciaPersonal.DNITrabajador != null ? this.asistenciaPersonal.DNITrabajador.ToString().Trim() : "";



                Modelo = new SJM_PensionesNegocios();
                listadoPersonalCampoDisponible = new List<PersonalCampo>();
                listadoPersonalCampoDisponible.Add(new PersonalCampo
                {
                    codigoPersonal = this.asistenciaPersonal.CodigoPersonal,
                    Nombres = this.asistenciaPersonal.Trabajador,
                    nroDNI = this.asistenciaPersonal.DNITrabajador,
                    estado = "ACTIVO",
                    fecha = this.asistenciaPersonal.Fecha != null ? Convert.ToDateTime(this.asistenciaPersonal.Fecha.Value) : DateTime.Now,
                    fechaDesde = this.asistenciaPersonal.Fecha != null ? (this.asistenciaPersonal.Fecha.Value).ToPresentationDate() : DateTime.Now.ToShortDateString(),
                    fechaHasta = this.asistenciaPersonal.Fecha != null ? (this.asistenciaPersonal.Fecha.Value).ToPresentationDate() : DateTime.Now.ToShortDateString(),
                    nroDNIPension = this.asistenciaPersonal.CodPension != null ? this.asistenciaPersonal.CodPension.ToString().Trim() : "",
                    pension = this.asistenciaPersonal.Pension != null ? this.asistenciaPersonal.Pension.ToString().Trim() : "",
                    refriferio = "TODOS",
                });

                listadoPersonalCampo = new List<PersonalCampo>();
                personalCampo = new PersonalCampo();
                personalCampo.nroDNI = this.asistenciaPersonal.DNITrabajador != null ? this.asistenciaPersonal.DNITrabajador.ToString().Trim() : "";
                personalCampo.Nombres = this.asistenciaPersonal.Trabajador != null ? this.asistenciaPersonal.Trabajador.ToString().Trim() : "";
                personalCampo.codigoPersonal = this.asistenciaPersonal.CodigoPersonal != null ? this.asistenciaPersonal.CodigoPersonal : "";
                personalCampo.estado = "ACTIVO";
                personalCampo.fecha = this.asistenciaPersonal.Fecha != null ? Convert.ToDateTime(this.asistenciaPersonal.Fecha.Value) : DateTime.Now;
                personalCampo.fechaDesde = this.asistenciaPersonal.Fecha != null ? (this.asistenciaPersonal.Fecha.Value).ToPresentationDate() : DateTime.Now.ToShortDateString();
                personalCampo.fechaHasta = this.asistenciaPersonal.Fecha != null ? (this.asistenciaPersonal.Fecha.Value).ToPresentationDate() : DateTime.Now.ToShortDateString();
                personalCampo.nroDNIPension = this.asistenciaPersonal.CodPension != null ? this.asistenciaPersonal.CodPension.ToString().Trim() : "";
                personalCampo.pension = this.asistenciaPersonal.Pension != null ? this.asistenciaPersonal.Pension.ToString().Trim() : "";
                personalCampo.refriferio = "TODOS";
                listadoPersonalCampo.Add(personalCampo);
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString().Trim(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bgwHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PresentarInformacion();
        }

        private void PresentarInformacion()
        {
            try
            {
                this.txtDNIProveedor.Text = this.asistenciaPersonal.CodPension; /*FALTA DNI PENSION */
                this.txtProveedor.Text = this.asistenciaPersonal.Pension;
                this.txtRefigerio.Text = "REFIGERIOS";
                this.txtEstado.Text = "SIN ESTADO";
                this.txtFecha.Text = this.asistenciaPersonal != null ? this.asistenciaPersonal.Fecha.Value.ToPresentationDate() : "";
                this.txtCodigoMovimiento.Text = this.asistenciaPersonal.CodPension != null ? this.asistenciaPersonal.CodPension.ToString().Trim() : "0";

                dgvTrabajador.DataSource = listadoPersonalCampo.ToDataTable<PersonalCampo>();
                dgvTrabajador.Refresh();

                dgvDisponibles.DataSource = listadoPersonalCampoDisponible.ToDataTable<PersonalCampo>();
                dgvDisponibles.Refresh();

                this.btnAceptar.Enabled = false;
                btnAnular.Enabled = false;
                this.gbDatosPensionRefrigerio.Enabled = true;
                this.dgvTrabajador.Enabled = true;
                this.dgvRefrigerioRecibido.Enabled = true;
                this.dgvDisponibles.Enabled = true;
                this.dgvPivotHistorialAsistencia.Enabled = true;
            }
            catch (Exception Ex)
            {
                this.btnAceptar.Enabled = false;
                btnAnular.Enabled = false;
                this.gbDatosPensionRefrigerio.Enabled = true;
                this.dgvTrabajador.Enabled = true;
                this.dgvRefrigerioRecibido.Enabled = true;
                this.dgvDisponibles.Enabled = true;
                this.dgvPivotHistorialAsistencia.Enabled = true;
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }
    }
}
