using System;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Car : Vehicle, IVehicle, ICar
    {
        public Car(string mark, string model, decimal price, int seats)
        {
        }

        public int Seats => throw new NotImplementedException();
    }
}
