using AuthenticationWithClie.ApplicationLogic.Validations;
using AuthenticationWithClie.Database.Models;
using AuthenticationWithClie.Database.Repository;
using AuthenticationWithClie.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Database.Models;

namespace AuthenticationWithClie.ApplicationLogic
{
    public static partial class Dashboard
    {
        public static void AdminPanel(string email)
        {
            Console.WriteLine("Available commands : ");

            Console.WriteLine("/add-user");
            Console.WriteLine("/update-user");
            Console.WriteLine("/remove-user");
            Console.WriteLine("/reports");
            Console.WriteLine("/add-admin");
            Console.WriteLine("/make-admin");
            Console.WriteLine("/show-admins");
            Console.WriteLine("/update-admin");
            Console.WriteLine("/remove-admin");
            Console.WriteLine("/logout");

            Console.WriteLine();
            Console.WriteLine("Please enter a command : ");
            string command = Console.ReadLine();

            if (command == "/add-user")
            {
                Authentication.Register();
            }

            else if (command == "/update-user")
            {
                Console.WriteLine("Please enter user's email you want to update : ");
                string updatedEmail = Console.ReadLine();

                User updatedUser = UserRepository.GetUserByEmail(email);

                if (updatedUser == null)
                {
                    Console.WriteLine("User is not found according to the entered email!");
                }

                if (updatedUser.Email == email)
                {
                    Console.WriteLine("Your email is already an admin!");
                }

                else
                {
                    if (updatedUser is User)
                    {
                        Admin updateUser = new Admin(UserValidation.GetFirstName(), UserValidation.GetLastName());
                        UserRepository.UpdateAdmin();
                    }
                }
            }

            else if (command == "/remove-user")
            {
                Console.WriteLine("Please enter user's email to remove him/her : ");
                string userEmail = Console.ReadLine();

                User user = UserRepository.GetUserByEmail(userEmail);

                if (user == null)
                {
                    Console.WriteLine("Could not find user according to the entered email!");
                }

                else if (user is Admin)
                {
                    Console.WriteLine("The user according to the entered email is an admin!");
                }

                else
                {
                    UserRepository.DeleteUser(user);
                    Console.WriteLine("User deleted successfully!");
                }
            }

            else if (command == "/reports")
            {
                List<Report> report = UserRepository.GetReports();

                foreach (Report reports in report)
                {
                    Console.WriteLine(reports.GetAdminReportInfo());
                }
            }

            else if (command == "/add-admin")
            {
                Admin admin = new Admin(UserValidation.GetFirstName(), UserValidation.GetLastName(), UserValidation.GetEmail(), UserValidation.GetPassword());
                UserRepository.AddUser(admin);

                Console.WriteLine($"Admin added successfully {admin.GetInfo()}");
            }

            else if (command == "/show-admins")
            {
                List<User> admin = UserRepository.GetAll();

                foreach (User admins in admin)
                {
                    if (admins is Admin)
                    {
                        Console.WriteLine(((Admin)admins).GetInfo());
                    }
                }
            }

            else if (command == "/updated-admin")
            {
                Console.WriteLine("Please enter email to update admin : ");
                string updatedAdmin = Console.ReadLine();

                User admin = UserRepository.GetUserByEmail(updatedAdmin);

                if (admin.Email == email)
                {
                    Console.WriteLine("You have entered email which belongs to the admin you have entered with!");
                }

                else if (admin == null)
                {
                    Console.WriteLine("Admin not found according to the entered email! Please enter email again : ");
                }

                else
                {
                    if (admin is Admin)
                    {
                        Admin updateAdmin = new Admin(UserValidation.GetFirstName(), UserValidation.GetLastName());
                        UserRepository.UpdateAdmin(updatedAdmin, updateAdmin);

                        Console.WriteLine("Admin is updated!");
                    }

                    else if (admin is User)
                    {
                        Console.WriteLine("The email's owner is a user!");
                    }
                }
            }

            else if (command == "/remove-admin")
            {
                Console.WriteLine("Please enter user's email to remove from admin : ");
                string adminEmail = Console.ReadLine();

                Admin admin = UserRepository.GetAdminByEmail(adminEmail);

                if (admin.Email == adminEmail)
                {
                    Console.WriteLine("The user found with entered email is a user! Please enter email again : ");
                }

                else if (admin == null)
                {
                    Console.WriteLine("Admin not found according to the entered email!");
                }

                else
                {
                    if (admin is User)
                    {
                        Console.WriteLine("Entered user name is a user!");
                    }

                    else if (admin is Admin)
                    {
                        UserRepository.DeleteAdmin(admin);
                        Console.WriteLine("Admin is deleted from the system!");
                    }
                }
            }

            if (command == "/make-admin")
            {
                Console.WriteLine("Please enter user's email : ");
                string userEmail = Console.ReadLine();

                User user = UserRepository.GetUserByEmail(email);

                if (user == null)
                {
                    Console.WriteLine("Could not found user by email!");
                }

                else
                {
                    UserRepository.DeleteUser(user);
                    Admin admin = new Admin(user.FirstName, user.LastName, user.Email, user.Password, user.Id);
                    UserRepository.AddUser(admin);
                }
            }

            else if (command == "/show-users")
            {
                List<User> User = UserRepository.GetAll();

                foreach (User users in User)
                {
                    if (users is User)
                    {
                        Console.WriteLine(users.GetInfo());
                    }
                }
            }

            else if (command == "/logout")
            {
                Program.Main(new string[] { });
                break;
            }

            else
            {
                Console.WriteLine("Command not found!");
            }
        }

        public static partial class Dashboard
        {
            public static void UserPanel()
            {
                User user = UserRepository.GetUserByEmail(email);

                Console.WriteLine($"User successfully joined : {user.GetInfo()}");

                while (true)
                {
                    Console.WriteLine("Available Commands : ");
                    Console.WriteLine("/update-info");
                    Console.WriteLine("/report-user");
                    Console.WriteLine("/logout");
                    string command = Console.ReadLine();

                    if (command == "/update-info")
                    {
                        if (user.Email == email)
                        {
                            User updateUser = new User(UserValidation.GetFirstName(), UserValidation.GetLastName());
                            UserRepository.UpdateUser(email, updateUser);
                        }
                    }

                    else if (command == "/report-user")
                    {
                        Console.WriteLine("Please enter user's email you want to report : ");
                        string reportEmail = Console.ReadLine();

                        Console.WriteLine("Please enter report : ");
                        string reportText = Console.ReadLine();

                        User reporter = UserRepository.GetUserByEmail(reportEmail);

                        if (reporter.Email == email)
                        {
                            Console.WriteLine("User cannot report himself/herself!");
                        }

                        else
                        {
                            Report report = UserRepository.AddReport(email, reporter.Email, reportText);
                        }
                    }

                    else if (command == "/logout")
                    {
                        Program.Main(new string[] { });
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
}