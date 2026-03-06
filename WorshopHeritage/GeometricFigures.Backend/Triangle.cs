using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricFigures.Backend;

public class Triangle : Rectangle
{
    private double _c;
    private double _h;


public Triangle(string name, double a, double b, double c, double h) : base(name, a, b)
    {
        C = c;
        H = h;
    }

    public double C
    {
        get => _c;
        set => _c = ValidateC(value);
    }

    public double H
    {
        get => _h;
        set => _h = ValidateH(value);
    }

    public override double GetArea()
    {
        return (B * H) / 2;
    }

    public override double GetPerimiter()
    {
        return A + B + C;
    }

    private double ValidateC(double c)
    {
        if (c <= 0)
        {
            throw new ArgumentException("The side length must be greater than 0.");
        }
        return c;
    }

    private double ValidateH(double c)
    {
        if (c <= 0)
        {
            throw new ArgumentException("The height must be greater than 0.");
        }
        return c;
    }


}