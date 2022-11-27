using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using AccesoDeDatos.ModeloDeDatos;

namespace AccesoDeDatos.Implementacion
{ 
	public class ImplProfesorDatos
	{
		public IEnumerable<tb_profesor> ListarRegistros(String filtro)
        {
			var lista = new List<tb_profesor>();
            var listaPersonas = new List<tb_persona>();
            
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                if (String.IsNullOrWhiteSpace(filtro))
                {
                    lista = bd.tb_profesor.ToList();
                }
                else
                {   
                    listaPersonas= bd.tb_persona.Where(x => x.primer_nombre.ToUpper().Contains(filtro.ToUpper())).ToList();
                    foreach (var i in listaPersonas)
                    {
                        lista.Add((tb_profesor)bd.tb_profesor.Where(x => x.id_persona.Equals(i.id)));
                    }
                    
                }
            }
            
			return lista;
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(tb_profesor registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_profesor.Where(x => x.id_persona.Equals(registro.id_persona)).Count() > 0)
                    {
                        return false;
                    }
                   
                    
                    bd.tb_profesor.Add(registro);
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
        public tb_profesor BuscarRegistro(int id)
        {
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                tb_profesor registro = bd.tb_profesor.Find(id);
                if (registro != null)
                {
                    return registro;
                }
                return null;
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(tb_profesor registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_profesor.Where(x => x.id == registro.id).Count() == 0)
                    {
                        return false;
                    }
                    
                    bd.Entry(registro).State = EntityState.Modified;
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
                    tb_profesor registro = bd.tb_profesor.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    bd.tb_profesor.Remove(registro);
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
