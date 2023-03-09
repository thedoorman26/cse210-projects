using System;

class SimpleGoal : Goal
{
    private bool _completed;

    public bool Completed
    {
        get { return _completed; }
        set { _completed = value; }
    }

    public SimpleGoal(int reward, string name, bool complete) : base(reward, name)
    {
        _completed = complete;
    }

    public override void Complete()
    {
        if (!_completed)
        {
            base.Complete();
            _completed = true;
        }
        else Console.WriteLine("But this goal has already been completed, so no points were awarded.");
    }

    public override void Display()
    {
        string completeString = _completed ? "X" : " ";
        Console.WriteLine($"[ {completeString} ] {Name} - {Reward} points");
    }
}
