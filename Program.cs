namespace Final_Project
{
    internal class Program
    {
        static List<User> users = new List<User>();
        static MovieRental rentalApp = new MovieRental();

        static void Main(string[] args)
        {
            DisplayWelcomeScreen();


        }// end of Main


        //Displays Welcome screen and handles Sign In / Sign Up
        static void DisplayWelcomeScreen()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|        Welcome to Movie Rental App         |");
            Console.WriteLine("==============================================");

            string loggedInUser = ""; // empty means not logged in yet

            while (loggedInUser == "")
            {
                Console.WriteLine("\n1. Sign In");
                Console.WriteLine("2. Sign Up / Create Account");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out int option))
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        loggedInUser = SignIn();
                        break;

                    case 2:
                        SignUp();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose 1 or 2.");
                        break;
                }
            }// end of while


            // Route to correct menu based on who logged in
            if (loggedInUser == "admin")
            {
                // ShowAdminMenu()
                ShowAdminMenu();
            }
            else
            {
                // ShowUserMenu(loggedInUser)
                ShowUserMenu(loggedInUser);
            }

        }// end of DisplayWelcomeScreen


        // Returns "admin", the username, or "" if login failed
        static string SignIn()
        {
            Console.Write("\nEnter your Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (username == "" || password == "")
            {
                Console.WriteLine("Username and Password cannot be empty.");
                return "";
            }

            // If user logged correct deatils for an admin account
            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("--- Admin Login Successful! ---");
                return "admin";
            }

            User userFound = users.Find(u => u.Username == username);


            // Check password matches
            if (userFound != null && userFound.CheckPassword(password))
            {
                Console.WriteLine($"\n--- Welcome back, {username}! --- ");
                return username;
            }
            else
            {
                Console.WriteLine("Username or Password is incorrect. Try again.");
                return "";
            }

        }// end of SignIn


        static void SignUp()
        {
            Console.Write("\nCreate your Username: ");
            string newUsername = Console.ReadLine();

            if (newUsername == "")
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }
            
            // If the user tries to create with the name "admin"
            if (newUsername == "admin")
            {
                Console.WriteLine("Username 'admin' is reserved. Please choose a different username.");
                return;
            }

            // Check if the username already exists in the users list
            if (users.Exists(u => u.Username == newUsername))
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
                return;
            }

            Console.Write("Create your Password: ");
            string newPassword = Console.ReadLine();

            if (newPassword == "")
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            User newUser = new User(newUsername, newPassword, false);
            users.Add(newUser);
            Console.WriteLine("--- Account Created Successfully! Please Sign In. ---");

        }// end of Sign Up


        //Display the menu for admin
        static void ShowAdminMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("\n1. Show All Movies");
                Console.WriteLine("2. Search a Movies");
                Console.WriteLine("3. Rent a Movies");
                Console.WriteLine("4. Add Movie");
                Console.WriteLine("5. Remove Movie");
                Console.WriteLine("6. Update Movie");
                Console.WriteLine("99. Exit");
                Console.Write("\nPlease choose an option: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int option))
                {
                    Console.WriteLine("\nInvalid. Please enter a number.");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        rentalApp.ListMovies();
                        break;
                    case 2:
                        rentalApp.SearchMovies();
                        break;
                    case 3:
                        rentalApp.RentMovie();
                        break;
                    case 4:
                        rentalApp.AddMovie();
                        break;
                    case 5:
                        rentalApp.RemoveMovie();
                        break;
                    case 6:
                        rentalApp.UpdateMovie();
                        break;
                    case 99:
                        Console.WriteLine("GoodBye!!!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("\nPlease choose the number from above.");
                        break;
                }

            } // End of while loop
        }// End of ShowAdminMenu Method



        // Displays the menu for regular users (non-admin)
        static void ShowUserMenu(string username)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("\n1. Show All Movies");
                Console.WriteLine("2. Search a Movies");
                Console.WriteLine("3. Rent a Movies");
                Console.WriteLine("99. Exit");
                Console.Write("Please choose an option: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int option))
                {
                    Console.WriteLine("\nInvalid. Please enter a number.");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Show All Movies (Coming Soon)");
                        break;
                    case 2:
                        Console.WriteLine("Search a Movies (Coming Soon)");
                        break;
                    case 3:
                        Console.WriteLine("Rent a Movies (Coming Soon)");
                        break;
                    case 99:
                        Console.WriteLine("GoodBye!!!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("\nPlease choose the number from above.");
                        break;
                }
            }//end of while 
        }//end of showusermenu



    }// end of class Program
}//end of namespace