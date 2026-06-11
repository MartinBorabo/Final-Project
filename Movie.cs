using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Movie : MovieDetails
    {
        //fields
        private string dvdCount;

        //properties
        public string DvdCount
        {
            get { return dvdCount; }
            set { dvdCount = value; }
        }

        //constructor
        public Movie(string title, string genre, int year, string dvdCount) : base(title, genre, year)
        {
            DvdCount = dvdCount;
        }

    }
}
