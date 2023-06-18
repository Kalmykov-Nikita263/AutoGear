using AutoGear.Identity.Utils;

namespace AutoGear.Identity;

public class SignInManager<TUser> 
    where TUser : IdentityUser
{
    private readonly UserManager<TUser> _userManager;

    private readonly PasswordHasher _passwordHasher;

    public SignInManager(UserManager<TUser> userManager, PasswordHasher passwordHasher)
    {
        _userManager = userManager;
        _passwordHasher = passwordHasher;
    }

    public async Task<SignInResult> SignInAsync(TUser user, string password)
    {
        var currentUser = await _userManager.FindByNameAsync(user.UserName);

        if(currentUser == null)
            return new SignInResult { Succeeded = false };

        if(_passwordHasher.VerifyPasswordHash(currentUser.PasswordHash, password))
        {
            if (user.IsLockedOut)
            {
                return new SignInResult { Succeeded = false, LockedOut = true };
            }

            _userManager.ResetAccessFailedCount(user);

            WpfDataContext.Instance.CurrentUser = currentUser;

            return new SignInResult { Succeeded = true };
        }
        else
        {
            _userManager.IncrementAccessFailedCount(user);

            if (user.AccessFailedCount >= _userManager.MaxFailedAccessAttemptsBeforeLockout)
            {
                _userManager.LockOutUser(user);
                return new SignInResult { Succeeded = false, LockedOut = true };
            }

            return new SignInResult { Succeeded = false };
        }
    }

    public Task SignOutAsync()
    {
        WpfDataContext.Instance.CurrentUser = null;
        return Task.CompletedTask;
    }
}