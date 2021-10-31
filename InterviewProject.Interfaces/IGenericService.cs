using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Interfaces
{
   public interface IGenericService<T> : IDisposable where T : class
    {
        [OperationContract]
        Task<T> Add(T entity);
        [OperationContract]
        T Get(long id);
        [OperationContract]
        List<T> GetAll();
        [OperationContract]
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        [OperationContract]
        Task Remove(long id);
        [OperationContract]
        Task Remove(T entity);
        [OperationContract]
        Task Update(T entity);
    }
}
