using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint.Core.IBusiness
{
    public interface IBaseService<T> where T : class ,new()
    {
        T AddEntity(T entity);
        T AddEntity(T entity, bool doSaveChange);
        bool UpdateEntity(T entity);
        bool UpdateEntity(T entity, bool doSaveChange);
        bool DeleteEntity(T entity);
        bool DeleteEntity(T entity, bool doSaveChange);
        T FindEntity(object keyValue);
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Func<T, S> orderByLambda);
    }
}
