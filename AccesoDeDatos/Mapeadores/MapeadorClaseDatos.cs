using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorClaseDatos : MapeadorBaseDatos<tb_clase, ClaseDbModel>
    {
        public override ClaseDbModel MapearTipo1Tipo2(tb_clase entrada)
        {
            return new ClaseDbModel()
            {
                Id = entrada.id,
                IdProfesor = (int)entrada.id_profesor,
                IdMateria = entrada.id_materia,
                IdAula = (int)entrada.id_aula, 
                CantidadHoras = entrada.cantidad_horas,
                FechaHoraInicio=entrada.fecha_hora_inicio,
                NombreAula=entrada.tb_aula.nombre,
                NombreProfesor=entrada.tb_profesor.tb_persona.primer_nombre+ " "+ entrada.tb_profesor.tb_persona.otros_nombres+" "+entrada.tb_profesor.tb_persona.primer_apellido
                
                
            };
        }

        public override IEnumerable<ClaseDbModel> MapearTipo1Tipo2(IEnumerable<tb_clase> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_clase MapearTipo2Tipo1(ClaseDbModel entrada)
        {
            return new tb_clase()
            {
                id = entrada.Id,
                id_profesor = (int)entrada.IdProfesor,
                id_materia = entrada.IdMateria,
                id_aula = entrada.IdAula,
                cantidad_horas = entrada.CantidadHoras,
                fecha_hora_inicio = entrada.FechaHoraInicio
            };
        }

        public override IEnumerable<tb_clase> MapearTipo2Tipo1(IEnumerable<ClaseDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}