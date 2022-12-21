﻿using AccesoDeDatos.DbModel.SecurityModule;
using AccesoDeDatos.Mapeadores.SecurityModule;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.SecurityModule
{
    public class UserImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro a los roles
        /// </summary>
        /// <param name="dbModel">Representa un objeto con la información del rol</param>
        /// <returns>entero con la respuesta: 1. OK, 2. KO, 3. Ya existe</returns>
        public int RecordCreation(UserDbModel dbModel)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    UserDbModelMapper mapper = new UserDbModelMapper();
                    SEC_USER record = mapper.MapearTipo2Tipo1(dbModel);
                    record.CREATE_DATE = dbModel.CurrentDate;
                    record.CREATE_USER_ID = dbModel.UserInSessionId;

                    db.SEC_USER.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public UserDbModel RecordSearch(int id)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                var record = db.SEC_USER.Where(x => !x.REMOVED && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    UserDbModelMapper mapper = new UserDbModelMapper();
                    return mapper.MapearTipo1Tipo2(record);
                }
                return null;
            }
        }

        /// <summary>
        /// Actualización de un registro
        /// </summary>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        public int RecordUpdate(UserDbModel dbModel)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    var record = db.SEC_USER.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }

                    record.NAME = dbModel.Name;
                    record.LASTNAME = dbModel.Lastname;
                    record.CELLPHONE = dbModel.Cellphone;
                    record.EMAIL = dbModel.Email;
                    record.USER_PASSWORD = dbModel.Password;
                    record.UPDATE_USER_ID = dbModel.UserInSessionId;
                    record.UPDATE_DATE = dbModel.CurrentDate;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        public int RecordRemove(UserDbModel dbModel)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    var record = db.SEC_USER.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    //db.SEC_ROLE.Remove(record);

                    record.REMOVED = true;
                    record.REMOVE_DATE = dbModel.CurrentDate;
                    record.REMOVE_USER_ID = dbModel.UserInSessionId;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<UserDbModel> RecordList(string filter)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                var lista = from role in db.SEC_USER
                            where !role.REMOVED && role.NAME.ToUpper().Contains(filter.ToUpper())
                            select role;

                UserDbModelMapper mapper = new UserDbModelMapper();
                var listaFinal = mapper.MapearTipo1Tipo2(lista);

                return listaFinal;
            }
        }

        public int ChangePassword(string currentPassword, string newPassword, int userId, out string email)
        {
            email = String.Empty;
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    var user = db.SEC_USER.Where(x => x.ID == userId && x.USER_PASSWORD.Equals(currentPassword)).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }
                    user.USER_PASSWORD = newPassword;
                    db.SaveChanges();
                    email = user.EMAIL;
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public int PasswordReset(string email, string newPassword)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    var user = db.SEC_USER.Where(x => x.EMAIL.Equals(email)).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }
                    user.USER_PASSWORD = newPassword;
                    db.SaveChanges();
                    email = user.EMAIL;
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }



        public UserDbModel Login(UserDbModel dbModel)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                var login = (from user in db.SEC_USER
                             where user.EMAIL.ToUpper().Equals(dbModel.Email.ToUpper()) && user.USER_PASSWORD.Equals(dbModel.Password)
                             select user).FirstOrDefault();

                if (login == null)
                {
                    return null;
                }

                var date = dbModel.CurrentDate;
                SEC_SESSION session = new SEC_SESSION()
                {
                    USERID = login.ID,
                    LOGIN_DATE = date,
                    TOKEN_STATUS = true,
                    TOKEN = this.GetToken(String.Concat(login.ID, date)),
                    IP_ADDRESS = this.GetIpAddress()
                };

                db.SEC_SESSION.Add(session);
                db.SaveChanges();
                UserDbModelMapper mapper = new UserDbModelMapper();
                return mapper.MapearTipo1Tipo2(login);
            }
        }



        private string GetToken(string key)
        {
            int HashCode = key.GetHashCode();
            return HashCode.ToString();
        }

        private string GetIpAddress()
        {
            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);
            // Get the IP  
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            return myIP;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool AssignRoles(List<int> roles, int userId)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    IList<SEC_USER_ROLE> userRoleList = db.SEC_USER_ROLE.Where(x => x.USERID == userId).ToList();
                    foreach (var userRole in userRoleList)
                    {
                        db.SEC_USER_ROLE.Remove(userRole);
                    }

                    foreach (int roleId in roles)
                    {
                        db.SEC_USER_ROLE.Add(new SEC_USER_ROLE()
                        {
                            USERID = userId,
                            ROLEID = roleId
                        });
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public IEnumerable<FormDbModel> GetRoleFormsByUser(int userId)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                // query to get role forms by user
                IEnumerable<SEC_FORM> list = (from u in db.SEC_USER
                                              join ur in db.SEC_USER_ROLE on u.ID equals ur.USERID
                                              join r in db.SEC_ROLE on ur.ROLEID equals r.ID
                                              join fr in db.SEC_FORMS_ROLE on r.ID equals fr.ROLE_ID
                                              join f in db.SEC_FORM on fr.FORM_ID equals f.ID
                                              where u.ID == userId
                                              select f).Distinct().ToList();

                IList<FormDbModel> formsList = new FormDbModelMapper().MapearTipo1Tipo2(list).ToList();

                return formsList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="formId"></param>
        /// <returns></returns>
        public bool ValidateUserInForm(int userId, int formId)
        {

            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                // query to get role forms by user
                var amountForms = (from u in db.SEC_USER
                                   join ur in db.SEC_USER_ROLE on u.ID equals ur.USERID
                                   join r in db.SEC_ROLE on ur.ROLEID equals r.ID
                                   join fr in db.SEC_FORMS_ROLE on r.ID equals fr.ROLE_ID
                                   where u.ID == userId && fr.FORM_ID == formId
                                   select fr).Count();

                return amountForms > 0;
            }
        }

    }
}
