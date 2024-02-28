using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        #region Field and Constractor
        protected MvcDBContext _dbContext;
        protected DbSet<T> _dbSet;

        public Repository(MvcDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }
        #endregion

        #region Add
        public async virtual Task Add(T entity)
        {
            await _dbContext.AddAsync(entity);
        }
        public async virtual Task AddRange(IEnumerable<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
        }
        #endregion

        #region Edit
        public virtual void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void EditRange(IEnumerable<T> entities)
        {
            _dbContext.Entry(entities).State = EntityState.Modified;
        }
        #endregion

        #region Get
        public virtual IEnumerable<T> Get(
            out int total, out int totalDisplay,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            var query = _dbSet.AsQueryable();
            total = query.Count();
            totalDisplay = total;

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            IQueryable<T> result = null;

            if (orderBy != null)
            {
                result = orderBy(query).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }

            if (isTrackingOff)
                return result?.AsNoTracking().ToList();
            else
                return result?.ToList();


        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", bool isTrackingOff = false)
        {

            var query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            IQueryable<T> result = query;

            if (orderBy != null)
                result = orderBy(query);

            if (isTrackingOff)
                return result?.AsNoTracking().ToList();
            else
                return result?.ToList();

        }

        public async virtual ValueTask<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        #endregion

        #region Remove
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.RemoveRange(entities);
        }
        public async virtual Task Remove(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            Remove(entity);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Remove(Expression<Func<T, bool>> filter)
        {
            _dbSet.RemoveRange(_dbSet.Where(filter));
        }
        #endregion

    }
}
