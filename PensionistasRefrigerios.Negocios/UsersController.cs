using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Asistencia.Datos;
using System.Configuration;
using System.Transactions;

namespace Asistencia.Negocios
{
    public class UsersController
    {
        // clase con los usuarios y privilegios

        public List<ASJ_USUARIOS> GetListAllUser(string conection, string companyId)
        {
            var result = new List<ASJ_USUARIOS>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection];
            using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
            {
                result = context.ASJ_USUARIOS.ToList();
            }
            return result;
        }

        public List<SAS_ListadoDeUsuariosDelSistema> GetListAllUserSystem(string conection, string companyId)
        {
            var result = new List<SAS_ListadoDeUsuariosDelSistema>();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection];
            using (SATURNODataContext context = new SATURNODataContext(cnx))
            {
                result = context.SAS_ListadoDeUsuariosDelSistema.ToList();
            }
            return result;
        }



        public ASJ_USUARIOS FindUserByIdUser(string conection, string idUser, string companyId)
        {
            var result = new ASJ_USUARIOS();
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection];
            using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
            {
                var resultQuery = context.ASJ_USUARIOS.Where(x => x.IdUsuario.Trim() == idUser.Trim()).ToList();
                if (resultQuery != null && resultQuery.Count == 1)
                {
                    result = resultQuery.Single();
                }
            }

            return result;
        }

        public bool AddUser(string conection, ASJ_USUARIOS user, string companyId)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection];
            using (TransactionScope scope = new TransactionScope())
            {
                using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
                {
                    var resultQuery = context.ASJ_USUARIOS.Where(x => x.IdUsuario.Trim() == user.IdUsuario.Trim()).ToList();
                    if (resultQuery != null && resultQuery.Count == 1)
                    {
                        #region Edit()
                        ASJ_USUARIOS oUserNew = new ASJ_USUARIOS();
                        oUserNew = resultQuery.Single();
                        oUserNew.IdCodigoGeneral = user.IdCodigoGeneral != null ? user.IdCodigoGeneral.ToUpper().Trim() : string.Empty;
                        //oUserNew.Password = user.Password != null ? user.Password.ToUpper().Trim() : string.Empty;
                        oUserNew.NombreCompleto = user.NombreCompleto != null ? user.NombreCompleto.ToUpper().Trim() : string.Empty;
                        oUserNew.AREA = user.AREA != null ? user.AREA.Trim() : string.Empty;
                        oUserNew.email = user.email != null ? user.email.ToLower().Trim() : string.Empty;
                        oUserNew.idestado = user.idestado != null ? user.idestado.Trim() : string.Empty;
                        oUserNew.Local = user.Local != null ? user.Local.Trim() : string.Empty;
                        oUserNew.nivel = user.nivel != null ? user.nivel.ToUpper().Trim() : string.Empty;
                        oUserNew.IDSUCURSAL = user.IDSUCURSAL != null ? user.IDSUCURSAL.ToUpper().Trim() : string.Empty;
                        oUserNew.SUCURSAL = user.SUCURSAL != null ? user.SUCURSAL.ToUpper().Trim() : string.Empty;
                        oUserNew.id_puerta = user.id_puerta;
                        oUserNew.puerta = user.puerta != null ? user.puerta.ToUpper().Trim() : string.Empty;
                        context.SubmitChanges();
                        status = true;
                        #endregion
                    }
                    else
                    {
                        #region Add()
                        ASJ_USUARIOS oUserNew = new ASJ_USUARIOS();
                        oUserNew.IdUsuario = user.IdUsuario.ToLower().Trim();
                        oUserNew.IdCodigoGeneral = user.IdCodigoGeneral != null ? user.IdCodigoGeneral.ToUpper().Trim() : string.Empty;
                        oUserNew.Password = user.Password != null ? user.Password.Trim() : string.Empty;
                        oUserNew.NombreCompleto = user.NombreCompleto != null ? user.NombreCompleto.ToUpper().Trim() : string.Empty;
                        oUserNew.AREA = user.AREA != null ? user.AREA.ToUpper().Trim() : string.Empty;
                        oUserNew.email = user.email != null ? user.email.ToLower().Trim() : string.Empty;
                        oUserNew.idestado = user.idestado != null ? user.idestado.ToUpper().Trim() : string.Empty;
                        oUserNew.Local = user.Local != null ? user.Local.ToUpper().Trim() : string.Empty;
                        oUserNew.nivel = user.nivel != null ? user.nivel.ToUpper().Trim() : string.Empty;
                        oUserNew.IDSUCURSAL = user.IDSUCURSAL != null ? user.IDSUCURSAL.ToUpper().Trim() : string.Empty;
                        oUserNew.SUCURSAL = user.SUCURSAL != null ? user.SUCURSAL.ToUpper().Trim() : string.Empty;
                        oUserNew.id_puerta = user.id_puerta;
                        oUserNew.puerta = user.puerta != null ? user.puerta.ToUpper().Trim() : string.Empty;
                        context.ASJ_USUARIOS.InsertOnSubmit(oUserNew);
                        context.SubmitChanges();
                        status = true;
                        #endregion
                    }
                }
                scope.Complete();
            }
            return status;
        }

        public bool RemoveUser(string conection, ASJ_USUARIOS user, string companyId)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection];
            using (TransactionScope scope = new TransactionScope())
            {
                using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
                {
                    var resultQuery = context.ASJ_USUARIOS.Where(x => x.IdUsuario.Trim() == user.IdUsuario.Trim()).ToList();
                    if (resultQuery != null && resultQuery.Count == 1)
                    {
                        #region Remove()
                        ASJ_USUARIOS oUserNew = new ASJ_USUARIOS();
                        oUserNew = resultQuery.Single();

                        var privilegesByUser = context.PrivilegioFormulario.Where(x => x.usuarioCodigo.Trim() == user.IdUsuario.Trim()).ToList();

                        if (privilegesByUser != null && privilegesByUser.ToList().Count > 0)
                        {
                            context.PrivilegioFormulario.DeleteAllOnSubmit(privilegesByUser);
                            context.SubmitChanges();
                        }

                        context.ASJ_USUARIOS.DeleteOnSubmit(oUserNew);
                        context.SubmitChanges();
                        status = true;
                        #endregion
                    }
                }
                scope.Complete();

            }
            return status;
        }

        public bool ChangeStateUser(string conection, ASJ_USUARIOS user, string companyId)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection];
            using (TransactionScope scope = new TransactionScope())
            {
                using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
                {
                    var resultQuery = context.ASJ_USUARIOS.Where(x => x.IdUsuario.Trim() == user.IdUsuario.Trim()).ToList();
                    if (resultQuery != null && resultQuery.Count == 1)
                    {
                        #region Edit()
                        ASJ_USUARIOS oUserNew = new ASJ_USUARIOS();
                        oUserNew = resultQuery.Single();
                        if (oUserNew.idestado.Trim() == "1")
                        {
                            oUserNew.idestado = "0";
                        }
                        else
                        {
                            oUserNew.idestado = "1";
                        }

                        context.SubmitChanges();
                        status = true;
                        #endregion
                    }
                }
                scope.Complete();
            }
            return status;
        }

        public bool ResetPasswordByUser(string conection, ASJ_USUARIOS user, string companyId)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (TransactionScope scope = new TransactionScope())
            {
                using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
                {
                    var resultQuery = context.ASJ_USUARIOS.Where(x => x.IdUsuario.Trim() == user.IdUsuario.Trim() && x.EmpresaID.Trim() == companyId.Trim()).ToList();
                    if (resultQuery != null && resultQuery.Count == 1)
                    {
                        #region ResetPassword()
                        ASJ_USUARIOS oUserNew = new ASJ_USUARIOS();
                        oUserNew = resultQuery.Single();
                        oUserNew.Password = string.Empty;
                        context.SubmitChanges();
                        status = true;
                        #endregion
                    }
                }
                scope.Complete();

            }
            return status;
        }


        public bool ChangePasswordByUser(string conection, ASJ_USUARIOS user, string companyId)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection].ToString();
            using (TransactionScope scope = new TransactionScope())
            {
                using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
                {
                    var resultQuery = context.ASJ_USUARIOS.Where(x => x.IdUsuario.Trim() == user.IdUsuario.Trim() && x.EmpresaID.Trim() == companyId.Trim()).ToList();
                    if (resultQuery != null && resultQuery.Count == 1)
                    {
                        #region ResetPassword()
                        ASJ_USUARIOS oUserNew = new ASJ_USUARIOS();
                        oUserNew = resultQuery.Single();
                        oUserNew.Password = user.Password;
                        context.SubmitChanges();
                        status = true;
                        #endregion
                    }
                }
                scope.Complete();

            }
            return status;
        }


        public bool UpdatePassWordByUser(string conection, ASJ_USUARIOS user, string companyId)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection];
            using (TransactionScope scope = new TransactionScope())
            {
                using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
                {
                    var resultQuery = context.ASJ_USUARIOS.Where(x => x.IdUsuario.Trim() == user.IdUsuario.Trim()).ToList();
                    if (resultQuery != null && resultQuery.Count == 1)
                    {
                        #region Edit()
                        ASJ_USUARIOS oUserNew = new ASJ_USUARIOS();
                        oUserNew = resultQuery.Single();
                        oUserNew.Password = user.Password.Trim();
                        context.SubmitChanges();
                        status = true;
                        #endregion
                    }
                }
                scope.Complete();

            }
            return status;
        }

        public List<PrivilegesByUser> GetListPrivilegesByUser(string conection, string userId, string companyId)
        {
            string cnx = string.Empty;
            List<PrivilegesByUser> result = new List<PrivilegesByUser>();
            cnx = ConfigurationManager.AppSettings[conection];
            using (SATURNODataContext context = new SATURNODataContext(cnx))
            {

                context.SAS_CompletarPrivilegiosParaUsuario(userId);

                result = (from p in context.SAS_PrivilegioFormulario
                          join m in context.SAS_FormularioSistema on p.formularioCodigo equals m.formularioCodigo
                          join mm in context.SAS_ModuloSistema on m.moduloCodigo.Trim() equals mm.moduloCodigo.Trim()
                          join usu in context.SAS_USUARIOS on p.usuarioCodigo.Trim() equals usu.IdUsuario.Trim()
                          where p.usuarioCodigo.Trim() == userId.Trim() && usu.EmpresaID.Trim() == companyId
                          select new PrivilegesByUser
                          {
                              usuarioCodigo = p.usuarioCodigo.Trim(),
                              nameUser = usu.NombreCompleto != null ? usu.NombreCompleto.Trim() : string.Empty,
                              formularioCodigo = p.formularioCodigo,
                              nuevo = p.nuevo,
                              editar = p.editar,
                              anular = p.anular,
                              eliminar = p.eliminar,
                              imprimir = p.imprimir,
                              exportar = p.exportar,
                              ninguno = p.ninguno,
                              consultar = p.consultar,
                              jerarquia = m.Jerarquia.Trim(),
                              descripcionFormulario = m.formulario.Trim() + "|  " + m.descripcion.Trim(),
                              moduloCodigo = m.moduloCodigo.Trim(),
                              modulo = mm.descripcion.Trim(),
                              tipoFormulario = m.formulario.Trim(),
                              nombreEnElSistema = m.nombreEnSistema.Trim(),
                              barraPadre = m.barraPadre.Trim(),
                          }).ToList();
            }

            return result.OrderBy(x => x.jerarquia).ToList();
        }



        public List<PrivilegesByUser> ObtenerListadoPrivilegiosPorUsuario(string conection, string userId, string companyId)
        {
            string cnx = string.Empty;
            List<PrivilegesByUser> result = new List<PrivilegesByUser>();
            cnx = ConfigurationManager.AppSettings["SAS"];
            using (SATURNODataContext context = new SATURNODataContext(cnx))
            {
                var listadoUsuario = context.SAS_USUARIOS.ToList();

                result = (from p in context.SAS_PrivilegioFormulario
                          join m in context.SAS_FormularioSistema on p.formularioCodigo equals m.formularioCodigo
                          join mm in context.SAS_ModuloSistema on m.moduloCodigo.Trim() equals mm.moduloCodigo.Trim()
                          join usu in context.SAS_USUARIOS on p.usuarioCodigo.Trim() equals usu.IdUsuario.Trim()
                          where p.usuarioCodigo.Trim() == userId.Trim() && usu.EmpresaID.Trim() == companyId
                          select new PrivilegesByUser
                          {
                              usuarioCodigo = p.usuarioCodigo.Trim(),
                              nameUser = usu.NombreCompleto != null ? usu.NombreCompleto.Trim() : string.Empty,
                              formularioCodigo = p.formularioCodigo.Trim(),
                              nuevo = p.nuevo,
                              editar = p.editar,
                              anular = p.anular,
                              eliminar = p.eliminar,
                              imprimir = p.imprimir,
                              exportar = p.exportar,
                              ninguno = p.ninguno,
                              consultar = p.consultar,
                              jerarquia = m.Jerarquia.Trim(),
                              descripcionFormulario = m.formulario.Trim() + "|  " + m.descripcion.Trim(),
                              moduloCodigo = m.moduloCodigo.Trim(),
                              modulo = mm.descripcion.Trim(),
                              tipoFormulario = m.formulario.Trim(),
                              nombreEnElSistema = m.nombreEnSistema.Trim(),
                              barraPadre = m.barraPadre.Trim(),
                          }).ToList();
            }

            return result.OrderBy(x => x.jerarquia).ToList();
        }


        public bool AddListPrivilegesByUser(string conection, List<PrivilegioFormulario> privileges, string companyId)
        {
            bool status = false;
            string cnx = string.Empty;
            cnx = ConfigurationManager.AppSettings[conection];
            using (TransactionScope scope = new TransactionScope())
            {
                using (BDAsistenciaDataContext context = new BDAsistenciaDataContext(cnx))
                {
                    if (privileges != null && privileges.ToList().Count > 0)
                    {
                        foreach (var privilege in privileges)
                        {
                            var resultQuery = context.PrivilegioFormulario.Where(x => x.formularioCodigo.Trim() == privilege.formularioCodigo.Trim() && x.usuarioCodigo.Trim() == privilege.usuarioCodigo.Trim()).ToList();
                            if (resultQuery != null && resultQuery.Count == 1)
                            {
                                var oPrivilege = new PrivilegioFormulario();
                                oPrivilege = resultQuery.Single();
                                oPrivilege.nuevo = privilege.nuevo != (byte?)null ? Convert.ToByte(privilege.nuevo) : Convert.ToByte("0");
                                oPrivilege.editar = privilege.editar != (byte?)null ? Convert.ToByte(privilege.editar) : Convert.ToByte("0");
                                oPrivilege.anular = privilege.anular != (byte?)null ? Convert.ToByte(privilege.anular) : Convert.ToByte("0");
                                oPrivilege.eliminar = privilege.eliminar != (byte?)null ? Convert.ToByte(privilege.eliminar) : Convert.ToByte("0");
                                oPrivilege.imprimir = privilege.imprimir != (byte?)null ? Convert.ToByte(privilege.imprimir) : Convert.ToByte("0");
                                oPrivilege.exportar = privilege.exportar != (byte?)null ? Convert.ToByte(privilege.exportar) : Convert.ToByte("0");
                                oPrivilege.ninguno = privilege.ninguno != (byte?)null ? Convert.ToByte(privilege.ninguno) : Convert.ToByte("0");
                                oPrivilege.consultar = privilege.consultar != (byte?)null ? Convert.ToByte(privilege.consultar) : Convert.ToByte("0");
                                context.SubmitChanges();
                                status = true;
                            }
                        }
                    }
                }
                scope.Complete();

            }

            return status;
        }

    }
}
