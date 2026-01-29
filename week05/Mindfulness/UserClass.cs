public class UserClass
{
    protected string _userName;
    protected int _userPIN;

    public string GetUserName()
    {
        return _userName;
    }

    public int GetPin()
    {
        return _userPIN;
    }

    public void SetUserCreds(string userCreds)
    {
        _userName = userCreds;
    }

    public void SetUserName(string userName)
    {
        _userName = userName;
    }

    public void SetUserPIN(int userPIN)
    {
        _userPIN = userPIN;
    }
}