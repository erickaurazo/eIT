using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transportista.Datos;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using System.Globalization;
//using MyControlsDataBinding.Busquedas;
using MyControlsDataBinding.Clases;
using MyControlsDataBinding.Controles;
using MyControlsDataBinding.ControlesUsuario;
using MyControlsDataBinding.Datos;
using MyControlsDataBinding.Extensions;

namespace Transportista.Negocios
{
    public class SJM_PensionesNegocios
    {
        #region Variables()
        private SJ_RHPensionRefrigerioPersona Personal;
        private string nuevoCodigo;
        private SJM_Pensione tranferenciaPension;
        private List<SJ_RHPensionRefrigerioBuscarPersonaResult> listadoTodoPersonalActivoBD = new List<SJ_RHPensionRefrigerioBuscarPersonaResult>();
        private decimal? importeDistribuir;
        private decimal? totalMinutosTrabajador;
        private decimal? totalRacimosTrabajador;
        private string pensiones;
        private string idPension;
        private string subplanilla;
        private SJ_LogTablasPension logTablas;
        private SJ_RHPensionRefrigerioPersonaListarResult oRegistroPersonal;
        private SJM_PensionesNegocios modeloNegocio;
        #endregion

        //Listado de todos los documentos con movimiento de registro de refrigerio
        public List<SJ_RHMovimientoAsistenciaRefrigeriosResult> ListarMovimientosAsistenciaRefrigerio(string Desde, string Hasta, string periodo)
        {
            List<SJ_RHMovimientoAsistenciaRefrigeriosResult> Listado = new List<SJ_RHMovimientoAsistenciaRefrigeriosResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                var lista = Modelo.SJ_RHMovimientoAsistenciaRefrigerios(Desde, Hasta).ToList();


                Listado = (from item in lista
                           where item.codigo != "" && item.codigo != null
                           group item by new { item.codigo } into j
                           select new SJ_RHMovimientoAsistenciaRefrigeriosResult
                           {

                               idempresa = j.FirstOrDefault().idempresa != null ? j.FirstOrDefault().idempresa.ToString().Trim() : "001",
                               idsucursal = j.FirstOrDefault().idsucursal != null ? j.FirstOrDefault().idsucursal.ToString().Trim() : "002",
                               codigo = j.Key.codigo.ToString().Trim(),
                               fecha = j.FirstOrDefault().fecha != null ? j.FirstOrDefault().fecha : string.Empty,
                               Documento = j.FirstOrDefault().Documento != null ? j.FirstOrDefault().Documento.ToString().Trim() : string.Empty,
                               //iddocumento = j.FirstOrDefault().iddocumento != null ? j.FirstOrDefault().iddocumento.ToString().Trim() : "RAR",
                               //serie = j.FirstOrDefault().serie != null ? j.FirstOrDefault().serie.ToString().Trim() : "0001",
                               //numero = j.FirstOrDefault().numero != null ? j.FirstOrDefault().numero.ToString().Trim() : "0000000",
                               numeroManual = j.FirstOrDefault().numeroManual != null ? j.FirstOrDefault().numeroManual.ToString().Trim() : string.Empty,
                               Idpension = j.FirstOrDefault().Idpension != null ? j.FirstOrDefault().Idpension.Value : 0,

                               NroDesayunos = j.Max(x => x.NroDesayunos) != null ? j.Max(x => x.NroDesayunos).Value : 0,
                               NroAlmuerzos = j.Max(x => x.NroAlmuerzos) != null ? j.Max(x => x.NroAlmuerzos).Value : 0,
                               NroCenas = j.Max(x => x.NroCenas) != null ? j.Max(x => x.NroCenas).Value : 0,

                               PensionNroRUC = j.FirstOrDefault().PensionNroRUC != null ? j.FirstOrDefault().PensionNroRUC.ToString().Trim() : string.Empty,
                               PensionDescripcion = j.FirstOrDefault().PensionDescripcion != null ? j.FirstOrDefault().PensionDescripcion.ToString().Trim() : string.Empty,
                               PensionNroDNI = j.FirstOrDefault().PensionNroDNI != null ? j.FirstOrDefault().PensionNroDNI.ToString().Trim() : string.Empty,

                               PensionDescripcionComercial = j.FirstOrDefault().PensionDescripcionComercial != null ? j.FirstOrDefault().PensionDescripcionComercial.ToString().Trim() : string.Empty,
                               idestado = j.FirstOrDefault().idestado != null ? j.FirstOrDefault().idestado.ToString().Trim() : "PE",
                               Estado = j.FirstOrDefault().Estado != null ? j.FirstOrDefault().Estado.ToString().Trim() : "PENDIENTE",
                           }
                               ).ToList();

            }
            return Listado;
        }

