using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Consultorio.Controllers
{
    public class TransacaoController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Transacao> _transacao;

            using (var uow = new Data.UnitOfWork(new ConsultorioContext()))
            {
                _transacao = uow.Transacoes.GetAll();
            }
            return View(_transacao);
        }

        public ActionResult Create()
        {
            Transacao transacao = new Transacao();

            return View(transacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transacao transacao)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Transacoes.Insert(transacao);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TransacaoCreate", ex.Message);
            }
            return View(transacao);
        }

        public ActionResult Details(int? id)
        {
            Transacao transacao;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    transacao = uow.Transacoes.GetById(id.GetValueOrDefault());
                }

                if (transacao == null)
                    throw new Exception(string.Format("Erro ao obter dados do tipo de exame: {0}", id.GetValueOrDefault()));

                return View(transacao);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TransacaoDetails", ex.Message);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int? id)
        {
            Transacao transacao;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    transacao = uow.Transacoes.GetById(id.GetValueOrDefault());
                }

                if (transacao == null)
                    throw new Exception(string.Format("Ocorreu um erro ao obter dados para o tipo de exame {0}", id.GetValueOrDefault()));

                return View(transacao);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TransacaoEdit", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transacao transacao)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Transacoes.Update(transacao);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TransacaoEdit", ex.Message);
                return View(transacao);
            }
        }

        public ActionResult Delete(int? id)
        {
            Transacao _transacao;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _transacao = uow.Transacoes.GetById(id.GetValueOrDefault());
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("TransacaoDelete", ex.Message);
            }
            return View(_transacao);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Transacao transacao)
        {
            using (var uow = new Data.UnitOfWork(new ConsultorioContext()))
            {
                uow.Transacoes.Delete(transacao.Id);
                uow.Complete();
            }
            return RedirectToAction("Index");
        }
    }
}