using AutoGear.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AutoGear.Identity;

public class UserManager<TUser>
    where TUser : IdentityUser
{
    private readonly IdentityDbContext<TUser> _context;

    public bool UserLockoutEnabledByDefault { private get; set; }

    public TimeSpan DefaultAccountLockoutTimeSpan { private get; set; }

    public int MaxFailedAccessAttemptsBeforeLockout { get; set; }

    public UserManager(IdentityDbContext<TUser> context)
    {
        _context = context;
    }

    public Task<TUser> FindByNameAsync(string userName)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public void IncrementAccessFailedCount(TUser user)
    {
        user.AccessFailedCount++;

        if (user.AccessFailedCount >= MaxFailedAccessAttemptsBeforeLockout)
            LockOutUser(user);

        _context.SaveChanges();
    }

    public void ResetAccessFailedCount(TUser user)
    {
        user.AccessFailedCount = 0;
        _context.SaveChanges();
    }

    public void LockOutUser(TUser user)
    {
        if (UserLockoutEnabledByDefault)
            user.IsLockedOut = true;

        _context.SaveChanges();
    }

    public void UnlockUser(TUser user)
    {
        if ((DateTime.Now - DefaultAccountLockoutTimeSpan).TimeOfDay < DefaultAccountLockoutTimeSpan)
        {
            throw new InvalidOperationException("Прошло менее двух часов с момента блокировки пользователя.");
        }

        user.IsLockedOut = false;
        _context.SaveChanges();
    }
}
