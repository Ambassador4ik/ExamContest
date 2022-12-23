internal abstract class Average
{
    protected int[] numbers;

    public Average(int[] numbers)
    {
        this.numbers = numbers;
    }

    public abstract int this[double num] { get; }
        
    public abstract double GetAverage();
}