using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;


namespace Consultorio.Data.Infrastructure
{
    public interface IDepartamentoRepository: IDisposable
    {
        IEnumerable<Departamento> GetAll();
        IEnumerable<Departamento> GetByEmpresa(int empresaId);
        Departamento GetById(int id);
        void Insert(Departamento departamento);
        void Delete(int id);
        void Update(Departamento departamento);
        void Save();
    }
}
