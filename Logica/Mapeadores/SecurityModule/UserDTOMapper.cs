using AccesoDeDatos.DbModel.SecurityModule;
using Logica.DTO.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Mapeadores.SecurityModule
{
    /// <summary>
    /// class to define the mapper structure for user
    /// </summary>
    public class UserDTOMapper : MapeadorBaseLogica<UserDbModel, UserDTO>
    {
        public override UserDTO MapearTipo1Tipo2(UserDbModel input)
        {
            RoleDTOMapper roleMapper = new RoleDTOMapper();
            return new UserDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Password = input.Password,
                Roles = roleMapper.MapearTipo1Tipo2(input.Roles),
                Token = input.Token
            };
        }

        public override IEnumerable<UserDTO> MapearTipo1Tipo2(IEnumerable<UserDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override UserDbModel MapearTipo2Tipo1(UserDTO input)
        {
            return new UserDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Password = input.Password,
                UserInSessionId = input.UserInSessionId,
                CurrentDate = input.CurrentDate
            };
        }

        public override IEnumerable<UserDbModel> MapearTipo2Tipo1(IEnumerable<UserDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
