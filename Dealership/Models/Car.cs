using System;
using Dealership.Contracts;
using Bytes2you.Validation;
using Dealership.Common.Enums;

namespace Dealership.Models
{
    public class Car : Vehicle, IVehicle, ICar, ICommentable, IPriceable
    {
        private const VehicleType typeConst = VehicleType.Car;

        private int seats;

        public Car(string make, string model, decimal price, int seats) : base(make, model, price)
        {
            this.Seats = seats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            set
            {
                Guard.WhenArgument(value, "Car seats").IsLessThan(0).IsGreaterThan(10).Throw();
                this.seats = value;
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
