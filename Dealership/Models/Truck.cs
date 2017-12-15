using Dealership.Contracts;

namespace Dealership.Models
{
    public class Truck : Vehicle, IVehicle, ITruck
    {
        public Truck(string make, string model, decimal price, int weightCapacity)
        {
        }
    }
}
