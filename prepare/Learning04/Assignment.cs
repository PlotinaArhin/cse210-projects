public class Assignment
{
    private string_studentName;
    private string_topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
    
    //We will provide Getters for our private member variables so they can be accessed
    //later both outside the class as well is in derived classes.
    public string GetStudentName()
    {
         return _studentName;
    }

    public string GetTopic()
    {
        return _ topic;

    }

    public string GetSummary()
    {
        return _ studentName + " - " + _topic;
    }
}