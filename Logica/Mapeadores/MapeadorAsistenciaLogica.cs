
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorAsistenciaLogica : MapeadorBaseLogica<AsistenciaDbModel, AsistenciaDTO>
    {
        public override AsistenciaDTO MapearTipo1Tipo2(AsistenciaDbModel entrada)
        {
            return new AsistenciaDTO()
            {
                Id = entrada.Id,
                IdMonitor = entrada.IdMonitor,
                IdAula = entrada.IdAula,
                IdProfesor = entrada.IdProfesor,
                FechaHoraInicio = entrada.FechaHoraInicio,
                FechaHoraFin = entrada.FechaHoraFin,
                Estado = entrada.Estado

            };
        }

        public override IEnumerable<AsistenciaDTO> MapearTipo1Tipo2(IEnumerable<AsistenciaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override AsistenciaDbModel MapearTipo2Tipo1(AsistenciaDTO entrada)
        {
            return new AsistenciaDbModel()
            {
                Id = entrada.Id,
                IdMonitor = entrada.IdMonitor,
                IdAula = entrada.IdAula,
                IdProfesor = entrada.IdProfesor,
                FechaHoraInicio = entrada.FechaHoraInicio,
                FechaHoraFin = entrada.FechaHoraFin,
                Estado = entrada.Estado
            };
        }

        public override IEnumerable<AsistenciaDbModel> MapearTipo2Tipo1(IEnumerable<AsistenciaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}