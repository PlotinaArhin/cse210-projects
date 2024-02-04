using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness App!");

        // Create instances of activities
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity listingActivity = new ListingActivity();

        // Menu system
        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }

            if (choice == 1)
            {
                Console.WriteLine("Enter duration for Breathing Activity (in seconds):");
                int duration;
                while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
                breathingActivity.duration = duration;
                breathingActivity.PerformActivity();
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter duration for Reflection Activity (in seconds):");
                int duration;
                while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
                reflectionActivity.duration = duration;
                reflectionActivity.PerformActivity();
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter duration for Listing Activity (in seconds):");
                int duration;
                while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
                listingActivity.duration = duration;
                listingActivity.PerformActivity();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Exiting program...");
                break;
            }
        }
    }
}
