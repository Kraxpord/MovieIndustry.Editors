using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using MovieIndustry.Entities;
using SubjectAreaLibraries.MovieIndustry.Data;

namespace MovieIndustry.Data.IO
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
                Encoding = Encoding.Unicode
            };
            XmlWriter writer = null;

            try
            {
                writer = XmlWriter.Create(filePath, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("MovieIndustry");
                WriteMovies(dataSet.Movie, writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                writer?.Close();
            }
        }

        private void WriteMovies(IEnumerable<Movie> collection, XmlWriter writer)
        {
            writer.WriteStartElement("Movies");
            foreach (var movie in collection)
            {
                writer.WriteStartElement("Movie");
                writer.WriteElementString("Id", movie.Id.ToString());
                writer.WriteElementString("Title", movie.Title);
                writer.WriteElementString("Director", movie.Director);
                writer.WriteElementString("Genre", movie.Genre);
                writer.WriteElementString("ReleaseYear", movie.ReleaseYear?.ToString() ?? "");
                writer.WriteElementString("Rating", movie.Rating?.ToString() ?? "");
                writer.WriteElementString("Description", movie.Description);
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
            Movie movie = new Movie();
            reader.ReadStartElement("Movie");
            movie.Id = reader.ReadElementContentAsInt();
            movie.Title = reader.ReadElementContentAsString();
            movie.Director = reader.ReadElementContentAsString();
            movie.Genre = reader.ReadElementContentAsString();

            string yearStr = reader.ReadElementContentAsString();
            movie.ReleaseYear = string.IsNullOrEmpty(yearStr) ? (int?)null : int.Parse(yearStr);

            string ratingStr = reader.ReadElementContentAsString();
            movie.Rating = string.IsNullOrEmpty(ratingStr) ? (double?)null : double.Parse(ratingStr);

            movie.Description = reader.ReadElementContentAsString();

            dataSet.Movie.Add(movie);
        }
    }
}