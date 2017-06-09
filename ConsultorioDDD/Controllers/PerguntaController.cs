using Consultorio;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultorioDDD.Controllers
{
    public class PerguntaController : Controller
    {
        [CustomAuthorize(Roles = "Pergunta:View")]
        public ActionResult Index(int? grupoid)
        {
            if (TempData["ModelState"] != null)
            {
                ModelState.AddModelError("PerguntaGrupoIndex", TempData["ModelState"].ToString());
                TempData["ModelState"] = null;
            }

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    IEnumerable<Pergunta> _pergunta;
                    _pergunta = uow.Perguntas.GetByGrupo(grupoid.GetValueOrDefault());

                    return View(_pergunta);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PerguntaIndex", ex.Message);
                return View();
            }
        }

        [CustomAuthorize(Roles = "Pergunta:View")]
        public ActionResult Details(int? id)
        {
            Pergunta _pergunta;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _pergunta = uow.Perguntas.GetById(id.GetValueOrDefault());
                }
                return View(_pergunta);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [CustomAuthorize(Roles = "Pergunta:Edit")]
        public ActionResult Create(int? grupoid)
        {
            using ( var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    CarregarPerguntaGrupo(uow, grupoid.GetValueOrDefault());
                    CarregarTipoResposta();
                    CarregarRespostaObrigatoria();
                    return View(new Pergunta());
                }
                catch (Exception ex)
                {
                    TempData["ModelState"] = ex.Message;
                    return RedirectToAction("Index");
                }
            }
        }

        [CustomAuthorize(Roles = "Pergunta:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pergunta pergunta, int? grupoid)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    pergunta.Validate();

                    uow.Perguntas.Insert(pergunta);
                    uow.Complete();

                    return RedirectToAction("Index", new { grupoid = grupoid.GetValueOrDefault() });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", string.Format("Erro ao salvar grupo: {0}", ex.Message));
                }

                CarregarPerguntaGrupo(uow, grupoid.GetValueOrDefault());
                CarregarTipoResposta();
                CarregarRespostaObrigatoria();

                return View(pergunta);
            }
        }

        [CustomAuthorize(Roles = "Pergunta:Edit")]
        public ActionResult Edit(int? id, int? grupoid)
        {
            Pergunta _pergunta;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    CarregarPerguntaGrupo(uow, grupoid.GetValueOrDefault());
                    CarregarTipoResposta();
                    CarregarRespostaObrigatoria();

                    _pergunta = uow.Perguntas.GetById(id.GetValueOrDefault());
                }
                return View(_pergunta);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index", new { grupoid = grupoid });
            }

        }

        [CustomAuthorize(Roles = "Pergunta:Edit")]
        [HttpPost]
        public ActionResult Edit(Pergunta pergunta, int? grupoid)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    pergunta.Validate();

                    uow.Perguntas.Update(pergunta);
                    uow.Complete();

                    return RedirectToAction("Index", new { grupoid = grupoid });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("PerguntaEdit", ex.Message);

                    return View(pergunta);
                }
            }
        }

        [CustomAuthorize(Roles = "Pergunta:Edit")]
        public ActionResult Delete(int? id)
        {
            try
            {
                Pergunta _pergunta;
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _pergunta = uow.Perguntas.GetById(id.GetValueOrDefault());
                }
                return View(_pergunta);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Pergunta:Edit")]
        [HttpPost]
        public ActionResult Delete(Pergunta pergunta, int? grupoid)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Perguntas.Delete(pergunta.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index", new { grupoid = grupoid });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PerguntaDelete", ex.Message);
                return View(pergunta);
            }
        }

        public void CarregarPerguntaGrupo(UnitOfWork uow, int? grupoId )
        {
            IEnumerable<PerguntaGrupo> _grupos = uow.PerguntaGrupos.GetAll();
            ViewBag.PerguntaGrupos = new SelectList(_grupos, "Id", "Descricao", grupoId.GetValueOrDefault());
        }

        private void CarregarTipoResposta()
        {
            TipoPergunta tipoPergunta = new TipoPergunta();
            var tipoRespostas = new SelectList(tipoPergunta.TiposPergunta, "key", "value", 1);

            ViewBag.TipoResposta = tipoRespostas;
        }

        private void CarregarRespostaObrigatoria()
        {
            var respostaObrigatoria = new SelectList(new[]
                                          {
                                              new {ID="0",Descricao="Não"},
                                              new{ID="1",Descricao="Sim"},
                                          },
                            "ID", "Descricao", 1);
            ViewBag.RespostaObrigatoriaLista = respostaObrigatoria;
        }

    }
}