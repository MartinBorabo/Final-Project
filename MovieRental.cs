using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class MovieRental
    {
        // A list to store movies in the rental system
        private List<Movie> movies = new List<Movie>();



        // ------------------------
        // LIST  ALL MOVIES
        // ------------------------


        // ------------------------
        // SEARCH ALL MOVIES
        // ------------------------


        // ------------------------
        // RENT A MOVIE
        // ------------------------


        // ------------------------
        // ADD A MOVIE (Admin only)
        // ------------------------
        public void AddMovie()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|                Add New Movie               |");
            Console.WriteLine("==============================================");

            Console.Write("Enter Movie Title: ");
            string title = Console.ReadLine();

            if (title == "")
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }

            if (movies.Exists(m => m.Title.ToLower() == title.ToLower()))
            {
                Console.WriteLine("Error: A movie with the same title already exist");
                return;
            }

            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine();

            if (genre == "")
            {
                Console.WriteLine("Genre cannot be empty.");
                return;
            }

            Console.Write("Enter Release Year: ");
            if (!int.TryParse(Console.ReadLine(), out int releaseYear))
            {
                Console.WriteLine("Invalid input for release year. Please enter a valid number.");
                return;
            }

            Console.Write("Enter the Number of DVDs: ");
            if (!int.TryParse(Console.ReadLine(), out int dvdCount) || dvdCount < 1)
            {
                Console.WriteLine("Error: DVD count must be at least 1.");
                return;
            }

            Movie newMovie = new Movie(title, genre, releaseYear, dvdCount);
            movies.Add(newMovie);
            Console.WriteLine($"Movie '{title}' added successfully! ");

        }// End of AddMovie method


        // ------------------------  
        // REMOVE A MOVIE (Admin only)
        // ------------------------ 
        public void RemoveMovie()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|                Remove Movie                |");
            Console.WriteLine("==============================================");

            if (movies.Count == 0)
            {
                Console.WriteLine("No movies available to remove.");
                return;
            }

            Console.Write("Enter Movie Title to Remove: ");
            string title = Console.ReadLine();

            if (title == "")
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }

            Movie movieFound = movies.FirstOrDefault(m => m.Title.ToLower() == title.ToLower());

            if (movieFound == null)
            {
                Console.WriteLine($"Movie '{title}' not found.");
                return;
            }

            Console.Write($"Are you sure you want to remove '{movieFound.Title}'? (Y/N): ");
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "y")
            {
                movies.Remove(movieFound);
                Console.WriteLine($"Movie '{movieFound.Title}' removed successfully!");
            } else
            {
                Console.WriteLine("Remove cancelled.");
            }

        }// Ennd of RemoveMovie method



        // ------------------------
        // UPDATE A MOVIE (Admin only)
        // ------------------------
        public void UpdateMovie()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|                Update Movie                |");
            Console.WriteLine("==============================================");

            if (movies.Count == 0)
            {
                Console.WriteLine("No movies available to update.");
                return;
            }

            Console.Write("Enter Movie Title to Update: ");
            string title = Console.ReadLine();

            if (title == "")
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }

            Movie movieFound = movies.FirstOrDefault(m => m.Title.ToLower() == title.ToLower());

            if (movieFound == null)
            {
                Console.WriteLine($"Movie '{title}' not found.");
                return;
            }

            Console.WriteLine($"Updating '{movieFound.Title}' - press Enter to keep current value");

            Console.Write($"New Genre [{movieFound.Genre}]: ");
            string newGenre = Console.ReadLine();
            if (newGenre != "") movieFound.Genre = newGenre;

            Console.Write($"New DVD Count [{movieFound.DvdCount}]: ");
            string dvdInput = Console.ReadLine();

            if (dvdInput != "")
            {
                if (int.TryParse(dvdInput, out int newDvdCount) && newDvdCount >= 0)
                {
                    movieFound.DvdCount = newDvdCount;
                }
                else
                {
                    Console.WriteLine("Invalid input for DVD count. Keeping current value.");
                }
            }

            Console.WriteLine($"Movie '{movieFound.Title}' updated successfully!");

        }// End of UpdateMovie method




    }// end of MovieRental class
}
