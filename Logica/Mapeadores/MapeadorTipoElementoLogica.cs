
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorTipoElementoLogica : MapeadorBaseLogica<TipoElementoDbModel, TipoElementoDTO>
    {
        public override TipoElementoDTO MapearTipo1Tipo2(TipoElementoDbModel entrada)
        {
            return new TipoElementoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre

            };
        }

        public override IEnumerable<TipoElementoDTO> MapearTipo1Tipo2(IEnumerable<TipoElementoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override TipoElementoDbModel MapearTipo2Tipo1(TipoElementoDTO entrada)
        {
            return new TipoElementoDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<TipoElementoDbModel> MapearTipo2Tipo1(IEnumerable<TipoElementoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}