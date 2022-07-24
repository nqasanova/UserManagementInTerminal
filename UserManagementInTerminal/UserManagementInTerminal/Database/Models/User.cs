using AuthenticationWithClie.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Database.Models;

namespace AuthenticationWithClie.Database.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Report> Report { get; set; }
        public DateTime RegistrationDate { get; } = DateTime.Now;

        public User(string firstName, string lastName, string email, string password, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = id;
        }

        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = UserRepository.IdCounter;
        }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public User(List<Report> report)
        {
            Report = report;
        }

        public virtual string GetInfo()
        {
            return $"First name : {FirstName}, Last name : {LastName}, Email : {Email}";
        }
    }
}