using System;
using System.Linq;
using SubjectAreaLibraries.MovieIndustry.Data;
using SubjectAreaLibraries.MovieIndustry.Data.Formatting;
using SubjectAreaLibraries.MovieIndustry.Data.Testing;

namespace MovieIndustry.ConsoleEditor.Studying
{
    internal class DataTraining
    {
        internal static void Run()
        {
            Console.WriteLine(" === DataTraining ===");

            StudyDataSet();
        }

        private static void StudyDataSet()
        {
            Console.WriteLine(" --- StudyDataSet ---");

            PrimDataSet dataSet = new PrimDataSet();
            Console.WriteLine(dataSet.ToDataString("DataString"));

            Console.WriteLine(new string('-', Console.BufferWidth - 1));

            dataSet.CreateTestingData();

            Console.WriteLine("dataSet.Movies.FirstOrDefault():\n"
                + dataSet.Movies.FirstOrDefault());
        }
    }
}
