using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using GestionReservasFacultad.Mapeadores;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionReservasFacultad.Controllers
{
    public class ReservaController : Controller
    {
        private ImplReservaLogica logica = new ImplReservaLogica();

        // GET: Reserva
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<ReservaDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorReservaGUI mapper = new MapeadorReservaGUI();
            IEnumerable<ModeloReservaGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloReservaGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservaDTO ReservaDTO = logica.BuscarRegistro(id.Value);
            if (ReservaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorReservaGUI mapper = new MapeadorReservaGUI();
            ModeloReservaGUI modelo = mapper.MapearTipo1Tipo2(ReservaDTO);
            return View(modelo);
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloReservaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorReservaGUI mapper = new MapeadorReservaGUI();
                ReservaDTO ReservaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(ReservaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservaDTO ReservaDTO = logica.BuscarRegistro(id.Value);
            if (ReservaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorReservaGUI mapper = new MapeadorReservaGUI();
            ModeloReservaGUI modelo = mapper.MapearTipo1Tipo2(ReservaDTO);
            return View(modelo);
        }

        // POST: Reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloReservaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorReservaGUI mapper = new MapeadorReservaGUI();
                ReservaDTO ReservaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(ReservaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservaDTO ReservaDTO = logica.BuscarRegistro(id.Value);
            if (ReservaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorReservaGUI mapper = new MapeadorReservaGUI();
            ModeloReservaGUI modelo = mapper.MapearTipo1Tipo2(ReservaDTO);
            return View(modelo);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ReservaDTO ReservaDTO = logica.BuscarRegistro(id);
                if (ReservaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorReservaGUI mapper = new MapeadorReservaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloReservaGUI modelo = mapper.MapearTipo1Tipo2(ReservaDTO);
                return View(modelo);
            }
        }
    }

}