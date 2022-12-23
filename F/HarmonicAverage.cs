using System;
using System.Collections.Generic;
using System.Linq;

internal class HarmonicAverage : Average
{
    public HarmonicAverage(int[] arr) : base(arr) { }

    public override double GetAverage()
    {
        double sum = numbers.Sum(number => 1.0 / number);
        return numbers.Length / sum;
    }
    
    public override int this[double num]
    {
        get
        {
            var numbersCopy = numbers.ToList();
            // Find index of the number closest to num
            // It should be greater than num
            int index = Array.FindIndex(numbersCopy.ToArray(), n => n > num);
            var indexes = new List<int>();
            while (index >= 0)
            {
                indexes.Add(index);
                index = Array.FindIndex(numbersCopy.ToArray(), index + 1, n => n > num);
            }
            
            if (indexes.Count == 0)
            {
                throw new ArgumentException("Number does not exist");
            }
            index = indexes.MinBy(x => numbers[x]);
            
            if (index == -1)
                throw new ArgumentException("Number does not exist");
            return numbers[index];
        }
    }
}
