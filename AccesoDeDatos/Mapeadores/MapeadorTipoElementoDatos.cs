using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorTipoElementoDatos : MapeadorBaseDatos<tb_tipoelemento, TipoElementoDbModel>
    {
        public override TipoElementoDbModel MapearTipo1Tipo2(tb_tipoelemento entrada)
        {
            return new TipoElementoDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre
            };
        }

        public override IEnumerable<TipoElementoDbModel> MapearTipo1Tipo2(IEnumerable<tb_tipoelemento> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_tipoelemento MapearTipo2Tipo1(TipoElementoDbModel entrada)
        {
            return new tb_tipoelemento()
            {
                id = entrada.Id,
                nombre = entrada.Nombre
            };
        }

        public override IEnumerable<tb_tipoelemento> MapearTipo2Tipo1(IEnumerable<TipoElementoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}