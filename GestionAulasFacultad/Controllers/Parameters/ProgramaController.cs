using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionAulasFacultad.ModeloBD;

namespace GestionAulasFacultad.Controllers.Parameters
{
    public class ProgramaController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Programa
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_programa.ToListAsync());
        }

        // GET: Programa/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_programa tb_programa = await db.tb_programa.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "id,nombre")] tb_programa tb_programa)
        {
            if (ModelState.IsValid)
            {
                db.tb_programa.Add(tb_programa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_programa);
        }

        // GET: Programa/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_programa tb_programa = await db.tb_programa.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre")] tb_programa tb_programa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_programa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_programa);
        }

        // GET: Programa/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_programa tb_programa = await db.tb_programa.FindAsync(id);
            if (tb_programa == null)
            {
                return HttpNotFound();
            }
            return View(tb_programa);
        }

        // POST: Programa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_programa tb_programa = await db.tb_programa.FindAsync(id);
            db.tb_programa.Remove(tb_programa);
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
