using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Data.Entities;

namespace Ticaret.Repository
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        Task<T> TAddAsync(T Entity);
        Task<bool> TRemoveAsync(int id);
        Task<T> TUpdateAsync(T Entity);
        Task<T> TGetByIdAsync(int id);
        Task<List<T>> TGetAllAsync();
        IQueryable<T> TQuery();
        Task<T> TFetchSingleAsync(Expression<Func<T, bool>> predicate);
        List<T> TFind(Expression<Func<T, bool>> predicate);



    }
}
