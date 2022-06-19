using DurbelALora.Model;
using Microsoft.EntityFrameworkCore;


namespace DurbelALora.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }
        public DbSet<Persona> Persona { get; set; }
    }
}
