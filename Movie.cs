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
        private int dvdCount;

        //properties
        public int DvdCount
        {
            get { return dvdCount; }
            set { dvdCount = value; }
        }

        //constructor
        public Movie(string title, string genre, int year, int dvdCount) : base(title, genre, year)
        {
            DvdCount = dvdCount;
        }

    }
}
