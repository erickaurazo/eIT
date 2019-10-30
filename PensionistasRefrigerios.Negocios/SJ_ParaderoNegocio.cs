using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Asistencia.Datos;


namespace Asistencia.Negocios
{
    public class SJ_ParaderoNegocio
    {
        private Grupo oTipoParadero;

        public List<Paradero> ObtenerListaParaderos(string periodoConsulta)
        {
            List<Paradero> listado = new List<Paradero>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoConsulta.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Contexto = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                Contexto.CommandTimeout = 99999;

                var resultadoConsulta = Contexto.SJ_Paraderos.ToList().OrderBy(x => x.IdParadero).ToList();

                listado = (from item in resultadoConsulta
                           where item.IdParadero != null
                           group item by new { item.IdParadero } into j
                           select new Paradero
                           {
                               idParadero = j.Key.IdParadero,
                               descripcionParadero = j.FirstOrDefault().DescripcionParadero != null ? j.FirstOrDefault().DescripcionParadero.Trim() : string.Empty,
                               observacion = j.FirstOrDefault().Observacion != null ? j.FirstOrDefault().Observacion.Trim() : string.Empty,
                               estado = j.FirstOrDefault().ESTADO != null ? Convert.ToInt32(j.FirstOrDefault().ESTADO.Value) : 0,
                               tipo = j.FirstOrDefault().tipo != null ? j.FirstOrDefault().tipo.ToString().Trim() : string.Empty,
                               estadoDescripcion = ((j.FirstOrDefault().ESTADO != null ? Convert.ToInt32(j.FirstOrDefault().ESTADO.Value) : 0) == 1) ? "ACTIVO" : "ANULADO",
                               tipoDescripcion = (j.FirstOrDefault().tipo != null ? j.FirstOrDefault().tipo.ToString().Trim() : string.Empty) == "T" ? "TRANSPORTE" : "PENSION",
                           }).ToList();
                    
                    
                Contexto.Connection.Close();
            }

            return listado;
        }

