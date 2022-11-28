﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Models;
using GestionMateriasFacultad.Mapeadores;
using Logica.DTO;
using Logica.Implementacion;
using PagedList;

namespace GestionMateriasFacultad.Controllers
{
    public class MateriaController : Controller
    {
        private ImplMateriaLogica logica = new ImplMateriaLogica();

        // GET: Materia
        public ActionResult Index(int? page, String filtro = "")
        {
            int numPagina = page ?? 1;
            int totalRegistros;

            int registrosPorPagina = DatosGenerales.RegistrosPorPagina;
            IEnumerable<MateriaDTO> listaDatos = logica.ListarRegistros(filtro, numPagina, registrosPorPagina, out totalRegistros);
            MapeadorMateriaGUI mapper = new MapeadorMateriaGUI();
            IEnumerable<ModeloMateriaGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            var registrosPagina = listaGUI.ToPagedList(numPagina, registrosPorPagina);
            var listaPagina = new StaticPagedList<ModeloMateriaGUI>(listaGUI, numPagina, registrosPorPagina, totalRegistros);
            return View(listaPagina);
        }

        // GET: Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaDTO MateriaDTO = logica.BuscarRegistro(id.Value);
            if (MateriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMateriaGUI mapper = new MapeadorMateriaGUI();
            ModeloMateriaGUI modelo = mapper.MapearTipo1Tipo2(MateriaDTO);
            return View(modelo);
        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloMateriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorMateriaGUI mapper = new MapeadorMateriaGUI();
                MateriaDTO MateriaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(MateriaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaDTO MateriaDTO = logica.BuscarRegistro(id.Value);
            if (MateriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMateriaGUI mapper = new MapeadorMateriaGUI();
            ModeloMateriaGUI modelo = mapper.MapearTipo1Tipo2(MateriaDTO);
            return View(modelo);
        }

        // POST: Materia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,PrimerApellido,SegundoApellido,Documento,Celular,Correo")] ModeloMateriaGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorMateriaGUI mapper = new MapeadorMateriaGUI();
                MateriaDTO MateriaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(MateriaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaDTO MateriaDTO = logica.BuscarRegistro(id.Value);
            if (MateriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMateriaGUI mapper = new MapeadorMateriaGUI();
            ModeloMateriaGUI modelo = mapper.MapearTipo1Tipo2(MateriaDTO);
            return View(modelo);
        }

        // POST: Materia/Delete/5
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
                MateriaDTO MateriaDTO = logica.BuscarRegistro(id);
                if (MateriaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorMateriaGUI mapper = new MapeadorMateriaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloMateriaGUI modelo = mapper.MapearTipo1Tipo2(MateriaDTO);
                return View(modelo);
            }
        }
    }

}