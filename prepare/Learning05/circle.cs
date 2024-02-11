public class Circle : Shape
{
    private double_radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    //Notice the use of the override keyword here 
    public override double GetArea ()
    {
        return_radius * _radius * Math.PI;
    }
}