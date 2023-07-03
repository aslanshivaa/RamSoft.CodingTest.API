using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RamSoft.CodingTest.Core.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public ApplicationContext _applicationContext;
        public RepositoryBase(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        

        public async Task<T> Add(T entity)
        {
            _applicationContext.Set<T>().Add(entity);
            await _applicationContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _applicationContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _applicationContext.Set<T>().Remove(entity);
            }
            await _applicationContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            var entity = await _applicationContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await _applicationContext.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _applicationContext.Set<T>().Update(entity);
            await _applicationContext.SaveChangesAsync();
            return entity;
        }
    }
}
