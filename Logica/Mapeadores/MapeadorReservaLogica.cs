
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorReservaLogica : MapeadorBaseLogica<ReservaDbModel, ReservaDTO>
    {
        public override ReservaDTO MapearTipo1Tipo2(ReservaDbModel entrada)
        {
            return new ReservaDTO()
            {
                Id = entrada.Id,
                IdMonitor = entrada.IdMonitor,
                IdProfesor = entrada.IdProfesor,
                IdAula = entrada.IdAula,
                CantidadHoras = entrada.CantidadHoras,
                FechaHoraInicio = entrada.FechaHoraInicio,
                Estado = entrada.Estado

            };
        }

        public override IEnumerable<ReservaDTO> MapearTipo1Tipo2(IEnumerable<ReservaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ReservaDbModel MapearTipo2Tipo1(ReservaDTO entrada)
        {
            return new ReservaDbModel()
            {
                Id = entrada.Id,
                IdMonitor = entrada.IdMonitor,
                IdProfesor = entrada.IdProfesor,
                IdAula = entrada.IdAula,
                CantidadHoras = entrada.CantidadHoras,
                FechaHoraInicio = entrada.FechaHoraInicio,
                Estado = entrada.Estado
            };
        }

        public override IEnumerable<ReservaDbModel> MapearTipo2Tipo1(IEnumerable<ReservaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}