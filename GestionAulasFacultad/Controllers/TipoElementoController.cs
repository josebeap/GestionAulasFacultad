using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using GestionTipoElementosFacultad.Mapeadores;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionTipoElementosFacultad.Controllers
{
    public class TipoElementoController : Controller
    {
        private ImplTipoElementoLogica logica = new ImplTipoElementoLogica();

        // GET: TipoElemento
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<TipoElementoDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorTipoElementoGUI mapper = new MapeadorTipoElementoGUI();
            IEnumerable<ModeloTipoElementoGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloTipoElementoGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: TipoElemento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoElementoDTO TipoElementoDTO = logica.BuscarRegistro(id.Value);
            if (TipoElementoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoElementoGUI mapper = new MapeadorTipoElementoGUI();
            ModeloTipoElementoGUI modelo = mapper.MapearTipo1Tipo2(TipoElementoDTO);
            return View(modelo);
        }

        // GET: TipoElemento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoElemento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloTipoElementoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorTipoElementoGUI mapper = new MapeadorTipoElementoGUI();
                TipoElementoDTO TipoElementoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(TipoElementoDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: TipoElemento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoElementoDTO TipoElementoDTO = logica.BuscarRegistro(id.Value);
            if (TipoElementoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoElementoGUI mapper = new MapeadorTipoElementoGUI();
            ModeloTipoElementoGUI modelo = mapper.MapearTipo1Tipo2(TipoElementoDTO);
            return View(modelo);
        }

        // POST: TipoElemento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloTipoElementoGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorTipoElementoGUI mapper = new MapeadorTipoElementoGUI();
                TipoElementoDTO TipoElementoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(TipoElementoDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: TipoElemento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoElementoDTO TipoElementoDTO = logica.BuscarRegistro(id.Value);
            if (TipoElementoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoElementoGUI mapper = new MapeadorTipoElementoGUI();
            ModeloTipoElementoGUI modelo = mapper.MapearTipo1Tipo2(TipoElementoDTO);
            return View(modelo);
        }

        // POST: TipoElemento/Delete/5
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
                TipoElementoDTO TipoElementoDTO = logica.BuscarRegistro(id);
                if (TipoElementoDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorTipoElementoGUI mapper = new MapeadorTipoElementoGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloTipoElementoGUI modelo = mapper.MapearTipo1Tipo2(TipoElementoDTO);
                return View(modelo);
            }
        }
    }

}