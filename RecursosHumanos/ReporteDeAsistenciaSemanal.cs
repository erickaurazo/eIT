using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using RecursosHumanos.Negocios;
using System.Configuration;
using System.Linq;
using RecursosHumanos.Datos;
using System.Collections;
using MyControlsDataBinding.Controles;
using System.Data;
using System.Drawing;
using DevSoftSolutionsControls;
using DevSoftSolutionsDataAccess;
using DevSoftSolutionsExtensions;
using MyControlsDataBinding.Extensions;

namespace RecursosHumanos
{
    public partial class ReporteDeAsistenciaSemanal : Form
    {
        string periodoConsulta = string.Empty;
        string codigoPlanilla = string.Empty;
        string semanaDesde = string.Empty;
        string semanaHasta = string.Empty;
        string periodoDesde = string.Empty;
        string periodoHasta = string.Empty;

        private string codigoUnicoAccesoSistema;
        private string codigoUsuario;
        private string codigoTipoPlanilla;
        private string semanaPlanilla;
        private List<ext_ObtenerListadoAsistenciaSemanalResult> listado;
        private AsistenciaNegocio modelo;
        private List<GrupoH> ListadoDiasSemanasConsulta;
        private PeriodoPlanillaNegocio modeloSemanas;
        private PeriodoPlanillaNegocio periodoPlanilla;
        private List<PlanillaPeriodo> ListaPeriodoPlanilla;
        private PeriodoPlanillaNegocio oPeriodoPlanillaNegocio;

        public ReporteDeAsistenciaSemanal()
        {
            InitializeComponent();
            Inicio();
        }

        public ReporteDeAsistenciaSemanal(string CodigoUnicoAccesoSistema, string CodigoUsuario, string CodigoTipoPlanilla, string SemanaPlanilla, string periodoElegido)
        {
            // TODO: Complete member initialization
            InitializeComponent();

            this.codigoUnicoAccesoSistema = CodigoUnicoAccesoSistema;
            this.codigoUsuario = CodigoUsuario;
            this.codigoTipoPlanilla = CodigoTipoPlanilla;
            this.semanaPlanilla = SemanaPlanilla;
            this.periodoElegido = periodoElegido;
            Program.ClaseCompartida.periodoElegido = this.periodoElegido;
            Program.ClaseCompartida.codigoTipoPlanilla = CodigoTipoPlanilla;
            Program.ClaseCompartida.semanaPlanilla = SemanaPlanilla;
            Inicio();
            CargarCombosPeriodoPlanilla();

        }

        public void Inicio()
        {

            MyControlsDataBinding.Extensions.Globales.Servidor = ConfigurationManager.AppSettings["Servidor"].ToString();
            MyControlsDataBinding.Extensions.Globales.UsuarioBaseDatos = ConfigurationManager.AppSettings["Usuario"].ToString();
            MyControlsDataBinding.Extensions.Globales.BaseDatos = ConfigurationManager.AppSettings["bd" + Program.ClaseCompartida.periodoElegido.Substring(0, 4)];
            MyControlsDataBinding.Extensions.Globales.ClaveBaseDatos = ConfigurationManager.AppSettings["Clave"].ToString();
            MyControlsDataBinding.Extensions.Globales.IdEmpresa = "001";
            MyControlsDataBinding.Extensions.Globales.Empresa = "Exotics Producers Packers SAC";
            MyControlsDataBinding.Extensions.Globales.UsuarioSistema = "EAURAZOC";
            MyControlsDataBinding.Extensions.Globales.NombreUsuarioSistema = "ERICK AURAZO";
        }

