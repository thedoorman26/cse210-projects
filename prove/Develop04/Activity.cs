using System;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public virtual void DisplayStart()
    {
        Console.WriteLine($"{_name} - {_description}");
        Console.WriteLine($"Starting {_name} for {_duration} seconds...");
        PauseCountdown();
    }

    public virtual void DisplayEnd()
    {
        Console.WriteLine($"Good job! You have completed {_name} for {_duration} seconds.");
        Thread.Sleep(3000);
        Console.WriteLine();
    }

    protected void PauseCountdown()
    {
        for (int i = 3; i > 0; i--)
        {
            Console.Write($"\r{_name} starting in {i}...");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public virtual void DoActivity()
    {
        DisplayStart();
        DisplayEnd();
    }
}