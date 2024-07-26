using Microsoft.EntityFrameworkCore;
using mvc_fakestore.Models;

namespace  mvc_fakestore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Productos> Productos { get; set; } = default!;
}
