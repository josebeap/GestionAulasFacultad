
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorProgramaLogica : MapeadorBaseLogica<ProgramaDbModel, ProgramaDTO>
    {
        public override ProgramaDTO MapearTipo1Tipo2(ProgramaDbModel entrada)
        {
            return new ProgramaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre

            };
        }

        public override IEnumerable<ProgramaDTO> MapearTipo1Tipo2(IEnumerable<ProgramaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProgramaDbModel MapearTipo2Tipo1(ProgramaDTO entrada)
        {
            return new ProgramaDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<ProgramaDbModel> MapearTipo2Tipo1(IEnumerable<ProgramaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}