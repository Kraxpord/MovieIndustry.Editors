using Common.Collection;
using Common.ConsoleIO;
using Common.ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private MenuItem[] _menuItems;

        public MovieEditor(PrimDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
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
            _menuItems = new MenuItem[]
            {
                new MenuItem("вийти", null),
                new MenuItem("створити тестові дані", CreateTestingData),
                new MenuItem("дані як текст", ShowAsText, true),
                new MenuItem("видалити усі дані", Clear),
                new MenuItem("зберегти дані", Save, stopping: true),
                new MenuItem("детально про...", ShowObjectDetails, true),
                new MenuItem("додати фільм", Add),
                new MenuItem("видалити фільм", Remove)
            };
        }

        private void PrepareRunning()
        {
            if (_dataContext.Load())
                Console.WriteLine("  Дані завантажено");
            else
                Console.WriteLine("  Файл з даними відсутній");

            SimpleCommandController.StopToView();
        }

        private void PrepareScreen()
        {
            Console.Clear();
            Console.WriteLine("ПО \"Кіностудія\"\n");
            Console.WriteLine(_collection.ToTable());
        }

        private void CreateTestingData()
        {
            if (!_dataContext.CreateTestingData())
            {
                Console.WriteLine("\n  Тестові дані не створені, оскільки сховище не порожнє.");
                SimpleCommandController.StopToView();
            }
        }

        private void Clear()
        {
            _dataContext.Clear();
        }

        private void ShowAsText()
        {
            Console.WriteLine();
            Console.WriteLine(_collection.ToLineList("Фільми"));
        }

        private void ShowObjectDetails()
        {
            int id = Inputting.InputInt32(" Введіть Id фільму");
            Movie movie = _collection.FirstOrDefault(m => m.Id == id);

            if (movie != null)
            {
                Console.WriteLine(movie);
            }
            else
            {
                Console.WriteLine($"  У списку немає фільму з Id = {id}");
            }
        }

        private void Add()
        {
            Console.WriteLine();
            Movie movie = new Movie();

            movie.Title = Inputting.InputString("Назва фільму");
            movie.Director = Inputting.InputString("Режисер");
            movie.ReleaseYear = Inputting.InputNullableInt32("Рік випуску");
            movie.Genre = Inputting.InputString("Жанр");
            movie.Rating = Inputting.InputNullableDouble("Рейтинг (0–10)");
            movie.Note = Inputting.InputString("Примітка");
            movie.Description = Inputting.InputString("Опис");

            movie.Id = _collection.Any() ? _collection.Max(m => m.Id) + 1 : 1;
            _collection.Add(movie);
        }

        private void Remove()
        {
            int id = Inputting.InputInt32(" Введіть Id фільму");
            Movie movie = _collection.FirstOrDefault(m => m.Id == id);

            if (movie != null)
            {
                _collection.Remove(movie);
            }
            else
            {
                Console.WriteLine($"  У списку немає фільму з Id = {id}");
            }
        }

        private void Save()
        {
            _dataContext.Save();
            Console.WriteLine("  Дані збережено");
        }
    }
}