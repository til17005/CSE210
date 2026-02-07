public class ChecklistGoal : Goal
{
    private int _amountComplete; // Quantity of time goal has been completed
    private int _target; // Quantity of times to complete goal
    private int _bonus;  // Bonus points to receive for completion

    // Constructors
    public ChecklistGoal() : base()
    {

    }

    public ChecklistGoal(string type, string name, string description, int points, string status, int target, int bonus) : base(type, name, description, points, status)
    {
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string type, string name, string description, int points, string status, int amountComplete, int target, int bonus) : base(type, name, description, points, status)
    {
        _amountComplete = amountComplete;
        _target = target;
        _bonus = bonus;
    }

    public virtual int AmountComplete
    {
        get { return _amountComplete; }
        set { _amountComplete = value; }
    }

    public virtual int Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public virtual int Bonus
    {
        get { return _bonus; }
        set { _bonus = value; }
    }
}
