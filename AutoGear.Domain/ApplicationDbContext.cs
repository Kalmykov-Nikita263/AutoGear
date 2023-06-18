using AutoGear.Identity;
using AutoGear.Identity.EntityFramework;
using AutoGear.Identity.Utils;
using Microsoft.EntityFrameworkCore;

namespace AutoGear.Domain;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "3568DAFB-5617-4B95-9618-5572274FC621",
            Name = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "E3B1A7AA-88EF-41E0-89B9-3803B8B54760",
            UserName = "admin",
            Email = "wpfsucks@mail.ru",
            PasswordHash = new PasswordHasher().HashPassword("superpassword"),
            LockoutEnabled = true
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = "E3B1A7AA-88EF-41E0-89B9-3803B8B54760",
            RoleId = "3568DAFB-5617-4B95-9618-5572274FC621"
        });

        modelBuilder.Entity<Car>().HasData(new Car
        {
            CarId = Guid.NewGuid(),
            CarName = "Мерседес",
            Speed = 100,
        });
    }
}