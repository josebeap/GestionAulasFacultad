using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionProfesorsFacultad.Mapeadores
{
    public class MapeadorProfesorGUI : MapeadorBaseGUI<ProfesorDTO, ModeloProfesorGUI>
    {
        public override ModeloProfesorGUI MapearTipo1Tipo2(ProfesorDTO entrada)
        {
            return new ModeloProfesorGUI()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                IdPrograma = entrada.IdPrograma,
                NombrePrograma = entrada.NombrePrograma,
                NombrePersona = entrada.NombrePersona
            };
        }

        public override IEnumerable<ModeloProfesorGUI> MapearTipo1Tipo2(IEnumerable<ProfesorDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProfesorDTO MapearTipo2Tipo1(ModeloProfesorGUI entrada)
        {
            return new ProfesorDTO()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                IdPrograma = entrada.IdPrograma
            };
        }

        public override IEnumerable<ProfesorDTO> MapearTipo2Tipo1(IEnumerable<ModeloProfesorGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}