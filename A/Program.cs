using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamContest;

internal class Program
{
    public static void Main(string[] args)
    {
        var nums = new List<int>();
        while (true)
        {
            var num = int.Parse(Console.ReadLine()!);
            if (num == 0)
            {
                break;
            }
            nums.Add(num);
        }
        var numsCopy = new List<int>(nums);
        numsCopy.Sort();
        Console.WriteLine(nums.SequenceEqual(numsCopy));
    }
}