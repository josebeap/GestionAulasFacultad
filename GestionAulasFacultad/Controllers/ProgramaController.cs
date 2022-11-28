using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using GestionProgramasFacultad.Mapeadores;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionProgramasFacultad.Controllers
{
    public class ProgramaController : Controller
    {
        private ImplProgramaLogica logica = new ImplProgramaLogica();

        // GET: Programa
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<ProgramaDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorProgramaGUI mapper = new MapeadorProgramaGUI();
            IEnumerable<ModeloProgramaGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloProgramaGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Programa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramaDTO ProgramaDTO = logica.BuscarRegistro(id.Value);
            if (ProgramaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProgramaGUI mapper = new MapeadorProgramaGUI();
            ModeloProgramaGUI modelo = mapper.MapearTipo1Tipo2(ProgramaDTO);
            return View(modelo);
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
        public ActionResult Create([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloProgramaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProgramaGUI mapper = new MapeadorProgramaGUI();
                ProgramaDTO ProgramaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(ProgramaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Programa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramaDTO ProgramaDTO = logica.BuscarRegistro(id.Value);
            if (ProgramaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProgramaGUI mapper = new MapeadorProgramaGUI();
            ModeloProgramaGUI modelo = mapper.MapearTipo1Tipo2(ProgramaDTO);
            return View(modelo);
        }

        // POST: Programa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloProgramaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProgramaGUI mapper = new MapeadorProgramaGUI();
                ProgramaDTO ProgramaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(ProgramaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Programa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramaDTO ProgramaDTO = logica.BuscarRegistro(id.Value);
            if (ProgramaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProgramaGUI mapper = new MapeadorProgramaGUI();
            ModeloProgramaGUI modelo = mapper.MapearTipo1Tipo2(ProgramaDTO);
            return View(modelo);
        }

        // POST: Programa/Delete/5
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
                ProgramaDTO ProgramaDTO = logica.BuscarRegistro(id);
                if (ProgramaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorProgramaGUI mapper = new MapeadorProgramaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloProgramaGUI modelo = mapper.MapearTipo1Tipo2(ProgramaDTO);
                return View(modelo);
            }
        }
    }

}