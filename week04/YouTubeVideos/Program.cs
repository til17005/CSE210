using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nHello World! This is the YouTubeVideos Project.\n");

        // Create Video 1
        Video video1 = new Video();
        video1._title = "C# Programming Tutorial";
        video1._author = "Matthew's Code Arena";
        video1._lengthInSeconds = 600;

        // Create Video 2
        Video video2 = new Video();
        video2._title = "Learn OOP in C#";
        video2._author = "Matthew's Code Arena";
        video2._lengthInSeconds = 900;

        // Create Video 3
        Video video3 = new Video();
        video3._title = "See You Later";
        video3._author = "Someone Else";
        video3._lengthInSeconds = 127;

        // Create Comments for Video 1
        Comment commentV11 = new Comment();
        commentV11._name = "Russell";
        commentV11._comment = "Awesome turorial, very helpful!";
        Comment commentV12 = new Comment();
        commentV12._name = "Toad";
        commentV12._comment = "Dumb comment";
        Comment commentV13 = new Comment();
        commentV13._name = "Rascal";
        commentV13._comment = "This was okay, could be better.";
        Comment commentV14 = new Comment();
        commentV14._name = "Bob";
        commentV14._comment = "Tutorial was too long.";

        // Create Comments for Video 2
        Comment commentV21 = new Comment();
        commentV21._name = "Teddy";
        commentV21._comment = "Ummmm, what?";
        Comment commentV22 = new Comment();
        commentV22._name = "Lily";
        commentV22._comment = "Content was great, thanks!";
        Comment commentV23 = new Comment();
        commentV23._name = "Little John";
        commentV23._comment = "Yep, Learned a lot.";
        Comment commentV24 = new Comment();
        commentV24._name = "Skinny Pete";
        commentV24._comment = "Such a waste of time.";

        // Create Comments for Video 3
        Comment commentV31 = new Comment();
        commentV31._name = "Ross";
        commentV31._comment = "This was weird.";
        Comment commentV32 = new Comment();
        commentV32._name = "Ursula";
        commentV32._comment = "Was not expecting that!";
        Comment commentV33 = new Comment();
        commentV33._name = "Smarty";
        commentV33._comment = "What did I just watch?";
        Comment commentV34 = new Comment();
        commentV34._name = "Stinky Joe";
        commentV34._comment = "I smell better than this content.";

        // Adding comments to Video 1
        video1._comments = new List<Comment>();
        video1._comments.Add(commentV11);
        video1._comments.Add(commentV12);
        video1._comments.Add(commentV13);
        video1._comments.Add(commentV14);

        // Adding comments to Video 2
        video2._comments = new List<Comment>();
        video2._comments.Add(commentV21);
        video2._comments.Add(commentV22);
        video2._comments.Add(commentV23);
        video2._comments.Add(commentV24);

        // Adding comments to Video 3
        video3._comments = new List<Comment>();
        video3._comments.Add(commentV31);
        video3._comments.Add(commentV32);
        video3._comments.Add(commentV33);
        video3._comments.Add(commentV34);

        // Display Video 1 details
        video1.DisplayVideoDetails();

        // Display Video 2 details
        video2.DisplayVideoDetails();

        // Display Video 3 details
        video3.DisplayVideoDetails();
    }
}