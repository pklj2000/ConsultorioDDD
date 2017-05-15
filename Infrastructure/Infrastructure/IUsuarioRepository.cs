using Consultorio.Domain.Models;

namespace Consultorio.Data.Infrastructure
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Usuario GetByCodigo(string codigo);
    }
}
