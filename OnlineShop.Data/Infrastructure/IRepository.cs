using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineShop.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Update(T enity);
        T Delete(T entity);
        T Delete(int i);
        void DeleteMulti(Expression<Func<T, bool>> where);
        T GetSingleById(int id);
        T GetSingleByCondition(Expression<Func<T, bool>> where=null, string[] includes = null);
        IEnumerable<T> GetAll(string[] includes = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate=null, string[] includes = null);
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate , out int total, int index = 0, int size = 20, string[] includes =null);
        int Count(Expression<Func<T, bool>> where=null);
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}