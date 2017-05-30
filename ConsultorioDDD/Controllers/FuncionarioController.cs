using Consultorio;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultorioDDD.Controllers
{
    public class FuncionarioController : Controller
    {
        [CustomAuthorize(Roles = "Funcionario:View")]
        public ActionResult Index(int? empresaId)
        {
            IEnumerable<Funcionario> _funcionarios;

            if (TempData["ModelState"] != null)
            {
                ModelState.AddModelError("FuncionarioIndex", TempData["ModelState"].ToString());
                TempData["ModelState"] = null;
            }

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _funcionarios = uow.Funcionario.GetByEmpresa(empresaId.GetValueOrDefault());

                    IEnumerable<Empresa> _empresas = uow.Empresas.GetAll();
                    ViewBag.Empresas = new SelectList(_empresas, "Id", "Nome", empresaId.GetValueOrDefault());
                }
                return View(_funcionarios);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("FuncionarioIndex", ex.Message);
                return View();
            }
        }

        [CustomAuthorize(Roles = "Funcionario:View")]
        public ActionResult Details(int? id)
        {
            Funcionario _funcionario;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _funcionario = uow.Funcionario.GetById(id.GetValueOrDefault());
                }
                return View(_funcionario);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [CustomAuthorize(Roles = "Funcionario:Edit")]
        public ActionResult Create(int? empresaId)
        {
            var _funcionario = new Funcionario();

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                
                CarregarEmpresa(uow, empresaId);
                CarregarDepartamento(uow, empresaId, 0);
                CarregarCargo(uow, empresaId, 0, 0);
                CarregarPeriodicidade(uow, empresaId);
                CarregarEstadoCivil(uow, 0);
                CarregarSituacaoFuncionario(uow, 0);
                CarregarSexos("");
            }
            return View(_funcionario);
        }

        [CustomAuthorize(Roles = "Funcionario:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    funcionario.Validate();

                    uow.Funcionario.Insert(funcionario);
                    uow.Complete();

                    return RedirectToAction("Index", new { empresaId = funcionario.EmpresaId });
                }
                catch (Exception ex)
                {

                    CarregarEmpresa(uow, funcionario.EmpresaId);
                    CarregarDepartamento(uow, funcionario.EmpresaId, funcionario.DepartamentoId);
                    CarregarCargo(uow, funcionario.EmpresaId, funcionario.DepartamentoId, funcionario.CargoId);
                    CarregarPeriodicidade(uow, funcionario.EmpresaId);
                    CarregarEstadoCivil(uow, 0);
                    CarregarSituacaoFuncionario(uow, 0);
                    CarregarSexos(funcionario.Sexo);

                    ModelState.AddModelError("", string.Format("Erro ao salvar empresa: {0}", ex.Message));
                }
                return View(funcionario);
            }
        }

        [CustomAuthorize(Roles = "Cargo:Edit")]
        public ActionResult Edit(int? id)
        {
            Funcionario _funcionario;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _funcionario = uow.Funcionario.GetById(id.GetValueOrDefault());

                    CarregarEmpresa(uow, _funcionario.EmpresaId);
                    CarregarDepartamento(uow, _funcionario.EmpresaId, _funcionario.DepartamentoId);
                    CarregarCargo(uow, _funcionario.EmpresaId, _funcionario.DepartamentoId, _funcionario.CargoId);
                    CarregarPeriodicidade(uow, _funcionario.EmpresaId);
                    CarregarEstadoCivil(uow, _funcionario.EstadoCivilId);
                    CarregarSituacaoFuncionario(uow, _funcionario.SituacaoFuncionarioId);
                    CarregarSexos(_funcionario.Sexo);
                }
                return View(_funcionario);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [CustomAuthorize(Roles = "Funcionario:Edit")]
        [HttpPost]
        public ActionResult Edit(Funcionario funcionario)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    funcionario.Validate();

                    uow.Funcionario.Update(funcionario);
                    uow.Complete();

                    return RedirectToAction("Index", new { empresaId = funcionario.EmpresaId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("FuncionarioEdit", ex.Message);

                    CarregarEmpresa(uow, funcionario.EmpresaId);
                    CarregarDepartamento(uow, funcionario.EmpresaId, funcionario.DepartamentoId);
                    CarregarCargo(uow, funcionario.EmpresaId, funcionario.DepartamentoId, funcionario.CargoId);
                    CarregarPeriodicidade(uow, funcionario.EmpresaId);
                    CarregarEstadoCivil(uow, funcionario.EstadoCivilId);
                    CarregarSituacaoFuncionario(uow, funcionario.SituacaoFuncionarioId);
                    CarregarSexos(funcionario.Sexo);
                    return View(funcionario);
                }
            }
        }

        [CustomAuthorize(Roles = "Funcionario:Edit")]
        public ActionResult Delete(int? id)
        {
            try
            {
                Funcionario _funcionario;
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _funcionario = uow.Funcionario.GetById(id.GetValueOrDefault());
                }
                return View(_funcionario);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Funcionario:Edit")]
        [HttpPost]
        public ActionResult Delete(Funcionario funcionario)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Funcionario.Delete(funcionario.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index", new { empresaId = funcionario.EmpresaId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("FuncionarioDelete", ex.Message);
                return View(funcionario);
            }
        }

        public JsonResult GetDepartamento(int empresaId)
        {
            IEnumerable<Departamento> _departamento;
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                _departamento = uow.Departamentos.GetByEmpresa(empresaId);
            }
            return Json(new SelectList(_departamento, "Id", "Descricao"));
        }

        public JsonResult GetCargo(int departamentoId)
        {
            IEnumerable<Cargo> _cargo;
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                _cargo = uow.Cargo.GetByDepartamento(departamentoId);
            }
            return Json(new SelectList(_cargo, "Id", "Descricao"));
        }

        public void CarregarEmpresa(UnitOfWork uow, int? empresaId)
        {
            IEnumerable<Empresa> empresas = uow.Empresas.GetAll();
            ViewBag.Empresas = new SelectList(empresas, "Id", "Nome", empresaId);
        }

        public void CarregarDepartamento(UnitOfWork uow, int? empresaId, int? departamentoId)
        {
            IEnumerable<Departamento> departamento = uow.Departamentos.GetByEmpresa(empresaId.GetValueOrDefault());
            ViewBag.Departamentos = new SelectList(departamento, "Id", "Descricao", departamentoId.GetValueOrDefault());
        }

        public void CarregarCargo(UnitOfWork uow, int? empresaId, int? departamentoId, int? cargoId)
        {
            IEnumerable<Cargo> cargo = uow.Cargo.GetByDepartamento(departamentoId.GetValueOrDefault());
            ViewBag.Cargos = new SelectList(cargo, "Id", "Descricao", cargoId.GetValueOrDefault());
        }

        public void CarregarPeriodicidade(UnitOfWork uow, int? empresaId)
        {
            IEnumerable<Periodicidade> _periodicidades = uow.Periodicidades.GetAll();
            ViewBag.Periodicidades = new SelectList(_periodicidades, "Id", "Descricao", empresaId.GetValueOrDefault());
        }

        public void CarregarEstadoCivil(UnitOfWork uow, int? estadoCivilId)
        {
            IEnumerable<EstadoCivil> _estadoCivil = uow.EstadoCivis.GetAll();
            ViewBag.EstadoCivil = new SelectList(_estadoCivil, "Id", "Descricao", estadoCivilId.GetValueOrDefault());
        }

        public void CarregarSituacaoFuncionario(UnitOfWork uow, int? situacaoId)
        {
            IEnumerable<SituacaoFuncionario> _situacao = uow.SituacaoFuncionario.GetAll();
            ViewBag.SituacaoFuncionario = new SelectList(_situacao, "Id", "Descricao", situacaoId.GetValueOrDefault());
        }

        public void CarregarSexos(string sexoId)
        {
            var sexos = new List<SelectListItem>
            {
                new SelectListItem{ Text="Masculino", Value = "M" },
                new SelectListItem{ Text="Feminino", Value = "F" }
            };

            ViewBag.Sexos = new SelectList(sexos, "Value", "Text", sexoId);
        }
    }
}