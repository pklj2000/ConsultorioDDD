using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;
using Consultorio.Service.Infrastructure;
using Consultorio.Data.Infrastructure;
using Consultorio.Data.Repository;

namespace Consultorio.Service
{
    public class EmpresaService : IEmpresaService
    {
        IEmpresaRepository _repository = new EmpresaRepository();

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Empresa> GetAll()
        {
            return _repository.GetAll();
        }

        public Empresa GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Empresa> GetByNome(string nome)
        {
            return _repository.GetByNome(nome);
        }

        public void Insert(Empresa empresa)
        {
            _repository.Insert(empresa);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Empresa empresa)
        {
            _repository.Update(empresa);
        }
    }
}
