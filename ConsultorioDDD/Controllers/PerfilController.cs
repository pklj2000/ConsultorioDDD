using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Data.ViewModel;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Consultorio.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {
            IEnumerable<Perfil> perfis;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    perfis = uow.Perfis.GetAll();
                }
                return View(perfis);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("PerfilEdit", ex.Message);
                perfis = new List<Perfil>();
                return View(perfis);
            }
            
        }

        public ActionResult Details(int? id)
        {
            Perfil perfil;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    perfil = uow.Perfis.GetById(id.GetValueOrDefault());
                }

                return View(perfil);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("PerfilDetails", ex.Message);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            PopularTransacaoData();

            Perfil perfil = new Perfil();
            return View(perfil);
        }

        [HttpPost]
        public ActionResult Create(Perfil perfil, string[] transacaoAssociado)
        {
            try
            {
                Transacao transacao;

                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    if (transacaoAssociado != null)
                    {
                        if (transacaoAssociado.Length > 0 && perfil.Transacao == null) perfil.Transacao = new List<Transacao>();
                        foreach (string item in transacaoAssociado)
                        {
                            transacao = new Transacao();
                            int codTransacao = Convert.ToInt32(item);

                            transacao = uow.Transacoes.GetById(codTransacao);
                            perfil.Transacao.Add(transacao);
                        }
                    }
                    uow.Perfis.Insert(perfil);
                    uow.Complete();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao salvar informações. Contate o resposával pelo sistema");
            }

            return View(perfil);
        }

        public ActionResult Edit(int? id)
        {
            Perfil perfil;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    perfil = uow.Perfis.GetById(id.GetValueOrDefault());

                    if (perfil == null)
                    {
                        return HttpNotFound();
                    }

                    PopularTransacaoData(perfil);
                    return View(perfil);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Erro ao carregar informações. Contate o resposával pelo sistema");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Perfil perfil, string[] transacaoAssociado)
        {
            Transacao _transacao;
            int _transacaoId;
            perfil.Transacao = new List<Transacao>();

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    if (transacaoAssociado != null)
                    {
                        for (int i = 0; i <= transacaoAssociado.Count() - 1; i++)
                        {

                            _transacaoId = Convert.ToInt32(transacaoAssociado[i]);
                            _transacao = uow.Transacoes.GetById(_transacaoId);
                            perfil.Transacao.Add(_transacao);
                        }
                    }
                    uow.Perfis.Update(perfil);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PerfilEdit", ex.Message);
                return Edit(perfil.Id);
            }
        }

        public ActionResult Delete(int? id)
        {
            Perfil perfil;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    perfil = uow.Perfis.GetById(id.GetValueOrDefault());
                }

                if (perfil == null)
                {
                    return HttpNotFound();
                }
                return View(perfil);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("PerfilDelete", ex.Message);
                return RedirectToAction("Index");
            }
        }

        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Perfis.Delete(id.GetValueOrDefault());
                    uow.Complete();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PerfilDelete", ex.Message);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        private void PopularTransacaoData(Perfil perfil)
        {
            IEnumerable<Transacao> _transacoes;
            var viewModel = new List<AssignedTransacao>();
            var cargoExame = new HashSet<int>(perfil.Transacao.Select(c => c.Id));

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                _transacoes = uow.Transacoes.GetAll();
            }

            foreach (var item in _transacoes)
            {
                viewModel.Add(new AssignedTransacao
                {
                    CodTransacao = item.Id,
                    Descricao = item.Descricao,
                    Assigned = cargoExame.Contains(item.Id)
                });
            }
            ViewBag.Transacoes = viewModel;
        }

        private void PopularTransacaoData()
        {
            IEnumerable<Transacao> _transacoes;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                _transacoes = uow.Transacoes.GetAll();
                var _transacoesAssociadas = new List<AssignedTransacao>();

                foreach (var item in _transacoes)
                {
                    _transacoesAssociadas.Add(new AssignedTransacao
                    {
                        CodTransacao = item.Id,
                        Descricao = item.Descricao,
                        Assigned = false
                    });
                }
                ViewBag.Transacoes = _transacoesAssociadas;
            }
        }
    }
}