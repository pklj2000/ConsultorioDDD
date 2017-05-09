using Consultorio.Domain.Models;
using System.Collections.Generic;

namespace Consultorio.Service.Infrastructure
{
    public interface ITipoExameService
    {
        IEnumerable<TipoExame> GetAll();
        TipoExame GetById(int id);
        void Insert(TipoExame tipoExame);
        void Delete(int id);
        void Update(TipoExame tipoExame);
        void Save();
    }
}
