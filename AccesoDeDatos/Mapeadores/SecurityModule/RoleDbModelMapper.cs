﻿using AccesoDeDatos.DbModel.SecurityModule;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.SecurityModule
{
    public class RoleDbModelMapper : MapeadorBaseDatos<SEC_ROLE, RoleDbModel>
    {
        /// <summary>
        /// Method to map the SEC_ROLE object to RoleDbModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override RoleDbModel MapearTipo1Tipo2(SEC_ROLE input)
        {
            return new RoleDbModel()
            {
                Id = input.ID,
                Name = input.NAME,
                Description = input.DESCRIPTION,
                Removed = input.REMOVED
            };
        }

        public override IEnumerable<RoleDbModel> MapearTipo1Tipo2(IEnumerable<SEC_ROLE> input)
        {
            foreach (var item in input)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override SEC_ROLE MapearTipo2Tipo1(RoleDbModel input)
        {
            return new SEC_ROLE()
            {
                ID = input.Id,
                NAME = input.Name,
                DESCRIPTION = input.Description,
                REMOVED = input.Removed
            };
        }

        public override IEnumerable<SEC_ROLE> MapearTipo2Tipo1(IEnumerable<RoleDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