        private void CargarCombosPeriodoPlanilla()
        {
            periodoPlanilla = new PeriodoPlanillaNegocio();
            cboPeriodoPlanillaInicio.DisplayMember = "periodo";
            cboPeriodoPlanillaInicio.ValueMember = "periodo";
            cboPeriodoPlanillaInicio.DataSource = periodoPlanilla.ListarPeriodoPlanilla(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.codigoTipoPlanilla).ToList();
            cboPeriodoPlanillaInicio.SelectedValue = Program.ClaseCompartida.periodoElegido;
            CargarComboSemanasByNumeroMesInicio(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.codigoTipoPlanilla, Program.ClaseCompartida.periodoElegido.Substring(4, 2));
            cboSemanaPlanillaInicio.SelectedValue = Program.ClaseCompartida.semanaPlanilla;

            periodoPlanilla = new PeriodoPlanillaNegocio();
            cboPeriodoPlanillaTermino.DisplayMember = "periodo";
            cboPeriodoPlanillaTermino.ValueMember = "periodo";
            cboPeriodoPlanillaTermino.DataSource = periodoPlanilla.ListarPeriodoPlanilla(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.codigoTipoPlanilla).ToList();
            cboPeriodoPlanillaTermino.SelectedValue = Program.ClaseCompartida.periodoElegido;
            CargarComboSemanasByNumeroMesFinal(Program.ClaseCompartida.periodoElegido, Program.ClaseCompartida.codigoTipoPlanilla, Program.ClaseCompartida.periodoElegido.Substring(4, 2));
            cboSemanaPlanillaTermino.SelectedValue = Program.ClaseCompartida.semanaPlanilla;
        }

        private void CargarComboSemanasByNumeroMesInicio(string periodo, string idplanilla, string numeroDeMes)
        {

            ListaPeriodoPlanilla = new List<PlanillaPeriodo>();
            oPeriodoPlanillaNegocio = new PeriodoPlanillaNegocio();
            ListaPeriodoPlanilla = oPeriodoPlanillaNegocio.ListarPeriodoPlanillaPorCodigoPlanillaByNumeroDeMes(periodo, idplanilla, numeroDeMes).ToList();
            cboSemanaPlanillaInicio.DisplayMember = "semana";
            cboSemanaPlanillaInicio.ValueMember = "semana";
            cboSemanaPlanillaInicio.DataSource = ListaPeriodoPlanilla.ToList();
        }

        private void CargarComboSemanasByNumeroMesFinal(string periodo, string idplanilla, string numeroDeMes)
        {

            ListaPeriodoPlanilla = new List<PlanillaPeriodo>();
            oPeriodoPlanillaNegocio = new PeriodoPlanillaNegocio();
            ListaPeriodoPlanilla = oPeriodoPlanillaNegocio.ListarPeriodoPlanillaPorCodigoPlanillaByNumeroDeMes(periodo, idplanilla, numeroDeMes).ToList();
            cboSemanaPlanillaTermino.DisplayMember = "semana";
            cboSemanaPlanillaTermino.ValueMember = "semana";
            cboSemanaPlanillaTermino.DataSource = ListaPeriodoPlanilla.ToList();
        }

        private void bwgHilo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                listado = new List<ext_ObtenerListadoAsistenciaSemanalResult>();
                modelo = new AsistenciaNegocio();
                listado = modelo.ObtenerListadoAsistenciaSemanal(periodoConsulta, codigoPlanilla, semanaDesde, semanaHasta, periodoDesde, periodoHasta).ToList();
                modeloSemanas = new PeriodoPlanillaNegocio();

                /* Obtener días para las columnas */
                ListadoDiasSemanasConsulta = new List<GrupoH>();
                ListadoDiasSemanasConsulta = modeloSemanas.ObtenerListadoDeDiasBySemanas(periodoConsulta, codigoPlanilla, periodoDesde.Substring(0, 4), periodoDesde, semanaDesde).ToList();
                ListadoDiasSemanasConsulta.AddRange(modeloSemanas.ObtenerListadoDeDiasBySemanas(periodoConsulta, codigoPlanilla, periodoDesde.Substring(0, 4), periodoHasta, semanaHasta).ToList());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void bwgHilo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CrearEstructuraGrilla();
            MostrarInformacionGrilla();

            Pintar();

        }

