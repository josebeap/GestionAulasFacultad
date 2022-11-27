using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionClasesFacultad.Mapeadores
{
    public class MapeadorClaseGUI : MapeadorBaseGUI<ClaseDTO, ModeloClaseGUI>
    {
        public override ModeloClaseGUI MapearTipo1Tipo2(ClaseDTO entrada)
        {
            return new ModeloClaseGUI()
            {
                Id = entrada.Id,
                IdProfesor = entrada.IdProfesor,
                IdMateria = entrada.IdMateria,
                IdAula = entrada.IdAula,
                CantidadHoras = entrada.CantidadHoras,
                FechaHoraInicio = entrada.FechaHoraInicio
            };
        }

        public override IEnumerable<ModeloClaseGUI> MapearTipo1Tipo2(IEnumerable<ClaseDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ClaseDTO MapearTipo2Tipo1(ModeloClaseGUI entrada)
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

        public override IEnumerable<ClaseDTO> MapearTipo2Tipo1(IEnumerable<ModeloClaseGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}