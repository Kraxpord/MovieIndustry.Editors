using System;

namespace Common.ConsoleIO
{
    public static class Inputting
    {

        static string s_promptFormat = "{0,40}: ";

        //-------------------------------------------------------------

        public static int InputInt32(string prompt)
        {
            while (true)
            {
                Console.Write(s_promptFormat, prompt);
                string str = Console.ReadLine();
                try
                {
                    return Convert.ToInt32(str);
                }
                catch (Exception)
                {
                    Console.WriteLine("\t\tПомилка введення цілого числа");
                }
            }
        }

        //public static int InputInt32(string prompt) {
        //    while (true) {
        //        Console.Write(s_promptFormat, prompt);
        //        string str = Console.ReadLine();
        //        int value;
        //        if (int.TryParse(str, out value)) {
        //            return value;
        //        }
        //        Console.WriteLine("\t\tПомилка введення цілого числа");
        //    }
        //}

        public static int InputInt32(string prompt, int min, int max = int.MaxValue)
        {

            while (true)
            {
                int value = InputInt32(prompt);
                if (min <= value && value <= max)
                {
                    return value;
                }
                Console.WriteLine("\t\tВведіть значення в межах від {0} до {1}", min, max);
            }
        }

        public static string InputString(string prompt)
        {
            Console.Write(s_promptFormat, prompt);
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            str = str.Trim();
            return str;
        }

        public static string InputString(string prompt, int minLength, int maxLength)
        {
            while (true)
            {
                string str = InputString(prompt);
                if (str == null || minLength <= str.Length && str.Length <= maxLength)
                {
                    return str;
                }
                Console.WriteLine("\t\tпотрібно ввести від {0} до {1} символів",
                    minLength, maxLength);
            }
        }

        public static double? InputNullableDouble(string prompt)
        {
            while (true)
            {
                Console.Write(s_promptFormat, prompt);
                string str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    return null;
                }
                try
                {
                    return Convert.ToDouble(str);
                }
                catch (Exception)
                {
                    Console.WriteLine("\t\tпомилка введення дійсного числа");
                }
            }
        }

        public static double? InputNullableDouble(string prompt,
            double min, double max = double.MaxValue)
        {

            while (true)
            {
                double? value = InputNullableDouble(prompt);
                if (value == null || min <= value && value <= max)
                {
                    return value;
                }
                Console.WriteLine("\t\tВведіть значення в межах від {0} до {1}", min, max);
            }
        }

        public static int? InputNullableInt32(string v)
        {
            throw new NotImplementedException();
        }
    }
}
