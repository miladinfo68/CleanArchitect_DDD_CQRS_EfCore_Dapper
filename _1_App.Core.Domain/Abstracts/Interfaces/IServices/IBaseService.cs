using System.Threading.Tasks;
using System.Collections.Generic;

namespace _1_App.Core.Domain.Abstracts.Interfaces.IServices
{
    public interface IBaseServiceGetById<T, U> where T : IDto where U : IDto
    {
        Task<U> GetByIdAsync(T entity);
    }
    public interface IBaseServiceAdd<T, U> where T : IDto where U : IDto
    {
        Task<U> AddAsync(T entity);
    }

    public interface IBaseServiceUpdate<T, U> where T : IDto where U : IDto
    {
        Task<U> UpdateAsync(T entity);
    }
    public interface IBaseServiceDelete<T> where T : IDto 
    {
        Task<bool> DeleteAsync(T entity);
    }
    public interface IBaseService<T> where T : IDto
    {
        Task<List<T>> GetAllAsync();
        //Task<T> GetByIdAsync(decimal id);
        //Task<bool> DeleteAsync(decimal id);
        //Task<T> AddAsync(T entity);
        //Task<T> UpdateAsync(T entity);
    }

}
