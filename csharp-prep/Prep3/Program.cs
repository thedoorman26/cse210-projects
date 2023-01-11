using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int secret_number = randomGenerator.Next(1, 101);
        int guess = -100;
        while (guess != secret_number)
        {
            Console.WriteLine("Try to guess the random number!");
            guess = int.Parse(Console.ReadLine());
            if (guess > secret_number)
            {
                Console.WriteLine("Your guess is too high. Try again.");
            }
            else if (guess < secret_number)
            {
                Console.WriteLine("Your guess is too low. Try again.");
            }
            else
            {
                Console.WriteLine("Congratulations!");
            }
        }
    }
}