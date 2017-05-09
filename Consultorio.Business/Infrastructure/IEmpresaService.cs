using System.Collections.Generic;
using Consultorio.Domain.Models;

namespace Consultorio.Service.Infrastructure
{
    public interface IEmpresaService
    {
        IEnumerable<Empresa> GetAll();
        IEnumerable<Empresa> GetByNome(string nome);
        Empresa GetById(int id);
        void Insert(Empresa empresa);
        void Delete(int id);
        void Update(Empresa empresa);
        void Save();
    }
}
