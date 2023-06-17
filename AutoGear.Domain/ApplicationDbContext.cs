using AutoGear.Identity;
using AutoGear.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AutoGear.Domain;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Car>().HasData(new Car
        {
            CarId = Guid.NewGuid(),
            CarName = "Мерседес",
            Speed = 100,
        });
    }
}