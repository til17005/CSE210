public class EternalGoal : Goal
{
    private int _timesComplete; // How many times has the user completed this goal

    // Constructors
    public EternalGoal() : base()
    {

    }
    public EternalGoal(string type, string name, string description, int points, string status) : base(type, name, description, points, status)
    {

    }

    public EternalGoal(string type, string name, string description, int points, string status, int timesComplete) : base(type, name, description, points, status)
    {
        _timesComplete = timesComplete;
    }

    public virtual int TimesComplete
    {
        get { return _timesComplete; }
        set { _timesComplete = value; }
    }


}