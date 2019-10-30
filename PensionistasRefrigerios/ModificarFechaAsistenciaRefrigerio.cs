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
using System.Globalization;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ModificarFechaAsistenciaRefrigerio : Form
    {
        private SJM_Pensione oTransferenciaAsistenciaAsistenciaRefrigerios;
        private List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult> listadoRefrigeriosRecibidosxTrabajadorxDia;
        private SJM_PensionesNegocios Modelo;

        public ModificarFechaAsistenciaRefrigerio()
        {
            InitializeComponent();
        }

        public ModificarFechaAsistenciaRefrigerio(SJM_Pensione oTransferenciaAsistenciaAsistenciaRefrigerios)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.oTransferenciaAsistenciaAsistenciaRefrigerios = oTransferenciaAsistenciaAsistenciaRefrigerios;
            PresentarDatos();
            btnActualizar.Enabled = false;
        }


        private void PresentarDatos()
        {
            #region
            try
            {
                #region Presentar Datos()

                //listadoPersonalCampoDisponible = new List<PersonalCampo>();
                //Modelo = new MovimientoAsistenciaRefrigerioNeg();
                this.txtDNIProveedor.Text = this.oTransferenciaAsistenciaAsistenciaRefrigerios.DniPension.ToString().Trim();
                this.txtProveedor.Text = this.oTransferenciaAsistenciaAsistenciaRefrigerios.NombresPension.ToString().Trim();
                this.txtTrabajador.Text = this.oTransferenciaAsistenciaAsistenciaRefrigerios.NombresTrabajador.ToString().Trim().ToUpper();

                switch (this.oTransferenciaAsistenciaAsistenciaRefrigerios.TipoComida)
                {
                    case 0:
                        this.txtRefigerio.Text = "DESAYUNO";

                        break;

                    case 1:
                        this.txtRefigerio.Text = "ALMUERZO";

                        break;

                    case 2:
                        this.txtRefigerio.Text = "CENA";

                        break;

                    default:
                        this.txtRefigerio.Text = "OTRO";
                        break;
                }

                switch (this.oTransferenciaAsistenciaAsistenciaRefrigerios.EsProcesado)
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


                this.txtFecha.Text = this.oTransferenciaAsistenciaAsistenciaRefrigerios.FechaPension.Value.ToPresentationDate();
                this.txtFechaActualizada.Text = DateTime.Now.ToShortDateString();
                this.txtCodigoMovimiento.Text = this.oTransferenciaAsistenciaAsistenciaRefrigerios.IdPension.ToString().Trim().PadLeft(7, '0');


                #endregion
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            #endregion
        }

        private void lblFechaDesde_Click(object sender, EventArgs e)
        {

        }

        private void ModificarFechaAsistenciaRefrigerio_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFechaActualizada_Leave(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            DateTime dateValue;
            try
            {
                if (DateTime.TryParseExact(txtFechaActualizada.Text, "dd/MM/yyyy", new CultureInfo("es-Es"), DateTimeStyles.None, out dateValue))
                {
                    listadoRefrigeriosRecibidosxTrabajadorxDia = new List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult>();
                    Modelo = new SJM_PensionesNegocios();
                    listadoRefrigeriosRecibidosxTrabajadorxDia = Modelo.ObtnerListaRefrigerioRecibidosxTrabajadorxDia(oTransferenciaAsistenciaAsistenciaRefrigerios.DniTrabajador, txtFechaActualizada.Text.ToString().Trim(), txtFechaActualizada.Text.ToString().Trim()).ToList();

                    dgvRefrigerioRecibido.DataSource = listadoRefrigeriosRecibidosxTrabajadorxDia.ToDataTable<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult>();
                    dgvRefrigerioRecibido.Refresh();
                    btnActualizar.Enabled = true;
                }




            }
            catch (Exception Ex)
            {

                throw Ex;
            }


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarDuplicidadRefrigerios() == false)
            {
                #region Actualizar fecha de Asistencia a Refrigerios()
                ActualizarFechaAsistenciaRefrigerio();

                #endregion
            }
        }

        private bool ValidarDuplicidadRefrigerios()
        {
            return false;
        }


        private void ActualizarFechaAsistenciaRefrigerio()
        {
            #region
            try
            {
                #region Actualizar DNI()
                Modelo = new SJM_PensionesNegocios();
                Modelo.ActualizarFechaAsistenciaRefrigerio(this.oTransferenciaAsistenciaAsistenciaRefrigerios, this.txtFechaActualizada.Text);
                RadMessageBox.Show("Actualizado Correctamente", "MENSAJE DEL SISTEMA");
                btnActualizar.Enabled = false;
                gbRefrigeriosRecibidosxTrabajador.Enabled = false;
                this.txtFechaActualizada.Enabled = false;
                #endregion
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            #endregion
        }
    }
}
