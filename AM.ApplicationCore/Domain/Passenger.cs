using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public int PassportNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int TelNumber { get; set; }
        public override string ToString()
        {
            return "FirstName: " + FirstName + " LastName: " + LastName + " date of Birth: " + BirthDate + " Passport Number: " + PassportNumber + " Phone Number: " + TelNumber + " Email Address: " + EmailAddress;
        }

        public bool CheckProfile(string firstName, string lastName)
        {
            return this.FirstName == firstName && this.LastName == lastName;
        }

        public bool CheckProfile(string firstName, string lastName, string email)
        {
            if (email != null)
                return FirstName == firstName && LastName == lastName &&
                EmailAddress == email;
            else
                return FirstName == firstName && LastName == lastName;
        }

        public virtual void PassangerType()
        {
            Console.WriteLine("I am a Passenger");

        }
    }
}
