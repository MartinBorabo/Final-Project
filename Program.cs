namespace Final_Project
{
    internal class Program
    {
        static List<(string username, string password)> users = new List<(string, string)>();

        static void Main(string[] args)
        {
            DisplayWelcomeScreen();


        }// end of Main


        //Displays Welcome screen and handles Sign In / Sign Up
        static void DisplayWelcomeScreen()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|      Welcome to Movie Rental App          |");
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
                // TODO: ShowAdminMenu()
            }
            else
            {
                // TODO: ShowUserMenu(loggedInUser)
            }

        }// end of DisplayWelcomeScreen


        // Returns "admin", the username, or "" if login failed
        static string SignIn()
        {
            Console.Write("\nEnter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("\n--- Welcome, Admin! ---");
                return "admin";
            }
            else if (users.Exists(u => u.username == username && u.password == password))
            {
                Console.WriteLine($"\n--- Welcome back, {username}! ---");
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

            if (newUsername == "admin")
            {
                Console.WriteLine("That username is reserved. Try a different one.");
                return;
            }

            if (users.Exists(u => u.username == newUsername))
            {
                Console.WriteLine("That username is already taken. Try a different one.");
                return;
            }

            Console.Write("Create your Password: ");
            string newPassword = Console.ReadLine();

            users.Add((newUsername, newPassword));
            Console.WriteLine("--- Account Created Successfully! Please Sign In. ---");

        }// end of SignUp


    }// end of class Program
}// end of namespace