using System.Web.Mvc;
using System.Net;
using System.Data;
using Consultorio.Domain.Models;
using System.Collections;
using Consultorio.Data.Context;

namespace Consultorio.Controllers
{
    public class EmpresaController : Controller
    { 
        public ActionResult Index(string empresaNome)
        {
            IEnumerable empresas;

            using (var uow = new Data.UnitOfWork(new ConsultorioContext()))
            {
                if (string.IsNullOrEmpty(empresaNome))
                    empresas = uow.Empresas.GetAll();
                else
                    empresas = uow.Empresas.GetByNome(empresaNome);
            }
            return View(empresas);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Empresa empresa;
            int empresaId = id.GetValueOrDefault();

            using (var uow = new Data.UnitOfWork(new ConsultorioContext()))
            {
                empresa = uow.Empresas.GetById(empresaId);
            }

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
                using (var uow = new Data.UnitOfWork(new ConsultorioContext()))
                {
                    uow.Empresas.Insert(empresa);
                }
                return RedirectToAction("Index");
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            int empresaId = id.GetValueOrDefault();
            Empresa empresa;

            using (var uow = new Data.UnitOfWork(new ConsultorioContext()))
            {
                empresa = uow.Empresas.GetById(empresaId);
            }

            if (empresa == null)
                return HttpNotFound();

            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Empresa empresa)
        {
            using (var uow = new Data.UnitOfWork(new ConsultorioContext()))
            {
                uow.Empresas.Delete(empresa.Id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int empresaId = id.GetValueOrDefault();
            Empresa empresa;

            using (var uow = new Data.UnitOfWork(new ConsultorioContext()))
            {
                empresa = uow.Empresas.GetById(empresaId);
            }

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
                using (var uow = new Data.UnitOfWork(new ConsultorioContext()))
                {
                    uow.Empresas.Update(empresa);
                }
                return RedirectToAction("Index");
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
