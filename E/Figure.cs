using System;
using System.Collections.Generic;
using System.Linq;
using ExamContest;

internal class Figure
{
    protected List<Point> points;
    public Figure(List<Point> points) => this.points = points;

    protected virtual double GetPerimeter() => 1.000;

    protected virtual double GetSquare() => 1.000;

    public static Figure GetFigure(string line)
    {
        List<Point> pairs;
        string type;
        try
        {
            var raw = line.Split(' ');
            type = raw[0];
            var points = raw.Skip(1).Select(int.Parse).ToList();
            // Combine points into pairs
            pairs = new List<Point>();
            for (var i = 0; i < points.Count; i += 2)
                pairs.Add(new Point(points[i], points[i + 1]));
            
            //pairs = points.Select((x, y) => new Point(x, y)).ToList();
        }
        catch (Exception)
        {
            throw new ArgumentException("Incorrect input");
        }

        // Create figure
        return type switch
        {
            "Figure" => new Figure(pairs),
            "Rhombus" => new Rhombus(pairs),
            "Circle" => new Circle(pairs),
            _ => throw new ArgumentException("Incorrect input")
        };
    }
    
    public static double Distance(Point a, Point b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

    public override string ToString()
    {
        return $"{this.GetType().Name} P = {GetPerimeter():F3}; S = {GetSquare():F3};";
    }
}