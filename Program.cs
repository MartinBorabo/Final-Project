namespace Final_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hi world");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|        Welcome to Movie Rental App         |");
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Have account?        Don't have an account?");
            Console.WriteLine("1. Sign in           2. Sign up/Create account");

            int option;
            do
            {
                Console.Write("\nChoose an option:    ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Have account");
                        break;
                    case 2:
                        Console.WriteLine("Don't Have an account");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose 1 or 2.");
                        break;
                }
            } while (option != 1 && option != 2);

        }//end of Main
    }//end of class Program
}//end of namespace 
