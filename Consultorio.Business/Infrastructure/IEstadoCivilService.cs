using Consultorio.Domain.Models;
using System.Collections.Generic;

namespace Consultorio.Service.Infrastructure
{
    public interface IEstadoCivilService
    {
        IEnumerable<EstadoCivil> GetAll();
        EstadoCivil GetById(int id);
        void Insert(EstadoCivil estadoCivil);
        void Delete(int id);
        void Update(EstadoCivil estadoCivil);
        void Save();
    }
}
