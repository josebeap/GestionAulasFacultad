using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using GestionProfesorsFacultad.Mapeadores;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionProfesorsFacultad.Controllers
{
    public class ProfesorController : Controller
    {
        private ImplProfesorLogica logica = new ImplProfesorLogica();

        // GET: Profesor
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<ProfesorDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorProfesorGUI mapper = new MapeadorProfesorGUI();
            IEnumerable<ModeloProfesorGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloProfesorGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Profesor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorDTO ProfesorDTO = logica.BuscarRegistro(id.Value);
            if (ProfesorDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProfesorGUI mapper = new MapeadorProfesorGUI();
            ModeloProfesorGUI modelo = mapper.MapearTipo1Tipo2(ProfesorDTO);
            return View(modelo);
        }

        // GET: Profesor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloProfesorGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProfesorGUI mapper = new MapeadorProfesorGUI();
                ProfesorDTO ProfesorDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(ProfesorDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Profesor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorDTO ProfesorDTO = logica.BuscarRegistro(id.Value);
            if (ProfesorDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProfesorGUI mapper = new MapeadorProfesorGUI();
            ModeloProfesorGUI modelo = mapper.MapearTipo1Tipo2(ProfesorDTO);
            return View(modelo);
        }

        // POST: Profesor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloProfesorGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProfesorGUI mapper = new MapeadorProfesorGUI();
                ProfesorDTO ProfesorDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(ProfesorDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Profesor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorDTO ProfesorDTO = logica.BuscarRegistro(id.Value);
            if (ProfesorDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProfesorGUI mapper = new MapeadorProfesorGUI();
            ModeloProfesorGUI modelo = mapper.MapearTipo1Tipo2(ProfesorDTO);
            return View(modelo);
        }

        // POST: Profesor/Delete/5
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
                ProfesorDTO ProfesorDTO = logica.BuscarRegistro(id);
                if (ProfesorDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorProfesorGUI mapper = new MapeadorProfesorGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloProfesorGUI modelo = mapper.MapearTipo1Tipo2(ProfesorDTO);
                return View(modelo);
            }
        }
    }

}