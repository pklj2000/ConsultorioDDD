using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;

namespace Consultorio.Data.Infrastructure
{
    public interface IEmpresaRepository: IDisposable
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
