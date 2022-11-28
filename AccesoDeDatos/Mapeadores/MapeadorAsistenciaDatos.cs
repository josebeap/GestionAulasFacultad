using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorAsistenciaDatos : MapeadorBaseDatos<tb_asistencia, AsistenciaDbModel>
    {
        public override AsistenciaDbModel MapearTipo1Tipo2(tb_asistencia entrada)
        {
            return new AsistenciaDbModel()
            {
                Id = entrada.id,
                IdMonitor=(int)entrada.id_monitor,
                IdAula=(int)entrada.id_aula,
                IdProfesor=(int)entrada.id_profesor,
                FechaHoraInicio=(DateTime)entrada.fecha_hora_inicio,
                FechaHoraFin=(DateTime)entrada.fecha_hora_fin,
                Estado=entrada.estado,
                NombreAula=entrada.tb_aula.nombre,
                NombreMonitor=entrada.tb_monitor.tb_persona.primer_nombre+ entrada.tb_monitor.tb_persona.primer_apellido,
                NombreProfesor = entrada.tb_monitor.tb_persona.primer_nombre + entrada.tb_monitor.tb_persona.primer_apellido
            };
        }

        public override IEnumerable<AsistenciaDbModel> MapearTipo1Tipo2(IEnumerable<tb_asistencia> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_asistencia MapearTipo2Tipo1(AsistenciaDbModel entrada)
        {
            return new tb_asistencia()
            {
                id = entrada.Id,
                id_monitor = entrada.IdMonitor,
                id_aula = entrada.IdAula,
                id_profesor = entrada.IdProfesor,
                fecha_hora_inicio = entrada.FechaHoraInicio,
                fecha_hora_fin = entrada.FechaHoraFin,
                estado = entrada.Estado,
               
            };
        }

        public override IEnumerable<tb_asistencia> MapearTipo2Tipo1(IEnumerable<AsistenciaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}