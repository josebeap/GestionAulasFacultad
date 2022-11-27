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
    public class InventarioController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Inventario
        public ActionResult Index()
        {
            var tb_inventario = db.tb_inventario.Include(t => t.tb_tipoelemento);
            return View(tb_inventario.ToList());
        }

        // GET: Inventario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_inventario tb_inventario = db.tb_inventario.Find(id);
            if (tb_inventario == null)
            {
                return HttpNotFound();
            }
            return View(tb_inventario);
        }

        // GET: Inventario/Create
        public ActionResult Create()
        {
            ViewBag.id_tipoelemento = new SelectList(db.tb_tipoelemento, "id", "nombre");
            return View();
        }

        // POST: Inventario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo_identificacion,id_tipoelemento,estado")] tb_inventario tb_inventario)
        {
            if (ModelState.IsValid)
            {
                db.tb_inventario.Add(tb_inventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipoelemento = new SelectList(db.tb_tipoelemento, "id", "nombre", tb_inventario.id_tipoelemento);
            return View(tb_inventario);
        }

        // GET: Inventario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_inventario tb_inventario = db.tb_inventario.Find(id);
            if (tb_inventario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipoelemento = new SelectList(db.tb_tipoelemento, "id", "nombre", tb_inventario.id_tipoelemento);
            return View(tb_inventario);
        }

        // POST: Inventario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo_identificacion,id_tipoelemento,estado")] tb_inventario tb_inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipoelemento = new SelectList(db.tb_tipoelemento, "id", "nombre", tb_inventario.id_tipoelemento);
            return View(tb_inventario);
        }

        // GET: Inventario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_inventario tb_inventario = db.tb_inventario.Find(id);
            if (tb_inventario == null)
            {
                return HttpNotFound();
            }
            return View(tb_inventario);
        }

        // POST: Inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_inventario tb_inventario = db.tb_inventario.Find(id);
            db.tb_inventario.Remove(tb_inventario);
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
