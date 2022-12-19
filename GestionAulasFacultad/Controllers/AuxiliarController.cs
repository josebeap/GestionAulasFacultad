using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using GestionAuxiliarsFacultad.Mapeadores;
using GestionPersonasFacultad.Mapeadores;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionAuxiliarsFacultad.Controllers
{
    public class AuxiliarController : Controller
    {
        private ImplAuxiliarLogica logica = new ImplAuxiliarLogica();

        // GET: Auxiliar
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<AuxiliarDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorAuxiliarGUI mapper = new MapeadorAuxiliarGUI();
            IEnumerable<ModeloAuxiliarGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            
            var listaPagina = new StaticPagedList<ModeloAuxiliarGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Auxiliar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuxiliarDTO AuxiliarDTO = logica.BuscarRegistro(id.Value);
            if (AuxiliarDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAuxiliarGUI mapper = new MapeadorAuxiliarGUI();
            ModeloAuxiliarGUI modelo = mapper.MapearTipo1Tipo2(AuxiliarDTO);
            return View(modelo);
        }

        // GET: Auxiliar/Create
        public ActionResult Create()
        {
            ModeloAuxiliarGUI modelo = new ModeloAuxiliarGUI();
            ObtenerListadoPersonas(modelo);
            return View(modelo);
        }

        private void ObtenerListadoPersonas(ModeloAuxiliarGUI modelo)
        {
            ImplPersonaLogica logicaPersona = new ImplPersonaLogica();
            IEnumerable<PersonaDTO> listaDTO = logicaPersona.ListarRegistros();
            MapeadorPersonaGUI mapeador = new MapeadorPersonaGUI();
            modelo.ListaPersonas = mapeador.MapearTipo1Tipo2(listaDTO);
        }

        // POST: Auxiliar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ModeloAuxiliarGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorAuxiliarGUI mapper = new MapeadorAuxiliarGUI();
                AuxiliarDTO AuxiliarDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(AuxiliarDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Auxiliar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuxiliarDTO AuxiliarDTO = logica.BuscarRegistro(id.Value);
            if (AuxiliarDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAuxiliarGUI mapper = new MapeadorAuxiliarGUI();
            ModeloAuxiliarGUI modelo = mapper.MapearTipo1Tipo2(AuxiliarDTO);
            return View(modelo);
        }

        // POST: Auxiliar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ModeloAuxiliarGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorAuxiliarGUI mapper = new MapeadorAuxiliarGUI();
                AuxiliarDTO AuxiliarDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(AuxiliarDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Auxiliar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuxiliarDTO AuxiliarDTO = logica.BuscarRegistro(id.Value);
            if (AuxiliarDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAuxiliarGUI mapper = new MapeadorAuxiliarGUI();
            ModeloAuxiliarGUI modelo = mapper.MapearTipo1Tipo2(AuxiliarDTO);
            return View(modelo);
        }

        // POST: Auxiliar/Delete/5
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
                AuxiliarDTO AuxiliarDTO = logica.BuscarRegistro(id);
                if (AuxiliarDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorAuxiliarGUI mapper = new MapeadorAuxiliarGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloAuxiliarGUI modelo = mapper.MapearTipo1Tipo2(AuxiliarDTO);
                return View(modelo);
            }
        }
    }

}