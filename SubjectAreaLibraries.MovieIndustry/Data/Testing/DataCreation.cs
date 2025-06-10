using System;
using System.Collections.Generic;
using MovieIndustry.Entities;

namespace MovieIndustry.Data.Testing
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
            movies.Add(new Movie("Inception", "Christopher Nolan", 2010, "Science Fiction", 8.8)
            {
                Id = 1,
                Description = "A thief who steals corporate secrets through dream-sharing technology is given the inverse task of planting an idea.",
                Note = "Award-winning film known for its complex narrative."
            });

            movies.Add(new Movie("The Godfather", "Francis Ford Coppola", 1972, "Crime", 9.2)
            {
                Id = 2,
                Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.",
                Note = "Considered one of the greatest films in world cinema."
            });

            movies.Add(new Movie("Parasite", "Bong Joon-ho", 2019, "Thriller", 8.6)
            {
                Id = 3,
                Description = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan.",
                Note = "First non-English language film to win Best Picture at the Oscars."
            });

            movies.Add(new Movie("Pulp Fiction", "Quentin Tarantino", 1994, "Crime", 8.9)
            {
                Id = 4,
                Description = "The lives of two mob hitmen, a boxer, and a gangster's wife intertwine in tales of violence and redemption.",
                Note = "Known for its nonlinear storyline and iconic dialogues."
            });

            movies.Add(new Movie("The Shawshank Redemption", "Frank Darabont", 1994, "Drama", 9.3)
            {
                Id = 5,
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption.",
                Note = "Ranks among the highest-rated movies on IMDb."
            });

            movies.Add(new Movie("The Matrix", "The Wachowskis", 1999, "Science Fiction", 8.7)
            {
                Id = 6,
                Description = "A hacker discovers the nature of reality and his role in the war against its controllers.",
                Note = "Revolutionized special effects with 'bullet time'."
            });
        }
    }
}