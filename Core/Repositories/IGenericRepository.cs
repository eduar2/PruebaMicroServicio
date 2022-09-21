using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Insert(TEntity entity);
        
        void Delete(TEntity entity);

        void Update(TEntity entity);

    }
}
