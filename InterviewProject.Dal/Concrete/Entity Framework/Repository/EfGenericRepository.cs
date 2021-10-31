using InterviewProject.Dal.Abstract;
using InterviewProject.Dal.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProject.Dal.Concrete.Entity_Framework.Repository
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ExamContext _dbContext;

        public EfGenericRepository()
        {
            _dbContext = new ExamContext();
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
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
                _dbContext.Dispose();
            }
        }

        public T Get(long id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            return entity;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public async Task Remove(long id)
        {
            await Remove(Get(id));
        }

        public async Task Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
