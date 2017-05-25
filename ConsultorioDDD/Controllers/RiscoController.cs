using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Consultorio.Controllers
{
    public class RiscoController : Controller
    {
        [CustomAuthorize(Roles = "Risco:View")]
        public ActionResult Index()
        {
            IEnumerable<Risco> _riscos;

            if (TempData["ModelState"] != null)
            {
                ModelState.AddModelError("RiscoIndex", TempData["ModelState"].ToString());
                TempData["ModelState"] = null;
            }

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _riscos = uow.Riscos.GetAll();
                }
                return View(_riscos);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("RiscoIndex", ex.Message);
                return View();
            }
        }

        public ActionResult Detail(int? id)
        {
            Risco _risco;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _risco = uow.Riscos.GetById(id.GetValueOrDefault());
                }
                return View(_risco);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("RiscoDetail", ex.Message);
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Risco:Edit")]
        public ActionResult Create()
        {
            return View(new Risco());
        }

        [CustomAuthorize(Roles = "Risco:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Risco risco)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Riscos.Insert(risco);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RiscoCreate", ex.Message);
                return View(risco);
            }
        }

        [CustomAuthorize(Roles = "Risco:Edit")]
        public ActionResult Edit(int? id)
        {
            Risco _risco;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _risco = uow.Riscos.GetById(id.GetValueOrDefault());
                }
                return View(_risco);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RiscoDetail", ex.Message);
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Risco:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Risco risco)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Riscos.Update(risco);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RiscoEdit", ex.Message);
                return View(risco);
            }
        }

        [CustomAuthorize(Roles = "Risco:Edit")]
        public ActionResult Delete(int? id)
        {
            Risco _risco;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _risco = uow.Riscos.GetById(id.GetValueOrDefault());
                }
                return View(_risco);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RiscoDetail", ex.Message);
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Risco:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Risco risco)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Riscos.Delete(risco.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("RiscoDelete", ex.Message);
                return View(risco);
            }
        }

    }
}