        public SJ_Paradero ObtenerParadero(string periodoConsulta, SJ_Paradero oSJ_Paradero)
        {
            SJ_Paradero oParadero = new SJ_Paradero();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoConsulta.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                Contexto.CommandTimeout = 99999;
                var listado = Contexto.SJ_Paraderos.Where(x => x.IdParadero.ToString().Trim() == oSJ_Paradero.IdParadero.ToString().Trim()).ToList().OrderBy(x => x.IdParadero).ToList();

                if (listado != null && listado.ToList().Count == 1)
                {
                    oParadero = listado.Single();
                }
                Contexto.Connection.Close();
            }
            return oParadero;
        }

        public void Registrar(string periodoRegistro, SJ_Paradero oSJ_Paradero)
        {
            SJ_Paradero oParadero = new SJ_Paradero();
            //using (TransactionScope Scope = new TransactionScope())
            //{
            #region Transaccion
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoRegistro.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                #region
                Contexto.CommandTimeout = 99999;

                var resultadoSubConsulta = Contexto.SJ_Paraderos.Where(x => x.IdParadero == oSJ_Paradero.IdParadero).ToList();

                if (resultadoSubConsulta != null && resultadoSubConsulta.ToList().Count == 1)
                {
                    #region Actualizar
                    oParadero = resultadoSubConsulta.Single();
                    //oParadero.IdParadero = oSJ_Paradero.IdParadero.ToString().Trim();
                    oParadero.DescripcionParadero = oSJ_Paradero.DescripcionParadero != null ? oSJ_Paradero.DescripcionParadero.ToString().Trim() : string.Empty;
                    oParadero.Observacion = oSJ_Paradero.Observacion != null ? oSJ_Paradero.Observacion.ToString().Trim() : string.Empty;
                    oParadero.tipo = oSJ_Paradero.tipo; 

                    //oParadero.ESTADO = oSJ_Paradero.ESTADO;
                    Contexto.SubmitChanges();
                    #endregion
                }
                else
                {
                    if (oSJ_Paradero.IdParadero == "")
                    {
                        #region Registro()
                        oParadero.IdParadero = ObtenerNuevoCodigo(periodoRegistro);
                        oParadero.DescripcionParadero = oSJ_Paradero.DescripcionParadero != null ? oSJ_Paradero.DescripcionParadero.ToString().Trim() : "";
                        oParadero.Observacion = oSJ_Paradero.Observacion != null ? oSJ_Paradero.Observacion.ToString().Trim() : "";
                        oParadero.ESTADO = oSJ_Paradero.ESTADO;
                        oParadero.tipo = oSJ_Paradero.tipo; 
                        Contexto.SJ_Paraderos.InsertOnSubmit(oParadero);
                        Contexto.SubmitChanges();

                        #endregion
                    }
                }
                Contexto.Connection.Close();
                #endregion
            }
            #endregion
            //    Scope.Complete();
            //}

        }

        private string ObtenerNuevoCodigo(string periodoRegistro)
        {
            string cnx = string.Empty;
            string codigo = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoRegistro.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                Contexto.CommandTimeout = 99999;
                string resultado = Contexto.SJ_Paraderos.ToList().OrderByDescending(x => x.IdParadero).ElementAt(0).IdParadero.Substring(1, 3);
                int nuevoCodigo = Convert.ToInt32(resultado) + 1;
                codigo = "P" + nuevoCodigo.ToString().PadLeft(3, '0');
                Contexto.Connection.Close();
            }

            return codigo;
        }

        public void Eliminar(string periodoRegistro, Paradero oSJ_Paradero)
        {
            SJ_Paradero oParadero = new SJ_Paradero();
            //using (TransactionScope Scope = new TransactionScope())
            //{
            #region Transaccion
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoRegistro.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                #region
                Contexto.CommandTimeout = 99999;

                var resultadoSubConsulta = Contexto.SJ_Paraderos.Where(x => x.IdParadero == oSJ_Paradero.idParadero).ToList();

                if (resultadoSubConsulta != null && resultadoSubConsulta.ToList().Count == 1)
                {
                    #region Actualizar

                    oParadero = resultadoSubConsulta.Single();
                    Contexto.SJ_Paraderos.DeleteOnSubmit(oParadero);
                    Contexto.SubmitChanges();
                    #endregion
                }

                Contexto.Connection.Close();
                #endregion
            }
            #endregion
            //    Scope.Complete();
            //}

        }

        /* Se puede anular o activar el paradero */
        public void CambiarEstadoDocumento(string periodoRegistro, Paradero oSJ_Paradero)
        {
            SJ_Paradero oParadero = new SJ_Paradero();
            //using (TransactionScope Scope = new TransactionScope())
            //{
            #region Transaccion
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoRegistro.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                #region
                Contexto.CommandTimeout = 99999;

                var resultadoSubConsulta = Contexto.SJ_Paraderos.Where(x => x.IdParadero == oSJ_Paradero.idParadero).ToList();

                if (resultadoSubConsulta != null && resultadoSubConsulta.ToList().Count == 1)
                {
                    #region Actualizar

                    oParadero = resultadoSubConsulta.Single();
                    if (oParadero.ESTADO == 1)
                    {
                        oParadero.ESTADO = 0;
                    }
                    else
                    {
                        oParadero.ESTADO = 1;
                    }
                    Contexto.SubmitChanges();
                    #endregion
                }

                Contexto.Connection.Close();
                #endregion
            }
            #endregion
            //    Scope.Complete();
            //}


        }



        public List<Grupo> ObtenerListadoTipoParaderos()
        {
            List<Grupo> listadoTipoParaderos = new List<Grupo>();

            oTipoParadero = new Grupo();
            oTipoParadero.Codigo = "T";
            oTipoParadero.Descripcion = "TRANSPORTE";
            listadoTipoParaderos.Add(oTipoParadero);

            oTipoParadero = new Grupo();
            oTipoParadero.Codigo = "P";
            oTipoParadero.Descripcion = "PENSION";
            listadoTipoParaderos.Add(oTipoParadero);


            oTipoParadero = new Grupo();
            oTipoParadero.Codigo = string.Empty;
            oTipoParadero.Descripcion = "SIN ESPECIFICAR";
            listadoTipoParaderos.Add(oTipoParadero);

            return listadoTipoParaderos.OrderBy(x => x.Codigo).ToList();
        }
    }
}
