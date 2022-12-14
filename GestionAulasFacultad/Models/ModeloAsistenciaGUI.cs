using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloAsistenciaGUI
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

        private string nombreMonitor;
        [DisplayName("Monitor")]
        public string NombreMonitor
        {
            get { return nombreMonitor; }
            set { nombreMonitor = value; }
        }


        private int idProfesor;

        public int IdProfesor
        {
            get { return idProfesor; }
            set { idProfesor = value; }
        }
        
        private string nombreProfesor;
        [DisplayName("Profesor")]
        public string NombreProfesor
        {
            get { return nombreProfesor; }
            set { nombreProfesor = value; }
        }


        private int idAula;

        public int IdAula
        {
            get { return idAula; }
            set { idAula = value; }
        }
        
        private string nombreAula;
        [DisplayName("Aula")]
        public string NombreAula
        {
            get { return nombreAula; }
            set { nombreAula = value; }
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
