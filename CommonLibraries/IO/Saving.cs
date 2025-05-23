using System;
using System.IO;

namespace Common.IO
{
    public static class Saving
    {
        public static void CheckAndCreateDirectory(ref string directoryName)
        {
            directoryName = (directoryName ?? "").Trim();
            if (!string.IsNullOrEmpty(directoryName)
                && !Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
                Console.WriteLine($"[INFO] Створено директорію: {directoryName}");
            }
        }

        // можливе повернення false у випадку виняткової ситуації
        public static bool CheckAndPrepareFilePath(ref string path)
        {
            path = (path ?? "").Trim();
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("[WARNING] Шлях до файлу порожній.");
                return false;
            }

            string directoryName = Path.GetDirectoryName(path);
            CheckAndCreateDirectory(ref directoryName);

            Console.WriteLine($"[INFO] Готовий шлях до файлу: {path}");
            return true;
        }
    }
}