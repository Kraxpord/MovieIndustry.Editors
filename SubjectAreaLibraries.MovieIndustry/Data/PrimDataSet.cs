using System;
using System.Collections.Generic;
using SubjectAreaLibraries.MovieIndustry.Entities;

namespace SubjectAreaLibraries.MovieIndustry.Data
{
    [Serializable]
    public class PrimDataSet
    {
        public readonly List<Movie> Movies = new List<Movie>();

        public void Clear()
        {
            Movies.Clear();
        }

        public virtual bool IsEmpty()
        {
            return Movies.Count == 0;
        }

        public void CopyTo(PrimDataSet other)
        {
            foreach (var movie in Movies)
                other.Movies.Add(movie);
        }
    }
}