using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorInventarioDatos : MapeadorBaseDatos<tb_inventario, InventarioDbModel>
    {
        public override InventarioDbModel MapearTipo1Tipo2(tb_inventario entrada)
        {
            return new InventarioDbModel()
            {
                Id = entrada.id,
                CodigoIdentificacion=entrada.codigo_identificacion,
                IdTipoElemento=entrada.id_tipoelemento,
                Estado=entrada.estado
            };
        }

        public override IEnumerable<InventarioDbModel> MapearTipo1Tipo2(IEnumerable<tb_inventario> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_inventario MapearTipo2Tipo1(InventarioDbModel entrada)
        {
            return new tb_inventario()
            {
                id = entrada.Id,
                codigo_identificacion = entrada.CodigoIdentificacion,
                id_tipoelemento = entrada.IdTipoElemento,
                estado = entrada.Estado
            };
        }

        public override IEnumerable<tb_inventario> MapearTipo2Tipo1(IEnumerable<InventarioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}