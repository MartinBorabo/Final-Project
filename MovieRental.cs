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
        public void ListMovies()
        {
            Console.WriteLine("\n=============================");
            Console.WriteLine("All Movies");
            Console.WriteLine("\n=============================");
            if(movies.Count==0)
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
            Console.WriteLine("\n=============================");
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
            Console.WriteLine("\n=============================");
            Console.WriteLine("Rent a Movie");
            Console.WriteLine("\n=============================");
            if(movies.Count==0)
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
            if (!int.TryParse(Console.ReadLine(), out int days) || days < 1 || days > 5) ;
            {          
                Console.WriteLine("Rental days must be between 1 and 5.");
                return;
            }

            double totalCost = days * 25.00;
            Console.WriteLine("\n=============================");
            Console.WriteLine("Rental Confirmation");
            Console.WriteLine("\n=============================");
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
        

        // ------------------------  
        // REMOVE A MOVIE (Admin only)
        // ------------------------ 


        // ------------------------
        // UPDATE A MOVIE (Admin only)
        // ------------------------

    }
}
