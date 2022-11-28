using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAsistenciasFacultad.Mapeadores;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionAsistenciasFacultad.Controllers
{
    public class AsistenciaController : Controller
    {
        private ImplAsistenciaLogica logica = new ImplAsistenciaLogica();

        // GET: Asistencia
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<AsistenciaDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorAsistenciaGUI mapper = new MapeadorAsistenciaGUI();
            IEnumerable<ModeloAsistenciaGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloAsistenciaGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Asistencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsistenciaDTO AsistenciaDTO = logica.BuscarRegistro(id.Value);
            if (AsistenciaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAsistenciaGUI mapper = new MapeadorAsistenciaGUI();
            ModeloAsistenciaGUI modelo = mapper.MapearTipo1Tipo2(AsistenciaDTO);
            return View(modelo);
        }

        // GET: Asistencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asistencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloAsistenciaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorAsistenciaGUI mapper = new MapeadorAsistenciaGUI();
                AsistenciaDTO AsistenciaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(AsistenciaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Asistencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsistenciaDTO AsistenciaDTO = logica.BuscarRegistro(id.Value);
            if (AsistenciaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAsistenciaGUI mapper = new MapeadorAsistenciaGUI();
            ModeloAsistenciaGUI modelo = mapper.MapearTipo1Tipo2(AsistenciaDTO);
            return View(modelo);
        }

        // POST: Asistencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloAsistenciaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorAsistenciaGUI mapper = new MapeadorAsistenciaGUI();
                AsistenciaDTO AsistenciaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(AsistenciaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Asistencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsistenciaDTO AsistenciaDTO = logica.BuscarRegistro(id.Value);
            if (AsistenciaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAsistenciaGUI mapper = new MapeadorAsistenciaGUI();
            ModeloAsistenciaGUI modelo = mapper.MapearTipo1Tipo2(AsistenciaDTO);
            return View(modelo);
        }

        // POST: Asistencia/Delete/5
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
                AsistenciaDTO AsistenciaDTO = logica.BuscarRegistro(id);
                if (AsistenciaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorAsistenciaGUI mapper = new MapeadorAsistenciaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloAsistenciaGUI modelo = mapper.MapearTipo1Tipo2(AsistenciaDTO);
                return View(modelo);
            }
        }
    }

}