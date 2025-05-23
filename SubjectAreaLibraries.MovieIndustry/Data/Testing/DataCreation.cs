using System.Collections.Generic;
using SubjectAreaLibraries.MovieIndustry.Entities;

namespace SubjectAreaLibraries.MovieIndustry.Data.Testing
{
    public static class DataCreation
    {
        public static bool CreateTestingData(this PrimDataSet dataSet)
        {
            if (dataSet.IsEmpty())
            {
                CreateTestingMovies(dataSet.Movies);
                return true;
            }
            return false;
        }

        public static void CreateTestingMovies(ICollection<Movie> movies)
        {
            movies.Add(new Movie("Inception", "Christopher Nolan", "Science Fiction", 2010, 8.8)
            {
                Id = 1,
                Note = "Inception is a 2010 science fiction action film written and directed by Christopher Nolan.",
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea."
            });

            movies.Add(new Movie("The Godfather", "Francis Ford Coppola", "Crime", 1972, 9.2)
            {
                Id = 2,
            });

            movies.Add(new Movie("Parasite", "Bong Joon-ho", "Thriller", 2019, 8.6)
            {
                Id = 3,
                Note = "Won the Academy Award for Best Picture in 2020.",
            });

            movies.Add(new Movie("Pulp Fiction", "Quentin Tarantino", "Crime", 1994, 8.9)
            {
                Id = 4,
            });

            movies.Add(new Movie("The Shawshank Redemption", "Frank Darabont", "Drama", 1994, 9.3)
            {
                Id = 5,
            });

            movies.Add(new Movie("The Matrix", "The Wachowskis", "Science Fiction", 1999, 8.7)
            {
                Id = 6,
            });
        }
    }
}