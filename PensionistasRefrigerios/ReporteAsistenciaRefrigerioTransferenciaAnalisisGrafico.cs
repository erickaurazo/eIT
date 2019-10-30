using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.ViewModels;
using Telerik.WinControls.UI;
using Telerik.Pivot.Core.Aggregates;
using TransportistaMto.Datos;
using Transportista.Negocios;
using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;
using Telerik.WinControls.UI.Export;
using System.IO;
using Telerik.WinControls.UI.Localization;
using System.Globalization;
using Telerik.Charting;
using TransportistaMto.Datos;

namespace Transportista
{
    public partial class ReporteAsistenciaRefrigerioTransferenciaAnalisisGrafico : Telerik.WinControls.UI.RadForm
    {
        private List<SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupadoResult> listadoAsistenciaTransferenciaMovilPensionAgrupado;

        private CartesianGridLineAnnotation googleAverage;
        private SJ_RHPensionNegocio modeloCasaPension;
        private SJ_RHPension oSJ_RHPension;
        private SJ_SemanaNegocio modeloSemana;
        private SJ_Semana oSemana;
        private SJ_Semana oSemanaConsulta;

        public ReporteAsistenciaRefrigerioTransferenciaAnalisisGrafico()
        {
            InitializeComponent();
            ObtenerFechasIniciales();
            CargarMeses();
        }



        private void CargarMeses()
        {
            Mes Meses = new Mes();

            cboMes.DisplayMember = "descripcion";
            cboMes.ValueMember = "valor";
            //cboMes.DataSource = Meses.ListarMeses().Where(x => x.Valor != "13" && x.Valor != "00").ToList();
            cboMes.DataSource = Meses.ListarMeses().ToList();
            cboMes.SelectedValue = DateTime.Now.ToString("MM");
        }

        private void ObtenerFechasIniciales()
        {
            this.txtPeriodo.Text = DateTime.Now.Year.ToString();
            this.txtFechaDesde.Text = "01" + DateTime.Now.ToShortDateString().Substring(3, 7);
            this.txtFechaHasta.Text = DateTime.Now.ToShortDateString();


            modeloSemana = new SJ_SemanaNegocio();
            oSemana = new SJ_Semana();
            oSemanaConsulta = new SJ_Semana();
            oSemana.año = Convert.ToInt32(this.txtPeriodo.Value);
            oSemana.semana = Convert.ToInt32(this.txtSemana.Value);

            oSemanaConsulta = modeloSemana.ObtenerSemanaPorNroSemana(oSemana);


            int numeroSemana = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DateTime.Now.DayOfWeek) - 1;
            txtSemana.Value = numeroSemana;

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

        public ReporteAsistenciaRefrigerioTransferenciaAnalisisGrafico(List<SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupadoResult> listadoAsistenciaTransferenciaMovilPensionAgrupado, oFechaAsistencia datosConsulta)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            ObtenerFechasIniciales();
            CargarMeses();

            this.txtPeriodo.Value = datosConsulta.anio;
            this.txtSemana.Value = datosConsulta.numeroSemana;
            cboMes.SelectedValue = datosConsulta.numeroMes != null ? datosConsulta.numeroMes.ToString().Trim() : string.Empty;
            this.txtFechaDesde.Text = datosConsulta.fechaDesde;
            this.txtFechaHasta.Text = datosConsulta.fechaHasta;

            this.listadoAsistenciaTransferenciaMovilPensionAgrupado = listadoAsistenciaTransferenciaMovilPensionAgrupado;

            if (this.listadoAsistenciaTransferenciaMovilPensionAgrupado != null && this.listadoAsistenciaTransferenciaMovilPensionAgrupado.Where(x => x.NombresTrabajador.Trim() != "DESCONOCIDO").ToList().Count > 0)
            {
                var resultadoConsulta = this.listadoAsistenciaTransferenciaMovilPensionAgrupado.Where(x => x.NombresTrabajador.Trim() != "DESCONOCIDO").ToList();
                PresentarComboCasaPension(resultadoConsulta);
                InicializarGrafico(resultadoConsulta);

            }
        }

        private void PresentarComboCasaPension(List<SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupadoResult> listado)
        {
            try
            {
                var nrosDniCasaPension = (from dni in listado
                                          where dni.dnipension != null && dni.NombresPension.Trim() != "" && dni.NombresTrabajador.Trim() != "DESCONOCIDO"
                                          group dni by new { dni.dnipension } into j
                                          select new
                                          {
                                              codigo = j.Key.dnipension.Trim(),
                                              descipcion = j.FirstOrDefault().NombresPension != null ? j.FirstOrDefault().NombresPension.Trim() : "",
                                          }
                                             ).ToList();



                string nombrePension = "";

                if (nrosDniCasaPension != null && nrosDniCasaPension.ToList().Count > 0)
                {
                    foreach (var item in nrosDniCasaPension)
                    {
                        nombrePension += item.descipcion + ";";
                    }


                    radCheckedDropDownList1.DisplayMember = "descipcion";
                    radCheckedDropDownList1.ValueMember = "codigo";
                    radCheckedDropDownList1.DataSource = nrosDniCasaPension.ToList();


                    for (int i = 0; i < radCheckedDropDownList1.CheckedItems.Count; i++)
                    {
                        radCheckedDropDownList1.CheckedItems[i].Checked = true;
                    }

                    if (nombrePension != "")
                    {
                        radCheckedDropDownList1.Text = nombrePension;
                    }

                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "MENSAJE DEL SISTEMA");
                return;
            }
        }

