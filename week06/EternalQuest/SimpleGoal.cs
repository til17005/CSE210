using System.Reflection.Metadata.Ecma335;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructors
    public SimpleGoal() : base()
    {

    }
    public SimpleGoal(string type, string name, string description, int points, string status) : base(type, name, description, points, status)
    {

    }

    public bool isComplete
    {
        get { return _isComplete; }
        set { _isComplete = value; }
    }

    public override bool IsComplete()
    {
        string status = _status.ToLower();
        if (status == "complete")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*
        public string GetStringRepresentation()
        {

        }
        */
}