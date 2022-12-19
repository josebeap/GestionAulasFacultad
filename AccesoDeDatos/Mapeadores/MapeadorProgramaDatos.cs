using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorProgramaDatos : MapeadorBaseDatos<tb_programa, ProgramaDbModel>
    {
        public override ProgramaDbModel MapearTipo1Tipo2(tb_programa entrada)
        {
            return new ProgramaDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre
            };
        }

        public override IEnumerable<ProgramaDbModel> MapearTipo1Tipo2(IEnumerable<tb_programa> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_programa MapearTipo2Tipo1(ProgramaDbModel entrada)
        {
            return new tb_programa()
            {
                id = entrada.Id,
                nombre = entrada.Nombre
            };
        }

        public override IEnumerable<tb_programa> MapearTipo2Tipo1(IEnumerable<ProgramaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}