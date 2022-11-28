using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using GestionMonitorsFacultad.Mapeadores;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionMonitorsFacultad.Controllers
{
    public class MonitorController : Controller
    {
        private ImplMonitorLogica logica = new ImplMonitorLogica();

        // GET: Monitor
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<MonitorDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorMonitorGUI mapper = new MapeadorMonitorGUI();
            IEnumerable<ModeloMonitorGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloMonitorGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Monitor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitorDTO MonitorDTO = logica.BuscarRegistro(id.Value);
            if (MonitorDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMonitorGUI mapper = new MapeadorMonitorGUI();
            ModeloMonitorGUI modelo = mapper.MapearTipo1Tipo2(MonitorDTO);
            return View(modelo);
        }

        // GET: Monitor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Monitor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloMonitorGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorMonitorGUI mapper = new MapeadorMonitorGUI();
                MonitorDTO MonitorDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(MonitorDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Monitor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitorDTO MonitorDTO = logica.BuscarRegistro(id.Value);
            if (MonitorDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMonitorGUI mapper = new MapeadorMonitorGUI();
            ModeloMonitorGUI modelo = mapper.MapearTipo1Tipo2(MonitorDTO);
            return View(modelo);
        }

        // POST: Monitor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloMonitorGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorMonitorGUI mapper = new MapeadorMonitorGUI();
                MonitorDTO MonitorDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(MonitorDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Monitor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitorDTO MonitorDTO = logica.BuscarRegistro(id.Value);
            if (MonitorDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMonitorGUI mapper = new MapeadorMonitorGUI();
            ModeloMonitorGUI modelo = mapper.MapearTipo1Tipo2(MonitorDTO);
            return View(modelo);
        }

        // POST: Monitor/Delete/5
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
                MonitorDTO MonitorDTO = logica.BuscarRegistro(id);
                if (MonitorDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorMonitorGUI mapper = new MapeadorMonitorGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloMonitorGUI modelo = mapper.MapearTipo1Tipo2(MonitorDTO);
                return View(modelo);
            }
        }
    }

}