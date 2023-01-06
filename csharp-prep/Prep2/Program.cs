using System;

class Program
{
    static void Main(string[] args)
    {
        string letter;
        bool pass = true;
        Console.WriteLine("What is your percentage grade?");
        string input = Console.ReadLine();
        float percentage = float.Parse(input);
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        if (percentage < 70)
        {
            pass = false;
        }
        if (pass)
        {
            Console.WriteLine($"Your grade is: {letter}. Congratulations, you passed!");
        }
        else 
        {
            Console.WriteLine($"Your grade is: {letter}. Sorry, you did not pass. Please try again.");
        }
    }
}