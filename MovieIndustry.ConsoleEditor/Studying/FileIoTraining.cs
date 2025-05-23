using System;
using System.IO; // для Path.Combine
using Common.IO; // для Saving.CheckAndPrepareFilePath
using SubjectAreaLibraries.MovieIndustry.Data;
using SubjectAreaLibraries.MovieIndustry.Data.Formatting;
using SubjectAreaLibraries.MovieIndustry.Data.IO;
using SubjectAreaLibraries.MovieIndustry.Data.Testing;

namespace MovieIndustry.ConsoleEditor.Studying
{
    internal class FileIoTraining
    {
        internal static void Run()
        {
            Console.WriteLine(" === FileIoTraining ===");

            //StudyXmlFileIo();
            StudyBinaryFileIo();
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
            Console.WriteLine(dataSet.ToDataString("dataSet"));
            xmlController.Load(dataSet, fileName);
            Console.WriteLine(dataSet.ToDataString("dataSet"));
        }

        public static void StudyBinaryFileIo()
        {
            Console.WriteLine("\nStudyBinaryFileIo\n");

            PrimBinaryFileIoController binaryController = new PrimBinaryFileIoController();
            PrimDataSet dataSet = new PrimDataSet();
            dataSet.CreateTestingData(); // Генеруємо тестові дані
            Console.WriteLine(dataSet.ToDataString("dataSet"));

            // Шлях до файлу збереження
            string fileName = Path.Combine("files", "MovieIndustry");
            Saving.CheckAndPrepareFilePath(ref fileName); // Створення директорії, якщо її немає

            // Зберігаємо дані
            binaryController.Save(dataSet, fileName);

            Console.WriteLine(new string('-', 50));

            // Очищуємо дані
            dataSet.Clear();
            Console.WriteLine(dataSet.ToDataString("dataSet"));

            // Завантажуємо дані з файлу
            binaryController.Load(dataSet, fileName);
            Console.WriteLine(dataSet.ToDataString("dataSet"));
        }
    }
}

