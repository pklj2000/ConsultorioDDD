using System.Web.Mvc;
using System.Net;
using System.Data;
using Consultorio.Domain.Models;
using System.Collections;
using Consultorio.Service.Infrastructure;
using Consultorio.Service;

namespace Consultorio.Controllers
{
    public class EmpresaController : Controller
    {
        IEmpresaService _service = new EmpresaService();

        public ActionResult Index(string empresaNome)
        {
            IEnumerable empresas;

            if (string.IsNullOrEmpty(empresaNome))
                empresas = _service.GetAll();
            else
                empresas = _service.GetByNome(empresaNome);

            return View(empresas);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            int empresaId = id.GetValueOrDefault();

            Empresa empresa = _service.GetById(empresaId);
            if (empresa == null)
                return HttpNotFound();

            return View(empresa);
        }

        public ActionResult Create()
        {
            CarregarAtivo();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Insert(empresa);
                    _service.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", string.Format("Erro ao salvar empresa: {0}", ex.Message));
            }
            CarregarAtivo();
            return View(empresa);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int empresaId = id.GetValueOrDefault();
            Empresa empresa = _service.GetById(empresaId);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Empresa empresa)
        {
            _service.Delete(empresa.Id);
            _service.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int empresaId = id.GetValueOrDefault();
            Empresa empresa = _service.GetById(empresaId);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Update(empresa);
                    _service.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Erro ao salvar empresa");
            }
            return View(empresa);
        }

        private void CarregarAtivo()
        {
            var ativo = new SelectList(new[]
                                          {
                                              new {ID="0",Descricao="Não"},
                                              new{ID="1",Descricao="Sim"},
                                          },
                            "ID", "Descricao", 1);
            ViewBag.AtivoLista = ativo;
        }
    }
}
