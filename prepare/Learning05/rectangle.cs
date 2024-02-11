public class Rectangle : Shape 
{
    private double_length;
    private double_width;

    public Rectangle(string color , double length, double width) : base(color)
    {
        _length =length;
        _width = width;
    }

    //Notice the use of the override keyword here
    public overide double GetArea()
    {
        return _length * _width;
    
    }
}
