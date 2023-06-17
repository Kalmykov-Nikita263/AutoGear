namespace AutoGear.Identity;

public class IdentityUser : IdentityUser<string>
{
    public IdentityUser()
    {
        Id = Guid.NewGuid().ToString();
    }

    public IdentityUser(string userName) : this()
    {
        UserName = userName;
    }
}

public class IdentityUser<TKey> where TKey : IEquatable<TKey>
{
    public IdentityUser() { }

    public IdentityUser(string userName) : this()
    {
        UserName = userName;
    }

    public virtual TKey Id { get; set; } = default;
    
    public virtual string UserName { get; set; }

    public virtual string Email { get; set; }

    public virtual string PasswordHash { get; set; }

    public virtual string PhoneNumber { get; set; }

    public virtual bool LockoutEnabled { get; set; }

    public virtual bool IsLockedOut { get; set; }

    public virtual int AccessFailedCount { get; set; }

    public override string ToString()
        => UserName ?? string.Empty;
}