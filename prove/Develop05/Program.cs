using System;

class Program
{
    static CompletionJournal journal;

    static void Main()
    {
        journal = new CompletionJournal(new List<SimpleGoal>(), new List<ChecklistGoal>(), new List<EternalGoal>(), 0);

        journal.LoadFromFile();

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Create a new simple goal");
            Console.WriteLine("2. Create a new eternal goal");
            Console.WriteLine("3. Create a new checklist goal");
            Console.WriteLine("4. Record an event");
            Console.WriteLine("5. Show goal completion");
            Console.WriteLine("6. Exit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateSimpleGoal();
                    break;
                case "2":
                    CreateEternalGoal();
                    break;
                case "3":
                    CreateChecklistGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    ShowAllGoals();
                    break;
                case "6":
                    journal.SaveToFile(journal.SimpleGoals, journal.ChecklistGoals, journal.EternalGoals);
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void CreateSimpleGoal()
    {
        Console.WriteLine("Enter the name of the goal:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the reward for completing the goal:");
        int reward = int.Parse(Console.ReadLine());

        SimpleGoal goal = new SimpleGoal(reward, name, false);
        journal.SimpleGoals.Add(goal);
        Console.WriteLine($"New simple goal created: {name}");
    }

    static void CreateEternalGoal()
    {
        Console.WriteLine("Enter the name of the goal:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the reward for completing the goal:");
        int reward = int.Parse(Console.ReadLine());

        EternalGoal goal = new EternalGoal(reward, name, 0);
        journal.EternalGoals.Add(goal);
        Console.WriteLine($"New eternal goal created: {name}");
    }

    static void CreateChecklistGoal()
    {
        Console.WriteLine("Enter the name of the goal:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the reward for completing each task:");
        int reward = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of times the goal must be completed:");
        int goalCount = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the bonus for completing the goal:");
        int bonus = int.Parse(Console.ReadLine());

        ChecklistGoal goal = new ChecklistGoal(reward, name, false, 0, goalCount, bonus);
        journal.ChecklistGoals.Add(goal);
        Console.WriteLine($"New checklist goal created: {name}");
    }

    static void RecordEvent()
    {
        Console.WriteLine("Enter the name of the goal:");
        string name = Console.ReadLine();

        foreach (SimpleGoal goal in journal.SimpleGoals)
        {
            if (goal.Name == name)
            {                
                journal.PointTotal += goal.Reward;
                Console.WriteLine($"Recorded event for {name}. You earned {goal.Reward} points!");
                goal.Complete();
                return;
            }
        }

        foreach (EternalGoal goal in journal.EternalGoals)
        {
            if (goal.Name == name)
            {
                goal.Complete();
                journal.PointTotal += goal.Reward;
                Console.WriteLine($"Recorded event for {name}. You earned {goal.Reward} points!");
                return;
            }
        }

        foreach (ChecklistGoal goal in journal.ChecklistGoals)
        {
            if (goal.Name == name)
            {
                goal.Record();
                journal.PointTotal += goal.Reward;
                Console.WriteLine($"Recorded event for {name}. You earned {goal.Reward} points!");
                if (goal.IsComplete())
                {
                    journal.PointTotal += goal.CompletionBonus;
                    Console.WriteLine($"Goal {name} completed! You earned an additional {goal.CompletionBonus} points!");
                }
                return;
            }
        }

        Console.WriteLine("No goal found with that name. Try again.");
    }

    static void ShowAllGoals()
    {
        Console.WriteLine("Simple Goals:");
        foreach (SimpleGoal goal in journal.SimpleGoals)
        {
            goal.Display();
        }

        Console.WriteLine("Checklist Goals:");
        foreach (ChecklistGoal goal in journal.ChecklistGoals)
        {
            goal.Display();
        }

        Console.WriteLine("Eternal Goals:");
        foreach (EternalGoal goal in journal.EternalGoals)
        {
            goal.Display();
        }

        Console.WriteLine($"Total Points: {journal.PointTotal}");
    }
}