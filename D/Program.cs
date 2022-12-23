using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        string fillType = Console.ReadLine();
        Matrix matrix = new Matrix(new int[size, size]);
        try
        {
            matrix.FillMatrix(fillType);
            Console.WriteLine(matrix);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}