using System;

public class Program
{
    public static void Main()
    {
        var movies = new Movies("./movies.csv");

        foreach (var movie in movies.MovieList)
        {
            Console.WriteLine($"{movie.Film} ({movie.Year}): {movie.Genre}");
        }
    }
}