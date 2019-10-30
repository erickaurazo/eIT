using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using System.Configuration;
using System.Transactions;
using RecursosHumanos.Datos;
using MyControlsDataBinding.Extensions;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.ControlesUsuario;
using System.Globalization;

namespace RecursosHumanos.Negocios
{
    public class PeriodoPlanillaNegocio
    {
        private string oConexion;

        public List<PERIODO_PLANILLA> ObtenerSemanaPlanillaRRHHByFechaByCodigoPlanilla(string fecha, string planillaCodigo, string periodo)
        {
            List<PERIODO_PLANILLA> listado = new List<PERIODO_PLANILLA>();

            string cnx = string.Empty;
            cnx = System.Configuration.ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();

            using (RecursosHumanosDataContext contexto = new RecursosHumanosDataContext(cnx))
            {
                contexto.CommandTimeout = 9000;

                string ABC = fecha.Substring(6, 4);

                listado = (
                    from item in contexto.PERIODO_PLANILLA.ToList()
                    where item.IDPLANILLA.Trim() == planillaCodigo
                    && item.ANIO.Trim() == ABC
                    && item.FECHA_INI <= Convert.ToDateTime(fecha)
                    && item.FECHA_FIN >= Convert.ToDateTime(fecha)
                    group item by new
                    {
                        item.IDPLANILLA,
                        item.SEMANA,
                        item.ANIO,
                        item.PERIODO
                    }
                        into j
                        select new PERIODO_PLANILLA
                        {
                            IDPLANILLA = j.Key.IDPLANILLA,
                            ANIO = j.Key.ANIO,
                            PERIODO = j.Key.PERIODO,
                            SEMANA = j.Key.SEMANA,
                            FECHA_INI = j.FirstOrDefault().FECHA_INI,
                            FECHA_FIN = j.FirstOrDefault().FECHA_FIN,

                        }).ToList();

                contexto.Connection.Close();
                contexto.Dispose();

            }
            return listado;

        }

        public List<PlanillaPeriodo> ListarPeriodoPlanillaPorCodigoPlanilla(string fecha, string planillaCodigo, string periodo)
        {
            List<PlanillaPeriodo> listado = new List<PlanillaPeriodo>();

            string cnx = string.Empty;
            cnx = System.Configuration.ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                contexto.CommandTimeout = 9000;

                string anioDePlanilla = fecha.Substring(6, 4);

                listado = (
                    from item in contexto.PlanillaPeriodo.ToList()
                    where item.CodigoPlanilla.Trim() == planillaCodigo
                    && item.anio.Trim() == anioDePlanilla
                    && item.periodo.Trim() == anioDePlanilla + fecha.Substring(3, 2)
                    group item by new
                    {
                        item.CodigoPlanilla,
                        item.semana,
                        item.anio,
                        item.periodo
                    }
                        into j
                        select new PlanillaPeriodo
                        {
                            CodigoPlanilla = j.Key.CodigoPlanilla,
                            anio = j.Key.anio,
                            periodo = j.Key.periodo,
                            semana = j.Key.semana,
                            fechaInicio = j.FirstOrDefault().fechaInicio,
                            fechaFinal = j.FirstOrDefault().fechaFinal,

                        }).ToList();

                contexto.Connection.Close();
                contexto.Dispose();

            }
            return listado;

        }

