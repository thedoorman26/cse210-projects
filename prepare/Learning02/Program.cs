using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "IBM";
        job1._jobTitle = "Programmer";
        job1._startYear = 2000;
        job1._endYear = 2010;

        Job job2 = new Job();
        job2._company = "Amazon";
        job2._jobTitle = "Senior Programmer";
        job2._startYear = 2010;
        job2._endYear = 2023;

        Resume resume1 = new Resume();
        resume1._name = "David Nelson";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1.Display();
    }
}

public class Job
{
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear = 0;
    public int _endYear = 0;

    public Job()
    {
    }

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

public class Resume
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    public Resume()
    {
    }

    public void Display()
    {
        Console.WriteLine($"\nMy Resume\n\nName: {_name}\nJobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
        Console.WriteLine("\n");
    }
}