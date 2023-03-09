using System;

class CompletionJournal
{
    private List<SimpleGoal> _simple;
    private List<ChecklistGoal> _checklist;
    private List<EternalGoal> _eternal;
    private int _pointTotal;

    public List<SimpleGoal> SimpleGoals
    {
        get { return _simple; }
        set { _simple = value; }
    }

    public List<ChecklistGoal> ChecklistGoals
    {
        get { return _checklist; }
        set { _checklist = value; }
    }

    public List<EternalGoal> EternalGoals
    {
        get { return _eternal; }
        set { _eternal = value; }
    }

    public int PointTotal
    {
        get { return _pointTotal; }
        set { _pointTotal = value; }
    }

    public CompletionJournal(List<SimpleGoal> simple, List<ChecklistGoal> checklist, List<EternalGoal> eternal, int pointTotal)
    {
        _simple = simple;
        _checklist = checklist;
        _eternal = eternal;
        _pointTotal = pointTotal;
    }

    public void SaveToFile(List<SimpleGoal> simple, List<ChecklistGoal> checklist, List<EternalGoal> eternal)
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_pointTotal);
            writer.WriteLine("--- SIMPLE GOALS ---");
            foreach (SimpleGoal goal in _simple)
            {
                writer.WriteLine($"{goal.Name},{goal.Reward},{goal.Completed}");
            }

            writer.WriteLine("--- CHECKLIST GOALS ---");
            foreach (ChecklistGoal goal in _checklist)
            {
                writer.WriteLine($"{goal.Name},{goal.Reward},{goal.Completed},{goal.TimesDone},{goal.TimesGoal},{goal.CompletionBonus}");
            }

            writer.WriteLine("--- ETERNAL GOALS ---");
            foreach (EternalGoal goal in _eternal)
            {
                writer.WriteLine($"{goal.Name},{goal.Reward},{goal.TimesDone}");
            }
        }
    }

    public void LoadFromFile()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                _pointTotal = int.Parse(reader.ReadLine());
                _simple = new List<SimpleGoal>();
                _checklist = new List<ChecklistGoal>();
                _eternal = new List<EternalGoal>();
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "--- SIMPLE GOALS ---")
                    {
                        while ((line = reader.ReadLine()) != null && line != "--- CHECKLIST GOALS ---")
                        {
                            string[] fields = line.Split(',');
                            _simple.Add(new SimpleGoal(int.Parse(fields[1]), fields[0], bool.Parse(fields[2])));
                        }
                    }
                    else if (line == "--- CHECKLIST GOALS ---")
                    {
                        while ((line = reader.ReadLine()) != null && line != "--- ETERNAL GOALS ---")
                        {
                            string[] fields = line.Split(',');
                            _checklist.Add(new ChecklistGoal(int.Parse(fields[1]), fields[0], bool.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5])));
                        }
                    }
                    else if (line == "--- ETERNAL GOALS ---")
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] fields = line.Split(',');
                            _eternal.Add(new EternalGoal(int.Parse(fields[1]), fields[0], int.Parse(fields[2])));
                        }
                    }
                }
             }
        }
    }
}