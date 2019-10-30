using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Transactions;
using MyControlsDataBinding;
using MyControlsDataBinding.Busquedas;
using TransportistaMto.Datos;

namespace Transportista.Negocios
{
    public class SJ_RHPensionNegocio
    {
        private SJ_RHPension oPension;
        private SJ_RHPensionTarifa oTarifa;

        public List<SJ_RHPensionListaResult> ListadoPensiones()
        {
            List<SJ_RHPensionListaResult> Listado = new List<SJ_RHPensionListaResult>();

            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Listado = Modelo.SJ_RHPensionLista().OrderBy(x=>x.RazonSocial.Trim()).ToList();
            }

            return Listado;
        }

        public string RegistrarPension(SJ_RHPension pension, List<SJ_RHPensionTarifa> Tarifas, List<SJ_RHPensionTarifa> TarifasEliminados)
        {
            string Codigo = string.Empty;
            //using (TransactionScope Scope = new TransactionScope())
            //{
                #region Transacción()
                string cnx = string.Empty;

                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {
                    #region Registrar()
                    if (pension.IdPension == 0)
                    {
                        #region
                        try
                        {
                            oPension = new SJ_RHPension();
                            //oPension.IdPension = pension.IdPension;
                            oPension.NroRuc = pension.NroRuc;
                            oPension.NroDNI = pension.NroDNI;
                            oPension.NombresCompletos = pension.NombresCompletos;
                            oPension.PseudoNombre = pension.PseudoNombre;
                            oPension.EsDesayuno = pension.EsDesayuno;
                            oPension.EsAlmuerzo = pension.EsAlmuerzo;
                            oPension.EsCena = pension.EsCena;
                            oPension.EsOtro = pension.EsOtro;
                            oPension.IdEstado = pension.IdEstado;
                            oPension.capacidadAtencion = pension.capacidadAtencion;
                            oPension.FechaRegistro = DateTime.Now;
                            Modelo.SJ_RHPensions.InsertOnSubmit(oPension);
                            Modelo.SubmitChanges();
                            Codigo = oPension.IdPension.ToString();


                            #region Registrar Tarifas()
                            foreach (SJ_RHPensionTarifa item in Tarifas)
                            {
                                #region Grabar Nuevo
                                try
                                {
                                    oTarifa = new SJ_RHPensionTarifa();
                                    oTarifa.IdPension = Convert.ToInt32(Codigo);
                                    oTarifa.Item = item.Item;
                                    oTarifa.TipoRefrigerio = item.TipoRefrigerio;
                                    oTarifa.PrecioPersona = item.PrecioPersona;
                                    oTarifa.ValidoDesde = item.ValidoDesde;
                                    oTarifa.ValidoHasta = item.ValidoHasta;
                                    oTarifa.Observacion = item.Observacion;
                                    oTarifa.IdEstado = item.IdEstado;
                                    Modelo.SJ_RHPensionTarifa.InsertOnSubmit(oTarifa);
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
                        catch (Exception Ex)
                        {
                            throw Ex;
                        }
                        #endregion
                    }
                    else
                    {
                        #region Actualizar

                        try
                        {
                            if (Modelo.SJ_RHPensions.Where(x => x.IdPension == pension.IdPension).ToList().Count == 1)
                            {
                                oPension = new SJ_RHPension();
                                oPension = Modelo.SJ_RHPensions.Where(x => x.IdPension == pension.IdPension).Single();
                                oPension.NroRuc = pension.NroRuc;
                                oPension.NroDNI = pension.NroDNI;
                                oPension.NombresCompletos = pension.NombresCompletos;
                                oPension.PseudoNombre = pension.PseudoNombre;
                                oPension.EsDesayuno = pension.EsDesayuno;
                                oPension.EsAlmuerzo = pension.EsAlmuerzo;
                                oPension.EsCena = pension.EsCena;
                                oPension.EsOtro = pension.EsOtro;
                                oPension.capacidadAtencion = pension.capacidadAtencion;
                                Modelo.SubmitChanges();
                                Codigo = oPension.IdPension.ToString();



                                if (TarifasEliminados.Count > 0)
                                {
                                    EliminarPensionTarifa(TarifasEliminados);
                                }

                                #region Registro y/o Actualizacion()
                                foreach (SJ_RHPensionTarifa item in Tarifas)
                                {
                                    if (Modelo.SJ_RHPensionTarifa.Where(x => x.IdPension == item.IdPension && x.Item == item.Item).ToList().Count == 1)
                                    {
                                        #region Actualizar()
                                        try
                                        {
                                            oTarifa = new SJ_RHPensionTarifa();
                                            oTarifa = Modelo.SJ_RHPensionTarifa.Where(x => x.IdPension == item.IdPension && x.Item == item.Item).Single();
                                            //oTarifa.IdPension = item.IdPension;
                                            //oTarifa.Item = item.Item;
                                            oTarifa.TipoRefrigerio = item.TipoRefrigerio;
                                            oTarifa.PrecioPersona = item.PrecioPersona;
                                            oTarifa.ValidoDesde = item.ValidoDesde;
                                            oTarifa.ValidoHasta = item.ValidoHasta;
                                            oTarifa.Observacion = item.Observacion;
                                            oTarifa.IdEstado = item.IdEstado;
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
                                        #region Grabar Nuevo
                                        try
                                        {
                                            oTarifa = new SJ_RHPensionTarifa();
                                            oTarifa.IdPension = item.IdPension;
                                            oTarifa.Item = item.Item;
                                            oTarifa.TipoRefrigerio = item.TipoRefrigerio;
                                            oTarifa.PrecioPersona = item.PrecioPersona;
                                            oTarifa.ValidoDesde = item.ValidoDesde;
                                            oTarifa.ValidoHasta = item.ValidoHasta;
                                            oTarifa.Observacion = item.Observacion;
                                            oTarifa.IdEstado = item.IdEstado;
                                            Modelo.SJ_RHPensionTarifa.InsertOnSubmit(oTarifa);
                                            Modelo.SubmitChanges();
                                        }
                                        catch (Exception Ex)
                                        {
                                            throw Ex;
                                        }
                                        #endregion
                                    }
                                }
                                #endregion
                            }
                        }
                        catch (Exception Ex)
                        {
                            throw Ex;
                        }
                        #endregion
                    }

                    #endregion
                    Modelo.Connection.Close();
                }
                #endregion
            //    Scope.Complete();
            //}

            return Codigo;
        }


        public SJ_RHPension ObtenerInformacionCasaPension(string nroDniPension)
        {
            SJ_RHPension oSJ_RHPension = new SJ_RHPension();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd2014"].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                var Listado = Modelo.SJ_RHPensions.Where(x => x.NroDNI.Trim() == nroDniPension).ToList();
                if (Listado != null && Listado.ToList().Count == 1)
                {
                    oSJ_RHPension = Listado.Single();
                }
                Modelo.Connection.Close();
            }
            return oSJ_RHPension;
        }


        public void AnularPension(int CodigoRegistro)
        {
            //using (TransactionScope Scope = new TransactionScope())
            //{
                #region Transacción()
                string cnx = string.Empty;

                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {
                    #region Registro, Edición de Pensión()
                    if (Modelo.SJ_RHPensions.Where(x => x.IdPension == CodigoRegistro).ToList().Count == 1)
                    {
                        //Anular
                        try
                        {
                            oPension = new SJ_RHPension();
                            oPension = Modelo.SJ_RHPensions.Where(x => x.IdPension == CodigoRegistro).Single();
                            oPension.IdEstado = "AN";
                            Modelo.SubmitChanges();
                        }
                        catch (Exception Ex)
                        {

                            throw Ex;
                        }

                    }
                    #endregion
                    Modelo.Connection.Close();
                }
                #endregion
            //    Scope.Complete();
            //}
        }

        public void EliminarPension(int CodigoRegistro)
        {
            //using (TransactionScope Scope = new TransactionScope())
            //{
                #region Transacción()
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {
                    #region Registro, Edición de Pensión()
                    if (Modelo.SJ_RHPensions.Where(x => x.IdPension == CodigoRegistro).ToList().Count == 1)
                    {
                        if (Modelo.SJ_RHPensionTarifa.Where(x => x.IdPension == CodigoRegistro).ToList().Count > 0)
                        {
                            Modelo.SJ_RHPensionTarifaEliminarxCodigo(CodigoRegistro);
                        }
                        // Eliminar
                        try
                        {
                            oPension = new SJ_RHPension();
                            oPension = Modelo.SJ_RHPensions.Where(x => x.IdPension == CodigoRegistro).Single();
                            Modelo.SJ_RHPensions.DeleteOnSubmit(oPension);
                            Modelo.SubmitChanges();
                        }
                        catch (Exception Ex)
                        {
                            throw Ex;
                        }
                    }
                    #endregion
                    Modelo.Connection.Close();
                }
                #endregion
            //    Scope.Complete();
            //}
        }

        public List<SJ_RHPensionTarifaListarXCodigoResult> ListadoPensionesxTarifa(int Codigo)
        {
            List<SJ_RHPensionTarifaListarXCodigoResult> Listado = new List<SJ_RHPensionTarifaListarXCodigoResult>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();

            using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
            {
                Listado = Modelo.SJ_RHPensionTarifaListarXCodigo(Codigo).ToList();
                Modelo.Connection.Close();
            }
            return Listado;
        }

        public void RegistrarPensionTarifa(List<SJ_RHPensionTarifa> Lista)
        {
            using (TransactionScope Scope = new TransactionScope())
            {
                #region Transaccion
                string cnx = string.Empty;

                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {
                    #region Registro y/o Actualizacion()

                    foreach (SJ_RHPensionTarifa item in Lista)
                    {
                        if (Modelo.SJ_RHPensionTarifa.Where(x => x.IdPension == item.IdPension && x.Item == item.Item).ToList().Count == 1)
                        {
                            #region Actualizar()
                            try
                            {
                                oTarifa = new SJ_RHPensionTarifa();
                                oTarifa = Modelo.SJ_RHPensionTarifa.Where(x => x.IdPension == item.IdPension && x.Item == item.Item).Single();
                                //oTarifa.IdPension = item.IdPension;
                                //oTarifa.Item = item.Item;
                                oTarifa.TipoRefrigerio = item.TipoRefrigerio;
                                oTarifa.PrecioPersona = item.PrecioPersona;
                                oTarifa.ValidoDesde = item.ValidoDesde;
                                oTarifa.ValidoHasta = item.ValidoHasta;
                                oTarifa.Observacion = item.Observacion;
                                //oTarifa.IdEstado = item.IdEstado;
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
                            #region Grabar Nuevo
                            try
                            {
                                oTarifa = new SJ_RHPensionTarifa();
                                oTarifa.IdPension = item.IdPension;
                                oTarifa.Item = item.Item;
                                oTarifa.TipoRefrigerio = item.TipoRefrigerio;
                                oTarifa.PrecioPersona = item.PrecioPersona;
                                oTarifa.ValidoDesde = item.ValidoDesde;
                                oTarifa.ValidoHasta = item.ValidoHasta;
                                oTarifa.Observacion = item.Observacion;
                                oTarifa.IdEstado = item.IdEstado;
                                Modelo.SJ_RHPensionTarifa.InsertOnSubmit(oTarifa);
                                Modelo.SubmitChanges();
                            }
                            catch (Exception Ex)
                            {

                                throw Ex;
                            }


                            #endregion
                        }
                    }

                    #endregion
                    Modelo.Connection.Close();
                }
                #endregion

                Scope.Complete();
            }
        }

        public List<DFormatoSimple> ListaRefrigerios()
        {
            List<DFormatoSimple> listado = new List<DFormatoSimple>();
            RefrigerioNegocio refrigerioNeg = new RefrigerioNegocio();
            List<Refrigerio> ListaRefrigerio = new List<Refrigerio>();

            string cnx;
            cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
            using (PensionRefrigeriosDataContext Contexto = new PensionRefrigeriosDataContext(cnx))
            {
                ListaRefrigerio = refrigerioNeg.ListaRefrigerios();
                listado = (from items in ListaRefrigerio

                           select new DFormatoSimple
                           {
                               Codigo = items.TipoRefrigerio.ToString(),
                               Descripcion = items.Descripcion.ToString().Trim(),
                           }).ToList();
            }

            return listado;
        }

        public void EliminarPensionTarifa(List<SJ_RHPensionTarifa> Lista)
        {
            using (TransactionScope Scope = new TransactionScope())
            {
                string cnx = string.Empty;
                cnx = ConfigurationManager.AppSettings["bd" + DateTime.Now.Year.ToString()].ToString();
                using (PensionRefrigeriosDataContext Modelo = new PensionRefrigeriosDataContext(cnx))
                {

                    foreach (SJ_RHPensionTarifa item in Lista)
                    {
                        if (Modelo.SJ_RHPensionTarifa.Where(x => x.IdPension == item.IdPension && x.Item == item.Item).ToList().Count == 1)
                        {
                            try
                            {
                                SJ_RHPensionTarifa tarifa = new SJ_RHPensionTarifa();
                                tarifa = Modelo.SJ_RHPensionTarifa.Where(x => x.IdPension == item.IdPension && x.Item == item.Item).Single();
                                Modelo.SJ_RHPensionTarifa.DeleteOnSubmit(tarifa);
                                Modelo.SubmitChanges();
                            }
                            catch (Exception Ex)
                            {

                                throw Ex;
                            }
                        }
                    }
                }
                Scope.Complete();
            }
        }

    }
}
