using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDeDatos.ModeloDeDatos;

namespace GestionAulasFacultad.Controllers.Parameters
{
    public class ProfesorController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Profesor
        public ActionResult Index()
        {
            var tb_profesor = db.tb_profesor.Include(t => t.tb_persona).Include(t => t.tb_programa);
            return View(tb_profesor.ToList());
        }

        // GET: Profesor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_profesor tb_profesor = db.tb_profesor.Find(id);
            if (tb_profesor == null)
            {
                return HttpNotFound();
            }
            return View(tb_profesor);
        }

        // GET: Profesor/Create
        public ActionResult Create()
        {
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre");
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre");
            return View();
        }

        // POST: Profesor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_persona,id_programa")] tb_profesor tb_profesor)
        {
            if (ModelState.IsValid)
            {
                db.tb_profesor.Add(tb_profesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre", tb_profesor.id_persona);
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre", tb_profesor.id_programa);
            return View(tb_profesor);
        }

        // GET: Profesor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_profesor tb_profesor = db.tb_profesor.Find(id);
            if (tb_profesor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre", tb_profesor.id_persona);
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre", tb_profesor.id_programa);
            return View(tb_profesor);
        }

        // POST: Profesor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_persona,id_programa")] tb_profesor tb_profesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_profesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre", tb_profesor.id_persona);
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre", tb_profesor.id_programa);
            return View(tb_profesor);
        }

        // GET: Profesor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_profesor tb_profesor = db.tb_profesor.Find(id);
            if (tb_profesor == null)
            {
                return HttpNotFound();
            }
            return View(tb_profesor);
        }

        // POST: Profesor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_profesor tb_profesor = db.tb_profesor.Find(id);
            db.tb_profesor.Remove(tb_profesor);
            db.SaveChanges();
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
