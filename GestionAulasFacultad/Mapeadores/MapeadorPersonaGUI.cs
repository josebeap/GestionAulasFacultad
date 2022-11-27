using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionPersonasFacultad.Mapeadores
{
    public class MapeadorPersonaGUI : MapeadorBaseGUI<PersonaDTO, ModeloPersonaGUI>
    {
        public override ModeloPersonaGUI MapearTipo1Tipo2(PersonaDTO entrada)
        {
            return new ModeloPersonaGUI()
            {
                Id = entrada.Id,
                PrimerNombre = entrada.PrimerNombre,
                OtrosNombres = entrada.OtrosNombres,
                PrimerApellido = entrada.PrimerApellido,
                SegundoApellido = entrada.SegundoApellido,
                DocumentoIdentidad = entrada.DocumentoIdentidad,
                Celular = entrada.Celular,
                Email = entrada.Email,
                Foto = entrada.Foto,
                Huella = entrada.Huella
            };
        }

        public override IEnumerable<ModeloPersonaGUI> MapearTipo1Tipo2(IEnumerable<PersonaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PersonaDTO MapearTipo2Tipo1(ModeloPersonaGUI entrada)
        {
            return new PersonaDTO()
            {
                Id = entrada.Id,
                PrimerNombre = entrada.PrimerNombre,
                OtrosNombres = entrada.OtrosNombres,
                PrimerApellido = entrada.PrimerApellido,
                SegundoApellido = entrada.SegundoApellido,
                DocumentoIdentidad = entrada.DocumentoIdentidad,
                Celular = entrada.Celular,
                Email = entrada.Email,
                Foto = entrada.Foto,
                Huella = entrada.Huella
            };
        }

        public override IEnumerable<PersonaDTO> MapearTipo2Tipo1(IEnumerable<ModeloPersonaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}