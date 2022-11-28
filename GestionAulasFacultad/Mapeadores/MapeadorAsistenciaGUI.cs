
using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionAsistenciasFacultad.Mapeadores
{
    public class MapeadorAsistenciaGUI : MapeadorBaseGUI<AsistenciaDTO, ModeloAsistenciaGUI>
    {
        public override ModeloAsistenciaGUI MapearTipo1Tipo2(AsistenciaDTO entrada)
        {
            return new ModeloAsistenciaGUI()
            {
                Id = entrada.Id,
                IdMonitor = entrada.IdMonitor,
                IdAula = entrada.IdAula,
                IdProfesor = entrada.IdProfesor,
                FechaHoraInicio = entrada.FechaHoraInicio,
                FechaHoraFin = entrada.FechaHoraFin,
                Estado = entrada.Estado,
                NombreProfesor = entrada.NombreProfesor,
                NombreMonitor = entrada.NombreMonitor, 
                NombreAula = entrada.NombreAula
            };
        }

        public override IEnumerable<ModeloAsistenciaGUI> MapearTipo1Tipo2(IEnumerable<AsistenciaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override AsistenciaDTO MapearTipo2Tipo1(ModeloAsistenciaGUI entrada)
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

        public override IEnumerable<AsistenciaDTO> MapearTipo2Tipo1(IEnumerable<ModeloAsistenciaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}