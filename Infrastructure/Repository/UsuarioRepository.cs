using Consultorio.Domain.Models;
using Consultorio.Data.Context;
using System.Linq;
using Consultorio.Data.Repository;

namespace Consultorio.Data.Infrastructure
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ConsultorioContext context): base(context)
        {
        }
        
        public Usuario GetByCodigo(string codigo)
        {
            return Context.Usuarios.Include("Perfis").Where(x => x.Codigo == codigo).FirstOrDefault();
        }

        public override Usuario GetById(int id)
        {
            return Context.Usuarios.Include("Perfis").Where(x => x.Id == id).FirstOrDefault();
        }

        
    }
}
