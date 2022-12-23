using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        
        Average harmonicAverage = new HarmonicAverage(arr);
        
        try
        {
            Console.WriteLine(harmonicAverage[harmonicAverage.GetAverage()]);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}