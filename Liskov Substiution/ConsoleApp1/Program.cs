

Rectangle rectangle = new Rectangle { Width = 5, Height = 4 };
Console.WriteLine("Rectangle Area: " + rectangle.Area());

Square square = new Square { SideLength = 5 };
Console.WriteLine("Square Area: " + square.Area());


public class Shape
{
    public virtual double Area()
    {
        return 0;
    }
}

public class Rectangle : Shape
{
    public double Witdh { get;set; }
    public double Heigth { get;set;}

    public override double Area()
    {
        return Witdh * Heigth;
    }
}

public class Square : Shape
{
    public double SideLength { get; set; }

    public override double Area()
    {
        return SideLength * SideLength;
    }
}


