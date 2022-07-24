using AuthenticationWithClie.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AuthenticationWithClie.ApplicationLogic.Validations
{
    public partial class UserValidation
    {
        public static bool IsValidFirstName(string firstName)
        {
            Regex regex = new Regex(@"^(?=[A-Z]{1})([A-Za-z]{3,30})$");

            if (regex.IsMatch(firstName))
            {
                return true;
            }

            Console.WriteLine("Daxil etdiyiniz ad yanlışdır, adın yalnız hərflərdən ibarət olduğuna, ilk hərfin böyük olduğuna və uzunluğunun 3 dən böyük, 30 - dan kiçik olduğuna əmin olun.");

            return false;
        }

        public static bool IsValidLastName(string lastName)
        {
            Regex regex = new Regex(@"^(?=[A-Z]{1})([A-Za-z]{3,30})$");

            if (regex.IsMatch(lastName))
            {
                return true;
            }

            Console.WriteLine("Daxil etdiyiniz soyad yanlışdır, adın yalnız hərflərdən ibarət olduğuna, ilk hərfin böyük olduğuna və uzunluğunun 3 dən böyük, 30 - dan kiçik olduğuna əmin olun.");

            return false;
        }

        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9]{10,30}@code\.edu\.az$");

            if (regex.IsMatch(email))
            {
                return true;
            }

            Console.WriteLine("Daxil etdiyiniz email yanlis formatdadir");

            return false;
        }

        public static bool IsPasswordsMatch(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }

            Console.WriteLine("Password is not match");

            return false;

        }

        public static bool IsValidPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[0-9])(?=.*[A-Z])(?=[a-zA-Z0-9]{8,}).*[a-z]$");

            if (regex.IsMatch(password))
            {
                return true;
            }

            Console.WriteLine("Daxil etdiyiniz sifre telebleri odemir");

            return false;
        }

        public static bool IsUserExist(string email)
        {
            if (UserRepository.IsUserExistsByEmail(email))
            {
                Console.WriteLine("User already exists");

                return true;
            }

            return false;
        }
    }

    public partial class UserValidation
    {
        public static string GetFirstName()
        {
            bool IsExceptionValid;
            string firstName = null;

            do
            {

                try
                {
                    Console.Write("Please enter first name : ");
                    firstName = Console.ReadLine();

                    if (firstName == "null")
                    {
                        throw new Exception();
                    }

                    IsExceptionValid = false;
                }

                catch (Exception)
                {

                    IsExceptionValid = true;
                    Console.WriteLine("There is an error!");
                }

            }

            while (IsExceptionValid || !UserValidation.IsValidFirstName(firstName));
            return firstName;
        }
        public static string GetLastName()
        {
            bool IsExceptionValid;
            string lastName = null;

            do
            {

                try
                {
                    Console.Write("Please enter last name : ");
                    lastName = Console.ReadLine();

                    if (lastName == "null")
                    {
                        throw new Exception();
                    }

                    IsExceptionValid = false;
                }
                catch (Exception)
                {

                    IsExceptionValid = true;
                    Console.WriteLine("There is an error!");
                }

            }

            while (IsExceptionValid || !UserValidation.IsValidLastName(lastName));
            return lastName;
        }

        public static string GetEmail()
        {
            Console.Write("Please enter email : ");
            string email = Console.ReadLine();

            while (!UserValidation.IsValidEmail(email) || !UserValidation.IsUserExist(email))
            {
                Console.Write("Please enter email again : ");
                email = Console.ReadLine();
            }

            return email;
        }

        public static string GetPassword()
        {
            string password = null;
            bool isExceptionValid;

            do
            {
                try
                {

                    Console.Write("Please enter password : ");
                    password = Console.ReadLine();

                    if (password == "null")
                    {
                        throw new Exception();
                    }

                    isExceptionValid = false;
                }
                catch (Exception)
                {
                    isExceptionValid = true;
                    Console.WriteLine("There is an error"); ;
                }

            }
            while (isExceptionValid || !UserValidation.IsValidPassword(password));

            string confirmPassword = null;

            do
            {
                try
                {

                    Console.Write("Please enter password again : ");
                    confirmPassword = Console.ReadLine();

                    if (confirmPassword == "null")
                    {
                        throw new Exception();
                    }

                    isExceptionValid = false;
                }

                catch
                {
                    isExceptionValid = true;
                    Console.WriteLine("There is an error!");
                }

            }

            while (isExceptionValid || !UserValidation.IsPasswordsMatch(password, confirmPassword));
            return password;
        }
    }

}