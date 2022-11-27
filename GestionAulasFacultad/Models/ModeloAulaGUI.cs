using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloAulaGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;
        [Required]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [Required]
        private string tipoAula;

        public string TipoAula
        {
            get { return tipoAula; }
            set { tipoAula = value; }
        }
        [Required]
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
        [Required]
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
