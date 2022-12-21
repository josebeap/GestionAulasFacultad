using AccesoDeDatos.DbModel.SecurityModule;
using AccesoDeDatos.Mapeadores.SecurityModule;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.SecurityModule
{
    public class RoleImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro a los roles
        /// </summary>
        /// <param name="dbModel">Representa un objeto con la información del rol</param>
        /// <returns>entero con la respuesta: 1. OK, 2. KO, 3. Ya existe</returns>
        public int RecordCreation(RoleDbModel dbModel)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    // Verifica si existe un role con el nombre que se quiere crear el nuevo
                    if (db.SEC_ROLE.Where(x => x.NAME.ToUpper().Equals(dbModel.Name.ToUpper())).Count() > 0)
                    {
                        return 3;
                    }

                    RoleDbModelMapper mapper = new RoleDbModelMapper();
                    SEC_ROLE record = mapper.MapearTipo2Tipo1(dbModel);

                    db.SEC_ROLE.Add(record);
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
        public int RecordUpdate(RoleDbModel dbModel)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }

                    record.NAME = dbModel.Name;
                    record.DESCRIPTION = dbModel.Description;
                    record.REMOVED = dbModel.Removed;

                    db.Entry(record).State = EntityState.Modified;
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
        public int RecordRemove(RoleDbModel dbModel)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    //db.SEC_ROLE.Remove(record);

                    record.REMOVED = true;

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
        public IEnumerable<RoleDbModel> RecordList(string filter)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                //var listaLambda = db.SEC_ROLE.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter.ToUpper())).ToList();

                var listaLinq = from role in db.SEC_ROLE
                                where !role.REMOVED && role.NAME.ToUpper().Contains(filter)
                                select role;

                RoleDbModelMapper mapper = new RoleDbModelMapper();
                var listaFinal = mapper.MapearTipo1Tipo2(listaLinq);

                return listaFinal.ToList();
            }
        }

        public RoleDbModel RecordSearch(int id)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                var record = db.SEC_ROLE.Where(x => !x.REMOVED && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    RoleDbModelMapper mapper = new RoleDbModelMapper();
                    return mapper.MapearTipo1Tipo2(record);
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<RoleDbModel> RecordListByUser(int userId)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                var roleListDB = from role in db.SEC_ROLE
                                 where !role.REMOVED
                                 select role;

                var rolelistDbModel = new List<RoleDbModel>();

                foreach (var role in roleListDB)
                {
                    rolelistDbModel.Add(new RoleDbModel()
                    {
                        Id = role.ID,
                        Name = role.NAME,
                        Description = role.DESCRIPTION,
                        Removed = role.REMOVED,
                        IsSelectedByUser = db.SEC_USER_ROLE.Where(x => x.ROLEID == role.ID && x.USERID == userId).Count() > 0
                    });
                }

                return rolelistDbModel.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forms"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool AssignForms(List<int> forms, int roleId)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                try
                {
                    IList<SEC_FORMS_ROLE> formsRoleList = db.SEC_FORMS_ROLE.Where(x => x.ROLE_ID == roleId).ToList();
                    foreach (var formsRole in formsRoleList)
                    {
                        db.SEC_FORMS_ROLE.Remove(formsRole);
                    }

                    foreach (int formsId in forms)
                    {
                        db.SEC_FORMS_ROLE.Add(new SEC_FORMS_ROLE()
                        {
                            ROLE_ID = roleId,
                            FORM_ID = formsId
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


        public IEnumerable<FormDbModel> RecordFormList()
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                var recordList = from f in db.SEC_FORM
                                 select f;

                FormDbModelMapper mapper = new FormDbModelMapper();
                var listaFinal = mapper.MapearTipo1Tipo2(recordList).ToList();

                return listaFinal.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IEnumerable<FormDbModel> RecordFormListByRole(int roleId)
        {
            using (SoftwareSSOEntities db = new SoftwareSSOEntities())
            {
                var recordList = from f in db.SEC_FORM
                                 select f;
                IList<FormDbModel> listaFinal = new List<FormDbModel>();
                foreach (var f in recordList)
                {
                    listaFinal.Add(new FormDbModel()
                    {
                        Id = f.ID,
                        Name = f.NAME,
                        Url = f.URL,
                        IsSelectedByUser = f.SEC_FORMS_ROLE.Where(x => x.ROLE_ID == roleId).Count() > 0
                    });
                }

                return listaFinal;
            }
        }

    }
}
