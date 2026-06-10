namespace Final_Project
{
    internal class Program
    {
        // Store registered users as a list of tuples (username, password)
        static List<(string username, string password)> users = new List<(string, string)>();

        static void Main(string[] args)
        {
            DisplayWelcomeScreen();
        }// end of Main


        // DisplayWelcomeScreen - shows the welcome screen and handles sign in / sign up
        static void DisplayWelcomeScreen()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|      Welcome to Movie Rental App          |");
            Console.WriteLine("==============================================");

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1. Sign In");
                Console.WriteLine("2. Sign Up / Create Account");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                // Validate input is a number
                if (!int.TryParse(input, out int option))
                {
                    Console.WriteLine("Invalid input. Please enter 1 or 2.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        SignIn(ref running);
                        break;

                    case 2:
                        SignUp();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose 1 or 2.");
                        break;
                }
            }// end of while

        }// end of DisplayWelcomeScreen


        // SignIn - handles user login and routes to correct menu
        static void SignIn(ref bool running)
        {
            Console.Write("\nEnter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            // Check against registered users list

            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("\n--- Welcome, Admin! ---");
                running = false; // stop welcome loop
                // TODO: ShowAdminMenu() will go here
            }
            // Check against registered users list
            else if (users.Exists(u => u.username == username && u.password == password))
            {
                Console.WriteLine($"\n--- Welcome back, {username}! ---");
                running = false; // stop welcome loop
                // TODO: ShowUserMenu() will go here
            }
            else
            {
                Console.WriteLine("Username or Password is incorrect. Try again.");
            }

        }// end of SignIn


        // SignUp - handles new account registration
        static void SignUp()
        {
            Console.Write("\nCreate your Username: ");
            string newUsername = Console.ReadLine();

            // Check if username already exists
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