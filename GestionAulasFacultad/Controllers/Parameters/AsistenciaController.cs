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
    public class AsistenciaController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Asistencia
        public async Task<ActionResult> Index()
        {
            var tb_asistencia = db.tb_asistencia.Include(t => t.tb_aula).Include(t => t.tb_monitor).Include(t => t.tb_profesor);
            return View(await tb_asistencia.ToListAsync());
        }

        // GET: Asistencia/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_asistencia tb_asistencia = await db.tb_asistencia.FindAsync(id);
            if (tb_asistencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_asistencia);
        }

        // GET: Asistencia/Create
        public ActionResult Create()
        {
            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre");
            ViewBag.id_monitor = new SelectList(db.tb_monitor, "id", "codigo_estudiante");
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id");
            return View();
        }

        // POST: Asistencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,id_monitor,id_profesor,id_aula,fecha_hora_inicio,fecha_hora_fin,estado")] tb_asistencia tb_asistencia)
        {
            if (ModelState.IsValid)
            {
                db.tb_asistencia.Add(tb_asistencia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre", tb_asistencia.id_aula);
            ViewBag.id_monitor = new SelectList(db.tb_monitor, "id", "codigo_estudiante", tb_asistencia.id_monitor);
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id", tb_asistencia.id_profesor);
            return View(tb_asistencia);
        }

        // GET: Asistencia/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_asistencia tb_asistencia = await db.tb_asistencia.FindAsync(id);
            if (tb_asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre", tb_asistencia.id_aula);
            ViewBag.id_monitor = new SelectList(db.tb_monitor, "id", "codigo_estudiante", tb_asistencia.id_monitor);
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id", tb_asistencia.id_profesor);
            return View(tb_asistencia);
        }

        // POST: Asistencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,id_monitor,id_profesor,id_aula,fecha_hora_inicio,fecha_hora_fin,estado")] tb_asistencia tb_asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_asistencia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre", tb_asistencia.id_aula);
            ViewBag.id_monitor = new SelectList(db.tb_monitor, "id", "codigo_estudiante", tb_asistencia.id_monitor);
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id", tb_asistencia.id_profesor);
            return View(tb_asistencia);
        }

        // GET: Asistencia/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_asistencia tb_asistencia = await db.tb_asistencia.FindAsync(id);
            if (tb_asistencia == null)
            {
                return HttpNotFound();
            }
            return View(tb_asistencia);
        }

        // POST: Asistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_asistencia tb_asistencia = await db.tb_asistencia.FindAsync(id);
            db.tb_asistencia.Remove(tb_asistencia);
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
