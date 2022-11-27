
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorPersonaLogica : MapeadorBaseLogica<PersonaDbModel, PersonaDTO>
    {
        public override PersonaDTO MapearTipo1Tipo2(PersonaDbModel entrada)
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

        public override IEnumerable<PersonaDTO> MapearTipo1Tipo2(IEnumerable<PersonaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PersonaDbModel MapearTipo2Tipo1(PersonaDTO entrada)
        {
            return new PersonaDbModel()
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

        public override IEnumerable<PersonaDbModel> MapearTipo2Tipo1(IEnumerable<PersonaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}