using System;

namespace MovieIndustry.Entities
{
    [Serializable]
    public class Movie
    {
        private double v2;

        public int Id { get; set; }

        public string Title { get; set; }
        public string Director { get; set; }
        public int? ReleaseYear { get; set; }
        public string Genre { get; set; }
        public double? Rating { get; set; } // Наприклад, рейтинг IMDb
        public string Description { get; set; }
        public string Note { get; set; }

        public string Key { get { return Title; } }

        public Movie(string title, string director, int? releaseYear, string genre)
        {
            Title = title;
            Director = director;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public Movie(string title, string director, string v, int v1)
            : this(title, director, null, null) { }

        public Movie() : this(null, null, null, null) { }

        public Movie(string title, string director, string v, int v1, double v2) : this(title, director, v, v1)
        {
            this.v2 = v2;
        }

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
                Title,
                Director,
                ReleaseYear.HasValue ? ReleaseYear.ToString() : "Невідомо",
                Genre,
                Rating.HasValue ? Rating.ToString() : "Немає",
                Note,
                Description
            );
        }
    }
}