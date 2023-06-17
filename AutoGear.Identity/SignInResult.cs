namespace AutoGear.Identity;

public class SignInResult
{
    public bool Succeeded { get; set; }

    public bool LockedOut { get; set; }
}
