// set the  comment below  about the abstract method .Because we hve an abstract method,
// this class must also  be declared as an abstract class.
public abstract class Shape
{
    private string_color;
    
    public Shape(string color )
    {
        _color = color;
    }

    public sring GetColor()
    {
        return _color;
    }

    public void Setcolor(sring color)
    {
        _color = color;
    }

    //Because it does not make sense to define a default body for this method in the 
    //base class, rather than make a "virtua" function here like this:
    //
    //public virtual double GetArea()
    //{
    // return 0;
    //}
    // We can instead declare the function as an "abstract" function. That means
    // any class that inherits from Shape. Then, any class that has an abstract method
    //must also be declared to be abstract.
    public abstrcat double GetArea();   
    }
    