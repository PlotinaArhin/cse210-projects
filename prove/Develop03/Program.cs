using System;

class Program

    static void Main(string[] args)
    {
        public class Fraction
{
    // Private attributes for the top and bottom numbers
    private int top;
    private int bottom;

    // Constructors
    // Constructor that initializes the number to 1/1
    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    // Constructor that initializes the top number and sets the bottom to 1
    public Fraction(int top)
    {
        this.top = top;
        bottom = 1;
    }

    // Constructor that initializes both top and bottom numbers
    public Fraction(int top, int bottom)
    {
        this.top = top;
        this.bottom = bottom;
    }

    // Getters and setters for top and bottom numbers
    public int GetTop()
    {
        return top;
    }

    public void SetTop(int top)
    {
        this.top = top;
    }

    public int GetBottom()
    {
        return bottom;
    }

    public void SetBottom(int bottom)
    {
        this.bottom = bottom;
    }

    // Method to return the fraction representation as a string
    public string GetFractionString()
    {
        return $"{top}/{bottom}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)top / bottom;
    }
    }
}