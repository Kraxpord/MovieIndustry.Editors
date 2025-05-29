using System;
using MovieIndustry.Data;
using MovieIndustry.Data.Formatting;
using MovieIndustry.Data.IO;
using MovieIndustry.Data.Testing;
using SubjectAreaLibraries.MovieIndustry.Data.IO;

namespace MovieIndustry.Training
{
    internal class FileIoTraining
    {
        internal static void Run()
        {
            Console.WriteLine(" === FileIoTraining ===");

            //StudyXmlFileIo();
            //StudyBinaryFileIo();
            StudyDataContextIo();
        }

        private static void StudyXmlFileIo()
        {
            Console.WriteLine(" --- StudyXmlFileIo ---");

            PrimXmlFileIoController xmlController = new PrimXmlFileIoController();

            PrimDataSet dataSet = new PrimDataSet();
            dataSet.CreateTestingData();
            Console.WriteLine(dataSet.ToDataString("dataSet"));

            string fileName = "MovieIndustry";
            xmlController.Save(dataSet, fileName);

            Console.WriteLine(new string('-', Console.BufferWidth - 1));

            dataSet.Clear();
            Console.WriteLine(dataSet.ToDataString("dataSet (after clear)"));

            xmlController.Load(dataSet, fileName);
            Console.WriteLine(dataSet.ToDataString("dataSet (after load)"));
        }

        private static void StudyBinaryFileIo()
        {
            Console.WriteLine(" --- StudyBinaryFileIo  ---");

            PrimBinaryFileIoController binaryController = new PrimBinaryFileIoController();

            PrimDataSet dataSet = new PrimDataSet();
            dataSet.CreateTestingData();
            Console.WriteLine(dataSet.ToDataString("dataSet"));

            string fileName = "MovieIndustry";
            binaryController.Save(dataSet, fileName);

            Console.WriteLine(new string('-', Console.BufferWidth - 1));

            dataSet.Clear();
            Console.WriteLine(dataSet.ToDataString("dataSet (after clear)"));

            binaryController.Load(dataSet, fileName);
            Console.WriteLine(dataSet.ToDataString("dataSet (after load)"));
        }

        private static void StudyDataContextIo()
        {
            Console.WriteLine(" --- StudyDataContextIo ---");

            var dataContext = new PrimDataContext();
            dataContext.CreateTestingData();
            Console.WriteLine("dataContext: " + dataContext);

            dataContext.DirectoryName = @"..\..\files";
            dataContext.Save();

            Console.WriteLine(new string('-', Console.BufferWidth - 1));

            dataContext.Clear();
            Console.WriteLine("dataContext (after clear): " + dataContext);

            dataContext.Load();
            Console.WriteLine("dataContext (after load): " + dataContext);
        }
    }
}