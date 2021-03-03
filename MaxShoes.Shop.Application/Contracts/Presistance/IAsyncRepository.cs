using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Contracts.Presistance
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task EditAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
