using System;

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