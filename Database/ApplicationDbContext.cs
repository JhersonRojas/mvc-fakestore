using Microsoft.EntityFrameworkCore;
using mvc_fakestore.Models;

namespace mvc_fakestore.Database;

public class AplicacionDbContext : DbContext
{
    public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
        : base(options) { }

    //agregue el modelo
    public DbSet<Proveedores> Proveedores { get; set; }
    public DbSet<Productos> Productos { get; set; } 
}
