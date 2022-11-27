using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using AccesoDeDatos.ModeloDeDatos;

namespace AccesoDeDatos.Implementacion
{ 
	public class ImplReservaDatos
	{
		public IEnumerable<tb_reserva> ListarRegistros(String filtro)
        {
			var lista = new List<tb_reserva>();
            var listaMaterias = new List<tb_materia>();
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                
                lista = bd.tb_reserva.ToList();

            }
            
			return lista;
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(tb_reserva registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con la misma aula, misma hora y cantidad de horas.
                    var filtradoPorAula = bd.tb_reserva.Where(x => x.id_aula.Equals(registro.id_aula));

                    if (filtradoPorAula.Count() != 0)
                    {

                        var filtradoPorHora = filtradoPorAula.Where(x => x.fecha_hora_inicio.Equals(registro.fecha_hora_inicio));
                        
                        if (filtradoPorHora.Count() > 0)
                        {
                            return false;
                        }
                        
                    }

                    
                    bd.tb_reserva.Add(registro);
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
        public tb_reserva BuscarRegistro(int id)
        {
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                tb_reserva registro = bd.tb_reserva.Find(id);
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
        public bool EditarRegistro(tb_reserva registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_reserva.Where(x => x.id == registro.id).Count() == 0)
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
                    tb_reserva registro = bd.tb_reserva.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    bd.tb_reserva.Remove(registro);
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
