using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;
using Consultorio.Service.Infrastructure;
using Consultorio.Data.Infrastructure;
using Consultorio.Data.Repository;

namespace Consultorio.Service
{
    public class EstadoCivilService : IEstadoCivilService
    {
        IEstadoCivilRepository _repository = new EstadoCivilRepository();

        public IEnumerable<EstadoCivil> GetAll()
        {
            return _repository.GetAll();
        }

        public EstadoCivil GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(EstadoCivil estadoCivil)
        {
            estadoCivil.Validate();
            _repository.Insert(estadoCivil);
            _repository.Save();
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(EstadoCivil estadoCivil)
        {
            estadoCivil.Validate();
            _repository.Update(estadoCivil);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

    }
}
