using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name ? ");
        string first = Console.ReadLine();

        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        Console.Write("What is your date of birth");
        string dateofbirth = Console.ReadLine();

        Console.Write("Where are you from ?");
        string place = Console.ReadLine();

        Console.WriteLine( $"Your first name is {last}, {first} {last}, {dateofbirth}, {place} ");

        
    }
}