        private void ReporteAsistenciaRefrigerioTransferenciaAnalisisGrafico_Load(object sender, EventArgs e)
        {

        }

        private void InicializarGrafico(List<SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupadoResult> listado)
        {
            this.radChartView1.Series.Clear();
            string dnipension = string.Empty;
            /*Obtener todos los dias agrupados*/
            var fechasRegistro = (from oFecha in listado.OrderBy(x => x.fecha.Value)
                                  where oFecha.fecha != null
                                  group oFecha by new { oFecha.fecha } into j
                                  select new
                                  {
                                      codigo = j.Key.fecha.Value.ToPresentationDate(),
                                      fecha = j.Key.fecha.Value,
                                  }).ToList();

            /* Obtener  */
            for (int i = 0; i < radCheckedDropDownList1.CheckedItems.Count; i++)
            {
                if (radCheckedDropDownList1.CheckedItems[i].Checked == true)
                {
                    LineSeries series = new LineSeries();
                    dnipension = radCheckedDropDownList1.Items[radCheckedDropDownList1.CheckedItems[i].Index].Value.ToString().Trim();
                    var resultadoConsulta2 = listado.Where(x => x.dnipension.Trim() == dnipension).ToList();

                    foreach (var item in fechasRegistro)
                    {
                        oClaseGeneral abc = new oClaseGeneral();
                        var resultadoConsulta = listado.Where(x => x.fecha.Value == item.fecha && x.dnipension.Trim() == dnipension).ToList();
                        int nroAsistenciaByDia = 0;

                        if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                        {
                            nroAsistenciaByDia = resultadoConsulta.GroupBy(x=> x.dniTrabajador).ToList().Count;
                        }

                        series.DataPoints.Add(new CategoricalDataPoint(nroAsistenciaByDia, item.codigo.Substring(0, 5)));
                        series.Name = resultadoConsulta2.FirstOrDefault().NombresPension.Trim();
                        series.ShowLabels = true;
                        series.ValueMember = resultadoConsulta2.FirstOrDefault().NombresPension.Trim();
                        series.LegendTitle = resultadoConsulta2.FirstOrDefault().NombresPension.Trim();


                    }
                    this.radChartView1.Series.Add(series);

                }
            }

            CartesianArea area = this.radChartView1.GetArea<CartesianArea>();
            area.ShowGrid = true;


            CartesianGrid grid = area.GetGrid<CartesianGrid>();

            grid.DrawHorizontalFills = true;
            grid.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

            radChartView1.ShowLegend = true;
            radChartView1.ShowSmartLabels = true;
            radChartView1.ShowTitle = true;




            this.googleAverage = new CartesianGridLineAnnotation();

            if (radChartView1.Series.Count > 1)
            {
                this.radChartView1.Area.Annotations.Clear();
                this.googleAverage = new CartesianGridLineAnnotation((CartesianAxis)this.radChartView1.Axes[1], 60);
                this.googleAverage.BorderColor = Color.LimeGreen; this.googleAverage.BorderWidth = 2;
                this.googleAverage.Label = "60 promedio";
                this.googleAverage.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                this.radChartView1.Area.Annotations.Add(this.googleAverage);
            }
            else if (radChartView1.Series.Count == 1)
            {
                this.radChartView1.Area.Annotations.Clear();
                if (dnipension != "")
                {
                    modeloCasaPension = new SJ_RHPensionNegocio();
                    oSJ_RHPension = new SJ_RHPension();

                    oSJ_RHPension = modeloCasaPension.ObtenerInformacionCasaPension(dnipension);
                    if (oSJ_RHPension != null && oSJ_RHPension.IdPension != null && oSJ_RHPension.capacidadAtencion.Value != null)
                    {
                        this.googleAverage = new CartesianGridLineAnnotation((CartesianAxis)this.radChartView1.Axes[1], oSJ_RHPension.capacidadAtencion.Value);
                        this.googleAverage.BorderColor = Color.LimeGreen; this.googleAverage.BorderWidth = 2;
                        this.googleAverage.Label = oSJ_RHPension.capacidadAtencion.Value.ToString() + " capacidad de atención";
                        this.googleAverage.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        this.radChartView1.Area.Annotations.Add(this.googleAverage);
                    }
                }
                else
                {
                    this.googleAverage = new CartesianGridLineAnnotation();
                    this.radChartView1.Area.Annotations.Clear();
                }

            }



        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            InicializarGrafico(this.listadoAsistenciaTransferenciaMovilPensionAgrupado);
        }

    }
}
