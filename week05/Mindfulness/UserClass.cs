public class UserClass
{
    // Variables for the users first name and the PIN
    protected string _userName;
    protected int _userPIN;

    // In another variation of code I was trying these were used, but not anymore. I thought I would leave them for now as if I were to user this for future developement and need them later
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