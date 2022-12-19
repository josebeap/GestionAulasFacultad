using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloClaseGUI
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

        private string nombreAula;
        [DisplayName("Aula")]
        public string NombreAula
        {
            get { return nombreAula; }
            set { nombreAula = value; }
        }

        private string nombreProfesor;
        [DisplayName("Profesor")]
        public string NombreProfesor
        {
            get { return nombreProfesor; }
            set { nombreProfesor = value; }
        }

        private string nombreMateria;
        [DisplayName("Materia")]
        public string NombreMateria
        {
            get { return nombreMateria; }
            set { nombreMateria = value; }
        }

        private IEnumerable<ModeloAulaGUI> modeloAulaGUIs;

        public IEnumerable<ModeloAulaGUI> ListaAulas
        {
            get { return modeloAulaGUIs; }
            set { modeloAulaGUIs = value; }
        }

        private IEnumerable<ModeloProfesorGUI> modeloProfesorGUIs;

        public IEnumerable<ModeloProfesorGUI> ListaProfesores
        {
            get { return modeloProfesorGUIs; }
            set { modeloProfesorGUIs = value; }
        }

        private IEnumerable<ModeloMateriaGUI> modeloMateriaGUIs;

        public IEnumerable<ModeloMateriaGUI> ListaMaterias
        {
            get { return modeloMateriaGUIs; }
            set { modeloMateriaGUIs = value; }
        }
    }
}
