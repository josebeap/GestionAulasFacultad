using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionAulasFacultad.Mapeadores
{
    public class MapeadorAulaGUI : MapeadorBaseGUI<AulaDTO, ModeloAulaGUI>
    {
        public override ModeloAulaGUI MapearTipo1Tipo2(AulaDTO entrada)
        {
            return new ModeloAulaGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                TipoAula = entrada.TipoAula,
                Capacidad = entrada.Capacidad,
                CantidadComputadores = entrada.CantidadComputadores,
                Multimedia = entrada.Multimedia,
                Disponibilidad = entrada.Disponibilidad
            };
        }

        public override IEnumerable<ModeloAulaGUI> MapearTipo1Tipo2(IEnumerable<AulaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override AulaDTO MapearTipo2Tipo1(ModeloAulaGUI entrada)
        {
            return new AulaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                TipoAula = entrada.TipoAula,
                Capacidad = entrada.Capacidad,
                CantidadComputadores = entrada.CantidadComputadores,
                Multimedia = entrada.Multimedia,
                Disponibilidad = entrada.Disponibilidad
            };
        }

        public override IEnumerable<AulaDTO> MapearTipo2Tipo1(IEnumerable<ModeloAulaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}