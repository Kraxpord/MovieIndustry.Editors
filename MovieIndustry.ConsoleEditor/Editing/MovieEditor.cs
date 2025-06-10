using Common.Collection;
using Common.ConsoleUI;
using System;
using System.Collections.Generic;
using MovieIndustry.Data;
using MovieIndustry.Data.Formatting;
using MovieIndustry.Entities;

namespace MovieIndustry.Editing
{
    internal class MovieEditor
    {
        private readonly SimpleCommandController _commandController;

        private readonly PrimDataContext _dataContext;
        private readonly ICollection<Movie> _collection;
        private Common.ConsoleUI.MenuItem[] _menuItems;

        public MovieEditor(PrimDataContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException(nameof(dataContext));
            }

            _dataContext = dataContext;
            _collection = dataContext.Movies;

            IniMenuItems();

            _commandController = new SimpleCommandController(
                _menuItems,
                PrepareScreen,
                PrepareRunning
            );
        }

        public void Run()
        {
            _commandController.Run();
        }

        private void IniMenuItems()
        {
            _menuItems = new Common.ConsoleUI.MenuItem[]
            {
                new Common.ConsoleUI.MenuItem("вийти", null),
                new Common.ConsoleUI.MenuItem("створити тестові дані", CreateTestingData),
                new Common.ConsoleUI.MenuItem("дані як текст", ShowAsText, true),
            };
        }

        private void PrepareScreen()
        {
            Console.Clear();
            Console.WriteLine("ПО \"Кіностудія\"\n");
            Console.WriteLine(_collection.ToTable());
        }

        private void PrepareRunning()
        {
            SimpleCommandController.StopToView();
        }

        private void CreateTestingData()
        {
            if (!_dataContext.CreateTestingData())
            {
                Console.WriteLine("\n  Тестові дані не створені, оскільки сховище не порожнє.");
                SimpleCommandController.StopToView();
            }
        }

        private void ShowAsText()
        {
            Console.WriteLine("\nФільми:\n");

            int i = 1;
            foreach (var movie in _collection)
            {
                Console.WriteLine(
                    string.Format(
                        "\tФільм №{0}\n" +
                        "\t  Назва: {1}\n" +
                        "\t  Режисер: {2}\n" +
                        "\t  Рік виходу: {3}\n" +
                        "\t  Жанр: {4}\n" +
                        "\t  Рейтинг: {5}\n" +
                        "\t  Примітка: {6}\n" +
                        "\t  Опис: {7}\n",
                        i++,
                        movie.Title ?? "—",
                        movie.Director ?? "—",
                        movie.ReleaseYear?.ToString() ?? "—",
                        movie.Genre ?? "—",
                        movie.Rating?.ToString("0.0") ?? "—",
                        movie.Note ?? "—",
                        movie.Description ?? "—"
                    )
                );
            }

            SimpleCommandController.StopToView();
        }
    }
}