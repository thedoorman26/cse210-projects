using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        RunningActivity runningActivity = new RunningActivity(new DateTime(2022, 11, 3), 30, 3.0);
        activities.Add(runningActivity);

        CyclingActivity cyclingActivity = new CyclingActivity(new DateTime(2022, 11, 3), 45, 15);
        activities.Add(cyclingActivity);

        SwimmingActivity swimmingActivity = new SwimmingActivity(new DateTime(2022, 11, 3), 60, 40);
        activities.Add(swimmingActivity);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}