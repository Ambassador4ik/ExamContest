using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string inputFile = "input.txt";
        string[] word = Fixer.ReadAndFix(inputFile);
        Console.WriteLine(string.Join(" ", word));
    }
}