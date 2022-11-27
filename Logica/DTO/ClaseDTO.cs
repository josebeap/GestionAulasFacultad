using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DTO
{
    public class ClaseDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private int idProfesor;

        public int IdProfesor
        {
            get { return idProfesor; }
            set { idProfesor = value; }
        }

        private int idAula;

        public int IdAula
        {
            get { return idAula; }
            set { idAula = value; }
        }

        private int idMateria;

        public int IdMateria
        {
            get { return idMateria; }
            set { idMateria = value; }
        }

        private int cantidadHoras;

        public int CantidadHoras
        {
            get { return cantidadHoras; }
            set { cantidadHoras = value; }
        }
        private DateTime fechaHoraInicio;

        public DateTime FechaHoraInicio
        {
            get { return fechaHoraInicio; }
            set { fechaHoraInicio = value; }
        }


    }
}
