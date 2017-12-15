using System;
using System.Collections.Generic;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        public int Wheels => throw new NotImplementedException();

        public VehicleType Type => throw new NotImplementedException();

        public string Make => throw new NotImplementedException();

        public string Model => throw new NotImplementedException();

        public IList<IComment> Comments => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();
    }
}
