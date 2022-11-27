
using AccesoDeDatos.DbModel;
using Logica.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logica.Mapeadores
{
    public class MapeadorMonitorLogica : MapeadorBaseLogica<MonitorDbModel, MonitorDTO>
    {
        public override MonitorDTO MapearTipo1Tipo2(MonitorDbModel entrada)
        {
            return new MonitorDTO()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                IdPrograma = entrada.IdPrograma,
                IdMateria = entrada.IdMateria,
                CodigoEstudiante = entrada.CodigoEstudiante

            };
        }

        public override IEnumerable<MonitorDTO> MapearTipo1Tipo2(IEnumerable<MonitorDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override MonitorDbModel MapearTipo2Tipo1(MonitorDTO entrada)
        {
            return new MonitorDbModel()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                IdPrograma = entrada.IdPrograma,
                IdMateria = entrada.IdMateria,
                CodigoEstudiante = entrada.CodigoEstudiante
            };
        }

        public override IEnumerable<MonitorDbModel> MapearTipo2Tipo1(IEnumerable<MonitorDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}