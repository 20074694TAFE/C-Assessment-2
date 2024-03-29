﻿using System;

namespace Car_App
{
    public class Car
    {
        private string regoNumber;
        private Make carMake;
        private Model carModel;
        private int carYear;
        private float price;
        public string photoFilename;

        public string RegoNumber
        {
            get
            {
                return regoNumber;
            }
            set
            {
                if(value.Length == 8)
                {
                    regoNumber = value.ToUpper();
                }
                else
                {
                    throw new ArgumentException("Length of rego number must be 8.");
                }
            }
        }

        public Make CarMake
        {
            get
            {
                return carMake;
            }
            set
            {
                if (value == Make.None)
                {
                    throw new ArgumentOutOfRangeException("Car make cannot be set to None.");
                }
                carMake = value;
            }
        }
        
        public Model CarModel
        {
            get
            {
                return carModel;
            }
            set
            {
                if(value == Model.None)
                {
                    throw new ArgumentOutOfRangeException("Car model cannot be set to None.");
                }
                carModel = value;
            }
        }

        public int CarYear
        {
            get
            {
                return carYear;
            }
            set
            {
                if(value < 1900)
                {
                    throw new ArgumentOutOfRangeException("Car year must be greater than 1900.");
                }
                else
                {
                    carYear = value;
                }
            }
        }

        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be a negative value.");
                }
                else
                {
                    Math.Round(value, 2);
                    price = value;
                }
                
            }
        }

        
        /// <summary>
        /// Default Constructor - Creates new Car object with default values.
        /// </summary>
        public Car()
        {
            RegoNumber = "10002GFD";
            CarMake = Make.White;
            CarModel = Model.Sedan;
            CarYear = 1950;
            Price = 20000.00f;
            photoFilename = "";
        }

        /// <summary>
        /// Copy Constructor - Creates new Car object with values set to Car input.
        /// </summary>
        public Car(Car car)
        {
            RegoNumber = car.RegoNumber;
            CarMake = car.CarMake;
            CarModel = car.CarModel;
            CarYear = car.CarYear;
            Price = car.Price;
            photoFilename = car.photoFilename;
        }

        /// <summary>
        /// Input Constructor - Creates new Car object with input values, requires ALL values.
        /// </summary>
        /// <param name="regoNumber">8 letter string, will throw exception otherwise.</param>
        /// <param name="carMake"></param>
        /// <param name="carModel"></param>
        /// <param name="carYear">Must be between 1900 and 2022, will throw exception otherwise.</param>
        /// <param name="price">Must be greater than 0, will throw exception otherwise.</param>
        public Car(string regoNumber, Make carMake, Model carModel, 
            int carYear, float price)
        {
            RegoNumber = regoNumber;
            CarMake = carMake;
            CarModel = carModel;
            CarYear = carYear;
            Price = price;
            photoFilename = "./images/" + CarModel.ToString() + "/" + CarMake.ToString() + ".png"; 
        }

        public override string ToString()
        {
            return RegoNumber + " " + CarMake + " " + CarModel + " " + CarYear + " " + Price;
        }
    }

    public enum Make
    {
        White,
        Black,
        Grey,
        Red,
        Blue,
        Yellow,
        None
    }

    public enum Model
    {
        SUV,
        Truck,
        Sedan,
        Coupe,
        SportsCar,
        HatchBack,
        Convertible,
        None
    }
}
