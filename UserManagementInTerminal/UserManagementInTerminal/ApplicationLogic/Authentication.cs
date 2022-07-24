using AuthenticationWithClie.ApplicationLogic.Validations;
using AuthenticationWithClie.Database.Repository;
using AuthenticationWithClie.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationWithClie.ApplicationLogic
{
    public class Authentication
    {
        public static void Register()
        {
            string firstName = GetFirstName();

            Console.Write("Please enter user's last name : ");
            string lastName = Console.ReadLine();

            Console.Write("Please enter user's email : ");
            string email = Console.ReadLine();

            Console.Write("Please enter user's password : ");
            string password = Console.ReadLine();

            Console.Write("Please enter user's confirm password : ");
            string confirmPassword = Console.ReadLine();

            Console.WriteLine();

            if (
                UserValidation.IsValidLastName(lastName) &
                UserValidation.IsValidEmail(email) &
                //UserValidation.IsValidPassword(password, confirmPassword) &  //&& -> shirt cut circuit
                !UserValidation.IsUserExist(email)
               )
            {
                User user = UserRepository.AddUser(firstName, lastName, email, password);
                Console.WriteLine($"User added to system, his/her details are : {user.GetInfo()}");
            }
        }


        private static string GetFirstName()
        {
            Console.Write("Please enter user's name : ");
            string firstName = Console.ReadLine();

            while (!UserValidation.IsValidFirstName(firstName))
            {
                Console.Write("Please enter correct user's name : ");
                firstName = Console.ReadLine();
            }

            return firstName;
        }

        public static void Login()
        {
            Console.Write("Please enter user's email : ");
            string email = Console.ReadLine();

            Console.Write("Please enter user's password : ");
            string password = Console.ReadLine();

            if (UserRepository.IsUserExistByEmailAndPassword(email, password))
            {
                User user = UserRepository.GetUserByEmail(email);
                Console.WriteLine($"User successfully authenticated : {user.GetInfo()}");

                if (user is Admin)
                {
                    Dashboard.AdminPanel(email);
                }

                else if (user is User)
                {
                    Dashboard.UserPanel(email);
                }

                else
                {
                    Console.WriteLine();
                }
            }

            else
            {
                Console.WriteLine();
            }
        }


    }
}