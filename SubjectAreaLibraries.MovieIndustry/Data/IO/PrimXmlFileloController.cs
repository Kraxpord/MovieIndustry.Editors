using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using SubjectAreaLibraries.MovieIndustry.Entities;
using SubjectAreaLibraries.MovieIndustry.Data;

namespace SubjectAreaLibraries.MovieIndustry.Data.IO
{
    public class PrimXmlFileIoController
    {

        public string FileExtension
        {
            get { return ".xml"; }
        }

        public string FileTypeCaption
        {
            get { return "Файли формату XML"; }
        }

        public void Save(PrimDataSet dataSet, string filePath)
        {
            filePath = Path.ChangeExtension(filePath, FileExtension);
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Encoding = Encoding.Unicode,
                Indent = true
            };

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("MovieIndustry");

                WriteMovies(dataSet.Movies, writer);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void WriteMovies(IEnumerable<Movie> collection, XmlWriter writer)
        {
            writer.WriteStartElement("Movies");
            foreach (var obj in collection)
            {
                writer.WriteStartElement("Movie");
                writer.WriteElementString("Id", obj.Id.ToString());
                writer.WriteElementString("Title", obj.Title);
                writer.WriteElementString("Genre", obj.Genre);
                writer.WriteElementString("Year", obj.Year.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public bool Load(PrimDataSet dataSet, string filePath)
        {
            filePath = Path.ChangeExtension(filePath, FileExtension);
            if (!File.Exists(filePath)) return false;

            XmlReaderSettings settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true
            };

            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Movie")
                    {
                        ReadMovie(reader, dataSet);
                    }
                }
            }
            return true;
        }

        private void ReadMovie(XmlReader reader, PrimDataSet dataSet)
        {
            Movie obj = new Movie();
            reader.ReadStartElement("Movie");
            obj.Id = reader.ReadElementContentAsInt();
            obj.Title = reader.ReadElementContentAsString();
            obj.Genre = reader.ReadElementContentAsString();
            obj.Year = reader.ReadElementContentAsInt();
            dataSet.Movies.Add(obj);
        }
    }
}