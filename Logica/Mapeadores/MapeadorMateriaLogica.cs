
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorMateriaLogica : MapeadorBaseLogica<MateriaDbModel, MateriaDTO>
    {
        public override MateriaDTO MapearTipo1Tipo2(MateriaDbModel entrada)
        {
            return new MateriaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdPrograma = entrada.IdPrograma

            };
        }

        public override IEnumerable<MateriaDTO> MapearTipo1Tipo2(IEnumerable<MateriaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override MateriaDbModel MapearTipo2Tipo1(MateriaDTO entrada)
        {
            return new MateriaDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdPrograma = entrada.IdPrograma
            };
        }

        public override IEnumerable<MateriaDbModel> MapearTipo2Tipo1(IEnumerable<MateriaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}