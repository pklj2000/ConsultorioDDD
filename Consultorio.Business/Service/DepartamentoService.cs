using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;
using Consultorio.Data.Infrastructure;
using Consultorio.Service.Infrastructure;
using Consultorio.Data.Repository;

namespace Consultorio.Service
{
    public class DepartamentoService : IDepartamentoService
    {
        IDepartamentoRepository _repository = new DepartamentoRepository();

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Departamento> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Departamento> GetByEmpresa(int empresaId)
        {
            return _repository.GetByEmpresa(empresaId);
        }

        public Departamento GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Departamento departamento)
        {
            _repository.Insert(departamento);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Departamento departamento)
        {
            _repository.Update(departamento);
        }
    }
}
