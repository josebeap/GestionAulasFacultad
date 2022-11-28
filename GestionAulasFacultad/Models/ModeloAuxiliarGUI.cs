using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloAuxiliarGUI
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
        [DisplayName("Persona")]
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

        private IEnumerable<ModeloPersonaGUI> modeloPersonaGUIs;

        public IEnumerable<ModeloPersonaGUI> ListaPersonas
        {
            get { return modeloPersonaGUIs; }
            set { modeloPersonaGUIs = value; }
        }

    }
}

