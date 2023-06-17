namespace AutoGear.Identity;

public class IdentityRole : IdentityRole<string>
{
    public IdentityRole()
    {
        Id = Guid.NewGuid().ToString();
    }

    public IdentityRole(string roleName) : this()
    {
        Name = roleName;
    }
}

public class IdentityRole<TKey> where TKey : IEquatable<TKey>
{
    public IdentityRole() { }

    public IdentityRole(string roleName) : this()
    {
        Name = roleName;
    }

    public virtual TKey Id { get; set; } = default;

    public virtual string Name { get; set; }

    public override string ToString() 
        => Name ?? string.Empty;
}