        private void Pintar()
        {
            try
            {
                foreach (DataGridViewColumn item in dgvDetalle.Columns)
                {
                    if (item.ToolTipText.ToUpper().Trim() == "DOMINGO")
                    {

                        dgvDetalle.Columns[item.Index].DefaultCellStyle.ForeColor = Color.Green;
                        dgvDetalle.Columns[item.Index].DefaultCellStyle.BackColor = Color.Green;

                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "");
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

                //INGRESANDO COLUMNA ITEM
                //*****************************************************************************
                DataGridViewProperties propItem = new DataGridViewProperties();
                propItem.P_LongColumnaCorrelativa = 3;
                propItem.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Texto;
                propItem.P_EsAutocorrelativa = false;

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
                propCodigo.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Texto;
                propCodigo.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chCodigo = new DataGridViewTextBoxColumn();
                chCodigo.Tag = propCodigo;
                chCodigo.HeaderText = "Codigo";
                chCodigo.Name = "chCodigo";
                chCodigo.ToolTipText = "Código del trabajador";
                chCodigo.Frozen = true;
                chCodigo.ReadOnly = true;
                chCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chCodigo.Width = 80;
                chCodigo.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chCodigo);

                //*****************************************************************************
                //INGRESANDO COLUMNA nombres completos
                //*****************************************************************************
                DataGridViewProperties propNombres = new DataGridViewProperties();
                propNombres.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Texto;
                propNombres.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chNombres = new DataGridViewTextBoxColumn();
                chNombres.Tag = propNombres;
                chNombres.HeaderText = "Nombres";
                chNombres.Name = "chNombres";
                chNombres.ToolTipText = "Nombres del trabajador";
                chNombres.Frozen = true;
                chNombres.ReadOnly = true;
                chNombres.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chNombres.Width = 100;
                chNombres.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chNombres);

                //*****************************************************************************
                //INGRESANDO COLUMNA AFP
                //*****************************************************************************
                DataGridViewProperties propAFP = new DataGridViewProperties();
                propAFP.P_LongColumnaCorrelativa = 0;
                propAFP.P_EsBusqueda = false;
                propAFP.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Texto;
                propAFP.P_EsAutocorrelativa = false;


                DataGridViewComboBoxColumn chAFP = new DataGridViewComboBoxColumn();
                chAFP.Tag = propAFP;
                chAFP.HeaderText = "AFP";
                chAFP.Name = "chAFP";
                chAFP.Frozen = true;
                chAFP.ReadOnly = true;
                chAFP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chAFP.Width = 70;
                chAFP.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                chAFP.Visible = false;
                pGrilla.Columns.Add(chAFP);

                //*****************************************************************************
                //INGRESANDO COLUMNA ESTATICA CARGO
                //*****************************************************************************
                DataGridViewProperties propCargo = new DataGridViewProperties();
                propCargo.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Texto;
                propCargo.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chCargo = new DataGridViewTextBoxColumn();
                chCargo.Tag = propCargo;
                chCargo.HeaderText = "Cargo";
                chCargo.Name = "chCargo";
                chCargo.Frozen = true;
                chCargo.ReadOnly = true;
                chCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chCargo.Width = 90;
                chCargo.Visible = false;
                chCargo.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chCargo);



                //Lista de solo consumidores
                var ListaFechas = (from items in ListadoDiasSemanasConsulta
                                   group items by items.Codigo into j
                                   select new GrupoH
                                   {
                                       Codigo = j.Key,
                                       Descripcion = j.FirstOrDefault().Descripcion,
                                   }).ToList();


                foreach (GrupoH cc in ListaFechas)
                {
                    DataGridViewProperties propCC = new DataGridViewProperties();
                    propCC.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Decimal;
                    propCC.P_EsBusqueda = false;
                    propCC.P_EsAutocorrelativa = false;

                    DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                    columna.Tag = propCC;
                    columna.HeaderText = cc.Codigo.Trim();
                    columna.Tag = cc.Descripcion.Trim();
                    columna.Name = "ch" + cc.Codigo.Trim();
                    columna.ToolTipText = cc.Descripcion.Trim();
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    columna.Width = 80;
                    columna.ReadOnly = true;
                    columna.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                    pGrilla.Columns.Add(columna);
                }


