namespace Final_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DisplayWelcomeScreen();


        }//end of Main

        //DisplayWelcomeScreen method to display the welcome screen and handle user sign in/sign up
        static void DisplayWelcomeScreen()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|        Welcome to Movie Rental App         |");
            Console.WriteLine("----------------------------------------------");

            int option;
            string sUsername = "";
            string sPassword = "";
            do
            {
                Console.WriteLine("\n1. Sign In");
                Console.WriteLine("2. Sign Up/Create Account");
                Console.Write("Choose an option: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        if (sUsername == "" || sPassword == "")
                        {
                            Console.WriteLine("No account found. Create an account first.");
                            break;
                        }

                        Console.Write("Enter Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string password = Console.ReadLine();

                        if (username == sUsername && password == sPassword)
                        {
                            Console.Write("--- Sign In Successful! ---");
                        }
                        else
                        {
                            Console.Write("Username or Password is Wrong!");
                        }
                        break;

                    case 2:
                        Console.Write("Create your Username: ");
                        sUsername = Console.ReadLine();
                        Console.Write("Create your Password: ");
                        sPassword = Console.ReadLine();
                        Console.Write("--- Account Created. ---\n");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose 1 or 2.");
                        break;
                }
            } while (option != 1);
            Console.ReadKey();




        }//end of DisplayWelcomeScreen




    }//end of class Program
}//end of namespace 
