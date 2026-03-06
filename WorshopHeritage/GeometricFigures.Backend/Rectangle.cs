using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricFigures.Backend
{
    public class Rectangle : Square
    {
        private double _b;
        public double B
        {
            get => _b;
            set => _b = ValidateB(value);
        }
        public Rectangle(string name, double a, double b) : base(name, a)
        {
            B = b;
        }
        public override double GetArea()
        {
            return A * B;
        }
        public override double GetPerimiter()
        {
            return 2*(A + B);
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
}
