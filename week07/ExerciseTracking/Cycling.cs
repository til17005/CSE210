public class Cycling : Activity
{
    private int _speed;

    public Cycling() : base()
    { }

    public Cycling(DateTime date, string name, int minutes) : base(date, name, minutes)
    { }

    public Cycling(DateTime date, string name, int minutes, int speed) : base(date, name, minutes)
    {
        this._speed = speed;
    }

    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }


    public override double GetDistance()
    {
        return (double)_speed * Minutes / 60.0;
    }

    public override double GetSpeed()
    {
        return (double)_speed;
    }

    public override double GetPace()
    {
        return base.GetPace();
    }
}