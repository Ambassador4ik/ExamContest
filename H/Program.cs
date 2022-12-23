using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string inputFile = "input.txt";
        int[] arr = Reader.ReadFile(inputFile);
        Console.WriteLine(string.Join(" " ,arr));
    }
}