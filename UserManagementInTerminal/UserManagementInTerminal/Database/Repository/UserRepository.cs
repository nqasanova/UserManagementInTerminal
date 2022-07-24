using AuthenticationWithClie.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Database.Models;

namespace AuthenticationWithClie.Database.Repository
{
    class UserRepository
    {
        private static int _idCounter;
        private static List<Report> reports;

        public static int IdCounter
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }
        }


        private static List<User> Users { get; set; } = new List<User>()
        {
            new Admin("Mahmood", "Garibov", "qaribovmahmud@gmail.com", "123321"),
            new User("Natavan", "Hasanova", "natavanhasanova@gmail.com", "123321"),
        };

        private static List<Report> Reports { get; set; } = new List<Report>()
        {
            new Report("natavanhasanova@gmail.com", "mahmoodgaribovgmail.com", "Text")
        };

        public static User AddUser(string firstName, string lastName, string email, string password)
        {
            User user = new User(firstName, lastName, email, password, IdCounter);
            Users.Add(user);
            return user;
        }

        public static User AddAdmin(string firstName, string lastName, string email, string password, int id)
        {
            User user = new User(firstName, lastName, email, password, id);
            Users.Add(user);
            return user;
        }

        public static User AddUser(User user)
        {
            Users.Add(user);
            return user;
        }

        public static User AddAdmin(Admin admin)
        {
            Users.Add(admin);
            return admin;
        }

        public static bool IsUserExistsByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }

            return false;
        }

        public static User GetUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

        public static bool IsUserExistByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }

            return false; ;
        }

        public static User GetUserByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }

            return null;
        }

        public static Admin GetAdminByEmail(string email)
        {
            foreach (Admin admin in Users)
            {
                if (admin.Email == email)
                {
                    return admin;
                }
            }

            return null;
        }
        public static void Remove(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                { }
                Users.Remove(user);
            }
        }

        public static Report AddReport(string reporter, string receiver, string, string text)
        {
            List<Report> reports = new List<Report>();
            Report report = new Report(reporter, receiver, text);
            reports.Add(report);
            return report;
        }

        public static void DeleteUser(User user)
        {
            Users.Remove(user);
        }

        public static void DeleteAdmin(Admin admin)
        {
            Users.Remove(admin);
        }

        public static List<User> GetAll()
        {
            return Users;
        }

        public static int GetUserCount()
        {
            return Users.Count;
        }

        public static List<Report> GetReports()
        {
            return reports;
        }

        public static User UpdateUser(string email, User user)
        {
            User enteredUser = UserRepository.GetUserByEmail(email);

            enteredUser.FirstName = user.FirstName;
            enteredUser.LastName = user.LastName;

            return enteredUser;
        }

        public static User UpdateAdmin(string email, Admin admin)
        {
            User enteredAdmin = UserRepository.GetUserByEmail(email);
            enteredAdmin.FirstName = admin.FirstName;
            enteredAdmin.LastName = admin.LastName;

            return enteredAdmin;
        }
    }
}
