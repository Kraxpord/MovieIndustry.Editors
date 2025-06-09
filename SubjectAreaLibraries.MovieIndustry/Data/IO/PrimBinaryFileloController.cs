using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MovieIndustry.Data;
using SubjectAreaLibraries.MovieIndustry.Data;

namespace SubjectAreaLibraries.MovieIndustry.Data.IO
{
    public class PrimBinaryFileIoController
    {
        public string FileExtension
        {
            get { return ".bin"; }
        }

        public string FileTypeCaption
        {
            get { return "Двійкові файли фільмів"; }
        }

        public void Save(PrimDataSet dataSet, string filePath)
        {
            filePath = Path.ChangeExtension(filePath, FileExtension);
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fStream = File.OpenWrite(filePath))
            {
                formatter.Serialize(fStream, dataSet);
            }
        }

        public bool Load(PrimDataSet dataSet, string filePath)
        {
            filePath = Path.ChangeExtension(filePath, FileExtension);
            if (!File.Exists(filePath))
                return false;

            PrimDataSet newDataSet = null;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fStream = File.OpenRead(filePath))
            {
                newDataSet = (PrimDataSet)formatter.Deserialize(fStream);
            }

            if (newDataSet == null)
            {
                return false;
            }

            newDataSet.CopyTo(dataSet);
            return true;
        }
    }
}