using System;
using System.Collections.Generic;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Bytes2you.Validation;
using System.Text.RegularExpressions;

namespace Dealership.Models
{
    public class User : IUser
    {
        private const string usernamePattern = "^[A-Za-z0-9]+$";
        private const string passwordPattern = "^[A-Za-z0-9@*_-]+$";

        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private Role role;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = (Role)Enum.Parse(typeof(Role), role);
            this.Vehicles = new List<IVehicle>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                Guard.WhenArgument(value, "Username").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "Username Length").IsLessThan(2).IsGreaterThan(15).Throw();

                var isMatchSuccessfull = Regex.Match(value, usernamePattern).Success;
                Guard.WhenArgument(isMatchSuccessfull, "Username pattern").IsFalse().Throw();

                this.username = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                Guard.WhenArgument(value, "User First Name").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "User First Name Length").IsLessThan(2).IsGreaterThan(15).Throw();
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                Guard.WhenArgument(value, "User Last Name").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "User Last Name Length").IsLessThan(2).IsGreaterThan(15).Throw();

                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                Guard.WhenArgument(value, "User Password").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "User Password Length").IsLessThan(6).IsGreaterThan(15).Throw();

                var isMatchSuccessfull = Regex.Match(value, passwordPattern).Success;
                Guard.WhenArgument(isMatchSuccessfull, "Password pattern").IsFalse().Throw();

                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }
            set
            {
                this.role = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
            set
            {
                this.vehicles = value;
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            this.Vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            Guard.WhenArgument(vehicleToRemoveComment.Comments.Contains(commentToRemove), "Comments contain comment").IsFalse().Throw();
            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            Guard.WhenArgument(this.Vehicles.Contains(vehicle), "User Vehicles Contain").IsFalse().Throw();
            this.Vehicles.Add(vehicle);
        }
    }
}
