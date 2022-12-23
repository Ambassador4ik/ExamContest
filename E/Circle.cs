using System;
using System.Collections.Generic;

namespace ExamContest;

internal class Circle : Figure
{
    public Circle(List<Point> points) : base(points) { }
    
    protected override double GetSquare()
    {
        var dist = Distance(points[0], points[1]);
        return Math.PI * Math.Pow(dist, 2);
    }

    protected override double GetPerimeter()
    {
        var dist = Distance(points[0], points[1]);
        return 2 * Math.PI * dist;
    }
}