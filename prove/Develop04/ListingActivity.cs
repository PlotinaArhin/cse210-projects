class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void PerformActivity()
    {
        Start();
        Random rnd = new Random();
        int randomIndex = rnd.Next(prompts.Length);
        Console.WriteLine(prompts[randomIndex]);
        Console.WriteLine("Start listing...");
        Thread.Sleep(duration * 1000); // Pause for duration seconds
        Console.WriteLine("You've listed as many items as you can.");
        End();
    }
}