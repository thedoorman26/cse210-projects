using System;

class SwimmingActivity : Activity
{
    private int laps;

    public SwimmingActivity(DateTime date, int length, int laps) : base(date, length)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 0.05;
    }

    public override double GetSpeed()
    {
        return (laps * 0.05) / (base.length / 60.0) * 60.0 / 1000.0;
    }

    public override double GetPace()
    {
        return (base.length / laps) * 60.0;
    }

    public override string GetSummary()
    {
        return $"{base.date.ToString("dd MMM yyyy")} Swimming ({base.length} min)- Laps: {laps}, Distance: {GetDistance()} km, Speed {GetSpeed().ToString("F1")} kph, Pace: {GetPace().ToString("F1")} min per km";
    }
}