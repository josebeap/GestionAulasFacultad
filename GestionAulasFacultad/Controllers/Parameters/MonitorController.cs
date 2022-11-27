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
    public class MonitorController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Monitor
        public ActionResult Index()
        {
            var tb_monitor = db.tb_monitor.Include(t => t.tb_materia).Include(t => t.tb_persona).Include(t => t.tb_programa);
            return View(tb_monitor.ToList());
        }

        // GET: Monitor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_monitor tb_monitor = db.tb_monitor.Find(id);
            if (tb_monitor == null)
            {
                return HttpNotFound();
            }
            return View(tb_monitor);
        }

        // GET: Monitor/Create
        public ActionResult Create()
        {
            ViewBag.id_materia = new SelectList(db.tb_materia, "id", "nombre");
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre");
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre");
            return View();
        }

        // POST: Monitor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_persona,id_programa,id_materia,codigo_estudiante")] tb_monitor tb_monitor)
        {
            if (ModelState.IsValid)
            {
                db.tb_monitor.Add(tb_monitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_materia = new SelectList(db.tb_materia, "id", "nombre", tb_monitor.id_materia);
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre", tb_monitor.id_persona);
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre", tb_monitor.id_programa);
            return View(tb_monitor);
        }

        // GET: Monitor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_monitor tb_monitor = db.tb_monitor.Find(id);
            if (tb_monitor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_materia = new SelectList(db.tb_materia, "id", "nombre", tb_monitor.id_materia);
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre", tb_monitor.id_persona);
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre", tb_monitor.id_programa);
            return View(tb_monitor);
        }

        // POST: Monitor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_persona,id_programa,id_materia,codigo_estudiante")] tb_monitor tb_monitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_monitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_materia = new SelectList(db.tb_materia, "id", "nombre", tb_monitor.id_materia);
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "primer_nombre", tb_monitor.id_persona);
            ViewBag.id_programa = new SelectList(db.tb_programa, "id", "nombre", tb_monitor.id_programa);
            return View(tb_monitor);
        }

        // GET: Monitor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_monitor tb_monitor = db.tb_monitor.Find(id);
            if (tb_monitor == null)
            {
                return HttpNotFound();
            }
            return View(tb_monitor);
        }

        // POST: Monitor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_monitor tb_monitor = db.tb_monitor.Find(id);
            db.tb_monitor.Remove(tb_monitor);
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
