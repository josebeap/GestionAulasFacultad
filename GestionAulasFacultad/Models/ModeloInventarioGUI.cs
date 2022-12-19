using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAulasFacultad.Models
{
    public class ModeloInventarioGUI
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
        [DisplayName("Tipo Elemento")]
        public string NombreTipoElemento
        {
            get { return nombreTipoElemento; }
            set { nombreTipoElemento = value; }
        }

        private IEnumerable<ModeloTipoElementoGUI> modeloTipoElementoGUIs;

        public IEnumerable<ModeloTipoElementoGUI> ListaTipoElementos
        {
            get { return modeloTipoElementoGUIs; }
            set { modeloTipoElementoGUIs = value; }
        }

    }
}

