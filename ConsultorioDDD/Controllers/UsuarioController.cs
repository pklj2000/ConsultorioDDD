using System;
using System.Net;
using System.Web.Mvc;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using Consultorio.Data;
using Consultorio.Data.Context;

namespace ConsultorioDDD.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            IEnumerable<Usuario> usuarios;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                usuarios = uow.Usuarios.GetAll();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            Usuario usuario;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                usuario = uow.Usuarios.GetById(id.GetValueOrDefault());
            }

            if (usuario == null)
            {
                return HttpNotFound("Usuário não encontrado");
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Usuarios.Insert(usuario);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Usuario/Create", ex.Message);
                return View(usuario);
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            Usuario usuario;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                usuario = uow.Usuarios.GetById(id.GetValueOrDefault());
            }

            if(usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                uow.Usuarios.Update(usuario);
                uow.Complete();
            }
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            Usuario usuario;
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                usuario = uow.Usuarios.GetById(id.GetValueOrDefault());
            }

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                uow.Usuarios.Delete(id);
                uow.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}
