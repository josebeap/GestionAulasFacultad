using AccesoDeDatos.DbModel;
using AccesoDeDatos.Mapeadores;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion
{
    public class ImplAuxiliarDatos
    {
        /// <summary>
        /// Método para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<AuxiliarDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros)
        {
            var lista = new List<AuxiliarDbModel>();
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                //var listaDatos = (from m in bd.tb_auxiliar
                 //                 where m.id_persona.Equals(from x in bd.tb_persona where x.primer_nombre.Contains(filtro) select x.id)
                   //               select m).ToList();
                var listaDatos = (from m in bd.tb_auxiliar select m).ToList();
                totalRegistros = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorAuxiliarDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }

        public IEnumerable<AuxiliarDbModel> ListarRegistros()
        {
            var lista = new List<AuxiliarDbModel>();
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                var listaDatos = (from m in bd.tb_auxiliar

                                  select m).ToList();

                lista = new MapeadorAuxiliarDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(AuxiliarDbModel registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_auxiliar.Where(x => x.id_persona.Equals(registro.IdPersona)).Count() > 0)
                    {
                        return false;
                    }
                    var reg = new MapeadorAuxiliarDatos().MapearTipo2Tipo1(registro);
                    bd.tb_auxiliar.Add(reg);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método de búsqueda de un registro
        /// </summary>
        /// <param name="id">id del registro a buscar</param>
        /// <returns>el objeto con el id buscado o null cuando no exista</returns>
        public AuxiliarDbModel BuscarRegistro(int id)
        {
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                tb_auxiliar registro = bd.tb_auxiliar.Find(id);
                return new MapeadorAuxiliarDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(AuxiliarDbModel registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_auxiliar.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    tb_auxiliar reg = new MapeadorAuxiliarDatos().MapearTipo2Tipo1(registro);
                    bd.Entry(reg).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método de eliminar un registro por el id
        /// </summary>
        /// <param name="id">id del registro a eliminar</param>
        /// <returns>true cuando se elimina, false cuando no existe el registro o una excepción</returns>
        public bool EliminarRegistro(int id)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    tb_auxiliar registro = bd.tb_auxiliar.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    bd.tb_auxiliar.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

