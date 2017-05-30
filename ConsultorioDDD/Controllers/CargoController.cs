using Consultorio;
using Consultorio.Data;
using Consultorio.Data.Context;
using Consultorio.Data.ViewModel;
using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultorioDDD.Controllers
{
    public class CargoController : Controller
    {
        [CustomAuthorize(Roles = "Cargo:View")]
        public ActionResult Index(int? empresaId)
        {
            IEnumerable<Cargo> _cargos;

            if (TempData["ModelState"] != null)
            {
                ModelState.AddModelError("cargoIndex", TempData["ModelState"].ToString());
                TempData["ModelState"] = null;
            }

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    if (empresaId.HasValue)
                    {
                        _cargos = uow.Cargo.GetByEmpresa(empresaId.GetValueOrDefault());
                    }
                    else
                        _cargos = new List<Cargo>();

                    IEnumerable<Empresa> empresas = uow.Empresas.GetAll();
                    ViewBag.Empresas = new SelectList(empresas, "Id", "Nome", empresaId.GetValueOrDefault());
                }
                return View(_cargos);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("CargoIndex", ex.Message);
                return View();
            }
        }


        [CustomAuthorize(Roles = "Cargo:View")]
        public ActionResult Details(int? id)
        {
            Cargo _cargo;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _cargo = uow.Cargo.GetById(id.GetValueOrDefault());
                }
                return View(_cargo);
            }
            catch(Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        [CustomAuthorize(Roles = "Cargo:Edit")]
        public ActionResult Create(int? empresaId)
        {
            var _cargo = new Cargo();

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                IEnumerable<Empresa> empresas = uow.Empresas.GetAll();
                ViewBag.Empresas = new SelectList(empresas, "Id", "Nome", empresaId.GetValueOrDefault());

                CarregarDepartamento(uow, empresaId, 0);
                CarregarPeriodicidade(uow, empresaId);
                CarregarExame(uow);
                CarregarRisco(uow);

            }
            return View(_cargo);
        }

        [CustomAuthorize(Roles = "Departamento:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cargo cargo, string[] exameAssociado, string[] riscoAssociado)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    cargo.Validate();

                    //Registrando os exames associados
                    //----------------------------------------------------
                    cargo.Exames = new List<Exame>();
                    if (exameAssociado != null)
                    {
                        foreach (string item in exameAssociado)
                        {
                            cargo.Exames.Add(uow.Exames.GetById(Convert.ToInt32(item)));
                        }
                    }
                    //----------------------------------------------------

                    //Registrando os riscos associados
                    //----------------------------------------------------
                    cargo.Riscos = new List<Risco>();
                    if (riscoAssociado != null)
                    {
                        foreach (string item in riscoAssociado)
                        {
                            cargo.Riscos.Add(uow.Riscos.GetById(Convert.ToInt32(item)));
                        }
                    }
                    //----------------------------------------------------

                    uow.Cargo.Insert(cargo);
                    uow.Complete();

                    return RedirectToAction("Index", new { empresaId = cargo.EmpresaId });
                }
                catch (Exception ex)
                {
                    CarregarDepartamento(uow, cargo.EmpresaId, cargo.DepartamentoId);
                    CarregarPeriodicidade(uow, cargo.EmpresaId);
                    CarregarExame(uow);
                    CarregarRisco(uow);
                    ModelState.AddModelError("", string.Format("Erro ao salvar empresa: {0}", ex.Message));
                }
                return View(cargo);
            }
        }

        [CustomAuthorize(Roles = "Cargo:Edit")]
        public ActionResult Edit(int? id)
        {
            Cargo _cargo;

            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _cargo = uow.Cargo.GetById(id.GetValueOrDefault());

                    CarregarEmpresa(uow, _cargo.EmpresaId);
                    CarregarDepartamento(uow, _cargo.EmpresaId, _cargo.DepartamentoId);
                    CarregarPeriodicidade(uow, _cargo.EmpresaId);
                    CarregarExame(uow, _cargo.ExamesKeys);
                    CarregarRisco(uow, _cargo.RiscosKeys);
                    
                }
                return View(_cargo);
            }
            catch (Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [CustomAuthorize(Roles = "Cargo:Edit")]
        [HttpPost]
        public ActionResult Edit(Cargo cargo, string[] exameAssociado, string[] riscoAssociado)
        {
            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                try
                {
                    cargo.Validate();

                    cargo.Exames = new List<Exame>();
                    cargo.ExamesKeys = new HashSet<int>();
                    foreach (string item in exameAssociado)
                    {
                        cargo.Exames.Add(uow.Exames.GetById(Convert.ToInt32(item)));
                        cargo.ExamesKeys.Add(Convert.ToInt32(item));
                    }

                    cargo.Riscos = new List<Risco>();
                    cargo.RiscosKeys = new HashSet<int>();
                    foreach (string item in riscoAssociado)
                    {
                        cargo.Riscos.Add(uow.Riscos.GetById(Convert.ToInt32(item)));
                        cargo.RiscosKeys.Add(Convert.ToInt32(item));
                    }

                    uow.Cargo.Update(cargo);
                    uow.Complete();

                    return RedirectToAction("Index", new { empresaId = cargo.EmpresaId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("CargoEdit", ex.Message);

                    CarregarEmpresa(uow, cargo.EmpresaId);
                    CarregarDepartamento(uow, cargo.DepartamentoId, cargo.DepartamentoId);
                    CarregarPeriodicidade(uow, cargo.EmpresaId);
                    CarregarExame(uow, cargo.ExamesKeys);
                    CarregarRisco(uow, cargo.RiscosKeys);
                    return View(cargo);
                }
            }
        }

        [CustomAuthorize(Roles = "Cargo:Edit")]
        public ActionResult Delete(int? id)
        {
            try
            {
                Cargo _cargo;
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    _cargo = uow.Cargo.GetById(id.GetValueOrDefault());
                }
                return View(_cargo);
            }
            catch(Exception ex)
            {
                TempData["ModelState"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [CustomAuthorize(Roles = "Cargo:Edit")]
        [HttpPost]
        public ActionResult Delete(Cargo cargo)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Cargo.Delete(cargo.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index", new { empresaId = cargo.EmpresaId });
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("CargoDelete", ex.Message);
                return View(cargo);
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

        public void CarregarEmpresa(UnitOfWork uow, int empresaId)
        {
            IEnumerable<Empresa> empresas = uow.Empresas.GetAll();
            ViewBag.Empresas = new SelectList(empresas, "Id", "Nome", empresaId);
        }

        public void CarregarDepartamento(UnitOfWork uow, int? empresaId, int? departamentoId)
        {
            IEnumerable<Departamento> departamento = uow.Departamentos.GetByEmpresa(empresaId.GetValueOrDefault());
            ViewBag.Departamentos = new SelectList(departamento, "Id", "Descricao", departamentoId.GetValueOrDefault());
        }

        public void CarregarPeriodicidade(UnitOfWork uow, int? empresaId)
        {
            IEnumerable<Periodicidade> _periodicidades = uow.Periodicidades.GetAll();
            ViewBag.Periodicidades = new SelectList(_periodicidades, "Id", "Descricao", empresaId.GetValueOrDefault());
        }

        public void CarregarExame(UnitOfWork uow)
        {
            IEnumerable<Exame> _exames;
            var viewModel = new List<AssignedExame>();

            _exames = uow.Exames.GetAll();
            foreach (var item in _exames)
            {
                viewModel.Add(new AssignedExame
                {
                    CodExame = item.Id,
                    Descricao = item.Descricao,
                    Assigned = false
                });
            }
            ViewBag.Exames = viewModel;
        }

        public void CarregarExame(UnitOfWork uow, HashSet<int> assignedExames)
        {
            IEnumerable<Exame> _exames;
            var viewModel = new List<AssignedExame>();

            _exames = uow.Exames.GetAll();
            foreach (var item in _exames)
            {
                viewModel.Add(new AssignedExame
                {
                    CodExame = item.Id,
                    Descricao = item.Descricao,
                    Assigned = assignedExames.Contains(item.Id)
                });
            }
            ViewBag.Exames = viewModel;
        }

        public void CarregarRisco(UnitOfWork uow)
        {
            IEnumerable<Risco> _riscos;
            var riscoVM = new List<AssignedRisco>();

            _riscos = uow.Riscos.GetAll();
            foreach (var item in _riscos)
            {
                riscoVM.Add(new AssignedRisco
                {
                    CodRisco = item.Id,
                    Descricao = item.Descricao,
                    Assigned = false
                });
            }
            ViewBag.Riscos = riscoVM;
        }

        public void CarregarRisco(UnitOfWork uow, HashSet<int> assignedRiscos)
        {
            IEnumerable<Risco> _riscos;
            var riscoVM = new List<AssignedRisco>();

            _riscos = uow.Riscos.GetAll();
            foreach (var item in _riscos)
            {
                riscoVM.Add(new AssignedRisco
                {
                    CodRisco = item.Id,
                    Descricao = item.Descricao,
                    Assigned = assignedRiscos.Contains(item.Id)
                });
            }
            ViewBag.Riscos = riscoVM;
        }
    }
}