using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shape = new List<Shape>();

        Square square1 = new Square("Blue", 34);
        shape.Add(square1);

        Square square2 = new Square("Pink", 4);
        shape.Add(square2);

        Circle circle1 = new Circle("Red", 23);
        shape.Add(circle1);

        Circle circle2 = new Circle("Purple", 17);
        shape.Add(circle2);

        Rectangle rectangle1 = new Rectangle("Yellow", 5, 3);
        shape.Add(rectangle1);

        Rectangle rectangle2 = new Rectangle("Green", 15, 8);
        shape.Add(rectangle2);

        foreach (Shape s in shape)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}