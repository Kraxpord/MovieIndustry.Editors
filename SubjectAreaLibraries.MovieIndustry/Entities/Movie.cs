using System;

namespace MovieIndustry.Entities
{
    [Serializable]
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int? ReleaseYear { get; set; }
        public string Genre { get; set; }
        public double? Rating { get; set; } // Рейтинг, наприклад IMDb
        public string Note { get; set; }
        public string Description { get; set; }

        public string Key => Title;

        // Основний конструктор
        public Movie(string title, string director, int? releaseYear, string genre, double? rating = null)
        {
            Title = title;
            Director = director;
            ReleaseYear = releaseYear;
            Genre = genre;
            Rating = rating;
        }

        // Без рейтингу
        public Movie(string title, string director, int? releaseYear, string genre)
            : this(title, director, releaseYear, genre, null)
        { }

        // Порожній конструктор — обов'язковий для XML/JSON-серіалізації
        public Movie() { }

        public override string ToString()
        {
            return string.Format(
                "\tФільм №{0}\n" +
                "\t  Назва: {1}\n" +
                "\t  Режисер: {2}\n" +
                "\t  Рік виходу: {3}\n" +
                "\t  Жанр: {4}\n" +
                "\t  Рейтинг: {5}\n" +
                "\t  Примітка: {6}\n" +
                "\t  Опис: {7}",
                Id,
                Title ?? "Невідомо",
                Director ?? "Невідомо",
                ReleaseYear?.ToString() ?? "Невідомо",
                Genre ?? "Невідомо",
                Rating?.ToString("0.0") ?? "Немає",
                Note ?? "—",
                Description ?? "—"
            );
        }
    }
}
