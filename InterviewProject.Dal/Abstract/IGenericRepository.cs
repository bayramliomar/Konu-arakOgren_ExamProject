using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Dal.Abstract
{
   public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<T> Add(T entity);
        T Get(long id);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        Task Remove(long id);
        Task Remove(T entity);
        Task Update(T entity);
    }
}
