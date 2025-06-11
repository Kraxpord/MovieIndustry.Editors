using System;
using System.Collections.Generic;
using MovieIndustry.Entities;

namespace MovieIndustry.Data
{
    [Serializable]
    public class PrimDataSet
    {
        // Основна колекція фільмів
        public readonly List<Movie> Movies = new List<Movie>();

        public object Movie { get; internal set; }

        public void Clear()
        {
            Movies.Clear();
        }

        public virtual bool IsEmpty()
        {
            return Movies.Count == 0;
        }

        public void CopyTo(PrimDataSet other)
        {
            foreach (var movie in Movies)
                other.Movies.Add(movie);
        }

        public string ToDataString(string title = "")
        {
            return title + ":\n" + string.Join("\n", Movies);
        }

        public bool CreateTestingData()
        {
            Movies.Clear();

            Movies.Add(new Movie("Inception", "Christopher Nolan", 2010, "Sci-Fi") { Rating = 8.8 });
            Movies.Add(new Movie("The Matrix", "Lana Wachowski", 1999, "Action") { Rating = 8.7 });
            Movies.Add(new Movie("Parasite", "Bong Joon-ho", 2019, "Thriller") { Rating = 8.6 });

            return true;
        }
    }
}