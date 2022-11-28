using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionAulasFacultad.Controllers
{
    public class AulaController : Controller
    {
        private ImplAulaLogica logica = new ImplAulaLogica();

        // GET: Aula
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<AulaDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorAulaGUI mapper = new MapeadorAulaGUI();
            IEnumerable<ModeloAulaGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            
            var listaPagina = new StaticPagedList<ModeloAulaGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Aula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AulaDTO AulaDTO = logica.BuscarRegistro(id.Value);
            if (AulaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAulaGUI mapper = new MapeadorAulaGUI();
            ModeloAulaGUI modelo = mapper.MapearTipo1Tipo2(AulaDTO);
            return View(modelo);
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
        public ActionResult Create( ModeloAulaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorAulaGUI mapper = new MapeadorAulaGUI();
                AulaDTO AulaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(AulaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Aula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AulaDTO AulaDTO = logica.BuscarRegistro(id.Value);
            if (AulaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAulaGUI mapper = new MapeadorAulaGUI();
            ModeloAulaGUI modelo = mapper.MapearTipo1Tipo2(AulaDTO);
            return View(modelo);
        }

        // POST: Aula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ModeloAulaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorAulaGUI mapper = new MapeadorAulaGUI();
                AulaDTO AulaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(AulaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Aula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AulaDTO AulaDTO = logica.BuscarRegistro(id.Value);
            if (AulaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAulaGUI mapper = new MapeadorAulaGUI();
            ModeloAulaGUI modelo = mapper.MapearTipo1Tipo2(AulaDTO);
            return View(modelo);
        }

        // POST: Aula/Delete/5
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
                AulaDTO AulaDTO = logica.BuscarRegistro(id);
                if (AulaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorAulaGUI mapper = new MapeadorAulaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloAulaGUI modelo = mapper.MapearTipo1Tipo2(AulaDTO);
                return View(modelo);
            }
        }
    }

}