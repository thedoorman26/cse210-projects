using System;

class Program {
    static void Main(string[] args) {
        Address eventAddress = new Address("123 Main St", "New York", "NY", 10001);
        Lecture lecture = new Lecture("How to Code", "Learn how to code with this informative lecture", new DateTime(2023, 4, 15), new TimeSpan(16, 0, 0), eventAddress, "John Smith", 50);
        Reception reception = new Reception("Networking Mixer", "Join us for a night of networking and drinks", new DateTime(2023, 5, 1), new TimeSpan(19, 0, 0), eventAddress, "rsvp@example.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Picnic", "Come enjoy a picnic in the park with your friends and family", new DateTime(2023, 6, 15), new TimeSpan(12, 0, 0), eventAddress, "The forecast calls for sunshine and clear skies");

        Console.WriteLine("Lecture Marketing Messages:\n");
        Console.WriteLine("Standard Details: \n");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine("Full Details: \n");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("Short Description: \n");
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine("\n\n");

        Console.WriteLine("Reception Marketing Messages:\n");
        Console.WriteLine("Standard Details: \n");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine("Full Details: \n");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine("Short Description: \n");
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine("\n\n");

        Console.WriteLine("Outdoor Gathering Marketing Messages:\n");
        Console.WriteLine("Standard Details: \n");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine("Full Details: \n");
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine("Short Description: \n");
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
} 