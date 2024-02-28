using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess
{
    public interface IRepository<T> where T : class
    {
        #region Add
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        #endregion

        #region Edit
        void Edit(T entity);
        void EditRange(IEnumerable<T> enities);
        #endregion

        #region Get
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", bool isTrackingOff = false);
        IEnumerable<T> Get(out int total, out int totalDisplay, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        ValueTask<T> GetById(int id);

        #endregion

        #region Remove
        void Remove(Expression<Func<T, bool>> filter);
        Task Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        #endregion

    }
}
