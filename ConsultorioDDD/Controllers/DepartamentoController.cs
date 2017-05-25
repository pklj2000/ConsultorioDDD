using System;
using System.Web.Mvc;
using System.Collections.Generic;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;
using Consultorio.Data;
using Consultorio;

namespace ConsultorioDDD.Controllers
{
    [CustomAuthorize(Roles = "Departamento:View")]
    public class DepartamentoController : Controller
    {
        public ActionResult Index(int? EmpresaId)
        {
            IEnumerable<Departamento> departamentos;
            int _empresaId = 0;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                _empresaId = EmpresaId.GetValueOrDefault();

                departamentos = uow.Departamentos.GetByEmpresa(_empresaId);

                IEnumerable<Empresa> empresas = uow.Empresas.GetAll();
                ViewBag.Empresas = new SelectList(empresas, "Id", "Nome", _empresaId);
            }
            ViewBag.EmpresaId = _empresaId;

            return View(departamentos);
        }

        [CustomAuthorize(Roles = "Departamento:Edit")]
        public ActionResult Create(int empresaId)
        {
            Empresa _empresa;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                _empresa = uow.Empresas.GetById(empresaId);
            }

            if (_empresa != null)
            {
                Departamento _departamento = new Departamento();
                _departamento.EmpresaId = empresaId;
                return View(_departamento);
            }

            ModelState.AddModelError("DepartamentoCreateKey", "Execute uma pesquisa para incluir");
            RedirectToAction("Index");
            return null;
        }

        [CustomAuthorize(Roles = "Departamento:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departamento departamento)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Departamentos.Insert(departamento);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", string.Format("Erro ao salvar empresa: {0}", ex.Message));
            }
            return View(departamento);
        }

        [CustomAuthorize(Roles = "Departamento:Edit")]
        public ActionResult Edit(int id)
        {
            Departamento departamento;

            using (var uow = new UnitOfWork(new ConsultorioContext()))
            {
                departamento = uow.Departamentos.GetById(id);
            }

            if (departamento != null)
            {
                return View(departamento);
            }
            else
            {
                ModelState.AddModelError("DepartamentoEdit", string.Format("Departamento não encontrado para o código {0}", id));
                RedirectToAction("Index");
                return null;
            }
        }

        [CustomAuthorize(Roles = "Departamento:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departamento departamento)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Departamentos.Update(departamento);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartamentoEdit", ex.Message);
            }
            return View(departamento);
        }

        public ActionResult Details(int id)
        {
            Departamento departamento;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    departamento = uow.Departamentos.GetById(id);
                }
            }
            catch (Exception ex)
            {
                departamento = null;
                ModelState.AddModelError("DepartamentoDetails", ex.Message);
            }
            return View(departamento);
        }

        [CustomAuthorize(Roles = "Departamento:Edit")]
        public ActionResult Delete(int id)
        {
            Departamento departamento;
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    departamento = uow.Departamentos.GetById(id);
                }
            }
            catch(Exception ex)
            {
                departamento = null;
                ModelState.AddModelError("DepartamentoDelete", ex.Message);
            }
            return View(departamento);
        }

        [CustomAuthorize(Roles = "Departamento:Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Departamento departamento)
        {
            try
            {
                using (var uow = new UnitOfWork(new ConsultorioContext()))
                {
                    uow.Departamentos.Delete(departamento.Id);
                    uow.Complete();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DepartamentoDelete", ex.Message);
            }
            return View(departamento);
        }
    }
}