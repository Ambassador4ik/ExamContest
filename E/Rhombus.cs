using System;
using System.Collections.Generic;

namespace ExamContest;

internal class Rhombus : Figure
{
    public Rhombus(List<Point> points) : base(points) { }
    
    protected override double GetSquare()
    {
        return 0.5 * Distance(points[0], points[1]) * Distance(points[2], points[3]);
    }
    
    protected override double GetPerimeter()
    {
        return 4 * Distance(points[0], points[2]);
    }
}