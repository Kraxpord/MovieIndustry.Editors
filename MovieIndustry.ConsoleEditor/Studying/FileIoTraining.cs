using System;
using MovieIndustry.Data;
using MovieIndustry.Data.Formatting;
using MovieIndustry.Data.IO;
using MovieIndustry.Data.Testing;

namespace MovieIndustry.Studying
{
    internal class FileIoTraining
    {
        internal static void Run()
        {
            Console.WriteLine(" === FileIoTraining ===");

            //StudyXmlFileIo();
            //StudyBinaryFileIo();
            StudyMovieContextIo();
        }

        private static void StudyXmlFileIo()
        {
            Console.WriteLine(" --- StudyXmlFileIo ---");

            var xmlController = new MovieXmlFileIoController();

            PrimDataSet dataSet = new PrimDataSet();
            dataSet.CreateTestingData();
            Console.WriteLine(dataSet.ToDataString("dataSet"));

            string fileName = "MovieIndustry";
            xmlController.Save(dataSet, fileName);

            Console.WriteLine(new string('-', Console.BufferWidth - 1));

            dataSet.Clear();
            Console.WriteLine(dataSet.ToDataString("dataSet"));
            xmlController.Load(dataSet, fileName);
            Console.WriteLine(dataSet.ToDataString("dataSet"));
        }

        private static void StudyBinaryFileIo()
        {
            Console.WriteLine(" --- StudyBinaryFileIo  ---");

            MovieBinaryFileIoController binaryController = new MovieBinaryFileIoController();

            PrimDataSet dataSet = new PrimDataSet();
            dataSet.CreateTestingData();
            Console.WriteLine(dataSet.ToDataString("dataSet"));

            string fileName = "MovieIndustry";
            binaryController.Save(dataSet, fileName);

            Console.WriteLine(new string('-', Console.BufferWidth - 1));

            dataSet.Clear();
            Console.WriteLine(dataSet.ToDataString("dataSet"));
            binaryController.Load(dataSet, fileName);
            Console.WriteLine(dataSet.ToDataString("dataSet"));
        }

        private static void StudyMovieContextIo()
        {
            Console.WriteLine(" --- StudyMovieContextIo ---");

            var dataContext = new PrimDataContext();
            dataContext.CreateTestingData();
            Console.WriteLine("dataContext: " + dataContext);
            dataContext.DirectoryName = @"..\..\files";
            dataContext.Save();

            Console.WriteLine(new string('-', Console.BufferWidth - 1));

            dataContext.Clear();
            Console.WriteLine("dataContext: " + dataContext);
            dataContext.Load();
            Console.WriteLine("dataContext: " + dataContext);
        }

        private class MovieXmlFileIoController
        {
            public MovieXmlFileIoController()
            {
            }

            internal void Load(PrimDataSet dataSet, string fileName)
            {
                throw new NotImplementedException();
            }

            internal void Save(PrimDataSet dataSet, string fileName)
            {
                throw new NotImplementedException();
            }
        }

        private class MovieBinaryFileIoController
        {
            internal void Load(PrimDataSet dataSet, string fileName)
            {
                throw new NotImplementedException();
            }

            internal void Save(PrimDataSet dataSet, string fileName)
            {
                throw new NotImplementedException();
            }
        }
    }
}