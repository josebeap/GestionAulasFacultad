using AccesoDeDatos.DbModel.SecurityModule;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.SecurityModule
{
    /// <summary>
    /// class to define the mapper structure for user
    /// </summary>
    public class UserDbModelMapper : MapeadorBaseDatos<SEC_USER, UserDbModel>
    {
        public override UserDbModel MapearTipo1Tipo2(SEC_USER input)
        {
            var roles = input.SEC_USER_ROLE.Select(x => x.SEC_ROLE);
            RoleDbModelMapper roleMapper = new RoleDbModelMapper();
            return new UserDbModel()
            {
                Id = input.ID,
                Name = input.NAME,
                Lastname = input.LASTNAME,
                Cellphone = input.CELLPHONE,
                Email = input.EMAIL,
                Password = input.USER_PASSWORD,
                Roles = roleMapper.MapearTipo1Tipo2(roles),
                Token = input.SEC_SESSION.Where(x => x.TOKEN_STATUS).OrderByDescending(d => d.LOGIN_DATE).Select(x => x.TOKEN).FirstOrDefault()
            };
        }

        public override IEnumerable<UserDbModel> MapearTipo1Tipo2(IEnumerable<SEC_USER> input)
        {
            foreach (var item in input)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override SEC_USER MapearTipo2Tipo1(UserDbModel input)
        {
            return new SEC_USER()
            {
                ID = input.Id,
                NAME = input.Name,
                LASTNAME = input.Lastname,
                CELLPHONE = input.Cellphone,
                EMAIL = input.Email,
                USER_PASSWORD = input.Password
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override IEnumerable<SEC_USER> MapearTipo2Tipo1(IEnumerable<UserDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
