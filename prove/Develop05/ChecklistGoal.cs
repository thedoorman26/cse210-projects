using System;

class ChecklistGoal : Goal
{
    private bool _complete;
    private int _timesDone;
    private int _timesGoal;
    private int _completionBonus;

    public bool Completed
    {
        get { return _complete; }
        set { _complete = value; }
    }

    public int TimesDone
    {
        get { return _timesDone; }
        set { _timesDone = value; }
    }

    public int TimesGoal
    {
        get { return _timesGoal; }
        set { _timesGoal = value; }
    }

    public int CompletionBonus
    {
        get { return _completionBonus; }
        set { _completionBonus = value; }
    }

    public ChecklistGoal(int reward, string name, bool complete, int timesDone, int timesGoal, int completionBonus) : base(reward, name)
    {
        _complete = complete;
        _timesDone = timesDone;
        _timesGoal = timesGoal;
        _completionBonus = completionBonus;
    }

    public override void Complete()
    {
        if (_timesDone < _timesGoal)
        {
            base.Complete();
            _timesDone++;
            if (_timesDone == _timesGoal)
            {
                _complete = true;
            }
        }
    }

    public void Record()
    {
        if (_timesDone < _timesGoal)
        {
            _timesDone++;
            if (_timesDone == _timesGoal)
            {
                _complete = true;
            }
        }
    }

    public override void Display()
    {
        string completeString = _complete ? "X" : " ";
        string timesString = $"Completed {_timesDone}/{_timesGoal} times";
        Console.WriteLine($"[ {completeString} ] {Name} - {Reward} points ({timesString})");
    }

    public bool IsComplete()
    {
        return _complete;
    }
}