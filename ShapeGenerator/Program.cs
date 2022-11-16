// See https://aka.ms/new-console-template for more information
using System.Reflection;

Console.WriteLine("Hello, World!");
Shape s = new Shape();
Console.WriteLine(typeof(s));




class Shape
{
    int sides;
    int area;
    string name;

    public Shape()
    {
        Random random = new Random();
        int[] classes = new int[] { 1, 2, 3, 4, 5 };
        var randomChosen = random.Next(0, 5);
        switch (randomChosen)
        {
            default:
                break;
        }
    }

}

class Rectangle : Shape
{

}

class Square : Rectangle
{

}

class Triangle : Shape
{

}

class RightAngle : Triangle
{

}

class IsoTriangle : Triangle
{

}

