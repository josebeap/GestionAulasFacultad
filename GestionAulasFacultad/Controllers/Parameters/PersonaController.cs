using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.Implementacion;

namespace GestionAulasFacultad.Controllers.Parameters
{
    public class PersonaController : Controller
    {
        private ImplPersonaDatos acceso = new ImplPersonaDatos();

        // GET: Persona
        public ActionResult Index(String filtro = "")
        {
            return View(acceso.ListarRegistros(String.Empty));
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = acceso.BuscarRegistro(id.Value);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }
            return View(tb_persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_rol,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,documentoIdentidad,celular,email,foto,huella")] tb_persona tb_persona)
        {
            if (ModelState.IsValid)
            {
                acceso.GuardarRegistro(tb_persona);
                return RedirectToAction("Index");
            }

            return View(tb_persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona =  acceso.BuscarRegistro(id.Value);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }
            return View(tb_persona);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_rol,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,documentoIdentidad,celular,email,foto,huella")] tb_persona tb_persona)
        {
            if (ModelState.IsValid)
            {
                acceso.EditarRegistro(tb_persona);
                return RedirectToAction("Index");
            }
            return View(tb_persona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = acceso.BuscarRegistro(id.Value);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }
            return View(tb_persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
            acceso.EliminarRegistro(id);
            return RedirectToAction("Index");
        }


    }
}
