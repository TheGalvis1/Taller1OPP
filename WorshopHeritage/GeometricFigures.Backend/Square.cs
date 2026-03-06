using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricFigures.Backend;

public class Square : GeometricFigure
{
    
    private double _a;

    
    public Square(string name, double a) :
        base(name)
    {
        A = a;
    }

    
    public double A
    {
        get => _a;
        set => _a = value;
    }
    
    public override double GetArea()
    {
        return Math.Pow(A, 2);
    }

    public override double GetPerimiter()
    {
        return 4 * A;
    }

    private double ValidateA(double a)
    {
        if (a <= 0)
        {
            throw new ArgumentException("The side length must be greater than 0.");
        }
        return a;
    }
}