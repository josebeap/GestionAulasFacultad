using AccesoDeDatos.DbModel.SecurityModule;
using AccesoDeDatos.Implementacion.SecurityModule;
using Logica.DTO.SecurityModule;
using Logica.Mapeadores.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementacion.SecurityModule
{
    public class RoleImplController
    {
        private RoleImplModel model;
        public RoleImplController()
        {
            model = new RoleImplModel();
        }

        /// <summary>
        /// Creción de un registro
        /// </summary>
        /// <param name="dto">información DTO</param>
        /// <returns>1: OK, 2: Excepción, 3. Ya existe</returns>
        public int RecordCreation(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapearTipo2Tipo1(dto);
            return model.RecordCreation(dbModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int RecordUpdate(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapearTipo2Tipo1(dto);
            return model.RecordUpdate(dbModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public int RecordRemove(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapearTipo2Tipo1(dto);
            return model.RecordRemove(dbModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<RoleDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapearTipo1Tipo2(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public RoleDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);

            if (record == null)
            {
                return null;
            }
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapearTipo1Tipo2(record);
        }

        public IEnumerable<FormDTO> RecordFormList()
        {
            var list = model.RecordFormList();
            FormDTOMapper mapper = new FormDTOMapper();
            return mapper.MapearTipo1Tipo2(list);
        }

        public IEnumerable<FormDTO> RecordFormListByRole(int roleId)
        {
            var list = model.RecordFormListByRole(roleId);
            FormDTOMapper mapper = new FormDTOMapper();
            return mapper.MapearTipo1Tipo2(list);
        }

        ///
        public bool AssignForms(List<int> formsList, int roleId)
        {
            return model.AssignForms(formsList, roleId);
        }
    }
}