        //Obtengo la cabecera del movimiento del formulario MOVIMIENTO REGISTRO ASISTENCIAS REFRIGERIO
        public List<SJ_RHMovimientoAsistenciaRefrigerioObjetoResult> ObtenerObjetoAsistenciaRefrigerio(string codigo, string periodo)
        {
            List<SJ_RHMovimientoAsistenciaRefrigerioObjetoResult> Objeto = new List<SJ_RHMovimientoAsistenciaRefrigerioObjetoResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Trim()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                var lista = Modelo.SJ_RHMovimientoAsistenciaRefrigerioObjeto(codigo).ToList();


                Objeto = (from item in lista
                          where item.codigo != "" && item.codigo != null
                          group item by new { item.codigo } into j
                          select new SJ_RHMovimientoAsistenciaRefrigerioObjetoResult
                          {

                              idempresa = j.FirstOrDefault().idempresa != null ? j.FirstOrDefault().idempresa.ToString().Trim() : "001",
                              idsucursal = j.FirstOrDefault().idsucursal != null ? j.FirstOrDefault().idsucursal.ToString().Trim() : "002",
                              codigo = j.Key.codigo.ToString().Trim(),
                              fecha = j.FirstOrDefault().fecha != null ? j.FirstOrDefault().fecha : string.Empty,
                              Documento = j.FirstOrDefault().Documento != null ? j.FirstOrDefault().Documento.ToString().Trim() : string.Empty,
                              iddocumento = j.FirstOrDefault().iddocumento != null ? j.FirstOrDefault().iddocumento.ToString().Trim() : "RAR",
                              serie = j.FirstOrDefault().serie != null ? j.FirstOrDefault().serie.ToString().Trim() : "0001",
                              numero = j.FirstOrDefault().numero != null ? j.FirstOrDefault().numero.ToString().Trim() : "0000000",
                              numeroManual = j.FirstOrDefault().numeroManual != null ? j.FirstOrDefault().numeroManual.ToString().Trim() : string.Empty,
                              Idpension = j.FirstOrDefault().Idpension != null ? j.FirstOrDefault().Idpension.Value : 0,

                              NroDesayunos = j.Max(x => x.NroDesayunos) != null ? j.Max(x => x.NroDesayunos).Value : 0,
                              NroAlmuerzos = j.Max(x => x.NroAlmuerzos) != null ? j.Max(x => x.NroAlmuerzos).Value : 0,
                              NroCenas = j.Max(x => x.NroCenas) != null ? j.Max(x => x.NroCenas).Value : 0,

                              PensionNroRUC = j.FirstOrDefault().PensionNroRUC != null ? j.FirstOrDefault().PensionNroRUC.ToString().Trim() : string.Empty,
                              PensionDescripcion = j.FirstOrDefault().PensionDescripcion != null ? j.FirstOrDefault().PensionDescripcion.ToString().Trim() : string.Empty,
                              PensionNroDNI = j.FirstOrDefault().PensionNroDNI != null ? j.FirstOrDefault().PensionNroDNI.ToString().Trim() : string.Empty,

                              PensionDescripcionComercial = j.FirstOrDefault().PensionDescripcionComercial != null ? j.FirstOrDefault().PensionDescripcionComercial.ToString().Trim() : string.Empty,
                              idestado = j.FirstOrDefault().idestado != null ? j.FirstOrDefault().idestado.ToString().Trim() : "PE",
                              Estado = j.FirstOrDefault().Estado != null ? j.FirstOrDefault().Estado.ToString().Trim() : "PENDIENTE",
                          }
                               ).ToList();

            }
            return Objeto;
        }

        //Obtengo el detalle de la cabecera del movimiento del formulario MOVIMIENTO REGISTRO ASISTENCIAS REFRIGERIO
        public List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult> ObtenerObjetoDetalleAsistenciaRefrigerio(string codigo, string dniPension, string Desde, string Hasta)
        {
            List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult> Listado = new List<SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalleResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + Convert.ToDateTime(Desde).Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800000;
                try
                {
                    Listado = Modelo.SJ_RHMovimientoAsistenciaRefrigerioObjetoDetalle(codigo, dniPension, Desde, Hasta).ToList();
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return Listado;
        }

        //Obtener el nombre del trabajador x numero de DNI, solo si estan activos.
        public string ObtenerNombresCompletosxDNI(string nroDni)
        {
            string cnx, Nombres = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 1800000;
                try
                {
                    if (Modelo.SJ_RHPensionRefrigerioObtenerNombresxDNI(nroDni) != null)
                    {
                        if (Modelo.SJ_RHPensionRefrigerioObtenerNombresxDNI(nroDni).ToList().Count == 1)
                        {
                            Nombres = Modelo.SJ_RHPensionRefrigerioObtenerNombresxDNI(nroDni) != null ? Modelo.SJ_RHPensionRefrigerioObtenerNombresxDNI(nroDni).FirstOrDefault().NOMBRE.ToString() : string.Empty;
                        }
                        else
                        {
                            Nombres = "";
                        }
                    }
                    else
                    {
                        Nombres = "";
                    }


                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }
            return Nombres;
        }

        public string RegistrarAsistenciaRefrigerios(List<SJM_Pensione> Listado, List<SJM_Pensione> ListadoEliminados)
        {
            string codigo = string.Empty;
            //using (TransactionScope Scope = new TransactionScope())
            //{
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                #region Eliminar Lista de Eliminados()
                if (ListadoEliminados != null)
                {
                    if (ListadoEliminados.ToList().Count > 0)
                    {
                        #region
                        foreach (SJM_Pensione item in Listado)
                        {
                            try
                            {
                                if (Modelo.SJM_Pensiones.Where(x => x.IdPension == item.IdPension).ToList().Count == 1)
                                {
                                    SJM_Pensione Obj = new SJM_Pensione();
                                    Obj = Modelo.SJM_Pensiones.Where(x => x.IdPension == item.IdPension).Single();
                                    Modelo.SJM_Pensiones.DeleteOnSubmit(Obj);
                                    Modelo.SubmitChanges();
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
                #endregion

                nuevoCodigo = ObtenerCodigoRegistroAsistenciaRefrigerio().ToString().Trim();

                #region Registro()
                foreach (SJM_Pensione item in Listado)
                {
                    if (item.IdPension == null || item.IdPension.ToString().Trim() == "")
                    {
                        #region Nuevo()
                        try
                        {
                            if (item.IdPension == 0)
                            {
                                #region Nuevo Registro()
                                SJM_Pensione Obj = new SJM_Pensione();
                                //Obj.IdPension = nuevoCodigo;
                                Obj.IdPension = item.IdPension;
                                Obj.DniPension = item.DniPension;
                                Obj.NombresPension = item.NombresPension;
                                Obj.DniTrabajador = item.DniTrabajador;
                                Obj.NombresTrabajador = item.NombresTrabajador;
                                Obj.TipoComida = item.TipoComida;
                                Obj.FechaPension = item.FechaPension;
                                Obj.FechaRegistro = item.FechaRegistro;
                                Obj.EsProcesado = item.EsProcesado;
                                Obj.idParadero = item.idParadero != null ? item.idParadero : "S/P";
                                Modelo.SJM_Pensiones.InsertOnSubmit(Obj);
                                Modelo.SubmitChanges();
                                codigo = Obj.IdPension.ToString();
                                #endregion
                            }
                            else
                            {
                                #region Actualizar()
                                if (Modelo.SJM_Pensiones.Where(x => x.IdPension == null && x.IdPension == item.IdPension).ToList().Count == 1)
                                {
                                    Modelo.CommandTimeout = 1890;
                                    SJM_Pensione Obj = new SJM_Pensione();
                                    Obj = Modelo.SJM_Pensiones.Where(x => x.IdPension == null && x.IdPension == item.IdPension).Single();
                                    //Obj.IdPension = nuevoCodigo;
                                    Obj.DniTrabajador = item.DniTrabajador;
                                    Obj.NombresTrabajador = item.NombresTrabajador;
                                    Obj.TipoComida = item.TipoComida;
                                    //Obj.FechaPension = item.FechaPension;
                                    //Obj.FechaRegistro = item.FechaRegistro;
                                    //Obj.EsProcesado = item.EsProcesado;
                                    Modelo.SubmitChanges();
                                    codigo = Obj.IdPension.ToString();
                                }
                                #endregion
                            }
                        }
                        catch (Exception Ex)
                        {

                            Ex.Message.ToString(); ;
                        }

                        #endregion
                    }
                    else
                    {
                        #region Actualizar()
                        try
                        {
                            if (Modelo.SJM_Pensiones.Where(x => x.IdPension == item.IdPension && x.IdPension == item.IdPension).ToList().Count == 1)
                            {
                                SJM_Pensione Obj = new SJM_Pensione();
                                Obj = Modelo.SJM_Pensiones.Where(x => x.IdPension == item.IdPension && x.IdPension == item.IdPension).Single();
                                //Obj.IdPension = item.IdPension;
                                //Obj.DniPension = item.DniPension;
                                //Obj.NombresPension = item.NombresPension;
                                Obj.DniTrabajador = item.DniTrabajador;
                                Obj.NombresTrabajador = item.NombresTrabajador;
                                Obj.TipoComida = item.TipoComida;
                                //Obj.FechaPension = item.FechaPension;
                                //Obj.FechaRegistro = item.FechaRegistro;
                                //Obj.EsProcesado = item.EsProcesado;
                                Modelo.SubmitChanges();
                                codigo = Obj.IdPension.ToString();
                            }
                        }
                        catch (Exception Ex)
                        {

                            throw Ex;
                        }

                        #endregion
                    }
                }
                #endregion
                //}
                //Scope.Complete();
            }
            return codigo;
        }

        public string ObtenerCodigoRegistroAsistenciaRefrigerio()
        {
            string codigo = string.Empty;
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (SJ_RHFacturacionTransportistaDataContext Modelo = new SJ_RHFacturacionTransportistaDataContext(cnx))
            {
                codigo = Modelo.ObtenerId().FirstOrDefault().Codigo != null ? Modelo.ObtenerId().FirstOrDefault().Codigo.ToString().Trim() : string.Empty;
            }
            return codigo;
        }

        // LISTAR TODO EL PERSONAL de la programacion del personal con la relacion de muchos a muchos
        public List<SJ_RHPensionRefrigerioPersonaListarResult> ObtenerListadoProgramacionRefrigerios(string periodo, string estado)
        {
            #region
            List<SJ_RHPensionRefrigerioPersonaListarResult> Lista = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 91899000;
                try
                {
                    if (estado == "AC")
                    {
                        Lista = Modelo.SJ_RHPensionRefrigerioPersonaListar().Where(x => x.IdEstado.Trim() == "AC").ToList();
                    }
                    else
                    {
                        Lista = Modelo.SJ_RHPensionRefrigerioPersonaListar().ToList();
                    }

                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return Lista;
            #endregion
        }

        // SLISTAR TODO EL PERSONAL de la programacion del personal con la relacion de muchos a muchos
        public List<SJ_RHPensionRefrigerioPersonaListarResult> ObtenerListadoProgramacionPersonalSinRenovarTickets(string periodo)
        {
            #region
            List<SJ_RHPensionRefrigerioPersonaListarResult> Lista = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 91899000;
                try
                {
                    var listaResultado = Modelo.SJ_RHListadoDiasTranscurridosPorProgramacionPension().ToList();

                    if (listaResultado != null && listaResultado.ToList().Count > 0)
                    {

                        Lista = (from item in listaResultado
                                 where item.Id > 0
                                 group item by new { item.Id } into j
                                 select new SJ_RHPensionRefrigerioPersonaListarResult
                                 {
                                     Id = j.Key.Id,

                                     IdCodigoPersonal = j.FirstOrDefault().IdCodigoPersonal != null ? j.FirstOrDefault().IdCodigoPersonal.Trim() : string.Empty,
                                     NroDocumento = j.FirstOrDefault().NroDocumento != null ? j.FirstOrDefault().NroDocumento.Trim() : string.Empty,
                                     NombresCompletos = j.FirstOrDefault().NombresCompletos != null ? j.FirstOrDefault().NombresCompletos.Trim() : string.Empty,
                                     IdSubPlanilla = j.FirstOrDefault().IdSubPlanilla != null ? j.FirstOrDefault().IdSubPlanilla.Trim() : string.Empty,
                                     SubPlanilla = j.FirstOrDefault().SubPlanilla != null ? j.FirstOrDefault().SubPlanilla.Trim() : string.Empty,
                                     IdPension = j.FirstOrDefault().IdPension != null ? j.FirstOrDefault().IdPension.Value : 0,
                                     NroDNIPension = j.FirstOrDefault().NroDNIPension != null ? j.FirstOrDefault().NroDNIPension.Trim() : string.Empty,
                                     Pension = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.Trim() : string.Empty,
                                     Condicion = j.FirstOrDefault().Condicion != null ? j.FirstOrDefault().Condicion.Trim() : string.Empty,
                                     Desayuno = j.FirstOrDefault().Desayuno != null ? Convert.ToByte(j.FirstOrDefault().Desayuno.Value) : Convert.ToByte(0),
                                     Almuerzo = j.FirstOrDefault().Almuerzo != null ? Convert.ToByte(j.FirstOrDefault().Almuerzo.Value) : Convert.ToByte(0),
                                     Cena = j.FirstOrDefault().Cena != null ? Convert.ToByte(j.FirstOrDefault().Cena.Value) : Convert.ToByte(0),
                                     Otro = j.FirstOrDefault().Otro != null ? Convert.ToByte(j.FirstOrDefault().Otro.Value) : Convert.ToByte(0),
                                     ValidoDesde = j.FirstOrDefault().ValidoDesde != null ? Convert.ToDateTime(j.FirstOrDefault().ValidoDesde.Value) : (DateTime?)null,
                                     ValidoHasta = j.FirstOrDefault().ValidoHasta != null ? Convert.ToDateTime(j.FirstOrDefault().ValidoHasta.Value) : (DateTime?)null,
                                     IdEstado = j.FirstOrDefault().IdEstado != null ? j.FirstOrDefault().IdEstado.Trim() : string.Empty,
                                     Estado = j.FirstOrDefault().Estado != null ? j.FirstOrDefault().Estado.Trim() : string.Empty,
                                     Item = j.FirstOrDefault().Item != null ? j.FirstOrDefault().Item.Trim() : string.Empty,
                                     idParadero = j.FirstOrDefault().idParadero != null ? j.FirstOrDefault().idParadero.Trim() : string.Empty,
                                     paradero = j.FirstOrDefault().paradero != null ? j.FirstOrDefault().paradero : string.Empty,
                                     diasFinalizacion = j.FirstOrDefault().diasFinalizacion != null ? j.FirstOrDefault().diasFinalizacion.Value : 0,
                                 }).ToList();

                    }

                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return Lista;
            #endregion
        }

        // AnularTicketsVencidoProgramacionRefrigerio
        public string AnularTicketsVencidoProgramacionRefrigerio(string periodo)
        {
            #region
            string resultado = string.Empty;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 91899000;
                try
                {
                    Modelo.SJ_RHAnularTicketsVencidoProgramacionRefrigerio();
                    resultado = "Correcto";
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return resultado;
            #endregion
        }

        // LISTAR TODO EL PERSONAL de la programacion del personal agrupado por trabajador
        public List<SJ_RHPensionRefrigerioPersonaListarResult> ObtenerListadoRefrigerioByTrabajador(List<SJ_RHPensionRefrigerioPersonaListarResult> listadoRefrigerioTrabajadorByPension)
        {
            List<SJ_RHPensionRefrigerioPersonaListarResult> Lista = new List<SJ_RHPensionRefrigerioPersonaListarResult>();
            try
            {
                /* 1.- Verifico que la lista contenta datos */
                if (listadoRefrigerioTrabajadorByPension != null && listadoRefrigerioTrabajadorByPension.ToList().Count > 0)
                {
                    /*1.1 agrupo mi lista por trabajador */
                    var trabajadores = (from item in listadoRefrigerioTrabajadorByPension
                                        where item.Id != null && item.IdCodigoPersonal != null
                                        group item by new { item.IdCodigoPersonal } into j
                                        select new
                                        {
                                            idCodigoGeneral = j.Key.IdCodigoPersonal.ToString().Trim(),
                                            nroDocumento = j.FirstOrDefault().NroDocumento != null ? j.FirstOrDefault().NroDocumento.ToString().Trim() : string.Empty,
                                            nombresCompletos = j.FirstOrDefault().NombresCompletos != null ? j.FirstOrDefault().NombresCompletos.ToString().Trim() : string.Empty,
                                            idSubPlanilla = j.FirstOrDefault().IdSubPlanilla != null ? j.FirstOrDefault().IdSubPlanilla : string.Empty,
                                        }).ToList();
                    /*1.2 Obtengo una lista personalizada por trabajador */
                    if (trabajadores != null && trabajadores.ToList().Count > 0)
                    {
                        #region
                        foreach (var trabajador in trabajadores)
                        {
                            /* 1.2.1 Obtengo la lista del trabajador filtrada de la lista de todos los registros de mi consulta principal */
                            var listadoPersonalByNroDNI = listadoRefrigerioTrabajadorByPension.Where(x => x.IdCodigoPersonal.ToString().Trim() == trabajador.idCodigoGeneral.ToString().Trim()).ToList();

                            /* 1.2.2 Valido que el dni del trabajador tenga al menos un registro, de solo tener un registro en la lista sólo lo asocio a mi nueva lista que voy a mostrar
                             caso contrario tengo que analizar si el colaborar esta en la misma pensión o en mas de dos pensiones */
                            if (listadoPersonalByNroDNI != null && listadoPersonalByNroDNI.ToList().Count == 1)
                            {
                                oRegistroPersonal = new SJ_RHPensionRefrigerioPersonaListarResult();
                                oRegistroPersonal = listadoPersonalByNroDNI.Single();
                                Lista.Add(oRegistroPersonal);
                            }
                            /* 1.2.3 Analizar si el colaborar esta en la misma pensión o en mas de dos pensiones, agrupado por el id del registro, eso se debe a que en ocasiones tengo dos items en el detalle de mis programación, lo ideal es tener solo una activa */
                            else if (listadoPersonalByNroDNI.ToList().Count > 1)
                            {
                                /* 1.2.3.1 Agrupo lista del trabajador por codigo del registro */
                                var trabajadorByCodigo = (from item in listadoPersonalByNroDNI
                                                          where item.Id != null && item.Id != null
                                                          group item by new { item.Id } into j
                                                          select new
                                                          {
                                                              codigo = j.Key.Id
                                                          }).ToList();

                                /* 1.2.3.2 Si Se trata del mismo registro, solo obtengo el primer elemento de mi lista */
                                if (trabajadorByCodigo.ToList().Count == 1)
                                {
                                    oRegistroPersonal = new SJ_RHPensionRefrigerioPersonaListarResult();
                                    oRegistroPersonal = listadoPersonalByNroDNI.ElementAt(0);
                                    Lista.Add(oRegistroPersonal);
                                }
                                /* 1.2.3.3 Se trata de un registro donde el trabajador esta en mas de una pensión */
                                else
                                {
                                    #region  Trabajador esta en mas de una pensión()
                                    oRegistroPersonal = new SJ_RHPensionRefrigerioPersonaListarResult();
                                    oRegistroPersonal.Id = 0;
                                    oRegistroPersonal.IdCodigoPersonal = trabajador.idCodigoGeneral;
                                    oRegistroPersonal.NroDocumento = trabajador.nroDocumento;
                                    oRegistroPersonal.NombresCompletos = trabajador.nombresCompletos;

                                    var subPlanillasByPersona = (from item in listadoPersonalByNroDNI
                                                                 where item.Id != null && item.IdSubPlanilla != null
                                                                 group item by new { item.IdSubPlanilla } into j
                                                                 select new
                                                                 {
                                                                     idPlanilla = j.Key.IdSubPlanilla.ToString().Trim(),
                                                                     subPlanilla = j.FirstOrDefault().SubPlanilla != null ? j.FirstOrDefault().SubPlanilla.ToString().Trim() : string.Empty,
                                                                 }).ToList();

                                    if (subPlanillasByPersona != null && subPlanillasByPersona.ToList().Count == 1)
                                    {
                                        oRegistroPersonal.IdSubPlanilla = subPlanillasByPersona.FirstOrDefault().idPlanilla.ToString().Trim();
                                        oRegistroPersonal.SubPlanilla = subPlanillasByPersona.FirstOrDefault().subPlanilla.ToString().Trim();
                                    }
                                    else if (subPlanillasByPersona != null && subPlanillasByPersona.ToList().Count > 1)
                                    {
                                        oRegistroPersonal.IdSubPlanilla = "0";
                                        string subPlanillasTrabajador = string.Empty;
                                        foreach (var item in subPlanillasByPersona)
                                        {
                                            subPlanillasTrabajador += item.subPlanilla + " - ";
                                        }
                                        oRegistroPersonal.SubPlanilla = subPlanillasTrabajador;
                                    }
                                    var pensionByPersona = (from item in listadoPersonalByNroDNI
                                                            where item.Id != null && item.IdPension != null
                                                            group item by new { item.IdPension } into j
                                                            select new
                                                            {
                                                                idPension = j.Key.IdPension,
                                                                nroDniPension = j.FirstOrDefault().NroDNIPension != null ? j.FirstOrDefault().NroDNIPension.ToString().Trim() : string.Empty,
                                                                pension = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.ToString().Trim() : string.Empty,
                                                                idparadero = j.FirstOrDefault().idParadero != null ? j.FirstOrDefault().idParadero.ToString().Trim() : string.Empty,
                                                                paradero = j.FirstOrDefault().paradero != null ? j.FirstOrDefault().paradero.ToString().Trim() : string.Empty,
                                                                item = j.FirstOrDefault().Item != null ? j.FirstOrDefault().Item.ToString().Trim() : string.Empty,
                                                            }).ToList();
                                    if (pensionByPersona != null && pensionByPersona.ToList().Count == 1)
                                    {
                                        oRegistroPersonal.IdPension = pensionByPersona.FirstOrDefault().idPension;
                                        oRegistroPersonal.NroDNIPension = pensionByPersona.FirstOrDefault().nroDniPension.ToString().Trim();
                                        oRegistroPersonal.Pension = pensionByPersona.FirstOrDefault().pension.ToString().Trim();
                                    }
                                    else if (pensionByPersona != null && pensionByPersona.ToList().Count > 1)
                                    {
                                        oRegistroPersonal.IdPension = 0;
                                        string dniPensionByTrabajador = string.Empty;
                                        string pensionByTrabajador = string.Empty;
                                        foreach (var item in pensionByPersona)
                                        {
                                            dniPensionByTrabajador += item.nroDniPension + " - ";
                                            pensionByTrabajador += item.pension + " - ";
                                        }
                                        oRegistroPersonal.NroDNIPension = dniPensionByTrabajador;
                                        oRegistroPersonal.Pension = pensionByTrabajador;
                                    }
                                    var CondicionByPersona = (from item in listadoPersonalByNroDNI
                                                              where item.Id != null && item.Condicion != null
                                                              group item by new { item.Condicion } into j
                                                              select new
                                                              {
                                                                  condicion = j.Key.Condicion,
                                                              }).ToList();

                                    if (CondicionByPersona != null && CondicionByPersona.ToList().Count == 1)
                                    {
                                        oRegistroPersonal.Condicion = CondicionByPersona.FirstOrDefault().condicion.ToString().Trim();
                                    }
                                    else if (CondicionByPersona != null && CondicionByPersona.ToList().Count > 1)
                                    {
                                        oRegistroPersonal.Condicion = "ACTIVO";
                                    }
                                    else
                                    {
                                        oRegistroPersonal.Condicion = "INACTIVO";
                                    }
                                    oRegistroPersonal.Desayuno = listadoPersonalByNroDNI.Max(x => x.Desayuno);
                                    oRegistroPersonal.Almuerzo = listadoPersonalByNroDNI.Max(x => x.Almuerzo);
                                    oRegistroPersonal.Cena = listadoPersonalByNroDNI.Max(x => x.Cena);
                                    oRegistroPersonal.Otro = listadoPersonalByNroDNI.Max(x => x.Otro);
                                    oRegistroPersonal.ValidoDesde = listadoPersonalByNroDNI.Max(x => x.ValidoDesde);
                                    oRegistroPersonal.ValidoHasta = listadoPersonalByNroDNI.Max(x => x.ValidoHasta);
                                    oRegistroPersonal.IdEstado = listadoPersonalByNroDNI.Max(x => x.IdEstado);
                                    oRegistroPersonal.Estado = (listadoPersonalByNroDNI.Max(x => x.IdEstado.Trim()) == "AC" ? "ACTIVO" : "ANULADO");
                                    oRegistroPersonal.idParadero = pensionByPersona.FirstOrDefault().idparadero != null ? pensionByPersona.FirstOrDefault().idparadero : string.Empty;
                                    oRegistroPersonal.paradero = pensionByPersona.FirstOrDefault().paradero != null ? pensionByPersona.FirstOrDefault().paradero : string.Empty;
                                    oRegistroPersonal.Item = pensionByPersona.FirstOrDefault().item != null ? pensionByPersona.FirstOrDefault().item : string.Empty;
                                    Lista.Add(oRegistroPersonal);
                                    #endregion
                                }
                            }
                        }
                        #endregion
                    }

                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


            return Lista;
        }

        // para el boton buscar personal
        public List<SJ_RHPensionRefrigerioBuscarPersonaxCodigoResult> ObtenerInformacionGeneralDePersonaxCodigo(string IdCodigoGeneral)
        {
            List<SJ_RHPensionRefrigerioBuscarPersonaxCodigoResult> Listado = new List<SJ_RHPensionRefrigerioBuscarPersonaxCodigoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 180000;

                // Obtengo la lista de todos los trabajadores activos del 2014
                var ListadoTodos = Modelo.SJ_RHPensionRefrigerioBuscarPersonaxCodigo(IdCodigoGeneral).ToList();
                // Obtengo todos el personal registrado sin importar su estado
                var ListarTodosExistentes = Modelo.SJ_RHPensionRefrigerioPersonalRegistrado().ToList();
                // Creo un arreglo para obtener el codigo del trabajador
                List<string> ListarCodigoPersonalExistente = new List<string>();

                foreach (var item in ListarTodosExistentes)
                {
                    // lleno mi lista a comparar
                    ListarCodigoPersonalExistente.Add(item.IdCodigoPersonal.ToString().Trim());
                }

                Listado = (from items in ListadoTodos.ToList()
                           where !(ListarCodigoPersonalExistente.Contains(items.IdCodigoPersonal.ToString()))
                           select items
                           ).ToList();

                Modelo.Connection.Close();
            }

            return Listado;
        }

        public List<SJ_RHPensionRefrigerioPersonalRegistradoResult> ObtenerListaPersonalRegistrado()
        {
            List<SJ_RHPensionRefrigerioPersonalRegistradoResult> Listado = new List<SJ_RHPensionRefrigerioPersonalRegistradoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 180000;

                Listado = Modelo.SJ_RHPensionRefrigerioPersonalRegistrado().ToList();

                Modelo.Connection.Close();
            }
            return Listado;
        }

        public List<SJ_RHPensionRefrigerioPersonalRegistradoResult> ObtenerListaPersonalRegistrado(int Codigo)
        {
            List<SJ_RHPensionRefrigerioPersonalRegistradoResult> Listado = new List<SJ_RHPensionRefrigerioPersonalRegistradoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 180000;

                Listado = Modelo.SJ_RHPensionRefrigerioPersonalRegistrado().Where(x => x.Id == Codigo).ToList();

                Modelo.Connection.Close();
            }
            return Listado;
        }

        public List<SJ_RHPensionRefrigerioBuscarPersonaResult> ObtenerListaPersonalNuevo()
        {
            List<SJ_RHPensionRefrigerioBuscarPersonaResult> Listado = new List<SJ_RHPensionRefrigerioBuscarPersonaResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9980000;

                // Obtengo la lista de todos los trabajadores activos del 2014
                var ListadoTodos = Modelo.SJ_RHPensionRefrigerioBuscarPersona().ToList();

                //// Obtengo todos el personal registrado sin importar su estado
                //var ListarTodosExistentes = Modelo.SJ_RHPensionRefrigerioPersonalRegistrado().ToList();
                //// Creo un arreglo para obtener el codigo del trabajador
                //List<string> ListarCodigoPersonalExistente = new List<string>();

                //foreach (var item in ListarTodosExistentes)
                //{
                //    // lleno mi lista a comparar
                //    ListarCodigoPersonalExistente.Add(item.IdCodigoPersonal.ToString().Trim());
                //}

                //Listado = (from items in ListadoTodos.ToList()
                //           where !(ListarCodigoPersonalExistente.Contains(items.IdCodigoPersonal.ToString()))
                //           select items
                //           ).ToList();

                Listado = ListadoTodos;
                Modelo.Connection.Close();
            }

            return Listado;
        }

        public List<SJ_RHPensionRefrigerioPersonaDetalleListadoResult> ObtenerListaPersonalRegistradoDetallado(int Codigo)
        {
            List<SJ_RHPensionRefrigerioPersonaDetalleListadoResult> Listado = new List<SJ_RHPensionRefrigerioPersonaDetalleListadoResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9899900;

                try
                {
                    Listado = Modelo.SJ_RHPensionRefrigerioPersonaDetalleListado(Codigo).ToList();
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
            }


            return Listado;
        }

        /* Lista de asistencias a las personas que reciben refigerios y que se encuentran pendientes de movimiento de asistencia diario */
        public List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ObtenerListaAsistenciasPersonalPendientesMovimientoAsistencia(string periodo, string fechaDesde, string fechaHasta, string dniPension)
        {
            List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> Listado = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Substring(0, 4)].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                try
                {
                    #region Consultar()
                    /* mejora en este reporte es asociar a cuantas planillas esta asociado este trabajador, mejor dicho agrupar por codigo de transferencia */
                    var listadoResultadoConsulta = Modelo.SJ_RHAsistenciasRefrigeriosPendientesMovimiento(fechaDesde, fechaHasta, (dniPension != null ? dniPension : "")).ToList();

                    /* OBTENGO TODAS LAS TRANSFERENCIAS VALIDAS PARA EL PROCESO */
                    /* En esta asiste*/
                    var listadoCodigoTransferenciaAsistencia = (from item in listadoResultadoConsulta
                                                                where item.idMovimientoTransferencia != null && item.estado == Convert.ToByte(1) && item.excluirDescuento == 0
                                                                group item by new { item.idMovimientoTransferencia } into j
                                                                select new
                                                                {
                                                                    codigoTransfereciaAsistencia = j.Key.idMovimientoTransferencia,
                                                                }).ToList();


                    if (listadoCodigoTransferenciaAsistencia != null && listadoCodigoTransferenciaAsistencia.ToList().Count > 0)
                    {
                        foreach (var itemTransferido in listadoCodigoTransferenciaAsistencia)
                        {
                            var resultadoByItem = listadoResultadoConsulta.Where(x => x.idMovimientoTransferencia == itemTransferido.codigoTransfereciaAsistencia).ToList();
                            if (resultadoByItem != null && resultadoByItem.ToList().Count > 0)
                            {
                                SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult registroTransferencia = new SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult();
                                registroTransferencia.idMovimientoTransferencia = itemTransferido.codigoTransfereciaAsistencia;
                                //registroTransferencia.FechaRefrigerio = resultadoByItem.FirstOrDefault().FechaRefrigerio != null ? resultadoByItem.FirstOrDefault().FechaRefrigerio.Value : (DateTime?)null;
                                registroTransferencia.idCodigoGeneral = resultadoByItem.FirstOrDefault().idCodigoGeneral != null ? resultadoByItem.FirstOrDefault().idCodigoGeneral.ToString().Trim() : string.Empty;
                                registroTransferencia.NombresTrabajador = resultadoByItem.FirstOrDefault().NombresTrabajador != null ? resultadoByItem.FirstOrDefault().NombresTrabajador.ToString().Trim() : string.Empty;
                                registroTransferencia.semanaAsistencia = resultadoByItem.FirstOrDefault().semanaAsistencia != null ? resultadoByItem.FirstOrDefault().semanaAsistencia : 0;
                                registroTransferencia.FechaRefrigerio = resultadoByItem.FirstOrDefault().FechaRefrigerio != null ? resultadoByItem.FirstOrDefault().FechaRefrigerio.Value : (DateTime?)null;
                                registroTransferencia.DniTrabajador = resultadoByItem.FirstOrDefault().DniTrabajador != null ? resultadoByItem.FirstOrDefault().DniTrabajador.ToString().Trim() : string.Empty;
                                registroTransferencia.NombresTrabajadorSistema = resultadoByItem.FirstOrDefault().NombresTrabajadorSistema != null ? resultadoByItem.FirstOrDefault().NombresTrabajadorSistema.ToString().Trim() : string.Empty;
                                registroTransferencia.idRefrigerio = resultadoByItem.FirstOrDefault().idRefrigerio != null ? resultadoByItem.FirstOrDefault().idRefrigerio : 0;
                                registroTransferencia.Refrigerio = resultadoByItem.FirstOrDefault().Refrigerio != null ? resultadoByItem.FirstOrDefault().Refrigerio.ToString().Trim() : string.Empty;
                                registroTransferencia.DniPension = resultadoByItem.FirstOrDefault().DniPension != null ? resultadoByItem.FirstOrDefault().DniPension.ToString().Trim() : string.Empty;
                                registroTransferencia.NombresPension = resultadoByItem.FirstOrDefault().NombresPension != null ? resultadoByItem.FirstOrDefault().NombresPension.ToString().Trim() : string.Empty;
                                registroTransferencia.FechaRegistro = resultadoByItem.FirstOrDefault().FechaRegistro != null ? resultadoByItem.FirstOrDefault().FechaRegistro.Value : (DateTime?)null;
                                registroTransferencia.EsProcesado = resultadoByItem.FirstOrDefault().EsProcesado != null ? resultadoByItem.FirstOrDefault().EsProcesado : 0;
                                registroTransferencia.idMovimientoAsistencia = resultadoByItem.FirstOrDefault().idMovimientoAsistencia != null ? resultadoByItem.FirstOrDefault().idMovimientoAsistencia.ToString().Trim() : string.Empty;
                                registroTransferencia.idPension = resultadoByItem.FirstOrDefault().idPension != null ? resultadoByItem.FirstOrDefault().idPension : 0;
                                registroTransferencia.estado = resultadoByItem.FirstOrDefault().estado != null ? resultadoByItem.FirstOrDefault().estado : 0;
                                registroTransferencia.SubPlanilla = resultadoByItem.FirstOrDefault().SubPlanilla != null ? resultadoByItem.FirstOrDefault().SubPlanilla.ToString().Trim() : string.Empty;
                                registroTransferencia.fechaTransferencia = resultadoByItem.FirstOrDefault().fechaTransferencia != null ? resultadoByItem.FirstOrDefault().fechaTransferencia : (DateTime?)null;
                                registroTransferencia.TipoEstadoPersonal = resultadoByItem.FirstOrDefault().TipoEstadoPersonal != null ? resultadoByItem.FirstOrDefault().TipoEstadoPersonal : string.Empty;
                                registroTransferencia.IDPLANILLA = resultadoByItem.FirstOrDefault().IDPLANILLA != null ? resultadoByItem.FirstOrDefault().IDPLANILLA.ToString().Trim() : string.Empty;
                                registroTransferencia.idparadero = resultadoByItem.FirstOrDefault().idparadero != null ? resultadoByItem.FirstOrDefault().idparadero.ToString().Trim() : "S/P";
                                registroTransferencia.paradero = resultadoByItem.FirstOrDefault().paradero != null ? resultadoByItem.FirstOrDefault().paradero.ToString().Trim() : "SIN UBICACION";
                                registroTransferencia.consumidor = resultadoByItem.FirstOrDefault().consumidor != null ? resultadoByItem.FirstOrDefault().consumidor.ToString().Trim() : string.Empty;
                                registroTransferencia.consumidorDescripcion = resultadoByItem.FirstOrDefault().consumidorDescripcion != null ? resultadoByItem.FirstOrDefault().consumidorDescripcion.ToString().Trim() : string.Empty;
                                registroTransferencia.pensionProgramada = resultadoByItem.FirstOrDefault().pensionProgramada != null ? resultadoByItem.FirstOrDefault().pensionProgramada.ToString().Trim() : string.Empty;

                                registroTransferencia.excluirDescuento = 0;
                                Listado.Add(registroTransferencia);
                            }
                        }
                    }
                    #endregion
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return Listado;
        }


        /* Lista de asistencias a las personas que reciben refigerios y que se encuentran pendientes de movimiento de asistencia diario */
        public List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ObtenerListaAsistenciasPersonalAnuladosMovimientoAsistencia(string periodo, string fechaDesde, string fechaHasta, string dniPension)
        {
            List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> Listado = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Substring(0, 4)].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                try
                {
                    #region Consultar()
                    /* mejora en este reporte es asociar a cuantas planillas esta asociado este trabajador, mejor dicho agrupar por codigo de transferencia */
                    var listadoResultadoConsulta = Modelo.SJ_RHAsistenciasRefrigeriosPendientesMovimiento(fechaDesde, fechaHasta, (dniPension != null ? dniPension : "")).ToList();

                    /* OBTENGO TODAS LAS TRANSFERENCIAS VALIDAS PARA EL PROCESO */
                    var listadoCodigoTransferenciaAsistencia = (from item in listadoResultadoConsulta
                                                                where item.idMovimientoTransferencia != null && item.estado == Convert.ToByte(2)
                                                                group item by new { item.idMovimientoTransferencia } into j
                                                                select new
                                                                {
                                                                    codigoTransfereciaAsistencia = j.Key.idMovimientoTransferencia,
                                                                }).ToList();


                    if (listadoCodigoTransferenciaAsistencia != null && listadoCodigoTransferenciaAsistencia.ToList().Count > 0)
                    {
                        foreach (var itemTransferido in listadoCodigoTransferenciaAsistencia)
                        {
                            var resultadoByItem = listadoResultadoConsulta.Where(x => x.idMovimientoTransferencia == itemTransferido.codigoTransfereciaAsistencia).ToList();
                            if (resultadoByItem != null && resultadoByItem.ToList().Count > 0)
                            {
                                SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult registroTransferencia = new SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult();
                                registroTransferencia.idMovimientoTransferencia = itemTransferido.codigoTransfereciaAsistencia;
                                //registroTransferencia.FechaRefrigerio = resultadoByItem.FirstOrDefault().FechaRefrigerio != null ? resultadoByItem.FirstOrDefault().FechaRefrigerio.Value : (DateTime?)null;
                                registroTransferencia.idCodigoGeneral = resultadoByItem.FirstOrDefault().idCodigoGeneral != null ? resultadoByItem.FirstOrDefault().idCodigoGeneral.ToString().Trim() : string.Empty;
                                registroTransferencia.NombresTrabajador = resultadoByItem.FirstOrDefault().NombresTrabajador != null ? resultadoByItem.FirstOrDefault().NombresTrabajador.ToString().Trim() : string.Empty;
                                registroTransferencia.semanaAsistencia = resultadoByItem.FirstOrDefault().semanaAsistencia != null ? resultadoByItem.FirstOrDefault().semanaAsistencia : 0;
                                registroTransferencia.FechaRefrigerio = resultadoByItem.FirstOrDefault().FechaRefrigerio != null ? resultadoByItem.FirstOrDefault().FechaRefrigerio.Value : (DateTime?)null;
                                registroTransferencia.DniTrabajador = resultadoByItem.FirstOrDefault().DniTrabajador != null ? resultadoByItem.FirstOrDefault().DniTrabajador.ToString().Trim() : string.Empty;
                                registroTransferencia.NombresTrabajadorSistema = resultadoByItem.FirstOrDefault().NombresTrabajadorSistema != null ? resultadoByItem.FirstOrDefault().NombresTrabajadorSistema.ToString().Trim() : string.Empty;
                                registroTransferencia.idRefrigerio = resultadoByItem.FirstOrDefault().idRefrigerio != null ? resultadoByItem.FirstOrDefault().idRefrigerio : 0;
                                registroTransferencia.Refrigerio = resultadoByItem.FirstOrDefault().Refrigerio != null ? resultadoByItem.FirstOrDefault().Refrigerio.ToString().Trim() : string.Empty;
                                registroTransferencia.DniPension = resultadoByItem.FirstOrDefault().DniPension != null ? resultadoByItem.FirstOrDefault().DniPension.ToString().Trim() : string.Empty;
                                registroTransferencia.NombresPension = resultadoByItem.FirstOrDefault().NombresPension != null ? resultadoByItem.FirstOrDefault().NombresPension.ToString().Trim() : string.Empty;
                                registroTransferencia.FechaRegistro = resultadoByItem.FirstOrDefault().FechaRegistro != null ? resultadoByItem.FirstOrDefault().FechaRegistro.Value : (DateTime?)null;
                                registroTransferencia.EsProcesado = resultadoByItem.FirstOrDefault().EsProcesado != null ? resultadoByItem.FirstOrDefault().EsProcesado : 0;
                                registroTransferencia.idMovimientoAsistencia = resultadoByItem.FirstOrDefault().idMovimientoAsistencia != null ? resultadoByItem.FirstOrDefault().idMovimientoAsistencia.ToString().Trim() : string.Empty;
                                registroTransferencia.idPension = resultadoByItem.FirstOrDefault().idPension != null ? resultadoByItem.FirstOrDefault().idPension : 0;
                                registroTransferencia.estado = resultadoByItem.FirstOrDefault().estado != null ? resultadoByItem.FirstOrDefault().estado : 0;
                                registroTransferencia.SubPlanilla = resultadoByItem.FirstOrDefault().SubPlanilla != null ? resultadoByItem.FirstOrDefault().SubPlanilla.ToString().Trim() : string.Empty;
                                registroTransferencia.fechaTransferencia = resultadoByItem.FirstOrDefault().fechaTransferencia != null ? resultadoByItem.FirstOrDefault().fechaTransferencia : (DateTime?)null;
                                registroTransferencia.TipoEstadoPersonal = resultadoByItem.FirstOrDefault().TipoEstadoPersonal != null ? resultadoByItem.FirstOrDefault().TipoEstadoPersonal : string.Empty;
                                registroTransferencia.IDPLANILLA = resultadoByItem.FirstOrDefault().IDPLANILLA != null ? resultadoByItem.FirstOrDefault().IDPLANILLA.ToString().Trim() : string.Empty;
                                registroTransferencia.idparadero = resultadoByItem.FirstOrDefault().idparadero != null ? resultadoByItem.FirstOrDefault().idparadero.ToString().Trim() : "S/P";
                                registroTransferencia.paradero = resultadoByItem.FirstOrDefault().paradero != null ? resultadoByItem.FirstOrDefault().paradero.ToString().Trim() : "SIN UBICACION";
                                registroTransferencia.consumidor = resultadoByItem.FirstOrDefault().consumidor != null ? resultadoByItem.FirstOrDefault().consumidor.ToString().Trim() : string.Empty;
                                registroTransferencia.consumidorDescripcion = resultadoByItem.FirstOrDefault().consumidorDescripcion != null ? resultadoByItem.FirstOrDefault().consumidorDescripcion.ToString().Trim() : string.Empty;
                                registroTransferencia.porcentaje = 0;
                                registroTransferencia.nroPersonas = 0;
                                registroTransferencia.observacion = "";
                                Listado.Add(registroTransferencia);
                            }
                        }
                    }
                    #endregion
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return Listado;
        }

        /* Lista de asistencias a las personas que reciben refigerios y que se encuentran pendientes de movimiento de asistencia diario */
        public List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ObtenerListaAsistenciasPersonalDesconocidoPendientesMovimientoAsistencia(string periodo, string fechaDesde, string fechaHasta, string dniPension)
        {
            List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> Listado = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString().Substring(0, 4)].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                try
                {
                    #region Consultar()

                    /* mejora en este reporte es asociar a cuantas planillas esta asociado este trabajador, mejor dicho agrupar por codigo de transferencia */

                    var listadoResultadoConsulta = Modelo.SJ_RHAsistenciasRefrigeriosPendientesMovimientoDesconocidos(fechaDesde, fechaHasta, (dniPension != null ? dniPension : "")).ToList();


                    var listadoCodigoTransferenciaAsistencia = (from item in listadoResultadoConsulta
                                                                where item.idMovimientoTransferencia != null
                                                                group item by new { item.idMovimientoTransferencia } into j
                                                                select new
                                                                {
                                                                    codigoTransfereciaAsistencia = j.Key.idMovimientoTransferencia,
                                                                }).ToList();


                    if (listadoCodigoTransferenciaAsistencia != null && listadoCodigoTransferenciaAsistencia.ToList().Count > 0)
                    {
                        foreach (var itemTransferido in listadoCodigoTransferenciaAsistencia)
                        {

                            var resultadoByItem = listadoResultadoConsulta.Where(x => x.idMovimientoTransferencia == itemTransferido.codigoTransfereciaAsistencia).ToList();

                            if (resultadoByItem != null && resultadoByItem.ToList().Count > 0)
                            {
                                SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult registroTransferencia = new SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult();
                                registroTransferencia.idMovimientoTransferencia = itemTransferido.codigoTransfereciaAsistencia;
                                registroTransferencia.FechaRegistro = resultadoByItem.FirstOrDefault().FechaRegistro != null ? resultadoByItem.FirstOrDefault().FechaRegistro.Value : (DateTime?)null;
                                registroTransferencia.idCodigoGeneral = resultadoByItem.FirstOrDefault().idCodigoGeneral != null ? resultadoByItem.FirstOrDefault().idCodigoGeneral.ToString().Trim() : string.Empty;
                                registroTransferencia.NombresTrabajador = resultadoByItem.FirstOrDefault().NombresTrabajador != null ? resultadoByItem.FirstOrDefault().NombresTrabajador.ToString().Trim() : string.Empty;
                                registroTransferencia.semanaAsistencia = resultadoByItem.FirstOrDefault().semanaAsistencia != null ? resultadoByItem.FirstOrDefault().semanaAsistencia : 0;
                                registroTransferencia.FechaRefrigerio = resultadoByItem.FirstOrDefault().FechaRefrigerio != null ? resultadoByItem.FirstOrDefault().FechaRefrigerio.Value : (DateTime?)null;
                                registroTransferencia.DniTrabajador = resultadoByItem.FirstOrDefault().DniTrabajador != null ? resultadoByItem.FirstOrDefault().DniTrabajador.ToString().Trim() : string.Empty;
                                registroTransferencia.NombresTrabajadorSistema = resultadoByItem.FirstOrDefault().NombresTrabajadorSistema != null ? resultadoByItem.FirstOrDefault().NombresTrabajadorSistema.ToString().Trim() : string.Empty;
                                registroTransferencia.idRefrigerio = resultadoByItem.FirstOrDefault().idRefrigerio != null ? resultadoByItem.FirstOrDefault().idRefrigerio : 0;
                                registroTransferencia.Refrigerio = resultadoByItem.FirstOrDefault().Refrigerio != null ? resultadoByItem.FirstOrDefault().Refrigerio.ToString().Trim() : string.Empty;
                                registroTransferencia.DniPension = resultadoByItem.FirstOrDefault().DniPension != null ? resultadoByItem.FirstOrDefault().DniPension.ToString().Trim() : string.Empty;
                                registroTransferencia.NombresPension = resultadoByItem.FirstOrDefault().NombresPension != null ? resultadoByItem.FirstOrDefault().NombresPension.ToString().Trim() : string.Empty;
                                registroTransferencia.EsProcesado = resultadoByItem.FirstOrDefault().EsProcesado != null ? resultadoByItem.FirstOrDefault().EsProcesado : 0;
                                registroTransferencia.idMovimientoAsistencia = resultadoByItem.FirstOrDefault().idMovimientoAsistencia != null ? resultadoByItem.FirstOrDefault().idMovimientoAsistencia.ToString().Trim() : string.Empty;
                                registroTransferencia.idPension = resultadoByItem.FirstOrDefault().idPension != null ? resultadoByItem.FirstOrDefault().idPension : 0;
                                registroTransferencia.estado = resultadoByItem.FirstOrDefault().estado != null ? resultadoByItem.FirstOrDefault().estado : 0;
                                registroTransferencia.SubPlanilla = resultadoByItem.FirstOrDefault().SubPlanilla != null ? resultadoByItem.FirstOrDefault().SubPlanilla.ToString().Trim() : string.Empty;
                                registroTransferencia.fechaTransferencia = resultadoByItem.FirstOrDefault().fechaTransferencia != null ? resultadoByItem.FirstOrDefault().fechaTransferencia : (DateTime?)null;
                                registroTransferencia.TipoEstadoPersonal = resultadoByItem.FirstOrDefault().TipoEstadoPersonal != null ? resultadoByItem.FirstOrDefault().TipoEstadoPersonal : string.Empty;
                                registroTransferencia.IDPLANILLA = resultadoByItem.FirstOrDefault().IDPLANILLA != null ? resultadoByItem.FirstOrDefault().IDPLANILLA.ToString().Trim() : string.Empty;
                                registroTransferencia.idparadero = resultadoByItem.FirstOrDefault().idparadero != null ? resultadoByItem.FirstOrDefault().idparadero.ToString().Trim() : "S/P";
                                registroTransferencia.paradero = resultadoByItem.FirstOrDefault().paradero != null ? resultadoByItem.FirstOrDefault().paradero.ToString().Trim() : "SIN UBICACION";
                                Listado.Add(registroTransferencia);
                            }
                        }
                    }
                    #endregion
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return Listado;
        }

        public void AnularAsistenciaTransferida(string periodo, int codigo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                if (Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).ToList().Count == 1)
                {
                    if (Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single().estado == 1)
                    {
                        #region Anular()
                        tranferenciaPension = new SJM_Pensione();
                        tranferenciaPension = Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single();
                        tranferenciaPension.estado = 0;
                        tranferenciaPension.fechaActualizacion = DateTime.Now;
                        tranferenciaPension.observacion = "NO CORRESPONDE REFRIGERIO A ESTA PENSION";
                        Modelo.SubmitChanges();
                        #endregion
                    }
                    else
                    {
                        #region Activar()
                        tranferenciaPension = new SJM_Pensione();
                        tranferenciaPension = Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single();
                        tranferenciaPension.estado = 1;
                        tranferenciaPension.fechaActualizacion = null;
                        tranferenciaPension.observacion = string.Empty;
                        Modelo.SubmitChanges();
                        #endregion
                    }
                }
                Modelo.Connection.Close();
            }
        }

        public void AnularAsistenciaTransferida(string periodo, int codigo, int motivo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                if (Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).ToList().Count == 1)
                {
                    if (Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single().estado == 1)
                    {
                        #region Anular()
                        tranferenciaPension = new SJM_Pensione();
                        tranferenciaPension = Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single();
                        tranferenciaPension.estado = 3;
                        tranferenciaPension.fechaActualizacion = DateTime.Now;
                        tranferenciaPension.observacion = "NO CORRESPONDE REFRIGERIO A ESTA PENSION";
                        Modelo.SubmitChanges();
                        #endregion
                    }
                    else if (Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single().estado == 3)
                    {
                        #region Activar()
                        tranferenciaPension = new SJM_Pensione();
                        tranferenciaPension = Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single();
                        tranferenciaPension.estado = 1;
                        tranferenciaPension.fechaActualizacion = null;
                        tranferenciaPension.observacion = string.Empty;

                        Modelo.SubmitChanges();
                        #endregion
                    }

                }
                Modelo.Connection.Close();
            }

        }

        public void ExcluirDeProcesoDeDescuento(string periodo, int codigo, int motivo)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo.ToString()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9999900;
                if (Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).ToList().Count == 1)
                {
                    if (Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single().excluirDescuento == 0)
                    {
                        #region Anular()
                        tranferenciaPension = new SJM_Pensione();
                        tranferenciaPension = Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single();
                        tranferenciaPension.excluirDescuento = 1;
                        tranferenciaPension.estado = 1;
                        Modelo.SubmitChanges();
                        #endregion
                    }
                    else if (Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single().excluirDescuento == 1)
                    {
                        #region Activar()
                        tranferenciaPension = new SJM_Pensione();
                        tranferenciaPension = Modelo.SJM_Pensiones.Where(x => x.IdPension == codigo).Single();
                        tranferenciaPension.excluirDescuento = 0;
                        tranferenciaPension.estado = 1;
                        Modelo.SubmitChanges();
                        #endregion
                    }

                }
                Modelo.Connection.Close();
            }
        }

        public int RegistrarProgramacionRefrigerio(SJ_RHPensionRefrigerioPersona oProgramacionRefrigerio, List<SJ_RHPensionRefrigerioPersonaDetalle> detalle, List<SJ_RHPensionRefrigerioPersonaDetalle> listadoDetalleEliminados)
        {
            int Codigo = 0;
            //using (TransactionScope Scope = new TransactionScope())
            //{
            #region Transacción()
            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                #region Registro / Edicion()
                Modelo.CommandTimeout = 9998000;
                if (oProgramacionRefrigerio.Id == 0)
                {
                    #region Registro Nuevo
                    try
                    {
                        Personal = new SJ_RHPensionRefrigerioPersona();
                        Personal.IdCodigoPersonal = oProgramacionRefrigerio.IdCodigoPersonal;
                        Personal.idParaderoPersonal = oProgramacionRefrigerio.idParaderoPersonal;
                        Personal.NroDocumento = oProgramacionRefrigerio.NroDocumento;
                        Personal.NombresCompletos = oProgramacionRefrigerio.NombresCompletos;
                        Personal.IdSubPlanilla = oProgramacionRefrigerio.IdSubPlanilla;
                        Personal.SubPlanilla = oProgramacionRefrigerio.SubPlanilla;
                        Personal.Condicion = oProgramacionRefrigerio.Condicion;
                        Personal.IdPension = oProgramacionRefrigerio.IdPension;
                        Personal.NroDNIPension = oProgramacionRefrigerio.NroDNIPension;
                        Personal.Pension = oProgramacionRefrigerio.Pension;
                        Personal.Desayuno = oProgramacionRefrigerio.Desayuno;
                        Personal.Almuerzo = oProgramacionRefrigerio.Almuerzo;
                        Personal.Cena = oProgramacionRefrigerio.Cena;
                        Personal.Otro = oProgramacionRefrigerio.Otro;
                        Personal.IdEstado = oProgramacionRefrigerio.IdEstado;
                        Personal.codigoRegistrado = "";
                        Personal.impreso = 0;
                        Personal.registradoPor = Environment.UserName;
                        Personal.fechaRegistro = DateTime.Now;
                        Modelo.SJ_RHPensionRefrigerioPersonas.InsertOnSubmit(Personal);
                        Modelo.SubmitChanges();
                        Codigo = Personal.Id;
                        if (detalle != null)
                        {
                            #region Detalle()
                            if (detalle.ToList().Count() > 0)
                            {
                                foreach (SJ_RHPensionRefrigerioPersonaDetalle item in detalle)
                                {
                                    #region
                                    SJ_RHPensionRefrigerioPersonaDetalle oDetalle = new SJ_RHPensionRefrigerioPersonaDetalle();
                                    oDetalle.Id = Codigo;
                                    oDetalle.Item = item.Item;
                                    oDetalle.ValidoDesde = item.ValidoDesde != null ? item.ValidoDesde.Value : (DateTime?)null;
                                    oDetalle.ValidoHasta = item.ValidoHasta != null ? item.ValidoHasta.Value : (DateTime?)null;
                                    oDetalle.Observacion = item.Observacion;
                                    oDetalle.IdEstado = item.IdEstado;
                                    Modelo.SJ_RHPensionRefrigerioPersonaDetalle.InsertOnSubmit(oDetalle);
                                    Modelo.SubmitChanges();
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        #region Registrar Log Historial
                        logTablas = new SJ_LogTablasPension();
                        logTablas.IDEMPRESA = "001";
                        logTablas.IDLOG = Personal.Id.ToString().PadLeft(16, '0');
                        logTablas.ITEM = "001";
                        logTablas.TABLA = "SJ_RHPensionRefrigerioPersona";
                        logTablas.IDCAMPO = "";
                        logTablas.CAMPOCLAVE = "";
                        logTablas.IDTABLA = "Id";
                        logTablas.EVENTO = "NUEVO";
                        logTablas.VALORANTERIOR = Personal.NroDocumento + " - " + oProgramacionRefrigerio.Pension;
                        logTablas.VALORACTUAL = Personal.SubPlanilla;
                        logTablas.IDUSUARIO = Environment.UserName;
                        logTablas.MAQUINA = Environment.MachineName;
                        logTablas.FECHACREACION = DateTime.Now;
                        logTablas.VENTANA = "ProgramacionRefrigerioxPersonalMantenimiento";
                        Modelo.SJ_LogTablasPension.InsertOnSubmit(logTablas);
                        Modelo.SubmitChanges();
                        #endregion
                        Modelo.SJ_RHPensionRefrigerioPersonaDetalleActualizarFechaActivacion();
                    }
                    catch (Exception Ex)
                    {
                        throw Ex;
                    }
                    #endregion
                }
                else
                {
                    #region Edicion
                    if (Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.Id == oProgramacionRefrigerio.Id).ToList().Count() == 1)
                    {
                        #region Actualizar

                        Personal = new SJ_RHPensionRefrigerioPersona();
                        //Personal.Id = Objeto.Id;
                        Personal = Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.Id == oProgramacionRefrigerio.Id).Single();
                        Personal.IdCodigoPersonal = oProgramacionRefrigerio.IdCodigoPersonal;
                        Personal.NroDocumento = oProgramacionRefrigerio.NroDocumento;
                        Personal.NombresCompletos = oProgramacionRefrigerio.NombresCompletos;
                        Personal.IdSubPlanilla = oProgramacionRefrigerio.IdSubPlanilla;
                        Personal.SubPlanilla = oProgramacionRefrigerio.SubPlanilla;
                        Personal.Condicion = oProgramacionRefrigerio.Condicion;
                        Personal.IdPension = oProgramacionRefrigerio.IdPension;
                        Personal.NroDNIPension = oProgramacionRefrigerio.NroDNIPension;
                        Personal.Pension = oProgramacionRefrigerio.Pension;
                        Personal.Desayuno = oProgramacionRefrigerio.Desayuno;
                        Personal.Almuerzo = oProgramacionRefrigerio.Almuerzo;
                        Personal.Cena = oProgramacionRefrigerio.Cena;
                        Personal.Otro = oProgramacionRefrigerio.Otro;
                        Personal.registradoPor = Environment.UserName;
                        Personal.fechaRegistro = DateTime.Now;

                        //Personal.IdEstado = Objeto.IdEstado;
                        Personal.codigoRegistrado = "";
                        Personal.impreso = 0;
                        //Modelo.SJ_RHPensionRefrigerioPersona.InsertOnSubmit(Personal);
                        Modelo.SubmitChanges();
                        Codigo = Personal.Id;


                        if (listadoDetalleEliminados != null && listadoDetalleEliminados.ToList().Count > 0)
                        {
                            foreach (var itemEliminado in listadoDetalleEliminados)
                            {
                                SJ_RHPensionRefrigerioPersonaDetalle odetalleEliminado = new SJ_RHPensionRefrigerioPersonaDetalle();
                                var consultaDetalle = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Item == itemEliminado.Item && x.Id == itemEliminado.Id).ToList();

                                if (consultaDetalle.ToList().Count == 1)
                                {
                                    odetalleEliminado = consultaDetalle.Single();
                                    Modelo.SJ_RHPensionRefrigerioPersonaDetalle.DeleteOnSubmit(odetalleEliminado);
                                    Modelo.SubmitChanges();
                                }
                            }
                        }

                        if (detalle != null)
                        {
                            #region Detalle()
                            if (detalle.ToList().Count() > 0)
                            {
                                #region
                                foreach (SJ_RHPensionRefrigerioPersonaDetalle item in detalle)
                                {
                                    #region

                                    if (Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == oProgramacionRefrigerio.Id && x.Item == item.Item).ToList().Count() == 1)
                                    {
                                        #region Actualizar
                                        try
                                        {
                                            SJ_RHPensionRefrigerioPersonaDetalle oDetalle = new SJ_RHPensionRefrigerioPersonaDetalle();
                                            //oDetalle.Id = Codigo;
                                            oDetalle = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == oProgramacionRefrigerio.Id && x.Item == item.Item).Single();
                                            //oDetalle.Item = item.Item;
                                            oDetalle.ValidoDesde = item.ValidoDesde != null ? item.ValidoDesde.Value : (DateTime?)null;
                                            oDetalle.ValidoHasta = item.ValidoHasta != null ? item.ValidoHasta.Value : (DateTime?)null;
                                            oDetalle.Observacion = item.Observacion;
                                            oDetalle.IdEstado = item.IdEstado;
                                            Modelo.SubmitChanges();
                                        }
                                        catch (Exception Ex)
                                        {

                                            throw Ex;
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Nuevo
                                        try
                                        {
                                            SJ_RHPensionRefrigerioPersonaDetalle oDetalle = new SJ_RHPensionRefrigerioPersonaDetalle();
                                            oDetalle.Id = Codigo;
                                            oDetalle.Item = item.Item;
                                            oDetalle.ValidoDesde = item.ValidoDesde != null ? item.ValidoDesde.Value : (DateTime?)null;
                                            oDetalle.ValidoHasta = item.ValidoHasta != null ? item.ValidoHasta.Value : (DateTime?)null;
                                            oDetalle.Observacion = item.Observacion;
                                            oDetalle.IdEstado = item.IdEstado;
                                            Modelo.SJ_RHPensionRefrigerioPersonaDetalle.InsertOnSubmit(oDetalle);
                                            Modelo.SubmitChanges();
                                        }
                                        catch (Exception Ex)
                                        {

                                            throw Ex;
                                        }


                                        #endregion
                                    }



                                    #endregion
                                }
                                #endregion
                            }
                            #endregion
                        }

                        #region Registrar Log Historial
                        SJ_LogTablasPension logTablas = new SJ_LogTablasPension();
                        logTablas.IDEMPRESA = "001";
                        logTablas.IDLOG = Personal.Id.ToString().PadLeft(16, '0');
                        //logTablas.ITEM = "001";
                        logTablas.ITEM = ObtenerNumeroItemLogTablas(logTablas.IDLOG, "SJ_RHPensionRefrigerioPersona").ToString();
                        logTablas.TABLA = "SJ_RHPensionRefrigerioPersona";
                        logTablas.IDCAMPO = "";
                        logTablas.CAMPOCLAVE = "";
                        logTablas.IDTABLA = "Id";
                        logTablas.EVENTO = "MODIFICADO";
                        logTablas.VALORANTERIOR = Personal.NroDocumento + oProgramacionRefrigerio.Pension;
                        logTablas.VALORACTUAL = Personal.SubPlanilla;
                        logTablas.IDUSUARIO = Environment.UserName;
                        logTablas.MAQUINA = Environment.MachineName;
                        logTablas.FECHACREACION = DateTime.Now;
                        logTablas.VENTANA = "ProgramacionRefrigerioxPersonalMantenimiento";
                        Modelo.SJ_LogTablasPension.InsertOnSubmit(logTablas);
                        Modelo.SubmitChanges();
                        #endregion

                        #endregion
                    }
                    #endregion
                }
                Modelo.Connection.Close();
                #endregion
            }

            #endregion
            //    Scope.Complete();
            //}
            return Codigo;
        }

        private string ObtenerNumeroItemLogTablas(string idCodigo, string tabla)
        {
            string cnx = string.Empty;
            string item = "001";
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                #region Registro / Edicion()
                Modelo.CommandTimeout = 9998000;

                var resultadoConsulta = Modelo.SJ_LogTablasPension.Where(x => x.IDLOG.ToString().Trim() == idCodigo && x.TABLA.ToString().Trim().Trim() == tabla).ToList();

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                {
                    int numero = Convert.ToInt32(resultadoConsulta.OrderByDescending(x => x.ITEM).FirstOrDefault().ITEM) + 1;
                    item = numero.ToString().Trim().PadLeft(3, '0');
                }

                Modelo.Connection.Close();
                Modelo.Dispose();
                #endregion
            }

            return item;
        }

        /* Anular un la programación de un trabajador */
        public void AnularProgramacionAsistenciaRefrigerioByTrabajador(string Periodo, SJ_RHPensionRefrigerioPersona Objeto, int tipoAnulado)
        {
            /* tipoAnulado 
             * 0 = Anular todos()
             * 1 = Activar todos()
             * 2 = activar uno desactivar el otro()
             */
            try
            {
                using (TransactionScope Scope = new TransactionScope())
                {
                    #region Transacción()
                    string cnx = string.Empty;

                    cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                    using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                    {
                        Modelo.CommandTimeout = 9998000;
                        #region Actualizar Estado
                        if (Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.Id == Objeto.Id).ToList().Count() == 1)
                        {
                            #region Actualizar

                            Personal = new SJ_RHPensionRefrigerioPersona();
                            Personal = Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.Id == Objeto.Id).Single();
                            if (Objeto.IdEstado == "AC")
                            {
                                Personal.IdEstado = "AN";
                                #region Anular estado del detalle()
                                var resultadoDetalle = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == Objeto.Id).ToList();
                                if (resultadoDetalle != null && resultadoDetalle.ToList().Count > 0)
                                {
                                    foreach (var item in resultadoDetalle)
                                    {
                                        SJ_RHPensionRefrigerioPersonaDetalle PersonalDetalle = new SJ_RHPensionRefrigerioPersonaDetalle();
                                        var resultado = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == item.Id && x.Item == item.Item).ToList();

                                        if (resultado != null && resultado.ToList().Count == 1)
                                        {
                                            PersonalDetalle = resultado.Single();
                                            PersonalDetalle.IdEstado = "AN";
                                        }
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                Personal.IdEstado = "AC";
                                #region Activar estado del detalle()
                                var resultadoDetalle = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == Objeto.Id).ToList();
                                if (resultadoDetalle != null && resultadoDetalle.ToList().Count > 0)
                                {
                                    foreach (var item in resultadoDetalle)
                                    {
                                        SJ_RHPensionRefrigerioPersonaDetalle PersonalDetalle = new SJ_RHPensionRefrigerioPersonaDetalle();
                                        var resultado = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == item.Id && x.Item == item.Item).ToList();

                                        if (resultado != null && resultado.ToList().Count == 1)
                                        {
                                            PersonalDetalle = resultado.Single();
                                            PersonalDetalle.IdEstado = "AC";
                                        }
                                    }
                                }
                                #endregion
                            }
                            //Personal.IdEstado = Objeto.IdEstado;                            
                            Modelo.SubmitChanges();
                            #endregion
                        }
                        else if (Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.IdCodigoPersonal == Objeto.IdCodigoPersonal && x.Id == 0).ToList().Count() > 0)
                        {
                            #region
                            var resultado = Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.IdCodigoPersonal == Objeto.IdCodigoPersonal).ToList();

                            foreach (var itemAnular in resultado)
                            {
                                if (Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.Id == itemAnular.Id).ToList().Count() == 1)
                                {
                                    #region Cambiar estado()

                                    Personal = new SJ_RHPensionRefrigerioPersona();
                                    Personal = Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.Id == itemAnular.Id).Single();
                                    if (Objeto.IdEstado == "AC")
                                    {
                                        Personal.IdEstado = "AN";
                                        #region Anular estado del detalle()
                                        var resultadoDetalle = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == Objeto.Id).ToList();
                                        if (resultadoDetalle != null && resultadoDetalle.ToList().Count > 0)
                                        {
                                            foreach (var item in resultadoDetalle)
                                            {
                                                SJ_RHPensionRefrigerioPersonaDetalle PersonalDetalle = new SJ_RHPensionRefrigerioPersonaDetalle();
                                                var resultado2 = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == item.Id && x.Item == item.Item).ToList();

                                                if (resultado2 != null && resultado2.ToList().Count == 1)
                                                {
                                                    PersonalDetalle = resultado2.Single();
                                                    PersonalDetalle.IdEstado = "AN";
                                                }
                                            }
                                        }
                                        #endregion

                                    }
                                    else
                                    {
                                        Personal.IdEstado = "AC";
                                        #region Activar estado del detalle()
                                        var resultadoDetalle = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == Objeto.Id).ToList();
                                        if (resultadoDetalle != null && resultadoDetalle.ToList().Count > 0)
                                        {
                                            foreach (var item in resultadoDetalle)
                                            {
                                                SJ_RHPensionRefrigerioPersonaDetalle PersonalDetalle = new SJ_RHPensionRefrigerioPersonaDetalle();
                                                var resultado2 = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == item.Id && x.Item == item.Item).ToList();

                                                if (resultado2 != null && resultado2.ToList().Count == 1)
                                                {
                                                    PersonalDetalle = resultado2.Single();
                                                    PersonalDetalle.IdEstado = "AC";
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    //Personal.IdEstado = Objeto.IdEstado;                            
                                    Modelo.SubmitChanges();
                                    #endregion
                                }
                            }
                            #endregion
                        }

                        #endregion
                        Modelo.Connection.Close();
                    }

                    Scope.Complete();
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<PersonalCampo> ObtenerListaPosiblesAsistenciasTrabajadores(int desayuno, int almuerzo, int cena, string fecha, int tipoComida, string nroDNIPension)
        {
            List<PersonalCampo> listado = new List<PersonalCampo>();

            string cnx = string.Empty;

            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998999;

                if (nroDNIPension == "00000000")
                {
                    #region Buscar todo el personal Activo en la base de datos()

                    var listadoPersonalGeneral = Modelo.SJ_RHPensionRefrigerioBuscarPersona();
                    listado = (from item in listadoPersonalGeneral
                               group item by new { item.NRODocumento } into j
                               select new PersonalCampo
                               {
                                   codigoPersonal = j.FirstOrDefault().IdCodigoPersonal != null ? j.FirstOrDefault().IdCodigoPersonal.ToString().Trim() : string.Empty,
                                   nroDNI = j.Key.NRODocumento.ToString().Trim(),
                                   Nombres = j.FirstOrDefault().NombresTrabajador != null ? j.FirstOrDefault().NombresTrabajador.ToString().Trim() : string.Empty,
                               }).ToList();

                    #endregion
                }
                else if (nroDNIPension == "00000001")
                {
                    #region Buscar todo el personal que Asistio al menos un refrigerio en el año actual()
                    var listadoPersonalGeneral = Modelo.SJ_RHObtenerListaTrabajadoresAsistieronARefrigerios();
                    listado = (from item in listadoPersonalGeneral
                               group item by new { item.dniTrabajador } into j
                               select new PersonalCampo
                               {
                                   nroDNI = j.Key.dniTrabajador.ToString().Trim(),
                                   Nombres = j.FirstOrDefault().NombresTrabajador != null ? j.FirstOrDefault().NombresTrabajador.ToString().Trim() : string.Empty,
                               }).ToList();
                    #endregion
                }
                else
                {
                    #region Buscar los trabajadores que han sido asignados a la pensión segun su numero dNIPension
                    //var resultadoConsulta = Modelo.SJ_RHObtenerPosibleAsistenciaTrabajadores(desayuno, almuerzo, cena, fecha, tipoComida, nroDNIPension).ToList();
                    var resultadoConsulta = Modelo.SJ_RHObtenerPosibleAsistenciaTrabajadores(1, 1, 1, fecha, tipoComida, nroDNIPension).ToList();
                    listado = (from item in resultadoConsulta
                               group item by new { item.DNI } into j
                               select new PersonalCampo
                               {
                                   nroDNI = j.Key.DNI.ToString().Trim(),
                                   Nombres = j.FirstOrDefault().NombresCompletos.ToString().Trim() != null ? j.FirstOrDefault().NombresCompletos.ToString().Trim() : string.Empty,
                               }).ToList();
                    #endregion
                }

                Modelo.Connection.Close();
            }
            return listado;
        }

        /* Método para Actualizar el número de DNI del trabajado ("DESCONOCIDOS"), se actualiza con la distribucion de refriferios para el personal (PROGRAMACION DE ASISTENCIA REFRIGERIOS) */
        public void ActualizarNumeroDNITrabajor(SJM_Pensione oTransferenciaAsistencia, PersonalCampo personalCampoDisponible)
        {
            using (TransactionScope Scope = new TransactionScope())
            {
                #region Transacción()
                string cnx = string.Empty;

                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {
                    Modelo.CommandTimeout = 9998998;
                    #region Actualizar Estado
                    try
                    {
                        #region Actualizar Número de DNI()
                        if (Modelo.SJM_Pensiones.Where(x => x.IdPension == oTransferenciaAsistencia.IdPension).ToList().Count == 1)
                        {
                            /* El estado 1 es importante por qye estaria dando actualizacion a un registro activo*/
                            if (Modelo.SJM_Pensiones.Where(x => x.IdPension == oTransferenciaAsistencia.IdPension).Single().estado == 1)
                            {
                                #region Anular()
                                tranferenciaPension = new SJM_Pensione();
                                tranferenciaPension = Modelo.SJM_Pensiones.Where(x => x.IdPension == oTransferenciaAsistencia.IdPension).Single();
                                tranferenciaPension.DniTrabajador = personalCampoDisponible.nroDNI;
                                tranferenciaPension.NombresTrabajador = personalCampoDisponible.Nombres.ToString().Trim();
                                Modelo.SubmitChanges();
                                #endregion
                            }

                        }
                        #endregion
                    }
                    catch (Exception Ex)
                    {

                        throw Ex;
                    }
                    #endregion
                    Modelo.Connection.Close();
                }
                Scope.Complete();
                #endregion
            }

        }

        /*Método para actualizar la fecha de la asistencia de refrigerio por nrodni del trabajador */
        public void ActualizarFechaAsistenciaRefrigerio(SJM_Pensione oTransferenciaAsistencia, string fechaActualizar)
        {
            using (TransactionScope Scope = new TransactionScope())
            {
                #region Transacción()
                string cnx = string.Empty;

                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {
                    Modelo.CommandTimeout = 9998998;
                    #region Actualizar Estado
                    try
                    {
                        #region Actualizar Número de DNI()
                        if (Modelo.SJM_Pensiones.Where(x => x.IdPension == oTransferenciaAsistencia.IdPension).ToList().Count == 1)
                        {
                            /* El estado 1 es importante por qye estaria dando actualizacion a un registro activo*/
                            if (Modelo.SJM_Pensiones.Where(x => x.IdPension == oTransferenciaAsistencia.IdPension).Single().estado == 1)
                            {
                                #region Actualizar()
                                tranferenciaPension = new SJM_Pensione();
                                tranferenciaPension = Modelo.SJM_Pensiones.Where(x => x.IdPension == oTransferenciaAsistencia.IdPension).Single();
                                tranferenciaPension.FechaPension = Convert.ToDateTime(fechaActualizar);
                                Modelo.SubmitChanges();
                                #endregion
                            }

                        }
                        #endregion
                    }
                    catch (Exception Ex)
                    {

                        throw Ex;
                    }
                    #endregion
                    Modelo.Connection.Close();
                }
                Scope.Complete();
                #endregion
            }

        }

        /* Método para ver el historial por trabajo y por pension y por trabajador, para que se visualice en la grilla pivot */
        public List<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult> ObtnerListaHistorialRefrigerioxTrabajador(string fecha, string dniPension, string dniTrabajador)
        {
            List<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult> listado = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajadorResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + fecha.Substring(6, 4)].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998999;
                listado = Modelo.SJ_RHConsultarHistorialAsistenciaRefrigerioxTrabajador(fecha, "", dniTrabajador).ToList();
                Modelo.Connection.Close();
            }

            return listado;
        }

        /* Método para ver el historial por trabajo y por pension, para que se visualice en la grilla pivot */
        public List<SJ_RHConsultarHistorialAsistenciaRefrigerioxPensionResult> ObtnerListaHistorialRefrigerioxPension(string fecha, string fechaHasta, string dniPension)
        {
            List<SJ_RHConsultarHistorialAsistenciaRefrigerioxPensionResult> listado = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioxPensionResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + fecha.Substring(6, 4)].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998999;
                listado = Modelo.SJ_RHConsultarHistorialAsistenciaRefrigerioxPension(fecha, fechaHasta, dniPension).ToList();
                Modelo.Connection.Close();
            }

            return listado;
        }

        /*Método para obtener que refrigerios recibio el trabajador durante el día de trabajo, siendo indiferente la si desayuno, almorzo o ceno en pensiones diferentes*/
        public List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult> ObtnerListaRefrigerioRecibidosxTrabajadorxDia(string dniTrabajador, string desde, string hasta)
        {
            List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult> listado = new List<SJ_RHObtenerRefrigeriosRecibidosxDniTrabadorResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + hasta.Substring(6, 4)].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998999;
                listado = Modelo.SJ_RHObtenerRefrigeriosRecibidosxDniTrabador(dniTrabajador, desde, hasta).ToList();
                Modelo.Connection.Close();
            }

            return listado;
        }

        #region Mantenimiento SJ_RHMovimientoAsistenciaPensiones Y SJ_RHMovimientoAsistenciaPensionDetalle()

        public string RegistrarMovimentoAsistenciaRefrigerios(SJ_RHMovimientoAsistenciaPension movimientoAsistenciaRefrigerio, List<SJ_RHMovimientoAsistenciaPensionDetalle> detallemovimientoAsistenciaRefrigerio, List<SJ_RHMovimientoAsistenciaPensionDetalle> detallemovimientoAsistenciaRefrigerioEliminados)
        {
            throw new NotImplementedException();
        }

        public string AnularMovimentoAsistenciaRefrigerios(SJ_RHMovimientoAsistenciaPension movimientoAsistenciaRefrigerio)
        {
            throw new NotImplementedException();
        }

        public string EliminarMovimentoAsistenciaRefrigerios(SJ_RHMovimientoAsistenciaPension movimientoAsistenciaRefrigerio)
        {
            throw new NotImplementedException();
        }

        public string ObtenerMovimentoAsistenciaRefrigerios(SJ_RHMovimientoAsistenciaPension movimientoAsistenciaRefrigerio)
        {
            throw new NotImplementedException();
        }


        #endregion

        public List<SJ_ReporteRefigeriosSubPlanilla> ListarAsistenciasPersonalPorSubPlanilla(int añoConsulta)
        {
            List<SJ_ReporteRefigeriosSubPlanilla> lista = new List<SJ_ReporteRefigeriosSubPlanilla>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + añoConsulta.ToString().Trim()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                lista = Modelo.SJ_ListarReporteRefigeriosSubPlanilla(añoConsulta).OrderBy(x => x.nroMes).ToList();
            }
            return lista;
        }

        public List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult> ListarPersonasConDuplicidadEnRefrigeriosPorDia(string desde, string hasta)
        {
            List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult> lista = new List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                lista = Modelo.SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDia(desde, hasta).ToList();
            }

            return lista;
        }

        /* Método para obtener el Listado de dias Excluidos que no formarán como Descuento entre periodos 
         * Generado  : Erick Aurazo
         * Creacion  : 21.03.16  */
        public List<SJ_RHPensionFacturacionPensionDiasExcluido> ListarDiasExcluidosaDescuentoByPeriodo(string desde, string hasta)
        {
            List<SJ_RHPensionFacturacionPensionDiasExcluido> listado = new List<SJ_RHPensionFacturacionPensionDiasExcluido>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                listado = Modelo.SJ_RHPensionFacturacionPensionDiasExcluidos.Where(x => x.fecha >= Convert.ToDateTime(desde) && x.fecha <= Convert.ToDateTime(hasta + " 23:59:00")).ToList();
            }

            return listado;
        }

        public List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult> ListarPersonasConDuplicidadEnRefrigerioResumen(List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult> listado, List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ListaAsistenciasPersonalPendientesMovimientoAsistencia)
        {
            List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult> lista = new List<SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999899;
                if (listado != null && listado.ToList().Count > 0)
                {
                    #region

                    foreach (var itemDuplicado in listado)
                    {

                        var ObtenerPensionesPorDuplicidadEnRefrigerio = ListaAsistenciasPersonalPendientesMovimientoAsistencia.Where(x => x.FechaRefrigerio.Value == itemDuplicado.fechapension.Value && x.idRefrigerio.Value == itemDuplicado.tipoComida.Value && x.DniTrabajador.ToString().Trim() == itemDuplicado.dniTrabajador.ToString().Trim()).ToList();
                        pensiones = string.Empty;
                        idPension = string.Empty;
                        subplanilla = string.Empty;

                        if (ObtenerPensionesPorDuplicidadEnRefrigerio != null && ObtenerPensionesPorDuplicidadEnRefrigerio.ToList().Count > 0)
                        {
                            pensiones = string.Empty;
                            idPension = string.Empty;
                            subplanilla = string.Empty;
                            foreach (var itemDuplicadoListadoPendiente in ObtenerPensionesPorDuplicidadEnRefrigerio)
                            {
                                pensiones += itemDuplicadoListadoPendiente.NombresPension.ToString().Trim() + "; ";
                                idPension += itemDuplicadoListadoPendiente.idPension.ToString().Trim() + "; ";
                                subplanilla = itemDuplicadoListadoPendiente.SubPlanilla.ToString().Trim();
                            }
                        }

                        SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult item = new SJ_ListarPersonasConDuplicidadEnRefrigeriosPorDiaResult();
                        item.fechapension = itemDuplicado.fechapension;
                        item.tipoComida = itemDuplicado.tipoComida;
                        item.refrigerio = itemDuplicado.refrigerio;
                        item.importeRefrigerio = (itemDuplicado.vecesPorRefrigerio - 1) * (itemDuplicado.importeRefrigerio);
                        item.dniTrabajador = itemDuplicado.dniTrabajador;
                        item.nombresTrabajador = itemDuplicado.nombresTrabajador;
                        item.vecesPorRefrigerio = itemDuplicado.vecesPorRefrigerio;
                        item.pension = pensiones;
                        item.idPension = idPension;
                        item.subplanilla = subplanilla;
                        lista.Add(item);
                    }

                    #endregion
                }
                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return lista;
        }

        /*  PROCEDIMIENTO ALMACENADO PARA SINCRONIZAR LAS ASISTENCIAS DE CAMPOS A UNA TABLA TEMPORAR PARA VALIDAR LOS DESCUENTO PARA EL PROCESO DE DESCUENTO POR ASISTENCIAS A LOS REFRIGERIOS POR PARTE DE LOS TRABAJADORES       */
        public void SincronizarAsistenciasCampoParaDescuentoPorInasistenciasRefrigerios(string desde, string hasta)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 99999899;
                Modelo.SJ_RRHHCopiarAsistenciaPersonalGeneralParaSistemaMovilesPensiones(desde, hasta);
                Modelo.Connection.Close();
                Modelo.Dispose();
            }

        }

        /* Lista generada para los descuento, donde interviene las asistencias con estado 1, el listado de asistencia de las planillas de rrhh y la lista de dias que han sido configuradas como no aplicables de descuento, ejemplo alguna fecha festiva o feriado */
        public List<SJM_Pensione> GenerarListaPersonalParaDescuento(List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> asistenciasRefrigerio, List<SJM_RefrigerioPensionesPersonalListaAsistenciaResult> asistenciasPlanillaRRHH, List<SJ_RHPensionFacturacionPensionDiasExcluido> diasExcluidosDeDescuento)
        {
            List<SJM_Pensione> listaResultado = new List<SJM_Pensione>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext modelo = new PensionRefrigeriosDataContext(cnx))
            {
                modelo.CommandTimeout = 9888999;
                #region Generar lista para descuento para la facturación de Servicios de alimentación()
                /* 1. Valido que la lista de asistencia de transferencia de las pensiones tenga información */
                if (asistenciasRefrigerio != null && asistenciasRefrigerio.ToList().Count > 0)
                {
                    /*1.1. Valido que la lista que voy a procesar no esten anulados es decir no tengan el estado 0, sólo deberán tener un estado 1 (de pendiente) */
                    foreach (var item in asistenciasRefrigerio.Where(x => x.estado != 0).ToList())
                    {

                        #region Valido que la lista que voy a procesar()
                        /* 1.1.3. Busco coincidenia entre la fecha del registro actual y la asistencia de asistencia en campo por horas // El filtro es por dnitrabajador y por fecha */
                        var listaResultadoCoincidencia = asistenciasPlanillaRRHH.Where(x => x.DniTrabajador.Trim() == item.DniTrabajador.Trim() && Convert.ToDateTime(x.Fecha) == item.FechaRefrigerio.Value).ToList();
                        /* 1.1.4. De no haber asistencia o coincidencia de registros, simplemente no agrego ese registro a mi lista */
                        if (listaResultadoCoincidencia != null && listaResultadoCoincidencia.ToList().Count == 0)
                        {
                            #region Analizar si la asistencia va a descuento o se le da como asisntencia()
                            CultureInfo ci = new CultureInfo("Es-PE");
                            string nombreDiaRegistro = Convert.ToDateTime(item.FechaRefrigerio).DayOfWeek.ToString();

                            /* 1.1.4.1 Obtengo el numero de semana del registro actual, mejor dicho de mis transferencia*/
                            int nroSemana = item.semanaAsistencia.Value;
                            /* 1.1.4.2 Obtengo el los dias trabajados durante la semana de este trabajador*/
                            modeloNegocio = new SJM_PensionesNegocios();
                            //List<SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaboradorResult> ListadoDiasTrabajadosByTrabajador = new List<SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaboradorResult>();
                            var ListadoDiasTrabajadosByTrabajador = listaResultadoCoincidencia.Where(x => x.semanaAsistencia == item.semanaAsistencia).ToList();

                            /* 1.1.4.3. Evaluo si el día en proceso es DOMINGO, y ke asigno un estado 2 de inasistencia */
                            if (nombreDiaRegistro.ToUpper().Trim() == "SUNDAY")
                            {
                                List<SJ_AsistenciaPersonalBySemanaByCodigoResult> resultadoConsulta = new List<SJ_AsistenciaPersonalBySemanaByCodigoResult>();
                                List<SJ_AsistenciaPersonalBySemanaByCodigoTareaResult> resultadoConsultaTarea = new List<SJ_AsistenciaPersonalBySemanaByCodigoTareaResult>();

                                resultadoConsulta = modelo.SJ_AsistenciaPersonalBySemanaByCodigo(item.semanaAsistencia, item.idCodigoGeneral.Trim()).ToList();

                                resultadoConsultaTarea = modelo.SJ_AsistenciaPersonalBySemanaByCodigoTarea(item.semanaAsistencia, item.idCodigoGeneral.Trim()).ToList();

                                if (resultadoConsultaTarea != null && resultadoConsultaTarea.ToList().Count > 0)
                                {
                                    var ListaFormateada = (from it in resultadoConsultaTarea
                                                           where it.nombredia != null && it.nombredia != string.Empty
                                                           select new SJ_AsistenciaPersonalBySemanaByCodigoResult
                                                           {
                                                               FechaAsistencia = it.FechaAsistencia,
                                                               nombredia = it.nombredia,
                                                               unidadControl = it.unidadControl
                                                           }).ToList();

                                    resultadoConsulta.AddRange(ListaFormateada);
                                }

                                if (resultadoConsulta.Where(x => x.nombredia.Trim() == "DOMINGO").ToList().Count == 0)
                                {
                                    #region Anulo Asistencia()
                                    SJM_Pensione registroAsistencia = new SJM_Pensione();
                                    registroAsistencia = modelo.SJM_Pensiones.Where(x => x.IdPension == item.idMovimientoTransferencia).Single();
                                    registroAsistencia.estado = 2;
                                    registroAsistencia.fechaBaja = DateTime.Now;
                                    registroAsistencia.observacion = "EL PERSONAL NO ASISTIO A LABORES DE CAMPO EL DÍA " + item.FechaRefrigerio.Value.ToShortDateString();
                                    modelo.SubmitChanges();
                                    //listaResultado.Add(registroAsistencia);
                                    #endregion
                                }

                                /*Aqui valido con la asistencia de los moviles de */

                            }
                            /* 1.1.4.3. Evaluo si el día en proceso es SABADO , si al menos tiene 4 días trabajados la empresa asume ese costo, caso contrario anulo la asistencia con un estado 2 (inasistencia) */
                            else if (nombreDiaRegistro.ToUpper().Trim() == "SATURDAY")
                            {
                                #region Evaluo si el día en proceso es SABADO()

                                List<SJ_AsistenciaPersonalBySemanaByCodigoResult> resultadoConsulta = new List<SJ_AsistenciaPersonalBySemanaByCodigoResult>();
                                List<SJ_AsistenciaPersonalBySemanaByCodigoTareaResult> resultadoConsultaTarea = new List<SJ_AsistenciaPersonalBySemanaByCodigoTareaResult>();

                                /* Obtengo la asistencia de la planilla de rrhh */
                                resultadoConsulta = modelo.SJ_AsistenciaPersonalBySemanaByCodigo(item.semanaAsistencia, item.idCodigoGeneral.Trim()).ToList();
                                /* Obtengo la asistencia de la planilla de tareos moviles */
                                resultadoConsultaTarea = modelo.SJ_AsistenciaPersonalBySemanaByCodigoTarea(item.semanaAsistencia, item.idCodigoGeneral.Trim()).ToList();

                                if (resultadoConsultaTarea != null && resultadoConsultaTarea.ToList().Count > 0)
                                {
                                    var ListaFormateada = (from it in resultadoConsultaTarea
                                                           where it.nombredia != null && it.nombredia != string.Empty
                                                           select new SJ_AsistenciaPersonalBySemanaByCodigoResult
                                                           {
                                                               FechaAsistencia = it.FechaAsistencia,
                                                               nombredia = it.nombredia,
                                                               unidadControl = it.unidadControl
                                                           }).ToList();
                                    /* agrego mi resultado de mi lista tarea a ami asistencia planilla */
                                    resultadoConsulta.AddRange(ListaFormateada);
                                }


                                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                                {

                                    List<SJ_AsistenciaPersonalBySemanaByCodigoResult> resultadoConsultaConDiaSabado = new List<SJ_AsistenciaPersonalBySemanaByCodigoResult>();
                                    resultadoConsultaConDiaSabado = resultadoConsulta.Where(x => x.nombredia.Trim() == "SÁBADO").ToList();

                                    if (resultadoConsultaConDiaSabado != null && resultadoConsultaConDiaSabado.ToList().Count == 0)
                                    {
                                        List<SJ_AsistenciaPersonalBySemanaByCodigoResult> resultadoConsultaSinDomingo = new List<SJ_AsistenciaPersonalBySemanaByCodigoResult>();
                                        resultadoConsultaSinDomingo = resultadoConsulta.Where(x => x.nombredia.Trim() != "DOMINGO").ToList();

                                        var resultadoPorDias = (from itemDiaTrabajado in resultadoConsultaSinDomingo
                                                                where itemDiaTrabajado.nombredia != null && itemDiaTrabajado.nombredia.Trim() != string.Empty
                                                                group itemDiaTrabajado by new { itemDiaTrabajado.nombredia } into j
                                                                select new SJ_AsistenciaPersonalBySemanaByCodigoResult
                                                                {

                                                                    nombredia = j.Key.nombredia != null ? j.Key.nombredia : string.Empty,
                                                                    FechaAsistencia = j.FirstOrDefault().FechaAsistencia.Value != null ? j.FirstOrDefault().FechaAsistencia.Value : (DateTime?)null,
                                                                    unidadControl = j.FirstOrDefault().unidadControl != null ? j.FirstOrDefault().unidadControl.Trim() : string.Empty,
                                                                }).ToList();

                                        if (resultadoPorDias != null && resultadoPorDias.ToList().Count <= 3)
                                        {
                                            SJM_Pensione registroAsistencia = new SJM_Pensione();
                                            registroAsistencia = modelo.SJM_Pensiones.Where(x => x.IdPension == item.idMovimientoTransferencia).Single();
                                            registroAsistencia.estado = 2;
                                            registroAsistencia.fechaBaja = DateTime.Now;
                                            registroAsistencia.observacion = "EL PERSONAL NO ASISTIO A LABORES DE CAMPO EL DÍA " + item.FechaRefrigerio.Value.ToShortDateString();
                                            modelo.SubmitChanges();
                                            //listaResultado.Add(registroAsistencia);
                                        }

                                    }

                                }
                                #endregion
                            }
                            else
                            /* 1.1.4.3. Evaluo si el día en proceso esta como excluido en la programación de descuentos para facturación //  Agregado el 21.03.16 dias excluidos desde aplicacion de programación de dias que no entran al descuento */
                            {
                                #region  Evaluo si el día en proceso esta como excluido()
                                if (diasExcluidosDeDescuento != null && diasExcluidosDeDescuento.ToList().Count > 0)
                                {
                                    /* 1.1.4.3.1 Filtro en mi lista de dias que no entrarán a descuento, si el trabajador al menos tiene 3 días trabajados anulo caso contrario activo asistencia */
                                    if (diasExcluidosDeDescuento.Where(x => x.fecha == item.FechaRefrigerio).ToList().Count == 1)
                                    {
                                        #region Evaluo los días trabajados en la semana()
                                        if (ListadoDiasTrabajadosByTrabajador != null && ListadoDiasTrabajadosByTrabajador.ToList().Count >= 3)
                                        {
                                            #region Activo Asistencia()
                                            SJM_Pensione registroAsistencia = new SJM_Pensione();
                                            registroAsistencia = modelo.SJM_Pensiones.Where(x => x.IdPension == item.idMovimientoTransferencia).Single();
                                            registroAsistencia.estado = 1;
                                            registroAsistencia.fechaActualizacion = DateTime.Now;
                                            registroAsistencia.observacion = "Esta asistencia fue activada el " + DateTime.Now.ToShortDateString() + ", no habiendose trabajado el dia por razones de que fue excluido por el área de GTH";
                                            modelo.SubmitChanges();
                                            #endregion
                                        }
                                        else
                                        {
                                            #region Anulo asistencia a refrigerio por inasistencia()
                                            SJM_Pensione registroAsistencia = new SJM_Pensione();
                                            registroAsistencia = modelo.SJM_Pensiones.Where(x => x.IdPension == item.idMovimientoTransferencia).Single();
                                            registroAsistencia.estado = 2;
                                            registroAsistencia.fechaBaja = DateTime.Now;
                                            registroAsistencia.observacion = "EL PERSONAL NO ASISTIO A LABORES DE CAMPO EL DÍA " + item.FechaRefrigerio.Value.ToShortDateString();
                                            modelo.SubmitChanges();
                                            //listaResultado.Add(registroAsistencia);
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    /* Caso contrario se trata de una falta a las labores de campo */
                                    else
                                    {
                                        #region Anulo asistencia a refrigerio por inasistencia()
                                        SJM_Pensione registroAsistencia = new SJM_Pensione();
                                        registroAsistencia = modelo.SJM_Pensiones.Where(x => x.IdPension == item.idMovimientoTransferencia).Single();
                                        registroAsistencia.estado = 2;
                                        registroAsistencia.fechaBaja = DateTime.Now;
                                        registroAsistencia.observacion = "EL PERSONAL NO ASISTIO A LABORES DE CAMPO EL DÍA " + item.FechaRefrigerio.Value.ToShortDateString();
                                        modelo.SubmitChanges();
                                        //listaResultado.Add(registroAsistencia);
                                        #endregion
                                    }
                                }
                                else
                                {
                                    #region Anulo asistencia a refrigerio por inasistencia()
                                    SJM_Pensione registroAsistencia = new SJM_Pensione();
                                    registroAsistencia = modelo.SJM_Pensiones.Where(x => x.IdPension == item.idMovimientoTransferencia).Single();
                                    registroAsistencia.estado = 2;
                                    registroAsistencia.fechaBaja = DateTime.Now;
                                    registroAsistencia.observacion = "EL PERSONAL NO ASISTIO A LABORES DE CAMPO EL DÍA " + item.FechaRefrigerio.Value.ToShortDateString();
                                    modelo.SubmitChanges();
                                    //listaResultado.Add(registroAsistencia);
                                    #endregion
                                }

                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                    }
                }
                #endregion
                modelo.Connection.Close();
                modelo.Dispose();
            }

            return listaResultado;
        }

        /* 19.04.16 Método para obtener el listado de asistencia en las labores de campo de un trabajados por semana  */
        private List<SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaboradorResult> ObtenerAsistenciaLaboresCampoBySemanaByColaborador(string codigoGeneral, int? numeroSemana)
        {
            List<SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaboradorResult> listado = new List<SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaboradorResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext modelo = new PensionRefrigeriosDataContext(cnx))
            {
                modelo.CommandTimeout = 9888999;
                listado = modelo.SJ_RHPensionAsistenciaLaboresCampoBySemanaByColaborador(codigoGeneral, numeroSemana).ToList();
                modelo.Connection.Close();
                modelo.Dispose();
            }
            return listado;
        }

        /*13-01-2016*/
        public List<SJ_RHListaPersonalParaDescuentoPensionbyProveedorbyFechaResult> ListarNombresPersonalParaReporteDescuentoByPensionByProveedorByPeriodo(string dniResponsablePension, string fechaDesde, string fechaHasta)
        {
            List<SJ_RHListaPersonalParaDescuentoPensionbyProveedorbyFechaResult> listado = new List<SJ_RHListaPersonalParaDescuentoPensionbyProveedorbyFechaResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext modelo = new PensionRefrigeriosDataContext(cnx))
            {
                modelo.CommandTimeout = 9888999;
                listado = modelo.SJ_RHListaPersonalParaDescuentoPensionbyProveedorbyFecha(dniResponsablePension, fechaDesde, fechaHasta).ToList();
                modelo.Connection.Close();
                modelo.Dispose();
            }
            return listado;
        }

        public void ProcesoCorregirNombresPersonalDesconocido(string fechaDesde, string fechaHasta, string dniPension)
        {
            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
                using (PensionRefrigeriosDataContext modelo = new PensionRefrigeriosDataContext(cnx))
                {
                    modelo.CommandTimeout = 9888999;
                    modelo.SJ_RHProcesoCorregirNombresPersonalDesconocidoAsistenciaRefrigerios(fechaDesde, fechaHasta, dniPension);
                    modelo.Connection.Close();
                    modelo.Dispose();
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }


        }

        public void ProcesoActualizarAsistenciaRefrigeriosAEstadoPendiente(string fechaDesde, string fechaHasta, string dniPension)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext modelo = new PensionRefrigeriosDataContext(cnx))
            {
                modelo.CommandTimeout = 9888999;
                modelo.SJ_RHProcesoActivarAsistenciaRefrigeriosByPensionByPeriodo(fechaDesde, fechaHasta, dniPension);
                modelo.Connection.Close();
                modelo.Dispose();
            }
        }

        public void ProcesoAnularAsistenciaDuplicadasByAsistenciasRefrigerios(string fechaDesde, string fechaHasta, string dniPension)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext modelo = new PensionRefrigeriosDataContext(cnx))
            {
                modelo.CommandTimeout = 9888999;
                modelo.SJ_RHProcesoActivarAsistenciaRefrigeriosByPensionByPeriodo(fechaDesde, fechaHasta, dniPension);
                modelo.Connection.Close();
                modelo.Dispose();
            }
        }

        public List<SJ_RHPensionRefrigerioPersona> ValidarDuplicidadRegistro(string Periodo, SJ_RHPensionRefrigerioPersona oProgramacionRefrigerio)
        {
            /* Si es true, que me deje grabar, si es false tiene duplicidad */

            List<SJ_RHPensionRefrigerioPersona> listado = new List<SJ_RHPensionRefrigerioPersona>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext modelo = new PensionRefrigeriosDataContext(cnx))
            {
                modelo.CommandTimeout = 9888999;

                /* 1.- Obtengo todos los registros de mi programación que esten activos */
                var resultadolistado = modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.IdCodigoPersonal.ToString().Trim() == oProgramacionRefrigerio.IdCodigoPersonal.ToString().Trim() && x.IdEstado == "AC").ToList();

                /* 2.- Verifico si se trata de una edición o y es un nuevo registro*/
                if (resultadolistado.Where(x => x.IdPension == oProgramacionRefrigerio.IdPension).ToList().Count() == 1)
                {
                    if (oProgramacionRefrigerio.Id > 0)
                    {
                        listado = new List<SJ_RHPensionRefrigerioPersona>();
                    }
                    else
                    {
                        listado = resultadolistado.Where(x => x.IdPension == oProgramacionRefrigerio.IdPension).ToList();
                    }
                }
                else
                {
                    listado = resultadolistado;
                }

                modelo.Connection.Close();
                modelo.Dispose();
            }

            return listado;
        }

        public List<SJ_RHPensionRefrigerioPersona> AnularTicketsActivosPorCodigoPersonal(string Periodo, SJ_RHPensionRefrigerioPersona oProgramacionRefrigerio)
        {
            /* Si es true, que me deje grabar, si es false tiene duplicidad */

            List<SJ_RHPensionRefrigerioPersona> listado = new List<SJ_RHPensionRefrigerioPersona>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext modelo = new PensionRefrigeriosDataContext(cnx))
            {
                modelo.CommandTimeout = 9888999;

                /* 1.- Obtengo todos los registros de mi programación que esten activos */
                var resultadolistado = modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.IdCodigoPersonal.ToString().Trim() == oProgramacionRefrigerio.IdCodigoPersonal.ToString().Trim() && x.IdEstado == "AC").ToList();

                if (resultadolistado != null && resultadolistado.ToList().Count > 0)
                {
                    foreach (var item in resultadolistado)
                    {
                        SJ_RHPensionRefrigerioPersona ticketProgramado = new SJ_RHPensionRefrigerioPersona();
                        ticketProgramado = modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.Id == item.Id).Single();
                        ticketProgramado.IdEstado = "AN";
                        modelo.SubmitChanges();

                        #region Registrar Log Historial
                        logTablas = new SJ_LogTablasPension();
                        logTablas.IDEMPRESA = "001";
                        logTablas.IDLOG = item.Id.ToString().PadLeft(16, '0');
                        logTablas.ITEM = ObtenerNumeroItemLogTablas(logTablas.IDLOG, "SJ_RHPensionRefrigerioPersona").ToString();
                        logTablas.TABLA = "SJ_RHPensionRefrigerioPersona";
                        logTablas.IDCAMPO = "";
                        logTablas.CAMPOCLAVE = "";
                        logTablas.IDTABLA = "Id";
                        logTablas.EVENTO = "MODIFICADO";
                        logTablas.VALORANTERIOR = "ACTIVO";
                        logTablas.VALORACTUAL = "RENOVACION";
                        logTablas.IDUSUARIO = Environment.UserName;
                        logTablas.MAQUINA = Environment.MachineName;
                        logTablas.FECHACREACION = DateTime.Now;
                        logTablas.VENTANA = "ProgramacionRefrigerioxPersonalMantenimiento";
                        modelo.SJ_LogTablasPension.InsertOnSubmit(logTablas);
                        modelo.SubmitChanges();
                        #endregion

                    }
                }

                modelo.Connection.Close();
                modelo.Dispose();
            }

            return listado;
        }

        public void EliminarProgramacionAsistenciaRefrigerioByTrabajador(string periodoConsulta, SJ_RHPensionRefrigerioPersona ObjetoRefrigerioPersona, int p)
        {
            try
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {
                    Modelo.CommandTimeout = 9998000;
                    #region Actualizar Estado
                    if (Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.Id == ObjetoRefrigerioPersona.Id).ToList().Count() == 1)
                    {
                        #region Actualizar

                        var detalleProgramacion = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == ObjetoRefrigerioPersona.Id).ToList();

                        if (detalleProgramacion != null && detalleProgramacion.ToList().Count > 0)
                        {
                            foreach (var detalle in detalleProgramacion)
                            {
                                SJ_RHPensionRefrigerioPersonaDetalle oDetalle = new SJ_RHPensionRefrigerioPersonaDetalle();
                                oDetalle = Modelo.SJ_RHPensionRefrigerioPersonaDetalle.Where(x => x.Id == ObjetoRefrigerioPersona.Id && x.Item.ToString().Trim() == detalle.Item.ToString().Trim()).Single();
                                Modelo.SJ_RHPensionRefrigerioPersonaDetalle.DeleteOnSubmit(oDetalle);
                            }
                        }

                        Personal = new SJ_RHPensionRefrigerioPersona();
                        Personal = Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.Id == ObjetoRefrigerioPersona.Id).Single();
                        Modelo.SJ_RHPensionRefrigerioPersonas.DeleteOnSubmit(Personal);
                        Modelo.SubmitChanges();
                        #endregion
                    }
                    Modelo.Connection.Close();
                    Modelo.Dispose();
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public List<SJ_RHPensionRefrigerioPersonaListarResult> ObtenerProgramacionAsistenciaRefrigerioByTrabajador(string periodoConsulta, SJ_RHPensionRefrigerioPersona oRefrigerioPersonaSelecionado)
        {
            List<SJ_RHPensionRefrigerioPersonaListarResult> listado = new List<SJ_RHPensionRefrigerioPersonaListarResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext modelo = new PensionRefrigeriosDataContext(cnx))
            {
                modelo.CommandTimeout = 9888999;

                var resultadoConsulta = modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.IdCodigoPersonal.ToString().Trim() == oRefrigerioPersonaSelecionado.IdCodigoPersonal.ToString().Trim()).ToList();

                listado = (from item in resultadoConsulta
                           where item.Id > 0
                           group item by new { item.Id } into j
                           select new SJ_RHPensionRefrigerioPersonaListarResult
                           {
                               Id = j.Key.Id,
                               IdCodigoPersonal = j.FirstOrDefault().IdCodigoPersonal != null ? j.FirstOrDefault().IdCodigoPersonal.ToString().Trim() : string.Empty,
                               IdPension = j.FirstOrDefault().IdPension != null ? j.FirstOrDefault().IdPension : 0,
                               Pension = j.FirstOrDefault().Pension != null ? j.FirstOrDefault().Pension.ToString().Trim() : string.Empty,
                               Desayuno = j.FirstOrDefault().Desayuno != null ? j.FirstOrDefault().Desayuno : 0,
                               Almuerzo = j.FirstOrDefault().Almuerzo != null ? j.FirstOrDefault().Almuerzo : 0,
                               Cena = j.FirstOrDefault().Cena != null ? j.FirstOrDefault().Cena : 0,
                               Otro = j.FirstOrDefault().Otro != null ? j.FirstOrDefault().Otro : 0,
                               ValidoDesde = j.FirstOrDefault().ValidoDesde != null ? j.FirstOrDefault().ValidoDesde : (DateTime?)null,
                               ValidoHasta = j.FirstOrDefault().ValidoHasta != null ? j.FirstOrDefault().ValidoHasta : (DateTime?)null,
                               IdEstado = j.FirstOrDefault().IdEstado != null ? j.FirstOrDefault().IdEstado.ToString().Trim() : "AN",
                           }).ToList();

                modelo.Connection.Close();
                modelo.Dispose();
            }
            return listado;
        }

        public SJ_ListadoPersonalGeneral ObtenerRegistroPersonalGeneral(string numeroDocumentoPersonal)
        {
            SJ_ListadoPersonalGeneral registroPersonal = new SJ_ListadoPersonalGeneral();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998000;

                var resultadoConsulta = Modelo.SJ_ListadoPersonalGenerals.Where(x => x.numeroDocumento.ToString().Trim() == numeroDocumentoPersonal).ToList();

                if (resultadoConsulta.ToList().Count == 1)
                {
                    registroPersonal = resultadoConsulta.Single();
                }
                else
                {
                    registroPersonal = new SJ_ListadoPersonalGeneral();
                    registroPersonal.numeroDocumento = numeroDocumentoPersonal;
                    registroPersonal.nombresCompletos = "DESCONOCIDO";
                    registroPersonal.subPlanilla = "DESCONOCIDO";
                }

                Modelo.Connection.Close();
                Modelo.Dispose();
            }
            return registroPersonal;
        }

        public List<SJ_RHPensionRefrigerioPersona> ObtenerListadoProgramacionPersonalBaseDatosByTrabajador(string nroDniTrabajador)
        {
            List<SJ_RHPensionRefrigerioPersona> listado = new List<SJ_RHPensionRefrigerioPersona>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998000;

                listado = Modelo.SJ_RHPensionRefrigerioPersonas.Where(x => x.NroDocumento.ToString().Trim() == nroDniTrabajador.ToString().Trim() && x.IdEstado.ToString().Trim() == "AC").ToList();

                Modelo.Connection.Close();
                Modelo.Dispose();
            }

            return listado;
        }

        /* 19.04.19 Proceso para AsociarParaderoATrabajadorPostTransferencia*/
        public void ProcesoAsociarParaderoATrabajadorPostTransferencia(string periodo, string desde, string hasta)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodo].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {

                contexto.CommandTimeout = 9998000;
                contexto.SJ_RHProcesoAsociarParaderoATrabajadorPostTransferencia(desde, hasta);
                //contexto.SJ_RHProcesoAsociarParaderoATrabajadorPostTransferencia
                contexto.Connection.Close();
                contexto.Dispose();
            }
        }

        public List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ObtenerListadoAsistenciaByConsumidores(List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ListaAsistenciasTransferenciaMoviles, string periodo, string fechaInicio, string fechaTermino)
        {
            string cnx = string.Empty;
            List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> listado = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();

            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {

                contexto.CommandTimeout = 9998000;
                //listado = ListaAsistenciasTransferenciaMoviles;
                //contexto.SJ_RHProcesoAsociarParaderoATrabajadorPostTransferencia
                if (ListaAsistenciasTransferenciaMoviles != null && ListaAsistenciasTransferenciaMoviles.ToList().Count > 0)
                {

                    var listaDias = (from item in ListaAsistenciasTransferenciaMoviles
                                     where item.FechaRefrigerio != null
                                     group item by new { item.FechaRefrigerio } into j
                                     select new
                                     {
                                         fecha = j.Key.FechaRefrigerio.Value,
                                         semana = j.FirstOrDefault().semanaAsistencia.Value,
                                     }).ToList();


                    foreach (var item in listaDias)
                    {
                        var resultadoByDia = ListaAsistenciasTransferenciaMoviles.Where(x => x.FechaRefrigerio.Value == item.fecha && x.estado == 1).ToList();

                        var listaTrabajador = (from trabajador in resultadoByDia
                                               where trabajador.DniTrabajador != null
                                               group trabajador by new { trabajador.DniTrabajador } into j
                                               select new
                                               {
                                                   dni = j.Key.DniTrabajador,
                                                   nombres = j.FirstOrDefault().NombresTrabajador.ToString().Trim(),
                                                   codigoTrabajado = j.FirstOrDefault().idCodigoGeneral.ToString().Trim()
                                               }).ToList();

                        foreach (var oTrabajador in listaTrabajador)
                        {

                            var listadoAsistenciaCampo = contexto.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos(item.fecha.ToShortDateString(), item.fecha.ToShortDateString(), oTrabajador.codigoTrabajado).ToList();

                            SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult asistencia = new SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult();
                            if (listadoAsistenciaCampo != null && listadoAsistenciaCampo.ToList().Count > 0)
                            {

                                decimal horasMaxima = 0;
                                horasMaxima = listadoAsistenciaCampo.Max(x => x.horas.Value);
                                var campoAsignado = listadoAsistenciaCampo.Where(x => x.horas >= horasMaxima).ElementAt(0);

                                asistencia.semanaAsistencia = item.semana;
                                asistencia.NombresTrabajador = oTrabajador.nombres;
                                asistencia.idCodigoGeneral = oTrabajador.codigoTrabajado;
                                asistencia.DniTrabajador = oTrabajador.dni;
                                asistencia.FechaRefrigerio = item.fecha;
                                asistencia.consumidor = campoAsignado.consumidor.ToString().Trim();
                                asistencia.consumidorDescripcion = campoAsignado.descr_consum.ToString().Trim();
                                asistencia.idRefrigerio = Convert.ToInt32(1);
                                listado.Add(asistencia);
                            }



                        }

                    }

                }






                contexto.Connection.Close();
                contexto.Dispose();
            }

            return listado.Where(x => x.consumidor != "").OrderBy(x => x.consumidor).ToList();
        }

        public List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> ObtenerListadoAsistenciaByConsumidoresAgrupado(List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> listado)
        {
            List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult> listadoPresentacion = new List<SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult>();
            decimal? totalRegistros = listado.ToList().Count;
            if (listado != null && listado.ToList().Count > 0)
            {
                //var listaDias = (from item in listado
                //                 where item.FechaRefrigerio != null
                //                 group item by new { item.FechaRefrigerio } into j
                //                 select new
                //                 {
                //                     fecha = j.Key.FechaRefrigerio.Value,
                //                     semana = j.FirstOrDefault().semanaAsistencia.Value,
                //                 }).ToList();


                //foreach (var item in listaDias)
                //{
                //    var resultadoByDia = listado.Where(x => x.FechaRefrigerio.Value == item.fecha).ToList();

                var listaConsumidor = (from consumidor in listado
                                       where consumidor.consumidor != null
                                       group consumidor by new { consumidor.consumidor } into j
                                       select new
                                       {
                                           consumidor = j.Key.consumidor,
                                           consumidorDescripcion = j.FirstOrDefault().consumidorDescripcion.ToString().Trim(),
                                           semana = j.FirstOrDefault().semanaAsistencia,
                                           fecha = j.FirstOrDefault().FechaRefrigerio
                                       }).ToList();


                foreach (var iConsumidor in listaConsumidor)
                {

                    var resultadoByConsumidor = listado.Where(x => x.consumidor == iConsumidor.consumidor).ToList();
                    decimal? totalRegistrosByConsumidor = resultadoByConsumidor.ToList().Count;

                    SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult asistencia = new SJ_RHAsistenciasRefrigeriosPendientesMovimientoResult();
                    if (resultadoByConsumidor != null && resultadoByConsumidor.ToList().Count > 0)
                    {

                        asistencia.semanaAsistencia = iConsumidor.semana;
                        asistencia.FechaRefrigerio = iConsumidor.fecha;
                        asistencia.consumidor = iConsumidor.consumidor;
                        asistencia.consumidorDescripcion = iConsumidor.consumidorDescripcion.ToString().Trim();
                        asistencia.nroPersonas = totalRegistrosByConsumidor.Value;
                        decimal porcentaje = Convert.ToDecimal(totalRegistrosByConsumidor / totalRegistros);
                        asistencia.observacion = iConsumidor.consumidorDescripcion.ToString().Trim() + " con un " + (porcentaje * 100).ToDecimalPresentation() + "%";
                        asistencia.porcentaje = Convert.ToDecimal(porcentaje * 100);
                        listadoPresentacion.Add(asistencia);
                    }

                }
                //}



            }
            return listadoPresentacion.Where(x => x.consumidor != "").OrderBy(x => x.consumidor).ToList();
        }

        public List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult> ObtenerlistadoAsistenciasByHorasByTrabajadasByPeriodo(string fechaDesde, string fechaHasta, string codigoTrabajado)
        {
            string cnx = string.Empty;
            List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult> listado = new List<SJ_ListarAsistenciasByHorasTrabajadasByPeriodosResult>();
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {

                contexto.CommandTimeout = 9998000;
                listado = contexto.SJ_ListarAsistenciasByHorasTrabajadasByPeriodos(fechaDesde, fechaHasta, codigoTrabajado).ToList();
                contexto.Connection.Close();
                contexto.Dispose();
            }
            return listado;
        }

        /* 22.06.16 proceso de actualizar nombre de los trabajadores post transferencia */
        public void ActualizarNombresColaboradorPostTransferencia(string desde, string hasta)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9998000;
                contexto.SJ_RHAsistenciaPensionActualizarNombresColaboradorPostTransferencia(desde, hasta);
                contexto.Connection.Close();
                contexto.Dispose();
            }
        }

        /* 22.06.16 proceso de anular duplicidad de asistencia por refrigerio por fecha */
        public void AnularDuplicidadAsistencia(string desde, string hasta)
        {
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9998000;
                contexto.SJ_RHAsistenciaPensionAnularDuplicidadAsistencia(desde, hasta);
                contexto.Connection.Close();
                contexto.Dispose();
            }
        }

        /* 23.06.16 Agrupar transferencia de asistencia por persona, pension, dia */
        public List<SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupadoResult> ObtnerListaAsistenciasValidasRefrigerioAgrupado(string fecha, string fechaHasta, string dniPension)
        {
            List<SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupadoResult> listado = new List<SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupadoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + fecha.Substring(6, 4)].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 9998999;
                listado = Modelo.SJ_RHConsultarHistorialAsistenciaRefrigerioAgrupado(fecha, fechaHasta, dniPension).ToList();
                Modelo.Connection.Close();
            }

            return listado;
        }

        public string ObtenerDniPension()
        {
            string cnx = string.Empty;
            string nroDniPension = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();
            using (PensionRefrigeriosDataContext contexto = new PensionRefrigeriosDataContext(cnx))
            {
                contexto.CommandTimeout = 9998000;
                var resultadoConsulta = contexto.SJ_RHPensions.ToList();

                if (resultadoConsulta != null && resultadoConsulta.ToList().Count > 0)
                {
                    foreach (var item in resultadoConsulta)
                    {
                        nroDniPension += (item.NroDNI != null ? item.NroDNI.Trim() : "") + ',';
                    }
                }

                contexto.Connection.Close();
                contexto.Dispose();
            }

            return nroDniPension;
        }

        public List<SJ_RHProgramacionRefrigerioResumenResult> ListarResumenProgramacionRefrigerio(string periodoConsulta)
        {
            List<SJ_RHProgramacionRefrigerioResumenResult> Lista = new List<SJ_RHProgramacionRefrigerioResumenResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + periodoConsulta].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Modelo.CommandTimeout = 91899000;
                try
                {
                    Lista = Modelo.SJ_RHProgramacionRefrigerioResumen().ToList();
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }

            }
            return Lista;
        }
    }

}
