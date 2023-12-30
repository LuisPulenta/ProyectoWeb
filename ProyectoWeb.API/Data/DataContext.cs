using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Shared.Entities;

namespace ProyectoWeb.API
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<AsignacionesOT> AsignacionesOTs { get; set; }
              
    }
}