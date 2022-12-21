using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using GestionMonitorsFacultad.Mapeadores;
using GestionProfesorsFacultad.Mapeadores;
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
            ModeloReservaGUI modelo = new ModeloReservaGUI();
            ObtenerListadoAulas(modelo);
            ObtenerListadoMonitores(modelo);
            ObtenerListadoProfesores(modelo);
            return View(modelo);
        }

        private void ObtenerListadoProfesores(ModeloReservaGUI modelo)
        {
            ImplProfesorLogica logicaProfesor = new ImplProfesorLogica();
            IEnumerable<ProfesorDTO> listaDTO = logicaProfesor.ListarRegistros();
            MapeadorProfesorGUI mapeador = new MapeadorProfesorGUI();
            modelo.ListaProfesores = mapeador.MapearTipo1Tipo2(listaDTO);
        }
        private IEnumerable<ModeloProfesorGUI> ObtenerListadoProfesores()
        {
            ImplProfesorLogica logicaProfesor = new ImplProfesorLogica();
            var listaProfesor = logicaProfesor.ListarRegistros();
            MapeadorProfesorGUI mapeador = new MapeadorProfesorGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaProfesor);
            return listado;
        }

        private void ObtenerListadoMonitores(ModeloReservaGUI modelo)
        {
            ImplMonitorLogica logicaMonitor = new ImplMonitorLogica();
            IEnumerable<MonitorDTO> listaDTO = logicaMonitor.ListarRegistros();
            MapeadorMonitorGUI mapeador = new MapeadorMonitorGUI();
            modelo.ListaMonitores = mapeador.MapearTipo1Tipo2(listaDTO);
        }
        private IEnumerable<ModeloMonitorGUI> ObtenerListadoMonitores()
        {
            ImplMonitorLogica logicaMonitor = new ImplMonitorLogica();
            var listaMonitor = logicaMonitor.ListarRegistros();
            MapeadorMonitorGUI mapeador = new MapeadorMonitorGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaMonitor);
            return listado;
        }
        private void ObtenerListadoAulas(ModeloReservaGUI modelo)
        {
            ImplAulaLogica logicaAula = new ImplAulaLogica();
            IEnumerable<AulaDTO> listaDTO = logicaAula.ListarRegistros();
            MapeadorAulaGUI mapeador = new MapeadorAulaGUI();
            modelo.ListaAulas = mapeador.MapearTipo1Tipo2(listaDTO);
        }
        private IEnumerable<ModeloAulaGUI> ObtenerListadoAulas()
        {
            ImplAulaLogica logicaAula = new ImplAulaLogica();
            var listaAula = logicaAula.ListarRegistros();
            MapeadorAulaGUI mapeador = new MapeadorAulaGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaAula);
            return listado;
        }
        // POST: Reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ModeloReservaGUI modelo)
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
            IEnumerable<ModeloProfesorGUI> listadoProfesores = ObtenerListadoProfesores();
            IEnumerable<ModeloMonitorGUI> listadoMonitores = ObtenerListadoMonitores();
            IEnumerable<ModeloAulaGUI> listadoAulas = ObtenerListadoAulas();
            MapeadorReservaGUI mapper = new MapeadorReservaGUI();
            ModeloReservaGUI modelo = mapper.MapearTipo1Tipo2(ReservaDTO);
            modelo.ListaAulas = listadoAulas;
            modelo.ListaMonitores = listadoMonitores;
            modelo.ListaProfesores = listadoProfesores;
            return View(modelo);
        }

        // POST: Reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ModeloReservaGUI modelo)
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