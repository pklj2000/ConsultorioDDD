using Consultorio;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Data.ViewModel;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultorioDDD.Controllers
{
    [CustomAuthorize(Roles = "Exame:View")]
    public class ExameController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Exame> _exames;

            if (TempData["ModelState"] != null)
            {
                ModelState.AddModelError("ExameIndex", TempData["ModelState"].ToString());
                TempData["ModelState"] = null;
            }

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _exames = uow.Exames.GetAll();
                }
                return View(_exames);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("ExameIndex", ex.Message);
                return View();
            }
        }

        public ActionResult Details(int? id)
        {
            Exame _exame;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _exame = uow.Exames.GetById(id.GetValueOrDefault());

                }
                return View(_exame);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ExameIndex", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Exame:Edit")]
        public ActionResult Create()
        {
            PopularPeriodicidadeData();
            PopularTipoExame(null);
            return View(new Exame());
        }

        [CustomAuthorize(Roles = "Exame:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exame exame)
        {
            try
            {
                exame.Validate();

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Exames.Insert(exame);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ExameCreate", ex.Message);
                PopularPeriodicidadeData();
                PopularTipoExame(exame.TipoExame);
                return View(exame);
            }
        }

        [CustomAuthorize(Roles = "Exame:Edit")]
        public ActionResult Edit(int? id)
        {
            Exame _exame;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _exame = uow.Exames.GetById(id.GetValueOrDefault());
                    PopularPeriodicidadeData();
                    PopularTipoExame(_exame.TipoExame);
                }
                return View(_exame);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ExameEdit", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Exame:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Exame exame, string[] selectedTipoExames)
        {
            try
            {
                exame.TipoExame = new List<TipoExame>();
                exame.Validate();

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    if (selectedTipoExames != null)
                        foreach (string item in selectedTipoExames)
                            exame.TipoExame.Add(uow.TipoExames.GetById(Convert.ToInt32(item)));

                    uow.Exames.Update(exame);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ExameCreate", ex.Message);
                PopularPeriodicidadeData();
                PopularTipoExame(exame.TipoExame);
                return View(exame);
            }
        }

        [CustomAuthorize(Roles = "Exame:Edit")]
        public ActionResult Delete(int? id)
        {
            Exame _exame;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _exame = uow.Exames.GetById(id.GetValueOrDefault());
                }
                return View(_exame);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ExameDelete", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Exame:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Exame exame)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Exames.Delete(exame.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ExameDelete", ex.Message);
                return View(exame);
            }
        }

        private void PopularPeriodicidadeData()
        {
            IEnumerable<Periodicidade> _periodicidades;
            List<AssignedPeriodicidade> viewModel;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                _periodicidades = uow.Periodicidades.GetAll();

                viewModel = new List<AssignedPeriodicidade>();

                foreach (var item in _periodicidades)
                {
                    viewModel.Add(new AssignedPeriodicidade
                    {
                        CodPeriodicidade = item.Id,
                        Descricao = item.Descricao,
                        Assigned = false
                    });
                }
                ViewBag.Periodicidades = new SelectList(viewModel, "CodPeriodicidade", "Descricao");
            }
        }


        private void PopularTipoExame(IEnumerable<TipoExame> assignedTipoExame)
        {
            IEnumerable<TipoExame> _tipoExame;
            List<AssignedTipoExame> viewModel;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                _tipoExame = uow.TipoExames.GetAll();
                viewModel = new List<AssignedTipoExame>();

                foreach (var item in _tipoExame)
                {

                    viewModel.Add(new AssignedTipoExame
                    {
                        Id = item.Id,
                        Descricao = item.Descricao,
                        Assigned = assignedTipoExame.Count(x => x.Id == item.Id) > 0
                    });
                }
            }
            ViewBag.TiposExames = viewModel;
        }
    }
}