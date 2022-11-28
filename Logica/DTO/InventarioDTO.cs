using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.DTO
{
    public class InventarioDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string codigoIdentificacion;

        public string CodigoIdentificacion
        {
            get { return codigoIdentificacion; }
            set { codigoIdentificacion = value; }
        }
        private int idTipoElemento;

        public int IdTipoElemento
        {
            get { return idTipoElemento; }
            set { idTipoElemento = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string nombreTipoElemento;

        public string NombreTipoElemento
        {
            get { return nombreTipoElemento; }
            set { nombreTipoElemento = value; }
        }

    }
}

