using Microsoft.EntityFrameworkCore;

namespace AutoGear.Identity.EntityFramework;

public class IdentityDbContext<TUser> : IdentityDbContext<TUser, IdentityRole>
    where TUser : IdentityUser
{
    protected IdentityDbContext() { }

    public IdentityDbContext(DbContextOptions options) : base(options) { }
}

public class IdentityDbContext<TUser, TRole> : IdentityDbContext<IdentityUser, IdentityRole, IdentityUserRole<string>>
    where TUser : IdentityUser
    where TRole : IdentityRole
{
    protected IdentityDbContext() { }

    public IdentityDbContext(DbContextOptions options) : base(options) { }
}


public abstract class IdentityDbContext<TUser, TRole, TUserRole> : DbContext 
    where TUser : IdentityUser 
    where TRole : IdentityRole
    where TUserRole : IdentityUserRole<string>
{
    protected IdentityDbContext() { }

    public IdentityDbContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<TUser> Users { get; set; } = default;

    public virtual DbSet<TRole> Roles { get; set; } = default;

    public virtual DbSet<TUserRole> UserRoles { get; set; } = default;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TUser>(b =>
        {
            b.HasMany<TUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        });

        modelBuilder.Entity<TRole>(b =>
        {
            b.HasKey(r => r.Id);
            b.Property(u => u.Name).HasMaxLength(256);
            b.HasMany<TUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
        });

        modelBuilder.Entity<TUserRole>(b =>
        {
            b.HasKey(r => new { r.UserId, r.RoleId });
        });
    }
}
