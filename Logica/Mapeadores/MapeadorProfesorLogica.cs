
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorProfesorLogica : MapeadorBaseLogica<ProfesorDbModel, ProfesorDTO>
    {
        public override ProfesorDTO MapearTipo1Tipo2(ProfesorDbModel entrada)
        {
            return new ProfesorDTO()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                IdPrograma = entrada.IdPrograma,
                NombrePrograma=entrada.NombrePrograma,
                NombrePersona=entrada.NombrePersona

            };
        }

        public override IEnumerable<ProfesorDTO> MapearTipo1Tipo2(IEnumerable<ProfesorDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProfesorDbModel MapearTipo2Tipo1(ProfesorDTO entrada)
        {
            return new ProfesorDbModel()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                IdPrograma = entrada.IdPrograma
            };
        }

        public override IEnumerable<ProfesorDbModel> MapearTipo2Tipo1(IEnumerable<ProfesorDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}