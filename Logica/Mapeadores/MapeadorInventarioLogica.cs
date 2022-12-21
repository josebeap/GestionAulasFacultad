
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorInventarioLogica : MapeadorBaseLogica<InventarioDbModel, InventarioDTO>
    {
        public override InventarioDTO MapearTipo1Tipo2(InventarioDbModel entrada)
        {
            return new InventarioDTO()
            {
                Id = entrada.Id,
                CodigoIdentificacion = entrada.CodigoIdentificacion,
                IdTipoElemento = entrada.IdTipoElemento,
                Estado = entrada.Estado,
                NombreTipoElemento=entrada.NombreTipoElemento

            };
        }

        public override IEnumerable<InventarioDTO> MapearTipo1Tipo2(IEnumerable<InventarioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override InventarioDbModel MapearTipo2Tipo1(InventarioDTO entrada)
        {
            return new InventarioDbModel()
            {
                Id = entrada.Id,
                CodigoIdentificacion = entrada.CodigoIdentificacion,
                IdTipoElemento = entrada.IdTipoElemento,
                Estado = entrada.Estado
            };
        }

        public override IEnumerable<InventarioDbModel> MapearTipo2Tipo1(IEnumerable<InventarioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}