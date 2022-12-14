using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloPersonaGUI
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string primerNombre;
        [DisplayName("Primer nombre")]
        public string PrimerNombre
        {
            get { return primerNombre; }
            set { primerNombre = value; }
        }
        private string otrosNombres;
        [DisplayName("Otros nombres")]
        public string OtrosNombres
        {
            get { return otrosNombres; }
            set { otrosNombres = value; }
        }
        private string primerApellido;
        [DisplayName("Primer apellido")]
        public string PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }
        private string segundoApellido;
        [DisplayName("Segundo apellido")]
        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }
        private string documentoIdentidad;
        [DisplayName("Documento de identidad")]
        public string DocumentoIdentidad
        {
            get { return documentoIdentidad; }
            set { documentoIdentidad = value; }
        }
        private string celular;
        [DisplayName("Número de celular")]
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        private string email;
        [DisplayName("E-mail")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string foto;
        [DisplayName("Foto")]
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        private byte[] huella;
        [DisplayName("Huella")]
        public byte[] Huella
        {
            get { return huella; }
            set { huella = value; }
        }
        private string nombreCompleto;

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

    }
}

