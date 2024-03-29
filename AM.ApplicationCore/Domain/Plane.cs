﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {
        public int PlaneId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Capacity must be a positive integer")]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }
        virtual public IList<Flight>? Flights { get; set; }
        public override string ToString()
        {
            return "PlaneId: " + PlaneId + " Plane Type: " + PlaneType + " Manufacture Date: " + ManufactureDate + " Capacity: " + Capacity;
        }
        public Plane () { }

        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            PlaneType = pt;
            Capacity = capacity;
            ManufactureDate = date;
        }

    }
}
