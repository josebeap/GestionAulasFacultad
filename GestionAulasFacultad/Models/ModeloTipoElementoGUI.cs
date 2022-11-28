using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloTipoElementoGUI
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
        private string nombreTipoElemento;

        public string NombreTipoElemento
        {
            get { return nombreTipoElemento; }
            set { nombreTipoElemento = value; }
        }
    }
}
