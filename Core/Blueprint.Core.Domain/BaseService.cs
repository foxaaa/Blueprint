using Blueprint.Core.IBusiness;
using Blueprint.Core.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint.Core.BaseBusiness
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, new()
    {
        public IRepository<T> CurrentRepository { get; set; }
        public T AddEntity(T entity)
        {
            return CurrentRepository.AddEntity(entity);
        }
        public T AddEntity(T entity, bool doSaveChange)
        {
            return CurrentRepository.AddEntity(entity, doSaveChange);
        }
        public bool UpdateEntity(T entity)
        {
            return CurrentRepository.UpdateEntity(entity);
        }
        public bool UpdateEntity(T entity, bool doSaveChange)
        {
            return CurrentRepository.UpdateEntity(entity, doSaveChange);
        }
        public bool DeleteEntity(T entity)
        {
            return CurrentRepository.DeleteEntity(entity);
        }
        public bool DeleteEntity(T entity, bool doSaveChange)
        {
            return CurrentRepository.DeleteEntity(entity, doSaveChange);
        }
        public T FindEntity(object keyValue)
        {
            return CurrentRepository.FindEntity(keyValue);
        }
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentRepository.LoadEntities(whereLambda);
        }
        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            return CurrentRepository.LoadPageEntities(pageIndex, pageSize, out  total, whereLambda, isAsc, orderByLambda);
        }
    }
}
