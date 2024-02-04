class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void PerformActivity()
    {
        Start();
        Console.WriteLine("Start breathing...");
        for (int i = 0; i < duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000); // Pause for 2 seconds
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000); // Pause for 2 seconds
        }
        End();
    }
}