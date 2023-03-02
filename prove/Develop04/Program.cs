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







