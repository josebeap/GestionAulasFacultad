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
    public class ImplMonitorDatos
    {
        /// <summary>
        /// Método para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<MonitorDbModel> ListarRegistros(String filtro)
        {
            var lista = new List<tb_monitor>();
            var listaPersonas = new List<tb_persona>();
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                // lista = bd.tb_monitor.Where(x => x.nombre.ToUpper().Contains(filtro.ToUpper())).ToList();
                listaPersonas = (
                    from c in bd.tb_persona
                    where c.primer_nombre.Contains(filtro)
                    select c
                    ).ToList();

                foreach (var i in listaPersonas)
                {
                    lista.Add((tb_monitor)bd.tb_monitor.Where(x => x.id_persona.Equals(i.id)));
                }
            }
            return new MapeadorMonitorDatos().MapearTipo1Tipo2(lista);
        }

        /// <summary>
        /// Método para almacenar un registro
        /// </summary>
        /// <param name="registro">el registro a almacenar</param>
        /// <returns>true cuando se almacena y false cuando ya existe un registro igual o una excepción</returns>
        public bool GuardarRegistro(MonitorDbModel registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo nombre
                    if (bd.tb_monitor.Where(x => x.id_persona.Equals(registro.IdPersona)).Count() > 0)
                    {
                        return false;
                    }
                    var reg = new MapeadorMonitorDatos().MapearTipo2Tipo1(registro);
                    bd.tb_monitor.Add(reg);
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
        public MonitorDbModel BuscarRegistro(int id)
        {
            using (SoftwareBDEntities bd = new SoftwareBDEntities())
            {
                tb_monitor registro = bd.tb_monitor.Find(id);
                return new MapeadorMonitorDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Método para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>true cuando se edita y false cuando no existe el registro o una excepción</returns>
        public bool EditarRegistro(MonitorDbModel registro)
        {
            try
            {
                using (SoftwareBDEntities bd = new SoftwareBDEntities())
                {
                    // verificación de la existencia de un registro con el mismo id
                    if (bd.tb_monitor.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }
                    tb_monitor reg = new MapeadorMonitorDatos().MapearTipo2Tipo1(registro);
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
                    tb_monitor registro = bd.tb_monitor.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    bd.tb_monitor.Remove(registro);
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
