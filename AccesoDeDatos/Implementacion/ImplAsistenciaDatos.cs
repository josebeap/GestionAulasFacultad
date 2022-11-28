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
    public class ImplAsistenciaDatos
    {
        /// <summary>
        /// Método para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<AsistenciaDbModel> ListarRegistros(String filtro, int paginaActual, int numRegistrosPorPagina, out int totalRegistros) 
        {
            var lista = new List<AsistenciaDbModel>();
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                int regDescartados = (paginaActual - 1) * numRegistrosPorPagina;
                ///var listaDatos = (from m in bd.tb_asistencia
                ///                  where m.id_profesor.Equals(from x in bd.tb_profesor 
                ///                                             where x.id_persona.Equals(from y in bd.tb_persona
                ///                                                                       where y.primer_nombre.Contains(filtro)
                ///                                                                      select y.id)
                ///                                             select x.id)
                ///                 select m).ToList();
                var listaDatos = (from m in bd.tb_asistencia select m).ToList();
                totalRegistros = listaDatos.Count();
                
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(regDescartados).Take(numRegistrosPorPagina).ToList();
                lista = new MapeadorAsistenciaDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }

        public IEnumerable<AsistenciaDbModel> ListarRegistros()
        {
            var lista = new List<AsistenciaDbModel>();
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                var listaDatos = (from m in bd.tb_asistencia

                                  select m).ToList();

                lista = new MapeadorAsistenciaDatos().MapearTipo1Tipo2(listaDatos).ToList();

            }
            return lista;
        }

        
        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(AsistenciaDbModel registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    
                    var reg = new MapeadorAsistenciaDatos().MapearTipo2Tipo1(registro);
                    bd.tb_asistencia.Add(reg);
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
        public AsistenciaDbModel BuscarRegistro(int id)
        {
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                tb_asistencia registro = bd.tb_asistencia.Find(id);
                return new MapeadorAsistenciaDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(AsistenciaDbModel registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_asistencia.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    tb_asistencia reg = new MapeadorAsistenciaDatos().MapearTipo2Tipo1(registro);
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
                    tb_asistencia registro = bd.tb_asistencia.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    bd.tb_asistencia.Remove(registro);
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

