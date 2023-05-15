// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;

Plane plane1 = new Plane();
plane1.PlaneId = 1;
plane1.Capacity = 300;
plane1.ManufactureDate = new DateTime(2022, 09, 23);
plane1.PlaneType = PlaneType.Airbus;
Console.WriteLine(plane1.ToString());


Plane plane2 = new Plane(PlaneType.Airbus, 500, DateTime.Now);
Console.WriteLine(plane2.ToString());


Plane p3 = new Plane()
{ Capacity = 500, PlaneType = PlaneType.Airbus, ManufactureDate = DateTime.Now };
Console.WriteLine(p3.ToString());