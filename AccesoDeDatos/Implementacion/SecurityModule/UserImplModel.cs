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
                    UserModelMapper mapper = new UserModelMapper();
                    SEC_USER record = mapper.MapperT2T1(dbModel);
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

                UserModelMapper mapper = new UserModelMapper();
                var listaFinal = mapper.MapperT1T2(lista);

                return listaFinal;
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
                UserModelMapper mapper = new UserModelMapper();
                return mapper.MapperT1T2(login);
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
    }
}
