class Activity
{
    protected string name;
    protected string description;
    protected int _duration; // Changed accessibility to protected and renamed to _duration

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    // Setter for duration
    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {name} activity...");
        Thread.Sleep(2000); // Pause for 2 seconds
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds
    }

    public void End()
    {
        Console.WriteLine($"Congratulations! You've completed the {name} activity.");
        Console.WriteLine($"Duration: {_duration} seconds");
        Thread.Sleep(2000); // Pause for 2 seconds
    }
}