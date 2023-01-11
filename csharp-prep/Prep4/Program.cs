using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int item = -1;
        int sum = 0;
        int largest = -100;
        Console.WriteLine("Enter numbers to add them to the list. Enter 0 to end list.");
        while (item != 0)
        {
            Console.WriteLine("Enter number:");
            item = int.Parse(Console.ReadLine());
            if (item != 0)
            {
                numbers.Add(item);
                sum = sum + item;
                if (item > largest)
                {
                    largest = item;
                }
            }
        }
        Console.WriteLine("Sum: " + sum);
        float average = (float)sum / numbers.Count;
        Console.WriteLine("Average: " + average);
        Console.WriteLine("Largest: " + largest);
    }
}