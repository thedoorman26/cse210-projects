using System;

class EternalGoal : Goal
{
    private int _timesDone;

    public int TimesDone
    {
        get { return _timesDone; }
        set { _timesDone = value; }
    }

    public EternalGoal(int reward, string name, int timesDone) : base(reward, name)
    {
        _timesDone = timesDone;
    }

    public override void Complete()
    {
        base.Complete();
        _timesDone++;
    }

    public override void Display()
    {
        Console.WriteLine($"{Name} - {Reward} points (completed {_timesDone} times)");
    }
}