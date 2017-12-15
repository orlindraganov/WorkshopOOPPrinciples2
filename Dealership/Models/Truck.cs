using System;
using Dealership.Contracts;
using Dealership.Common.Enums;
using Bytes2you.Validation;

namespace Dealership.Models
{
    public class Truck : Vehicle, IVehicle, ITruck, ICommentable, IPriceable
    {
        private const VehicleType typeConst = VehicleType.Truck;

        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) : base(make, model, price)
        {
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            set
            {
                Guard.WhenArgument(value, "Truck WeightCapacity").IsLessThan(0).IsGreaterThan(100).Throw();
                this.weightCapacity = value;
            }
        }

        protected override VehicleType TypeConst
        {
            get
            {
                return typeConst;
            }
        }
    }
}
