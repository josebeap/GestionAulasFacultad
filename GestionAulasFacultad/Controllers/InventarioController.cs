using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using GestionInventariosFacultad.Mapeadores;
using GestionTipoElementosFacultad.Mapeadores;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionInventariosFacultad.Controllers
{
    public class InventarioController : Controller
    {
        private ImplInventarioLogica logica = new ImplInventarioLogica();

        // GET: Inventario
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<InventarioDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorInventarioGUI mapper = new MapeadorInventarioGUI();
            IEnumerable<ModeloInventarioGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            
            var listaPagina = new StaticPagedList<ModeloInventarioGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Inventario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventarioDTO InventarioDTO = logica.BuscarRegistro(id.Value);
            if (InventarioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorInventarioGUI mapper = new MapeadorInventarioGUI();
            ModeloInventarioGUI modelo = mapper.MapearTipo1Tipo2(InventarioDTO);
            return View(modelo);
        }

        // GET: Inventario/Create
        public ActionResult Create()
        {
            ModeloInventarioGUI modelo = new ModeloInventarioGUI();
            ObtenerListadoTipoElementos(modelo);
            return View(modelo);
        }

        private void ObtenerListadoTipoElementos(ModeloInventarioGUI modelo)
        {
            ImplTipoElementoLogica logicaTipoElemento = new ImplTipoElementoLogica();
            IEnumerable<TipoElementoDTO> listaDTO = logicaTipoElemento.ListarRegistros();
            MapeadorTipoElementoGUI mapeador = new MapeadorTipoElementoGUI();
            modelo.ListaTipoElementos = mapeador.MapearTipo1Tipo2(listaDTO);
        }
        private IEnumerable<ModeloTipoElementoGUI> ObtenerListadoTipoElementos()
        {
            ImplTipoElementoLogica logicaTipoElemento = new ImplTipoElementoLogica();
            var listaTipoElemento = logicaTipoElemento.ListarRegistros();
            MapeadorTipoElementoGUI mapeador = new MapeadorTipoElementoGUI();

            var listado = mapeador.MapearTipo1Tipo2(listaTipoElemento);
            return listado;
        }

        // POST: Inventario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ModeloInventarioGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorInventarioGUI mapper = new MapeadorInventarioGUI();
                InventarioDTO InventarioDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(InventarioDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Inventario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventarioDTO InventarioDTO = logica.BuscarRegistro(id.Value);
            if (InventarioDTO == null)
            {
                return HttpNotFound();
            }
            IEnumerable<ModeloTipoElementoGUI> listadoTipoElementos = ObtenerListadoTipoElementos();
            MapeadorInventarioGUI mapper = new MapeadorInventarioGUI();
            ModeloInventarioGUI modelo = mapper.MapearTipo1Tipo2(InventarioDTO);
            modelo.ListaTipoElementos = listadoTipoElementos;
            return View(modelo);
        }

        // POST: Inventario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ModeloInventarioGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorInventarioGUI mapper = new MapeadorInventarioGUI();
                InventarioDTO InventarioDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(InventarioDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Inventario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventarioDTO InventarioDTO = logica.BuscarRegistro(id.Value);
            if (InventarioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorInventarioGUI mapper = new MapeadorInventarioGUI();
            ModeloInventarioGUI modelo = mapper.MapearTipo1Tipo2(InventarioDTO);
            return View(modelo);
        }

        // POST: Inventario/Delete/5
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
                InventarioDTO InventarioDTO = logica.BuscarRegistro(id);
                if (InventarioDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorInventarioGUI mapper = new MapeadorInventarioGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloInventarioGUI modelo = mapper.MapearTipo1Tipo2(InventarioDTO);
                return View(modelo);
            }
        }
    }

}