using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;
using Consultorio.Service.Infrastructure;
using Consultorio.Data.Repository;
using Consultorio.Data.Infrastructure;

namespace Consultorio.Service
{
    public class TipoExameService : ITipoExameService
    {
        ITipoExameRepository _repository = new TipoExameRepository();

        public IEnumerable<TipoExame> GetAll()
        {
            return _repository.GetAll();
        }

        public TipoExame GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(TipoExame tipoExame)
        {
            tipoExame.Validate();
            _repository.Insert(tipoExame);
            _repository.Save();
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(TipoExame tipoExame)
        {
            tipoExame.Validate();
            _repository.Update(tipoExame);
            _repository.Save();

        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

    }
}
