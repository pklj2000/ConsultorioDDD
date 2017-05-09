using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;

namespace Consultorio.Data.Infrastructure
{
    public interface IEstadoCivilRepository: IDisposable
    {
        IEnumerable<EstadoCivil> GetAll();
        EstadoCivil GetById(int id);
        void Insert(EstadoCivil estadoCivil);
        void Delete(int id);
        void Update(EstadoCivil estadoCivil);
        void Save();
    }
}
