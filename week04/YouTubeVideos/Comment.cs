public class Comment
{
    public string _name;
    public string _comment;

    public void DisplayCommentDetails()
    {
        Console.WriteLine($"{_name}: {_comment}\n");
    }
}