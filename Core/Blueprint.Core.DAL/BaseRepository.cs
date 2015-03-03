using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using Blueprint.Core.IDataAccess;

namespace Blueprint.Core.BaseDataAccess
{
    public class BaseRepository<T> : IRepository<T> where T : class,new()
    {
        public DbContext DbContext;
        public T AddEntity(T entity)
        {
            return AddEntity(entity, true);
        }
        public T AddEntity(T entity, bool doSaveChange)
        {
            DbContext.Entry<T>(entity).State = EntityState.Added;
            if (doSaveChange)
                DbContext.SaveChanges();
            return entity;
        }
        public bool UpdateEntity(T entity)
        {
            return UpdateEntity(entity, true);
        }
        public bool UpdateEntity(T entity, bool doSaveChange)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry<T>(entity).State = EntityState.Modified;
            return doSaveChange ? DbContext.SaveChanges() > 0 : false;
        }
        public bool DeleteEntity(T entity)
        {
            return DeleteEntity(entity, true);
        }
        public bool DeleteEntity(T entity, bool doSaveChange)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry<T>(entity).State = EntityState.Deleted;
            return doSaveChange ? DbContext.SaveChanges() > 0 : false;
        }
        public T FindEntity(object keyValue)
        {
            return DbContext.Set<T>().Find(keyValue);
        }
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return DbContext.Set<T>().Where<T>(whereLambda).AsQueryable();
        }
        public IQueryable<T> LoadPageEntities<S>(
            int pageIndex, int pageSize, out  int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            var temp = DbContext.Set<T>().Where<T>(whereLambda);
            total = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize).AsQueryable();
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize).AsQueryable();
            }

            return temp.AsQueryable();
        }
    }
}
