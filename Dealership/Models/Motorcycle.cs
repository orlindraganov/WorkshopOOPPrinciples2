using System;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IVehicle, IMotorcycle
    {
        public Motorcycle(string make, string model, decimal price, string category)
        {
        }

        public string Category => throw new NotImplementedException();
    }
}
