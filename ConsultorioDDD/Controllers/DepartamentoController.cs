using System.Web.Mvc;
using Consultorio.Domain.Models;
using Consultorio.Service.Infrastructure;
using Consultorio.Service;
using System.Collections;
using System;

namespace ConsultorioDDD.Controllers
{
    public class DepartamentoController : Controller
    {
        IDepartamentoService _service = new DepartamentoService();
        IEmpresaService _serviceEmpresa = new EmpresaService();

        public ActionResult Index(int? EmpresaId)
        {
            IEnumerable departamentos;
            int _empresaId = EmpresaId.GetValueOrDefault();

            departamentos = _service.GetByEmpresa(_empresaId);

            IEnumerable empresas = _serviceEmpresa.GetAll();
            ViewBag.Empresas = new SelectList(empresas, "Id", "Nome", _empresaId);

            ViewBag.EmpresaId = _empresaId;

            return View(departamentos);
        }

        public ActionResult Create(int empresaId)
        {
            IEmpresaService _serviceEmpresa = new EmpresaService();
            Empresa _empresa = _serviceEmpresa.GetById(empresaId);


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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departamento departamento)
        {
            try
            {
                _service.Insert(departamento);
                _service.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", string.Format("Erro ao salvar empresa: {0}", ex.Message));
            }
            return View(departamento);
        }

        public ActionResult Edit(int id)
        {
            Departamento departamento;

            departamento = _service.GetById(id);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departamento departamento)
        {
            try
            {
                _service.Update(departamento);
                _service.Save();
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
                departamento = _service.GetById(id);
            }
            catch (Exception ex)
            {
                departamento = null;
                ModelState.AddModelError("DepartamentoDetails", ex.Message);
            }
            return View(departamento);
        }

        public ActionResult Delete(int id)
        {
            Departamento departamento;
            try
            {
                departamento = _service.GetById(id);
            }
            catch(Exception ex)
            {
                departamento = null;
                ModelState.AddModelError("DepartamentoDelete", ex.Message);
            }
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Departamento departamento)
        {
            try
            {
                _service.Delete(departamento.Id);
                _service.Save();
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