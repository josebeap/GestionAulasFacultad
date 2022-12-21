﻿using GestionAulasFacultad.Helpers;
using GestionAulasFacultad.Mapeadores.SecurityModule;
using GestionAulasFacultad.Models.SecurityModule;
using Logica.DTO.SecurityModule;
using Logica.Implementacion.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GestionAulasFacultad.Controllers.SecurityModule
{
    public class UserController : BaseController
    {
        private UserImplController capaNegocio = new UserImplController();
        private RoleImplController capaNegocioRol = new RoleImplController();

        public UserController()
        {

        }

        // GET: User
        public ActionResult Index(string filter = "")
        {
            if (!this.VerifySession() || !this.VerifyUserInForm())
            {
                return RedirectToAction("Index", "Home");
            }
            UserModelMapper mapper = new UserModelMapper();
            IEnumerable<UserModel> roleList = mapper.MapearTipo1Tipo2(capaNegocio.RecordList(filter));
            return View(roleList);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if (!this.VerifySession() || !this.VerifyUserInForm())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,LastName,Cellphone,Email")] UserModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserInSessionId = 1;
                UserModelMapper mapper = new UserModelMapper();
                UserDTO dto = mapper.MapearTipo2Tipo1(model);
                int response = capaNegocio.RecordCreation(dto);
                return this.ProcessResponse(response, model);
            }

            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!this.VerifySession() || !this.VerifyUserInForm())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModelMapper mapper = new UserModelMapper();
            UserModel model = mapper.MapearTipo1Tipo2(dto);
            return View(model);
        }

        // POST: User/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Cellphone,Email")] UserModel model)
        {
            if (ModelState.IsValid)
            {
                UserModelMapper mapper = new UserModelMapper();
                UserDTO dto = mapper.MapearTipo2Tipo1(model);
                int response = capaNegocio.RecordUpdate(dto);
                return this.ProcessResponse(response, model);
            }
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private ActionResult ProcessResponse(int response, UserModel model)
        {
            switch (response)
            {
                case 1:
                    return RedirectToAction("Index");
                case 2:
                    ViewBag.Message = Mensajes.ExceptionMessage;
                    return View(model);
                case 3:
                    ViewBag.Message = Mensajes.alreadyExistMessage;
                    return View(model);
            }
            return RedirectToAction("Index");
        }


        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!this.VerifySession() || !this.VerifyUserInForm())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO dto = capaNegocio.RecordSearch(id.Value);
            if (dto == null)
            {
                return HttpNotFound();
            }
            UserModelMapper mapper = new UserModelMapper();
            UserModel model = mapper.MapearTipo1Tipo2(dto);
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Name,Removed,Description")] UserModel model)
        {
            UserModelMapper mapper = new UserModelMapper();
            UserDTO dto = mapper.MapearTipo2Tipo1(model);
            int response = capaNegocio.RecordRemove(dto);
            return this.ProcessResponse(response, model);
        }

        public ActionResult Roles(int? id)
        {
            if (!this.VerifySession() || !this.VerifyUserInForm())
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<RoleDTO> dtoList = capaNegocio.RecordListByUser(id.Value);
            if (dtoList == null)
            {
                return HttpNotFound();
            }
            RoleModelMapper mapper = new RoleModelMapper();
            IEnumerable<RoleModel> roleList = mapper.MapearTipo1Tipo2(dtoList);
            var selectedList = roleList.Where(x => x.IsSelectedByUser).Select(x => x.Id).ToList();

            UserRoleModel model = new UserRoleModel()
            {
                UserId = id.Value,
                RoleList = roleList,
                SelectedRoles = String.Join(",", selectedList)
            };
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Roles")]
        [ValidateAntiForgeryToken]
        public ActionResult Roles([Bind(Include = "UserId,SelectedRoles")] UserRoleModel model)
        {
            List<int> roleList = new List<int>();
            foreach (string roleId in model.SelectedRoles.Split(','))
            {
                roleList.Add(int.Parse(roleId));
            }

            bool response = capaNegocio.AssignRoles(roleList, model.UserId);
            if (response)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Reset()
        {

            return View();

        }

        public ActionResult Login()
        {
            if (this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult IdentifyUser([Bind(Include = "UserName,Password")] LoginModel model)
        {
            UserDTO dto = new UserDTO()
            {
                Email = model.UserName,
                Password = model.Password,
                CurrentDate = DateTime.Now
            };

            UserDTO login = capaNegocio.Login(dto);
            if (login == null)
            {
                ViewBag.ErrorMessage = "Datos inválidos";
                return View(model);
            }
            else
            {
                Session["username"] = model.UserName;
                Session["token"] = login.Token;
                Session["userId"] = login.Id;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost, ActionName("Reset")]
        [ValidateAntiForgeryToken]
        public ActionResult Resetp([Bind(Include = "Email")] ResetModel model)
        {


            if (capaNegocio.PasswordReset(model.Email) != 1)
            {
                ViewBag.ErrorMessage = "CORREO INVALIDO";
                return View(model);
            }
            else
            {
                ViewBag.ErrorMessage = "Nueva contraseña en el correo ingresado";
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            if (!this.VerifySession())
            {
                return RedirectToAction("Index", "Home");
            }
            Session.Remove("username");
            Session.Remove("token");
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}