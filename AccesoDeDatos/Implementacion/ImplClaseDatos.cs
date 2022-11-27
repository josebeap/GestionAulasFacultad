using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using AccesoDeDatos.ModeloDeDatos;

namespace AccesoDeDatos.Implementacion
{ 
	public class ImplClaseDatos
	{
		public IEnumerable<tb_clase> ListarRegistros(String filtro)
        {
			var lista = new List<tb_clase>();
            var listaMaterias = new List<tb_materia>();
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                if (String.IsNullOrWhiteSpace(filtro))
                {
                    lista = bd.tb_clase.ToList();
                }
                else
                {   
                    listaMaterias= bd.tb_materia.Where(x => x.nombre.ToUpper().Contains(filtro.ToUpper())).ToList();
                    foreach (var i in listaMaterias)
                    {
                        lista.Add((tb_clase)bd.tb_clase.Where(x => x.id_materia.Equals(i.id)));
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
        public bool GuardarRegistro(tb_clase registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con la misma materia, mismo profesor y misma hora
                    var filtradoPorMateria = bd.tb_clase.Where(x => x.id_materia.Equals(registro.id_materia));
                    
                    if(filtradoPorMateria.Count() != 0)
                    {
                        var filtradoPorProfesor = filtradoPorMateria.Where(x => x.id_profesor.Equals(registro.id_profesor));

                        if (filtradoPorProfesor.Count() != 0)
                        {
                            var filtradoPorHora = filtradoPorProfesor.Where(x => x.fecha_hora_inicio.Equals(registro.fecha_hora_inicio));
                            if (filtradoPorHora.Count() > 0) {
                                return false;
                            }
                        }
                    }

                    
                    bd.tb_clase.Add(registro);
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
        public tb_clase BuscarRegistro(int id)
        {
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                tb_clase registro = bd.tb_clase.Find(id);
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
        public bool EditarRegistro(tb_clase registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_clase.Where(x => x.id == registro.id).Count() == 0)
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
