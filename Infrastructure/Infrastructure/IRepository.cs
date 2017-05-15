using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Data.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find<T>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, T>> orderBy);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
            
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(int id);
        void DeleteRange(IEnumerable<int> ids);
    }
}
