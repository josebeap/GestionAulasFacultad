﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using GestionClasesFacultad.Mapeadores;
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
            var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
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
            return View();
        }

        // POST: Clase/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloClaseGUI modelo)
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
            MapeadorClaseGUI mapper = new MapeadorClaseGUI();
            ModeloClaseGUI modelo = mapper.MapearTipo1Tipo2(ClaseDTO);
            return View(modelo);
        }

        // POST: Clase/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloClaseGUI modelo)
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