        public PlanillaPeriodo ObtenerSemanaByPlanilla(string fecha, string planillaCodigo, string periodo)
        {
            #region Ejecutar Consulta()

            PlanillaPeriodo oPeriodoPlanilla = new PlanillaPeriodo();
            string cnx = string.Empty;
            cnx = System.Configuration.ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();
            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                contexto.CommandTimeout = 9000;

                string anioDePlanilla = fecha.Substring(6, 4);

                var resultadoSubConsulta = contexto.PlanillaPeriodo.Where(x => x.CodigoPlanilla == planillaCodigo && x.fechaInicio <= Convert.ToDateTime(fecha) && x.fechaFinal >= Convert.ToDateTime(fecha)).ToList();

                if (resultadoSubConsulta.ToList().Count > 0)
                {
                    oPeriodoPlanilla = (
                    from item in contexto.PlanillaPeriodo.OrderByDescending(x => x.semana).ToList()
                    where item.CodigoPlanilla.Trim() == planillaCodigo
                    //&& item.anio.Trim() == anioDePlanilla
                    && item.fechaInicio <= Convert.ToDateTime(fecha)
                    && item.fechaFinal >= Convert.ToDateTime(fecha)
                    group item by new
                    {
                        item.CodigoPlanilla,
                        item.semana,
                        item.anio,
                        item.periodo
                    }
                        into j
                        select new PlanillaPeriodo
                        {
                            CodigoPlanilla = j.Key.CodigoPlanilla,
                            anio = j.Key.anio,
                            periodo = j.Key.periodo,
                            semana = j.Key.semana,
                            fechaInicio = j.FirstOrDefault().fechaInicio,
                            fechaFinal = j.FirstOrDefault().fechaFinal,
                        }).Single();
                }

                

                contexto.Connection.Close();
                contexto.Dispose();

            }
            #endregion
            return oPeriodoPlanilla;

        }

        public PlanillaPeriodo ObtenerSemanaByPlanillaByNumeroDeSemana(string periodo, string planillaCodigo, string semana)
        {
            #region Ejecutar Consulta()

            PlanillaPeriodo oPeriodoPlanilla = new PlanillaPeriodo();
            //oPeriodoPlanilla.semana = "";
            //oPeriodoPlanilla.periodo = periodo;
            //oPeriodoPlanilla.fechaInicio = DateTime.Now;
            //oPeriodoPlanilla.fechaFinal = DateTime.Now;
            //oPeriodoPlanilla.CodigoPlanilla = planillaCodigo;

            string cnx = string.Empty;
            cnx = System.Configuration.ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();
            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                contexto.CommandTimeout = 9000;

                string anioDePlanilla = periodo;

                if (semana.Trim() != "")
                {
                    oPeriodoPlanilla = (
                        from item in contexto.PlanillaPeriodo.ToList()
                        where item.CodigoPlanilla.Trim() == planillaCodigo
                        && item.anio.Trim() == anioDePlanilla
                        && item.semana.Trim() == semana.Trim()
                        && semana != ""
                        group item by new
                        {
                            item.CodigoPlanilla,
                            item.semana,
                            item.anio,
                            item.periodo
                        }
                            into j
                            select new PlanillaPeriodo
                            {
                                CodigoPlanilla = j.Key.CodigoPlanilla,
                                anio = j.Key.anio,
                                periodo = j.Key.periodo,
                                semana = j.Key.semana,
                                fechaInicio = j.FirstOrDefault().fechaInicio,
                                fechaFinal = j.FirstOrDefault().fechaFinal,

                            }).Single();
                }
                contexto.Connection.Close();
                contexto.Dispose();
                return oPeriodoPlanilla;
            }

            #endregion
        }

        public List<PlanillaPeriodo> ListarPeriodoPlanillaPorCodigoPlanillaByNumeroDeMes(string periodo, string planillaCodigo, string numeroDeMes)
        {
            List<PlanillaPeriodo> listado = new List<PlanillaPeriodo>();

            string cnx = string.Empty;
            cnx = System.Configuration.ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();

            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                contexto.CommandTimeout = 9000;

                string anioDePlanilla = periodo;

                listado = (
                    from item in contexto.PlanillaPeriodo.ToList()
                    where item.CodigoPlanilla.Trim() == planillaCodigo
                    && item.anio.Trim() == anioDePlanilla.Substring(0,4)
                    && item.periodo.Trim() == periodo.Substring(0,4) + numeroDeMes
                    group item by new
                    {
                        item.CodigoPlanilla,
                        item.semana,
                        item.anio,
                        item.periodo
                    }
                        into j
                        select new PlanillaPeriodo
                        {
                            CodigoPlanilla = j.Key.CodigoPlanilla,
                            anio = j.Key.anio,
                            periodo = j.Key.periodo,
                            semana = j.Key.semana,
                            fechaInicio = j.FirstOrDefault().fechaInicio,
                            fechaFinal = j.FirstOrDefault().fechaFinal,

                        }).ToList();

                contexto.Connection.Close();
                contexto.Dispose();

            }

            return listado;
        }

        public List<ext_ListarPeriodoPlanillaResult> ListarPeridosPlanilla(string periodoConsulta)
        {
            List<ext_ListarPeriodoPlanillaResult> listado = new List<ext_ListarPeriodoPlanillaResult>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ListarPeriodoPlanilla().ToList();
            }
            return listado;
        }

        public List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaResult> ListarSemanaByCodigoPlanillaByPerido(string periodoConsulta, string codigoPlanilla, string periodo)
        {
            List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaResult> listado = new List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaResult>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ListarPeriodoPlanillaBySemanaByCodigoPlanilla(codigoPlanilla, periodo).ToList();
            }
            return listado;
        }


        /*24/10/18*/
        public List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaBySemanaResult> ListarSemanaByCodigoPlanillaBySemana(string periodoConsulta, string codigoPlanilla, string periodo, string semana)
        {
            List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaBySemanaResult> listado = new List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaBySemanaResult>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = Modelo.ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaBySemana(codigoPlanilla, periodo, semana).ToList();
            }
            return listado;
        }

        /*24/10/18*/
        public List<GrupoH> ObtenerListadoDeDiasBySemanas(string periodoConsulta, string codigoPlanilla, string anio, string periodo, string semana)
        {
            List<GrupoH> listado = new List<GrupoH>();
            List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaBySemanaResult> semanaElegida = new List<ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaBySemanaResult>();

            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : DateTime.Now.Year.ToString())].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                semanaElegida = Modelo.ext_ListarPeriodoPlanillaBySemanaByCodigoPlanillaBySemana(codigoPlanilla, periodo, semana).ToList();

                foreach (var fechaSemana in semanaElegida)
                {
                    TimeSpan ts = Convert.ToDateTime(fechaSemana.fechaFinal) - Convert.ToDateTime(fechaSemana.fechaInicio);

                    for (int i = 0; i <= ts.Days; i++)
                    {
                        GrupoH fechaElegida = new GrupoH();
                        fechaElegida.Codigo = fechaSemana.fechaInicio.Value.AddDays(i).ToShortDateString();
                        fechaElegida.Descripcion = fechaSemana.fechaInicio.Value.AddDays(i).ToString("dddd", new CultureInfo("es-ES"));
                        listado.Add(fechaElegida);
                    }
                }
            }
            return listado;
        }


        public List<PlanillaPeriodo> ListarPeriodoPlanilla(string periodoConsulta, string codigoTipoPlanilla)
        {
            List<PlanillaPeriodo> listado = new List<PlanillaPeriodo>();
            oConexion = ConfigurationManager.AppSettings["bd" + (periodoConsulta != null ? periodoConsulta.Substring(0, 4) : "2018")].ToString();
            using (ExoticsModelDataContext Modelo = new ExoticsModelDataContext(oConexion))
            {
                listado = (from items in Modelo.PlanillaPeriodo
                           where items.CodigoPlanilla == codigoTipoPlanilla /* && items.anio == periodoConsulta.Substring(0, 4*/
                            where items.CodigoPlanilla == codigoTipoPlanilla 
                           group items by new
                           {
                               items.periodo                               
                           } into j
                           select new PlanillaPeriodo
                           {
                               codigoEmpresa	= j.FirstOrDefault().codigoEmpresa.Trim(),
                               CodigoPlanilla = j.FirstOrDefault().CodigoPlanilla.Trim(),
                               anio = j.FirstOrDefault().anio.Trim(),
                               periodo = j.Key.periodo.Trim(),
                           }).ToList();
            }

            return listado;
        }

        public PlanillaPeriodo ObtenerSemanaByPlanillaByFechas(string fecha, string planillaCodigo, string periodo)
        {
            #region Ejecutar Consulta()

            PlanillaPeriodo oPeriodoPlanilla = new PlanillaPeriodo();
            string cnx = string.Empty;
            cnx = System.Configuration.ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();
            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                contexto.CommandTimeout = 9000;

                string anioDePlanilla = fecha.Substring(6, 4);

                var resultadoSubConsulta = contexto.PlanillaPeriodo.Where(x => x.CodigoPlanilla == planillaCodigo && x.fechaInicio <= Convert.ToDateTime(fecha) && x.fechaFinal >= Convert.ToDateTime(fecha)).ToList();

                if (resultadoSubConsulta.ToList().Count > 0)
                {
                    oPeriodoPlanilla = (
                    from item in contexto.PlanillaPeriodo.OrderByDescending(x => x.semana).ToList()
                    where item.CodigoPlanilla.Trim() == planillaCodigo
                        //&& item.anio.Trim() == anioDePlanilla
                    && item.fechaInicio <= Convert.ToDateTime(fecha)
                    && item.fechaFinal >= Convert.ToDateTime(fecha)
                    group item by new
                    {
                        item.CodigoPlanilla,
                        item.semana,
                        item.anio,
                        item.periodo
                    }
                        into j
                        select new PlanillaPeriodo
                        {
                            CodigoPlanilla = j.Key.CodigoPlanilla,
                            anio = j.Key.anio,
                            periodo = j.Key.periodo,
                            semana = j.Key.semana,
                            fechaInicio = j.FirstOrDefault().fechaInicio,
                            fechaFinal = j.FirstOrDefault().fechaFinal,
                        }).Single();
                }



                contexto.Connection.Close();
                contexto.Dispose();

            }
            #endregion
            return oPeriodoPlanilla;
        }

        public PlanillaPeriodo ObtenerSemanaByPlanillaBySemana(string fecha, string planillaCodigo, string periodo, string semana)
        {
            #region Ejecutar Consulta()

            PlanillaPeriodo oPeriodoPlanilla = new PlanillaPeriodo();
            string cnx = string.Empty;
            cnx = System.Configuration.ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim().Substring(0, 4)].ToString().Trim();
            using (ExoticsModelDataContext contexto = new ExoticsModelDataContext(cnx))
            {
                contexto.CommandTimeout = 9000;

                string anioDePlanilla = fecha.Substring(6, 4);

                var resultadoSubConsulta = contexto.PlanillaPeriodo.Where(x => x.CodigoPlanilla == planillaCodigo
                    && x.anio == anioDePlanilla
                    && x.semana == semana
                    ).ToList();

                if (resultadoSubConsulta.ToList().Count > 0)
                {
                    oPeriodoPlanilla = (
                    from item in contexto.PlanillaPeriodo.OrderByDescending(x => x.semana).ToList()
                    where item.CodigoPlanilla.Trim() == planillaCodigo
                        && item.anio.Trim() == anioDePlanilla
                        && item.semana == semana
                    group item by new
                    {
                        item.CodigoPlanilla,
                        item.semana,
                        item.anio,
                        item.periodo
                    }
                        into j
                        select new PlanillaPeriodo
                        {
                            CodigoPlanilla = j.Key.CodigoPlanilla,
                            anio = j.Key.anio,
                            periodo = j.Key.periodo,
                            semana = j.Key.semana,
                            fechaInicio = j.FirstOrDefault().fechaInicio,
                            fechaFinal = j.FirstOrDefault().fechaFinal,
                        }).Single();
                }



                contexto.Connection.Close();
                contexto.Dispose();

            }
            #endregion
            return oPeriodoPlanilla;
        }
    }
}
