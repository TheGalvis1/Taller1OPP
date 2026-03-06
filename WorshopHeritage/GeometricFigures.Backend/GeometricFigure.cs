using System.Diagnostics.Metrics;
namespace GeometricFigures.Backend;

public abstract class GeometricFigure
{
    public string Name { get; set; }

    public GeometricFigure(string name)
    {
        Name = name;
    }

    public abstract double GetArea();

    public abstract double GetPerimiter();

    public override string ToString()
    {
        return $"{Name,-15} => Area.....: {GetArea(),15:N5}    Perimiter: {GetPerimiter(),15:N5}";
    }
}
