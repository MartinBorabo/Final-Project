using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal abstract class MovieDetails
    {
        //fieds
        private string title;
        private string genre;
        private int year;

        //properties
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        //constructor
        public MovieDetails(string title, string genre, int year)
        {
            Title = title;
            Genre = genre;
            Year = year;
        }

        //Abstract method
        public abstract void DisplayInfo();
    }
}
