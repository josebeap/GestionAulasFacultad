
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
    public class ImplTipoElementoLogica
    {
        private ImplTipoElementoDatos accesoDatos;
        public ImplTipoElementoLogica()
        {
            this.accesoDatos = new ImplTipoElementoDatos();
        }

        /// <summary>
        /// Listar registros
        /// </summary>
        /// <param name="filtro">filtro de búsqueda</param>
        /// <param name="numPagina">página actual</param>
        /// <param name="registrosPorPagina">Cantidad de registros a mostrar por página</param>
        /// <param name="totalRegistros">Total de registros en base de datos</param>
        /// <returns>Listado de registros para mostrar en la página actual que coincida con el filtro</returns>
        public IEnumerable<TipoElementoDTO> ListarRegistros(String filtro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro);
            MapeadorTipoElementoLogica mapeador = new MapeadorTipoElementoLogica();
            return mapeador.MapearTipo1Tipo2(listado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TipoElementoDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorTipoElementoLogica mapeador = new MapeadorTipoElementoLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean EditarRegistro(TipoElementoDTO registro)
        {
            MapeadorTipoElementoLogica mapeador = new MapeadorTipoElementoLogica();
            TipoElementoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean GuardarRegistro(TipoElementoDTO registro)
        {
            MapeadorTipoElementoLogica mapeador = new MapeadorTipoElementoLogica();
            TipoElementoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
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
