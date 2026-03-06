using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricFigures.Backend;

public class Trapeze : Triangle
{
    private double _d;

    public double D
    {
        get => _d;
        set => _d = value;
    }

    public Trapeze(string name, double a, double b, double c, double h, double d) : base(name, a, b, c, h)
    {
        D = d;
    }

    public override double GetArea()
    {
        return ((B + D) * H) / 2;
    }

    public override double GetPerimiter()
    {
        return A + B + C + D;
    }

    private double ValidateD(double d)
    {
        if (d <= 0)
        {
            throw new ArgumentException("The side length must be greater than 0.");
        }
        return d;
    }
}

