using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorAulaDatos : MapeadorBaseDatos<tb_aula, AulaDbModel>
    {
        public override AulaDbModel MapearTipo1Tipo2(tb_aula entrada)
        {
            return new AulaDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                TipoAula = entrada.tipo_aula,
                Capacidad = entrada.capacidad,
                CantidadComputadores = (int)entrada.cantidad_computadores,
                Multimedia = entrada.multimedia,
                Disponibilidad = entrada.disponibilidad
            };
        }

        public override IEnumerable<AulaDbModel> MapearTipo1Tipo2(IEnumerable<tb_aula> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_aula MapearTipo2Tipo1(AulaDbModel entrada)
        {
            return new tb_aula()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                tipo_aula = entrada.TipoAula,
                capacidad = entrada.Capacidad,
                cantidad_computadores = entrada.CantidadComputadores,
                multimedia = entrada.Multimedia,
                disponibilidad = entrada.Disponibilidad
            };
        }

        public override IEnumerable<tb_aula> MapearTipo2Tipo1(IEnumerable<AulaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}