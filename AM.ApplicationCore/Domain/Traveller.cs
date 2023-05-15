using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    internal class Traveller : Passenger
    {
        public string? HealthInformation { get; set; }
        public string? Nationality { get; set; }
        public override string ToString()
        {
            return "HealthInformation: " + HealthInformation + " Nationality: " + Nationality;
        }

        public override void PassangerType()
        {
            base.PassangerType();
            Console.WriteLine("and I'm a traveller");
        }
    }
}
