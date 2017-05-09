using System;
using System.Collections.Generic;
using System.Linq;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;

namespace Consultorio.Data.Repository
{
    public class EmpresaRepository : IEmpresaRepository, IDisposable
    {
        private ConsultorioContext _context = new ConsultorioContext();


        public IEnumerable<Empresa> GetAll()
        {
            return _context.Empresas;
        }

        public IEnumerable<Empresa> GetByNome(string nome)
        {
            return _context.Empresas.Where(x => x.Cidade.Contains(nome));
        }

        public Empresa GetById(int id)
        {
            return _context.Empresas.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
        }

        public void Delete(int id)
        {
            _context.Empresas.Remove(_context.Empresas.Find(id));
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Empresa empresa)
        {
            _context.Entry(empresa).State = System.Data.Entity.EntityState.Modified;
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
