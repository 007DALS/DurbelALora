using DurbelALora.Data;
using DurbelALora.Model;
using DurbelALora.Repository;
using DurbelALora.Shared;
using Microsoft.EntityFrameworkCore;

namespace DurbelALora.Repositories
{
    public class PersonaRepository : IPersonaRepository
{
        private readonly ApplicationDBContext _dbContext;

        public PersonaRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Persona> Add(Persona entity)
        {
            await _dbContext.Persona.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            bool r = false;
            Persona? persona = await _dbContext.Persona.FirstOrDefaultAsync(x => x.ID == id);
            if (persona != null)
            {
                _dbContext.Persona.Remove(persona);
                await _dbContext.SaveChangesAsync();
                r = true;
            }
            return r;
        }

        public async Task<IList<Persona>> GetAll()
        {
            return await _dbContext.Persona.ToListAsync();
        }

        public async Task<Persona> GetById(int id)
        {
            Persona? persona = await _dbContext.Persona.FirstOrDefaultAsync(x => x.ID == id);
            if (persona != null) return persona;
            else throw new Exception("Record not found.");
        }

        public async Task<PaginationShared<Persona>> GetPagination(int page = 1, int take = 10, string sParam = "")
        {
            var r = new PaginationShared<Persona>();

            r.Records = string.IsNullOrWhiteSpace(sParam) ?
                await _dbContext.Persona.Skip((page - 1) * take).Take(take).ToListAsync()
                : await _dbContext.Persona.Where(x =>
                    x.ID.ToString().Contains(sParam)
                    || x.Nombre.Trim().ToLower().Contains(sParam.Trim().ToLower())
                    
                    
                  ).Skip((page - 1) * take).Take(take).ToListAsync();

            r.Count = string.IsNullOrWhiteSpace(sParam)
                      ? await _dbContext.Persona.CountAsync()
                      : await _dbContext.Persona.Where(x =>
                     x.ID.ToString().Contains(sParam)
                     || x.Nombre.Trim().ToLower().Contains(sParam.Trim().ToLower())
                                       
                  ).CountAsync();
            r.PagesQuantity = Convert.ToInt32(Math.Ceiling(r.Count / take));
            return r;
        }
    }
}
