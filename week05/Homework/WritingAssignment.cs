public class WrittingAssignment : Assignment
{
    private string _title;

    public WrittingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWrittingInformation()
    {
        return $"Student Name: {base._studentName}\nTopic: {base._topic}\nTitle: {_title}\n";
    }
}