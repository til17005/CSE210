public class Video
{
    public string _title;
    public string _author;
    public int _lengthInSeconds;
    public List<Comment> _comments;
    public void DisplayVideoDetails()
    {
        Console.WriteLine("#############################################");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine("-----------------------------------\n");

        foreach (Comment comment in _comments)
        {
            comment.DisplayCommentDetails();
        }
        Console.WriteLine("#############################################\n");
    }
}