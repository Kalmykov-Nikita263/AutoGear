namespace AutoGear.Identity;

public class IdentityUserRole<TKey> where TKey : IEquatable<TKey>
{
    public virtual TKey UserId { get; set; } = default;

    public virtual TKey RoleId { get; set; } = default;
}