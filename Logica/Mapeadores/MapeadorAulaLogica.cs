
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorAulaLogica : MapeadorBaseLogica<AulaDbModel, AulaDTO>
    {
        public override AulaDTO MapearTipo1Tipo2(AulaDbModel entrada)
        {
            return new AulaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                TipoAula = entrada.TipoAula,
                Capacidad = entrada.Capacidad,
                CantidadComputadores = entrada.CantidadComputadores,
                Multimedia = entrada.Multimedia,
                Disponibilidad = entrada.Disponibilidad

            };
        }

        public override IEnumerable<AulaDTO> MapearTipo1Tipo2(IEnumerable<AulaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override AulaDbModel MapearTipo2Tipo1(AulaDTO entrada)
        {
            return new AulaDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                TipoAula = entrada.TipoAula,
                Capacidad = entrada.Capacidad,
                CantidadComputadores = entrada.CantidadComputadores,
                Multimedia = entrada.Multimedia,
                Disponibilidad = entrada.Disponibilidad
            };
        }

        public override IEnumerable<AulaDbModel> MapearTipo2Tipo1(IEnumerable<AulaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}