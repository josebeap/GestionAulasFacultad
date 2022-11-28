using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionMonitorsFacultad.Mapeadores
{
    public class MapeadorMonitorGUI : MapeadorBaseGUI<MonitorDTO, ModeloMonitorGUI>
    {
        public override ModeloMonitorGUI MapearTipo1Tipo2(MonitorDTO entrada)
        {
            return new ModeloMonitorGUI()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                IdPrograma = entrada.IdPrograma,
                IdMateria = entrada.IdMateria,
                CodigoEstudiante = entrada.CodigoEstudiante,
                NombrePrograma = entrada.NombrePrograma,
                NombreMateria = entrada.NombreMateria,
                NombrePersona = entrada.NombrePersona
            };
        }

        public override IEnumerable<ModeloMonitorGUI> MapearTipo1Tipo2(IEnumerable<MonitorDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override MonitorDTO MapearTipo2Tipo1(ModeloMonitorGUI entrada)
        {
            return new MonitorDTO()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                IdPrograma = entrada.IdPrograma,
                IdMateria = entrada.IdMateria,
                CodigoEstudiante = entrada.CodigoEstudiante
            };
        }

        public override IEnumerable<MonitorDTO> MapearTipo2Tipo1(IEnumerable<ModeloMonitorGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}