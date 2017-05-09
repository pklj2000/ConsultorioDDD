using System;
using System.Net;
using System.Web.Mvc;
using Consultorio.Domain.Models;
using Consultorio.Service.Infrastructure;
using Consultorio.Service;

namespace ConsultorioDDD.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioService _service = new UsuarioService();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            int usuarioId = id.GetValueOrDefault();
            Usuario usuario = _service.GetById(usuarioId);
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
                if (ModelState.IsValid)
                {
                    _service.Insert(usuario);
                    _service.Save();
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Usuario/Create", ex.Message);
                return View(usuario);
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            Usuario usuario = _service.GetById(id.GetValueOrDefault());

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
            if (ModelState.IsValid)
            {
                _service.Update(usuario);
                _service.Save();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = _service.GetById(id.GetValueOrDefault());
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
            _service.Delete(id);
            _service.Save();
            return RedirectToAction("Index");
        }
    }
}
