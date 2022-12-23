using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int moviesCount = int.Parse(Console.ReadLine());
        string[] minMaxViews = Console.ReadLine().Split();
        int minViews = int.Parse(minMaxViews[0]);
        int maxViews = int.Parse(minMaxViews[1]);
        Movie[] movies = new Movie[moviesCount];
        try
        {
            for (int i = 0; i < movies.Length; i++)
            {
                movies[i] = Movie.Parse(Console.ReadLine());
            }

            Console.WriteLine($"{Movie.GetAverageRating(movies, minViews, maxViews):F3}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}