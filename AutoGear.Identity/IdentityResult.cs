namespace AutoGear.Identity;

public class IdentityResult
{
    public bool Succeeded { get; set; }

    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}
