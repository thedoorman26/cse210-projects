using System;

abstract class Activity
{
    protected DateTime date;
    protected int length;

    public Activity(DateTime date, int length)
    {
        this.date = date;
        this.length = length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} {GetType().Name} ({length} min)- Distance {GetDistance().ToString("F1")} km, Speed {GetSpeed().ToString("F1")} kph, Pace: {GetPace().ToString("F1")} min per km";
    }
}