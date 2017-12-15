using System;
using Dealership.Contracts;
using Dealership.Common.Enums;
using Bytes2you.Validation;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IVehicle, IMotorcycle, ICommentable, IPriceable
    {
        private const VehicleType typeConst = VehicleType.Motorcycle;

        private string category;

        public Motorcycle(string make, string model, decimal price, string category) : base(make, model, price)
        {
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                Guard.WhenArgument(value, "Motorcycle category").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Motorcycle category length").IsLessThan(1).IsGreaterThan(10).Throw();

                this.category = value;
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
