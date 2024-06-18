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
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Ventas> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar la relación uno a muchos entre Productos y Ventas
        modelBuilder
            .Entity<Ventas>()
            .HasOne(v => v.Productos)
            .WithMany(p => p.Ventas)
            .HasForeignKey(v => v.FkProducto);

        // Configurar la relación uno a muchos entre Usuario y Ventas
        modelBuilder
            .Entity<Ventas>()
            .HasOne(v => v.Usuarios)
            .WithMany(u => u.Ventas)
            .HasForeignKey(v => v.FkUsuario);

        //coneccion con categorias y productos
        modelBuilder
            .Entity<Productos>()
            .HasOne(v => v.Categorias)
            .WithMany(u => u.Productos)
            .HasForeignKey(v => v.FkCategoria);

        modelBuilder
            .Entity<Productos>()
            .HasOne(v => v.Proveedores)
            .WithMany(u => u.Productos)
            .HasForeignKey(v => v.FkProveedor);

        modelBuilder
            .Entity<Usuarios>()
            .Property(p => p.IdUsuario)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        modelBuilder
            .Entity<Productos>()
            .Property(p => p.IdProducto)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<Ventas>()
            .Property(v => v.Actualizado)
            .HasDefaultValue(DateTime.Now);
            
        modelBuilder.Entity<Ventas>()
            .Property(v => v.Creado)
            .HasDefaultValue(DateTime.Now);
    }
}
