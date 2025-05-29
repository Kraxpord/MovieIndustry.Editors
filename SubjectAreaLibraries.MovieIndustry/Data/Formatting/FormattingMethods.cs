using Common.Collection;
using System.Collections.Generic;
using System.Text;
using MovieIndustry.Entities;
using SubjectAreaLibraries.MovieIndustry.Data;

namespace MovieIndustry.Data.Formatting
{
    public static class FormattingMethods
    {
        public static string ToDataString(this PrimDataSet dataSet, string header = null)
        {
            if (header == null)
                header = "ПО \"Кіноіндустрія\"";
            return string.Concat(header == null ? "" : header + "\n",
                dataSet.Movie.ToLineList("  Фільми"));
        }

        public static string ToTable(this IEnumerable<Movie> objects, string header = null)
        {
            if (header == null)
                header = "Фільми";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(header);

            string format = "  {0,5} {1,-30} {2,-20} {3,6} {4,12}\n";
            sb.AppendFormat(format, "Id", "Назва", "Режисер", "Рік", "Рейтинг");
            sb.AppendFormat("  {0}\n", new string('-', 80));

            foreach (var obj in objects)
            {
                sb.AppendFormat(format,
                    obj.Id,
                    obj.Title,
                    obj.Director,
                    obj.ReleaseYear.HasValue ? obj.ReleaseYear.ToString() : "—",
                    obj.Rating.HasValue ? obj.Rating.Value.ToString("0.0") : "—"
                );
            }
            sb.Length--;
            return sb.ToString();
        }
    }
}