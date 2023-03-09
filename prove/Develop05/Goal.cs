using System;

class Goal
{
    private int _reward;
    private string _name;

    public int Reward
    {
        get { return _reward; }
        set { _reward = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Goal(int reward, string name)
    {
        _reward = reward;
        _name = name;
    }

    public virtual void Complete()
    {
        Console.WriteLine($"Goal {Name} completed!");
    }

    public virtual void Display()
    {
        Console.WriteLine($"Goal: {Name} Reward: {Reward}");
    }
}