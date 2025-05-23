using System;

namespace SubjectAreaLibraries.MovieIndustry.Entities
{
    [Serializable]
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int? Duration { get; set; } // в хвилинах
        public string Director { get; set; }
        public string Description { get; set; }

        public string Key { get { return Title; } }

        public string Note { get; internal set; }

        public Movie(string title, string genre, int year, int? duration)
        {
            Title = title;
            Genre = genre;
            Year = year;
            Duration = duration;
        }

        public Movie(string title, string genre, string v, int v1, double v2)
            : this(title, genre, 0, null) { }

        public Movie() : this(null, null, 0, null) { }

        public override string ToString()
        {
            return string.Format(
                "\tФільм №{0}\n" +
                "\t  Назва: {1}\n" +
                "\t  Жанр: {2}\n" +
                "\t  Рік: {3}\n" +
                "\t  Тривалість (хв): {4}\n" +
                "\t  Режисер: {5}\n" +
                "\t  Опис: {6}",
                Id,
                Title,
                Genre,
                Year,
                Duration.HasValue ? Duration.ToString() : "Невідомо",
                Director,
                Description
            );
        }
    }
}