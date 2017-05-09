using Consultorio.Domain.Models;
using System.Collections.Generic;

namespace Consultorio.Service.Infrastructure
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        Usuario GetByCodigo(string codigo);
        void Insert(Usuario usuario);
        void Delete(int id);
        void Update(Usuario usuario);
        void Save();
        bool ValidatePassword(string usuario, string password);
    }
}
