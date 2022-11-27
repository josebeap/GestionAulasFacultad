using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DTO
{
    public class AulaDTO
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

        private string tipoAula;

        public string TipoAula
        {
            get { return tipoAula; }
            set { tipoAula = value; }
        }

        private int capacidad;

        public int Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }

        private int cantidadComputadores;

        public int CantidadComputadores
        {
            get { return cantidadComputadores; }
            set { cantidadComputadores = value; }
        }

        private bool multimedia;

        public bool Multimedia
        {
            get { return multimedia; }
            set { multimedia = value; }
        }

        private bool disponibilidad;

        public bool Disponibilidad
        {
            get { return disponibilidad; }
            set { disponibilidad = value; }
        }


    }
}
