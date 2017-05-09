using Consultorio.Data.Infrastructure;
using System;
using Consultorio.Domain.Models;
using System.Collections.Generic;
using Consultorio.Data.Context;
using System.Linq;

namespace Consultorio.Data.Repository
{
    public class TipoExameRepository : ITipoExameRepository, IDisposable
    {
        ConsultorioContext _context = new ConsultorioContext();

        public IEnumerable<TipoExame> GetAll()
        {
            return _context.TipoExame;
        }

        public TipoExame GetById(int id)
        {
            return _context.TipoExame.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(TipoExame tipoExame)
        {
            _context.TipoExame.Add(tipoExame);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TipoExame tipoExame)
        {
            _context.Entry(tipoExame).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            _context.TipoExame.Remove(_context.TipoExame.Find(id));
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
