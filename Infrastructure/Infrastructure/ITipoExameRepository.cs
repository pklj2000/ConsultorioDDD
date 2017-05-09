using Consultorio.Domain.Models;
using System;
using System.Collections.Generic;

namespace Consultorio.Data.Infrastructure
{
    public interface ITipoExameRepository: IDisposable
    {
        IEnumerable<TipoExame> GetAll();
        TipoExame GetById(int id);
        void Insert(TipoExame tipoExame);
        void Delete(int id);
        void Update(TipoExame tipoExame);
        void Save();
    }
}
