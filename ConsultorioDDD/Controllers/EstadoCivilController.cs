using System.Web.Mvc;
using Consultorio.Service.Infrastructure;
using Consultorio.Service;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using System;

namespace ConsultorioDDD.Controllers
{
    public class EstadoCivilController : Controller
    {
        IEstadoCivilService _service = new EstadoCivilService();

        public EstadoCivilController(IEstadoCivilService service)
        {
            _service = service;
        }

        public EstadoCivilController():this(new EstadoCivilService())
        {
        }

        public ActionResult Index()
        {
            IEnumerable<EstadoCivil> estadoCivil;

            try
            {
                estadoCivil = _service.GetAll();
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
                _service.Insert(estadoCivil);
                //_service.Save();
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
                estadoCivil = _service.GetById(estadoCivilId);

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
                estadoCivil = _service.GetById(estadoCivilId);

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
                _service.Update(estadoCivil);
                _service.Save();
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
                estadoCivil = _service.GetById(estadoCivilId);

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
                _service.Delete(estadoCivil.Id);
                _service.Save();
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