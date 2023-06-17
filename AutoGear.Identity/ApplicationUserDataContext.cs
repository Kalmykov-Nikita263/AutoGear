namespace AutoGear.Identity;

public class ApplicationUserDataContext
{
    private static ApplicationUserDataContext _instance;
    public static ApplicationUserDataContext Instance => _instance ??= new ApplicationUserDataContext();

    private IdentityUser _currentUser;
    public IdentityUser CurrentUser
    {
        get { return _currentUser; }
        set { _currentUser = value; }
    }
}
