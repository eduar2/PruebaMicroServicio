using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core;
using Core.Repositories;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        internal DbSet<TEntity> dbSet;
        
        public GenericRepository(DbContext context)
        {
            this.Context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            Context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            Context.SaveChanges();
        }

        
        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
