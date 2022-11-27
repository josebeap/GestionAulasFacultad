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
    public class AuxiliarController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Auxiliar
        public ActionResult Index()
        {
            var tb_auxiliar = db.tb_auxiliar.Include(t => t.tb_persona);
            return View(tb_auxiliar.ToList());
        }

        // GET: Auxiliar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_auxiliar tb_auxiliar = db.tb_auxiliar.Find(id);
            if (tb_auxiliar == null)
            {
                return HttpNotFound();
            }
            return View(tb_auxiliar);
        }

        // GET: Auxiliar/Create
        public ActionResult Create()
        {
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre");
            return View();
        }

        // POST: Auxiliar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_persona,funcion")] tb_auxiliar tb_auxiliar)
        {
            if (ModelState.IsValid)
            {
                db.tb_auxiliar.Add(tb_auxiliar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre", tb_auxiliar.id_persona);
            return View(tb_auxiliar);
        }

        // GET: Auxiliar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_auxiliar tb_auxiliar = db.tb_auxiliar.Find(id);
            if (tb_auxiliar == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre", tb_auxiliar.id_persona);
            return View(tb_auxiliar);
        }

        // POST: Auxiliar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_persona,funcion")] tb_auxiliar tb_auxiliar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_auxiliar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre", tb_auxiliar.id_persona);
            return View(tb_auxiliar);
        }

        // GET: Auxiliar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_auxiliar tb_auxiliar = db.tb_auxiliar.Find(id);
            if (tb_auxiliar == null)
            {
                return HttpNotFound();
            }
            return View(tb_auxiliar);
        }

        // POST: Auxiliar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_auxiliar tb_auxiliar = db.tb_auxiliar.Find(id);
            db.tb_auxiliar.Remove(tb_auxiliar);
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
