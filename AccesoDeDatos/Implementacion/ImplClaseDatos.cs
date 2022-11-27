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
    public class ImplClaseDatos
    {
        /// <summary>
        /// Método para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<ClaseDbModel> ListarRegistros(String filtro)
        {
            var lista = new List<tb_clase>();
            var listaMaterias = new List<tb_materia>();
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                listaMaterias = (
                    from c in bd.tb_materia
                    where c.nombre.Contains(filtro)
                    select c
                    ).ToList();

                foreach (var i in listaMaterias)
                {
                    lista.Add((tb_clase)bd.tb_clase.Where(x => x.id_materia.Equals(i.id)));
                }
            }

            return new MapeadorClaseDatos().MapearTipo1Tipo2(lista);
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(ClaseDbModel registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    var filtradoPorMateria = bd.tb_clase.Where(x => x.id_materia.Equals(registro.IdMateria));

                    if (filtradoPorMateria.Count() != 0)
                    {
                        var filtradoPorProfesor = filtradoPorMateria.Where(x => x.id_profesor.Equals(registro.IdProfesor));

                        if (filtradoPorProfesor.Count() != 0)
                        {
                            var filtradoPorHora = filtradoPorProfesor.Where(x => x.fecha_hora_inicio.Equals(registro.FechaHoraInicio));
                            if (filtradoPorHora.Count() > 0)
                            {
                                return false;
                            }
                        }
                    }
                    var reg = new MapeadorClaseDatos().MapearTipo2Tipo1(registro);
                    bd.tb_clase.Add(reg);
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
        public ClaseDbModel BuscarRegistro(int id)
        {
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                tb_clase registro = bd.tb_clase.Find(id);
                return new MapeadorClaseDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(ClaseDbModel registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_clase.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    tb_clase reg = new MapeadorClaseDatos().MapearTipo2Tipo1(registro);
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
                    tb_clase registro = bd.tb_clase.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    bd.tb_clase.Remove(registro);
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


