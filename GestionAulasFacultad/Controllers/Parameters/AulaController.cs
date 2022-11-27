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
    public class AulaController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Aula
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_aula.ToListAsync());
        }

        // GET: Aula/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_aula tb_aula = await db.tb_aula.FindAsync(id);
            if (tb_aula == null)
            {
                return HttpNotFound();
            }
            return View(tb_aula);
        }

        // GET: Aula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,tipo_aula,capacidad,cantidad_computadores,multimedia,disponibilidad")] tb_aula tb_aula)
        {
            if (ModelState.IsValid)
            {
                db.tb_aula.Add(tb_aula);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_aula);
        }

        // GET: Aula/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_aula tb_aula = await db.tb_aula.FindAsync(id);
            if (tb_aula == null)
            {
                return HttpNotFound();
            }
            return View(tb_aula);
        }

        // POST: Aula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,tipo_aula,capacidad,cantidad_computadores,multimedia,disponibilidad")] tb_aula tb_aula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_aula).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_aula);
        }

        // GET: Aula/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_aula tb_aula = await db.tb_aula.FindAsync(id);
            if (tb_aula == null)
            {
                return HttpNotFound();
            }
            return View(tb_aula);
        }

        // POST: Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_aula tb_aula = await db.tb_aula.FindAsync(id);
            db.tb_aula.Remove(tb_aula);
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
