using DurbelALora.Model;
using DurbelALora.Repository;
using DurbelALora.Shared;

namespace DurbelALora.Service
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _repository;

        public PersonaService(IPersonaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Persona> Add(Persona model)
        {
            return await _repository.Add(model);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IList<Persona>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Persona> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<PaginationShared<Persona>> GetPagination(int page = 1, int take = 10, string sParam = "")
        {
            try
            {
                var r =  await _repository.GetPagination(page, take, sParam);
                return r;
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                return null;
            }
        }
    }
}
