using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using System.Collections.Generic;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorPersonaDatos : MapeadorBaseDatos<tb_persona, PersonaDbModel>
    {
        public override PersonaDbModel MapearTipo1Tipo2(tb_persona entrada)
        {
            return new PersonaDbModel()
            {
                Id = entrada.id,
                PrimerNombre = entrada.primer_nombre,
                OtrosNombres=entrada.otros_nombres,
                PrimerApellido=entrada.primer_apellido,
                SegundoApellido=entrada.segundo_apellido,
                DocumentoIdentidad=entrada.documentoIdentidad,
                Celular=entrada.celular,
                Email=entrada.email,
                Foto=entrada.foto,
                Huella=entrada.huella
            };
        }

        public override IEnumerable<PersonaDbModel> MapearTipo1Tipo2(IEnumerable<tb_persona> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_persona MapearTipo2Tipo1(PersonaDbModel entrada)
        {
            return new tb_persona()
            {
                id = entrada.Id,
                primer_nombre=entrada.PrimerNombre,
                otros_nombres=entrada.OtrosNombres,
                primer_apellido=entrada.PrimerApellido,
                segundo_apellido=entrada.SegundoApellido,
                documentoIdentidad=entrada.DocumentoIdentidad,
                celular = entrada.Celular,
                email = entrada.Email,
                foto = entrada.Foto,
                huella = entrada.Huella
            };
        }

        public override IEnumerable<tb_persona> MapearTipo2Tipo1(IEnumerable<PersonaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}