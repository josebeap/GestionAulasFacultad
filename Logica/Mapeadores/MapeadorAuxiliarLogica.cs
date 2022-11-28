
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorAuxiliarLogica : MapeadorBaseLogica<AuxiliarDbModel, AuxiliarDTO>
    {
        public override AuxiliarDTO MapearTipo1Tipo2(AuxiliarDbModel entrada)
        {
            return new AuxiliarDTO()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                NombrePersona = entrada.NombrePersona,
                Funcion = entrada.Funcion

            };
        }

        public override IEnumerable<AuxiliarDTO> MapearTipo1Tipo2(IEnumerable<AuxiliarDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override AuxiliarDbModel MapearTipo2Tipo1(AuxiliarDTO entrada)
        {
            return new AuxiliarDbModel()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                Funcion = entrada.Funcion
            };
        }

        public override IEnumerable<AuxiliarDbModel> MapearTipo2Tipo1(IEnumerable<AuxiliarDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}