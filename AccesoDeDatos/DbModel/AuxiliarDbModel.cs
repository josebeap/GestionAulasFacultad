using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel
{
    public class AuxiliarDbModel
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

        private string nombrePersona;

        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }

        private string funcion;

        public string Funcion
        {
            get { return funcion; }
            set { funcion = value; }
        }


    }
}

