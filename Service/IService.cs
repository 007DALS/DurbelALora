using DurbelALora.Model;

namespace DurbelALora.Service
{
    public interface IService<T> where T : class
    {
        public Task<T> GetById(int id);
        public Task<IList<T>> GetAll();
        public Task<T> Add(T model);
        public Task<bool> Delete(int id);
    }
    public interface IPersonaService : IService<Persona> { }
}
