using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Videocassette> Videocassetes { get; set; }
        public DbSet<Renta> Rentas { get; set; }
    }
}
