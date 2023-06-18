namespace AutoGear.Identity;

public class WpfDataContext
{
    private static WpfDataContext _instance;
    
    public static WpfDataContext Instance => _instance ??= new WpfDataContext();

    private IdentityUser _currentUser;
    
    public IdentityUser CurrentUser
    {
        get { return _currentUser; }
        set { _currentUser = value; }
    }
}
