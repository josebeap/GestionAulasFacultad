using AccesoDeDatos.DbModel.SecurityModule;
using Logica.DTO.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Mapeadores.SecurityModule
{
    public class RoleDTOMapper : MapeadorBaseLogica<RoleDbModel, RoleDTO>
    {
        /// <summary>
        /// Method to map the RoleDbModel object to RoleDTO
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override RoleDTO MapearTipo1Tipo2(RoleDbModel input)
        {
            return new RoleDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Removed = input.Removed,
                IsSelectedByUser = input.IsSelectedByUser
            };
        }

        public override IEnumerable<RoleDTO> MapearTipo1Tipo2(IEnumerable<RoleDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override RoleDbModel MapearTipo2Tipo1(RoleDTO input)
        {
            return new RoleDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Removed = input.Removed
            };
        }

        public override IEnumerable<RoleDbModel> MapearTipo2Tipo1(IEnumerable<RoleDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
