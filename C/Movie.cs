using System;
using System.Linq;

internal class Movie
{
    public string Name { get; set; }
    public int Views { get; set; }
    public double Rating { get; set; }

    private Movie(string name, int views, double rating)
    {
        Name = name;
        Views = views;
        Rating = rating;
    }

    public static Movie Parse(string line)
    {
        //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        try
        {
            var parts = line.Split(' ');
            if (int.Parse(parts[1]) < 0 || double.Parse(parts[2]) is < 0 or > 10)
            {
                throw new ArgumentException("Incorrect input");
            }
            return new Movie(parts[0], int.Parse(parts[1]), double.Parse(parts[2]));
        }
        catch (Exception)
        {
            throw new ArgumentException("Incorrect input");
        }
        
    }

    public static double GetAverageRating(Movie[] movies, int minViews, int maxViews)
    {
        var goodMovies = movies.Where(x => x.Views >= minViews && x.Views <= maxViews).ToList();
        return !goodMovies.Any() ? 0.000 : goodMovies.Average(x => x.Rating);
    }
}
