using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; } 
        [Display(Name = "Date of Birth"),DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Key]
        [StringLength(7, ErrorMessage = "the PassportNumber require 7 caracters")]
        public string? PassportNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public string? EmailAddress { get; set; }
        [MinLength(3, ErrorMessage = "Invalid First name ! Length < 3")]
        [MaxLength(25, ErrorMessage = "Invalid First name ! Length > 25")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "Tel number must contain 8 digits")]
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
