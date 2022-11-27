using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel
{
    public class ProfesorDbModel
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
        

    }
}

