using Consultorio;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultorioDDD.Controllers
{
    public class AtendimentoController : Controller
    {
        [CustomAuthorize(Roles = "Atendimento:View")]
        public ActionResult Index()
        {
            IEnumerable<Atendimento> atendimentos;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                atendimentos = uow.Atendimentos.GetAll();
            }

            if (TempData["ModelError"] != null)
            {
                ModelState.AddModelError("AtendimentoIndex", TempData["ModelError"].ToString());
                TempData["ModelError"] = null;
            }

            return View(atendimentos);
        }

        [CustomAuthorize(Roles = "Atendimento:View")]
        public ActionResult Details(int? id)
        {
            try
            {
                Atendimento _atendimento;
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _atendimento = uow.Atendimentos.GetById(id.GetValueOrDefault());
                }

                if (_atendimento == null)
                {
                    throw new Exception("Atendimento não encontrado");
                }

                return View(_atendimento);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Atendimento:Edit")]
        public ActionResult Create(int? empresaId)
        {
            CarregarEmpresas(empresaId);
            ViewBag.Funcionarios = CarregarFuncionarios(empresaId.GetValueOrDefault());
            CarregarTipoExames();

            Atendimento atendimento = new Atendimento();
            atendimento.DataAtendimento = DateTime.Now;
            return View(atendimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Atendimento atendimento)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    if (atendimento.FuncionarioId > 0)
                    {
                        atendimento.Funcionario = uow.Funcionario.GetById(atendimento.FuncionarioId);
                        atendimento.DepartamentoId = atendimento.Funcionario.DepartamentoId;
                        atendimento.CargoId = atendimento.Funcionario.CargoId;
                    }
                    atendimento.Validate();

                    uow.Atendimentos.Insert(atendimento);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                CarregarEmpresas(atendimento.EmpresaId);
                ViewBag.Funcionarios = CarregarFuncionarios(atendimento.EmpresaId);
                CarregarTipoExames();

                ModelState.AddModelError("AtendimentoCreate", ex.Message);
                return View(atendimento);
            }
        }

        [CustomAuthorize(Roles = "Atendimento:Edit")]
        public ActionResult Delete(int? id)
        {
            try
            {
                Atendimento _atendimento;
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _atendimento = uow.Atendimentos.GetById(id.GetValueOrDefault());
                }

                if (_atendimento == null)
                {
                    throw new Exception("Atendimento não encontrado");
                }

                return View(_atendimento);
            }
            catch(Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Atendimento atendimento)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Atendimentos.Delete(atendimento.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AtendimentoDelete", ex.Message);
                return View(atendimento);
            }
        }

        private void CarregarEmpresas(int? empresaId)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                var empresas = uow.Empresas.GetAll();
                ViewBag.Empresas = new SelectList(empresas, "Id", "Nome", empresaId.GetValueOrDefault());
            }
        }

        private SelectList CarregarFuncionarios(int empresaId)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                var funcionarios = uow.Funcionario.GetByEmpresa(empresaId);
               return new SelectList(funcionarios, "Id", "Nome");
            }
        }

        private void CarregarTipoExames()
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                var tiposExames = uow.TipoExames.GetAll();
                ViewBag.TiposExames = new SelectList(tiposExames, "Id", "Descricao");
            }
        }

        public JsonResult CarregarFuncionariosJSON(int? id)
        {
            return Json(CarregarFuncionarios(id.GetValueOrDefault()));
        }
    }
}