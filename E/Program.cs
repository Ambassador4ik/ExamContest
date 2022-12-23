using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < count; i++)
        {
            try
            {
                Console.WriteLine(Figure.GetFigure(Console.ReadLine()));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
