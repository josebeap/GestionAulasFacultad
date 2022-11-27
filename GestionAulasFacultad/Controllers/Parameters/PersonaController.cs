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

namespace GestionAulasFacultad.Controllers.Parameters
{
    public class PersonaController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Persona
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_persona.ToListAsync());
        }

        // GET: Persona/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = await db.tb_persona.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "id,id_rol,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,documentoIdentidad,celular,email,foto,huella")] tb_persona tb_persona)
        {
            if (ModelState.IsValid)
            {
                db.tb_persona.Add(tb_persona);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_persona);
        }

        // GET: Persona/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = await db.tb_persona.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "id,id_rol,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,documentoIdentidad,celular,email,foto,huella")] tb_persona tb_persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_persona).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_persona);
        }

        // GET: Persona/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_persona tb_persona = await db.tb_persona.FindAsync(id);
            if (tb_persona == null)
            {
                return HttpNotFound();
            }
            return View(tb_persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_persona tb_persona = await db.tb_persona.FindAsync(id);
            db.tb_persona.Remove(tb_persona);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
