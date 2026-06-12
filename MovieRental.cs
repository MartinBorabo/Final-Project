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
        private List<Movie> movies = new List<Movie>()
        {
            new Movie("Obsessed", "Psychological", 2026, 4)
        };



        // ------------------------
        // LIST  ALL MOVIES
        // ------------------------
        public void ListMovies()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|              Showing All Movies            |");
            Console.WriteLine("==============================================");
            if (movies.Count==0)
            {
                Console.WriteLine("No movies available.");
                return;
            }
            foreach (Movie movie in movies)
            {
                movie.DisplayInfo();
            }
        }//end of list all movies



        // ------------------------
        // SEARCH ALL MOVIES
        // ------------------------
        public void SearchMovies()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|               Search All Movies            |");
            Console.WriteLine("==============================================");
            Console.Write("Enter Movie Title: ");
            string searchTerm = Console.ReadLine();
            if(searchTerm == "")
            {
                Console.WriteLine("Search term cannot be empty.");
                return;
            }
            List<Movie> results = movies.FindAll(m => m.Title.ToLower().Contains(searchTerm.ToLower()));
            if(results.Count==0)
            {
                Console.WriteLine($"No movies found matching '{searchTerm}'.");
                    return;
            }
            Console.WriteLine($"Found {results.Count} result(s)");
            foreach (Movie movie in results)
            {
                movie.DisplayInfo();
            }
        }//end of search all movies



        // ------------------------
        // RENT A MOVIE
        // ------------------------
        public void RentMovie()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|                 Rent a Movie               |");
            Console.WriteLine("==============================================");
            if (movies.Count==0)
            {
                Console.WriteLine("No movies available.");
                return;
            }
            Console.Write("Enter Movie Title to Rent: ");
            string title = Console.ReadLine();
            if (title == "")
            {
                Console.WriteLine("Title cannot be empty");
                return;
            }
            Movie movieFound = movies.Find(m => m.Title.ToLower() == title.ToLower());
            if(movieFound == null)
            {
                Console.WriteLine($"Movie '{title}' not found.");
                return;
            }
            
            Console.Write("Enter the number of days you want to rent (1 to 5 only): ");
            if (!int.TryParse(Console.ReadLine(), out int days) || days < 1 || days > 5)
            {          
                Console.WriteLine("Rental days must be between 1 and 5.");
                return;
            }

            double totalCost = days * 25.00;
            Console.WriteLine("==============================================");
            Console.WriteLine("|              Rental Confirmation            |");
            Console.WriteLine("==============================================");
            Console.WriteLine($"Movie : {movieFound.Title}");
            Console.WriteLine($"Days: {days}");
            Console.WriteLine($"Per Day: $25.00");
            Console.WriteLine($"Total: ${totalCost:F2} ");
            Console.WriteLine("\n=============================");
            Console.WriteLine("Enjoy!!!");

        }//end of rent a movie



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
