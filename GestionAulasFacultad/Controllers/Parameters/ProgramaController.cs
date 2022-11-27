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
    public class ProgramaController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Programa
        public ActionResult Index()
        {
            return View(db.tb_programa.ToList());
        }

        // GET: Programa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_programa tb_programa = db.tb_programa.Find(id);
            if (tb_programa == null)
            {
                return HttpNotFound();
            }
            return View(tb_programa);
        }

        // GET: Programa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_programa tb_programa)
        {
            if (ModelState.IsValid)
            {
                db.tb_programa.Add(tb_programa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_programa);
        }

        // GET: Programa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_programa tb_programa = db.tb_programa.Find(id);
            if (tb_programa == null)
            {
                return HttpNotFound();
            }
            return View(tb_programa);
        }

        // POST: Programa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_programa tb_programa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_programa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_programa);
        }

        // GET: Programa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_programa tb_programa = db.tb_programa.Find(id);
            if (tb_programa == null)
            {
                return HttpNotFound();
            }
            return View(tb_programa);
        }

        // POST: Programa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_programa tb_programa = db.tb_programa.Find(id);
            db.tb_programa.Remove(tb_programa);
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
