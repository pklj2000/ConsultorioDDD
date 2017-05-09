using System;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using Consultorio.Data.Context;
using System.Linq;
using Consultorio.Data.Infrastructure;

namespace Consultorio.Data.Infrastructure
{
    public class UsuarioRepository : IUsuarioRepository, IDisposable
    {
        private ConsultorioContext _context = new ConsultorioContext();

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios;
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public Usuario GetByCodigo(string codigo)
        {
            return _context.Usuarios.Where(x => x.Codigo == codigo).FirstOrDefault();
        }

        public void Insert(Usuario usuario)
        {
            usuario.Validate();
            _context.Usuarios.Add(usuario);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            usuario.Validate();
            _context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            _context.Usuarios.Remove(_context.Usuarios.Find(id));
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
