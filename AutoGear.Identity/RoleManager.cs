using AutoGear.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AutoGear.Identity;

public class RoleManager<TRole>
    where TRole : IdentityRole
{
    private readonly IdentityDbContext<IdentityUser> _context;

    public RoleManager(IdentityDbContext<IdentityUser> context)
    {
        _context = context;
    }

    public async Task<IdentityResult> CreateAsync(TRole role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();

        return new IdentityResult { Succeeded = true};
    }

    public async Task<IdentityResult> DeleteAsync(TRole role)
    {
        _context.Roles.Remove(role);

        var userRoles = await _context.UserRoles.Where(ur => ur.RoleId == role.Id).ToListAsync();

        _context.UserRoles.RemoveRange(userRoles);

        await _context.SaveChangesAsync();

        return new IdentityResult { Succeeded = true };
    }

    public async Task<TRole> FindByNameAsync(string roleName)
    {
        return (TRole) await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
    }

    public async Task<IdentityResult> AddToRoleAsync(IdentityUser user, string roleName)
    {
        var role = await FindByNameAsync(roleName);
    
        if(!string.IsNullOrEmpty(role.Name))
        {
            await _context.Roles.AddAsync(role);
            await _context.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.Id
            });

            await _context.SaveChangesAsync();

            return new IdentityResult { Succeeded = true };
        }

        return new IdentityResult { Succeeded = false, Errors = new List<string> { "Запрашиваемая роль не найдена" } };
    }
}
