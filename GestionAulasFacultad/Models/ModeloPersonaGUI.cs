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

        public string OtrosNombres
        {
            get { return otrosNombres; }
            set { otrosNombres = value; }
        }
        private string primerApellido;

        public string PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }
        private string segundoApellido;

        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }
        private string documentoIdentidad;

        public string DocumentoIdentidad
        {
            get { return documentoIdentidad; }
            set { documentoIdentidad = value; }
        }
        private string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string foto;

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        private byte[] huella;

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

