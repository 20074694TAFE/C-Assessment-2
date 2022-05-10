using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_App
{
    class Car
    {
        int regoNumber;
        Make carMake;
        Model carModel;
        private int carYear;
        private float price;
        string photoFilename;

        public int RegoNumber
        {
            get
            {
                return regoNumber;
            }
            set
            {
                regoNumber = value;
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
                Type t = value.GetType();
                if (t == typeof(Model)){
                    carModel = value;
                }
                else
                {
                    carModel = Model.Sudan;
                }
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
                    carYear = value;
                }
                else
                {
                    carYear = 1900;
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
                    price = 0;
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
            regoNumber = 1000;
            carMake = Make.White;
            carModel = Model.Sudan;
            CarYear = 1950;
            Price = 20000.00f;
            photoFilename = "";
        }

        /// <summary>
        /// Copy Constructor - Creates new Car object with values set to Car input.
        /// </summary>
        public Car(Car car)
        {
            regoNumber = car.regoNumber;
            carMake = car.carMake;
            carModel = car.carModel;
            CarYear = car.CarYear;
            Price = car.Price;
            photoFilename = car.photoFilename;
        }

        /// <summary>
        /// Input Constructor - Creates new Car object with input values, requires ALL values.
        /// </summary>
        /// <param name="regoNumber"></param>
        /// <param name="carMake"></param>
        /// <param name="carModel"></param>
        /// <param name="CarYear"></param>
        /// <param name="Price"></param>
        /// <param name="photoFilename"></param>
        public Car(int regoNumber, Make carMake, Model carModel, 
            int CarYear, float Price, string photoFilename)
        {
            this.regoNumber = regoNumber;
            this.carMake = carMake;
            this.carModel = carModel;
            this.CarYear = CarYear;
            this.Price = Price;
            this.photoFilename = photoFilename;
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
