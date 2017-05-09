using System;
using System.Collections.Generic;
using Consultorio.Data.Infrastructure;
using Consultorio.Domain.Models;
using Consultorio.Data.Context;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class EstadoCivilRepository : IEstadoCivilRepository, IDisposable
    {
        ConsultorioContext _context = new ConsultorioContext();

        public IEnumerable<EstadoCivil> GetAll()
        {
            return _context.EstadoCivil;
        }

        public EstadoCivil GetById(int id)
        {
            return _context.EstadoCivil.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(EstadoCivil estadoCivil)
        {
            _context.EstadoCivil.Add(estadoCivil);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(EstadoCivil estadoCivil)
        {
            _context.Entry(estadoCivil).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            _context.EstadoCivil.Remove(_context.EstadoCivil.Find(id));
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
