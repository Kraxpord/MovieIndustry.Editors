using Common.ConsoleIO;
using System;
using MovieIndustry.ConsoleEditor.Studying;

namespace MovieIndustry.ConsoleEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "MovieIndustry.ConsoleEditor (Стець А. М.)";

            ConsoleSettings.SetConsoleParam();

            Console.WriteLine(" Реалізація редактора даних ПО \"Кіноіндустрія\"");

            //DataTraining.Run();
            FileIoTraining.Run();

            Console.ReadKey(true);
        }
    }
}