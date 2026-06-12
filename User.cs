using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class User
    {
        // Fields
        private string username;
        private string password;
        private bool isAdmin; // if user is admin or regular user

        // Properties
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public bool IsAdmin
        {
            get { return isAdmin; }
            set {  isAdmin = value; }
        }

        // Constructor
        public User(string username, string password, bool isAdmin)
        {
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }

        //Checks if input password matches the user's password
        public bool CheckPassword(string inputPassword)
        {
            return password == inputPassword;
        }


        // Display user's details
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Role: {(IsAdmin ? "Admin" : "Regular User")}");
        }
        


    }
}
