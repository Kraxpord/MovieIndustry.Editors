using System.Collections.Generic;
using System.IO;
using MovieIndustry.Data.Formatting;
using MovieIndustry.Data.IO;
using MovieIndustry.Data.Testing;
using MovieIndustry.Entities;

namespace MovieIndustry.Data
{
    public class PrimDataContext
    {
        protected readonly PrimDataSet _dataSet = new PrimDataSet();

        public ICollection<Movie> Movies
        {
            get { return (ICollection<Movie>)_dataSet.Movie; }
        }

        public void Clear()
        {
            _dataSet.Clear();
        }

        public bool IsEmpty()
        {
            return _dataSet.IsEmpty();
        }

        public override string ToString()
        {
            return _dataSet.ToDataString();
        }

        public bool CreateTestingData()
        {
            return _dataSet.CreateTestingData();
        }

        //-----------------------------------------------------------------------

        private string _directoryName = "";

        public string DirectoryName
        {
            get { return _directoryName; }
            set
            {
                _directoryName = value;
                if (!string.IsNullOrEmpty(value) && !Directory.Exists(_directoryName))
                {
                    Directory.CreateDirectory(_directoryName);
                }
            }
        }

        public string FileName { get; set; }

        public PrimDataContext(string directoryName)
        {
            DirectoryName = directoryName;
            FileName = "MovieIndustry";
        }

        public PrimDataContext() : this("") { }

        // Можна змінити на бінарний контролер при потребі
        protected PrimXmlFileIoController _fileIoController = new PrimXmlFileIoController();

        public string FilePath
        {
            get
            {
                return Path.Combine(DirectoryName, FileName + _fileIoController.FileExtension);
            }
        }

        public void Save()
        {
            _fileIoController.Save(_dataSet, FilePath);
        }

        public bool Load()
        {
            return _fileIoController.Load(_dataSet, FilePath);
        }
    }
}