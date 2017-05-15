using System.Collections.Generic;
using System.Linq;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;

namespace Consultorio.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ConsultorioContext context):base(context)
        {
        }

        public IEnumerable<Empresa> GetByNome(string nome)
        {
            return Context.Empresas.Where(x => x.Cidade.Contains(nome));
        }
    }
}
