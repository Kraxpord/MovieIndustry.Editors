using System.IO;

namespace Common.IO
{
    public static class Saving
    {
        public static void CheckAndCreateDirectory(ref string directoryName)
        {
            directoryName = (directoryName ?? "").Trim();
            if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }

        public static bool CheckAndPrepareFilePath(ref string path)
        {
            path = (path ?? "").Trim();
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            string directoryName = Path.GetDirectoryName(path);
            CheckAndCreateDirectory(ref directoryName);
            return true;
        }
    }
}