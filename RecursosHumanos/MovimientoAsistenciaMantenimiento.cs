using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using RecursosHumanos.Datos;
using RecursosHumanos.Negocios;
using System.Configuration;
using MyControlsDataBinding;
//using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using RecursosHumanos.Negocios;
using System.Collections;
using DevSoftSolutionsControls;
using DevSoftSolutionsDataAccess;
using DevSoftSolutionsExtensions;

using System.Data.SqlClient;

namespace RecursosHumanos
{
    public partial class MovimientoAsistenciaMantenimiento : Telerik.WinControls.UI.RadForm
    {
        private string codigoEditar;
        private Datos.UsuarioMovimientoIngresoSistema usuario;
        private List<Documento> oDocumentos;
        private DocumentoNegocio oDocumentoNegocio;
        private PuntoEmisionDocumentoNegocio oSerieNegocio;
        private List<PuntoEmisionDocumento> oSerieDocumentos;
        private List<ObtenerListadoAsistenciaByCodigoResult> listadoMovimientoAsistencia;
        private List<ObtenerListadoAsistenciaByCodigoResult> ListaTareos;
        private AsistenciaNegocio modelo;
        private LaborNegocio laborNegocio;
        private List<Labor> listaLabores;
        private List<Consumidor> ListaConsumidores;
        private DataGridViewRow Row;
        private MyHelpDataGridView pGrilla;
        private Labor labor;
        private ConsumidorNegocio consumidorNegocio;
        private List<Consumidor> listadoConsumidoresGrilla;
        private List<Consumidor> listaTodosConsumidores;
        private int ultimoItemGrilla = 0;
        private string oConexion;
        private MovimientoAsistencia oCabecera;
        private AsistenciaNegocio asistenciaNegocio;
        private List<MovimientoAsistenciaDetalle> oDetallesEliminar = new List<MovimientoAsistenciaDetalle>();

        public MovimientoAsistenciaMantenimiento()
        {
            InitializeComponent();
        }

        public MovimientoAsistenciaMantenimiento(string codigoEditar, Datos.UsuarioMovimientoIngresoSistema usuario)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            Inicio();
            this.codigoEditar = codigoEditar;
            this.txtAsistenciaCodigoMovimiento.Text = codigoEditar;
            this.usuario = usuario;
            CargarCombosIniciales();
            CargarDocumentoEnControles(codigoEditar);

        }

        private void CargarDocumentoEnControles(string codigoEditar)
        {
            gbAsistencia.Enabled = false;
            gbDetalleAsistencia.Enabled = true;
            gbEmisor.Enabled = false;
            ProgressBarF.Visible = true;
            bgwComboInicial.RunWorkerAsync();

        }

        private void MovimientoAsistenciaMantenimiento_Load(object sender, EventArgs e)
        {
            ObtenerListaAsistencias();
            CrearEstructuraGrilla();
            MostrarInformacionGrilla();
            MostrarTotalHoras();
            ActivarControlesEdicion("Editar");

        }

