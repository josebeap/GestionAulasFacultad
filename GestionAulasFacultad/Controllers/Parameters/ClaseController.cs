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
    public class ClaseController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Clase
        public async Task<ActionResult> Index()
        {
            var tb_clase = db.tb_clase.Include(t => t.tb_aula).Include(t => t.tb_profesor);
            return View(await tb_clase.ToListAsync());
        }

        // GET: Clase/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_clase tb_clase = await db.tb_clase.FindAsync(id);
            if (tb_clase == null)
            {
                return HttpNotFound();
            }
            return View(tb_clase);
        }

        // GET: Clase/Create
        public ActionResult Create()
        {
            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre");
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id");
            return View();
        }

        // POST: Clase/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,id_profesor,id_aula,id_materia,cantidad_horas,fecha_hora_inicio")] tb_clase tb_clase)
        {
            if (ModelState.IsValid)
            {
                db.tb_clase.Add(tb_clase);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre", tb_clase.id_aula);
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id", tb_clase.id_profesor);
            return View(tb_clase);
        }

        // GET: Clase/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_clase tb_clase = await db.tb_clase.FindAsync(id);
            if (tb_clase == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre", tb_clase.id_aula);
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id", tb_clase.id_profesor);
            return View(tb_clase);
        }

        // POST: Clase/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,id_profesor,id_aula,id_materia,cantidad_horas,fecha_hora_inicio")] tb_clase tb_clase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_clase).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre", tb_clase.id_aula);
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id", tb_clase.id_profesor);
            return View(tb_clase);
        }

        // GET: Clase/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_clase tb_clase = await db.tb_clase.FindAsync(id);
            if (tb_clase == null)
            {
                return HttpNotFound();
            }
            return View(tb_clase);
        }

        // POST: Clase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_clase tb_clase = await db.tb_clase.FindAsync(id);
            db.tb_clase.Remove(tb_clase);
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
