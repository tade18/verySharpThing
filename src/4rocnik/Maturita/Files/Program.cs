using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var movies = new Movies("./movies.csv");
        
        Console.WriteLine("");
        foreach (var movie in movies.MovieList)
        {
            Console.WriteLine($"{movie.Film} ({movie.Year}): {movie.Genre}, score: {movie.AudienceScore}, {movie.WorldwideGross}");
        }
        
        
        //NEJHORSI RATING-----------------------------------------------------
        var worstByYear = movies.MovieList
            .GroupBy(m => m.Year)
            .Select(g => new
            {
                Year = g.Key,
                WorstMovie = g.OrderBy(m => m.AudienceScore).First()
            });

        foreach (var item in worstByYear)
        {
            Console.WriteLine($"Rok: {item.Year}, Film: {item.WorstMovie.Film}, Nejhorší rating: {item.WorstMovie.AudienceScore}");
        }
        
        //NEJLEPSI RATING------------------------------------------------------
        Console.WriteLine("");
        var bestByYear = movies.MovieList.GroupBy(m => m.Year)
            .Select(g => new
            {
                Year = g.Key,
                BestMovie = g.OrderBy(m => m.AudienceScore).Last()
            });

        foreach (var item in bestByYear)
        {
            Console.WriteLine($"Rok: {item.Year}, Film: {item.BestMovie.Film} Nejlepší rating: {item.BestMovie.AudienceScore}");
        }
        
        //NEJLEPSI PROFIT------------------------------------------------------
        Console.WriteLine("");
        var bestProfitByYear = movies.MovieList.GroupBy(m => m.Year)
            .Select(g => new
            {
                Year = g.Key,
                BestProfit = g.OrderBy(m => m.Profitability).Last()
            });

        foreach (var item in bestProfitByYear)
        {
            Console.WriteLine($"Rok: {item.Year}, Film: {item.BestProfit.Film} Nejvýdělečnější: {item.BestProfit.Profitability}");
        }
        
        //NEJHORSI PROFIT------------------------------------------------------
        Console.WriteLine("");
        var worstProfitByYear = movies.MovieList.GroupBy(m => m.Year)
            .Select(g => new
            {
                Year = g.Key,
                WorstProfit = g.OrderBy(m => m.Profitability).First()
            });

        foreach (var item in worstProfitByYear)
        {
            Console.WriteLine($"Rok: {item.Year}, Film: {item.WorstProfit.Film} Nejmenší výdělek: {item.WorstProfit.Profitability}");
        }



        Console.WriteLine(" ");
        var resultByYear = movies.MovieList.GroupBy(m => m.Year)
            .Select(g => new
            {
                Year = g.Key,
                AverageRevenue = g.Average(m => m.WorldwideGross)
            });

        foreach (var item in resultByYear)
        {
            Console.WriteLine(
                $"Rok: {item.Year}, Průměrný výdělek: {item.AverageRevenue}"
            );
        }
    }
}