using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionProgramasFacultad.Mapeadores
{
    public class MapeadorProgramaGUI : MapeadorBaseGUI<ProgramaDTO, ModeloProgramaGUI>
    {
        public override ModeloProgramaGUI MapearTipo1Tipo2(ProgramaDTO entrada)
        {
            return new ModeloProgramaGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<ModeloProgramaGUI> MapearTipo1Tipo2(IEnumerable<ProgramaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProgramaDTO MapearTipo2Tipo1(ModeloProgramaGUI entrada)
        {
            return new ProgramaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<ProgramaDTO> MapearTipo2Tipo1(IEnumerable<ModeloProgramaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}