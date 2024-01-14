using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string answer = Console.ReadLine();
        int.Parse(answer);

          char letter = ' '; // Variable to store the letter grade
        string sign = "";  // Variable to store the grade sign (+, -, or "")

        // Determine the letter grade
        if (Percentage >= 90)
        {
            letter = 'A';
    }
     else if (Percentage >= 80)
        {
            letter = 'B';
        }
        else if (Percentage >= 70)
        {
            letter = 'C';
        }
        else if (Percentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        // Determine the grade sign
        if (Percentage % 10 >= 7)
        {
            sign = "+";
        }
        else if (Percentage % 10 < 3)
        {
            sign = "-";
        }

        // Print the letter grade and message
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Check if the user passed the course and display a message
        if (Percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard. You'll do better next time!");
        }
    }
}