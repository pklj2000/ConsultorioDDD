using System;
using System.Collections.Generic;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        ConsultorioContext _context = new ConsultorioContext();

        public void Delete(int id)
        {
            _context.Departamentos.Remove(_context.Departamentos.Find(id));
        }

        public IEnumerable<Departamento> GetAll()
        {
            return _context.Departamentos.Include("Empresa");
        }

        public IEnumerable<Departamento> GetByEmpresa(int empresaId)
        {
            return _context.Departamentos.Where(x => x.EmpresaId == empresaId);
        }

        public Departamento GetById(int id)
        {
            return _context.Departamentos.Include("Empresa").Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Departamento departamento)
        {
            _context.Entry(departamento).State = System.Data.Entity.EntityState.Modified;
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
