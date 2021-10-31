using InterviewProject.Dal.Abstract;
using InterviewProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Bll
{
   public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericManager(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public Task<T> Add(T entity)
        {  //varsa iş kuralları uygulanacak
            return _genericRepository.Add(entity);
        }

        public Task Remove(long id)
        {
            return _genericRepository.Remove(id);
        }

        public Task Remove(T entity)
        {
            return _genericRepository.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _genericRepository.Dispose();
            }
        }
        public T Get(long id)
        {
            return _genericRepository.Get(id);
        }
        public List<T> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _genericRepository.GetAll(predicate);
        }

        public Task Update(T entity)
        {
            return _genericRepository.Update(entity);
        }

    }
}
