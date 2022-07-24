using AuthenticationWithClie.ApplicationLogic;
using System;

namespace AuthenticationWithClie.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our website!");
            Console.WriteLine();

            Console.WriteLine("Available Commands :");
            Console.WriteLine("/register");
            Console.WriteLine("/login");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Please enter command : ");
                string command = Console.ReadLine();

                if (command == "/register")
                {
                    Authentication.Register();
                }

                else if (command == "/login")
                {
                    Authentication.Login();
                }

                else if (command == "/exit")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Command not found!");
                }
            }
        }
    }
}