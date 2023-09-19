using Microsoft.EntityFrameworkCore;

namespace FirstApp.Infrustracture;

public class FirstAppDbContext : DbContext
{
    public FirstAppDbContext(DbContextOptions<FirstAppDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FirstAppDbContext).Assembly);
    }
}
