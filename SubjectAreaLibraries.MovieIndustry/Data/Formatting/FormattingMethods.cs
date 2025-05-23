using Common.Collection;
using System.Collections.Generic;
using System.Text;
using SubjectAreaLibraries.MovieIndustry.Entities;

namespace SubjectAreaLibraries.MovieIndustry.Data.Formatting
{
    public static class FormattingMethods
    {

        public static string ToDataString(this PrimDataSet dataSet, string header = null)
        {
            if (header == null)
                header = "ПО \"Кіноіндустрія\"";
            return string.Concat(header + "\n",
                dataSet.Movies.ToLineList("Фільми")
            );
        }

        public static string ToTable(this IEnumerable<Movie> movies, string header = null)
        {
            if (header == null)
                header = "Фільми";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(header);

            string format = "  {0,5} {1,-30} {2,-20} {3,10} {4,15}\n";
            sb.AppendFormat(format, "Id", "Назва", "Жанр", "Рік", "Бюджет ($)");
            sb.AppendLine("  " + new string('-', 85));

            foreach (var movie in movies)
            {
                sb.AppendFormat(format,
                    movie.Id,
                    movie.Title,
                    movie.Genre,
                    movie.Year
                );
            }
            sb.Length--; // обрізаємо останній символ '\n'
            return sb.ToString();
        }
    }
}