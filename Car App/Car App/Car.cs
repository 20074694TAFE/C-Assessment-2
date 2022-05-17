using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_App
{
    class Car
    {
        private string regoNumber;
        private Make carMake;
        private Model carModel;
        private int carYear;
        private float price;
        string photoFilename;

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
                    throw new ArgumentException();
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
                if(value >= 1900)
                {
                    throw new ArgumentOutOfRangeException();
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
                    throw new ArgumentOutOfRangeException();
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
            CarModel = Model.Sudan;
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
            photoFilename = ""; //TODO: Add filepath based on make and model.
        }

        public override string ToString()
        {
            return RegoNumber + " " + CarMake + " " + CarModel + " " + CarYear + " " + Price;
        }
    }

    enum Make
    {
        White,
        Black,
        Grey,
        Red,
        Blue,
        Yellow
    }

    enum Model
    {
        SUV,
        Truck,
        Sudan,
        Coupe,
        StationWagon,
        SportsCar,
        HatchBack,
        Convertible
    }
}
