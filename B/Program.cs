using System;
using System.Linq;

namespace ExamContest;

internal class Program
{
    public static void Main(string[] args)
    {
        var nums = Console.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        var module = int.Parse(Console.ReadLine()!);
        Console.WriteLine(nums.Select(x => x % module).ToList().Sum());
    }
}