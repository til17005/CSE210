public class Running : Activity
{
    private int _distance;

    public Running() : base()
    { }

    public Running(DateTime date, string name, int minutes) : base(date, name, minutes)
    { }

    public Running(DateTime date, string name, int minutes, int distance) : base(date, name, minutes)
    {
        this._distance = distance;
    }

    public int Distance
    {
        get { return _distance; }
        set { _distance = value; }
    }

    public override double GetDistance()
    {
        return (double)_distance;
    }

    public override double GetSpeed()
    {
        return base.GetSpeed();
    }

    public override double GetPace()
    {
        return base.GetPace();
    }
}