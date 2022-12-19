using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorProfesorDatos : MapeadorBaseDatos<tb_profesor, ProfesorDbModel>
    {
        public override ProfesorDbModel MapearTipo1Tipo2(tb_profesor entrada)
        {
            return new ProfesorDbModel()
            {
                Id = entrada.id,
                IdPersona=entrada.id_persona,
                IdPrograma=entrada.id_programa,
                NombrePersona = entrada.tb_persona.primer_nombre + " " + entrada.tb_persona.otros_nombres + " " + entrada.tb_persona.primer_apellido,
                NombrePrograma =entrada.tb_programa.nombre
                
            };
        }

        public override IEnumerable<ProfesorDbModel> MapearTipo1Tipo2(IEnumerable<tb_profesor> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_profesor MapearTipo2Tipo1(ProfesorDbModel entrada)
        {
            return new tb_profesor()
            {
                id = entrada.Id,
                id_persona=entrada.IdPersona,
                id_programa=entrada.IdPrograma
            };
        }

        public override IEnumerable<tb_profesor> MapearTipo2Tipo1(IEnumerable<ProfesorDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}