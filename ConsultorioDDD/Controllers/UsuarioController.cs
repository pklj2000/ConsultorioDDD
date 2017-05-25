using System;
using System.Web.Mvc;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Data.ViewModel;
using System.Linq;

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

            if (TempData["ModelError"] != null)
            {
                ModelState.AddModelError("UsuárioIndex", TempData["ModelError"].ToString());
                TempData["ModelError"] = null;
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

        public ActionResult UsuarioPerfil(int? id, string[] perfilAssociado, string comando)
        {
            Usuario _usuario;
            IEnumerable<Perfil> _perfis;
            List<AssignedPerfil> viewModel;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _usuario = uow.Usuarios.GetById(id.GetValueOrDefault());
                    _perfis = uow.Perfis.GetAll();
                    viewModel = new List<AssignedPerfil>();
                    var _perfilUsuario = _usuario.Perfis;

                    foreach (var item in _perfis)
                    {
                        viewModel.Add(new AssignedPerfil
                        {
                            CodPerfil = item.Id,
                            Descricao = item.Descricao,
                            Assigned = _perfilUsuario.Contains(item)
                        });
                    }
                }
                ViewBag.Perfis = viewModel;
                return View(_usuario);
            }
            catch (Exception ex)
            {
                TempData["ModelError"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult UsuarioPerfil(int? id, string[] perfilAssociado)
        {
            try
            {
                Usuario _usuario;
                
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _usuario = uow.Usuarios.GetById(id.GetValueOrDefault());
                    _usuario.Perfis = new List<Perfil>();

                   var perfilAssociadoHash = new HashSet<string>(perfilAssociado);
                    
                    foreach(string item in perfilAssociadoHash)
                    {
                        _usuario.Perfis.Add(
                            uow.Perfis.GetById(Convert.ToInt32(item)));
                    }
                    uow.Usuarios.Update(_usuario);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UsuarioPerfil", ex.Message);
                return UsuarioPerfil(id, perfilAssociado);
            }
        }
    }
}
