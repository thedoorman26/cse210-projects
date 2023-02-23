using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the self-care app!");
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing exercise");
            Console.WriteLine("2. Reflection exercise");
            Console.WriteLine("3. Listing exercise");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            string input = Console.ReadLine();
            if (input == "1")
            {
                BreathingActivity breathing = new BreathingActivity("Breathing Exercise", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", GetDuration());
                breathing.DoActivity();
            }
            else if (input == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity("Reflection Exercise", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", GetDuration());
                reflecting.DoActivity();
            }
            else if (input == "3")
            {
                ListingActivity listing = new ListingActivity("Listing Exercise", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", GetDuration());
                listing.DoActivity();
            }
            else if (input == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                Thread.Sleep(2000);
            }
        }

        Console.WriteLine("Thank you for using the self-care app. Goodbye!");
    }

    static int GetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            Console.Write("Enter the duration of the activity in seconds: ");
        }
        return duration;
    }
}

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

class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description, int duration)
        : base(name, description, duration)
    {
    }

    public override void DoActivity()
    {
        DisplayStart();

        int secondsLeft = _duration;
        bool breatheIn = true;

        while (secondsLeft > 0)
        {
            if (breatheIn)
            {
                Console.WriteLine("Breathe in...");
            }
            else
            {
                Console.WriteLine("Breathe out...");
            }

            breatheIn = !breatheIn;
            secondsLeft = secondsLeft - 3;
            Thread.Sleep(3000);
        }

        DisplayEnd();
    }
}

class ReflectingActivity : Activity
{
    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    };

    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
    };

    public ReflectingActivity(string name, string description, int duration)
        : base(name, description, duration)
    {
    }

    public override void DoActivity()
    {
        DisplayStart();
        DisplayPrompt();
        DisplayQuestion();
        DisplayEnd();
    }

    public override void DisplayEnd()
    {
        Console.WriteLine("Thank you for reflecting with us today.");
        base.DisplayEnd();
    }

    private string PromptGenerator()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string QuestionGenerator()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine(PromptGenerator());
        PauseCountdown();
    }

    private void DisplayQuestion()
    {
        int secondsLeft = _duration;
        while (secondsLeft > 0)
        {
            string question = QuestionGenerator();
            Console.WriteLine(question);
            PauseCountdown();
            secondsLeft -= 3;
        }
    }
}

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