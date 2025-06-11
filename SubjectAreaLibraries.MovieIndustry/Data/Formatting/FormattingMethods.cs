using Common.Collection;
using System.Collections.Generic;
using System.Text;
using MovieIndustry.Entities;
using SubjectAreaLibraries.MovieIndustry.Data;

namespace MovieIndustry.Data.Formatting
{
    public static class FormattingMethods
    {
        // Формування всього набору фільмів
        public static string ToDataString(this PrimDataSet dataSet, string header = null)
        {
            if (header == null)
                header = "ПО \"Кіноіндустрія\"";

            return string.Concat(
                header + "\n",
                dataSet.Movies.ToLineList("  Фільми")  // Множина
            );
        }

        // Табличне представлення фільмів з пронумерованими рядками
        public static string ToTable(this IEnumerable<Movie> objects, string header = null)
        {
            if (header == null)
                header = "Фільми";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(header);

            // Шапка таблиці
            string format = "  {0,5} {1,-30} {2,-20} {3,6} {4,10}\n";
            sb.AppendFormat(format, "№", "Назва", "Режисер", "Рік", "Рейтинг");
            sb.AppendFormat("  {0}\n", new string('-', 85));

            // Пронумеровані рядки
            int number = 1;
            foreach (var obj in objects)
            {
                sb.AppendFormat(format,
                    number++,
                    obj.Title ?? "—",
                    obj.Director ?? "—",
                    obj.ReleaseYear?.ToString() ?? "—",
                    obj.Rating?.ToString("0.0") ?? "—"
                );
            }

            if (sb.Length > 0)
                sb.Length--;

            return sb.ToString();
        }
    }
}