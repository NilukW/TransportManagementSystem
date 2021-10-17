using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<int> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task<List<T>> IGenericRepository<T>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
