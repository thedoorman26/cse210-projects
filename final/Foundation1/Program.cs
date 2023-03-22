using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Make Pancakes", "Cooking with Sarah", 300);
        video1.AddComment("John", "Great recipe! I tried it and it turned out delicious.");
        video1.AddComment("Mary", "Thanks for sharing, Sarah! I've been looking for a good pancake recipe.");
        videos.Add(video1);

        Video video2 = new Video("Gym Workout Routine", "Fitness with Mike", 600);
        video2.AddComment("Alice", "This workout looks intense! I can't wait to try it out.");
        video2.AddComment("Bob", "Thanks for the tips, Mike. I'm trying to get in shape and this will help.");
        videos.Add(video2);

        Video video3 = new Video("Funny Cat Videos Compilation", "Cats Rule", 1800);
        video3.AddComment("Tom", "These cats are hilarious!");
        video3.AddComment("Jen", "I love watching cat videos, they always cheer me up.");
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"Comment from {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); 
        }

        Console.ReadLine();
    }
}