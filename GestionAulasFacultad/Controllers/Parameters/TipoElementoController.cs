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
    public class TipoElementoController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Tipoelemento
        public ActionResult Index()
        {
            return View(db.tb_tipoelemento.ToList());
        }

        // GET: Tipoelemento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipoelemento tb_tipoelemento = db.tb_tipoelemento.Find(id);
            if (tb_tipoelemento == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipoelemento);
        }

        // GET: Tipoelemento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipoelemento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_tipoelemento tb_tipoelemento)
        {
            if (ModelState.IsValid)
            {
                db.tb_tipoelemento.Add(tb_tipoelemento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_tipoelemento);
        }

        // GET: Tipoelemento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipoelemento tb_tipoelemento = db.tb_tipoelemento.Find(id);
            if (tb_tipoelemento == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipoelemento);
        }

        // POST: Tipoelemento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_tipoelemento tb_tipoelemento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_tipoelemento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_tipoelemento);
        }

        // GET: Tipoelemento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipoelemento tb_tipoelemento = db.tb_tipoelemento.Find(id);
            if (tb_tipoelemento == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipoelemento);
        }

        // POST: Tipoelemento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_tipoelemento tb_tipoelemento = db.tb_tipoelemento.Find(id);
            db.tb_tipoelemento.Remove(tb_tipoelemento);
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
