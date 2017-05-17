using System.Web.Mvc;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using System;
using Consultorio.Data;
using Consultorio.Data.Context;

namespace ConsultorioDDD.Controllers
{
    public class EstadoCivilController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<EstadoCivil> estadoCivil;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    estadoCivil = uow.EstadoCivis.GetAll();
                }
            }
            catch(System.Exception ex)
            {
                estadoCivil = new List<EstadoCivil>();
                ModelState.AddModelError("EstadoCivilIndex", ex.Message);
            }
            return View(estadoCivil);
        }

        public ActionResult Create()
        {
            EstadoCivil estadoCivil = new EstadoCivil();

            return View(estadoCivil);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadoCivil estadoCivil)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.EstadoCivis.Insert(estadoCivil);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("EstadoCivilCreate", ex.Message);
            }
            return View("Create",estadoCivil);
        }

        public ActionResult Details(int? id)
        {
            int estadoCivilId;
            EstadoCivil estadoCivil;

            try
            {
                estadoCivilId = id.GetValueOrDefault();

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    estadoCivil = uow.EstadoCivis.GetById(estadoCivilId);
                }
                if (estadoCivil == null)
                    throw new Exception(string.Format("Erro ao obter dados do tipo de exame: {0}", estadoCivilId));

                return View(estadoCivil);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("EstadoCivilDetails", ex.Message);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int? id)
        {
            int estadoCivilId;
            EstadoCivil estadoCivil;

            try
            {
                estadoCivilId = id.GetValueOrDefault();

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    estadoCivil = uow.EstadoCivis.GetById(estadoCivilId);
                }

                if (estadoCivil == null)
                    throw new Exception(string.Format("Ocorreu um erro ao obter dados para o tipo de exame {0}", estadoCivilId));

                return View(estadoCivil);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TipoExameEdit", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EstadoCivil estadoCivil)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.EstadoCivis.Update(estadoCivil);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("EstadoCivilEdit", ex.Message);
                return View(estadoCivil);
            }
        }

        public ActionResult Delete(int? id)
        {
            int estadoCivilId;
            EstadoCivil estadoCivil;

            try
            {
                estadoCivilId = id.GetValueOrDefault();

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    estadoCivil = uow.EstadoCivis.GetById(estadoCivilId);
                }

                if (estadoCivil == null)
                    throw new Exception(string.Format("Ocorreu um erro ao obter dados para o tipo de exame {0}", estadoCivilId));

                return View(estadoCivil);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TipoExameEdit", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EstadoCivil estadoCivil)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.EstadoCivis.Delete(estadoCivil.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("EstadoCivilDelete", ex.Message);
                return View(estadoCivil);
            }
        }
    }
}