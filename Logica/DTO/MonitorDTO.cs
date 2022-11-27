using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DTO
{
    public class MonitorDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idPersona;

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        private int idPrograma;

        public int IdPrograma
        {
            get { return idPrograma; }
            set { idPrograma = value; }
        }
        private int idMateria;

        public int IdMateria
        {
            get { return idMateria; }
            set { idMateria = value; }
        }

        private string codigoEstudiante;

        public string CodigoEstudiante
        {
            get { return codigoEstudiante; }
            set { codigoEstudiante = value; }
        }

    }
}
