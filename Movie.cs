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
            set
            {
                if (value < 0) { Console.WriteLine("Error: DVD count cannot be negative."); }
                else { dvdCount = value; }
            }
        }

        // Constructor - calls base class constructor
        public Movie(string title, string genre, int year, int dvdCount)
            : base(title, genre, year)
        {    
            DvdCount = dvdCount;
        }

        // Override DisplayInfo - polymorphism in action
        public override void DisplayInfo()
        {
            Console.WriteLine($"  Title    : {Title}");
            Console.WriteLine($"  Genre    : {Genre}");
            Console.WriteLine($"  Year     : {Year}");
            Console.WriteLine($"  DVDs     : {DvdCount}");
            Console.WriteLine("  ------------------------------------------");
        }

    }
}
