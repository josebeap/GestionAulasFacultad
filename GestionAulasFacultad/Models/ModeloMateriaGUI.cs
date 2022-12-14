using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloMateriaGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private int idPrograma;

        public int IdPrograma
        {
            get { return idPrograma; }
            set { idPrograma = value; }
        }

        private string nombrePrograma;
        [DisplayName("Programa")]
        public string NombrePrograma
        {
            get { return nombrePrograma; }
            set { nombrePrograma = value; }
        }

        private IEnumerable<ModeloProgramaGUI> modeloProgramaGUIs;

        public IEnumerable<ModeloProgramaGUI> ListaProgramas
        {
            get { return modeloProgramaGUIs; }
            set { modeloProgramaGUIs = value; }
        }
    }
}
