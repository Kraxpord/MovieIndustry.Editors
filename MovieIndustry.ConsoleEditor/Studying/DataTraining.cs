using System;
using System.Linq;
using MovieIndustry.Data;
using MovieIndustry.Data.Formatting;
using MovieIndustry.Data.Testing;

namespace MovieIndustry.Training
{
    internal class DataTraining
    {
        internal static void Run()
        {
            Console.WriteLine(" === DataTraining ===");

            //StudyDataSet();
            StudyDataContext();
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

        private static void StudyDataContext()
        {
            Console.WriteLine(" --- StudyDataContext ---");

            PrimDataContext dataContext = new PrimDataContext();
            Console.WriteLine("dataContext.IsEmpty():\t" + dataContext.IsEmpty());
            dataContext.CreateTestingData();
            Console.WriteLine("dataContext.IsEmpty():\t" + dataContext.IsEmpty());
            Console.WriteLine("dataContext:\n" + dataContext);

            Console.WriteLine(new string('-', Console.BufferWidth - 1));

            dataContext.Clear();
            Console.WriteLine("dataContext.IsEmpty():\t" + dataContext.IsEmpty());
            Console.WriteLine("dataContext:\n" + dataContext);
        }
    }
}
