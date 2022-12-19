using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionReservasFacultad.Mapeadores
{
    public class MapeadorReservaGUI : MapeadorBaseGUI<ReservaDTO, ModeloReservaGUI>
    {
        public override ModeloReservaGUI MapearTipo1Tipo2(ReservaDTO entrada)
        {
            return new ModeloReservaGUI()
            {
                Id = entrada.Id,
                IdMonitor = entrada.IdMonitor,
                IdProfesor = entrada.IdProfesor,
                IdAula = entrada.IdAula,
                CantidadHoras = entrada.CantidadHoras,
                FechaHoraInicio = entrada.FechaHoraInicio,
                Estado = entrada.Estado,
                NombreProfesor = entrada.NombreProfesor,
                NombreAula = entrada.NombreAula,
                NombreMonitor = entrada.NombreMonitor
            };
        }

        public override IEnumerable<ModeloReservaGUI> MapearTipo1Tipo2(IEnumerable<ReservaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ReservaDTO MapearTipo2Tipo1(ModeloReservaGUI entrada)
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

        public override IEnumerable<ReservaDTO> MapearTipo2Tipo1(IEnumerable<ModeloReservaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}