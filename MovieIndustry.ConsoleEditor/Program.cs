using Common.ConsoleIO;
using System;
using MovieIndustry.Data;
using MovieIndustry.Editing;
using MovieIndustry.Studying;

namespace MovieIndustry.ConsoleEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "MovieIndustry.ConsoleEditor (Стець А. М.)";

            ConsoleSettings.SetConsoleParam();

            Console.WriteLine(" Реалізація редактора даних ПО \"Кіностудія\"");

            //EntitiesTraining.Run();
            //DataTraining.Run();
            //FileIoTraining.Run();

            //Console.ReadKey(true);

            RunProgram();
        }

        static MovieEditor _moviesEditor = null;
        static PrimDataContext _dataContext = null;

        private static void RunProgram()
        {
            _dataContext = new PrimDataContext();
            _dataContext.DirectoryName = @"..\..\files";
            _moviesEditor = new MovieEditor(_dataContext);
            _moviesEditor.Run();
        }
    }
}