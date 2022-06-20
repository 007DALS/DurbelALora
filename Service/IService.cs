using DurbelALora.Model;
using DurbelALora.Shared;

namespace DurbelALora.Service
{
    public interface IService<T> where T : class
    {
        public Task<T> GetById(int id);
        public Task<IList<T>> GetAll();
        public Task<T> Add(T model);
        public Task<bool> Delete(int id);
    }
    public interface IPersonaService : IService<Persona> {
        public Task<PaginationShared<Persona>> GetPagination(int page = 1, int take = 10, string sParam = "");
    }
}
