using AuthenticationWithClie.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationWithClie.Database.Models
{
    public class Admin : User
    {
        public static int row = 1;
        public int Row { get; set; }

        public Admin(string firstName, string lastName, string email, string password, int id)
            : base(firstName, lastName, email, password, id)
        {
            Row = row++;
        }

        public Admin(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password)
        {
            Row = row++;
        }

        public Admin(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }

        public override string GetInfo()
        {
            return $"Row No : {Row}, User Id : {Id}, First name : {FirstName}, Last name :  {LastName}, Email :  {Email}, Registration Date : {RegistrationDate}";
        }
    }
}