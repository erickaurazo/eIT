using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecursosHumanos.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;

namespace RecursosHumanos.Negocios
{
    public class AsistenciaByProyectoDiarioNegocios
    {

        public List<AsistenciaByProyectoDiaria> ObtenerAsistenciaDetalleByProyectoByNroPersonas(List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoGeneralAsistencia)
        {
            List<AsistenciaByProyectoDiaria> listadoByDia = new List<AsistenciaByProyectoDiaria>();
            List<AsistenciaByProyectoDiaria> listadoResumen = new List<AsistenciaByProyectoDiaria>();

            if (listadoGeneralAsistencia != null && listadoGeneralAsistencia.ToList().Count > 0)
            {
                #region 
                /*Dias trabajados*/
                var diasTrabajadas = (from item in listadoGeneralAsistencia
                                      where item.FECHA != null
                                      group item by new { item.FECHA } into j
                                      select new
                                      {
                                          diaTrabajado = j.Key.FECHA,
                                      }).ToList();

                if (diasTrabajadas != null && diasTrabajadas.ToList().Count > 0)
                {
                    #region Agrupar por actividades()
                    foreach (var itemDia in diasTrabajadas)
                    {
                        var listadoAsistenciaByPersonasByDia = listadoGeneralAsistencia.Where(x => x.FECHA == itemDia.diaTrabajado).ToList();

                        if (listadoAsistenciaByPersonasByDia != null && listadoAsistenciaByPersonasByDia.ToList().Count > 0)
                        {

                            var proyectos = (from item in listadoAsistenciaByPersonasByDia
                                             where item.idProyecto != null
                                             group item by new { item.idProyecto } into j
                                             select new
                                             {
                                                 idproyecto = j.Key.idProyecto.ToString().Trim(),
                                                 proyecto = j.FirstOrDefault().proyecto.ToString().Trim()
                                             }).ToList();


                            foreach (var itemProyecto in proyectos)
                            {
                                #region Dias por Proyecto
                                var listadoAsistenciaByPersonasByDiaByProyecto = listadoAsistenciaByPersonasByDia.Where(x => x.idProyecto == itemProyecto.idproyecto).ToList();

                                if (listadoAsistenciaByPersonasByDiaByProyecto != null && listadoAsistenciaByPersonasByDiaByProyecto.ToList().Count > 0)
                                {
                                    #region
                                    var nroPersonas = (from item in listadoAsistenciaByPersonasByDiaByProyecto
                                                       where item.nroDocumento != null
                                                       group item by new { item.nroDocumento } into j
                                                       select new
                                                       {
                                                           nroDocumento = j.Key.nroDocumento.ToString().Trim()
                                                       }).ToList();


                                    AsistenciaByProyectoDiaria asistenciaByProyectoDiaria = new AsistenciaByProyectoDiaria();
                                    asistenciaByProyectoDiaria.fecha = itemDia.diaTrabajado;
                                    asistenciaByProyectoDiaria.Semana = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().numeroSemanaRegistro != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().numeroSemanaRegistro) : 0;
                                    asistenciaByProyectoDiaria.NumeroMes = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().mesFechaRegistro != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().mesFechaRegistro) : 0;
                                    asistenciaByProyectoDiaria.NumeroAño = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().añoFechaRegistro != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().añoFechaRegistro) : 0;
                                    asistenciaByProyectoDiaria.idMedida = "PER";
                                    asistenciaByProyectoDiaria.NombreMes = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().nombreMesFechaRegistro != null ? Convert.ToString(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().nombreMesFechaRegistro) : "";
                                    asistenciaByProyectoDiaria.nombreDia = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().nombreDiaFechaRegistro != null ? Convert.ToString(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().nombreDiaFechaRegistro) : "";
                                    asistenciaByProyectoDiaria.sinProyecto = 0;

                                    switch (itemProyecto.idproyecto.ToString().Trim())
                                    {
                                        case "0001": /* 0001 - uva*/
                                            asistenciaByProyectoDiaria.otros = nroPersonas.Count;
                                            break;

                                        case "0002": /* 0002 - caña*/
                                            asistenciaByProyectoDiaria.otros = nroPersonas.Count;
                                            break;

                                        case "0003": /* 0003 - fundo*/
                                            asistenciaByProyectoDiaria.otros = nroPersonas.Count;
                                            break;

                                        case "0004": /* 0004 - g.admin*/
                                            asistenciaByProyectoDiaria.otros = nroPersonas.Count;
                                            break;

                                        case "0005": /* 0005 - export*/
                                            asistenciaByProyectoDiaria.otros = nroPersonas.Count;
                                            break;

                                        case "0006": /* 0006 - taller || 1009 - taller*/
                                            asistenciaByProyectoDiaria.taller = nroPersonas.Count;
                                            break;

                                        case "1009": /* 0006 - taller || 1009 - taller*/
                                            asistenciaByProyectoDiaria.taller = nroPersonas.Count;
                                            break;

                                        case "0007": /* 0007 - arandano*/
                                            asistenciaByProyectoDiaria.otros = nroPersonas.Count;
                                            break;

                                        case "0008": /* 0008 - palta*/
                                            asistenciaByProyectoDiaria.palta = nroPersonas.Count;
                                            break;

                                        case "0009": /* 0009 - planillas*/
                                            asistenciaByProyectoDiaria.otros = nroPersonas.Count;
                                            break;

                                        case "0010": /* 0010 - impuestos*/
                                            asistenciaByProyectoDiaria.otros = nroPersonas.Count;
                                            break;

                                        case "0011": /* 0011 - planta || 1010 - planta */
                                            asistenciaByProyectoDiaria.planta = nroPersonas.Count;
                                            break;

                                        case "1010": /* 0011 - planta || 1010 - planta */
                                            asistenciaByProyectoDiaria.planta = nroPersonas.Count;
                                            break;

                                        case "0012": /* 0012 - ventas */
                                            asistenciaByProyectoDiaria.otros = nroPersonas.Count;
                                            break;

                                        case "1001": /* 1001 - sanidad */
                                            asistenciaByProyectoDiaria.sanidad = nroPersonas.Count;
                                            break;

                                        case "1002": /* 1002 - fertirriego */
                                            asistenciaByProyectoDiaria.fertiRiego = nroPersonas.Count;
                                            break;

                                        case "1003": /* 1003 - evaluaciones */
                                            asistenciaByProyectoDiaria.evaluaciones = nroPersonas.Count;
                                            break;

                                        case "1004": /* 1004 - areas verdes */
                                            asistenciaByProyectoDiaria.areasVerdes = nroPersonas.Count;
                                            break;

                                        case "1005": /*  1005 - vigilancia  */
                                            asistenciaByProyectoDiaria.vigilancia = nroPersonas.Count;
                                            break;

                                        case "1006": /*  1006 - laboratorio  */
                                            asistenciaByProyectoDiaria.laboratorio = nroPersonas.Count;
                                            break;

                                        case "1007": /* 1007 - caña san juan  */
                                            asistenciaByProyectoDiaria.canaSanJuan = nroPersonas.Count;
                                            break;

                                        case "1008": /* 1008 - caña tablazos - huacablanca  */
                                            asistenciaByProyectoDiaria.canaTablazosHuacaBlanca = nroPersonas.Count;
                                            break;

                                        case "1011": /*  1011 - servicios generales  */
                                            asistenciaByProyectoDiaria.serviciosGenerales = nroPersonas.Count;
                                            break;

                                        case "1012": /*  1012 - ucupe  */
                                            asistenciaByProyectoDiaria.ucupe = nroPersonas.Count;
                                            break;

                                        case "9000": /*  1012 - ucupe  */
                                            asistenciaByProyectoDiaria.ConstanciasFallecimiento = nroPersonas.Count;
                                            break;

                                        default:
                                            asistenciaByProyectoDiaria.sinProyecto = nroPersonas.Count;
                                            break;
                                    }
                                    listadoByDia.Add(asistenciaByProyectoDiaria);




                                    #endregion

                                }
                                #endregion
                            }
                        }

                    }
                    #endregion
                }
                #endregion
            }

            if (listadoByDia != null && listadoByDia.ToList().Count > 0)
            {
                #region
                var diasTrabajadas = (from item in listadoByDia
                                      where item.fecha != null
                                      group item by new { item.fecha } into j
                                      select new
                                      {
                                          diaTrabajado = j.Key.fecha,
                                      }).ToList();

                if (diasTrabajadas != null && diasTrabajadas.ToList().Count > 0)
                {
                    #region MyRegion
                    foreach (var itemDia in diasTrabajadas)
                    {

                        var listadoAsistenciaByPersonasByDia = listadoByDia.Where(x => x.fecha == itemDia.diaTrabajado).ToList();

                        if (listadoAsistenciaByPersonasByDia != null && listadoAsistenciaByPersonasByDia.ToList().Count > 0)
                        {
                            AsistenciaByProyectoDiaria asistenciaByProyectoDiaria = new AsistenciaByProyectoDiaria();
                            asistenciaByProyectoDiaria.fecha = itemDia.diaTrabajado;
                            asistenciaByProyectoDiaria.Semana = listadoAsistenciaByPersonasByDia.FirstOrDefault().Semana != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().Semana) : 0;
                            asistenciaByProyectoDiaria.NumeroMes = listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroMes != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroMes) : 0;
                            asistenciaByProyectoDiaria.NumeroAño = listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroAño != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroAño) : 0;
                            asistenciaByProyectoDiaria.idMedida = "PER";
                            asistenciaByProyectoDiaria.NombreMes = listadoAsistenciaByPersonasByDia.FirstOrDefault().NombreMes != null ? Convert.ToString(listadoAsistenciaByPersonasByDia.FirstOrDefault().NombreMes) : "";
                            asistenciaByProyectoDiaria.nombreDia = listadoAsistenciaByPersonasByDia.FirstOrDefault().nombreDia != null ? Convert.ToString(listadoAsistenciaByPersonasByDia.FirstOrDefault().nombreDia) : "";
                            asistenciaByProyectoDiaria.sinProyecto = 0;
                            asistenciaByProyectoDiaria.taller = listadoAsistenciaByPersonasByDia.Sum(x => x.taller != null ? x.taller : 0);
                            asistenciaByProyectoDiaria.palta = listadoAsistenciaByPersonasByDia.Sum(x => x.palta != null ? x.palta : 0);
                            asistenciaByProyectoDiaria.planta = listadoAsistenciaByPersonasByDia.Sum(x => x.planta != null ? x.planta : 0);
                            asistenciaByProyectoDiaria.sanidad = listadoAsistenciaByPersonasByDia.Sum(x => x.sanidad != null ? x.sanidad : 0);
                            asistenciaByProyectoDiaria.fertiRiego = listadoAsistenciaByPersonasByDia.Sum(x => x.fertiRiego != null ? x.fertiRiego : 0);
                            asistenciaByProyectoDiaria.evaluaciones = listadoAsistenciaByPersonasByDia.Sum(x => x.evaluaciones != null ? x.evaluaciones : 0);
                            asistenciaByProyectoDiaria.areasVerdes = listadoAsistenciaByPersonasByDia.Sum(x => x.areasVerdes != (decimal?)null ? x.areasVerdes : 0);
                            asistenciaByProyectoDiaria.vigilancia = listadoAsistenciaByPersonasByDia.Sum(x => x.vigilancia != null ? x.vigilancia : 0);
                            asistenciaByProyectoDiaria.laboratorio = listadoAsistenciaByPersonasByDia.Sum(x => x.laboratorio != null ? x.laboratorio : 0);
                            asistenciaByProyectoDiaria.canaSanJuan = listadoAsistenciaByPersonasByDia.Sum(x => x.canaSanJuan != null ? x.canaSanJuan : 0);
                            asistenciaByProyectoDiaria.canaTablazosHuacaBlanca = listadoAsistenciaByPersonasByDia.Sum(x => x.canaTablazosHuacaBlanca != null ? x.canaTablazosHuacaBlanca : 0);
                            asistenciaByProyectoDiaria.serviciosGenerales = listadoAsistenciaByPersonasByDia.Sum(x => x.serviciosGenerales != null ? x.serviciosGenerales : 0);
                            asistenciaByProyectoDiaria.ucupe = listadoAsistenciaByPersonasByDia.Sum(x => x.ucupe != null ? x.ucupe : 0);
                            asistenciaByProyectoDiaria.ConstanciasFallecimiento = listadoAsistenciaByPersonasByDia.Sum(x => x.ConstanciasFallecimiento != null ? x.ConstanciasFallecimiento : 0);
                            asistenciaByProyectoDiaria.sinProyecto = listadoAsistenciaByPersonasByDia.Sum(x => x.sinProyecto != null ? x.sinProyecto : 0);
                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDia.Sum(x => x.otros != null ? x.otros : 0);
                            asistenciaByProyectoDiaria.total = (asistenciaByProyectoDiaria.taller + asistenciaByProyectoDiaria.palta + asistenciaByProyectoDiaria.planta +
                                 asistenciaByProyectoDiaria.sanidad + asistenciaByProyectoDiaria.fertiRiego + asistenciaByProyectoDiaria.evaluaciones + asistenciaByProyectoDiaria.areasVerdes
                                 + asistenciaByProyectoDiaria.vigilancia + asistenciaByProyectoDiaria.laboratorio + asistenciaByProyectoDiaria.canaSanJuan + asistenciaByProyectoDiaria.canaTablazosHuacaBlanca
                                 + asistenciaByProyectoDiaria.serviciosGenerales + asistenciaByProyectoDiaria.ucupe + asistenciaByProyectoDiaria.ConstanciasFallecimiento + asistenciaByProyectoDiaria.sinProyecto
                                 + asistenciaByProyectoDiaria.otros);
                            listadoResumen.Add(asistenciaByProyectoDiaria);
                        }

                    }
                    #endregion
                }
                #endregion
            }

            return listadoResumen;
        }

        public List<AsistenciaByProyectoDiaria> ObtenerAsistenciaResumenByProyectoByNroPersonas(List<AsistenciaByProyectoDiaria> listadorAsistenciaAgrupadaByProyectoByNroPersonas)
        {
            
            List<AsistenciaByProyectoDiaria> listadoResumen = new List<AsistenciaByProyectoDiaria>();



            if (listadorAsistenciaAgrupadaByProyectoByNroPersonas != null && listadorAsistenciaAgrupadaByProyectoByNroPersonas.ToList().Count > 0)
            {
                #region
                var diasTrabajadas = (from item in listadorAsistenciaAgrupadaByProyectoByNroPersonas
                                      where item.fecha != null
                                      group item by new { item.fecha } into j
                                      select new
                                      {
                                          diaTrabajado = j.Key.fecha,
                                      }).ToList();

                if (diasTrabajadas != null && diasTrabajadas.ToList().Count > 0)
                {
                    #region MyRegion
                    foreach (var itemDia in diasTrabajadas)
                    {

                        var listadoAsistenciaByPersonasByDia = listadorAsistenciaAgrupadaByProyectoByNroPersonas.Where(x => x.fecha == itemDia.diaTrabajado).ToList();

                        if (listadoAsistenciaByPersonasByDia != null && listadoAsistenciaByPersonasByDia.ToList().Count > 0)
                        {
                            AsistenciaByProyectoDiaria asistenciaByProyectoDiaria = new AsistenciaByProyectoDiaria();
                            asistenciaByProyectoDiaria.fecha = itemDia.diaTrabajado;
                            asistenciaByProyectoDiaria.Semana = listadoAsistenciaByPersonasByDia.FirstOrDefault().Semana != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().Semana) : 0;
                            asistenciaByProyectoDiaria.NumeroMes = listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroMes != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroMes) : 0;
                            asistenciaByProyectoDiaria.NumeroAño = listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroAño != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroAño) : 0;
                            asistenciaByProyectoDiaria.idMedida = "PER";
                            asistenciaByProyectoDiaria.NombreMes = listadoAsistenciaByPersonasByDia.FirstOrDefault().NombreMes != null ? Convert.ToString(listadoAsistenciaByPersonasByDia.FirstOrDefault().NombreMes) : "";
                            asistenciaByProyectoDiaria.nombreDia = listadoAsistenciaByPersonasByDia.FirstOrDefault().nombreDia != null ? Convert.ToString(listadoAsistenciaByPersonasByDia.FirstOrDefault().nombreDia) : "";
                            asistenciaByProyectoDiaria.sinProyecto = 0;
                            asistenciaByProyectoDiaria.taller = listadoAsistenciaByPersonasByDia.Sum(x => x.taller != null ? x.taller : 0);
                            asistenciaByProyectoDiaria.palta = listadoAsistenciaByPersonasByDia.Sum(x => x.palta != null ? x.palta : 0);
                            asistenciaByProyectoDiaria.planta = listadoAsistenciaByPersonasByDia.Sum(x => x.planta != null ? x.planta : 0);
                            asistenciaByProyectoDiaria.sanidad = listadoAsistenciaByPersonasByDia.Sum(x => x.sanidad != null ? x.sanidad : 0);
                            asistenciaByProyectoDiaria.fertiRiego = listadoAsistenciaByPersonasByDia.Sum(x => x.fertiRiego != null ? x.fertiRiego : 0);
                            asistenciaByProyectoDiaria.evaluaciones = listadoAsistenciaByPersonasByDia.Sum(x => x.evaluaciones != null ? x.evaluaciones : 0);
                            asistenciaByProyectoDiaria.areasVerdes = listadoAsistenciaByPersonasByDia.Sum(x => x.areasVerdes != null ? x.areasVerdes : 0);
                            asistenciaByProyectoDiaria.vigilancia = listadoAsistenciaByPersonasByDia.Sum(x => x.vigilancia != null ? x.vigilancia : 0);
                            asistenciaByProyectoDiaria.laboratorio = listadoAsistenciaByPersonasByDia.Sum(x => x.laboratorio != null ? x.laboratorio : 0);
                            asistenciaByProyectoDiaria.canaSanJuan = listadoAsistenciaByPersonasByDia.Sum(x => x.canaSanJuan != null ? x.canaSanJuan : 0);
                            asistenciaByProyectoDiaria.canaTablazosHuacaBlanca = listadoAsistenciaByPersonasByDia.Sum(x => x.canaTablazosHuacaBlanca != null ? x.canaTablazosHuacaBlanca : 0);
                            asistenciaByProyectoDiaria.serviciosGenerales = listadoAsistenciaByPersonasByDia.Sum(x => x.serviciosGenerales != null ? x.serviciosGenerales : 0);
                            asistenciaByProyectoDiaria.ucupe = listadoAsistenciaByPersonasByDia.Sum(x => x.ucupe != null ? x.ucupe : 0);
                            asistenciaByProyectoDiaria.ConstanciasFallecimiento = listadoAsistenciaByPersonasByDia.Sum(x => x.ConstanciasFallecimiento != null ? x.ConstanciasFallecimiento : 0);
                            asistenciaByProyectoDiaria.sinProyecto = listadoAsistenciaByPersonasByDia.Sum(x => x.sinProyecto != null ? x.sinProyecto : 0);
                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDia.Sum(x => x.otros != null ? x.otros : 0);
                            asistenciaByProyectoDiaria.total = (asistenciaByProyectoDiaria.taller + asistenciaByProyectoDiaria.palta + asistenciaByProyectoDiaria.planta +
                                 asistenciaByProyectoDiaria.sanidad + asistenciaByProyectoDiaria.fertiRiego + asistenciaByProyectoDiaria.evaluaciones + asistenciaByProyectoDiaria.areasVerdes
                                 + asistenciaByProyectoDiaria.vigilancia + asistenciaByProyectoDiaria.laboratorio + asistenciaByProyectoDiaria.canaSanJuan + asistenciaByProyectoDiaria.canaTablazosHuacaBlanca
                                 + asistenciaByProyectoDiaria.serviciosGenerales + asistenciaByProyectoDiaria.ucupe + asistenciaByProyectoDiaria.ConstanciasFallecimiento + asistenciaByProyectoDiaria.sinProyecto
                                 + asistenciaByProyectoDiaria.otros);
                            listadoResumen.Add(asistenciaByProyectoDiaria);
                        }

                    }
                    #endregion
                }
                #endregion
            }

            return listadoResumen;
        }

        public List<AsistenciaByProyectoDiaria> ObtenerAsistenciaDetalleByProyectoByNroHorasAcumuladasTrabajadas(List<SJ_RHListarAsistenciaPersonalByPeriodoResult> listadoGeneralAsistencia)
        {
            List<AsistenciaByProyectoDiaria> listadoByDia = new List<AsistenciaByProyectoDiaria>();
            List<AsistenciaByProyectoDiaria> listadoResumen = new List<AsistenciaByProyectoDiaria>();

            if (listadoGeneralAsistencia != null && listadoGeneralAsistencia.ToList().Count > 0)
            {
                #region
                /*Dias trabajados*/
                var diasTrabajadas = (from item in listadoGeneralAsistencia
                                      where item.FECHA != null
                                      group item by new { item.FECHA } into j
                                      select new
                                      {
                                          diaTrabajado = j.Key.FECHA,
                                      }).ToList();

                if (diasTrabajadas != null && diasTrabajadas.ToList().Count > 0)
                {
                    #region Agrupar por actividades()
                    foreach (var itemDia in diasTrabajadas)
                    {
                        var listadoAsistenciaByPersonasByDia = listadoGeneralAsistencia.Where(x => x.FECHA == itemDia.diaTrabajado).ToList();

                        if (listadoAsistenciaByPersonasByDia != null && listadoAsistenciaByPersonasByDia.ToList().Count > 0)
                        {

                            var proyectos = (from item in listadoAsistenciaByPersonasByDia
                                             where item.idProyecto != null
                                             group item by new { item.idProyecto } into j
                                             select new
                                             {
                                                 idproyecto = j.Key.idProyecto.ToString().Trim(),
                                                 proyecto = j.FirstOrDefault().proyecto.ToString().Trim()
                                             }).ToList();


                            foreach (var itemProyecto in proyectos)
                            {
                                #region Dias por Proyecto
                                var listadoAsistenciaByPersonasByDiaByProyecto = listadoAsistenciaByPersonasByDia.Where(x => x.idProyecto == itemProyecto.idproyecto).ToList();

                                if (listadoAsistenciaByPersonasByDiaByProyecto != null && listadoAsistenciaByPersonasByDiaByProyecto.ToList().Count > 0)
                                {
                                    #region
                                    AsistenciaByProyectoDiaria asistenciaByProyectoDiaria = new AsistenciaByProyectoDiaria();
                                    asistenciaByProyectoDiaria.fecha = itemDia.diaTrabajado;
                                    asistenciaByProyectoDiaria.Semana = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().numeroSemanaRegistro != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().numeroSemanaRegistro) : 0;
                                    asistenciaByProyectoDiaria.NumeroMes = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().mesFechaRegistro != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().mesFechaRegistro) : 0;
                                    asistenciaByProyectoDiaria.NumeroAño = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().añoFechaRegistro != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().añoFechaRegistro) : 0;
                                    asistenciaByProyectoDiaria.idMedida = "PER";
                                    asistenciaByProyectoDiaria.NombreMes = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().nombreMesFechaRegistro != null ? Convert.ToString(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().nombreMesFechaRegistro) : "";
                                    asistenciaByProyectoDiaria.nombreDia = listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().nombreDiaFechaRegistro != null ? Convert.ToString(listadoAsistenciaByPersonasByDiaByProyecto.FirstOrDefault().nombreDiaFechaRegistro) : "";
                                    asistenciaByProyectoDiaria.sinProyecto = 0;

                                    switch (itemProyecto.idproyecto.ToString().Trim())
                                    {
                                        case "0001": /* 0001 - uva*/
                                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x=> x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0002": /* 0002 - caña*/
                                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0003": /* 0003 - fundo*/
                                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0004": /* 0004 - g.admin*/
                                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0005": /* 0005 - export*/
                                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0006": /* 0006 - taller || 1009 - taller*/
                                            asistenciaByProyectoDiaria.taller = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1009": /* 0006 - taller || 1009 - taller*/
                                            asistenciaByProyectoDiaria.taller = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0007": /* 0007 - arandano*/
                                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0008": /* 0008 - palta*/
                                            asistenciaByProyectoDiaria.palta = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0009": /* 0009 - planillas*/
                                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0010": /* 0010 - impuestos*/
                                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0011": /* 0011 - planta || 1010 - planta */
                                            asistenciaByProyectoDiaria.planta = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1010": /* 0011 - planta || 1010 - planta */
                                            asistenciaByProyectoDiaria.planta = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "0012": /* 0012 - ventas */
                                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1001": /* 1001 - sanidad */
                                            asistenciaByProyectoDiaria.sanidad = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1002": /* 1002 - fertirriego */
                                            asistenciaByProyectoDiaria.fertiRiego = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1003": /* 1003 - evaluaciones */
                                            asistenciaByProyectoDiaria.evaluaciones = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1004": /* 1004 - areas verdes */
                                            asistenciaByProyectoDiaria.areasVerdes = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1005": /*  1005 - vigilancia  */
                                            asistenciaByProyectoDiaria.vigilancia = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1006": /*  1006 - laboratorio  */
                                            asistenciaByProyectoDiaria.laboratorio = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1007": /* 1007 - caña san juan  */
                                            asistenciaByProyectoDiaria.canaSanJuan = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1008": /* 1008 - caña tablazos - huacablanca  */
                                            asistenciaByProyectoDiaria.canaTablazosHuacaBlanca = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1011": /*  1011 - servicios generales  */
                                            asistenciaByProyectoDiaria.serviciosGenerales = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "1012": /*  1012 - ucupe  */
                                            asistenciaByProyectoDiaria.ucupe = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        case "9000": /*  1012 - ucupe  */
                                            asistenciaByProyectoDiaria.ConstanciasFallecimiento = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;

                                        default:
                                            asistenciaByProyectoDiaria.sinProyecto = listadoAsistenciaByPersonasByDiaByProyecto.Sum(x => x.TOTAL_HORAS.Value != null ? x.TOTAL_HORAS.Value : 0);
                                            break;
                                    }
                                    listadoByDia.Add(asistenciaByProyectoDiaria);
                                    #endregion
                                }
                                #endregion
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            }

            if (listadoByDia != null && listadoByDia.ToList().Count > 0)
            {
                #region
                var diasTrabajadas = (from item in listadoByDia
                                      where item.fecha != null
                                      group item by new { item.fecha } into j
                                      select new
                                      {
                                          diaTrabajado = j.Key.fecha,
                                      }).ToList();

                if (diasTrabajadas != null && diasTrabajadas.ToList().Count > 0)
                {
                    #region MyRegion
                    foreach (var itemDia in diasTrabajadas)
                    {

                        var listadoAsistenciaByPersonasByDia = listadoByDia.Where(x => x.fecha == itemDia.diaTrabajado).ToList();

                        if (listadoAsistenciaByPersonasByDia != null && listadoAsistenciaByPersonasByDia.ToList().Count > 0)
                        {
                            AsistenciaByProyectoDiaria asistenciaByProyectoDiaria = new AsistenciaByProyectoDiaria();
                            asistenciaByProyectoDiaria.fecha = itemDia.diaTrabajado;
                            asistenciaByProyectoDiaria.Semana = listadoAsistenciaByPersonasByDia.FirstOrDefault().Semana != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().Semana) : 0;
                            asistenciaByProyectoDiaria.NumeroMes = listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroMes != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroMes) : 0;
                            asistenciaByProyectoDiaria.NumeroAño = listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroAño != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroAño) : 0;
                            asistenciaByProyectoDiaria.idMedida = "PER";
                            asistenciaByProyectoDiaria.NombreMes = listadoAsistenciaByPersonasByDia.FirstOrDefault().NombreMes != null ? Convert.ToString(listadoAsistenciaByPersonasByDia.FirstOrDefault().NombreMes) : "";
                            asistenciaByProyectoDiaria.nombreDia = listadoAsistenciaByPersonasByDia.FirstOrDefault().nombreDia != null ? Convert.ToString(listadoAsistenciaByPersonasByDia.FirstOrDefault().nombreDia) : "";
                            asistenciaByProyectoDiaria.sinProyecto = 0;
                            asistenciaByProyectoDiaria.taller = listadoAsistenciaByPersonasByDia.Sum(x => x.taller != null ? x.taller : 0);
                            asistenciaByProyectoDiaria.palta = listadoAsistenciaByPersonasByDia.Sum(x => x.palta != null ? x.palta : 0);
                            asistenciaByProyectoDiaria.planta = listadoAsistenciaByPersonasByDia.Sum(x => x.planta != null ? x.planta : 0);
                            asistenciaByProyectoDiaria.sanidad = listadoAsistenciaByPersonasByDia.Sum(x => x.sanidad != null ? x.sanidad : 0);
                            asistenciaByProyectoDiaria.fertiRiego = listadoAsistenciaByPersonasByDia.Sum(x => x.fertiRiego != null ? x.fertiRiego : 0);
                            asistenciaByProyectoDiaria.evaluaciones = listadoAsistenciaByPersonasByDia.Sum(x => x.evaluaciones != null ? x.evaluaciones : 0);
                            asistenciaByProyectoDiaria.areasVerdes = listadoAsistenciaByPersonasByDia.Sum(x => x.areasVerdes != null ? x.areasVerdes : 0);
                            asistenciaByProyectoDiaria.vigilancia = listadoAsistenciaByPersonasByDia.Sum(x => x.vigilancia != null ? x.vigilancia : 0);
                            asistenciaByProyectoDiaria.laboratorio = listadoAsistenciaByPersonasByDia.Sum(x => x.laboratorio != null ? x.laboratorio : 0);
                            asistenciaByProyectoDiaria.canaSanJuan = listadoAsistenciaByPersonasByDia.Sum(x => x.canaSanJuan != null ? x.canaSanJuan : 0);
                            asistenciaByProyectoDiaria.canaTablazosHuacaBlanca = listadoAsistenciaByPersonasByDia.Sum(x => x.canaTablazosHuacaBlanca != null ? x.canaTablazosHuacaBlanca : 0);
                            asistenciaByProyectoDiaria.serviciosGenerales = listadoAsistenciaByPersonasByDia.Sum(x => x.serviciosGenerales != null ? x.serviciosGenerales : 0);
                            asistenciaByProyectoDiaria.ucupe = listadoAsistenciaByPersonasByDia.Sum(x => x.ucupe != null ? x.ucupe : 0);
                            asistenciaByProyectoDiaria.ConstanciasFallecimiento = listadoAsistenciaByPersonasByDia.Sum(x => x.ConstanciasFallecimiento != null ? x.ConstanciasFallecimiento : 0);
                            asistenciaByProyectoDiaria.sinProyecto = listadoAsistenciaByPersonasByDia.Sum(x => x.sinProyecto != null ? x.sinProyecto : 0);
                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDia.Sum(x => x.otros != null ? x.otros : 0);
                            asistenciaByProyectoDiaria.total = (asistenciaByProyectoDiaria.taller + asistenciaByProyectoDiaria.palta + asistenciaByProyectoDiaria.planta +
                                 asistenciaByProyectoDiaria.sanidad + asistenciaByProyectoDiaria.fertiRiego + asistenciaByProyectoDiaria.evaluaciones + asistenciaByProyectoDiaria.areasVerdes
                                 + asistenciaByProyectoDiaria.vigilancia + asistenciaByProyectoDiaria.laboratorio + asistenciaByProyectoDiaria.canaSanJuan + asistenciaByProyectoDiaria.canaTablazosHuacaBlanca
                                 + asistenciaByProyectoDiaria.serviciosGenerales + asistenciaByProyectoDiaria.ucupe + asistenciaByProyectoDiaria.ConstanciasFallecimiento + asistenciaByProyectoDiaria.sinProyecto
                                 + asistenciaByProyectoDiaria.otros);
                            listadoResumen.Add(asistenciaByProyectoDiaria);
                        }

                    }
                    #endregion
                }
                #endregion
            }

            return listadoResumen;
        }

        public List<AsistenciaByProyectoDiaria> ObtenerAsistenciaResumenByProyectoByNroHorasAcumuladasTrabajadas(List<AsistenciaByProyectoDiaria> listadorAsistenciaAgrupadaByProyectoByNroPersonas)
        {
           
            List<AsistenciaByProyectoDiaria> listadoResumen = new List<AsistenciaByProyectoDiaria>();


            if (listadorAsistenciaAgrupadaByProyectoByNroPersonas != null && listadorAsistenciaAgrupadaByProyectoByNroPersonas.ToList().Count > 0)
            {
                #region
                var diasTrabajadas = (from item in listadorAsistenciaAgrupadaByProyectoByNroPersonas
                                      where item.fecha != null
                                      group item by new { item.fecha } into j
                                      select new
                                      {
                                          diaTrabajado = j.Key.fecha,
                                      }).ToList();

                if (diasTrabajadas != null && diasTrabajadas.ToList().Count > 0)
                {
                    #region MyRegion
                    foreach (var itemDia in diasTrabajadas)
                    {

                        var listadoAsistenciaByPersonasByDia = listadorAsistenciaAgrupadaByProyectoByNroPersonas.Where(x => x.fecha == itemDia.diaTrabajado).ToList();

                        if (listadoAsistenciaByPersonasByDia != null && listadoAsistenciaByPersonasByDia.ToList().Count > 0)
                        {
                            AsistenciaByProyectoDiaria asistenciaByProyectoDiaria = new AsistenciaByProyectoDiaria();
                            asistenciaByProyectoDiaria.fecha = itemDia.diaTrabajado;
                            asistenciaByProyectoDiaria.Semana = listadoAsistenciaByPersonasByDia.FirstOrDefault().Semana != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().Semana) : 0;
                            asistenciaByProyectoDiaria.NumeroMes = listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroMes != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroMes) : 0;
                            asistenciaByProyectoDiaria.NumeroAño = listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroAño != null ? Convert.ToInt32(listadoAsistenciaByPersonasByDia.FirstOrDefault().NumeroAño) : 0;
                            asistenciaByProyectoDiaria.idMedida = "PER";
                            asistenciaByProyectoDiaria.NombreMes = listadoAsistenciaByPersonasByDia.FirstOrDefault().NombreMes != null ? Convert.ToString(listadoAsistenciaByPersonasByDia.FirstOrDefault().NombreMes) : "";
                            asistenciaByProyectoDiaria.nombreDia = listadoAsistenciaByPersonasByDia.FirstOrDefault().nombreDia != null ? Convert.ToString(listadoAsistenciaByPersonasByDia.FirstOrDefault().nombreDia) : "";
                            asistenciaByProyectoDiaria.sinProyecto = 0;
                            asistenciaByProyectoDiaria.taller = listadoAsistenciaByPersonasByDia.Sum(x => x.taller != null ? x.taller : 0);
                            asistenciaByProyectoDiaria.palta = listadoAsistenciaByPersonasByDia.Sum(x => x.palta != null ? x.palta : 0);
                            asistenciaByProyectoDiaria.planta = listadoAsistenciaByPersonasByDia.Sum(x => x.planta != null ? x.planta : 0);
                            asistenciaByProyectoDiaria.sanidad = listadoAsistenciaByPersonasByDia.Sum(x => x.sanidad != null ? x.sanidad : 0);
                            asistenciaByProyectoDiaria.fertiRiego = listadoAsistenciaByPersonasByDia.Sum(x => x.fertiRiego != null ? x.fertiRiego : 0);
                            asistenciaByProyectoDiaria.evaluaciones = listadoAsistenciaByPersonasByDia.Sum(x => x.evaluaciones != null ? x.evaluaciones : 0);
                            asistenciaByProyectoDiaria.areasVerdes = listadoAsistenciaByPersonasByDia.Sum(x => x.areasVerdes != null ? x.areasVerdes : 0);
                            asistenciaByProyectoDiaria.vigilancia = listadoAsistenciaByPersonasByDia.Sum(x => x.vigilancia != null ? x.vigilancia : 0);
                            asistenciaByProyectoDiaria.laboratorio = listadoAsistenciaByPersonasByDia.Sum(x => x.laboratorio != null ? x.laboratorio : 0);
                            asistenciaByProyectoDiaria.canaSanJuan = listadoAsistenciaByPersonasByDia.Sum(x => x.canaSanJuan != null ? x.canaSanJuan : 0);
                            asistenciaByProyectoDiaria.canaTablazosHuacaBlanca = listadoAsistenciaByPersonasByDia.Sum(x => x.canaTablazosHuacaBlanca != null ? x.canaTablazosHuacaBlanca : 0);
                            asistenciaByProyectoDiaria.serviciosGenerales = listadoAsistenciaByPersonasByDia.Sum(x => x.serviciosGenerales != null ? x.serviciosGenerales : 0);
                            asistenciaByProyectoDiaria.ucupe = listadoAsistenciaByPersonasByDia.Sum(x => x.ucupe != null ? x.ucupe : 0);
                            asistenciaByProyectoDiaria.ConstanciasFallecimiento = listadoAsistenciaByPersonasByDia.Sum(x => x.ConstanciasFallecimiento != null ? x.ConstanciasFallecimiento : 0);
                            asistenciaByProyectoDiaria.sinProyecto = listadoAsistenciaByPersonasByDia.Sum(x => x.sinProyecto != null ? x.sinProyecto : 0);
                            asistenciaByProyectoDiaria.otros = listadoAsistenciaByPersonasByDia.Sum(x => x.otros != null ? x.otros : 0);
                            asistenciaByProyectoDiaria.total = (asistenciaByProyectoDiaria.taller + asistenciaByProyectoDiaria.palta + asistenciaByProyectoDiaria.planta +
                                 asistenciaByProyectoDiaria.sanidad + asistenciaByProyectoDiaria.fertiRiego + asistenciaByProyectoDiaria.evaluaciones + asistenciaByProyectoDiaria.areasVerdes
                                 + asistenciaByProyectoDiaria.vigilancia + asistenciaByProyectoDiaria.laboratorio + asistenciaByProyectoDiaria.canaSanJuan + asistenciaByProyectoDiaria.canaTablazosHuacaBlanca
                                 + asistenciaByProyectoDiaria.serviciosGenerales + asistenciaByProyectoDiaria.ucupe + asistenciaByProyectoDiaria.ConstanciasFallecimiento + asistenciaByProyectoDiaria.sinProyecto
                                 + asistenciaByProyectoDiaria.otros);
                            listadoResumen.Add(asistenciaByProyectoDiaria);
                        }

                    }
                    #endregion
                }
                #endregion
            }

            return listadoResumen;
        }

    }
}
