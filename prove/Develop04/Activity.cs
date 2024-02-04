class Activity
{
    protected string name;
    protected string description;
    protected int duration; // Changed accessibility to protected

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
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
        Console.WriteLine($"Duration: {duration} seconds");
        Thread.Sleep(2000); // Pause for 2 seconds
    }
}