using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public List<DateTime> GetFlightDatesA(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == destination)
                {
                    dates.Add(Flights[i].FlightDate);
                }
            }
            return dates;
        }


        //simple foreach we use it for IList ==>
        public List<DateTime> GetFlightDatesB(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Flight f in Flights)

                if (f.Destination.Equals(destination))
                    dates.Add(f.FlightDate);
            return dates;
        }


        //we can't use .ForEach in IList ( if you want to use it convert it to a list by => Flights.ToList().ForEach 
        public List<DateTime> GetFlightDates2(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            Flights.ForEach(f =>
            {
                if (f.Destination == destination)
                {
                    dates.Add(f.FlightDate);
                };
            }
            );
            return dates;
        }

        // using Enumerable
        public IEnumerable<DateTime> GettFlightDates(string destination)
        {

            foreach (Flight flight in Flights)
            {
                if (flight.Destination == destination)
                {

                    yield return flight.FlightDate;
                }
            }

        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }
        }


        //LINQ Method 1 (Requete) :
        public IList<DateTime> GetFlightDateslinq(string destination)
        {
            var query = from f in Flights where f.Destination == destination select f.FlightDate;
            return query.ToList();
        }

        //LINQ Method 2 (Method): 
        public IList<DateTime> GetFlightDateslinq2(string destination)
        {
            var query = Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate);
            return query.ToList();

            //return Flights.Where(x => x.Destination == destination).Select(x => x.FlightDate).ToList();
        }

        // LINQ Requete
        public void ShowFlightDetails(Plane plane)
        {
            var req = from f in Flights
                      where (f.Plane == plane)
                      select new { f.FlightDate, f.Destination };
            foreach (var item in req)
            {
                Console.WriteLine(item.Destination + " " + item.FlightDate);
            }
        }

        // LINQ Des method
        public void ShowFlightDetails2(Plane plane)
        {

            var req = Flights.Where(f => f.Plane == plane).Select(f => new { f.FlightDate, f.Destination });
            foreach (var item in req)
            {
                Console.WriteLine(item.Destination + " " + item.FlightDate);
            }
        }

        // le nombre des vols programmmes pour une semaine a partire de startDate
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            return Flights.Where(f => f.FlightDate > startDate && ((f.FlightDate - startDate).TotalDays < 7)).Count();
        }

        // La moyenne == Average ( tdhaker el Select zeyda a3mel .Where.Average toul)
        public double DurationAverage(string destination)
        {
            //var query = from f in Flights
            //where f.Destination == destination select f;
            //return query.Average (f=>f.EstimatedDuration);
            var query = Flights
            .Where(f => f.Destination == destination)
            .Average(f => f.EstimatedDuration);
            return query;
        }

        // LINQ Method 1 (Requete) :
        public IList<Flight> OrderedDurationFlights()
        {
            var query = from f in Flights orderby f.EstimatedDuration descending select f;
            return query.ToList();
        }
        // LINQ Method 2 (Method): =====> this
        public IList<Flight> OrderedDurationFlights2()
        {
            return Flights.OrderByDescending(f => f.FlightDate).ToList();
        }


        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            var query = (from f in Flights where f.FlightId == flight.FlightId select f).Single();
            return query.Passengers.OfType<Traveller>().ToList().OrderBy(p => p.BirthDate).Take(3).ToList();
        }

        public List<Traveller> SeniorTravellers2(Flight flight)
        {
            var query = from x in flight.Passengers.OfType<Traveller>()
                        orderby x.BirthDate ascending
                        select x.Nationality;
            return (List<Traveller>)query.Take(3);
        }





    }
}
