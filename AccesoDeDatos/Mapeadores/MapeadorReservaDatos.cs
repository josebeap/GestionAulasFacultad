using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorReservaDatos : MapeadorBaseDatos<tb_reserva, ReservaDbModel>
    {
        public override ReservaDbModel MapearTipo1Tipo2(tb_reserva entrada)
        {
            return new ReservaDbModel()
            {
                Id = entrada.id,
                IdMonitor = (int)entrada.id_monitor,
                IdProfesor = (int)entrada.id_profesor,
                IdAula = (int)entrada.id_aula,
                CantidadHoras = entrada.cantidad_horas,
                FechaHoraInicio=(DateTime)entrada.fecha_hora_inicio,
                Estado=entrada.estado,
                NombreMonitor = entrada.tb_monitor.tb_persona.primer_nombre + " " + entrada.tb_monitor.tb_persona.otros_nombres + " " + entrada.tb_monitor.tb_persona.primer_apellido,
                NombreProfesor = entrada.tb_profesor.tb_persona.primer_nombre + " " + entrada.tb_profesor.tb_persona.otros_nombres + " " + entrada.tb_profesor.tb_persona.primer_apellido,
                NombreAula =entrada.tb_aula.nombre

            };
        }

        public override IEnumerable<ReservaDbModel> MapearTipo1Tipo2(IEnumerable<tb_reserva> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_reserva MapearTipo2Tipo1(ReservaDbModel entrada)
        {
            return new tb_reserva()
            {
                id = entrada.Id,
                id_monitor = entrada.IdMonitor,
                id_profesor = entrada.IdProfesor,
                id_aula = entrada.IdAula,
                cantidad_horas = entrada.CantidadHoras,
                fecha_hora_inicio = entrada.FechaHoraInicio,
                estado = entrada.Estado
            };
        }

        public override IEnumerable<tb_reserva> MapearTipo2Tipo1(IEnumerable<ReservaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}