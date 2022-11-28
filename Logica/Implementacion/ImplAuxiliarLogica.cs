
using AccesoDeDatos.DbModel;
using AccesoDeDatos.Implementacion;
using Logica.DTO;
using Logica.Mapeadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Implementacion
{
    public class ImplAuxiliarLogica
    {
        private ImplAuxiliarDatos accesoDatos;
        public ImplAuxiliarLogica()
        {
            this.accesoDatos = new ImplAuxiliarDatos();
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="filtro">filtro de búsqueda</param>
        /// <param name="numPagina">página actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a mostrar por página</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincida con el filtro</returns>
        public IEnumerable<AuxiliarDTO> ListarRegistros(String filtro, int numPagina, int registrosPorPagina, out int totalRegistros)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorAuxiliarLogica mapeador = new MapeadorAuxiliarLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }
        // esto va en producto
        public IEnumerable<AuxiliarDTO> ListarRegistros()
        {
            var listado = this.accesoDatos.ListarRegistros();
            MapeadorAuxiliarLogica mapeador = new MapeadorAuxiliarLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AuxiliarDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorAuxiliarLogica mapeador = new MapeadorAuxiliarLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean EditarRegistro(AuxiliarDTO registro)
        {
            MapeadorAuxiliarLogica mapeador = new MapeadorAuxiliarLogica();
            AuxiliarDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean GuardarRegistro(AuxiliarDTO registro)
        {
            MapeadorAuxiliarLogica mapeador = new MapeadorAuxiliarLogica();
            AuxiliarDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }
    }
}
