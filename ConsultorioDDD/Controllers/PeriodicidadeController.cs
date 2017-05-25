using Consultorio;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultorioDDD.Controllers
{
    [CustomAuthorize(Roles = "Periodicidade:View")]
    public class PeriodicidadeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Periodicidade> _periodicidades;

            if(TempData["ModelState"] != null)
            {
                ModelState.AddModelError("PeriodicidadeIndex", TempData["ModelState"].ToString());
                TempData["ModelState"] = null;
            }

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _periodicidades = uow.Periodicidades.GetAll();
                }
                return View(_periodicidades);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("PeriodicidadeIndex", ex.Message);
                return View();
            }
        }

        public ActionResult Details(int? id)
        {
            Periodicidade _periodicidade;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _periodicidade = uow.Periodicidades.GetById(id.GetValueOrDefault());
                }
                return View(_periodicidade);
            }
            catch(Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Periodicidade:Edit")]
        public ActionResult Create()
        {
            return View(new Periodicidade());
        }

        [CustomAuthorize(Roles = "Periodicidade:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Periodicidade periodicidade)
        {
            try
            {
                periodicidade.Validate();

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Periodicidades.Insert(periodicidade);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("PeriodicidadeCreate", ex.Message);
                return View(periodicidade);
            }
        }

        [CustomAuthorize(Roles = "Periodicidade:Edit")]
        public ActionResult Edit(int? id)
        {
            Periodicidade _periodicidade;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _periodicidade = uow.Periodicidades.GetById(id.GetValueOrDefault());
                }
                return View(_periodicidade);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Periodicidade:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Periodicidade periodicidade)
        {
            try
            {
                periodicidade.Validate();

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Periodicidades.Update(periodicidade);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("PeriodicidadeEdit", ex.Message);
                return View(periodicidade);
            }
        }

        [CustomAuthorize(Roles = "Periodicidade:Edit")]
        public ActionResult Delete(int? id)
        {
            Periodicidade _periodicidade;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _periodicidade = uow.Periodicidades.GetById(id.GetValueOrDefault());
                }
                return View(_periodicidade);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Periodicidade:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Periodicidade periodicidade)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Periodicidades.Delete(periodicidade.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PeriodicidadeDelete", ex.Message);
                return View(periodicidade);
            }
        }
    }
}