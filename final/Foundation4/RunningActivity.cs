using System;

class RunningActivity : Activity
{
    private double distance;

    public RunningActivity(DateTime date, int length, double distance) : base(date, length)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (base.length / 60.0);
    }

    public override double GetPace()
    {
        return (base.length / distance);
    }
}
