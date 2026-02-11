using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Swimming : Activity
{
    private int _laps;

    public Swimming() : base()
    { }

    public Swimming(DateTime date, string name, int minutes) : base(date, name, minutes)
    { }

    public Swimming(DateTime date, string name, int minutes, int laps) : base(date, name, minutes)
    {
        this._laps = laps;
    }

    public int Laps
    {
        get { return _laps; }
        set { _laps = value; }
    }

    public override double GetDistance()
    {
        return (double)(_laps * 50);
    }

    public override double GetSpeed()
    {
        return (double)GetDistance() / (Minutes * 60);
    }

    public override double GetPace()
    {
        return (double)Minutes / _laps;
    }

    public override string GetSummary()
    {
        return $"{Date.ToString("d")} {Name} ({Minutes} min) - Distance: {GetDistance()} meters, Speed: {GetSpeed():0.00} kph, Pace: {GetPace():0.00} min per lap\n";
    }
}