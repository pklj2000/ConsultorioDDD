using System;
using System.Collections.Generic;
using Consultorio.Domain.Models;

namespace Consultorio.Data.Infrastructure
{
    public interface IUsuarioRepository: IDisposable
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        Usuario GetByCodigo(string codigo);
        void Insert(Usuario usuario);
        void Delete(int id);
        void Update(Usuario usuario);
        void Save();
    }
}
