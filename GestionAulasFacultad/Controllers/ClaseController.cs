using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using GestionClasesFacultad.Mapeadores;
using GestionMateriasFacultad.Mapeadores;
using GestionProfesorsFacultad.Mapeadores;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionClasesFacultad.Controllers
{
    public class ClaseController : Controller
    {
        private ImplClaseLogica logica = new ImplClaseLogica();

        // GET: Clase
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<ClaseDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorClaseGUI mapper = new MapeadorClaseGUI();
            IEnumerable<ModeloClaseGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            
            var listaPagina = new StaticPagedList<ModeloClaseGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Clase/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseDTO ClaseDTO = logica.BuscarRegistro(id.Value);
            if (ClaseDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorClaseGUI mapper = new MapeadorClaseGUI();
            ModeloClaseGUI modelo = mapper.MapearTipo1Tipo2(ClaseDTO);
            return View(modelo);
        }

        // GET: Clase/Create
        public ActionResult Create()
        {
            ModeloClaseGUI modelo = new ModeloClaseGUI();
            ObtenerListadoProfesores(modelo);
            ObtenerListadoMaterias(modelo);
            ObtenerListadoAulas(modelo);
            return View(modelo);
        }


        private void ObtenerListadoProfesores(ModeloClaseGUI modelo)
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


        private void ObtenerListadoAulas(ModeloClaseGUI modelo)
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
        private void ObtenerListadoMaterias(ModeloClaseGUI modelo)
        {
            ImplMateriaLogica logicaMateria = new ImplMateriaLogica();
            IEnumerable<MateriaDTO> listaDTO = logicaMateria.ListarRegistros();
            MapeadorMateriaGUI mapeador = new MapeadorMateriaGUI();
            modelo.ListaMaterias = mapeador.MapearTipo1Tipo2(listaDTO);
        }

        private IEnumerable<ModeloMateriaGUI> ObtenerListadoMaterias()
        {
            ImplMateriaLogica logicaMateria = new ImplMateriaLogica();
            var listaMateria = logicaMateria.ListarRegistros();
            MapeadorMateriaGUI mapeador = new MapeadorMateriaGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaMateria);
            return listado;
        }


        // POST: Clase/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ModeloClaseGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorClaseGUI mapper = new MapeadorClaseGUI();
                ClaseDTO ClaseDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(ClaseDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Clase/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseDTO ClaseDTO = logica.BuscarRegistro(id.Value);
            if (ClaseDTO == null)
            {
                return HttpNotFound();
            }
            IEnumerable<ModeloProfesorGUI> listadoProfesores = ObtenerListadoProfesores();
            IEnumerable<ModeloMateriaGUI> listadoMaterias = ObtenerListadoMaterias();
            IEnumerable<ModeloAulaGUI> listadoAulas = ObtenerListadoAulas();

            MapeadorClaseGUI mapper = new MapeadorClaseGUI();
            ModeloClaseGUI modelo = mapper.MapearTipo1Tipo2(ClaseDTO);

            modelo.ListaAulas = listadoAulas;
            modelo.ListaMaterias = listadoMaterias;
            modelo.ListaProfesores = listadoProfesores;
            return View(modelo);
        }

        // POST: Clase/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ModeloClaseGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorClaseGUI mapper = new MapeadorClaseGUI();
                ClaseDTO ClaseDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(ClaseDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Clase/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseDTO ClaseDTO = logica.BuscarRegistro(id.Value);
            if (ClaseDTO == null)
            {
                return HttpNotFound();
            }
           
            MapeadorClaseGUI mapper = new MapeadorClaseGUI();
            ModeloClaseGUI modelo = mapper.MapearTipo1Tipo2(ClaseDTO);

           
            return View(modelo);
        }

        // POST: Clase/Delete/5
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
                ClaseDTO ClaseDTO = logica.BuscarRegistro(id);
                if (ClaseDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorClaseGUI mapper = new MapeadorClaseGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloClaseGUI modelo = mapper.MapearTipo1Tipo2(ClaseDTO);
                return View(modelo);
            }
        }
    }

}