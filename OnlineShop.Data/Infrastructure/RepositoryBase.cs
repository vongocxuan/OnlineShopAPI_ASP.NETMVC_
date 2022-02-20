using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private OnlineShopDbContext dataContext;
        private readonly DbSet<T> dbSet;
        protected IDbFactory DbFactory
        {
            private set;
            get;
        }
        protected OnlineShopDbContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual T Delete(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public virtual void DeleteMulti(Expression<Func<T,bool>> where)
        {
            var objects = dbSet.Where<T>(where);
            foreach (var obj in objects)
                dbSet.Remove(obj);
        }

        private DbQuery<T> GetAll_DbQuery(string[] includes = null)
        {
            if(includes != null && includes.Count() > 0)
            {
                var query = dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = dbSet.Include(include);
                return query;
            }
            return dbSet;
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            return GetAll_DbQuery(includes).ToList();
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T,bool>> predicate = null, string[] includes = null)
        {
            var query = GetAll_DbQuery(includes);
            return predicate != null ? query.Where(predicate).AsQueryable() : query.AsQueryable();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T,bool>> predicate, out int total, int index =0, int size =20, string[] includes = null)
        {
            int skipCount = size * index;
            IQueryable<T> _resetSet;
            _resetSet = (IQueryable<T>)GetMulti(predicate, includes);
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet;
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T GetSingleByCondition(Expression<Func<T,bool>> predicate=null, string[] includes = null)
        {
            return GetAll_DbQuery().FirstOrDefault(predicate);
        }

        public virtual int Count(Expression<Func<T,bool>> where)
        {
            return where != null ? dbSet.Count<T>(where) : dbSet.Count<T>();
        }

        public virtual bool CheckContains(Expression<Func<T,bool>> where)
        {
            return dbSet.Count<T>(where) > 0;
        }
    }
}
