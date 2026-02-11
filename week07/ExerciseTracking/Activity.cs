public abstract class Activity
{
    private string _name;
    private DateTime _date;
    private int _minutes;

    public Activity()
    { }

    public Activity(DateTime date, string name, int minutes)
    {
        this._date = date;
        this._name = name;
        this._minutes = minutes;
    }

    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Minutes
    {
        get { return _minutes; }
        set { _minutes = value; }
    }

    public abstract double GetDistance();

    public virtual double GetSpeed()
    {
        return (double)GetDistance() / Minutes * 60;
    }

    public virtual double GetPace()
    {
        return (double)Minutes / GetDistance();
    }

    public virtual string GetSummary()
    {
        return $"{Date.ToString("d")} {Name} ({Minutes} min) - Distance: {GetDistance()} km, Speed: {GetSpeed():0.00} kph, Pace: {GetPace():0.00} min per km\n";
    }
}