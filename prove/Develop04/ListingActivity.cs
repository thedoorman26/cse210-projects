using System;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };

    private List<string> _listed = new List<string>();

    public ListingActivity(string name, string description, int duration)
        : base(name, description, duration)
    {
    }

    public override void DoActivity()
    {
        DisplayStart();
        DisplayPrompt();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int secondsLeft = _duration;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                _listed.Add(input);
            }
        }
        DisplayListNumber();
        DisplayEnd();
    }

    private string PromptGenerator()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine(PromptGenerator());
        PauseCountdown();
    }

    private void DisplayListNumber()
    {
        Console.WriteLine($"You listed {_listed.Count} items.");
        Thread.Sleep(3000);
    }

    public override void DisplayEnd()
    {
        Console.WriteLine($"You listed {_listed.Count} items:");
        foreach (string item in _listed)
        {
            Console.WriteLine("- " + item);
        }
        base.DisplayEnd();
    }
}