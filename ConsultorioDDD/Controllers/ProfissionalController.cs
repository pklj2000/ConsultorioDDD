using Consultorio;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultorioDDD.Controllers
{
    public class ProfissionalController : Controller
    {
        [CustomAuthorize(Roles = "Profissional:View")]
        public ActionResult Index()
        {
            if (TempData["ModelState"] != null)
            {
                ModelState.AddModelError("ProfissionalGrupoIndex", TempData["ModelState"].ToString());
                TempData["ModelState"] = null;
            }

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    IEnumerable<Profissional> _profissionais;
                    _profissionais = uow.Profissionais.GetAll();

                    return View(_profissionais);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ProfissionalGrupoIndex", ex.Message);
                return View();
            }
        }

        [CustomAuthorize(Roles = "Profissional:View")]
        public ActionResult Details(int? id)
        {
            Profissional _profissional;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _profissional = uow.Profissionais.GetById(id.GetValueOrDefault());
                }
                return View(_profissional);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [CustomAuthorize(Roles = "Profissional:Edit")]
        public ActionResult Create()
        {
            return View(new Profissional());
        }

        [CustomAuthorize(Roles = "Profissional:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profissional profissional)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    profissional.Validate();

                    uow.Profissionais.Insert(profissional);
                    uow.Complete();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", string.Format("Erro ao salvar grupo: {0}", ex.Message));
                }
                return View(profissional);
            }
        }

        [CustomAuthorize(Roles = "Profissional:Edit")]
        public ActionResult Edit(int? id)
        {
            Profissional _profissional;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _profissional = uow.Profissionais.GetById(id.GetValueOrDefault());
                }
                return View(_profissional);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [CustomAuthorize(Roles = "Profissional:Edit")]
        [HttpPost]
        public ActionResult Edit(Profissional profissional)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    profissional.Validate();

                    uow.Profissionais.Update(profissional);
                    uow.Complete();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ProfissionalEdit", ex.Message);

                    return View(profissional);
                }
            }
        }

        [CustomAuthorize(Roles = "Profissional:Edit")]
        public ActionResult Delete(int? id)
        {
            try
            {
                Profissional _profissional;
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _profissional = uow.Profissionais.GetById(id.GetValueOrDefault());
                }
                return View(_profissional);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Profissional:Edit")]
        [HttpPost]
        public ActionResult Delete(Profissional profissional)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Profissionais.Delete(profissional.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ProfissionalDelete", String.Format("Operação não foi concluída. Podem haver Exames associados a este profissional: {0}", ex.Message));
                return View(profissional);
            }
        }
    }
}