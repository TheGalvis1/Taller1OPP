using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricFigures.Backend;

public class Circle : GeometricFigure
{
    private double _r;

    public double R
    {
        get => _r;
        set => _r = ValidateR(value);
    }

    public Circle(string name, double r) : base(name)
    {
        R = r;
    }

    public override double GetArea()
    {
        return Math.PI * R * R;
    }

    public override double GetPerimiter()
    {
        return 2 * Math.PI * R;
    }

    private double ValidateR(double r)
    {
        if (r <= 0)
            throw new ArgumentException("Radius must be greater than 0");
        return r;
    }
}