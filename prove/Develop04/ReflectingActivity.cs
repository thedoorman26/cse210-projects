using System;

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