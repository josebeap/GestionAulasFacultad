using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorMonitorDatos : MapeadorBaseDatos<tb_monitor, MonitorDbModel>
    {
        public override MonitorDbModel MapearTipo1Tipo2(tb_monitor entrada)
        {
            return new MonitorDbModel()
            {
                Id = entrada.id,
                IdPersona = entrada.id_persona,
                IdPrograma = entrada.id_programa,
                IdMateria = entrada.id_materia,
                CodigoEstudiante = entrada.codigo_estudiante,
                NombreMateria=entrada.tb_materia.nombre,
                NombrePrograma=entrada.tb_programa.nombre,
                NombrePersona=entrada.tb_persona.primer_nombre+entrada.tb_persona.primer_apellido

            };
        }

        public override IEnumerable<MonitorDbModel> MapearTipo1Tipo2(IEnumerable<tb_monitor> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_monitor MapearTipo2Tipo1(MonitorDbModel entrada)
        {
            return new tb_monitor()
            {
                id = entrada.Id,
                id_persona=entrada.IdPersona,
                id_programa=entrada.IdPrograma,
                id_materia=entrada.IdMateria,
                codigo_estudiante=entrada.CodigoEstudiante
            };
        }

        public override IEnumerable<tb_monitor> MapearTipo2Tipo1(IEnumerable<MonitorDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}