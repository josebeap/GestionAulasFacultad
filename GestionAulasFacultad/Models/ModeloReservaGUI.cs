using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloReservaGUI
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
        [DisplayName("Profesor")]
        public string NombreProfesor
        {
            get { return nombreProfesor; }
            set { nombreProfesor = value; }
        }
        private string nombreAula;
        [DisplayName("Aula")]
        public string NombreAula
        {
            get { return nombreAula; }
            set { nombreAula = value; }
        }

        private IEnumerable<ModeloProfesorGUI> modeloProfesorGUIs;

        public IEnumerable<ModeloProfesorGUI> ListaProfesores
        {
            get { return modeloProfesorGUIs; }
            set { modeloProfesorGUIs = value; }

        }

        private IEnumerable<ModeloMonitorGUI> modeloMonitorGUIs;

        public IEnumerable<ModeloMonitorGUI> ListaMonitores
        {
            get { return modeloMonitorGUIs; }
            set { modeloMonitorGUIs = value; }
        }

        private IEnumerable<ModeloAulaGUI> modeloAulaGUIs;

        public IEnumerable<ModeloAulaGUI> ListaAulas
        {
            get { return modeloAulaGUIs; }
            set { modeloAulaGUIs = value; }
        }
    }
}
