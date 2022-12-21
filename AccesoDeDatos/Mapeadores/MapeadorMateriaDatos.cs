using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorMateriaDatos : MapeadorBaseDatos<tb_materia, MateriaDbModel>
    {
        public override MateriaDbModel MapearTipo1Tipo2(tb_materia entrada)
        {
            return new MateriaDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                IdPrograma=entrada.id_programa,
                NombrePrograma=entrada.tb_programa.nombre
            };
        }

        public override IEnumerable<MateriaDbModel> MapearTipo1Tipo2(IEnumerable<tb_materia> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_materia MapearTipo2Tipo1(MateriaDbModel entrada)
        {
            return new tb_materia()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                id_programa=entrada.IdPrograma
            };
        }

        public override IEnumerable<tb_materia> MapearTipo2Tipo1(IEnumerable<MateriaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}