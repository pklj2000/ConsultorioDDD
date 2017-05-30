using Consultorio;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultorioDDD.Controllers
{
    public class SituacaoFuncionarioController : Controller
    {
        [CustomAuthorize(Roles = "SituacaoFuncionario:View")]
        public ActionResult Index()
        {
            IEnumerable<SituacaoFuncionario> _situacoes;

            if (TempData["ModelState"] != null)
            {
                ModelState.AddModelError("cargoIndex", TempData["ModelState"].ToString());
                TempData["ModelState"] = null;
            }

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _situacoes = uow.SituacaoFuncionario.GetAll();
                }
                return View(_situacoes);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("SituacaoFuncionarioIndex", ex.Message);
                return View();
            }
        }

        public ActionResult Details(int? id)
        {
            SituacaoFuncionario _situacao;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _situacao = uow.SituacaoFuncionario.GetById(id.GetValueOrDefault());
                }
                return View(_situacao);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "SituacaoFuncionario:Edit")]
        public ActionResult Create()
        {
            return View(new SituacaoFuncionario());
        }

        [CustomAuthorize(Roles = "SituacaoFuncionario:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SituacaoFuncionario situacao)
        {
            try
            {
                situacao.Validate();

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.SituacaoFuncionario.Insert(situacao);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("SituacaoFuncionarioCreate", ex.Message);
                return View(situacao);
            }
        }

        [CustomAuthorize(Roles = "SituacaoFuncionario:Edit")]
        public ActionResult Edit(int? id)
        {
            SituacaoFuncionario _situacao;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _situacao = uow.SituacaoFuncionario.GetById(id.GetValueOrDefault());
                }
                return View(_situacao);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "SituacaoFuncionario:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SituacaoFuncionario situacao)
        {
            try
            {
                situacao.Validate();

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.SituacaoFuncionario.Update(situacao);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("SituacaoFuncionarioEdit", ex.Message);
                return View(situacao);
            }
        }

        [CustomAuthorize(Roles = "SituacaoFuncionario:Edit")]
        public ActionResult Delete(int? id)
        {
            SituacaoFuncionario _situacao;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _situacao = uow.SituacaoFuncionario.GetById(id.GetValueOrDefault());
                }
                return View(_situacao);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "SituacaoFuncionario:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SituacaoFuncionario situacao)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.SituacaoFuncionario.Delete(situacao.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("SituacaoFuncionarioDelete", ex.Message);
                return View(situacao);
            }
        }
    }
}