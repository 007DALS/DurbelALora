using DurbelALora.Model;
using DurbelALora.Shared;
using Microsoft.AspNetCore.Identity;

namespace DurbelALora.Repository
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetById(int id);       
        public Task<IList<T>> GetAll();
        public Task<T> Add(T entity);       
        public Task<bool> Delete(int id);
    }
    public interface IPersonaRepository : IRepository<Persona> {
        public Task<PaginationShared<Persona>> GetPagination(int Page = 1, int take = 10, string sParam = "");
    }
}
