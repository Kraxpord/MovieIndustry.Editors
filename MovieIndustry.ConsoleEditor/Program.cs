using Common.ConsoleIO;
using System;
using MovieIndustry.Data;
using MovieIndustry.Editing;
using MovieIndustry.Training;

namespace MovieIndustry.ConsoleEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "MovieIndustry.ConsoleEditor (Стець А. М.)";

            ConsoleSettings.SetConsoleParam();

            Console.WriteLine(" Реалізація редактора даних ПО \"Кіностудія\"");

            //DataTraining.Run();
            //FileIoTraining.Run();

            //Console.ReadKey(true);

            RunProgram();
        }

        static MovieEditor _movieEditor = null;
        static PrimDataContext _dataContext = null;

        private static void RunProgram()
        {
            _dataContext = new PrimDataContext();
            _dataContext.DirectoryName = @"..\..\files";

        
            if (_dataContext.IsEmpty())
            {
                _dataContext.CreateTestingData();  
            }

            _movieEditor = new MovieEditor(_dataContext);
            _movieEditor.Run();
        }
    }
}