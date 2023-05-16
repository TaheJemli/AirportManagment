using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string? Destination { get; set; }
        public string? Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public IList<Passenger>? Passengers { get; set; }
        public Plane? Plane { get; set; }

        public string Airline { get; set; }

        public override string ToString()
        {
            return "FlightId: " + FlightId + " FlightDate: " + FlightDate + " EstimatedDuration: " + EstimatedDuration + " EffectiveArrival: " + EffectiveArrival + " Departure: " + Departure + " Destination: " + Destination;
        }




    }
}
