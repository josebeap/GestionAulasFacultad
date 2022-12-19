using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel
{
    public class MonitorDbModel
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

        private string nombreMateria;

        public string NombreMateria
        {
            get { return nombreMateria; }
            set { nombreMateria = value; }
        }

        private string nombrePrograma;

        public string NombrePrograma
        {
            get { return nombrePrograma; }
            set { nombrePrograma = value; }
        }

        private string nombrePersona;

        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }

    }
}
