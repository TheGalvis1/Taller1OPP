using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricFigures.Backend;

public class Parallelogram : Rectangle
{
    private double _h;

    public double H
    {
        get => _h;
        set => _h = ValidateH(value);
    }

    public Parallelogram(string name, double a, double b, double h) : base(name, a, b)
    {
        H = h;
    }

    public override double GetArea()
    {
        return B * H;
    }

    public override double GetPerimiter()
    {
        return 2 * (A + B);
    }


    private double ValidateH(double h)
    {
        if (h <= 0)
        {
            throw new ArgumentException("The height must be greater than 0.");
        }
        return h;
    }
}
