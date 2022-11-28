using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DTO
{
    public class AuxiliarDTO
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

        private string funcion;

        public string Funcion
        {
            get { return funcion; }
            set { funcion = value; }
        }

        private string nombrePersona;

        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }


    }
}

