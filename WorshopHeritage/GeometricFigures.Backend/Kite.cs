using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricFigures.Backend;

public class Kite : Rhombus
{
    
    private double _b;
    
    public Kite(string name, double a, double d1, double d2, double b) :
        base(name, a, d1, d2)
    {
        B = b;
    }

    
    public double B
    {
        get => _b;
        set => _b = ValidateB(value);
    }
    
    public override double GetArea()
    {
        return (D1 * D2) / 2;
    }

    public override double GetPerimiter()
    {
        return 2 * (A + B);
    }

    private double ValidateB(double b)
    {
        if (b <= 0)
        {
            throw new ArgumentException("The side length must be greater than 0.");
        }
        return b;
    }

}