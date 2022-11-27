
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorClaseLogica : MapeadorBaseLogica<ClaseDbModel, ClaseDTO>
    {
        public override ClaseDTO MapearTipo1Tipo2(ClaseDbModel entrada)
        {
            return new ClaseDTO()
            {
                Id = entrada.Id,
                IdProfesor = entrada.IdProfesor,
                IdMateria = entrada.IdMateria,
                IdAula = entrada.IdAula,
                CantidadHoras = entrada.CantidadHoras,
                FechaHoraInicio = entrada.FechaHoraInicio

            };
        }

        public override IEnumerable<ClaseDTO> MapearTipo1Tipo2(IEnumerable<ClaseDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ClaseDbModel MapearTipo2Tipo1(ClaseDTO entrada)
        {
            return new ClaseDbModel()
            {
                Id = entrada.Id,
                IdProfesor = entrada.IdProfesor,
                IdMateria = entrada.IdMateria,
                IdAula = entrada.IdAula,
                CantidadHoras = entrada.CantidadHoras,
                FechaHoraInicio = entrada.FechaHoraInicio
            };
        }

        public override IEnumerable<ClaseDbModel> MapearTipo2Tipo1(IEnumerable<ClaseDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}