        private void ActivarControlesEdicion(string nombreAccion)
        {

            try
            {
                switch (nombreAccion)
                {
                    case "Editar":
                        dgvDetalle.ReadOnly = false;
                        btnAgregar.Enabled = true;
                        btnQuitar.Enabled = true;
                        btnNuevo.Enabled = !true;
                        btnEditar.Enabled = !true;
                        btnGrabar.Enabled = true;
                        btnAtras.Enabled = true;
                        btnAnular.Enabled = !true;
                        btnHistorial.Enabled = true;
                        btnImportar.Enabled = !true;
                        btnExportar.Enabled = true;
                        btnSalir.Enabled = true;
                        dgvDetalle.Enabled = true;
                        btnAgregarConsumidor.Enabled = true;
                        dgvDetalle.Columns[2].ReadOnly = false;
                        //dgvDetalle.Columns[3].ReadOnly = false;
                        dgvDetalle.Columns[4].ReadOnly = false;
                        dgvDetalle.Columns[5].ReadOnly = false;
                        //dgvDetalle.Columns[6].ReadOnly = false;
                        dgvDetalle.Refresh();
                        break;
                    case "Atras":
                        dgvDetalle.ReadOnly = !false;
                        btnAgregar.Enabled = !true;
                        btnQuitar.Enabled = !true;
                        btnNuevo.Enabled = true;
                        btnEditar.Enabled = true;
                        btnGrabar.Enabled = !true;
                        btnAtras.Enabled = !true;
                        btnAnular.Enabled = !true;
                        btnHistorial.Enabled = true;
                        btnImportar.Enabled = !true;
                        btnExportar.Enabled = true;
                        btnSalir.Enabled = true;
                        dgvDetalle.Enabled = true;
                        btnAgregarConsumidor.Enabled = !true;
                        break;

                    case "Grabar":
                        Grabar();
                        dgvDetalle.ReadOnly = !false;
                        btnAgregar.Enabled = !true;
                        btnQuitar.Enabled = !true;
                        btnNuevo.Enabled = true;
                        btnEditar.Enabled = true;
                        btnGrabar.Enabled = !true;
                        btnAtras.Enabled = !true;
                        btnAnular.Enabled = !true;
                        btnHistorial.Enabled = true;
                        btnImportar.Enabled = !true;
                        btnExportar.Enabled = true;
                        btnSalir.Enabled = true;
                        dgvDetalle.Enabled = true;
                        btnAgregarConsumidor.Enabled = !true;
                        break;


                    default:
                        btnAgregar.Enabled = !true;
                        btnQuitar.Enabled = !true;
                        btnNuevo.Enabled = !true;
                        btnEditar.Enabled = !true;
                        btnGrabar.Enabled = !true;
                        btnAtras.Enabled = !true;
                        btnAnular.Enabled = !true;
                        btnHistorial.Enabled = !true;
                        btnImportar.Enabled = !true;
                        btnExportar.Enabled = !true;
                        btnSalir.Enabled = !true;
                        break;
                }


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        public void SumarElementosSeleccionadosGrilla(object senderGrilla)
        {
            try
            {
                if (((DataGridView)senderGrilla).CurrentRow != null && ((DataGridView)senderGrilla).CurrentCell != null)
                {
                    int fila = ((DataGridView)senderGrilla).CurrentRow.Index;
                    int columna = ((DataGridView)senderGrilla).CurrentCell.ColumnIndex;

                    decimal SumaSeleccionada = 0;
                    decimal promedioSeleccionado = 0;
                    int recuento = 0;

                    foreach (DataGridViewCell celda in ((DataGridView)senderGrilla).SelectedCells)
                    {
                        string tipoDato = celda.Value == null ? string.Empty : celda.Value.GetType().Name.ToString();
                        if (tipoDato != null && tipoDato != string.Empty)
                        {
                            if (tipoDato == "Double" || tipoDato == "Decimal")
                            {
                                SumaSeleccionada += Convert.ToDecimal(celda.Value);
                                recuento++;
                                promedioSeleccionado = (SumaSeleccionada / recuento);
                            }
                            else
                            {
                                SumaSeleccionada = 0;
                                recuento = 0;
                                promedioSeleccionado = 0;
                                break;
                            }
                        }
                        else
                        {
                            SumaSeleccionada = 0;
                            recuento = 0;
                            promedioSeleccionado = 0;
                            break;
                        }
                    }

                    this.lblSumaSeleccionada.Text = SumaSeleccionada.ToDecimalPresentation();
                    this.lblRecuento.Text = recuento.ToString();
                    this.lblPromedio.Text = promedioSeleccionado.ToDecimalPresentation();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerListaAsistencias()
        {
            try
            {
                ListaTareos = listadoMovimientoAsistencia;
                laborNegocio = new LaborNegocio();
                listaLabores = new List<Labor>();
                listaLabores = laborNegocio.ListadoLabores(Program.ClaseCompartida.periodoElegido).ToList();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        public void CrearEstructuraGrilla()
        {
            try
            {

                MyDataGridViewDetails pGrilla = this.dgvDetalle;
                pGrilla.Rows.Clear();
                pGrilla.Columns.Clear();
                pGrilla.Refresh();
                //INSERTANDO LA FILA DE LOS TOTALIZADOS QUE SE MUESTRE EN LA
                //PRIMERA FILA PARA UNA MAYOR VISUALIZACION
                //**********************************************************************************
                ArrayList arraytotal = new ArrayList();
                string id_variedad = string.Empty;

                #region Creacion de columnas

                //INGRESANDO COLUMNA CORRELATIVO
                //*****************************************************************************
                //DataGridViewProperties propCorrelativo = new DataGridViewProperties();
                //propCorrelativo.P_LongColumnaCorrelativa = 3;
                //propCorrelativo.P_TipoDato = EnumTipoDato.Entero;
                //propCorrelativo.P_EsAutocorrelativa = true;

                //DataGridViewTextBoxColumn chCorrelativo = new DataGridViewTextBoxColumn();
                //chCorrelativo.Tag = propCorrelativo;
                //chCorrelativo.HeaderText = "Correlativo";
                //chCorrelativo.Name = "chCorrelativo";
                //chCorrelativo.Frozen = true;
                //chCorrelativo.Visible = false;
                ////chCorrelativo.ReadOnly = true;
                //chCorrelativo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //chCorrelativo.Width = 30;
                //chCorrelativo.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                //pGrilla.Columns.Add(chCorrelativo);

                //INGRESANDO COLUMNA ITEM
                //*****************************************************************************
                DataGridViewProperties propItem = new DataGridViewProperties();
                propItem.P_LongColumnaCorrelativa = 3;
                propItem.P_TipoDato = EnumTipoDato.Texto;
                propItem.P_EsAutocorrelativa = true;

                DataGridViewTextBoxColumn chItem = new DataGridViewTextBoxColumn();
                chItem.Tag = propItem;
                chItem.HeaderText = "Item";
                chItem.Name = "chItem";
                chItem.Frozen = true;
                chItem.ReadOnly = true;
                chItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chItem.Width = 50;
                chItem.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chItem);

                //INGRESANDO COLUMNA Codigo del personal
                //*****************************************************************************
                DataGridViewProperties propCodigo = new DataGridViewProperties();
                propCodigo.P_LongColumnaCorrelativa = 0;
                propCodigo.P_EsBusqueda = true;
                propCodigo.P_TipoDato = EnumTipoDato.Texto;
                propCodigo.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chCodigo = new DataGridViewTextBoxColumn();
                chCodigo.Tag = propCodigo;
                chCodigo.HeaderText = "Codigo";
                chCodigo.Name = "chCodigo";
                chCodigo.Frozen = true;
                chCodigo.ReadOnly = false;
                chCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chCodigo.Width = 80;
                chCodigo.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chCodigo);

                //*****************************************************************************
                //INGRESANDO COLUMNA nombres completos
                //*****************************************************************************
                DataGridViewProperties propNombres = new DataGridViewProperties();
                propNombres.P_TipoDato = EnumTipoDato.Texto;
                propNombres.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chNombres = new DataGridViewTextBoxColumn();
                chNombres.Tag = propNombres;
                chNombres.HeaderText = "Nombres";
                chNombres.Name = "chNombres";
                chNombres.Frozen = true;
                chNombres.ReadOnly = false;
                chNombres.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chNombres.Width = 250;
                chNombres.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chNombres);

                DataGridViewProperties propObs = new DataGridViewProperties();
                propObs.P_LongColumnaCorrelativa = 0;
                propObs.P_EsBusqueda = false;
                propObs.P_TipoDato = EnumTipoDato.Texto;
                propObs.P_EsAutocorrelativa = false;

                DataGridViewComboBoxColumn chObs = new DataGridViewComboBoxColumn();
                chObs.Items.Add("Dia compensado");
                chObs.Items.Add("No firmo planilla");
                chObs.Items.Add("Permiso");
                chObs.Items.Add("Abandono");

                chObs.Tag = propObs;
                chObs.HeaderText = "Obs";
                chObs.Name = "chObs";
                chObs.Frozen = true;
                chObs.ReadOnly = false;
                chObs.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chObs.Width = 200;
                chObs.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chObs);

                //*****************************************************************************
                //INGRESANDO COLUMNA ESTATICA ACTIVIDADES
                //*****************************************************************************
                DataGridViewProperties propIdAct = new DataGridViewProperties();
                propIdAct.P_TipoDato = EnumTipoDato.Texto;
                propIdAct.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chIdActividad = new DataGridViewTextBoxColumn();
                chIdActividad.Tag = propIdAct;
                chIdActividad.HeaderText = "Act";
                chIdActividad.Name = "chIdActividad";
                chIdActividad.Frozen = true;
                chIdActividad.ReadOnly = false;
                chIdActividad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chIdActividad.Width = 40;
                chIdActividad.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chIdActividad);

                //*****************************************************************************
                //INGRESANDO COLUMNA ESTATICA LABORES
                //*****************************************************************************
                DataGridViewProperties propIdLab = new DataGridViewProperties();
                propIdLab.P_TipoDato = EnumTipoDato.Texto;
                propIdLab.P_EsBusqueda = true;
                propIdLab.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chIdLabor = new DataGridViewTextBoxColumn();
                chIdLabor.Tag = propIdLab;
                chIdLabor.HeaderText = "Lab";
                chIdLabor.Name = "chIdLabor";
                chIdLabor.Frozen = true;
                chIdLabor.ReadOnly = false;
                chIdLabor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chIdLabor.Width = 90;
                chIdLabor.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chIdLabor);

                //*****************************************************************************
                //INGRESANDO COLUMNA ESTATICA DESCRIPCION  DE LABOR
                //*****************************************************************************
                DataGridViewProperties propLab = new DataGridViewProperties();
                propLab.P_TipoDato = EnumTipoDato.Texto;
                propLab.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chLabor = new DataGridViewTextBoxColumn();

                chLabor.HeaderText = "Lab";
                chLabor.Name = "chLabor";
                chLabor.Frozen = true;
                chLabor.ReadOnly = true;
                chLabor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chLabor.Width = 200;
                chLabor.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chLabor);

                //this.dgvDetalleTrabajadores.dgvDetalles.Refresh();

                //Lista de solo consumidores
                ListaConsumidores = (from items in ListaTareos
                                     group items by items.codigoConsumidor into j
                                     select new Consumidor
                                     {
                                         codigoConsumidor = j.Key
                                     }).ToList();


                foreach (Consumidor cc in ListaConsumidores)
                {
                    DataGridViewProperties propCC = new DataGridViewProperties();
                    propCC.P_TipoDato = EnumTipoDato.Decimal;
                    propCC.P_EsBusqueda = false;
                    propCC.P_EsAutocorrelativa = false;

                    DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                    columna.Tag = propCC;
                    columna.HeaderText = cc.codigoConsumidor.Trim();
                    columna.Tag = cc.codigoConsumidor.Trim();
                    columna.Name = "ch" + cc.codigoConsumidor.Trim();
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    columna.Width = 100;
                    columna.ReadOnly = false;
                    columna.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                    pGrilla.Columns.Add(columna);
                }

                //dgvDetalle = pGrilla;
                #endregion

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        public void MostrarInformacionGrilla()
        {
            #region Grupo de Trabajadores x Labor y Act.

            var trabajadores = (from items in ListaTareos
                                group items by new
                                {
                                    items.codigoPersona,
                                    items.codigoAsistencia,
                                    items.codigoTurnoTrabajo,
                                    items.item,
                                    items.codigoResponsable,
                                    items.codigoActividad,
                                    items.codigoLabor
                                } into j
                                select new ObtenerListadoAsistenciaByCodigoResult
                                {
                                    codigoPersona = j.Key.codigoPersona,
                                    codigoAsistencia = j.Key.codigoAsistencia,
                                    codigoResponsable = j.Key.codigoResponsable,
                                    codigoTurnoTrabajo = j.Key.codigoTurnoTrabajo,
                                    item = j.Key.item,
                                    codigoActividad = j.Key.codigoActividad,
                                    codigoLabor = j.Key.codigoLabor,
                                    NombreTrabador = j.FirstOrDefault().NombreTrabador != null ? j.FirstOrDefault().NombreTrabador : string.Empty,
                                    observacion = j.FirstOrDefault().observacion != null ? j.FirstOrDefault().observacion : string.Empty,

                                }).ToList();

            foreach (ObtenerListadoAsistenciaByCodigoResult personal in trabajadores)
            {
                List<ArrayList> ListaArrayPersonal = new List<ArrayList>();
                ArrayList arraySubGrupo = new ArrayList();
                foreach (DataGridViewColumn columna in this.dgvDetalle.Columns)
                {
                    string cc = columna.HeaderText;

                    //if (columna.Name == "chCorrelativo")
                    //{
                    //    arraySubGrupo.Add(personal.correlativo);
                    //}

                    if (columna.Name == "chItem")
                    {
                        arraySubGrupo.Add(personal.item);
                    }
                    else if (columna.Name == "chCodigo")
                    {
                        arraySubGrupo.Add(personal.codigoPersona);
                    }
                    else if (columna.Name == "chNombres")
                    {
                        arraySubGrupo.Add(personal.NombreTrabador);
                    }
                    else if (columna.Name == "chIdActividad")
                    {
                        arraySubGrupo.Add(personal.codigoActividad);
                    }
                    else if (columna.Name == "chIdLabor")
                    {
                        arraySubGrupo.Add(personal.codigoLabor);
                    }
                    else if (columna.Name == "chObs")
                    {
                        arraySubGrupo.Add(personal.observacion);
                    }
                    else if (columna.Name == "chLabor")
                    {
                        labor = listaLabores.Where(x => x.codigoActividad.Trim() == personal.codigoActividad.Trim() &&
                                                                x.codigoLabor.Trim() == personal.codigoLabor.Trim()).FirstOrDefault();
                        if (labor != null)
                        {
                            arraySubGrupo.Add(labor.descripcion.Trim());
                        }
                        else
                        {
                            arraySubGrupo.Add(string.Empty);
                        }

                    }
                    else
                    {
                        ObtenerListadoAsistenciaByCodigoResult tareo = ListaTareos.Where(x =>
                                                                      x.codigoPersona.Trim() == personal.codigoPersona.Trim() &&
                                                                      x.codigoAsistencia == personal.codigoAsistencia &&
                                                                      x.codigoTurnoTrabajo == personal.codigoTurnoTrabajo &&
                                                                      x.codigoResponsable == personal.codigoResponsable &&
                                                                      x.item == personal.item &&
                                                                      x.codigoActividad == personal.codigoActividad &&
                                                                      x.codigoLabor == personal.codigoLabor &&
                                                                      x.codigoConsumidor.Trim() == cc.Trim()
                                                                      ).FirstOrDefault();
                        if (tareo != null)
                        {
                            arraySubGrupo.Add(Convert.ToDecimal(tareo.TotalHoras.Value));
                        }
                        else
                        {
                            arraySubGrupo.Add(Convert.ToDecimal(0));
                        }
                    }
                }

                this.AgregarCeldas(this.dgvDetalle, arraySubGrupo);
            }

            #endregion
        }

        private void MostrarTotalHoras()
        {
            try
            {
                if (this.ListaTareos != null)
                {
                    this.lblTotalHorasByPlanilla.Text = ListaTareos.Sum(x => x.TotalHoras.Value).ToDecimalPresentation() + " HORAS";
                    ultimoItemGrilla = String.IsNullOrEmpty(ListaTareos.LastOrDefault().item) ? 0 : Int32.Parse(ListaTareos.LastOrDefault().item);
                    txtTotalHorasByDocumento.Text = ListaTareos.Sum(x => x.TotalHoras.Value).ToDecimalPresentation();

                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        public int AgregarCeldas(MyDataGridViewDetails rc, ArrayList Elemnts)
        {
            System.Windows.Forms.DataGridViewRow Row = new System.Windows.Forms.DataGridViewRow();
            int x = 0;
            Row.CreateCells(rc);
            try
            {
                foreach (var item in Elemnts)
                {

                    if (item != null)
                    {
                        Row.Cells[x].ValueType = item.GetType();
                        Row.Cells[x].Value = item;
                        Row.ReadOnly = false;
                        if (item.GetType().ToString() == "System.Double")
                        {
                            //Row.DefaultCellStyle.Format = "N2";
                            Row.Cells[x].Style.Format = "N2";
                        }
                        if (item.GetType().ToString() == "System.Decimal")
                        {
                            //Row.DefaultCellStyle.Format = "N2";
                            Row.Cells[x].Style.Format = "N2";
                            if (Convert.ToDecimal(item) > 0)
                            {
                                Row.Cells[x].Style.BackColor = Utiles.colorAmarilloMedio;
                            }
                            else
                            {
                                Row.Cells[x].Style.BackColor = Color.White;
                            }
                        }
                        if (item.GetType().ToString() == "System.DateTime")
                        {
                            //Row.DefaultCellStyle.Format = "u";
                            Row.Cells[x].Style.Format = "u";
                        }

                        if (item.GetType().ToString() == "System.Int")
                        {
                            //Row.DefaultCellStyle.Format = "N0";
                            Row.Cells[x].Style.Format = "N0";
                        }

                        if (item.GetType().ToString() == "System.Int32" || item.GetType().ToString() == "System.Int64")
                        {
                            //Row.DefaultCellStyle.Format = "N0";
                            Row.Cells[x].Style.Format = "N0";
                        }
                        x++;
                    }

                }
                rc.Rows.Add(Row);
                return x;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return x;
            }
        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listadoMovimientoAsistencia = new List<ObtenerListadoAsistenciaByCodigoResult>();
                modelo = new AsistenciaNegocio();
                listadoMovimientoAsistencia = modelo.ObtenerMovimientoAsistenciaByCodigoAsistencia(Program.ClaseCompartida.periodoElegido, codigoEditar);

                listadoConsumidoresGrilla = new List<Consumidor>();
                consumidorNegocio = new ConsumidorNegocio();
                listadoConsumidoresGrilla = consumidorNegocio.ObtenerConsumidorByListadoDetalleAsistencia(listadoMovimientoAsistencia).ToList();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Mensaje del sistema");
                return;
            }
        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.txtFecha.Text = listadoMovimientoAsistencia.FirstOrDefault().fecha != null ? listadoMovimientoAsistencia.FirstOrDefault().fecha.Value.ToShortDateString() : DateTime.Now.ToShortDateString();
                this.txtPuntoEmisionCodigo.Text = listadoMovimientoAsistencia.FirstOrDefault().codigoPuntoEmisor != null ? listadoMovimientoAsistencia.FirstOrDefault().codigoPuntoEmisor : string.Empty;
                this.txtPuntoEmisionDescripcion.Text = listadoMovimientoAsistencia.FirstOrDefault().PuntoEmision != null ? listadoMovimientoAsistencia.FirstOrDefault().PuntoEmision.Trim() : string.Empty;
                this.txtOperacionCodigo.Text = listadoMovimientoAsistencia.FirstOrDefault().codigoOperacion != null ? listadoMovimientoAsistencia.FirstOrDefault().codigoOperacion.Trim() : string.Empty;
                this.txtOperacionDescripcion.Text = listadoMovimientoAsistencia.FirstOrDefault().operacion != null ? listadoMovimientoAsistencia.FirstOrDefault().operacion.Trim() : string.Empty;
                this.txtSucursalCodigo.Text = listadoMovimientoAsistencia.FirstOrDefault().codigoSucursal != null ? listadoMovimientoAsistencia.FirstOrDefault().codigoSucursal.Trim() : string.Empty;
                this.txtSucursalDescripcion.Text = listadoMovimientoAsistencia.FirstOrDefault().sucursal != null ? listadoMovimientoAsistencia.FirstOrDefault().sucursal.Trim() : string.Empty;
                this.txtAsistenciaCodigoMovimiento.Text = listadoMovimientoAsistencia.FirstOrDefault().codigoAsistencia != null ? listadoMovimientoAsistencia.FirstOrDefault().codigoAsistencia.Trim() : string.Empty;
                this.txtEstadoDescripcion.Text = listadoMovimientoAsistencia.FirstOrDefault().estado != null ? listadoMovimientoAsistencia.FirstOrDefault().estado.Trim() : string.Empty;
                this.txtEstadoCodigo.Text = listadoMovimientoAsistencia.FirstOrDefault().codigoEstado != null ? listadoMovimientoAsistencia.FirstOrDefault().codigoEstado.Trim() : string.Empty;
                this.txtPlanillaCodigo.Text = listadoMovimientoAsistencia.FirstOrDefault().codigoPlanilla != null ? listadoMovimientoAsistencia.FirstOrDefault().codigoPlanilla.Trim() : string.Empty;
                this.txtPlanillaDescripcion.Text = listadoMovimientoAsistencia.FirstOrDefault().planilla != null ? listadoMovimientoAsistencia.FirstOrDefault().planilla.Trim() : string.Empty;
                this.txtSemana.Text = listadoMovimientoAsistencia.FirstOrDefault().semana != null ? listadoMovimientoAsistencia.FirstOrDefault().semana.Trim() : string.Empty;
                this.txtFechaDesde.Text = listadoMovimientoAsistencia.FirstOrDefault().fechaInicioAsistencia != null ? listadoMovimientoAsistencia.FirstOrDefault().fechaInicioAsistencia.Value.ToShortDateString() : string.Empty;
                this.txtFechaHasta.Text = listadoMovimientoAsistencia.FirstOrDefault().fechaTerminoAsistencia != null ? listadoMovimientoAsistencia.FirstOrDefault().fechaTerminoAsistencia.Value.ToShortDateString() : string.Empty;
                this.txtNumeroDocumento.Text = listadoMovimientoAsistencia.FirstOrDefault().numeroRegistroAsistencia != null ? listadoMovimientoAsistencia.FirstOrDefault().numeroRegistroAsistencia.ToString().Trim().PadLeft(7, '0') : string.Empty;
                this.txtResponsableCodigo.Text = listadoMovimientoAsistencia.FirstOrDefault().codigoResponsable != null ? listadoMovimientoAsistencia.FirstOrDefault().codigoResponsable.Trim() : string.Empty;
                this.txtResponsableDescripcion.Text = listadoMovimientoAsistencia.FirstOrDefault().nombresCompletos != null ? listadoMovimientoAsistencia.FirstOrDefault().nombresCompletos.Trim() : string.Empty;
                this.txtTurnoCodigo.Text = listadoMovimientoAsistencia.FirstOrDefault().codigoTurnoTrabajo != null ? listadoMovimientoAsistencia.FirstOrDefault().codigoTurnoTrabajo.Trim() : string.Empty;
                this.txtTurnoDescripcion.Text = listadoMovimientoAsistencia.FirstOrDefault().turno != null ? listadoMovimientoAsistencia.FirstOrDefault().turno.Trim() : string.Empty;
                this.txtPeriodoPlanilla.Text = listadoMovimientoAsistencia.FirstOrDefault().periodoPlanilla != null ? listadoMovimientoAsistencia.FirstOrDefault().periodoPlanilla.Trim() : string.Empty;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Mensaje del sistema");
                return;
            }
        }

        private void bgwComboInicial_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                /* Obtener info para combo de Documento - ASI */
                oDocumentos = new List<Documento>();
                oDocumentoNegocio = new DocumentoNegocio();
                oDocumentos = oDocumentoNegocio.ObtenerListaDocumentoByCodigoDocumento(Program.ClaseCompartida.periodoElegido, "ASI");


                /* Obtener info para serie de documento - ASI */

                oSerieNegocio = new PuntoEmisionDocumentoNegocio();
                oSerieDocumentos = new List<PuntoEmisionDocumento>();
                PuntoEmisionDocumento oSerie = new PuntoEmisionDocumento();
                oSerie.codigoDocumento = "ASI";
                oSerieDocumentos = oSerieNegocio.ObtenerNumeroSerieByCodigoDocumento(Program.ClaseCompartida.periodoElegido, oSerie);

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Mensaje del sistema");
                return;
            }
        }

        private void bgwComboInicial_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                cboDocumentoCodigo.DisplayMember = "codigoDocumento";
                cboDocumentoCodigo.ValueMember = "codigoDocumento";
                cboDocumentoCodigo.DataSource = oDocumentos;

                cboSerie.DisplayMember = "serie";
                cboSerie.ValueMember = "serie";
                cboSerie.DataSource = oSerieDocumentos;

                txtNumeroDocumento.Text = oSerieDocumentos.FirstOrDefault().numero.PadLeft(7, '0');
                this.txtFecha.Text = DateTime.Now.ToShortDateString();

                gbAsistencia.Enabled = !false;
                gbDetalleAsistencia.Enabled = true;
                gbEmisor.Enabled = !false;
                ProgressBarF.Visible = !true;

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Mensaje del sistema");
                return;
            }
        }

        private void btnAgregarConsumidor_Click(object sender, EventArgs e)
        {
            consumidorNegocio = new ConsumidorNegocio();
            listaTodosConsumidores = new List<Consumidor>();
            listaTodosConsumidores = consumidorNegocio.ObtenerListadoConsumidorForListadoDetalleAsistencia(Program.ClaseCompartida.periodoElegido);

            if (listaTodosConsumidores.Where(x => x.codigoConsumidor.Trim() == this.txtIdConsumidor.Text.Trim()) != null)
            {
                if (this.ListaConsumidores.FirstOrDefault(x => x.codigoConsumidor.Trim() == this.txtIdConsumidor.Text.Trim()) == null)
                {
                    // QUIERE DECIR QUE NO EXISTE ACTUALMENTE y lo agrego a la lista
                    ListaConsumidores.Add(new Consumidor { codigoConsumidor = this.txtIdConsumidor.Text.Trim() });

                    //CREAMOS LA NUEVA COLUMNA Y SE LE DEBE DE ASIGNAR A LA GRILLA.
                    DataGridViewProperties propCC = new DataGridViewProperties();
                    propCC.P_TipoDato = EnumTipoDato.Decimal;
                    propCC.P_EsBusqueda = false;
                    propCC.P_EsAutocorrelativa = false;

                    DataGridViewTextBoxColumn chCC = new DataGridViewTextBoxColumn();
                    chCC.Tag = propCC;
                    chCC.HeaderText = this.txtIdConsumidor.Text.Trim();
                    chCC.Name = "ch" + this.txtIdConsumidor.Text.Trim();
                    //chCC.Frozen = true;
                    chCC.ReadOnly = false;
                    chCC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    chCC.DefaultCellStyle.Format = "N2";
                    chCC.Width = 90;
                    chCC.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                    this.dgvDetalle.Columns.Add(chCC);
                    this.dgvDetalle.Refresh();
                    txtIdConsumidor.Clear();
                }
                else
                {
                    //DE LO CONTRARIO YA EXISTE ESTE CONSUMIDOR Y NO DEBERIA DE INSERTARSE
                    MessageBox.Show("Ya existe este Consumidor : " + this.txtIdConsumidor.Text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Este consumidor no existe en la base de datos : " + this.txtIdConsumidor.Text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            SumarElementosSeleccionadosGrilla(sender);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ActivarControlesEdicion("Salir");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ActivarControlesEdicion("Nuevo");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActivarControlesEdicion("Editar");
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ActivarControlesEdicion("Grabar");
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            ActivarControlesEdicion("Atras");
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            ActivarControlesEdicion("Anular");
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            ActivarControlesEdicion("Historial");
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ActivarControlesEdicion("Importar");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ActivarControlesEdicion("Exportar");
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string DNIBuscar = Convert.ToString(this.dgvDetalle.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chCodigo"].Value) != null ? Convert.ToString(this.dgvDetalle.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chCodigo"].Value) : string.Empty;
            string codigoActividadBuscar = Convert.ToString(this.dgvDetalle.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chIdActividad"].Value) != null ? Convert.ToString(this.dgvDetalle.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chIdActividad"].Value) : string.Empty;
            string codigoLaborBuscar = Convert.ToString(this.dgvDetalle.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chIdLabor"].Value) != null ? Convert.ToString(this.dgvDetalle.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chIdLabor"].Value) : string.Empty;

            if (DNIBuscar != "")
            {
                if (DNIBuscar.Length == 8)
                {
                    PersonaNegocio personaNegocio = new PersonaNegocio();
                    string nombreCompletosBuscado = string.Empty;
                    nombreCompletosBuscado = personaNegocio.ObtenerNombrePersona(Program.ClaseCompartida.periodoElegido, DNIBuscar);
                    this.dgvDetalle.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chNombres"].Value = nombreCompletosBuscado;
                }
            }
            if (codigoActividadBuscar != "" && codigoLaborBuscar != "")
            {
                LaborNegocio laboreNegocio = new LaborNegocio();
                string nombreCompletoLabor = string.Empty;
                nombreCompletoLabor = laboreNegocio.ObtenerNombreLaborByCodigoLaborByCodigoActividad(Program.ClaseCompartida.periodoElegido, codigoActividadBuscar, codigoLaborBuscar);
                this.dgvDetalle.Rows[((DataGridView)sender).CurrentRow.Index].Cells["chLabor"].Value = nombreCompletoLabor;
            }
        }


        private void Grabar()
        {

            try
            {
                oCabecera = new MovimientoAsistencia();
                oCabecera.codigoEmpresa = "001";
                oCabecera.codigoAsistencia = txtAsistenciaCodigoMovimiento.Text.Trim();
                oCabecera.fecha = Convert.ToDateTime(this.txtFecha.Text);
                oCabecera.codigoPuntoEmisor = this.txtPuntoEmisionCodigo.Text.Trim();
                oCabecera.codigoPlanilla = this.txtPlanillaCodigo.Text.Trim();
                oCabecera.codigoSucursal = this.txtSucursalCodigo.Text.Trim();
                oCabecera.codigoDocumento = this.cboDocumentoCodigo.SelectedValue.ToString().Trim();
                oCabecera.codigoTurnoTrabajo = this.txtTurnoCodigo.Text;
                oCabecera.codigoResponsable = this.txtResponsableCodigo.Text.Trim();
                oCabecera.codigoEstado = this.txtEstadoCodigo.Text.Trim();
                oCabecera.codigoOperacion = this.txtOperacionCodigo.Text.Trim();
                oCabecera.serieDocumento = this.cboSerie.SelectedValue.ToString().Trim();
                oCabecera.numeroRegistroAsistencia = this.txtNumeroDocumento.Text.Trim();
                oCabecera.numeroOperacion = this.txtNumeroDocumento.Text.Trim();
                oCabecera.periodo = this.txtPeriodoPlanilla.Text.Trim();
                oCabecera.periodoPlanilla = this.txtPeriodoPlanilla.Text.Trim();
                oCabecera.semana = this.txtSemana.Text.Trim();
                oCabecera.fechaCreacion = DateTime.Now;
                oCabecera.rendimiento = '0';
                //oCabecera.esResultadoImportacion = 0;
                oCabecera.totalHorasRefrigerio = 0;
                oCabecera.totalHoras = Convert.ToDecimal(txtTotalHorasByDocumento.Text);
                //oCabecera.codigoReferencia = string.Empty;
                //oCabecera.comentario = string.Empty;
                //oCabecera.ventanaReferencia = string.Empty;
                oCabecera.numeroManual = string.Empty;
                oCabecera.procesado = 0;
                oCabecera.fechaInicioAsistencia = Convert.ToDateTime(txtFechaDesde.Text);
                oCabecera.fechaTerminoAsistencia = Convert.ToDateTime(txtFechaHasta.Text);
                oCabecera.estaSincronizado = 'N';


                List<MovimientoAsistenciaDetalle> oDetalles = new List<MovimientoAsistenciaDetalle>();
                foreach (DataGridViewRow item in this.dgvDetalle.Rows)
                {
                    foreach (Consumidor cc in ListaConsumidores)
                    {
                        //X CADA FILA VERIFICAMOS EN CADA CONUSMIDOR, Y CADA CC. ESTA COMO COLUMNA
                        #region INSERT INTO TABLA ()
                        if (item.Cells["ch" + cc.codigoConsumidor.Trim()].Value != null && item.Cells["ch" + cc.codigoConsumidor.Trim()].Value.ToString() != string.Empty)
                        {
                            MovimientoAsistenciaDetalle oDetalle = new MovimientoAsistenciaDetalle();
                            oDetalle.codigoEmpresa = "001";
                            oDetalle.codigoAsistencia = this.txtAsistenciaCodigoMovimiento.Text.Trim();
                            oDetalle.item = item.Cells["chItem"].Value.ToString();
                            oDetalle.codigoPersona = item.Cells["chCodigo"].Value.ToString();
                            oDetalle.codigoConsumidor = cc.codigoConsumidor.Trim();
                            oDetalle.codigoActividad = item.Cells["chIdActividad"].Value.ToString();
                            oDetalle.codigoLabor = item.Cells["chIdLabor"].Value.ToString();
                            oDetalle.puntoTomaAsistencia = "001";
                            oDetalle.numeroRegistroAsistencia = "1";
                            oDetalle.porcentajeAvance = 1;
                            oDetalle.tipoAsistencia = 'N';
                            oDetalle.horasDobles = 0;
                            oDetalle.HorasExtras25 = 0;
                            oDetalle.HorasExtras35 = 0;
                            oDetalle.totalHorasExtras = 0;
                            oDetalle.TotalHoras = Convert.ToDecimal(item.Cells["ch" + cc.codigoConsumidor.Trim()].Value);
                            oDetalle.fechaCreacion = DateTime.Now;
                            oDetalle.horasNocturnas = 0;
                            oDetalle.horasNocturnasExtras25 = 0;
                            oDetalle.horasNocturnasExtras35 = 0;
                            oDetalle.procesado = 0;
                            oDetalle.observacion = item.Cells["chObs"].Value.ToString();
                            oDetalles.Add(oDetalle);
                        }
                        #endregion
                    }
                }

                asistenciaNegocio = new AsistenciaNegocio();
                string resultado = asistenciaNegocio.GrabarAsistencia(Program.ClaseCompartida.periodoElegido, oCabecera, oDetalles, oDetallesEliminar);
                MessageBox.Show("Registrado correctamente", "CONFIRMACION DEL SISTEMA");
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }


        private void CargarCombosIniciales()
        {
            gbAsistencia.Enabled = false;
            gbDetalleAsistencia.Enabled = true;
            gbEmisor.Enabled = false;
            ProgressBarF.Visible = true;
            bwgHilo.RunWorkerAsync();

        }

        public void Inicio()
        {

            MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
            MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
            MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["BasesDatos" + Program.ClaseCompartida.periodoElegido.Substring(0, 4)];
            MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
            MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
            MyControlsDataBinding.Extensions.Globales.Empresa = "Exotics Producers Packers SAC";
            MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "EAURAZOC";
            MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "ERICK AURAZO";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }

        private void AgregarDetalle()
        {
            try
            {
                if (this.dgvDetalle != null)
                {
                    #region
                    ArrayList arraySubGrupo = new ArrayList();
                    foreach (DataGridViewColumn columna in this.dgvDetalle.Columns)
                    {
                        string cc = columna.HeaderText;
                        if (columna.Name == "chItem")
                        {
                            arraySubGrupo.Add(AsignarNumeroItemsGrilla(ultimoItemGrilla));
                        }
                        else if (columna.Name == "chCodigo")
                        {
                            arraySubGrupo.Add("");
                        }
                        else if (columna.Name == "chNombres")
                        {
                            arraySubGrupo.Add("");
                        }
                        else if (columna.Name == "chIdActividad")
                        {
                            arraySubGrupo.Add("");
                        }
                        else if (columna.Name == "chIdLabor")
                        {
                            arraySubGrupo.Add("");
                        }
                        else if (columna.Name == "chObs")
                        {
                            arraySubGrupo.Add("");
                        }
                        else if (columna.Name == "chLabor")
                        {
                            arraySubGrupo.Add(string.Empty);
                        }
                        else
                        {
                            arraySubGrupo.Add(Convert.ToDecimal(0));
                        }
                    }

                    this.AgregarCeldas(this.dgvDetalle, arraySubGrupo);
                    ultimoItemGrilla += 1;
                    #endregion
                }
                else
                {
                    Formateador.MostrarMensajeAdvertencia(this, "Haga click en la Grilla a Modificar", "Validacion Ingreso de Datos");
                }
            }
            catch (Exception ex)
            {
                Formateador.ControlExcepcion(this, this.Name, ex);
                return;
            }
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarDetalle();
        }

        private void QuitarDetalle()
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
                            foreach (Consumidor cc in ListaConsumidores)
                            {
                                if ((this.dgvDetalle.CurrentRow.Cells["ch" + cc.codigoConsumidor.Trim()].Value != null && this.dgvDetalle.CurrentRow.Cells["ch" + cc.codigoConsumidor.Trim()].Value.ToString() != string.Empty))
                                {
                                    MovimientoAsistenciaDetalle oDetalle = new MovimientoAsistenciaDetalle();
                                    oDetalle.codigoEmpresa = "001";
                                    oDetalle.codigoAsistencia = this.txtAsistenciaCodigoMovimiento.Text.Trim();
                                    oDetalle.item = (this.dgvDetalle.CurrentRow.Cells["chItem"].Value != null ? Convert.ToString(this.dgvDetalle.CurrentRow.Cells["chItem"].Value) : string.Empty);
                                    oDetalle.codigoPersona = (this.dgvDetalle.CurrentRow.Cells["chCodigo"].Value != null ? Convert.ToString(this.dgvDetalle.CurrentRow.Cells["chCodigo"].Value) : string.Empty);
                                    oDetalle.codigoConsumidor = cc.codigoConsumidor.Trim();
                                    oDetalle.codigoActividad = (this.dgvDetalle.CurrentRow.Cells["chIdActividad"].Value != null ? Convert.ToString(this.dgvDetalle.CurrentRow.Cells["chIdActividad"].Value) : string.Empty);
                                    oDetalle.codigoLabor = (this.dgvDetalle.CurrentRow.Cells["chIdLabor"].Value != null ? Convert.ToString(this.dgvDetalle.CurrentRow.Cells["chIdLabor"].Value) : string.Empty);
                                    oDetalle.puntoTomaAsistencia = "001";
                                    oDetalle.numeroRegistroAsistencia = "1";
                                    oDetalle.porcentajeAvance = 1;
                                    oDetalle.tipoAsistencia = 'N';
                                    oDetalle.horasDobles = 0;
                                    oDetalle.HorasExtras25 = 0;
                                    oDetalle.HorasExtras35 = 0;
                                    oDetalle.totalHorasExtras = 0;
                                    oDetalle.TotalHoras = Convert.ToDecimal(this.dgvDetalle.CurrentRow.Cells["ch" + cc.codigoConsumidor.Trim()].Value);
                                    oDetalle.fechaCreacion = DateTime.Now;
                                    oDetalle.horasNocturnas = 0;
                                    oDetalle.horasNocturnasExtras25 = 0;
                                    oDetalle.horasNocturnasExtras35 = 0;
                                    oDetalle.procesado = 0;
                                    oDetalle.observacion = "";
                                    oDetallesEliminar.Add(oDetalle);
                                }
                            }

                            dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
                        }
                        catch
                        {
                            Formateador.MostrarMensajeAdvertencia(this, "Seleccione un elemento de la grilla para eliminar ", "Validacion Ingreso de Datos");
                            return;
                        }
                    }
                    else
                    {
                        Formateador.MostrarMensajeAdvertencia(this, "Seleccione un elemento de la grilla para eliminar ", "Validacion Ingreso de Datos");
                    }
                }
                else
                {
                    Formateador.MostrarMensajeAdvertencia(this, "Haga click en la Grilla a Modificar", "Validacion Ingreso de Datos");
                }
                #endregion
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