                //*****************************************************************************
                //INGRESANDO COLUMNA Total Horas
                //*****************************************************************************
                DataGridViewProperties propTotalHoras = new DataGridViewProperties();
                propTotalHoras.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Decimal;
                propTotalHoras.P_EsBusqueda = false;
                propTotalHoras.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chTotalHoras = new DataGridViewTextBoxColumn();
                chTotalHoras.Tag = propTotalHoras;
                chTotalHoras.HeaderText = "Total Horas";
                chTotalHoras.Name = "chTotalHoras";
                chTotalHoras.Frozen = false;
                chTotalHoras.ReadOnly = true;
                chTotalHoras.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chTotalHoras.Width = 70;
                chTotalHoras.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chTotalHoras);




                //*****************************************************************************
                //INGRESANDO COLUMNA DIAS TRABAJADOS
                //*****************************************************************************
                DataGridViewProperties propDiasTrabajados = new DataGridViewProperties();
                propDiasTrabajados.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Entero;
                propDiasTrabajados.P_EsBusqueda = false;
                propDiasTrabajados.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chDiasTrabajados = new DataGridViewTextBoxColumn();
                chDiasTrabajados.Tag = propDiasTrabajados;
                chDiasTrabajados.HeaderText = "Dias Trab";
                chDiasTrabajados.Name = "chDiasTrabajados";
                chDiasTrabajados.Frozen = false;
                chDiasTrabajados.ReadOnly = true;
                chDiasTrabajados.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chDiasTrabajados.Width = 70;
                chDiasTrabajados.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chDiasTrabajados);




                //*****************************************************************************
                //INGRESANDO COLUMNA chDiasFalta
                //*****************************************************************************
                DataGridViewProperties propDiasFalta = new DataGridViewProperties();
                propDiasFalta.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Entero;
                propDiasFalta.P_EsBusqueda = false;
                propDiasFalta.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chDiasFalta = new DataGridViewTextBoxColumn();
                chDiasFalta.Tag = propDiasFalta;
                chDiasFalta.HeaderText = "Días Falta";
                chDiasFalta.Name = "chDiasFalta";
                chDiasFalta.Frozen = false;
                chDiasFalta.ReadOnly = true;
                chDiasFalta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chDiasFalta.Width = 70;
                chDiasFalta.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chDiasFalta);




                //*****************************************************************************
                //INGRESANDO COLUMNA DiasDescanzo
                //*****************************************************************************
                DataGridViewProperties propDiasDescanzo = new DataGridViewProperties();
                propDiasDescanzo.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Entero;
                propDiasDescanzo.P_EsBusqueda = false;
                propDiasDescanzo.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chDiasDescanzo = new DataGridViewTextBoxColumn();
                chDiasDescanzo.Tag = propDiasDescanzo;
                chDiasDescanzo.HeaderText = "Días Descanzo";
                chDiasDescanzo.Name = "chDiasDescanzo";
                chDiasDescanzo.Frozen = false;
                chDiasDescanzo.ReadOnly = true;
                chDiasDescanzo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chDiasDescanzo.Width = 70;
                chDiasDescanzo.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chDiasDescanzo);




                //*****************************************************************************
                //INGRESANDO COLUMNA chDiasFalta
                //*****************************************************************************
                DataGridViewProperties propDiasVacaciones = new DataGridViewProperties();
                propDiasVacaciones.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Entero;
                propDiasVacaciones.P_EsBusqueda = false;
                propDiasVacaciones.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chDiasVacaciones = new DataGridViewTextBoxColumn();
                chDiasVacaciones.Tag = propDiasVacaciones;
                chDiasVacaciones.HeaderText = "Días Vac.";
                chDiasVacaciones.Name = "chDiasVacaciones";
                chDiasVacaciones.Frozen = false;
                chDiasVacaciones.ReadOnly = true;
                chDiasVacaciones.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chDiasVacaciones.Width = 70;
                chDiasVacaciones.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chDiasVacaciones);



                //*****************************************************************************
                //INGRESANDO COLUMNA HorasNormales
                //*****************************************************************************
                DataGridViewProperties propHorasNormales = new DataGridViewProperties();
                propHorasNormales.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Decimal;
                propHorasNormales.P_EsBusqueda = false;
                propHorasNormales.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chHorasNormales = new DataGridViewTextBoxColumn();
                chHorasNormales.Tag = propHorasNormales;
                chHorasNormales.HeaderText = "Horas Normales";
                chHorasNormales.Name = "chHorasNormales";
                chHorasNormales.Frozen = false;
                chHorasNormales.ReadOnly = true;
                chHorasNormales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chHorasNormales.Width = 70;
                chHorasNormales.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chHorasNormales);




                //*****************************************************************************
                //INGRESANDO COLUMNA Horas25
                //*****************************************************************************
                DataGridViewProperties propHoras25 = new DataGridViewProperties();
                propHoras25.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Decimal;
                propHoras25.P_EsBusqueda = false;
                propHoras25.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chHoras25 = new DataGridViewTextBoxColumn();
                chHoras25.Tag = propHoras25;
                chHoras25.HeaderText = "Horas 25";
                chHoras25.Name = "chHoras25";
                chHoras25.Frozen = false;
                chHoras25.ReadOnly = true;
                chHoras25.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chHoras25.Width = 70;
                chHoras25.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chHoras25);




                //*****************************************************************************
                //INGRESANDO COLUMNA Horas35
                //*****************************************************************************
                DataGridViewProperties propHoras35 = new DataGridViewProperties();
                propHoras35.P_TipoDato = DevSoftSolutionsExtensions.EnumTipoDato.Decimal;
                propHoras35.P_EsBusqueda = false;
                propHoras35.P_EsAutocorrelativa = false;

                DataGridViewTextBoxColumn chHoras35 = new DataGridViewTextBoxColumn();
                chHoras35.Tag = propHoras35;
                chHoras35.HeaderText = "Horas 35";
                chHoras35.Name = "chHoras35";
                chHoras35.Frozen = false;
                chHoras35.ReadOnly = true;
                chHoras35.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                chHoras35.Width = 70;
                chHoras35.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular);
                pGrilla.Columns.Add(chHoras35);


                #endregion

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Crear vista del reporte");
                return;
            }
        }

        public void MostrarInformacionGrilla()
        {
            try
            {
                #region Grupo de Trabajadores x Labor y Act.

                var trabajadores = (from items in listado
                                    group items by new
                                    {
                                        items.codigoPersona,
                                    } into j
                                    select new GrupoH
                                    {
                                        Codigo = j.Key.codigoPersona,
                                        Descripcion = j.FirstOrDefault().nombresCompletos.Trim(),
                                        afp = string.Empty,
                                        cargo = string.Empty,

                                    }).ToList();



                int numeroOrden = 1;
                foreach (GrupoH personal in trabajadores)
                {
                    var asistenciaByPersonal = listado.Where(x => x.codigoPersona == personal.Codigo).ToList();
                    List<ArrayList> ListaArrayPersonal = new List<ArrayList>();
                    ArrayList arraySubGrupo = new ArrayList();

                    var nroSemanasAsistencia = (from items in listado.Where(x => x.codigoPersona == personal.Codigo)
                                                group items by new
                                                {
                                                    items.semana,
                                                } into j
                                                select new GrupoH
                                                {
                                                    Codigo = j.Key.semana,
                                                }).ToList();

                    var nroHorasPersonaDiaDomingo = listado.Where(x => x.codigoPersona == personal.Codigo && x.nombreDia.ToUpper() == "DOMINGO").ToList();


                    foreach (DataGridViewColumn columna in this.dgvDetalle.Columns)
                    {
                        string cc = columna.HeaderText;
                        //if (columna.Name == "chCorrelativo")
                        //{
                        //    arraySubGrupo.Add(personal.correlativo);
                        //}

                        if (columna.Name == "chItem")
                        {
                            arraySubGrupo.Add((numeroOrden).ToString().PadLeft(3, '0'));
                        }
                        else if (columna.Name == "chCodigo")
                        {
                            arraySubGrupo.Add(personal.Codigo);
                        }
                        else if (columna.Name == "chNombres")
                        {
                            arraySubGrupo.Add(personal.Descripcion);
                        }
                        else if (columna.Name == "chAFP")
                        {
                            arraySubGrupo.Add(personal.afp);
                        }
                        else if (columna.Name == "chCargo")
                        {
                            arraySubGrupo.Add(personal.cargo);
                        }

                        else if (columna.Name == "chTotalHoras")
                        {
                            List<ext_ObtenerListadoAsistenciaSemanalResult> horasByDia = asistenciaByPersonal.ToList();
                            if (horasByDia != null)
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(horasByDia.Sum(x => x.totalHoras)));
                            }
                            else
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(0));
                            }
                        }
                        else if (columna.Name == "chDiasTrabajados")
                        {
                            List<ext_ObtenerListadoAsistenciaSemanalResult> horasByDia = asistenciaByPersonal.ToList();
                            if (horasByDia != null)
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(horasByDia.Count().ToString()));
                            }
                            else
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(0));
                            }
                        }
                        else if (columna.Name == "chDiasFalta")
                        {
                            arraySubGrupo.Add(0.00);
                        }
                        else if (columna.Name == "chDiasDescanzo")
                        {
                            arraySubGrupo.Add(0.00);
                        }
                        else if (columna.Name == "chDiasVacaciones")
                        {
                            arraySubGrupo.Add(0.00);
                        }
                        else if (columna.Name == "chHorasNormales")
                        {
                            decimal NumeroHorasPermitidoBySemana = nroSemanasAsistencia.Count * 48;
                            decimal? HorasTrabajadasSegunListado = asistenciaByPersonal.Sum(x => x.totalHoras);

                            if (HorasTrabajadasSegunListado < NumeroHorasPermitidoBySemana)
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(asistenciaByPersonal.Sum(x => x.totalHoras)));
                            }
                            else if (HorasTrabajadasSegunListado > NumeroHorasPermitidoBySemana)
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(NumeroHorasPermitidoBySemana));
                            }
                            else
                            {
                                arraySubGrupo.Add(0.00);
                            }


                        }
                        else if (columna.Name == "chHoras25")
                        {
                            /* Si la suma de los días por semana esta entre los 48 y 60 sin incluir domingos y feriados entonces es horas extras al 25 */

                            decimal? totalHorasTrabajadasByListado = asistenciaByPersonal.Sum(x => x.totalHoras);
                            decimal? totalHorasDomingo = nroHorasPersonaDiaDomingo.Sum(x => x.totalHoras.Value);
                            decimal? horasNetas = totalHorasTrabajadasByListado - totalHorasDomingo;
                            decimal? nroSemanasIncluidas = nroSemanasAsistencia.Count;
                            decimal? factorMaximo25 = 60 * nroSemanasAsistencia.Count;
                            decimal? factorMinimo25 = 48 * nroSemanasAsistencia.Count;

                            if (horasNetas > factorMinimo25 && horasNetas <= factorMaximo25)
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(horasNetas - factorMinimo25));
                            }
                            else
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(0.00));
                            }

                        }
                        else if (columna.Name == "chHoras35")
                        {
                            /* Si la suma de los días por semana esta pasa 60 sin incluir domingos y feriados entonces es horas extras al 35 */
                            decimal? totalHorasTrabajadasByListado = asistenciaByPersonal.Sum(x => x.totalHoras);
                            decimal? totalHorasDomingo = nroHorasPersonaDiaDomingo.Sum(x => x.totalHoras.Value);
                            decimal? horasNetas = totalHorasTrabajadasByListado - totalHorasDomingo;
                            decimal? nroSemanasIncluidas = nroSemanasAsistencia.Count;
                            decimal? factorMaximo35 = 192 * nroSemanasAsistencia.Count;
                            decimal? factorMinimo35 = 61 * nroSemanasAsistencia.Count;

                            if (horasNetas > factorMinimo35 && horasNetas <= factorMaximo35)
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(horasNetas - factorMinimo35));
                            }
                            else
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(0.00));
                            }
                        }
                        else if (columna.Name == "ch" + cc.Trim())
                        {
                            ext_ObtenerListadoAsistenciaSemanalResult horasByDia = asistenciaByPersonal.Where(x => x.fecha.Value.ToShortDateString().Trim() == cc.Trim()).FirstOrDefault();
                            if (horasByDia != null)
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(horasByDia.totalHoras.Value));
                            }
                            else
                            {
                                arraySubGrupo.Add(Convert.ToDecimal(0.0));
                            }
                        }
                        else
                        {
                            arraySubGrupo.Add(Convert.ToDecimal(0.0));
                        }
                    }
                    this.AgregarCeldas(this.dgvDetalle, arraySubGrupo);
                    numeroOrden = numeroOrden + 1;
                }
                #endregion
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message.ToString(), "Mostrar resultados");
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
                        #region
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
                                Row.Cells[x].Style.BackColor = DevSoftSolutionsExtensions.Utiles.colorAmarilloClaro;

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
                        #endregion
                    }


                }
                rc.Rows.Add(Row);
                return x;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Agregando fila al reporte");
                return x;
            }
        }


        private void ReporteDeAsistenciaSemanal_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            periodoConsulta = Program.ClaseCompartida.periodoElegido;
            codigoPlanilla = this.txtPlanillaCodigo.Text;
            semanaDesde = cboSemanaPlanillaInicio.SelectedValue.ToString();
            semanaHasta = cboSemanaPlanillaTermino.SelectedValue.ToString();
            periodoDesde = cboPeriodoPlanillaInicio.SelectedValue.ToString();
            periodoHasta = cboPeriodoPlanillaTermino.SelectedValue.ToString();
            btnConsultar.Enabled = !true;
            gbCabeceraConsulta.Enabled = !true;
            ProgressBar.Visible = true;
            btnConsultar.Enabled = true;
            gbCabeceraConsulta.Enabled = true;
            ProgressBar.Visible = !true;
            bwgHilo.RunWorkerAsync();
        }

        public string periodoElegido { get; set; }

        private void cboPeriodoPlanillaInicio_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboPeriodoPlanillaInicio.SelectedIndex >= 0)
            {

                CargarComboSemanasByNumeroMesInicio(cboPeriodoPlanillaInicio.SelectedValue.ToString(), Program.ClaseCompartida.codigoTipoPlanilla, cboPeriodoPlanillaInicio.SelectedValue.ToString().Substring(4, 2));



            }
        }

        private void cboPeriodoPlanillaTermino_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cboPeriodoPlanillaTermino.SelectedIndex >= 0)
            {

                CargarComboSemanasByNumeroMesFinal(cboPeriodoPlanillaTermino.SelectedValue.ToString(), Program.ClaseCompartida.codigoTipoPlanilla, cboPeriodoPlanillaTermino.SelectedValue.ToString().Substring(4, 2));

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            btnConsultar.Enabled = !true;
            gbCabeceraConsulta.Enabled = !true;
            ProgressBar.Visible = true;
            gbCabeceraConsulta.Enabled = true;
            gbDetalle.Enabled = false;
            menuPrincipal.Enabled = false;
            dgvDetalle.Enabled = false;
            bwgExportar.RunWorkerAsync();
        }

        private void bwgExportar_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.dgvDetalle.Rows.Count > 0)
            {
                //Seguir
            }
            else
            {

            }
        }

        private void bwgExportar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (this.dgvDetalle.Rows.Count > 0)
                {
                    //UtilControles.ExportarDataTableExcel();
                    DevSoftSolutionsExtensions.Utiles.ExportarDataGridViewExcel(this.dgvDetalle, "Registro de asistencia");
                    btnConsultar.Enabled = true;
                    gbCabeceraConsulta.Enabled = true;
                    ProgressBar.Visible = false;
                    ProgressBar.Visible = false;
                    gbDetalle.Enabled = !false;
                    dgvDetalle.Enabled = true;
                    menuPrincipal.Enabled = !false;
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }


        }
    }
}
