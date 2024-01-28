using System;

class Program
{
    static void Main(string[] args)
    {
        // Create instances using different constructors
        Fraction fraction1 = new Fraction();      // Initializes to 1/1
        Fraction fraction2 = new Fraction(5);     // Initializes to 5/1
        Fraction fraction3 = new Fraction(3, 4);  // Initializes to 3/4
        Fraction fraction4 = new Fraction(1, 3);  // Initializes to 1/3

        // Display fractions and their representations
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());
    }
}