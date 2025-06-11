using System;
using MovieIndustry.Entities;

namespace MovieIndustry.Studying
{
    internal static class EntitiesTraining
    {
        internal static void Run()
        {
            Console.WriteLine(" === EntitiesTraining ===");

            StudyMovies();
        }

        private static void StudyMovies()
        {
            Console.WriteLine(" --- StudyMovies ---");

            Movie movie1 = new Movie();
            Console.WriteLine("movie1.Key: {0}", movie1.Key);
            Console.WriteLine("movie1.ToString:\n{0}", movie1.ToString());

            movie1.Id = 1;
            movie1.Title = "Інтерстеллар";
            movie1.Director = "Крістофер Нолан";
            movie1.Year = 2014;
            movie1.Genre = "Наукова фантастика";
            movie1.Description = "Фільм про подорож групи дослідників у крізь космос через червоточину у пошуках нового дому для людства.";
            movie1.Note = "Фільм отримав премію Оскар за найкращі візуальні ефекти.";

            Console.WriteLine("movie1.Key: {0}", movie1.Key);
            Console.WriteLine("movie1.ToString:\n{0}", movie1.ToString());

            Console.WriteLine(new string('-', Console.BufferWidth - 1));
            Console.WriteLine("movie1:\n{0}", movie1);
            Console.WriteLine(new string('=', Console.BufferWidth - 1));

            Movie movie2 = new Movie("Темний лицар", "Крістофер Нолан", 2008)
            {
                Id = 2,
                Genre = "Екшн",
                Note = "Один з найуспішніших фільмів про Бетмена."
            };
            Console.WriteLine("movie2:\n{0}", movie2);

            Movie movie3 = new Movie("Паразити", "Пон Чжун Хо", 2019)
            {
                Id = 3,
                Genre = "Трилер",
                Note = "Перший фільм іноземною мовою, що виграв Оскар як найкращий фільм.",
            };
            Console.WriteLine("movie3:\n{0}", movie3);
        }
    }
}