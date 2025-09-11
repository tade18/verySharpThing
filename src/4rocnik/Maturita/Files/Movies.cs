using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

public class Movies
{
    public List<Movie> MovieList { get; private set; }

    public Movies(string filePath)
    {
        MovieList = new List<Movie>();
        LoadFromCsv(filePath);
    }

    private void LoadFromCsv(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            // Přeskočení hlavičky
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                // Kontrola, zda máme dostatek sloupců
                if (values.Length < 8)
                {
                    Console.WriteLine($"Chybí data v řádku: {line}");
                    continue;
                }

                var movie = new Movie
                {
                    Film = values[0],
                    Genre = values[1],
                    LeadStudio = values[2],
                    AudienceScore = TryParseDouble(values[3]),
                    Profitability = TryParseDouble(values[4]),
                    RottenTomatoes = TryParseDouble(values[5]),
                    WorldwideGross = TryParseDouble(values[6]),
                    Year = TryParseInt(values[7])
                };

                MovieList.Add(movie);
            }
        }
    }

    private double TryParseDouble(string value)
    {
        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
        {
            return result;
        }
        return 0; // Výchozí hodnota, pokud se nepodaří parsovat
    }

    private int TryParseInt(string value)
    {
        if (int.TryParse(value, out int result))
        {
            return result;
        }
        return 0; // Výchozí hodnota, pokud se nepodaří parsovat
    }
}