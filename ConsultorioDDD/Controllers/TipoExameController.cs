using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Consultorio.Service;
using Consultorio.Domain.Models;

namespace ConsultorioDDD.Controllers
{
    public class TipoExameController : Controller
    {
        TipoExameService _service = new TipoExameService();

        public ActionResult Index()
        {
            IEnumerable<TipoExame> tipoExame;

            tipoExame = _service.GetAll();
            return View(tipoExame);
        }

        public ActionResult Create()
        {
            TipoExame tipoExame = new TipoExame();

            return View(tipoExame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoExame tipoExame)
        {
            try
            {
                _service.Insert(tipoExame);
                _service.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TipoExameCreate", ex.Message);
            }
            return View(tipoExame);
        }

        public ActionResult Details(int? id)
        {
            int tipoExameId;
            TipoExame tipoExame;

            try
            {
                tipoExameId = id.GetValueOrDefault();
                tipoExame = _service.GetById(tipoExameId);

                if (tipoExame == null)
                    throw new Exception(string.Format("Erro ao obter dados do tipo de exame: {0}", tipoExameId));

                return View(tipoExame);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TipoExameDetails", ex.Message);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int? id)
        {
            int tipoExameId;
            TipoExame tipoExame;

            try
            {
                tipoExameId = id.GetValueOrDefault();
                tipoExame = _service.GetById(tipoExameId);

                if (tipoExame == null)
                    throw new Exception(string.Format("Ocorreu um erro ao obter dados para o tipo de exame {0}", tipoExameId));

                return View(tipoExame);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TipoExameEdit", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoExame tipoExame)
        {
            try
            {
                _service.Update(tipoExame);
                _service.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TipoExameEdit", ex.Message);
                return View(tipoExame);
            }
        }

        public ActionResult Delete(int? id)
        {
            int tipoExameId;

            try
            {
                tipoExameId = id.GetValueOrDefault();
                _service.Delete(tipoExameId);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("TipoExameDelete", ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}