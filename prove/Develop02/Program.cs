using System;

class Entry
{
    public string prompt;
    public string response;
    public DateTime date;

    public Entry(string prompt, string response, DateTime date)
    {
        this.prompt = prompt;
        this.response = response;
        this.date = date;
    }

    public void Display()
    {
        Console.WriteLine("Prompt: " + prompt);
        Console.WriteLine("Response: " + response);
        Console.WriteLine("Date: " + date);
    }
}

class Journal
{
    public string userName;
    public List<Entry> entries;

    public Journal(string userName)
    {
        this.userName = userName;
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, DateTime date)
    {
        entries.Add(new Entry(prompt, response, date));
    }

    public void DisplayEntries()
    {
        Console.WriteLine("Entries for user: " + userName);
        int entryNumber = 1;
        foreach (Entry entry in entries)
        {
            Console.WriteLine("Entry " + entryNumber);
            Console.WriteLine("Prompt: " + entry.prompt);
            Console.WriteLine("Response: " + entry.response);
            Console.WriteLine("Date: " + entry.date);
            Console.WriteLine();
            entryNumber++;
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(userName);
            foreach (Entry entry in entries)
            {
                writer.WriteLine(entry.prompt);
                writer.WriteLine(entry.response);
                writer.WriteLine(entry.date);
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            userName = reader.ReadLine();
            entries.Clear();

            while (!reader.EndOfStream)
            {
                string prompt = reader.ReadLine();
                string response = reader.ReadLine();
                DateTime date = DateTime.Parse(reader.ReadLine());
                entries.Add(new Entry(prompt, response, date));
            }
        }
    }
}

class Program
{
    static List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static Journal journal;

    static void Main(string[] args)
    {
        Console.WriteLine("Enter your name:");
        string userName = Console.ReadLine();
        journal = new Journal(userName);

        int choice;
        do
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    WriteNewEntry();
                    break;
                case 2:
                    DisplayJournal();
                    break;
                case 3:
                    SaveJournal();
                    break;
                case 4:
                    LoadJournal();
                    break;
                case 5:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (choice != 5);
    }

    static void WriteNewEntry()
    {
        Random rnd = new Random();
        int promptIndex = rnd.Next(prompts.Count);
        string prompt = prompts[promptIndex];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        DateTime date = DateTime.Now;
        journal.AddEntry(prompt, response, date);
        Console.WriteLine("Entry added.");
    }

    static void DisplayJournal()
    {
        journal.DisplayEntries();
    }

    static void SaveJournal()
    {
        Console.WriteLine("Enter a file name to save the journal:");
        string fileName = Console.ReadLine();
        journal.SaveToFile(fileName);
        Console.WriteLine("Journal saved to file.");
    }

    static void LoadJournal()
    {
        Console.WriteLine("Enter a file name to load the journal:");
        string fileName = Console.ReadLine();
        journal.LoadFromFile(fileName);
        Console.WriteLine("Journal loaded from file.");
    }
}