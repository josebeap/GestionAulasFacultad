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
    public class MateriaController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Materia
        public ActionResult Index()
        {
            var tb_materia = db.tb_materia.Include(t => t.tb_programa);
            return View(tb_materia.ToList());
        }

        // GET: Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_materia tb_materia = db.tb_materia.Find(id);
            if (tb_materia == null)
            {
                return HttpNotFound();
            }
            return View(tb_materia);
        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre");
            return View();
        }

        // POST: Materia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_programa,nombre")] tb_materia tb_materia)
        {
            if (ModelState.IsValid)
            {
                db.tb_materia.Add(tb_materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre", tb_materia.id_programa);
            return View(tb_materia);
        }

        // GET: Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_materia tb_materia = db.tb_materia.Find(id);
            if (tb_materia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre", tb_materia.id_programa);
            return View(tb_materia);
        }

        // POST: Materia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_programa,nombre")] tb_materia tb_materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre", tb_materia.id_programa);
            return View(tb_materia);
        }

        // GET: Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_materia tb_materia = db.tb_materia.Find(id);
            if (tb_materia == null)
            {
                return HttpNotFound();
            }
            return View(tb_materia);
        }

        // POST: Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_materia tb_materia = db.tb_materia.Find(id);
            db.tb_materia.Remove(tb_materia);
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
