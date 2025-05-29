using System;
using System.Collections.Generic;
using MovieIndustry.Entities;

namespace MovieIndustry.Data
{
    [Serializable]
    public class PrimDataSet
    {
        public readonly List<Movie> Movie = new List<Movie>();

        public void Clear()
        {
            Movie.Clear();
        }

        public virtual bool IsEmpty()
        {
            return Movie.Count == 0;
        }

        public void CopyTo(PrimDataSet other)
        {
            foreach (var obj in Movie)
                other.Movie.Add(obj);
        }
    }
}