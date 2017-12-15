using System;
using System.Collections.Generic;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Bytes2you.Validation;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle, ICommentable, IPriceable
    {
        private int wheels;
        private VehicleType type;
        private string make;
        private string model;
        private IList<IComment> comments;
        private decimal price;

        public Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Type = TypeConst;
            this.Wheels = (int)this.Type;
            this.comments = new List<IComment>();
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
            private set
            {
                this.wheels = value;
            }
        }

        public VehicleType Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                Guard.WhenArgument(value, "Vehicle make").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Vehicle make length").IsLessThan(2).IsGreaterThan(15).Throw();

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                Guard.WhenArgument(value, "Vehicle model").IsNull().Throw();
                Guard.WhenArgument(value.Length, "Vehicle model length").IsLessThan(2).IsGreaterThan(15).Throw();

                this.model = value;
            }
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                Guard.WhenArgument(value, "Vehicle price").IsLessThan(0).IsGreaterThan(100000).Throw();
                this.price = value;
            }
        }

        protected abstract VehicleType TypeConst
        {
            get;
        }
    }
}
