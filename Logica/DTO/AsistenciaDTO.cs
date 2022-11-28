using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DTO
{
    public class AsistenciaDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idMonitor;

        public int IdMonitor
        {
            get { return idMonitor; }
            set { idMonitor = value; }
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

        private DateTime fechaHoraInicio;

        public DateTime FechaHoraInicio
        {
            get { return fechaHoraInicio; }
            set { fechaHoraInicio = value; }
        }

        private DateTime fechaHoraFin;

        public DateTime FechaHoraFin
        {
            get { return fechaHoraFin; }
            set { fechaHoraFin = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string nombreMonitor;

        public string NombreMonitor
        {
            get { return nombreMonitor; }
            set { nombreMonitor = value; }
        }

        private string nombreProfesor;

        public string NombreProfesor
        {
            get { return nombreProfesor; }
            set { nombreProfesor = value; }
        }

        private string nombreAula;

        public string NombreAula
        {
            get { return nombreAula; }
            set { nombreAula = value; }
        }
    }
}
