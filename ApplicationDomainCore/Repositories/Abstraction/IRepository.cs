using ApplicationDomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomainCore.Repositories.Abstraction
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> CreateAsync(T item);
        Task<IEnumerable<T>> ReadAsync();
        Task<bool> UpdateAsync(int id, T item);
        Task<bool> DeleteAsync(T item);
        Task<T> GetByIdAsync(int id);
        DbSet<T> Get();
    }
}
