using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloMonitorGUI
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

        public int IdMateriaa
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
        private string nombrePersona;
        [DisplayName("Persona")]
        public string NombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }

        private string nombrePrograma;
        [DisplayName("Programa")]
        public string NombrePrograma
        {
            get { return nombrePrograma; }
            set { nombrePrograma = value; }
        }

        private string nombreMateria;
        [DisplayName("Materia")]
        public string NombreMateria
        {
            get { return nombreMateria; }
            set { nombreMateria = value; }
        }

        private IEnumerable<ModeloProgramaGUI> modeloProgramaGUIs;

        public IEnumerable<ModeloProgramaGUI> ListaProgramas
        {
            get { return modeloProgramaGUIs; }
            set { modeloProgramaGUIs = value; }
        }

        private IEnumerable<ModeloMateriaGUI> modeloMateriaGUIs;

        public IEnumerable<ModeloMateriaGUI> ListaMaterias
        {
            get { return modeloMateriaGUIs; }
            set { modeloMateriaGUIs = value; }
        }

        private IEnumerable<ModeloPersonaGUI> modeloPersonaGUIs;

        public IEnumerable<ModeloPersonaGUI> ListaPersonas
        {
            get { return modeloPersonaGUIs; }
            set { modeloPersonaGUIs = value; }
        }
    }
}
