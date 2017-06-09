using Consultorio;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultorioDDD.Controllers
{
    public class PerguntaGrupoController : Controller
    {
        [CustomAuthorize(Roles = "PerguntaGrupo:View")]
        public ActionResult Index()
        {
            if(TempData["ModelState"] != null)
            {
                ModelState.AddModelError("PerguntaGrupoIndex", TempData["ModelState"].ToString());
                TempData["ModelState"] = null;
            }

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    IEnumerable<PerguntaGrupo> _grupos;
                    _grupos = uow.PerguntaGrupos.GetAll();

                    return View(_grupos);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("PerguntaGrupoIndex", ex.Message);
                return View();
            }
        }

        [CustomAuthorize(Roles = "PerguntaGrupo:View")]
        public ActionResult Details(int? id)
        {
            PerguntaGrupo _grupo;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _grupo = uow.PerguntaGrupos.GetById(id.GetValueOrDefault());
                }
                return View(_grupo);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [CustomAuthorize(Roles = "PerguntaGrupo:Edit")]
        public ActionResult Create()
        {
            return View(new PerguntaGrupo());
        }

        [CustomAuthorize(Roles = "PerguntaGrupo:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PerguntaGrupo grupo)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    grupo.Validate();

                    uow.PerguntaGrupos.Insert(grupo);
                    uow.Complete();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", string.Format("Erro ao salvar grupo: {0}", ex.Message));
                }
                return View(grupo);
            }
        }

        [CustomAuthorize(Roles = "PerguntaGrupo:Edit")]
        public ActionResult Edit(int? id)
        {
            PerguntaGrupo _grupo;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _grupo = uow.PerguntaGrupos.GetById(id.GetValueOrDefault());
                }
                return View(_grupo);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [CustomAuthorize(Roles = "PerguntaGrupo:Edit")]
        [HttpPost]
        public ActionResult Edit(PerguntaGrupo grupo)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    grupo.Validate();

                    uow.PerguntaGrupos.Update(grupo);
                    uow.Complete();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("PerguntaGrupoEdit", ex.Message);

                    return View(grupo);
                }
            }
        }

        [CustomAuthorize(Roles = "PerguntaGrupo:Edit")]
        public ActionResult Delete(int? id)
        {
            try
            {
                PerguntaGrupo _grupo;
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _grupo = uow.PerguntaGrupos.GetById(id.GetValueOrDefault());
                }
                return View(_grupo);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] =  ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "PerguntaGrupo:Edit")]
        [HttpPost]
        public ActionResult Delete(PerguntaGrupo grupo)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.PerguntaGrupos.Delete(grupo.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PerguntaGrupoDelete", String.Format("Operação não foi concluída. Verifique se existem perguntas associadas: {0}", ex.Message));
                return View(grupo);
            }
        }
    }
}