using System;

class CyclingActivity : Activity
{
    private double speed;

    public CyclingActivity(DateTime date, int length, double speed) : base(date, length)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return speed * (base.length / 60.0);
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60.0 / speed;
    }
}