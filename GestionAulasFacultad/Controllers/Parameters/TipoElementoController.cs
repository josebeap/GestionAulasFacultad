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
    public class TipoElementoController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: TipoElemento
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_tipoelemento.ToListAsync());
        }

        // GET: TipoElemento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipoelemento tb_tipoelemento = await db.tb_tipoelemento.FindAsync(id);
            if (tb_tipoelemento == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipoelemento);
        }

        // GET: TipoElemento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoElemento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre")] tb_tipoelemento tb_tipoelemento)
        {
            if (ModelState.IsValid)
            {
                db.tb_tipoelemento.Add(tb_tipoelemento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_tipoelemento);
        }

        // GET: TipoElemento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipoelemento tb_tipoelemento = await db.tb_tipoelemento.FindAsync(id);
            if (tb_tipoelemento == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipoelemento);
        }

        // POST: TipoElemento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre")] tb_tipoelemento tb_tipoelemento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_tipoelemento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_tipoelemento);
        }

        // GET: TipoElemento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipoelemento tb_tipoelemento = await db.tb_tipoelemento.FindAsync(id);
            if (tb_tipoelemento == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipoelemento);
        }

        // POST: TipoElemento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_tipoelemento tb_tipoelemento = await db.tb_tipoelemento.FindAsync(id);
            db.tb_tipoelemento.Remove(tb_tipoelemento);
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
