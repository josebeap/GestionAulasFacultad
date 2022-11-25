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
    public class ReservaController : Controller
    {
        private SoftwareBDEntities db = new SoftwareBDEntities();

        // GET: Reserva
        public async Task<ActionResult> Index()
        {
            var tb_reserva = db.tb_reserva.Include(t => t.tb_aula).Include(t => t.tb_monitor).Include(t => t.tb_profesor);
            return View(await tb_reserva.ToListAsync());
        }

        // GET: Reserva/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_reserva tb_reserva = await db.tb_reserva.FindAsync(id);
            if (tb_reserva == null)
            {
                return HttpNotFound();
            }
            return View(tb_reserva);
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre");
            ViewBag.id_monitor = new SelectList(db.tb_monitor, "id", "codigo_estudiante");
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id");
            return View();
        }

        // POST: Reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,id_monitor,id_profesor,id_aula,cantidad_horas,fecha_hora_inicio,estado")] tb_reserva tb_reserva)
        {
            if (ModelState.IsValid)
            {
                db.tb_reserva.Add(tb_reserva);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre", tb_reserva.id_aula);
            ViewBag.id_monitor = new SelectList(db.tb_monitor, "id", "codigo_estudiante", tb_reserva.id_monitor);
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id", tb_reserva.id_profesor);
            return View(tb_reserva);
        }

        // GET: Reserva/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_reserva tb_reserva = await db.tb_reserva.FindAsync(id);
            if (tb_reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre", tb_reserva.id_aula);
            ViewBag.id_monitor = new SelectList(db.tb_monitor, "id", "codigo_estudiante", tb_reserva.id_monitor);
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id", tb_reserva.id_profesor);
            return View(tb_reserva);
        }

        // POST: Reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,id_monitor,id_profesor,id_aula,cantidad_horas,fecha_hora_inicio,estado")] tb_reserva tb_reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_reserva).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_aula = new SelectList(db.tb_aula, "id", "nombre", tb_reserva.id_aula);
            ViewBag.id_monitor = new SelectList(db.tb_monitor, "id", "codigo_estudiante", tb_reserva.id_monitor);
            ViewBag.id_profesor = new SelectList(db.tb_profesor, "id", "id", tb_reserva.id_profesor);
            return View(tb_reserva);
        }

        // GET: Reserva/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_reserva tb_reserva = await db.tb_reserva.FindAsync(id);
            if (tb_reserva == null)
            {
                return HttpNotFound();
            }
            return View(tb_reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_reserva tb_reserva = await db.tb_reserva.FindAsync(id);
            db.tb_reserva.Remove(tb_reserva);
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
