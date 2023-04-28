using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        List<T> GetByDefault(Expression<Func<T, bool>> filter = null);
        List<T> GetActive();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(Guid id);
    }
}
