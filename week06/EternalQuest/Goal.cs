using System.Text;

public abstract class Goal
{
    private string _type;
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected string _status;

    // Constructors
    public Goal()
    {

    }
    
    public Goal(string type, string name, string description, int points, string status)
    {
        _type = type;
        _shortName = name;
        _description = description;
        _points = points;
        _status = status;
    }

    public void RecordEvent()
    {

    }

    public virtual bool IsComplete()
    {
        return false;
    }

    // I decided to use StringBuilder for this, but don't think I will be using this with the updates I have added
    public string GetDetailsString()
    {
        // Display to user
        var goalBuilder = new StringBuilder();
        goalBuilder.AppendLine($"Type: {_type}");
        goalBuilder.AppendLine($"Name: {_shortName}");
        goalBuilder.AppendLine($"Description: {_description}");
        goalBuilder.AppendLine($"Points: {_points}");
        goalBuilder.AppendLine($"Completed: {IsComplete()}");

        string goals = goalBuilder.ToString();
        return goals;
    }

    // I don't think I will be using this with the updates I have added
    public virtual string GetStringRepresentation()
    {
        return $"{_type}, {_shortName}, {_description}, {_points}, {IsComplete()}";
    }

    // Entries for enhancement
    // Getters & Setters
    public virtual string Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public virtual string Name
    {
        get { return _shortName; }
        set { _shortName = value; }
    }

    public virtual string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public virtual int Points
    {
        get { return _points; }
        set { _points = value; }
    }

    public virtual string Status
    {
        get { return _status; }
        set { _status = value; }
    }
    // -------------------------------
}